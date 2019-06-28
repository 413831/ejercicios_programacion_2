using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ComiqueriaLogic.Entidades
{
    public class Sql
    {
        public delegate void DelegadoBaseDeDatos(AccionesDB acciones);
        public static event DelegadoBaseDeDatos AccesoBaseDeDatos; 

        private String connectionStr = @"Data Source=.\SQLEXPRESS; " +
            "Initial Catalog = Comiqueria; Integrated Security = True"; // Cadena que establece comando para la instancia SQL y la base de datos
        private SqlConnection conexion; // Variable para la conexión a la base de datos
        private SqlCommand comando; // Variable para ejecutar comandos SQL
        private SqlDataReader lectorBaseDeDatos; // Variable para leer datos de la tabla de SQL
        public List<Producto> listado = new List<Producto>();

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
            catch (InvalidOperationException exception)
            {
                throw new ComiqueriaException("No se pudo conectar con la base de datos.",exception);
            }
        }

        /// <summary>
        /// Método para guardar en la base de datos
        /// </summary>
        /// <param name="descripcion"></param>
        /// <param name="stock"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
        public bool Guardar(string descripcion, int stock, double precio)
        {
            StringBuilder comandoTexto = new StringBuilder("INSERT INTO Productos(Descripcion,Precio,Stock) ");
            comando.CommandText = comandoTexto.AppendFormat("VALUES('{0}',{1},{2})",
                                                            descripcion,
                                                            precio,
                                                            stock).ToString();

            try
            {
                conexion.Open(); // Abre comunicación con la base de datos
                comando.ExecuteNonQuery(); // Ejecuta el comando
                Sql.AccesoBaseDeDatos(AccionesDB.Insert);
                return true;
            }
            catch (SqlException exception)
            {
                return false;
                throw new ComiqueriaException("No se pudo guardar en la base de datos.", exception);
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
        public bool Modificar(string descripcion, double precio)
        {
            StringBuilder comandoTexto = new StringBuilder("UPDATE Productos SET ");
            comando.CommandText = comandoTexto.AppendFormat("precio = '{0}', WHERE Descripcion = '{1}'",
                                                            precio, descripcion).ToString();

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
        /// Método para leer TODOS los datos de una tabla de la base de datos SQL
        /// </summary>
        /// <returns></returns>
        public List<Producto> Leer()
        {
            Producto producto;
            this.comando.CommandText = "SELECT * FROM Productos";

            try
            {
                this.conexion.Open(); // Abre comunicación con la base de datos
                this.lectorBaseDeDatos = comando.ExecuteReader(); // Seteo el objeto para leer datos  

                while (this.lectorBaseDeDatos.Read())
                {
                    // Creo un nuevo objetos con los datos leídos de cada columna de la tabla
                    //Modificar según atributos del objeto
                    producto = new Producto((int)lectorBaseDeDatos["Codigo"],
                                                lectorBaseDeDatos["Descripcion"].ToString(),
                                                (int)lectorBaseDeDatos["Stock"],
                                                (double)lectorBaseDeDatos["Precio"]);
                    this.listado.Add(producto); // Agrego el nuevo objeto en el listado de la clase
                }
                
                return this.listado;
            }
            catch (SqlException exception)
            {
                throw new ComiqueriaException("Error al acceder a base de datos.", exception);
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
        public bool Borrar(Producto producto)
        {
            StringBuilder comandoTexto = new StringBuilder("DELETE FROM Productos ");
            this.comando.CommandText = comandoTexto.AppendFormat("WHERE Descripcion = '{0}'", producto.Descripcion).ToString();

            try
            {
                this.conexion.Open(); // Abre comunicación con la base de datos
                this.comando.ExecuteNonQuery(); // Ejecuta el comando

                Sql.AccesoBaseDeDatos(AccionesDB.Delete);
                return true;
            }
            catch (SqlException exception)
            {
                throw new ComiqueriaException("Error al acceder a base de datos.",exception);
            }
            finally
            {
                this.conexion.Close();
            }
        }
    }
}

