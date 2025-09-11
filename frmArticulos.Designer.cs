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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulos));
			this.dgvArticulos = new System.Windows.Forms.DataGridView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.btnAdminMarcas = new System.Windows.Forms.ToolStripButton();
			this.btnAdminCategorias = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// dgvArticulos
			// 
			this.dgvArticulos.AllowUserToOrderColumns = true;
			this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvArticulos.Location = new System.Drawing.Point(85, 125);
			this.dgvArticulos.Name = "dgvArticulos";
			this.dgvArticulos.Size = new System.Drawing.Size(547, 313);
			this.dgvArticulos.TabIndex = 0;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAdminMarcas,
            this.btnAdminCategorias});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// btnAdminMarcas
			// 
			this.btnAdminMarcas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAdminMarcas.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminMarcas.Image")));
			this.btnAdminMarcas.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdminMarcas.Name = "btnAdminMarcas";
			this.btnAdminMarcas.Size = new System.Drawing.Size(23, 22);
			this.btnAdminMarcas.Text = "toolStripButton1";
			this.btnAdminMarcas.Click += new System.EventHandler(this.btnAdminMarcas_Click);
			// 
			// btnAdminCategorias
			// 
			this.btnAdminCategorias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.btnAdminCategorias.Image = ((System.Drawing.Image)(resources.GetObject("btnAdminCategorias.Image")));
			this.btnAdminCategorias.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAdminCategorias.Name = "btnAdminCategorias";
			this.btnAdminCategorias.Size = new System.Drawing.Size(23, 22);
			this.btnAdminCategorias.Text = "toolStripButton2";
			this.btnAdminCategorias.Click += new System.EventHandler(this.btnAdminCategorias_Click);
			// 
			// frmArticulos
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.dgvArticulos);
			this.Name = "frmArticulos";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmArticulos";
			this.Load += new System.EventHandler(this.frmArticulos_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dgvArticulos;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton btnAdminMarcas;
		private System.Windows.Forms.ToolStripButton btnAdminCategorias;
	}
}