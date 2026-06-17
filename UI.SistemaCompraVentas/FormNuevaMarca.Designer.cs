namespace UI.SistemaCompraVentas
{
    partial class FormNuevaMarca
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMarca = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblProveedores = new System.Windows.Forms.Label();
            this.cboProveedor = new System.Windows.Forms.ComboBox();
            this.btnAsociar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblMarca
            //
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(15, 18);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(40, 13);
            this.lblMarca.TabIndex = 0;
            this.lblMarca.Text = "Marca:";
            //
            // txtMarca
            //
            this.txtMarca.Location = new System.Drawing.Point(95, 15);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(240, 20);
            this.txtMarca.TabIndex = 1;
            //
            // lblProveedores
            //
            this.lblProveedores.AutoSize = true;
            this.lblProveedores.Location = new System.Drawing.Point(15, 52);
            this.lblProveedores.Name = "lblProveedores";
            this.lblProveedores.Size = new System.Drawing.Size(160, 13);
            this.lblProveedores.TabIndex = 2;
            this.lblProveedores.Text = "Proveedor que provee esta marca:";
            //
            // cboProveedor
            //
            this.cboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProveedor.FormattingEnabled = true;
            this.cboProveedor.Location = new System.Drawing.Point(15, 70);
            this.cboProveedor.Name = "cboProveedor";
            this.cboProveedor.Size = new System.Drawing.Size(320, 21);
            this.cboProveedor.TabIndex = 3;
            //
            // btnAsociar
            //
            this.btnAsociar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAsociar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAsociar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsociar.Location = new System.Drawing.Point(133, 110);
            this.btnAsociar.Name = "btnAsociar";
            this.btnAsociar.Size = new System.Drawing.Size(95, 30);
            this.btnAsociar.TabIndex = 4;
            this.btnAsociar.Text = "Asociar";
            this.btnAsociar.UseVisualStyleBackColor = false;
            this.btnAsociar.Click += new System.EventHandler(this.btnAsociar_Click);
            //
            // btnCerrar
            //
            this.btnCerrar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCerrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(234, 110);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(101, 30);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cancelar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            //
            // FormNuevaMarca
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 160);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Controls.Add(this.lblMarca);
            this.Controls.Add(this.txtMarca);
            this.Controls.Add(this.lblProveedores);
            this.Controls.Add(this.cboProveedor);
            this.Controls.Add(this.btnAsociar);
            this.Controls.Add(this.btnCerrar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNuevaMarca";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva marca";
            this.Load += new System.EventHandler(this.FormNuevaMarca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label lblProveedores;
        private System.Windows.Forms.ComboBox cboProveedor;
        private System.Windows.Forms.Button btnAsociar;
        private System.Windows.Forms.Button btnCerrar;
    }
}
