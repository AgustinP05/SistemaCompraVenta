using System.Windows.Forms;

namespace UI.SistemaCompraVentas
{
    // Helpers reutilizables para leer celdas de una grilla. Evita duplicar el mismo
    // "leer la columna por su nombre" (ObtenerCelda/LeerCelda) en cada form.
    internal static class GrillaHelper
    {
        // Lee la celda de la fila probando varios nombres de columna posibles.
        // Devuelve "" si ninguno existe.
        public static string LeerCelda(DataGridView dgv, DataGridViewRow fila, params string[] nombres)
        {
            foreach (string nombre in nombres)
                if (dgv.Columns.Contains(nombre))
                    return fila.Cells[nombre].Value?.ToString() ?? "";
            return "";
        }

        // Igual que LeerCelda pero parseando a int (0 si no es número o no existe la columna).
        public static int LeerEntero(DataGridView dgv, DataGridViewRow fila, params string[] nombres)
        {
            return int.TryParse(LeerCelda(dgv, fila, nombres), out int valor) ? valor : 0;
        }
    }
}
