using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public void Guardar(string archivo, T datos)
        {
            XmlTextWriter escritor = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            serializador.Serialize(escritor, datos);

            escritor.Close();
        }

        public void Leer(string archivo, out T datos)
        {
            XmlTextReader lector = new XmlTextReader(archivo);
            XmlSerializer serializador = new XmlSerializer(typeof(T));

            datos = (T)serializador.Deserialize(lector);

            lector.Close();
        }

    }
}
