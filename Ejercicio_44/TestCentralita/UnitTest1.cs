using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestCentralita
{
    /*
     * a. Crear un test unitario que valide que la lista de llamadas de la centralita esté instanciada al
    crear un nuevo objeto del tipo Centralita.
    b. Controlar mediante un nuevo método de test unitario que la excepción CentralitaExcepcion
    se lance al intentar cargar una segunda llamada con solamente los mismos datos de origen y
    destino de una llamada Local ya existente.
    c. Controlar mediante un nuevo método de test unitario que la excepción CentralitaExcepcion
    se lance al intentar cargar una segunda llamada con solamente los mismos datos de origen y
    destino de una llamada Provincial ya existente.
    d. Dentro de un método de test unitario crear dos llamadas Local y dos Provincial, todos con
    los mismos datos de origen y destino. Luego comparar cada uno de estos cuatro objetos
    contra los demás, debiendo ser iguales solamente las instancias de Local y de Provincial
    entre sí.
     * */
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestListaLlamadas()
        {
            //arrange
            Centralita central;
            //act
            central = new Centralita("Empresa");
            //assert
            Assert.IsNotNull(central.Llamadas);
        }

        [TestMethod]
        public void TestLlamadaExistente()
        {
            //arrange
            Centralita central;
            Local llamadaUno;
            Local llamadaDos;
            //act
            central = new Centralita("Emplesa");
            llamadaUno = new Local("Bernal", 30, "Rosario", 2.65f);
            llamadaDos = new Local("idxgmkfd", 45, "Rosario", 2.65f);
            try
            {
                central += llamadaUno;
                central += llamadaDos;
                Assert.Fail("No se lanzo un joraca");//Se lanza un assert exception
            }
            catch (AssertFailedException)//Se puede lanzar una excepcion para casos correctos
            {
                throw;
            }
            catch (CentralitaException exception)
            {
                //Excepcion del error buscado
                //assert
                Assert.Fail(exception.Message);
            }
        }
    }
}
