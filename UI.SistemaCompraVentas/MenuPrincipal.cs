using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ENT.SistemaCompraVenta;       // <--- Aquí viven ahora Usuario, Rol y Permisos
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
            ConfigurarPermisos();

            // Verificamos si hay alguien logueado usando el Singleton de la BLL
            if (Sesion.ObtenerInstancia().UsuarioActual != null)
            {
                lblUsuario.Text = "Hola usuario " + Sesion.ObtenerInstancia().UsuarioActual.Nombre;
                lblSesion.Text = "Sesion iniciada: " + Sesion.ObtenerInstancia().UsuarioActual.FechaHoraLogin.ToString("dd/MM/yyyy HH:mm:ss"); 
            }
        }

        private void ConfigurarPermisos()
        {
            // Usamos el objeto Usuario que ahora viene de la capa ENT
            var usuario = Sesion.ObtenerInstancia().UsuarioActual;

            if (usuario != null && usuario.Rol != null)
            {
                var rol = usuario.Rol;

                // Estos nombres de permisos deben coincidir con los que pusiste en UsuarioService
                btnUsuarios.Visible = rol.TienePermiso("GestionarUsuarios");
                btnVentas.Visible = rol.TienePermiso("RegistrarVentas");
                btnProductos.Visible = rol.TienePermiso("GestionarProductos");
                btnReportes.Visible = rol.TienePermiso("VerReportes");
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