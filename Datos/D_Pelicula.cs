using Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class D_Pelicula //Aqui van los metodos (agregar, seleccionar, modificar...)
    {
        //Obtenemos la cadena de conexión desde WebConfig con la clase ConfigurationManager (es global)
        private string CadenaConexion = ConfigurationManager.ConnectionStrings["sql"].ConnectionString;

        public List<E_Pelicula> ObtenerTodos()
        {
            //Creamos nuestros objetos
            List<E_Pelicula> peliculas = new List<E_Pelicula>();
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                //Abrir conexión a DB
                conexion.Open();

                //Objeto de la clase SqlCommand para ejecutar el Stored Procedure
                // Le pasamos al constructor el nombre del Stored Procedure y la cadena de conexión
                SqlCommand comando = new SqlCommand("obtener_todos_peliculas", conexion);

                //Indicarle al objeto comando que va a ejecutar un stored procedure
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Declaramos un SqlDataReader para almacenar los resultados y ejecutamos el Stored Procedure
                SqlDataReader reader = comando.ExecuteReader();

                //Recorrer los resultados y crear lista de Peliculas
                while (reader.Read())
                {
                    //Crear un objeto pelicula
                    E_Pelicula pelicula = new E_Pelicula();

                    pelicula.IdPelicula = Convert.ToInt32(reader["idPelicula"]); //IdPelicula es la referencia al constructor, idPelicula es la referencia a lo traido de la DB
                    pelicula.Nombre = Convert.ToString(reader["nombre"]);
                    pelicula.Genero = Convert.ToString(reader["genero"]);
                    pelicula.FechaEstreno = Convert.ToDateTime(reader["fechaEstreno"]);

                    peliculas.Add(pelicula);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }

            return peliculas;
        }


        // Paso 1 para editar/eliminar
        public E_Pelicula ObtenerPorID(int id)
        {
            //Crear objetos
            E_Pelicula pelicula = new E_Pelicula();
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                //Abrimos la conexión
                conexion.Open();

                //Objeto de la clase SqlCommand para ejecutar el Stored Procedure
                //Pasamos al constructor le nombre del SP y la cadena de conexion
                SqlCommand comando = new SqlCommand("obtener_pelicula_id", conexion);

                //Indicamos que se trata de un SP
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Valores de los parámetros del SP
                comando.Parameters.AddWithValue("@idPelicula", id);

                //Creamos objeto SqlDataReader y lo ejecutamos
                SqlDataReader reader = comando.ExecuteReader();

                //Recorremos el único resultado para armar nuestro objeto

                if (reader.Read()) //Si existe algo a leer, entonces...
                {
                    //Asignamos valores a las propiedades del objeto E_Pelicula vacio
                    pelicula.IdPelicula = Convert.ToInt32(reader["idPelicula"]);
                    pelicula.Nombre = Convert.ToString(reader["nombre"]);
                    pelicula.Genero = Convert.ToString(reader["genero"]);
                    pelicula.FechaEstreno = Convert.ToDateTime(reader["fechaEstreno"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
            return pelicula;
        }

        public void Agregar(E_Pelicula pelicula)
        {
            SqlConnection conexion = new SqlConnection(CadenaConexion);

            try
            {
                //Abrimos conexión a DB
                conexion.Open();

                //Objeto de la clase SqlCommand para ejecutar nuestro Stored Procedure
                //Le pasamos al constructor le nombre del Stored Procedure y la conexión
                SqlCommand comando = new SqlCommand("agregar_pelicula", conexion);

                //Indicar al objeto comando que va a ejecutar un Stored Procedure
                comando.CommandType = System.Data.CommandType.StoredProcedure;

                //Como el Stored Procedure recibe parametros, antes de ejecutarlos le pasamos los valores a dichos parámetros
                comando.Parameters.AddWithValue("@nombre", pelicula.Nombre);
                comando.Parameters.AddWithValue("@genero", pelicula.Genero);
                comando.Parameters.AddWithValue("@fechaEstreno", pelicula.FechaEstreno);

                //Ejecutar el comando (Stored Procedure)
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
