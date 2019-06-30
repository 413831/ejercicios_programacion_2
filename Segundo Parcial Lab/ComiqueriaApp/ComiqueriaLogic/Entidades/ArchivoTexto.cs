using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using ComiqueriaLogic.Comun;

namespace ComiqueriaLogic.Entidades
{
    public static class ArchivoTexto
    {
        static StreamWriter txtWriter;
        static StreamReader txtReader;

        /// <summary>
        /// Método para guardar los datos de un objeto del tipo de interfaz IArchivoTexto
        /// </summary>
        /// <param name="objeto">Objeto para guardar los datos</param>
        /// <param name="append">Valor para indicar si sobreescribo o agrego al archivo</param>
        /// <returns>Retorna true si logro guardar sino retorna false</returns>
        public static bool Escribir(IArchivoTexto objeto, bool append)
        {
            try
            {
                txtWriter = new StreamWriter(objeto.Ruta, append,Encoding.UTF8); //Creo variable para escribir en un archivo
                txtWriter.WriteLine(objeto.Texto); // Escribo cada dato en una linea diferente
                return true;

            }
            catch (NotSupportedException exception)
            {
                return false;
                throw new ComiqueriaException("Error al guardar.",exception);
            }
            catch (IOException exception)
            {
                return false;
                throw new ComiqueriaException("Error al guardar", exception);
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
        public static string Leer(string archivo)
        {
            try
            {
                txtReader = new StreamReader(archivo, Encoding.UTF8); // Creo variable para leer archivo
                return  txtReader.ReadToEnd(); // Leo hasta el final del archivo y guardo la información en un string
            }
            catch (OutOfMemoryException exception)
            {
                throw new ComiqueriaException("Error al leer.", exception);
            }
            catch (IOException exception)
            {
                throw new ComiqueriaException("Error al leer.", exception);
            }
            finally
            {
                txtReader.Close(); // Cierro el archivo
            }
        }
    }
}
