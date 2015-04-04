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
        private const int PIXEL_TAMANHO = 3;

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

        public void Transladar(int horizontal, int vertical)
        {
            var matrizTranslacao = new int[,] {
                {1, 0, 0},
                {0, 1, 0},
                {vertical, horizontal * 3, 1}
            };

            AbrirBytesImagem(bytes =>
            {
                var copia = (byte[,])bytes.Clone();

                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j++)
                    {
                        bytes[i, j] = 0xFF;
                    }
                }

                for (int i = 0; i < copia.GetLength(0); i++)
                {
                    for (int j = 0; j < copia.GetLength(1); j += 3)
                    {
                        var posicao = new int[,] {
                            {i, j, 1}
                        };

                        var novaPosicao = MultiplicarMatrizes(posicao, matrizTranslacao);

                        if (novaPosicao[0, 0] < 0 || novaPosicao[0, 0] > bytes.GetUpperBound(0)) continue;
                        if (novaPosicao[0, 1] < 0 || novaPosicao[0, 1] > bytes.GetUpperBound(1)) continue;

                        bytes[novaPosicao[0, 0], novaPosicao[0, 1]] = copia[posicao[0, 0], posicao[0, 1]];
                        bytes[novaPosicao[0, 0], novaPosicao[0, 1] + 1] = copia[posicao[0, 0], posicao[0, 1] + 1];
                        bytes[novaPosicao[0, 0], novaPosicao[0, 1] + 2] = copia[posicao[0, 0], posicao[0, 1] + 2];
                    }
                }
            });
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

        private int[,] MultiplicarMatrizes(int[,] matrizA, int[,] matrizB)
        {
            if (matrizA.GetLength(1) != matrizB.GetLength(0))
            {
                throw new InvalidOperationException("Número de colunas da matriz A deve ser igual ao número de linhas da matriz B");
            }

            int[,] resultado = new int[matrizA.GetLength(0), matrizB.GetLength(1)];

            for (int i = 0; i < matrizA.GetLength(0); i++)
            {
                for (int j = 0; j < matrizB.GetLength(0); j++)
                {
                    var soma = 0;

                    for (int k = 0; k < matrizB.GetLength(0); k++)
                    {
                        soma += matrizA[i, k] * matrizB[k, j];
                    }

                    resultado[i, j] = soma;
                }
            }

            return resultado;
        }
    }
}
