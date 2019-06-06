using OpenTK.Graphics.OpenGL;

namespace Progra_Grafica_3D
{
    class Contenedor
    {
        public Contenedor()
        {
            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(-50.0, 100.0, 0.0);
            GL.Vertex3(-50.0, -100.0, 0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(-50.0, 100, 0.0);
            GL.Vertex3(-50.0, 100, 100.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(-50.0, 100, 100.0);
            GL.Vertex3(-50.0, -100, 100.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(-50.0, 100, 0.0);
            GL.Vertex3(50.0, 100, 0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, 100.0, 0.0);
            GL.Vertex3(50.0, -100.0, 0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, -100.0, 0.0);
            GL.Vertex3(-50.0, -100.0, 0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(-50.0, -100.0, 100.0);
            GL.Vertex3(-50.0, -100.0, 0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, -100.0, 100.0);
            GL.Vertex3(50.0, -100.0,  0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, 100.0, 100.0);
            GL.Vertex3(50.0, 100.0, 0.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, 100.0, 100.0);
            GL.Vertex3(50.0, -100.0, 100.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, 100.0, 100.0);
            GL.Vertex3(-50.0, 100.0, 100.0);

            GL.Color3(0.0, 0.0, 0.0);
            GL.Vertex3(50.0, -100.0, 100.0);
            GL.Vertex3(-50.0, -100.0, 100.0);
        }
    }
}
