using System;
using System.IO;
using System.Text;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{

    public class ComprobanteBLL
    {
        private VentaDAL oVentaDAL = new VentaDAL();

        public string GenerarTexto(int nroVenta)
        {
            Venta venta = oVentaDAL.ObtenerVentaPorId(nroVenta);
            if (venta == null)
                throw new Exception("No se encontró la venta N° " + nroVenta + ".");

            return Formatear(venta, nroVenta);
        }

        // Genera el archivo .txt en Mis Documentos\Comprobantes y devuelve la ruta.
        public string GuardarComprobante(int nroVenta)
        {
            string carpeta = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Comprobantes");
            Directory.CreateDirectory(carpeta);

            string ruta = Path.Combine(carpeta, $"Comprobante_Venta_{nroVenta}.txt");
            File.WriteAllText(ruta, GenerarTexto(nroVenta));
            return ruta;
        }

        private string Formatear(Venta venta, int nroVenta)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("===================================================");
            sb.AppendLine("              SPORT UPE - COMPROBANTE");
            sb.AppendLine("===================================================");
            sb.AppendLine($"Venta N°      : {nroVenta}");
            sb.AppendLine($"Fecha         : {venta.Fecha:dd/MM/yyyy HH:mm}");
            sb.AppendLine($"Vendedor      : {(venta.Usuario != null ? $"{venta.Usuario.Nombre} {venta.Usuario.Apellido}".Trim() : "-")}");
            sb.AppendLine($"Cliente       : {(venta.Cliente != null ? $"{venta.Cliente.Apellido}, {venta.Cliente.Nombre} (DNI {venta.Cliente.Dni})" : "-")}");
            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine($"{"Producto",-22}{"Cant",-6}{"Precio",10}{"Subtotal",13}");
            sb.AppendLine("---------------------------------------------------");

            foreach (DetalleVenta d in venta.Detalles)
            {
                string nombre = d.Variante.Nombre.Length > 20
                    ? d.Variante.Nombre.Substring(0, 20) : d.Variante.Nombre;
                sb.AppendLine($"{nombre,-22}{d.Cantidad,-6}{d.PrecioUnitario,10:N2}{d.DevolverSubtotal(),13:N2}");
                sb.AppendLine($"   SKU {d.Variante.SKU} | Talle {d.Variante.Talle} | Color {d.Variante.Color}");
            }

            sb.AppendLine("---------------------------------------------------");
            sb.AppendLine($"SUBTOTAL : $ {venta.DevolverSubtotal():N2}");
            sb.AppendLine($"DESCUENTO: $ {venta.DevolverDescuento():N2}  ({venta.Descuento.Descripcion})");
            sb.AppendLine($"TOTAL    : $ {venta.DevolverTotal():N2}");
            sb.AppendLine("===================================================");
            sb.AppendLine("              ¡Gracias por su compra!");

            return sb.ToString();
        }
    }
}
