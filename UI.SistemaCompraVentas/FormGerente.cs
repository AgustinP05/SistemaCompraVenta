using BLL.SistemaCompraVentas;
using BLL.SistemaCompraVentas; 
using System;
using System.Collections.Generic;
using System.Windows.Forms;

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
                System.Data.DataTable datos = oReporteBLL.ObtenerVentasMensuales();

                // Ahora tu grilla mostrará automáticamente las 3 columnas: Mes, Usuario, VentasTotales
                dgvCrecimiento.DataSource = datos;

                // Formateo de columnas para que se vea profesional
                if (dgvCrecimiento.Columns.Contains("VentasTotales"))
                {
                    dgvCrecimiento.Columns["VentasTotales"].DefaultCellStyle.Format = "C2";
                }

                // El cálculo del total sigue igual, pero ahora sabemos que 'VentasTotales' existe
                decimal totalGeneral = 0;
                foreach (System.Data.DataRow fila in datos.Rows)
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
            CargarReportes(); // Actualiza los números cada vez que el gerente entra a la vista
        }
    }
}