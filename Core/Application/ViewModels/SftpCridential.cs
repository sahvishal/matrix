using System;
using System.Xml.Serialization;

namespace Falcon.App.Core.Application.ViewModels
{
    public class SftpCridential
    {
        public long AccountId { get; set; }
        public string HostName { get; set; }
        public string UserName { get; set; }
        public string PasswordBase64 { get; set; }
        public string PasswordPlainText { get; set; }
        public string SftpPath { get; set; }
        public bool SendFileToSftp { get; set; }

        [XmlIgnore]
        public string Password
        {
            get { return Base64Decode(PasswordBase64); }
            set { PasswordBase64 = Base64Encode(value); }
        }

        private string Base64Encode(string plainText)
        {
            if (string.IsNullOrEmpty(plainText)) return string.Empty;

            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private string Base64Decode(string base64EncodedData)
        {
            if (string.IsNullOrEmpty(PasswordBase64)) return string.Empty;

            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
