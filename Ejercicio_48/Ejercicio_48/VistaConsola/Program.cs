using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Entidades;

namespace VistaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Random numeroAleatorio = new Random();
            Contabilidad<Factura, Recibo> listaContable;
            Factura facturaUno;
            Factura facturaDos;
            Factura facturaTres;
            Recibo reciboUno;
            Recibo reciboDos;
            Recibo reciboTres;

            listaContable = new Contabilidad<Factura, Recibo>();

            facturaUno = new Factura(numeroAleatorio.Next(0,1000));
            Thread.Sleep(1000);
            facturaDos = new Factura(numeroAleatorio.Next(0, 1000));
            Thread.Sleep(1000);
            facturaTres = new Factura(numeroAleatorio.Next(0, 1000));

            reciboUno = new Recibo();
            Thread.Sleep(1000);
            reciboDos = new Recibo(numeroAleatorio.Next(0, 1000));
            Thread.Sleep(1000);
            reciboTres= new Recibo(numeroAleatorio.Next(0, 1000));


            listaContable += facturaUno;
            listaContable += facturaDos;
            listaContable += facturaTres;
            listaContable += reciboUno;
            listaContable += reciboDos;
            listaContable += reciboTres;
            Console.Write(listaContable.Mostrar());

            Console.ReadKey();

        }
    }
}
