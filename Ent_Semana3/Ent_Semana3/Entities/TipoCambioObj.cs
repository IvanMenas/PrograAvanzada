using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Ent_Semana3.Entities
{
    [XmlRoot(ElementName = "Datos_de_INGC011_CAT_INDICADORECONOMIC")]
    public class TiposCambio
    {

        [XmlElement(ElementName = "INGC011_CAT_INDICADORECONOMIC")]
        public List<TipoCambio> List { get; set; }
    }

    [XmlRoot(ElementName = "INGC011_CAT_INDICADORECONOMIC")]
    public class TipoCambio
    {

        [XmlElement(ElementName = "COD_INDICADORINTERNO")]
        public int CODINDICADORINTERNO { get; set; }

        [XmlElement(ElementName = "DES_FECHA")]
        public DateTime DESFECHA { get; set; }

        [XmlElement(ElementName = "NUM_VALOR")]
        public decimal NUMVALOR { get; set; }
    }

    public class RequestParam
    {
        public string Indicador { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFinal { get; set; }
        public string Nombre { get; set; }
        public string SubNiveles { get; set; }
        public string CorreoElectronico { get; set; }
        public string Token { get; set; }

        public RequestParam(string Indicador, string FechaInicio, string FechaFinal, string Nombre, string SubNiveles, string CorreoElectronico, string Token)
        {
            this.Indicador = Indicador;
            this.FechaInicio = FechaInicio; 
            this.FechaFinal = FechaFinal;
            this.Nombre = Nombre;
            this.SubNiveles = SubNiveles;
            this.CorreoElectronico = CorreoElectronico;
            this.Token = Token;
        }
    }

    public class apiResponse
    {
        public string code { get; set; }
        public string xml { get; set; }
        public string json { get; set; }
    }
}