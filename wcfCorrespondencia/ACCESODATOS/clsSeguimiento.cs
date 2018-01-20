using FramNet.ClSDataBaseDestok;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACCESODATOS
{
    public class clsSeguimiento
    {
        private String strConexion;                                                                 //Almacena el String de conexion                                                               //Almacena el String de conexion
        private SqlConnection sqlConexion;                                                          //Almacena la conexion
        private SqlCommand sqlCommand;                                                              //Comando de la conexion
        private SqlDataAdapter sqlDataAdapter;                                                      //DataAdapter de la conexion
        private DataTable dtDatos = new DataTable();                                                //Carga los datos del sql
        private StringBuilder strSql;                                                               //Constructor de string de conexion
        private SqlConnectionStringBuilder[] strSqlConexion = new SqlConnectionStringBuilder[1];    //Arreglo de conexiones
        private clsTransaccion istTransaccion;

        public clsSeguimiento()
        {
            strConexion = "strConexionOrden";
            strSqlConexion[0] = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings[strConexion].ConnectionString);
            ClsFactoriaDAO.metTipoBD = "SQLSERVER";
            strConexion = System.Configuration.ConfigurationManager.ConnectionStrings[strConexion].ConnectionString;
        }
        //---------------------------------------------------------------------------------------
        // Procedure : insert
        // DateTime  : 22/12/2017
        // Author    : Cuso Cenfortec
        // Purpose   : Insertar los datos del seguimiento realizado por el analista
        // Parameter : pStrNumDocum: Contiene el numero del archivo a insertar
        //           : pStrRegistro: numero de registro al que pertenece el archivo
        //          : pStrArchivo: nombre del archivo a insertar
        //           : pStrCarpetaTrabajo: nombre del archivo a insertar de la carpeta de trabajo
        //          : pStrArchivosModifi: nombre del archivo a insertar en la base de datos de los modificados en el proyecto
        //          : pStrArchivosModiBD: nombre del archivo a insertar de los datos modificado en la base de datos.
        //          : pStrNumBoleta: Numero de boleta del seguimiento.
        //          : pStrFecha: Fecha en que se realizó la modificación del sistema.
        // Return    :
        // Notes     :
        //---------------------------------------------------------------------------------------
        public bool insertSeguimiento(string pStrNumDocum, string pStrRegistro, string pStrArchivo,
                         string pStrCodEmp, DateTime pDateHoraIni, DateTime pDateHoraFin,
                         string pStrAsist, string pStrComent, string pStrCarpetaTrabajo,
                         string pStrArchivosModifi, string pStrArchivosModiBD, string pStrVersion,
                         string pStrEstado, string pStrNumBoleta, DateTime pDateFecha,
                         string pStrCliRepre)
        {


            bool blnResult = false;
            bool blnRespuestaTran = true;


            try
            {
                istTransaccion = new clsTransaccion(strSqlConexion[0].DataSource, strSqlConexion[0].InitialCatalog, strSqlConexion[0].UserID, strSqlConexion[0].Password);

                string strNombreDoc; //nombre del archivo a agregar     
                DateTime datFecha;
                string strResultado; //Resultado del registro de los datos

                //Archivo = modPrincipal.leerArchivo(pStrArchivo)
                //    strNombreDoc = modPrincipal.fileSingleName(pStrArchivo)    'Toma solo el nombre del documento

                strSql = new StringBuilder();

                // inserta nuevos Datos a la BD

                //string a = datFecha.ToString("yyyyMMdd");


                strSql.Append("insert into COtblDocEmp");
                strSql.Append("(NumDocum,NumOrden,NombreDoc,CodigoEmp,HoraInicio,HoraFin,");
                strSql.Append("LugarAsistencia,Comentario,VersionFinal,Estado,FCIA43,FCIA44,");
                strSql.Append("CarpetaTrabajo,ArchivosModifi,ArchivosModiBD,NumBoleta,FechaMod,CliRepre) Values(");
                strSql.Append("'" + pStrNumDocum + "'");
                strSql.Append(",'" + pStrRegistro + "'");
                strSql.Append(",'" + pStrArchivo + "'");
                strSql.Append(",'" + pStrCodEmp + "'");
                strSql.Append(",'" + Convert.ToDateTime(pDateHoraIni.ToString()).ToString("yyyyMMdd hh:mm:ss").Trim()  + "'");
                strSql.Append(",'" + Convert.ToDateTime(pDateHoraFin.ToString()).ToString("yyyyMMdd hh:mm:ss").Trim()  + "'");
                strSql.Append(",'" + pStrAsist + "'");
                strSql.Append(",'" + pStrComent + "'");
                strSql.Append(",'" + pStrVersion + "'");
                strSql.Append(",'" + pStrEstado + "'");
                strSql.Append(",'PRUEBA'");
                strSql.Append(",'" + Convert.ToDateTime(DateTime.Now.ToString()).ToString("yyyyMMdd").Trim() + "'");
                strSql.Append(",'" + pStrCarpetaTrabajo + "'");
                strSql.Append(",'" + pStrArchivosModifi + "'");
                strSql.Append(",'" + pStrArchivosModiBD + "'");
                strSql.Append(",'" + pStrNumBoleta + "'");
                strSql.Append(",'" + Convert.ToDateTime(pDateFecha.ToString()).ToString("yyyyMMdd").Trim() + "'");
                strSql.Append(",'" + pStrCliRepre + "' )");
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

