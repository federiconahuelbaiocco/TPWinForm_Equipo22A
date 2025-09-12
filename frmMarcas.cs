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
	}
}
