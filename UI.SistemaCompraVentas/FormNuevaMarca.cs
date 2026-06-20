using BLL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    // Alta de una marca nueva: se escribe el nombre y se elige el proveedor que la provee.
    // Regla del dominio: una marca pertenece a un único proveedor (no se cruza entre varios).
    public partial class FormNuevaMarca : Form
    {
        private readonly ProveedorBLL _bll = new ProveedorBLL();

        // Marca que quedó cargada (la usa el form padre para refrescar y preseleccionar).
        public string MarcaCreada { get; private set; }

        public FormNuevaMarca()
        {
            InitializeComponent();
        }

        private void FormNuevaMarca_Load(object sender, EventArgs e)
        {
            cboProveedor.DataSource = _bll.ListarProveedores();
            cboProveedor.DisplayMember = "RazonSocial";
            cboProveedor.ValueMember = "IdProveedor";
            cboProveedor.SelectedIndex = -1;
        }

        private void btnAsociar_Click(object sender, EventArgs e)
        {
            string marca = txtMarca.Text.Trim();
            if (string.IsNullOrWhiteSpace(marca))
            {
                MessageBox.Show("Ingresá el nombre de la marca.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Proveedor prov = cboProveedor.SelectedItem as Proveedor;
            if (prov == null)
            {
                MessageBox.Show("Seleccioná el proveedor que provee esta marca.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _bll.AsociarMarca(prov.IdProveedor, marca);

                MarcaCreada = marca;
                MessageBox.Show(
                    "Marca \"" + marca + "\" asignada a " + prov.RazonSocial + ".",
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (OperacionNoPermitidaException ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
