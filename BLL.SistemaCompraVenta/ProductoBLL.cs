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

        public List<ProductoVariante> ListarVariantesPorProveedor(int idProveedor) =>
            oVarianteDAL.ListarVariantesPorProveedor(idProveedor);

        public System.Data.DataTable ObtenerVariantes(string filtro) => oVarianteDAL.ObtenerVariantes(filtro);

        public System.Data.DataTable ObtenerVariantesPorProveedor(string filtro, int idProveedor) =>
            oVarianteDAL.ObtenerVariantesPorProveedor(filtro, idProveedor);

        public int BuscarStockPorVariante(int idVariante) => oProductoDAL.BuscarStockPorVariante(idVariante);
    }
}
