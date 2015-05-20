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
    public class TransformacoesImagemTest
    {
        [Fact]
        public void Transladar_1pxDireita_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(2, 0, Color.FromArgb(0, 0, 0));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Transladar(1, 0);

            // Assert
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }

        [Fact]
        public void Transladar_1pxEsquerda_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(1, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(2, 0, Color.FromArgb(0, 0, 0));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Transladar(-1, 0);

            // Assert
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), transformacoesImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }

        [Fact]
        public void Transladar_1pxBaixo_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 2, Color.FromArgb(0, 0, 0));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Transladar(0, 1);

            // Assert
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }

        [Fact]
        public void Transladar_1pxCima_ImagemDeslocada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 1, Color.FromArgb(0, 0, 0));
            bmp.SetPixel(0, 2, Color.FromArgb(0, 0, 0));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Transladar(0, -1);

            // Assert
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(0, 0, 0), transformacoesImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(0xFF, 0xFF, 0xFF), transformacoesImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }

        [Fact]
        public void Redimensionar_200pct_ImagemAumentada()
        {
            // Arrange
            var bmp = new Bitmap(2, 3);

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Redimensionar(2, 2);

            // Assert
            Assert.Equal(4, transformacoesImagem.Imagem.Width);
            Assert.Equal(6, transformacoesImagem.Imagem.Height);
        }

        [Fact]
        public void Redimensionar_50pct_ImagemReduzida()
        {
            // Arrange
            var bmp = new Bitmap(2, 2);

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Redimensionar(0.5f, 0.5f);

            // Assert
            Assert.Equal(1, transformacoesImagem.Imagem.Width);
            Assert.Equal(1, transformacoesImagem.Imagem.Height);
        }

        [Fact]
        public void Rotacionar_90graus_ImagemRotacionada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Rotacionar(TransformacoesImagem.TipoRotacao.R90);

            // Assert
            Assert.Equal(Color.FromArgb(1, 1, 1), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), transformacoesImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(3, 3, 3), transformacoesImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Width, transformacoesImagem.Imagem.Height);
            Assert.Equal(bmp.Height, transformacoesImagem.Imagem.Width);
        }

        [Fact]
        public void Rotacionar_180graus_ImagemRotacionada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Rotacionar(TransformacoesImagem.TipoRotacao.R180);

            // Assert
            Assert.Equal(Color.FromArgb(1, 1, 1), transformacoesImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(Color.FromArgb(2, 2, 2), transformacoesImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(3, 3, 3), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }

        [Fact]
        public void Rotacionar_270graus_ImagemRotacionada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Rotacionar(TransformacoesImagem.TipoRotacao.R270);

            // Assert
            Assert.Equal(Color.FromArgb(3, 3, 3), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), transformacoesImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(1, 1, 1), transformacoesImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Width, transformacoesImagem.Imagem.Height);
            Assert.Equal(bmp.Height, transformacoesImagem.Imagem.Width);
        }

        [Fact]
        public void Espelhar_Horizontal_ImagemEspelhada()
        {
            // Arrange
            var bmp = new Bitmap(3, 1);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(1, 0, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(2, 0, Color.FromArgb(3, 3, 3));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Espelhar(TransformacoesImagem.TipoEspelhamento.Horizontal);

            // Assert
            Assert.Equal(Color.FromArgb(3, 3, 3), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), transformacoesImagem.Imagem.GetPixel(1, 0));
            Assert.Equal(Color.FromArgb(1, 1, 1), transformacoesImagem.Imagem.GetPixel(2, 0));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }

        [Fact]
        public void Espelhar_Vertical_ImagemEspelhada()
        {
            // Arrange
            var bmp = new Bitmap(1, 3);
            bmp.SetPixel(0, 0, Color.FromArgb(1, 1, 1));
            bmp.SetPixel(0, 1, Color.FromArgb(2, 2, 2));
            bmp.SetPixel(0, 2, Color.FromArgb(3, 3, 3));

            var transformacoesImagem = new TransformacoesImagem();
            transformacoesImagem.CarregarImagem(bmp);

            // Act
            transformacoesImagem.Espelhar(TransformacoesImagem.TipoEspelhamento.Vertical);

            // Assert
            Assert.Equal(Color.FromArgb(3, 3, 3), transformacoesImagem.Imagem.GetPixel(0, 0));
            Assert.Equal(Color.FromArgb(2, 2, 2), transformacoesImagem.Imagem.GetPixel(0, 1));
            Assert.Equal(Color.FromArgb(1, 1, 1), transformacoesImagem.Imagem.GetPixel(0, 2));
            Assert.Equal(bmp.Size, transformacoesImagem.Imagem.Size);
        }
    }
}
