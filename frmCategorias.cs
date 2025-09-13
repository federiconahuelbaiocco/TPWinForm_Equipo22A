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
	public partial class frmCategorias : Form
	{
		public frmCategorias()
		{
			InitializeComponent();
			cargarGrilla();
		}

		private void frmCategorias_Load(object sender, EventArgs e)
		{
		cargarGrilla();
		CategoriaNegocio negocio = new CategoriaNegocio();
			try
			{
				// Obtengo la lista de categorías de la base de datos
				dgvCategorias.DataSource = negocio.listar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnVolver_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			// Creo una nueva instancia del formulario de gestión de categorías
			frmGestionCategoria gestion = new frmGestionCategoria();

			// Muestro el formulario de forma modal para que no se pueda interactuar con otros formularios hasta cerrar el actual
			gestion.ShowDialog();

			// Cuando el formulario se cierra, recargo la grilla para que se vea la nueva categoría
			cargarGrilla();
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{
			// Declaro una variable para guardar la categoría seleccionada
			Categoria seleccionada;

			// Verifico si hay una fila seleccionada en la grilla
			if (dgvCategorias.CurrentRow != null)
			{
				// Tomo el objeto completo de la fila
				seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

				// Abro el formulario de gestión y le paso la categoría para modificar
				frmGestionCategoria modificar = new frmGestionCategoria(seleccionada);
				modificar.ShowDialog();

				// Recargo la grilla para ver los cambios
				cargarGrilla();
			}
			else
			{
				MessageBox.Show("Por favor, seleccione una categoría para modificar.");
			}
		}

		private void btnEliminar_Click(object sender, EventArgs e)
		{
			CategoriaNegocio negocio = new CategoriaNegocio();
			Categoria seleccionada;

			try
			{
				// Verifico si hay una fila seleccionada
				if (dgvCategorias.CurrentRow != null)
				{
					// Tomo el objeto de la categoría seleccionada
					seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

					// Le pido al usuario que confirme la eliminación
					DialogResult respuesta = MessageBox.Show("¿Seguro que quiere eliminar esta categoría?", "Eliminar Categoría", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

					// Si la respuesta es "Sí", procedo a eliminar
					if (respuesta == DialogResult.Yes)
					{
						negocio.eliminar(seleccionada.Id);

						// Recargo la grilla para que el cambio se refleje
						cargarGrilla();
					}
				}
				else
				{
					MessageBox.Show("Por favor, seleccione una categoría para eliminar.");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void cargarGrilla()
		{
			CategoriaNegocio negocio = new CategoriaNegocio();
			try
			{
				// Obtengo la lista de categorías y la asigno a la grilla
				dgvCategorias.DataSource = negocio.listar();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		
	}
}
