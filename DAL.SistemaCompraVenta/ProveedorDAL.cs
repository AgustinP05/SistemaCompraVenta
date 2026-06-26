using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ProveedorDAL
    {
        private Conexion conexion = new Conexion();

        // Catálogo completo (para resolver el CUIT tipeado en FormCompras).
        public List<Proveedor> ListarProveedores()
        {
            List<Proveedor> lista = new List<Proveedor>();
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarProveedores", null);
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Proveedor
                {
                    IdProveedor = Convert.ToInt32(fila["ID_Proveedor"]),
                    Cuit        = fila["CUIT"].ToString(),
                    RazonSocial = fila["RazonSocial"].ToString(),
                    Telefono    = fila["Telefono"].ToString(),
                    Email       = fila["Email"].ToString(),
                    Direccion   = fila["Direccion"].ToString()
                });
            }
            return lista;
        }

        // Proveedor que provee un SKU (modo "SKU primero"). Null si el SKU no existe.
        public Proveedor ObtenerPorSku(int sku)
        {
            SqlParameter[] param = { ParametroSql.Crear("@SKU", sku) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ObtenerProveedorPorSku", param);
            if (dt == null || dt.Rows.Count == 0) return null;

            DataRow f = dt.Rows[0];
            return new Proveedor
            {
                IdProveedor = Convert.ToInt32(f["ID_Proveedor"]),
                Cuit        = f["CUIT"].ToString(),
                RazonSocial = f["RazonSocial"].ToString(),
                Telefono    = f["Telefono"].ToString(),
                Email       = f["Email"].ToString(),
                Direccion   = f["Direccion"].ToString()
            };
        }

        // Catálogo de marcas disponibles (las que provee algún proveedor).
        public List<string> ListarMarcas()
        {
            List<string> marcas = new List<string>();
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarMarcas", null);
            foreach (DataRow fila in dt.Rows)
                marcas.Add(fila["Marca"].ToString());
            return marcas;
        }

        // Alta de marca: la asocia a un proveedor (idempotente en el SP).
        public int AsociarMarca(int idProveedor, string marca)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@ID_Proveedor", idProveedor),
                ParametroSql.Crear("@Marca", marca)
            };
            try
            {
                return conexion.EscribirPorStoreProcedure("SP_AsociarMarcaProveedor", param);
            }
            catch (SqlException ex) when (ErrorSql.EsViolacionUnica(ex)) // Marca es PK
            {
                throw new OperacionNoPermitidaException(
                    "La marca \"" + marca + "\" ya pertenece a un proveedor. " +
                    "Cada marca puede estar asignada a un único proveedor.");
            }
        }

        // Marcas (texto, igual que tProducto.Marca) que provee un proveedor.
        public List<string> MarcasDeProveedor(int idProveedor)
        {
            List<string> marcas = new List<string>();
            SqlParameter[] param = { ParametroSql.Crear("@ID_Proveedor", idProveedor) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_MarcasDeProveedor", param);
            foreach (DataRow fila in dt.Rows)
                marcas.Add(fila["Marca"].ToString());
            return marcas;
        }

        public int InsertarProveedor(Proveedor p)
        {
            SqlParameter[] parametros =
            {
                ParametroSql.Crear("@CUIT",        p.Cuit),
                ParametroSql.Crear("@RazonSocial", p.RazonSocial),
                ParametroSql.Crear("@Telefono",    p.Telefono),
                ParametroSql.Crear("@Email",       p.Email),
                ParametroSql.Crear("@Direccion",   p.Direccion)
            };
            return conexion.EscribirPorStoreProcedure("SP_InsertarProveedor", parametros);
        }

        public bool ExisteProveedor(string cuit)
        {
            SqlParameter[] parametros =
            {
                ParametroSql.Crear("@CUIT", cuit)
            };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ExisteProveedor", parametros);
            return dt != null && dt.Rows.Count > 0;
        }

        public DataTable ObtenerProveedores(string filtro)
        {
            SqlParameter[] parametros =
            {
                ParametroSql.Crear("@Filtro", filtro ?? "")
            };
            return conexion.LeerPorStoreProcedure("SP_ObtenerProveedores", parametros);
        }

        public int ModificarProveedor(Proveedor p)
        {
            SqlParameter[] parametros =
            {
                ParametroSql.Crear("@CUIT",        p.Cuit),
                ParametroSql.Crear("@RazonSocial", p.RazonSocial),
                ParametroSql.Crear("@Telefono",    p.Telefono),
                ParametroSql.Crear("@Email",       p.Email),
                ParametroSql.Crear("@Direccion",   p.Direccion)
            };
            return conexion.EscribirPorStoreProcedure("SP_ModificarProveedor", parametros);
        }

        public int EliminarProveedor(string cuit)
        {
            SqlParameter[] parametros =
            {
                ParametroSql.Crear("@CUIT", cuit)
            };
            try
            {
                return conexion.EscribirPorStoreProcedure("SP_EliminarProveedor", parametros);
            }
            catch (SqlException ex) when (ErrorSql.EsViolacionFK(ex))
            {
                throw new OperacionNoPermitidaException(
                    "No se puede eliminar el proveedor porque tiene compras registradas en el sistema.");
            }
        }
    }
}
