using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Insurance;
using Falcon.App.Core.Insurance.Domain;
using Falcon.App.Core.Insurance.ViewModels;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.Insurance.Impl
{
    [DefaultImplementation]
    public class EligibilityApi : IEligibilityApi
    {

        private const string RootApi = @"https://gds.eligibleapi.com/v1.3/{0}/{1}?api_key={2}";

        private readonly ISettings _settings;

        public EligibilityApi(ISettings settings)
        {
            _settings = settings;
        }

        public EligibleResponse GetCoverage(EligibilityRequestEditModel eligbleRequest, InsuranceCompany insuranceCompany, InsuranceServiceType insuranceServiceType)
        {
            // Init the URL
            string url = string.Format(RootApi, "coverage", "all.json", _settings.EligibilityApiKey);

            // Update the URL
            url = BuildUrl(url, eligbleRequest, insuranceCompany, insuranceServiceType);

            try
            {
                // Grab the response
                string responseBody = PostRequest(url);

                // Parse the response object
                var response = JsonConvert.DeserializeObject<EligibleResponse>(responseBody);


                // Save the JSON, may want it later
                response.RawResponse = responseBody;

                return response;

            }
            catch (Exception)
            {
                return new EligibleResponse
                {
                    Error = new EligibleError
                    {
                        ResponseDescription = "Unauthorized",
                        RejectionReasonDescription = "Authorization/Access Restrictions",
                        FollowUpActionDescription = "Please Correct and Resubmit"
                    }
                };
            }

        }

        private string BuildUrl(string url, EligibilityRequestEditModel eligbleRequest, InsuranceCompany insuranceCompany, InsuranceServiceType insuranceServiceType)
        {
            if (_settings.EligibilityTestMode)
            {
                url = AddUrlParameter(url, @"test", "true");
            }
            url = AddUrlParameter(url, @"payer_id", insuranceCompany.Code);
            url = AddUrlParameter(url, @"provider_last_name", _settings.EligibilityProviderLastName);
            url = AddUrlParameter(url, @"provider_first_name", _settings.EligibilityProviderFirstName);
            url = AddUrlParameter(url, @"provider_npi", _settings.EligibilityProviderNpi);
            url = AddUrlParameter(url, @"service_type", insuranceServiceType.Code);
            url = AddUrlParameter(url, @"network", (insuranceCompany.InNetwork ? "IN" : "OUT"));
            url = AddUrlParameter(url, @"member_id", eligbleRequest.MemberId);
            url = AddUrlParameter(url, @"member_last_name", eligbleRequest.LastName);
            url = AddUrlParameter(url, @"member_first_name", eligbleRequest.FirstName);
            if (eligbleRequest.Dob.HasValue)
                url = AddUrlParameter(url, @"member_dob", eligbleRequest.Dob.Value.ToString("yyyy-MM-dd"));

            return url;
        }

        private static string PostRequest(string url, string json = null)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "application/json";
            if (!string.IsNullOrEmpty(json))
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(json);
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

            }

            using (WebResponse r = request.GetResponse())
            using (var sr = new StreamReader(r.GetResponseStream()))
                return sr.ReadToEnd();

        }

        private static string AddUrlParameter(string url, string name, string value)
        {
            if (string.IsNullOrEmpty(value))
                return url;

            return string.Concat(url, @"&", name, @"=", HttpUtility.UrlEncode(value));

        }
    }
}
