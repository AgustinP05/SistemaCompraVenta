using System;

namespace ENT.SistemaCompraVenta
{
    public class Cliente
    {
        private int dni;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;

        public int Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string NombreCompleto
        {
            get { return nombre + " " + apellido; }
        }
    }
}