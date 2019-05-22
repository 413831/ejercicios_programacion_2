using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace VistaConsola
{
    public class Program
    {
        /*  i. Crear un programa que genere 2 torneos, uno de Futbol y otro de Basquet.
            ii. Crear 3 equipos de cada tipo.
            iii. Agregar los equipos en tantos torneos como se pueda.
            iv. Llamar al método Mostrar de Torneo e imprimir su retorno por pantalla.
            v. Llamar al menos 3 veces a la propiedad JugarPartido de cada torneo e imprimir su
            respuesta por pantalla
         */
        static void Main(string[] args)
        {
            Torneo<EquipoFutbol> torneoFutbol = new Torneo<EquipoFutbol>("Torneo Nertor Kirssner");
            Torneo<EquipoBasquet> torneoBasquet = new Torneo<EquipoBasquet>("Copa Martita Fort");
            Equipo equipoFutbolUno = new EquipoFutbol("Sporting Pepito", DateTime.Parse("06 / 04 / 1945"));
            Equipo equipoFutbolDos = new EquipoFutbol("Pajaros Dorados", DateTime.Parse("24 / 11 / 1968"));
            Equipo equipoFutbolTres = new EquipoFutbol("Massachussets Plate", DateTime.Parse("07 / 07 / 1953"));
            Equipo equipoBasketUno = new EquipoBasquet("LAMAS", DateTime.Parse("06 / 04 / 1945"));
            Equipo equipoBasketDos = new EquipoBasquet("Deportivo Cristal", DateTime.Parse("24 / 11 / 1968"));
            Equipo equipoBasketTres = new EquipoBasquet("Tropisports", DateTime.Parse("07 / 07 / 1953"));

            torneoFutbol + 

        }
    }
}
