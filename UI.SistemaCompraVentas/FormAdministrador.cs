using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormGestionUsuarios : Form
    {
        private static readonly List<string> roles = new List<string>
            { "Administrador", "Vendedor", "Stock", "Gerente" };

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            cboRoles.DataSource = new List<string>(roles);
            cboEditRoles.DataSource = new List<string>(roles);

            dgvUsuariosCargados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LimpiarEdicion();
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

                bool exito = bll.CrearUsuario(
                    txtDni.Text,
                    txtNombre.Text,
                    txtApellido.Text,        
                    txtPassword.Text,       
                    cboRoles.SelectedItem.ToString(),
                    txtEmail.Text,           
                    dtpFechaNacimiento.Value 
                );
                if (exito)
                {
                    MessageBox.Show("Usuario " + txtNombre.Text + " " + txtApellido.Text +
                                    " registrado correctamente en la base de datos.");
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
            cboRoles.SelectedIndex = 0;
        }

        private void CargarGrillaUsuarios()
        {
            try
            {
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                dgvUsuariosCargados.DataSource = bll.ObtenerUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error DAL");
            }
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
            txtEditDni.Text      = fila.Cells["DNI"].Value?.ToString() ?? "";
            txtEditNombre.Text   = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txtEditApellido.Text = fila.Cells["Apellido"].Value?.ToString() ?? "";

            string rolFila = fila.Cells["Rol"].Value?.ToString() ?? "";
            int idx = cboEditRoles.Items.IndexOf(rolFila);
            cboEditRoles.SelectedIndex = idx >= 0 ? idx : 0;
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEditDni.Text))
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

                     bool exito = bll.ModificarUsuario(
                     txtEditDni.Text,
                     txtEditNombre.Text,
                     txtEditApellido.Text,
                     txtEditPassword.Text,       
                     cboEditRoles.SelectedItem.ToString(),
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
            if (string.IsNullOrEmpty(txtEditDni.Text))
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
                bool exito = bll.EliminarUsuario(txtEditDni.Text);

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
            txtEditDni.Clear();
            txtEditNombre.Clear();
            txtEditApellido.Clear();
            txtEditPassword.Clear();
            txtEditEmail.Clear();
            dtpEditFechaNacimiento.Value = System.DateTime.Today;
            cboEditRoles.SelectedIndex = 0;
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
