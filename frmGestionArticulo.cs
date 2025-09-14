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

		private Articulo articulo = null; // Variable para guardar el artículo que se está gestionando
		private int indiceImagenActual = 0;
		private Articulo articuloActual = null;

		// Constructor para agregar 
		public frmGestionArticulo()
		{
			InitializeComponent();
			// Cuando no se le pasa un artículo, creo uno nuevo.
			articulo = new Articulo();
			btnAnteriorImagen.Enabled = false;
			btnSiguienteImagen.Enabled = false;
			btnQuitarImagen.Enabled = false;
		}

		// Constructor para modificar: recibe el artículo
		public frmGestionArticulo(Articulo articulo)
		{
			InitializeComponent();
			// aca guardo el articulo que recibo
			this.articulo = articulo;
			btnAnteriorImagen.Enabled = true;
			btnSiguienteImagen.Enabled = true;
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

				// **--- Agregamos estas líneas para configurar el ComboBox ---**
				cboMarca.DataSource = listaMarcas.GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				cboMarca.ValueMember = "Id";
				cboMarca.DisplayMember = "Descripcion";
				// **--- Fin de la corrección ---**


				// hago lo mismo para las categorías.
				// Así el ComboBox solo muestra una vez cada categoría.
				List<Categoria> listaCategorias = categoriaNegocio.listar();

				// **--- Agregamos estas líneas para configurar el ComboBox ---**
				cboCategoria.DataSource = listaCategorias.GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				cboCategoria.ValueMember = "Id";
				cboCategoria.DisplayMember = "Descripcion";

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

			articuloActual = articulo;
			indiceImagenActual = 0;
			MostrarImagenActual();
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
				articulo.Codigo = txtCodigo.Text;
				articulo.Nombre = txtNombre.Text;
				articulo.Descripcion = txtDescripcion.Text;

				// Convierto el texto del precio a un número decimal
				articulo.Precio = decimal.Parse(txtPrecio.Text);

				// Tomo el objeto completo que seleccionó el usuario del ComboBox
				articulo.Marca = (Marca)cboMarca.SelectedItem;
				articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

				// Agregar la imagen del TextBox si no está vacía y no está ya en la lista
				if (!string.IsNullOrEmpty(url))
				{
					if (articulo.Imagenes == null)
						articulo.Imagenes = new List<string>();
					if (!articulo.Imagenes.Contains(url))
						articulo.Imagenes.Add(url);
				}

				if (articulo.Id != 0)
				{
					negocio.modificar(articulo);
					negocio.guardarImagenes(articulo.Id, articulo.Imagenes); // <-- Agrega esta línea
					MessageBox.Show("Modificado exitosamente");
				}
				else
				{
					int nuevoId = negocio.agregar(articulo);
					negocio.guardarImagenes(nuevoId, articulo.Imagenes);
					MessageBox.Show("Agregado exitosamente");
				}

				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void cargarImagen(string url)
		{
			try
			{
				// Intenta cargar la imagen desde la URL en el PictureBox
				pbxGestionImagen.Load(url);
			}
			catch (Exception)
			{
				// Si la URL es inválida, usa una imagen local
				pbxGestionImagen.Load("imagenes/imagenDefecto.jpg");
			}
		}

		private void txtUrlImagen_Leave(object sender, EventArgs e)
		{
			// Carga la imagen solo cuando el usuario sale del TextBox
			cargarImagen(txtUrlImagen.Text);
		}

		private void btnAnteriorImagen_Click(object sender, EventArgs e)
		{
			if (articuloActual != null && articuloActual.Imagenes.Count > 0)
			{
				indiceImagenActual--;
				if (indiceImagenActual < 0)
					indiceImagenActual = articuloActual.Imagenes.Count - 1;
				MostrarImagenActual();
			}
		}

		private void btnSiguienteImagen_Click(object sender, EventArgs e)
		{
			if (articuloActual != null && articuloActual.Imagenes.Count > 0)
			{
				indiceImagenActual++;
				if (indiceImagenActual >= articuloActual.Imagenes.Count)
					indiceImagenActual = 0;
				MostrarImagenActual();
			}
		}

		private void MostrarImagenActual()
		{
			if (articulo == null || articulo.Imagenes == null || articulo.Imagenes.Count == 0)
			{
				pbxGestionImagen.Load("imagenes/imagenDefecto.jpg");
				return;
			}

			try
			{
				pbxGestionImagen.Load(articulo.Imagenes[indiceImagenActual]);
			}
			catch
			{
				pbxGestionImagen.Load("imagenes/imagenDefecto.jpg");
			}
		}

		private void btnAgregarImagen_Click(object sender, EventArgs e)
		{
			string url = txtUrlImagen.Text.Trim();
			if (!string.IsNullOrEmpty(url))
			{
				if (articulo.Imagenes == null)
					articulo.Imagenes = new List<string>();
				articulo.Imagenes.Add(url);
				indiceImagenActual = articulo.Imagenes.Count - 1;
				MostrarImagenActual();
				txtUrlImagen.Clear();
			}
			else
			{
				MessageBox.Show("Ingrese una URL de imagen válida.");
			}
		}

		private void btnQuitarImagen_Click(object sender, EventArgs e)
		{
			if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
			{
				articulo.Imagenes.RemoveAt(indiceImagenActual);
				if (indiceImagenActual >= articulo.Imagenes.Count)
					indiceImagenActual = articulo.Imagenes.Count - 1;
				MostrarImagenActual();
			}
		}
	}
}
