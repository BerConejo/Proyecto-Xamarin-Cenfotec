using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using ACCESODATOS;

namespace wcfCorrespondencia
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class Service1 : IService1
    {
        clsUsuario instClsUsuario = new clsUsuario();
        clsOrden instClsOrden = new clsOrden();
        clsSeguimiento instClsSeguimiento = new clsSeguimiento();
        clsPrograma instClsLista = new clsPrograma();
        clsCombos instClsCombo = new clsCombos();

        public string validarUsuario(string pStrUsuario, string pStrCodigo)
        {
            return instClsUsuario.validarUsuario(pStrUsuario, pStrCodigo);
        }

        public string obtenerOrden(string pStrOrden)
        {
            return instClsOrden.obtenerOrden(pStrOrden);
        }

        public bool borrarOrden(string pStrOrden)
        {
            return instClsOrden.borrarOrden(pStrOrden);
        }

        public bool insertOrden(string pStrOrden, DateTime pDateFchOrden, string pStrCodCliente, string pStrTipoDoc, string pStrAsunto,
            string pStrTipoRecep, string pStrTipoServicio, string pStrTipoOrden, string pStrSistema, string pStrTipoAjuste,
            string pStrAsigna, string pStrTiempoLimite, string pStrNoOrdClie, string pStrChequeado)
        {


            return instClsOrden.insertOrden(pStrOrden, pDateFchOrden,
                                            pStrCodCliente, pStrTipoDoc,
                                            pStrAsunto, pStrTipoRecep,
                                            pStrTipoServicio, pStrTipoOrden,
                                            pStrSistema, pStrTipoAjuste,
                                            pStrAsigna, pStrTiempoLimite,
                                            pStrNoOrdClie, pStrChequeado);
        }


        public bool insertSeguimiento(string pStrNumDocum, string pStrRegistro, string pStrArchivo, string pStrCodEmp, DateTime pDateHoraIni,
            DateTime pDateHoraFin, string pStrAsist, string pStrComent, string pStrCarpetaTrabajo, string pStrArchivosModifi, string pStrArchivosModiBD,
            string pStrVersion, string pStrEstado, string pStrNumBoleta, DateTime pDateFecha, string pStrCliRepre)
        {


            pStrNumDocum = "1";
            pStrRegistro = "00005166";
            pStrArchivo = "ABCD";
            pStrCodEmp = "000011";
            pStrAsist = "01";
            pStrComent = "prueba1";
            pStrCarpetaTrabajo = "bbogantes";
            pStrArchivosModifi = "asd";
            pStrArchivosModiBD = "adasda";
            pStrVersion = "7.0.31";
            pStrEstado = "04";
            pStrNumBoleta = "";
            pStrCliRepre = "";

            return instClsSeguimiento.insertSeguimiento(pStrNumDocum, pStrRegistro, pStrArchivo,
                                                        pStrCodEmp, pDateHoraIni, pDateHoraFin,
                                                        pStrAsist, pStrComent, pStrCarpetaTrabajo,
                                                        pStrArchivosModifi, pStrArchivosModiBD, pStrVersion,
                                                        pStrEstado, pStrNumBoleta, pDateFecha,
                                                        pStrCliRepre);
        }

        public List<clsPrograma> findAll()
        {
            return instClsLista.findAll();
        }

        public List<clsCombos> findByPrimary(string pStrIdGeneral, string pStrEspecifico)
        {
            return instClsCombo.findByPrimary(pStrIdGeneral, pStrEspecifico);
        }


    }
}
