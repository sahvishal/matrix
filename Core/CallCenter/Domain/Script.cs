using System;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.CallCenter.Domain
{
    public class Script : DomainObjectBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ScriptText { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long ScriptTypeId { get; set; }
    }
}
