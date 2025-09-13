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

				// Usamos el JOIN para obtener las descripciones de las marcas y categorías.
				comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion, C.Descripcion, A.IdMarca, A.IdCategoria, A.Precio FROM ARTICULOS A, MARCAS M, CATEGORIAS C WHERE A.IdMarca = M.Id AND A.IdCategoria = C.Id";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Articulo aux = new Articulo();

					// Asignamos las propiedades usando el índice de cada columna
					aux.Id = lector.GetInt32(0);
					aux.Codigo = lector.GetString(1);
					aux.Nombre = lector.GetString(2);
					aux.Descripcion = lector.GetString(3);

					// verificamos si el precio es nulo antes de asignarlo
					if (!lector.IsDBNull(8))
					{
						aux.Precio = lector.GetDecimal(8);
					}

					aux.Marca = new Marca();
					aux.Marca.Id = lector.GetInt32(6);
					aux.Marca.Descripcion = lector.GetString(4);

					aux.Categoria = new Categoria();
					aux.Categoria.Id = lector.GetInt32(7);
					aux.Categoria.Descripcion = lector.GetString(5);

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

		public Articulo obtenerPorId(int id)
		{
			Articulo articulo = null;
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id AS IdMarca, M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.Id = @id";
				comando.Connection = conexion;
				comando.Parameters.AddWithValue("@id", id);

				conexion.Open();
				lector = comando.ExecuteReader();

				if (lector.Read())
				{
					articulo = new Articulo();
					articulo.Id = (int)lector["Id"];
					articulo.Codigo = (string)lector["Codigo"];
					articulo.Nombre = (string)lector["Nombre"];
					articulo.Descripcion = (string)lector["Descripcion"];
					articulo.Precio = (decimal)lector["Precio"];

					articulo.Marca = new Marca();
					articulo.Marca.Id = (int)lector["IdMarca"];
					articulo.Marca.Descripcion = (string)lector["Marca"];

					articulo.Categoria = new Categoria();
					articulo.Categoria.Id = (int)lector["IdCategoria"];
					articulo.Categoria.Descripcion = (string)lector["Categoria"];
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Error al obtener el artículo por ID", ex);
			}
			finally
			{
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
			return articulo;
		}



	}
}
