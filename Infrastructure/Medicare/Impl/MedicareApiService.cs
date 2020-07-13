using System;
using System.Net;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class MedicareApiService : IMedicareApiService
    {
        private readonly ISettings _settings;
        private readonly IUserLoginLogRepository _userLoginLogRepository;
        private string ApiUrl { get; set; }
        private string Token { get; set; }
        private string MedicareToken { get; set; }

        public MedicareApiService(ISettings settings, IUserLoginLogRepository userLoginLogRepository)
        {
            _settings = settings;
            _userLoginLogRepository = userLoginLogRepository;
        }

        private void Connect(string token)
        {
            Token = GetPrivateToken(token);
            ApiUrl = _settings.MedicareApiUrl;

            AuthenticateUser();
        }

        public void Connect(long userLoginLogId)
        {
            var token = _userLoginLogRepository.GetMedicareToken(userLoginLogId);
            Connect(token);
        }

        public T Post<T>(string url, object data)
        {

            var json = "";
            if (data != null)
            {
                json = JsonConvert.SerializeObject(data);
            }

            using (var client = new WebClient())
            {
                SetHeaders(client);
                var result = client.UploadString(ApiUrl + url, "POST", json);

                return CheckResponse<T>(result);
            }


        }

        /// <summary>
        /// As object is converted to Json , it might break if special characters, just pass escapeAscii true in that case
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="escapeAscii"></param>
        /// <returns></returns>
        public T PostAnonymous<T>(string url, object data, bool escapeAscii = false)
        {
            var json = "";
            if (data != null)
            {
                json = JsonConvert.SerializeObject(data);
                if (escapeAscii)
                {
                    var setting = new JsonSerializerSettings();
                    setting.StringEscapeHandling = StringEscapeHandling.EscapeNonAscii;
                    json.Remove(0);
                    json = JsonConvert.SerializeObject(data, Formatting.None, setting);
                }
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

                var result = client.DownloadString(ApiUrl + url);
                return CheckResponse<T>(result);
            }

        }

        private void SetHeaders(WebClient client)
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.Headers["timezoneoffset"] = (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes).ToString();
            client.Headers["Ehr-token"] = Token;
            client.Headers[_settings.MedicareTokenKeyName] = MedicareToken;

        }

        private string GetPrivateToken(string token)
        {
            var decryptedToken = token.Decrypt();
            var userData = decryptedToken.Split('_');
            if (userData.Length != 5)
            {
                throw new Exception("Invalid medicare token.");
            }
            var sessionId = userData[3];
            var userId = long.Parse(userData[1]);
            var roleId = long.Parse(userData[0]);
            var organizationId = long.Parse(userData[2]);

            return (sessionId + "_" + userId + "_" + roleId + "_" + organizationId).Encrypt();

        }

        private static T CheckResponse<T>(string result)
        {
            if (string.IsNullOrEmpty(result)) return default(T);
            var response = JsonConvert.DeserializeObject<MedicareResponseModel>(result);
            if (response.Message.MessageType == MedicareResponseMessageType.Error)
            {
                throw new Exception(response.Message.Message);


            }

            return response.Data != null ? JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(response.Data)) : default(T);
        }

        private void AuthenticateUser()
        {
            var userToken = Post<string>(MedicareApiUrl.AuthenticationUrl, null);
            if (string.IsNullOrEmpty(userToken))
                throw new Exception("Invalid medicare token.");
            MedicareToken = userToken;
        }
    }
}
