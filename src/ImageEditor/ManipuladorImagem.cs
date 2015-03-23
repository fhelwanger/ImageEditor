﻿using System;
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
        private const PixelFormat PIXEL_FORMATO = PixelFormat.Format24bppRgb;

        private Bitmap bitmap;

        public Bitmap Imagem
        {
            get
            {
                return bitmap;
            }
        }

        public void CarregarImagem(string caminho)
        {
            var bitmap = new Bitmap(Image.FromFile(caminho));

            CarregarImagem(bitmap);
        }

        public void CarregarImagem(Bitmap bitmap)
        {
            if (this.bitmap != null)
            {
                this.bitmap.Dispose();
            }

            this.bitmap = bitmap;
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

        public int[] CalcularHistograma()
        {
            var histograma = new int[256];

            AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += PIXEL_TAMANHO)
                    {
                        histograma[bytes[i, j]]++;
                    }
                }
            });

            return histograma;
        }

        public EstatisticasImagem CalcularEstatisticas()
        {
            var estatisticas = new EstatisticasImagem();
            
            AbrirBytesImagem(bytes =>
            {
                var soma = 0;
                var listaMediana = new List<byte>();

                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += PIXEL_TAMANHO)
                    {
                        soma += bytes[i, j];
                        listaMediana.Add(bytes[i, j]);
                    }
                }

                estatisticas.Media = soma / (bytes.Length / PIXEL_TAMANHO);
                estatisticas.Mediana = listaMediana.OrderBy(x => x).ElementAt(listaMediana.Count() / 2);

                soma = 0;

                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += PIXEL_TAMANHO)
                    {
                        soma += (int)Math.Pow(bytes[i, j] - estatisticas.Media, 2);
                    }
                }

                estatisticas.Variancia = soma / (bytes.Length / PIXEL_TAMANHO);
            });
            
            var histograma = CalcularHistograma();
            estatisticas.Moda = histograma.ToList().IndexOf(histograma.Max());
            
            return estatisticas;
        }

        private void AbrirBytesImagem(Action<byte[,]> acao)
        {
            //Explicação do LockBits: http://bobpowell.net/lockingbits.aspx

            var area = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            var bitmapData = bitmap.LockBits(area, ImageLockMode.ReadWrite, PIXEL_FORMATO);
            
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
