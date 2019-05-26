using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IO
{
    public static class ArchivoTexto
    {
        public static void Guardar(string ruta, string texto)
        {
            StreamWriter archivo = new StreamWriter(ruta, true);
            archivo.WriteLine(texto);
            archivo.Close();
        }

        public static string Leer(string ruta)
        {
            StreamReader archivo;
            string texto;
         
            if(File.Exists(ruta))
            {
                archivo = new StreamReader(ruta);
                texto = archivo.ReadToEnd();
                archivo.Close();
            }
            else
            {
                throw new FileNotFoundException();
            }
            return texto;
        }
    }
}
