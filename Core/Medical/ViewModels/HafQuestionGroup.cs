using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HafQuestionGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long GroupId { get; set; }
        public IEnumerable<HafQuestion> Questions { get; set; }
    }
}