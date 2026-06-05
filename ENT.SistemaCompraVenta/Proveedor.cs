using System;

namespace ENT.SistemaCompraVenta
{
    public class Proveedor
    {
        private string cuit;
        private string razonSocial;
        private string telefono;
        private string direccion;
        private string email;

        public string Cuit
        {
            get { return cuit; }
            set { cuit = value; }
        }

        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
    }
}