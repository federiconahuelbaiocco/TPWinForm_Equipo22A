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
	public partial class frmArticulos : Form
	{
		private List<Articulo> listaArticulos;
		private int indiceImagenActual = 0;
		private Articulo articuloActual = null;
		public frmArticulos()
		{
			InitializeComponent();
		}



		private void frmArticulos_Load(object sender, EventArgs e)
		{
			cargarGrilla();
		}

		private void cargarGrilla()
		{
			ArticuloNegocio negocio = new ArticuloNegocio();
			try
			{
				// Guardamos la lista en la variable de clase antes de asignarla a la grilla
				listaArticulos = negocio.Listar();
				dgvArticulos.DataSource = listaArticulos;

				// Ocultar las columnas
				dgvArticulos.Columns["Id"].Visible = false;
				dgvArticulos.Columns["Descripcion"].Visible = false;
				dgvArticulos.Columns["Marca"].Visible = false;
				dgvArticulos.Columns["Categoria"].Visible = false;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			frmGestionArticulo ventana = new frmGestionArticulo();
			ventana.ShowDialog();
			// Cuando la ventana de gestion articulo se cierra, recargo la grilla para ver el nuevo artículo
			cargarGrilla();
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			// Declaro una variable local para el articulo seleccionado
			Articulo seleccionado;

			// Verifico si hay una fila seleccionada en la grilla
			if (dgvArticulos.CurrentRow != null)
			{
				// Tomo el objeto completo que está en la fila seleccionada
				seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

				// Creo una nueva ventana, pero esta vez le paso el objeto seleccionado
				frmGestionArticulo modificar = new frmGestionArticulo(seleccionado);
				modificar.ShowDialog();

				// Vuelvo a cargar la grilla para ver los cambios
				cargarGrilla();
			}
			else
			{
				// Si el usuario no seleccionó nada, muestro un mensaje
				MessageBox.Show("Por favor, seleccione un artículo para modificar.");
			}
		}

		private void btnDetalle_Click(object sender, EventArgs e)
		{
			// Declaro una variable local para el articulo seleccionado
			Articulo seleccionado;
			// Verifico si hay una fila seleccionada en la grilla.
			if (dgvArticulos.CurrentRow != null)
			{
				// Tomo el objeto completo que está en la fila seleccionada
				seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

				frmDetalleArticulo detalle = new frmDetalleArticulo(seleccionado);
				detalle.ShowDialog();

				cargarGrilla();
			}
			else
			{
				MessageBox.Show("Por favor, seleccione un artículo para ver los detalles.");
			}
		}


		private void btnMarcas_Click(object sender, EventArgs e)
		{
			frmMarcas ventana = new frmMarcas();
			ventana.ShowDialog();
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			ArticuloNegocio negocio = new ArticuloNegocio();
			Articulo seleccionado;

			try
			{
				// Verifico que haya una fila seleccionada
				if (dgvArticulos.CurrentRow != null)
				{
					// Tomo el objeto completo de la fila seleccionada
					seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

					// Muestro un mensaje de confirmación al usuario
					DialogResult respuesta = MessageBox.Show("¿Seguro que quiere eliminar este artículo?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					// Si el usuario confirma, lo elimino
					if (respuesta == DialogResult.Yes)
					{
						negocio.eliminar(seleccionado.Id);

						// Recargo la grilla para que ya no aparezca
						cargarGrilla();
					}
				}
				else
				{
					MessageBox.Show("Por favor, seleccione un artículo para eliminar.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnAdminCategorias_Click(object sender, EventArgs e)
		{
			frmCategorias ventana = new frmCategorias();
			ventana.ShowDialog();
		}

		private void btnFiltro_Click(object sender, EventArgs e)
		{
			List<Articulo> listaFiltrada;
			string filtro = txtFiltro.Text.ToUpper();

			if (filtro != "")
			{
				listaFiltrada = listaArticulos.FindAll(
					x => x.Nombre.ToUpper().Contains(filtro) || // condición para el Nombre
						 x.Codigo.ToUpper().Contains(filtro) || // condición para el Código	
						 (x.Marca != null && x.Marca.Descripcion.ToUpper().Contains(filtro)) || // condición para la Marca
						 (x.Categoria != null && x.Categoria.Descripcion.ToUpper().Contains(filtro)) // condición para la Categoría
				);
			}
			else
			{
				listaFiltrada = listaArticulos; // Si el filtro está vacío, muestra toda la lista
			}

			// Asigna la lista filtrada al DataSource de la grilla
			dgvArticulos.DataSource = listaFiltrada;
		}

		private void btnReiniciar_Click(object sender, EventArgs e)
		{
			// Limpio el filtro con txtFiltro.Clear()
			txtFiltro.Clear();

			// Recargo la grilla con todos los datos
			cargarGrilla();
		}

		private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvArticulos.CurrentRow != null)
			{
				articuloActual = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
				indiceImagenActual = 0;
				MostrarImagenActual();
			}
		}

		private void MostrarImagenActual()
		{
			if (articuloActual == null || articuloActual.Imagenes == null || articuloActual.Imagenes.Count == 0)
			{
				pbxArticulo.Load("imagenes/imagenDefecto.jpg");
				return;
			}

			try
			{
				pbxArticulo.Load(articuloActual.Imagenes[indiceImagenActual]);
			}
			catch
			{
				pbxArticulo.Load("imagenes/imagenDefecto.jpg");
			}
		}

		private void btnAnterior_Click(object sender, EventArgs e)
		{
			if (articuloActual != null && articuloActual.Imagenes.Count > 0)
			{
				indiceImagenActual--;
				if (indiceImagenActual < 0)
					indiceImagenActual = articuloActual.Imagenes.Count - 1;
				MostrarImagenActual();
			}
		}

		private void btnSiguiente_Click(object sender, EventArgs e)
		{
			if (articuloActual != null && articuloActual.Imagenes.Count > 0)
			{
				indiceImagenActual++;
				if (indiceImagenActual >= articuloActual.Imagenes.Count)
					indiceImagenActual = 0;
				MostrarImagenActual();
			}
		}
	}
}
