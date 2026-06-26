using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    // Única responsabilidad: fabricar SqlParameter.
    public static class ParametroSql
    {
        // Genérico: si el valor es null (o DBNull), lo manda como DBNull para SQL.
        public static SqlParameter Crear(string nombre, object valor)
        {
            return new SqlParameter
            {
                ParameterName = nombre,
                Value = valor ?? DBNull.Value
            };
        }

        public static SqlParameter Crear(string nombre, string valor)
        {
            return new SqlParameter { ParameterName = nombre, Value = valor, DbType = DbType.String };
        }

        public static SqlParameter Crear(string nombre, int valor)
        {
            return new SqlParameter { ParameterName = nombre, Value = valor, DbType = DbType.Int32 };
        }

        public static SqlParameter Crear(string nombre, double valor)
        {
            return new SqlParameter { ParameterName = nombre, Value = valor, DbType = DbType.Double };
        }

        public static SqlParameter Crear(string nombre, DateTime valor)
        {
            return new SqlParameter { ParameterName = nombre, Value = valor, DbType = DbType.DateTime };
        }
    }
}
