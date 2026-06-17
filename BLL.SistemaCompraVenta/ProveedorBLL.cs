using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL.SistemaCompraVenta
{
    public class ProveedorBLL
    {
        private ProveedorDAL oProveedorDAL = new ProveedorDAL();

        // Catálogo en memoria para resolver el CUIT tipeado en FormCompras.
        public List<Proveedor> ListarProveedores()
        {
            return oProveedorDAL.ListarProveedores();
        }

        // Marcas que provee un proveedor (para filtrar los productos en la compra).
        public List<string> MarcasDeProveedor(int idProveedor)
        {
            return oProveedorDAL.MarcasDeProveedor(idProveedor);
        }

        public bool ExisteProveedor(string cuit)
        {
            return oProveedorDAL.ExisteProveedor(cuit);
        }

        public bool CrearProveedor(string cuit, string razonSocial, string telefono,
                                    string email, string direccion)
        {
            if (string.IsNullOrWhiteSpace(cuit) || string.IsNullOrWhiteSpace(razonSocial))
                throw new Exception("Complete todos los datos obligatorios.");

            if (!Validaciones.EmailValido(email))
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

            if (!Validaciones.EmailValido(p.Email))
                throw new Exception("Email inválido.");

            return oProveedorDAL.ModificarProveedor(p) > 0;
        }

        public bool EliminarProveedor(string cuit)
        {
            if (string.IsNullOrWhiteSpace(cuit))
                throw new Exception("CUIT inválido.");

            return oProveedorDAL.EliminarProveedor(cuit) > 0;
        }

    }
}
