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
    public class ManipuladorImagemTest
    {
        [Fact]
        public void CarregarImagem_DaMemoria_CarregaImagem()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();
            var bmp = new Bitmap(1, 1);

            // Act
            manipuladorImagem.CarregarImagem(bmp);

            // Assert
            Assert.True(bmp == manipuladorImagem.Imagem);
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
        public void AbrirBytesImagem_ImagemDaMemoria_BytesCorretos()
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
    }
}
