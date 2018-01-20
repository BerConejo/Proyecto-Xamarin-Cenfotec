using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto.Model
{
    public class OrdenModel
    {

        #region Miembros del contrato

        public string NumOrden { get; set; }
        public DateTime FechaOrden { get; set; }
        public string CodCliente { get; set; }
        public string TipoDocum { get; set; }
        public string Asunto { get; set; }
        public string TipoRecep { get; set; }
        public string TipoServicio { get; set; }
        public string TipoOrden { get; set; }
        public string Sistema { get; set; }
        public string TipoAjuste { get; set; }
        public string AsignaOrden { get; set; }
        public string NoOrdCliente { get; set; }

        #endregion Miembros del contrato

        public static List<OrdenModel> ObtenerOrdenes(string pStrNumOrden)
        {
            string strJson = string.Empty;
            List<OrdenModel> lstOrden = new List<OrdenModel>();
            OrdenModel miOrden = new OrdenModel();

            try
            {
                Service1Client cliente = Conexion.Cliente();
                strJson = cliente.obtenerOrden(pStrNumOrden);

                if (!string.IsNullOrEmpty(strJson) || strJson == "[]")
                {
                    JArray jArray = JArray.Parse(strJson);
                    for (int i = 0; i < jArray.Count; i++)
                    {
                        miOrden = new OrdenModel();

                        miOrden.NumOrden = jArray[i]["NumOrden"].ToString();
                        miOrden.FechaOrden = Convert.ToDateTime(jArray[i]["FechaOrden"].ToString());
                        miOrden.CodCliente = jArray[i]["CodCliente"].ToString();
                        miOrden.TipoDocum = jArray[i]["TipoDocum"].ToString();
                        miOrden.Asunto = jArray[i]["Asunto"].ToString();
                        miOrden.TipoRecep = jArray[i]["TipoRecep"].ToString();
                        miOrden.TipoServicio = jArray[i]["TipoServicio"].ToString();
                        miOrden.TipoOrden = jArray[i]["TipoOrden"].ToString();
                        miOrden.Sistema = jArray[i]["Sistema"].ToString();
                        miOrden.TipoAjuste = jArray[i]["TipoAjuste"].ToString();
                        miOrden.AsignaOrden = jArray[i]["AsignaOrden"].ToString();
                        miOrden.NoOrdCliente = jArray[i]["NoOrdCliente"].ToString();


                        lstOrden.Add(miOrden);
                    }

                    return lstOrden;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public static bool GuardarOrden(string pstrNumeroOrden, DateTime pDateFecha, string pStrCliente, string pStrTipoDocumento,
            string pStrAsunto, string pStrTipoRecepcion, string pStrTipoServicio, string pStrTipoOrden, string pStrTipoSistema, string pStrTipoAjuste)
        {
            try
            {
                Service1Client cliente = Conexion.Cliente();
                return cliente.insertOrden(pstrNumeroOrden, pDateFecha, pStrCliente, Convert.ToString(pStrTipoDocumento), pStrAsunto
                , Convert.ToString(pStrTipoRecepcion), Convert.ToString(pStrTipoServicio), Convert.ToString(pStrTipoOrden), Convert.ToString(pStrTipoSistema),
                Convert.ToString(pStrTipoAjuste), "000011", "", "", "N");
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool borrarOrden(string pStrOrden)
        {
            try
            {
                Service1Client cliente = Conexion.Cliente();
                return cliente.borrarOrden(pStrOrden);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
