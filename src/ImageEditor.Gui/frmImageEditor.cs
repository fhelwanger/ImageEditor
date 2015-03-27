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
        private ManipuladorImagem manipuladorImagem = new ManipuladorImagem();
        private EstatisticasImagem estatisticasImagem = new EstatisticasImagem();

        public frmImageEditor()
        {
            InitializeComponent();
        }

        private void mnuAbrir_Click(object sender, EventArgs e)
        {
            using (var j = new OpenFileDialog())
            {
                j.Filter = "Imagens | *.jpg; *.jpeg; *.png; *.bmp; *.gif | Todos os arquivos| *";
                
                if (j.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        var bitmap = new Bitmap(Image.FromFile(j.FileName));
                        CarregarImagem(bitmap);
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
            manipuladorImagem.CarregarImagem(bitmap);
            manipuladorImagem.TransformarEscalaCinza();

            estatisticasImagem.CarregarImagem(bitmap);

            var menor125abaixoDiagSec = estatisticasImagem.ContarPixels((i, j, r, g, b) => r < 125 && i > (bitmap.Width - 1) - j);
            var maior125acimaDiagSec = estatisticasImagem.ContarPixels((i, j, r, g, b) => r > 125 && i < (bitmap.Width - 1) - j);

            picImagem.Image = bitmap;

            dgvEstatisticas.DataSource = new[] {
                new { Nome = "Média", Valor = estatisticasImagem.CalcularMedia() },
                new { Nome = "Mediana", Valor = estatisticasImagem.CalcularMediana() },
                new { Nome = "Moda", Valor = estatisticasImagem.CalcularModa() },
                new { Nome = "Variância", Valor = estatisticasImagem.CalcularVariancia() },
                new { Nome = "Pixels < 125 abaixo diag. sec.", Valor = menor125abaixoDiagSec },
                new { Nome = "Pixels > 125 acima diag. sec.", Valor = maior125acimaDiagSec }
            };
        }

        private void mnuHistograma_Click(object sender, EventArgs e)
        {
            if (manipuladorImagem.Imagem == null)
            {
                MessageBox.Show("Selecione uma imagem", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var j = new frmHistograma(estatisticasImagem.CalcularHistograma()))
            {
                j.ShowDialog();
            }
        }

        private void mnuThreshold1_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a média recebem preto
            
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

            CarregarImagem(manipuladorImagem.Imagem);
        }

        private void mnuThreshold2_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a moda recebem 100

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

            CarregarImagem(manipuladorImagem.Imagem);
        }

        private void mnuThreshold3_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a mediana recebem branco

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

            CarregarImagem(manipuladorImagem.Imagem);
        }

        private void mnuThreshold4_Click(object sender, EventArgs e)
        {
            // Valores menores que a média recebem 50

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

            CarregarImagem(manipuladorImagem.Imagem);
        }

        private void mnuThreshold5_Click(object sender, EventArgs e)
        {
            // Valores maiores que a mediana recebem 255 e menores que a média recebem 0

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

            CarregarImagem(manipuladorImagem.Imagem);
        }
    }
}
