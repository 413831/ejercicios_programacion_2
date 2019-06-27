using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class Dao<T> : IArchivo<Votacion>
    {
        private String connectionStr = @"Data Source=.\SQLEXPRESS; " +
            "Initial Catalog = votacion-sp-2018; Integrated Security = True"; // Cadena que establece comando para la instancia SQL y la base de datos
        private SqlConnection conexion; // Variable para la conexión a la base de datos
        private SqlCommand comando; // Variable para ejecutar comandos SQL
   

        public Dao()
        {
            this.ConectarBaseDeDatos();
        }

        private void ConectarBaseDeDatos()
        {
            try
            {
                this.conexion = new SqlConnection(connectionStr); // Creo la conexión por medio de string
                this.comando = new SqlCommand(); // Creo el objeto para ejecutar comandos
                this.comando.CommandType = System.Data.CommandType.Text; // Seteo al objeto comando para trabajar con texto

                this.comando.Connection = conexion;
            }
            catch (InvalidOperationException exception)
            {
                throw exception;
            }
        }

        public bool Guardar(string rutaArchivo, Votacion objeto)
        {
            StringBuilder comandoTexto = new StringBuilder("INSERT INTO Votaciones(nombreLey,afirmativos,negativos,abstenciones,nombreAlumno) ");

            comando.CommandText = comandoTexto.AppendFormat("VALUES('{0}',{1},{2},{3},'{4}')",
                                                                objeto.NombreLey,
                                                                objeto.ContadorAfirmativo,
                                                                objeto.ContadorNegativo,
                                                                objeto.ContadorAbstencion,
                                                                "Alejandro Planes").ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery(); // Ejecuta el comando
                return true;
            }
            catch (SqlException exception)
            {
                return false;
                throw exception;
            }
            finally
            {
                conexion.Close();
            }
        }

        public Votacion Leer(string rutaArchivo)
        {
            throw new NotImplementedException();
        }

    }
}
