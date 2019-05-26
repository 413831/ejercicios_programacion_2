using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaConsola
{
    class ClaseTest
    {
        public static void MetodoEstatico()
        {
            try
            {
                int numeroUno = 10;
                int numeroDos = 0;
                int resultado;

                resultado = numeroUno / numeroDos;

            }
            catch (DivideByZeroException exception)
            {
                throw exception;
            }
        }

        

        public ClaseTest()
        {
            try
            {
                ClaseTest.MetodoEstatico();
            }
            catch(DivideByZeroException exception)
            {
                throw exception;
            }
        }

        public ClaseTest(int numero)
        {   
            try
            {
                new ClaseTest();
            }
            catch (DivideByZeroException exception)
            {
                throw new UnaException("No es válido dividir por 0",exception);
            }
        }
    }
}
