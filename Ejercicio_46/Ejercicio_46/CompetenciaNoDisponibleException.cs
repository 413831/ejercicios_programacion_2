using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_36
{
    public class CompetenciaNoDisponibleException : Exception
    {
        private string nombreClase;
        private string nombreMetodo;

        public string NombreClase
        {
            get
            {
                return this.nombreClase;
            }
        }

        public string NombreMetodo
        {
            get
            {
                return this.nombreMetodo;
            }
        }

        public CompetenciaNoDisponibleException(string mensaje,string clase, string metodo):base(mensaje)
        {
            this.nombreClase = clase;
            this.nombreMetodo = metodo;
        }

        public CompetenciaNoDisponibleException(string mensaje, string clase, string metodo, Exception innerException):base(mensaje,innerException)
        {
            this.nombreClase = clase;
            this.nombreMetodo = metodo;
        }


        public override string ToString()
        {
            StringBuilder detalleExcepcion = new StringBuilder();

            detalleExcepcion.AppendFormat("Excepción en el método {0} de la clase {1}:", this.NombreMetodo, this.NombreClase);
            detalleExcepcion.AppendFormat(this.Message);


            if (!object.ReferenceEquals(this.InnerException, null))
            {
                Exception auxiliar = this.InnerException;

                do
                {
                    detalleExcepcion.AppendFormat(auxiliar.Message);
                    auxiliar = auxiliar.InnerException;

                } while (!object.ReferenceEquals(auxiliar, null));
            }

            return detalleExcepcion.ToString();
        }

    }
}
