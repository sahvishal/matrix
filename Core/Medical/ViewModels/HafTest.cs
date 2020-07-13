using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HafTest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<HafQuestionGroup> HafQuestionGroups { get; set; }
    }
}