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
            this.VentasDelMes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCantidadVentas = new System.Windows.Forms.Label();
            this.DvgAlerta = new System.Windows.Forms.Panel();
            this.labelAlerta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCrecimiento = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.VentasDelMes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.DvgAlerta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrecimiento)).BeginInit();
            this.SuspendLayout();
            // 
            // VentasDelMes
            // 
            this.VentasDelMes.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.VentasDelMes.Controls.Add(this.label1);
            this.VentasDelMes.Location = new System.Drawing.Point(40, 88);
            this.VentasDelMes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VentasDelMes.Name = "VentasDelMes";
            this.VentasDelMes.Size = new System.Drawing.Size(300, 55);
            this.VentasDelMes.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ventas del Mes";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Controls.Add(this.labelCantidadVentas);
            this.panel2.Location = new System.Drawing.Point(428, 88);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 55);
            this.panel2.TabIndex = 1;
            // 
            // labelCantidadVentas
            // 
            this.labelCantidadVentas.AutoSize = true;
            this.labelCantidadVentas.Location = new System.Drawing.Point(44, 15);
            this.labelCantidadVentas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCantidadVentas.Name = "labelCantidadVentas";
            this.labelCantidadVentas.Size = new System.Drawing.Size(150, 20);
            this.labelCantidadVentas.TabIndex = 0;
            this.labelCantidadVentas.Text = "Cantidad de Ventas";
            // 
            // DvgAlerta
            // 
            this.DvgAlerta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DvgAlerta.Controls.Add(this.labelAlerta);
            this.DvgAlerta.Location = new System.Drawing.Point(836, 88);
            this.DvgAlerta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DvgAlerta.Name = "DvgAlerta";
            this.DvgAlerta.Size = new System.Drawing.Size(300, 55);
            this.DvgAlerta.TabIndex = 2;
            // 
            // labelAlerta
            // 
            this.labelAlerta.AutoSize = true;
            this.labelAlerta.Location = new System.Drawing.Point(38, 15);
            this.labelAlerta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlerta.Name = "labelAlerta";
            this.labelAlerta.Size = new System.Drawing.Size(50, 20);
            this.labelAlerta.TabIndex = 0;
            this.labelAlerta.Text = "Stock";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(330, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "DASHBOARD ESTRATÉGICO - GERENCIA";
            // 
            // dgvCrecimiento
            // 
            this.dgvCrecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrecimiento.Location = new System.Drawing.Point(40, 211);
            this.dgvCrecimiento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCrecimiento.Name = "dgvCrecimiento";
            this.dgvCrecimiento.RowHeadersWidth = 62;
            this.dgvCrecimiento.Size = new System.Drawing.Size(1095, 362);
            this.dgvCrecimiento.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Top Ventas";
            // 
            // FormGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCrecimiento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DvgAlerta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.VentasDelMes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormGerente";
            this.Text = "SPORT UPE | Generar Reportes";
            this.Load += new System.EventHandler(this.FormGerente_Load);
            this.VentasDelMes.ResumeLayout(false);
            this.VentasDelMes.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.DvgAlerta.ResumeLayout(false);
            this.DvgAlerta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCrecimiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel VentasDelMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCantidadVentas;
        private System.Windows.Forms.Panel DvgAlerta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvCrecimiento;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelAlerta;
    }
}