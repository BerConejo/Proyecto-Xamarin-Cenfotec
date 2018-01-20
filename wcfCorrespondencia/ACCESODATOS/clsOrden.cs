using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FramNet.ClSDataBaseDestok;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace ACCESODATOS
{

    public class clsOrden
    {

        #region Variables
        private String strConexion;                                                                 //Almacena el String de conexion
        private SqlConnection sqlConexion;                                                          //Almacena la conexion
        private SqlCommand sqlCommand;                                                              //Comando de la conexion
        private SqlDataAdapter sqlDataAdapter;                                                      //DataAdapter de la conexion
        private DataTable dtDatos = new DataTable();                                                //Carga los datos del sql
        private StringBuilder strSql;                                                               //Constructor de string de conexion
        private SqlConnectionStringBuilder[] strSqlConexion = new SqlConnectionStringBuilder[1];    //Arreglo de conexiones
        private clsTransaccion istTransaccion;

        #endregion Variables

        #region Miembros del contrato

        [DataMember]
        public string NumOrden { get; set; }

        [DataMember]
        public DateTime FechaOrden { get; set; }

        [DataMember]
        public string CodCliente { get; set; }

        [DataMember]
        public string TipoDocum { get; set; }

        [DataMember]
        public string Asunto { get; set; }

        [DataMember]
        public string TipoRecep { get; set; }

        [DataMember]
        public string TipoServicio { get; set; }

        [DataMember]
        public string TipoOrden { get; set; }

        [DataMember]
        public string Sistema { get; set; }

        [DataMember]
        public string TipoAjuste { get; set; }

        [DataMember]
        public string AsignaOrden { get; set; }

        [DataMember]
        public string NoOrdCliente { get; set; }

        #endregion Miembros del contrato

        public clsOrden()
        {
            strConexion = "strConexionOrden";
            strSqlConexion[0] = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[strConexion].ConnectionString);
            ClsFactoriaDAO.metTipoBD = "SQLSERVER";
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings[strConexion].ConnectionString;
        }
        //---------------------------------------------------------------------------------------
        /// Procedure : insertOrden.
        /// DateTime  : 22/12/2017 09:26
        /// Author    : Curso Cenfotec
        /// Purpose   : Insertar los datos de la orden que solicita el cliente
        /// Parameter : pStrOrden. Numero de Orden,pStrFchOrden Fecha de la orden
        ///           : pStrCodCliente. Codigo del cliente, pStrTipoDoc Tipo de documento
        ///           : pStrAsunto. Asunto por el el cual se realizo la orden, Tipo de Recepcion
        ///           : pStrTipoServicio. Tipo de servicio brindador,pStrTipoOrden Tipo de orden
        ///           : pStrSistema. Sistema al que pertenece la orden,Tipo de Ajuste requerido
        ///           :  pStrAsigna. Analista que asigna la orden,Tiempo Limite para resolver la orden
        ///           : pStrNoOrdClie. Numero de orden del cliente, pStrChequeado. Indica si fue chequeada a ono
        //' Return    :
        //' Notes     :
        //'---------------------------------------------------------------------------------------
        public bool insertOrden(string pStrOrden, DateTime pDateFchOrden, 
                 string pStrCodCliente, string pStrTipoDoc, 
                string pStrAsunto, string pStrTipoRecep, 
                string pStrTipoServicio, string pStrTipoOrden, 
                string pStrSistema, string pStrTipoAjuste, 
                string pStrAsigna, string pStrTiempoLimite,
                string pStrNoOrdClie, string pStrChequeado)
        {

            bool blnResult = false;
            bool blnRespuestaTran = true;

            try
            {

                istTransaccion = new clsTransaccion(strSqlConexion[0].DataSource, strSqlConexion[0].InitialCatalog, strSqlConexion[0].UserID, strSqlConexion[0].Password);
                //' inserta nuevos Datos a la BD
                strSql = new StringBuilder();

                strSql.Append("INSERT INTO COtblOrden( ");
                strSql.Append("NumOrden");
                strSql.Append(",FechaOrden");
                strSql.Append(",CodCliente");
                strSql.Append(",TipoDocum");
                strSql.Append(",Asunto");
                strSql.Append(",TipoRecep");
                strSql.Append(",TipoServicio");
                strSql.Append(",TipoOrden");
                strSql.Append(",Sistema");
                strSql.Append(",TipoAjuste");
                strSql.Append(",AsignaOrden");
                strSql.Append(",FCIA43,tiemLimite");
                strSql.Append(",NoOrdCliente");
                strSql.Append(",Chequeado");
                strSql.Append(")VALUES(");
                strSql.Append("'" + pStrOrden + "'");
                strSql.Append(",'" + Convert.ToDateTime(pDateFchOrden.ToString()).ToString("yyyyMMdd").Trim() + "'");
                strSql.Append(",'" + pStrCodCliente + "'");
                strSql.Append(",'" + pStrTipoDoc + "'");
                strSql.Append(",'" + pStrAsunto + "'");
                strSql.Append(",'" + pStrTipoRecep + "'");
                strSql.Append(",'" + pStrTipoServicio + "'");
                strSql.Append(",'" + pStrTipoOrden + "'");
                strSql.Append(",'" + pStrSistema + "'");
                strSql.Append(",'" + pStrTipoAjuste + "'");
                strSql.Append(",'" + pStrAsigna + "'");
                strSql.Append(",'PRUEBA'");
                strSql.Append(",'" + pStrTiempoLimite + "'");
                strSql.Append(",'" + pStrNoOrdClie + "'");
                strSql.Append(",'" + pStrChequeado + "'");
                strSql.Append(")");

                blnRespuestaTran = ClsFactoriaDAO.metGetConexion().metEjecutarSQLTransac(strSql.ToString());
                if (blnRespuestaTran)
                {
                    throw new System.ArgumentException("Error", "Error");
                }

                ClsFactoriaDAO.metGetConexion().metCommit();
                blnResult = true;
            }
            catch (Exception)
            {
                //Si sucede algún problema no se guarda nada en la BD. 
                ClsFactoriaDAO.metGetConexion().metRollback();
                blnResult = false;
            }

            return blnResult;

        }


        /// <summary>
        /// Obtiene todas las ordenes, de la mas nueva a la mas antigua
        /// </summary>
        /// <returns>un json con la informacion de las ordenes</returns>
        public string obtenerOrden(string pStrOrden)
        {
            List<clsOrden> lstOrden = new List<clsOrden>();
            try
            {
                strSql = new StringBuilder();
                strSql.Append("Select * From COtblOrden ");
                strSql.Append("WHERE NumOrden = '" + pStrOrden + "'");


                using (sqlConexion = new SqlConnection(strConexion))
                {
                    if (sqlConexion.State == ConnectionState.Closed)
                    {
                        sqlConexion.Open();
                    }
                    sqlCommand = new SqlCommand(" " + strSql + " ", sqlConexion);
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    dtDatos.Clear();
                    sqlDataAdapter.Fill(dtDatos);
                    sqlConexion.Close();
                }

                if (dtDatos != null)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        clsOrden miOrden = new clsOrden();

                        miOrden.NumOrden = dtDatos.Rows[i]["NumOrden"].ToString();
                        miOrden.FechaOrden = Convert.ToDateTime(dtDatos.Rows[i]["FechaOrden"].ToString());
                        miOrden.CodCliente = dtDatos.Rows[i]["CodCliente"].ToString();
                        miOrden.TipoDocum = dtDatos.Rows[i]["TipoDocum"].ToString();
                        miOrden.Asunto = dtDatos.Rows[i]["Asunto"].ToString();
                        miOrden.TipoRecep = dtDatos.Rows[i]["TipoRecep"].ToString();
                        miOrden.TipoServicio = dtDatos.Rows[i]["TipoServicio"].ToString();
                        miOrden.TipoOrden = dtDatos.Rows[i]["TipoOrden"].ToString();
                        miOrden.Sistema = dtDatos.Rows[i]["Sistema"].ToString();
                        miOrden.TipoAjuste = dtDatos.Rows[i]["TipoAjuste"].ToString();
                        miOrden.AsignaOrden = dtDatos.Rows[i]["AsignaOrden"].ToString();
                        miOrden.NoOrdCliente = dtDatos.Rows[i]["NoOrdCliente"].ToString();

                        lstOrden.Add(miOrden);
                    }

                    return JsonConvert.SerializeObject(lstOrden);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "";
            }
        }



        public bool borrarOrden(string pStrOrden)
        {

            bool blnResult = false;
            bool blnRespuestaTran = true;

            try
            {

                istTransaccion = new clsTransaccion(strSqlConexion[0].DataSource, strSqlConexion[0].InitialCatalog, strSqlConexion[0].UserID, strSqlConexion[0].Password);
                //' inserta nuevos Datos a la BD
                strSql = new StringBuilder();
                strSql.Append("DELETE FROM COtblOrden ");
                strSql.Append("WHERE NumOrden = '" + pStrOrden + "'");


                blnRespuestaTran = ClsFactoriaDAO.metGetConexion().metEjecutarSQLTransac(strSql.ToString());
                if (blnRespuestaTran)
                {
                    throw new System.ArgumentException("Error", "Error");
                }

                ClsFactoriaDAO.metGetConexion().metCommit();
                blnResult = true;
            }
            catch (Exception)
            {
                //Si sucede algún problema no se guarda nada en la BD. 
                ClsFactoriaDAO.metGetConexion().metRollback();
                blnResult = false;
            }

            return blnResult;

        }

    }
}
