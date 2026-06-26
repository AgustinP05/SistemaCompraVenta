using System;

namespace ENT.SistemaCompraVenta
{
    public class Cliente
    {

        private int idCliente;
        private string dni;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;
        private string direccion;

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string Dni
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

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        // Propiedad de solo lectura para el Nombre Completo
        public string NombreCompleto
        {
            get { return (nombre + " " + apellido).Trim(); }
        }
    }
}