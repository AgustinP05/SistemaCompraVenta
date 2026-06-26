using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    // Única responsabilidad: ejecutar acceso a datos (correr stored procedures) y
    // orquestar la transacción. NO sabe de dónde sale la cadena (ConfiguracionBD),
    // ni cómo se abre una conexión (FabricaConexion), ni cómo se fabrican los
    // parámetros (ParametroSql).
    public class Conexion
    {
        private readonly FabricaConexion fabrica = new FabricaConexion();
        private SqlConnection objConexion;
        private SqlTransaction objTransaccion;
        private bool enTransaccion = false;

        // Abre la conexión. Si hay una transacción en curso, reutiliza la conexión ya abierta por IniciarTransaccion().
        private void Conectar()
        {
            if (enTransaccion) return;
            objConexion = fabrica.CrearAbierta();
        }

        // Cierra la conexión. Durante una transacción NO cierra: debe seguir viva
        // hasta el Confirmar()/Revertir().
        private void Desconectar()
        {
            if (enTransaccion) return;
            objConexion.Close();
            objConexion.Dispose();
        }

        /* -------------------- Transacciones ------------
         * Agrupan varias operaciones en un "todo o nada": si alguna falla se
         * revierten todas. Uso: IniciarTransaccion(); ...varios SP...; Confirmar();
         * y en el catch, Revertir();
         */
        public void IniciarTransaccion()
        {
            objConexion = fabrica.CrearAbierta();
            objTransaccion = objConexion.BeginTransaction();
            enTransaccion = true;
        }

        public void Confirmar()
        {
            try { objTransaccion?.Commit(); }
            finally { CerrarTransaccion(); }
        }

        public void Revertir()
        {
            try { objTransaccion?.Rollback(); }
            finally { CerrarTransaccion(); }
        }

        private void CerrarTransaccion()
        {
            enTransaccion = false;
            if (objTransaccion != null) { objTransaccion.Dispose(); objTransaccion = null; }
            if (objConexion != null) { objConexion.Close(); objConexion.Dispose(); }
        }

        public DataTable LeerPorStoreProcedure(string pNombreStoreProcedure, SqlParameter[] pParametrosSql = null)
        {
            var unaTabla = new DataTable();
            var objComando = new SqlCommand();

            this.Conectar();
            try
            {
                objComando.CommandText = pNombreStoreProcedure;
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = this.objConexion;
                if (enTransaccion) objComando.Transaction = objTransaccion;

                if (pParametrosSql != null)
                    objComando.Parameters.AddRange(pParametrosSql);

                var objAdaptador = new SqlDataAdapter(objComando);
                objAdaptador.Fill(unaTabla);
            }
            catch (Exception)
            {
                unaTabla = null;
                throw;
            }
            finally
            {
                this.Desconectar();
            }

            return unaTabla;
        }

        public int EscribirPorStoreProcedure(string pTexto, SqlParameter[] pParametrosSql)
        {
            int filasAfectadas = 0;
            var objComando = new SqlCommand();

            this.Conectar();
            try
            {
                objComando.CommandText = pTexto;
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = this.objConexion;
                if (enTransaccion) objComando.Transaction = objTransaccion;

                // Agregar parámetros es opcional (un SP de escritura puede no tenerlos);
                // ejecutar el SP NO lo es: va siempre, afuera del if.
                if (pParametrosSql != null && pParametrosSql.Length > 0)
                    objComando.Parameters.AddRange(pParametrosSql);

                filasAfectadas = objComando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                filasAfectadas = -1;
                throw;
            }
            finally
            {
                this.Desconectar();
            }

            return filasAfectadas;
        }
    }
}
