using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_equipo_22A
{
	public partial class frmGestionArticulo : Form
	{
		public frmGestionArticulo()
		{
			InitializeComponent();
		}

		private void frmGestionArticulo_Load(object sender, EventArgs e)
		{
			MarcaNegocio marcaNegocio = new MarcaNegocio();
			CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

			try
			{
				// Primero pido la lista completa de marcas a la base de datos y las guardo en una lista 
				List<Marca> listaMarcas = marcaNegocio.listar();
				// luego, uso  LINQ (Language-Integrated Query) para filtrar los repetidos: característica de C# que permite consultar y manipular colecciones de datos
				// (como listas, arrays, bases de datos, etc.) usando una sintaxis similar a SQL, pero integrada en el lenguaje.
				// con GroupBy agrupo las marcas por su descripción .
				// tomo la primera de cada grupo para eliminar los repetidos con select (g.First).
				// se la asigno al ComboBox para que muestre solo una vez cada marca.
				cboMarca.DataSource = listaMarcas.GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();

				// hago lo mismo para las categorías.
				// Así el ComboBox solo muestra una vez cada categoría.
				List<Categoria> listaCategorias = categoriaNegocio.listar();
				cboCategoria.DataSource = listaCategorias.GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				// https://stackoverflow.com/questions/19012986/how-to-get-first-record-in-each-group-using-linq referencia para entender el  LINQ
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			Articulo nuevo = new Articulo();
			ArticuloNegocio negocio = new ArticuloNegocio();

			try
			{
				// Asigno lo que escribió el usuario en los campos con .text
				nuevo.Codigo = txtCodigo.Text;
				nuevo.Nombre = txtNombre.Text;
				nuevo.Descripcion = txtDescripcion.Text;

				// hago la conversin del texto del precio a un número decimal
				nuevo.Precio = decimal.Parse(txtPrecio.Text);

				// Tomo el objeto completo que seleccionó el usuario del ComboBox
				nuevo.Marca = (Marca)cboMarca.SelectedItem;
				nuevo.Categoria = (Categoria)cboCategoria.SelectedItem;

				// Le pido a mi clase ArticuloNegocio que guarde el artículo que creé
				negocio.agregar(nuevo);

				// Cierro la ventana de gestión
			}
			catch (Exception ex)
			{
				// Si algo sale mal, muestro un mensaje de error
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
