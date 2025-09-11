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
	}
}
