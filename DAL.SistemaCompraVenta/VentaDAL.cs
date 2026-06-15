using ENT.SistemaCompraVenta;
using ENT.SistemaCompraVenta.Descuentos;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class VentaDAL
    {
        private Conexion conexion = new Conexion();

        public Venta ObtenerVentaPorId(int idVenta)
        {
            SqlParameter[] pCab = { conexion.crearParametro("@ID_Venta", idVenta) };
            DataTable dtCab = conexion.LeerPorStoreProcedure("SP_ObtenerVentaPorId", pCab);
            if (dtCab == null || dtCab.Rows.Count == 0) return null;

            DataRow cab = dtCab.Rows[0];
            Venta venta = new Venta
            {
                IdVenta = Convert.ToInt32(cab["ID_Venta"]),
                Fecha   = Convert.ToDateTime(cab["Fecha"]),
                Cliente = new Cliente
                {
                    IdCliente = Convert.ToInt32(cab["ID_Cliente"]),
                    Dni       = cab["ClienteDNI"].ToString(),
                    Nombre    = cab["ClienteNombre"].ToString(),
                    Apellido  = cab["ClienteApellido"].ToString()
                },
                Usuario = new Usuario
                {
                    ID       = Convert.ToInt32(cab["UsuarioID"]),
                    Nombre   = cab["UsuarioNombre"].ToString(),
                    Apellido = cab["UsuarioApellido"].ToString()
                }
            };

        
            SqlParameter[] pDet = { conexion.crearParametro("@ID_Venta", idVenta) };
            DataTable dtDet = conexion.LeerPorStoreProcedure("SP_ObtenerDetalleVentaPorId", pDet);
            foreach (DataRow fila in dtDet.Rows)
            {
                venta.Detalles.Add(new DetalleVenta
                {
                    Variante = new ProductoVariante
                    {
                        SKU    = Convert.ToInt32(fila["SKU"]),
                        Nombre = fila["Nombre"].ToString(),
                        Marca  = fila["Marca"].ToString(),
                        Talle  = fila["Talle"].ToString(),
                        Color  = fila["Color"].ToString()
                    },
                    Cantidad       = Convert.ToInt32(fila["Cantidad"]),
                    PrecioUnitario = Convert.ToDouble(fila["PrecioUnitario"])
                });
            }

            // Descuento auditado (si la venta tuvo descuentos)
            SqlParameter[] pDesc = { conexion.crearParametro("@ID_Venta", idVenta) };
            DataTable dtDesc = conexion.LeerPorStoreProcedure("SP_ObtenerDescuentoVenta", pDesc);
            if (dtDesc != null && dtDesc.Rows.Count > 0)
            {
                DataRow d = dtDesc.Rows[0];
                venta.Descuento = new DescuentoAuditado(
                    Convert.ToDouble(d["Monto"]), d["Tipo"].ToString());
            }

            return venta;
        }

        public int RegistrarVenta(Venta v)
        {
            SqlParameter[] parametros = {
                conexion.crearParametro("@Fecha",      v.Fecha),
                conexion.crearParametro("@ID_Cliente", v.Cliente.IdCliente),
                conexion.crearParametro("@ID_Usuario", v.Usuario.ID)
            };

            DataTable dt = conexion.LeerPorStoreProcedure("SP_RegistrarVenta", parametros);
            return Convert.ToInt32(dt.Rows[0]["ID_Venta"]);
        }

        public int ObtenerProximoNumero()
        {
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ProximoNumeroVenta", null);
            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["ProximoNumero"]);
            return 1;
        }

        public void InsertarDetalle(int idVenta, DetalleVenta d)
        {
            SqlParameter[] parametros = {
                conexion.crearParametro("@ID_Venta",            idVenta),
                conexion.crearParametro("@SKU",            d.Variante.SKU),
                conexion.crearParametro("@Cantidad",            d.Cantidad),
                conexion.crearParametro("@PrecioUnitario",      d.PrecioUnitario)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarDetalleVenta", parametros);
        }

        public void InsertarDescuento(int idVenta, string tipo, double monto)
        {
            SqlParameter[] parametros = {
                conexion.crearParametro("@ID_Venta", idVenta),
                conexion.crearParametro("@Tipo",     tipo),
                conexion.crearParametro("@Monto",    monto)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarDescuentoVenta", parametros);
        }
    }
}
