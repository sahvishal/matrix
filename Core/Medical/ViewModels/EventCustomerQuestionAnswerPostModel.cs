using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class EventCustomerQuestionAnswerPostModel
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string QuestionAnswerTestIds { get; set; }
        public string DisqualifiedTests { get; set; }
    }
}
