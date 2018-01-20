using ACCESODATOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace wcfCorrespondencia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string validarUsuario(string pStrUsuario, string pStrCodigo);

        [OperationContract]
        string obtenerOrden(string pStrOrden);

        [OperationContract]
        bool insertOrden(string pStrOrden, DateTime pDateFchOrden,
                    string pStrCodCliente, string pStrTipoDoc,
                    string pStrAsunto, string pStrTipoRecep,
                    string pStrTipoServicio, string pStrTipoOrden,
                    string pStrSistema, string pStrTipoAjuste,
                    string pStrAsigna, string pStrTiempoLimite,
                    string pStrNoOrdClie, string pStrChequeado);

        [OperationContract]
        bool borrarOrden(string pStrOrden);

        [OperationContract]
        bool insertSeguimiento(string pStrNumDocum, string pStrRegistro, string pStrArchivo,
                         string pStrCodEmp, DateTime pDateHoraIni, DateTime pDateHoraFin,
                         string pStrAsist, string pStrComent, string pStrCarpetaTrabajo,
                         string pStrArchivosModifi, string pStrArchivosModiBD, string pStrVersion,
                         string pStrEstado, string pStrNumBoleta, DateTime pDateFecha,
                         string pStrCliRepre);

        [OperationContract]
        List<clsPrograma> findAll();

        [OperationContract]
        List<clsCombos> findByPrimary(string pStrIdGeneral, string pStrEspecifico);



    }
}
