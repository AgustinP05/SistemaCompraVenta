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
        }

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
        }
    }
}