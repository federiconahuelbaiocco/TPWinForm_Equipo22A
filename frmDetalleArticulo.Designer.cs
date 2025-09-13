namespace TPWinForm_equipo_22A
{
	partial class frmDetalleArticulo
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
			this.lblPrecio = new System.Windows.Forms.Label();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblCodigo = new System.Windows.Forms.Label();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.btnVolver = new System.Windows.Forms.Button();
			this.lblMarca = new System.Windows.Forms.Label();
			this.lblCategoria = new System.Windows.Forms.Label();
			this.lblId = new System.Windows.Forms.Label();
			this.txtId = new System.Windows.Forms.TextBox();
			this.cboMarca = new System.Windows.Forms.ComboBox();
			this.cboCategoria = new System.Windows.Forms.ComboBox();
			this.btnSiguienteImagen = new System.Windows.Forms.Button();
			this.btnAnteriorImagen = new System.Windows.Forms.Button();
			this.pbxDetalleImagen = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pbxDetalleImagen)).BeginInit();
			this.SuspendLayout();
			// 
			// lblPrecio
			// 
			this.lblPrecio.AutoSize = true;
			this.lblPrecio.Location = new System.Drawing.Point(77, 238);
			this.lblPrecio.Name = "lblPrecio";
			this.lblPrecio.Size = new System.Drawing.Size(37, 13);
			this.lblPrecio.TabIndex = 20;
			this.lblPrecio.Text = "Precio";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.Location = new System.Drawing.Point(47, 188);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
			this.lblDescripcion.TabIndex = 19;
			this.lblDescripcion.Text = "Descripcion";
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Location = new System.Drawing.Point(70, 148);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(44, 13);
			this.lblNombre.TabIndex = 18;
			this.lblNombre.Text = "Nombre";
			// 
			// lblCodigo
			// 
			this.lblCodigo.AutoSize = true;
			this.lblCodigo.Location = new System.Drawing.Point(70, 106);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(40, 13);
			this.lblCodigo.TabIndex = 17;
			this.lblCodigo.Text = "Codigo";
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(149, 231);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.ReadOnly = true;
			this.txtPrecio.Size = new System.Drawing.Size(100, 20);
			this.txtPrecio.TabIndex = 16;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(149, 141);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.ReadOnly = true;
			this.txtNombre.Size = new System.Drawing.Size(100, 20);
			this.txtNombre.TabIndex = 15;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(149, 99);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.ReadOnly = true;
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 14;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(149, 188);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ReadOnly = true;
			this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
			this.txtDescripcion.TabIndex = 13;
			// 
			// btnVolver
			// 
			this.btnVolver.Location = new System.Drawing.Point(149, 387);
			this.btnVolver.Name = "btnVolver";
			this.btnVolver.Size = new System.Drawing.Size(75, 23);
			this.btnVolver.TabIndex = 23;
			this.btnVolver.Text = "Volver";
			this.btnVolver.UseVisualStyleBackColor = true;
			this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
			// 
			// lblMarca
			// 
			this.lblMarca.AutoSize = true;
			this.lblMarca.Location = new System.Drawing.Point(77, 291);
			this.lblMarca.Name = "lblMarca";
			this.lblMarca.Size = new System.Drawing.Size(37, 13);
			this.lblMarca.TabIndex = 26;
			this.lblMarca.Text = "Marca";
			// 
			// lblCategoria
			// 
			this.lblCategoria.AutoSize = true;
			this.lblCategoria.Location = new System.Drawing.Point(58, 338);
			this.lblCategoria.Name = "lblCategoria";
			this.lblCategoria.Size = new System.Drawing.Size(52, 13);
			this.lblCategoria.TabIndex = 27;
			this.lblCategoria.Text = "Categoria";
			// 
			// lblId
			// 
			this.lblId.AutoSize = true;
			this.lblId.Location = new System.Drawing.Point(92, 64);
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(18, 13);
			this.lblId.TabIndex = 28;
			this.lblId.Text = "ID";
			// 
			// txtId
			// 
			this.txtId.Location = new System.Drawing.Point(149, 61);
			this.txtId.Name = "txtId";
			this.txtId.ReadOnly = true;
			this.txtId.Size = new System.Drawing.Size(100, 20);
			this.txtId.TabIndex = 29;
			// 
			// cboMarca
			// 
			this.cboMarca.Enabled = false;
			this.cboMarca.FormattingEnabled = true;
			this.cboMarca.Location = new System.Drawing.Point(149, 330);
			this.cboMarca.Name = "cboMarca";
			this.cboMarca.Size = new System.Drawing.Size(121, 21);
			this.cboMarca.TabIndex = 30;
			// 
			// cboCategoria
			// 
			this.cboCategoria.Enabled = false;
			this.cboCategoria.FormattingEnabled = true;
			this.cboCategoria.Location = new System.Drawing.Point(149, 283);
			this.cboCategoria.Name = "cboCategoria";
			this.cboCategoria.Size = new System.Drawing.Size(121, 21);
			this.cboCategoria.TabIndex = 31;
			// 
			// btnSiguienteImagen
			// 
			this.btnSiguienteImagen.Location = new System.Drawing.Point(594, 387);
			this.btnSiguienteImagen.Name = "btnSiguienteImagen";
			this.btnSiguienteImagen.Size = new System.Drawing.Size(75, 23);
			this.btnSiguienteImagen.TabIndex = 34;
			this.btnSiguienteImagen.Text = "Siguente";
			this.btnSiguienteImagen.UseVisualStyleBackColor = true;
			this.btnSiguienteImagen.Click += new System.EventHandler(this.btnSiguienteImagen_Click);
			// 
			// btnAnteriorImagen
			// 
			this.btnAnteriorImagen.Location = new System.Drawing.Point(411, 387);
			this.btnAnteriorImagen.Name = "btnAnteriorImagen";
			this.btnAnteriorImagen.Size = new System.Drawing.Size(75, 23);
			this.btnAnteriorImagen.TabIndex = 33;
			this.btnAnteriorImagen.Text = "Anterior";
			this.btnAnteriorImagen.UseVisualStyleBackColor = true;
			this.btnAnteriorImagen.Click += new System.EventHandler(this.btnAnteriorImagen_Click);
			// 
			// pbxDetalleImagen
			// 
			this.pbxDetalleImagen.Location = new System.Drawing.Point(370, 61);
			this.pbxDetalleImagen.MaximumSize = new System.Drawing.Size(360, 300);
			this.pbxDetalleImagen.MinimumSize = new System.Drawing.Size(360, 300);
			this.pbxDetalleImagen.Name = "pbxDetalleImagen";
			this.pbxDetalleImagen.Size = new System.Drawing.Size(360, 300);
			this.pbxDetalleImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxDetalleImagen.TabIndex = 32;
			this.pbxDetalleImagen.TabStop = false;
			// 
			// frmDetalleArticulo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.btnSiguienteImagen);
			this.Controls.Add(this.btnAnteriorImagen);
			this.Controls.Add(this.pbxDetalleImagen);
			this.Controls.Add(this.cboCategoria);
			this.Controls.Add(this.cboMarca);
			this.Controls.Add(this.txtId);
			this.Controls.Add(this.lblId);
			this.Controls.Add(this.lblCategoria);
			this.Controls.Add(this.lblMarca);
			this.Controls.Add(this.btnVolver);
			this.Controls.Add(this.lblPrecio);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.lblNombre);
			this.Controls.Add(this.lblCodigo);
			this.Controls.Add(this.txtPrecio);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.txtDescripcion);
			this.Name = "frmDetalleArticulo";
			this.Text = "frmDetallesArticulo";
			this.Load += new System.EventHandler(this.frmDetalleArticulo_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.pbxDetalleImagen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblPrecio;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.TextBox txtPrecio;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.Button btnVolver;
		private System.Windows.Forms.Label lblMarca;
		private System.Windows.Forms.Label lblCategoria;
		private System.Windows.Forms.Label lblId;
		private System.Windows.Forms.TextBox txtId;
		private System.Windows.Forms.ComboBox cboMarca;
		private System.Windows.Forms.ComboBox cboCategoria;
		private System.Windows.Forms.Button btnSiguienteImagen;
		private System.Windows.Forms.Button btnAnteriorImagen;
		private System.Windows.Forms.PictureBox pbxDetalleImagen;
	}
}