namespace UI.SistemaCompraVentas
{
    partial class FormRecepcionCompras
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
            this.lblPendientes = new System.Windows.Forms.Label();
            this.dgvPendientes = new System.Windows.Forms.DataGridView();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPendientes
            // 
            this.lblPendientes.AutoSize = true;
            this.lblPendientes.Location = new System.Drawing.Point(12, 8);
            this.lblPendientes.Name = "lblPendientes";
            this.lblPendientes.Size = new System.Drawing.Size(158, 13);
            this.lblPendientes.TabIndex = 1;
            this.lblPendientes.Text = "Órdenes de compra pendientes:";
            // 
            // dgvPendientes
            // 
            this.dgvPendientes.AllowUserToAddRows = false;
            this.dgvPendientes.AllowUserToDeleteRows = false;
            this.dgvPendientes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPendientes.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPendientes.Location = new System.Drawing.Point(12, 25);
            this.dgvPendientes.MultiSelect = false;
            this.dgvPendientes.Name = "dgvPendientes";
            this.dgvPendientes.ReadOnly = true;
            this.dgvPendientes.RowHeadersVisible = false;
            this.dgvPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPendientes.Size = new System.Drawing.Size(860, 170);
            this.dgvPendientes.TabIndex = 2;
            this.dgvPendientes.SelectionChanged += new System.EventHandler(this.dgvPendientes_SelectionChanged);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(752, 201);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(120, 28);
            this.btnRefrescar.TabIndex = 3;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Location = new System.Drawing.Point(12, 234);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(396, 13);
            this.lblDetalle.TabIndex = 4;
            this.lblDetalle.Text = "Detalle de la orden seleccionada (Corregir la \"Cantidad recibida\" si hubo faltant" +
    "es):";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(12, 254);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.RowHeadersVisible = false;
            this.dgvDetalle.Size = new System.Drawing.Size(860, 220);
            this.dgvDetalle.TabIndex = 5;
            // 
            // btnProcesar
            // 
            this.btnProcesar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnProcesar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnProcesar.Location = new System.Drawing.Point(12, 486);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(260, 40);
            this.btnProcesar.TabIndex = 6;
            this.btnProcesar.Text = "Procesar recepción";
            this.btnProcesar.UseVisualStyleBackColor = false;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(752, 486);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(120, 40);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormRecepcionCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 541);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvPendientes);
            this.Controls.Add(this.lblPendientes);
            this.Name = "FormRecepcionCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SPORT UPE | Recepción de Compras";
            this.Load += new System.EventHandler(this.FormRecepcionCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPendientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPendientes;
        private System.Windows.Forms.DataGridView dgvPendientes;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.Button btnSalir;
    }
}
