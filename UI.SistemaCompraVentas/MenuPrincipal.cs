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

            btnUsuarios.Visible = (rol == Rol.Administrador);
            btnVentas.Visible = (rol == Rol.Vendedor);
            btnProductos.Visible = (rol == Rol.Stock);
            btnReportes.Visible = (rol == Rol.Gerente);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Sesion.ObtenerInstancia().Logout();

            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
