﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImageEditor.Test
{
    public class ManipuladorImagemTest
    {
        [Fact]
        public void CarregarImagem_DaMemoria_CarregaCopiaImagem()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();
            var bmp = new Bitmap(1, 1);
            bmp.SetPixel(0, 0, Color.Red);

            // Act
            manipuladorImagem.CarregarImagem(bmp);
            
            // Assert
            Assert.Equal(bmp.Width, manipuladorImagem.Imagem.Width);
            Assert.Equal(bmp.Height, manipuladorImagem.Imagem.Height);
            Assert.Equal(bmp.GetPixel(0, 0), manipuladorImagem.Imagem.GetPixel(0, 0));
        }

        [Fact]
        public void TransformarEscalaCinza_ComImagemColorida_RgbDeCadaPixelIgual()
        {
            // Arrange
            var bmp = new Bitmap(2, 2);
            bmp.SetPixel(0, 0, Color.FromArgb(0xFF, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0xFF, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(0, 0, 0xFF));
            bmp.SetPixel(1, 1, Color.FromArgb(0xDD, 0x1D, 0xFF));
            
            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.TransformarEscalaCinza();

            // Assert
            for (int x = 0; x < manipuladorImagem.Imagem.Width; x++)
            {
                for (int y = 0; y < manipuladorImagem.Imagem.Height; y++)
                {
                    var pixel = manipuladorImagem.Imagem.GetPixel(x, y);

                    Assert.True(pixel.R == pixel.G);
                    Assert.True(pixel.G == pixel.B);
                }
            }
        }

        [Fact]
        public void Transladar_1pxDireita_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(2, 0, Color.FromArgb(0, 0, 0));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Transladar(1, 0);

            // Assert
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void Transladar_1pxEsquerda_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(2, 0, Color.FromArgb(0, 0, 0));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Transladar(-1, 0);

            // Assert
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), manipuladorImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void Transladar_1pxBaixo_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 2, Color.FromArgb(0, 0, 0));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Transladar(0, 1);

            // Assert
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void Transladar_1pxCima_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 2, Color.FromArgb(0, 0, 0));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Transladar(0, -1);

            // Assert
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), manipuladorImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void Rotacionar_90graus_ImagemRotacionada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Rotacionar(ManipuladorImagem.TipoRotacao.R90);

            // Assert
            Assert.Equal(Color.FromArgb(1, 1, 1), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), manipuladorImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(3, 3, 3), manipuladorImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Width, manipuladorImagem.Imagem.Height);
            Assert.Equal(bmp.Height, manipuladorImagem.Imagem.Width);
        }

        [Fact]
        public void Rotacionar_180graus_ImagemRotacionada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Rotacionar(ManipuladorImagem.TipoRotacao.R180);

            // Assert
            Assert.Equal(Color.FromArgb(1, 1, 1), manipuladorImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(Color.FromArgb(2, 2, 2), manipuladorImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(3, 3, 3), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void Rotacionar_270graus_ImagemRotacionada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Rotacionar(ManipuladorImagem.TipoRotacao.R270);

            // Assert
            Assert.Equal(Color.FromArgb(3, 3, 3), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), manipuladorImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(1, 1, 1), manipuladorImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Width, manipuladorImagem.Imagem.Height);
            Assert.Equal(bmp.Height, manipuladorImagem.Imagem.Width);
        }

        [Fact]
        public void Espelhar_Horizontal_ImagemEspelhada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(1, 0, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(2, 0, Color.FromArgb(3, 3, 3));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Espelhar(ManipuladorImagem.TipoEspelhamento.Horizontal);

            // Assert
            Assert.Equal(Color.FromArgb(3, 3, 3), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), manipuladorImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(1, 1, 1), manipuladorImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void Espelhar_Vertical_ImagemEspelhada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.Espelhar(ManipuladorImagem.TipoEspelhamento.Vertical);

            // Assert
            Assert.Equal(Color.FromArgb(3, 3, 3), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), manipuladorImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(1, 1, 1), manipuladorImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(bmp.Size, manipuladorImagem.Imagem.Size);
        }

        [Fact]
        public void AbrirBytesImagem_ParaLeitura_LeituraCorreta()
        {
            // Arrange
            var bmp = new Bitmap(3, 3);
            var seed = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bmp.SetPixel(j, i, Color.FromArgb(seed++, seed++, seed++));
                }
            }

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            byte[,] bytes = null;

            // Act
            manipuladorImagem.AbrirBytesImagem(x => bytes = x);

            // Assert
            seed = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Assert.Equal(seed++, bytes[i, j]);
                }
            }
        }

        [Fact]
        public void AbrirBytesImagem_ParaEscrita_EscritaCorreta()
        {
            // Arrange
            var bmp = new Bitmap(2, 2);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 1, Color.FromArgb(0, 0, 0));

            var manipuladorImagem = new ManipuladorImagem();
            manipuladorImagem.CarregarImagem(bmp);

            // Act
            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int j = 0; j < bytes.GetLength(1); j += 3)
                {
                    bytes[0, j + 0] = 0xFF;
                    bytes[0, j + 1] = 0xFF;
                    bytes[0, j + 2] = 0xFF;
                }
            });

            // Assert
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), manipuladorImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), manipuladorImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(0, 0, 0), manipuladorImagem.Imagem.GetPixel(1, 1));
        }
    }
}
