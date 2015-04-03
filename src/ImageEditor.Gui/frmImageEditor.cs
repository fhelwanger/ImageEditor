using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor.Gui
{
    public partial class frmImageEditor : Form
    {
        private Bitmap bitmap = null;

        public frmImageEditor()
        {
            InitializeComponent();
        }

        private void mnuAbrirEscalaCinza_Click(object sender, EventArgs e)
        {
            using (var j = new OpenFileDialog())
            {
                j.Filter = "Imagens | *.jpg; *.jpeg; *.png; *.bmp; *.gif | Todos os arquivos| *";
                
                if (j.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var bitmap = new Bitmap(Image.FromFile(j.FileName));
                        
                        var manipulador = new ManipuladorImagem();
                        manipulador.CarregarImagem(bitmap);
                        manipulador.TransformarEscalaCinza();

                        CarregarImagem(manipulador.Imagem);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro ao abrir a imagem", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CarregarImagem(Bitmap bitmap)
        {
            this.bitmap = bitmap;
            picImagem.Image = this.bitmap;
        }

        private void mnuHistograma_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            var j = new frmHistograma();
            j.CarregarImagem(bitmap);
            j.Show();
        }

        private void mnuEstatisticas_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            var j = new frmEstatisticas();
            j.CarregarImagem(bitmap);
            j.Show();
        }

        private void mnuThreshold1_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a média recebem preto
            AplicarTransformacao((manipuladorImagem, estatisticasImagem) =>
            {
                var media = estatisticasImagem.CalcularMedia();

                manipuladorImagem.AbrirBytesImagem(bytes =>
                {
                    for (int i = 0; i < bytes.GetLength(0); i++)
                    {
                        for (int j = 0; j < bytes.GetLength(1); j += 3)
                        {
                            if (bytes[i, j] >= media)
                            {
                                bytes[i, j + 0] = 0;
                                bytes[i, j + 1] = 0;
                                bytes[i, j + 2] = 0;
                            }
                        }
                    }
                });
            });
        }

        private void mnuThreshold2_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a moda recebem 100
            AplicarTransformacao((manipuladorImagem, estatisticasImagem) =>
            {
                var moda = estatisticasImagem.CalcularModa();

                manipuladorImagem.AbrirBytesImagem(bytes =>
                {
                    for (int i = 0; i < bytes.GetLength(0); i++)
                    {
                        for (int j = 0; j < bytes.GetLength(1); j += 3)
                        {
                            if (bytes[i, j] >= moda)
                            {
                                bytes[i, j + 0] = 100;
                                bytes[i, j + 1] = 100;
                                bytes[i, j + 2] = 100;
                            }
                        }
                    }
                });
            });
        }

        private void mnuThreshold3_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a mediana recebem branco
            AplicarTransformacao((manipuladorImagem, estatisticasImagem) =>
            {
                var mediana = estatisticasImagem.CalcularMediana();

                manipuladorImagem.AbrirBytesImagem(bytes =>
                {
                    for (int i = 0; i < bytes.GetLength(0); i++)
                    {
                        for (int j = 0; j < bytes.GetLength(1); j += 3)
                        {
                            if (bytes[i, j] >= mediana)
                            {
                                bytes[i, j + 0] = 255;
                                bytes[i, j + 1] = 255;
                                bytes[i, j + 2] = 255;
                            }
                        }
                    }
                });
            });
        }

        private void mnuThreshold4_Click(object sender, EventArgs e)
        {
            // Valores menores que a média recebem 50
            AplicarTransformacao((manipuladorImagem, estatisticasImagem) =>
            {
                var media = estatisticasImagem.CalcularMedia();

                manipuladorImagem.AbrirBytesImagem(bytes =>
                {
                    for (int i = 0; i < bytes.GetLength(0); i++)
                    {
                        for (int j = 0; j < bytes.GetLength(1); j += 3)
                        {
                            if (bytes[i, j] < media)
                            {
                                bytes[i, j + 0] = 50;
                                bytes[i, j + 1] = 50;
                                bytes[i, j + 2] = 50;
                            }
                        }
                    }
                });
            });
        }

        private void mnuThreshold5_Click(object sender, EventArgs e)
        {
            // Valores maiores que a mediana recebem 255 e menores que a média recebem 0
            AplicarTransformacao((manipuladorImagem, estatisticasImagem) =>
            {
                var media = estatisticasImagem.CalcularMedia();
                var mediana = estatisticasImagem.CalcularMediana();

                manipuladorImagem.AbrirBytesImagem(bytes =>
                {
                    for (int i = 0; i < bytes.GetLength(0); i++)
                    {
                        for (int j = 0; j < bytes.GetLength(1); j += 3)
                        {
                            if (bytes[i, j] > mediana)
                            {
                                bytes[i, j + 0] = 255;
                                bytes[i, j + 1] = 255;
                                bytes[i, j + 2] = 255;
                            }
                            else if (bytes[i, j] < media)
                            {
                                bytes[i, j + 0] = 0;
                                bytes[i, j + 1] = 0;
                                bytes[i, j + 2] = 0;
                            }
                        }
                    }
                });
            });
        }

        private void AplicarTransformacao(Action<ManipuladorImagem, EstatisticasImagem> transformacao)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bitmap);

            var estatisticasImagem = new EstatisticasImagem();
            estatisticasImagem.CarregarImagem(bitmap);

            transformacao(manipuladorImagem, estatisticasImagem);

            picImagem.Image = manipuladorImagem.Imagem;
        }

        private bool ConsistirImagemSelecionada()
        {
            if (bitmap == null)
            {
                MessageBox.Show("Selecione uma imagem.", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
    }
}
