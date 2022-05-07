using Casa5.interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casa5.ctr
{
    class Escenario:IDibujo
    {
        public string name { get; set; }
        public Punto cm { get; set; }
        public Dictionary<string, Objeto> d;
        
        public Escenario()
        {
            d = new Dictionary<string, Objeto>();
        }

        public Escenario(string name)
        {
            this.name = name;
        }

        public Escenario(string name, Dictionary<string, Objeto> d)
        {
            this.d = new Dictionary<string, Objeto>();
            foreach (KeyValuePair<string, Objeto> value in d)
            {
                addObjeto(value.Key, value.Value);
            }
        }

        public Escenario(Escenario e)
        {
            this.name = e.name;
            this.cm = e.cm.copiar();
            this.d = new Dictionary<string, Objeto>();

            foreach (KeyValuePair<string, Objeto> value in e.d)
            {
                addObjeto(value.Key, value.Value);
            }
        }

        public void addObjeto(string key, Objeto value)
        {
            d.Add(key, value);
        }

        public Objeto getObjeto(string key)
        {
            return d[key];
        }

        public void deleteObjeto(string key)
        {
            d.Remove(key);
        }

        public void vaciarEscenario()
        {
            d.Clear();
        }

        public void dibujar()
        {
            foreach (KeyValuePair<string, Objeto> value in d)
            {
                value.Value.dibujar();
            }
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

        public void dispose()
        {
            foreach (KeyValuePair<string, Objeto> value in d)
            {
                value.Value.dispose();
            }
        }
    }
}
