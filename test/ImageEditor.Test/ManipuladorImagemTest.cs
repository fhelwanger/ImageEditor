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
    }
}
