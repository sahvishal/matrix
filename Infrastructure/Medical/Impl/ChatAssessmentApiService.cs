using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ChatAssessmentApiService : IChatAssessmentApiService
    {
        private string ApiUrl;
        private string Token { get; set; }
        private readonly ISettings _settings;
        private readonly ILogger _logger;

        public ChatAssessmentApiService(ISettings settings, ILogManager logManager)
        {
            _settings = settings;
            ApiUrl = _settings.ChatAssessmentPdfUrl;
            _logger = logManager.GetLogger("ApiService");
        }

        public T Post<T>(object data)
        {
            try
            {
                var json = "";
                if (data != null)
                {
                    json = data.ToString();
                }

                using (var client = new WebClient())
                {
                    SetHeaders(client);
                    var result = client.UploadString(ApiUrl, json);
                    return CheckResponse<T>(result);
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred: Exception: " + ex.Message + " StackTrace: " + ex.StackTrace);
                throw new WebException("Error at API level: " + ex.Message);
            }
        }

        private void SetHeaders(WebClient client)
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            //client.Headers["ApplicationIdentity"] = _settings.ApplicationIdentity;

            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.ChatAssessmentPdfUserName + ":" + _settings.ChatAssessmentPdfPassword));
            client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", credentials);
        }

        private static T CheckResponse<T>(string result)
        {
            if (string.IsNullOrEmpty(result)) return default(T);

            var response = JsonConvert.DeserializeObject<Falcon.App.Core.Medical.ViewModels.ChatAssessmentDataModel>(result);
            if (response == null)
            {
                throw new Exception("Some un-expected error occurred at API level.");
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(response));
            }
        }

        //public T Get<T>(string url)
        //{
        //    using (var client = new WebClient())
        //    {
        //        SetHeaders(client);

        //        var result = client.DownloadString(ApiUrl + url);
        //        return CheckResponse<T>(result);
        //    }
        //}
    }
}
