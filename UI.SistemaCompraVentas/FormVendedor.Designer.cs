namespace UI.SistemaCompraVentas
{
    partial class FormVendedor
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
            this.components = new System.ComponentModel.Container();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.lblNumeroVenta = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.timerFecha = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProductoColor = new System.Windows.Forms.Label();
            this.buscarSku = new System.Windows.Forms.Button();
            this.buscarCliente = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.lblProductoPrecio = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.lblProductoStock = new System.Windows.Forms.Label();
            this.lblProductoMarca = new System.Windows.Forms.Label();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.lblProductoTalle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nmCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEliminarItem = new System.Windows.Forms.Button();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDescuentoTitulo = new System.Windows.Forms.Label();
            this.cboDescuento = new System.Windows.Forms.ComboBox();
            this.lblValorDescuento = new System.Windows.Forms.Label();
            this.nmDescuento = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDescuento)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVendedor
            // 
            this.lblVendedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblVendedor.Location = new System.Drawing.Point(12, 345);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(280, 18);
            this.lblVendedor.TabIndex = 8;
            this.lblVendedor.Text = "Vendedor: -";
            // 
            // lblNumeroVenta
            // 
            this.lblNumeroVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblNumeroVenta.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNumeroVenta.Location = new System.Drawing.Point(12, 367);
            this.lblNumeroVenta.Name = "lblNumeroVenta";
            this.lblNumeroVenta.Size = new System.Drawing.Size(280, 18);
            this.lblNumeroVenta.TabIndex = 9;
            this.lblNumeroVenta.Text = "Venta N°: -";
            // 
            // lblFecha
            // 
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblFecha.Location = new System.Drawing.Point(12, 389);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(280, 18);
            this.lblFecha.TabIndex = 10;
            this.lblFecha.Text = "Fecha: -";
            // 
            // timerFecha
            // 
            this.timerFecha.Interval = 1000;
            this.timerFecha.Tick += new System.EventHandler(this.timerFecha_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProductoColor);
            this.groupBox1.Controls.Add(this.buscarSku);
            this.groupBox1.Controls.Add(this.buscarCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblProductoNombre);
            this.groupBox1.Controls.Add(this.lblProductoPrecio);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.lblProductoStock);
            this.groupBox1.Controls.Add(this.lblProductoMarca);
            this.groupBox1.Controls.Add(this.lblClienteNombre);
            this.groupBox1.Controls.Add(this.lblProductoTalle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtSku);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nmCantidad);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Venta";
            // 
            // lblProductoColor
            // 
            this.lblProductoColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductoColor.Location = new System.Drawing.Point(554, 78);
            this.lblProductoColor.Name = "lblProductoColor";
            this.lblProductoColor.Size = new System.Drawing.Size(119, 18);
            this.lblProductoColor.TabIndex = 15;
            this.lblProductoColor.Text = "Color: -";
            // 
            // buscarSku
            // 
            this.buscarSku.Location = new System.Drawing.Point(248, 48);
            this.buscarSku.Name = "buscarSku";
            this.buscarSku.Size = new System.Drawing.Size(117, 21);
            this.buscarSku.TabIndex = 14;
            this.buscarSku.Text = "Buscar SKU";
            this.buscarSku.UseVisualStyleBackColor = true;
            this.buscarSku.Click += new System.EventHandler(this.buscarSku_Click);
            // 
            // buscarCliente
            // 
            this.buscarCliente.Location = new System.Drawing.Point(248, 18);
            this.buscarCliente.Name = "buscarCliente";
            this.buscarCliente.Size = new System.Drawing.Size(117, 21);
            this.buscarCliente.TabIndex = 13;
            this.buscarCliente.Text = "Buscar Cliente";
            this.buscarCliente.UseVisualStyleBackColor = true;
            this.buscarCliente.Click += new System.EventHandler(this.buscarCliente_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "DNI Cliente";
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoNombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductoNombre.Location = new System.Drawing.Point(8, 78);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new System.Drawing.Size(272, 18);
            this.lblProductoNombre.TabIndex = 5;
            this.lblProductoNombre.Text = "Producto: -";
            // 
            // lblProductoPrecio
            // 
            this.lblProductoPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoPrecio.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductoPrecio.Location = new System.Drawing.Point(703, 78);
            this.lblProductoPrecio.Name = "lblProductoPrecio";
            this.lblProductoPrecio.Size = new System.Drawing.Size(150, 18);
            this.lblProductoPrecio.TabIndex = 9;
            this.lblProductoPrecio.Text = "Precio: -";
            // 
            // txtCliente
            // 
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtCliente.Location = new System.Drawing.Point(104, 18);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(130, 20);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.TextChanged += new System.EventHandler(this.txtCliente_TextChanged);
            // 
            // lblProductoStock
            // 
            this.lblProductoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoStock.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductoStock.Location = new System.Drawing.Point(507, 49);
            this.lblProductoStock.Name = "lblProductoStock";
            this.lblProductoStock.Size = new System.Drawing.Size(166, 18);
            this.lblProductoStock.TabIndex = 10;
            this.lblProductoStock.Text = "Stock Disp: -";
            // 
            // lblProductoMarca
            // 
            this.lblProductoMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoMarca.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductoMarca.Location = new System.Drawing.Point(293, 78);
            this.lblProductoMarca.Name = "lblProductoMarca";
            this.lblProductoMarca.Size = new System.Drawing.Size(121, 18);
            this.lblProductoMarca.TabIndex = 11;
            this.lblProductoMarca.Text = "Marca: -";
            // 
            // lblClienteNombre
            // 
            this.lblClienteNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblClienteNombre.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblClienteNombre.Location = new System.Drawing.Point(372, 20);
            this.lblClienteNombre.Name = "lblClienteNombre";
            this.lblClienteNombre.Size = new System.Drawing.Size(466, 20);
            this.lblClienteNombre.TabIndex = 2;
            this.lblClienteNombre.Text = "Cliente: -";
            // 
            // lblProductoTalle
            // 
            this.lblProductoTalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoTalle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblProductoTalle.Location = new System.Drawing.Point(438, 78);
            this.lblProductoTalle.Name = "lblProductoTalle";
            this.lblProductoTalle.Size = new System.Drawing.Size(119, 18);
            this.lblProductoTalle.TabIndex = 12;
            this.lblProductoTalle.Text = "Talle: -";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(8, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "SKU";
            // 
            // txtSku
            // 
            this.txtSku.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtSku.Location = new System.Drawing.Point(104, 48);
            this.txtSku.Name = "txtSku";
            this.txtSku.Size = new System.Drawing.Size(130, 20);
            this.txtSku.TabIndex = 4;
            this.txtSku.TextChanged += new System.EventHandler(this.txtSku_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(372, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad";
            // 
            // nmCantidad
            // 
            this.nmCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.nmCantidad.Location = new System.Drawing.Point(441, 48);
            this.nmCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmCantidad.Name = "nmCantidad";
            this.nmCantidad.Size = new System.Drawing.Size(60, 20);
            this.nmCantidad.TabIndex = 6;
            this.nmCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnAgregar.Location = new System.Drawing.Point(706, 43);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(125, 23);
            this.btnAgregar.TabIndex = 7;
            this.btnAgregar.Text = "Agregar Item";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblTotal.Location = new System.Drawing.Point(640, 345);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(231, 22);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "SUBTOTAL VENTA: $ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnEliminarItem
            // 
            this.btnEliminarItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEliminarItem.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnEliminarItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnEliminarItem.Location = new System.Drawing.Point(7, 423);
            this.btnEliminarItem.Name = "btnEliminarItem";
            this.btnEliminarItem.Size = new System.Drawing.Size(130, 32);
            this.btnEliminarItem.TabIndex = 3;
            this.btnEliminarItem.Text = "Eliminar Item";
            this.btnEliminarItem.UseVisualStyleBackColor = false;
            this.btnEliminarItem.Click += new System.EventHandler(this.btnEliminarItem_Click);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelarVenta.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelarVenta.Location = new System.Drawing.Point(147, 423);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(130, 32);
            this.btnCancelarVenta.TabIndex = 2;
            this.btnCancelarVenta.Text = "Vaciar Carrito";
            this.btnCancelarVenta.UseVisualStyleBackColor = false;
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirmar.Location = new System.Drawing.Point(741, 423);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(130, 32);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar Venta";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnSalir.Location = new System.Drawing.Point(287, 423);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(130, 32);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(12, 129);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.RowHeadersWidth = 62;
            this.dgvCarrito.Size = new System.Drawing.Size(859, 213);
            this.dgvCarrito.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(640, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "DESCUENTO: -$ 0,00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(640, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "TOTAL: $ 0,00";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDescuentoTitulo
            // 
            this.lblDescuentoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblDescuentoTitulo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblDescuentoTitulo.Location = new System.Drawing.Point(328, 355);
            this.lblDescuentoTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescuentoTitulo.Name = "lblDescuentoTitulo";
            this.lblDescuentoTitulo.Size = new System.Drawing.Size(135, 18);
            this.lblDescuentoTitulo.TabIndex = 11;
            this.lblDescuentoTitulo.Text = "Tipo descuento:";
            this.lblDescuentoTitulo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboDescuento
            // 
            this.cboDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDescuento.Location = new System.Drawing.Point(467, 353);
            this.cboDescuento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboDescuento.Name = "cboDescuento";
            this.cboDescuento.Size = new System.Drawing.Size(170, 23);
            this.cboDescuento.TabIndex = 12;
            this.cboDescuento.SelectedIndexChanged += new System.EventHandler(this.cboDescuento_SelectedIndexChanged);
            // 
            // lblValorDescuento
            // 
            this.lblValorDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblValorDescuento.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblValorDescuento.Location = new System.Drawing.Point(328, 387);
            this.lblValorDescuento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblValorDescuento.Name = "lblValorDescuento";
            this.lblValorDescuento.Size = new System.Drawing.Size(135, 18);
            this.lblValorDescuento.TabIndex = 13;
            this.lblValorDescuento.Text = "Valor (% o $):";
            this.lblValorDescuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nmDescuento
            // 
            this.nmDescuento.DecimalPlaces = 2;
            this.nmDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.nmDescuento.Location = new System.Drawing.Point(467, 385);
            this.nmDescuento.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nmDescuento.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.nmDescuento.Name = "nmDescuento";
            this.nmDescuento.Size = new System.Drawing.Size(100, 22);
            this.nmDescuento.TabIndex = 14;
            this.nmDescuento.ValueChanged += new System.EventHandler(this.nmDescuento_ValueChanged_Desc);
            // 
            // FormVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(882, 467);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.lblNumeroVenta);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblDescuentoTitulo);
            this.Controls.Add(this.cboDescuento);
            this.Controls.Add(this.lblValorDescuento);
            this.Controls.Add(this.nmDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEliminarItem);
            this.Controls.Add(this.btnCancelarVenta);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "FormVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Registrar Venta";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmDescuento)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSku;
        private System.Windows.Forms.Label lblProductoNombre;
        private System.Windows.Forms.Label lblProductoMarca;
        private System.Windows.Forms.Label lblProductoTalle;
        private System.Windows.Forms.Label lblProductoPrecio;
        private System.Windows.Forms.Label lblProductoStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Button btnEliminarItem;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button buscarSku;
        private System.Windows.Forms.Button buscarCliente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProductoColor;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Label lblNumeroVenta;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer timerFecha;
        private System.Windows.Forms.Label lblDescuentoTitulo;
        private System.Windows.Forms.ComboBox cboDescuento;
        private System.Windows.Forms.Label lblValorDescuento;
        private System.Windows.Forms.NumericUpDown nmDescuento;
    }
}