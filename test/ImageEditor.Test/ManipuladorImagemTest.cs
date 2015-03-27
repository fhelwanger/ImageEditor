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
            Assert.Equal(bmp, manipuladorImagem.Imagem);
        }

        [Fact]
        public void CarregarImagem_OutraImagem_DescartaAntiga()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();
            var bmp1 = new Bitmap(1, 1);
            var bmp2 = new Bitmap(1, 1);

            // Act
            manipuladorImagem.CarregarImagem(bmp1);
            manipuladorImagem.CarregarImagem(bmp2);

            // Assert
            Assert.Equal(bmp2, manipuladorImagem.Imagem);
            Assert.Equal(1, bmp2.Width);
            Assert.Throws<ArgumentException>(() => bmp1.Width);
        }

        [Fact]
        public void CarregarImagem_MesmaImagem_NaoDescarta()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();
            var bmp = new Bitmap(1, 1);

            // Act
            manipuladorImagem.CarregarImagem(bmp);
            manipuladorImagem.CarregarImagem(bmp);

            // Assert
            Assert.Equal(bmp, manipuladorImagem.Imagem);
            Assert.Equal(1, bmp.Width);
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
        public void AbrirBytesImagem_ImagemDaMemoria_LeituraCorreta()
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
        public void AbrirBytesImagem_ImagemDaMemoria_EscritaCorreta()
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
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), bmp.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), bmp.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), bmp.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(0, 0, 0), bmp.GetPixel(1, 1));
        }
    }
}
