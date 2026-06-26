using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;
using System;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormBuscarCliente : Form
    {
        private readonly ClienteBLL oClienteBLL = new ClienteBLL();

        // Cliente que el usuario eligió de la lista (null si canceló).
        public Cliente ClienteSeleccionado { get; private set; }

        public FormBuscarCliente()
        {
            InitializeComponent();
        }

        private void FormBuscarCliente_Load(object sender, EventArgs e)
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
                // SP_ObtenerClientes filtra por DNI, Nombre o Apellido
                dgvResultados.DataSource = oClienteBLL.ObtenerClientes(txtBusqueda.Text.Trim());
                OcultarColumnasExtra();
                AjustarColumnas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // En la grilla mostramos solo DNI, Nombre y Apellido; el resto sigue
        // disponible en las celdas (oculto) para poder armar el Cliente completo.
        private void OcultarColumnasExtra()
        {
            foreach (string columna in new[] { "ID_Cliente", "Direccion", "Telefono", "Email" })
                if (dgvResultados.Columns.Contains(columna))
                    dgvResultados.Columns[columna].Visible = false;
        }

        // Reparte el ancho: DNI más angosto, Nombre y Apellido más amplios.
        private void AjustarColumnas()
        {
            AjustarColumna("DNI", 60);
            AjustarColumna("Nombre", 130);
            AjustarColumna("Apellido", 130);
        }

        private void AjustarColumna(string nombre, int peso)
        {
            if (dgvResultados.Columns.Contains(nombre))
                dgvResultados.Columns[nombre].FillWeight = peso;
        }

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            using (FormCrearCliente crear = new FormCrearCliente())
                crear.ShowDialog();

            Buscar(); // refresco por si se cargó un cliente nuevo
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
                MessageBox.Show("Seleccioná un cliente de la lista.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow fila = dgvResultados.CurrentRow;

            ClienteSeleccionado = new Cliente
            {
                IdCliente = GrillaHelper.LeerEntero(dgvResultados, fila, "ID_Cliente"),
                Dni       = GrillaHelper.LeerCelda(dgvResultados, fila, "DNI"),
                Nombre    = GrillaHelper.LeerCelda(dgvResultados, fila, "Nombre"),
                Apellido  = GrillaHelper.LeerCelda(dgvResultados, fila, "Apellido"),
                Direccion = GrillaHelper.LeerCelda(dgvResultados, fila, "Direccion"),
                Telefono  = GrillaHelper.LeerCelda(dgvResultados, fila, "Telefono"),
                Email     = GrillaHelper.LeerCelda(dgvResultados, fila, "Email")
            };

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
