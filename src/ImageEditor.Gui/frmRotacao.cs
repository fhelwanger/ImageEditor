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
    public partial class frmRotacao : Form
    {
        public ManipuladorImagem.TipoRotacao TipoRotacao
        {
            get
            {
                if (rad90.Checked)
                {
                    return ManipuladorImagem.TipoRotacao.R90;
                }
                else if (rad180.Checked)
                {
                    return ManipuladorImagem.TipoRotacao.R180;
                }
                else
                {
                    return ManipuladorImagem.TipoRotacao.R270;
                }
            }
        }

        public frmRotacao()
        {
            InitializeComponent();
        }
    }
}
