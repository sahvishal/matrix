using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.UI.Filters;
using System;
using System.Web.Mvc;

namespace Falcon.App.UI.Areas.Scheduling.Controllers
{
    [RoleBasedAuthorize]
    public class ChatAssessmentController : Controller
    {
        private readonly ISessionContext _sessionContext;
        private readonly IChatAssessmentService _chatAssessmentService;

        public ChatAssessmentController(ISessionContext sessionContext, IChatAssessmentService chatAssessmentService)
        {
            _sessionContext = sessionContext;
            _chatAssessmentService = chatAssessmentService;
        }

        [HttpPost]
        public ActionResult GetChatAssessmentPdf(long eventId, string acesId)
        {
            try
            {
                var model = _chatAssessmentService.GetChatAssessmentPdfPath(eventId, acesId);
                return PartialView(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public bool SaveChatAssessmentPdfReview(long eventId, long customerId, bool isVerified, bool isforOveread)
        {
            var physicianId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
            return _chatAssessmentService.SaveAssessmentPdfVerification(eventId, customerId, isVerified, isforOveread, physicianId);
        }
    }
}
