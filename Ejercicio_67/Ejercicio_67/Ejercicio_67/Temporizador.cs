using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio_67
{
    public class Temporizador
    {
        private Thread hilo;
        private int intervalo;

        public bool Activo
        {
            get
            {

            }
            set
            {

            }
        }

        public int Invervalo
        {
            get
            {
                return this.intervalo;
            }
            set
            {
                this.intervalo = value;
            }
        }

        public void Corriendo()
        {

        }

        public delegate void encargadoTiempo

        public event EventoTiempo()
    }
}
