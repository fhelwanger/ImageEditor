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
                    CarregarImagem(j.FileName);
                }
            }
        }

        private void CarregarImagem(string caminhoArquivo)
        {
            Bitmap bitmap;

            try
            {
                bitmap = new Bitmap(Image.FromFile(caminhoArquivo));
            }
            catch (Exception)
            {
                MessageBox.Show("Houve um erro ao abrir a imagem", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            manipuladorImagem.CarregarImagem(bitmap);
            manipuladorImagem.TransformarEscalaCinza();

            estatisticasImagem.CarregarImagem(bitmap);

            picImagem.Image = bitmap;

            dgvEstatisticas.DataSource = new[] {
                new { Nome = "Média", Valor = estatisticasImagem.CalcularMedia() },
                new { Nome = "Mediana", Valor = estatisticasImagem.CalcularMediana() },
                new { Nome = "Moda", Valor = estatisticasImagem.CalcularModa() },
                new { Nome = "Variância", Valor = estatisticasImagem.CalcularVariancia() }
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
    }
}
