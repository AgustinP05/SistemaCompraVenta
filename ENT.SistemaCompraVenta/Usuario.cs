using System;

namespace ENT.SistemaCompraVenta
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string DNI { get; set; }

        public DateTime FechaHoraLogin { get; set; }

        public string Apellido { get; set; }
        public string Email { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public Rol Rol { get; set; }

        public string NombreMostrar => $"{$"{Nombre} {Apellido}".Trim()} ({Rol?.NombreRol})";
    }
}