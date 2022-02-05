using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ent_Semana3.Entities
{
    public class TipoCambioObj
    {
        public DateTime DES_FECHA { get; set;}
        public int NUM_VALOR { get; set;}
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
            this. Nombre = Nombre;
            this.SubNiveles = SubNiveles;
            this.CorreoElectronico = CorreoElectronico;
            this.Token = Token;
        }
    }

    public class apiResponse
    {
        public string codigoRespuesta { get; set; }
        public string xmlResponse { get; set; }
    }
}