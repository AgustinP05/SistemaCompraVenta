using System;
using System.Data;
using System.Windows.Forms;
// --- CAMBIOS CLAVE AQUÍ ---
using ENT.SistemaCompraVenta;      // Traemos Usuario, Rol y Permisos de la nueva capa
using BLL.SistemaCompraVenta.Services; // Para usar UsuarioService
using BLL.SistemaCompraVenta.Sesion;   // Para usar el Singleton (Sesion)

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

            // 2. Intentamos loguear (service ahora devuelve un Usuario de la capa ENT)
            //var usuarioLogueado = service.Login(txtUsuario.Text, txtPassword.Text);
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