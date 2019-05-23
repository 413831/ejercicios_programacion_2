using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Contabilidad<T, U> where T : Documento
                                    where U : Documento, new()
    {
        private List<T> egresos;
        private List<U> ingresos;

        public Contabilidad()
        {
            this.egresos = new List<T>();
            this.ingresos = new List<U>();
        }

        public static Contabilidad<T,U> operator +(Contabilidad<T,U> contabilidad, T egreso)
        {
            contabilidad.egresos.Add(egreso);

            return contabilidad;
        }

        public static Contabilidad<T, U> operator +(Contabilidad<T, U> contabilidad, U ingreso)
        {
            contabilidad.ingresos.Add(ingreso);

            return contabilidad;
        }

        public string Mostrar()
        {
            StringBuilder datos = new StringBuilder();
            int contador = 0;

            datos.AppendLine("FACTURAS");
            foreach(T factura in this.egresos)
            {
                datos.AppendFormat("\nFactura {0} : {1}", ++contador, factura.Numero);
            }

            datos.AppendLine("\nRECIBOS");
            foreach (U recibo in this.ingresos)
            {
                datos.AppendFormat("\nRecibo {0} : {1}", ++contador, recibo.Numero);
            }
            return datos.ToString();
        }
            
    }
}
