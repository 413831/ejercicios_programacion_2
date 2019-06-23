using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase para realizar operaciónes básicas de ABM con una tabla de una base de datos SQL
    /// </summary>
    public class Sql
    {
        private String connectionStr = @"Data Source=LAB3PC10\SQLEXPRESS; " +
            "Initial Catalog =BaseDeDatos_Practica; Integrated Security = True"; // Cadena que establece comando para la instancia SQL y la base de datos
        private SqlConnection conexion; // Variable para la conexión a la base de datos
        private SqlCommand comando; // Variable para ejecutar comandos SQL
        private SqlDataReader lectorBaseDeDatos; // Variable para leer datos de la tabla de SQL
        public List<Object> listado = new List<Object>();  

        /// <summary>
        /// Constructor público que inicializa la conexión a la base de datos
        /// </summary>
        public Sql()
        {
            this.ConectarBaseDeDatos();
        }

        /// <summary>
        /// Método para inicializar atributos para trabajar con la base de datos
        /// </summary>
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

        /// <summary>
        /// Método para guardar un objeto en la tabla de la base de datos SQL
        /// </summary>
        /// <param name="objeto">Objeto para guardar los datos</param>
        /// <returns>Retorna true si logró guardarlo sino retorna false</returns>
        public bool Guardar(Object objeto)
        {
            StringBuilder comandoTexto = new StringBuilder("INSERT INTO Persona(ID,Nombre,Apellido) ");
            comando.CommandText = comandoTexto.AppendFormat("VALUES({0},'{1}','{2}')",
                                                            objeto.Id.ToString(),
                                                            objeto.Nombre,
                                                            objeto.Apellido).ToString();

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

        /// <summary>
        /// Método para leer TODOS los datos de una tabla de la base de datos SQL
        /// </summary>
        /// <returns></returns>
        public List<Persona> Leer()
        {
            Object objeto;
            comando.CommandText = "SELECT * FROM Persona";

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                lectorBaseDeDatos = comando.ExecuteReader(); // Seteo el objeto para leer datos  

                while (lectorBaseDeDatos.Read())
                {
                    // Creo un nuevo objetos con los datos leídos de cada columna de la tabla
                    //Modificar según atributos del objeto
                    objeto = new Persona((int)lectorBaseDeDatos["ID"],
                                                    lectorBaseDeDatos["Nombre"].ToString(), 
                                                    lectorBaseDeDatos["Apellido"].ToString());
                    listado.Add(objeto); // Agrego el nuevo objeto en el listado de la clase
                }
                return listado;
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

        /// <summary>
        /// Método para leer los datos de UN objeto por ID de una tabla de la base de datos SQL
        /// </summary>
        /// <param name="id">ID del elemento a leer</param>
        /// <returns>Retorna un objeto construido desde los datos de la tabla</returns>
        public Object LeerPorID(int id)
        {
            Object objeto;
            StringBuilder comandoTexto = new StringBuilder("SELECT * FROM Persona "); 
            comando.CommandText = comandoTexto.AppendFormat("WHERE id = {0}",id).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                lectorBaseDeDatos = comando.ExecuteReader(); // Seteo el objeto para leer datos  

                if (lectorBaseDeDatos.Read())
                {
                    //Modificar según atributos del objeto
                    objeto = new Persona((int)lectorBaseDeDatos["ID"],
                                            lectorBaseDeDatos["Nombre"].ToString(),
                                            lectorBaseDeDatos["Apellido"].ToString());
                    return objeto;
                }
                throw new NullReferenceException("Elemento inexistente");
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

        /// <summary>
        /// Método para actualizar los datos de un objeto de una tabla de la base de datos SQL
        /// </summary>
        /// <param name="id">Valor para el campo ID del objeto</param>
        /// <param name="nombre">Valor para el campo nombre del objeto</param>
        /// <param name="apellido">Valor para el campo apellido del objeto</param>
        /// <returns></returns>
        public bool Modificar(int id, string nombre, string apellido)
        {
            StringBuilder comandoTexto = new StringBuilder("UPDATE Persona SET ");
            comando.CommandText = comandoTexto.AppendFormat("Nombre = '{0}', Apellido = '{1}' WHERE id = {2}",
                                                            nombre,apellido,id.ToString()).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery(); // Ejecuta el comando

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

        /// <summary>
        /// Método para eliminar un objeto de una tabla de la base de datos SQL
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Borrar(int id)
        {
            StringBuilder comandoTexto = new StringBuilder("DELETE FROM Persona ");
            comando.CommandText = comandoTexto.AppendFormat("WHERE id = {0}",id.ToString()).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery(); // Ejecuta el comando

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
