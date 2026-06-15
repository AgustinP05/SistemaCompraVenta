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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.lblProductoPrecio = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblProductoStock = new System.Windows.Forms.Label();
            this.lblProductoMarca = new System.Windows.Forms.Label();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.lblProductoTalle = new System.Windows.Forms.Label();
            this.lblProductoColor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProductoColor);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblProductoNombre);
            this.groupBox1.Controls.Add(this.lblProductoPrecio);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.lblProductoStock);
            this.groupBox1.Controls.Add(this.lblProductoMarca);
            this.groupBox1.Controls.Add(this.lblClienteNombre);
            this.groupBox1.Controls.Add(this.lblProductoTalle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboProducto);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(248, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 21);
            this.button2.TabIndex = 14;
            this.button2.Text = "Buscar SKU";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 21);
            this.button1.TabIndex = 13;
            this.button1.Text = "Buscar Cliente";
            this.button1.UseVisualStyleBackColor = true;
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
            this.lblProductoNombre.Click += new System.EventHandler(this.lblProductoNombre_Click);
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
            this.lblProductoPrecio.Click += new System.EventHandler(this.lblProductoPrecio_Click);
            // 
            // cboCliente
            // 
            this.cboCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboCliente.Location = new System.Drawing.Point(104, 18);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(130, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
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
            this.lblProductoStock.Click += new System.EventHandler(this.lblProductoStock_Click);
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
            this.lblProductoMarca.Click += new System.EventHandler(this.lblProductoMarca_Click);
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
            this.lblProductoTalle.Click += new System.EventHandler(this.lblProductoTalle_Click);
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
            // cboProducto
            // 
            this.cboProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cboProducto.Location = new System.Drawing.Point(104, 48);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(130, 21);
            this.cboProducto.TabIndex = 4;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
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
            this.nmCantidad.ValueChanged += new System.EventHandler(this.nmCantidad_ValueChanged);
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
            this.lblTotal.Location = new System.Drawing.Point(111, 345);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(760, 22);
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
            this.dgvCarrito.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(12, 129);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(859, 213);
            this.dgvCarrito.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(111, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(760, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "DESCUENTO %: $ 0,00";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(111, 389);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(760, 22);
            this.label5.TabIndex = 7;
            this.label5.Text = "TOTAL: $ 0,00";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Click += new System.EventHandler(this.label5_Click);
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
            this.lblProductoColor.Click += new System.EventHandler(this.lblProductoColor_Click);
            // 
            // FormVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(883, 467);
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
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProducto;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblProductoColor;
    }
}