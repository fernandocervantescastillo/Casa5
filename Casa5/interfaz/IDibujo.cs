using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casa5.interfaz
{
    public interface IDibujo
    {
        void dibujar();
        void rotar();
        void ampliar();
        void trasladar();
        void dispose();
    }
}
