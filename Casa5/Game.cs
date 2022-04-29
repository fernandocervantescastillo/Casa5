using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa5.ctr;
using Casa5.extras;
using Casa5.objetos;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa5
{
    class Game : GameWindow
    {
        
        Escenario escenario;
        private float angle;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title) { }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color4.Black);


            escenario = new Escenario();

            Casa casa = new Casa(5, 5, 5, 0, 0, 0);
            Casa casa1 = new Casa(5, 5, 5, 10, 0, 0);

            casa.guardarCasa("Casa.txt");
            casa1.guardarCasa("Casa1.txt");


            Casa c1 = Casa.getCasa("Casa.txt");
            Casa c2 = Casa.getCasa("Casa1.txt");

            escenario.addObjeto("casa", c1);
            escenario.addObjeto("casa1", c2);

            angle = 0;
            base.OnLoad(e);
        }

        protected override void OnUnload(EventArgs e)
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.DeleteBuffer(VertexBufferObject);
            base.OnUnload(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.DepthMask(true);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);
            GL.LoadIdentity();

            angle = angle + 0.8f;
            GL.Rotate(20, 1, 0, 0);
            GL.Rotate(angle, 0, 1, 0);
            //this.casa.dibujar();
            //this.casa1.dibujar();

            escenario.dibujar();

            Context.SwapBuffers();
            base.OnRenderFrame(e);

        }


        protected override void OnResize(EventArgs e)
        {
            float d = 30;
            GL.Viewport(0, 0, Width, Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-d, d, -d, d, -d, d);
            //GL.Frustum(-80, 80, -80, 80, 4, 100);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            base.OnResize(e);
        }



    }
}
