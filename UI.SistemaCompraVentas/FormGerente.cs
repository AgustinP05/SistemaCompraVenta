using BLL.SistemaCompraVentas;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL.SistemaCompraVentas; 

namespace UI.SistemaCompraVentas
{
    public partial class FormGerente : Form
    {
        public FormGerente()
        {
            InitializeComponent();
            // Llamamos a cargar los datos al iniciar el formulario
            CargarReportes();
        }
        /*
        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Vinculamos el evento Load en el rayito si no funciona automáticamente
            MostrarDatosSimulados();
        }

        private void MostrarDatosSimulados()
        {
            // Ponemos los números "a mano" para la demo
            label2.Text = "$ 1.250.000"; // Ventas totales
                                         // Si agregas labels a los otros paneles, podés llenarlos acá

            // Llenamos la tablita de crecimiento
            var datos = new List<object>
            {
                new { Mes = "Marzo", Ventas = 850000, Crecimiento = "Estable" },
                new { Mes = "Abril", Ventas = 980000, Crecimiento = "+15%" },
                new { Mes = "Mayo", Ventas = 1250000, Crecimiento = "+27%" }
            };

            dgvCrecimiento.DataSource = null;
            dgvCrecimiento.DataSource = datos;
            dgvCrecimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }*/
        /*
private void MostrarDatosReales()
    {
        ReporteBLL oReporteBLL = new ReporteBLL(); // El formulario solo conoce la BLL
        dgvCrecimiento.DataSource = oReporteBLL.ObtenerVentasMensuales();
    }*/
        private void CargarReportes()
        {
            try
            {
                ReporteBLL oReporteBLL = new ReporteBLL();

                // 1. Lógica de la Grilla 
                System.Data.DataTable datos = oReporteBLL.ObtenerVentasMensuales();
                dgvCrecimiento.DataSource = datos;
                dgvCrecimiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                if (dgvCrecimiento.Columns.Contains("VentasTotales"))
                {
                    dgvCrecimiento.Columns["VentasTotales"].DefaultCellStyle.Format = "C2";
                }

                // Ttotal para el Label Verde
                decimal totalGeneral = 0;
                foreach (System.Data.DataRow fila in datos.Rows)
                {
                    totalGeneral += Convert.ToDecimal(fila["VentasTotales"]);
                }
                labelCantidadVentas.Text = totalGeneral.ToString("C2");

                // Agregamos la lógica para mostrar el total de ventas realizadas
                VentasDelMes.Text = oReporteBLL.ObtenerTotalOperaciones().ToString();

                // Alerta de Stock Crítico
                var stockCritico = oReporteBLL.ObtenerProductosStockCritico();
                if (stockCritico.Rows.Count > 0)
                {
                    DvgAlerta.Text = "Stock bajo: " + stockCritico.Rows.Count + " productos";
                    DvgAlerta.BackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los reportes: " + ex.Message);
            }
        }
    }
}