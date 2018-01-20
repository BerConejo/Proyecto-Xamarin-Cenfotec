using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using FramNet.ClSDataBaseDestok;
using System.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ACCESODATOS
{
    public class clsUsuario
    {

        #region Variables

        private String strConexion;                                                                 //Almacena el String de conexion
        private SqlConnection sqlConexion;                                                          //Almacena la conexion
        private SqlCommand sqlCommand;                                                              //Comando de la conexion
        private SqlDataAdapter sqlDataAdapter;                                                      //DataAdapter de la conexion
        private DataTable dtDatos = new DataTable();                                                //Carga los datos del sql
        private StringBuilder strSql;                                                               //Constructor de string de conexion
        private SqlConnectionStringBuilder[] strSqlConexion = new SqlConnectionStringBuilder[1];    //Arreglo de conexiones

        #endregion Variables

        #region Constructor
        public clsUsuario()
        {
            strConexion = "strConexionCuenta";
            strSqlConexion[0] = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[strConexion].ConnectionString);
            ClsFactoriaDAO.metTipoBD = "SQLSERVER";
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings[strConexion].ConnectionString;
        }

        #endregion Constructor

        #region Miembros del contrato

        [DataMember]
        public string Usuario { get; set; }
        public string Password { get; set; }

        #endregion Miembros del contrato

        #region Metodos

        /// <summary>
        /// Procedure : validarUsuario
        /// Autor     : bbogantes
        /// Date      : 18/12/2017
        /// Purpose   : Metodo que recibe como parametro el usuario, codigo para validar que el usuario tenga acceso a la app.
        /// Return    : True si el usuario posee acceso, y False si no posee acceso.
        /// Modified  : 
        /// </summary>
        /// <param name="pStrUsuario">Recibe un string con el usuario que ingresa a la app</param>
        /// <param name="pStrCodigo">Recibe un string con el codigo de seguridad</param>
        public string validarUsuario(string pStrUsuario, string pStrCodigo)
        {
            try
            {
                List<clsUsuario> lstUsuario = new List<clsUsuario>();
                clsUsuario miUsuario = new clsUsuario();


                strSql = new StringBuilder();
                strSql.Append("Select UD.Login, U.Clave ");
                strSql.Append("From tblUsuarios U, tblUsuarioDetalle UD ");
                strSql.Append("Where U.Login = '" + pStrUsuario + "' ");
                strSql.Append("And U.Clave = '" + pStrCodigo + "' ");
                strSql.Append("And U.Login = UD.Login ");
                strSql.Append("And UD.CodGrupo in('02','03','04')");

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

                if (dtDatos != null && dtDatos.Rows.Count > 0)
                {
                    for (int i = 0; i < dtDatos.Rows.Count; i++)
                    {
                        miUsuario.Usuario = dtDatos.Rows[i]["Login"].ToString();
                        miUsuario.Password = dtDatos.Rows[i]["Clave"].ToString();
                        lstUsuario.Add(miUsuario);
                    }
                    return JsonConvert.SerializeObject(lstUsuario);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        #endregion Metodos
    }
}