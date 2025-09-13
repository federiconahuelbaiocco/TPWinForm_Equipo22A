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

				comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

				while (lector.Read())
				{
					Articulo aux = new Articulo();

					aux.Id = (int)lector["Id"];
					aux.Codigo = (string)lector["Codigo"];
					aux.Nombre = (string)lector["Nombre"];
					aux.Descripcion = (string)lector["Descripcion"];


					if (!(lector["Precio"] is DBNull))
						aux.Precio = (decimal)lector["Precio"];

					aux.Marca = new Marca();
					aux.Marca.Id = (int)lector["IdMarca"];
					aux.Marca.Descripcion = (string)lector["Marca"];

					aux.Categoria = new Categoria();
					aux.Categoria.Id = (int)lector["IdCategoria"];
					aux.Categoria.Descripcion = (string)lector["Categoria"];

					// Aquí se asigna solo la primera imagen válida
					aux.UrlImagen = ObtenerPrimeraImagenValida(aux.Id);

					// Después de crear el objeto Articulo aux
					aux.Imagenes = ObtenerImagenesPorId(aux.Id); 
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
		public int agregar(Articulo nuevo)
		{
			int idGenerado = 0;
			using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				string query = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) OUTPUT INSERTED.Id VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)";
				SqlCommand comando = new SqlCommand(query, conexion);
				comando.Parameters.AddWithValue("@codigo", nuevo.Codigo);
				comando.Parameters.AddWithValue("@nombre", nuevo.Nombre);
				comando.Parameters.AddWithValue("@descripcion", nuevo.Descripcion);
				comando.Parameters.AddWithValue("@idMarca", nuevo.Marca.Id);
				comando.Parameters.AddWithValue("@idCategoria", nuevo.Categoria.Id);
				comando.Parameters.AddWithValue("@precio", nuevo.Precio);

				conexion.Open();
				idGenerado = (int)comando.ExecuteScalar();
			}
			return idGenerado;
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

		public string ObtenerPrimeraImagenValida(int idArticulo)
		{
			using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				string query = "SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo";
				SqlCommand comando = new SqlCommand(query, conexion);
				comando.Parameters.AddWithValue("@idArticulo", idArticulo);
				conexion.Open();
				SqlDataReader lector = comando.ExecuteReader();
				if (lector.Read())
				{
					return (string)lector["ImagenUrl"];
				}
			}
			return null;
		}

		public List<string> ObtenerImagenesPorId(int idArticulo)
		{
			var imagenes = new List<string>();
			using (var conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				var query = "SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo";
				var comando = new SqlCommand(query, conexion);
				comando.Parameters.AddWithValue("@idArticulo", idArticulo);
				conexion.Open();
				var lector = comando.ExecuteReader();
				while (lector.Read())
				{
					imagenes.Add((string)lector["ImagenUrl"]);
				}
			}
			return imagenes;
		}

		public static bool EsImagenValida(string url)
		{
			try
			{
				var request = System.Net.WebRequest.Create(url);
				request.Method = "GET";
				request.Timeout = 3000; // 3 segundos
				using (var response = request.GetResponse())
				{
					return ((System.Net.HttpWebResponse)response).StatusCode == System.Net.HttpStatusCode.OK;
				}
			}
			catch
			{
				return false;
			}
		}
		
		public void guardarImagenes(int idArticulo, List<string> imagenes)
		{
			using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				conexion.Open();
				// Elimina las imágenes anteriores
				var comandoDelete = new SqlCommand("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo", conexion);
				comandoDelete.Parameters.AddWithValue("@idArticulo", idArticulo);
				comandoDelete.ExecuteNonQuery();

				// Inserta las nuevas imágenes
				foreach (var url in imagenes)
				{
					var comandoInsert = new SqlCommand("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @url)", conexion);
					comandoInsert.Parameters.AddWithValue("@idArticulo", idArticulo);
					comandoInsert.Parameters.AddWithValue("@url", url);
					comandoInsert.ExecuteNonQuery();
				}
			}
		}
	}
}
