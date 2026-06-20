using System;
using System.Collections.Generic;
using System.Data;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    public class ProductoBLL
    {
        private ProductoDAL oProductoDAL = new ProductoDAL();
        private VarianteDAL oVarianteDAL = new VarianteDAL();

        // Devuelve el ID del producto creado (para mostrarlo en la grilla de la solapa Crear).
        public int GuardarProducto(Producto p)
        {
            ValidarProducto(p);
            return oProductoDAL.Guardar(p);
        }

        public List<Producto> ListarProductos() => oProductoDAL.ListarTodo();

        public Producto ObtenerProductoPorId(int idProducto) => oProductoDAL.ObtenerPorId(idProducto);

        // ── Buscar / Editar / Eliminar producto ──────────────────────────

        public DataTable ObtenerProductos(string filtro) => oProductoDAL.ObtenerProductos(filtro);

        public bool ModificarProducto(Producto p)
        {
            if (p.Id <= 0)
                throw new Exception("Producto inválido.");

            ValidarProducto(p);
            return oProductoDAL.Modificar(p) > 0;
        }

        public bool EliminarProducto(int idProducto)
        {
            if (idProducto <= 0)
                throw new Exception("Producto inválido.");

            // La DAL traduce la violación de FK (producto con variantes/movimientos)
            // a una OperacionNoPermitidaException con el mensaje correspondiente.
            return oProductoDAL.Eliminar(idProducto) > 0;
        }

        // ── Variantes (SKU) ──────────────────────────────────────────────

        public DataTable ListarVariantesPorProducto(int idProducto) =>
            oVarianteDAL.ListarPorProducto(idProducto);

        public DataTable ListarColores() => oVarianteDAL.ListarColores();

        public DataTable ListarTallesPorCategoria(int idCategoria) =>
            oVarianteDAL.ListarTallesPorCategoria(idCategoria);

        public bool CrearVariante(int idProducto, int idColor, int idTalle)
        {
            if (idProducto <= 0 || idColor <= 0 || idTalle <= 0)
                throw new Exception("Seleccioná producto, color y talle.");

            // Chequeo previo: evita disparar un INSERT que fallaría por el UNIQUE
            // (un insert fallido igual consume el número de SKU y deja huecos).
            if (oVarianteDAL.ExisteVariante(idProducto, idColor, idTalle))
                throw new OperacionNoPermitidaException(
                    "Ya existe una variante de ese producto con ese color y talle.");

            // La red de seguridad ante el UNIQUE (carrera entre el chequeo y el insert)
            // la maneja la DAL, que traduce el SqlException a OperacionNoPermitidaException.
            return oVarianteDAL.Insertar(idProducto, idColor, idTalle) > 0;
        }

        private void ValidarProducto(Producto p)
        {
            if (string.IsNullOrWhiteSpace(p.Nombre) ||
                string.IsNullOrWhiteSpace(p.Marca))
                throw new Exception("Complete nombre y marca del producto.");

            if (p.ID_Categoria <= 0)
                throw new Exception("Seleccione una categoría.");

            if (p.PrecioVenta <= 0 || p.PrecioCosto <= 0)
                throw new Exception("Los precios deben ser mayores a cero.");

            if (p.PrecioVenta < p.PrecioCosto)
                throw new Exception("El precio de venta no puede ser menor al precio de costo.");
        }

        public List<ProductoVariante> ListarVariantes() => oVarianteDAL.ListarVariantes();

        public List<ProductoVariante> ListarVariantesPorProveedor(int idProveedor) =>
            oVarianteDAL.ListarVariantesPorProveedor(idProveedor);

        public System.Data.DataTable ObtenerVariantes(string filtro) => oVarianteDAL.ObtenerVariantes(filtro);

        public System.Data.DataTable ObtenerVariantesPorProveedor(string filtro, int idProveedor) =>
            oVarianteDAL.ObtenerVariantesPorProveedor(filtro, idProveedor);

        public int BuscarStockPorVariante(int idVariante) => oProductoDAL.BuscarStockPorVariante(idVariante);
    }
}
