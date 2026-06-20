using System;

namespace BLL.SistemaCompraVenta
{
    // Catálogo fijo de categorías del dominio (las define el seed de 3-DatosIniciales:
    // 1 = Vestimenta, 2 = Calzado). Centraliza el mapeo nombre <-> ID para no repetir
    // números mágicos en cada form.
    public static class Categorias
    {
        public const int Vestimenta = 1;
        public const int Calzado    = 2;

        // ID a partir del nombre. Devuelve null si no es una categoría concreta
        // (ej.: la opción "Todas" de los filtros del reporte).
        public static int? IdPorNombre(string nombre)
        {
            if (string.Equals(nombre, "Calzado", StringComparison.OrdinalIgnoreCase))    return Calzado;
            if (string.Equals(nombre, "Vestimenta", StringComparison.OrdinalIgnoreCase)) return Vestimenta;
            return null;
        }
    }
}
