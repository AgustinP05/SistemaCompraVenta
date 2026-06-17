using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormCrearCliente : Form
    {
        private bool _cargando = false;
        private readonly List<ENT.SistemaCompraVenta.Cliente> _clientesCargados =
            new List<ENT.SistemaCompraVenta.Cliente>();
        private int _idClienteSeleccionado = 0;

        public FormCrearCliente()
        {
            InitializeComponent();
        }

        private void FormCrearCliente_Load(object sender, EventArgs e)
        {
            dgvClientesCargados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientesCargados.Columns.Add("DNI",       "DNI");
            dgvClientesCargados.Columns.Add("Nombre",    "Nombre");
            dgvClientesCargados.Columns.Add("Apellido",  "Apellido");
            dgvClientesCargados.Columns.Add("Telefono",  "Teléfono");
            dgvClientesCargados.Columns.Add("Email",     "Email");
            dgvClientesCargados.Columns.Add("Direccion", "Dirección");

            LimpiarEdicion();
        }

        // ── Tab 1: Cargar ────────────────────────────────────────────────

        private void btnIngresarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text) ||
                string.IsNullOrEmpty(txtNombre.Text) ||
                string.IsNullOrEmpty(txtApellido.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text) ||
                string.IsNullOrEmpty(txtTelefono.Text) ||
                string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Datos incompletos.");
                return;
            }

            try
            {
                BLL.SistemaCompraVenta.ClienteBLL bll = new BLL.SistemaCompraVenta.ClienteBLL();

                if (bll.ExisteCliente(txtDni.Text))
                {
                    MessageBox.Show("Cliente ya ingresado.");
                    return;
                }

                bool exito = bll.CrearCliente(txtDni.Text, txtNombre.Text, txtApellido.Text,
                                              txtDireccion.Text, txtTelefono.Text, txtEmail.Text);
                if (exito)
                {
                    MessageBox.Show("Cliente creado con éxito.");
                    _clientesCargados.Add(new ENT.SistemaCompraVenta.Cliente
                    {
                        Dni       = txtDni.Text,
                        Nombre    = txtNombre.Text,
                        Apellido  = txtApellido.Text,
                        Direccion = txtDireccion.Text,
                        Telefono  = txtTelefono.Text,
                        Email     = txtEmail.Text
                    });
                    LimpiarCarga();
                    CargarGrillaClientes();
                }
                else
                {
                    MessageBox.Show("Error al registrar el cliente en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        // Limpiar campos del formulario de carga
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCarga();
        }

        private void LimpiarCarga()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
        }

        private void CargarGrillaClientes()
        {
            dgvClientesCargados.Rows.Clear();

            foreach (ENT.SistemaCompraVenta.Cliente c in _clientesCargados)
                dgvClientesCargados.Rows.Add(c.Dni, c.Nombre, c.Apellido, c.Telefono, c.Email, c.Direccion);
        }

        // ── Tab 2: Buscar / Editar ────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                BLL.SistemaCompraVenta.ClienteBLL bll = new BLL.SistemaCompraVenta.ClienteBLL();
                var resultado = bll.ObtenerClientes(txtBuscarDni.Text.Trim());
                dgvClientes.DataSource = resultado;
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

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvClientes.CurrentRow == null || dgvClientes.Columns.Count == 0) return;

            var fila = dgvClientes.CurrentRow;
            string idStr = ObtenerCelda(fila, "ID_Cliente", "IdCliente", "ID");
            _idClienteSeleccionado = int.TryParse(idStr, out int idP) ? idP : 0;

            txtEditDni.Text       = ObtenerCelda(fila, "DNI", "Dni");
            txtEditNombre.Text    = ObtenerCelda(fila, "Nombre", "nombre");
            txtEditApellido.Text  = ObtenerCelda(fila, "Apellido", "apellido");
            txtEditDireccion.Text = ObtenerCelda(fila, "Direccion", "Dirección");
            txtEditTelefono.Text  = ObtenerCelda(fila, "Telefono", "Teléfono", "Tel");
            txtEditEmail.Text     = ObtenerCelda(fila, "Email", "email", "Mail");
        }

        // Intenta leer la celda por varios nombres posibles; devuelve "" si ninguno existe.
        private string ObtenerCelda(DataGridViewRow fila, params string[] nombres)
        {
            foreach (var nombre in nombres)
            {
                if (dgvClientes.Columns.Contains(nombre))
                    return fila.Cells[nombre].Value?.ToString() ?? "";
            }
            return "";
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditDni.Text))
            {
                MessageBox.Show("Seleccione un cliente de la lista antes de guardar.");
                return;
            }

            if (string.IsNullOrEmpty(txtEditNombre.Text) ||
                string.IsNullOrEmpty(txtEditApellido.Text) ||
                string.IsNullOrEmpty(txtEditDireccion.Text) ||
                string.IsNullOrEmpty(txtEditTelefono.Text) ||
                string.IsNullOrEmpty(txtEditEmail.Text))
            {
                MessageBox.Show("Datos incompletos.");
                return;
            }

            try
            {
                BLL.SistemaCompraVenta.ClienteBLL bll = new BLL.SistemaCompraVenta.ClienteBLL();

                Cliente c = new Cliente
                {
                    IdCliente = _idClienteSeleccionado,
                    Dni       = txtEditDni.Text,
                    Nombre    = txtEditNombre.Text,
                    Apellido  = txtEditApellido.Text,
                    Direccion = txtEditDireccion.Text,
                    Telefono  = txtEditTelefono.Text,
                    Email     = txtEditEmail.Text
                };

                bool exito = bll.ModificarCliente(c);
                if (exito)
                {
                    MessageBox.Show("Cliente modificado con éxito.");
                    ActualizarGrillaEdicion();
                    CargarGrillaClientes();
                }
                else
                {
                    MessageBox.Show("Error al modificar el cliente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idClienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un cliente de la lista antes de eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar al cliente " + txtEditDni.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                BLL.SistemaCompraVenta.ClienteBLL bll = new BLL.SistemaCompraVenta.ClienteBLL();
                bool exito = bll.EliminarCliente(_idClienteSeleccionado);

                if (exito)
                {
                    MessageBox.Show("Cliente eliminado con éxito.");
                    ActualizarGrillaEdicion();
                    CargarGrillaClientes();
                    LimpiarEdicion();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente.");
                }
            }
            catch (OperacionNoPermitidaException ex)
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
                BLL.SistemaCompraVenta.ClienteBLL bll = new BLL.SistemaCompraVenta.ClienteBLL();
                dgvClientes.DataSource = bll.ObtenerClientes(txtBuscarDni.Text.Trim());
            }
            catch { }
            finally
            {
                _cargando = false;
            }
        }

        private void LimpiarEdicion()
        {
            txtEditDni.Clear();
            txtEditNombre.Clear();
            txtEditApellido.Clear();
            txtEditDireccion.Clear();
            txtEditTelefono.Clear();
            txtEditEmail.Clear();
        }

        // ── Global ───────────────────────────────────────────────────────

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
