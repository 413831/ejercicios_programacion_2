using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Archivos
{
    /// <summary>
    /// Clase para guardar y leer archivos XML en binario
    /// </summary>
    public class XmlBinario
    {
        /// <summary>
        /// Implementación de método para guardar en un archivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo para guardar los datos</param>
        /// <param name="datos">Datos para guardar en el archivo</param>
        /// <returns>Retorna true si logra guardar sino retorna false</returns>
        public bool Guardar(string archivo, Object datos)
        {
            FileStream archivo = new FileStream(archivo, FileMode.Create); // Creo objeto para escribir el archivo
            BinaryFormatter serializador = new BinaryFormatter(); // Creo objeto para serializar el objeto para escribir

            try
            {
                serializador.Serialize(archivo, datos); // Serializo el objeto para escribir en el archivo
                return true;
            }
            catch (System.Runtime.Serialization.SerializationException exception)
            {
                return false;
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                return false;
                throw exception;
            }
            finally
            {
                archivo.Close();
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
            FileStream archivo = new FileStream(archivo, FileMode.Open); // Creo objeto para escribir el archivo
            BinaryFormatter serializador = new BinaryFormatter(); // Creo objeto para serializar el objeto para escribir

            try
            {
                datos = (Object)serializador.Deserialize(archivo);
                return true;
            }
            catch (System.Runtime.Serialization.SerializationException exception)
            {
                return false;
                throw exception;
            }
            catch (ArgumentNullException exception)
            {
                return false;
                throw exception;
            }
            finally
            {
                archivo.Close();
            }
        }
    }
}