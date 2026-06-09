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
        ProductoBLL oProductoBLL = new ProductoBLL();
        VentaBLL oVentaBLL = new VentaBLL();
        ClienteBLL oClienteBLL = new ClienteBLL();

        Venta ventaActual = new Venta();

        public FormVendedor() { InitializeComponent(); }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            ConfigurarBuscador(cboCliente, "DNI");
            ConfigurarBuscador(cboProducto, "ID");

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

        private void cboCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCliente.SelectedItem is Cliente cli)
                lblClienteNombre.Text = $"Nombre: {cli.Apellido}, {cli.Nombre}";
            else
                lblClienteNombre.Text = "Nombre: -";
        }

        private void cboProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is Producto prod)
            {
                lblProductoNombre.Text = $"Producto: {prod.Nombre}";
                lblProductoPrecio.Text = $"Precio: {prod.PrecioVenta.ToString("N2")}";
                lblProductoStock.Text = $"Stock Disp: {prod.Stock.Cantidad}";
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
            try
            {
                if (!(cboProducto.SelectedItem is Producto prodSeleccionado))
                {
                    MessageBox.Show("Seleccioná un producto.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cantidadSolicitada = (int)nmCantidad.Value;

                oVentaBLL.ValidarStockDisponible(prodSeleccionado, cantidadSolicitada);

                DetalleVenta detalle = new DetalleVenta();
                detalle.Producto = prodSeleccionado;
                detalle.Cantidad = cantidadSolicitada;
                detalle.PrecioUnitario = prodSeleccionado.PrecioVenta;

                ventaActual.Detalles.Add(detalle);
                cboCliente.Enabled = false;

                ActualizarGrilla();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ActualizarGrilla()
        {
            dgvCarrito.Rows.Clear();
            dgvCarrito.Columns.Clear();
            dgvCarrito.Columns.Add("Codigo", "Código");
            dgvCarrito.Columns.Add("Nombre", "Nombre");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Precio", "Precio Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            foreach (DetalleVenta d in ventaActual.Detalles)
            {
                dgvCarrito.Rows.Add(
                    d.Producto.Id,
                    d.Producto.Nombre,
                    d.Cantidad,
                    d.PrecioUnitario.ToString("N2"),
                    d.DevolverSubtotal().ToString("N2")
                );
            }

            lblTotal.Text = "TOTAL VENTA: $ " + ventaActual.DevolverTotal().ToString("N2");
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
            cboCliente.Enabled = true;
        }

        /*private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventaActual.Detalles.Count == 0) return;
                if (!(cboCliente.SelectedItem is Cliente cli)) return;

                ventaActual.Cliente = cli;
                lblClienteNombre.Text = cli.NombreCompleto;
                ventaActual.Fecha = DateTime.Now;

                oVentaBLL.FinalizarVenta(ventaActual);
                MessageBox.Show("Venta registrada con éxito.");

                ventaActual = new Venta();
                cboCliente.Enabled = true;
                ActualizarGrilla();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }*/
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventaActual.Detalles.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío. Agregá productos antes de confirmar.");
                    return;
                }

                // Si el combo está vacío o no seleccionaste a nadie
                if (cboCliente.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccioná un cliente antes de confirmar la venta.");
                    return;
                }

                Cliente cli = (Cliente)cboCliente.SelectedItem;
                // Asegúrate de asignar un usuario, aunque sea uno por defecto para probar
                ventaActual.Usuario = new Usuario { ID = 1 }; // O el usuario que esté logueado
                ventaActual.Cliente = cli;
                ventaActual.Fecha = DateTime.Now;

                oVentaBLL.FinalizarVenta(ventaActual);
                ventaActual.Cliente = cli;
                ventaActual.Fecha = DateTime.Now;

                oVentaBLL.FinalizarVenta(ventaActual);
                MessageBox.Show("¡Venta registrada con éxito!");

                ventaActual = new Venta();
                cboCliente.SelectedIndex = -1;
                ActualizarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar: " + ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();

        private void nmCantidad_ValueChanged(object sender, EventArgs e) { }
    }
}