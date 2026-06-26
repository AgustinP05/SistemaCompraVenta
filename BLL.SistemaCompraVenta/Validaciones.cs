namespace BLL.SistemaCompraVenta
{
    // Validaciones simples compartidas por las distintas BLL (evita duplicar lógica).
    public static class Validaciones
    {
        // Email válido: no vacío y con un formato mínimo (contiene "@" y ".").
        public static bool EmailValido(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Contains("@") && email.Contains(".");
        }
    }
}
