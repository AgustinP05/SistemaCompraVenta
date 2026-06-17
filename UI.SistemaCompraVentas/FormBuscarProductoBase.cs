using BLL.SistemaCompraVenta;
using System;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    // Selector de producto BASE (no de SKU). Espeja a FormBuscarProveedor:
    // se abre con ShowDialog y, si el resultado es OK, expone el ID elegido.
    public partial class FormBuscarProductoBase : Form
    {
        private readonly ProductoBLL oProductoBLL = new ProductoBLL();

        // ID del producto elegido (0 si canceló).
        public int IdProductoSeleccionado { get; private set; }

        public FormBuscarProductoBase()
        {
            InitializeComponent();
        }

        private void FormBuscarProductoBase_Load(object sender, EventArgs e)
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
                dgvResultados.DataSource = oProductoBLL.ObtenerProductos(txtBusqueda.Text.Trim());
                AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjustarColumnas()
        {
            if (dgvResultados.Columns.Contains("ID_Categoria"))
                dgvResultados.Columns["ID_Categoria"].Visible = false;
            if (dgvResultados.Columns.Contains("ID_Producto"))
                dgvResultados.Columns["ID_Producto"].HeaderText = "ID";
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

            int id = GrillaHelper.LeerEntero(dgvResultados, dgvResultados.CurrentRow, "ID_Producto", "Id");
            if (id <= 0)
            {
                MessageBox.Show("No se pudo leer el ID del producto seleccionado.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdProductoSeleccionado = id;
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
