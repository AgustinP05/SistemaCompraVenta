namespace UI.SistemaCompraVentas
{
    partial class FormCrearProveedor
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
            this.datosDelProveedor = new System.Windows.Forms.GroupBox();
            this.lblCuit = new System.Windows.Forms.Label();
            this.txtCuit = new System.Windows.Forms.TextBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.btnIngresarProveedor = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvProveedoresCargados = new System.Windows.Forms.DataGridView();
            this.tabEditar = new System.Windows.Forms.TabPage();
            this.grpBuscar = new System.Windows.Forms.GroupBox();
            this.lblBuscarCuit = new System.Windows.Forms.Label();
            this.txtBuscarCuit = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvProveedores = new System.Windows.Forms.DataGridView();
            this.grpEditar = new System.Windows.Forms.GroupBox();
            this.lblEditCuit = new System.Windows.Forms.Label();
            this.txtEditCuit = new System.Windows.Forms.TextBox();
            this.lblEditRazonSocial = new System.Windows.Forms.Label();
            this.txtEditRazonSocial = new System.Windows.Forms.TextBox();
            this.lblEditTelefono = new System.Windows.Forms.Label();
            this.txtEditTelefono = new System.Windows.Forms.TextBox();
            this.lblEditEmail = new System.Windows.Forms.Label();
            this.txtEditEmail = new System.Windows.Forms.TextBox();
            this.lblEditDireccion = new System.Windows.Forms.Label();
            this.txtEditDireccion = new System.Windows.Forms.TextBox();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabCargar.SuspendLayout();
            this.datosDelProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedoresCargados)).BeginInit();
            this.tabEditar.SuspendLayout();
            this.grpBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).BeginInit();
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
            this.tabCargar.Controls.Add(this.datosDelProveedor);
            this.tabCargar.Controls.Add(this.dgvProveedoresCargados);
            this.tabCargar.Location = new System.Drawing.Point(4, 22);
            this.tabCargar.Name = "tabCargar";
            this.tabCargar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCargar.Size = new System.Drawing.Size(776, 372);
            this.tabCargar.TabIndex = 0;
            this.tabCargar.Text = "Cargar Proveedor";
            this.tabCargar.UseVisualStyleBackColor = true;
            // 
            // datosDelProveedor
            // 
            this.datosDelProveedor.Controls.Add(this.lblCuit);
            this.datosDelProveedor.Controls.Add(this.txtCuit);
            this.datosDelProveedor.Controls.Add(this.lblRazonSocial);
            this.datosDelProveedor.Controls.Add(this.txtRazonSocial);
            this.datosDelProveedor.Controls.Add(this.lblTelefono);
            this.datosDelProveedor.Controls.Add(this.txtTelefono);
            this.datosDelProveedor.Controls.Add(this.lblEmail);
            this.datosDelProveedor.Controls.Add(this.txtEmail);
            this.datosDelProveedor.Controls.Add(this.lblDireccion);
            this.datosDelProveedor.Controls.Add(this.txtDireccion);
            this.datosDelProveedor.Controls.Add(this.btnIngresarProveedor);
            this.datosDelProveedor.Controls.Add(this.btnCancelar);
            this.datosDelProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.datosDelProveedor.Location = new System.Drawing.Point(8, 8);
            this.datosDelProveedor.Name = "datosDelProveedor";
            this.datosDelProveedor.Size = new System.Drawing.Size(760, 139);
            this.datosDelProveedor.TabIndex = 0;
            this.datosDelProveedor.TabStop = false;
            this.datosDelProveedor.Text = "Datos del Proveedor";
            // 
            // lblCuit
            // 
            this.lblCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCuit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCuit.Location = new System.Drawing.Point(21, 27);
            this.lblCuit.Name = "lblCuit";
            this.lblCuit.Size = new System.Drawing.Size(73, 20);
            this.lblCuit.TabIndex = 0;
            this.lblCuit.Text = "CUIT";
            this.lblCuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCuit
            // 
            this.txtCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCuit.Location = new System.Drawing.Point(100, 27);
            this.txtCuit.Name = "txtCuit";
            this.txtCuit.Size = new System.Drawing.Size(137, 20);
            this.txtCuit.TabIndex = 1;
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblRazonSocial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblRazonSocial.Location = new System.Drawing.Point(248, 27);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(99, 20);
            this.lblRazonSocial.TabIndex = 2;
            this.lblRazonSocial.Text = "Razón Social";
            this.lblRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtRazonSocial.Location = new System.Drawing.Point(353, 27);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(204, 20);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTelefono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTelefono.Location = new System.Drawing.Point(21, 60);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(73, 20);
            this.lblTelefono.TabIndex = 4;
            this.lblTelefono.Text = "Teléfono";
            this.lblTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtTelefono.Location = new System.Drawing.Point(100, 60);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(137, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEmail.Location = new System.Drawing.Point(248, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(99, 20);
            this.lblEmail.TabIndex = 6;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEmail.Location = new System.Drawing.Point(353, 60);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(204, 20);
            this.txtEmail.TabIndex = 7;
            // 
            // lblDireccion
            // 
            this.lblDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDireccion.Location = new System.Drawing.Point(21, 93);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(73, 20);
            this.lblDireccion.TabIndex = 8;
            this.lblDireccion.Text = "Dirección";
            this.lblDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtDireccion.Location = new System.Drawing.Point(100, 93);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(457, 20);
            this.txtDireccion.TabIndex = 9;
            // 
            // btnIngresarProveedor
            // 
            this.btnIngresarProveedor.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIngresarProveedor.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnIngresarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnIngresarProveedor.Location = new System.Drawing.Point(600, 81);
            this.btnIngresarProveedor.Name = "btnIngresarProveedor";
            this.btnIngresarProveedor.Size = new System.Drawing.Size(140, 32);
            this.btnIngresarProveedor.TabIndex = 10;
            this.btnIngresarProveedor.Text = "Ingresar proveedor";
            this.btnIngresarProveedor.UseVisualStyleBackColor = false;
            this.btnIngresarProveedor.Click += new System.EventHandler(this.btnIngresarProveedor_Click);
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
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Limpiar campos";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dgvProveedoresCargados
            // 
            this.dgvProveedoresCargados.AllowUserToAddRows = false;
            this.dgvProveedoresCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedoresCargados.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProveedoresCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedoresCargados.Location = new System.Drawing.Point(8, 153);
            this.dgvProveedoresCargados.Name = "dgvProveedoresCargados";
            this.dgvProveedoresCargados.ReadOnly = true;
            this.dgvProveedoresCargados.Size = new System.Drawing.Size(760, 213);
            this.dgvProveedoresCargados.TabIndex = 12;
            // 
            // tabEditar
            // 
            this.tabEditar.Controls.Add(this.grpBuscar);
            this.tabEditar.Controls.Add(this.dgvProveedores);
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
            this.grpBuscar.Controls.Add(this.lblBuscarCuit);
            this.grpBuscar.Controls.Add(this.txtBuscarCuit);
            this.grpBuscar.Controls.Add(this.btnBuscar);
            this.grpBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpBuscar.Location = new System.Drawing.Point(8, 8);
            this.grpBuscar.Name = "grpBuscar";
            this.grpBuscar.Size = new System.Drawing.Size(760, 55);
            this.grpBuscar.TabIndex = 0;
            this.grpBuscar.TabStop = false;
            this.grpBuscar.Text = "Buscar proveedor";
            // 
            // lblBuscarCuit
            // 
            this.lblBuscarCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblBuscarCuit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBuscarCuit.Location = new System.Drawing.Point(21, 20);
            this.lblBuscarCuit.Name = "lblBuscarCuit";
            this.lblBuscarCuit.Size = new System.Drawing.Size(73, 20);
            this.lblBuscarCuit.TabIndex = 0;
            this.lblBuscarCuit.Text = "CUIT";
            this.lblBuscarCuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBuscarCuit
            // 
            this.txtBuscarCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtBuscarCuit.Location = new System.Drawing.Point(100, 20);
            this.txtBuscarCuit.Name = "txtBuscarCuit";
            this.txtBuscarCuit.Size = new System.Drawing.Size(200, 20);
            this.txtBuscarCuit.TabIndex = 1;
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
            // dgvProveedores
            // 
            this.dgvProveedores.AllowUserToAddRows = false;
            this.dgvProveedores.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProveedores.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvProveedores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProveedores.Location = new System.Drawing.Point(8, 70);
            this.dgvProveedores.MultiSelect = false;
            this.dgvProveedores.Name = "dgvProveedores";
            this.dgvProveedores.ReadOnly = true;
            this.dgvProveedores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProveedores.Size = new System.Drawing.Size(760, 155);
            this.dgvProveedores.TabIndex = 1;
            this.dgvProveedores.SelectionChanged += new System.EventHandler(this.dgvProveedores_SelectionChanged);
            // 
            // grpEditar
            // 
            this.grpEditar.Controls.Add(this.lblEditCuit);
            this.grpEditar.Controls.Add(this.txtEditCuit);
            this.grpEditar.Controls.Add(this.lblEditRazonSocial);
            this.grpEditar.Controls.Add(this.txtEditRazonSocial);
            this.grpEditar.Controls.Add(this.lblEditTelefono);
            this.grpEditar.Controls.Add(this.txtEditTelefono);
            this.grpEditar.Controls.Add(this.lblEditEmail);
            this.grpEditar.Controls.Add(this.txtEditEmail);
            this.grpEditar.Controls.Add(this.lblEditDireccion);
            this.grpEditar.Controls.Add(this.txtEditDireccion);
            this.grpEditar.Controls.Add(this.btnGuardarCambios);
            this.grpEditar.Controls.Add(this.btnEliminar);
            this.grpEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpEditar.Location = new System.Drawing.Point(8, 232);
            this.grpEditar.Name = "grpEditar";
            this.grpEditar.Size = new System.Drawing.Size(760, 133);
            this.grpEditar.TabIndex = 2;
            this.grpEditar.TabStop = false;
            this.grpEditar.Text = "Modificar datos del proveedor seleccionado";
            // 
            // lblEditCuit
            // 
            this.lblEditCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditCuit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditCuit.Location = new System.Drawing.Point(21, 27);
            this.lblEditCuit.Name = "lblEditCuit";
            this.lblEditCuit.Size = new System.Drawing.Size(73, 20);
            this.lblEditCuit.TabIndex = 0;
            this.lblEditCuit.Text = "CUIT";
            this.lblEditCuit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditCuit
            // 
            this.txtEditCuit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtEditCuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditCuit.Location = new System.Drawing.Point(100, 27);
            this.txtEditCuit.Name = "txtEditCuit";
            this.txtEditCuit.ReadOnly = true;
            this.txtEditCuit.Size = new System.Drawing.Size(137, 20);
            this.txtEditCuit.TabIndex = 1;
            // 
            // lblEditRazonSocial
            // 
            this.lblEditRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditRazonSocial.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditRazonSocial.Location = new System.Drawing.Point(248, 27);
            this.lblEditRazonSocial.Name = "lblEditRazonSocial";
            this.lblEditRazonSocial.Size = new System.Drawing.Size(96, 20);
            this.lblEditRazonSocial.TabIndex = 2;
            this.lblEditRazonSocial.Text = "Razón Social";
            this.lblEditRazonSocial.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditRazonSocial
            // 
            this.txtEditRazonSocial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditRazonSocial.Location = new System.Drawing.Point(350, 27);
            this.txtEditRazonSocial.Name = "txtEditRazonSocial";
            this.txtEditRazonSocial.Size = new System.Drawing.Size(207, 20);
            this.txtEditRazonSocial.TabIndex = 3;
            // 
            // lblEditTelefono
            // 
            this.lblEditTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditTelefono.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditTelefono.Location = new System.Drawing.Point(21, 60);
            this.lblEditTelefono.Name = "lblEditTelefono";
            this.lblEditTelefono.Size = new System.Drawing.Size(73, 20);
            this.lblEditTelefono.TabIndex = 4;
            this.lblEditTelefono.Text = "Teléfono";
            this.lblEditTelefono.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditTelefono
            // 
            this.txtEditTelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditTelefono.Location = new System.Drawing.Point(100, 60);
            this.txtEditTelefono.Name = "txtEditTelefono";
            this.txtEditTelefono.Size = new System.Drawing.Size(137, 20);
            this.txtEditTelefono.TabIndex = 5;
            // 
            // lblEditEmail
            // 
            this.lblEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditEmail.Location = new System.Drawing.Point(248, 60);
            this.lblEditEmail.Name = "lblEditEmail";
            this.lblEditEmail.Size = new System.Drawing.Size(96, 20);
            this.lblEditEmail.TabIndex = 6;
            this.lblEditEmail.Text = "Email";
            this.lblEditEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditEmail
            // 
            this.txtEditEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditEmail.Location = new System.Drawing.Point(350, 60);
            this.txtEditEmail.Name = "txtEditEmail";
            this.txtEditEmail.Size = new System.Drawing.Size(207, 20);
            this.txtEditEmail.TabIndex = 7;
            // 
            // lblEditDireccion
            // 
            this.lblEditDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditDireccion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditDireccion.Location = new System.Drawing.Point(21, 93);
            this.lblEditDireccion.Name = "lblEditDireccion";
            this.lblEditDireccion.Size = new System.Drawing.Size(73, 20);
            this.lblEditDireccion.TabIndex = 8;
            this.lblEditDireccion.Text = "Dirección";
            this.lblEditDireccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditDireccion
            // 
            this.txtEditDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtEditDireccion.Location = new System.Drawing.Point(100, 93);
            this.txtEditDireccion.Name = "txtEditDireccion";
            this.txtEditDireccion.Size = new System.Drawing.Size(457, 20);
            this.txtEditDireccion.TabIndex = 9;
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
            this.btnGuardarCambios.TabIndex = 10;
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
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar proveedor";
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
            // FormCrearProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(784, 447);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSalir);
            this.Name = "FormCrearProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Gestionar Proveedores";
            this.Load += new System.EventHandler(this.FormCrearProveedor_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCargar.ResumeLayout(false);
            this.datosDelProveedor.ResumeLayout(false);
            this.datosDelProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedoresCargados)).EndInit();
            this.tabEditar.ResumeLayout(false);
            this.grpBuscar.ResumeLayout(false);
            this.grpBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProveedores)).EndInit();
            this.grpEditar.ResumeLayout(false);
            this.grpEditar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCargar;
        private System.Windows.Forms.TabPage tabEditar;
        // Tab 1
        private System.Windows.Forms.GroupBox datosDelProveedor;
        private System.Windows.Forms.Label lblCuit;
        private System.Windows.Forms.TextBox txtCuit;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnIngresarProveedor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvProveedoresCargados;
        // Tab 2
        private System.Windows.Forms.GroupBox grpBuscar;
        private System.Windows.Forms.Label lblBuscarCuit;
        private System.Windows.Forms.TextBox txtBuscarCuit;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.GroupBox grpEditar;
        private System.Windows.Forms.Label lblEditCuit;
        private System.Windows.Forms.TextBox txtEditCuit;
        private System.Windows.Forms.Label lblEditRazonSocial;
        private System.Windows.Forms.TextBox txtEditRazonSocial;
        private System.Windows.Forms.Label lblEditTelefono;
        private System.Windows.Forms.TextBox txtEditTelefono;
        private System.Windows.Forms.Label lblEditEmail;
        private System.Windows.Forms.TextBox txtEditEmail;
        private System.Windows.Forms.Label lblEditDireccion;
        private System.Windows.Forms.TextBox txtEditDireccion;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminar;
        // Global
        private System.Windows.Forms.Button btnSalir;
    }
}
