using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Recibo : Documento
    {
        public Recibo()
        {
            this.Numero = 0;
        }

        public Recibo(int numero)
        {
            this.Numero = numero;
        }

    }
}
