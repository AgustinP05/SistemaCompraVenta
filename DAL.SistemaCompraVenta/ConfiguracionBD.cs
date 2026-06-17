namespace DAL.SistemaCompraVenta
{
    // Única responsabilidad: de dónde sale la cadena de conexión.
    // Para cambiar de máquina se toca SOLO acá (a futuro, mover a App.config).
    internal static class ConfiguracionBD
    {
        public static string CadenaConexion =>
            @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaCompraVenta;Data Source=DESKTOP-31EJQH0\SQLEXPRESS";

        // Otras máquinas del equipo (descomentar la que corresponda):
        //   ...Data Source=SOFI\SQLEXPRESS
        //   ...Data Source=JULAZARO\SQLEXPRESS
        //   ...Data Source=AgusPC
    }
}
