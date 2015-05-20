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
    public partial class frmHistograma : Form
    {
        private EstatisticasImagem estatisticasImagem = new EstatisticasImagem();

        public frmHistograma()
        {
            InitializeComponent();
        }

        public void CarregarImagem(Bitmap bitmap)
        {
            estatisticasImagem.CarregarImagem(bitmap);
        }

        private void frmHistograma_Load(object sender, EventArgs e)
        {
            crtHistograma.DataSource = estatisticasImagem.CalcularHistograma().Select((x, i) => new KeyValuePair<int, int>(i, x)); ;
            crtHistograma.Series[0].XValueMember = "Key";
            crtHistograma.Series[0].YValueMembers = "Value";
            crtHistograma.Series[0]["PointWidth"] = "1";

            crtHistograma.ChartAreas[0].AxisX.Minimum = 0;
            crtHistograma.ChartAreas[0].AxisX.Maximum = 255;
            crtHistograma.ChartAreas[0].AxisX.Interval = 255;
        }
    }
}
