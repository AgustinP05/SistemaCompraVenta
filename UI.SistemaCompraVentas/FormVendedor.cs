using System;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Sesion;

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
            cboCliente.DropDownStyle      = ComboBoxStyle.DropDown;
            cboCliente.AutoCompleteMode   = AutoCompleteMode.SuggestAppend;
            cboCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboCliente.DisplayMember      = "DNI";

            cboProducto.DropDownStyle      = ComboBoxStyle.DropDown;
            cboProducto.AutoCompleteMode   = AutoCompleteMode.SuggestAppend;
            cboProducto.AutoCompleteSource = AutoCompleteSource.ListItems;

            cboCliente.DataSource  = oClienteBLL.ListarClientes();
            cboProducto.DataSource = oProductoBLL.ListarVariantes();

            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.Columns.Add("Codigo",   "Código");
            dgvCarrito.Columns.Add("Nombre",   "Nombre");
            dgvCarrito.Columns.Add("Color",    "Color");
            dgvCarrito.Columns.Add("Talle",    "Talle");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Precio",   "Precio Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");

            ActualizarGrilla();
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
            if (cboProducto.SelectedItem is ProductoVariante v)
            {
                lblProductoNombre.Text = $"Producto: {v.Nombre}";
                lblProductoMarca.Text  = $"Marca: {v.Marca}";
                lblProductoColor.Text  = $"Color: {v.Color}";
                lblProductoPrecio.Text = $"Precio: {v.PrecioVenta:N2}";
                lblProductoStock.Text  = $"Stock Disp: {v.Cantidad}";
            }
            else
            {
                lblProductoNombre.Text = "Producto: -";
                lblProductoMarca.Text  = "Marca: -";
                lblProductoColor.Text  = "Color: -";
                lblProductoPrecio.Text = "Precio: -";
                lblProductoStock.Text  = "Stock Disp: -";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(cboProducto.SelectedItem is ProductoVariante variante))
                {
                    MessageBox.Show("Seleccioná una variante de producto.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nmCantidad.Value == 0)
                {
                    MessageBox.Show("La cantidad debe ser mayor a cero.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int cantidad = (int)nmCantidad.Value;
                oVentaBLL.ValidarStockDisponible(variante, cantidad);

                ventaActual.Detalles.Add(new DetalleVenta
                {
                    Variante       = variante,
                    Cantidad       = cantidad,
                    PrecioUnitario = variante.PrecioVenta
                });

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

            foreach (DetalleVenta d in ventaActual.Detalles)
            {
                dgvCarrito.Rows.Add(
                    d.Variante.ID_ProductoVariante,
                    d.Variante.Nombre,
                    d.Variante.Color,
                    d.Variante.Talle,
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
                ventaActual.Detalles.RemoveAt(dgvCarrito.CurrentRow.Index);
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No hay ningún item seleccionado para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Vaciar carrito?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ventaActual        = new Venta();
                cboCliente.Enabled = true;
                ActualizarGrilla();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventaActual.Detalles.Count == 0)
                {
                    MessageBox.Show("El carrito está vacío. Agregá productos antes de confirmar.");
                    return;
                }

                if (cboCliente.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccioná un cliente antes de confirmar la venta.");
                    return;
                }

                ventaActual.Cliente = (Cliente)cboCliente.SelectedItem;
                ventaActual.Fecha   = DateTime.Now;
                ventaActual.Usuario = Sesion.ObtenerInstancia().UsuarioActual ?? new Usuario { ID = 1 };

                oVentaBLL.FinalizarVenta(ventaActual);
                MessageBox.Show("¡Venta registrada con éxito!");

                ventaActual              = new Venta();
                cboCliente.Enabled       = true;
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
        private void lblClienteNombre_Click(object sender, EventArgs e) { }
    }
}