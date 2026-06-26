using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System.Collections.Generic;

namespace BLL.SistemaCompraVenta
{
    public class CategoriaBLL
    {
        private CategoriaDAL oCategoriaDAL = new CategoriaDAL();

        public List<Categoria> ListarCategorias() => oCategoriaDAL.ListarCategorias();
    }
}
