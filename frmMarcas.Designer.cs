namespace TPWinForm_equipo_22A
{
	partial class frmMarcas
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.dgvMarcas = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(56, 63);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(75, 23);
			this.btnAgregar.TabIndex = 10;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(242, 63);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(75, 23);
			this.btnModificar.TabIndex = 11;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(424, 63);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 12;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			// 
			// dgvMarcas
			// 
			this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvMarcas.Location = new System.Drawing.Point(56, 116);
			this.dgvMarcas.MaximumSize = new System.Drawing.Size(745, 465);
			this.dgvMarcas.MinimumSize = new System.Drawing.Size(745, 465);
			this.dgvMarcas.Name = "dgvMarcas";
			this.dgvMarcas.Size = new System.Drawing.Size(745, 465);
			this.dgvMarcas.TabIndex = 13;
			// 
			// frmMarcas
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.dgvMarcas);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.MaximumSize = new System.Drawing.Size(900, 700);
			this.MinimumSize = new System.Drawing.Size(900, 700);
			this.Name = "frmMarcas";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmMarcas";
			((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.DataGridView dgvMarcas;
	}
}