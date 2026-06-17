using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;

namespace UI.SistemaCompraVentas
{
    public partial class FormGestionUsuarios : Form
    {
        // filas cargadas en esta sesión: [DNI, Nombre, Apellido, Rol, Email, FechaNac]
        private readonly List<string[]> _usuariosCargados = new List<string[]>();

        // DNI del usuario seleccionado en la grilla (key natural del SP)
        private string _dniUsuarioSeleccionado = "";

        // Solapa "Permisos por rol". Cada rol ES una familia: sus componentes son
        // permisos individuales (hojas) y otros roles incluidos como sub-familias.
        private readonly PermisoBLL oPermisoBLL = new PermisoBLL();
        private readonly RolComposicionBLL oRolComposicionBLL = new RolComposicionBLL();
        private List<Componente> _permisosDisponibles = new List<Componente>();
        private List<Componente> _permisosOtorgados = new List<Componente>();

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            lstPermDisponibles.SelectionMode = SelectionMode.MultiExtended;
            lstPermOtorgados.SelectionMode = SelectionMode.MultiExtended;

            // Al seleccionar una familia en cualquiera de las listas, se exhiben
            // sus permisos individuales (hijos del Composite) en la grilla inferior.
            lstPermDisponibles.SelectedIndexChanged += ListaPermisos_SelectedIndexChanged;
            lstPermOtorgados.SelectedIndexChanged += ListaPermisos_SelectedIndexChanged;

            dgvPermisosFamilia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPermisosFamilia.Columns.Add("colIdPermiso", "ID");
            dgvPermisosFamilia.Columns.Add("colNombrePermiso", "Permiso");
            dgvPermisosFamilia.Columns["colIdPermiso"].FillWeight = 20;
            dgvPermisosFamilia.Columns["colNombrePermiso"].FillWeight = 80;

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
                cboRolPermisos.DisplayMember = "NombreRol";
                cboRolPermisos.ValueMember   = "ID_Rol";
                cboRolPermisos.DataSource    = dt.Copy();
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
                cboRolPermisos.DisplayMember = "NombreRol";
                cboRolPermisos.ValueMember   = "ID_Rol";
                cboRolPermisos.DataSource    = fallback.Copy();
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
                OcultarColumnasUsuarios();
                LimpiarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message);
            }
        }

        // ID_Rol se usa internamente (al seleccionar la fila se setea el combo),
        // pero no tiene sentido mostrarlo en la grilla.
        private void OcultarColumnasUsuarios()
        {
            if (dgvUsuarios.Columns.Contains("ID_Rol"))
                dgvUsuarios.Columns["ID_Rol"].Visible = false;
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
                OcultarColumnasUsuarios();
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

        // ── Tab 3: Permisos por rol ───────────────────────────────────────

        private void cboRolPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPermisos();
        }

        private void CargarPermisos()
        {
            if (!int.TryParse(cboRolPermisos.SelectedValue?.ToString(), out int idRol))
                return;

            try
            {
                // Hojas: catálogo de permisos individuales y los que ya tiene el rol.
                List<Permiso> todosPermisos = oPermisoBLL.ListarTodos();
                HashSet<int> idsPermisosRol = new HashSet<int>();
                foreach (Permiso p in oPermisoBLL.ListarPorRol(idRol)) idsPermisosRol.Add(p.ID_Permiso);

                // Sub-familias: los otros roles que este rol contiene (Composite).
                HashSet<int> idsSubRolesDelRol = new HashSet<int>();
                foreach (Rol r in oRolComposicionBLL.SubRolesDeRol(idRol)) idsSubRolesDelRol.Add(r.ID_Rol);

                _permisosDisponibles = new List<Componente>();
                _permisosOtorgados = new List<Componente>();

                // Cada OTRO rol es una sub-familia candidata (un rol no se contiene a sí mismo).
                // Se arma su árbol Composite para poder exhibir sus permisos efectivos.
                foreach (DataRow fila in TablaRoles().Rows)
                {
                    int idOtro = Convert.ToInt32(fila["ID_Rol"]);
                    if (idOtro == idRol) continue;

                    FamiliaPermisos subFamilia =
                        oRolComposicionBLL.ConstruirArbolDeRol(idOtro, fila["NombreRol"].ToString());

                    if (idsSubRolesDelRol.Contains(idOtro)) _permisosOtorgados.Add(subFamilia);
                    else _permisosDisponibles.Add(subFamilia);
                }

                // Permisos individuales (hojas), igual que cualquier componente.
                foreach (Permiso p in todosPermisos)
                {
                    if (idsPermisosRol.Contains(p.ID_Permiso)) _permisosOtorgados.Add(p);
                    else _permisosDisponibles.Add(p);
                }

                RefrescarListasPermisos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar los permisos: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Catálogo de roles cargado en el combo (DataTable con ID_Rol / NombreRol).
        private DataTable TablaRoles()
        {
            return (DataTable)cboRolPermisos.DataSource;
        }

        private void RefrescarListasPermisos()
        {
            // Sin DisplayMember: cada nodo se muestra con su ToString()
            // ("[Rol] ..." para los roles-familia, el nombre para los permisos).
            lstPermDisponibles.DataSource = null;
            lstPermDisponibles.DataSource = _permisosDisponibles;

            lstPermOtorgados.DataSource = null;
            lstPermOtorgados.DataSource = _permisosOtorgados;

            LimpiarGrillaFamilia();
        }

        // Si lo seleccionado es un rol (sub-familia), muestra sus permisos efectivos
        // (en cascada, incluidos los de sus propios sub-roles). Si es un permiso suelto, limpia.
        private void ListaPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox lista = sender as ListBox;
            if (!(lista?.SelectedItem is FamiliaPermisos familia))
            {
                LimpiarGrillaFamilia();
                return;
            }

            Dictionary<int, string> permisos = new Dictionary<int, string>();
            RecolectarPermisos(familia, permisos);

            dgvPermisosFamilia.Rows.Clear();
            foreach (KeyValuePair<int, string> par in permisos)
                dgvPermisosFamilia.Rows.Add(par.Key, par.Value);

            lblPermisosFamilia.Text = "Permisos del rol: " + familia.Nombre;
        }

        // Recorre el Composite y junta los permisos hoja (sin repetir), bajando por los sub-roles.
        private void RecolectarPermisos(FamiliaPermisos familia, Dictionary<int, string> acumulado)
        {
            foreach (Componente hijo in familia.ObtenerHijos)
            {
                if (hijo is Permiso p) acumulado[p.ID_Permiso] = p.Nombre;
                else if (hijo is FamiliaPermisos sub) RecolectarPermisos(sub, acumulado);
            }
        }

        private void LimpiarGrillaFamilia()
        {
            dgvPermisosFamilia.Rows.Clear();
            lblPermisosFamilia.Text = "Permisos del rol seleccionado:";
        }

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            MoverPermisos(lstPermDisponibles, _permisosDisponibles, _permisosOtorgados);
        }

        private void btnQuitarPermiso_Click(object sender, EventArgs e)
        {
            MoverPermisos(lstPermOtorgados, _permisosOtorgados, _permisosDisponibles);
        }

        private void MoverPermisos(ListBox origen, List<Componente> listaOrigen, List<Componente> listaDestino)
        {
            if (origen.SelectedItems.Count == 0) return;

            List<Componente> seleccionados = new List<Componente>();
            foreach (object item in origen.SelectedItems)
                seleccionados.Add((Componente)item);

            foreach (Componente c in seleccionados)
            {
                listaOrigen.Remove(c);
                listaDestino.Add(c);
            }

            RefrescarListasPermisos();
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(cboRolPermisos.SelectedValue?.ToString(), out int idRol))
            {
                MessageBox.Show("Seleccioná un rol.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Separa lo otorgado en sub-roles (familias) y permisos individuales (hojas).
            List<int> idsSubRoles = new List<int>();
            List<Permiso> permisos = new List<Permiso>();
            foreach (Componente c in _permisosOtorgados)
            {
                if (c is FamiliaPermisos f) idsSubRoles.Add(f.ID_Familia); // ID_Familia = ID del rol
                else if (c is Permiso p) permisos.Add(p);
            }

            try
            {
                oPermisoBLL.GuardarPermisosDeRol(idRol, permisos);
                oRolComposicionBLL.GuardarSubRolesDeRol(idRol, idsSubRoles);
                MessageBox.Show("Permisos del rol actualizados con éxito.");
                CargarPermisos(); // refresca el árbol (la composición pudo cambiar)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
