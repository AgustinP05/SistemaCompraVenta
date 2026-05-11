using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormProductos : Form
    {
        // Lista temporal para simular la base de datos
        List<object> listaProductos = new List<object>();

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            // Limpiamos antes de cargar para evitar duplicados
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Hierros");
            cboCategoria.Items.Add("Cementos");
            cboCategoria.Items.Add("Áridos");
            cboCategoria.Items.Add("Herramientas");

            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;

            // Simulamos productos iniciales
            listaProductos.Add(new { Nombre = "Cemento Avellaneda 50kg", Categoria = "Cementos", Precio = 8500.00, Stock = 120 });
            listaProductos.Add(new { Nombre = "Hierro del 12", Categoria = "Hierros", Precio = 15400.00, Stock = 45 });

            ActualizarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.");
                return;
            }

            // Validación de categoría (por si no seleccionó nada)
            if (cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría válida.");
                return;
            }

            // Agregamos a la lista
            listaProductos.Add(new
            {
                Nombre = txtNombre.Text,
                Categoria = cboCategoria.SelectedItem.ToString(),
                Precio = (double)nmPrecio.Value,
                Stock = (int)nmStock.Value
            });

            ActualizarGrilla();
            LimpiarCampos();
            MessageBox.Show("Producto registrado correctamente.");
        }

        private void ActualizarGrilla()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = listaProductos;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            nmPrecio.Value = 0;
            nmStock.Value = 0;
            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;
        }
    }
}