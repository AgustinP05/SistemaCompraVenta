using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;
using System;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormBuscarProveedor : Form
    {
        private readonly ProveedorBLL oProveedorBLL = new ProveedorBLL();

        // Proveedor que el usuario eligió de la lista (null si canceló).
        public Proveedor ProveedorSeleccionado { get; private set; }

        public FormBuscarProveedor()
        {
            InitializeComponent();
        }

        private void FormBuscarProveedor_Load(object sender, EventArgs e)
        {
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.MultiSelect = false;
            dgvResultados.ReadOnly = true;
            dgvResultados.AllowUserToAddRows = false;
            // La grilla arranca vacía; solo se llena al apretar Buscar.
        }

        private void Buscar()
        {
            try
            {
                // SP_ObtenerProveedores filtra por CUIT o RazonSocial (LIKE %filtro%).
                dgvResultados.DataSource = oProveedorBLL.ObtenerProveedores(txtBusqueda.Text.Trim());
                OcultarColumnasExtra();
                AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // En la grilla mostramos CUIT y Razón Social; el resto sigue disponible
        // (oculto) para poder armar el Proveedor completo al seleccionar.
        private void OcultarColumnasExtra()
        {
            foreach (string columna in new[] { "ID_Proveedor", "Direccion", "Telefono", "Email" })
                if (dgvResultados.Columns.Contains(columna))
                    dgvResultados.Columns[columna].Visible = false;
        }

        private void AjustarColumnas()
        {
            AjustarColumna("CUIT", 70);
            AjustarColumna("RazonSocial", 180);
        }

        private void AjustarColumna(string nombre, int peso)
        {
            if (dgvResultados.Columns.Contains(nombre))
                dgvResultados.Columns[nombre].FillWeight = peso;
        }

        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            using (FormCrearProveedor crear = new FormCrearProveedor())
                crear.ShowDialog();

            Buscar(); // refresco por si se cargó un proveedor nuevo
        }

        private void btnBuscar_Click(object sender, EventArgs e) => Buscar();

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Buscar();
                e.SuppressKeyPress = true; // evita el "ding"
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e) => Seleccionar();

        private void dgvResultados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) Seleccionar();
        }

        private void Seleccionar()
        {
            if (dgvResultados.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un proveedor de la lista.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dgvResultados.CurrentRow;

            ProveedorSeleccionado = new Proveedor
            {
                IdProveedor = LeerEntero(fila, "ID_Proveedor"),
                Cuit        = LeerCelda(fila, "CUIT"),
                RazonSocial = LeerCelda(fila, "RazonSocial"),
                Direccion   = LeerCelda(fila, "Direccion"),
                Telefono    = LeerCelda(fila, "Telefono"),
                Email       = LeerCelda(fila, "Email")
            };

            DialogResult = DialogResult.OK;
            Close();
        }

        private string LeerCelda(DataGridViewRow fila, string columna)
        {
            if (dgvResultados.Columns.Contains(columna))
                return fila.Cells[columna].Value?.ToString() ?? "";
            return "";
        }

        private int LeerEntero(DataGridViewRow fila, string columna)
        {
            return int.TryParse(LeerCelda(fila, columna), out int valor) ? valor : 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
