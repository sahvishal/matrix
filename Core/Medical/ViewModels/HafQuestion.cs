using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class HafQuestion
    {
        public long ControlType { get; set; }
        public IEnumerable<string> ControlValues { get; set; }
        public int DisplaySequence { get; set; }
        public string DefaultValue { get; set; }
        public string Answer { get; set; }
        public string Label { get; set; }
        public string Question { get; set; }
        public long QuestoinId { get; set; }
        public long QuestionGroupId { get; set; }
        public long ParentQuestionId { get; set; }
        public long DependentQuestionId { get; set; }
        public string DependencyRule { get; set; }
        public int RelativeOrder { get; set; }
        public IEnumerable<HafQuestion> ChildQuestion { get; set; }
    }


}