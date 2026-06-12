using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    public class ProductoBLL
    {
        private ProductoDAL oProductoDAL = new ProductoDAL();

        public void GuardarProducto(Producto p)
        {
            // Aquí irían validaciones de negocio antes de guardar
            oProductoDAL.Guardar(p);
        }

        public Stock BuscarStockPorId(int id)
        {
            // Delegamos la búsqueda a la Capa de Acceso a Datos (DAL)
            return oProductoDAL.BuscarStockPorId(id);
        }
        public void ActualizarStock(int idProducto, int cantidadVendida)
        {
            // Llamamos a la DAL para que haga la resta en la tabla tProducto
            oProductoDAL.ActualizarStock(idProducto, cantidadVendida);
        }

        public List<Producto> ListarProductos()
        {
            return oProductoDAL.ListarTodo();
        }
    }
}