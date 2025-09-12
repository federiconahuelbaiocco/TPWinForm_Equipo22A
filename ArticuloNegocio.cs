using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPWinForm_equipo_22A
{
	internal class ArticuloNegocio
	{
		public List<Articulo> Listar()
		{
			List<Articulo> lista = new List<Articulo>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio FROM ARTICULOS";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Articulo aux = new Articulo();
					aux.Id = lector.GetInt32(0);
					aux.Codigo = lector.GetString(1);
					aux.Nombre = lector.GetString(2);
					aux.Descripcion = lector.GetString(3);
					aux.Precio = lector.GetDecimal(6);

					// Aquí tendrás que asignar la marca y la categoría.
					// Lo veremos en el siguiente paso.

					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{
				throw new Exception("Error al listar los artículos", ex);
			}
			finally
			{
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
		}
		public void agregar(Articulo nuevo)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "INSERT into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)";
				comando.Connection = conexion;

				// Pasamos los parámetros
				comando.Parameters.AddWithValue("@codigo", nuevo.Codigo);
				comando.Parameters.AddWithValue("@nombre", nuevo.Nombre);
				comando.Parameters.AddWithValue("@descripcion", nuevo.Descripcion);
				comando.Parameters.AddWithValue("@idMarca", nuevo.Marca.Id);
				comando.Parameters.AddWithValue("@idCategoria", nuevo.Categoria.Id);
				comando.Parameters.AddWithValue("@precio", nuevo.Precio);

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

		//logica para modificar 
		public void modificar(Articulo articulo)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "UPDATE ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id";
				comando.Connection = conexion;

				comando.Parameters.AddWithValue("@codigo", articulo.Codigo); //genero la variable con el @
				comando.Parameters.AddWithValue("@nombre", articulo.Nombre);
				comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
				comando.Parameters.AddWithValue("@idMarca", articulo.Marca.Id);
				comando.Parameters.AddWithValue("@idCategoria", articulo.Categoria.Id);
				comando.Parameters.AddWithValue("@precio", articulo.Precio);
				comando.Parameters.AddWithValue("@id", articulo.Id);

				conexion.Open();
				comando.ExecuteNonQuery();

			}
			catch (Exception)
			{
				throw ;
			}
			finally
			{
				conexion.Close();
			}
		}

		//logi
		public void eliminar(int id)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;

				// Consulta SQL para eliminar un registro
				comando.CommandText = "DELETE FROM ARTICULOS WHERE Id = @id";
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
