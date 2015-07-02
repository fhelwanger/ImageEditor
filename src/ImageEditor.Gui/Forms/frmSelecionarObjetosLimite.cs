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
    public partial class frmSelecionarObjetosLimite : Form
    {
        public int Tamanho
        {
            get
            {
                return int.Parse(txtTamanho.Text);
            }
        }

        public frmSelecionarObjetosLimite()
        {
            InitializeComponent();
        }

        private void frmSelecionarObjetosLimite_FormClosing(object sender, FormClosingEventArgs e)
        {
            int result;

            if (!int.TryParse(txtTamanho.Text, out result))
            {
                MessageBox.Show("Preencha o tamanho corretamente.", "ImageEditor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTamanho.Focus();
                e.Cancel = true;
            }
        }
    }
}
