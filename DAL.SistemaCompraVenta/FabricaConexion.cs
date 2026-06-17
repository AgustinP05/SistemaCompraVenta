using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    // Única responsabilidad: crear y abrir conexiones (usando la configuración).
    // Conexion ya no sabe CÓMO se construye/abre una conexión ni de dónde sale la cadena.
    internal class FabricaConexion
    {
        public SqlConnection CrearAbierta()
        {
            SqlConnection conexion = new SqlConnection(ConfiguracionBD.CadenaConexion);
            conexion.Open();
            return conexion;
        }
    }
}
