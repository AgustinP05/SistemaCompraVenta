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
            this.DvgAlerta = new System.Windows.Forms.Panel();
            this.labelAlerta = new System.Windows.Forms.Label();
            this.resumen_General = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvCrecimiento = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCantidadVentas = new System.Windows.Forms.Label();
            this.VentasDelMes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.categoria = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnGenerarReporte = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCliente = new System.Windows.Forms.ComboBox();
            this.cboProducto = new System.Windows.Forms.ComboBox();
            this.txtProducto = new System.Windows.Forms.Label();
            this.txtVendedor = new System.Windows.Forms.Label();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.fecha_inicio = new System.Windows.Forms.Label();
            this.fecha_fin = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnGenerarExcel = new System.Windows.Forms.Button();
            this.DvgAlerta.SuspendLayout();
            this.resumen_General.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrecimiento)).BeginInit();
            this.panel2.SuspendLayout();
            this.VentasDelMes.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // DvgAlerta
            // 
            this.DvgAlerta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DvgAlerta.Controls.Add(this.labelAlerta);
            this.DvgAlerta.Location = new System.Drawing.Point(508, 83);
            this.DvgAlerta.Name = "DvgAlerta";
            this.DvgAlerta.Size = new System.Drawing.Size(200, 36);
            this.DvgAlerta.TabIndex = 2;
            // 
            // labelAlerta
            // 
            this.labelAlerta.AutoSize = true;
            this.labelAlerta.Location = new System.Drawing.Point(29, 15);
            this.labelAlerta.Name = "labelAlerta";
            this.labelAlerta.Size = new System.Drawing.Size(35, 13);
            this.labelAlerta.TabIndex = 0;
            this.labelAlerta.Text = "Stock";
            // 
            // resumen_General
            // 
            this.resumen_General.Controls.Add(this.tabPage1);
            this.resumen_General.Controls.Add(this.tabPage2);
            this.resumen_General.Location = new System.Drawing.Point(-5, 1);
            this.resumen_General.Name = "resumen_General";
            this.resumen_General.SelectedIndex = 0;
            this.resumen_General.Size = new System.Drawing.Size(810, 452);
            this.resumen_General.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.DvgAlerta);
            this.tabPage1.Controls.Add(this.dgvCrecimiento);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.VentasDelMes);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(802, 426);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Resumen General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-139, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Top Ventas";
            // 
            // dgvCrecimiento
            // 
            this.dgvCrecimiento.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvCrecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrecimiento.Location = new System.Drawing.Point(34, 163);
            this.dgvCrecimiento.Name = "dgvCrecimiento";
            this.dgvCrecimiento.Size = new System.Drawing.Size(730, 235);
            this.dgvCrecimiento.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(289, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "DASHBOARD ESTRATÉGICO - GERENCIA";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Controls.Add(this.labelCantidadVentas);
            this.panel2.Location = new System.Drawing.Point(292, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 36);
            this.panel2.TabIndex = 7;
            // 
            // labelCantidadVentas
            // 
            this.labelCantidadVentas.AutoSize = true;
            this.labelCantidadVentas.Location = new System.Drawing.Point(29, 10);
            this.labelCantidadVentas.Name = "labelCantidadVentas";
            this.labelCantidadVentas.Size = new System.Drawing.Size(100, 13);
            this.labelCantidadVentas.TabIndex = 0;
            this.labelCantidadVentas.Text = "Cantidad de Ventas";
            // 
            // VentasDelMes
            // 
            this.VentasDelMes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.VentasDelMes.Controls.Add(this.label1);
            this.VentasDelMes.Location = new System.Drawing.Point(34, 83);
            this.VentasDelMes.Name = "VentasDelMes";
            this.VentasDelMes.Size = new System.Drawing.Size(200, 36);
            this.VentasDelMes.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas del Mes";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnGenerarExcel);
            this.tabPage2.Controls.Add(this.cboCategoria);
            this.tabPage2.Controls.Add(this.categoria);
            this.tabPage2.Controls.Add(this.dgvReporte);
            this.tabPage2.Controls.Add(this.btnGenerarReporte);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cboCliente);
            this.tabPage2.Controls.Add(this.cboProducto);
            this.tabPage2.Controls.Add(this.txtProducto);
            this.tabPage2.Controls.Add(this.txtVendedor);
            this.tabPage2.Controls.Add(this.cboVendedor);
            this.tabPage2.Controls.Add(this.fecha_inicio);
            this.tabPage2.Controls.Add(this.fecha_fin);
            this.tabPage2.Controls.Add(this.dtpHasta);
            this.tabPage2.Controls.Add(this.dtpDesde);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(802, 426);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reporte Detallado";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(206, 92);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(128, 21);
            this.cboCategoria.TabIndex = 14;
            this.cboCategoria.SelectedIndexChanged += new System.EventHandler(this.cboCategoria_SelectedIndexChanged);
            // 
            // categoria
            // 
            this.categoria.AutoSize = true;
            this.categoria.Location = new System.Drawing.Point(219, 75);
            this.categoria.Name = "categoria";
            this.categoria.Size = new System.Drawing.Size(52, 13);
            this.categoria.TabIndex = 13;
            this.categoria.Text = "Categoria";
            // 
            // dgvReporte
            // 
            this.dgvReporte.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(37, 163);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.Size = new System.Drawing.Size(591, 240);
            this.dgvReporte.TabIndex = 12;
            // 
            // btnGenerarReporte
            // 
            this.btnGenerarReporte.Location = new System.Drawing.Point(642, 133);
            this.btnGenerarReporte.Name = "btnGenerarReporte";
            this.btnGenerarReporte.Size = new System.Drawing.Size(136, 23);
            this.btnGenerarReporte.TabIndex = 11;
            this.btnGenerarReporte.Text = "Generar Reporte";
            this.btnGenerarReporte.UseVisualStyleBackColor = true;
            this.btnGenerarReporte.Click += new System.EventHandler(this.btnGenerarReporte_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(540, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(593, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            // 
            // cboCliente
            // 
            this.cboCliente.FormattingEnabled = true;
            this.cboCliente.Location = new System.Drawing.Point(532, 92);
            this.cboCliente.Name = "cboCliente";
            this.cboCliente.Size = new System.Drawing.Size(132, 21);
            this.cboCliente.TabIndex = 8;
            // 
            // cboProducto
            // 
            this.cboProducto.FormattingEnabled = true;
            this.cboProducto.Location = new System.Drawing.Point(370, 92);
            this.cboProducto.Name = "cboProducto";
            this.cboProducto.Size = new System.Drawing.Size(134, 21);
            this.cboProducto.TabIndex = 7;
            // 
            // txtProducto
            // 
            this.txtProducto.AutoSize = true;
            this.txtProducto.Location = new System.Drawing.Point(380, 75);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(50, 13);
            this.txtProducto.TabIndex = 6;
            this.txtProducto.Text = "Producto";
            // 
            // txtVendedor
            // 
            this.txtVendedor.AutoSize = true;
            this.txtVendedor.Location = new System.Drawing.Point(50, 75);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.Size = new System.Drawing.Size(53, 13);
            this.txtVendedor.TabIndex = 5;
            this.txtVendedor.Text = "Vendedor";
            // 
            // cboVendedor
            // 
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(38, 92);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(134, 21);
            this.cboVendedor.TabIndex = 4;
            this.cboVendedor.Click += new System.EventHandler(this.FormGerente_Load);
            // 
            // fecha_inicio
            // 
            this.fecha_inicio.AutoSize = true;
            this.fecha_inicio.Location = new System.Drawing.Point(116, 16);
            this.fecha_inicio.Name = "fecha_inicio";
            this.fecha_inicio.Size = new System.Drawing.Size(82, 13);
            this.fecha_inicio.TabIndex = 3;
            this.fecha_inicio.Text = "Fecha De Inicio";
            // 
            // fecha_fin
            // 
            this.fecha_fin.AutoSize = true;
            this.fecha_fin.Location = new System.Drawing.Point(399, 16);
            this.fecha_fin.Name = "fecha_fin";
            this.fecha_fin.Size = new System.Drawing.Size(71, 13);
            this.fecha_fin.TabIndex = 2;
            this.fecha_fin.Text = "Fecha De Fin";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(385, 33);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(200, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(110, 33);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(200, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.Location = new System.Drawing.Point(642, 380);
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.Size = new System.Drawing.Size(136, 23);
            this.btnGenerarExcel.TabIndex = 15;
            this.btnGenerarExcel.Text = "Exportar a Excel";
            this.btnGenerarExcel.UseVisualStyleBackColor = true;
            this.btnGenerarExcel.Click += new System.EventHandler(this.btnGenerarExcel_Click);
            // 
            // FormGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resumen_General);
            this.Name = "FormGerente";
            this.Text = "SPORT UPE | Generar Reportes";
            this.DvgAlerta.ResumeLayout(false);
            this.DvgAlerta.PerformLayout();
            this.resumen_General.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrecimiento)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.VentasDelMes.ResumeLayout(false);
            this.VentasDelMes.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel DvgAlerta;
        private System.Windows.Forms.Label labelAlerta;
        private System.Windows.Forms.TabControl resumen_General;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvCrecimiento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCantidadVentas;
        private System.Windows.Forms.Panel VentasDelMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fecha_fin;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label fecha_inicio;
        private System.Windows.Forms.ComboBox cboProducto;
        private System.Windows.Forms.Label txtProducto;
        private System.Windows.Forms.Label txtVendedor;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnGenerarReporte;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCliente;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label categoria;
        private System.Windows.Forms.Button btnGenerarExcel;
    }
}