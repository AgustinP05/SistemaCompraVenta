using DAL.SistemaCompraVenta;
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
                conexion.crearParametro("@Fecha", v.Fecha),
                conexion.crearParametro("@ID_Cliente", v.Cliente.IdCliente),
                conexion.crearParametro("@ID_Usuario", v.Usuario.ID),
                conexion.crearParametro("@Total", v.DevolverTotal())
            };

            // Usamos un método que nos devuelva el ID del registro insertado
            DataTable dt = conexion.LeerPorStoreProcedure("SP_RegistrarVenta", parametros);
            return Convert.ToInt32(dt.Rows[0]["ID_Venta"]);
        }
        public void InsertarDetalle(int idVenta, DetalleVenta d)
        {
            SqlParameter[] parametros = {
        conexion.crearParametro("@ID_Venta", idVenta),
        conexion.crearParametro("@ID_Producto", d.Producto.Id),
        conexion.crearParametro("@Cantidad", d.Cantidad),
        conexion.crearParametro("@PrecioUnitario", d.PrecioUnitario),
        conexion.crearParametro("@Subtotal", d.DevolverSubtotal())
    };
            conexion.EscribirPorStoreProcedure("SP_InsertarDetalleVenta", parametros);
        }
    }
}
