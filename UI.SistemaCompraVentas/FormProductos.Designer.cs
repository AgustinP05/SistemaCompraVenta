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
            this.nmPrecio = new System.Windows.Forms.NumericUpDown();
            this.nmCategoria = new System.Windows.Forms.NumericUpDown();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.nmStock = new System.Windows.Forms.NumericUpDown();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.btnCargarStock = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.nmPrecio);
            this.groupBox1.Controls.Add(this.nmCategoria);
            this.groupBox1.Controls.Add(this.cboCategoria);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Detalle del Producto";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(62, 211);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(113, 23);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // nmPrecio
            // 
            this.nmPrecio.Location = new System.Drawing.Point(18, 162);
            this.nmPrecio.Name = "nmPrecio";
            this.nmPrecio.Size = new System.Drawing.Size(80, 20);
            this.nmPrecio.TabIndex = 1;
            // 
            // nmCategoria
            // 
            this.nmCategoria.Location = new System.Drawing.Point(100, 118);
            this.nmCategoria.Name = "nmCategoria";
            this.nmCategoria.Size = new System.Drawing.Size(80, 20);
            this.nmCategoria.TabIndex = 1;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(18, 74);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(162, 21);
            this.cboCategoria.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(18, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(162, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // nmStock
            // 
            this.nmStock.Location = new System.Drawing.Point(0, 0);
            this.nmStock.Name = "nmStock";
            this.nmStock.Size = new System.Drawing.Size(120, 20);
            this.nmStock.TabIndex = 0;
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(218, 12);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(369, 375);
            this.dgvProductos.TabIndex = 1;
            // 
            // btnCargarStock
            // 
            this.btnCargarStock.Location = new System.Drawing.Point(408, 347);
            this.btnCargarStock.Name = "btnCargarStock";
            this.btnCargarStock.Size = new System.Drawing.Size(163, 23);
            this.btnCargarStock.TabIndex = 2;
            this.btnCargarStock.Text = "Cargar Stock";
            this.btnCargarStock.UseVisualStyleBackColor = true;
            // 
            // FormProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCargarStock);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormProductos";
            this.Text = "FormProductos";
            this.Load += new System.EventHandler(this.FormProductos_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.NumericUpDown nmPrecio;
        private NumericUpDown nmStock;
        private System.Windows.Forms.NumericUpDown nmCategoria;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btnCargarStock;
    }
}