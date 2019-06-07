using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public class PersonaDAO
    {
        private String connectionStr = @"Data Source=LAB3PC10\SQLEXPRESS; " +
            "Initial Catalog =BaseDeDatos_Practica; Integrated Security = True";
        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lectorBaseDeDatos;
        public List<Persona> listadoPersonas = new List<Persona>(); 

        public PersonaDAO()
        {
            this.ConectarBaseDeDatos();
        }

        private void ConectarBaseDeDatos()
        {
            try
            {
                conexion = new SqlConnection(connectionStr); // Creo la conexión por medio de string
                comando = new SqlCommand(); // Creo el objeto para ejecutar comandos
                comando.CommandType = System.Data.CommandType.Text; // Seteo al objeto comando para trabajar con texto

                comando.Connection = conexion;
            }
            catch(InvalidOperationException exception)
            {
                throw exception;
            }
        }


        public bool Guardar(Persona persona)
        {
            StringBuilder comandoTexto = new StringBuilder("INSERT INTO Persona(ID,Nombre,Apellido) ");
            comando.CommandText = comandoTexto.AppendFormat("VALUES({0},'{1}','{2}')", 
                                                            persona.Id.ToString(), 
                                                            persona.Nombre,
                                                            persona.Apellido).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery();
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

        public List<Persona> Leer()
        {
            Persona personaAuxiliar;
            comando.CommandText = "SELECT * FROM Persona";

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                lectorBaseDeDatos = comando.ExecuteReader(); // Seteo el objeto para leer datos  

                while (lectorBaseDeDatos.Read())
                {
                    personaAuxiliar = new Persona((int)lectorBaseDeDatos["ID"],
                                                    lectorBaseDeDatos["Nombre"].ToString(), 
                                                    lectorBaseDeDatos["Apellido"].ToString());
                    listadoPersonas.Add(personaAuxiliar);
                }

                return listadoPersonas;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                conexion.Close();
            }
        }

        public Persona LeerPorID(int id)
        {
            Persona personaAuxiliar;
            StringBuilder comandoTexto = new StringBuilder("SELECT * FROM Persona "); 
            comando.CommandText = comandoTexto.AppendFormat("WHERE id = {0}",id).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                lectorBaseDeDatos = comando.ExecuteReader(); // Seteo el objeto para leer datos  

                if (lectorBaseDeDatos.Read())
                {
                    personaAuxiliar = new Persona((int)lectorBaseDeDatos["ID"],
                                                    lectorBaseDeDatos["Nombre"].ToString(),
                                                    lectorBaseDeDatos["Apellido"].ToString());
                    return personaAuxiliar;
                }
                throw new NullReferenceException("Persona inexistente");
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Modificar(int id, string nombre, string apellido)
        {
            StringBuilder comandoTexto = new StringBuilder("UPDATE Persona SET ");
            comando.CommandText = comandoTexto.AppendFormat("Nombre = '{0}', Apellido = '{1}' WHERE id = {2}",
                                                            nombre,apellido,id.ToString()).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery();

                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                conexion.Close();
            }
        }

        public bool Borrar(int id)
        {
            StringBuilder comandoTexto = new StringBuilder("DELETE FROM Persona ");
            comando.CommandText = comandoTexto.AppendFormat("WHERE id = {0}",id.ToString()).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery();

                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
