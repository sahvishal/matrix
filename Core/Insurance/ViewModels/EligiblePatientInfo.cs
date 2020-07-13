using Newtonsoft.Json;

namespace Falcon.App.Core.Insurance.ViewModels
{
    public class EligiblePatientInfo
    {
        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "member_id")]
        public string MemberId { get; set; }

        [JsonProperty(PropertyName = "group_id")]
        public string GroupId { get; set; }

        [JsonProperty(PropertyName = "group_name")]
        public string GroupName { get; set; }

        [JsonProperty(PropertyName = "dob")]
        public string Dob { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "address")]
        public EligiblePatientAddress Address { get; set; }
    }
}
