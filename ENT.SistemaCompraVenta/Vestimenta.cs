using System;

namespace ENT.SistemaCompraVenta
{
    // Hereda de Producto (: Producto)
    public class Vestimenta : Producto
    {
        // Propiedad específica para ropa (S, M, L, XL, etc.)
        public string Talle { get; set; }

        // Podés agregar otras como "Material" o "Genero"
    }
}