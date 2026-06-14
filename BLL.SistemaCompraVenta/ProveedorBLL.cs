using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Data;

namespace BLL.SistemaCompraVenta
{
    public class ProveedorBLL
    {
        private ProveedorDAL oProveedorDAL = new ProveedorDAL();

        public bool ExisteProveedor(string cuit)
        {
            return oProveedorDAL.ExisteProveedor(cuit);
        }

        public bool CrearProveedor(string cuit, string razonSocial, string telefono,
                                    string email, string direccion)
        {
            if (string.IsNullOrWhiteSpace(cuit) || string.IsNullOrWhiteSpace(razonSocial))
                throw new Exception("Complete todos los datos obligatorios.");

            if (!ValidarEmail(email))
                throw new Exception("Email inválido.");

            Proveedor p = new Proveedor
            {
                Cuit        = cuit,
                RazonSocial = razonSocial,
                Telefono    = telefono,
                Email       = email,
                Direccion   = direccion
            };

            return oProveedorDAL.InsertarProveedor(p) > 0;
        }

        public DataTable ObtenerProveedores(string filtro)
        {
            return oProveedorDAL.ObtenerProveedores(filtro);
        }

        public bool ModificarProveedor(Proveedor p)
        {
            if (string.IsNullOrWhiteSpace(p.Cuit) || string.IsNullOrWhiteSpace(p.RazonSocial))
                throw new Exception("Complete todos los datos obligatorios.");

            if (!ValidarEmail(p.Email))
                throw new Exception("Email inválido.");

            return oProveedorDAL.ModificarProveedor(p) > 0;
        }

        public bool EliminarProveedor(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                throw new Exception("CUIT inválido.");

            return oProveedorDAL.EliminarProveedor(cuit) > 0;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Contains("@") && email.Contains(".");
        }
    }
}
