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
    public class BitmapsParaTeste : IDisposable
    {
        public Bitmap Lenna { get; set; }
        public Bitmap Rgb { get; set; }

        public BitmapsParaTeste()
        {
            CarregarLenna();
            CriarRgb();
        }

        public void Dispose()
        {
            Lenna.Dispose();
            Rgb.Dispose();
        }

        private void CarregarLenna()
        {
            Lenna = new Bitmap(Image.FromFile(Directory.GetCurrentDirectory() + @"\..\..\..\..\img\Lenna.png"));
        }

        private void CriarRgb()
        {
            Rgb = new Bitmap(3, 1);
            Rgb.SetPixel(0, 0, Color.FromArgb(0xFF, 0, 0));
            Rgb.SetPixel(1, 0, Color.FromArgb(0, 0xFF, 0));
            Rgb.SetPixel(2, 0, Color.FromArgb(0, 0, 0xFF));
        }
    }

    [CollectionDefinition("BitmapsParaTeste")]
    public class BitmapsParaTesteCollection : ICollectionFixture<BitmapsParaTeste> { }
}
