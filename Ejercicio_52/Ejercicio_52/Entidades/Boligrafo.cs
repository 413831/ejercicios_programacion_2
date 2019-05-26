using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Boligrafo : IAcciones
    {
        private ConsoleColor colorTinta;
        private float tinta;

        #region Propiedades

        public ConsoleColor Color
        {
            get
            {
                return this.colorTinta;
            }
            set
            {
                this.colorTinta = value;
            }
        }

        public float UnidadesDeEscritura
        {
            get
            {
                return this.tinta;
            }
            set
            {
                this.tinta = value;
            }
        }

        #endregion

        #region Métodos

        public Boligrafo(int unidades, ConsoleColor color)
        {

        }

        public EscrituraWrapper Escribir(string texto)
        {
            for(int i = 0;i < texto.Length;i++)
            {
                this.tinta -= 0.3f;
            }
            return new EscrituraWrapper(texto, this.Color);
        }

        public bool Recargar(int unidades)
        {
            this.tinta += unidades;
            return true;
        }


        public override string ToString()
        {
            StringBuilder atributos = new StringBuilder("");

            atributos.AppendFormat("Clase: {0}", typeof(Boligrafo).ToString());
            atributos.AppendFormat("Color: {0}", this.Color);
            atributos.AppendFormat("Tinta: {0}", this.UnidadesDeEscritura);

            return base.ToString();
        }

        #endregion

    }
}
