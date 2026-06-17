using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Proveedor = ENT.SistemaCompraVenta.Proveedor;

namespace UI.SistemaCompraVentas
{
    public partial class FormCrearProveedor : Form
    {
        private bool _cargando = false;
        private readonly List<Proveedor> _proveedoresCargados = new List<Proveedor>();

        public FormCrearProveedor()
        {
            InitializeComponent();
        }

        private void FormCrearProveedor_Load(object sender, EventArgs e)
        {
            dgvProveedoresCargados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProveedoresCargados.Columns.Add("CUIT",        "CUIT");
            dgvProveedoresCargados.Columns.Add("RazonSocial", "Razón Social");
            dgvProveedoresCargados.Columns.Add("Telefono",    "Teléfono");
            dgvProveedoresCargados.Columns.Add("Email",       "Email");
            dgvProveedoresCargados.Columns.Add("Direccion",   "Dirección");

            // El CUIT es la clave del proveedor y no puede modificarse desde la edición
            txtEditCuit.ReadOnly = true;

            LimpiarEdicion();
        }

        // ── Tab 1: Cargar ────────────────────────────────────────────────

        private void btnIngresarProveedor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCuit.Text) ||
                string.IsNullOrEmpty(txtRazonSocial.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtEmail.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text))
            {
                MessageBox.Show("Datos incompletos.");
                return;
            }

            try
            {
                BLL.SistemaCompraVenta.ProveedorBLL bll = new BLL.SistemaCompraVenta.ProveedorBLL();

                if (bll.ExisteProveedor(txtCuit.Text))
                {
                    MessageBox.Show("Proveedor ya ingresado.");
                    return;
                }

                bool exito = bll.CrearProveedor(
                    txtCuit.Text, txtRazonSocial.Text,
                    txtTelefono.Text, txtEmail.Text, txtDireccion.Text);

                if (exito)
                {
                    MessageBox.Show("Proveedor creado con éxito.");
                    _proveedoresCargados.Add(new Proveedor
                    {
                        Cuit        = txtCuit.Text,
                        RazonSocial = txtRazonSocial.Text,
                        Telefono    = txtTelefono.Text,
                        Email       = txtEmail.Text,
                        Direccion   = txtDireccion.Text
                    });
                    LimpiarCarga();
                    CargarGrillaProveedores();
                }
                else
                {
                    MessageBox.Show("Error al registrar el proveedor en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCarga();
        }

        private void LimpiarCarga()
        {
            txtCuit.Clear();
            txtRazonSocial.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }

        private void CargarGrillaProveedores()
        {
            dgvProveedoresCargados.Rows.Clear();

            foreach (Proveedor p in _proveedoresCargados)
                dgvProveedoresCargados.Rows.Add(
                    p.Cuit, p.RazonSocial, p.Telefono, p.Email, p.Direccion);
        }

        // ── Tab 2: Buscar / Editar ────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                BLL.SistemaCompraVenta.ProveedorBLL bll = new BLL.SistemaCompraVenta.ProveedorBLL();
                dgvProveedores.DataSource = bll.ObtenerProveedores(txtBuscarCuit.Text.Trim());
                LimpiarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message);
            }
            finally
            {
                _cargando = false;
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvProveedores.CurrentRow == null || dgvProveedores.Columns.Count == 0) return;

            var fila = dgvProveedores.CurrentRow;
            txtEditCuit.Text        = ObtenerCelda(fila, "CUIT");
            txtEditRazonSocial.Text = ObtenerCelda(fila, "RazonSocial", "Razon_Social");
            txtEditTelefono.Text    = ObtenerCelda(fila, "Telefono");
            txtEditEmail.Text       = ObtenerCelda(fila, "Email");
            txtEditDireccion.Text   = ObtenerCelda(fila, "Direccion");
        }

        private string ObtenerCelda(DataGridViewRow fila, params string[] nombres)
        {
            foreach (var nombre in nombres)
                if (dgvProveedores.Columns.Contains(nombre))
                    return fila.Cells[nombre].Value?.ToString() ?? "";
            return "";
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditCuit.Text))
            {
                MessageBox.Show("Seleccione un proveedor de la lista antes de guardar.");
                return;
            }

            if (string.IsNullOrEmpty(txtEditRazonSocial.Text) ||
                string.IsNullOrEmpty(txtEditTelefono.Text) ||
                string.IsNullOrEmpty(txtEditEmail.Text) ||
                string.IsNullOrEmpty(txtEditDireccion.Text))
            {
                MessageBox.Show("Datos incompletos.");
                return;
            }

            try
            {
                BLL.SistemaCompraVenta.ProveedorBLL bll = new BLL.SistemaCompraVenta.ProveedorBLL();

                Proveedor p = new Proveedor
                {
                    Cuit        = txtEditCuit.Text,
                    RazonSocial = txtEditRazonSocial.Text,
                    Telefono    = txtEditTelefono.Text,
                    Email       = txtEditEmail.Text,
                    Direccion   = txtEditDireccion.Text
                };

                bool exito = bll.ModificarProveedor(p);
                if (exito)
                {
                    MessageBox.Show("Proveedor modificado con éxito.");
                    ActualizarGrillaEdicion();
                }
                else
                {
                    MessageBox.Show("Error al modificar el proveedor.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditCuit.Text))
            {
                MessageBox.Show("Seleccione un proveedor de la lista antes de eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar al proveedor " + txtEditCuit.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                BLL.SistemaCompraVenta.ProveedorBLL bll = new BLL.SistemaCompraVenta.ProveedorBLL();
                bool exito = bll.EliminarProveedor(txtEditCuit.Text);

                if (exito)
                {
                    MessageBox.Show("Proveedor eliminado con éxito.");
                    ActualizarGrillaEdicion();
                    LimpiarEdicion();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el proveedor.");
                }
            }
            catch (ENT.SistemaCompraVenta.OperacionNoPermitidaException ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void ActualizarGrillaEdicion()
        {
            try
            {
                _cargando = true;
                BLL.SistemaCompraVenta.ProveedorBLL bll = new BLL.SistemaCompraVenta.ProveedorBLL();
                dgvProveedores.DataSource = bll.ObtenerProveedores(txtBuscarCuit.Text.Trim());
            }
            catch { }
            finally
            {
                _cargando = false;
            }
        }

        private void LimpiarEdicion()
        {
            txtEditCuit.Clear();
            txtEditRazonSocial.Clear();
            txtEditTelefono.Clear();
            txtEditEmail.Clear();
            txtEditDireccion.Clear();
        }

        // ── Global ───────────────────────────────────────────────────────

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
