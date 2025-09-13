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
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnEliminar = new System.Windows.Forms.Button();
			this.btnDetalle = new System.Windows.Forms.Button();
			this.btnAdminMarcas = new System.Windows.Forms.Button();
			this.btnAdminCategorias = new System.Windows.Forms.Button();
			this.btnFiltro = new System.Windows.Forms.Button();
			this.txtFiltro = new System.Windows.Forms.TextBox();
			this.lblFiltro = new System.Windows.Forms.Label();
			this.btnReiniciar = new System.Windows.Forms.Button();
			this.pbxArticulo = new System.Windows.Forms.PictureBox();
			this.btnAnterior = new System.Windows.Forms.Button();
			this.btnSiguiente = new System.Windows.Forms.Button();
			this.dgvArticulos = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
			this.SuspendLayout();
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(70, 39);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(75, 23);
			this.btnAgregar.TabIndex = 2;
			this.btnAgregar.Text = "Agregar";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(209, 39);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(75, 23);
			this.btnModificar.TabIndex = 3;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// btnEliminar
			// 
			this.btnEliminar.Location = new System.Drawing.Point(348, 39);
			this.btnEliminar.Name = "btnEliminar";
			this.btnEliminar.Size = new System.Drawing.Size(75, 23);
			this.btnEliminar.TabIndex = 4;
			this.btnEliminar.Text = "Eliminar";
			this.btnEliminar.UseVisualStyleBackColor = true;
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			// 
			// btnDetalle
			// 
			this.btnDetalle.Location = new System.Drawing.Point(481, 39);
			this.btnDetalle.Name = "btnDetalle";
			this.btnDetalle.Size = new System.Drawing.Size(75, 23);
			this.btnDetalle.TabIndex = 5;
			this.btnDetalle.Text = "Detalle";
			this.btnDetalle.UseVisualStyleBackColor = true;
			this.btnDetalle.Click += new System.EventHandler(this.btnDetalle_Click);
			// 
			// btnAdminMarcas
			// 
			this.btnAdminMarcas.Location = new System.Drawing.Point(606, 39);
			this.btnAdminMarcas.Name = "btnAdminMarcas";
			this.btnAdminMarcas.Size = new System.Drawing.Size(75, 23);
			this.btnAdminMarcas.TabIndex = 6;
			this.btnAdminMarcas.Text = "Marcas";
			this.btnAdminMarcas.UseVisualStyleBackColor = true;
			this.btnAdminMarcas.Click += new System.EventHandler(this.btnMarcas_Click);
			// 
			// btnAdminCategorias
			// 
			this.btnAdminCategorias.Location = new System.Drawing.Point(740, 39);
			this.btnAdminCategorias.Name = "btnAdminCategorias";
			this.btnAdminCategorias.Size = new System.Drawing.Size(75, 23);
			this.btnAdminCategorias.TabIndex = 7;
			this.btnAdminCategorias.Text = "Categorias";
			this.btnAdminCategorias.UseVisualStyleBackColor = true;
			this.btnAdminCategorias.Click += new System.EventHandler(this.btnAdminCategorias_Click);
			// 
			// btnFiltro
			// 
			this.btnFiltro.Location = new System.Drawing.Point(481, 87);
			this.btnFiltro.Name = "btnFiltro";
			this.btnFiltro.Size = new System.Drawing.Size(75, 23);
			this.btnFiltro.TabIndex = 8;
			this.btnFiltro.Text = "Buscar";
			this.btnFiltro.UseVisualStyleBackColor = true;
			this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
			// 
			// txtFiltro
			// 
			this.txtFiltro.Location = new System.Drawing.Point(169, 90);
			this.txtFiltro.Name = "txtFiltro";
			this.txtFiltro.Size = new System.Drawing.Size(254, 20);
			this.txtFiltro.TabIndex = 9;
			// 
			// lblFiltro
			// 
			this.lblFiltro.AutoSize = true;
			this.lblFiltro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblFiltro.Location = new System.Drawing.Point(75, 90);
			this.lblFiltro.Name = "lblFiltro";
			this.lblFiltro.Size = new System.Drawing.Size(49, 20);
			this.lblFiltro.TabIndex = 10;
			this.lblFiltro.Text = "Filtrar";
			// 
			// btnReiniciar
			// 
			this.btnReiniciar.Location = new System.Drawing.Point(606, 86);
			this.btnReiniciar.Name = "btnReiniciar";
			this.btnReiniciar.Size = new System.Drawing.Size(98, 23);
			this.btnReiniciar.TabIndex = 11;
			this.btnReiniciar.Text = "Reiniciar Filtros";
			this.btnReiniciar.UseVisualStyleBackColor = true;
			this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
			// 
			// pbxArticulo
			// 
			this.pbxArticulo.Location = new System.Drawing.Point(481, 160);
			this.pbxArticulo.MaximumSize = new System.Drawing.Size(360, 300);
			this.pbxArticulo.MinimumSize = new System.Drawing.Size(360, 300);
			this.pbxArticulo.Name = "pbxArticulo";
			this.pbxArticulo.Size = new System.Drawing.Size(360, 300);
			this.pbxArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxArticulo.TabIndex = 12;
			this.pbxArticulo.TabStop = false;
			// 
			// btnAnterior
			// 
			this.btnAnterior.Location = new System.Drawing.Point(512, 476);
			this.btnAnterior.Name = "btnAnterior";
			this.btnAnterior.Size = new System.Drawing.Size(75, 23);
			this.btnAnterior.TabIndex = 13;
			this.btnAnterior.Text = "Anterior";
			this.btnAnterior.UseVisualStyleBackColor = true;
			this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
			// 
			// btnSiguiente
			// 
			this.btnSiguiente.Location = new System.Drawing.Point(710, 476);
			this.btnSiguiente.Name = "btnSiguiente";
			this.btnSiguiente.Size = new System.Drawing.Size(75, 23);
			this.btnSiguiente.TabIndex = 14;
			this.btnSiguiente.Text = "Siguente";
			this.btnSiguiente.UseVisualStyleBackColor = true;
			this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
			// 
			// dgvArticulos
			// 
			this.dgvArticulos.AllowUserToOrderColumns = true;
			this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvArticulos.Location = new System.Drawing.Point(79, 160);
			this.dgvArticulos.MaximumSize = new System.Drawing.Size(360, 300);
			this.dgvArticulos.MinimumSize = new System.Drawing.Size(360, 300);
			this.dgvArticulos.Name = "dgvArticulos";
			this.dgvArticulos.Size = new System.Drawing.Size(360, 300);
			this.dgvArticulos.TabIndex = 0;
			this.dgvArticulos.SelectionChanged += new System.EventHandler(this.dgvArticulos_SelectionChanged);
			// 
			// frmArticulos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 511);
			this.Controls.Add(this.btnSiguiente);
			this.Controls.Add(this.btnAnterior);
			this.Controls.Add(this.pbxArticulo);
			this.Controls.Add(this.btnReiniciar);
			this.Controls.Add(this.lblFiltro);
			this.Controls.Add(this.txtFiltro);
			this.Controls.Add(this.btnFiltro);
			this.Controls.Add(this.btnAdminCategorias);
			this.Controls.Add(this.btnAdminMarcas);
			this.Controls.Add(this.btnDetalle);
			this.Controls.Add(this.btnEliminar);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.dgvArticulos);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(900, 550);
			this.MinimumSize = new System.Drawing.Size(900, 550);
			this.Name = "frmArticulos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmArticulos";
			this.Load += new System.EventHandler(this.frmArticulos_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbxArticulo)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnAgregar;
		private System.Windows.Forms.Button btnModificar;
		private System.Windows.Forms.Button btnEliminar;
		private System.Windows.Forms.Button btnDetalle;
		private System.Windows.Forms.Button btnAdminMarcas;
		private System.Windows.Forms.Button btnAdminCategorias;
		private System.Windows.Forms.Button btnFiltro;
		private System.Windows.Forms.TextBox txtFiltro;
		private System.Windows.Forms.Label lblFiltro;
		private System.Windows.Forms.Button btnReiniciar;
		private System.Windows.Forms.PictureBox pbxArticulo;
		private System.Windows.Forms.Button btnAnterior;
		private System.Windows.Forms.Button btnSiguiente;
		private System.Windows.Forms.DataGridView dgvArticulos;
	}
}