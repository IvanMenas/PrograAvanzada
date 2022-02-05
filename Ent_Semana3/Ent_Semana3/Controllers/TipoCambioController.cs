using Ent_Semana3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace Ent_Semana3.Controllers
{
    public class TipoCambioController : ApiController
    {
        public RequestParam initParamsCompra()
        {
            return new RequestParam(
                    "317", "05/09/2021", "05/02/2022", "Diego Morales", "N",
                    "diego.morales22102001@gmail.com", "MG0MD0MGLO");
        }

        [HttpGet]
        [Route("api/TipoCambio/getTipoCambioCompra")]
        public apiResponse getTipoCambioCompra()
        {
            try
            {
                RequestParam requestParam = initParamsCompra();
                cr.fi.bccr.gee.wsindicadoreseconomicos WSBancoCentral = new cr.fi.bccr.gee.wsindicadoreseconomicos();
                String WSResponse = WSBancoCentral.ObtenerIndicadoresEconomicosXML(
                    requestParam.Indicador,
                    requestParam.FechaInicio,
                    requestParam.FechaFinal,
                    requestParam.Nombre,
                    requestParam.SubNiveles,
                    requestParam.CorreoElectronico,
                    requestParam.Token);
                apiResponse response = new apiResponse();
                response.codigoRespuesta = requestParam.Indicador;
                response.xmlResponse = WSResponse;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(WSResponse);
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public RequestParam initParamsVenta()
        {
            return new RequestParam(
                    "318", "05/09/2021", "05/02/2022", "Diego Morales", "N",
                    "diego.morales22102001@gmail.com", "MG0MD0MGLO");
        }

        [HttpGet]
        [Route("api/TipoCambio/getTipoCambioVenta")]
        public apiResponse getTipoCambioVenta()
        {
            try
            {
                RequestParam requestParam = initParamsVenta();
                cr.fi.bccr.gee.wsindicadoreseconomicos WSBancoCentral = new cr.fi.bccr.gee.wsindicadoreseconomicos();
                String WSResponse = WSBancoCentral.ObtenerIndicadoresEconomicosXML(
                    requestParam.Indicador,
                    requestParam.FechaInicio,
                    requestParam.FechaFinal,
                    requestParam.Nombre,
                    requestParam.SubNiveles,
                    requestParam.CorreoElectronico,
                    requestParam.Token);
                apiResponse response = new apiResponse();
                response.codigoRespuesta = requestParam.Indicador;
                response.xmlResponse = WSResponse;
                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
