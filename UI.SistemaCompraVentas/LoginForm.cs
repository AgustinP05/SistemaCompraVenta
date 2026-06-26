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
            //    Instanciamos el servicio de la BLL
            UsuarioBLL service = new UsuarioBLL();

            //    Intentamos loguear. El usuario es la parte del email anterior al '@'
            //    (ej: 'aperea'); la contraseña se deriva y valida en la BLL.
            var usuarioLogueado = service.Login(txtUsuario.Text.Trim(), txtPassword.Text.Trim());

            if (usuarioLogueado != null)
            {
                //    Guardamos el usuario en el Singleton (BLL)
                Sesion.ObtenerInstancia().UsuarioActual = usuarioLogueado;

                //    Abrimos el menú principal. Este LoginForm es el form principal
                //    (Application.Run), así que NO lo cerramos: lo ocultamos y nos
                //    enganchamos al cierre del menú para decidir qué hacer.
                MenuPrincipal menu = new MenuPrincipal();
                menu.FormClosed += Menu_FormClosed;
                this.Hide(); // Ocultamos el login
                menu.Show();
            }
            else
            {
                MessageBox.Show(
                    "Credenciales incorrectas. Intente nuevamente.",
                    "Inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Se dispara cuando se cierra el MenuPrincipal.
        //   - Logout (Sesion vacía): volvemos a mostrar este mismo login.
        //   - Cierre con la X (sigue logueado): cerramos el login => termina la app.
        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Sesion.ObtenerInstancia().UsuarioActual == null)
            {
                txtUsuario.Clear();
                txtPassword.Clear();
                this.Show();
                txtUsuario.Focus();
            }
            else
            {
                this.Close(); // cierra el form principal => Application.Run finaliza
            }
        }

    }
}