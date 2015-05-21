using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public class FiltrosPassaBaixa
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

        public void Media()
        {
            var matrizMedia = new byte[,] {
                {1, 1, 1},
                {1, 1, 1},
                {1, 1, 1}
            };

            Convolucao(matrizMedia, 9);
        }

        public void Gauss()
        {
            var matrizGauss = new byte[,] {
                {1, 2, 1},
                {2, 4, 2},
                {1, 2, 1}
            };

            Convolucao(matrizGauss, 16);
        }

        private void Convolucao(byte[,] matriz, int divisor)
        {
            byte[,] novosBytes = null;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                novosBytes = new byte[bytes.GetLength(0), bytes.GetLength(1)];

                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        var z = .0;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                z += bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] * matriz[i, j];
                            }
                        }

                        var novoValor = (byte)(z / divisor);

                        novosBytes[y, x] = novoValor;
                        novosBytes[y, x + 1] = novoValor;
                        novosBytes[y, x + 2] = novoValor;
                    }
                }
            });

            manipuladorImagem.TrocarImagem(novosBytes);
        }
    }
}
