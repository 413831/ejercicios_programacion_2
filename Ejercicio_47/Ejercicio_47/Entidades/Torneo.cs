using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Torneo<T> where T : Equipo
    {
        private List<T> equipos;
        private string nombre;

        private Torneo()
        {
            this.equipos = new List<T>();
        }

        public Torneo(String nombre):this()
        {
            this.nombre = nombre;
        }
            

        public static bool operator ==(Torneo<T> torneo, T equipo)
        {
            foreach(Equipo auxEquipo in torneo.equipos)
            {
                if(auxEquipo == equipo)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Torneo<T> torneo, T equipo)
        {
            return !(torneo == equipo);
        }

        public static Torneo<T> operator +(Torneo<T> torneo, T equipo)
        {
            if(torneo != equipo)
            {
                torneo.equipos.Add(equipo);
            }
            return torneo;
        }

        public string Mostrar()
        {
            StringBuilder datos = new StringBuilder("");

            datos.AppendFormat("\n\nNombre del torneo: {0}\n", this.nombre);

            foreach(Equipo equipo in this.equipos)
            {
                datos.AppendFormat("\nNombre del equipo: {0}", equipo.Ficha());
            }
            return datos.ToString();
        }
        private string CalcularPartido(T equipoUno, T equipoDos)
        {
            StringBuilder datos = new StringBuilder("");
            Random resultado = new Random();
            // “[EQUIPO1] [RESULTADO1] – [RESULTADO2] [EQUIPO2]”
            datos.AppendFormat("\n\n{0} {1} - {2} {3}", equipoUno.Nombre, resultado.Next(0, 10),
                                                    equipoDos.Nombre, resultado.Next(0, 10));
            return datos.ToString();
        }

        public string JugarPartido()
        {
            Random seleccion = new Random();
            T equipoUno;
            T equipoDos;

            do
            {
                equipoUno = this.equipos.ElementAt(seleccion.Next(0, this.equipos.Count));
                Thread.Sleep(2000);
                equipoDos = this.equipos.ElementAt(seleccion.Next(0, this.equipos.Count));
            } while (equipoUno == equipoDos);

            return this.CalcularPartido(equipoUno,equipoDos);
        }


    }
}
