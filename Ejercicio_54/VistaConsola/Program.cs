using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;

namespace VistaConsola
{
    /*   a.Lanzar una excepción DivideByZeroException en un método estático
       b.Capturar la excepción del punto a en un constructor de instancia y relanzarla hacia otro
       constructor de instancia.
       c.En este segundo constructor, crear una excepción propia llamada UnaException (utilizar
       innerException para almacenar la excepción original) y volver a lanzarla.
       d.Luego crear un método de instancia que capture la excepción anterior. Este método
       generará una excepción propia llamada MiException y la lanzará.
       e.MiException será capturada en el Main, mostrando el mensaje de error que esta almacena
       por pantalla y los mensajes de todas las excepciones almacenadas en sus innerException.*/
    // '20171012-1316.txt'
    class Program
    {
        static void Main(string[] args)
        {
            ClaseMetodo test;
            
            string nombreArchivo = DateTime.Now.ToString("yyyyMMdd-Hmm") + ".txt";

            try
            {
                test = new ClaseMetodo();
                test.MetodoInstancia(1);
            }
            catch(MiExcepcion excepcion)
            {
                ArchivoTexto.Guardar(nombreArchivo, excepcion.Message);

                if (!object.ReferenceEquals(excepcion.InnerException, null))
                {
                    Exception auxiliar = excepcion.InnerException;

                    do
                    {
                        ArchivoTexto.Guardar(nombreArchivo, auxiliar.Message);
                        auxiliar = auxiliar.InnerException;

                    } while (!object.ReferenceEquals(auxiliar, null));
                }
            }

            try
            {
                Console.Write(ArchivoTexto.Leer(nombreArchivo));
            }
            catch(FileNotFoundException exception)
            {
                Console.Write(exception.Message);
            }
            Console.ReadKey();
        }
    }
}
