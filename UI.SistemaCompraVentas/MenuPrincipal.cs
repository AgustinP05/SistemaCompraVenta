using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ENT.SistemaCompraVenta;       //  Usuario, Rol y Permisos
using BLL.SistemaCompraVenta.Sesion; // Aquí vive el Singleton (Sesion)

namespace UI.SistemaCompraVentas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // 1. Configuramos las visibilidades de los botones usando el patrón Composite
            ConfigurarPermisos();

            // 2. Verificamos si hay alguien logueado usando el Singleton de la BLL
            var usuarioLogueado = Sesion.ObtenerInstancia().UsuarioActual;
            if (usuarioLogueado != null)
            {
                // Usamos la propiedad calculada 'NombreMostrar' que configuramos en la entidad
                lblUsuario.Text = "Hola usuario " + usuarioLogueado.NombreMostrar;
                lblSesion.Text = "Sesion iniciada: " + usuarioLogueado.FechaHoraLogin.ToString("dd/MM/yyyy HH:mm:ss");
            }
        }

        private void ConfigurarPermisos()
        {
            // Recuperamos el usuario activo de la sesión
            var usuario = Sesion.ObtenerInstancia().UsuarioActual;

            // Verificamos que el usuario y su árbol de permisos existan
            if (usuario != null && usuario.Permisos != null)
            {
                var arbolPermisos = usuario.Permisos;

                // Evalua en cascada de forma recursiva gracias al patrón Composite
                // Los nombres de cadenas coinciden exactamente con PermisosFactory
                btnUsuarios.Visible = arbolPermisos.TienePermiso("GestionarUsuarios");
                btnVentas.Visible = arbolPermisos.TienePermiso("RegistrarVentas");
                btnProductos.Visible = arbolPermisos.TienePermiso("GestionarProductos");
                btnReportes.Visible = arbolPermisos.TienePermiso("VerReportes");
            }
            else
            {
                // Por seguridad, si ocurre un fallo o no hay usuario, ocultamos los accesos
                btnUsuarios.Visible = false;
                btnVentas.Visible = false;
                btnProductos.Visible = false;
                btnReportes.Visible = false;
            }
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormGestionUsuarios frmGestion = new FormGestionUsuarios();
            frmGestion.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FormVendedor vistaVentas = new FormVendedor();
            vistaVentas.StartPosition = FormStartPosition.CenterScreen;
            vistaVentas.ShowDialog();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormStock vistaStock = new FormStock();
            vistaStock.StartPosition = FormStartPosition.CenterScreen;
            vistaStock.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormGerente vistaGerente = new FormGerente();
            vistaGerente.StartPosition = FormStartPosition.CenterScreen;
            vistaGerente.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Sesion.ObtenerInstancia().Logout();
            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}