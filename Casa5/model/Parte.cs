using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa5.interfaz;
using Casa5.objetos;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa5.ctr
{
    class Parte:IDibujo
    {
        public Punto cm { get; set; }
        public Color color { get; set; }
        public string name { get; set; }

        public LinkedList<Punto> l;

        public Parte()
        {
            l = new LinkedList<Punto>();
            color = Color.White;
        }

        public Parte(String name):this()
        {
            this.name = name;
        }

        public Parte(Parte p)
        {
            this.name = p.name;
            this.color = p.color;
            this.cm = p.cm.copiar();
            this.l = new LinkedList<Punto>();

            Punto punto;
            for(int i = 0; i < p.nroPuntos(); i++)
            {
                punto = p.getPunto(i);
                addPunto(punto.copiar());
            }
        }

        public void addPunto(Punto punto)
        {
            l.AddLast(punto);
        }

        public Punto getPunto(int i)
        {
            return (Punto)l.ElementAt(i);
        }

        public void borrarPunto(int pos)
        {
            Punto p = getPunto(pos);
            l.Remove(p);
        }

        public void borrarPunto(Punto punto)
        {
            l.Remove(punto);
        }

        public int nroPuntos() 
        {
            return l.Count;
        }

        public Parte copiar()
        {
            Parte p1 = new Parte(this);
            return p1;
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

        public void dispose()
        {
            l.Clear();
        }

        public void rotar()
        {
            throw new NotImplementedException();
        }

        public void ampliar()
        {
            throw new NotImplementedException();
        }

        public void trasladar()
        {
            throw new NotImplementedException();
        }
    }
}

