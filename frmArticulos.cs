using proyectoParaActividad2;
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
		public frmArticulos()
		{
			InitializeComponent();

		}
		


private void frmArticulos_Load(object sender, EventArgs e)
		{
			SQLDatos datos = new SQLDatos();
			dgvArticulos.DataSource = datos.listar();
		}

		private void btnAdminMarcas_Click(object sender, EventArgs e)
		{
			frmMarcas ventanaMarcas = new frmMarcas();
			ventanaMarcas.ShowDialog();
		}

		private void btnAdminCategorias_Click(object sender, EventArgs e)
		{
			frmCategorias ventanaCategorias = new frmCategorias();
			ventanaCategorias.ShowDialog();
		}
	}
}
