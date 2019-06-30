using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ComiqueriaLogic.Entidades
{
    public static class Serializador<T> where T : new()
    {
        static FileStream escritor;
        static BinaryFormatter serializador;
        static Serializador()
        { }

        public static bool GuardarXmlBinario(string archivo, T datos)
        {
            try
            {
                escritor = new FileStream(archivo, FileMode.Create); // Creo objeto para escribir el archivo
                serializador = new BinaryFormatter(); // Creo objeto para serializar el objeto para escribir

                serializador.Serialize(escritor, datos); // Serializo el objeto para escribir en el archivo
                return true;
            }
            catch (NullReferenceException exception)
            {
                throw new ComiqueriaException("Ocurrió un error, llame al administrador.", exception);
            }
            catch (ArgumentException exception)
            {
                throw new ComiqueriaException("Ocurrió un error, llame al administrador.", exception);
            }
            catch (DirectoryNotFoundException exception)
            {
                throw new ComiqueriaException("Error: Directorio no encontrado",exception);
            }
            finally
            {
                escritor.Close();
            }
        }

        /// <summary>
        /// Implementación del método para leer de un archivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo para leer los datos</param>
        /// <param name="datos">Variable para retornar los datos leídos</param>
        /// <returns>Retorna true si logró leer sino lanza una excepción del tipo ArchivoException</returns>
        public static bool LeerXmlBinario(string archivo, out T datos)
        {
            FileStream lector = new FileStream(archivo, FileMode.Open); // Creo objeto para escribir el archivo
            BinaryFormatter serializador = new BinaryFormatter(); // Creo objeto para serializar el objeto para escribir

            try
            {
                datos = (T)serializador.Deserialize(lector);
                return true;
            }
            catch (ArgumentException exception)
            {
                throw new ComiqueriaException("Ocurrió un error, llame al administrador.", exception);
            }
            catch (DirectoryNotFoundException exception)
            {
                throw new ComiqueriaException("Error: Directorio no encontrado", exception);
            }
            finally
            {
                lector.Close();
            }
        }

        /// <summary>
        /// Implementación de método para guardar en un archivo XML
        /// </summary>
        /// <param name="archivo">Nombre del archivo para guardar los datos</param>
        /// <param name="datos">Datos para guardar en el archivo</param>
        /// <returns>Retorna true si logra guardar sino retorna false</returns>
        public static bool GuardarXml(string archivo, T datos)
        {
            XmlTextWriter textWriter = new XmlTextWriter(archivo, Encoding.UTF8); // Creo objeto para escribir el archivo
            XmlSerializer serializador = new XmlSerializer(typeof(T)); // Creo objeto para serializar el objeto para escribir

            try
            {
                serializador.Serialize(textWriter, datos); // Serializo el objeto para escribir en el archivo
                return true;
            }
            catch (ArgumentException exception)
            {
                return false;
                throw new ComiqueriaException("Ocurrió un error, llame al administrador.", exception);
            }
            catch (DirectoryNotFoundException exception)
            {
                return false;
                throw new ComiqueriaException("Error: Directorio no encontrado", exception);
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
        public static bool LeerXml(string archivo, out T datos)
        {
            XmlTextReader textReader = new XmlTextReader(archivo); // Creo objeto para leer el archivo
            XmlSerializer serializador = new XmlSerializer(typeof(T)); // Creo objeto para deserializar el objeto para escribir

            try
            {
                datos = (T)serializador.Deserialize(textReader);
                return true;
            }
            catch (ArgumentException exception)
            {
                throw new ComiqueriaException("Ocurrió un error, llame al administrador.", exception);
            }
            catch (DirectoryNotFoundException exception)
            {
                throw new ComiqueriaException("Error: Directorio no encontrado", exception);
            }
            finally
            {
                textReader.Close();
            }
        }

    }
}
