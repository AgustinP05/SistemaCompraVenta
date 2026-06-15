using ENT.SistemaCompraVenta;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class VentaDAL
    {
        private Conexion conexion = new Conexion();

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
    }
}
