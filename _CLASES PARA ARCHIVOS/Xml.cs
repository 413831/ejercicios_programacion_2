using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    /// <summary>
    /// Clase para guardar y leer archivos XML
    /// </summary>
    public class Xml
    {
        /// <summary>
        /// Implementación de método para guardar en un archivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo para guardar los datos</param>
        /// <param name="datos">Datos para guardar en el archivo</param>
        /// <returns>Retorna true si logra guardar sino retorna false</returns>
        public bool Guardar(string archivo, Object datos)
        {
            XmlTextWriter textWriter = new XmlTextWriter(archivo, Encoding.UTF8); // Creo objeto para escribir el archivo
            XmlSerializer serializador = new XmlSerializer(typeof(T)); // Creo objeto para serializar el objeto para escribir

            try
            {
                serializador.Serialize(textWriter, datos); // Serializo el objeto para escribir en el archivo
                return true;
            }
            catch(InvalidOperationException exception)
            {
                return false;
                throw exception;
            }
            finally
            {
                textWriter.Close();
            }
        }

        /// <summary>
        /// Implementación del método para leer de un archivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo para leer los datos</param>
        /// <param name="datos">Variable para retornar los datos leídos</param>
        /// <returns>Retorna true si logró leer sino lanza una excepción del tipo ArchivoException</returns>
        public bool Leer(string archivo, out Object datos)
        {
            XmlTextReader textReader = new XmlTextReader(archivo); // Creo objeto para leer el archivo
            XmlSerializer serializador = new XmlSerializer(typeof(T)); // Creo objeto para deserializar el objeto para escribir

            try
            {
                datos = (Object)serializador.Deserialize(textReader);
                return true;
            }
            catch(InvalidOperationException exception)
            {
                throw exception;
            }
            finally
            {
                textReader.Close();
            }
        }
    }
}
