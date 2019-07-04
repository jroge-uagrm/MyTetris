using SharpGL;
using System;

namespace Tetris
{
    public class Contenedor
    {
        int[,,] matrizEspacios;
        Figura figuraCayendo;
        int tx, ty, tz;
        int ancho, largo, alto, numero, camara;

        public Contenedor(int nuevoAncho, int nuevoLargo, int nuevoAlto)
        {
            camara = 0;
            ancho = nuevoAncho; largo = nuevoLargo; alto = nuevoAlto;
            matrizEspacios = new int[nuevoAncho, nuevoLargo, nuevoAlto];
        }
        public void nuevaFiguraCayendo(OpenGL open,int Width,int Height)
        {
            figuraCayendo = new Figura();
            figuraCayendo.crearCubo();
            Random r = new Random();
            figuraCayendo.elegirFigura(r.Next(0,5));
            rotarCamaraHorizontal(open, Width, Height);
            tz = 0;
            tx = 0;
            ty = 0;
        }
        public void desplazarHaciaAbajo(OpenGL open,int Width,int Height)
        {
            if (avance(figuraCayendo, tx, ty, tz + 1))
            {
                tz++;
            }
            else
            {
                añadirFigura(figuraCayendo, tx, ty, tz);
                nuevaFiguraCayendo(open,Width,Height);
            }
        }
        public int getTX() => tx;
        public int getTY() => ty;
        public int getTZ() => tz;
        public void dibujarFiguraQueCae(OpenGL open) => figuraCayendo.dibujar(open);
        public void desplazarHaciaLaIzquierda()
        {
            if(avance(figuraCayendo, tx + 1, ty, tz)) tx++;
        }
        public void desplazarHaciaLaDerecha()
        {
            if (avance(figuraCayendo, tx - 1, ty, tz)) tx--;
        }
        public void desplazarhaciaElFondo()
        {
            if (avance(figuraCayendo, tx, ty + 1, tz)) ty++;
        }
        public void desplazarHaciaElFrente()
        {
            if (avance(figuraCayendo, tx, ty - 1, tz)) ty--;
        }
        public void rotacionFrontalFiguraQueCae(bool sentidoHorario)
        {
            figuraCayendo.rotacionFrontal(sentidoHorario);
            if (!avance(figuraCayendo, tx, ty, tz))
            {
                figuraCayendo.rotacionFrontal(!sentidoHorario);
            }
        }
        public void rotacionVerticalFiguraQueCae(bool sentidoHorario)
        {
            figuraCayendo.rotacionVertical(sentidoHorario);
            if (!avance(figuraCayendo, tx, ty, tz))
            {
                figuraCayendo.rotacionVertical(!sentidoHorario);
            }
        }
        public void rotacionHorizontalFiguraQueCae(bool sentidoHorario)
        {
            figuraCayendo.rotacionHorizontal(sentidoHorario);
            if (!avance(figuraCayendo, tx, ty, tz))
            {
                figuraCayendo.rotacionHorizontal(!sentidoHorario);
            }
        }
        public bool avance(Figura figura, int xx, int yy, int zz)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        try
                        {
                            if (figura.get(i, j, k) == 1 && 
                                matrizEspacios[i + xx, j + yy, k + zz] == 1)
                            {
                                return false;
                            }
                        }
                        catch (Exception)
                        {
                            return false;
                            throw;
                        }
                    }
                }
            }
            return true;
        }
        public void añadirFigura(Figura figura, int xx, int yy, int zz)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        if (figura.get(i, j, k) == 1)
                        {
                            matrizEspacios[i + xx, j + yy, k + zz]=1;
                        }
                    }
                }
            }
            if (areaCompletada())
            {
                eliminarArea();
            }
        }
        public bool areaCompletada()
        {
            return false;
        }
        public void eliminarArea()
        {

        }
        public void dibujarTodoElContenedor(OpenGL gl)
        {
            gl.Color(0, 0, 0);
            for (int i = 0; i <= ancho; i++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(i, largo, 0);
                gl.Vertex(i, largo, alto);
                gl.Vertex(i, 0, alto);
                //gl.Vertex(i, 0, 0);
                gl.End();
            }

            for (int j = 0; j < largo; j++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(0, j, 0);
                gl.Vertex(0, j, alto);
                gl.Vertex(ancho, j, alto);
                gl.Vertex(ancho, j, 0);
                gl.End();
            }

            for (int k = 0; k <= alto; k++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(0, 0, k);
                gl.Vertex(0, largo, k);
                gl.Vertex(ancho, largo, k);
                gl.Vertex(ancho, 0, k);
                //gl.Vertex(0, 0, k);
                gl.End();
            }
            for(int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                    for (int k = 0; k < alto; k++)
                    {
                        if (matrizEspacios[i, j, k] == 1)
                        {
                            Cubo cubo = new Cubo(1, 1, 1);
                            cubo.dibujarContenedor(gl,i,j,k);
                        }
                    }
                }
            }
        }
        public void rotarCamaraHorizontal(OpenGL open,double Width,double Height)
        {
            open.MatrixMode(OpenGL.GL_PROJECTION);
            open.LoadIdentity();
            open.Perspective(60.0f, Width / Height, 1, 100);
            switch (camara)
            {
                case 0:
                    {
                        //VISTA FRONTAL
                        open.LookAt(ancho / 2, -alto, 5, ancho / 2, largo / 2, alto / 2, 0, 0, -1);
                    }
                    break;
                case 1:
                    {
                        //VISTA AEREA
                        open.LookAt(ancho / 2, largo / 2, -alto, ancho / 2, largo / 2, alto / 2, 0, 1, 0);
                    }
                    break;
                case 2:
                    {
                        //VISTA LATERAL
                        open.LookAt(-alto, alto/2, 5, ancho / 2, largo / 2, alto / 2, 0, 0, -1);
                    }
                    break;
            }
            open.MatrixMode(OpenGL.GL_MODELVIEW);
            camara++;
            camara %= 3;
        }
    }
}







