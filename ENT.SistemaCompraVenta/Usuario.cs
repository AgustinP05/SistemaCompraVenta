using System;

namespace ENT.SistemaCompraVenta
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }

        // Relación con la entidad Rol
        //public Rol Rol { get; set; }

        public DateTime FechaHoraLogin { get; set; }

        

        // guarda toda la estructura Compositecon sus permisos
        public Componente Permisos { get; set; }

        
        public string NombreMostrar => $"{Nombre} ({Permisos.Nombre})";
    }
}