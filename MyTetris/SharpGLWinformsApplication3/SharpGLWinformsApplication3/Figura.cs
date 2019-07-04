using SharpGL;
using System.Drawing;

namespace Tetris
{
    public class Figura
    {
        int[,,] matriz;
        int x, y, z, tipoFigura;
        Cubo cubo;

        public Figura()
        {
            x = y = z = 3;
            matriz = new int[x, y, z];
        }
        public void crearCubo()
        {
            cubo = new Cubo(1, 1, 1);
        }
        public int get(int i, int j, int k)
        {
            return matriz[i, j, k];
        }
        public void elegirFigura(int numeroDeFigura)
        {
            tipoFigura = numeroDeFigura;
            matriz = new int[x, y, z];
            switch (tipoFigura)
            {
                case 1:
                    {
                        matriz[0, 0, 1] = 1;
                        matriz[0, 1, 1] = 1;
                        matriz[0, 2, 1] = 1;
                        matriz[1, 1, 1] = 1;
                        matriz[2, 1, 1] = 0;
                    } break;
                case 2:
                    {
                        matriz[0, 1, 1] = 1;
                        matriz[1, 1, 1] = 1;
                        matriz[2, 1, 1] = 1;
                    } break;
                /*case 3:
                    {
                        matriz[0, 0, 1] = 1;
                        matriz[0, 1, 1] = 1;
                        matriz[1, 1, 1] = 1;
                        matriz[1, 2, 1] = 1;
                    } break;*/
                case 3:
                    {
                        matriz[0, 0, 1] = 1;
                        matriz[1, 0, 1] = 1;
                        matriz[0, 1, 1] = 1;
                        matriz[1, 1, 1] = 1;
                        matriz[0, 0, 0] = 1;
                        matriz[1, 0, 0] = 1;
                        matriz[0, 1, 0] = 1;
                        matriz[1, 1, 0] = 1;
                    } break;
                /*case 4:
                    {
                        matriz[0, 1, 1] = 1;
                        matriz[1, 1, 1] = 1;
                        matriz[2, 0, 1] = 1;
                        matriz[2, 1, 1] = 1;
                        matriz[2, 2, 1] = 1;
                    } break;*/
                /*case 4:
                    {
                        matriz[0, 0, 0] = 1;
                        matriz[0, 0, 1] = 1;
                        matriz[0, 0, 2] = 1;
                    } break;*/
                default:
                    {
                        matriz[0, 0, 1] = 1;
                        matriz[1, 0, 1] = 1;
                        matriz[2, 0, 1] = 1;
                        matriz[2, 1, 1] = 1;
                    }
                    break;
            }
        }
        public void dibujar(OpenGL open)
        {
            for(int i=0;i<x;i++)
            {
                for (int j = 0; j<y;j++)
                {
                    for (int k = 0; k<z; k++)
                    {
                        if (matriz[i, j, k] == 1)
                        {
                            Color color = Color.Gray;
                            cubo.dibujar(open, i, j, k,color);
                        }
                    }
                }
            }
        }
        public void rotacionFrontal(bool horario)
        {
            if (tipoFigura != 3)
            {
                int[,,] aux = new int[3, 3, 3];
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        for (int k = 0; k < z; k++)
                        {
                            if (horario)
                                aux[k, j, 2 - i] = matriz[i, j, k];
                            else
                            {
                                aux[2 - k, j, i] = matriz[i, j, k];
                            }
                        }
                    }
                }
                matriz = aux;
            }
        }
        public void rotacionVertical(bool horario)
        {
            if (tipoFigura != 3)
            {
                int[,,] aux = new int[3, 3, 3];
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        for (int k = 0; k < z; k++)
                        {
                            if(horario)
                                aux[j, 2 - i, k] = matriz[i, j, k];
                            else
                                aux[2 - j, i, k] = matriz[i, j, k];
                        }
                    }
                }
                matriz = aux;
            }
        }
        public void rotacionHorizontal(bool horario)
        {
            if (tipoFigura != 3)
            {
                int[,,] aux = new int[3, 3, 3];
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        for (int k = 0; k < z; k++)
                        {
                            if(horario)
                                aux[i, k, 2 - j] = matriz[i, j, k];
                            else
                                aux[i, 2 - k, j] = matriz[i, j, k];
                        }
                    }
                }
                matriz = aux;
            }
        }
    }
}
