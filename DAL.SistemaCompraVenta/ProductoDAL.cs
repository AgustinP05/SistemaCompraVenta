using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ProductoDAL
    {
        private Conexion conexion = new Conexion();

        private Producto MapearProducto(DataRow fila)
        {
            string categoria = fila["Categoria"].ToString();
            Producto p = categoria.Equals("CALZADO", StringComparison.OrdinalIgnoreCase)
                ? (Producto)new Calzado()
                : new Vestimenta();

            p.Id          = Convert.ToInt32(fila["ID_Producto"]);
            p.Nombre      = fila["Nombre"].ToString();
            p.Marca       = fila["Marca"].ToString();
            p.Categoria   = categoria;
            p.PrecioVenta = (double)Convert.ToDecimal(fila["PrecioVenta"]);
            p.PrecioCosto = (double)Convert.ToDecimal(fila["PrecioCosto"]);
            return p;
        }

        public List<Producto> ListarTodo()
        {
            List<Producto> lista = new List<Producto>();
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarProductos", null);
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearProducto(fila));
            return lista;
        }

        public void Guardar(Producto p)
        {
            SqlParameter[] param = {
                conexion.crearParametro("@Nombre",       p.Nombre),
                conexion.crearParametro("@Marca",        p.Marca),
                conexion.crearParametro("@ID_Categoria", p.ID_Categoria),
                conexion.crearParametro("@PrecioVenta",  p.PrecioVenta),
                conexion.crearParametro("@PrecioCosto",  p.PrecioCosto)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarProducto", param);
        }

        public int BuscarStockPorVariante(int idVariante)
        {
            SqlParameter[] param = { conexion.crearParametro("@SKU", idVariante) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_BuscarStock", param);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["Cantidad"]);
            return 0;
        }

        public void ActualizarStock(int idVariante, int cantidadVendida)
        {
            SqlParameter[] param = {
                conexion.crearParametro("@SKU",      idVariante),
                conexion.crearParametro("@Cantidad", cantidadVendida)
            };
            conexion.EscribirPorStoreProcedure("SP_ActualizarStock", param);
        }
    }
}
