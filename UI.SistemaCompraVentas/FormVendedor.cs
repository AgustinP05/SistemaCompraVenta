using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormVendedor : Form
    {
        // Lista para el "carrito" de esta venta
        List<object> carrito = new List<object>();
        double acumuladoTotal = 0;

        public FormVendedor()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // Simulamos productos con precio
            var productos = new[] {
            new { Nombre = "Cemento 50kg", Precio = 8500 },
            new { Nombre = "Cal Hidratada", Precio = 4200 },
            new { Nombre = "Hierro del 8", Precio = 12000 }
        };

            cboProducto.DataSource = productos;
            cboProducto.DisplayMember = "Nombre"; // Lo que el usuario ve
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Obtenemos el producto seleccionado usando 'dynamic' para acceder a sus propiedades
            dynamic prod = cboProducto.SelectedItem;
            int cant = (int)nmCantidad.Value;
            double subtotal = prod.Precio * cant;

            // Agregamos al carrito
            carrito.Add(new
            {
                Producto = prod.Nombre,
                PrecioUnit = prod.Precio,
                Cantidad = cant,
                Subtotal = subtotal
            });

            // Actualizamos la grilla
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = carrito;

            // Sumamos al total
            acumuladoTotal += subtotal;
            lblTotal.Text = "TOTAL: $ " + acumuladoTotal.ToString();
        }

        private void nmCantidad_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Simulamos la confirmación con un mensaje
            MessageBox.Show("Venta registrada con éxito en el sistema.\nTotal: " + lblTotal.Text,
                            "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Limpiamos todo para la siguiente venta
            carrito.Clear();
            dgvCarrito.DataSource = null;
            acumuladoTotal = 0;
            lblTotal.Text = "TOTAL: $ 0.00";
            textBox1.Clear(); // El DNI del cliente
            nmCantidad.Value = 1;
        }
    }
}
