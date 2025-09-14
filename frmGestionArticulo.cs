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
		private int indiceImagenActual = 0; // Para saber qué foto estamos viendo ahora
		private Articulo articuloActual = null; // Variable para manejar el artículo actual en la gestión de imágenes

		// Constructor para agregar un nuevo artículo
		public frmGestionArticulo()
		{
			InitializeComponent();
			// Cuando arranca sin nada, creamos un objeto vacío.
			articulo = new Articulo();
			// Desactivamos los botones de navegación porque todavía no hay fotos.
			btnAnteriorImagen.Enabled = false;
			btnSiguienteImagen.Enabled = false;
			btnQuitarImagen.Enabled = false;
		}

		// Constructor para modificar, recibe el artículo que queremos cambiar
		public frmGestionArticulo(Articulo articulo)
		{
			InitializeComponent();
			// Con esto guardamos el artículo que recibimos.
			this.articulo = articulo;
			// Activamos los botones porque ya debe tener fotos.
			btnAnteriorImagen.Enabled = true;
			btnSiguienteImagen.Enabled = true;
		}

		// Esto se ejecuta cuando se carga la ventana. Es lo primero que pasa.
		private void frmGestionArticulo_Load(object sender, EventArgs e)
		{
			MarcaNegocio marcaNegocio = new MarcaNegocio();
			CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

			try
			{
				// Acá traemos la lista completa de marcas.
				List<Marca> listaMarcas = marcaNegocio.listar();
				// Creamos una lista nueva para no tener repetidas.
				List<Marca> marcasUnicas = new List<Marca>();
				// Recorremos la lista que trajimos de la base.
				foreach (Marca marca in listaMarcas)
				{
					// Si la marca no está en la nueva lista la agrego (esto es para no repetir).
					if (!marcasUnicas.Any(m => m.Id == marca.Id))
					{
						marcasUnicas.Add(marca);
					}
				}
				// Asignamos la lista sin repetidas al combo.
				cboMarca.DataSource = marcasUnicas;
				cboMarca.ValueMember = "Id"; // Para guardar el ID
				cboMarca.DisplayMember = "Descripcion"; // Para mostrar la descripción


				// Hacemos lo mismo para las categorías.
				List<Categoria> listaCategorias = categoriaNegocio.listar();
				List<Categoria> categoriasUnicas = new List<Categoria>();
				foreach (Categoria categoria in listaCategorias)
				{
					if (!categoriasUnicas.Any(c => c.Id == categoria.Id))
					{
						categoriasUnicas.Add(categoria);
					}
				}
				cboCategoria.DataSource = categoriasUnicas;
				cboCategoria.ValueMember = "Id";
				cboCategoria.DisplayMember = "Descripcion";

				// Si el artículo ya tiene ID, significa que es para modificar.
				if (articulo != null && articulo.Id != 0)
				{
					// Le pasamos la info a los campos de texto.
					txtCodigo.Text = articulo.Codigo;
					txtNombre.Text = articulo.Nombre;
					txtDescripcion.Text = articulo.Descripcion;
					txtPrecio.Text = articulo.Precio.ToString();

					// Y seteamos la marca y categoría que le corresponden.
					if (articulo.Marca != null)
						cboMarca.SelectedValue = articulo.Marca.Id;
					if (articulo.Categoria != null)
						cboCategoria.SelectedValue = articulo.Categoria.Id;
				}
			}
			catch (Exception ex)
			{
				// Por si algo falla, que muestre el error y no explote.
				MessageBox.Show(ex.ToString());
			}

			articuloActual = articulo;
			indiceImagenActual = 0;
			MostrarImagenActual();
		}

		// Este botón es para no guardar nada y salir de la ventana.
		private void btnCancelar_Click(object sender, EventArgs e)
		{
			Close();
		}

		// El botón de guardar. Acá validamos y guardamos todo.
		private void btnAceptar_Click(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();

			// VALIDACIONES
			// Esto es para que no queden campos vacíos.
			if (string.IsNullOrWhiteSpace(txtCodigo.Text))
			{
				MessageBox.Show("El código es obligatorio.");
				return;
			}
			// ... y lo mismo para los demás campos.
			if (string.IsNullOrWhiteSpace(txtNombre.Text))
			{
				MessageBox.Show("El nombre es obligatorio.");
				return;
			}
			if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
			{
				MessageBox.Show("La descripción es obligatoria.");
				return;
			}
			if (cboMarca.SelectedItem == null)
			{
				MessageBox.Show("Debe seleccionar una marca.");
				return;
			}
			if (cboCategoria.SelectedItem == null)
			{
				MessageBox.Show("Debe seleccionar una categoría.");
				return;
			}
			if (string.IsNullOrWhiteSpace(txtPrecio.Text) || !decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
			{
				MessageBox.Show("El precio debe ser un número positivo.");
				return;
			}
			// Y esta es para que la URL de la imagen sea válida.
			string url = txtUrlImagen.Text.Trim();
			if (!string.IsNullOrEmpty(url) && !(url.StartsWith("http://") || url.StartsWith("https://")))
			{
				MessageBox.Show("La URL de la imagen debe comenzar con http:// o https://");
				return;
			}

			try
			{
				// Asignamos lo que hay en los campos a las propiedades del objeto.
				articulo.Codigo = txtCodigo.Text;
				articulo.Nombre = txtNombre.Text;
				articulo.Descripcion = txtDescripcion.Text;
				articulo.Precio = precio;
				// Las marcas y categorías las sacamos del combo, ya vienen con el objeto.
				articulo.Marca = (Marca)cboMarca.SelectedItem;
				articulo.Categoria = (Categoria)cboCategoria.SelectedItem;

				// Chequeamos si la URL no está vacía y si no la agregamos dos veces.
				if (!string.IsNullOrEmpty(url))
				{
					if (articulo.Imagenes == null)
						articulo.Imagenes = new List<string>();
					if (!articulo.Imagenes.Contains(url))
						articulo.Imagenes.Add(url);
				}

				// Si el ID no es cero, es un artículo existente para modificar.
				if (articulo.Id != 0)
				{
					negocio.modificar(articulo);
					negocio.guardarImagenes(articulo.Id, articulo.Imagenes);
					MessageBox.Show("Modificado exitosamente");
				}
				// Si el ID es cero, es un artículo nuevo para agregar.
				else
				{
					int nuevoId = negocio.agregar(articulo);
					negocio.guardarImagenes(nuevoId, articulo.Imagenes);
					MessageBox.Show("Agregado exitosamente");
				}

				// Y cerramos la ventana al terminar.
				this.Close();
			}
			catch (Exception ex)
			{
				// Por si explota algo al guardar, que nos avise.
				MessageBox.Show(ex.ToString());
			}
		}

		// Esto es para cerrar la ventana y volver a la anterior.
		private void btnVolver_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		// Método que carga una foto en el PictureBox.
		private void cargarImagen(string url)
		{
			try
			{
				// Intentamos cargar la foto de la URL.
				pbxGestionImagen.Load(url);
			}
			catch (Exception)
			{
				// Si no se pudo, ponemos una imagen local por si acaso.
				pbxGestionImagen.Load("imagenes/imagenDefecto.jpg");
			}
		}

		// Cuando salís del campo de URL, intentamos cargar la foto para verla en vivo.
		private void txtUrlImagen_Leave(object sender, EventArgs e)
		{
			// Carga la imagen solo cuando el usuario sale del TextBox
			cargarImagen(txtUrlImagen.Text);
		}

		// Botón para ir a la foto anterior.
		private void btnAnteriorImagen_Click(object sender, EventArgs e)
		{
			// Si tenemos fotos, ajustamos el índice.
			if (articuloActual != null && articuloActual.Imagenes.Count > 0)
			{
				indiceImagenActual--;
				// Si el índice es negativo, volvemos a la última foto de la lista.
				if (indiceImagenActual < 0)
					indiceImagenActual = articuloActual.Imagenes.Count - 1;
				// Y la mostramos.
				MostrarImagenActual();
			}
		}

		// Botón para ir a la foto siguiente.
		private void btnSiguienteImagen_Click(object sender, EventArgs e)
		{
			// Si tenemos fotos, ajustamos el índice.
			if (articuloActual != null && articuloActual.Imagenes.Count > 0)
			{
				indiceImagenActual++;
				// Si el índice se pasa de largo, volvemos a la primera.
				if (indiceImagenActual >= articuloActual.Imagenes.Count)
					indiceImagenActual = 0;
				// Y la mostramos.
				MostrarImagenActual();
			}
		}

		// Muestra la foto que le corresponde al índice actual.
		private void MostrarImagenActual()
		{
			// Chequeamos si hay fotos, si no, ponemos la por defecto.
			if (articulo == null || articulo.Imagenes == null || articulo.Imagenes.Count == 0)
			{
				pbxGestionImagen.Load("imagenes/imagenDefecto.jpg");
				return;
			}

			try
			{
				// Intentamos cargar la foto de la lista.
				pbxGestionImagen.Load(articulo.Imagenes[indiceImagenActual]);
			}
			catch
			{
				// Si hay algún problema, ponemos la por defecto.
				pbxGestionImagen.Load("imagenes/imagenDefecto.jpg");
			}
		}

		// Botón para agregar una nueva URL a la lista de fotos.
		private void btnAgregarImagen_Click(object sender, EventArgs e)
		{
			string url = txtUrlImagen.Text.Trim();
			if (!string.IsNullOrEmpty(url))
			{
				// Hacemos una validación rápida para ver si es una URL real.
				if (!(url.StartsWith("http://") || url.StartsWith("https://")))
				{
					MessageBox.Show("La URL de la imagen debe comenzar con http:// o https://");
					return;
				}
				if (articulo.Imagenes == null)
					articulo.Imagenes = new List<string>();
				// No queremos fotos repetidas.
				if (articulo.Imagenes.Contains(url))
				{
					MessageBox.Show("La imagen ya fue agregada.");
					return;
				}
				// Y la agregamos a la lista del objeto.
				articulo.Imagenes.Add(url);
				// Nos movemos a la última foto que agregamos para verla.
				indiceImagenActual = articulo.Imagenes.Count - 1;
				MostrarImagenActual();
				// Limpiamos el campo para que puedas agregar otra.
				txtUrlImagen.Clear();
			}
			else
			{
				MessageBox.Show("Ingrese una URL de imagen válida.");
			}
		}

		// Botón para quitar la foto actual.
		private void btnQuitarImagen_Click(object sender, EventArgs e)
		{
			// Chequeamos que la lista tenga fotos para no romper nada.
			if (articulo.Imagenes != null && articulo.Imagenes.Count > 0)
			{
				// Removemos la foto que estamos viendo ahora.
				articulo.Imagenes.RemoveAt(indiceImagenActual);

				// Ajustamos el índice por si se borró la última foto de la lista.
				if (indiceImagenActual >= articulo.Imagenes.Count)
					indiceImagenActual = articulo.Imagenes.Count - 1;

				// Y mostramos la foto que toca ahora.
				MostrarImagenActual();
			}
		}
	}
}
