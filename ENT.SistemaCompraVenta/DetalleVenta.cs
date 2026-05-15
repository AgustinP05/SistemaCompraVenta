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

        // Relación con el producto deportivo
        public Producto Producto { get; set; }

        public int Cantidad { get; set; }

        // Es importante guardar el precio del momento de la venta 
        // por si el producto cambia de precio mañana
        public double PrecioUnitario { get; set; }

        // Propiedad calculada (Lógica mínima permitida en Entidades)
        public double Subtotal => Cantidad * PrecioUnitario;
    }
}