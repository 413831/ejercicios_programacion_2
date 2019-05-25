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
            Competencia competencia;
            List<VehiculoCarrera> lista;

            //act
            competencia = new Competencia(5, 5, TipoCompetencia.F1);
            lista = competencia.ListaVehiculos;

            //assert
            Assert.IsNotNull(lista);
        }

        [TestMethod]
        public void TestExcepcionCompetenciaVehiculoNoValido()
        {
            //Test para probar el funcionamiento de la excepción con vehiculo inválido
            //arrange
            Competencia competencia;
            AutoF1 auto;

            //act
            competencia = new Competencia(5, 5, TipoCompetencia.MotoCross);
            auto = new AutoF1(4, "Mercedez Benz");
            try
            {
                if(competencia + auto)
                {}
            }
            catch(CompetenciaNoDisponibleException excepcion)
            {
                //assert
                Assert.Fail(excepcion.Message);
            }
        }

        [TestMethod]
        public void TestExcepcionCompetenciaVehiculoValido()
        {
            //Test para probar el funcionamiento de la excepción con vehiculo válido
            //arrange
            Competencia competencia;
            MotoCross moto;

            //act
            competencia = new Competencia(5, 5, TipoCompetencia.MotoCross);
            moto = new MotoCross(2, "Mitsubishi");
            
            try
            {
                //assert
                Assert.IsTrue(competencia + moto);
            }
            catch (CompetenciaNoDisponibleException excepcion)
            {
                Assert.Fail(excepcion.Message);
            }
            
        }

        [TestMethod]
        public void TestVehiculoExistenteEnLista()
        {
            //Test para probar que un vehiculo ya existe en la lista
            //arrange
            Competencia competencia = new Competencia(5, 5, TipoCompetencia.F1); ;
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
            Competencia competencia = new Competencia(5, 5, TipoCompetencia.F1); ;
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
