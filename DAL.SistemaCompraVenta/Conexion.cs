using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Incorporo el espacio de nombre System.Data.SqlClient
using System.Data.SqlClient;
using System.Data;

namespace DAL.SistemaCompraVenta
{
    public class Conexion
    {
        private SqlConnection objConexion;
        private SqlTransaction objTransaccion;
        private bool enTransaccion = false;
        private string strCadenaDeConexion = "";

        private void AsignarCadena()
        {
            //strCadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaCompraVenta;Data Source=AgusPC";
            //cadena de compu sofi,
            //strCadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaCompraVenta;Data Source=SOFI\SQLEXPRESS";
            //cadena de compu agos,
            strCadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaCompraVenta;Data Source=DESKTOP-31EJQH0\SQLEXPRESS";
            //cadena de compu Juli,
            //strCadenaDeConexion = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SistemaCompraVenta;Data Source=JULAZARO\SQLEXPRESS";
        }

        /* -------------------- private void Conectar() ------------
         * Abre la conexión con la base. Si hay una transacción en curso, no abre
         * una nueva: reutiliza la conexión ya abierta por IniciarTransaccion().
         */
        private void Conectar()
        {
            if (enTransaccion) return;
            AsignarCadena();
            objConexion = new SqlConnection();
            objConexion.ConnectionString = strCadenaDeConexion;
            objConexion.Open();
        }

        /* -------------------- private void Desconectar() ------------
         * Cierra la conexión. Durante una transacción NO cierra: la conexión
         * debe seguir viva hasta el Confirmar()/Revertir().
         */
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
            AsignarCadena();
            objConexion = new SqlConnection();
            objConexion.ConnectionString = strCadenaDeConexion;
            objConexion.Open();
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
            //Instancio un objeto del tipo DataTable
            var unaTabla = new DataTable();

            //Instancio un objeto del tipo SqlCommand
            var objComando = new SqlCommand();

            //Me conecto...
            this.Conectar();


            try
            {
                objComando.CommandText = pNombreStoreProcedure;
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = this.objConexion;
                if (enTransaccion) objComando.Transaction = objTransaccion;

                if (pParametrosSql != null)
                {
                    //Lleno los SqlParameters a la lista de parametros
                    objComando.Parameters.AddRange(pParametrosSql);
                }

                //Instancio un adaptador con el parametro SqlCommand
                var objAdaptador = new SqlDataAdapter(objComando);

                //Lleno la tabla, el objeto unaTabla con el adaptador
                objAdaptador.Fill(unaTabla);
            }
            catch (Exception)
            {
                //Como hay error... por el motivo que sea asigno el resultado a null
                unaTabla = null;

                throw;
            }
            finally
            {

                //Pase lo que pase me desconecto
                this.Desconectar();
            }


            return unaTabla;
        }

        public SqlParameter crearParametro(string pNombre, object pValor)
        {
            SqlParameter objParametro = new SqlParameter();
            objParametro.ParameterName = pNombre;

            // Si el valor es nulo (o DBNull), lo asignamos correctamente para SQL
            if (pValor == null)
            {
                objParametro.Value = DBNull.Value;
            }
            else
            {
                objParametro.Value = pValor;
            }

            return objParametro;
        }
        public int EscribirPorStoreProcedure(string pTexto, SqlParameter[] pParametrosSql)
        {
            //Instanció una variable filasAfectadas que va a terminar devolviendo la cantidad de filas afectadas.
            int filasAfectadas = 0;

            //Instancio un objeto del tipo SqlCommand
            var objComando = new SqlCommand();

            //Me conecto...
            this.Conectar();

            try
            {
                objComando.CommandText = pTexto;
                objComando.CommandType = CommandType.StoredProcedure;
                objComando.Connection = this.objConexion;
                if (enTransaccion) objComando.Transaction = objTransaccion;

                if (pParametrosSql.Length > 0)
                {
                    objComando.Parameters.AddRange(pParametrosSql);
                    //El método ExecuteNonQuery() me devuelve la cantidad de filas afectadas.
                    filasAfectadas = objComando.ExecuteNonQuery();
                }
                else
                {
                    //retorno -1 porque la lista de parametros Sql tiene 0 ítems...
                    filasAfectadas = -1;
                }



            }
            catch (Exception)
            {
                filasAfectadas = -1;
                throw;
            }
            finally
            {
                //Me desconecto
                this.Desconectar();
            }


            return filasAfectadas;
        }

        #region Parametros
        public SqlParameter crearParametro(string pNombre, string pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.String;

            return objParametro;
        }



        public SqlParameter crearParametro(string pNombre, double pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.Double;

            return objParametro;
        }


        public SqlParameter crearParametro(string pNombre, DateTime pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.DateTime;

            return objParametro;
        }


        public SqlParameter crearParametro(string pNombre, int pValor)
        {

            SqlParameter objParametro = new SqlParameter();

            objParametro.ParameterName = pNombre;
            objParametro.Value = pValor;
            objParametro.DbType = DbType.Int32;

            return objParametro;
        }


        #endregion


    }
}
