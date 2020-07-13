using Falcon.App.Core.Domain;

namespace Falcon.App.Core.ACL.Domain
{
    public class AccessControlObjectUrl : DomainObjectBase
    {
        public string Url { get; set; }
        public AccessControlObject AccessControlObject { get; set; }
    }
}