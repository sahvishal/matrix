using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MedicareQuestionGroupEditModel
    {
        public long Id { get; set; }
        public string GroupName { get; set; }
        public string GroupAlias { get; set; }
        public bool IsAcitve { get; set; }
        public bool IsDefault { get; set; }

        public IEnumerable<MedicareQuestionEditModel> MedicareQuestions { get; set; }
    }
}