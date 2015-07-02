using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageEditor
{
    public class ExtracaoCaracteristicas
    {
        public class MedidasCirculo
        {
            public long Area { get; set; }
            public long Perimetro { get; set; }
            public double Circularidade { get; set; }
        }

        public class MedidasQuadrado
        {
            public Point Inicio { get; set; }
            public Point Fim { get; set; }
            
            public int Perimetro
            {
                get
                {
                    return (Fim.X - Inicio.X + 1) * 2 + (Fim.Y - Inicio.Y + 1) * 2;
                }
            }

            public int Area
            {
                get
                {
                    return (Fim.X - Inicio.X + 1) * (Fim.Y - Inicio.Y + 1);
                }
            }
        }

        public class ObjetoDiverso
        {
            private List<Tuple<int, int, int>> linhasObjeto = new List<Tuple<int, int, int>>();

            public void AdicionarLinha(int linha, int inicio, int fim)
            {
                linhasObjeto.Add(new Tuple<int, int, int>(linha, inicio, fim));
            }

            public IList<Tuple<int, int, int>> Linhas
            {
                get
                {
                    return linhasObjeto;
                }
            }

            public int Area
            {
                get
                {
                    var area = 0;

                    foreach (var linha in linhasObjeto)
                    {
                        area += linha.Item3 - linha.Item2 + 1;
                    }

                    return area;
                }
            }
        }

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
        
        public MedidasCirculo CalcularCirculo()
        {
            var mascaraInicioCirculo = new byte[3, 3]
            {
                {255, 255, 255},
                {255, 0, 0},
                {0, 0, 0}
            };

            long perimetro = 0;
            long area = 0;

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                var procurandoInicio = true;
                var ultimaDiferenca = 0;

                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    int inicioPreto = -1;
                    int fimPreto = -1;
                    
                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        if (procurandoInicio)
                        {
                            if (CompararMascara(bytes, mascaraInicioCirculo, x, y))
                            {
                                procurandoInicio = false;
                                inicioPreto = x;
                            }
                        }

                        if (!procurandoInicio)
                        {
                            if (inicioPreto == -1 && bytes[y, x] == 0)
                            {
                                inicioPreto = x;
                            }

                            if (inicioPreto != -1 && fimPreto == -1 && bytes[y, x] == 255)
                            {
                                fimPreto = x - 1;
                            }
                        }
                    }

                    if (inicioPreto == -1 || fimPreto == -1)
                    {
                        procurandoInicio = true;
                    }
                    else
                    {
                        int diferenca = (fimPreto - inicioPreto) / ManipuladorImagem.PIXEL_TAMANHO + 1;
                        int diferencaPerimetro = Math.Abs(diferenca - ultimaDiferenca);

                        // Se o círculo não crescer nessa linha, precisa de 2 de perímetro mesmo assim
                        perimetro += Math.Max(diferencaPerimetro, 2);
                        area += diferenca;

                        ultimaDiferenca = diferenca;
                    }
                }
            });

            var circularidade = Math.Pow(perimetro, 2) / (4 * Math.PI * area);

            return new MedidasCirculo()
            {
                Area = area,
                Perimetro = perimetro,
                Circularidade = circularidade
            };
        }
        
        public void SelecionarDiversos(int limiteTamanho)
        {
            var objetos = new List<ObjetoDiverso>();

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    var procurandoPreto = true;
                    var inicioLinha = 0;

                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        if (procurandoPreto)
                        {
                            if (bytes[y, x] == 0)
                            {
                                inicioLinha = x / ManipuladorImagem.PIXEL_TAMANHO;
                                procurandoPreto = false;
                            }
                        }
                        else
                        {
                            if (bytes[y, x] == 255)
                            {
                                var novaLinha = new Tuple<int, int, int>(y, inicioLinha, x / ManipuladorImagem.PIXEL_TAMANHO - 1);
                                
                                var conectados = ProcurarConectadosAcima(objetos, novaLinha);

                                ObjetoDiverso obj;

                                if (conectados.Count == 0)
                                {
                                    obj = new ObjetoDiverso();
                                    obj.AdicionarLinha(novaLinha.Item1, novaLinha.Item2, novaLinha.Item3);
                                    objetos.Add(obj);
                                }
                                else
                                {
                                    obj = conectados.First();

                                    for (int i = 1; i < conectados.Count; i++)
                                    {
                                        var obj2 = conectados[i];

                                        foreach (var l in obj2.Linhas)
                                        {
                                            obj.AdicionarLinha(l.Item1, l.Item2, l.Item3);
                                        }

                                        objetos.Remove(obj2);
                                    }

                                    obj.AdicionarLinha(novaLinha.Item1, novaLinha.Item2, novaLinha.Item3);
                                }

                                procurandoPreto = true;
                            }
                        }
                    }
                }

                foreach (var obj in objetos)
                {
                    if (obj.Area > limiteTamanho)
                    {
                        continue;
                    }

                    foreach (var linha in obj.Linhas)
                    {
                        for (int x = linha.Item2; x <= linha.Item3; x++)
                        {
                            bytes[linha.Item1, x * ManipuladorImagem.PIXEL_TAMANHO] = 255;
                        }
                    }
                }
            });
        }

        private IList<ObjetoDiverso> ProcurarConectadosAcima(IList<ObjetoDiverso> objetos, Tuple<int, int, int> linha)
        {
            return objetos.Where(o => o.Linhas.Any(l => 
            {
                return l.Item1 == (linha.Item1 - 1) &&
                    ((linha.Item2 >= l.Item2 && linha.Item2 <= l.Item3) || (linha.Item3 >= l.Item2 && linha.Item3 <= l.Item3) ||
                     (l.Item2 >= linha.Item2 && l.Item2 <= linha.Item3) || (l.Item3 >= linha.Item2 && l.Item3 <= linha.Item3));
            })).ToList();
        }

        public IList<MedidasQuadrado> CalcularQuadrados()
        {
            var mascaraInicioQuadrado = new byte[3, 3]
            {
                {255, 255, 255},
                {255, 0, 0},
                {255, 0, 0}
            };

            var quadrados = new List<MedidasQuadrado>();

            manipuladorImagem.AbrirBytesImagem(bytes =>
            {
                for (int y = 1; y < bytes.GetLength(0) - 1; y++)
                {
                    for (int x = ManipuladorImagem.PIXEL_TAMANHO; x < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO; x += ManipuladorImagem.PIXEL_TAMANHO)
                    {
                        if (CompararMascara(bytes, mascaraInicioQuadrado, x, y))
                        {
                            var quadrado = new MedidasQuadrado();

                            quadrado.Inicio = new Point(x / ManipuladorImagem.PIXEL_TAMANHO, y);

                            var fimX = x;
                            var fimY = y;

                            while (bytes[fimY, x] == 0 && fimY < bytes.GetLength(0) - 1)
                            {
                                fimY++;
                            }

                            fimY--;

                            while (bytes[y, fimX] == 0 && fimX < bytes.GetLength(1) - ManipuladorImagem.PIXEL_TAMANHO)
                            {
                                fimX += ManipuladorImagem.PIXEL_TAMANHO;
                            }

                            fimX--;

                            quadrado.Fim = new Point(fimX / ManipuladorImagem.PIXEL_TAMANHO, fimY);

                            quadrados.Add(quadrado);
                        }
                    }
                }
            });

            return quadrados;
        }

        private bool CompararMascara(byte[,] bytesImagem, byte[,] mascara, int x, int y)
        {
            var igual = true;

            for (int i = 0; i < 3 && igual == true; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (bytesImagem[y + (i - 1), x + (j - 1) * ManipuladorImagem.PIXEL_TAMANHO] != mascara[i, j])
                    {
                        igual = false;
                        break;
                    }
                }
            }

            return igual;
        }
    }
}
