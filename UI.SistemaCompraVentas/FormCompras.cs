using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Sesion;

namespace UI.SistemaCompraVentas
{
    public partial class FormCompras : Form
    {
        ProductoBLL oProductoBLL = new ProductoBLL();
        CompraBLL oCompraBLL = new CompraBLL();
        ProveedorBLL oProveedorBLL = new ProveedorBLL();

        Compra compraActual = new Compra();

        // Listas en memoria para resolver el CUIT / SKU que se tipea.
        List<Proveedor> proveedores = new List<Proveedor>();
        // Solo las variantes de las marcas del proveedor elegido (se cargan al seleccionarlo).
        List<ProductoVariante> variantes = new List<ProductoVariante>();
        int idProveedorCargado = 0;

        public FormCompras() { InitializeComponent(); }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            proveedores = oProveedorBLL.ListarProveedores();
            // Las variantes se cargan recién al elegir un proveedor (se filtran por sus marcas).

            dgvCarrito.Columns.Add("SKU",      "SKU");
            dgvCarrito.Columns.Add("Nombre",   "Nombre");
            dgvCarrito.Columns.Add("Marca",    "Marca");
            dgvCarrito.Columns.Add("Talle",    "Talle");
            dgvCarrito.Columns.Add("Color",    "Color");
            dgvCarrito.Columns.Add("Cantidad", "Cantidad");
            dgvCarrito.Columns.Add("Precio",   "Costo Unit.");
            dgvCarrito.Columns.Add("Subtotal", "Subtotal");
            dgvCarrito.Columns["Nombre"].MinimumWidth = 200;
            dgvCarrito.Columns["Precio"].MinimumWidth = 100;
            dgvCarrito.Columns["Nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCarrito.Columns["Precio"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ActualizarGrilla();

            MostrarComprador();
            ActualizarNumeroCompra();

            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
            timerFecha.Start();
        }

        private void MostrarComprador()
        {
            Usuario u = Sesion.ObtenerInstancia().UsuarioActual;
            lblComprador.Text = u != null
                ? $"Encargado de compras: {$"{u.Nombre} {u.Apellido}".Trim()}"
                : "Encargado de compras: -";
        }

        private void ActualizarNumeroCompra()
        {
            try { lblNumeroCompra.Text = "Orden N°: " + oCompraBLL.ObtenerProximoNumeroCompra(); }
            catch { lblNumeroCompra.Text = "Orden N°: -"; }
        }

        private void timerFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = "Fecha: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void txtProveedor_TextChanged(object sender, EventArgs e)
        {
            Proveedor prov = BuscarProveedorPorCuit(txtProveedor.Text.Trim());
            lblProveedorNombre.Text = prov != null
                ? $"Proveedor: {prov.RazonSocial}"
                : "Proveedor: -";

            CargarVariantesDelProveedor(prov);
        }

        // Carga en memoria solo las variantes de las marcas que provee el proveedor.
        // Si no hay proveedor válido, deja la lista vacía (no se puede comprar nada todavía).
        private void CargarVariantesDelProveedor(Proveedor prov)
        {
            int idNuevo = prov?.IdProveedor ?? 0;
            if (idNuevo == idProveedorCargado) return; // ya está cargado (o sigue sin proveedor)

            idProveedorCargado = idNuevo;
            variantes = idNuevo > 0
                ? oProductoBLL.ListarVariantesPorProveedor(idNuevo)
                : new List<ProductoVariante>();

            // Reevalúa el SKU tipeado contra el nuevo catálogo (puede dejar de ser válido).
            txtSku_TextChanged(null, EventArgs.Empty);
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
                lblProductoPrecio.Text = $"Costo: {v.PrecioCosto:N2}";
                lblProductoStock.Text  = $"Stock actual: {v.Cantidad}";
            }
            else
            {
                lblProductoNombre.Text = "Producto: -";
                lblProductoMarca.Text  = "Marca: -";
                lblProductoColor.Text  = "Color: -";
                lblProductoTalle.Text  = "Talle: -";
                lblProductoPrecio.Text = "Costo: -";
                lblProductoStock.Text  = "Stock actual: -";
            }
        }

        private Proveedor BuscarProveedorPorCuit(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit)) return null;
            return proveedores.Find(p => p.Cuit == cuit);
        }

        private ProductoVariante BuscarVariantePorSku(string skuTexto)
        {
            if (int.TryParse(skuTexto, out int sku))
                return variantes.Find(v => v.SKU == sku);
            return null;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = BuscarProveedorPorCuit(txtProveedor.Text.Trim());
            if (proveedor == null)
            {
                MessageBox.Show("Ingresá o buscá un proveedor válido antes de agregar productos.", "Atención",
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

            // En compras no se valida stock disponible: la orden lo va a INCREMENTAR
            // cuando el encargado de Stock la recepcione.
            compraActual.Detalles.Add(new DetalleCompra
            {
                Variante       = variante,
                Cantidad       = cantidad,
                PrecioUnitario = variante.PrecioCosto
            });

            txtProveedor.Enabled    = false;
            buscarProveedor.Enabled = false;
            ActualizarGrilla();
        }

        private void ActualizarGrilla()
        {
            dgvCarrito.Rows.Clear();

            foreach (DetalleCompra d in compraActual.Detalles)
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

            lblTotal.Text = "TOTAL ORDEN: $ " + compraActual.DevolverTotal().ToString("N2");
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.CurrentRow != null)
            {
                compraActual.Detalles.RemoveAt(dgvCarrito.CurrentRow.Index);
                ActualizarGrilla();
            }
            else
            {
                MessageBox.Show("No hay ningún item seleccionado para eliminar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelarCompra_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Vaciar la orden?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                compraActual            = new Compra();
                txtProveedor.Enabled    = true;
                buscarProveedor.Enabled = true;
                ActualizarGrilla();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (compraActual.Detalles.Count == 0)
                {
                    MessageBox.Show("La orden está vacía. Agregá productos antes de generarla.");
                    return;
                }

                Proveedor proveedor = BuscarProveedorPorCuit(txtProveedor.Text.Trim());
                if (proveedor == null)
                {
                    MessageBox.Show("Por favor, ingresá o buscá un proveedor válido antes de generar la orden.");
                    return;
                }

                compraActual.Proveedor = proveedor;
                compraActual.Fecha     = DateTime.Now;
                compraActual.Usuario   = Sesion.ObtenerInstancia().UsuarioActual ?? new Usuario { ID = 1 };

                int nroOrden = oCompraBLL.RegistrarCompra(compraActual);

                MessageBox.Show(
                    $"Orden de compra N° {nroOrden} generada en estado PENDIENTE.\n\n" +
                    "El encargado de Stock deberá recepcionarla para que el stock se actualice.",
                    "Orden registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                compraActual            = new Compra();
                txtProveedor.Enabled    = true;
                buscarProveedor.Enabled = true;
                txtProveedor.Clear();
                ActualizarGrilla();
                ActualizarNumeroCompra();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la orden: " + ex.Message);
            }
        }

        private void buscarProveedor_Click(object sender, EventArgs e)
        {
            using (FormBuscarProveedor buscador = new FormBuscarProveedor())
            {
                if (buscador.ShowDialog() != DialogResult.OK || buscador.ProveedorSeleccionado == null)
                    return;

                Proveedor elegido = buscador.ProveedorSeleccionado;

                // Lo dejo en la lista para poder resolver el CUIT al generar la orden.
                if (!proveedores.Exists(p => p.Cuit == elegido.Cuit))
                    proveedores.Add(elegido);

                // Al setear el texto se dispara txtProveedor_TextChanged y se actualiza el label.
                txtProveedor.Text = elegido.Cuit;
            }
        }

        private void buscarSku_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = BuscarProveedorPorCuit(txtProveedor.Text.Trim());

            using (FormBuscarProducto buscador = new FormBuscarProducto())
            {
                // Con proveedor: el buscador se limita a sus marcas.
                // Sin proveedor (modo "SKU primero"): catálogo completo; después
                // resolvemos el proveedor a partir del SKU elegido.
                if (proveedor != null)
                    buscador.IdProveedorFiltro = proveedor.IdProveedor;

                if (buscador.ShowDialog() != DialogResult.OK || buscador.SkuSeleccionado == 0)
                    return;

                txtSku.Text = buscador.SkuSeleccionado.ToString();

                if (proveedor == null)
                    ResolverProveedorDesdeSku(avisarSiNoExiste: true);
            }
        }

        // Modo "SKU primero": si todavía no hay proveedor elegido, resuelve el proveedor
        // a partir del SKU (la marca del producto lo determina de forma única) y lo carga.
        private void ResolverProveedorDesdeSku(bool avisarSiNoExiste = false)
        {
            // Si ya hay un proveedor válido, no pisamos su elección.
            if (BuscarProveedorPorCuit(txtProveedor.Text.Trim()) != null) return;
            if (!int.TryParse(txtSku.Text.Trim(), out int sku)) return;

            Proveedor prov = oProveedorBLL.ObtenerProveedorPorSku(sku);
            if (prov == null)
            {
                if (avisarSiNoExiste)
                    MessageBox.Show("No se encontró ningún proveedor para el SKU " + sku + ".",
                        "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!proveedores.Exists(p => p.Cuit == prov.Cuit))
                proveedores.Add(prov);

            // Al setear el CUIT se dispara la carga de variantes del proveedor;
            // luego re-evaluamos el SKU para mostrar sus datos.
            txtProveedor.Text = prov.Cuit;
            txtSku_TextChanged(null, EventArgs.Empty);
        }

        // Al salir del campo SKU, si no hay proveedor elegido, intentamos resolverlo
        // (silencioso: no molesta con avisos si el SKU está incompleto o no existe).
        private void txtSku_Leave(object sender, EventArgs e)
        {
            ResolverProveedorDesdeSku(avisarSiNoExiste: false);
        }

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
