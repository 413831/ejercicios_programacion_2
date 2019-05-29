using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace VistaConsola
{
    [Serializable]
    public class Persona
    {
        private string nombre;
        private string apellido;

        public Persona(string nombre,string apellido)
        {
            this.nombre = nombre;
            this.apellido = apellido;
        }

        public static void Guardar(string nombreArchivo, Persona persona)
        {
            FileStream archivo;
            BinaryFormatter serializador;

            try
            {
                archivo = new FileStream(nombreArchivo, FileMode.Create); //Se crea un archivo
                serializador = new BinaryFormatter(); //Se crea el serializador
                serializador.Serialize(archivo, persona); //Se serializa el objeto en el archivo
                archivo.Close();
            }
            catch (FileNotFoundException exception)
            {
                throw new FileNotFoundException("No se pudo guardar el archivo", exception);
            }            
        }

        public static Persona Leer(string nombreArchivo)
        {
            FileStream archivo;
            BinaryFormatter serializador;
            Persona persona;

            try
            {
                archivo = new FileStream(nombreArchivo, FileMode.Open); //Se crea un archivo
                serializador = new BinaryFormatter(); //Se crea el serializador
                persona = (Persona)serializador.Deserialize(archivo); //Se deserializa y retorna un object
                archivo.Close();
            }
            catch(FileNotFoundException exception) // REVISAR
            {
                persona = new Persona("Nombre no cargado", "Apellido no cargado");
                throw new FileNotFoundException("No se pudo leer el archivo", exception);
            }
            return persona;

        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendLine(this.nombre);
            datos.AppendLine(this.apellido);

            return datos.ToString();
        }
    }
}
