namespace UI.SistemaCompraVentas
{
    partial class FormStock
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
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nmStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.nmStockActual = new System.Windows.Forms.NumericUpDown();
            this.nmPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.nmPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.txtTalle = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnCargarStock = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockMinimo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtColor);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.nmStockMinimo);
            this.groupBox1.Controls.Add(this.nmStockActual);
            this.groupBox1.Controls.Add(this.nmPrecioCosto);
            this.groupBox1.Controls.Add(this.nmPrecioVenta);
            this.groupBox1.Controls.Add(this.txtTalle);
            this.groupBox1.Controls.Add(this.txtMarca);
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 597);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Producto";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nombre";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 14);
            this.label7.TabIndex = 1;
            this.label7.Text = "Marca";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(22, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "Talle";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(25, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "Precio Venta";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 368);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 4;
            this.label4.Text = "Precio Costo";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(25, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Stock Actual";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 488);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stock Mínimo";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "Categoría";
            // 
            // nmStockMinimo
            // 
            this.nmStockMinimo.Location = new System.Drawing.Point(25, 513);
            this.nmStockMinimo.Name = "nmStockMinimo";
            this.nmStockMinimo.Size = new System.Drawing.Size(120, 20);
            this.nmStockMinimo.TabIndex = 8;
            // 
            // nmStockActual
            // 
            this.nmStockActual.Location = new System.Drawing.Point(25, 453);
            this.nmStockActual.Name = "nmStockActual";
            this.nmStockActual.Size = new System.Drawing.Size(120, 20);
            this.nmStockActual.TabIndex = 9;
            // 
            // nmPrecioCosto
            // 
            this.nmPrecioCosto.Location = new System.Drawing.Point(25, 393);
            this.nmPrecioCosto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmPrecioCosto.Name = "nmPrecioCosto";
            this.nmPrecioCosto.Size = new System.Drawing.Size(120, 20);
            this.nmPrecioCosto.TabIndex = 10;
            // 
            // nmPrecioVenta
            // 
            this.nmPrecioVenta.Location = new System.Drawing.Point(25, 333);
            this.nmPrecioVenta.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmPrecioVenta.Name = "nmPrecioVenta";
            this.nmPrecioVenta.Size = new System.Drawing.Size(120, 20);
            this.nmPrecioVenta.TabIndex = 11;
            // 
            // txtTalle
            // 
            this.txtTalle.Location = new System.Drawing.Point(22, 276);
            this.txtTalle.Name = "txtTalle";
            this.txtTalle.Size = new System.Drawing.Size(237, 20);
            this.txtTalle.TabIndex = 12;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(19, 169);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(240, 20);
            this.txtMarca.TabIndex = 13;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 547);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(240, 40);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar Producto";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboCategoria
            // 
            this.cboCategoria.Location = new System.Drawing.Point(19, 57);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(240, 21);
            this.cboCategoria.TabIndex = 15;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(19, 108);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(240, 20);
            this.txtNombre.TabIndex = 16;
            // 
            // dgvProductos
            // 
            this.dgvProductos.Location = new System.Drawing.Point(310, 20);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(860, 500);
            this.dgvProductos.TabIndex = 1;
            // 
            // btnCargarStock
            // 
            this.btnCargarStock.Location = new System.Drawing.Point(920, 540);
            this.btnCargarStock.Name = "btnCargarStock";
            this.btnCargarStock.Size = new System.Drawing.Size(250, 40);
            this.btnCargarStock.TabIndex = 0;
            this.btnCargarStock.Text = "Exportar a Inventario";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 212);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Color";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(25, 228);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(234, 20);
            this.txtColor.TabIndex = 2;
            // 
            // FormStock
            // 
            this.ClientSize = new System.Drawing.Size(1184, 611);
            this.Controls.Add(this.btnCargarStock);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormStock";
            this.Text = "Gestión de Stock";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockMinimo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmStockMinimo;
        private System.Windows.Forms.NumericUpDown nmStockActual;
        private System.Windows.Forms.NumericUpDown nmPrecioCosto;
        private System.Windows.Forms.NumericUpDown nmPrecioVenta;
        private System.Windows.Forms.TextBox txtTalle;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnCargarStock;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label9;
    }
}