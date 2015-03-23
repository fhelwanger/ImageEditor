using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImageEditor.Test
{
    public class BitmapsFixture : IDisposable
    {
        public Bitmap Lenna { get; set; }
        public Bitmap Histograma { get; set; }
        public Bitmap Estatisticas { get; set; }

        public BitmapsFixture()
        {
            CarregarLenna();
            CriarHistograma();
            CriarEstatisticas();
        }

        public void Dispose()
        {
            Lenna.Dispose();
            Histograma.Dispose();
            Estatisticas.Dispose();
        }

        private void CarregarLenna()
        {
            Lenna = new Bitmap(Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\..\..\img\Lenna.png"));
        }

        private void CriarHistograma()
        {
            Histograma = new Bitmap(3, 1);
            Histograma.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            Histograma.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            Histograma.SetPixel(2, 0, Color.FromArgb(0xFF, 0xFF, 0xFF));
        }

        private void CriarEstatisticas()
        {
            Estatisticas = new Bitmap(5, 1);
            Estatisticas.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            Estatisticas.SetPixel(1, 0, Color.FromArgb(60, 60, 60));
            Estatisticas.SetPixel(2, 0, Color.FromArgb(128, 128, 128));
            Estatisticas.SetPixel(3, 0, Color.FromArgb(254, 254, 254));
            Estatisticas.SetPixel(4, 0, Color.FromArgb(254, 254, 254));
        }
    }
}
