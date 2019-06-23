using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    /// <summary>
    /// Clase para guardar y leer archivos de formato TXT
    /// </summary>
    public class Texto
    {
        StreamWriter txtWriter;
        StreamReader txtReader;
        /// <summary>
        /// Implementación de método para guardar en archivos de tipo texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo donde se guardará</param>
        /// <param name="datos">Datos para guardar en archivo</param>
        /// <returns>Retorna true si logra guardar sino retorna false</returns>
        public bool Guardar(string archivo, string datos)
        {
            try
            {
                txtWriter = new StreamWriter(archivo,false); //Creo variable para escribir en un archivo
                txtWriter.WriteLine(datos); // Escribo cada dato en una linea diferente
                return true;

            }
            catch(NotSupportedException exception)
            {
                return false;
                throw new ArchivosException(exception);
            }
            catch (IOException exception)
            {
                return false;
                throw new ArchivosException(exception);
            }
            finally
            {
                txtWriter.Close(); // Cierro el archivo
            }
        }

        /// <summary>
        /// Implementación de método para leer de un archivo de texto
        /// </summary>
        /// <param name="archivo">Nombre del archivo para leer</param>
        /// <param name="datos">Variable para guardar los datos leídos</param>
        /// <returns>Retorna true si logra leer los datos sino retorna false</returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                txtReader = new StreamReader(archivo, Encoding.UTF8); // Creo variable para leer archivo
                datos = txtReader.ReadToEnd(); // Leo hasta el final del archivo y guardo la información en un string
                return true;
            }
            catch(OutOfMemoryException exception)
            {
                datos = "";
                return false;
                throw new ArchivosException(exception);
            }
            catch (IOException exception)
            {
                datos = "";
                return false;
                throw new ArchivosException(exception);
            }
            finally
            {
                txtReader.Close(); // Cierro el archivo
            }
        }
    }
}
