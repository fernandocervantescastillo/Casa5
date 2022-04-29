using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casa5.extras
{
    class Archivos
    {
        static string path = "..//..//..//file//";
        static string name = "MyTest.txt";

        public static void agregarArhivo(string name, string json)
        {

            if (!File.Exists(path + name))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path + name))
                {
                    sw.WriteLine(json);
                }
            }

        }


        public static string leerArchivo(string name)
        {
            string t = "";
            
            using (StreamReader sr = File.OpenText(path + name))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    t = t + s;
                }
            }

            return t;

        }

    }
}
