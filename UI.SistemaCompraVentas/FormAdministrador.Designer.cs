namespace UI.SistemaCompraVentas
{
    partial class FormGestionUsuarios
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.datosDelUsuario = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.rol = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.apellido = new System.Windows.Forms.Label();
            this.dni = new System.Windows.Forms.Label();
            this.nombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.seguridadGestionPermisos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.datosDelUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(226, 68);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(574, 382);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // datosDelUsuario
            // 
            this.datosDelUsuario.Controls.Add(this.btnGuardar);
            this.datosDelUsuario.Controls.Add(this.rol);
            this.datosDelUsuario.Controls.Add(this.txtDni);
            this.datosDelUsuario.Controls.Add(this.cboRoles);
            this.datosDelUsuario.Controls.Add(this.apellido);
            this.datosDelUsuario.Controls.Add(this.dni);
            this.datosDelUsuario.Controls.Add(this.nombre);
            this.datosDelUsuario.Controls.Add(this.txtApellido);
            this.datosDelUsuario.Controls.Add(this.txtNombre);
            this.datosDelUsuario.Dock = System.Windows.Forms.DockStyle.Left;
            this.datosDelUsuario.Location = new System.Drawing.Point(0, 0);
            this.datosDelUsuario.Name = "datosDelUsuario";
            this.datosDelUsuario.Size = new System.Drawing.Size(220, 450);
            this.datosDelUsuario.TabIndex = 1;
            this.datosDelUsuario.TabStop = false;
            this.datosDelUsuario.Text = "Datos del Usuario";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(17, 260);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(180, 30);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // rol
            // 
            this.rol.AutoSize = true;
            this.rol.Location = new System.Drawing.Point(14, 214);
            this.rol.Name = "rol";
            this.rol.Size = new System.Drawing.Size(29, 13);
            this.rol.TabIndex = 7;
            this.rol.Text = "ROL";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(94, 37);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 2;
            // 
            // cboRoles
            // 
            this.cboRoles.FormattingEnabled = true;
            this.cboRoles.Location = new System.Drawing.Point(73, 211);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(121, 21);
            this.cboRoles.TabIndex = 4;
            // 
            // apellido
            // 
            this.apellido.AutoSize = true;
            this.apellido.Location = new System.Drawing.Point(14, 125);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(68, 13);
            this.apellido.TabIndex = 6;
            this.apellido.Text = "APELLIDO : ";
            // 
            // dni
            // 
            this.dni.AutoSize = true;
            this.dni.Location = new System.Drawing.Point(12, 37);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(35, 13);
            this.dni.TabIndex = 2;
            this.dni.Text = "DNI : ";
            // 
            // nombre
            // 
            this.nombre.AutoSize = true;
            this.nombre.Location = new System.Drawing.Point(14, 79);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(63, 13);
            this.nombre.TabIndex = 5;
            this.nombre.Text = "NOMBRE : ";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(94, 122);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(94, 79);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // seguridadGestionPermisos
            // 
            this.seguridadGestionPermisos.AutoSize = true;
            this.seguridadGestionPermisos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seguridadGestionPermisos.Location = new System.Drawing.Point(299, 33);
            this.seguridadGestionPermisos.Name = "seguridadGestionPermisos";
            this.seguridadGestionPermisos.Size = new System.Drawing.Size(391, 17);
            this.seguridadGestionPermisos.TabIndex = 2;
            this.seguridadGestionPermisos.Text = "MÓDULO DE SEGURIDAD - GESTIÓN DE PERMISOS";
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.seguridadGestionPermisos);
            this.Controls.Add(this.datosDelUsuario);
            this.Controls.Add(this.dgvUsuarios);
            this.Name = "FormGestionUsuarios";
            this.Text = "Gestión de Usuarios y Seguridad";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.datosDelUsuario.ResumeLayout(false);
            this.datosDelUsuario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox datosDelUsuario;
        private System.Windows.Forms.Label dni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Label apellido;
        private System.Windows.Forms.Label rol;
        private System.Windows.Forms.Label seguridadGestionPermisos;
        private System.Windows.Forms.Button btnGuardar;
    }
}