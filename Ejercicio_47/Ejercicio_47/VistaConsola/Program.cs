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
            EquipoFutbol equipoFutbolUno = new EquipoFutbol("Sporting Pepito", DateTime.Parse("06 / 04 / 1945"));
            EquipoFutbol equipoFutbolDos = new EquipoFutbol("Pajaros Dorados", DateTime.Parse("24 / 11 / 1968"));
            EquipoFutbol equipoFutbolTres = new EquipoFutbol("Massachussets Plate", DateTime.Parse("07 / 07 / 1953"));
            EquipoBasquet equipoBasketUno = new EquipoBasquet("LAMAS", DateTime.Parse("06 / 04 / 1945"));
            EquipoBasquet equipoBasketDos = new EquipoBasquet("Deportivo Cristal", DateTime.Parse("24 / 11 / 1968"));
            EquipoBasquet equipoBasketTres = new EquipoBasquet("Tropisports", DateTime.Parse("07 / 07 / 1953"));

            torneoFutbol += equipoFutbolUno;
            torneoFutbol += equipoFutbolDos;
            torneoFutbol += equipoFutbolTres;

            torneoBasquet += equipoBasketUno;
            torneoBasquet += equipoBasketDos;
            torneoBasquet += equipoBasketTres;

            /////Mostrar

            Console.Write(torneoFutbol.Mostrar());
            Console.Write(torneoBasquet.Mostrar());
            
            /////Jugar

            Console.Write(torneoFutbol.JugarPartido());
            Console.Write(torneoFutbol.JugarPartido());
            Console.Write(torneoFutbol.JugarPartido());
            Console.ReadKey();
            Console.Write(torneoBasquet.JugarPartido());
            Console.Write(torneoBasquet.JugarPartido());
            Console.Write(torneoBasquet.JugarPartido());
            Console.ReadKey();

        }
    }
}
