namespace UI.SistemaCompraVentas
{
    partial class FormGerente
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
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.categoria = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.txtProducto = new System.Windows.Forms.Label();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.txtVendedor = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.fecha_fin = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.cboAgrupar = new System.Windows.Forms.ComboBox();
            this.lblAgrupar = new System.Windows.Forms.Label();
            this.fecha_inicio = new System.Windows.Forms.Label();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnGenerarExcel = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblFacturado = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.lblTicket = new System.Windows.Forms.Label();
            this.lblUnidades = new System.Windows.Forms.Label();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblFacturadoBruto = new System.Windows.Forms.Label();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblCosto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabReporte = new System.Windows.Forms.TabPage();
            this.tabReclamos = new System.Windows.Forms.TabPage();
            this.dgvReclamos = new System.Windows.Forms.DataGridView();
            this.btnActualizarReclamos = new System.Windows.Forms.Button();
            this.lblReclamosInfo = new System.Windows.Forms.Label();
            this.grpFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.tabReporte.SuspendLayout();
            this.tabReclamos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclamos)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.cboCliente);
            this.grpFiltros.Controls.Add(this.label5);
            this.grpFiltros.Controls.Add(this.cboCategoria);
            this.grpFiltros.Controls.Add(this.categoria);
            this.grpFiltros.Controls.Add(this.cboProducto);
            this.grpFiltros.Controls.Add(this.txtProducto);
            this.grpFiltros.Controls.Add(this.cboVendedor);
            this.grpFiltros.Controls.Add(this.txtVendedor);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.fecha_fin);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.cboAgrupar);
            this.grpFiltros.Controls.Add(this.lblAgrupar);
            this.grpFiltros.Controls.Add(this.fecha_inicio);
            this.grpFiltros.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grpFiltros.Location = new System.Drawing.Point(18, 18);
            this.grpFiltros.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpFiltros.Size = new System.Drawing.Size(998, 191);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtros del Reporte";
            // 
            // cboCliente
            // 
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(718, 64);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(261, 30);
            this.cboCliente.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(713, 35);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Cliente";
            // 
            // cboCategoria
            // 
            this.cboCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(408, 142);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(261, 30);
            this.cboCategoria.TabIndex = 12;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // categoria
            // 
            this.categoria.AutoSize = true;
            this.categoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.categoria.ForeColor = System.Drawing.SystemColors.WindowText;
            this.categoria.Location = new System.Drawing.Point(403, 112);
            this.categoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(97, 25);
            this.categoria.TabIndex = 11;
            this.categoria.Text = "Categoría";
            // 
            // cboProducto
            // 
            this.cboProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(23, 142);
            this.cboProducto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(338, 30);
            this.cboProducto.TabIndex = 10;
            // 
            // txtProducto
            // 
            this.txtProducto.AutoSize = true;
            this.txtProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtProducto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtProducto.Location = new System.Drawing.Point(18, 113);
            this.txtProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(90, 25);
            this.txtProducto.TabIndex = 9;
            this.txtProducto.Text = "Producto";
            // 
            // cboVendedor
            // 
            this.cboVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(408, 64);
            this.cboVendedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(261, 30);
            this.cboVendedor.TabIndex = 6;
            // 
            // txtVendedor
            // 
            this.txtVendedor.AutoSize = true;
            this.txtVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtVendedor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtVendedor.Location = new System.Drawing.Point(403, 34);
            this.txtVendedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(98, 25);
            this.txtVendedor.TabIndex = 5;
            this.txtVendedor.Text = "Vendedor";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(215, 65);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(144, 26);
            this.dtpHasta.TabIndex = 4;
            // 
            // fecha_fin
            // 
            this.fecha_fin.AutoSize = true;
            this.fecha_fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.fecha_fin.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fecha_fin.Location = new System.Drawing.Point(210, 35);
            this.fecha_fin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(120, 25);
            this.fecha_fin.TabIndex = 3;
            this.fecha_fin.Text = "Fecha hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(22, 65);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(144, 26);
            this.dtpDesde.TabIndex = 2;
            // 
            // cboAgrupar
            // 
            this.cboAgrupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.cboAgrupar.FormattingEnabled = true;
            this.cboAgrupar.Location = new System.Drawing.Point(718, 142);
            this.cboAgrupar.Name = "cboAgrupar";
            this.cboAgrupar.Size = new System.Drawing.Size(261, 30);
            this.cboAgrupar.TabIndex = 13;
            this.cboAgrupar.SelectedIndexChanged += new System.EventHandler(this.cboAgrupar_SelectedIndexChanged);
            // 
            // lblAgrupar
            // 
            this.lblAgrupar.AutoSize = true;
            this.lblAgrupar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblAgrupar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblAgrupar.Location = new System.Drawing.Point(713, 113);
            this.lblAgrupar.Name = "lblAgrupar";
            this.lblAgrupar.Size = new System.Drawing.Size(170, 25);
            this.lblAgrupar.TabIndex = 13;
            this.lblAgrupar.Text = "Ver agrupado por:";
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.AutoSize = true;
            this.fecha_inicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.fecha_inicio.ForeColor = System.Drawing.SystemColors.WindowText;
            this.fecha_inicio.Location = new System.Drawing.Point(18, 35);
            this.fecha_inicio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Size = new System.Drawing.Size(126, 25);
            this.fecha_inicio.TabIndex = 1;
            this.fecha_inicio.Text = "Fecha desde";
            this.fecha_inicio.Click += new System.EventHandler(this.fecha_inicio_Click);
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGenerarReporte.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGenerarReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGenerarReporte.Location = new System.Drawing.Point(831, 489);
            this.btnGenerarReporte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(185, 43);
            this.btnGenerarReporte.TabIndex = 9;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = false;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(18, 219);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 24;
            this.dgvReporte.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvReporte.Size = new System.Drawing.Size(998, 260);
            this.dgvReporte.TabIndex = 1;
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnGenerarExcel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnGenerarExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnGenerarExcel.Location = new System.Drawing.Point(23, 667);
            this.btnGenerarExcel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.Size = new System.Drawing.Size(204, 46);
            this.btnGenerarExcel.TabIndex = 11;
            this.btnGenerarExcel.Text = "Exportar a Excel";
            this.btnGenerarExcel.UseVisualStyleBackColor = false;
            this.btnGenerarExcel.Click += new System.EventHandler(this.btnGenerarExcel_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelar.Location = new System.Drawing.Point(817, 667);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(204, 46);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblFacturado
            // 
            this.lblFacturado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFacturado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFacturado.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFacturado.Location = new System.Drawing.Point(3, 22);
            this.lblFacturado.Name = "lblFacturado";
            this.lblFacturado.Size = new System.Drawing.Size(167, 53);
            this.lblFacturado.TabIndex = 0;
            this.lblFacturado.Text = "Facturado neto";
            this.lblFacturado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblGanancia
            // 
            this.lblGanancia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGanancia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblGanancia.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblGanancia.Location = new System.Drawing.Point(3, 22);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(167, 53);
            this.lblGanancia.TabIndex = 0;
            this.lblGanancia.Text = "Ganancia neta";
            this.lblGanancia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTicket
            // 
            this.lblTicket.AutoSize = true;
            this.lblTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTicket.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTicket.Location = new System.Drawing.Point(23, 484);
            this.lblTicket.Name = "lblTicket";
            this.lblTicket.Size = new System.Drawing.Size(151, 25);
            this.lblTicket.TabIndex = 2;
            this.lblTicket.Text = "Ticket promedio";
            this.lblTicket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUnidades
            // 
            this.lblUnidades.AutoSize = true;
            this.lblUnidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblUnidades.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblUnidades.Location = new System.Drawing.Point(23, 538);
            this.lblUnidades.Name = "lblUnidades";
            this.lblUnidades.Size = new System.Drawing.Size(172, 25);
            this.lblUnidades.TabIndex = 4;
            this.lblUnidades.Text = "Unidades | Ventas";
            this.lblUnidades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblTop.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTop.Location = new System.Drawing.Point(23, 511);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(265, 25);
            this.lblTop.TabIndex = 3;
            this.lblTop.Text = "Top producto | Top vendedor";
            this.lblTop.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFacturadoBruto
            // 
            this.lblFacturadoBruto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFacturadoBruto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblFacturadoBruto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFacturadoBruto.Location = new System.Drawing.Point(3, 22);
            this.lblFacturadoBruto.Name = "lblFacturadoBruto";
            this.lblFacturadoBruto.Size = new System.Drawing.Size(167, 53);
            this.lblFacturadoBruto.TabIndex = 0;
            this.lblFacturadoBruto.Text = "Facturado bruto";
            this.lblFacturadoBruto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDescuento
            // 
            this.lblDescuento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblDescuento.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDescuento.Location = new System.Drawing.Point(3, 22);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(167, 53);
            this.lblDescuento.TabIndex = 0;
            this.lblDescuento.Text = "Descuento";
            this.lblDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCosto
            // 
            this.lblCosto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCosto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCosto.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblCosto.Location = new System.Drawing.Point(3, 22);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(167, 53);
            this.lblCosto.TabIndex = 0;
            this.lblCosto.Text = "Costo";
            this.lblCosto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCosto.Click += new System.EventHandler(this.lblCosto_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblFacturado);
            this.groupBox1.Location = new System.Drawing.Point(433, 572);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 78);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facturado Neto";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.lblGanancia);
            this.groupBox2.Location = new System.Drawing.Point(843, 572);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(173, 78);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ganancia Neta";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblFacturadoBruto);
            this.groupBox3.Location = new System.Drawing.Point(23, 572);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(173, 78);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Facturado Bruto";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDescuento);
            this.groupBox4.Location = new System.Drawing.Point(228, 572);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 78);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Descuentos";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblCosto);
            this.groupBox5.Location = new System.Drawing.Point(638, 572);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(173, 78);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Costos";
            // 
            // FormGerente
            // 
            //
            // tabReporte
            //
            this.tabReporte.Controls.Add(this.groupBox5);
            this.tabReporte.Controls.Add(this.groupBox4);
            this.tabReporte.Controls.Add(this.groupBox3);
            this.tabReporte.Controls.Add(this.btnGenerarReporte);
            this.tabReporte.Controls.Add(this.groupBox2);
            this.tabReporte.Controls.Add(this.groupBox1);
            this.tabReporte.Controls.Add(this.btnCancelar);
            this.tabReporte.Controls.Add(this.btnGenerarExcel);
            this.tabReporte.Controls.Add(this.lblTop);
            this.tabReporte.Controls.Add(this.lblUnidades);
            this.tabReporte.Controls.Add(this.lblTicket);
            this.tabReporte.Controls.Add(this.dgvReporte);
            this.tabReporte.Controls.Add(this.grpFiltros);
            this.tabReporte.Location = new System.Drawing.Point(4, 34);
            this.tabReporte.Name = "tabReporte";
            this.tabReporte.Padding = new System.Windows.Forms.Padding(3);
            this.tabReporte.Size = new System.Drawing.Size(1054, 754);
            this.tabReporte.TabIndex = 0;
            this.tabReporte.Text = "Reporte de Ventas";
            this.tabReporte.UseVisualStyleBackColor = true;
            //
            // tabReclamos
            //
            this.tabReclamos.Controls.Add(this.dgvReclamos);
            this.tabReclamos.Controls.Add(this.btnActualizarReclamos);
            this.tabReclamos.Controls.Add(this.lblReclamosInfo);
            this.tabReclamos.Location = new System.Drawing.Point(4, 34);
            this.tabReclamos.Name = "tabReclamos";
            this.tabReclamos.Padding = new System.Windows.Forms.Padding(3);
            this.tabReclamos.Size = new System.Drawing.Size(1054, 754);
            this.tabReclamos.TabIndex = 1;
            this.tabReclamos.Text = "Reclamos";
            this.tabReclamos.UseVisualStyleBackColor = true;
            //
            // lblReclamosInfo
            //
            this.lblReclamosInfo.AutoSize = true;
            this.lblReclamosInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblReclamosInfo.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblReclamosInfo.Location = new System.Drawing.Point(18, 18);
            this.lblReclamosInfo.Name = "lblReclamosInfo";
            this.lblReclamosInfo.Size = new System.Drawing.Size(458, 25);
            this.lblReclamosInfo.TabIndex = 0;
            this.lblReclamosInfo.Text = "Reclamos por compras recibidas incompletas";
            //
            // btnActualizarReclamos
            //
            this.btnActualizarReclamos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnActualizarReclamos.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnActualizarReclamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarReclamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnActualizarReclamos.Location = new System.Drawing.Point(845, 12);
            this.btnActualizarReclamos.Name = "btnActualizarReclamos";
            this.btnActualizarReclamos.Size = new System.Drawing.Size(185, 40);
            this.btnActualizarReclamos.TabIndex = 1;
            this.btnActualizarReclamos.Text = "Actualizar";
            this.btnActualizarReclamos.UseVisualStyleBackColor = false;
            this.btnActualizarReclamos.Click += new System.EventHandler(this.btnActualizarReclamos_Click);
            //
            // dgvReclamos
            //
            this.dgvReclamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReclamos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvReclamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReclamos.Location = new System.Drawing.Point(18, 60);
            this.dgvReclamos.Name = "dgvReclamos";
            this.dgvReclamos.RowHeadersWidth = 24;
            this.dgvReclamos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvReclamos.Size = new System.Drawing.Size(1012, 680);
            this.dgvReclamos.TabIndex = 2;
            //
            // tabPrincipal
            //
            this.tabPrincipal.Controls.Add(this.tabReporte);
            this.tabPrincipal.Controls.Add(this.tabReclamos);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(1062, 792);
            this.tabPrincipal.TabIndex = 0;
            //
            // FormGerente
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1062, 792);
            this.Controls.Add(this.tabPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormGerente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Generar Reportes";
            this.Load += new System.EventHandler(this.FormGerente_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.tabReporte.ResumeLayout(false);
            this.tabReporte.PerformLayout();
            this.tabReclamos.ResumeLayout(false);
            this.tabReclamos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReclamos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label categoria;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label txtProducto;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.Label txtVendedor;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label fecha_fin;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label fecha_inicio;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnGenerarExcel;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cboAgrupar;
        private System.Windows.Forms.Label lblAgrupar;
        private System.Windows.Forms.Label lblFacturado;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.Label lblTicket;
        private System.Windows.Forms.Label lblUnidades;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblFacturadoBruto;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblCosto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabReporte;
        private System.Windows.Forms.TabPage tabReclamos;
        private System.Windows.Forms.DataGridView dgvReclamos;
        private System.Windows.Forms.Button btnActualizarReclamos;
        private System.Windows.Forms.Label lblReclamosInfo;
    }
}
