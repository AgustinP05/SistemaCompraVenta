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
            this.label3 = new System.Windows.Forms.Label();
            this.dgvCrecimiento = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.labelAlerta = new System.Windows.Forms.Label();
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
            this.VentasDelMes.Location = new System.Drawing.Point(27, 57);
            this.VentasDelMes.Name = "VentasDelMes";
            this.VentasDelMes.Size = new System.Drawing.Size(200, 36);
            this.VentasDelMes.TabIndex = 0;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LimeGreen;
            this.panel2.Controls.Add(this.labelCantidadVentas);
            this.panel2.Location = new System.Drawing.Point(285, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 36);
            this.panel2.TabIndex = 1;
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
            // DvgAlerta
            // 
            this.DvgAlerta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.DvgAlerta.Controls.Add(this.labelAlerta);
            this.DvgAlerta.Location = new System.Drawing.Point(557, 57);
            this.DvgAlerta.Name = "DvgAlerta";
            this.DvgAlerta.Size = new System.Drawing.Size(200, 36);
            this.DvgAlerta.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(218, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "DASHBOARD ESTRATÉGICO - GERENCIA";
            // 
            // dgvCrecimiento
            // 
            this.dgvCrecimiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCrecimiento.Location = new System.Drawing.Point(27, 137);
            this.dgvCrecimiento.Name = "dgvCrecimiento";
            this.dgvCrecimiento.Size = new System.Drawing.Size(730, 235);
            this.dgvCrecimiento.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Top Ventas";
            // 
            // labelAlerta
            // 
            this.labelAlerta.AutoSize = true;
            this.labelAlerta.Location = new System.Drawing.Point(25, 10);
            this.labelAlerta.Name = "labelAlerta";
            this.labelAlerta.Size = new System.Drawing.Size(35, 13);
            this.labelAlerta.TabIndex = 0;
            this.labelAlerta.Text = "Stock";
            // 
            // FormGerente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvCrecimiento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DvgAlerta);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.VentasDelMes);
            this.Name = "FormGerente";
            this.Text = "FormReportes";
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