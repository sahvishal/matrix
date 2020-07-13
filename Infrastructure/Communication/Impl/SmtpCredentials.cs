using System;
using System.Configuration;
using Falcon.App.Core.Communication;

namespace Falcon.App.Infrastructure.Communication.Impl
{
    public class SmtpCredentials : ISmtpCredentials 
    {
        public string Host
        {
            get { return ConfigurationManager.AppSettings.Get("Host"); } 
        }

        public int Port
        {
            get { return  Convert.ToInt32(ConfigurationManager.AppSettings.Get("Port")); }
        }

        public string SmtpUserName
        {
            get { return ConfigurationManager.AppSettings.Get("UserName"); } 
        }

        public string SmtpPassword
        {
            get { return ConfigurationManager.AppSettings.Get("Password"); } 
        }

    }
}