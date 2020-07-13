using System;
using Falcon.App.Core.Communication;

namespace Falcon.Web.IntegrationTests.Fakes
{
    public class FakeSmtpCredentials : ISmtpCredentials 
    {
        public string Host
        {
            get { return "mail.taazaa.com"; }
        }

        public int Port
        {
            get { return 587; }
        }

        public string SmtpUserName
        {
            get { return "support@preventionhealth.org"; }
        }

        public string SmtpPassword
        {
            get { return "phsSupport12"; }
        }
    }
}