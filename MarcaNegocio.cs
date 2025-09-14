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
		public List<Marca> listar()
		{
			List<Marca> lista = new List<Marca>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT Id, Descripcion FROM MARCAS";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Marca aux = new Marca();
					aux.Id = (int)lector["Id"];
					aux.Descripcion = (string)lector["Descripcion"];

					lista.Add(aux);
				}
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
			return lista;
		}

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
				throw;
			}
			finally
			{
				conexion.Close();
			}
		}

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
