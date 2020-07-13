using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Communication.Domain
{
    public class SmsReceived : DomainObjectBase
    {
        public string PhoneNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public string Message { get; set; }
    }
}
