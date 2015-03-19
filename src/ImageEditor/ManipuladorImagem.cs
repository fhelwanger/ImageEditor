using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public class ManipuladorImagem
    {
        private Bitmap bitmap;

        public Image Imagem
        {
            get
            {
                return bitmap;
            }
        }

        public void CarregarImagem(string caminho)
        {
            bitmap = new Bitmap(Image.FromFile(caminho));
        }

        public void TransformarEscalaCinza()
        {
            AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.Length; i += 3)
                {
                    var cinza = (byte)(bytes[i] * 0.3 + bytes[i + 1] * 0.59 + bytes[i + 2] * 0.11);
                    bytes[i] = cinza;
                    bytes[i + 1] = cinza;
                    bytes[i + 2] = cinza;
                }
            });
        }

        public int[] CalcularHistograma()
        {
            var histograma = new int[256];

            AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.Length; i += 3)
                {
                    histograma[bytes[i]]++;
                }
            });

            return histograma;
        }

        private void AbrirBytesImagem(Action<byte[]> acao)
        {
            var area = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bmpData = bitmap.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int numBytes = bmpData.Stride * bmpData.Height;
            var bytes = new byte[numBytes];

            Marshal.Copy(bmpData.Scan0, bytes, 0, numBytes);

            acao(bytes);

            Marshal.Copy(bytes, 0, bmpData.Scan0, numBytes);

            bitmap.UnlockBits(bmpData);
        }
    }
}
