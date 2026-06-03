using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.SistemaCompraVenta
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }

        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        public double PrecioUnitario { get; set; }

        public double Subtotal => Cantidad * PrecioUnitario;
    }
}