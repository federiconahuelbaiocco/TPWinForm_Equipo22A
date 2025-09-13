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

		public frmDetalleArticulo(Articulo articulo)
		{
			InitializeComponent();
			this.articulo = articulo;
		}

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
				cboMarca.DataSource = marcaNegocio.listar().GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				cboMarca.ValueMember = "Id";
				cboMarca.DisplayMember = "Descripcion";

				cboCategoria.DataSource = categoriaNegocio.listar().GroupBy(x => x.Descripcion).Select(g => g.First()).ToList();
				cboCategoria.ValueMember = "Id";
				cboCategoria.DisplayMember = "Descripcion";

				// Mostrar los datos del artículo
				if (articulo != null)
				{
					txtId.Text = articulo.Id.ToString();
					txtCodigo.Text = articulo.Codigo;
					txtNombre.Text = articulo.Nombre;
					txtDescripcion.Text = articulo.Descripcion;
					txtPrecio.Text = articulo.Precio.ToString();

					if (articulo.Marca != null)
						cboMarca.SelectedValue = articulo.Marca.Id;
					if (articulo.Categoria != null)
						cboCategoria.SelectedValue = articulo.Categoria.Id;
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Ocurrió un error al cargar los datos. " + ex.ToString());
			}

		}
	}
}
