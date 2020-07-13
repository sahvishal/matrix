using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.CallQueues.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class MassAgentAssignmentEditModel
    {
        public HttpPostedFileBase MassAssignmentFile { get; set; }
        public long? HealthPlanId { get; set; }
        public string CallQueueCategory { get; set; }
        public long? CriteriaId { get; set; }
        public IEnumerable<CallQueueAssignmentEditModel> AssignmentsfromUi{ get; set; }
        //public FormCollection AssignmentsfromUi { get; set; }
    }
}
