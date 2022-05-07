using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Casa5.extras;
using Casa5.interfaz;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa5.ctr
{
    class Objeto:IDibujo
    {
        public Punto cm { get; set; }
        public string name { get; set; }
        public Dictionary<string, Parte> d;
        
        public Objeto()
        {
            d = new Dictionary<string, Parte>();
        }

        public Objeto(Punto cm)
        {
            this.cm = cm;
        }

        public Objeto(Objeto o)
        {
            this.cm = o.cm.copiar();
            this.d = new Dictionary<string, Parte>();
            foreach (KeyValuePair<string, Parte> value in o.d)
            {
                addParte(value.Key, value.Value);
            }
        }

        public void addParte(string key, Parte value)
        {
            d.Add(key, value);
        }

        public Parte getParte(string key)
        {
            return d[key];
        }

        public string getParteKey(int index)
        {
            return d.ElementAt(index).Key;
        }

        public void vaciar()
        {
            d.Clear();
        }

        public Parte getParteValue(int index)
        {
            return d.ElementAt(index).Value;
        }

        public void dibujar()
        {
            foreach (KeyValuePair<string, Parte> value in d)
            {
                value.Value.dibujar();
            }
        }

        public string toJson()
        {
            return JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        public static Objeto toObjeto(string json)
        {
            return JsonConvert.DeserializeObject<Objeto>(json);
        }

        public void serializar(string name)
        {
            string t = toJson();
            Archivos.agregarArhivo(name, t);
        }

        public static T desserializar<T>(string name)
        {
            string t = Archivos.leerArchivo(name);
            return JsonConvert.DeserializeObject<T>(t);
        }

        public Objeto copy()
        {
            return new Objeto(this);
        }

        public void rotar(float x, float y, float z)
        {
            throw new NotImplementedException();
        }

        public void ampliar(float x, float y, float z)
        {
            throw new NotImplementedException();
        }

        public void trasladar(float x, float y, float z)
        {
            throw new NotImplementedException();
        }

        public void dispose()
        {
            foreach (KeyValuePair<string, Parte> value in d)
            {
                value.Value.dispose();
            }
        }
    }
}
