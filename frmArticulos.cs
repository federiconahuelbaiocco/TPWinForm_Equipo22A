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
				listaArticulos = negocio.Listar();
				dgvArticulos.DataSource = listaArticulos;

				//aca con columns accedo a las columnas de la grilla y le digo que no me muestre las que quiero ocultar con visible = false
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

		
	}
}
