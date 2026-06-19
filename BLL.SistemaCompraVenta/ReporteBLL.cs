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

        /*
         * CASO DE USO CU-GER0001
         */

        public List<EntidadReporte> GenerarReporte(FiltroReporte f)
        {
            // Valida fechas antes de ir a la BD
            ValidarFechas(f);

            // pide datos a la capa DAL
            List<EntidadReporte> lista = oReporteDAL.ObtenerDatosReporte(f);

            // Un periodo sin ventas no es un error: se devuelve la lista vacía y la UI
            // muestra "No hay datos para mostrar" (Alternativa 1 del CU).
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
    }
}