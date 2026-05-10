using BLL.SistemaCompraVenta.Entities;
using BLL.SistemaCompraVenta.Sesion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarPermisos();

            lblUsuario.Text ="Hola usuario "+Sesion.ObtenerInstancia().UsuarioActual.Nombre;
        }

        private void ConfigurarPermisos()
        {
            var rol = Sesion.ObtenerInstancia().UsuarioActual.Rol;

            btnUsuarios.Visible = rol.TienePermiso("GestionarUsuarios");

            btnVentas.Visible = rol.TienePermiso("RegistrarVentas");

            btnProductos.Visible = rol.TienePermiso("GestionarProductos");

            btnReportes.Visible = rol.TienePermiso("VerReportes");

        }
        
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            // Creamos la instancia de la pantalla de gestión
            FormGestionUsuarios frmGestion = new FormGestionUsuarios();

            // La mostramos como cuadro de diálogo
            frmGestion.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Sesion.ObtenerInstancia().Logout();

            var login = new LoginForm();
            login.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
