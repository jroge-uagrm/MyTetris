using OpenTK.Graphics.OpenGL;

namespace Progra_Grafica_3D
{
    public class Figura
    {
        int fig = 0;
        double x1, y1, z1 = 0;

        public Figura(int i)
        {
            this.fig = i;
            figurita(40.0,80.0,40.0);
        }

        public void figurita(double posx, double posy, double posz)
        {
            switch (fig)
            {
                case 0:
                    x1 = y1 = 1.0;
                    z1 = 0;
                    cubo(0 + posx, 0 + posy, 0 + posz);
                    cubo(10 + posx, 0 + posy, 0 + posz);
                    cubo(10 + posx, 10 + posy, 0 + posz);
                    cubo(0 + posx, -10 + posy, 0 + posz);
                    break;
                case 1:
                    x1 = z1 = 1.0;
                    y1 = 0;
                    cubo(0, 0, 0);
                    cubo(10, 0, 0);
                    cubo(10, 10, 0);
                    cubo(0, 10, 0);
                    break;
                case 2:
                    z1 = y1 = 1.0;
                    x1 = 0;
                    cubo(0, 0, 0);
                    cubo(10, 0, 0);
                    cubo(20, 0, 0);
                    cubo(30, 0, 0);
                    break;
                case 3:
                    z1 = y1 = 0.0;
                    x1 = 1.0;
                    cubo(0, 0, 0);
                    cubo(10, 0, 0);
                    cubo(20, 0, 0);
                    cubo(10, -10, 0);
                    break;
                case 4:
                    x1 = z1 = 0.0;
                    y1 = 1.0;
                    cubo(0, 0, 0);
                    cubo(10, 0, 0);
                    cubo(20, 0, 0);
                    cubo(20, -10, 0);
                    break;
                case 5:
                    x1 = y1 = 0.0;
                    z1 = 1.0;
                    cubo(0, 0, 0);
                    cubo(10, 0, 0);
                    cubo(20, 0, 0);
                    cubo(0, -10, 0);
                    break;
                case 6:
                    x1 = y1 = 0.2;
                    z1 = 0.5;
                    cubo(0, 0, 0);
                    cubo(0, 10, 0);
                    cubo(10, 10, 0);
                    cubo(-10, 0, 0);
                    break;
                default:
                    cubo(0, 0, 0);
                    cubo(10, 0, 0);
                    cubo(10, 10, 0);
                    cubo(0, 10, 0);
                    break;
            }
        }

        void cubo(double a, double b, double c)
        {
            colorsito(); 
            //GL.Color3(1.0, 1.0, 0.0);
            GL.Vertex3(0.0 + a, 10.0 + b, 10.0 + c);
            GL.Vertex3(0.0 + a, 10.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 0.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 0.0 + b, 10.0 + c);
            colorsito();
            //GL.Color3(1.0, 0.0, 1.0);
            GL.Vertex3(10.0 + a, 10.0 + b, 10.0 + c);
            GL.Vertex3(10.0 + a, 10.0 + b, 0.0 + c);
            GL.Vertex3(10.0 + a, 0.0 + b, 0.0 + c);
            GL.Vertex3(10.0 + a, 0.0 + b, 10.0 + c);
            colorsito();
            //GL.Color3(0.0, 1.0, 1.0);
            GL.Vertex3(10.0 + a, 0.0 + b, 10.0 + c);
            GL.Vertex3(10.0 + a, 0.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 0.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 0.0 + b, 10.0 + c);
            colorsito();
            //GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex3(10.0 + a, 10.0 + b, 10.0 + c);
            GL.Vertex3(10.0 + a, 10.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 10.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 10.0 + b, 10.0 + c);
            colorsito();
            //GL.Color3(0.0, 1.0, 0.0);
            GL.Vertex3(10.0 + a, 10.0 + b, 0.0 + c);
            GL.Vertex3(10.0 + a, 0.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 0.0 + b, 0.0 + c);
            GL.Vertex3(0.0 + a, 10.0 + b, 0.0 + c);
            colorsito();
            //GL.Color3(0.0, 0.0, 1.0);
            GL.Vertex3(10.0 + a, 10.0 + b, 10.0 + c);
            GL.Vertex3(10.0 + a, 0.0 + b, 10.0 + c);
            GL.Vertex3(0.0 + a, 0.0 + b, 10.0 + c);
            GL.Vertex3(0.0 + a, 10.0 + b, 10.0 + c);
        }

        void colorsito()
        {
            GL.Color3(x1,y1,z1);
        }
    }
}
