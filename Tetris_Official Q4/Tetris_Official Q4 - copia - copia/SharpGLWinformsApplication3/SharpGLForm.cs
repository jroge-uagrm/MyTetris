using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using SharpGLWinformsApplication3.clases;

namespace SharpGLWinformsApplication3
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        mallaG m;
        cubo c;
        espacio3D s;
        figura f;
        int tx, ty, tz;
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
            timer2.Stop();
            timer2.Interval = 50;
            s = new espacio3D(7, 7, 10);
            m = new mallaG(s.getX(),s.getY(),s.getZ());
            c = new cubo(1,1,1);
            f = new figura();
            f.Choosefigures(2);
            //f.randomFig();
            tz = -1;
            tx = 3;
            ty = 3;
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            s.avanzar();
            OpenGL gl = openGLControl.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.Translate(tx,ty,tz);
            f.dibujar(gl, c);
            gl.PopMatrix();
            gl.PushMatrix();
            m.drawnCube(gl, s, c);
            m.draw(gl);
        }



        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            Color dc = Color.Beige;
            byte w=dc.R;
            byte re = dc.G;
            byte rq = dc.B;
            gl.ClearColor(dc.R,dc.G,dc.B,dc.A);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            OpenGL gl = openGLControl.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);
            gl.LookAt(4, 5,-7, 4,4, 0, 0, 1, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {

        }

        //esta bien
        private void openGLControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case '4':
                    {
                        if (s.RotarEnNegY(f, tx, ty, tz))
                            f.rotarNegY();
                    }
                    break;
                case '6':
                    {
                        if (s.RotarEnY(f, tx, ty, tz))
                            f.rotarY();
                    }
                    break;
                case '8':
                    {
                        if (s.RotarEnNegX(f, tx, ty, tz))
                            f.rotarNegX();
                    }
                    break;
                case '5':
                    {
                        if (s.RotarEnX(f, tx, ty, tz))
                            f.rotarX();
                    }
                    break;

                case '7':
                    {
                        if (s.RotarEnNegZ(f, tx, ty, tz))
                            f.rotarNegZ();
                    }
                    break;

                case '9':
                    {
                        if(s.RotarEnZ(f,tx,ty,tz))
                        f.rotarZ();
                    }
                    break;
                case 'a':
                    {
                        if (s.avance3(f, tx + 1, ty, tz))
                            tx++;
                    }
                    break;
                case 'd':
                    {
                        if (s.avance3(f, tx - 1, ty, tz))
                            tx--;
                    }
                    break;
                case 'w':
                    {
                        if (s.avance3(f, tx, ty + 1, tz))
                            ty++;
                    }
                    break;
                case 's':
                    {
                        if (s.avance3(f, tx, ty - 1, tz))
                            ty--;
                    }
                    break;
                case 'q':
                    {
                        if (s.avance3(f, tx, ty, tz + 1)) {
                            //tz++;
                            timer1.Stop();
                            timer2.Start();
                        }
                        
                    }
                    break;
                case 'e':
                    {
                        if (s.avance3(f, tx, ty, tz - 1))
                            tz--;
                    }
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //OpenGL gl= openGLControl.OpenGL;
            
            if (s.avance3(f,(int)tx,(int)ty,(int)tz+1)) {
                tz++;
            }                
            else{
                s.addFig(f,(int)tx,(int)ty,(int)tz);
                //f.randomFig();
                tz = -1;
                tx = 3;
                ty = 3;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (s.avance3(f, (int)tx, (int)ty, (int)tz + 1))
            {
                tz++;
            }
            else
            {
                s.addFig(f, (int)tx, (int)ty, (int)tz);
                //f.randomFig();
                tz = -1;
                tx = 3;
                ty = 3;
                timer2.Stop();
                timer1.Start();
            }
        }
    }
}
