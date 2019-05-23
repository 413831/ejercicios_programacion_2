using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Equipo
    {
        string nombre;
        DateTime fechaCreacion;

        public Equipo(String nombre, DateTime fecha)
        {
            this.Nombre = nombre;
            this.FechaCreacion = fecha;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public DateTime FechaCreacion
        {
            get
            {
                return this.fechaCreacion;
            }
            set
            {
                this.fechaCreacion = value;
            }
        }


        public static bool operator ==(Equipo equipoUno, Equipo equipoDos)
        {
            if(equipoUno.nombre == equipoDos.nombre && equipoUno.fechaCreacion == equipoDos.fechaCreacion)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Equipo equipoUno, Equipo equipoDos)
        {
            
            return !(equipoUno == equipoDos);
        }

        // “[EQUIPO] fundado el [FECHA]”
        public string Ficha()
        {
            StringBuilder ficha = new StringBuilder("");

            ficha.AppendFormat("{0} fundado el {1}", this.Nombre, this.FechaCreacion.Date.ToString());

            return ficha.ToString();
        }

    }
}
