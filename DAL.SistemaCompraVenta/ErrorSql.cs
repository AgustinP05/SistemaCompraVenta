using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    // Traduce los códigos de error de SQL Server. Centraliza acá (en la DAL) el
    // conocimiento del motor para que las capas superiores no tengan que conocer
    // SqlException ni números mágicos como 547 / 2627.
    internal static class ErrorSql
    {
        private const int ViolacionFK        = 547;          // FOREIGN KEY constraint
        private const int ViolacionUniqueIdx = 2601;         // unique index
        private const int ViolacionUniqueKey = 2627;         // PK / UNIQUE constraint

        // ¿El error es por una FK? (ej.: borrar algo referenciado por otra tabla).
        public static bool EsViolacionFK(SqlException ex) => ex.Number == ViolacionFK;

        // ¿El error es por una clave única / PK duplicada?
        public static bool EsViolacionUnica(SqlException ex) =>
            ex.Number == ViolacionUniqueKey || ex.Number == ViolacionUniqueIdx;
    }
}
