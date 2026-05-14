using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    partial class FormProductos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.nmStock = new System.Windows.Forms.NumericUpDown();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnCargarStock = new System.Windows.Forms.Button();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.txtTalle = new System.Windows.Forms.TextBox();
            this.nmPrecioVenta = new System.Windows.Forms.NumericUpDown();
            this.nmPrecioCosto = new System.Windows.Forms.NumericUpDown();
            this.nmStockActual = new System.Windows.Forms.NumericUpDown();
            this.nmStockMinimo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioVenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioCosto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockActual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockMinimo)).BeginInit();
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
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(300, 582);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Producto";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(7, 536);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(170, 35);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(7, 60);
            this.cboCategoria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(241, 28);
            this.cboCategoria.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(7, 116);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(241, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // nmStock
            // 
            this.nmStock.Location = new System.Drawing.Point(0, 0);
            this.nmStock.Name = "nmStock";
            this.nmStock.Size = new System.Drawing.Size(120, 26);
            this.nmStock.TabIndex = 0;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(327, 29);
            this.dgvProductos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersWidth = 62;
            this.dgvProductos.Size = new System.Drawing.Size(845, 526);
            this.dgvProductos.TabIndex = 1;
            // 
            // btnCargarStock
            // 
            this.btnCargarStock.Location = new System.Drawing.Point(928, 565);
            this.btnCargarStock.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCargarStock.Name = "btnCargarStock";
            this.btnCargarStock.Size = new System.Drawing.Size(244, 35);
            this.btnCargarStock.TabIndex = 2;
            this.btnCargarStock.Text = "Cargar Stock";
            this.btnCargarStock.UseVisualStyleBackColor = true;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(7, 170);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(241, 26);
            this.txtMarca.TabIndex = 2;
            // 
            // txtTalle
            // 
            this.txtTalle.Location = new System.Drawing.Point(7, 224);
            this.txtTalle.Name = "txtTalle";
            this.txtTalle.Size = new System.Drawing.Size(239, 26);
            this.txtTalle.TabIndex = 4;
            // 
            // nmPrecioVenta
            // 
            this.nmPrecioVenta.Location = new System.Drawing.Point(7, 278);
            this.nmPrecioVenta.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmPrecioVenta.Name = "nmPrecioVenta";
            this.nmPrecioVenta.Size = new System.Drawing.Size(120, 26);
            this.nmPrecioVenta.TabIndex = 5;
            this.nmPrecioVenta.ThousandsSeparator = true;
            this.nmPrecioVenta.ValueChanged += new System.EventHandler(this.nmPrecioVenta_ValueChanged);
            // 
            // nmPrecioCosto
            // 
            this.nmPrecioCosto.Location = new System.Drawing.Point(7, 332);
            this.nmPrecioCosto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nmPrecioCosto.Name = "nmPrecioCosto";
            this.nmPrecioCosto.Size = new System.Drawing.Size(120, 26);
            this.nmPrecioCosto.TabIndex = 6;
            this.nmPrecioCosto.ThousandsSeparator = true;
            // 
            // nmStockActual
            // 
            this.nmStockActual.Location = new System.Drawing.Point(7, 386);
            this.nmStockActual.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmStockActual.Name = "nmStockActual";
            this.nmStockActual.Size = new System.Drawing.Size(120, 26);
            this.nmStockActual.TabIndex = 7;
            // 
            // nmStockMinimo
            // 
            this.nmStockMinimo.Location = new System.Drawing.Point(7, 440);
            this.nmStockMinimo.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmStockMinimo.Name = "nmStockMinimo";
            this.nmStockMinimo.Size = new System.Drawing.Size(120, 26);
            this.nmStockMinimo.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Categoria";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Stock Minimo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 361);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Stock Actual";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Precio Costo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Precio Venta";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Talle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Marca";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nombre";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 630);
            this.Controls.Add(this.btnCargarStock);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormProductos";
            this.Text = "FormProductos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioVenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecioCosto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockActual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStockMinimo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Button btnGuardar;
        private NumericUpDown nmStock;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnCargarStock;
        private TextBox txtMarca;
        private NumericUpDown nmPrecioVenta;
        private TextBox txtTalle;
        private NumericUpDown nmStockMinimo;
        private NumericUpDown nmStockActual;
        private NumericUpDown nmPrecioCosto;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
    }
}