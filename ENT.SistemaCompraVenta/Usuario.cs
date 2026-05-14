using System;

namespace ENT.SistemaCompraVenta
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Password { get; set; }

        // Relación con la entidad Rol
        public Rol Rol { get; set; }

        // Podés agregar una propiedad extra para legibilidad
        public string NombreMostrar => $"{Nombre} ({Rol?.NombreRol})";
    }
}