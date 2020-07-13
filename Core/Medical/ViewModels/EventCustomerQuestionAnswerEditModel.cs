using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
     [NoValidationRequired]
    public class EventCustomerQuestionAnswerEditModel
    {
         public long CustomerId { get; set; }
         public long EventId { get; set; }
         public long TestId { get; set; }
         public long QuestionId { get; set; }
         public string Answer { get; set; }
         public long Version { get; set; }
    }
}
