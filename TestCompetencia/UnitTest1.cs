using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ejercicio_36;

namespace TestCompetencia
{
    [TestClass]
    public class TestCompetencia
    {
        [TestMethod]
        public void TestListaInicializada()
        {
            //Test para evaluar que una lista esté inicializada
            //arrange
            Competencia<VehiculoCarrera> competencia;
            List<VehiculoCarrera> lista;

            //act
            competencia = new Competencia<VehiculoCarrera>(5, 5, TipoCompetencia.F1);
            lista = competencia.ListaVehiculos;

            //assert
            Assert.IsNotNull(lista);
        }


        [TestMethod]
        public void TestVehiculoExistenteEnLista()
        {
            //Test para probar que un vehiculo ya existe en la lista
            //arrange
            Competencia<VehiculoCarrera> competencia = new Competencia<VehiculoCarrera>(5, 5, TipoCompetencia.F1);
            VehiculoCarrera vehiculo = new AutoF1(5,"Toyota");

            //act
            if(competencia + vehiculo)//Agrego vehiculo
            {
                Assert.IsTrue(competencia == vehiculo);//Es true porque ya está
            }
        }

        [TestMethod]
        public void TestVehiculoInexistenteEnLista()
        {
            //Test para probar que un vehiculo ya existe en la lista
            //arrange
            Competencia<VehiculoCarrera> competencia = new Competencia<VehiculoCarrera>(5, 5, TipoCompetencia.F1);
            VehiculoCarrera vehiculo = new AutoF1(5, "Toyota");

            //act
            if (competencia + vehiculo)//Agrego vehiculo
            {
                if(competencia - vehiculo)//Quito vehiculo
                {
                    Assert.IsTrue(competencia != vehiculo);//Es true si ya no está
                }
            }
        }
    }
}
