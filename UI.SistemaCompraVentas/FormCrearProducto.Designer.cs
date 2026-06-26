namespace UI.SistemaCompraVentas
{
    partial class FormCrearProducto
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCrear = new System.Windows.Forms.TabPage();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.btnNuevaMarca = new System.Windows.Forms.Button();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.nmPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.lblPrecioCosto = new System.Windows.Forms.Label();
            this.nmPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblCargados = new System.Windows.Forms.Label();
            this.dgvProductosCargados = new System.Windows.Forms.DataGridView();
            this.tabBuscar = new System.Windows.Forms.TabPage();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.lblEditNombre = new System.Windows.Forms.Label();
            this.txtEditNombre = new System.Windows.Forms.TextBox();
            this.lblEditMarca = new System.Windows.Forms.Label();
            this.cboEditMarca = new System.Windows.Forms.ComboBox();
            this.lblEditCategoria = new System.Windows.Forms.Label();
            this.txtEditCategoria = new System.Windows.Forms.TextBox();
            this.lblEditPrecioVenta = new System.Windows.Forms.Label();
            this.nmEditPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.lblEditPrecioCosto = new System.Windows.Forms.Label();
            this.nmEditPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.btnGuardarCambios = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.tabVariante = new System.Windows.Forms.TabPage();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.lblTalle = new System.Windows.Forms.Label();
            this.cboTalle = new System.Windows.Forms.ComboBox();
            this.lblInfoStock = new System.Windows.Forms.Label();
            this.btnCrearVariante = new System.Windows.Forms.Button();
            this.lblVariantes = new System.Windows.Forms.Label();
            this.dgvVariantes = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl.SuspendLayout();
            this.tabCrear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosCargados)).BeginInit();
            this.tabBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmEditPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmEditPrecioCosto)).BeginInit();
            this.tabVariante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariantes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCrear);
            this.tabControl.Controls.Add(this.tabBuscar);
            this.tabControl.Controls.Add(this.tabVariante);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(796, 420);
            this.tabControl.TabIndex = 0;
            // 
            // tabCrear
            // 
            this.tabCrear.Controls.Add(this.groupBox1);
            this.tabCrear.Location = new System.Drawing.Point(4, 22);
            this.tabCrear.Name = "tabCrear";
            this.tabCrear.Padding = new System.Windows.Forms.Padding(3);
            this.tabCrear.Size = new System.Drawing.Size(788, 394);
            this.tabCrear.TabIndex = 0;
            this.tabCrear.Text = "Crear Producto";
            this.tabCrear.UseVisualStyleBackColor = true;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNombre.Location = new System.Drawing.Point(42, 28);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(59, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 24);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblMarca.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblMarca.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMarca.Location = new System.Drawing.Point(362, 59);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(48, 16);
            this.lblMarca.TabIndex = 2;
            this.lblMarca.Text = "Marca:";
            this.lblMarca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(416, 55);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(201, 21);
            this.cboMarca.TabIndex = 3;
            // 
            // btnNuevaMarca
            // 
            this.btnNuevaMarca.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNuevaMarca.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnNuevaMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaMarca.Location = new System.Drawing.Point(627, 51);
            this.btnNuevaMarca.Name = "btnNuevaMarca";
            this.btnNuevaMarca.Size = new System.Drawing.Size(109, 25);
            this.btnNuevaMarca.TabIndex = 4;
            this.btnNuevaMarca.Text = "Nueva marca…";
            this.btnNuevaMarca.UseVisualStyleBackColor = false;
            this.btnNuevaMarca.Click += new System.EventHandler(this.btnNuevaMarca_Click);
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCategoria.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCategoria.Location = new System.Drawing.Point(32, 59);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(69, 16);
            this.lblCategoria.TabIndex = 5;
            this.lblCategoria.Text = "Categoría:";
            this.lblCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(107, 54);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(240, 21);
            this.cboCategoria.TabIndex = 6;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPrecioVenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPrecioVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPrecioVenta.Location = new System.Drawing.Point(17, 112);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(85, 16);
            this.lblPrecioVenta.TabIndex = 7;
            this.lblPrecioVenta.Text = "Precio venta:";
            this.lblPrecioVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmPrecioVenta
            // 
            this.nmPrecioVenta.DecimalPlaces = 2;
            this.nmPrecioVenta.Location = new System.Drawing.Point(108, 110);
            this.nmPrecioVenta.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmPrecioVenta.Name = "nmPrecioVenta";
            this.nmPrecioVenta.Size = new System.Drawing.Size(126, 20);
            this.nmPrecioVenta.TabIndex = 8;
            this.nmPrecioVenta.ThousandsSeparator = true;
            // 
            // lblPrecioCosto
            // 
            this.lblPrecioCosto.AutoSize = true;
            this.lblPrecioCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblPrecioCosto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPrecioCosto.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPrecioCosto.Location = new System.Drawing.Point(259, 112);
            this.lblPrecioCosto.Name = "lblPrecioCosto";
            this.lblPrecioCosto.Size = new System.Drawing.Size(85, 16);
            this.lblPrecioCosto.TabIndex = 9;
            this.lblPrecioCosto.Text = "Precio costo:";
            this.lblPrecioCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmPrecioCosto
            // 
            this.nmPrecioCosto.DecimalPlaces = 2;
            this.nmPrecioCosto.Location = new System.Drawing.Point(354, 110);
            this.nmPrecioCosto.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmPrecioCosto.Name = "nmPrecioCosto";
            this.nmPrecioCosto.Size = new System.Drawing.Size(126, 20);
            this.nmPrecioCosto.TabIndex = 10;
            this.nmPrecioCosto.ThousandsSeparator = true;
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Location = new System.Drawing.Point(497, 104);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(120, 32);
            this.btnIngresar.TabIndex = 11;
            this.btnIngresar.Text = "Crear producto";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(627, 104);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(110, 32);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblCargados
            // 
            this.lblCargados.AutoSize = true;
            this.lblCargados.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F);
            this.lblCargados.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCargados.Location = new System.Drawing.Point(16, 158);
            this.lblCargados.Name = "lblCargados";
            this.lblCargados.Size = new System.Drawing.Size(194, 15);
            this.lblCargados.TabIndex = 13;
            this.lblCargados.Text = "Productos creados en esta sesión:";
            // 
            // dgvProductosCargados
            // 
            this.dgvProductosCargados.AllowUserToAddRows = false;
            this.dgvProductosCargados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductosCargados.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvProductosCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductosCargados.Location = new System.Drawing.Point(16, 176);
            this.dgvProductosCargados.Name = "dgvProductosCargados";
            this.dgvProductosCargados.ReadOnly = true;
            this.dgvProductosCargados.RowHeadersWidth = 51;
            this.dgvProductosCargados.Size = new System.Drawing.Size(720, 180);
            this.dgvProductosCargados.TabIndex = 14;
            // 
            // tabBuscar
            // 
            this.tabBuscar.Controls.Add(this.groupBox2);
            this.tabBuscar.Controls.Add(this.lblBuscar);
            this.tabBuscar.Controls.Add(this.txtBuscar);
            this.tabBuscar.Controls.Add(this.btnBuscar);
            this.tabBuscar.Controls.Add(this.dgvProductos);
            this.tabBuscar.Location = new System.Drawing.Point(4, 22);
            this.tabBuscar.Name = "tabBuscar";
            this.tabBuscar.Padding = new System.Windows.Forms.Padding(3);
            this.tabBuscar.Size = new System.Drawing.Size(788, 394);
            this.tabBuscar.TabIndex = 1;
            this.tabBuscar.Text = "Buscar / Editar";
            this.tabBuscar.UseVisualStyleBackColor = true;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblBuscar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblBuscar.Location = new System.Drawing.Point(20, 17);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(180, 16);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar (ID, nombre o marca):";
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(211, 18);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(250, 20);
            this.txtBuscar.TabIndex = 1;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(471, 16);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 26);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(20, 51);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.RowHeadersWidth = 51;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(748, 188);
            this.dgvProductos.TabIndex = 3;
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // lblEditNombre
            // 
            this.lblEditNombre.AutoSize = true;
            this.lblEditNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditNombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditNombre.Location = new System.Drawing.Point(25, 21);
            this.lblEditNombre.Name = "lblEditNombre";
            this.lblEditNombre.Size = new System.Drawing.Size(59, 16);
            this.lblEditNombre.TabIndex = 4;
            this.lblEditNombre.Text = "Nombre:";
            this.lblEditNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditNombre
            // 
            this.txtEditNombre.Location = new System.Drawing.Point(90, 19);
            this.txtEditNombre.Name = "txtEditNombre";
            this.txtEditNombre.Size = new System.Drawing.Size(240, 20);
            this.txtEditNombre.TabIndex = 5;
            // 
            // lblEditMarca
            // 
            this.lblEditMarca.AutoSize = true;
            this.lblEditMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditMarca.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditMarca.Location = new System.Drawing.Point(36, 56);
            this.lblEditMarca.Name = "lblEditMarca";
            this.lblEditMarca.Size = new System.Drawing.Size(48, 16);
            this.lblEditMarca.TabIndex = 6;
            this.lblEditMarca.Text = "Marca:";
            this.lblEditMarca.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboEditMarca
            // 
            this.cboEditMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEditMarca.FormattingEnabled = true;
            this.cboEditMarca.Location = new System.Drawing.Point(90, 54);
            this.cboEditMarca.Name = "cboEditMarca";
            this.cboEditMarca.Size = new System.Drawing.Size(240, 21);
            this.cboEditMarca.TabIndex = 7;
            // 
            // lblEditCategoria
            // 
            this.lblEditCategoria.AutoSize = true;
            this.lblEditCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditCategoria.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditCategoria.Location = new System.Drawing.Point(15, 91);
            this.lblEditCategoria.Name = "lblEditCategoria";
            this.lblEditCategoria.Size = new System.Drawing.Size(69, 16);
            this.lblEditCategoria.TabIndex = 8;
            this.lblEditCategoria.Text = "Categoría:";
            this.lblEditCategoria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEditCategoria
            // 
            this.txtEditCategoria.Location = new System.Drawing.Point(90, 89);
            this.txtEditCategoria.Name = "txtEditCategoria";
            this.txtEditCategoria.ReadOnly = true;
            this.txtEditCategoria.Size = new System.Drawing.Size(240, 20);
            this.txtEditCategoria.TabIndex = 9;
            this.txtEditCategoria.TabStop = false;
            // 
            // lblEditPrecioVenta
            // 
            this.lblEditPrecioVenta.AutoSize = true;
            this.lblEditPrecioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditPrecioVenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditPrecioVenta.Location = new System.Drawing.Point(375, 21);
            this.lblEditPrecioVenta.Name = "lblEditPrecioVenta";
            this.lblEditPrecioVenta.Size = new System.Drawing.Size(85, 16);
            this.lblEditPrecioVenta.TabIndex = 10;
            this.lblEditPrecioVenta.Text = "Precio venta:";
            this.lblEditPrecioVenta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmEditPrecioVenta
            // 
            this.nmEditPrecioVenta.DecimalPlaces = 2;
            this.nmEditPrecioVenta.Location = new System.Drawing.Point(481, 17);
            this.nmEditPrecioVenta.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmEditPrecioVenta.Name = "nmEditPrecioVenta";
            this.nmEditPrecioVenta.Size = new System.Drawing.Size(220, 20);
            this.nmEditPrecioVenta.TabIndex = 11;
            this.nmEditPrecioVenta.ThousandsSeparator = true;
            // 
            // lblEditPrecioCosto
            // 
            this.lblEditPrecioCosto.AutoSize = true;
            this.lblEditPrecioCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblEditPrecioCosto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblEditPrecioCosto.Location = new System.Drawing.Point(375, 56);
            this.lblEditPrecioCosto.Name = "lblEditPrecioCosto";
            this.lblEditPrecioCosto.Size = new System.Drawing.Size(85, 16);
            this.lblEditPrecioCosto.TabIndex = 12;
            this.lblEditPrecioCosto.Text = "Precio costo:";
            this.lblEditPrecioCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmEditPrecioCosto
            // 
            this.nmEditPrecioCosto.DecimalPlaces = 2;
            this.nmEditPrecioCosto.Location = new System.Drawing.Point(481, 52);
            this.nmEditPrecioCosto.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nmEditPrecioCosto.Name = "nmEditPrecioCosto";
            this.nmEditPrecioCosto.Size = new System.Drawing.Size(220, 20);
            this.nmEditPrecioCosto.TabIndex = 13;
            this.nmEditPrecioCosto.ThousandsSeparator = true;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGuardarCambios.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGuardarCambios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarCambios.Location = new System.Drawing.Point(481, 84);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.Size = new System.Drawing.Size(120, 30);
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
            this.btnEliminar.Location = new System.Drawing.Point(607, 84);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(94, 30);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tabVariante
            // 
            this.tabVariante.Controls.Add(this.lblProducto);
            this.tabVariante.Controls.Add(this.txtIdProducto);
            this.tabVariante.Controls.Add(this.btnBuscarProducto);
            this.tabVariante.Controls.Add(this.lblProductoNombre);
            this.tabVariante.Controls.Add(this.lblColor);
            this.tabVariante.Controls.Add(this.cboColor);
            this.tabVariante.Controls.Add(this.lblTalle);
            this.tabVariante.Controls.Add(this.cboTalle);
            this.tabVariante.Controls.Add(this.lblInfoStock);
            this.tabVariante.Controls.Add(this.btnCrearVariante);
            this.tabVariante.Controls.Add(this.lblVariantes);
            this.tabVariante.Controls.Add(this.dgvVariantes);
            this.tabVariante.Location = new System.Drawing.Point(4, 22);
            this.tabVariante.Name = "tabVariante";
            this.tabVariante.Padding = new System.Windows.Forms.Padding(3);
            this.tabVariante.Size = new System.Drawing.Size(788, 394);
            this.tabVariante.TabIndex = 2;
            this.tabVariante.Text = "Crear Variante (SKU)";
            this.tabVariante.UseVisualStyleBackColor = true;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProducto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblProducto.Location = new System.Drawing.Point(54, 27);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(80, 16);
            this.lblProducto.TabIndex = 0;
            this.lblProducto.Text = "ID Producto:";
            this.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(140, 25);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.Size = new System.Drawing.Size(100, 20);
            this.txtIdProducto.TabIndex = 1;
            this.txtIdProducto.TextChanged += new System.EventHandler(this.txtIdProducto_TextChanged);
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBuscarProducto.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscarProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarProducto.Location = new System.Drawing.Point(250, 23);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(130, 25);
            this.btnBuscarProducto.TabIndex = 2;
            this.btnBuscarProducto.Text = "Buscar producto";
            this.btnBuscarProducto.UseVisualStyleBackColor = false;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.AutoSize = true;
            this.lblProductoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lblProductoNombre.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblProductoNombre.Location = new System.Drawing.Point(390, 27);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new System.Drawing.Size(71, 16);
            this.lblProductoNombre.TabIndex = 3;
            this.lblProductoNombre.Text = "Producto: -";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblColor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblColor.Location = new System.Drawing.Point(92, 68);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(42, 16);
            this.lblColor.TabIndex = 4;
            this.lblColor.Text = "Color:";
            this.lblColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboColor
            // 
            this.cboColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(140, 63);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(200, 21);
            this.cboColor.TabIndex = 5;
            // 
            // lblTalle
            // 
            this.lblTalle.AutoSize = true;
            this.lblTalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTalle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTalle.Location = new System.Drawing.Point(370, 64);
            this.lblTalle.Name = "lblTalle";
            this.lblTalle.Size = new System.Drawing.Size(41, 16);
            this.lblTalle.TabIndex = 6;
            this.lblTalle.Text = "Talle:";
            this.lblTalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboTalle
            // 
            this.cboTalle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTalle.FormattingEnabled = true;
            this.cboTalle.Location = new System.Drawing.Point(417, 63);
            this.cboTalle.Name = "cboTalle";
            this.cboTalle.Size = new System.Drawing.Size(200, 21);
            this.cboTalle.TabIndex = 7;
            // 
            // lblInfoStock
            // 
            this.lblInfoStock.AutoSize = true;
            this.lblInfoStock.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblInfoStock.Location = new System.Drawing.Point(231, 114);
            this.lblInfoStock.Name = "lblInfoStock";
            this.lblInfoStock.Size = new System.Drawing.Size(230, 13);
            this.lblInfoStock.TabIndex = 8;
            this.lblInfoStock.Text = "El stock de la nueva variante (SKU) inicia en 0.";
            // 
            // btnCrearVariante
            // 
            this.btnCrearVariante.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCrearVariante.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCrearVariante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearVariante.Location = new System.Drawing.Point(261, 141);
            this.btnCrearVariante.Name = "btnCrearVariante";
            this.btnCrearVariante.Size = new System.Drawing.Size(160, 32);
            this.btnCrearVariante.TabIndex = 9;
            this.btnCrearVariante.Text = "Crear variante (SKU)";
            this.btnCrearVariante.UseVisualStyleBackColor = false;
            this.btnCrearVariante.Click += new System.EventHandler(this.btnCrearVariante_Click);
            // 
            // lblVariantes
            // 
            this.lblVariantes.AutoSize = true;
            this.lblVariantes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblVariantes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblVariantes.Location = new System.Drawing.Point(21, 200);
            this.lblVariantes.Name = "lblVariantes";
            this.lblVariantes.Size = new System.Drawing.Size(116, 13);
            this.lblVariantes.TabIndex = 10;
            this.lblVariantes.Text = "Variantes del producto:";
            // 
            // dgvVariantes
            // 
            this.dgvVariantes.AllowUserToAddRows = false;
            this.dgvVariantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVariantes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvVariantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVariantes.Location = new System.Drawing.Point(21, 220);
            this.dgvVariantes.MultiSelect = false;
            this.dgvVariantes.Name = "dgvVariantes";
            this.dgvVariantes.ReadOnly = true;
            this.dgvVariantes.RowHeadersWidth = 51;
            this.dgvVariantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVariantes.Size = new System.Drawing.Size(748, 150);
            this.dgvVariantes.TabIndex = 11;
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Location = new System.Drawing.Point(708, 438);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 30);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNombre);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblMarca);
            this.groupBox1.Controls.Add(this.cboMarca);
            this.groupBox1.Controls.Add(this.btnNuevaMarca);
            this.groupBox1.Controls.Add(this.lblCategoria);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Controls.Add(this.lblPrecioVenta);
            this.groupBox1.Controls.Add(this.nmPrecioVenta);
            this.groupBox1.Controls.Add(this.lblPrecioCosto);
            this.groupBox1.Controls.Add(this.nmPrecioCosto);
            this.groupBox1.Controls.Add(this.btnIngresar);
            this.groupBox1.Controls.Add(this.btnCancelar);
            this.groupBox1.Controls.Add(this.lblCargados);
            this.groupBox1.Controls.Add(this.dgvProductosCargados);
            this.groupBox1.Location = new System.Drawing.Point(17, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 371);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inserte los datos del nuevo producto";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEditNombre);
            this.groupBox2.Controls.Add(this.txtEditNombre);
            this.groupBox2.Controls.Add(this.lblEditMarca);
            this.groupBox2.Controls.Add(this.cboEditMarca);
            this.groupBox2.Controls.Add(this.lblEditCategoria);
            this.groupBox2.Controls.Add(this.txtEditCategoria);
            this.groupBox2.Controls.Add(this.lblEditPrecioVenta);
            this.groupBox2.Controls.Add(this.nmEditPrecioVenta);
            this.groupBox2.Controls.Add(this.lblEditPrecioCosto);
            this.groupBox2.Controls.Add(this.nmEditPrecioCosto);
            this.groupBox2.Controls.Add(this.btnGuardarCambios);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Location = new System.Drawing.Point(21, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(747, 130);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Selecciona y edita solo los cambios necesarios";
            // 
            // FormCrearProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 481);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnSalir);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "FormCrearProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Stock";
            this.Load += new System.EventHandler(this.FormCrearProducto_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCrear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductosCargados)).EndInit();
            this.tabBuscar.ResumeLayout(false);
            this.tabBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmEditPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmEditPrecioCosto)).EndInit();
            this.tabVariante.ResumeLayout(false);
            this.tabVariante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVariantes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCrear;
        private System.Windows.Forms.TabPage tabBuscar;
        private System.Windows.Forms.TabPage tabVariante;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.Button btnNuevaMarca;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.NumericUpDown nmPrecioVenta;
        private System.Windows.Forms.Label lblPrecioCosto;
        private System.Windows.Forms.NumericUpDown nmPrecioCosto;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblCargados;
        private System.Windows.Forms.DataGridView dgvProductosCargados;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblEditNombre;
        private System.Windows.Forms.TextBox txtEditNombre;
        private System.Windows.Forms.Label lblEditMarca;
        private System.Windows.Forms.ComboBox cboEditMarca;
        private System.Windows.Forms.Label lblEditCategoria;
        private System.Windows.Forms.TextBox txtEditCategoria;
        private System.Windows.Forms.Label lblEditPrecioVenta;
        private System.Windows.Forms.NumericUpDown nmEditPrecioVenta;
        private System.Windows.Forms.Label lblEditPrecioCosto;
        private System.Windows.Forms.NumericUpDown nmEditPrecioCosto;
        private System.Windows.Forms.Button btnGuardarCambios;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.Label lblProductoNombre;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label lblTalle;
        private System.Windows.Forms.ComboBox cboTalle;
        private System.Windows.Forms.Label lblInfoStock;
        private System.Windows.Forms.Button btnCrearVariante;
        private System.Windows.Forms.Label lblVariantes;
        private System.Windows.Forms.DataGridView dgvVariantes;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}
