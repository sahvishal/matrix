using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class CustomerMedicareQuestionAnswerEditModel
    {
        public long CustomerEventId { get; set; }
        public IEnumerable<CustomerMedicareAnswer> Question { get; set; }
    }

    [NoValidationRequired]
    public class CustomerMedicareAnswer
    {
        public long Id { get; set; }
        public string Answer { get; set; }
        public DisplayControlType ControlType { get; set; }
    }
}