using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public class Morfologia
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

        public void Dilatacao()
        {
            var elementoEstruturante = new int[,] {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            byte[,] novosBytes = null;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                novosBytes = new byte[bytes.GetLength(0), bytes.GetLength(1)];

                manipuladorImagem.CopiarBorda(bytes, novosBytes);

                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        var trocar = false;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                // Procura por algum que não seja "fundo" no elemento estruturante
                                if (bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] != 255)
                                {
                                    trocar = true;
                                }
                            }
                        }

                        if (!trocar)
                        {
                            // Não encontrou, apenas copia os bytes da imagem original
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] =
                                        bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO];
                                    novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 1] =
                                        bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 1];
                                    novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 2] =
                                        bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 2];
                                }
                            }

                            continue;
                        }

                        var novoValor = 255;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                int valor = bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] - elementoEstruturante[i, j];

                                valor = Math.Max(valor, 0);
                                novoValor = Math.Min(novoValor, valor);
                            }
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] = (byte)novoValor;
                                novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 1] = (byte)novoValor;
                                novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 2] = (byte)novoValor;
                            }
                        }
                    }
                }
            });

            manipuladorImagem.TrocarImagem(novosBytes);
        }

        public void Erosao()
        {
            var elementoEstruturante = new int[,] {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };

            byte[,] novosBytes = null;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                novosBytes = new byte[bytes.GetLength(0), bytes.GetLength(1)];

                manipuladorImagem.CopiarBorda(bytes, novosBytes);

                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        var trocar = false;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                // Procura por algum que seja "fundo" no elemento estruturante
                                if (bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] == 255)
                                {
                                    trocar = true;
                                }
                            }
                        }

                        if (!trocar)
                        {
                            // Não encontrou, apenas copia os bytes da imagem original
                            for (int i = 0; i < 3; i++)
                            {
                                for (int j = 0; j < 3; j++)
                                {
                                    novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] =
                                        bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO];
                                    novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 1] =
                                        bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 1];
                                    novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 2] =
                                        bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 2];
                                }
                            }

                            continue;
                        }

                        var novoValor = 0;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                int valor = bytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] + elementoEstruturante[i, j];

                                valor = Math.Min(valor, 255);
                                novoValor = Math.Max(novoValor, valor);
                            }
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] = (byte)novoValor;
                                novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 1] = (byte)novoValor;
                                novosBytes[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO + 2] = (byte)novoValor;
                            }
                        }
                    }
                }
            });

            manipuladorImagem.TrocarImagem(novosBytes);
        }

        public void Abertura()
        {
            Erosao();
            Dilatacao();
        }

        public void Fechamento()
        {
            Dilatacao();
            Erosao();
        }
    }
}
