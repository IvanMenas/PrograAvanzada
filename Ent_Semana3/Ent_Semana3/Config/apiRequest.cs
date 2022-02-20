using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Ent_Semana3.Config
{
    public class apiRequest
    {

        public string indicator { get; set; }
        public string sublevel { get; set; }

        private string nameConnection;

        public apiRequest(string nameConnection = "apiRequest")
        {
            this.nameConnection = nameConnection;
        }

        public void getApiRequest()
        {
            ConnectionStringSettingsCollection connectionSettings = ConfigurationManager.ConnectionStrings;

            if (connectionSettings.Count > 0)
            {
                foreach (ConnectionStringSettings connection in connectionSettings)
                {
                    if (connection.Name.Equals(nameConnection))
                    {
                        string[] connectionKeyValues = connection.ConnectionString.Split(';');
                        foreach (var i in connectionKeyValues)
                        {
                            string[] connectionKeyValue = i.Split('=');
                            switch (connectionKeyValue[0].ToLower())
                            {
                                case "indicator":
                                    indicator = connectionKeyValue[1];
                                    break;
                                case "sublevel":
                                    sublevel = connectionKeyValue[1];
                                    break;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new Exception("No hay cadenas de conexion");
            }
        }

    }
}
