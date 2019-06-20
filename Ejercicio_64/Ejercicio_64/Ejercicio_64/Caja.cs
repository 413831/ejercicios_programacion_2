using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio_64
{
    public class Caja
    {
        private List<string> filaClientes;

        public List<string> FilaClientes
        {
            get
            {
                return this.filaClientes;
            }
        }

        public void AtenderClientes()
        {
            foreach(string cliente in this.FilaClientes)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
                Console.WriteLine(cliente);
                Thread.Sleep(2000);
            }
        }

        public Caja()
        {
            this.filaClientes = new List<string>();
        }
    }
}
