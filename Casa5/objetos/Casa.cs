using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa5.ctr;
using Casa5.extras;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa5.objetos
{
    class Casa : Objeto
    {

        public Casa()
        {

        }

        public Casa(float ancho, float alto, float largo, float x, float y, float z) : base()
        {

            cg = new Punto(x, y, z);

            Parte pared1 = new Parte();
            pared1.color = Color.Salmon;
            pared1.cg = new Punto(x, y, z);
            pared1.addPunto(new Punto(x, y, z));
            pared1.addPunto(new Punto(x + ancho, y, z));
            pared1.addPunto(new Punto(x + ancho, y + alto * 0.8f, z));
            pared1.addPunto(new Punto(x + ancho / 2.0f, y + alto, z));
            pared1.addPunto(new Punto(x, y + alto * 0.8f, z));

            Parte pared2 = new Parte();
            pared2.color = Color.AliceBlue;
            pared2.cg = new Punto(x + ancho, y, z);
            pared2.addPunto(new Punto(x + ancho, y, z));
            pared2.addPunto(new Punto(x + ancho, y, z + largo));
            pared2.addPunto(new Punto(x + ancho, y + alto * 0.8f, z + largo));
            pared2.addPunto(new Punto(x + ancho, y + alto * 0.8f, z));

            Parte pared3 = new Parte();
            pared3.color = Color.Pink;
            pared3.cg = new Punto(x, y, z + largo);
            pared3.addPunto(new Punto(x, y, z + largo));
            pared3.addPunto(new Punto(x + ancho, y, z + largo));
            pared3.addPunto(new Punto(x + ancho, y + alto * 0.8f, z + largo));
            pared3.addPunto(new Punto(x + ancho / 2.0f, y + alto, z + largo));
            pared3.addPunto(new Punto(x, y + alto * 0.8f, z + largo));

            Parte pared4 = new Parte();
            pared4.color = Color.LawnGreen;
            pared4.cg = new Punto(x, y, z);
            pared4.addPunto(new Punto(x, y, z));
            pared4.addPunto(new Punto(x, y, z + largo));
            pared4.addPunto(new Punto(x, y + alto * 0.8f, z + largo));
            pared4.addPunto(new Punto(x, y + alto * 0.8f, z));

            Parte techo1 = new Parte();
            techo1.color = Color.Gray;
            techo1.cg = new Punto(x, y + alto * 0.8f, z);
            techo1.addPunto(new Punto(x, y + alto * 0.8f, z));
            techo1.addPunto(new Punto(x + ancho / 2.0f, y + alto, z));
            techo1.addPunto(new Punto(x + ancho / 2.0f, y + alto, z + largo));
            techo1.addPunto(new Punto(x, y + alto * 0.8f, z + largo));

            Parte techo2 = new Parte();
            techo2.color = Color.Gray;
            techo2.cg = new Punto(x + ancho, y + alto * 0.8f, z);
            techo2.addPunto(new Punto(x + ancho, y + alto * 0.8f, z));
            techo2.addPunto(new Punto(x + ancho / 2.0f, y + alto, z));
            techo2.addPunto(new Punto(x + ancho / 2.0f, y + alto, z + largo));
            techo2.addPunto(new Punto(x + ancho, y + alto * 0.8f, z + largo));


            Parte puerta = new Parte();
            puerta.color = Color.Brown;
            puerta.cg = new Punto(x + ancho / 2.0f, y, z + largo);
            puerta.addPunto(new Punto(x + ancho / 2.0f, y, z + largo + 0.01f));
            puerta.addPunto(new Punto(x + ancho / 2.0f + ancho * 0.2f, y, z + largo + 0.01f));
            puerta.addPunto(new Punto(x + ancho / 2.0f + ancho * 0.2f, y + alto * 0.4f, z + largo + 0.01f));
            puerta.addPunto(new Punto(x + ancho / 2.0f, y + alto * 0.4f, z + largo + 0.01f));

            Parte ventana = new Parte();
            ventana.color = Color.Brown;
            ventana.cg = new Punto(x, y + alto * 0.2f, z + largo / 2.0f - largo * 0.1f);
            ventana.addPunto(new Punto(x - 0.01f, y + alto * 0.2f, z + largo / 2.0f - largo * 0.1f));
            ventana.addPunto(new Punto(x - 0.01f, y + alto * 0.2f, z + largo / 2.0f + largo * 0.1f));
            ventana.addPunto(new Punto(x - 0.01f, y + alto * 0.4f, z + largo / 2.0f + largo * 0.1f));
            ventana.addPunto(new Punto(x - 0.01f, y + alto * 0.4f, z + largo / 2.0f - largo * 0.1f));


            addParte("Pared1", pared1);
            addParte("Pared2", pared2);
            addParte("Pared3", pared3);
            addParte("Pared4", pared4);
            addParte("Techo1", techo1);
            addParte("Techo2", techo2);
            addParte("Puerta", puerta);
            addParte("Ventana", ventana);
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Casa toCasa(string json)
        {
            return JsonConvert.DeserializeObject<Casa>(json);
        }

        public void guardarCasa(string name)
        {
            string t = toJson();
            Archivos.agregarArhivo(name, t);
        }

        public static Casa getCasa(string name)
        {
            string t = Archivos.leerArchivo(name);
            return JsonConvert.DeserializeObject<Casa>(t);
        }

    }
}
