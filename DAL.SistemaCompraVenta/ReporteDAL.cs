using DAL.SistemaCompraVenta;
using System.Data;
using System.Data.SqlClient;


namespace DAL.SistemaCompraVentas
{
    public class ReporteDAL
    {
        private Conexion conexion = new Conexion();

        // Trae las ventas agrupadas por mes para la grilla
        public DataTable ObtenerVentasMensuales()
        {
            return conexion.LeerPorStoreProcedure("SP_ReporteVentasMensuales", null);
        }

        // Trae el top 5 de productos más vendidos
        public DataTable ObtenerTopProductos()
        {
            return conexion.LeerPorStoreProcedure("SP_ReporteTopProductos", null);
        }
        //Cantidad de ventas
        public DataTable ObtenerTotalOperaciones()
        {
            return conexion.LeerPorStoreProcedure("SP_ContarVentas", null);
        }

        //Alertas de stock
        public DataTable ObtenerProductosStockCritico()
        {
            return conexion.LeerPorStoreProcedure("SP_ProductosStockMinimo", null);
        }
    }
}