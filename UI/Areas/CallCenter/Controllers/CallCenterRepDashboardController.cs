using System;
using System.Web.Mvc;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Filters;

namespace Falcon.App.UI.Areas.CallCenter.Controllers
{
    [RoleBasedAuthorize]
    public class CallCenterRepDashboardController : Controller
    {
        private readonly ICallCenterCallRepository _callCenterCallRepository;
        private readonly ISessionContext _sessionContext;
        private string GuId { get; set; }

        public RegistrationFlowModel RegistrationFlow
        {
            get
            {
                if (!string.IsNullOrEmpty(GuId))
                {
                    return Session[GuId] as RegistrationFlowModel;
                }
                return null;
            }
            set { Session[GuId] = value; }
        }
        public CallCenterRepDashboardController(ICallCenterCallRepository callCenterCallRepository, ISessionContext sessionContext)
        {
            _callCenterCallRepository = callCenterCallRepository;
            _sessionContext = sessionContext;
        }

        //
        // GET: /CallCenter/CallCenterRepDashboard/
        public ActionResult Index()
        {
            if (Request.QueryString["dn"] != null && (Request.QueryString["cn"] != null || Request.QueryString["amp;cn"] != null))
            {
                var txtIncomingPhLineText = string.Empty;
                var txtCallersPhNumberText = string.Empty;

                if (Request.QueryString["dn"] != null)
                {
                    txtIncomingPhLineText = Request.QueryString["dn"];
                }

                if (Request.QueryString["cn"] != null)
                {
                    txtCallersPhNumberText = Request.QueryString["cn"];
                }
                else if (Request.QueryString["amp;cn"] != null)
                {
                    txtCallersPhNumberText = Request.QueryString["amp;cn"];
                }

                Response.RedirectUser("~/CallCenter/CallCenterRepDashboard/StartCall?cn=" + txtCallersPhNumberText + "&dn=" + txtIncomingPhLineText + "&isInbound=true");
            }

            return View();
        }

        public ActionResult StartCall(string cn, string dn, bool isInbound)
        {
            var call = new Call
            {
                CreatedByOrgRoleUserId = _sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,
                StartTime = DateTime.Now,
                IsIncoming = isInbound,
                CalledInNumber = dn,
                CallerNumber = cn,
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                Status = (long)CallStatus.Initiated
            };

            call = _callCenterCallRepository.Save(call);

            GuId = Guid.NewGuid().ToString();

            var registrationFlow = new RegistrationFlowModel
            {
                GuId = GuId,
                CallId = call.Id,
                PreQualificationResultId = 0
            };

            RegistrationFlow = registrationFlow;
            Response.RedirectUser("~/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?guid=" + GuId);

            return null;
        }

    }
}