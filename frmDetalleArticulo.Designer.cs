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
			this.btnCancelar = new System.Windows.Forms.Button();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.cboCategoria = new System.Windows.Forms.ComboBox();
			this.cboMarca = new System.Windows.Forms.ComboBox();
			this.lblPrecio = new System.Windows.Forms.Label();
			this.lblDescripcion = new System.Windows.Forms.Label();
			this.lblNombre = new System.Windows.Forms.Label();
			this.lblCodigo = new System.Windows.Forms.Label();
			this.txtPrecio = new System.Windows.Forms.TextBox();
			this.txtNombre = new System.Windows.Forms.TextBox();
			this.txtCodigo = new System.Windows.Forms.TextBox();
			this.txtDescripcion = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnCancelar
			// 
			this.btnCancelar.Location = new System.Drawing.Point(428, 332);
			this.btnCancelar.Name = "btnCancelar";
			this.btnCancelar.Size = new System.Drawing.Size(75, 23);
			this.btnCancelar.TabIndex = 24;
			this.btnCancelar.Text = "Cancelar";
			this.btnCancelar.UseVisualStyleBackColor = true;
			this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
			// 
			// btnAceptar
			// 
			this.btnAceptar.Location = new System.Drawing.Point(221, 332);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(75, 23);
			this.btnAceptar.TabIndex = 23;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.UseVisualStyleBackColor = true;
			// 
			// cboCategoria
			// 
			this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboCategoria.FormattingEnabled = true;
			this.cboCategoria.Location = new System.Drawing.Point(534, 152);
			this.cboCategoria.Name = "cboCategoria";
			this.cboCategoria.Size = new System.Drawing.Size(121, 21);
			this.cboCategoria.TabIndex = 22;
			// 
			// cboMarca
			// 
			this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboMarca.FormattingEnabled = true;
			this.cboMarca.Location = new System.Drawing.Point(534, 102);
			this.cboMarca.Name = "cboMarca";
			this.cboMarca.Size = new System.Drawing.Size(121, 21);
			this.cboMarca.TabIndex = 21;
			// 
			// lblPrecio
			// 
			this.lblPrecio.AutoSize = true;
			this.lblPrecio.Location = new System.Drawing.Point(172, 238);
			this.lblPrecio.Name = "lblPrecio";
			this.lblPrecio.Size = new System.Drawing.Size(37, 13);
			this.lblPrecio.TabIndex = 20;
			this.lblPrecio.Text = "Precio";
			// 
			// lblDescripcion
			// 
			this.lblDescripcion.AutoSize = true;
			this.lblDescripcion.Location = new System.Drawing.Point(146, 188);
			this.lblDescripcion.Name = "lblDescripcion";
			this.lblDescripcion.Size = new System.Drawing.Size(63, 13);
			this.lblDescripcion.TabIndex = 19;
			this.lblDescripcion.Text = "Descripcion";
			// 
			// lblNombre
			// 
			this.lblNombre.AutoSize = true;
			this.lblNombre.Location = new System.Drawing.Point(165, 152);
			this.lblNombre.Name = "lblNombre";
			this.lblNombre.Size = new System.Drawing.Size(44, 13);
			this.lblNombre.TabIndex = 18;
			this.lblNombre.Text = "Nombre";
			// 
			// lblCodigo
			// 
			this.lblCodigo.AutoSize = true;
			this.lblCodigo.Location = new System.Drawing.Point(169, 102);
			this.lblCodigo.Name = "lblCodigo";
			this.lblCodigo.Size = new System.Drawing.Size(40, 13);
			this.lblCodigo.TabIndex = 17;
			this.lblCodigo.Text = "Codigo";
			// 
			// txtPrecio
			// 
			this.txtPrecio.Location = new System.Drawing.Point(221, 231);
			this.txtPrecio.Name = "txtPrecio";
			this.txtPrecio.ReadOnly = true;
			this.txtPrecio.Size = new System.Drawing.Size(100, 20);
			this.txtPrecio.TabIndex = 16;
			// 
			// txtNombre
			// 
			this.txtNombre.Location = new System.Drawing.Point(221, 145);
			this.txtNombre.Name = "txtNombre";
			this.txtNombre.ReadOnly = true;
			this.txtNombre.Size = new System.Drawing.Size(100, 20);
			this.txtNombre.TabIndex = 15;
			// 
			// txtCodigo
			// 
			this.txtCodigo.Location = new System.Drawing.Point(221, 95);
			this.txtCodigo.Name = "txtCodigo";
			this.txtCodigo.ReadOnly = true;
			this.txtCodigo.Size = new System.Drawing.Size(100, 20);
			this.txtCodigo.TabIndex = 14;
			// 
			// txtDescripcion
			// 
			this.txtDescripcion.Location = new System.Drawing.Point(221, 185);
			this.txtDescripcion.Name = "txtDescripcion";
			this.txtDescripcion.ReadOnly = true;
			this.txtDescripcion.Size = new System.Drawing.Size(100, 20);
			this.txtDescripcion.TabIndex = 13;
			// 
			// frmDetalleArticulo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
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
			this.Name = "frmDetalleArticulo";
			this.Text = "frmDetallesArticulo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnCancelar;
		private System.Windows.Forms.Button btnAceptar;
		private System.Windows.Forms.ComboBox cboCategoria;
		private System.Windows.Forms.ComboBox cboMarca;
		private System.Windows.Forms.Label lblPrecio;
		private System.Windows.Forms.Label lblDescripcion;
		private System.Windows.Forms.Label lblNombre;
		private System.Windows.Forms.Label lblCodigo;
		private System.Windows.Forms.TextBox txtPrecio;
		private System.Windows.Forms.TextBox txtNombre;
		private System.Windows.Forms.TextBox txtCodigo;
		private System.Windows.Forms.TextBox txtDescripcion;
	}
}