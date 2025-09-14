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
		public List<Categoria> listar()
		{
			List<Categoria> lista = new List<Categoria>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT Id, Descripcion FROM CATEGORIAS";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();

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

		//logica de agregar-modifica-eliminar similar a marcaNegocio leer comentarios de ahi
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
				if (conexion != null)
					conexion.Close();
			}
		}

		public void modificar(Categoria categoria)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE CATEGORIAS set Descripcion = @descripcion WHERE Id = @id"; //convencion de sql asi el valor de @descripcion será el que tenga categoria.Descripcion,
																										 //y el de @id el de categoria.Id porque se pasan como parametros
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
