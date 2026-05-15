using System;

namespace ENT.SistemaCompraVenta
{
    // Hereda de Producto (: Producto)
    public class Calzado : Producto
    {
        // Propiedad específica para calzado deportivo
        public string Talle { get; set; }

        // Podés agregar otras como "TipoSuela" o "Color" si querés
    }
}