using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Screening;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.UI.App.Common
{
    public partial class PostAudit : System.Web.UI.Page
    {

        public long EventId { get; set; }
        public long CustomerId { get; set; }
        protected bool IsNewResultFlow { get; set; }
        protected string VersionNumber { get; set; }
        protected bool IsHealthPlan { get; set; }
        protected bool ShowHraQuestions { get; set; }
        protected bool IsEawvTestPurchased { get; set; }
        protected bool IsEawvTestNotPerformed { get; set; }
        protected QuestionnaireType QuestionnaireType { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ISystemInformationRepository systemInformationRepository = new SystemInformationRepository();
            VersionNumber = systemInformationRepository.GetBuildNumber();

            var master = ((Franchisor_FranchisorMaster)Master);
            if (master != null)
            {
                master.HideLeftContainer = true;
                master.hideucsearch();
                master.settitle("Post Audit");
                master.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
            }

            long s = 0;
            if (Request.QueryString["EventId"] != null && long.TryParse(Request.QueryString["EventId"], out s))
            {
                EventId = s;
            }

            s = 0;
            if (Request.QueryString["CustomerId"] != null && long.TryParse(Request.QueryString["CustomerId"], out s))
            {
                CustomerId = s;
            }

            if (EventId > 0 && CustomerId > 0)
            {
                var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();
                var account = corporateAccountRepository.GetbyEventId(EventId);

                IsHealthPlan = account != null && account.IsHealthPlan;

                var eventRepository = IoC.Resolve<IEventRepository>();
                var theEvent = eventRepository.GetById(EventId);
                QuestionnaireType = QuestionnaireType.None;
                if (account != null && theEvent != null)
                {
                    var accountHraChatQuestionnaireHistoryServices = IoC.Resolve<IAccountHraChatQuestionnaireHistoryServices>();
                    QuestionnaireType = accountHraChatQuestionnaireHistoryServices.QuestionnaireTypeByAccountIdandEventDate(account.Id, theEvent.EventDate);
                }

                ShowHraQuestions = (QuestionnaireType == QuestionnaireType.HraQuestionnaire);

                var eventCustomerResultRepository = IoC.Resolve<IEventCustomerResultRepository>();
                var testResultService = IoC.Resolve<ITestResultService>();
                var eventCustomerResult = eventCustomerResultRepository.GetByCustomerIdAndEventId(CustomerId, EventId);

                IsEawvTestPurchased = testResultService.IsTestPurchasedByCustomer(eventCustomerResult.Id, (long)TestType.eAWV);
                if (IsEawvTestPurchased)
                    IsEawvTestNotPerformed = IoC.Resolve<ITestNotPerformedRepository>().IsTestNotPerformed(eventCustomerResult.Id, (long)TestType.eAWV);

                if (account != null)
                {
                    if (account.MarkPennedBack && eventCustomerResult.IsRevertedToEvaluation)
                    {
                        MarkAsPennedBackDiv.Visible = true;
                        if (eventCustomerResult.IsPennedBack)
                            MarkAsPennedBackCheckbox.Checked = true;
                    }
                    else
                        MarkAsPennedBackDiv.Visible = false;
                }

                IsNewResultFlow = eventRepository.IsEventHasNewResultFlow(EventId);

                if (IsNewResultFlow)
                    ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "true");
                else
                    ClientScript.RegisterHiddenField("IsNewResultFlowInputHidden", "false");
            }

            var repository = new TestResultRepository();
            var nextCustomerId = repository.GetNextCustomerPostAudit(EventId, CustomerId, IsNewResultFlow);

            ClientScript.RegisterStartupScript(Page.GetType(), "js_nextCustomer", "nextCustomerId = " + nextCustomerId + ";", true);
        }

    }
}