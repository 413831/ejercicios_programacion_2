using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComiqueriaLogic.Comun;

namespace ComiqueriaLogic.Entidades
{
    public class ComiqueriaException : Exception, IArchivoTexto
    {
        public ComiqueriaException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
            ArchivoTexto.Escribir(this,true);
        }

        public string Ruta
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\log.txt";
            }

        }
        public string Texto
        {
            get
            {
                StringBuilder datosExcepciones = new StringBuilder((DateTime.Now).ToString());

                datosExcepciones.AppendLine(base.Message);
                
                while(base.InnerException != null)
                {
                    datosExcepciones.AppendLine(base.InnerException.Message);
                }
                return datosExcepciones.ToString();
            }

        }
    }
}
