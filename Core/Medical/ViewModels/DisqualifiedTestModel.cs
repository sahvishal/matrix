using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class DisqualifiedTestModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public long TestId { get; set; }
        public long Version { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
