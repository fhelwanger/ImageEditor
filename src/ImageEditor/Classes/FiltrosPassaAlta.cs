using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public class FiltrosPassaAlta
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

        public void Roberts()
        {
            var matX = new int[,] {
                {0, 0, 0},
                {0, -1, 0},
                {0, 0, 1}
            };

            var matY = new int[,] {
                {0, 0, 0},
                {0, 0, -1},
                {0, 1, 0}
            };

            Convolucao(matX, matY, 100);
        }

        public void Sobel()
        {
            var matX = new int[,] {
                {1, 0, -1},
                {2, 0, -2},
                {1, 0, -1}
            };

            var matY = new int[,] {
                {1, 2, 1},
                {0, 0, 0},
                {-1, -2, -1}
            };

            Convolucao(matX, matY, 150);
        }

        public void MarrHildreth()
        {
            var passaBaixa = new FiltrosPassaBaixa();
            passaBaixa.CarregarImagem(Imagem);
            passaBaixa.Gauss();

            CarregarImagem(passaBaixa.Imagem);

            var matX = new int[,] {
                {1, 0, -1},
                {2, 0, -2},
                {1, 0, -1}
            };

            var matY = new int[,] {
                {1, 2, 1},
                {0, 0, 0},
                {-1, -2, -1}
            };

            Convolucao(matX, matY, 150);
        }

        private void Convolucao(int[,] matX, int[,] matY, int threshold)
        {
            byte[,] novosBytes = null;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                novosBytes = new byte[bytes.GetLength(0), bytes.GetLength(1)];

                manipuladorImagem.CopiarBorda(bytes, novosBytes);

                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        var gx = .0;
                        var gy = .0;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                var v = bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO];

                                gx += v * matX[i, j];
                                gy += v * matY[i, j];
                            }
                        }

                        var g = Math.Sqrt(Math.Pow(gx, 2) + Math.Pow(gy, 2));
                        byte p = 0;

                        if (g > threshold)
                        {
                            p = 255;
                        }

                        novosBytes[y, x] = p;
                        novosBytes[y, x + 1] = p;
                        novosBytes[y, x + 2] = p;
                    }
                }
            });

            manipuladorImagem.TrocarImagem(novosBytes);
        }
    }
}
