using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ENT.SistemaCompraVenta; // <--- USAR ENTIDADES
using BLL.SistemaCompraVenta; // <--- USAR NEGOCIO

namespace UI.SistemaCompraVentas
{
    public partial class FormStock : Form
    {
        // Ya no usamos List<object>, usamos el servicio de negocio
        ProductoBLL oProductoBLL = new ProductoBLL();

        public FormStock()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Calzado");
            cboCategoria.Items.Add("Vestimenta");
            cboCategoria.SelectedIndex = 0;

            ActualizarGrilla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // ... (validaciones previas)

            Producto nuevoProducto;
            if (cboCategoria.Text == "Calzado")
                nuevoProducto = new Calzado { Talle = txtTalle.Text };
            else
                nuevoProducto = new Vestimenta { Talle = txtTalle.Text };

            // --- AQUÍ ESTÁ EL TRUCO: ASIGNAR LOS VALORES ---
            nuevoProducto.Nombre = txtNombre.Text;
            nuevoProducto.Marca = txtMarca.Text; 
            nuevoProducto.Categoria = cboCategoria.Text;
            nuevoProducto.PrecioVenta = (double)nmPrecioVenta.Value;
            nuevoProducto.PrecioCosto = (double)nmPrecioCosto.Value;
            nuevoProducto.Stock = (int)nmStockActual.Value;

            // Enviamos a la BLL
            oProductoBLL.GuardarProducto(nuevoProducto);

            ActualizarGrilla();
            LimpiarCampos();
            MessageBox.Show("Producto registrado con ID: " + nuevoProducto.ID);
        }

        private void ActualizarGrilla()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = oProductoBLL.ListarProductos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTalle.Clear();
            txtMarca.Clear();
            nmStockMinimo.Value = 0;
            nmPrecioCosto.Value = 0;
            nmPrecioVenta.Value = 0;
            nmStockActual.Value = 0;
        }
    }
}