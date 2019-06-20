using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Archivos
{
    public class Sql : IArchivo<Queue<Patente>>
    {
        private SqlCommand comando;
        private SqlConnection conexion;

        public void Guardar(string tabla, Queue<Patente> datos)
        {
          
            try
            {
                this.conexion.Open();
                
                foreach(Patente patente in datos)
                {
                    StringBuilder consulta = new StringBuilder("INSERT INTO ");

                    consulta.Append(tabla);
                    consulta.AppendFormat("(Patente) VALUES ({0});", patente);
                    this.comando.CommandText = consulta.ToString();
                    this.comando.ExecuteNonQuery();
                }
            }
            catch(SqlException exception)
            {
                throw exception;
            }
            finally
            {
                this.conexion.Close();
            }


        }

        public void Leer(string tabla, out Queue<Patente> datos)
        {
            StringBuilder consulta = new StringBuilder("SELECT Patente FROM ");
            SqlDataReader lectorBaseDatos = this.comando.ExecuteReader();
            datos = new Queue<Patente>();

            while(lectorBaseDatos.Read())
            {
                string codigoPatente = lectorBaseDatos["codigo"].ToString();
                Patente.Tipo tipoPatente = (Patente.Tipo)lectorBaseDatos["tipo"];

                datos.Enqueue(new Patente(codigoPatente, tipoPatente));
            }
        }

        public Sql()
        {
            String connectionString = "Data Source=[Instancia Del Servidor];" +
                " Initial Catalog =[Nombre de la Base de Datos]; Integrated Security = True";
            this.conexion = new SqlConnection(connectionString);
            this.comando = new SqlCommand();

            comando.CommandType = CommandType.Text;
            comando.Connection = conexion;
        }

    }
}
