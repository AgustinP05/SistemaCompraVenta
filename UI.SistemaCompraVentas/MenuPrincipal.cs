using BLL.SistemaCompraVenta.Entities;
using BLL.SistemaCompraVenta.Sesion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    // Agregamos 'public' para que coincida con el Designer
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarPermisos();
            if (Sesion.ObtenerInstancia().UsuarioActual != null)
            {
                lblUsuario.Text = "Hola usuario " + Sesion.ObtenerInstancia().UsuarioActual.Nombre;
            }
        }

        private void ConfigurarPermisos()
        {
            var sesion = Sesion.ObtenerInstancia().UsuarioActual;
            if (sesion != null && sesion.Rol != null)
            {
                var rol = sesion.Rol;
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
            FormVentas vistaVentas = new FormVentas();
            vistaVentas.StartPosition = FormStartPosition.CenterScreen;
            vistaVentas.ShowDialog();
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