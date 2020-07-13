using System;
namespace Falcon.App.Core.Medical.Domain
{
    public class ActivityType
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DateTime CreatedDate { get; set; }
        public long CreatedBy { get; set; }
        public bool IsActive { get; set; }
    }
}
