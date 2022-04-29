using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa5.ctr
{
    class Parte
    {
        public LinkedList<Punto> l;
        public Punto cg { get; set; }

        public Color color { get; set; }

        public Parte()
        {
            l = new LinkedList<Punto>();
            color = Color.White;
        }

        public void addPunto(Punto punto)
        {
            l.AddLast(punto);
        }

        public void dibujar()
        {
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(color);
            foreach (Punto punto in l)
            {
                GL.Vertex3(punto.ToVector3());
            }
            GL.End();
        }
    }
}

