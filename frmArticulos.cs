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

		}

		private void btnAgregar_Click(object sender, EventArgs e)
		{
			frmGestionArticulo ventana = new frmGestionArticulo();
			ventana.ShowDialog();
		}

		private void btnModificar_Click(object sender, EventArgs e)
		{

		}

		private void btnDetalle_Click(object sender, EventArgs e)
		{
			frmDetalleArticulo ventana = new frmDetalleArticulo();
			ventana.ShowDialog();
		}

		private void btnCategorias_Click(object sender, EventArgs e)
		{
			frmCategorias ventana = new frmCategorias();
			ventana.ShowDialog();
		}

		private void btnMarcas_Click(object sender, EventArgs e)
		{
			frmMarcas ventana = new frmMarcas();
			ventana.ShowDialog();
		}
	}
}
