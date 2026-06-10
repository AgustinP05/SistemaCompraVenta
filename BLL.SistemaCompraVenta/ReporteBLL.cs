using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using DAL.SistemaCompraVentas;

namespace BLL.SistemaCompraVentas
{
    public class ReporteBLL
    {
        private ReporteDAL oReporteDAL = new ReporteDAL();

        public DataTable ObtenerVentasMensuales()
        {
            // Aquí podrías agregar lógica de negocio si fuera necesario
            return oReporteDAL.ObtenerVentasMensuales();
        }
        public System.Data.DataTable ObtenerTopProductos()
        {
            return oReporteDAL.ObtenerTopProductos(); // Asegurate de tener este método en tu ReporteDAL
        }
        public int ObtenerTotalOperaciones()
        {
            // Usamos LeerPorStoreProcedure que es lo que YA tenés funcionando
            DataTable dt = oReporteDAL.ObtenerTotalOperaciones();

            // Si la tabla tiene datos, convertimos el primer valor
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
    }
}