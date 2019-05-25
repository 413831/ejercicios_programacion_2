using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public class GuardarTexto<T,V> : IGuardar<T, V>
    {
        public bool Guardar(T objeto)
        {
            return true;
        }

        public V Leer()
        {
            return (V)Convert.ChangeType("Texto Leído",typeof(V));
        }
    }
}
