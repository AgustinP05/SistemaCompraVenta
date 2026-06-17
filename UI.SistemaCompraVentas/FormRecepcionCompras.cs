using System;
using System.Windows.Forms;
using ENT.SistemaCompraVenta;
using BLL.SistemaCompraVenta;
using BLL.SistemaCompraVenta.Sesion;

namespace UI.SistemaCompraVentas
{
    public partial class FormRecepcionCompras : Form
    {
        private readonly CompraBLL oCompraBLL = new CompraBLL();

        // Orden actualmente cargada en la grilla de detalle (con sus DetalleCompra).
        private Compra compraSeleccionada;

        public FormRecepcionCompras()
        {
            InitializeComponent();
        }

        private void FormRecepcionCompras_Load(object sender, EventArgs e)
        {
            ConfigurarGrillaDetalle();
            CargarPendientes();
        }

        // Columnas fijas del detalle. Solo "Recibida" es editable: ahí el encargado
        // ajusta lo que efectivamente llegó (precargado con lo pedido).
        private void ConfigurarGrillaDetalle()
        {
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.Columns.Clear();
            dgvDetalle.Columns.Add("SKU", "SKU");
            dgvDetalle.Columns.Add("Nombre", "Producto");
            dgvDetalle.Columns.Add("Marca", "Marca");
            dgvDetalle.Columns.Add("Talle", "Talle");
            dgvDetalle.Columns.Add("Color", "Color");
            dgvDetalle.Columns.Add("Pedida", "Cant. pedida");
            dgvDetalle.Columns.Add("Recibida", "Cant. recibida");

            dgvDetalle.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvDetalle.Columns)
                col.ReadOnly = col.Name != "Recibida";

            // Reparte el ancho entre todas las columnas (llena la grilla) y evita que
            // el encabezado se parta en dos líneas.
            dgvDetalle.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalle.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            dgvDetalle.Columns["SKU"].FillWeight      = 45;
            dgvDetalle.Columns["Nombre"].FillWeight   = 150;
            dgvDetalle.Columns["Marca"].FillWeight    = 75;
            dgvDetalle.Columns["Talle"].FillWeight    = 50;
            dgvDetalle.Columns["Color"].FillWeight    = 75;
            dgvDetalle.Columns["Pedida"].FillWeight   = 85;
            dgvDetalle.Columns["Recibida"].FillWeight = 90;
        }

        private void CargarPendientes()
        {
            // Limpiar ANTES de bindear: asignar el DataSource dispara SelectionChanged,
            // que es quien carga el detalle. Si limpiáramos después, lo borraríamos.
            compraSeleccionada = null;
            dgvDetalle.Rows.Clear();

            try
            {
                dgvPendientes.DataSource = oCompraBLL.ListarPendientes();
                if (dgvPendientes.Columns.Contains("ID_Compra"))
                    dgvPendientes.Columns["ID_Compra"].HeaderText = "N° Orden";
                if (dgvPendientes.Columns.Contains("Total"))
                    dgvPendientes.Columns["Total"].DefaultCellStyle.Format = "N2";
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudieron cargar las órdenes pendientes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Por si el SelectionChanged del bind disparó sin fila válida todavía.
            CargarDetalleDeSeleccion();
        }

        private void dgvPendientes_SelectionChanged(object sender, EventArgs e)
        {
            CargarDetalleDeSeleccion();
        }

        // Carga el detalle de la orden seleccionada. La columna "Recibida" arranca
        // con lo pedido; el encargado la baja si llegó menos.
        private void CargarDetalleDeSeleccion()
        {
            dgvDetalle.Rows.Clear();
            compraSeleccionada = null;

            if (dgvPendientes.CurrentRow == null) return;
            if (!dgvPendientes.Columns.Contains("ID_Compra")) return;

            object valor = dgvPendientes.CurrentRow.Cells["ID_Compra"].Value;
            if (valor == null || !int.TryParse(valor.ToString(), out int idCompra)) return;

            try
            {
                compraSeleccionada = oCompraBLL.ObtenerCompraPorId(idCompra);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar el detalle: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (compraSeleccionada == null) return;

            foreach (DetalleCompra d in compraSeleccionada.Detalles)
            {
                dgvDetalle.Rows.Add(
                    d.Variante.SKU,
                    d.Variante.Nombre,
                    d.Variante.Marca,
                    d.Variante.Talle,
                    d.Variante.Color,
                    d.Cantidad,
                    d.Cantidad); // recibida precargada = pedida
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            if (compraSeleccionada == null || compraSeleccionada.Detalles.Count == 0)
            {
                MessageBox.Show("Seleccioná una orden pendiente para recepcionar.", "Atención",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Traslada lo tipeado en la grilla a cada detalle (CantidadConfirmada).
            try
            {
                for (int i = 0; i < compraSeleccionada.Detalles.Count; i++)
                {
                    object valor = dgvDetalle.Rows[i].Cells["Recibida"].Value;
                    if (valor == null || !int.TryParse(valor.ToString(), out int recibida))
                    {
                        MessageBox.Show($"Ingresá una cantidad recibida válida en la fila {i + 1}.",
                            "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    compraSeleccionada.Detalles[i].CantidadConfirmada = recibida;
                }

                Usuario usuarioRecepcion = Sesion.ObtenerInstancia().UsuarioActual
                    ?? new Usuario { ID = 1 };

                oCompraBLL.ProcesarRecepcion(compraSeleccionada, usuarioRecepcion);

                string encabezado = compraSeleccionada.Estado.Nombre == "Reclamo"
                    ? "Recepción procesada con FALTANTES.\n\nSe sumó al stock lo efectivamente recibido y se registró el reclamo correspondiente."
                    : "Recepción CONFIRMADA.\n\nLlegó la mercadería completa y el stock fue actualizado.";

                string auditoria =
                    $"\n\nRecepcionado por: {usuarioRecepcion.Nombre} {usuarioRecepcion.Apellido}".TrimEnd() +
                    $"\nFecha y hora: {compraSeleccionada.FechaRecepcion:dd/MM/yyyy HH:mm}";

                MessageBox.Show(encabezado + auditoria, "Recepción procesada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CargarPendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo procesar la recepción: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e) => CargarPendientes();

        private void btnSalir_Click(object sender, EventArgs e) => this.Close();
    }
}
