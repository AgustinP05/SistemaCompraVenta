using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ENT.SistemaCompraVenta
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; } // O la entidad Cliente si la tienen

        // La lista que conecta con los detalles
        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public double Total { get; set; }
    }
}