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
			this.SuspendLayout();
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(178, 192);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
			this.txtDescripcion.TabIndex = 0;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(178, 102);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 1;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(178, 152);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.Size = new System.Drawing.Size(100, 20);
			this.txtNombre.TabIndex = 3;
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(178, 238);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.Size = new System.Drawing.Size(100, 20);
			this.txtPrecio.TabIndex = 4;
			// 
			// lblCodigo
			// 
			this.lblCodigo.AutoSize = true;
			this.lblCodigo.Location = new System.Drawing.Point(126, 109);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(40, 13);
			this.lblCodigo.TabIndex = 5;
			this.lblCodigo.Text = "Codigo";
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Location = new System.Drawing.Point(122, 159);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(44, 13);
			this.lblNombre.TabIndex = 6;
			this.lblNombre.Text = "Nombre";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.Location = new System.Drawing.Point(103, 195);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
			this.lblDescripcion.TabIndex = 7;
			this.lblDescripcion.Text = "Descripcion";
			// 
			// lblPrecio
			// 
			this.lblPrecio.AutoSize = true;
			this.lblPrecio.Location = new System.Drawing.Point(129, 245);
			this.lblPrecio.Name = "lblPrecio";
			this.lblPrecio.Size = new System.Drawing.Size(37, 13);
			this.lblPrecio.TabIndex = 8;
			this.lblPrecio.Text = "Precio";
			// 
			// cboMarca
			// 
			this.cboMarca.FormattingEnabled = true;
			this.cboMarca.Location = new System.Drawing.Point(491, 109);
			this.cboMarca.Name = "cboMarca";
			this.cboMarca.Size = new System.Drawing.Size(121, 21);
			this.cboMarca.TabIndex = 9;
			// 
			// cboCategoria
			// 
			this.cboCategoria.FormattingEnabled = true;
			this.cboCategoria.Location = new System.Drawing.Point(491, 159);
			this.cboCategoria.Name = "cboCategoria";
			this.cboCategoria.Size = new System.Drawing.Size(121, 21);
			this.cboCategoria.TabIndex = 10;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(178, 339);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 11;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(385, 339);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 12;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			// 
			// frmGestionArticulo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 450);
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
			this.MaximumSize = new System.Drawing.Size(800, 600);
			this.Name = "frmGestionArticulo";
			this.Text = "frmGestionArticulo";
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
	}
}