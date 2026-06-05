using System.Collections.Generic;
using ENT.SistemaCompraVenta;

namespace DAL.SistemaCompraVenta
{
    public class ProductoDAL
    {
        private static List<Producto> baseDeDatos = new List<Producto>()
{
    new Calzado {
        Id = 45000, Nombre = "Zapatillas Air Max", Marca = "Nike", PrecioVenta = 120000, PrecioCosto = 70000, Talle = 42,
        Stock = new Stock { IdProducto = 45000, Cantidad = 50 }
    },
    new Vestimenta {
        Id = 45003, Nombre = "Remera Dry-Fit", Marca = "Adidas", PrecioVenta = 45000, PrecioCosto = 20000, Talle = "L",
        Stock = new Stock { IdProducto = 45003, Cantidad = 10 }
    }
};
        // Creamos un contador que empiece en 1
        private static int proximoId = 45004;
        public Stock BuscarStockPorId(int id)
        {
            // Recorremos la lista simulada a mano usando un bucle clásico (¡SIN LINQ!)
            // CAMBIO: Ahora recorre 'baseDeDatos' que es el nombre real de tu lista
            foreach (Producto p in baseDeDatos)
            {
                if (p.Id == id)
                {
                    // Si encontramos el producto, devolvemos su objeto Stock
                    return p.Stock;
                }
            }

            // Si el producto no existe, devolvemos null (o podrías lanzar una excepción)
            return null;
        }
        public void Guardar(Producto p)
        {
            // Le asignamos el ID actual y después sumamos 1 para el próximo
            p.Id = proximoId++;
            baseDeDatos.Add(p);
        }

        public List<Producto> ListarTodo()
        {
            return baseDeDatos;
        }
    }
}