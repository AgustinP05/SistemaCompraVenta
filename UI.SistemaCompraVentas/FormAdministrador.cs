using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormGestionUsuarios : Form
    {
        // Lista en memoria para simular la BD
        List<object> listaUsuariosSimulados = new List<object>();

        public FormGestionUsuarios()
        {
            InitializeComponent();
        }

        private void FormGestionUsuarios_Load(object sender, EventArgs e)
        {
            // Cargamos los roles en el ComboBox apenas abre la ventana
            List<string> roles = new List<string> { "Administrador", "Vendedor", "Stock", "Gerente" };
            cboRoles.DataSource = roles;

            // Estética de la grilla
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        /*
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación simple
            if (string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, cargue DNI y Nombre para continuar.");
                return;
            }

            // Creamos un objeto con los datos cargados
            var nuevoUsuario = new
            {
                DNI = txtDni.Text,
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Rol = cboRoles.SelectedItem.ToString()
            };

            // Agregamos a la lista y refrescamos la grilla
            listaUsuariosSimulados.Add(nuevoUsuario);

            dgvUsuarios.DataSource = null; // Reset para refrescar
            dgvUsuarios.DataSource = listaUsuariosSimulados;

            MessageBox.Show("Usuario registrado correctamente (Simulación)");

            // Limpiamos los campos para el siguiente
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
        }
        */
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Validación de campos obligatorios
            if (string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Por favor, cargue DNI y Nombre para continuar.");
                return;
            }

            try
            {
                // 2. Instanciamos la BLL para guardar en la BD real
                BLL.SistemaCompraVenta.Services.UsuarioBLL bll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();

                // 3. Llamamos al método de creación (pasando el Rol seleccionado del ComboBox)
                // Nota: Asegurate que tu método en la BLL reciba estos parámetros o adaptalo
                bool exito = bll.CrearUsuario(txtNombre.Text, "1234", cboRoles.SelectedItem.ToString());

                if (exito)
                {
                    MessageBox.Show("Usuario registrado correctamente en la base de datos.");

                    // 4. Limpiamos y refrescamos la grilla
                    txtDni.Clear();
                    txtNombre.Clear();
                    txtApellido.Clear();
                    // Aquí podrías llamar a un método que recargue el DataGridView desde la BD
                }
                else
                {
                    MessageBox.Show("Error al registrar el usuario en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}