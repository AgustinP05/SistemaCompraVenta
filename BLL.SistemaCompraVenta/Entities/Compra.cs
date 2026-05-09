using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Entities
{
    public class Compra
    {
        public int IdCompra { get; set; }

        public List<DetalleCompra> Detalles { get; set; }
    }
}
