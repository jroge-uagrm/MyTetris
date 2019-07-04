using SharpGL;
using System.Drawing;

namespace Tetris
{
    public class Cubo
    {
        double ancho, largo, alto;
        public Cubo(double nuevoAncho,double nuevoLargo,double nuevoAlto)
        {
            ancho = nuevoAncho;largo = nuevoLargo;alto = nuevoAlto;
        }
        public void dibujar(OpenGL gl,double nuevaX,double nuevaY,double nuevaZ,Color color)
        {
            double xx = nuevaX + 0.5, yy = nuevaY + 0.5, zz = nuevaZ + 0.5;
            double x1, y1, z1;
            x1 = ancho / 2; y1 = largo / 2; z1 = alto / 2;
            gl.Color(color.R, color.G, color.B);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.End();

            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.End();
            //gl.Translate(x, y, z);
        }
        public void dibujarContenedor(OpenGL gl, double nuevaX, double nuevaY, double nuevaZ)
        {
            double xx = nuevaX + 0.5, yy = nuevaY + 0.5, zz = nuevaZ + 0.5;
            double x1, y1, z1;
            x1 = ancho / 2; y1 = largo / 2; z1 = alto / 2;
            gl.Color(0, 0.5, 0);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.End();

            gl.Color(0, 0.5, 0);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            gl.Color(0, 0.5, 0);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            gl.Color(0, 0.5, 0);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            gl.Color(0, 0.5, 0);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.End();

            gl.Color(0, 0.5, 0);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.End();
            //gl.Translate(x, y, z);
        }
    }
}
