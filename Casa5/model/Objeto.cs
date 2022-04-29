using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Casa5.ctr
{
    class Objeto
    {
        public Dictionary<string, Parte> d;
        public Punto cg { get; set; }

  

        public Objeto()
        {
            d = new Dictionary<string, Parte>();
        }

        public void addParte(string key, Parte value)
        {
            d.Add(key, value);
        }

        public void dibujar()
        {
            foreach (KeyValuePair<string, Parte> value in d)
            {
                value.Value.dibujar();
            }
        }

    }
}
