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
		// Este método obtiene la lista de artículos desde la base de datos.
		// Realiza una consulta SQL que une las tablas de artículos, marcas y categorías,
		// y construye objetos Articulo con sus propiedades y relaciones.
		public List<Articulo> Listar()
		{
			List<Articulo> lista = new List<Articulo>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				// Se configura la conexión a la base de datos local
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;

				// Consulta SQL: obtiene datos del artículo y sus descripciones de marca y categoría
				comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, A.IdCategoria, A.Precio, M.Descripcion AS Marca, C.Descripcion AS Categoria FROM ARTICULOS A LEFT JOIN MARCAS M ON A.IdMarca = M.Id LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id";
				comando.Connection = conexion;

				conexion.Open();
				lector = comando.ExecuteReader();

				// Se recorre cada registro devuelto por la consulta
				while (lector.Read())
				{
					Articulo aux = new Articulo();

					// Se asignan los datos básicos del artículo
					aux.Id = (int)lector["Id"];
					aux.Codigo = (string)lector["Codigo"];
					aux.Nombre = (string)lector["Nombre"];
					aux.Descripcion = (string)lector["Descripcion"];


					// Se verifica si el precio no es nulo antes de asignarlo
					if (!(lector["Precio"] is DBNull))
						aux.Precio = (decimal)lector["Precio"];

					// Se crea y asigna el objeto Marca con su Id y descripción
					aux.Marca = new Marca();
					aux.Marca.Id = (int)lector["IdMarca"];
					aux.Marca.Descripcion = (string)lector["Marca"];

					// Se crea y asigna el objeto Categoria con su Id y descripción
					aux.Categoria = new Categoria();
					aux.Categoria.Id = (int)lector["IdCategoria"];
					aux.Categoria.Descripcion = (string)lector["Categoria"];

					// Se obtiene la primera imagen válida del artículo (para mostrar en la grilla)
					aux.UrlImagen = ObtenerPrimeraImagenValida(aux.Id);

					// Se obtiene la lista completa de imágenes asociadas al artículo
					aux.Imagenes = ObtenerImagenesPorId(aux.Id); 
					// Se agrega el artículo a la lista final
					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{
				// Si ocurre un error, se lanza una excepción personalizada
				throw new Exception("Error al listar los artículos", ex);
			}
			finally
			{
				// Se cierran los recursos de base de datos para evitar fugas de memoria
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
		}
		// Este método agrega un nuevo artículo a la base de datos.
		// Recibe un objeto Articulo con todos sus datos y ejecuta un INSERT.
		public int agregar(Articulo nuevo)
		{
			int idGenerado = 0;
			using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				// La consulta OUTPUT INSERTED.Id permite obtener el Id del artículo recién insertado.
				string query = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) OUTPUT INSERTED.Id VALUES (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @precio)";
				SqlCommand comando = new SqlCommand(query, conexion);
				// Se asignan los valores de las propiedades del objeto Articulo a los parámetros SQL.
				comando.Parameters.AddWithValue("@codigo", nuevo.Codigo);
				comando.Parameters.AddWithValue("@nombre", nuevo.Nombre);
				comando.Parameters.AddWithValue("@descripcion", nuevo.Descripcion);
				comando.Parameters.AddWithValue("@idMarca", nuevo.Marca.Id);
				comando.Parameters.AddWithValue("@idCategoria", nuevo.Categoria.Id);
				comando.Parameters.AddWithValue("@precio", nuevo.Precio);

				conexion.Open();
				// Ejecuta la consulta y obtiene el Id generado.
				idGenerado = (int)comando.ExecuteScalar();
			}
			return idGenerado;
		}

		// Este método actualiza los datos de un artículo existente en la base de datos.
		// Recibe un objeto Articulo con los nuevos valores y ejecuta un UPDATE.
		// Utiliza parámetros para modificar los campos y asegura que solo se actualice el artículo con el Id indicado.
		public void modificar(Articulo articulo)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				// Se configura la conexión y el tipo de comando.
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				// Consulta SQL para actualizar los campos del artículo.
				comando.CommandText = "UPDATE ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio WHERE Id = @id";
				comando.Connection = conexion;

				// Se asignan los valores del objeto Articulo a los parámetros SQL.
				comando.Parameters.AddWithValue("@codigo", articulo.Codigo);
				comando.Parameters.AddWithValue("@nombre", articulo.Nombre);
				comando.Parameters.AddWithValue("@descripcion", articulo.Descripcion);
				comando.Parameters.AddWithValue("@idMarca", articulo.Marca.Id);
				comando.Parameters.AddWithValue("@idCategoria", articulo.Categoria.Id);
				comando.Parameters.AddWithValue("@precio", articulo.Precio);
				comando.Parameters.AddWithValue("@id", articulo.Id);

				conexion.Open();
				// Ejecuta la consulta de actualización.
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

		// Este método elimina un artículo de la base de datos.
		// Recibe el Id del artículo a eliminar y ejecuta un DELETE en la tabla ARTICULOS.
		public void eliminar(int id)
		{
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			try
			{
				// Se configura la conexión y el tipo de comando.
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;

				// Consulta SQL para eliminar el artículo por su Id.
				comando.CommandText = "DELETE FROM ARTICULOS WHERE Id = @id";
				comando.Connection = conexion;

				// Se asigna el parámetro @id con el valor recibido.
				comando.Parameters.AddWithValue("@id", id);

				conexion.Open();
				// Ejecuta la consulta de eliminación.
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

		// Este método obtiene un artículo específico por su Id.
		// Realiza una consulta SQL que une las tablas de artículos, marcas y categorías.
		// Si encuentra el registro, construye y retorna un objeto Articulo con todos sus datos.
		public Articulo obtenerPorId(int id)
		{
			Articulo articulo = null;
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector = null;

			try
			{
				// Se configura la conexión y el tipo de comando.
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				// Consulta SQL para obtener el artículo y sus datos relacionados.
				// En la consulta SQL, se utiliza A.Id, A.Codigo, etc., porque se están haciendo INNER JOIN entre varias tablas.
				// El prefijo 'A' indica que esos campos pertenecen a la tabla ARTICULOS (A).
				// Esto es necesario para diferenciar los campos cuando hay columnas con el mismo nombre en distintas tablas (por ejemplo, 'Id' existe en ARTICULOS, MARCAS y CATEGORIAS).
				// Así se evita ambigüedad y se obtiene el dato correcto de cada tabla.
				comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id AS IdMarca, M.Descripcion AS Marca, C.Id AS IdCategoria, C.Descripcion AS Categoria FROM ARTICULOS A INNER JOIN MARCAS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS C ON A.IdCategoria = C.Id WHERE A.Id = @id";
				comando.Connection = conexion;
				// con addWithValue permite enviar el valor de 'id' de forma segura
				// El parámetro @id en la consulta se reemplaza por el valor que recibe el método.
				comando.Parameters.AddWithValue("@id", id);
				


				conexion.Open();
				lector = comando.ExecuteReader();

				// Si se encuentra el registro, se asignan los datos al objeto Articulo.
				if (lector.Read())
				{
					articulo = new Articulo();
					articulo.Id = (int)lector["Id"];
					articulo.Codigo = (string)lector["Codigo"];
					articulo.Nombre = (string)lector["Nombre"];
					articulo.Descripcion = (string)lector["Descripcion"];
					articulo.Precio = (decimal)lector["Precio"];

					// Se asigna la marca y la categoría asociadas.
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
				// Si ocurre un error, se lanza una excepción personalizada.
				throw new Exception("Error al obtener el artículo por ID", ex);
			}
			finally
			{
				// Se cierran los recursos de base de datos para evitar fugas de memoria.
				if (lector != null)
					lector.Close();
				if (conexion != null)
					conexion.Close();
			}
			return articulo;
		}

		// Este método obtiene la primera imagen asociada a un artículo en la base de datos.
		// Utiliza un parámetro SQL (@idArticulo) para filtrar por el Id recibido.
		// Devuelve la URL de la primera imagen encontrada o null si no hay ninguna.
		public string ObtenerPrimeraImagenValida(int idArticulo)
		{
			using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				string query = "SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo";
				SqlCommand comando = new SqlCommand(query, conexion);
				// Se usa AddWithValue para pasar el valor de idArticulo de forma segura al parámetro @idArticulo.
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

		// Este método obtiene todas las imágenes asociadas a un artículo.
		// Devuelve una lista de URLs de imágenes filtradas por el Id del artículo.
		public List<string> ObtenerImagenesPorId(int idArticulo)
		{
			var imagenes = new List<string>();
			using (var conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				var query = "SELECT ImagenUrl FROM IMAGENES WHERE IdArticulo = @idArticulo";
				var comando = new SqlCommand(query, conexion);
				// Se usa AddWithValue para pasar el valor de idArticulo de forma segura al parámetro @idArticulo.
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

		// Este método comprueba si una URL de imagen es válida y accesible en Internet.
		// Recibe la URL como parámetro y devuelve true si la imagen existe y es accesible, o false si no lo es.
		public static bool EsImagenValida(string url)
		{
			try
			{
				// Se crea una solicitud HTTP para la URL indicada.
				// WebRequest.Create genera un objeto que permite interactuar con el recurso remoto.
				var request = System.Net.WebRequest.Create(url);

				// Se especifica el método HTTP a usar, en este caso GET, que es el estándar para obtener recursos.
				request.Method = "GET";

				// Se establece un tiempo máximo de espera (timeout) de 3 segundos para evitar que la aplicación se bloquee si la URL no responde.
				request.Timeout = 3000; // 3 segundos

				// Se envía la solicitud y se obtiene la respuesta del servidor.
				// Si la URL es válida y el recurso está disponible, se recibe una respuesta.
				using (var response = request.GetResponse())
				{
					// Se verifica el código de estado HTTP de la respuesta.
					// Si el código es OK (200), significa que la imagen existe y es accesible.
					return ((System.Net.HttpWebResponse)response).StatusCode == System.Net.HttpStatusCode.OK;
				}
			}
			catch
			{
				// Si ocurre cualquier excepción (por ejemplo, la URL no existe, no hay conexión, o el recurso no está disponible),
				// el método retorna false indicando que la imagen no es válida o no se pudo acceder.
				return false;
			}
			// este metodo lo saque de https://stackoverflow.com/questions/11082804/detecting-image-url-in-c-net por si lo tengo que volver a buscar
		}

		// Este método guarda una lista de imágenes para un artículo en la base de datos.
		// Recibe el id del artículo y una lista de URLs de imágenes.
		public void guardarImagenes(int idArticulo, List<string> imagenes)
		{
			// Se crea y abre la conexión a la base de datos.
			using (SqlConnection conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true"))
			{
				conexion.Open();

				// Elimina todas las imágenes anteriores asociadas al artículo.
				// ExecuteNonQuery ejecuta la consulta SQL y retorna el número de filas afectadas.
				// Se usa para comandos que no devuelven resultados (como DELETE, INSERT, UPDATE).
				var comandoDelete = new SqlCommand("DELETE FROM IMAGENES WHERE IdArticulo = @idArticulo", conexion);
				comandoDelete.Parameters.AddWithValue("@idArticulo", idArticulo);
				comandoDelete.ExecuteNonQuery(); // Aquí se eliminan las imágenes previas.

				// Inserta cada nueva imagen en la tabla IMAGENES.
				foreach (var url in imagenes)
				{
					var comandoInsert = new SqlCommand("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@idArticulo, @url)", conexion);
					comandoInsert.Parameters.AddWithValue("@idArticulo", idArticulo);
					comandoInsert.Parameters.AddWithValue("@url", url);
					comandoInsert.ExecuteNonQuery(); // Aquí se agrega la nueva imagen.
				}
			}
		}
	}
}
