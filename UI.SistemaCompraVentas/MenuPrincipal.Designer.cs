namespace UI.SistemaCompraVentas
{
    partial class MenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblSesion = new System.Windows.Forms.Label();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnVentas = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnProveedores = new System.Windows.Forms.Button();
            this.btnCompras = new System.Windows.Forms.Button();
            this.btnRecepcionCompras = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUsuario
            // 
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblUsuario.Location = new System.Drawing.Point(6, 39);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(400, 22);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Cargando...";
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSesion
            // 
            this.lblSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblSesion.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSesion.Location = new System.Drawing.Point(6, 65);
            this.lblSesion.Name = "lblSesion";
            this.lblSesion.Size = new System.Drawing.Size(400, 22);
            this.lblSesion.TabIndex = 1;
            this.lblSesion.Text = "Cargando sesión...";
            this.lblSesion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnUsuarios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUsuarios.Location = new System.Drawing.Point(56, 119);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(300, 36);
            this.btnUsuarios.TabIndex = 2;
            this.btnUsuarios.Text = "Gestionar Usuarios";
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnReportes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnReportes.Location = new System.Drawing.Point(56, 165);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(300, 36);
            this.btnReportes.TabIndex = 3;
            this.btnReportes.Text = "Generar Reportes";
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVentas.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnVentas.Location = new System.Drawing.Point(56, 211);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(300, 36);
            this.btnVentas.TabIndex = 4;
            this.btnVentas.Text = "Registrar Venta";
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnProductos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProductos.Location = new System.Drawing.Point(56, 257);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(300, 36);
            this.btnProductos.TabIndex = 5;
            this.btnProductos.Text = "Gestionar Stock";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLogout.Location = new System.Drawing.Point(266, 505);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 32);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnClientes.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnClientes.Location = new System.Drawing.Point(56, 303);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(300, 36);
            this.btnClientes.TabIndex = 7;
            this.btnClientes.Text = "Gestionar Clientes";
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            //
            // btnProveedores
            //
            this.btnProveedores.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnProveedores.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnProveedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProveedores.Location = new System.Drawing.Point(56, 349);
            this.btnProveedores.Name = "btnProveedores";
            this.btnProveedores.Size = new System.Drawing.Size(300, 36);
            this.btnProveedores.TabIndex = 8;
            this.btnProveedores.Text = "Gestionar Proveedores";
            this.btnProveedores.UseVisualStyleBackColor = false;
            this.btnProveedores.Click += new System.EventHandler(this.btnProveedores_Click);
            //
            // btnCompras
            //
            this.btnCompras.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCompras.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCompras.Location = new System.Drawing.Point(56, 395);
            this.btnCompras.Name = "btnCompras";
            this.btnCompras.Size = new System.Drawing.Size(300, 36);
            this.btnCompras.TabIndex = 9;
            this.btnCompras.Text = "Registrar Compra";
            this.btnCompras.UseVisualStyleBackColor = false;
            this.btnCompras.Click += new System.EventHandler(this.btnCompras_Click);
            //
            // btnRecepcionCompras
            //
            this.btnRecepcionCompras.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRecepcionCompras.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnRecepcionCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecepcionCompras.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRecepcionCompras.Location = new System.Drawing.Point(56, 441);
            this.btnRecepcionCompras.Name = "btnRecepcionCompras";
            this.btnRecepcionCompras.Size = new System.Drawing.Size(300, 36);
            this.btnRecepcionCompras.TabIndex = 10;
            this.btnRecepcionCompras.Text = "Recepción de Compras";
            this.btnRecepcionCompras.UseVisualStyleBackColor = false;
            this.btnRecepcionCompras.Click += new System.EventHandler(this.btnRecepcionCompras_Click);
            //
            // MenuPrincipal
            //
            this.AccessibleName = "Sistema SCV - Panel de Control";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(418, 560);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblSesion);
            this.Controls.Add(this.btnUsuarios);
            this.Controls.Add(this.btnReportes);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.btnProveedores);
            this.Controls.Add(this.btnCompras);
            this.Controls.Add(this.btnRecepcionCompras);
            this.Controls.Add(this.btnLogout);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Menú Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblSesion;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnCompras;
        private System.Windows.Forms.Button btnRecepcionCompras;
    }
}