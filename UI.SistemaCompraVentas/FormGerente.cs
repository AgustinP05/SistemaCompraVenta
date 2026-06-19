using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BLL.SistemaCompraVentas;
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
            // Días y meses siempre en 2 cifras (dd/MM/yyyy).
            dtpDesde.Format = DateTimePickerFormat.Custom;
            dtpDesde.CustomFormat = "dd/MM/yyyy";
            dtpHasta.Format = DateTimePickerFormat.Custom;
            dtpHasta.CustomFormat = "dd/MM/yyyy";

            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;
            ////////////////////////
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Todas");
            cboCategoria.Items.Add("Calzado");
            cboCategoria.Items.Add("Vestimenta");
            cboCategoria.SelectedIndex = 0;

            cboAgrupar.Items.Clear();
            cboAgrupar.Items.Add("Sin agrupar");
            cboAgrupar.Items.Add("Vendedor");
            cboAgrupar.Items.Add("Cliente");
            cboAgrupar.Items.Add("Producto");
            cboAgrupar.SelectedIndex = 0;

            CargarCombosFiltros();

            // El texto de las etiquetas es solo de ejemplo (para verlas en el diseñador);
            // en ejecución arrancan vacías hasta que se genera un reporte.
            LimpiarResumen();

            CargarReclamos();
        }

        // --- REPORTE DETALLADO ---

        private void CargarCombosFiltros()
        {
            try
            {
                // 1. VENDEDORES
                BLL.SistemaCompraVenta.Services.UsuarioBLL uBll = new BLL.SistemaCompraVenta.Services.UsuarioBLL();
                DataTable dtVendedores = uBll.ObtenerUsuarios("");

                DataRow filaVendedor = dtVendedores.NewRow();
                filaVendedor["ID"] = 0;
                filaVendedor["Nombre"] = "Todos los Vendedores";
                dtVendedores.Rows.InsertAt(filaVendedor, 0);

                cboVendedor.DisplayMember = "Nombre";
                cboVendedor.ValueMember = "ID";
                cboVendedor.DataSource = dtVendedores;

                // 2. CLIENTES
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

                // 3. PRODUCTOS 
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

        // Vestimenta = 1, Calzado = 2 (orden del INSERT en 3-DatosIniciales.sql). "Todas" => sin filtro.
        private int? IdCategoriaSeleccionada()
        {
            if (cboCategoria.Text == "Calzado") return 2;
            if (cboCategoria.Text == "Vestimenta") return 1;
            return null;
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

                // Alternativa 1 del CU: no hay ventas para los criterios elegidos.
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

        // Encabezados, anchos y formato de la grilla del reporte.
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
                dgvReporte.Columns["IdVenta"].FillWeight = 12; // angosta
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

        // Totales (KPIs) del reporte en etiquetas.
        private void MostrarResumen(List<EntidadReporte> ventas)
        {
            decimal facturadoBruto = 0;
            decimal descuentos = 0;
            decimal costo = 0;
            int unidades = 0;
            foreach (EntidadReporte v in ventas)
            {
                facturadoBruto += v.TotalVenta;
                descuentos += v.Descuento;
                costo += v.Costo;
                foreach (DetalleReporte d in v.Detalles)
                    unidades += d.Cantidad;
            }
            int cantidad = ventas.Count;
            decimal facturadoNeto = facturadoBruto - descuentos;
            decimal gananciaNeta = facturadoNeto - costo;
            decimal ticket = cantidad > 0 ? facturadoNeto / cantidad : 0;

            var topProducto = ventas.SelectMany(v => v.Detalles)
                .GroupBy(d => d.DescripcionProducto)
                .Select(g => new { Nombre = g.Key, Unidades = g.Sum(x => x.Cantidad) })
                .OrderByDescending(x => x.Unidades)
                .FirstOrDefault();

            var topVendedor = ventas.GroupBy(v => v.NombreVendedor)
                .Select(g => new { Nombre = g.Key, Total = g.Sum(x => x.TotalNeto) })
                .OrderByDescending(x => x.Total)
                .FirstOrDefault();

            // Valores solos (las etiquetas descriptivas van aparte en el diseñador).
            lblFacturadoBruto.Text = facturadoBruto.ToString("C2");
            lblDescuento.Text      = descuentos.ToString("C2");
            lblFacturado.Text      = facturadoNeto.ToString("C2");
            lblCosto.Text          = costo.ToString("C2");
            lblGanancia.Text       = gananciaNeta.ToString("C2");
            lblTicket.Text         = "Ticket promedio: " + ticket.ToString("C2");
            lblUnidades.Text  = "Unidades: " + unidades + "     |     Ventas: " + cantidad;

            string top = "";
            if (topProducto != null)
                top += "Top producto: " + topProducto.Nombre + " (" + topProducto.Unidades + "u)";
            if (topVendedor != null)
                top += (top.Length > 0 ? "     |     " : "") + "Top vendedor: " + topVendedor.Nombre;
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

        // Punto 2: muestra la grilla en detalle o agrupada según el combo, sin volver a consultar.
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
                dgvReporte.DataSource = ConstruirAgrupado(_ultimoResultado, criterio);
                FormatearGrillaAgrupada();
            }
        }

        private void cboAgrupar_SelectedIndexChanged(object sender, EventArgs e)
        {
            RenderResultado();
        }

        // Construye la tabla de subtotales por el criterio elegido (Vendedor, Cliente o Producto).
        private DataTable ConstruirAgrupado(List<EntidadReporte> ventas, string criterio)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Grupo", typeof(string));
            dt.Columns.Add("Unidades", typeof(int));
            dt.Columns.Add("Descuento", typeof(decimal));
            dt.Columns.Add("Total Neto", typeof(decimal));
            dt.Columns.Add("Ganancia", typeof(decimal));

            if (criterio == "Producto")
            {
                // El descuento es por venta, no por producto: no se discrimina en este corte.
                var grupos = ventas.SelectMany(v => v.Detalles)
                    .GroupBy(d => d.DescripcionProducto)
                    .Select(g => new
                    {
                        Grupo = g.Key,
                        Unidades = g.Sum(x => x.Cantidad),
                        Total = g.Sum(x => x.Subtotal),
                        Ganancia = g.Sum(x => x.Subtotal - x.Costo)
                    })
                    .OrderByDescending(x => x.Total);

                foreach (var g in grupos)
                    dt.Rows.Add(g.Grupo, g.Unidades, 0m, g.Total, g.Ganancia);
            }
            else
            {
                System.Func<EntidadReporte, string> selector =
                    criterio == "Cliente"
                        ? (System.Func<EntidadReporte, string>)(v => v.NombreCliente)
                        : (v => v.NombreVendedor);

                var grupos = ventas.GroupBy(selector)
                    .Select(g => new
                    {
                        Grupo = g.Key,
                        Unidades = g.Sum(v => v.Detalles.Sum(d => d.Cantidad)),
                        Descuento = g.Sum(v => v.Descuento),
                        Total = g.Sum(v => v.TotalNeto),
                        Ganancia = g.Sum(v => v.Ganancia)
                    })
                    .OrderByDescending(x => x.Total);

                foreach (var g in grupos)
                    dt.Rows.Add(g.Grupo, g.Unidades, g.Descuento, g.Total, g.Ganancia);
            }

            return dt;
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
            // Cada vez que el gerente cambie de categoría, recargamos el combo de productos
            if (cboProducto != null)
            {
                CargarProductosPorCategoria();
            }
        }

        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            // 1. Validar que la grilla tenga datos antes de intentar exportar
            if (dgvReporte.Rows.Count == 0 || dgvReporte.DataSource == null)
            {
                MessageBox.Show("No hay datos para exportar. Genere un reporte primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. Abrir la ventana para que el gerente elija dónde guardar el archivo
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Archivo de Excel (*.csv)|*.csv";
            sfd.Title = "Guardar Reporte Gerencial";
            // Te arma un nombre automático con la fecha de hoy
            sfd.FileName = "Reporte_Gerencial_" + DateTime.Now.ToString("yyyyMMdd") + ".csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 3. Escribir el archivo usando StreamWriter (System.IO)
                    // Usamos UTF8
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(sfd.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // A. Escribir los ENCABEZADOS
                        string encabezados = "";
                        foreach (DataGridViewColumn col in dgvReporte.Columns)
                        {
                            if (col.Visible)
                            {
                                // Usamos punto y coma
                                encabezados += col.HeaderText + ";";
                            }
                        }
                        sw.WriteLine(encabezados.TrimEnd(';'));

                        // B. Escribir las FILAS de datos
                        foreach (DataGridViewRow fila in dgvReporte.Rows)
                        {
                            string linea = "";
                            foreach (DataGridViewCell celda in fila.Cells)
                            {
                                if (dgvReporte.Columns[celda.ColumnIndex].Visible)
                                {
                                    // Leemos el valor, lo pasamos a string y evitamos que un salto de línea rompa el Excel
                                    string valor = celda.Value != null ? celda.Value.ToString().Replace("\n", " ").Replace("\r", "") : "";
                                    linea += valor + ";";
                                }
                            }
                            sw.WriteLine(linea.TrimEnd(';'));
                        }
                    }

                    MessageBox.Show("¡Reporte exportado con éxito!", "Exportación Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. abre el excel luego del guardado exitoso
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al intentar guardar el archivo: " + ex.Message, "Error de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Alternativa 3 del CU: descarta lo ingresado y cierra la interfaz (vuelve a Gerente).
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fecha_inicio_Click(object sender, EventArgs e)
        {

        }

        private void lblCosto_Click(object sender, EventArgs e)
        {

        }
    }
}