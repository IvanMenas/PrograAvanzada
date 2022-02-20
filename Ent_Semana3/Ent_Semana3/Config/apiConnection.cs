using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Ent_Semana3
{
    public class apiConnection
    {
        public string user { get; set; }
        public string email { get; set; }
        public string token { get; set; }

        private string nameConnection;

        public apiConnection(string nameConnection = "apiConnection")
        {
            this.nameConnection = nameConnection;
        }

        public void getApiConnection()
        {
            ConnectionStringSettingsCollection connectionSettings = ConfigurationManager.ConnectionStrings;

            if (connectionSettings.Count >0)
            {
                foreach(ConnectionStringSettings connection in connectionSettings)
                {
                    if (connection.Name.Equals(nameConnection))
                    {
                        string[] connectionKeyValues = connection.ConnectionString.Split(';');
                        foreach(var i in connectionKeyValues)
                        {
                            string[] connectionKeyValue = i.Split('=');
                            switch (connectionKeyValue[0].ToLower())
                            {
                                case "user":
                                    user = connectionKeyValue[1];
                                    break;
                                case "email":
                                    email = connectionKeyValue[1];
                                    break;
                                case "token":
                                    token = connectionKeyValue[1];
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