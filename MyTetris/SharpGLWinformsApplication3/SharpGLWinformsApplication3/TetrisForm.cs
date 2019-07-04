using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SharpGL;

namespace Tetris
{
    public partial class TetrisForm: Form
    {
        Contenedor contenedor;
        int a=10,b=10,c=20;
        OpenGL open;
        Thread caida;
        bool juegoEnMarcha;
        public TetrisForm()
        {
            InitializeComponent();
            juegoEnMarcha = true;
            contenedor = new Contenedor(a, b, c);
            contenedor.nuevaFiguraCayendo(open,Width,Height);
            caida = new Thread(ejecutarCaida);
            caida.Start();
        }
        private void ejecutarCaida()
        {
            while (juegoEnMarcha)
            {
                contenedor.desplazarHaciaAbajo(open,Width,Height);
                Thread.Sleep(1000);
            }
            caida.Abort();
        }
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            open = openGLControl.OpenGL;
            open.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            open.LoadIdentity();
            open.PushMatrix();
            open.Translate(
                contenedor.getTX(),
                contenedor.getTY(),
                contenedor.getTZ()
            );
            contenedor.dibujarFiguraQueCae(open);
            open.PopMatrix();
            open.PushMatrix();
            contenedor.dibujarTodoElContenedor(open);
            //contenedor.dibujarCubo(open,figura.getCubo());
            //contenedor.dibujarEn(open);
        }
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            open = openGLControl.OpenGL;
            open.ClearColor((float)0.1,(float)0.9,(float)0.5,0);
        }
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            open = openGLControl.OpenGL;
            open.MatrixMode(OpenGL.GL_PROJECTION);
            open.LoadIdentity();
            open.Perspective(60.0f, (double)Width / (double)Height, 0.001, c * 3);
            //open.LookAt(4, 5,-7, 4,4, 0, 0, 1,0);PRUEBA 1
            int ancho = a, alto = b, largo = c;
            if (contenedor != null)
            {
                contenedor.rotarCamaraHorizontal(open, Width, Height);
                contenedor.rotarCamaraHorizontal(open, Width, Height);
                contenedor.rotarCamaraHorizontal(open, Width, Height);
            }
            open.MatrixMode(OpenGL.GL_MODELVIEW);
        }
        private void openGLControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'a':contenedor.desplazarHaciaLaIzquierda();
                    break;
                case 'd':contenedor.desplazarHaciaLaDerecha();
                    break;
                case 'w':contenedor.desplazarhaciaElFondo();
                    break;
                case 's':contenedor.desplazarHaciaElFrente();
                    break;
                case 'r':
                    contenedor.rotarCamaraHorizontal(open, Width, Height);
                    break;
                case 'k':contenedor.rotacionFrontalFiguraQueCae(true);
                    break;
                case 'i':contenedor.rotacionFrontalFiguraQueCae(false);
                    break;
                case 'l':contenedor.rotacionVerticalFiguraQueCae(true);
                    break;
                case 'o':contenedor.rotacionVerticalFiguraQueCae(false);
                    break;
                case 'ñ':contenedor.rotacionHorizontalFiguraQueCae(true);
                    break;
                case 'p':contenedor.rotacionHorizontalFiguraQueCae(false);
                    break;
            }
        }
    }
}
