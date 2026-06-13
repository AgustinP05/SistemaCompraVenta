using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormGestionUsuarios : Form
    {
        // filas cargadas en esta sesión: [DNI, Nombre, Apellido, Rol, Email, FechaNac]
        private readonly List<string[]> _usuariosCargados = new List<string[]>();

        // DNI del usuario seleccionado en la grilla (key natural del SP)
        private string _dniUsuarioSeleccionado = "";

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            CargarCombosRoles();

            dgvUsuariosCargados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuariosCargados.Columns.Add("DNI",             "DNI");
            dgvUsuariosCargados.Columns.Add("Nombre",          "Nombre");
            dgvUsuariosCargados.Columns.Add("Apellido",        "Apellido");
            dgvUsuariosCargados.Columns.Add("Rol",             "Rol");
            dgvUsuariosCargados.Columns.Add("Email",           "Email");
            dgvUsuariosCargados.Columns.Add("FechaNacimiento", "Fecha Nac.");

            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LimpiarEdicion();
        }

        private void CargarCombosRoles()
        {
            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                DataTable dt = bll.ObtenerRoles();
                cboRoles.DisplayMember    = "NombreRol";
                cboRoles.ValueMember      = "ID_Rol";
                cboRoles.DataSource       = dt;
                cboEditRoles.DisplayMember = "NombreRol";
                cboEditRoles.ValueMember   = "ID_Rol";
                cboEditRoles.DataSource    = dt.Copy();
            }
            catch
            {
                // Si la DB no está disponible, usa lista hardcodeada como fallback
                var fallback = new DataTable();
                fallback.Columns.Add("ID_Rol",    typeof(int));
                fallback.Columns.Add("NombreRol", typeof(string));
                fallback.Rows.Add(1, "Administrador");
                fallback.Rows.Add(2, "Vendedor");
                fallback.Rows.Add(3, "Stock");
                fallback.Rows.Add(4, "Gerente");
                cboRoles.DisplayMember    = "NombreRol";
                cboRoles.ValueMember      = "ID_Rol";
                cboRoles.DataSource       = fallback;
                cboEditRoles.DisplayMember = "NombreRol";
                cboEditRoles.ValueMember   = "ID_Rol";
                cboEditRoles.DataSource    = fallback.Copy();
            }
        }

        // ── Tab 1: Cargar ────────────────────────────────────────────────

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, cargue datos del usuario para continuar.");
                return;
            }

            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();

                int idRol = (int)cboRoles.SelectedValue;
                bool exito = bll.CrearUsuario(
                    txtDni.Text,
                    txtNombre.Text,
                    txtApellido.Text,
                    txtPassword.Text,
                    idRol,
                    txtEmail.Text,
                    dtpFechaNacimiento.Value
                );
                if (exito)
                {
                    MessageBox.Show("Usuario " + txtNombre.Text + " " + txtApellido.Text +
                                    " registrado correctamente en la base de datos.");
                    _usuariosCargados.Add(new string[]
                    {
                        txtDni.Text,
                        txtNombre.Text,
                        txtApellido.Text,
                        cboRoles.Text,
                        txtEmail.Text,
                        dtpFechaNacimiento.Value.ToShortDateString()
                    });
                    LimpiarCarga();
                    CargarGrillaUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCarga();
        }

        private void LimpiarCarga()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            dtpFechaNacimiento.Value = System.DateTime.Today;
            if (cboRoles.Items.Count > 0) cboRoles.SelectedIndex = 0;
        }

        private void CargarGrillaUsuarios()
        {
            dgvUsuariosCargados.Rows.Clear();

            foreach (string[] u in _usuariosCargados)
                dgvUsuariosCargados.Rows.Add(u[0], u[1], u[2], u[3], u[4], u[5]);
        }

        // ── Tab 2: Buscar / Editar ────────────────────────────────────────

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                dgvUsuarios.DataSource = bll.ObtenerUsuarios(txtBuscarDni.Text.Trim());
                LimpiarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null) return;

            var fila = dgvUsuarios.CurrentRow;

            _dniUsuarioSeleccionado = fila.Cells["DNI"].Value?.ToString() ?? "";
            txtEditDni.Text         = _dniUsuarioSeleccionado;
            txtEditNombre.Text      = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txtEditApellido.Text    = fila.Cells["Apellido"].Value?.ToString() ?? "";
            txtEditEmail.Text       = LeerCelda(fila, "Email", "email", "Mail");

            // Seleccionar rol: por ID_Rol si el SP lo devuelve, si no por nombre
            string idRolStr = LeerCelda(fila, "ID_Rol");
            if (int.TryParse(idRolStr, out int idRol) && idRol > 0)
            {
                cboEditRoles.SelectedValue = idRol;
            }
            else
            {
                string rolNombre = LeerCelda(fila, "Rol");
                foreach (DataRow dr in ((System.Data.DataTable)cboEditRoles.DataSource).Rows)
                    if (dr["NombreRol"].ToString() == rolNombre)
                    { cboEditRoles.SelectedValue = dr["ID_Rol"]; break; }
            }

            string fechaStr = LeerCelda(fila, "FechaNacimiento", "Fecha_Nacimiento", "FechaNac");
            if (DateTime.TryParse(fechaStr, out DateTime fecha))
                dtpEditFechaNacimiento.Value = fecha;
        }

        private string LeerCelda(DataGridViewRow fila, params string[] nombres)
        {
            foreach (var nombre in nombres)
                if (dgvUsuarios.Columns.Contains(nombre))
                    return fila.Cells[nombre].Value?.ToString() ?? "";
            return "";
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_dniUsuarioSeleccionado))
            {
                MessageBox.Show("Seleccione un usuario de la lista antes de guardar.");
                return;
            }

            if (string.IsNullOrEmpty(txtEditNombre.Text))
            {
                MessageBox.Show("Por favor, complete los datos del usuario.");
                return;
            }

            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();

                int idRolEdit = (int)cboEditRoles.SelectedValue;
                bool exito = bll.ModificarUsuario(
                    _dniUsuarioSeleccionado,
                    txtEditNombre.Text,
                    txtEditApellido.Text,
                    txtEditPassword.Text,
                    idRolEdit,
                    txtEditEmail.Text,
                    dtpEditFechaNacimiento.Value
                );
                if (exito)
                {
                    MessageBox.Show("Usuario modificado con éxito.");
                    ActualizarGrillaEdicion();
                    CargarGrillaUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al modificar el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_dniUsuarioSeleccionado))
            {
                MessageBox.Show("Seleccione un usuario de la lista antes de eliminar.");
                return;
            }

            var confirmacion = MessageBox.Show(
                "¿Está seguro que desea eliminar al usuario " + txtEditDni.Text + "?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion != DialogResult.Yes) return;

            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                bool exito = bll.EliminarUsuario(_dniUsuarioSeleccionado);

                if (exito)
                {
                    MessageBox.Show("Usuario eliminado con éxito.");
                    ActualizarGrillaEdicion();
                    CargarGrillaUsuarios();
                    LimpiarEdicion();
                }
                else
                {
                    MessageBox.Show("Error al eliminar el usuario.");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE") || ex.Message.Contains("FK_"))
                    MessageBox.Show("No se puede eliminar el usuario porque tiene operaciones registradas en el sistema.",
                                    "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void ActualizarGrillaEdicion()
        {
            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                dgvUsuarios.DataSource = bll.ObtenerUsuarios(txtBuscarDni.Text.Trim());
            }
            catch { }
        }

        private void LimpiarEdicion()
        {
            _dniUsuarioSeleccionado = "";
            txtEditDni.Clear();
            txtEditNombre.Clear();
            txtEditApellido.Clear();
            txtEditPassword.Clear();
            txtEditEmail.Clear();
            dtpEditFechaNacimiento.Value = System.DateTime.Today;
            if (cboEditRoles.Items.Count > 0) cboEditRoles.SelectedIndex = 0;
        }

        // ── Global ───────────────────────────────────────────────────────

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuariosCargados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtEditEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEditEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblEditFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void dtpEditFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cboEditRoles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtEditNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblEditNombre_Click(object sender, EventArgs e)
        {

        }

        private void lblEditRol_Click(object sender, EventArgs e)
        {

        }

        private void datosDelUsuario_Enter(object sender, EventArgs e)
        {

        }
    }
}
