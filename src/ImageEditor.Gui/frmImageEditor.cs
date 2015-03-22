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
                    manipuladorImagem.CarregarImagem(j.FileName);
                    manipuladorImagem.TransformarEscalaCinza();
                    
                    picImagem.Image = manipuladorImagem.Imagem;

                    var estatisticas = manipuladorImagem.CalcularEstatisticas();
                    
                    dgvEstatisticas.DataSource = new[] {
                        new { Nome = "Média", Valor = estatisticas.Media },
                        new { Nome = "Mediana", Valor = estatisticas.Mediana },
                        new { Nome = "Moda", Valor = estatisticas.Moda },
                        new { Nome = "Variância", Valor = estatisticas.Variancia }
                    };
                }
            }
        }

        private void mnuHistograma_Click(object sender, EventArgs e)
        {
            if (manipuladorImagem.Imagem == null)
            {
                MessageBox.Show("Selecione uma imagem", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            using (var j = new frmHistograma(manipuladorImagem.CalcularHistograma()))
            {
                j.ShowDialog();
            }
        }
    }
}
