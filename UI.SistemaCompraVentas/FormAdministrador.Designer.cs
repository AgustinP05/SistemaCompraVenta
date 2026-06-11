namespace UI.SistemaCompraVentas
{
    partial class FormGestionUsuarios
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
            this.datosDelUsuario = new System.Windows.Forms.GroupBox();
            this.dni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.nombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.apellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.rol = new System.Windows.Forms.Label();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.datosDelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // datosDelUsuario
            // 
            this.datosDelUsuario.Controls.Add(this.dni);
            this.datosDelUsuario.Controls.Add(this.txtDni);
            this.datosDelUsuario.Controls.Add(this.nombre);
            this.datosDelUsuario.Controls.Add(this.txtNombre);
            this.datosDelUsuario.Controls.Add(this.apellido);
            this.datosDelUsuario.Controls.Add(this.txtApellido);
            this.datosDelUsuario.Controls.Add(this.rol);
            this.datosDelUsuario.Controls.Add(this.cboRoles);
            this.datosDelUsuario.Controls.Add(this.btnGuardar);
            this.datosDelUsuario.Controls.Add(this.btnCancelar);
            this.datosDelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.datosDelUsuario.Location = new System.Drawing.Point(12, 12);
            this.datosDelUsuario.Name = "datosDelUsuario";
            this.datosDelUsuario.Size = new System.Drawing.Size(760, 132);
            this.datosDelUsuario.TabIndex = 1;
            this.datosDelUsuario.TabStop = false;
            this.datosDelUsuario.Text = "Datos del Usuario";
            // 
            // dni
            // 
            this.dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dni.Location = new System.Drawing.Point(34, 53);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(60, 20);
            this.dni.TabIndex = 4;
            this.dni.Text = "DNI";
            this.dni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDni.Location = new System.Drawing.Point(100, 53);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(137, 20);
            this.txtDni.TabIndex = 5;
            // 
            // nombre
            // 
            this.nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nombre.Location = new System.Drawing.Point(24, 27);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(70, 20);
            this.nombre.TabIndex = 0;
            this.nombre.Text = "Nombre";
            this.nombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.Location = new System.Drawing.Point(100, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(137, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // apellido
            // 
            this.apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.apellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.apellido.Location = new System.Drawing.Point(248, 27);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(70, 20);
            this.apellido.TabIndex = 2;
            this.apellido.Text = "Apellido";
            this.apellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtApellido.Location = new System.Drawing.Point(324, 27);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(137, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // rol
            // 
            this.rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rol.Location = new System.Drawing.Point(248, 52);
            this.rol.Name = "rol";
            this.rol.Size = new System.Drawing.Size(70, 20);
            this.rol.TabIndex = 6;
            this.rol.Text = "Rol";
            this.rol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboRoles
            // 
            this.cboRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(324, 52);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(137, 21);
            this.cboRoles.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGuardar.Location = new System.Drawing.Point(602, 73);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 32);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.Location = new System.Drawing.Point(602, 29);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 32);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(12, 150);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 270);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 435);
            this.Controls.Add(this.datosDelUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "FormGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Gestionar Usuarios";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            this.datosDelUsuario.ResumeLayout(false);
            this.datosDelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox datosDelUsuario;
        private System.Windows.Forms.Label dni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label apellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label rol;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnCancelar;
    }
}