using Falcon.App.Core.Domain;
using System;

namespace Falcon.App.Core.Medical.Domain
{
    public class SurveyTemplate : DomainObjectBase
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsPublished { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public long CreatedBy { get; set; }
        public long? ModifiedBy { get; set; }
        public bool IsDefault { get; set; }
    }
}