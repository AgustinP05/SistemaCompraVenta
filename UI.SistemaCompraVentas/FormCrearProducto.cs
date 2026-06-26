using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    public partial class FormCrearProducto : Form
    {
        private readonly BLL.SistemaCompraVenta.ProductoBLL _bll =
            new BLL.SistemaCompraVenta.ProductoBLL();
        private readonly BLL.SistemaCompraVenta.ProveedorBLL _provBll =
            new BLL.SistemaCompraVenta.ProveedorBLL();

        private bool _cargando = false;
        private int _idProductoSeleccionado = 0;
        private string _categoriaSeleccionada = "";
        private Producto _productoVariante; // producto resuelto en la solapa SKU

        public FormCrearProducto()
        {
            InitializeComponent();
        }

        private void FormCrearProducto_Load(object sender, EventArgs e)
        {
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Calzado");
            cboCategoria.Items.Add("Vestimenta");
            cboCategoria.SelectedIndex = 0;

            dgvProductosCargados.Columns.Add("colId",        "ID");
            dgvProductosCargados.Columns.Add("colNombre",    "Nombre");
            dgvProductosCargados.Columns.Add("colMarca",     "Marca");
            dgvProductosCargados.Columns.Add("colCategoria", "Categoría");
            dgvProductosCargados.Columns.Add("colPVenta",    "P. Venta");
            dgvProductosCargados.Columns.Add("colPCosto",    "P. Costo");

            CargarMarcas();
            CargarColores();
            LimpiarEdicion();
        }

        // ── Solapa 1: Crear Producto ────────────────────────

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto p = new Producto();
                p.Nombre       = txtNombre.Text.Trim();
                p.Marca        = cboMarca.Text;
                p.ID_Categoria = IdCategoria(cboCategoria.Text);
                p.Categoria    = cboCategoria.Text;
                p.PrecioVenta  = (double)nmPrecioVenta.Value;
                p.PrecioCosto  = (double)nmPrecioCosto.Value;

                int nuevoId = _bll.GuardarProducto(p);
                MessageBox.Show("Producto creado con éxito (ID " + nuevoId + ").");

                dgvProductosCargados.Rows.Add(nuevoId, p.Nombre, p.Marca, p.Categoria,
                    p.PrecioVenta.ToString("N2"), p.PrecioCosto.ToString("N2"));

                LimpiarCarga();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e) => LimpiarCarga();

        private void LimpiarCarga()
        {
            txtNombre.Clear();
            if (cboMarca.Items.Count > 0) cboMarca.SelectedIndex = 0;
            cboCategoria.SelectedIndex = 0;
            nmPrecioVenta.Value = 0;
            nmPrecioCosto.Value = 0;
        }

        // Marca nueva: se asocia a proveedores en un diálogo y queda disponible en el combo.
        private void btnNuevaMarca_Click(object sender, EventArgs e)
        {
            using (var dlg = new FormNuevaMarca())
            {
                if (dlg.ShowDialog() != DialogResult.OK) return;

                CargarMarcas();
                if (!string.IsNullOrEmpty(dlg.MarcaCreada) && cboMarca.Items.Contains(dlg.MarcaCreada))
                    cboMarca.SelectedItem = dlg.MarcaCreada;
            }
        }

        private void CargarMarcas()
        {
            List<string> marcas = _provBll.ListarMarcas();
            cboMarca.Items.Clear();
            cboEditMarca.Items.Clear();
            foreach (string m in marcas)
            {
                cboMarca.Items.Add(m);
                cboEditMarca.Items.Add(m);
            }
            cboMarca.SelectedIndex = cboMarca.Items.Count > 0 ? 0 : -1;
        }

        // ── Solapa 2: Buscar / Editar / Eliminar ──

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                _cargando = true;
                dgvProductos.DataSource = _bll.ObtenerProductos(txtBuscar.Text.Trim());
                AjustarColumnas();
                LimpiarEdicion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar: " + ex.Message);
            }
            finally { _cargando = false; }
        }

        // El ID se muestra; solo se oculta la FK interna de categoría.
        private void AjustarColumnas()
        {
            if (dgvProductos.Columns.Contains("ID_Categoria"))
                dgvProductos.Columns["ID_Categoria"].Visible = false;
            if (dgvProductos.Columns.Contains("ID_Producto"))
                dgvProductos.Columns["ID_Producto"].HeaderText = "ID";
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargando || dgvProductos.CurrentRow == null || dgvProductos.Columns.Count == 0) return;

            var fila = dgvProductos.CurrentRow;
            _idProductoSeleccionado = GrillaHelper.LeerEntero(dgvProductos, fila, "ID_Producto", "Id");
            _categoriaSeleccionada  = GrillaHelper.LeerCelda(dgvProductos, fila, "Categoria");

            txtEditNombre.Text    = GrillaHelper.LeerCelda(dgvProductos, fila, "Nombre");
            SeleccionarMarca(cboEditMarca, GrillaHelper.LeerCelda(dgvProductos, fila, "Marca"));
            txtEditCategoria.Text = _categoriaSeleccionada; // solo lectura: la categoría no se edita
            nmEditPrecioVenta.Value = LeerPrecio(fila, "PrecioVenta");
            nmEditPrecioCosto.Value = LeerPrecio(fila, "PrecioCosto");
        }

        // Si la marca del producto no está en el catálogo, la agrega para poder mostrarla.
        private void SeleccionarMarca(ComboBox cbo, string marca)
        {
            if (string.IsNullOrEmpty(marca)) { cbo.SelectedIndex = -1; return; }
            if (!cbo.Items.Contains(marca)) cbo.Items.Add(marca);
            cbo.SelectedItem = marca;
        }

        private decimal LeerPrecio(DataGridViewRow fila, string col)
        {
            if (dgvProductos.Columns.Contains(col) &&
                decimal.TryParse(fila.Cells[col].Value?.ToString(), out decimal v))
            {
                if (v < nmEditPrecioVenta.Minimum) return nmEditPrecioVenta.Minimum;
                if (v > nmEditPrecioVenta.Maximum) return nmEditPrecioVenta.Maximum;
                return v;
            }
            return 0;
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista antes de guardar.");
                return;
            }

            try
            {
                Producto p = new Producto();
                p.Id           = _idProductoSeleccionado;
                p.Nombre       = txtEditNombre.Text.Trim();
                p.Marca        = cboEditMarca.Text;
                p.ID_Categoria = IdCategoria(_categoriaSeleccionada); // categoría bloqueada
                p.Categoria    = _categoriaSeleccionada;
                p.PrecioVenta  = (double)nmEditPrecioVenta.Value;
                p.PrecioCosto  = (double)nmEditPrecioCosto.Value;

                if (_bll.ModificarProducto(p))
                {
                    MessageBox.Show("Producto modificado con éxito.");
                    RefrescarBusqueda();
                }
                else
                    MessageBox.Show("Error al modificar el producto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idProductoSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista antes de eliminar.");
                return;
            }

            var conf = MessageBox.Show(
                "¿Está seguro que desea eliminar el producto \"" + txtEditNombre.Text + "\"?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (conf != DialogResult.Yes) return;

            try
            {
                if (_bll.EliminarProducto(_idProductoSeleccionado))
                {
                    MessageBox.Show("Producto eliminado con éxito.");
                    RefrescarBusqueda();
                    LimpiarEdicion();
                }
                else
                    MessageBox.Show("Error al eliminar el producto.");
            }
            catch (OperacionNoPermitidaException ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void RefrescarBusqueda()
        {
            try
            {
                _cargando = true;
                dgvProductos.DataSource = _bll.ObtenerProductos(txtBuscar.Text.Trim());
                AjustarColumnas();
            }
            catch { }
            finally { _cargando = false; }
        }

        private void LimpiarEdicion()
        {
            _idProductoSeleccionado = 0;
            _categoriaSeleccionada = "";
            txtEditNombre.Clear();
            cboEditMarca.SelectedIndex = -1;
            txtEditCategoria.Clear();
            nmEditPrecioVenta.Value = 0;
            nmEditPrecioCosto.Value = 0;
        }

        // ── Solapa 3: Crear Variante (SKU) ───────────────────────────────

        private void CargarColores()
        {
            cboColor.DataSource = _bll.ListarColores();
            cboColor.DisplayMember = "Nombre";
            cboColor.ValueMember = "ID_Color";
            cboColor.SelectedIndex = -1;
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var buscador = new FormBuscarProductoBase())
            {
                if (buscador.ShowDialog() == DialogResult.OK && buscador.IdProductoSeleccionado > 0)
                    txtIdProducto.Text = buscador.IdProductoSeleccionado.ToString(); // dispara ResolverProducto
            }
        }

        private void txtIdProducto_TextChanged(object sender, EventArgs e)
        {
            ResolverProducto();
        }

        // Resuelve el producto a partir del ID tipeado: muestra su nombre, carga los
        // talles de su categoría y lista sus variantes.
        private void ResolverProducto()
        {
            _productoVariante = null;
            if (int.TryParse(txtIdProducto.Text.Trim(), out int id) && id > 0)
                _productoVariante = _bll.ObtenerProductoPorId(id);

            if (_productoVariante != null)
            {
                lblProductoNombre.Text = _productoVariante.Nombre + "  ·  " +
                                         _productoVariante.Marca + "  ·  " + _productoVariante.Categoria;

                cboTalle.DataSource = _bll.ListarTallesPorCategoria(_productoVariante.ID_Categoria);
                cboTalle.DisplayMember = "Valor";
                cboTalle.ValueMember = "ID_Talle";
                cboTalle.SelectedIndex = -1;

                CargarVariantes(_productoVariante.Id);
            }
            else
            {
                lblProductoNombre.Text = "Producto: -";
                cboTalle.DataSource = null;
                dgvVariantes.DataSource = null;
            }
        }

        private void CargarVariantes(int idProducto)
        {
            dgvVariantes.DataSource = _bll.ListarVariantesPorProducto(idProducto);
        }

        private void btnCrearVariante_Click(object sender, EventArgs e)
        {
            if (_productoVariante == null)
            {
                MessageBox.Show("Ingresá o buscá un ID de producto válido.");
                return;
            }
            if (cboColor.SelectedValue == null || cboTalle.SelectedValue == null)
            {
                MessageBox.Show("Seleccioná color y talle.");
                return;
            }

            try
            {
                int idColor = Convert.ToInt32(cboColor.SelectedValue);
                int idTalle = Convert.ToInt32(cboTalle.SelectedValue);

                if (_bll.CrearVariante(_productoVariante.Id, idColor, idTalle))
                {
                    MessageBox.Show("Variante (SKU) creada con stock inicial 0.");
                    CargarVariantes(_productoVariante.Id);
                }
                else
                    MessageBox.Show("Error al crear la variante.");
            }
            catch (OperacionNoPermitidaException ex)
            {
                MessageBox.Show(ex.Message, "Operación no permitida",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ── Helpers ──────────────────────────────────────────────────────

        // Mapeo nombre -> ID centralizado en la BLL (Categorias). El combo solo tiene
        // "Calzado"/"Vestimenta", así que el ?? nunca cae al default.
        private static int IdCategoria(string categoria) =>
            BLL.SistemaCompraVenta.Categorias.IdPorNombre(categoria)
            ?? BLL.SistemaCompraVenta.Categorias.Vestimenta;

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
