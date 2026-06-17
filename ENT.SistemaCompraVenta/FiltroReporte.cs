using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ENT.SistemaCompraVenta
{
    public class FiltroReporte
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }

        // El 'int?' permite valores nulos, ideal porque el gerente 
        // podría elegir NO filtrar por vendedor, producto o cliente.
        public int? IdVendedor { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCliente { get; set; }
    }
}
