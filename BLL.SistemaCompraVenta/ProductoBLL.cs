using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    public class ProductoBLL
    {
        private ProductoDAL oProductoDAL = new ProductoDAL();
        private VarianteDAL oVarianteDAL = new VarianteDAL();

        public void GuardarProducto(Producto p) => oProductoDAL.Guardar(p);

        public List<Producto> ListarProductos() => oProductoDAL.ListarTodo();

        public List<ProductoVariante> ListarVariantes() => oVarianteDAL.ListarVariantes();

        public System.Data.DataTable ObtenerVariantes(string filtro) => oVarianteDAL.ObtenerVariantes(filtro);

        public int BuscarStockPorVariante(int idVariante) => oProductoDAL.BuscarStockPorVariante(idVariante);

        public void ActualizarStock(int idVariante, int cantidadVendida) =>
            oProductoDAL.ActualizarStock(idVariante, cantidadVendida);
    }
}
