using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImageEditor.Test
{
    [Collection("BitmapsParaTeste")]
    public class ManipuladorImagemTest
    {
        private BitmapsParaTeste bitmapsParaTeste;

        public ManipuladorImagemTest(BitmapsParaTeste bitmapsParaTeste)
        {
            this.bitmapsParaTeste = bitmapsParaTeste;
        }

        [Fact]
        public void CarregarImagem_DoDisco_CarregaImagem()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();
            var caminho = Directory.GetCurrentDirectory() + @"\..\..\..\..\img\Lenna.png";

            // Act
            manipuladorImagem.CarregarImagem(caminho);

            // Assert
            for (int x = 0; x < manipuladorImagem.Imagem.Width; x++)
            {
                for (int y = 0; y < manipuladorImagem.Imagem.Height; y++)
                {
                    var pixelImagemCaminho = manipuladorImagem.Imagem.GetPixel(x, y);
                    var pixelImagemTeste = bitmapsParaTeste.Lenna.GetPixel(x, y);
                    Assert.True(pixelImagemCaminho == pixelImagemTeste );
                }
            }
        }

        [Fact]
        public void CarregarImagem_DaMemoria_CarregaImagem()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();

            // Act
            manipuladorImagem.CarregarImagem(bitmapsParaTeste.Lenna);

            // Assert
            Assert.True(bitmapsParaTeste.Lenna == manipuladorImagem.Imagem);
        }

        [Fact]
        public void TransformarEscalaCinza_ComImagemColorida_RgbDeCadaPixelIgual()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();

            manipuladorImagem.CarregarImagem(bitmapsParaTeste.Rgb);

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
    }
}
