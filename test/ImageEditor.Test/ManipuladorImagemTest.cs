using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImageEditor.Test
{
    public class ManipuladorImagemTest : IClassFixture<BitmapsFixture>
    {
        private BitmapsFixture bitmapsParaTeste;

        public ManipuladorImagemTest(BitmapsFixture bitmapsParaTeste)
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
        public void CarregarImagem_DoDiscoInexistente_LancaExcecao()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();
            var caminho = @"C:\este_arquivo_nao_deve_existir.aaaxxxbbb";

            // Act & Assert
            Assert.Throws<FileNotFoundException>(() => manipuladorImagem.CarregarImagem(caminho));
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

            manipuladorImagem.CarregarImagem(bitmapsParaTeste.Lenna);

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
        public void CalcularHistograma_ComImagemEscalaCinza_HistogramaCalculado()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();

            manipuladorImagem.CarregarImagem(bitmapsParaTeste.Histograma);

            // Act
            var histograma = manipuladorImagem.CalcularHistograma();

            // Assert
            Assert.Equal(2, histograma[0]);
            Assert.Equal(1, histograma[0xFF]);

            Assert.All(histograma.Take(255).Skip(1), h => Assert.Equal(0, h));
        }

        [Fact]
        public void CalcularEstatisticas_ComImagemEscalaCinza_CalculoCorreto()
        {
            // Arrange
            var manipuladorImagem = new ManipuladorImagem();

            manipuladorImagem.CarregarImagem(bitmapsParaTeste.Estatisticas);

            // Act
            var estatisticas = manipuladorImagem.CalcularEstatisticas();

            // Assert
            Assert.Equal(139, estatisticas.Media);
            Assert.Equal(128, estatisticas.Mediana);
            Assert.Equal(254, estatisticas.Moda);
            Assert.Equal(10426, estatisticas.Variancia);
        }
    }
}
