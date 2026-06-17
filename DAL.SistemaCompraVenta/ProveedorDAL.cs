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

        // Marcas (texto, igual que tProducto.Marca) que provee un proveedor.
        public List<string> MarcasDeProveedor(int idProveedor)
        {
            List<string> marcas = new List<string>();
            SqlParameter[] param = { conexion.crearParametro("@ID_Proveedor", idProveedor) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_MarcasDeProveedor", param);
            foreach (DataRow fila in dt.Rows)
                marcas.Add(fila["Marca"].ToString());
            return marcas;
        }

        public int InsertarProveedor(Proveedor p)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@CUIT",        p.Cuit),
                conexion.crearParametro("@RazonSocial", p.RazonSocial),
                conexion.crearParametro("@Telefono",    p.Telefono),
                conexion.crearParametro("@Email",       p.Email),
                conexion.crearParametro("@Direccion",   p.Direccion)
            };
            return conexion.EscribirPorStoreProcedure("SP_InsertarProveedor", parametros);
        }

        public bool ExisteProveedor(string cuit)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@CUIT", cuit)
            };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ExisteProveedor", parametros);
            return dt != null && dt.Rows.Count > 0;
        }

        public DataTable ObtenerProveedores(string filtro)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@Filtro", filtro ?? "")
            };
            return conexion.LeerPorStoreProcedure("SP_ObtenerProveedores", parametros);
        }

        public int ModificarProveedor(Proveedor p)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@CUIT",        p.Cuit),
                conexion.crearParametro("@RazonSocial", p.RazonSocial),
                conexion.crearParametro("@Telefono",    p.Telefono),
                conexion.crearParametro("@Email",       p.Email),
                conexion.crearParametro("@Direccion",   p.Direccion)
            };
            return conexion.EscribirPorStoreProcedure("SP_ModificarProveedor", parametros);
        }

        public int EliminarProveedor(string cuit)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@CUIT", cuit)
            };
            return conexion.EscribirPorStoreProcedure("SP_EliminarProveedor", parametros);
        }
    }
}
