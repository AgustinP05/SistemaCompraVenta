using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Sesion;

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
            //    Configuramos las visibilidades de los botones usando el patrón Composite
            ConfigurarPermisos();
            ReordenarBotones();   

            //    Verificamos si hay alguien logueado usando el Singleton de la BLL
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
            if (usuario != null && usuario.Rol != null)
            {
                var rol = usuario.Rol;

                // Evalúa en cascada de forma recursiva gracias al patrón Composite.
                // Los nombres coinciden con los permisos cargados desde la base.
                btnUsuarios.Visible = rol.TienePermiso("GestionarUsuarios");
                btnVentas.Visible = rol.TienePermiso("RegistrarVentas");
                btnProductos.Visible = rol.TienePermiso("GestionarProductos");
                btnReportes.Visible = rol.TienePermiso("VerReportes");
                btnClientes.Visible     = rol.TienePermiso("GestionarClientes");
                btnProveedores.Visible  = rol.TienePermiso("GestionarProveedores");
                btnCompras.Visible          = rol.TienePermiso("RegistrarCompras");
                btnRecepcionCompras.Visible = rol.TienePermiso("ConfirmarCompras");
            }
            else
            {
                // Por seguridad, si ocurre un fallo o no hay usuario, ocultamos los accesos
                btnUsuarios.Visible    = false;
                btnVentas.Visible      = false;
                btnProductos.Visible   = false;
                btnReportes.Visible    = false;
                btnClientes.Visible    = false;
                btnProveedores.Visible = false;
                btnCompras.Visible          = false;
                btnRecepcionCompras.Visible = false;
            }
        }



        private void ReordenarBotones()
        {
            // Lista de botones en orden lógico 
            var botones = new List<System.Windows.Forms.Button>
            {
                btnUsuarios,         // 1
                btnClientes,         // 2
                btnProveedores,      // 3
                btnProductos,        // 4  (Gestionar Stock)
                btnCompras,          // 5  (Registrar Compra)
                btnRecepcionCompras, // 6
                btnVentas,           // 7  (Registrar Venta)
                btnReportes          // 8  (Generar Reportes)
            };

            int yInicial = 119; // misma Y que tenía btnUsuarios en el Designer
            int separacion = 46;
            int contador = 0;

            foreach (var btn in botones)
            {
                if (btn.Visible)
                {
                    btn.Location = new System.Drawing.Point(btn.Location.X, yInicial + (contador * separacion));
                    contador++;
                }
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
            FormCrearProducto vistaProductos = new FormCrearProducto();
            vistaProductos.StartPosition = FormStartPosition.CenterScreen;
            vistaProductos.ShowDialog();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormGerente vistaGerente = new FormGerente();
            vistaGerente.StartPosition = FormStartPosition.CenterScreen;
            vistaGerente.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormCrearCliente vistaClientes = new FormCrearCliente();
            vistaClientes.StartPosition = FormStartPosition.CenterScreen;
            vistaClientes.ShowDialog();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            FormCrearProveedor vistaProveedores = new FormCrearProveedor();
            vistaProveedores.StartPosition = FormStartPosition.CenterScreen;
            vistaProveedores.ShowDialog();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FormCompras vistaCompras = new FormCompras();
            vistaCompras.StartPosition = FormStartPosition.CenterScreen;
            vistaCompras.ShowDialog();
        }

        private void btnRecepcionCompras_Click(object sender, EventArgs e)
        {
            FormRecepcionCompras vistaRecepcion = new FormRecepcionCompras();
            vistaRecepcion.StartPosition = FormStartPosition.CenterScreen;
            vistaRecepcion.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Limpiamos la sesión y cerramos el menú. El LoginForm (form principal)
            // detecta el cierre y, al ver la sesión vacía, vuelve a mostrarse.
            // No creamos un LoginForm nuevo: así no quedan formularios huérfanos vivos.
            Sesion.ObtenerInstancia().Logout();
            this.Close();
        }
    }
}