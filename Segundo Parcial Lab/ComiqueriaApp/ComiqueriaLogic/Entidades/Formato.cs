using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic.Entidades
{
    public static class Formato
    {
        public static string FormatearPrecio(this double numero)
        {
            return String.Format("${0:0.00}", numero);
        }
    }
}
