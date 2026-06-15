using BLL.SistemaCompraVenta;
using System;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormBuscarProducto : Form
    {
        private readonly ProductoBLL oProductoBLL = new ProductoBLL();

        // SKU de la variante elegida (0 si canceló).
        public int SkuSeleccionado { get; private set; }

        public FormBuscarProducto()
        {
            InitializeComponent();
        }

        private void FormBuscarProducto_Load(object sender, EventArgs e)
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
                // SP_ObtenerVariantes filtra por SKU o por nombre de producto (LIKE %filtro%).
                dgvResultados.DataSource = oProductoBLL.ObtenerVariantes(txtBusqueda.Text.Trim());
                AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Reparte el ancho: SKU y Talle angostos, Nombre amplio para que se lea completo.
        private void AjustarColumnas()
        {
            AjustarColumna("SKU", 35);
            AjustarColumna("Nombre", 220);
            AjustarColumna("Marca", 70);
            AjustarColumna("Talle", 35);
            AjustarColumna("Color", 70);
            AjustarColumna("Cantidad", 60);
            AjustarColumna("PrecioVenta", 85);
        }

        private void AjustarColumna(string nombre, int peso)
        {
            if (dgvResultados.Columns.Contains(nombre))
                dgvResultados.Columns[nombre].FillWeight = peso;
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
                MessageBox.Show("Seleccioná un producto de la lista.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dgvResultados.CurrentRow;

            if (!dgvResultados.Columns.Contains("SKU") ||
                !int.TryParse(fila.Cells["SKU"].Value?.ToString(), out int sku))
            {
                MessageBox.Show("No se pudo leer el SKU del producto seleccionado.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SkuSeleccionado = sku;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
