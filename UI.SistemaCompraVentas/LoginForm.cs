using BLL.SistemaCompraVenta.Services;
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
using static System.Collections.Specialized.BitVector32;

namespace UI.SistemaCompraVentas
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var service = new UsuarioService();
            var usuario = service.Login(txtUsuario.Text, txtPassword.Text);

            if (usuario != null)
            {
                Sesion.ObtenerInstancia().Login(usuario);

                var menu = new MenuPrincipal();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas");
            }
        }

        private void btnMostrarUsuarios_Click(object sender, EventArgs e)
        {
            UsuarioService usuarioService = new UsuarioService();

            DataTable tabla = usuarioService.ObtenerUsuarios();

            dataGridView1.DataSource = tabla;
        }
    }
}
