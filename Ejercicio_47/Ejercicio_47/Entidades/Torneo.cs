using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Torneo<T> where T : Equipo
    {
        private List<T> equipos;
        private string nombre;

        private Torneo()
        {
            this.equipos = new List<T>;
        }

        public Torneo(String nombre):this()
        {
            this.nombre = nombre;
        }
            

        public static bool operator ==(Torneo<T> torneo, T equipo)
        {
            foreach(Equipo auxEquipo in torneo.equipos)
            {

            }
            return true;
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

            datos.AppendFormat("Nombre del torneo: {0}", this.nombre);

            foreach(Equipo equipo in this.equipos)
            {
                datos.AppendFormat("Nombre del torneo: {0}", this.nombre);

            }
            return datos.ToString();
        }
        public string CalcularPartido(T equipoUno, T equipoDos)
        {
            StringBuilder datos = new StringBuilder("");
            Random resultado = new Random();
            // “[EQUIPO1] [RESULTADO1] – [RESULTADO2] [EQUIPO2]”
            datos.AppendFormat("{0} {1} - {2} {3}", equipoUno.Nombre, resultado.Next(0, 10),
                                                    equipoDos.Nombre, resultado.Next(0, 10));
            return datos.ToString();
        }

        public void JugarPartido()
        {
            Random seleccion = new Random();

            this.CalcularPartido(this.equipos.ElementAt(seleccion.Next(0, this.equipos.Count)),
                                this.equipos.ElementAt(seleccion.Next(0, this.equipos.Count)));

        }


    }
}
