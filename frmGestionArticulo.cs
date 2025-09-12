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

		private Articulo articulo = null;

		// Constructor para agregar 
		public frmGestionArticulo()
		{
			InitializeComponent();
			// Cuando no se le pasa un artículo, creo uno nuevo.
			articulo = new Articulo();
		}

		// Constructor para modificar: recibe el artículo
		public frmGestionArticulo(Articulo articulo)
		{
			InitializeComponent();
			// aca guardo el articulo que recibo
			this.articulo = articulo;
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
				
				
				// Verifico si tengo un artículo para modificar
				if (articulo != null && articulo.Id != 0)
				{
					// Si hay un artículo, cargo sus datos en los controles
					txtCodigo.Text = articulo.Codigo;
					txtNombre.Text = articulo.Nombre;
					txtDescripcion.Text = articulo.Descripcion;
					txtPrecio.Text = articulo.Precio.ToString();

					// Cargo la marca y categoría correctas en los ComboBox
					// Uso los IDs para seleccionar la opción correcta en los ComboBox.
					// Estos ComboBox solo se cargarán si el objeto articulo.Marca no es nulo
					if (articulo.Marca != null)
						cboMarca.SelectedValue = articulo.Marca.Id;
					if (articulo.Categoria != null)
						cboCategoria.SelectedValue = articulo.Categoria.Id;
				}
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
			ArticuloNegocio negocio = new ArticuloNegocio();

			try
			{
				// Asigno lo que escribió el usuario en los campos
				articulo.Codigo = txtCodigo.Text;
				articulo.Nombre = txtNombre.Text;
				articulo.Descripcion = txtDescripcion.Text;

				// Convierto el texto del precio a un número decimal
				articulo.Precio = decimal.Parse(txtPrecio.Text);

				// Tomo el objeto completo que seleccionó el usuario del ComboBox
				articulo.Marca = (Marca)cboMarca.SelectedItem;
				articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

				// Si el ID del artículo es 0, es nuevo Si tiene ID, significa que ya existe entonces lo estoy modificando modificando.
				if (articulo.Id != 0)
				{
					negocio.modificar(articulo);
					MessageBox.Show("Modificado exitosamente");
				}
				else
				{
					negocio.agregar(articulo);
					MessageBox.Show("Agregado exitosamente");
				}

				// Cierro la ventana de gestión
				this.Close();
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
