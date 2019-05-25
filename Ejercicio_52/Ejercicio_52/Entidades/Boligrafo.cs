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


            }
            set
            {

            }
        }

        #endregion

        #region Métodos

        public Boligrafo(int unidades, ConsoleColor color)
        {

        }

        public EscrituraWrapper Escribir(string texto)
        {
        }

        public bool Recargar()
        {
            return true;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        #endregion

    }
}
