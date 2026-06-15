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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCargar = new System.Windows.Forms.TabPage();
            this.datosDelUsuario = new System.Windows.Forms.GroupBox();
            this.nombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.apellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.dni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.rol = new System.Windows.Forms.Label();
            this.cboRoles = new System.Windows.Forms.ComboBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.dgvUsuariosCargados = new System.Windows.Forms.DataGridView();
            this.tabEditar = new System.Windows.Forms.TabPage();
            this.grpBuscar = new System.Windows.Forms.GroupBox();
            this.lblBuscarDni = new System.Windows.Forms.Label();
            this.txtBuscarDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.grpEditar = new System.Windows.Forms.GroupBox();
            this.lblEditDni = new System.Windows.Forms.Label();
            this.txtEditDni = new System.Windows.Forms.TextBox();
            this.lblEditNombre = new System.Windows.Forms.Label();
            this.txtEditNombre = new System.Windows.Forms.TextBox();
            this.lblEditApellido = new System.Windows.Forms.Label();
            this.txtEditApellido = new System.Windows.Forms.TextBox();
            this.lblEditRol = new System.Windows.Forms.Label();
            this.cboEditRoles = new System.Windows.Forms.ComboBox();
            this.lblEditPassword = new System.Windows.Forms.Label();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.lblEditEmail = new System.Windows.Forms.Label();
            this.txtEditEmail = new System.Windows.Forms.TextBox();
            this.lblEditFechaNacimiento = new System.Windows.Forms.Label();
            this.dtpEditFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabPermisos = new System.Windows.Forms.TabPage();
            this.lblRolPermisos = new System.Windows.Forms.Label();
            this.cboRolPermisos = new System.Windows.Forms.ComboBox();
            this.lblPermDisponibles = new System.Windows.Forms.Label();
            this.lstPermDisponibles = new System.Windows.Forms.ListBox();
            this.lblPermOtorgados = new System.Windows.Forms.Label();
            this.lstPermOtorgados = new System.Windows.Forms.ListBox();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.btnQuitarPermiso = new System.Windows.Forms.Button();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.lblPermisosFamilia = new System.Windows.Forms.Label();
            this.dgvPermisosFamilia = new System.Windows.Forms.DataGridView();
            this.tabControl.SuspendLayout();
            this.tabCargar.SuspendLayout();
            this.datosDelUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosCargados)).BeginInit();
            this.tabEditar.SuspendLayout();
            this.grpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.grpEditar.SuspendLayout();
            this.tabPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisosFamilia)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCargar);
            this.tabControl.Controls.Add(this.tabEditar);
            this.tabControl.Controls.Add(this.tabPermisos);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 550);
            this.tabControl.TabIndex = 0;
            // 
            // tabCargar
            // 
            this.tabCargar.Controls.Add(this.datosDelUsuario);
            this.tabCargar.Controls.Add(this.dgvUsuariosCargados);
            this.tabCargar.Location = new System.Drawing.Point(4, 22);
            this.tabCargar.Name = "tabCargar";
            this.tabCargar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargar.Size = new System.Drawing.Size(776, 387);
            this.tabCargar.TabIndex = 0;
            this.tabCargar.Text = "Cargar Usuario";
            this.tabCargar.UseVisualStyleBackColor = true;
            // 
            // datosDelUsuario
            // 
            this.datosDelUsuario.Controls.Add(this.nombre);
            this.datosDelUsuario.Controls.Add(this.txtNombre);
            this.datosDelUsuario.Controls.Add(this.apellido);
            this.datosDelUsuario.Controls.Add(this.txtApellido);
            this.datosDelUsuario.Controls.Add(this.dni);
            this.datosDelUsuario.Controls.Add(this.txtDni);
            this.datosDelUsuario.Controls.Add(this.rol);
            this.datosDelUsuario.Controls.Add(this.cboRoles);
            this.datosDelUsuario.Controls.Add(this.lblPassword);
            this.datosDelUsuario.Controls.Add(this.txtPassword);
            this.datosDelUsuario.Controls.Add(this.lblEmail);
            this.datosDelUsuario.Controls.Add(this.txtEmail);
            this.datosDelUsuario.Controls.Add(this.lblFechaNacimiento);
            this.datosDelUsuario.Controls.Add(this.dtpFechaNacimiento);
            this.datosDelUsuario.Controls.Add(this.btnGuardar);
            this.datosDelUsuario.Controls.Add(this.btnLimpiar);
            this.datosDelUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.datosDelUsuario.Location = new System.Drawing.Point(8, 8);
            this.datosDelUsuario.Name = "datosDelUsuario";
            this.datosDelUsuario.Size = new System.Drawing.Size(760, 175);
            this.datosDelUsuario.TabIndex = 0;
            this.datosDelUsuario.TabStop = false;
            this.datosDelUsuario.Text = "Datos del Nuevo Usuario";
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
            this.apellido.Location = new System.Drawing.Point(268, 27);
            this.apellido.Name = "apellido";
            this.apellido.Size = new System.Drawing.Size(70, 20);
            this.apellido.TabIndex = 2;
            this.apellido.Text = "Apellido";
            this.apellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtApellido.Location = new System.Drawing.Point(344, 27);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(137, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // dni
            // 
            this.dni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.dni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dni.Location = new System.Drawing.Point(34, 57);
            this.dni.Name = "dni";
            this.dni.Size = new System.Drawing.Size(60, 20);
            this.dni.TabIndex = 4;
            this.dni.Text = "DNI";
            this.dni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDni.Location = new System.Drawing.Point(100, 57);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(137, 20);
            this.txtDni.TabIndex = 5;
            // 
            // rol
            // 
            this.rol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.rol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rol.Location = new System.Drawing.Point(268, 57);
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
            this.cboRoles.Location = new System.Drawing.Point(344, 57);
            this.cboRoles.Name = "cboRoles";
            this.cboRoles.Size = new System.Drawing.Size(137, 21);
            this.cboRoles.TabIndex = 7;
            // 
            // lblPassword
            // 
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPassword.Location = new System.Drawing.Point(24, 88);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 20);
            this.lblPassword.TabIndex = 8;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtPassword.Location = new System.Drawing.Point(100, 88);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(137, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(24, 120);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 20);
            this.lblEmail.TabIndex = 12;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEmail.Location = new System.Drawing.Point(100, 120);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(272, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // lblFechaNacimiento
            // 
            this.lblFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblFechaNacimiento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblFechaNacimiento.Location = new System.Drawing.Point(249, 88);
            this.lblFechaNacimiento.Name = "lblFechaNacimiento";
            this.lblFechaNacimiento.Size = new System.Drawing.Size(89, 20);
            this.lblFechaNacimiento.TabIndex = 10;
            this.lblFechaNacimiento.Text = "Fecha Nac.";
            this.lblFechaNacimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(344, 88);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(137, 20);
            this.dtpFechaNacimiento.TabIndex = 11;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGuardar.Location = new System.Drawing.Point(601, 67);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 32);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar Usuario";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLimpiar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnLimpiar.Location = new System.Drawing.Point(601, 27);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(140, 32);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar campos";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // dgvUsuariosCargados
            // 
            this.dgvUsuariosCargados.AllowUserToAddRows = false;
            this.dgvUsuariosCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuariosCargados.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUsuariosCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuariosCargados.Location = new System.Drawing.Point(8, 191);
            this.dgvUsuariosCargados.Name = "dgvUsuariosCargados";
            this.dgvUsuariosCargados.ReadOnly = true;
            this.dgvUsuariosCargados.Size = new System.Drawing.Size(760, 177);
            this.dgvUsuariosCargados.TabIndex = 1;
            // 
            // tabEditar
            // 
            this.tabEditar.Controls.Add(this.grpBuscar);
            this.tabEditar.Controls.Add(this.dgvUsuarios);
            this.tabEditar.Controls.Add(this.grpEditar);
            this.tabEditar.Location = new System.Drawing.Point(4, 22);
            this.tabEditar.Name = "tabEditar";
            this.tabEditar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditar.Size = new System.Drawing.Size(776, 387);
            this.tabEditar.TabIndex = 1;
            this.tabEditar.Text = "Buscar / Editar";
            this.tabEditar.UseVisualStyleBackColor = true;
            // 
            // grpBuscar
            // 
            this.grpBuscar.Controls.Add(this.lblBuscarDni);
            this.grpBuscar.Controls.Add(this.txtBuscarDni);
            this.grpBuscar.Controls.Add(this.btnBuscar);
            this.grpBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpBuscar.Location = new System.Drawing.Point(8, 8);
            this.grpBuscar.Name = "grpBuscar";
            this.grpBuscar.Size = new System.Drawing.Size(760, 55);
            this.grpBuscar.TabIndex = 0;
            this.grpBuscar.TabStop = false;
            this.grpBuscar.Text = "Buscar usuario";
            // 
            // lblBuscarDni
            // 
            this.lblBuscarDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblBuscarDni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBuscarDni.Location = new System.Drawing.Point(21, 20);
            this.lblBuscarDni.Name = "lblBuscarDni";
            this.lblBuscarDni.Size = new System.Drawing.Size(73, 20);
            this.lblBuscarDni.TabIndex = 0;
            this.lblBuscarDni.Text = "DNI";
            this.lblBuscarDni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuscarDni
            // 
            this.txtBuscarDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBuscarDni.Location = new System.Drawing.Point(100, 20);
            this.txtBuscarDni.Name = "txtBuscarDni";
            this.txtBuscarDni.Size = new System.Drawing.Size(200, 20);
            this.txtBuscarDni.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBuscar.Location = new System.Drawing.Point(316, 18);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(120, 24);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(8, 70);
            this.dgvUsuarios.MultiSelect = false;
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsuarios.Size = new System.Drawing.Size(760, 145);
            this.dgvUsuarios.TabIndex = 1;
            this.dgvUsuarios.SelectionChanged += new System.EventHandler(this.dgvUsuarios_SelectionChanged);
            // 
            // grpEditar
            // 
            this.grpEditar.Controls.Add(this.lblEditDni);
            this.grpEditar.Controls.Add(this.txtEditDni);
            this.grpEditar.Controls.Add(this.lblEditNombre);
            this.grpEditar.Controls.Add(this.txtEditNombre);
            this.grpEditar.Controls.Add(this.lblEditApellido);
            this.grpEditar.Controls.Add(this.txtEditApellido);
            this.grpEditar.Controls.Add(this.lblEditRol);
            this.grpEditar.Controls.Add(this.cboEditRoles);
            this.grpEditar.Controls.Add(this.lblEditPassword);
            this.grpEditar.Controls.Add(this.txtEditPassword);
            this.grpEditar.Controls.Add(this.lblEditEmail);
            this.grpEditar.Controls.Add(this.txtEditEmail);
            this.grpEditar.Controls.Add(this.lblEditFechaNacimiento);
            this.grpEditar.Controls.Add(this.dtpEditFechaNacimiento);
            this.grpEditar.Controls.Add(this.btnGuardarCambios);
            this.grpEditar.Controls.Add(this.btnEliminar);
            this.grpEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpEditar.Location = new System.Drawing.Point(8, 222);
            this.grpEditar.Name = "grpEditar";
            this.grpEditar.Size = new System.Drawing.Size(760, 156);
            this.grpEditar.TabIndex = 2;
            this.grpEditar.TabStop = false;
            this.grpEditar.Text = "Modificar datos del usuario seleccionado";
            // 
            // lblEditDni
            // 
            this.lblEditDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditDni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditDni.Location = new System.Drawing.Point(34, 27);
            this.lblEditDni.Name = "lblEditDni";
            this.lblEditDni.Size = new System.Drawing.Size(60, 20);
            this.lblEditDni.TabIndex = 0;
            this.lblEditDni.Text = "DNI";
            this.lblEditDni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditDni
            // 
            this.txtEditDni.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtEditDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditDni.Location = new System.Drawing.Point(100, 27);
            this.txtEditDni.Name = "txtEditDni";
            this.txtEditDni.ReadOnly = true;
            this.txtEditDni.Size = new System.Drawing.Size(137, 20);
            this.txtEditDni.TabIndex = 1;
            // 
            // lblEditNombre
            // 
            this.lblEditNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditNombre.Location = new System.Drawing.Point(279, 27);
            this.lblEditNombre.Name = "lblEditNombre";
            this.lblEditNombre.Size = new System.Drawing.Size(70, 20);
            this.lblEditNombre.TabIndex = 2;
            this.lblEditNombre.Text = "Nombre";
            this.lblEditNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditNombre
            // 
            this.txtEditNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditNombre.Location = new System.Drawing.Point(355, 27);
            this.txtEditNombre.Name = "txtEditNombre";
            this.txtEditNombre.Size = new System.Drawing.Size(137, 20);
            this.txtEditNombre.TabIndex = 3;
            // 
            // lblEditApellido
            // 
            this.lblEditApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditApellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditApellido.Location = new System.Drawing.Point(34, 57);
            this.lblEditApellido.Name = "lblEditApellido";
            this.lblEditApellido.Size = new System.Drawing.Size(60, 20);
            this.lblEditApellido.TabIndex = 4;
            this.lblEditApellido.Text = "Apellido";
            this.lblEditApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditApellido
            // 
            this.txtEditApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditApellido.Location = new System.Drawing.Point(100, 57);
            this.txtEditApellido.Name = "txtEditApellido";
            this.txtEditApellido.Size = new System.Drawing.Size(137, 20);
            this.txtEditApellido.TabIndex = 5;
            // 
            // lblEditRol
            // 
            this.lblEditRol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditRol.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditRol.Location = new System.Drawing.Point(279, 57);
            this.lblEditRol.Name = "lblEditRol";
            this.lblEditRol.Size = new System.Drawing.Size(70, 20);
            this.lblEditRol.TabIndex = 6;
            this.lblEditRol.Text = "Rol";
            this.lblEditRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboEditRoles
            // 
            this.cboEditRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboEditRoles.FormattingEnabled = true;
            this.cboEditRoles.Location = new System.Drawing.Point(355, 57);
            this.cboEditRoles.Name = "cboEditRoles";
            this.cboEditRoles.Size = new System.Drawing.Size(137, 21);
            this.cboEditRoles.TabIndex = 7;
            // 
            // lblEditPassword
            // 
            this.lblEditPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditPassword.Location = new System.Drawing.Point(24, 88);
            this.lblEditPassword.Name = "lblEditPassword";
            this.lblEditPassword.Size = new System.Drawing.Size(70, 20);
            this.lblEditPassword.TabIndex = 8;
            this.lblEditPassword.Text = "Password";
            this.lblEditPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditPassword
            // 
            this.txtEditPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditPassword.Location = new System.Drawing.Point(100, 88);
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.PasswordChar = '*';
            this.txtEditPassword.Size = new System.Drawing.Size(137, 20);
            this.txtEditPassword.TabIndex = 9;
            // 
            // lblEditEmail
            // 
            this.lblEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditEmail.Location = new System.Drawing.Point(24, 122);
            this.lblEditEmail.Name = "lblEditEmail";
            this.lblEditEmail.Size = new System.Drawing.Size(70, 20);
            this.lblEditEmail.TabIndex = 12;
            this.lblEditEmail.Text = "Email";
            this.lblEditEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditEmail
            // 
            this.txtEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditEmail.Location = new System.Drawing.Point(100, 122);
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.Size = new System.Drawing.Size(231, 20);
            this.txtEditEmail.TabIndex = 13;
            // 
            // lblEditFechaNacimiento
            // 
            this.lblEditFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditFechaNacimiento.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditFechaNacimiento.Location = new System.Drawing.Point(260, 87);
            this.lblEditFechaNacimiento.Name = "lblEditFechaNacimiento";
            this.lblEditFechaNacimiento.Size = new System.Drawing.Size(89, 20);
            this.lblEditFechaNacimiento.TabIndex = 10;
            this.lblEditFechaNacimiento.Text = "Fecha Nac.";
            this.lblEditFechaNacimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpEditFechaNacimiento
            // 
            this.dtpEditFechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpEditFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEditFechaNacimiento.Location = new System.Drawing.Point(355, 87);
            this.dtpEditFechaNacimiento.Name = "dtpEditFechaNacimiento";
            this.dtpEditFechaNacimiento.Size = new System.Drawing.Size(137, 20);
            this.dtpEditFechaNacimiento.TabIndex = 11;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGuardarCambios.Location = new System.Drawing.Point(602, 67);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(140, 32);
            this.btnGuardarCambios.TabIndex = 14;
            this.btnGuardarCambios.Text = "Guardar cambios";
            this.btnGuardarCambios.UseVisualStyleBackColor = false;
            this.btnGuardarCambios.Click += new System.EventHandler(this.btnGuardarCambios_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEliminar.Location = new System.Drawing.Point(602, 27);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(140, 32);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar usuario";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSalir.Location = new System.Drawing.Point(640, 560);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 32);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            //
            // tabPermisos
            //
            this.tabPermisos.Controls.Add(this.lblRolPermisos);
            this.tabPermisos.Controls.Add(this.cboRolPermisos);
            this.tabPermisos.Controls.Add(this.lblPermDisponibles);
            this.tabPermisos.Controls.Add(this.lstPermDisponibles);
            this.tabPermisos.Controls.Add(this.lblPermOtorgados);
            this.tabPermisos.Controls.Add(this.lstPermOtorgados);
            this.tabPermisos.Controls.Add(this.btnAgregarPermiso);
            this.tabPermisos.Controls.Add(this.btnQuitarPermiso);
            this.tabPermisos.Controls.Add(this.btnGuardarPermisos);
            this.tabPermisos.Controls.Add(this.lblPermisosFamilia);
            this.tabPermisos.Controls.Add(this.dgvPermisosFamilia);
            this.tabPermisos.Location = new System.Drawing.Point(4, 22);
            this.tabPermisos.Name = "tabPermisos";
            this.tabPermisos.Padding = new System.Windows.Forms.Padding(3);
            this.tabPermisos.Size = new System.Drawing.Size(776, 524);
            this.tabPermisos.TabIndex = 2;
            this.tabPermisos.Text = "Permisos por rol";
            this.tabPermisos.UseVisualStyleBackColor = true;
            //
            // lblRolPermisos
            //
            this.lblRolPermisos.AutoSize = true;
            this.lblRolPermisos.Location = new System.Drawing.Point(8, 15);
            this.lblRolPermisos.Name = "lblRolPermisos";
            this.lblRolPermisos.Size = new System.Drawing.Size(28, 13);
            this.lblRolPermisos.TabIndex = 0;
            this.lblRolPermisos.Text = "Rol:";
            //
            // cboRolPermisos
            //
            this.cboRolPermisos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRolPermisos.Location = new System.Drawing.Point(50, 12);
            this.cboRolPermisos.Name = "cboRolPermisos";
            this.cboRolPermisos.Size = new System.Drawing.Size(300, 21);
            this.cboRolPermisos.TabIndex = 1;
            this.cboRolPermisos.SelectedIndexChanged += new System.EventHandler(this.cboRolPermisos_SelectedIndexChanged);
            //
            // lblPermDisponibles
            //
            this.lblPermDisponibles.AutoSize = true;
            this.lblPermDisponibles.Location = new System.Drawing.Point(8, 48);
            this.lblPermDisponibles.Name = "lblPermDisponibles";
            this.lblPermDisponibles.Size = new System.Drawing.Size(115, 13);
            this.lblPermDisponibles.TabIndex = 2;
            this.lblPermDisponibles.Text = "Permisos disponibles:";
            //
            // lstPermDisponibles
            //
            this.lstPermDisponibles.FormattingEnabled = true;
            this.lstPermDisponibles.Location = new System.Drawing.Point(8, 65);
            this.lstPermDisponibles.Name = "lstPermDisponibles";
            this.lstPermDisponibles.Size = new System.Drawing.Size(290, 277);
            this.lstPermDisponibles.TabIndex = 3;
            //
            // lblPermOtorgados
            //
            this.lblPermOtorgados.AutoSize = true;
            this.lblPermOtorgados.Location = new System.Drawing.Point(478, 48);
            this.lblPermOtorgados.Name = "lblPermOtorgados";
            this.lblPermOtorgados.Size = new System.Drawing.Size(94, 13);
            this.lblPermOtorgados.TabIndex = 4;
            this.lblPermOtorgados.Text = "Otorgados al rol:";
            //
            // lstPermOtorgados
            //
            this.lstPermOtorgados.FormattingEnabled = true;
            this.lstPermOtorgados.Location = new System.Drawing.Point(478, 65);
            this.lstPermOtorgados.Name = "lstPermOtorgados";
            this.lstPermOtorgados.Size = new System.Drawing.Size(290, 277);
            this.lstPermOtorgados.TabIndex = 5;
            //
            // btnAgregarPermiso
            //
            this.btnAgregarPermiso.Location = new System.Drawing.Point(330, 150);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(116, 30);
            this.btnAgregarPermiso.TabIndex = 6;
            this.btnAgregarPermiso.Text = ">>";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            this.btnAgregarPermiso.Click += new System.EventHandler(this.btnAgregarPermiso_Click);
            //
            // btnQuitarPermiso
            //
            this.btnQuitarPermiso.Location = new System.Drawing.Point(330, 195);
            this.btnQuitarPermiso.Name = "btnQuitarPermiso";
            this.btnQuitarPermiso.Size = new System.Drawing.Size(116, 30);
            this.btnQuitarPermiso.TabIndex = 7;
            this.btnQuitarPermiso.Text = "<<";
            this.btnQuitarPermiso.UseVisualStyleBackColor = true;
            this.btnQuitarPermiso.Click += new System.EventHandler(this.btnQuitarPermiso_Click);
            //
            // btnGuardarPermisos
            //
            this.btnGuardarPermisos.Location = new System.Drawing.Point(628, 488);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(140, 30);
            this.btnGuardarPermisos.TabIndex = 8;
            this.btnGuardarPermisos.Text = "Guardar permisos";
            this.btnGuardarPermisos.UseVisualStyleBackColor = true;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            //
            // lblPermisosFamilia
            //
            this.lblPermisosFamilia.AutoSize = true;
            this.lblPermisosFamilia.Location = new System.Drawing.Point(8, 352);
            this.lblPermisosFamilia.Name = "lblPermisosFamilia";
            this.lblPermisosFamilia.Size = new System.Drawing.Size(212, 13);
            this.lblPermisosFamilia.TabIndex = 9;
            this.lblPermisosFamilia.Text = "Permisos de la familia seleccionada:";
            //
            // dgvPermisosFamilia
            //
            this.dgvPermisosFamilia.AllowUserToAddRows = false;
            this.dgvPermisosFamilia.AllowUserToDeleteRows = false;
            this.dgvPermisosFamilia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisosFamilia.Location = new System.Drawing.Point(8, 372);
            this.dgvPermisosFamilia.Name = "dgvPermisosFamilia";
            this.dgvPermisosFamilia.ReadOnly = true;
            this.dgvPermisosFamilia.RowHeadersVisible = false;
            this.dgvPermisosFamilia.AllowUserToResizeRows = false;
            this.dgvPermisosFamilia.MultiSelect = false;
            this.dgvPermisosFamilia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPermisosFamilia.Size = new System.Drawing.Size(760, 108);
            this.dgvPermisosFamilia.TabIndex = 10;
            //
            // FormGestionUsuarios
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 600);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSalir);
            this.Name = "FormGestionUsuarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Gestionar Usuarios";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCargar.ResumeLayout(false);
            this.datosDelUsuario.ResumeLayout(false);
            this.datosDelUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuariosCargados)).EndInit();
            this.tabEditar.ResumeLayout(false);
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.grpEditar.ResumeLayout(false);
            this.grpEditar.PerformLayout();
            this.tabPermisos.ResumeLayout(false);
            this.tabPermisos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisosFamilia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCargar;
        private System.Windows.Forms.TabPage tabEditar;
        // Tab 1
        private System.Windows.Forms.GroupBox datosDelUsuario;
        private System.Windows.Forms.Label nombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label apellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label dni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label rol;
        private System.Windows.Forms.ComboBox cboRoles;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView dgvUsuariosCargados;
        // Tab 2
        private System.Windows.Forms.GroupBox grpBuscar;
        private System.Windows.Forms.Label lblBuscarDni;
        private System.Windows.Forms.TextBox txtBuscarDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.GroupBox grpEditar;
        private System.Windows.Forms.Label lblEditDni;
        private System.Windows.Forms.TextBox txtEditDni;
        private System.Windows.Forms.Label lblEditNombre;
        private System.Windows.Forms.TextBox txtEditNombre;
        private System.Windows.Forms.Label lblEditApellido;
        private System.Windows.Forms.TextBox txtEditApellido;
        private System.Windows.Forms.Label lblEditRol;
        private System.Windows.Forms.ComboBox cboEditRoles;
        private System.Windows.Forms.Label lblEditPassword;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.Label lblEditEmail;
        private System.Windows.Forms.TextBox txtEditEmail;
        private System.Windows.Forms.Label lblEditFechaNacimiento;
        private System.Windows.Forms.DateTimePicker dtpEditFechaNacimiento;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminar;
        // Global
        private System.Windows.Forms.Button btnSalir;
        // Tab 3
        private System.Windows.Forms.TabPage tabPermisos;
        private System.Windows.Forms.Label lblRolPermisos;
        private System.Windows.Forms.ComboBox cboRolPermisos;
        private System.Windows.Forms.Label lblPermDisponibles;
        private System.Windows.Forms.ListBox lstPermDisponibles;
        private System.Windows.Forms.Label lblPermOtorgados;
        private System.Windows.Forms.ListBox lstPermOtorgados;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.Button btnQuitarPermiso;
        private System.Windows.Forms.Button btnGuardarPermisos;
        private System.Windows.Forms.Label lblPermisosFamilia;
        private System.Windows.Forms.DataGridView dgvPermisosFamilia;
    }
}
