using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_equipo_22A
{
	internal class MarcaNegocio
	{
		// Este método obtiene todas las marcas de la base de datos.
		// Realiza una consulta SELECT sobre la tabla MARCAS y recorre los resultados.
		// Por cada registro, crea un objeto Marca y lo agrega a la lista final.
		public List<Marca> listar()
		{
			List<Marca> lista = new List<Marca>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				// Se configura la cadena de conexión y el tipo de comando SQL.
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				// Consulta SQL para obtener Id y Descripcion de todas las marcas.
				comando.CommandText = "SELECT Id, Descripcion FROM MARCAS";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				// Se recorre cada registro devuelto por la consulta.
				while (lector.Read())
				{
					Marca aux = new Marca();
					// Se asignan los valores de Id y Descripcion al objeto Marca.
					aux.Id = (int)lector["Id"];
					aux.Descripcion = (string)lector["Descripcion"];
					// Se agrega la marca a la lista.
					lista.Add(aux);
				}
			}
			catch (Exception)
			{
				// Si ocurre un error, se relanza la excepción.
				throw;
			}
			finally
			{
				// Se cierran los recursos de base de datos para evitar fugas de memoria.
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
			// Se retorna la lista de marcas obtenidas.
			return lista;
		}

		// Este método agrega una nueva marca a la base de datos.
		// Recibe un objeto Marca y ejecuta un INSERT en la tabla MARCAS.
		// Se utiliza un parámetro SQL (@descripcion) para asegurar que el valor sea el correcto.
		// ExecuteNonQuery ejecuta el comando SQL y retorna el número de filas afectadas
		public void agregar(Marca nueva)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "INSERT into MARCAS (Descripcion) values (@descripcion)";
				comando.Connection = conexion;
				comando.Parameters.AddWithValue("@descripcion", nueva.Descripcion);
				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception)
			{
				// Si ocurre un error, se relanza la excepción.
				throw;
			}
			finally
			{
				// Se cierra la conexión para liberar recursos.
				conexion.Close();
			}
		}

		// Este método modifica una marca existente en la base de datos.
		// Recibe un objeto Marca y actualiza la descripción según el Id.
		// Se usan parámetros SQL para evitar inyecciones y asegurar los valores.
		public void modificar(Marca marca)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE MARCAS set Descripcion = @descripcion WHERE Id = @id";
				comando.Connection = conexion;
				comando.Parameters.AddWithValue("@descripcion", marca.Descripcion);
				comando.Parameters.AddWithValue("@id", marca.Id);
				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				conexion.Close();
			}
		}

		// Este método elimina una marca de la base de datos según su Id.
		// Ejecuta un DELETE en la tabla MARCAS usando el parámetro @id.
		public void eliminar(int id)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "DELETE FROM MARCAS WHERE Id = @id";
				comando.Connection = conexion;
				comando.Parameters.AddWithValue("@id", id);
				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				conexion.Close();
			}
		}
	}
}
