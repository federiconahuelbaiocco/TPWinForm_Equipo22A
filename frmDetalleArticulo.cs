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
	public partial class frmDetalleArticulo : Form
	{
		private Articulo articulo = null;
		private int indiceImagenActual = 0;

		// Constructor: acá recibimos el articulo que queremos ver en detalle
		public frmDetalleArticulo(Articulo articulo)
		{
			InitializeComponent();
			this.articulo = articulo;
		}

		// Botón para volver al listado, lo normal, cerrar la ventana y listo.
		private void btnVolver_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmDetalleArticulo_Load_1(object sender, EventArgs e)
		{
			MarcaNegocio marcaNegocio = new MarcaNegocio();
			CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

			try
			{
				// Cargar marcas y categorías en los ComboBox (solo para mostrar)
				// Hacemos el mismo truco con LINQ que ya conoces para no repetir marcas en la lista,
				// aunque en esta ventana no se pueden cambiar, queda más pro.
				cboMarca.DataSource = marcaNegocio.listar().GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				cboMarca.ValueMember = "Id";
				cboMarca.DisplayMember = "Descripcion";

				// Lo mismo para las categorías, para que se vean bien sin repetir.
				cboCategoria.DataSource = categoriaNegocio.listar().GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				cboCategoria.ValueMember = "Id";
				cboCategoria.DisplayMember = "Descripcion";

				// Mostrar los datos del artículo
				// Chequeamos si el articulo no es nulo y lo cargamos en los campos de texto
				if (articulo != null)
				{
					txtId.Text = articulo.Id.ToString();
					txtCodigo.Text = articulo.Codigo;
					txtNombre.Text = articulo.Nombre;
					txtDescripcion.Text = articulo.Descripcion;
					txtPrecio.Text = articulo.Precio.ToString();

					// Seteamos la marca y categoría correctas en los ComboBox para que coincidan con el artículo
					if (articulo.Marca != null)
						cboMarca.SelectedValue = articulo.Marca.Id;
					if (articulo.Categoria != null)
						cboCategoria.SelectedValue = articulo.Categoria.Id;
				}

			}
			catch (Exception ex)
			{
				// Si algo se rompe al cargar, mostramos un error para que no se caiga la app.
				MessageBox.Show("Ocurrió un error al cargar los datos. " + ex.ToString());
			}

			// Arrancamos el carrusel de imágenes desde la primera foto
			indiceImagenActual = 0;
			MostrarImagenActual();
		}

		// Este método es el que se encarga de mostrar la imagen que toca
		private void MostrarImagenActual()
		{
			// Si el articulo o la lista de imágenes está vacía, ponemos la imagen por defecto
			if (articulo == null || articulo.Imagenes == null || articulo.Imagenes.Count == 0)
			{
				pbxDetalleImagen.Load("imagenes/imagenDefecto.jpg");
				return;
			}

			try
			{
				// Intentamos cargar la imagen desde la URL de la lista
				pbxDetalleImagen.Load(articulo.Imagenes[indiceImagenActual]);
			}
			catch
			{
				// Si la URL falla (está caída o lo que sea), usamos la imagen por defecto como respaldo
				pbxDetalleImagen.Load("imagenes/imagenDefecto.jpg");
			}
		}

		// Botón para ir a la imagen anterior
		private void btnAnteriorImagen_Click(object sender, EventArgs e)
		{
			// Si hay imágenes, ajustamos el índice
			if (articulo != null && articulo.Imagenes.Count > 0)
			{
				indiceImagenActual--;
				// Si nos pasamos, volvemos al final de la lista.
				if (indiceImagenActual < 0)
					indiceImagenActual = articulo.Imagenes.Count - 1;
				// Y mostramos la imagen que corresponde ahora
				MostrarImagenActual();
			}
		}

		// Botón para ir a la imagen siguiente
		private void btnSiguienteImagen_Click(object sender, EventArgs e)
		{
			// Si hay imágenes, ajustamos el índice
			if (articulo != null && articulo.Imagenes.Count > 0)
			{
				indiceImagenActual++;
				// Si nos pasamos, volvemos a la primera imagen.
				if (indiceImagenActual >= articulo.Imagenes.Count)
					indiceImagenActual = 0;
				// Y mostramos la imagen que toca
				MostrarImagenActual();
			}
		}
	}
}
