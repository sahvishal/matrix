using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class QuestionViewModel
    {
        public long Id { get; set; }
        public string Question { get; set; }
        public long TestId { get; set; }
        public IEnumerable<string> Options { get; set; }
        public string Answer { get; set; }
        public long? ParentId { get; set; }
        public long? TypeId { get; set; } 
    }
}
