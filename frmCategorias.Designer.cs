namespace TPWinForm_equipo_22A
{
	partial class frmCategorias
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
			this.dgvCategorias = new System.Windows.Forms.DataGridView();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnAgregar = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvCategorias
			// 
			this.dgvCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCategorias.Location = new System.Drawing.Point(39, 149);
			this.dgvCategorias.MaximumSize = new System.Drawing.Size(745, 465);
			this.dgvCategorias.MinimumSize = new System.Drawing.Size(745, 465);
			this.dgvCategorias.Name = "dgvCategorias";
			this.dgvCategorias.Size = new System.Drawing.Size(745, 465);
			this.dgvCategorias.TabIndex = 17;
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(564, 76);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 16;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(301, 76);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(75, 23);
			this.btnModificar.TabIndex = 15;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(39, 76);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(75, 23);
			this.btnAgregar.TabIndex = 14;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			// 
			// frmCategorias
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.dgvCategorias);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.MaximumSize = new System.Drawing.Size(900, 700);
			this.MinimumSize = new System.Drawing.Size(900, 700);
			this.Name = "frmCategorias";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmCategorias";
			((System.ComponentModel.ISupportInitialize)(this.dgvCategorias)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvCategorias;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnAgregar;
	}
}