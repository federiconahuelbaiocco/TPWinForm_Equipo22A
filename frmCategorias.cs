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
		}

		private void frmCategorias_Load(object sender, EventArgs e)
		{
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
	}
}
