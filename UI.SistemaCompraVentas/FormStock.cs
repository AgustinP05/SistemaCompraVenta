using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;

namespace UI.SistemaCompraVentas
{
    public partial class FormStock : Form
    {
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
            try
            {
                Producto nuevoProducto;

                // 1. Instanciamos la subclase específica según lo elegido en pantalla
                if (cboCategoria.Text == "Calzado")
                {
                    Calzado oCalzado = new Calzado();
                    // Como el talle del calzado es numérico, lo parseamos a int
                    oCalzado.Talle = int.Parse(txtTalle.Text);
                    nuevoProducto = oCalzado; // Upcasting automático
                }
                else
                {
                    Vestimenta oVestimenta = new Vestimenta();
                    // Como el talle de vestimenta es texto, pasa directo
                    oVestimenta.Talle = txtTalle.Text;
                    nuevoProducto = oVestimenta; // Upcasting automático
                }

                // 2. Llenamos los atributos COMUNES que heredaron de 'Producto'
                nuevoProducto.Nombre = txtNombre.Text;
                nuevoProducto.Marca = txtMarca.Text;
                nuevoProducto.PrecioVenta = (double)nmPrecioVenta.Value;
                nuevoProducto.PrecioCosto = (double)nmPrecioCosto.Value;
                nuevoProducto.Stock = new Stock { Cantidad = (int)nmStockActual.Value };

                // 3. Enviamos a la BLL (Polimorfismo en acción)
                oProductoBLL.GuardarProducto(nuevoProducto);

                ActualizarGrilla();
                LimpiarCampos();
                MessageBox.Show("Producto registrado con éxito en el catálogo.");
            }
            catch (FormatException)
            {
                MessageBox.Show("Error: Asegúrese de ingresar un número válido para el talle del calzado.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message);
            }
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