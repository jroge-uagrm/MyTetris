using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpGL;

namespace SharpGLWinformsApplication3.clases
{
    public class mallaG
    {
        int x, y, z;
        int[, ,] m;
        
        public mallaG(int xx,int yy,int zz) {
            x = xx;
            y = yy;
            z = zz;
        }

        public void setX(int xx) {
            x = xx;
        }

        public int getX() {
            return x;
        }

        public void setY(int yy)
        {
            y = yy;
        }

        public int getY()
        {
            return y;
        }

        public void setZ(int zz)
        {
            z = zz;
        }

        public int getZ()
        {
            return z;
        }

        public void dibujarEn(OpenGL gl)
        {
            double x1, y1, z1;
            x1 = 0.5; y1 = 0.5; z1 =0.5;
            //xx = xx + 0.5; yy = yy + 0.5; zz = zz + 0.5;
            gl.Translate(0.5,0.5,0.5);
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

        public void drawnCube(OpenGL gl,espacio3D E3D,cubo cu) {
            for (int i = 0; i < E3D.getX(); i++)
            {
                for (int j = 0; j < E3D.getY(); j++)
                {
                    for (int k = 0; k < E3D.getZ(); k++)
                    {
                        if(E3D.get(i,j,k)!=0){
                            gl.Color(0.2f,0.3f,0.5f);
                            cu.draw(gl,i,j,k);
                        }
                    }
                }
            }
        }

        public void drawnFigure(OpenGL gl, espacio3D E3D, figura f)
        {
            for (int i = 0; i < E3D.getX(); i++)
            {
                for (int j = 0; j < E3D.getY(); j++)
                {
                    for (int k = 0; k < E3D.getZ(); k++)
                    {
                        if (E3D.get(i, j, k) == 1)
                        {
                            //c.draw(gl, i, j, k);
                        }
                    }
                }
            }
        }

        public void draw(OpenGL gl) {
            gl.Color(0.2f, 0.5f, 0f);
            for (int i = 0; i <= x;i++ )
            {                
                gl.Begin(OpenGL.GL_LINE_STRIP);
                    gl.Vertex(i,y,0);
                    gl.Vertex(i,y,z);
                    gl.Vertex(i,0,z);
                    gl.Vertex(i,0,0);
                gl.End();    
            }

            for (int j = 0; j < y; j++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                    gl.Vertex(0,j,0);
                    gl.Vertex(0,j,z);
                    gl.Vertex(x,j,z);
                    gl.Vertex(x,j,0);
                gl.End();    
            }
            
            for (int k = 0; k <= z; k++)
            {
                gl.Begin(OpenGL.GL_LINE_LOOP);
                    gl.Vertex(0,y,k);
                    gl.Vertex(x,y,k);
                    gl.Vertex(x,0,k);
                    gl.Vertex(0,0,k);
                gl.End();    
            }
        }
            
    }
}
