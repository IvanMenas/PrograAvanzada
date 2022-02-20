using Ent_Semana3.Entities;
using Ent_Semana3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.IO;

namespace Ent_Semana3.Controllers
{
    public class TipoCambioController : ApiController
    {
        TipoCambioModel logicTipoCambio = new TipoCambioModel();

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

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(WSResponse);
                string json = JsonConvert.SerializeXmlNode(xmlDoc);

                apiResponse response = new apiResponse();
                response.code = requestParam.Indicador;
                response.xml = WSResponse;
                response.json = json;

                XmlSerializer serializer = new XmlSerializer(typeof(TiposCambio));
                using (StringReader reader = new StringReader(WSResponse))
                {
                    var tiposCambio = (TiposCambio)serializer.Deserialize(reader);

                    foreach (TipoCambio tipoCambio in tiposCambio.List)
                    {
                        logicTipoCambio.Insert(tipoCambio);
                    }

                }

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

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(WSResponse);
                string json = JsonConvert.SerializeXmlNode(xmlDoc);

                apiResponse response = new apiResponse();
                response.code = requestParam.Indicador;
                response.xml = WSResponse;
                response.json = json;

                XmlSerializer serializer = new XmlSerializer(typeof(TiposCambio));
                using (StringReader reader = new StringReader(WSResponse))
                {
                    var tiposCambio = (TiposCambio)serializer.Deserialize(reader);

                    foreach (TipoCambio tipoCambio in tiposCambio.List)
                    {
                        logicTipoCambio.Insert(tipoCambio);
                    }

                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
