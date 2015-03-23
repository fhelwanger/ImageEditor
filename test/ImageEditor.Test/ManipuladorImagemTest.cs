using System;
using System.Collections.Generic;
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

        [Fact]
        public void CalcularHistograma_ImagemDoisPixels_HistogramaCalculado()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();

            manipuladorImagem.CarregarImagem(bitmapsParaTeste.PretoBranco);

            // Act
            var histograma = manipuladorImagem.CalcularHistograma();

            // Assert
            Assert.Equal(1, histograma[0]);
            Assert.Equal(1, histograma[0xFF]);

            Assert.All(histograma.Take(255).Skip(1), h => Assert.Equal(0, h));
        }
    }
}
