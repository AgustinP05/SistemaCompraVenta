using System;
using System.Collections.Generic;


namespace ENT.SistemaCompraVenta
{
    public class EntidadReporte
    {
        private int idVenta;
        private DateTime fecha;
        private string nombreCliente;
        private string nombreVendedor;
        private decimal totalVenta;
        private decimal descuento;
        private string tipoDescuento;
        private decimal costo;

        // Relación de composición con los detalles
        private List<DetalleReporte> detalles = new List<DetalleReporte>();

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        public string NombreVendedor
        {
            get { return nombreVendedor; }
            set { nombreVendedor = value; }
        }

        // Total bruto (suma de subtotales, antes de descuento).
        public decimal TotalVenta
        {
            get { return totalVenta; }
            set { totalVenta = value; }
        }

        // Tipo de descuento aplicado a la venta (vacío si no hubo).
        public string TipoDescuento
        {
            get { return tipoDescuento; }
            set { tipoDescuento = value; }
        }

        // Monto del descuento aplicado a la venta (0 si no hubo).
        public decimal Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        // Total neto cobrado (bruto - descuento).
        public decimal TotalNeto
        {
            get { return totalVenta - descuento; }
        }

        // Costo total de la venta (suma de los costos de cada detalle).
        public decimal Costo
        {
            get { return costo; }
            set { costo = value; }
        }

        // Ganancia NETA de la venta (neto cobrado - costo).
        public decimal Ganancia
        {
            get { return (totalVenta - descuento) - costo; }
        }

        public List<DetalleReporte> Detalles
        {
            get { return detalles; }
            set { detalles = value; }
        }
    }
}
