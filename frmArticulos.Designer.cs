namespace TPWinForm_equipo_22A
{
	partial class frmArticulos
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
			this.dgvArticulos = new System.Windows.Forms.DataGridView();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnDetalle = new System.Windows.Forms.Button();
			this.btnAdminMarcas = new System.Windows.Forms.Button();
			this.btnAdminCategorias = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvArticulos
			// 
			this.dgvArticulos.AllowUserToOrderColumns = true;
			this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvArticulos.Location = new System.Drawing.Point(43, 89);
			this.dgvArticulos.MaximumSize = new System.Drawing.Size(745, 465);
			this.dgvArticulos.MinimumSize = new System.Drawing.Size(745, 465);
			this.dgvArticulos.Name = "dgvArticulos";
			this.dgvArticulos.Size = new System.Drawing.Size(745, 465);
			this.dgvArticulos.TabIndex = 0;
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(103, 60);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(75, 23);
			this.btnAgregar.TabIndex = 2;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(184, 60);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(75, 23);
			this.btnModificar.TabIndex = 3;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(265, 60);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 4;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			// 
			// btnDetalle
			// 
			this.btnDetalle.Location = new System.Drawing.Point(346, 60);
			this.btnDetalle.Name = "btnDetalle";
			this.btnDetalle.Size = new System.Drawing.Size(75, 23);
			this.btnDetalle.TabIndex = 5;
			this.btnDetalle.Text = "Detalle";
			this.btnDetalle.UseVisualStyleBackColor = true;
			this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
			// 
			// btnAdminMarcas
			// 
			this.btnAdminMarcas.Location = new System.Drawing.Point(437, 60);
			this.btnAdminMarcas.Name = "btnAdminMarcas";
			this.btnAdminMarcas.Size = new System.Drawing.Size(75, 23);
			this.btnAdminMarcas.TabIndex = 6;
			this.btnAdminMarcas.Text = "Marcas";
			this.btnAdminMarcas.UseVisualStyleBackColor = true;
			this.btnAdminMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
			// 
			// btnAdminCategorias
			// 
			this.btnAdminCategorias.Location = new System.Drawing.Point(557, 60);
			this.btnAdminCategorias.Name = "btnAdminCategorias";
			this.btnAdminCategorias.Size = new System.Drawing.Size(75, 23);
			this.btnAdminCategorias.TabIndex = 7;
			this.btnAdminCategorias.Text = "Categorias";
			this.btnAdminCategorias.UseVisualStyleBackColor = true;
			this.btnAdminCategorias.Click += new System.EventHandler(this.btnCategorias_Click);
			// 
			// frmArticulos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 661);
			this.Controls.Add(this.btnAdminCategorias);
			this.Controls.Add(this.btnAdminMarcas);
			this.Controls.Add(this.btnDetalle);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.dgvArticulos);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(900, 700);
			this.MinimumSize = new System.Drawing.Size(900, 700);
			this.Name = "frmArticulos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmArticulos";
			this.Load += new System.EventHandler(this.frmArticulos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvArticulos;
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnDetalle;
		private System.Windows.Forms.Button btnAdminMarcas;
		private System.Windows.Forms.Button btnAdminCategorias;
	}
}