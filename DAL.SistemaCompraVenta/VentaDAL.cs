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
            SqlParameter[] pCab = { ParametroSql.Crear("@ID_Venta", idVenta) };
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

        
            SqlParameter[] pDet = { ParametroSql.Crear("@ID_Venta", idVenta) };
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
            SqlParameter[] pDesc = { ParametroSql.Crear("@ID_Venta", idVenta) };
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
                ParametroSql.Crear("@Fecha",      v.Fecha),
                ParametroSql.Crear("@ID_Cliente", v.Cliente.IdCliente),
                ParametroSql.Crear("@ID_Usuario", v.Usuario.ID)
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
                ParametroSql.Crear("@ID_Venta",            idVenta),
                ParametroSql.Crear("@SKU",            d.Variante.SKU),
                ParametroSql.Crear("@Cantidad",            d.Cantidad),
                ParametroSql.Crear("@PrecioUnitario",      d.PrecioUnitario)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarDetalleVenta", parametros);
        }

        public void InsertarDescuento(int idVenta, string tipo, double monto)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_Venta", idVenta),
                ParametroSql.Crear("@Tipo",     tipo),
                ParametroSql.Crear("@Monto",    monto)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarDescuentoVenta", parametros);
        }

        // Cierra la venta de forma atómica: cabecera + detalles + descuento de stock +
        // auditoría de descuento, todo en una transacción. La validación de stock la
        // hace la BLL antes de llamar acá.
        public int FinalizarVenta(Venta v)
        {
            conexion.IniciarTransaccion();
            try
            {
                int idVenta = RegistrarVenta(v);

                foreach (DetalleVenta d in v.Detalles)
                {
                    InsertarDetalle(idVenta, d);
                    DescontarStock(d.Variante.SKU, d.Cantidad);
                }

                double montoDescuento = v.DevolverDescuento();
                if (montoDescuento > 0)
                    InsertarDescuento(idVenta, v.Descuento.Descripcion, montoDescuento);

                conexion.Confirmar();
                return idVenta;
            }
            catch
            {
                conexion.Revertir();
                throw;
            }
        }

        private void DescontarStock(int sku, int cantidad)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@SKU",      sku),
                ParametroSql.Crear("@Cantidad", cantidad)
            };
            conexion.EscribirPorStoreProcedure("SP_ActualizarStock", parametros);
        }
    }
}
