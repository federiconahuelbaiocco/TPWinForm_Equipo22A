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
			catch (Exception ex)
			{
				throw ex;
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
	}
}
