using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace DemoGL
{
    class Game : GameWindow
    {
        public Game()
                : base(3000, 1700, new GraphicsMode(32, 0, 0, 4),"Demo")
            {
            WindowState = WindowState.Fullscreen;
        }

        #region OnLoad
 
        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case OpenTK.Input.Key.Escape:
                    Exit();
                    break;
            }
        }

            #endregion

        #region OnResize

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-2.0, 2.0, -2.0, 2.0, 0.0, 4.0);
            

            base.OnResize(e);
        }

        #endregion

        #region OnUpdateFrame

  
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
           
        }

        #endregion

        #region OnRenderFrame
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.DepthBufferBit);
          
            GL.Color3(1.0f, 1.0f, 0.0f);
            GL.Begin(BeginMode.Triangles);

            //GL.Color3(1.0f, 1.0f, 0.0f); 
            GL.Vertex2(-1.0f, 1.0f);
            //GL.Color3(1.0f, 0.0f, 0.0f); 
            GL.Vertex2(0.0f, -1.0f);
            //GL.Color3(0.2f, 0.9f, 1.0f);
            GL.Vertex2(1.0f, 1.0f);

            GL.End();

            this.SwapBuffers();
        }

        #endregion

        #region public static void Main()

            
        [STAThread]
        public static void Main()
        {
            using (Game MyGame = new Game())
            {
                
                MyGame.Run(30.0, 0.0);
            }
        }

        #endregion
        }

        
    }
