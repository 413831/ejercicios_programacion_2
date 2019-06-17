using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio_64
{
    public class Negocio
    {
        private Caja cajaUno;
        private Caja cajaDos;
        private List<string> clientes;

        public Caja CajaUno
        {
            get
            {
                return this.cajaUno;
            }
        }

        public Caja CajaDos
        {
            get
            {
                return this.cajaDos;
            }
        }

        public List<string> Clientes
        {
            get
            {
                return this.clientes;
            }
        }

        public void AsignarCaja()
        {
            Console.Write("Asignando cajas...");

            foreach(string cliente in this.clientes)
            {
                if(this.cajaUno.FilaClientes.Count < this.cajaDos.FilaClientes.Count)
                {
                    this.cajaUno.FilaClientes.Add(cliente);
                }
                else
                {
                    this.cajaDos.FilaClientes.Add(cliente);
                }
                Thread.Sleep(1000);
            }
        }

        public Negocio(Caja cajaUno, Caja cajaDos)
        {
            this.cajaUno = cajaUno;
            this.cajaDos = cajaDos;
            this.clientes = new List<string>();
        }
    }
}
