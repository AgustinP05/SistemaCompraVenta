using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    public class ReporteBLL
    {
        private ReporteDAL oReporteDAL = new ReporteDAL();

        public List<EntidadReporte> GenerarReporte(FiltroReporte f)
        {
            // Valida fechas antes de ir a la BD
            ValidarFechas(f);

            // pide datos a la capa DAL
            List<EntidadReporte> lista = oReporteDAL.ObtenerDatosReporte(f);

            // Un periodo sin ventas no es un error: se devuelve la lista vacía y la UI muestra "No hay datos para mostrar".
            CalcularTotales(lista);

            return lista;
        }

        private void ValidarFechas(FiltroReporte f)
        {
            if (f.FechaDesde > f.FechaHasta)
            {
                // Fechas invalidas mensaje error
                throw new Exception("Seleccione un periodo válido.");
            }
        }

        private void CalcularTotales(List<EntidadReporte> data)
        {
            // Recorremos cada venta del reporte
            foreach (var reporte in data)
            {
                decimal totalAcumulado = 0;
                decimal costoAcumulado = 0;

                foreach (var detalle in reporte.Detalles)
                {
                    totalAcumulado += detalle.Subtotal;
                    costoAcumulado += detalle.Costo;
                }

                //resultado en la cabecera (TotalVenta bruto y costo para el margen)
                reporte.TotalVenta = totalAcumulado;
                reporte.Costo = costoAcumulado;
            }
        }

        // KPIs del reporte (facturación, ganancia, ticket, tops).
        // FormGerente muestra lo que devuelve este método.
        public ResumenReporte CalcularResumen(List<EntidadReporte> ventas)
        {
            ResumenReporte r = new ResumenReporte();
            if (ventas == null) return r;

            foreach (EntidadReporte v in ventas)
            {
                r.FacturadoBruto += v.TotalVenta;
                r.Descuentos     += v.Descuento;
                r.Costo          += v.Costo;
                foreach (DetalleReporte d in v.Detalles)
                    r.Unidades += d.Cantidad;
            }

            r.CantidadVentas  = ventas.Count;
            r.FacturadoNeto   = r.FacturadoBruto - r.Descuentos;
            r.GananciaNeta    = r.FacturadoNeto - r.Costo;
            r.TicketPromedio  = r.CantidadVentas > 0 ? r.FacturadoNeto / r.CantidadVentas : 0;

            var topProducto = ventas.SelectMany(v => v.Detalles)
                .GroupBy(d => d.DescripcionProducto)
                .Select(g => new { Nombre = g.Key, Unidades = g.Sum(x => x.Cantidad) })
                .OrderByDescending(x => x.Unidades)
                .FirstOrDefault();
            if (topProducto != null)
            {
                r.TopProductoNombre   = topProducto.Nombre;
                r.TopProductoUnidades = topProducto.Unidades;
            }

            var topVendedor = ventas.GroupBy(v => v.NombreVendedor)
                .Select(g => new { Nombre = g.Key, Total = g.Sum(x => x.TotalNeto) })
                .OrderByDescending(x => x.Total)
                .FirstOrDefault();
            if (topVendedor != null)
                r.TopVendedorNombre = topVendedor.Nombre;

            return r;
        }

        // Subtotales agrupados por Producto / Cliente / Vendedor (para la grilla
        // agrupada del reporte). Devuelve una DataTable lista para bindear.
        public DataTable Agrupar(List<EntidadReporte> ventas, string criterio)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Grupo", typeof(string));
            dt.Columns.Add("Unidades", typeof(int));
            dt.Columns.Add("Descuento", typeof(decimal));
            dt.Columns.Add("Total Neto", typeof(decimal));
            dt.Columns.Add("Ganancia", typeof(decimal));

            if (ventas == null) return dt;

            if (criterio == "Producto")
            {
                // El descuento es por venta, no por producto: no se discrimina en este corte.
                var grupos = ventas.SelectMany(v => v.Detalles)
                    .GroupBy(d => d.DescripcionProducto)
                    .Select(g => new
                    {
                        Grupo = g.Key,
                        Unidades = g.Sum(x => x.Cantidad),
                        Total = g.Sum(x => x.Subtotal),
                        Ganancia = g.Sum(x => x.Subtotal - x.Costo)
                    })
                    .OrderByDescending(x => x.Total);

                foreach (var g in grupos)
                    dt.Rows.Add(g.Grupo, g.Unidades, 0m, g.Total, g.Ganancia);
            }
            else
            {
                Func<EntidadReporte, string> selector =
                    criterio == "Cliente"
                        ? (Func<EntidadReporte, string>)(v => v.NombreCliente)
                        : (v => v.NombreVendedor);

                var grupos = ventas.GroupBy(selector)
                    .Select(g => new
                    {
                        Grupo = g.Key,
                        Unidades = g.Sum(v => v.Detalles.Sum(d => d.Cantidad)),
                        Descuento = g.Sum(v => v.Descuento),
                        Total = g.Sum(v => v.TotalNeto),
                        Ganancia = g.Sum(v => v.Ganancia)
                    })
                    .OrderByDescending(x => x.Total);

                foreach (var g in grupos)
                    dt.Rows.Add(g.Grupo, g.Unidades, g.Descuento, g.Total, g.Ganancia);
            }

            return dt;
        }
    }
}