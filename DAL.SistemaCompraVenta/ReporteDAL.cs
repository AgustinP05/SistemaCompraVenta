using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ReporteDAL
    {
        private Conexion conexion = new Conexion();
      
        //Reporte Filtrado
        public List<EntidadReporte> ObtenerDatosReporte(FiltroReporte f)
        {
            List<EntidadReporte> listaReportes = new List<EntidadReporte>();

            // si DBNull.Value si el filtro no se selecciono
            SqlParameter[] parametros = {
                ParametroSql.Crear("@Desde", f.FechaDesde),
                ParametroSql.Crear("@Hasta", f.FechaHasta),
                ParametroSql.Crear("@IdVendedor", f.IdVendedor.HasValue ? (object)f.IdVendedor.Value : DBNull.Value),
                ParametroSql.Crear("@IdProducto", f.IdProducto.HasValue ? (object)f.IdProducto.Value : DBNull.Value),
                ParametroSql.Crear("@IdCliente", f.IdCliente.HasValue ? (object)f.IdCliente.Value : DBNull.Value),
                ParametroSql.Crear("@IdCategoria", f.IdCategoria.HasValue ? (object)f.IdCategoria.Value : DBNull.Value)
            };

            // SP
            DataTable dt = conexion.LeerPorStoreProcedure("sp_GenerarReporteVentas", parametros);

            // Agrupacion x diccionario 
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
                    nuevaVenta.Descuento = Convert.ToDecimal(fila["Descuento"]);
                    nuevaVenta.TipoDescuento = fila["TipoDescuento"].ToString();

                    diccionarioVentas.Add(idVenta, nuevaVenta);
                }

                // detalle
                DetalleReporte detalle = new DetalleReporte();
                detalle.DescripcionProducto = fila["DescripcionProducto"].ToString();
                detalle.Cantidad = Convert.ToInt32(fila["Cantidad"]);
                detalle.Subtotal = Convert.ToDecimal(fila["Subtotal"]);
                detalle.Costo = Convert.ToDecimal(fila["Costo"]);

                diccionarioVentas[idVenta].Detalles.Add(detalle);
            }

            // de diccionario a lista
            listaReportes.AddRange(diccionarioVentas.Values);
            return listaReportes;
        }
    }
}