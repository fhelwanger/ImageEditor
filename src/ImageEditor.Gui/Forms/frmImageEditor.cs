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
        private bool colorida;

        public frmImageEditor()
        {
            InitializeComponent();
        }

        private void mnuAbrirColorida_Click(object sender, EventArgs e)
        {
            var bitmap = AbrirImagem();

            if (bitmap == null)
            {
                return;
            }

            colorida = true;
            CarregarImagem(bitmap);
        }

        private void mnuAbrirEscalaCinza_Click(object sender, EventArgs e)
        {
            var bitmap = AbrirImagem();

            if (bitmap == null)
            {
                return;
            }

            var manipulador = new ManipuladorImagem();
            manipulador.CarregarImagem(bitmap);
            manipulador.TransformarEscalaCinza();

            colorida = false;
            CarregarImagem(manipulador.Imagem);
        }

        private void mnuFechar_Click(object sender, EventArgs e)
        {
            CarregarImagem(null);
        }

        private void mnuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private Bitmap AbrirImagem()
        {
            using (var j = new OpenFileDialog())
            {
                j.Filter = "Imagens | *.jpg; *.jpeg; *.png; *.bmp; *.gif | Todos os arquivos| *";

                if (j.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        return new Bitmap(Image.FromFile(j.FileName));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Houve um erro ao abrir a imagem", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return null;
        }

        private void CarregarImagem(Bitmap bitmap)
        {
            if (this.bitmap != null)
            {
                this.bitmap.Dispose();
            }

            this.bitmap = bitmap;
            picImagem.Image = this.bitmap;
        }

        private void TrocarImagem(Bitmap bitmap)
        {
            if (mnuAplicarOriginal.Checked)
            {
                picImagem.Image = bitmap;
            }
            else
            {
                CarregarImagem(bitmap);
            }
        }

        private void mnuThreshold1_Click(object sender, EventArgs e)
        {
            // Valores maiores ou iguais a média recebem preto
            AplicarThreshold((manipuladorImagem, estatisticasImagem) =>
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
            AplicarThreshold((manipuladorImagem, estatisticasImagem) =>
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
            AplicarThreshold((manipuladorImagem, estatisticasImagem) =>
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
            AplicarThreshold((manipuladorImagem, estatisticasImagem) =>
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
            AplicarThreshold((manipuladorImagem, estatisticasImagem) =>
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

        private void AplicarThreshold(Action<ManipuladorImagem, EstatisticasImagem> transformacao)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bitmap);

            var estatisticasImagem = new EstatisticasImagem();
            estatisticasImagem.CarregarImagem(bitmap);

            transformacao(manipuladorImagem, estatisticasImagem);

            TrocarImagem(manipuladorImagem.Imagem);
        }

        private void mnuTranslacao_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            using (var j = new frmTranslacao())
            {
                if (j.ShowDialog() == DialogResult.OK)
                {
                    var transformacoes = new TransformacoesImagem();
                    transformacoes.CarregarImagem(bitmap);
                    transformacoes.Transladar(j.Horizontal, j.Vertical);

                    TrocarImagem(transformacoes.Imagem);
                }
            }
        }

        private void mnuRedimensionar_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            using (var j = new frmRedimensionamento())
            {
                if (j.ShowDialog() == DialogResult.OK)
                {
                    var transformacoes = new TransformacoesImagem();
                    transformacoes.CarregarImagem(bitmap);

                    float horizontal = j.PercentualHorizontal / 100f;
                    float vertical = j.PercentualVertical / 100f;

                    transformacoes.Redimensionar(horizontal, vertical);

                    TrocarImagem(transformacoes.Imagem);
                }
            }
        }

        private void mnuRotacao_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            using (var j = new frmRotacao())
            {
                if (j.ShowDialog() == DialogResult.OK)
                {
                    var transformacoes = new TransformacoesImagem();
                    transformacoes.CarregarImagem(bitmap);
                    transformacoes.Rotacionar(j.TipoRotacao);

                    TrocarImagem(transformacoes.Imagem);
                }
            }
        }

        private void mnuEspelhamento_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemSelecionada())
            {
                return;
            }

            using (var j = new frmEspelhamento())
            {
                if (j.ShowDialog() == DialogResult.OK)
                {
                    var transformacoes = new TransformacoesImagem();
                    transformacoes.CarregarImagem(bitmap);
                    transformacoes.Espelhar(j.TipoEspelhamento);

                    TrocarImagem(transformacoes.Imagem);
                }
            }
        }

        private void mnuFiltroMedia_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaBaixa();
            filtros.CarregarImagem(bitmap);
            filtros.Media();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroMediana_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaBaixa();
            filtros.CarregarImagem(bitmap);
            filtros.Mediana();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroGauss_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaBaixa();
            filtros.CarregarImagem(bitmap);
            filtros.Gauss();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroRoberts_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaAlta();
            filtros.CarregarImagem(bitmap);
            filtros.Roberts();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroSobel_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaAlta();
            filtros.CarregarImagem(bitmap);
            filtros.Sobel();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroKirsch_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaAlta();
            filtros.CarregarImagem(bitmap);
            filtros.Kirsch();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroRobinson_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaAlta();
            filtros.CarregarImagem(bitmap);
            filtros.Robinson();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuFiltroMarrHildreth_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var filtros = new FiltrosPassaAlta();
            filtros.CarregarImagem(bitmap);
            filtros.MarrHildreth();

            TrocarImagem(filtros.Imagem);
        }

        private void mnuDilatacao_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var morfo = new Morfologia();
            morfo.CarregarImagem(bitmap);
            morfo.Dilatacao();

            TrocarImagem(morfo.Imagem);
        }

        private void mnuErosao_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var morfo = new Morfologia();
            morfo.CarregarImagem(bitmap);
            morfo.Erosao();

            TrocarImagem(morfo.Imagem);
        }

        private void mnuAbertura_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var morfo = new Morfologia();
            morfo.CarregarImagem(bitmap);
            morfo.Abertura();

            TrocarImagem(morfo.Imagem);
        }

        private void mnuFechamento_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var morfo = new Morfologia();
            morfo.CarregarImagem(bitmap);
            morfo.Fechamento();

            TrocarImagem(morfo.Imagem);
        }

        private void mnuMedidasCirculo_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var extracao = new ExtracaoCaracteristicas();
            extracao.CarregarImagem(bitmap);

            var medidas = extracao.CalcularCirculo();

            MessageBox.Show("Área: " + medidas.Area + "\n" +
                            "Perímetro: " + medidas.Perimetro + "\n" +
                            "Circularidade: " + medidas.Circularidade.ToString("0.00"));
        }

        private void mnuMedidasQuadrados_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var extracao = new ExtracaoCaracteristicas();
            extracao.CarregarImagem(bitmap);

            var quadrados = extracao.CalcularQuadrados();
            var areaMaior = 0;
            var perimetroMenor = 0;

            if (quadrados[0].Area > quadrados[1].Area)
            {
                areaMaior = quadrados[0].Area;
                perimetroMenor = quadrados[1].Perimetro;
            }
            else
            {
                areaMaior = quadrados[1].Area;
                perimetroMenor = quadrados[0].Perimetro;
            }

            MessageBox.Show("Área do quadrado maior: " + areaMaior + "\n" +
                            "Perímetro do quadrado menor: " + perimetroMenor);
        }

        private void mnuSelecionarObjetos_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            using (var j = new frmSelecionarObjetosLimite())
            {
                if (j.ShowDialog() == DialogResult.OK)
                {
                    var extracao = new ExtracaoCaracteristicas();

                    extracao.CarregarImagem(bitmap);

                    extracao.SelecionarDiversos(j.Tamanho);

                    TrocarImagem(extracao.Imagem);
                }
            }
        }

        private void mnuEstatisticas_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var j = new frmEstatisticas();
            j.CarregarImagem(bitmap);
            j.Show();
        }

        private void mnuHistograma_Click(object sender, EventArgs e)
        {
            if (!ConsistirImagemEscalaCinzaSelecionada())
            {
                return;
            }

            var j = new frmHistograma();
            j.CarregarImagem(bitmap);
            j.Show();
        }

        private bool ConsistirImagemEscalaCinzaSelecionada()
        {
            if (!ConsistirImagemSelecionada())
            {
                return false;
            }

            if (colorida)
            {
                MessageBox.Show("Função disponível somente para imagens em escala de cinza.", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
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
