using System.Collections.Generic;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class StaffEventRoleBasicModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Tests { get; set; }
    }
}