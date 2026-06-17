using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using ENT.SistemaCompraVenta.Descuentos;
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

        // Listas en memoria para resolver el DNI / SKU que se tipea en los campos de texto.
        List<Cliente> clientes = new List<Cliente>();
        List<ProductoVariante> variantes = new List<ProductoVariante>();

        public FormVendedor() { InitializeComponent(); }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            clientes  = oClienteBLL.ListarClientes();
            variantes = oProductoBLL.ListarVariantes();

            dgvCarrito.Columns.Add("SKU",   "SKU");
            dgvCarrito.Columns.Add("Nombre",   "Nombre");
            dgvCarrito.Columns.Add("Marca", "Marca");
            dgvCarrito.Columns.Add("Talle",    "Talle");
            dgvCarrito.Columns.Add("Color",    "Color");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Precio",   "Precio Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");
            dgvCarrito.Columns["Nombre"].MinimumWidth = 200;
            dgvCarrito.Columns["Precio"].MinimumWidth = 100;
            dgvCarrito.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCarrito.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dgvCarrito.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();

            MostrarVendedor();
            ActualizarNumeroVenta();

            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            timerFecha.Start();

            // Opciones de descuento (patrón Strategy). El orden coincide con AplicarDescuento().
            cboDescuento.Items.Add("Sin descuento");
            cboDescuento.Items.Add("Porcentaje (%)");
            cboDescuento.Items.Add("Monto fijo ($)");
            cboDescuento.Items.Add("Por volumen (automático)");
            cboDescuento.SelectedIndex = 0; // dispara AplicarDescuento()
        }

        private void cboDescuento_SelectedIndexChanged(object sender, EventArgs e) => AplicarDescuento();
        private void nmDescuento_ValueChanged_Desc(object sender, EventArgs e) => AplicarDescuento();

        private void AplicarDescuento()
        {
            double valor = (double)nmDescuento.Value;

            switch (cboDescuento.SelectedIndex)
            {
                case 1: ventaActual.Descuento = new DescuentoPorcentaje(valor); break;
                case 2: ventaActual.Descuento = new DescuentoFijo(valor);       break;
                case 3: ventaActual.Descuento = new DescuentoPorVolumen();      break;
                default: ventaActual.Descuento = new SinDescuento();            break;
            }

            // El valor solo aplica a porcentaje o monto fijo.
            nmDescuento.Enabled = cboDescuento.SelectedIndex == 1 || cboDescuento.SelectedIndex == 2;

            ActualizarGrilla();
        }

        private void MostrarVendedor()
        {
            Usuario u = Sesion.ObtenerInstancia().UsuarioActual;
            lblVendedor.Text = u != null
                ? $"Vendedor: {$"{u.Nombre} {u.Apellido}".Trim()}"
                : "Vendedor: -";
        }

        private void ActualizarNumeroVenta()
        {
            try { lblNumeroVenta.Text = "Venta N°: " + oVentaBLL.ObtenerProximoNumeroVenta(); }
            catch { lblNumeroVenta.Text = "Venta N°: -"; }
        }

        private void timerFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void txtCliente_TextChanged(object sender, EventArgs e)
        {
            Cliente cli = BuscarClientePorDni(txtCliente.Text.Trim());
            lblClienteNombre.Text = cli != null
                ? $"Nombre: {cli.Apellido}, {cli.Nombre}"
                : "Nombre: -";
        }

        private void txtSku_TextChanged(object sender, EventArgs e)
        {
            ProductoVariante v = BuscarVariantePorSku(txtSku.Text.Trim());
            if (v != null)
            {
                lblProductoNombre.Text = $"Producto: {v.Nombre}";
                lblProductoMarca.Text  = $"Marca: {v.Marca}";
                lblProductoColor.Text  = $"Color: {v.Color}";
                lblProductoTalle.Text  = $"Talle: {v.Talle}";
                lblProductoPrecio.Text = $"Precio: {v.PrecioVenta:N2}";
                lblProductoStock.Text  = $"Stock Disp: {v.Cantidad}";
            }
            else
            {
                lblProductoNombre.Text = "Producto: -";
                lblProductoMarca.Text  = "Marca: -";
                lblProductoColor.Text  = "Color: -";
                lblProductoTalle.Text  = "Talle: -";
                lblProductoPrecio.Text = "Precio: -";
                lblProductoStock.Text  = "Stock Disp: -";
            }
        }

        private Cliente BuscarClientePorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni)) return null;
            return clientes.Find(c => c.Dni == dni);
        }

        private ProductoVariante BuscarVariantePorSku(string skuTexto)
        {
            if (int.TryParse(skuTexto, out int sku))
                return variantes.Find(v => v.SKU == sku);
            return null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = BuscarClientePorDni(txtCliente.Text.Trim());
                if (cliente == null)
                {
                    MessageBox.Show("Ingresá o buscá un cliente válido antes de agregar productos.", "Atención",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductoVariante variante = BuscarVariantePorSku(txtSku.Text.Trim());
                if (variante == null)
                {
                    MessageBox.Show("Ingresá un SKU válido.", "Atención",
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

                txtCliente.Enabled    = false;
                buscarCliente.Enabled = false;
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
                    d.Variante.SKU,
                    d.Variante.Nombre,
                    d.Variante.Marca,
                    d.Variante.Talle,
                    d.Variante.Color,
                    d.Cantidad,
                    d.PrecioUnitario.ToString("N2"),
                    d.DevolverSubtotal().ToString("N2")
                );
            }

            lblTotal.Text = "SUBTOTAL VENTA: $ " + ventaActual.DevolverSubtotal().ToString("N2");
            label4.Text   = "DESCUENTO: -$ "      + ventaActual.DevolverDescuento().ToString("N2");
            label5.Text   = "TOTAL: $ "          + ventaActual.DevolverTotal().ToString("N2");
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
                ventaActual           = new Venta();
                txtCliente.Enabled    = true;
                buscarCliente.Enabled = true;
                cboDescuento.SelectedIndex = 0;
                nmDescuento.Value = 0;
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

                Cliente cliente = BuscarClientePorDni(txtCliente.Text.Trim());
                if (cliente == null)
                {
                    MessageBox.Show("Por favor, ingresá o buscá un cliente válido antes de confirmar la venta.");
                    return;
                }

                ventaActual.Cliente = cliente;
                ventaActual.Fecha   = DateTime.Now;
                ventaActual.Usuario = Sesion.ObtenerInstancia().UsuarioActual ?? new Usuario { ID = 1 };

                int nroVenta = oVentaBLL.FinalizarVenta(ventaActual);

                DialogResult resp = MessageBox.Show(
                    "¡Venta registrada con éxito!\n\n¿Querés generar el comprobante?",
                    "Venta registrada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (resp == DialogResult.Yes)
                    GenerarComprobante(nroVenta);

                ventaActual           = new Venta();
                txtCliente.Enabled    = true;
                buscarCliente.Enabled = true;
                txtCliente.Clear();
                cboDescuento.SelectedIndex = 0;
                nmDescuento.Value = 0;
                ActualizarGrilla();
                ActualizarNumeroVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al confirmar: " + ex.Message);
            }
        }

        private void GenerarComprobante(int nroVenta)
        {
            try
            {
                // ComprobanteBLL trae los datos de la venta desde la base (vía DAL) y arma el .txt.
                string ruta = new ComprobanteBLL().GuardarComprobante(nroVenta);
                Process.Start(ruta); // lo abre con el bloc de notas
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el comprobante: " + ex.Message,
                    "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buscarCliente_Click(object sender, EventArgs e)
        {
            using (FormBuscarCliente buscador = new FormBuscarCliente())
            {
                if (buscador.ShowDialog() != DialogResult.OK || buscador.ClienteSeleccionado == null)
                    return;

                Cliente elegido = buscador.ClienteSeleccionado;

                // Lo dejo en la lista para poder resolver el DNI al confirmar la venta.
                if (!clientes.Exists(c => c.Dni == elegido.Dni))
                    clientes.Add(elegido);

                // Al setear el texto se dispara txtCliente_TextChanged y se actualiza el label.
                txtCliente.Text = elegido.Dni;
            }
        }

        private void buscarSku_Click(object sender, EventArgs e)
        {
            using (FormBuscarProducto buscador = new FormBuscarProducto())
            {
                if (buscador.ShowDialog() != DialogResult.OK || buscador.SkuSeleccionado == 0)
                    return;

                // Al setear el texto se dispara txtSku_TextChanged y se actualizan los datos del producto.
                txtSku.Text = buscador.SkuSeleccionado.ToString();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}