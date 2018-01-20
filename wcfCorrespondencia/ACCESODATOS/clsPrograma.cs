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
    public class clsPrograma
    {

        private String strConexion;                                                                 //Almacena el String de conexion                                                               //Almacena el String de conexion
        private SqlConnection sqlConexion;                                                          //Almacena la conexion
        private SqlCommand sqlCommand;                                                              //Comando de la conexion
        private SqlDataAdapter sqlDataAdapter;                                                      //DataAdapter de la conexion
        private DataTable dtDatos = new DataTable();                                                //Carga los datos del sql
        private StringBuilder strSql;                                                               //Constructor de string de conexion
        private SqlConnectionStringBuilder[] strSqlConexion = new SqlConnectionStringBuilder[1];    //Arreglo de conexiones

        public clsPrograma()
        {
            strConexion = "strConexionCuenta";
            strSqlConexion[0] = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[strConexion].ConnectionString);
            ClsFactoriaDAO.metTipoBD = "SQLSERVER";
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings[strConexion].ConnectionString;
        }


        #region Miembros del contrato
        [DataMember]
        public string CODPROGRAMA { get; set; }
        [DataMember]
        public string NOMBREPROGRAMA { get; set; }

        #endregion


        //' DateTime  : 22/12/2017
        //' Author    : Curso Cenfotec
        //' Purpose   : Obtener la lista de programas de la base de datos
        //' Return    : 
        //' Notes     :
        //'---------------------------------------------------------------------------------------

        public List<clsPrograma> findAll()
        {

            try
            {

                List<clsPrograma> lstfindAll = new List<clsPrograma>();//Lista que se retorna con los datos del usuario
                strSql = new StringBuilder();
                strSql.Append("Select  CodPrograma, NombrePrograma ");
                strSql.Append(" From tblProgramas ");
                strSql.Append(" order by NombrePrograma ");

                lstfindAll.Clear();

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
                    clsPrograma miLista = new clsPrograma();
                    miLista.CODPROGRAMA = dtDatos.Rows[i]["CodPrograma"].ToString();
                    miLista.NOMBREPROGRAMA = dtDatos.Rows[i]["NombrePrograma"].ToString();
                    lstfindAll.Add(miLista);
                }
                return lstfindAll;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
