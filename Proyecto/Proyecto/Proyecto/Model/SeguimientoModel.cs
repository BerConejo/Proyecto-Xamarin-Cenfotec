using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Model
{
    public class SeguimientoModel
    {
        public static bool GuardarSeguimiento(string pStrNumBoleta, string pStrAnalista, string pStrLugarAsistencia, string pStrObservaciones, string pStrCarpetaTrabajo,
               string pStrArchivosModificados, string pStrCamposModificados, string pStrVersion, string pStrEstadoOrden, string pStrOrdenTransferida,
               DateTime pDataFecha, DateTime pDataHoraInicio, DateTime pDataHoraFin)
        {
            try
            {
                Service1Client cliente = Conexion.Cliente();
                //DateTime horaIni = Convert.ToDateTime(pDataHoraInicio);
                //DateTime horafin = Convert.ToDateTime(pDataHoraFin);

                return cliente.insertSeguimiento("1", pStrNumBoleta, "", pStrAnalista, pDataHoraInicio, pDataHoraFin, pStrLugarAsistencia, pStrObservaciones,
                    pStrCarpetaTrabajo, pStrArchivosModificados, pStrCamposModificados, pStrVersion, pStrEstadoOrden, "", pDataFecha, "");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
