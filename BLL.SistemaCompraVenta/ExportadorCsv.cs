using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BLL.SistemaCompraVenta
{
    // Exportación a CSV: formato + escritura del archivo. Saca esa responsabilidad de
    // la UI; el form solo junta los encabezados y filas visibles y los pasa acá.
    public static class ExportadorCsv
    {
        private const char Separador = ';';

        public static void Exportar(string ruta, IList<string> encabezados,
                                    IEnumerable<IList<string>> filas)
        {
            using (StreamWriter sw = new StreamWriter(ruta, false, Encoding.UTF8))
            {
                sw.WriteLine(ArmarLinea(encabezados));
                foreach (IList<string> fila in filas)
                    sw.WriteLine(ArmarLinea(fila));
            }
        }

        private static string ArmarLinea(IList<string> campos)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < campos.Count; i++)
            {
                if (i > 0) sb.Append(Separador);
                sb.Append(Escapar(campos[i]));
            }
            return sb.ToString();
        }

        // Regla estándar de CSV: si el valor trae el separador, comillas o saltos de
        // línea, se encierra entre comillas y se duplican las comillas internas.
        private static string Escapar(string valor)
        {
            if (string.IsNullOrEmpty(valor)) return "";

            bool necesitaComillas =
                valor.IndexOf(Separador) >= 0 ||
                valor.IndexOf('"') >= 0 ||
                valor.IndexOf('\n') >= 0 ||
                valor.IndexOf('\r') >= 0;

            return necesitaComillas
                ? "\"" + valor.Replace("\"", "\"\"") + "\""
                : valor;
        }
    }
}
