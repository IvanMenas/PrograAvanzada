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
using Ent_Semana3.Config;

namespace Ent_Semana3.Controllers
{
    public class TipoCambioController : ApiController
    {
        TipoCambioModel logicTipoCambio = new TipoCambioModel();
        apiConnection apiCfg = new apiConnection();
        apiRequest apiReq = new apiRequest();
        const string reqTipoCambioVenta_1DayByMonth = "400301";
        const string reqTipoCambioVenta_15DayByMonth = "400315";
        const string reqTipoCambioVenta_LastDayByMonth = "400331";
        public  String Date_6Months_Ago()
        {
            return DateTime.Now.AddMonths(-6).ToString("d/M/yyyy");

        }
        public String Date_Today()
        {
            return DateTime.Now.ToString("d/M/yyyy");

        }

        public RequestParam initParamsCompra()
        {
            apiCfg.getApiConnection();
            apiReq.getApiRequest();
            return new RequestParam(
                    apiReq.indicatorCompra, Date_6Months_Ago(), Date_Today(), apiCfg.user, apiReq.sublevel,
                    apiCfg.email, apiCfg.token);
        }

        //QUIZ STARTS
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

                logicTipoCambio.InsertXML(WSResponse, Int32.Parse(requestParam.Indicador));

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public RequestParam initParamsVenta()
        {
            apiCfg.getApiConnection();
            apiReq.getApiRequest();
            return new RequestParam(
                    apiReq.indicatorVenta, Date_6Months_Ago(), Date_Today(), apiCfg.user, apiReq.sublevel,
                     apiCfg.email, apiCfg.token);
        }

        //QUIZ ENDS

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

                logicTipoCambio.InsertXML(WSResponse, Int32.Parse(requestParam.Indicador));

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("api/TipoCambio/getTipoCambioVenta_1DayByMonth")]
        public apiResponse getTipoCambioVenta_1DayByMonth()
        {
            try
            {

                apiResponse response = new apiResponse();
                response.code = reqTipoCambioVenta_1DayByMonth;
                response.json = JsonConvert.SerializeObject(logicTipoCambio.getTipoCambioVenta_1DayByMonth());

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("api/TipoCambio/getTipoCambioVenta_15DayByMonth")]
        public apiResponse getTipoCambioVenta_15DayByMonth()
        {
            try
            {

                apiResponse response = new apiResponse();
                response.code = reqTipoCambioVenta_15DayByMonth;
                response.json = JsonConvert.SerializeObject(logicTipoCambio.getTipoCambioVenta_15DayByMonth());

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("api/TipoCambio/getTipoCambioVenta_LastDayByMonth")]
        public apiResponse getTipoCambioVenta_LastDayByMonth()
        {
            try
            {

                apiResponse response = new apiResponse();
                response.code = reqTipoCambioVenta_LastDayByMonth;
                response.json = JsonConvert.SerializeObject(logicTipoCambio.getTipoCambioVenta_LastDayByMonth());

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
