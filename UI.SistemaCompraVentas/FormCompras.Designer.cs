namespace UI.SistemaCompraVentas
{
    partial class FormCompras
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
            this.lblComprador = new System.Windows.Forms.Label();
            this.lblNumeroCompra = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.timerFecha = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProductoColor = new System.Windows.Forms.Label();
            this.buscarSku = new System.Windows.Forms.Button();
            this.buscarProveedor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.lblProductoPrecio = new System.Windows.Forms.Label();
            this.txtProveedor = new System.Windows.Forms.TextBox();
            this.lblProductoStock = new System.Windows.Forms.Label();
            this.lblProductoMarca = new System.Windows.Forms.Label();
            this.lblProveedorNombre = new System.Windows.Forms.Label();
            this.lblProductoTalle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSku = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nmCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEliminarItem = new System.Windows.Forms.Button();
            this.btnCancelarCompra = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // lblComprador
            // 
            this.lblComprador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblComprador.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblComprador.Location = new System.Drawing.Point(12, 345);
            this.lblComprador.Name = "lblComprador";
            this.lblComprador.Size = new System.Drawing.Size(280, 18);
            this.lblComprador.TabIndex = 8;
            this.lblComprador.Text = "Encargado de compras: -";
            // 
            // lblNumeroCompra
            // 
            this.lblNumeroCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblNumeroCompra.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblNumeroCompra.Location = new System.Drawing.Point(12, 367);
            this.lblNumeroCompra.Name = "lblNumeroCompra";
            this.lblNumeroCompra.Size = new System.Drawing.Size(280, 18);
            this.lblNumeroCompra.TabIndex = 9;
            this.lblNumeroCompra.Text = "Orden N°: -";
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
            this.groupBox1.Controls.Add(this.buscarProveedor);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblProductoNombre);
            this.groupBox1.Controls.Add(this.lblProductoPrecio);
            this.groupBox1.Controls.Add(this.txtProveedor);
            this.groupBox1.Controls.Add(this.lblProductoStock);
            this.groupBox1.Controls.Add(this.lblProductoMarca);
            this.groupBox1.Controls.Add(this.lblProveedorNombre);
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
            this.groupBox1.Text = "Datos de la Compra";
            // 
            // lblProductoColor
            // 
            this.lblProductoColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
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
            // buscarProveedor
            // 
            this.buscarProveedor.Location = new System.Drawing.Point(248, 18);
            this.buscarProveedor.Name = "buscarProveedor";
            this.buscarProveedor.Size = new System.Drawing.Size(117, 21);
            this.buscarProveedor.TabIndex = 13;
            this.buscarProveedor.Text = "Buscar Proveedor";
            this.buscarProveedor.UseVisualStyleBackColor = true;
            this.buscarProveedor.Click += new System.EventHandler(this.buscarProveedor_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUIT Proveedor";
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoNombre.Location = new System.Drawing.Point(8, 78);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new System.Drawing.Size(272, 18);
            this.lblProductoNombre.TabIndex = 5;
            this.lblProductoNombre.Text = "Producto: -";
            // 
            // lblProductoPrecio
            // 
            this.lblProductoPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoPrecio.Location = new System.Drawing.Point(703, 78);
            this.lblProductoPrecio.Name = "lblProductoPrecio";
            this.lblProductoPrecio.Size = new System.Drawing.Size(150, 18);
            this.lblProductoPrecio.TabIndex = 9;
            this.lblProductoPrecio.Text = "Costo: -";
            // 
            // txtProveedor
            // 
            this.txtProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.txtProveedor.Location = new System.Drawing.Point(104, 18);
            this.txtProveedor.Name = "txtProveedor";
            this.txtProveedor.Size = new System.Drawing.Size(130, 20);
            this.txtProveedor.TabIndex = 1;
            this.txtProveedor.TextChanged += new System.EventHandler(this.txtProveedor_TextChanged);
            // 
            // lblProductoStock
            // 
            this.lblProductoStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoStock.Location = new System.Drawing.Point(507, 49);
            this.lblProductoStock.Name = "lblProductoStock";
            this.lblProductoStock.Size = new System.Drawing.Size(166, 18);
            this.lblProductoStock.TabIndex = 10;
            this.lblProductoStock.Text = "Stock actual: -";
            // 
            // lblProductoMarca
            // 
            this.lblProductoMarca.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoMarca.Location = new System.Drawing.Point(293, 78);
            this.lblProductoMarca.Name = "lblProductoMarca";
            this.lblProductoMarca.Size = new System.Drawing.Size(121, 18);
            this.lblProductoMarca.TabIndex = 11;
            this.lblProductoMarca.Text = "Marca: -";
            // 
            // lblProveedorNombre
            // 
            this.lblProveedorNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProveedorNombre.Location = new System.Drawing.Point(372, 20);
            this.lblProveedorNombre.Name = "lblProveedorNombre";
            this.lblProveedorNombre.Size = new System.Drawing.Size(466, 20);
            this.lblProveedorNombre.TabIndex = 2;
            this.lblProveedorNombre.Text = "Proveedor: -";
            // 
            // lblProductoTalle
            // 
            this.lblProductoTalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.lblProductoTalle.Location = new System.Drawing.Point(438, 78);
            this.lblProductoTalle.Name = "lblProductoTalle";
            this.lblProductoTalle.Size = new System.Drawing.Size(119, 18);
            this.lblProductoTalle.TabIndex = 12;
            this.lblProductoTalle.Text = "Talle: -";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
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
            this.nmCantidad.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
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
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(600, 345);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(271, 26);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "TOTAL ORDEN: $ 0,00";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnEliminarItem
            // 
            this.btnEliminarItem.BackColor = System.Drawing.SystemColors.ControlLight;
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
            // btnCancelarCompra
            // 
            this.btnCancelarCompra.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnCancelarCompra.Location = new System.Drawing.Point(147, 423);
            this.btnCancelarCompra.Name = "btnCancelarCompra";
            this.btnCancelarCompra.Size = new System.Drawing.Size(130, 32);
            this.btnCancelarCompra.TabIndex = 2;
            this.btnCancelarCompra.Text = "Vaciar Orden";
            this.btnCancelarCompra.UseVisualStyleBackColor = false;
            this.btnCancelarCompra.Click += new System.EventHandler(this.btnCancelarCompra_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnConfirmar.Location = new System.Drawing.Point(706, 423);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(165, 32);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Generar Orden de Compra";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight;
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
            // FormCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(882, 467);
            this.Controls.Add(this.lblComprador);
            this.Controls.Add(this.lblNumeroCompra);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnEliminarItem);
            this.Controls.Add(this.btnCancelarCompra);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmar);
            this.Name = "FormCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Registrar Compra";
            this.Load += new System.EventHandler(this.FormCompras_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProveedor;
        private System.Windows.Forms.Label lblProveedorNombre;
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
        private System.Windows.Forms.Button btnCancelarCompra;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button buscarSku;
        private System.Windows.Forms.Button buscarProveedor;
        private System.Windows.Forms.Label lblProductoColor;
        private System.Windows.Forms.Label lblComprador;
        private System.Windows.Forms.Label lblNumeroCompra;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Timer timerFecha;
    }
}
