using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaConsola
{
    class UnaException : Exception
    {
        public UnaException(string mensaje):base(mensaje)
        {

        }

        public UnaException(string mensaje,Exception innerException) : base(mensaje,innerException)
        {
        }
    }
}
