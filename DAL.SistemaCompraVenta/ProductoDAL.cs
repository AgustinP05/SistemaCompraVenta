using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class ProductoDAL
{
    private Conexion conexion = new Conexion();

    private Producto MapearProducto(DataRow fila)
    {
        // Determinamos el tipo según una columna (ej. "Tipo")
        string tipo = fila["Tipo"].ToString();
        Producto p;

        if (tipo == "Calzado") p = new Calzado();
        else p = new Vestimenta(); // O el tipo por defecto

        p.Id = Convert.ToInt32(fila["ID_Producto"]);
        p.Nombre = fila["Nombre"].ToString();
        p.Marca = fila["Marca"].ToString();
        p.Color = fila["Color"].ToString();
        p.PrecioVenta = (double)Convert.ToDecimal(fila["PrecioVenta"]);
        p.PrecioCosto = (double)Convert.ToDecimal(fila["PrecioCosto"]);
        p.Stock = new Stock { Cantidad = Convert.ToInt32(fila["Stock"]) };

        return p;
    }

    public List<Producto> ListarTodo()
    {
        List<Producto> lista = new List<Producto>();
        DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarProductos", null);
        foreach (DataRow fila in dt.Rows) lista.Add(MapearProducto(fila));
        return lista;
    }

    public Stock BuscarStockPorId(int id)
    {
        SqlParameter[] param = { conexion.crearParametro("@ID_Producto", id) };
        DataTable dt = conexion.LeerPorStoreProcedure("SP_BuscarStock", param);

        if (dt.Rows.Count > 0)
            return new Stock { Cantidad = Convert.ToInt32(dt.Rows[0]["Stock"]) };
        return null;
    }

    public void ActualizarStock(int idProducto, int cantidadVendida)
    {
        SqlParameter[] param = {
            conexion.crearParametro("@ID_Producto", idProducto),
            conexion.crearParametro("@Cantidad", cantidadVendida)
        };
        conexion.EscribirPorStoreProcedure("SP_ActualizarStock", param);
    }
    public void Guardar(Producto p)
    {
        // Asegurate de tener un SP_InsertarProducto en tu SQL
        SqlParameter[] param = {
        conexion.crearParametro("@Nombre", p.Nombre),
        conexion.crearParametro("@Marca", p.Marca),
        conexion.crearParametro("@Color", p.Color), // ¡Agregado!
        conexion.crearParametro("@PrecioVenta", p.PrecioVenta),
        conexion.crearParametro("@PrecioCosto", p.PrecioCosto),
        conexion.crearParametro("@Stock", p.Stock.Cantidad),
        conexion.crearParametro("@Tipo", p.GetType().Name) // Calzado o Vestimenta
    };
        conexion.EscribirPorStoreProcedure("SP_InsertarProducto", param);
    }
}