using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ENT.SistemaCompraVenta
{
    public class EntidadReporte
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreCliente { get; set; }
        public string NombreVendedor { get; set; }
        public decimal TotalVenta { get; set; }

        // Relación de composición con los detalles
        public List<DetalleReporte> Detalles { get; set; } = new List<DetalleReporte>();
    }
}