using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casa5.ctr
{
    class Escenario
    {
        public Dictionary<string, Objeto> d;
        public Punto cg { get; set; }

        public Escenario()
        {
            d = new Dictionary<string, Objeto>();
            init();
        }

        private void init()
        {
           
        }

        public void addObjeto(string key, Objeto value)
        {
            d.Add(key, value);
        }

        public void dibujar()
        {
            foreach (KeyValuePair<string, Objeto> value in d)
            {
                value.Value.dibujar();
            }
        }
    }
}
