namespace ENT.SistemaCompraVenta
{
    public class Cliente
    {
        public string DNI { get; set; } // ID del cliente
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        // Lo que se va a ver en la lista desplegable
        public string NombreCompleto => $"{Apellido}, {Nombre} (DNI: {DNI})";

        public override string ToString() => NombreCompleto;
    }
}