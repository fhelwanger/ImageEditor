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
    public partial class frmRedimensionamento : Form
    {
        public int PercentualHorizontal
        {
            get
            {
                return (int)nudHorizontal.Value;
            }
        }

        public int PercentualVertical
        {
            get
            {
                return (int)nudVertical.Value;
            }
        }

        public frmRedimensionamento()
        {
            InitializeComponent();
        }
    }
}
