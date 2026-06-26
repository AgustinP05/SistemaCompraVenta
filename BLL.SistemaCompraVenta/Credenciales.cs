using System;
using System.Globalization;
using System.Text;

namespace BLL.SistemaCompraVenta
{
    // Reglas de credenciales:
    //  - La contraseña NO se almacena: se deriva y se valida.
    //  - El email se autogenera a partir del nombre y apellido.
    public static class Credenciales
    {
        public const string DominioEmail = "@sportupe.com.ar";

        // Contraseña = ddMM (de la fecha de nacimiento) + los primeros 4 dígitos del DNI.
        // Ej: nacido 12/03/1985, DNI 11111111 -> "1203" + "1111" = "12031111".
        public static string GenerarPassword(DateTime? fechaNacimiento, string dni)
        {
            if (!fechaNacimiento.HasValue) return null;

            string ddmm = fechaNacimiento.Value.ToString("ddMM", CultureInfo.InvariantCulture);

            string digitos = SoloDigitos(dni);
            if (digitos.Length < 4) return null; // DNI sin los 4 dígitos necesarios
            string dni4 = digitos.Substring(0, 4);

            return ddmm + dni4;
        }

        // Parte local del email (antes del @): inicial del nombre + apellido completo,
        // en minúsculas, sin tildes ni espacios. Ej: "Agustin", "Perea" -> "aperea".
        public static string BaseEmail(string nombre, string apellido)
        {
            string n = Normalizar(nombre);
            string a = Normalizar(apellido);
            string inicial = n.Length > 0 ? n.Substring(0, 1) : "";
            return inicial + a;
        }

        // Quita tildes/acentos, espacios y todo lo que no sea letra o dígito; pasa a minúsculas.
        private static string Normalizar(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return "";

            string sinTildes = texto.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in sinTildes)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
                    continue; // descarta la marca diacrítica
                if (char.IsLetterOrDigit(c))
                    sb.Append(char.ToLowerInvariant(c));
            }
            return sb.ToString();
        }

        private static string SoloDigitos(string texto)
        {
            if (string.IsNullOrEmpty(texto)) return "";
            StringBuilder sb = new StringBuilder();
            foreach (char c in texto)
                if (char.IsDigit(c)) sb.Append(c);
            return sb.ToString();
        }
    }
}
