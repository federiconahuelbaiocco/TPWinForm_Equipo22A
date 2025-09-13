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
	public partial class frmMarcas : Form
	{
		public frmMarcas()
		{
			InitializeComponent();
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void frmMarcas_Load(object sender, EventArgs e)
		{
			MarcaNegocio negocio = new MarcaNegocio();
			try
			{
				// Obtengo la lista de marcas de la base de datos
				dgvMarcas.DataSource = negocio.listar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			// Abro el formulario de gestión para agregar una nueva marca
			frmGestionMarca gestion = new frmGestionMarca();
			gestion.ShowDialog();
			// Cuando el formulario se cierra, recargo la grilla
			cargarGrilla();
		}

		private void cargarGrilla()
		{
			MarcaNegocio negocio = new MarcaNegocio();
			try
			{
				// Limpio la grilla y la vuelvo a llenar con los datos actualizados
				dgvMarcas.DataSource = null;
				dgvMarcas.DataSource = negocio.listar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			Marca seleccionada;
			if (dgvMarcas.CurrentRow != null)
			{
				// Tomo el objeto completo que está en la fila seleccionada
				seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

				// Creo una nueva ventana, pero le paso el objeto seleccionado
				frmGestionMarca modificar = new frmGestionMarca(seleccionada);
				modificar.ShowDialog();

				// Vuelvo a cargar la grilla para ver los cambios
				cargarGrilla();
			}
			else
			{
				MessageBox.Show("Por favor, seleccione una marca para modificar.");
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			MarcaNegocio negocio = new MarcaNegocio();
			Marca seleccionada;

			try
			{
				// Esto verifica si hay una fila seleccionada en la grilla.
				if (dgvMarcas.CurrentRow != null)
				{
					// Guardo el objeto de la marca que el usuario seleccionó.
					seleccionada = (Marca)dgvMarcas.CurrentRow.DataBoundItem;

					// Muestro un mensaje de alerta para confirmar si el usuario realmente quiere eliminar.
					DialogResult respuesta = MessageBox.Show("¿Seguro que quiere eliminar esta marca?", "Eliminar Marca", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					// Si la respuesta es si procedo a eliminar.
					if (respuesta == DialogResult.Yes)
					{
						// Llamo al método de mi capa de negocio para eliminar la marca por su ID.
						negocio.eliminar(seleccionada.Id);

						// Recargo la grilla para que la marca eliminada ya no aparezca.
						cargarGrilla();
					}
				}
				else
				{
					// Si no seleccionó nada, le muestro un mensaje de error.
					MessageBox.Show("Por favor, seleccione una marca para eliminar.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
