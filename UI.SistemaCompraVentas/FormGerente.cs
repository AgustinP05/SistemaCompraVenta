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

        private void CargarReportes()
        {
            try
            {
                ReporteBLL oReporteBLL = new ReporteBLL();
                System.Data.DataTable datos = oReporteBLL.ObtenerVentasMensuales();

                // La grilla muestra las columnas: Mes, Usuario, VentasTotales
                dgvCrecimiento.DataSource = datos;

                // Formateo de columnas para que se vea profesional
                if (dgvCrecimiento.Columns.Contains("VentasTotales"))
                {
                    dgvCrecimiento.Columns["VentasTotales"].DefaultCellStyle.Format = "C2";
                }

                // Sumamos el total general de ventas
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

        private void FormGerente_Load(object sender, EventArgs e)
        {

        }
    }
}