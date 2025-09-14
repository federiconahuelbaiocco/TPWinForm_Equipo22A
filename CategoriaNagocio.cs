using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_equipo_22A
{
	internal class CategoriaNegocio
	{
		// Este método obtiene todas las categorías de la base de datos.
		// Realiza una consulta SELECT y recorre los resultados para crear objetos Categoria.
		public List<Categoria> listar()
		{
			List<Categoria> lista = new List<Categoria>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				// Se configura la conexión y el comando SQL.
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT Id, Descripcion FROM CATEGORIAS";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				// Se recorre cada registro y se crea un objeto Categoria.
				while (lector.Read())
				{
					Categoria aux = new Categoria();
					aux.Id = (int)lector["Id"];
					aux.Descripcion = (string)lector["Descripcion"];
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
				// Se cierran los recursos de base de datos.
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
			return lista;
		}

		// Este método agrega una nueva categoría a la base de datos.
		// Recibe un objeto Categoria y ejecuta un INSERT.
		public void agregar(Categoria nueva)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "INSERT into CATEGORIAS (Descripcion) values (@descripcion)";
				comando.Connection = conexion;

				// Se asigna el valor de la descripción como parámetro.
				comando.Parameters.AddWithValue("@descripcion", nueva.Descripcion);

				conexion.Open();
				// ExecuteNonQuery ejecuta el comando SQL sin devolver resultados.
				comando.ExecuteNonQuery();
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (conexion != null)
					conexion.Close();
			}
		}

		// Este método modifica una categoría existente en la base de datos.
		// Recibe un objeto Categoria y actualiza la descripción según el Id.
		public void modificar(Categoria categoria)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				// Se actualiza la descripción de la categoría con el Id correspondiente.
				comando.CommandText = "UPDATE CATEGORIAS set Descripcion = @descripcion WHERE Id = @id";
				comando.Connection = conexion;

				comando.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
				comando.Parameters.AddWithValue("@id", categoria.Id);

				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception )
			{
				throw ;
			}
			finally
			{
				if (conexion != null)
					conexion.Close();
			}
		}

		// Este método elimina una categoría de la base de datos según su Id.
		public void eliminar(int id)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "DELETE FROM CATEGORIAS WHERE Id = @id";
				comando.Connection = conexion;

				comando.Parameters.AddWithValue("@id", id);

				conexion.Open();
				comando.ExecuteNonQuery();
			}
			catch (Exception )
			{
				throw ;
			}
			finally
			{
				if (conexion != null)
					conexion.Close();
			}
		}
	}
}
