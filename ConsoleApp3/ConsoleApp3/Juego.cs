using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Progra_Grafica_3D
{
    public class Juego
    {
        Contenedor contenedor;
        Figura figurita;
        GameWindow ventana;
        int cambiar_fig;
        double theta = 0.0;
        double rot_x, rot_y, rot_z = 0.0;
        double pos_x = 40.0, pos_z = 40.0;
        double pos_y = 80.0;
        Matrix4d matriz = new Matrix4d();

        public Juego(GameWindow ventana)
        {
            this.ventana = ventana;
            cambiar_fig = 0;
            this.figurita = new Figura(cambiar_fig);
            Empezar();
        }
        private void Empezar()
        {
            ventana.Load += myLoad;
            ventana.Resize += myResize;
            ventana.UpdateFrame += updateF;
            ventana.KeyDown += keyDown;
            ventana.RenderFrame += renderF;
            ventana.Run(1.0/4.0);
        }
        private void myLoad(object o, EventArgs e)
        {
            GL.ClearColor(OpenTK.Graphics.Color4.Black);
            GL.Enable(EnableCap.DepthTest);
        }
        private void myResize(object o, EventArgs e)
        {
            GL.Viewport(0,0,ventana.Width,ventana.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            matriz=Matrix4d.Perspective
                (45.0f,ventana.Width/ventana.Height,2.0f,2000.0f);
            GL.LoadMatrix(ref matriz);
            GL.MatrixMode(MatrixMode.Modelview);
        }

        void updateF(object o, EventArgs e)
        {
            KeyboardState k = Keyboard.GetState();
            if(k.IsKeyDown(Key.Left) || k.IsKeyDown(Key.Down) || k.IsKeyDown(Key.PageDown))
            {
                if (k.IsKeyDown(Key.Left))
                {
                    theta -= 1.0;
                    rot_y = 1.0; rot_x = rot_z = 0.0;
                    /*
                    if (rot_x == 0.0 && rot_z == 0.0)
                    {
                        theta -= 1.0;  rot_y += 0.0;
                        rot_y = rot_y %360; rot_x = rot_z = 0.0;
                    }
                    else if (rot_x == 0.0){
                        rot_y += 1.0;
                        rot_y = rot_y % 360; rot_z -= 1.0;
                    }
                    else if (rot_z == 0.0)
                    {
                        rot_y += 1.0;
                        rot_y = rot_y % 360; rot_x -= 1.0;
                    }
                    else
                    {
                        rot_y += 1.0;
                        rot_y = rot_y % 360; rot_x -= 1.0; rot_z -= 1.0;
                    }
                    */
                }

                if (k.IsKeyDown(Key.Down))
                {
                    theta -= 1.0;
                    rot_x = 1.0; rot_y = rot_z = 0.0;
                    /*
                    if (rot_y == 0.0 && rot_z == 0.0)
                    {
                        theta -= 1.0; rot_x += 1.0;
                        rot_x = rot_x % 360; rot_y = rot_z = 0.0;
                    }
                    else if (rot_y == 0.0)
                    {
                        rot_x += 1.0;
                        rot_x = rot_x % 360; rot_z -= 1.0;
                    }
                    else if (rot_z == 0.0)
                    {
                        rot_x += 1.0;
                        rot_x = rot_x % 360; rot_y -= 1.0;
                    }
                    else
                    {
                        rot_x += 1.0;
                        rot_x = rot_x % 360; rot_y -= 1.0; rot_z -= 1.0;
                    }
                    */
                }

                if (k.IsKeyDown(Key.PageDown))
                {
                    theta -= 1.0;
                    rot_z = 1.0; rot_x = rot_y = 0.0;
                    rot_z %= 360;
                    /*
                    if (rot_y == 0.0 && rot_x == 0.0)
                    {
                        theta -= 1.0; rot_z += 1.0;
                        rot_z = rot_z % 360; rot_y = rot_x = 0.0;
                    }
                    else if (rot_y == 0.0)
                    {
                        rot_z += 1.0;
                        rot_z = rot_z % 360; rot_x -= 1.0;
                    }
                    else if (rot_x == 0.0)
                    {
                        rot_z += 1.0;
                        rot_z = rot_z % 360; rot_y -= 1.0;
                    }
                    else
                    {
                        rot_z += 1.0;
                        rot_z = rot_z % 360; rot_y -= 1.0; rot_x -= 1.0;
                    }
                    */
                }

                if (k.IsKeyDown(Key.Left) && k.IsKeyDown(Key.Down))
                {
                    theta += 1.0;
                    rot_x += 1.0;
                    rot_y += 1.0;
                    rot_x = rot_x % 360;
                    rot_y = rot_y % 360;
                    rot_z = 0.0;
                }
            }

            if (k.IsKeyDown(Key.Right) || k.IsKeyDown(Key.Up) || k.IsKeyDown(Key.PageUp))
            {
                if (k.IsKeyDown(Key.Right))
                {
                    theta += 1.0;
                    rot_y = 1.0; rot_x = rot_z = 0.0;
                    /*
                    if (rot_x == 0.0 && rot_z == 0.0)
                    {
                        theta += 1.0; rot_y += 1.0;
                        rot_y = rot_y % 360; rot_x = rot_z = 0.0;
                    }
                    else if (rot_x == 0.0)
                    {
                        rot_y += 1.0;
                        rot_y = rot_y % 360; rot_z -= 1.0;
                    }
                    else if (rot_z == 0.0)
                    {
                        rot_y += 1.0;
                        rot_y = rot_y % 360; rot_x -= 1.0;
                    }
                    else
                    {
                        rot_y += 1.0;
                        rot_y = rot_y % 360; rot_x -= 1.0; rot_z -= 1.0;
                    }*/
                }

                if (k.IsKeyDown(Key.Up))
                {
                    theta += 1.0;
                    rot_x = 1.0; rot_y = rot_z = 0.0;
                    /*
                    if (rot_y == 0.0 && rot_z == 0.0)
                    {
                        theta += 1.0; rot_x += 1.0;
                        rot_x = rot_x % 360; rot_y = rot_z = 0.0;
                    }
                    else if (rot_y == 0.0)
                    {
                        rot_x += 1.0;
                        rot_x = rot_x % 360; rot_z -= 1.0;
                    }
                    else if (rot_z == 0.0)
                    {
                        rot_x += 1.0;
                        rot_x = rot_x % 360; rot_y -= 1.0;
                    }
                    else
                    {
                        rot_x += 1.0;
                        rot_x = rot_x % 360; rot_y -= 1.0; rot_z -= 1.0;
                    }*/

                }

                if (k.IsKeyDown(Key.PageUp))
                {
                    if (rot_y == 0.0 && rot_x == 0.0)
                    {
                        theta += 1.0; rot_z += 1.0;
                        rot_z = rot_z % 360; rot_y = rot_x = 0.0;
                    }
                    else if (rot_y == 0.0)
                    {
                        rot_z += 1.0;
                        rot_z = rot_z % 360; rot_x -= 1.0;
                    }
                    else if (rot_x == 0.0)
                    {
                        rot_z += 1.0;
                        rot_z = rot_z % 360; rot_y -= 1.0;
                    }
                    else
                    {
                        rot_z += 1.0;
                        rot_z = rot_z % 360; rot_y -= 1.0; rot_x -= 1.0;
                    }

                }

                if (k.IsKeyDown(Key.Up) && k.IsKeyDown(Key.Right))
                {
                    theta -= 1.0;
                    rot_x += 1.0;
                    rot_y += 1.0;
                    rot_z = 0.0;
                }
            }


            if (theta > 360 || theta < -360)
            {
                theta = 0;
                cambiar_fig++;
                cambiar_fig = cambiar_fig % 7;
            }
        }

        void renderF(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Translate(0.0, 0.0, -95.0);
            GL.Rotate(theta, rot_x, rot_y, rot_z );

            GL.Begin(PrimitiveType.Lines);

            this.contenedor = new Contenedor();

            GL.End();

            GL.Begin(PrimitiveType.Quads);

            figurita.figurita(pos_x, pos_y, pos_z);
            
            GL.End();

            ventana.SwapBuffers();

        }

        void keyDown(object o, KeyboardKeyEventArgs e)
        {
            if(e.Key == Key.D)
            {
                this.pos_x += 10.0;
            }
            if (e.Key == Key.A)
            {
                this.pos_x -= 10.0;
            }
            if (e.Key == Key.W)
            {
                this.pos_z += 10.0;
            }
            if (e.Key == Key.X)
            {
                this.pos_z -= 10.0;
            }
            if (e.Key == Key.S)
            {
                this.pos_y -= 10.0;
            }
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            if (e.Key == Key.O)
            {
                matriz = Matrix4d.CreateOrthographic(300.0, 300.0, 1.0, 300.0);
            }
            if (e.Key == Key.P)
            {
                //  matriz = Matrix4d.Perspective(45.0f, ventana.Width / ventana.Height, 50.0f, 200.0f);
                matriz = Matrix4d.Perspective(45.0f, ventana.Width / ventana.Height, 2.0f, 2000.0f);
                // matriz = Matrix4d.CreatePerspectiveFieldOfView(20.0f, ventana.Width / ventana.Height, 50.0f, 200.0f);
            }
            GL.LoadMatrix(ref matriz);
            GL.MatrixMode(MatrixMode.Modelview);
        }
  


    }
}
