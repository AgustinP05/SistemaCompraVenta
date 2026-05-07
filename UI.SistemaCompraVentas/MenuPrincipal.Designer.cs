namespace UI.SistemaCompraVentas
{
    partial class MenuPrincipal
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
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Location = new System.Drawing.Point(191, 62);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(75, 23);
            this.btnUsuarios.TabIndex = 0;
            this.btnUsuarios.Text = "btnUsuarios";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            this.btnVentas.Location = new System.Drawing.Point(294, 62);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(75, 23);
            this.btnVentas.TabIndex = 1;
            this.btnVentas.Text = "btnVentas";
            this.btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnProductos
            // 
            this.btnProductos.Location = new System.Drawing.Point(409, 62);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(75, 23);
            this.btnProductos.TabIndex = 2;
            this.btnProductos.Text = "btnProductos";
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Location = new System.Drawing.Point(523, 62);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(75, 23);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "btnReportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(368, 9);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(62, 13);
            this.lblUsuario.TabIndex = 4;
            this.lblUsuario.Text = "Cargando...";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(191, 266);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnUsuarios);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipalForm";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button btnLogout;
    }
}