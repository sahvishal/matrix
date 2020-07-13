using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Operations.Domain
{
    public class ExportableReports : DomainObjectBase
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
