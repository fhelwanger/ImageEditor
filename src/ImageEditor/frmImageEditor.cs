using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
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
                }
            }
        }
    }
}
