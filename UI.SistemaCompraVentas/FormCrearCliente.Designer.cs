namespace UI.SistemaCompraVentas
{
    partial class FormCrearCliente
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
            this.datosDelCliente = new System.Windows.Forms.GroupBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnIngresarCliente = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvClientesCargados = new System.Windows.Forms.DataGridView();
            this.tabEditar = new System.Windows.Forms.TabPage();
            this.grpBuscar = new System.Windows.Forms.GroupBox();
            this.lblBuscarDni = new System.Windows.Forms.Label();
            this.txtBuscarDni = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.grpEditar = new System.Windows.Forms.GroupBox();
            this.lblEditDni = new System.Windows.Forms.Label();
            this.txtEditDni = new System.Windows.Forms.TextBox();
            this.lblEditNombre = new System.Windows.Forms.Label();
            this.txtEditNombre = new System.Windows.Forms.TextBox();
            this.lblEditApellido = new System.Windows.Forms.Label();
            this.txtEditApellido = new System.Windows.Forms.TextBox();
            this.lblEditDireccion = new System.Windows.Forms.Label();
            this.txtEditDireccion = new System.Windows.Forms.TextBox();
            this.lblEditTelefono = new System.Windows.Forms.Label();
            this.txtEditTelefono = new System.Windows.Forms.TextBox();
            this.lblEditEmail = new System.Windows.Forms.Label();
            this.txtEditEmail = new System.Windows.Forms.TextBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabCargar.SuspendLayout();
            this.datosDelCliente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesCargados)).BeginInit();
            this.tabEditar.SuspendLayout();
            this.grpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.grpEditar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCargar);
            this.tabControl.Controls.Add(this.tabEditar);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(784, 398);
            this.tabControl.TabIndex = 0;
            // 
            // tabCargar
            // 
            this.tabCargar.Controls.Add(this.datosDelCliente);
            this.tabCargar.Controls.Add(this.dgvClientesCargados);
            this.tabCargar.Location = new System.Drawing.Point(4, 22);
            this.tabCargar.Name = "tabCargar";
            this.tabCargar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargar.Size = new System.Drawing.Size(776, 372);
            this.tabCargar.TabIndex = 0;
            this.tabCargar.Text = "Cargar Cliente";
            this.tabCargar.UseVisualStyleBackColor = true;
            // 
            // datosDelCliente
            // 
            this.datosDelCliente.Controls.Add(this.lblDni);
            this.datosDelCliente.Controls.Add(this.txtDni);
            this.datosDelCliente.Controls.Add(this.lblNombre);
            this.datosDelCliente.Controls.Add(this.txtNombre);
            this.datosDelCliente.Controls.Add(this.lblApellido);
            this.datosDelCliente.Controls.Add(this.txtApellido);
            this.datosDelCliente.Controls.Add(this.lblDireccion);
            this.datosDelCliente.Controls.Add(this.txtDireccion);
            this.datosDelCliente.Controls.Add(this.lblTelefono);
            this.datosDelCliente.Controls.Add(this.txtTelefono);
            this.datosDelCliente.Controls.Add(this.lblEmail);
            this.datosDelCliente.Controls.Add(this.txtEmail);
            this.datosDelCliente.Controls.Add(this.btnIngresarCliente);
            this.datosDelCliente.Controls.Add(this.btnCancelar);
            this.datosDelCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.datosDelCliente.Location = new System.Drawing.Point(8, 8);
            this.datosDelCliente.Name = "datosDelCliente";
            this.datosDelCliente.Size = new System.Drawing.Size(760, 139);
            this.datosDelCliente.TabIndex = 0;
            this.datosDelCliente.TabStop = false;
            this.datosDelCliente.Text = "Datos del Cliente";
            // 
            // lblDni
            // 
            this.lblDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDni.Location = new System.Drawing.Point(21, 27);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(73, 20);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI";
            this.lblDni.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDni
            // 
            this.txtDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDni.Location = new System.Drawing.Point(100, 27);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(137, 20);
            this.txtDni.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombre.Location = new System.Drawing.Point(248, 27);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 20);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtNombre.Location = new System.Drawing.Point(324, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(233, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // lblApellido
            // 
            this.lblApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblApellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblApellido.Location = new System.Drawing.Point(21, 60);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(73, 20);
            this.lblApellido.TabIndex = 4;
            this.lblApellido.Text = "Apellido";
            this.lblApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtApellido
            // 
            this.txtApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtApellido.Location = new System.Drawing.Point(100, 60);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(137, 20);
            this.txtApellido.TabIndex = 5;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDireccion.Location = new System.Drawing.Point(248, 60);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(70, 20);
            this.lblDireccion.TabIndex = 6;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDireccion.Location = new System.Drawing.Point(324, 60);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(233, 20);
            this.txtDireccion.TabIndex = 7;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTelefono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTelefono.Location = new System.Drawing.Point(21, 93);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(73, 20);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTelefono.Location = new System.Drawing.Point(100, 93);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(248, 93);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(70, 20);
            this.lblEmail.TabIndex = 10;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEmail.Location = new System.Drawing.Point(324, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(233, 20);
            this.txtEmail.TabIndex = 11;
            // 
            // btnIngresarCliente
            // 
            this.btnIngresarCliente.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIngresarCliente.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnIngresarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnIngresarCliente.Location = new System.Drawing.Point(600, 81);
            this.btnIngresarCliente.Name = "btnIngresarCliente";
            this.btnIngresarCliente.Size = new System.Drawing.Size(140, 32);
            this.btnIngresarCliente.TabIndex = 12;
            this.btnIngresarCliente.Text = "Ingresar cliente";
            this.btnIngresarCliente.UseVisualStyleBackColor = false;
            this.btnIngresarCliente.Click += new System.EventHandler(this.btnIngresarCliente_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.Location = new System.Drawing.Point(600, 36);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 32);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Limpiar campos";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvClientesCargados
            // 
            this.dgvClientesCargados.AllowUserToAddRows = false;
            this.dgvClientesCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientesCargados.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvClientesCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientesCargados.Location = new System.Drawing.Point(8, 153);
            this.dgvClientesCargados.Name = "dgvClientesCargados";
            this.dgvClientesCargados.ReadOnly = true;
            this.dgvClientesCargados.Size = new System.Drawing.Size(760, 213);
            this.dgvClientesCargados.TabIndex = 14;
            // 
            // tabEditar
            // 
            this.tabEditar.Controls.Add(this.grpBuscar);
            this.tabEditar.Controls.Add(this.dgvClientes);
            this.tabEditar.Controls.Add(this.grpEditar);
            this.tabEditar.Location = new System.Drawing.Point(4, 22);
            this.tabEditar.Name = "tabEditar";
            this.tabEditar.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditar.Size = new System.Drawing.Size(776, 372);
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
            this.grpBuscar.Text = "Buscar cliente";
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
            // dgvClientes
            // 
            this.dgvClientes.AllowUserToAddRows = false;
            this.dgvClientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Location = new System.Drawing.Point(8, 70);
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.Size = new System.Drawing.Size(760, 155);
            this.dgvClientes.TabIndex = 1;
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);
            // 
            // grpEditar
            // 
            this.grpEditar.Controls.Add(this.lblEditDni);
            this.grpEditar.Controls.Add(this.txtEditDni);
            this.grpEditar.Controls.Add(this.lblEditNombre);
            this.grpEditar.Controls.Add(this.txtEditNombre);
            this.grpEditar.Controls.Add(this.lblEditApellido);
            this.grpEditar.Controls.Add(this.txtEditApellido);
            this.grpEditar.Controls.Add(this.lblEditDireccion);
            this.grpEditar.Controls.Add(this.txtEditDireccion);
            this.grpEditar.Controls.Add(this.lblEditTelefono);
            this.grpEditar.Controls.Add(this.txtEditTelefono);
            this.grpEditar.Controls.Add(this.lblEditEmail);
            this.grpEditar.Controls.Add(this.txtEditEmail);
            this.grpEditar.Controls.Add(this.btnGuardarCambios);
            this.grpEditar.Controls.Add(this.btnEliminar);
            this.grpEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpEditar.Location = new System.Drawing.Point(8, 232);
            this.grpEditar.Name = "grpEditar";
            this.grpEditar.Size = new System.Drawing.Size(760, 133);
            this.grpEditar.TabIndex = 2;
            this.grpEditar.TabStop = false;
            this.grpEditar.Text = "Modificar datos del cliente seleccionado en la grilla";
            // 
            // lblEditDni
            // 
            this.lblEditDni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditDni.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditDni.Location = new System.Drawing.Point(21, 27);
            this.lblEditDni.Name = "lblEditDni";
            this.lblEditDni.Size = new System.Drawing.Size(73, 20);
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
            this.lblEditNombre.Location = new System.Drawing.Point(248, 27);
            this.lblEditNombre.Name = "lblEditNombre";
            this.lblEditNombre.Size = new System.Drawing.Size(70, 20);
            this.lblEditNombre.TabIndex = 2;
            this.lblEditNombre.Text = "Nombre";
            this.lblEditNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditNombre
            // 
            this.txtEditNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditNombre.Location = new System.Drawing.Point(324, 27);
            this.txtEditNombre.Name = "txtEditNombre";
            this.txtEditNombre.Size = new System.Drawing.Size(233, 20);
            this.txtEditNombre.TabIndex = 3;
            // 
            // lblEditApellido
            // 
            this.lblEditApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditApellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditApellido.Location = new System.Drawing.Point(21, 60);
            this.lblEditApellido.Name = "lblEditApellido";
            this.lblEditApellido.Size = new System.Drawing.Size(73, 20);
            this.lblEditApellido.TabIndex = 4;
            this.lblEditApellido.Text = "Apellido";
            this.lblEditApellido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditApellido
            // 
            this.txtEditApellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditApellido.Location = new System.Drawing.Point(100, 60);
            this.txtEditApellido.Name = "txtEditApellido";
            this.txtEditApellido.Size = new System.Drawing.Size(137, 20);
            this.txtEditApellido.TabIndex = 5;
            // 
            // lblEditDireccion
            // 
            this.lblEditDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditDireccion.Location = new System.Drawing.Point(248, 60);
            this.lblEditDireccion.Name = "lblEditDireccion";
            this.lblEditDireccion.Size = new System.Drawing.Size(70, 20);
            this.lblEditDireccion.TabIndex = 6;
            this.lblEditDireccion.Text = "Dirección";
            this.lblEditDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditDireccion
            // 
            this.txtEditDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditDireccion.Location = new System.Drawing.Point(324, 60);
            this.txtEditDireccion.Name = "txtEditDireccion";
            this.txtEditDireccion.Size = new System.Drawing.Size(233, 20);
            this.txtEditDireccion.TabIndex = 7;
            // 
            // lblEditTelefono
            // 
            this.lblEditTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditTelefono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditTelefono.Location = new System.Drawing.Point(21, 93);
            this.lblEditTelefono.Name = "lblEditTelefono";
            this.lblEditTelefono.Size = new System.Drawing.Size(73, 20);
            this.lblEditTelefono.TabIndex = 8;
            this.lblEditTelefono.Text = "Teléfono";
            this.lblEditTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditTelefono
            // 
            this.txtEditTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditTelefono.Location = new System.Drawing.Point(100, 93);
            this.txtEditTelefono.Name = "txtEditTelefono";
            this.txtEditTelefono.Size = new System.Drawing.Size(137, 20);
            this.txtEditTelefono.TabIndex = 9;
            // 
            // lblEditEmail
            // 
            this.lblEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditEmail.Location = new System.Drawing.Point(248, 93);
            this.lblEditEmail.Name = "lblEditEmail";
            this.lblEditEmail.Size = new System.Drawing.Size(70, 20);
            this.lblEditEmail.TabIndex = 10;
            this.lblEditEmail.Text = "Email";
            this.lblEditEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditEmail
            // 
            this.txtEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditEmail.Location = new System.Drawing.Point(324, 93);
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.Size = new System.Drawing.Size(233, 20);
            this.txtEditEmail.TabIndex = 11;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGuardarCambios.Location = new System.Drawing.Point(602, 72);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(140, 32);
            this.btnGuardarCambios.TabIndex = 12;
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
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar cliente";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSalir.Location = new System.Drawing.Point(632, 404);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(140, 32);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormCrearCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 447);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSalir);
            this.Name = "FormCrearCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Gestionar Clientes";
            this.Load += new System.EventHandler(this.FormCrearCliente_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCargar.ResumeLayout(false);
            this.datosDelCliente.ResumeLayout(false);
            this.datosDelCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientesCargados)).EndInit();
            this.tabEditar.ResumeLayout(false);
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.grpEditar.ResumeLayout(false);
            this.grpEditar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCargar;
        private System.Windows.Forms.TabPage tabEditar;
        // Tab 1
        private System.Windows.Forms.GroupBox datosDelCliente;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnIngresarCliente;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvClientesCargados;
        // Tab 2
        private System.Windows.Forms.GroupBox grpBuscar;
        private System.Windows.Forms.Label lblBuscarDni;
        private System.Windows.Forms.TextBox txtBuscarDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.GroupBox grpEditar;
        private System.Windows.Forms.Label lblEditDni;
        private System.Windows.Forms.TextBox txtEditDni;
        private System.Windows.Forms.Label lblEditNombre;
        private System.Windows.Forms.TextBox txtEditNombre;
        private System.Windows.Forms.Label lblEditApellido;
        private System.Windows.Forms.TextBox txtEditApellido;
        private System.Windows.Forms.Label lblEditDireccion;
        private System.Windows.Forms.TextBox txtEditDireccion;
        private System.Windows.Forms.Label lblEditTelefono;
        private System.Windows.Forms.TextBox txtEditTelefono;
        private System.Windows.Forms.Label lblEditEmail;
        private System.Windows.Forms.TextBox txtEditEmail;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminar;
        // Global
        private System.Windows.Forms.Button btnSalir;
    }
}
