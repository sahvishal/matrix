using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Deprecated.Repository;

public partial class App_CallCenter_CallCenterRep_CallCenterRepChangePackage : Page
{
    public string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
        }
    }

    private RegistrationFlowModel RegistrationFlow
    {
        get
        {
            if (!string.IsNullOrEmpty(GuId))
            {
                return Session[GuId] as RegistrationFlowModel;
            }
            return null;
        }
    }
    protected long ExistingCallId
    {
        get { return RegistrationFlow != null ? RegistrationFlow.CallId : 0; }
    }
    protected long EventId {  get; set; }

    protected long CustomerId { get; set; }
    public long ClinicalQuestionTemplateId { get; set; }
    public long EventCustomerId { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        ClinicalQuestionTemplateId = 0;
        Page.Title = "Adjust order";
        CallCenter_CallCenterMaster1 obj;
        obj = (CallCenter_CallCenterMaster1)this.Master;
        obj.SetTitle("");
         

        if (!IsPostBack)
        {

            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            }
            else
            {
                var repository = new CallCenterCallRepository();
                var objCall = repository.GetCallCenterEntity(ExistingCallId);
                hfCallStartTime.Value = objCall.TimeCreated;
            }
        }

        var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
        if (Request.QueryString["EventCustomerID"] != null)
        {
            EventCustomerId = Convert.ToInt64(Request.QueryString["EventCustomerID"]);
            var eventCustomer = eventCustomerRepository.GetById(EventCustomerId);

            CustomerId = eventCustomer.CustomerId;
            EventId = eventCustomer.EventId;
        }
        else if (Request.QueryString["EventId"] != null && Request.QueryString["CustomerId"] != null)
        {
            EventId = Convert.ToInt64(Request.QueryString["EventId"]);
            CustomerId = Convert.ToInt64(Request.QueryString["CustomerId"]);

            EventCustomerId = eventCustomerRepository.Get(EventId, CustomerId).Id;
        }

        if (EventId > 0)
        {  
            var corporateAccountRepository = IoC.Resolve<ICorporateAccountRepository>();

            var account = corporateAccountRepository.GetbyEventId(EventId);

            if (account != null)
            {
                if (account.AskClinicalQuestions && account.ClinicalQuestionTemplateId.HasValue)
                {
                    FillClinicialQuestionnaireDiv.Visible = true;
                    ClinicalQuestionTemplateId = account.ClinicalQuestionTemplateId.Value;
                    GetRecommendationText();
                }
            }
        }
    }

    private void GetRecommendationText()
    {
        recommended_test_text.Style.Add(HtmlTextWriterStyle.Display, "none");
        disqulifiedTests.Style.Add(HtmlTextWriterStyle.Display, "none");

        var clinicalQuestionAnswersRepository = IoC.Resolve<ICustomerClinicalQuestionAnswerRepository>();
        var answersSaved = clinicalQuestionAnswersRepository.GetCustomerClinicalQuestionAnswers(GuId, CustomerId);
        if (answersSaved.IsNullOrEmpty()) return;

        var customerClinicalQuestionAnswerSerice = IoC.Resolve<ICustomerClinicalQuestionAnswerService>();
        var recommendedTest = customerClinicalQuestionAnswerSerice.RecommendTestToCustomer(GuId, CustomerId, EventId);
        var recommendedTestNames = "None";

        if (recommendedTest != null && recommendedTest.Any(x => !x.IsDisqualified))
        {
            recommendedTestNames = string.Join(",", recommendedTest.Where(x => !x.IsDisqualified).Select(x => x.Name).ToArray());
        }

        if (recommendedTest != null && recommendedTest.Any(x => x.IsDisqualified))
        {
            var disqualifiedTestNames = string.Join(",", recommendedTest.Where(x => x.IsDisqualified).Select(x => x.Name).ToArray());
            disqulifiedTests.InnerHtml = "<b>Disqualified Tests: </b>" + HttpUtility.HtmlEncode(disqualifiedTestNames);
            disqulifiedTests.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        recommended_test_text.InnerHtml = "<b>Recommended Tests: </b>" + HttpUtility.HtmlEncode(recommendedTestNames);
        recommended_test_text.Style.Add(HtmlTextWriterStyle.Display, "block");
    }
}
