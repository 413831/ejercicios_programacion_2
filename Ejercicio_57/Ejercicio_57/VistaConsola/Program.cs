using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona("Pepe", "Juarez");
            String nombreArchivo = "personita.txt";

            Persona.Guardar(nombreArchivo, persona);
            Console.Write(Persona.Leer(nombreArchivo).ToString()); //Se deserializa el archivo y se muestran los datos
            Console.ReadKey();
        }
    }
}
