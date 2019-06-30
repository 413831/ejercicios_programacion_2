using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComiqueriaLogic.Entidades;
using ComiqueriaLogic;
using System.Collections.Generic;

namespace TestComiqueria
{
    [TestClass]
    public class TestComiqueria
    {
        [TestMethod]
        public void TestListarVentas()
        {
            //Arrange
            Comiqueria comiqueria = new Comiqueria();

            //Act

            //Arrange
            Assert.IsNotNull(comiqueria.ListarVentas());

        }

        [TestMethod]
        public void TestLeerBaseDeDatos()
        {
            //Arrange
            Sql sql = new Sql();
            List<Producto> listaTest;

            //Act
            listaTest = sql.Leer();

            //Arrange
            Assert.IsNotNull(listaTest);

        }

        [TestMethod]
        public void TestGuardarBaseDeDatos()
        {
            //Arrange
            Sql sql = new Sql();

            //Act

            //Arrange
            
            Assert.IsFalse(sql.Guardar("test",1,2f));

        }

    }
}
