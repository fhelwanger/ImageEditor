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
    public partial class frmEstatisticas : Form
    {
        private EstatisticasImagem estatisticasImagem = new EstatisticasImagem();

        public frmEstatisticas()
        {
            InitializeComponent();
        }

        public void CarregarImagem(Bitmap bitmap)
        {
            estatisticasImagem.CarregarImagem(bitmap);
        }

        private void frmEstatisticas_Load(object sender, EventArgs e)
        {
            var menor125abaixoDiagSec = estatisticasImagem.ContarPixels((i, j, r, g, b) => r < 125 && i > (estatisticasImagem.Imagem.Width - 1) - j);
            var maior125acimaDiagSec = estatisticasImagem.ContarPixels((i, j, r, g, b) => r > 125 && i < (estatisticasImagem.Imagem.Width - 1) - j);

            dgvEstatisticas.DataSource = new[] {
                new { Nome = "Média", Valor = estatisticasImagem.CalcularMedia() },
                new { Nome = "Mediana", Valor = estatisticasImagem.CalcularMediana() },
                new { Nome = "Moda", Valor = estatisticasImagem.CalcularModa() },
                new { Nome = "Variância", Valor = estatisticasImagem.CalcularVariancia() },
                new { Nome = "Pixels < 125 abaixo diag. sec.", Valor = menor125abaixoDiagSec },
                new { Nome = "Pixels > 125 acima diag. sec.", Valor = maior125acimaDiagSec }
            };
        }
    }
}
