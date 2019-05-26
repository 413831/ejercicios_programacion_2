using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Lapiz : IAcciones
    {
        public float tamanioMina;

        #region Propiedades

        public ConsoleColor Color
        {
            get
            {
                return ConsoleColor.Gray;
            }
            set
            {
                throw new NotImplementedException();
            }
        }
        //PREGUNTAR SOBRE PROPIEDADES DE INTERFACES E IMPLEMENTACION EXPLICITAS

        public float UnidadesDeEscritura
        {
            get
            {
                return this.tamanioMina;
            }
            set
            {
                this.tamanioMina = value;
            }
        }

        #endregion

        #region Métodos

        public Lapiz(int unidades)
        {
            this.tamanioMina = unidades;
        }

        public override string ToString()
        {
            StringBuilder atributos = new StringBuilder("");

            atributos.AppendFormat("Clase: {0}", typeof(Lapiz).ToString());
            atributos.AppendFormat("Color: {0}", this.Color);
            atributos.AppendFormat("Tinta: {0}", this.tamanioMina);

            return base.ToString();
        }

        EscrituraWrapper IAcciones.Escribir(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                this.tamanioMina -= 0.1f;
            }
            return new EscrituraWrapper(texto,this.Color);
        }

        bool IAcciones.Recargar(int unidades)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
C