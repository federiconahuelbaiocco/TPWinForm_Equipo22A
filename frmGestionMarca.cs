using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace TPWinForm_equipo_22A
{
	public partial class frmGestionMarca : Form
	{
		// Declaro la variable 'marca' a nivel de clase
		private Marca marca = null;

		// Constructor para agregar (sin parámetros)
		public frmGestionMarca()
		{
			InitializeComponent();
			// Inicializo la variable para que no dé error.
			marca = new Marca();
		}

		// Nuevo constructor para modificar.
		// Recibe un objeto Marca para trabajar con él.
		public frmGestionMarca(Marca marca)
		{
			InitializeComponent();
			this.marca = marca;
		}

		private void frmGestionMarca_Load(object sender, EventArgs e)
		{
			// Si estoy modificando, cargo los datos en el campo.
			if (marca != null && marca.Id != 0)
			{
				txtDescripcion.Text = marca.Descripcion;
			}
		}

		private void btnAceptar_Click(object sender, EventArgs e)
		{
			MarcaNegocio negocio = new MarcaNegocio();
			try
			{
				// Asigno la descripción del TextBox a mi objeto 'marca'
				marca.Descripcion = txtDescripcion.Text;

				// Si el ID de la marca es 0, es nueva. Si es diferente, la estoy modificando.
				if (marca.Id != 0)
				{
					negocio.modificar(marca);
					MessageBox.Show("Marca modificada exitosamente.");
				}
				else
				{
					negocio.agregar(marca);
					MessageBox.Show("Marca agregada exitosamente.");
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
			Close();
		}
	}
}
