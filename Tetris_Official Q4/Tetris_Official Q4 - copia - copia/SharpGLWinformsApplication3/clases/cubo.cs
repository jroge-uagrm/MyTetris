using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace SharpGLWinformsApplication3
{
    public class cubo
    {
        double x, y, z;
        double t;
        public cubo(double xx, double yy,double zz) {
            x = xx;
            y = yy;
            z = zz;
        }

        public cubo(int x) {
            t = x;
            z = 8;
        }

        public void changeXYZ(double xx, double yy, double zz)
        {
            x = xx;
            y = yy;
            z = zz;
        }

        public void draw(OpenGL gl) {
            double x1, y1, z1;
            x1 = x / 2; y1 = y / 2; z1 =z / 2;
            gl.Color(0f,1f,0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1,y1,z1);
            gl.Vertex(-x1,-y1,z1);
            gl.Vertex(x1,-y1,z1);
            gl.Vertex(x1,y1,z1);
            gl.End();
            
            gl.Color(0.2f, 0.2f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1,y1,-z1);
            gl.Vertex(-x1,-y1,-z1);
            gl.Vertex(x1,-y1,-z1);
            gl.Vertex(x1,y1,-z1);
            gl.End();

            gl.Color(1f,0f,1f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, y1, z1);
            gl.Vertex(-x1, -y1, z1);
            gl.Vertex(-x1, -y1, -z1);
            gl.Vertex(-x1, y1, -z1);
            gl.End();

            gl.Color(1f, 0f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x1, -y1, z1);
            gl.Vertex(x1, -y1, -z1);
            gl.Vertex(x1, y1, -z1);
            gl.End();

            gl.Color(0f, 0.2f, 0.5f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, -y1, z1);
            gl.Vertex(x1, -y1, z1);
            gl.Vertex(x1, -y1, -z1);
            gl.Vertex(-x1, -y1, -z1);
            gl.End();

            gl.Color(0f, 0.2f, 0.0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 ,y1, z1);
            gl.Vertex( x1 ,y1, z1);
            gl.Vertex( x1 ,y1, -z1);
            gl.Vertex(-x1 ,y1, -z1);
            gl.End();
            //gl.Translate(x, y, z);
        }

        public void draw(OpenGL gl, double xx2, double yy2, double zz2)
        {
            double xx=xx2+0.5, yy=yy2+0.5, zz=zz2+0.5;
            double x1, y1, z1;
            x1 = x / 2; y1 = y / 2; z1 = z / 2;
            //gl.Color(0f, 1f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.End();

            //gl.Color(0.2f, 0.2f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1+xx, y1+yy, -z1+zz);
            gl.Vertex(-x1+xx, -y1+yy, -z1+zz);
            gl.Vertex(x1+xx, -y1+yy, -z1+zz);
            gl.Vertex(x1+xx, y1+yy, -z1+zz);
            gl.End();

            //gl.Color(1f, 0f, 1f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1+zz);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            //gl.Color(1f, 0f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.End();

            //gl.Color(0f, 0.2f, 0.5f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, -y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, -y1 + yy, -z1 + zz);
            gl.End();

            //gl.Color(0f, 0.2f, 0.0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, z1 + zz);
            gl.Vertex(x1 + xx, y1 + yy, -z1 + zz);
            gl.Vertex(-x1 + xx, y1 + yy, -z1 + zz);
            gl.End();
            //gl.Translate(x, y, z);
        }

        public void dibujarEn(OpenGL gl,double xx, double yy, double zz) {
            double x1, y1, z1;
            x1 = xx; y1 = yy ; z1 = zz;
            gl.Color(0f, 1f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, y1, z1);
            gl.Vertex(-x1, -y1, z1);
            gl.Vertex(x1, -y1, z1);
            gl.Vertex(x1, y1, z1);
            gl.End();

            gl.Color(0.2f, 0.2f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, y1, -z1);
            gl.Vertex(-x1, -y1, -z1);
            gl.Vertex(x1, -y1, -z1);
            gl.Vertex(x1, y1, -z1);
            gl.End();

            gl.Color(1f, 0f, 1f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, y1, z1);
            gl.Vertex(-x1, -y1, z1);
            gl.Vertex(-x1, -y1, -z1);
            gl.Vertex(-x1, y1, -z1);
            gl.End();

            gl.Color(1f, 0f, 0f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x1, -y1, z1);
            gl.Vertex(x1, -y1, -z1);
            gl.Vertex(x1, y1, -z1);
            gl.End();

            gl.Color(0f, 0.2f, 0.5f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, -y1, z1);
            gl.Vertex(x1, -y1, z1);
            gl.Vertex(x1, -y1, -z1);
            gl.Vertex(-x1, -y1, -z1);
            gl.End();

            gl.Color(0f, 0.2f, 0.2f);
            gl.Begin(OpenGL.GL_QUADS);
            gl.Vertex(-x1, y1, z1);
            gl.Vertex(x1, y1, z1);
            gl.Vertex(x1, y1, -z1);
            gl.Vertex(-x1, y1, -z1);
            gl.End();
        }
    }
}
