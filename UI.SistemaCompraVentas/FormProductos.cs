using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormProductos : Form
    {
        List<object> listaProductos = new List<object>();

        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Calzado");
            cboCategoria.Items.Add("Vestimenta");
            cboCategoria.Items.Add("Accesorios");

            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;

            // Productos de ejemplo acordes al negocio
            listaProductos.Add(new { NombreProducto = "Zapatillas Running Nike Air", Categoria = "Calzado", Marca = "Nike", Talle = "42", PrecioVenta = 85000.00, PrecioCosto = 55000.00, StockActual = 10, StockMinimo = 3 });
            listaProductos.Add(new { NombreProducto = "Remera Deportiva Adidas", Categoria = "Vestimenta", Marca = "Adidas", Talle = "M", PrecioVenta = 32000.00, PrecioCosto = 18000.00, StockActual = 25, StockMinimo = 5 });

            ActualizarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del producto.");
                return;
            }

            if (cboCategoria.SelectedItem == null)
            {
                MessageBox.Show("Seleccione una categoría válida.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Por favor, ingrese la marca del producto.");
                return;
            }

            listaProductos.Add(new
            {
                NombreProducto = txtNombre.Text,
                Categoria = cboCategoria.SelectedItem.ToString(),
                Marca = txtMarca.Text,
                Talle = txtTalle.Text,
                PrecioVenta = (double)nmPrecioVenta.Value,
                PrecioCosto = (double)nmPrecioCosto.Value,
                StockActual = (int)nmStockActual.Value,
                StockMinimo = (int)nmStockMinimo.Value
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
            txtMarca.Clear();
            txtTalle.Clear();
            nmPrecioVenta.Value = 0;
            nmPrecioCosto.Value = 0;
            nmStockActual.Value = 0;
            nmStockMinimo.Value = 0;
            if (cboCategoria.Items.Count > 0)
                cboCategoria.SelectedIndex = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void nmPrecioVenta_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}