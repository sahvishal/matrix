using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HafModel 
    {
        public long EventId { get; set; }
        public long CustomerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HafQuestionGroup HafGroup { get; set; }
        public IEnumerable<HafTest> HafTests { get; set; }
        public bool IsSuccess { get; set; }
    }
}