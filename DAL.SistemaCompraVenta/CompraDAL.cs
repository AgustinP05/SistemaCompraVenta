using ENT.SistemaCompraVenta;
using ENT.SistemaCompraVenta.EstadosCompra;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class CompraDAL
    {
        private Conexion conexion = new Conexion();

        // Registra la orden completa (cabecera + detalles) de forma atómica: si falla
        // algún detalle, no queda la cabecera suelta. Nace en estado 'Pendiente'.
        // Lista los reclamos por compras incompletas (faltantes registrados en recepción).
        public DataTable ListarReclamos()
        {
            return conexion.LeerPorStoreProcedure("SP_ListarReclamos", null);
        }

        public int RegistrarCompra(Compra c)
        {
            conexion.IniciarTransaccion();
            try
            {
                SqlParameter[] parametros = {
                    ParametroSql.Crear("@Fecha",        c.Fecha),
                    ParametroSql.Crear("@ID_Proveedor", c.Proveedor.IdProveedor),
                    ParametroSql.Crear("@ID_Usuario",   c.Usuario.ID)
                };

                DataTable dt = conexion.LeerPorStoreProcedure("SP_RegistrarCompra", parametros);
                int idCompra = Convert.ToInt32(dt.Rows[0]["ID_Compra"]);

                foreach (DetalleCompra d in c.Detalles)
                    InsertarDetalle(idCompra, d);

                conexion.Confirmar();
                return idCompra;
            }
            catch
            {
                conexion.Revertir();
                throw;
            }
        }

        public void InsertarDetalle(int idCompra, DetalleCompra d)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_Compra",      idCompra),
                ParametroSql.Crear("@SKU",            d.Variante.SKU),
                ParametroSql.Crear("@Cantidad",       d.Cantidad),
                ParametroSql.Crear("@PrecioUnitario", d.PrecioUnitario)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarDetalleCompra", parametros);
        }

        public int ObtenerProximoNumero()
        {
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ProximoNumeroCompra", null);
            if (dt != null && dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["ProximoNumero"]);
            return 1;
        }

        // Órdenes pendientes para la grilla de recepción (encargado de Stock).
        public DataTable ListarPendientes()
        {
            return conexion.LeerPorStoreProcedure("SP_ListarComprasPendientes", null);
        }

        // Reconstruye una orden completa (cabecera + detalle) desde la base.
        public Compra ObtenerCompraPorId(int idCompra)
        {
            SqlParameter[] pCab = { ParametroSql.Crear("@ID_Compra", idCompra) };
            DataTable dtCab = conexion.LeerPorStoreProcedure("SP_ObtenerCompraPorId", pCab);
            if (dtCab == null || dtCab.Rows.Count == 0) return null;

            DataRow cab = dtCab.Rows[0];
            Compra compra = new Compra
            {
                IdCompra = Convert.ToInt32(cab["ID_Compra"]),
                Fecha    = Convert.ToDateTime(cab["Fecha"]),
                Estado   = EstadoCompraFactory.Crear(cab["Estado"].ToString()),
                Proveedor = new Proveedor
                {
                    IdProveedor = Convert.ToInt32(cab["ID_Proveedor"]),
                    Cuit        = cab["ProveedorCUIT"].ToString(),
                    RazonSocial = cab["ProveedorRazonSocial"].ToString()
                },
                Usuario = new Usuario
                {
                    ID       = Convert.ToInt32(cab["UsuarioID"]),
                    Nombre   = cab["UsuarioNombre"].ToString(),
                    Apellido = cab["UsuarioApellido"].ToString()
                }
            };

            SqlParameter[] pDet = { ParametroSql.Crear("@ID_Compra", idCompra) };
            DataTable dtDet = conexion.LeerPorStoreProcedure("SP_ObtenerDetalleCompraPorId", pDet);
            foreach (DataRow fila in dtDet.Rows)
            {
                compra.Detalles.Add(new DetalleCompra
                {
                    Variante = new ProductoVariante
                    {
                        SKU    = Convert.ToInt32(fila["SKU"]),
                        Nombre = fila["Nombre"].ToString(),
                        Marca  = fila["Marca"].ToString(),
                        Talle  = fila["Talle"].ToString(),
                        Color  = fila["Color"].ToString()
                    },
                    Cantidad           = Convert.ToInt32(fila["Cantidad"]),
                    PrecioUnitario     = Convert.ToDouble(fila["PrecioUnitario"]),
                    CantidadConfirmada = fila["CantidadConfirmada"] == DBNull.Value
                                            ? (int?)null
                                            : Convert.ToInt32(fila["CantidadConfirmada"])
                });
            }

            return compra;
        }

        public void ConfirmarDetalle(int idCompra, int sku, int cantidadConfirmada)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_Compra",          idCompra),
                ParametroSql.Crear("@SKU",                sku),
                ParametroSql.Crear("@CantidadConfirmada", cantidadConfirmada)
            };
            conexion.EscribirPorStoreProcedure("SP_ConfirmarDetalleCompra", parametros);
        }

        // Cierra la recepción: estado final + fecha y usuario que la procesó.
        public void CerrarRecepcion(int idCompra, string estado, DateTime fechaRecepcion, int idUsuarioRecepcion)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_Compra",           idCompra),
                ParametroSql.Crear("@Estado",              estado),
                ParametroSql.Crear("@FechaRecepcion",      fechaRecepcion),
                ParametroSql.Crear("@ID_UsuarioRecepcion", idUsuarioRecepcion)
            };
            conexion.EscribirPorStoreProcedure("SP_CerrarRecepcionCompra", parametros);
        }

        public void InsertarReclamo(int idCompra, int sku, int pedida, int recibida, int faltante)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_Compra",        idCompra),
                ParametroSql.Crear("@SKU",              sku),
                ParametroSql.Crear("@CantidadPedida",   pedida),
                ParametroSql.Crear("@CantidadRecibida", recibida),
                ParametroSql.Crear("@CantidadFaltante", faltante)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarReclamoCompra", parametros);
        }

        // Recepción atómica: por cada ítem suma stock, confirma lo recibido y registra
        // el faltante si lo hubo; al final cierra el estado de la orden. Todo en una
        // transacción: si algo falla, no queda nada a medias (ni stock sumado de más).
        public void ProcesarRecepcion(int idCompra, List<DetalleCompra> detalles,
                                      string estado, DateTime fechaRecepcion, int idUsuarioRecepcion)
        {
            conexion.IniciarTransaccion();
            try
            {
                foreach (DetalleCompra d in detalles)
                {
                    int recibido = d.CantidadConfirmada ?? d.Cantidad;

                    SumarStock(d.Variante.SKU, recibido);
                    ConfirmarDetalle(idCompra, d.Variante.SKU, recibido);

                    int faltante = d.Cantidad - recibido;
                    if (faltante > 0)
                        InsertarReclamo(idCompra, d.Variante.SKU, d.Cantidad, recibido, faltante);
                }

                CerrarRecepcion(idCompra, estado, fechaRecepcion, idUsuarioRecepcion);
                conexion.Confirmar();
            }
            catch
            {
                conexion.Revertir();
                throw;
            }
        }

        private void SumarStock(int sku, int cantidad)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@SKU",      sku),
                ParametroSql.Crear("@Cantidad", cantidad)
            };
            conexion.EscribirPorStoreProcedure("SP_SumarStock", parametros);
        }
    }
}
