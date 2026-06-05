namespace UI.SistemaCompraVentas
{
    partial class FormVendedor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.lblClienteNombre = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.lblProductoNombre = new System.Windows.Forms.Label();
            this.lblProductoPrecio = new System.Windows.Forms.Label();
            this.lblProductoStock = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nmCantidad = new System.Windows.Forms.NumericUpDown();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnEliminarItem = new System.Windows.Forms.Button();
            this.btnCancelarVenta = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cboCliente);
            this.groupBox1.Controls.Add(this.lblClienteNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboProducto);
            this.groupBox1.Controls.Add(this.lblProductoNombre);
            this.groupBox1.Controls.Add(this.lblProductoPrecio);
            this.groupBox1.Controls.Add(this.lblProductoStock);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nmCantidad);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Location = new System.Drawing.Point(13, 26);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(187, 377);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Venta";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID / DNI Cliente:";
            // 
            // cboCliente
            // 
            this.cboCliente.Location = new System.Drawing.Point(10, 39);
            this.cboCliente.Margin = new System.Windows.Forms.Padding(2);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(161, 21);
            this.cboCliente.TabIndex = 1;
            this.cboCliente.SelectedIndexChanged += new System.EventHandler(this.cboCliente_SelectedIndexChanged);
            // 
            // lblClienteNombre
            // 
            this.lblClienteNombre.AutoSize = true;
            this.lblClienteNombre.Location = new System.Drawing.Point(10, 63);
            this.lblClienteNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClienteNombre.Name = "lblClienteNombre";
            this.lblClienteNombre.Size = new System.Drawing.Size(53, 13);
            this.lblClienteNombre.TabIndex = 2;
            this.lblClienteNombre.Text = "Nombre: -";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID Producto:";
            // 
            // cboProducto
            // 
            this.cboProducto.Location = new System.Drawing.Point(10, 107);
            this.cboProducto.Margin = new System.Windows.Forms.Padding(2);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(161, 21);
            this.cboProducto.TabIndex = 4;
            this.cboProducto.SelectedIndexChanged += new System.EventHandler(this.cboProducto_SelectedIndexChanged);
            // 
            // lblProductoNombre
            // 
            this.lblProductoNombre.AutoSize = true;
            this.lblProductoNombre.Location = new System.Drawing.Point(10, 132);
            this.lblProductoNombre.Name = "lblProductoNombre";
            this.lblProductoNombre.Size = new System.Drawing.Size(59, 13);
            this.lblProductoNombre.TabIndex = 5;
            this.lblProductoNombre.Text = "Producto: -";
            // 
            // lblProductoPrecio
            // 
            this.lblProductoPrecio.AutoSize = true;
            this.lblProductoPrecio.Location = new System.Drawing.Point(10, 148);
            this.lblProductoPrecio.Name = "lblProductoPrecio";
            this.lblProductoPrecio.Size = new System.Drawing.Size(53, 13);
            this.lblProductoPrecio.TabIndex = 9;
            this.lblProductoPrecio.Text = "Precio: -";
            // 
            // lblProductoStock
            // 
            this.lblProductoStock.AutoSize = true;
            this.lblProductoStock.Location = new System.Drawing.Point(10, 164);
            this.lblProductoStock.Name = "lblProductoStock";
            this.lblProductoStock.Size = new System.Drawing.Size(67, 13);
            this.lblProductoStock.TabIndex = 10;
            this.lblProductoStock.Text = "Stock Disp: -";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 184);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cantidad:";
            // 
            // nmCantidad
            // 
            this.nmCantidad.Location = new System.Drawing.Point(10, 200);
            this.nmCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.nmCantidad.Name = "nmCantidad";
            this.nmCantidad.Size = new System.Drawing.Size(67, 20);
            this.nmCantidad.TabIndex = 7;
            this.nmCantidad.ValueChanged += new System.EventHandler(this.nmCantidad_ValueChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(10, 240);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(160, 29);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar Item";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrito.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarrito.Location = new System.Drawing.Point(213, 32);
            this.dgvCarrito.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(567, 280);
            this.dgvCarrito.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(213, 322);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(283, 37);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "TOTAL VENTA: $ 0.00";
            // 
            // btnEliminarItem
            // 
            this.btnEliminarItem.Location = new System.Drawing.Point(213, 374);
            this.btnEliminarItem.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminarItem.Name = "btnEliminarItem";
            this.btnEliminarItem.Size = new System.Drawing.Size(107, 29);
            this.btnEliminarItem.TabIndex = 3;
            this.btnEliminarItem.Text = "Eliminar Item";
            this.btnEliminarItem.Click += new System.EventHandler(this.btnEliminarItem_Click);
            // 
            // btnCancelarVenta
            // 
            this.btnCancelarVenta.Location = new System.Drawing.Point(333, 374);
            this.btnCancelarVenta.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelarVenta.Name = "btnCancelarVenta";
            this.btnCancelarVenta.Size = new System.Drawing.Size(107, 29);
            this.btnCancelarVenta.TabIndex = 2;
            this.btnCancelarVenta.Text = "Cancelar Venta";
            this.btnCancelarVenta.Click += new System.EventHandler(this.btnCancelarVenta_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(640, 374);
            this.btnConfirmar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(140, 29);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar Venta";
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(727, 6);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(53, 20);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = "Salir";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 422);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelarVenta);
            this.Controls.Add(this.btnEliminarItem);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormVendedor";
            this.Text = "Terminal de Ventas - SportUPE";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.Label lblClienteNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label lblProductoNombre;
        private System.Windows.Forms.Label lblProductoPrecio;
        private System.Windows.Forms.Label lblProductoStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nmCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dgvCarrito;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnEliminarItem;
        private System.Windows.Forms.Button btnCancelarVenta;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnSalir;
    }
}