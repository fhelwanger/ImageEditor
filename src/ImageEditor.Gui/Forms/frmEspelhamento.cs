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
    public partial class frmEspelhamento : Form
    {
        public TransformacoesImagem.TipoEspelhamento TipoEspelhamento
        {
            get
            {
                return (radHorizontal.Checked) ?
                    TransformacoesImagem.TipoEspelhamento.Horizontal :
                    TransformacoesImagem.TipoEspelhamento.Vertical;
            }
        }

        public frmEspelhamento()
        {
            InitializeComponent();
        }
    }
}
