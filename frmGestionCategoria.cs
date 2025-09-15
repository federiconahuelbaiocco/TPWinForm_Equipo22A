using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_22A
{
	public partial class frmGestionCategoria : Form
	{
		private Categoria categoria = null;

		// Constructor para agregar
		public frmGestionCategoria()
		{
			InitializeComponent();
			categoria = new Categoria();
		}

		// Constructor para modificar recibiendo el parametro
		public frmGestionCategoria(Categoria categoria)
		{
			InitializeComponent();
			this.categoria = categoria;
		}

		private void frmGestionCategoria_Load(object sender, EventArgs e)
		{
			// Si estoy en modo modificar, cargo la descripción
			if (categoria != null && categoria.Id != 0)
			{
				txtDescripcion.Text = categoria.Descripcion;
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			CategoriaNegocio negocio = new CategoriaNegocio();
			try
			{
				// Asigno la descripción del TextBox a mi objeto categoria obteniendo el text
				categoria.Descripcion = txtDescripcion.Text;

				//verifico si tiene id es para modificar, si no es para agregar
				if (categoria.Id != 0)
				{
					negocio.modificar(categoria);
					MessageBox.Show("Categoría modificada exitosamente.");
				}
				else
				{
					negocio.agregar(categoria);
					MessageBox.Show("Categoría agregada exitosamente.");
				}
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void btnCancelar_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
