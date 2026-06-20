namespace ENT.SistemaCompraVenta
{
    // KPIs del reporte gerencial. Los calcula la BLL (ReporteBLL.CalcularResumen);
    // el form solo los muestra en las etiquetas.
    public class ResumenReporte
    {
        public decimal FacturadoBruto { get; set; }
        public decimal Descuentos { get; set; }
        public decimal FacturadoNeto { get; set; }
        public decimal Costo { get; set; }
        public decimal GananciaNeta { get; set; }
        public int Unidades { get; set; }
        public int CantidadVentas { get; set; }
        public decimal TicketPromedio { get; set; }

        public string TopProductoNombre { get; set; }
        public int TopProductoUnidades { get; set; }
        public string TopVendedorNombre { get; set; }
    }
}
