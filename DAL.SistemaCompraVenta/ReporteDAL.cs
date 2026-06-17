using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVentas
{
    public class ReporteDAL
    {
        private Conexion conexion = new Conexion();

        /* METODOS DEL DASHBOARD  */

        public DataTable ObtenerVentasMensuales()
        {
            return conexion.LeerPorStoreProcedure("SP_ReporteVentasMensuales", null);
        }

        public DataTable ObtenerTopProductos()
        {
            return conexion.LeerPorStoreProcedure("SP_ReporteTopProductos", null);
        }

        public DataTable ObtenerTotalOperaciones()
        {
            return conexion.LeerPorStoreProcedure("SP_ContarVentas", null);
        }

        public DataTable ObtenerProductosStockCritico()
        {
            return conexion.LeerPorStoreProcedure("SP_ProductosStockMinimo", null);
        }

        /*
         * CASO DE USO CU-GER0001 (Reporte Filtrado)
         */

        public List<EntidadReporte> ObtenerDatosReporte(FiltroReporte f)
        {
            List<EntidadReporte> listaReportes = new List<EntidadReporte>();

            // si DBNull.Value si el filtro no se selecciono
            SqlParameter[] parametros = {
                conexion.crearParametro("@Desde", f.FechaDesde),
                conexion.crearParametro("@Hasta", f.FechaHasta),
                conexion.crearParametro("@IdVendedor", f.IdVendedor.HasValue ? (object)f.IdVendedor.Value : DBNull.Value),
                conexion.crearParametro("@IdProducto", f.IdProducto.HasValue ? (object)f.IdProducto.Value : DBNull.Value),
                conexion.crearParametro("@IdCliente", f.IdCliente.HasValue ? (object)f.IdCliente.Value : DBNull.Value)
            };

            // SP
            DataTable dt = conexion.LeerPorStoreProcedure("sp_GenerarReporteVentas", parametros);

            // Agrupacion x diccionario.. esto lo vimos en la catedra? o lo vimos en eda? 
            Dictionary<int, EntidadReporte> diccionarioVentas = new Dictionary<int, EntidadReporte>();

            foreach (DataRow fila in dt.Rows)
            {
                int idVenta = Convert.ToInt32(fila["ID_Venta"]);

                if (!diccionarioVentas.ContainsKey(idVenta))
                {
                    EntidadReporte nuevaVenta = new EntidadReporte();
                    nuevaVenta.IdVenta = idVenta;
                    nuevaVenta.Fecha = Convert.ToDateTime(fila["Fecha"]);
                    nuevaVenta.NombreCliente = fila["NombreCliente"].ToString();
                    nuevaVenta.NombreVendedor = fila["NombreVendedor"].ToString();
                    nuevaVenta.TotalVenta = 0;

                    diccionarioVentas.Add(idVenta, nuevaVenta);
                }

                // detalle
                DetalleReporte detalle = new DetalleReporte();
                detalle.DescripcionProducto = fila["DescripcionProducto"].ToString();
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(fila["Subtotal"]);

                diccionarioVentas[idVenta].Detalles.Add(detalle);
            }

            // de diccionario a lista
            listaReportes.AddRange(diccionarioVentas.Values);
            return listaReportes;
        }
    }
}