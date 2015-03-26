using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ImageEditor.Test
{
    public class EstatisticasImagemTest
    {
        [Fact]
        public void CalcularHistograma_ImagemEscalaCinza_HistogramaCalculado()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(2, 0, Color.FromArgb(0xFF, 0xFF, 0xFF));

            var estatisticas = new EstatisticasImagem();
            estatisticas.CarregarImagem(bmp);

            // Act
            var histograma = estatisticas.CalcularHistograma();

            // Assert
            Assert.Equal(2, histograma[0]);
            Assert.Equal(1, histograma[0xFF]);

            Assert.All(histograma.Take(255).Skip(1), h => Assert.Equal(0, h));
        }

        [Fact]
        public void CalcularMedia_ImagemEscalaCinza_MediaCalculada()
        {
            // Arrange
            var bmp = new Bitmap(2, 2);
            bmp.SetPixel(0, 0, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(1, 0, Color.FromArgb(3, 3, 3));
            bmp.SetPixel(0, 1, Color.FromArgb(3, 3, 3));
            bmp.SetPixel(1, 1, Color.FromArgb(4, 4, 4));

            var estatisticas = new EstatisticasImagem();
            estatisticas.CarregarImagem(bmp);

            // Act
            var media = estatisticas.CalcularMedia();

            // Assert
            Assert.Equal(3, media);
        }

        [Fact]
        public void CalcularMediana_ImagemEscalaCinzaNrPixelImpar_MedianaCalculada()
        {
            // Arrange
            var bmp = new Bitmap(5, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(240, 240, 240));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(2, 0, Color.FromArgb(210, 210, 210));
            bmp.SetPixel(3, 0, Color.FromArgb(30, 30, 30));
            bmp.SetPixel(4, 0, Color.FromArgb(45, 45, 45));
            
            var estatisticas = new EstatisticasImagem();
            estatisticas.CarregarImagem(bmp);

            // Act
            var mediana = estatisticas.CalcularMediana();

            // Assert
            Assert.Equal(45, mediana);
        }

        [Fact]
        public void CalcularMediana_ImagemEscalaCinzaNrPixelPar_MedianaCalculadaPixelDireita()
        {
            // Arrange
            var bmp = new Bitmap(2, 2);
            bmp.SetPixel(0, 0, Color.FromArgb(240, 240, 240));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(210, 210, 210));
            bmp.SetPixel(1, 1, Color.FromArgb(30, 30, 30));
            
            var estatisticas = new EstatisticasImagem();
            estatisticas.CarregarImagem(bmp);

            // Act
            var mediana = estatisticas.CalcularMediana();

            // Assert
            Assert.Equal(210, mediana);
        }

        [Fact]
        public void CalcularModa_ImagemEscalaCinza_TomMaiorFrequenciaRetornado()
        {
            // Arrange
            var bmp = new Bitmap(2, 2);
            bmp.SetPixel(0, 0, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(1, 0, Color.FromArgb(4, 4, 4));
            bmp.SetPixel(0, 1, Color.FromArgb(3, 3, 3));
            bmp.SetPixel(1, 1, Color.FromArgb(4, 4, 4));

            var estatisticas = new EstatisticasImagem();
            estatisticas.CarregarImagem(bmp);

            // Act
            var moda = estatisticas.CalcularModa();

            // Assert
            Assert.Equal(4, moda);
        }

        [Fact]
        public void CalcularVariancia_ImagemEscalaCinza_VarianciaRetornada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(1, 0, Color.FromArgb(5, 5, 5));
            bmp.SetPixel(2, 0, Color.FromArgb(9, 9, 9));

            var estatisticas = new EstatisticasImagem();
            estatisticas.CarregarImagem(bmp);

            // Act
            var variancia = estatisticas.CalcularVariancia();

            // Assert
            Assert.Equal(10, variancia);
        }
    }
}
