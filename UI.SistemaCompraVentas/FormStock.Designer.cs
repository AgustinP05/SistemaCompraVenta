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
            this.groupBox1.Size = new System.Drawing.Size(280, 580);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Producto";
            // 
            // label1-label8 (Configuración de etiquetas)
            // 
            this.label1.Text = "Categoría"; this.label1.Location = new System.Drawing.Point(15, 30);
            this.label8.Text = "Nombre"; this.label8.Location = new System.Drawing.Point(15, 90);
            this.label7.Text = "Marca"; this.label7.Location = new System.Drawing.Point(15, 150);
            this.label6.Text = "Talle"; this.label6.Location = new System.Drawing.Point(15, 210);
            this.label5.Text = "Precio Venta"; this.label5.Location = new System.Drawing.Point(15, 270);
            this.label4.Text = "Precio Costo"; this.label4.Location = new System.Drawing.Point(15, 330);
            this.label3.Text = "Stock Actual"; this.label3.Location = new System.Drawing.Point(15, 390);
            this.label2.Text = "Stock Mínimo"; this.label2.Location = new System.Drawing.Point(15, 450);
            // 
            // cboCategoria
            // 
            this.cboCategoria.Location = new System.Drawing.Point(15, 55);
            this.cboCategoria.Size = new System.Drawing.Size(240, 28);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(15, 115);
            this.txtNombre.Size = new System.Drawing.Size(240, 26);
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(15, 175);
            this.txtMarca.Size = new System.Drawing.Size(240, 26);
            // 
            // txtTalle
            // 
            this.txtTalle.Location = new System.Drawing.Point(15, 235);
            this.txtTalle.Size = new System.Drawing.Size(240, 26);
            // 
            // nmPrecioVenta
            // 
            this.nmPrecioVenta.Location = new System.Drawing.Point(15, 295);
            this.nmPrecioVenta.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            // 
            // nmPrecioCosto
            // 
            this.nmPrecioCosto.Location = new System.Drawing.Point(15, 355);
            this.nmPrecioCosto.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            // 
            // nmStockActual
            // 
            this.nmStockActual.Location = new System.Drawing.Point(15, 415);
            // 
            // nmStockMinimo
            // 
            this.nmStockMinimo.Location = new System.Drawing.Point(15, 475);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(15, 520);
            this.btnGuardar.Size = new System.Drawing.Size(240, 40);
            this.btnGuardar.Text = "Guardar Producto";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.Location = new System.Drawing.Point(310, 20);
            this.dgvProductos.Size = new System.Drawing.Size(860, 500);
            // 
            // btnCargarStock
            // 
            this.btnCargarStock.Location = new System.Drawing.Point(920, 540);
            this.btnCargarStock.Size = new System.Drawing.Size(250, 40);
            this.btnCargarStock.Text = "Exportar a Inventario";
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
    }
}