using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;

namespace UI.SistemaCompraVentas
{
    public partial class FormVendedor : Form
    {
        // 1. SOLO INSTANCIAMOS BLL (Nunca la DAL aquí)
        ProductoBLL oProductoBLL = new ProductoBLL();
        VentaBLL oVentaBLL = new VentaBLL();
        ClienteBLL oClienteBLL = new ClienteBLL();

        Venta ventaActual = new Venta();

        public FormVendedor() { InitializeComponent(); 
        
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            // CONFIGURACIÓN DE BUSCADORES (Escribir y sugerir)
            ConfigurarBuscador(cboCliente, "DNI");
            ConfigurarBuscador(cboProducto, "ID");

            // CARGA DE DATOS
            cboCliente.DataSource = oClienteBLL.ListarClientes();
            cboProducto.DataSource = oProductoBLL.ListarProductos();

            ActualizarGrilla();
        }

        private void ConfigurarBuscador(ComboBox combo, string miembro)
        {
            combo.DropDownStyle = ComboBoxStyle.DropDown;
            combo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combo.AutoCompleteSource = AutoCompleteSource.ListItems;
            combo.DisplayMember = miembro;
        }

        // Se dispara cuando elegís o terminás de escribir un DNI
        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem is Cliente cli)
            {
                lblClienteNombre.Text = $"Nombre: {cli.Apellido}, {cli.Nombre}";
            }
            else
            {
                lblClienteNombre.Text = "Nombre: -";
            }
        }

        // Se dispara cuando elegís o terminás de escribir un ID de producto
        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is Producto prod)
            {
                lblProductoNombre.Text = $"Producto: {prod.Nombre}";
                lblProductoPrecio.Text = $"Precio: {prod.PrecioVenta.ToString("C2")}";
                lblProductoStock.Text = $"Stock Disp: {prod.Stock}";
            }
            else
            {
                lblProductoNombre.Text = "Producto: -";
                lblProductoPrecio.Text = "Precio: -";
                lblProductoStock.Text = "Stock Disp: -";
            }
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!(cboProducto.SelectedItem is Producto prod))
            {
                MessageBox.Show("ID de producto no válido.");
                return;
            }

            int cant = (int)nmCantidad.Value;
            if (cant > prod.Stock)
            {
                MessageBox.Show("Stock insuficiente.");
                return;
            }

            DetalleVenta item = new DetalleVenta
            {
                Producto = prod,
                Cantidad = cant,
                PrecioUnitario = prod.PrecioVenta
            };

            ventaActual.Detalles.Add(item);
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvCarrito.DataSource = null;

            // Creamos una lista personalizada para la grilla
            dgvCarrito.DataSource = ventaActual.Detalles.Select(d => new {
                Código = d.Producto.ID,          // Columna de Código
                Nombre = d.Producto.Nombre,
                Cantidad = d.Cantidad,
                Precio = d.PrecioUnitario.ToString("N2"),
                Subtotal = d.Subtotal.ToString("N2") // Columna de Subtotal (Precio x Cantidad)
            }).ToList();

            // Calculamos el TOTAL general para el label grande de abajo
            ventaActual.Total = ventaActual.Detalles.Sum(d => d.Subtotal);
            lblTotal.Text = "TOTAL VENTA: $ " + ventaActual.Total.ToString("N2");
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                int fila = dgvCarrito.CurrentRow.Index;
                ventaActual.Detalles.RemoveAt(fila);
                ActualizarGrilla();
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Vaciar carrito?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ventaActual = new Venta();
                ActualizarGrilla();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventaActual.Detalles.Count == 0) return;
                if (!(cboCliente.SelectedItem is Cliente cli)) return;

                ventaActual.Cliente = $"{cli.Apellido}, {cli.Nombre}";
                ventaActual.Fecha = DateTime.Now;

                oVentaBLL.FinalizarVenta(ventaActual);
                MessageBox.Show("Venta registrada con éxito.");

                ventaActual = new Venta();
                ActualizarGrilla();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void btnSalir_Click(object sender, EventArgs e) => this.Close();

        // Este método vacío es para que no falle el Designer
        private void nmCantidad_ValueChanged(object sender, EventArgs e) { }
    }
}