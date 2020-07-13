using System.Configuration;

namespace Falcon.App.Core.Deprecated.Utility
{
    public sealed class ConnectionHandler
    {
        /// <summary>
        /// Returns the connection string from web.config as per the 'DBToUse' key in web.config
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {            
                    return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }
    }

}
