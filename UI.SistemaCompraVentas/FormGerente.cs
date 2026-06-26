using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;

namespace UI.SistemaCompraVentas
{
    public partial class FormGerente : Form
    {
        private ReporteBLL _reporteBLL = new ReporteBLL();
        private List<EntidadReporte> _ultimoResultado;

        public FormGerente()
        {
            InitializeComponent();
        }

        private void FormGerente_Load(object sender, EventArgs e)
        {

            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.CustomFormat = "dd/MM/yyyy";

            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;

            var categorias = new BLL.SistemaCompraVenta.CategoriaBLL().ListarCategorias();
            categorias.Insert(0, new ENT.SistemaCompraVenta.Categoria { ID_Categoria = 0, Nombre = "Todas" });
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "ID_Categoria";
            cboCategoria.DataSource = categorias;
            cboCategoria.SelectedIndex = 0;

            cboAgrupar.Items.Clear();
            cboAgrupar.Items.Add("Sin agrupar");
            cboAgrupar.Items.Add("Vendedor");
            cboAgrupar.Items.Add("Cliente");
            cboAgrupar.Items.Add("Producto");
            cboAgrupar.SelectedIndex = 0;

            CargarCombosFiltros();


            LimpiarResumen();

            CargarReclamos();
        }

        // --- REPORTE DETALLADO ---

        private void CargarCombosFiltros()
        {
            try
            {
                //    VENDEDORES: solo rol Vendedor + quienes tengan ventas (aunque hayan
                //    cambiado de rol). Evita ofrecer usuarios que darían reporte vacío.
                BLL.SistemaCompraVenta.Services.UsuarioBLL uBll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                DataTable dtVendedores = uBll.ObtenerVendedores();

                DataRow filaVendedor = dtVendedores.NewRow();
                filaVendedor["ID"] = 0;
                filaVendedor["Nombre"] = "Todos los Vendedores";
                dtVendedores.Rows.InsertAt(filaVendedor, 0);

                cboVendedor.DisplayMember = "Nombre";
                cboVendedor.ValueMember = "ID";
                cboVendedor.DataSource = dtVendedores;

                //  CLIENTES
                BLL.SistemaCompraVenta.ClienteBLL cBll = new BLL.SistemaCompraVenta.ClienteBLL();
                List<ENT.SistemaCompraVenta.Cliente> listaClientes = cBll.ListarClientes();

                ENT.SistemaCompraVenta.Cliente cliTodos = new ENT.SistemaCompraVenta.Cliente();
                cliTodos.IdCliente = 0;
                cliTodos.Nombre = "Todos los Clientes";
                cliTodos.Apellido = "";
                listaClientes.Insert(0, cliTodos);

                cboCliente.DisplayMember = "NombreCompleto";
                cboCliente.ValueMember = "IdCliente";
                cboCliente.DataSource = listaClientes;

                //  PRODUCTOS 
                CargarProductosPorCategoria();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los filtros: " + ex.Message, "Inicialización", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CargarProductosPorCategoria()
        {
            BLL.SistemaCompraVenta.ProductoBLL pBll = new BLL.SistemaCompraVenta.ProductoBLL();
            List<ENT.SistemaCompraVenta.Producto> listaProductos = pBll.ListarProductos();

            // Filtra el combo de productos según la categoría elegida.
            int? idCategoria = IdCategoriaSeleccionada();
            if (idCategoria.HasValue)
                listaProductos = listaProductos.Where(p => p.ID_Categoria == idCategoria.Value).ToList();

            // Item placeholder "Todos los Productos" al tope del combo.
            ENT.SistemaCompraVenta.Producto prodTodos = new ENT.SistemaCompraVenta.Producto();

            prodTodos.Id = 0;
            prodTodos.Nombre = "Todos los Productos";
            listaProductos.Insert(0, prodTodos);

            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember = "Id";
            cboProducto.DataSource = listaProductos;
        }

        // El combo trae el ID en el ValueMember. "Todas" = ID 0 => null = sin filtro.
        private int? IdCategoriaSeleccionada()
        {
            int id = cboCategoria.SelectedValue != null ? Convert.ToInt32(cboCategoria.SelectedValue) : 0;
            return id == 0 ? (int?)null : id;
        }

        // --- RECLAMOS (compras recibidas incompletas) ---

        private void CargarReclamos()
        {
            try
            {
                BLL.SistemaCompraVenta.CompraBLL cBll = new BLL.SistemaCompraVenta.CompraBLL();
                dgvReclamos.DataSource = cBll.ListarReclamos();
                FormatearGrillaReclamos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reclamos: " + ex.Message, "Reclamos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormatearGrillaReclamos()
        {
            if (dgvReclamos.Columns.Count == 0) return;

            // Pesos proporcionales: Proveedor/Producto anchos; Talle y numéricos mínimos.
            if (dgvReclamos.Columns.Contains("NroCompra"))
            {
                dgvReclamos.Columns["NroCompra"].HeaderText = "N° Compra";
                dgvReclamos.Columns["NroCompra"].FillWeight = 9;
            }
            if (dgvReclamos.Columns.Contains("FechaCompra"))
            {
                dgvReclamos.Columns["FechaCompra"].HeaderText = "Fecha Compra";
                dgvReclamos.Columns["FechaCompra"].FillWeight = 15;
                dgvReclamos.Columns["FechaCompra"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvReclamos.Columns.Contains("Proveedor"))
                dgvReclamos.Columns["Proveedor"].FillWeight = 26;
            if (dgvReclamos.Columns.Contains("Producto"))
                dgvReclamos.Columns["Producto"].FillWeight = 28;
            if (dgvReclamos.Columns.Contains("Color"))
                dgvReclamos.Columns["Color"].FillWeight = 11;
            if (dgvReclamos.Columns.Contains("Talle"))
                dgvReclamos.Columns["Talle"].FillWeight = 8;
            if (dgvReclamos.Columns.Contains("Pedido"))
                dgvReclamos.Columns["Pedido"].FillWeight = 9;
            if (dgvReclamos.Columns.Contains("Recibido"))
                dgvReclamos.Columns["Recibido"].FillWeight = 9;
            if (dgvReclamos.Columns.Contains("Faltante"))
                dgvReclamos.Columns["Faltante"].FillWeight = 9;
            if (dgvReclamos.Columns.Contains("FechaReclamo"))
            {
                dgvReclamos.Columns["FechaReclamo"].HeaderText = "Fecha Reclamo";
                dgvReclamos.Columns["FechaReclamo"].FillWeight = 15;
                dgvReclamos.Columns["FechaReclamo"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnActualizarReclamos_Click(object sender, EventArgs e)
        {
            CargarReclamos();
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                FiltroReporte filtro = new FiltroReporte();
                filtro.FechaDesde = dtpDesde.Value.Date;
                filtro.FechaHasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

                if (cboVendedor.SelectedValue != null && cboVendedor.SelectedIndex > 0)
                    filtro.IdVendedor = Convert.ToInt32(cboVendedor.SelectedValue);

                if (cboProducto.SelectedValue != null && cboProducto.SelectedIndex > 0)
                    filtro.IdProducto = Convert.ToInt32(cboProducto.SelectedValue);

                if (cboCliente.SelectedValue != null && cboCliente.SelectedIndex > 0)
                    filtro.IdCliente = Convert.ToInt32(cboCliente.SelectedValue);

                filtro.IdCategoria = IdCategoriaSeleccionada();

                List<EntidadReporte> resultado = _reporteBLL.GenerarReporte(filtro);

                // Camino alternativo: no hay ventas para los criterios elegidos.
                if (resultado == null || resultado.Count == 0)
                {
                    _ultimoResultado = null;
                    dgvReporte.DataSource = null;
                    LimpiarResumen();
                    MessageBox.Show("No hay datos para mostrar.", "Generar Reporte",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _ultimoResultado = resultado;

                MostrarResumen(resultado);
                RenderResultado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvReporte.DataSource = null;
            }
        }


        private void FormatearGrilla()
        {
            if (dgvReporte.Columns.Contains("Detalles"))
                dgvReporte.Columns["Detalles"].Visible = false;
            if (dgvReporte.Columns.Contains("Costo"))
                dgvReporte.Columns["Costo"].Visible = false;
            if (dgvReporte.Columns.Contains("Ganancia"))
                dgvReporte.Columns["Ganancia"].Visible = false;

            if (dgvReporte.Columns.Contains("IdVenta"))
            {
                dgvReporte.Columns["IdVenta"].HeaderText = "ID Venta";
                dgvReporte.Columns["IdVenta"].FillWeight = 12; 
            }
            if (dgvReporte.Columns.Contains("Fecha"))
            {
                dgvReporte.Columns["Fecha"].HeaderText = "Fecha";
                dgvReporte.Columns["Fecha"].FillWeight = 22;
                dgvReporte.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvReporte.Columns.Contains("NombreCliente"))
            {
                dgvReporte.Columns["NombreCliente"].HeaderText = "Cliente";
                dgvReporte.Columns["NombreCliente"].FillWeight = 28;
            }
            if (dgvReporte.Columns.Contains("NombreVendedor"))
            {
                dgvReporte.Columns["NombreVendedor"].HeaderText = "Vendedor";
                dgvReporte.Columns["NombreVendedor"].FillWeight = 28;
            }
            if (dgvReporte.Columns.Contains("TotalVenta"))
            {
                dgvReporte.Columns["TotalVenta"].HeaderText = "Total Bruto";
                dgvReporte.Columns["TotalVenta"].FillWeight = 22;
                dgvReporte.Columns["TotalVenta"].DefaultCellStyle.Format = "C2";
            }
            if (dgvReporte.Columns.Contains("TipoDescuento"))
            {
                dgvReporte.Columns["TipoDescuento"].HeaderText = "Tipo Desc.";
                dgvReporte.Columns["TipoDescuento"].FillWeight = 24;
            }
            if (dgvReporte.Columns.Contains("Descuento"))
            {
                dgvReporte.Columns["Descuento"].HeaderText = "Descuento";
                dgvReporte.Columns["Descuento"].FillWeight = 20;
                dgvReporte.Columns["Descuento"].DefaultCellStyle.Format = "C2";
            }
            if (dgvReporte.Columns.Contains("TotalNeto"))
            {
                dgvReporte.Columns["TotalNeto"].HeaderText = "Total Neto";
                dgvReporte.Columns["TotalNeto"].FillWeight = 22;
                dgvReporte.Columns["TotalNeto"].DefaultCellStyle.Format = "C2";
            }
        }


        private void MostrarResumen(List<EntidadReporte> ventas)
        {

            ResumenReporte r = _reporteBLL.CalcularResumen(ventas);

            lblFacturadoBruto.Text = r.FacturadoBruto.ToString("C2");
            lblDescuento.Text      = r.Descuentos.ToString("C2");
            lblFacturado.Text      = r.FacturadoNeto.ToString("C2");
            lblCosto.Text          = r.Costo.ToString("C2");
            lblGanancia.Text       = r.GananciaNeta.ToString("C2");
            lblTicket.Text         = "Ticket promedio: " + r.TicketPromedio.ToString("C2");
            lblUnidades.Text       = "Unidades: " + r.Unidades + "     |     Ventas: " + r.CantidadVentas;

            string top = "";
            if (!string.IsNullOrEmpty(r.TopProductoNombre))
                top += "Top producto: " + r.TopProductoNombre + " (" + r.TopProductoUnidades + "u)";
            if (!string.IsNullOrEmpty(r.TopVendedorNombre))
                top += (top.Length > 0 ? "     |     " : "") + "Top vendedor: " + r.TopVendedorNombre;
            lblTop.Text = top;
        }

        private void LimpiarResumen()
        {
            lblFacturadoBruto.Text = "";
            lblDescuento.Text = "";
            lblFacturado.Text = "";
            lblCosto.Text = "";
            lblGanancia.Text = "";
            lblTicket.Text = "";
            lblUnidades.Text = "";
            lblTop.Text = "";
        }

        // Muestra la grilla en detalle o agrupada según el combo, sin volver a consultar.
        private void RenderResultado()
        {
            if (_ultimoResultado == null) return;

            string criterio = cboAgrupar.SelectedItem != null ? cboAgrupar.SelectedItem.ToString() : "Sin agrupar";

            if (criterio == "Sin agrupar")
            {
                dgvReporte.DataSource = null;
                dgvReporte.DataSource = _ultimoResultado;
                FormatearGrilla();
            }
            else
            {
                dgvReporte.DataSource = null;
                dgvReporte.DataSource = _reporteBLL.Agrupar(_ultimoResultado, criterio);
                FormatearGrillaAgrupada();
            }
        }

        private void cboAgrupar_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderResultado();
        }


        private void FormatearGrillaAgrupada()
        {
            if (dgvReporte.Columns.Contains("Grupo"))
                dgvReporte.Columns["Grupo"].FillWeight = 42;
            if (dgvReporte.Columns.Contains("Unidades"))
                dgvReporte.Columns["Unidades"].FillWeight = 14;
            if (dgvReporte.Columns.Contains("Descuento"))
            {
                dgvReporte.Columns["Descuento"].FillWeight = 18;
                dgvReporte.Columns["Descuento"].DefaultCellStyle.Format = "C2";
            }
            if (dgvReporte.Columns.Contains("Total Neto"))
            {
                dgvReporte.Columns["Total Neto"].FillWeight = 24;
                dgvReporte.Columns["Total Neto"].DefaultCellStyle.Format = "C2";
            }
            if (dgvReporte.Columns.Contains("Ganancia"))
            {
                dgvReporte.Columns["Ganancia"].FillWeight = 24;
                dgvReporte.Columns["Ganancia"].DefaultCellStyle.Format = "C2";
            }
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cboProducto != null)
            {
                CargarProductosPorCategoria();
            }
        }

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            //  Validar que la grilla tenga datos antes de intentar exportar
            if (dgvReporte.Rows.Count == 0 || dgvReporte.DataSource == null)
            {
                MessageBox.Show("No hay datos para exportar. Genere un reporte primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //  Abrir la ventana para que el gerente elija dónde guardar el archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo de Excel (*.csv)|*.csv";
            sfd.Title = "Guardar Reporte Gerencial";

            sfd.FileName = "Reporte_Gerencial_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //    El form solo junta lo VISIBLE en la grilla (tarea de UI). El
                    //    formato CSV y la escritura del archivo los hace la BLL.
                    List<string> encabezados = new List<string>();
                    foreach (DataGridViewColumn col in dgvReporte.Columns)
                        if (col.Visible) encabezados.Add(col.HeaderText);

                    List<IList<string>> filas = new List<IList<string>>();
                    foreach (DataGridViewRow fila in dgvReporte.Rows)
                    {
                        if (fila.IsNewRow) continue;
                        List<string> celdas = new List<string>();
                        foreach (DataGridViewColumn col in dgvReporte.Columns)
                            if (col.Visible)
                                celdas.Add(fila.Cells[col.Index].Value?.ToString() ?? "");
                        filas.Add(celdas);
                    }

                    BLL.SistemaCompraVenta.ExportadorCsv.Exportar(sfd.FileName, encabezados, filas);

                    MessageBox.Show("¡Reporte exportado con éxito!", "Exportación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //  Abre el excel luego del guardado exitoso
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar el archivo: " + ex.Message, "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Camino alternativo: Descarta lo ingresado y cierra la interfaz (vuelve a Gerente).
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}