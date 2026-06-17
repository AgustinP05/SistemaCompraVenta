using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        // Proveedor que provee un SKU (la marca del producto lo determina de forma única).
        public Proveedor ObtenerProveedorPorSku(int sku)
        {
            return oProveedorDAL.ObtenerPorSku(sku);
        }

        // Catálogo de marcas disponibles (para el desplegable al crear/editar producto).
        public List<string> ListarMarcas()
        {
            return oProveedorDAL.ListarMarcas();
        }

        // Alta de marca nueva: la asocia a un proveedor existente.
        // Regla: una marca pertenece a un único proveedor (no se cruza).
        public void AsociarMarca(int idProveedor, string marca)
        {
            if (idProveedor <= 0)
                throw new Exception("Seleccioná un proveedor.");
            if (string.IsNullOrWhiteSpace(marca))
                throw new Exception("Ingresá el nombre de la marca.");

            try
            {
                oProveedorDAL.AsociarMarca(idProveedor, marca.Trim());
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601) // PK/UNIQUE
            {
                throw new OperacionNoPermitidaException(
                    "La marca \"" + marca.Trim() + "\" ya pertenece a un proveedor. " +
                    "Cada marca puede estar asignada a un único proveedor.");
            }
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

            try
            {
                return oProveedorDAL.EliminarProveedor(cuit) > 0;
            }
            catch (SqlException ex) when (ex.Number == 547) // violación de FK
            {
                throw new OperacionNoPermitidaException(
                    "No se puede eliminar el proveedor porque tiene compras registradas en el sistema.");
            }
        }

    }
}
