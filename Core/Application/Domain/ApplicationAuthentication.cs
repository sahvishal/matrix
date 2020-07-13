using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Application.Domain
{
    public class ApplicationAuthentication : DomainObjectBase
    {
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string Token { get; set; }
        public long CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsActive { get; set; }
    }
}
