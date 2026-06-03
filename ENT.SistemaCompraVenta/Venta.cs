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
        public Cliente Cliente { get; set; }


        public List<DetalleVenta> Detalles { get; set; } = new List<DetalleVenta>();

        public double Total
        {
            get
            {
                double suma = 0;
                foreach (DetalleVenta detalle in Detalles)
                {
                    suma += detalle.DevolverSubtotal();
                }
                return suma;
            }
        }
    }
}

