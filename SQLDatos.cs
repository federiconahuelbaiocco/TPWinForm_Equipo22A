using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoParaActividad2
{
	internal class SQLDatos
	{

		public List<Articulos> listar()
		{
			List<Articulos> lista = new List<Articulos>();
			SqlConnection conexion = new SqlConnection();
			SqlCommand comando = new SqlCommand();
			SqlDataReader lector;
			
			try {
				conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_P3_DB; integrated security=true";
				comando.CommandType = System.Data.CommandType.Text;
				comando.CommandText = "SELECT Id, Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio FROM ARTICULOS";
				comando.Connection = conexion;
				conexion.Open();
				lector = comando.ExecuteReader();
				while (lector.Read())
				{
					Articulos aux = new Articulos();
					aux.ID = lector.GetInt32(0);
					aux.Codigo = lector.GetString(1);
					aux.Nombre = lector.GetString(2);
					aux.Descripcion = lector.GetString(3);
					aux.Marca = lector.GetInt32(4);
					aux.Categoria = lector.GetInt32(5);

					if (!lector.IsDBNull(6))
					{
						aux.Precio = lector.GetDecimal(6);
					}
					else
					{
						aux.Precio = 0;
					}

					lista.Add(aux);
				}
				conexion.Close();
				return lista;
			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (conexion.State == System.Data.ConnectionState.Open)
					conexion.Close();
			}

		}
		
	}


}
