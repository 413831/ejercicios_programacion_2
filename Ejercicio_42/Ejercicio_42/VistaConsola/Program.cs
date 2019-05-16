﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaConsola
{
     /*   a.Lanzar una excepción DivideByZeroException en un método estático
        b.Capturar la excepción del punto a en un constructor de instancia y relanzarla hacia otro
        constructor de instancia.
        c.En este segundo constructor, crear una excepción propia llamada UnaException (utilizar
        innerException para almacenar la excepción original) y volver a lanzarla.
        d.Luego crear un método de instancia que capture la excepción anterior. Este método
        generará una excepción propia llamada MiException y la lanzará.
        e.MiException será capturada en el Main, mostrando el mensaje de error que esta almacena
        por pantalla y los mensajes de todas las excepciones almacenadas en sus innerException.*/
    class Program
    {
        static void Main(string[] args)
        {
            int primerNumero = 20;
            int segundoNumero = 0;
            int resultado;

            try
            {
                resultado = primerNumero / segundoNumero;                
            }
            catch(DivideByZeroException exception)
            {
                throw new UnaException(exception);
            }
        }
    }
}
