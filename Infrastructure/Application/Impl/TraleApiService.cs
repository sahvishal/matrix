using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class TraleApiService : ITraleApiService
    {
        private readonly string _trailUrl;

        private const string PostUrl = "api/assessment/submit";
        private readonly string _traleKey;
        private readonly string _traleIv;
        private readonly string _traleApiKey;
        private readonly ILogger _logger;
        public TraleApiService(ISettings settings, ILogManager logManager)
        {
            _trailUrl = settings.TraleUrl;
            _traleKey = settings.TraleKey;
            _traleIv = settings.TraleIv;
            _traleApiKey = settings.TraleApiKey;
            _logger = logManager.GetLogger("TraleWebApi");
        }

        public T Post<T>(object data)
        {
            try
            {
                var encrypted = EncryptEncoded(JsonConvert.SerializeObject(data));

                using (var client = new WebClient())
                {
                    SetHeaders(client);
                    string postBody = String.Format("apiKey={0}&payload={1}", _traleApiKey, Uri.EscapeDataString(encrypted));
                    var result = UnescapeString(Encoding.UTF8.GetString(client.UploadData(_trailUrl + PostUrl, "POST", Encoding.UTF8.GetBytes(postBody))));
                    return CheckResponse<T>(result);
                    
                }
            }
            catch (Exception ex)
            {
                _logger.Error("some Error Occurred while Requesting on Trale API Message: " + ex.Message + " Stack Trace:" + ex.StackTrace);
                throw;
            }
        }

        public BioCheckJsonViewModel Post(BioCheckJsonViewModel data)
        {
            try
            {
                var encrypted = EncryptEncoded(JsonConvert.SerializeObject(data));

                using (var client = new WebClient())
                {
                    SetHeaders(client);
                    string postBody = String.Format("apiKey={0}&payload={1}", _traleApiKey, Uri.EscapeDataString(encrypted));
                    var result = UnescapeString(Encoding.UTF8.GetString(client.UploadData(_trailUrl + PostUrl, "POST", Encoding.UTF8.GetBytes(postBody))));

                    return CheckResponse(result);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("some Error Occurred while Requesting on Trale API Message: " + ex.Message + " Stack Trace:" + ex.StackTrace);
                throw;
            }
        }

        public T Post<T>(string url, object data)
        {
            var json = "";
            if (data != null)
            {
                json = EncryptEncoded(JsonConvert.SerializeObject(data)); // ;
            }

            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                client.Headers["timezoneoffset"] = (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes).ToString();
                var result = client.UploadString(url, "POST", json);

                return CheckResponse<T>(result);
            }
        }

        public T Get<T>(string url)
        {
            using (var client = new WebClient())
            {
                SetHeaders(client);

                var result = client.DownloadString(_trailUrl + url);
                return CheckResponse<T>(result);
            }

        }

        private void SetHeaders(WebClient client)
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers["timezoneoffset"] = (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes).ToString();

        }

        private BioCheckJsonViewModel CheckResponse(string result)
        {
            if (string.IsNullOrEmpty(result)) return null;
            var decryptedResult = DecryptEncoded(result);
            var response = JsonConvert.DeserializeObject<BioCheckJsonViewModel>(decryptedResult);
            return response;
        }

        private T CheckResponse<T>(string result)
        {
            if (string.IsNullOrEmpty(result)) return default(T);
            var decryptedResult = DecryptEncoded(result);
            var response = JsonConvert.DeserializeObject<T>(decryptedResult);
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(response));
        }

        private string EncryptEncoded(string plainText)
        {
            //Encrypts to AES256 and then encodes with Base64

            var result = String.Empty;

            using (var aesCrypt = new AesManaged())
            {
                aesCrypt.IV = Encoding.UTF8.GetBytes(_traleIv);
                aesCrypt.Key = Encoding.UTF8.GetBytes(_traleKey);

                ICryptoTransform encryptor = aesCrypt.CreateEncryptor(aesCrypt.Key, aesCrypt.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        byte[] encrypted = msEncrypt.ToArray();

                        result = Convert.ToBase64String(encrypted);
                    }
                }
            }

            return result;
        }

        private string DecryptEncoded(string encryptedEcodedString)
        {
            //Decodes Base64 string and then decrypts with AES256

            string result = String.Empty;

            using (AesManaged aesCrypt = new AesManaged())
            {
                aesCrypt.IV = Encoding.UTF8.GetBytes(_traleIv);
                aesCrypt.Key = Encoding.UTF8.GetBytes(_traleKey);

                ICryptoTransform decryptor = aesCrypt.CreateDecryptor(aesCrypt.Key, aesCrypt.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedEcodedString)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            result = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return result;
        }

        static string UnescapeString(string s)
        {
            //The response payload includes embedded reports and makes 
            //the string too long to process with Uri.UnescapeString()

            //Remove double quotes and backslashes
            s = s.Replace("\"", "").Replace(@"\/", "/");
            return s;
        }
    }
}
