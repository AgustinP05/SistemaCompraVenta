using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Entities
{
    public class Venta
    {
        public int IdVenta { get; set; }

        public List<DetalleVenta> Detalles { get; set; }
    }
}
