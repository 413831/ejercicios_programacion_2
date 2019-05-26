using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaConsola
{
    public class ClaseMetodo
    {
        public void MetodoInstancia(int numero)
        {
            try
            {
                new ClaseTest(numero);
            }
            catch (UnaException exception)
            {
                throw new MiExcepcion("Mensaje de error", exception);
            }

        }
    }
}
