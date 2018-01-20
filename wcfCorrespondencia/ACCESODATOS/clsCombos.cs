using FramNet.ClSDataBaseDestok;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ACCESODATOS
{
    public class clsCombos
    {
        private String strConexion;                                                                 //Almacena el String de conexion                                                               //Almacena el String de conexion
        private SqlConnection sqlConexion;                                                          //Almacena la conexion
        private SqlCommand sqlCommand;                                                              //Comando de la conexion
        private SqlDataAdapter sqlDataAdapter;                                                      //DataAdapter de la conexion
        private DataTable dtDatos = new DataTable();                                                //Carga los datos del sql
        private StringBuilder strSql;                                                               //Constructor de string de conexion
        private SqlConnectionStringBuilder[] strSqlConexion = new SqlConnectionStringBuilder[1];    //Arreglo de conexiones

        public clsCombos()
        {
            strConexion = "strConexionOrden";
            strSqlConexion[0] = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[strConexion].ConnectionString);
            ClsFactoriaDAO.metTipoBD = "SQLSERVER";
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings[strConexion].ConnectionString;
        }


        #region Miembros del contrato

        [DataMember]
        public string DESCRIPCION { get; set; }

        #endregion

        //'---------------------------------------------------------------------------------------
        //' Procedure : findByPrimary
        //' DateTime  : 22/12/2017
        //' Author    : Curso Cenfotec
        //' Purpose   : Devolver la lista con los datos requeridos
        //' Parameter : pStrIdGeneral: Codigo general
        //'           : pStrEspecifico: Codigo especifico
        //' Return    : "True": si existe el registro o un mensaje de error si no existe
        //' Notes     :
        //'---------------------------------------------------------------------------------------
        public List<clsCombos> findByPrimary(string pStrIdGeneral, string pStrEspecifico)
        {
            try
            {

                List<clsCombos> lstFindByPrimary = new List<clsCombos>();//Lista que se retorna con los datos del usuario
                strSql = new StringBuilder();

                strSql.Append("select Descripcion from COtblCodigos where NumGeneral='" + pStrIdGeneral + "'");
                strSql.Append(" and NumEspecifico <> '000' ");

                if (string.IsNullOrEmpty(pStrEspecifico))
                {
                    pStrEspecifico = "";
                }
                else
                {
                    strSql.Append("and NumEspecifico='" + pStrEspecifico + "'");
                }

                lstFindByPrimary.Clear();

                using (sqlConexion = new SqlConnection(strConexion))
                {
                    //Verifica si la conexion esta abierta
                    if (sqlConexion.State == ConnectionState.Closed)
                    {
                        sqlConexion.Open();//Abre la conexion
                    }
                    sqlCommand = new SqlCommand(" " + strSql + " ", sqlConexion);
                    sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    dtDatos.Clear();
                    sqlDataAdapter.Fill(dtDatos);
                    sqlConexion.Close();
                }

                if (dtDatos == null) return null;

                for (int i = 0; i < dtDatos.Rows.Count; i++)
                {
                    clsCombos miCombo = new clsCombos();
                    miCombo.DESCRIPCION = dtDatos.Rows[i]["DESCRIPCION"].ToString();
                    lstFindByPrimary.Add(miCombo);
                }
                return lstFindByPrimary;
            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}