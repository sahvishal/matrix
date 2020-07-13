using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medical.ViewModels
{
    [NoValidationRequired]
    public class PostEvaluationEditModel
    {
        public long CustomerId { get; set; }

        public long EventId { get; set; }
        public IEnumerable<string> TestResultStrings { get; set; }
        public bool DoPostAudit { get; set; }
        public bool DoReque { get; set; }
        public long OrganizationRoleUserId { get; set; }
        public bool IsNewResultflow { get; set; }
        public bool IsPennedBack { get; set; }
        public bool IsRevertToCoding { get; set; }
        public bool IsRevertToNp { get; set; }
        public bool IsRevertToPreAudit { get; set; }
        
        public bool IsHealthPlanEvent { get; set; }
        public bool ShowHraQuestions { get; set; }
        public bool IsEawvTestPurchased { get; set; }
        public bool IsEawvTestNotPerformed { get; set; }

        public string Message { get; set; }
    }
}
