using ENT.SistemaCompraVenta;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ProveedorDAL
    {
        private Conexion conexion = new Conexion();

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
