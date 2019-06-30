using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Entidades
{
    public class XmlSerializar<T> : IArchivo<T>
    {
        XmlTextWriter escritor;
        XmlTextReader lector;
        XmlSerializer serializador;
        
        public XmlSerializar()
        { }
       
        public bool Guardar(string rutaArchivo, T objeto)
        {
            try
            {
                this.escritor = new XmlTextWriter(rutaArchivo, Encoding.UTF8);
                this.serializador = new XmlSerializer(typeof(T));
                serializador.Serialize(escritor, objeto);
                return true;
            }
            catch (Exception exception)
            {
                return false;
                throw new ErrorArchivoException("Error. No se pudo guardar el archivo", exception);
            }
            finally
            {
                if(escritor != null)
                {
                    escritor.Close();
                }
            }
        }

        public T Leer(string rutaArchivo)
        {
            try
            {
                this.lector = new XmlTextReader(rutaArchivo);
                this.serializador = new XmlSerializer(typeof(T));

                return (T)serializador.Deserialize(lector);
            }
            catch (Exception exception)
            {
                throw new ErrorArchivoException("Error. No se encuentra el archivo.", exception);
            }
            finally
            {
                lector.Close();
            }
        }
    }
}
