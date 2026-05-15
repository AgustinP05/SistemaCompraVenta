using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.SistemaCompraVenta
{
    public class DetalleCompra
    {
        public int IdDetalle { get; set; }
        public Producto Producto { get; set; } // La clase que ya creamos
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; } // Guardamos el precio del momento
        public double Subtotal => Cantidad * PrecioUnitario;
    }
}