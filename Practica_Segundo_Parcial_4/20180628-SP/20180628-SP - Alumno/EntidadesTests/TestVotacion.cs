using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Entidades.Tests
{
    [TestClass()]
    public class TestVotacion
    {
        [TestMethod()]
        [ExpectedException(typeof(ErrorArchivoException))]
        public void XmlGuardarTest()
        {
            //Arrange
            Votacion votacion = new Votacion();
            XmlSerializar<Votacion> xml = new XmlSerializar<Votacion>();

            //Act
            xml.Guardar("\\testVotacion.xml", votacion);

            //Assert
        }
    }
}