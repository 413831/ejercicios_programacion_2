using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ejercicio_64
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Los threads (hilos) son métodos que reciben punteros a funciones para establecer su prioridad dentro del hilo principal
            * 
            *
             */
            Caja cajaUno = new Caja();
            Caja cajaDos = new Caja();
            Negocio negocio = new Negocio(cajaUno, cajaDos);
            Thread asignacionCajas = new Thread(negocio.AsignarCaja);
            Thread atenderCajaUno = new Thread(cajaUno.AtenderClientes);
            Thread atenderCajaDos = new Thread(cajaDos.AtenderClientes);

            negocio.Clientes.Add("Juancito");
            negocio.Clientes.Add("Pepito");
            negocio.Clientes.Add("Pedrito");
            negocio.Clientes.Add("Manuelita");
            negocio.Clientes.Add("Francisquito");

            atenderCajaUno.Name = "Caja N°1";
            atenderCajaDos.Name = "Caja N°2";

            asignacionCajas.Start();
            asignacionCajas.Join();
            atenderCajaUno.Start();
            atenderCajaDos.Start();

            Console.ReadKey();
        }
    }
}
