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
        public const int PIXEL_TAMANHO = 3;

        private Bitmap bitmap;

        public Bitmap Imagem
        {
            get
            {
                return bitmap;
            }
        }

        public void CarregarImagem(Bitmap bitmap)
        {
            this.bitmap = new Bitmap(bitmap);
        }

        public void TransformarEscalaCinza()
        {
            AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += PIXEL_TAMANHO)
                    {
                        var cinza = (byte)(bytes[i, j + 0] * 0.30 +
                                           bytes[i, j + 1] * 0.59 +
                                           bytes[i, j + 2] * 0.11);

                        bytes[i, j + 0] = cinza;
                        bytes[i, j + 1] = cinza;
                        bytes[i, j + 2] = cinza;
                    }
                }
            });
        }

        public void TrocarImagem(byte[,] novosBytes)
        {
            this.bitmap.Dispose();
            this.bitmap = new Bitmap(novosBytes.GetLength(1) / 3, novosBytes.GetLength(0));

            AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j++)
                    {
                        bytes[i, j] = novosBytes[i, j];
                    }
                }
            });
        }

        public void CopiarBorda(byte[,] origem, byte[,] destino)
        {
            for (int x = 0; x < origem.GetLength(1); x++)
            {
                int ultimaLinha = origem.GetLength(0) - 1;

                destino[0, x] = origem[0, x];
                destino[ultimaLinha, x] = origem[ultimaLinha, x];
            }

            for (int y = 0; y < origem.GetLength(0); y++)
            {
                int ultimaColuna = origem.GetLength(1) - 1;

                destino[y, 0] = origem[y, 0];
                destino[y, 1] = origem[y, 1];
                destino[y, 2] = origem[y, 2];

                destino[y, ultimaColuna - 2] = origem[y, ultimaColuna - 2];
                destino[y, ultimaColuna - 1] = origem[y, ultimaColuna - 1];
                destino[y, ultimaColuna] = origem[y, ultimaColuna];
            }
        }

        public void AbrirBytesImagem(Action<byte[,]> acao)
        {
            //Explicação do LockBits: http://bobpowell.net/lockingbits.aspx

            var area = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            
            try
            {
                var bytes = PegarMatrizBitmap(bitmapData);

                acao(bytes);

                InformarMatrizBitmap(bitmapData, bytes);
            }
            finally
            {
                bitmap.UnlockBits(bitmapData);
            }
        }

        private unsafe byte[,] PegarMatrizBitmap(BitmapData bitmapData)
        {
            var bytes = new byte[bitmapData.Height, bitmapData.Width * PIXEL_TAMANHO];

            for (int y = 0; y < bitmapData.Height; y++)
            {
                byte* linha = (byte*)bitmapData.Scan0 + (bitmapData.Stride * y);

                for (int x = 0; x < bitmapData.Width; x++)
                {
                    bytes[y, x * PIXEL_TAMANHO + 0] = linha[x * PIXEL_TAMANHO + 2];
                    bytes[y, x * PIXEL_TAMANHO + 1] = linha[x * PIXEL_TAMANHO + 1];
                    bytes[y, x * PIXEL_TAMANHO + 2] = linha[x * PIXEL_TAMANHO + 0];
                }
            }

            return bytes;
        }

        private unsafe void InformarMatrizBitmap(BitmapData bitmapData, byte[,] bytes)
        {
            for (int y = 0; y < bitmapData.Height; y++)
            {
                byte* linha = (byte*)bitmapData.Scan0 + (bitmapData.Stride * y);

                for (int x = 0; x < bitmapData.Width; x++)
                {
                    linha[x * PIXEL_TAMANHO + 0] = bytes[y, x * PIXEL_TAMANHO + 2];
                    linha[x * PIXEL_TAMANHO + 1] = bytes[y, x * PIXEL_TAMANHO + 1];
                    linha[x * PIXEL_TAMANHO + 2] = bytes[y, x * PIXEL_TAMANHO + 0];
                }
            }
        }
    }
}
