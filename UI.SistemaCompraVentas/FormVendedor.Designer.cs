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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.nmCantidad = new System.Windows.Forms.NumericUpDown();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvCarrito = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConfirmar);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.nmCantidad);
            this.groupBox1.Controls.Add(this.cboProducto);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(214, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de Venta";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(51, 360);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(130, 35);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "Confirmar Venta";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(17, 310);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(115, 17);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "TOTAL: $ 0.00";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(106, 250);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // nmCantidad
            // 
            this.nmCantidad.Location = new System.Drawing.Point(61, 205);
            this.nmCantidad.Name = "nmCantidad";
            this.nmCantidad.Size = new System.Drawing.Size(120, 20);
            this.nmCantidad.TabIndex = 1;
            this.nmCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmCantidad.ValueChanged += new System.EventHandler(this.nmCantidad_ValueChanged);
            // 
            // cboProducto
            // 
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(60, 150);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(121, 21);
            this.cboProducto.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(106, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "DNI :";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(130, 20);
            this.textBox1.TabIndex = 1;
            // 
            // dgvCarrito
            // 
            this.dgvCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrito.Location = new System.Drawing.Point(245, 22);
            this.dgvCarrito.Name = "dgvCarrito";
            this.dgvCarrito.Size = new System.Drawing.Size(530, 416);
            this.dgvCarrito.TabIndex = 1;
            // 
            // FormVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvCarrito);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormVentas";
            this.Text = "Registrar Nueva Venta";
            this.Load += new System.EventHandler(this.FormVentas_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nmCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.DataGridView dgvCarrito;
    }
}