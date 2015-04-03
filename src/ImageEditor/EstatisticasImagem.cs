using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public class EstatisticasImagem
    {
        private ManipuladorImagem manipuladorImagem = new ManipuladorImagem();

        public Bitmap Imagem
        {
            get
            {
                return manipuladorImagem.Imagem;
            }
        }

        public void CarregarImagem(Bitmap bitmap)
        {
            manipuladorImagem.CarregarImagem(bitmap);
        }

        public int[] CalcularHistograma()
        {
            var histograma = new int[256];

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += 3)
                    {
                        histograma[bytes[i, j]]++;
                    }
                }
            });
            
            return histograma;
        }

        public int CalcularMedia()
        {
            var soma = 0L;
            var quantidade = 0;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += 3)
                    {
                        soma += bytes[i, j];
                    }
                }

                quantidade = (bytes.Length / 3);
            });
            
            return (int)(soma / quantidade);
        }

        public int CalcularMediana()
        {
            var listaMediana = new List<byte>();

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += 3)
                    {
                        listaMediana.Add(bytes[i, j]);
                    }
                }
            });
            
            return listaMediana.OrderBy(x => x).ElementAt(listaMediana.Count() / 2);
        }

        public int CalcularModa()
        {
            var histograma = CalcularHistograma();
            return histograma.ToList().IndexOf(histograma.Max());
        }

        public int CalcularVariancia()
        {
            var media = CalcularMedia();
            var soma = 0L;
            var quantidade = 0;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += 3)
                    {
                        soma += (int)Math.Pow(bytes[i, j] - media, 2);
                    }
                }

                quantidade = (bytes.Length / 3);
            });
            
            return (int)(soma / quantidade);
        }

        public int ContarPixels(Func<int, int, int, int, int, bool> condicao)
        {
            var quantidade = 0;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int i = 0; i < bytes.GetLength(0); i++)
                {
                    for (int j = 0; j < bytes.GetLength(1); j += 3)
                    {
                        if (condicao(i, j / 3, bytes[i, j], bytes[i, j + 1], bytes[i, j + 2]))
                        {
                            quantidade++;
                        }
                    }
                }
            });

            return quantidade;
        }
    }
}
