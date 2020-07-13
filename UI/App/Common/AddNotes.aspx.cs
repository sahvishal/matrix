using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Extentions;

public partial class App_Common_AddNotes : BasePage
{
    private string GuId
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
        set { Session[GuId] = value; }
    }

    private long CustomerId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
        }
    }

    protected long EventId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Add Notes";
        Franchisee_Technician_TechnicianMaster obj;
        obj = (Franchisee_Technician_TechnicianMaster)this.Master;
        
        obj.SetBreadcrumb = "<a href=\"/App/Franchisee/Technician/HomePage.aspx\">Dashboard></a>";
        if (Request.QueryString["Customer"] != null && Request.QueryString["Customer"].ToString() == "Existing")
        {
            obj.settitle("Existing Customer");
            dvTitle.InnerText = "Technician Existing Customer";
        }
        else
        {
            obj.settitle("Register New Customer");
            dvTitle.InnerText = "Technician Register Customer";
        }
    }
    
    
    protected void ImgBtnFinish_Click(object sender, ImageClickEventArgs e)
    {

        if (CustomerId > 0 && !(string.IsNullOrWhiteSpace(txtnotes.Text)))
        {
            var currentUser = IoC.Resolve<ISessionContext>().UserSession;
            var customerRegistrationNotes = new CustomerCallNotes
            {
                CustomerId = CustomerId,
                EventId =
                    EventId > 0 ? (long?)EventId : null,
                Notes = txtnotes.Text,
                NotesType = CustomerRegistrationNotesType.AppointmentNote,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(currentUser.CurrentOrganizationRole.OrganizationRoleUserId)
                }
            };

            var customerRegistrationNotesRepository = IoC.Resolve<IUniqueItemRepository<CustomerCallNotes>>();
            customerRegistrationNotesRepository.Save(customerRegistrationNotes);
            LogAudit(ModelType.Edit, customerRegistrationNotes,CustomerId);
        }

        var eventId = EventId;
        RegistrationFlow = null;

        if (eventId > 0)
            Response.RedirectUser("/Scheduling/EventCustomerList/Index?id=" + eventId);
        else
            Response.RedirectUser("/Scheduling/Event/Index?showUpcoming=true");
    }
    
}
