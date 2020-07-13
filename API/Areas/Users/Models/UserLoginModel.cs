using System.Runtime.Serialization;
using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Users.Models
{
    [NoValidationRequired]
    [DataContract]
    public class UserLoginModel
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        [IgnoreAudit]
        public string Password { get; set; }

        [DataMember]
        public string DeviceKey { get; set; }
    }
}