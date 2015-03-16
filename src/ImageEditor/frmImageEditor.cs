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
        public frmImageEditor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var img1 = new ManipuladorImagem();
            img1.CarregarImagem(@"D:\Lenna.png");
            pictureBox1.Image = img1.Imagem;

            var img2 = new ManipuladorImagem();
            img2.CarregarImagem(@"D:\Lenna.png");
            img2.TransformarEscalaCinza();
            pictureBox2.Image = img2.Imagem;
        }
    }
}
