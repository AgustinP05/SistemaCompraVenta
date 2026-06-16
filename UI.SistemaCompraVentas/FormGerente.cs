using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BLL.SistemaCompraVentas;
using ENT.SistemaCompraVenta;

namespace UI.SistemaCompraVentas
{
    public partial class FormGerente : Form
    {
        private ReporteBLL _reporteBLL = new ReporteBLL();

        public FormGerente()
        {
            InitializeComponent();
            CargarReportes();
        }

        private void FormGerente_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpHasta.Value = DateTime.Now;
            ////////////////////////
            cboCategoria.Items.Clear();
            cboCategoria.Items.Add("Todas");
            cboCategoria.Items.Add("Calzado");
            cboCategoria.Items.Add("Vestimenta");
            cboCategoria.SelectedIndex = 0;

            CargarCombosFiltros();
        }

        // --- TAB 1: DASHBOARD --- si lo queremos voletear lo volamos, no rompe la logica ni nada...

        private void CargarReportes()
        {
            try
            {
                DataTable datos = _reporteBLL.ObtenerVentasMensuales();
                dgvCrecimiento.DataSource = datos;

                if (dgvCrecimiento.Columns.Contains("VentasTotales"))
                {
                    dgvCrecimiento.Columns["VentasTotales"].DefaultCellStyle.Format = "C2";
                }

                decimal totalGeneral = 0;
                foreach (DataRow fila in datos.Rows)
                {
                    totalGeneral += Convert.ToDecimal(fila["VentasTotales"]);
                }
                labelCantidadVentas.Text = totalGeneral.ToString("C2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar reportes: " + ex.Message);
            }
        }

        private void FormGerente_Activated(object sender, EventArgs e)
        {
            CargarReportes();
        }

        // --- TAB 2: REPORTE DETALLADO ---

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

        // Reutilizacion de productos por la clase abstracta
        private void CargarProductosPorCategoria()
        {
            BLL.SistemaCompraVenta.ProductoBLL pBll = new BLL.SistemaCompraVenta.ProductoBLL();
            List<ENT.SistemaCompraVenta.Producto> listaProductos = pBll.ListarProductos();

            ENT.SistemaCompraVenta.Producto prodTodos;

            // polimorfismo
            if (cboCategoria.Text == "Calzado")
            {
                prodTodos = new ENT.SistemaCompraVenta.Calzado();
            }
            else
            {
                prodTodos = new ENT.SistemaCompraVenta.Vestimenta();
            }

            prodTodos.Id = 0;
            prodTodos.Nombre = "Todos los Productos";
            listaProductos.Insert(0, prodTodos);

            cboProducto.DisplayMember = "Nombre";
            cboProducto.ValueMember = "Id";
            cboProducto.DataSource = listaProductos;
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

                List<EntidadReporte> resultado = _reporteBLL.GenerarReporte(filtro);

                dgvReporte.DataSource = null;
                dgvReporte.DataSource = resultado;

                if (dgvReporte.Columns.Contains("Detalles"))
                    dgvReporte.Columns["Detalles"].Visible = false;

                if (dgvReporte.Columns.Contains("TotalVenta"))
                    dgvReporte.Columns["TotalVenta"].DefaultCellStyle.Format = "C2";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvReporte.DataSource = null;
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
    }
}