using System;
using System.Data;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Services;
using BLL.SistemaCompraVenta.Sesion;

namespace UI.SistemaCompraVentas
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin; 

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 1. Instanciamos el servicio de la BLL
            UsuarioBLL service = new UsuarioBLL();

            // 2. Intentamos loguear (service devuelve un Usuario de la capa ENT, o null)
            var usuarioLogueado = service.Login(txtUsuario.Text, txtPassword.Text);

            if (usuarioLogueado != null)
            {
                // 3. Guardamos el usuario en el Singleton (BLL)
                Sesion.ObtenerInstancia().UsuarioActual = usuarioLogueado;

                MessageBox.Show("¡Bienvenido " + usuarioLogueado.Nombre + "!");

                // 4. Abrimos el menú principal
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();

                this.Hide(); // Ocultamos el login
            }
            else
            {
                MessageBox.Show("Credenciales incorrectas. Intente nuevamente.");
            }
        }

    }
}