using System;
using System.Collections.Generic;
using System.Data;
using DAL.SistemaCompraVentas;
using ENT.SistemaCompraVenta; 

namespace BLL.SistemaCompraVentas
{
    public class ReporteBLL
    {
        private ReporteDAL oReporteDAL = new ReporteDAL();

        /*DASHHH*/

        public DataTable ObtenerVentasMensuales()
        {
            return oReporteDAL.ObtenerVentasMensuales();
        }

        public DataTable ObtenerTopProductos()
        {
            return oReporteDAL.ObtenerTopProductos();
        }

        public int ObtenerTotalOperaciones()
        {
            DataTable dt = oReporteDAL.ObtenerTotalOperaciones();
            if (dt != null && dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }

        public DataTable ObtenerProductosStockCritico()
        {
            return oReporteDAL.ObtenerProductosStockCritico();
        }

        /* 
         * CASO DE USO CU-GER0001
         */

        public List<EntidadReporte> GenerarReporte(FiltroReporte f)
        {
            // Valida fechas antes de ir a la BD
            ValidarFechas(f);

            // pide datos a la capa DAL
            List<EntidadReporte> lista = oReporteDAL.ObtenerDatosReporte(f);

            // Mensaje por si no hay registros
            if (lista == null || lista.Count == 0)
            {
                throw new Exception("No hay datos para el periodo seleccionado.");
            }
            CalcularTotales(lista);

            return lista;
        }

        private void ValidarFechas(FiltroReporte f)
        {
            if (f.FechaDesde > f.FechaHasta)
            {
                // Fechasin validas mensaje error
                throw new Exception("Seleccione un periodo válido.");
            }
        }

        private void CalcularTotales(List<EntidadReporte> data)
        {
            // Recorremos cada venta del reporte
            foreach (var reporte in data)
            {
                decimal totalAcumulado = 0;

              
                foreach (var detalle in reporte.Detalles)
                {
                    totalAcumulado += detalle.Subtotal;
                }

                //resultado en la cabecera
                reporte.TotalVenta = totalAcumulado;
            }
        }
    }
}