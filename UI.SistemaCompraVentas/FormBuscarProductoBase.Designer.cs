namespace UI.SistemaCompraVentas
{
    partial class FormBuscarProductoBase
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

        private void InitializeComponent()
        {
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvResultados = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblBusqueda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).BeginInit();
            this.SuspendLayout();
            //
            // lblBusqueda
            //
            this.lblBusqueda.AutoSize = true;
            this.lblBusqueda.Location = new System.Drawing.Point(12, 18);
            this.lblBusqueda.Name = "lblBusqueda";
            this.lblBusqueda.Size = new System.Drawing.Size(91, 13);
            this.lblBusqueda.TabIndex = 0;
            this.lblBusqueda.Text = "ID / nombre / marca:";
            //
            // txtBusqueda
            //
            this.txtBusqueda.Location = new System.Drawing.Point(125, 15);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(250, 20);
            this.txtBusqueda.TabIndex = 1;
            this.txtBusqueda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyDown);
            //
            // btnBuscar
            //
            this.btnBuscar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Location = new System.Drawing.Point(385, 13);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(90, 25);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            //
            // dgvResultados
            //
            this.dgvResultados.AllowUserToAddRows = false;
            this.dgvResultados.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            this.dgvResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultados.Location = new System.Drawing.Point(15, 48);
            this.dgvResultados.MultiSelect = false;
            this.dgvResultados.Name = "dgvResultados";
            this.dgvResultados.ReadOnly = true;
            this.dgvResultados.RowHeadersWidth = 51;
            this.dgvResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResultados.Size = new System.Drawing.Size(560, 280);
            this.dgvResultados.TabIndex = 3;
            this.dgvResultados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResultados_CellDoubleClick);
            //
            // btnSeleccionar
            //
            this.btnSeleccionar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Location = new System.Drawing.Point(355, 338);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(110, 30);
            this.btnSeleccionar.TabIndex = 4;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            //
            // btnCancelar
            //
            this.btnCancelar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Location = new System.Drawing.Point(471, 338);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            //
            // FormBuscarProductoBase
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 380);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Controls.Add(this.lblBusqueda);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvResultados);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCancelar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBuscarProductoBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Buscar producto";
            this.Load += new System.EventHandler(this.FormBuscarProductoBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblBusqueda;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvResultados;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnCancelar;
    }
}
