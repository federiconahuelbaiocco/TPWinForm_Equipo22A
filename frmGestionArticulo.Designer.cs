namespace TPWinForm_equipo_22A
{
	partial class frmGestionArticulo
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
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.lblCodigo = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.lblPrecio = new System.Windows.Forms.Label();
			this.cboMarca = new System.Windows.Forms.ComboBox();
			this.cboCategoria = new System.Windows.Forms.ComboBox();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.btnCancelar = new System.Windows.Forms.Button();
			this.lblUrl = new System.Windows.Forms.Label();
			this.txtUrlImagen = new System.Windows.Forms.TextBox();
			this.pbxGestionImagen = new System.Windows.Forms.PictureBox();
			this.lblCategoria = new System.Windows.Forms.Label();
			this.lblMarca = new System.Windows.Forms.Label();
			this.btnAnteriorImagen = new System.Windows.Forms.Button();
			this.btnSiguienteImagen = new System.Windows.Forms.Button();
			this.btnQuitarImagen = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pbxGestionImagen)).BeginInit();
			this.SuspendLayout();
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(142, 154);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
			this.txtDescripcion.TabIndex = 2;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(142, 66);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 0;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(142, 109);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(100, 20);
			this.txtNombre.TabIndex = 1;
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(142, 198);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.Size = new System.Drawing.Size(100, 20);
			this.txtPrecio.TabIndex = 3;
			// 
			// lblCodigo
			// 
			this.lblCodigo.AutoSize = true;
			this.lblCodigo.Location = new System.Drawing.Point(71, 69);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(40, 13);
			this.lblCodigo.TabIndex = 5;
			this.lblCodigo.Text = "Codigo";
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Location = new System.Drawing.Point(74, 112);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(44, 13);
			this.lblNombre.TabIndex = 6;
			this.lblNombre.Text = "Nombre";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.Location = new System.Drawing.Point(55, 154);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
			this.lblDescripcion.TabIndex = 7;
			this.lblDescripcion.Text = "Descripcion";
			// 
			// lblPrecio
			// 
			this.lblPrecio.AutoSize = true;
			this.lblPrecio.Location = new System.Drawing.Point(74, 198);
			this.lblPrecio.Name = "lblPrecio";
			this.lblPrecio.Size = new System.Drawing.Size(37, 13);
			this.lblPrecio.TabIndex = 8;
			this.lblPrecio.Text = "Precio";
			// 
			// cboMarca
			// 
			this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMarca.FormattingEnabled = true;
			this.cboMarca.Location = new System.Drawing.Point(142, 287);
			this.cboMarca.Name = "cboMarca";
			this.cboMarca.Size = new System.Drawing.Size(121, 21);
			this.cboMarca.TabIndex = 5;
			// 
			// cboCategoria
			// 
			this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCategoria.FormattingEnabled = true;
			this.cboCategoria.Location = new System.Drawing.Point(142, 334);
			this.cboCategoria.Name = "cboCategoria";
			this.cboCategoria.Size = new System.Drawing.Size(121, 21);
			this.cboCategoria.TabIndex = 6;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(62, 396);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 7;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(188, 396);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 8;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// lblUrl
			// 
			this.lblUrl.AutoSize = true;
			this.lblUrl.Location = new System.Drawing.Point(82, 246);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(29, 13);
			this.lblUrl.TabIndex = 13;
			this.lblUrl.Text = "URL";
			// 
			// txtUrlImagen
			// 
			this.txtUrlImagen.Location = new System.Drawing.Point(142, 243);
			this.txtUrlImagen.Name = "txtUrlImagen";
			this.txtUrlImagen.Size = new System.Drawing.Size(100, 20);
			this.txtUrlImagen.TabIndex = 4;
			this.txtUrlImagen.Leave += new System.EventHandler(this.txtUrlImagen_Leave);
			// 
			// pbxGestionImagen
			// 
			this.pbxGestionImagen.Location = new System.Drawing.Point(292, 69);
			this.pbxGestionImagen.MaximumSize = new System.Drawing.Size(360, 300);
			this.pbxGestionImagen.MinimumSize = new System.Drawing.Size(360, 300);
			this.pbxGestionImagen.Name = "pbxGestionImagen";
			this.pbxGestionImagen.Size = new System.Drawing.Size(360, 300);
			this.pbxGestionImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbxGestionImagen.TabIndex = 15;
			this.pbxGestionImagen.TabStop = false;
			// 
			// lblCategoria
			// 
			this.lblCategoria.AutoSize = true;
			this.lblCategoria.Location = new System.Drawing.Point(59, 334);
			this.lblCategoria.Name = "lblCategoria";
			this.lblCategoria.Size = new System.Drawing.Size(52, 13);
			this.lblCategoria.TabIndex = 16;
			this.lblCategoria.Text = "Categoria";
			// 
			// lblMarca
			// 
			this.lblMarca.AutoSize = true;
			this.lblMarca.Location = new System.Drawing.Point(74, 290);
			this.lblMarca.Name = "lblMarca";
			this.lblMarca.Size = new System.Drawing.Size(37, 13);
			this.lblMarca.TabIndex = 17;
			this.lblMarca.Text = "Marca";
			// 
			// btnAnteriorImagen
			// 
			this.btnAnteriorImagen.Location = new System.Drawing.Point(329, 396);
			this.btnAnteriorImagen.Name = "btnAnteriorImagen";
			this.btnAnteriorImagen.Size = new System.Drawing.Size(75, 23);
			this.btnAnteriorImagen.TabIndex = 18;
			this.btnAnteriorImagen.Text = "Anterior";
			this.btnAnteriorImagen.UseVisualStyleBackColor = true;
			this.btnAnteriorImagen.Click += new System.EventHandler(this.btnAnteriorImagen_Click);
			// 
			// btnSiguienteImagen
			// 
			this.btnSiguienteImagen.Location = new System.Drawing.Point(440, 396);
			this.btnSiguienteImagen.Name = "btnSiguienteImagen";
			this.btnSiguienteImagen.Size = new System.Drawing.Size(75, 23);
			this.btnSiguienteImagen.TabIndex = 19;
			this.btnSiguienteImagen.Text = "siguiente";
			this.btnSiguienteImagen.UseVisualStyleBackColor = true;
			this.btnSiguienteImagen.Click += new System.EventHandler(this.btnSiguienteImagen_Click);
			// 
			// btnQuitarImagen
			// 
			this.btnQuitarImagen.AllowDrop = true;
			this.btnQuitarImagen.Location = new System.Drawing.Point(565, 396);
			this.btnQuitarImagen.Name = "btnQuitarImagen";
			this.btnQuitarImagen.Size = new System.Drawing.Size(75, 23);
			this.btnQuitarImagen.TabIndex = 20;
			this.btnQuitarImagen.Text = "Quitar";
			this.btnQuitarImagen.UseVisualStyleBackColor = true;
			this.btnQuitarImagen.Click += new System.EventHandler(this.btnQuitarImagen_Click);
			// 
			// frmGestionArticulo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(684, 461);
			this.Controls.Add(this.btnQuitarImagen);
			this.Controls.Add(this.btnSiguienteImagen);
			this.Controls.Add(this.btnAnteriorImagen);
			this.Controls.Add(this.lblMarca);
			this.Controls.Add(this.lblCategoria);
			this.Controls.Add(this.pbxGestionImagen);
			this.Controls.Add(this.txtUrlImagen);
			this.Controls.Add(this.lblUrl);
			this.Controls.Add(this.btnCancelar);
			this.Controls.Add(this.btnAceptar);
			this.Controls.Add(this.cboCategoria);
			this.Controls.Add(this.cboMarca);
			this.Controls.Add(this.lblPrecio);
			this.Controls.Add(this.lblDescripcion);
			this.Controls.Add(this.lblNombre);
			this.Controls.Add(this.lblCodigo);
			this.Controls.Add(this.txtPrecio);
			this.Controls.Add(this.txtNombre);
			this.Controls.Add(this.txtCodigo);
			this.Controls.Add(this.txtDescripcion);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(700, 500);
			this.MinimumSize = new System.Drawing.Size(700, 500);
			this.Name = "frmGestionArticulo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmGestionArticulo";
			this.Load += new System.EventHandler(this.frmGestionArticulo_Load);
			((System.ComponentModel.ISupportInitialize)(this.pbxGestionImagen)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtDescripcion;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtPrecio;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Label lblPrecio;
		private System.Windows.Forms.ComboBox cboMarca;
		private System.Windows.Forms.ComboBox cboCategoria;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Label lblUrl;
		private System.Windows.Forms.TextBox txtUrlImagen;
		private System.Windows.Forms.PictureBox pbxGestionImagen;
		private System.Windows.Forms.Label lblCategoria;
		private System.Windows.Forms.Label lblMarca;
		private System.Windows.Forms.Button btnAnteriorImagen;
		private System.Windows.Forms.Button btnSiguienteImagen;
		private System.Windows.Forms.Button btnQuitarImagen;
	}
}