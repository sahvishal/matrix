using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallCenter.Domain;
using Falcon.App.Core.Communication.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.App.BasePageClass;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Extensions;
using Falcon.App.Lib;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Deprecated.Repository;

public partial class NewucCallCenterLeftPanel : BaseUserControl
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
    }

    private ProspectCustomer CurrentProspectCustomer
    {
        get
        {
            var prospectCustomerId = RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;

            if (prospectCustomerId > 0)
            {
                var prospectCustomerRepository = IoC.Resolve<IUniqueItemRepository<ProspectCustomer>>();
                return prospectCustomerRepository.GetById(Convert.ToInt64(prospectCustomerId));
            }
            return null;
        }

    }

    # region "Properties"

    //Customer Info visible property
    public bool CustomerInfoVisible
    {
        get
        {
            return spCustomerInfo.Visible;
        }
        set
        {
            spCustomerInfo.Visible = value;
        }
    }

    //Event Info Visible Property
    public bool EventInfoVisible
    {
        get
        {
            return spEventInfo.Visible;
        }
        set
        {
            spEventInfo.Visible = value;
        }
    }

    //Package Info Visible Property
    public bool PackageInfoVisible
    {
        get
        {
            return spPackageInfo.Visible;
        }
        set
        {
            spPackageInfo.Visible = value;
        }
    }

    //Customer Name
    public string CustomerName
    {
        get
        {
            return spCustName.InnerHtml;
        }
        set
        {
            spCustName.InnerHtml = value;
        }
    }

    //Customer Age
    public string CustomerAge
    {
        get
        {
            return spCustAge.InnerHtml;
        }
        set
        {
            spCustAge.InnerHtml = value;
        }
    }

    public string CustomerId_Old
    {
        get
        {
            return spCustomerID.InnerHtml;
        }
    }


    private long CustomerId
    {
        get
        {
            long customerId = 0;

            if (RegistrationFlow != null && RegistrationFlow.CustomerId > 0)
            {
                return RegistrationFlow.CustomerId;
            }
            if (customerId == 0 && Request.QueryString["CustomerID"] != null)
                customerId = Request.QueryString["CustomerID"].ToLong();

            return customerId;
        }

    }

    protected long EventId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.EventId : 0;
        }
    }

    //Customer Gender
    public string CustomerGender
    {
        get
        {
            return spCustGender.InnerHtml;
        }
        set
        {
            spCustGender.InnerHtml = value;
        }
    }

    //Customer DOB
    public string CustomerDOB
    {
        get
        {
            return spCustDOB.InnerHtml;
        }
        set
        {
            spCustDOB.InnerHtml = value;
        }
    }

    //EventName
    public string EventName
    {
        get
        {
            return spEventName.InnerHtml;
        }
        set
        {
            spEventName.InnerHtml = value;
        }
    }

    //EventDate
    public string EventDate
    {
        get
        {
            return spEventDate.InnerHtml;
        }
        set
        {
            spEventDate.InnerHtml = value;
        }
    }

    //package name
    public string PackageName
    {
        get
        {
            return spPackageName.InnerHtml;
        }
        set
        {
            spPackageName.InnerHtml = value;
        }
    }

    //appoint time
    public string AppointmentTime
    {
        get
        {
            return spAppointTime.InnerHtml;
        }
        set
        {
            spAppointTime.InnerHtml = value;
        }
    }

    protected long CallId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
        }
    }


    protected String FirstName
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["FirstName"])
                      ? string.Empty
                      : Request.QueryString["FirstName"];
        }
    }

    protected String LastName
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["LastName"])
                          ? string.Empty
                          : Request.QueryString["LastName"];
        }
    }

    protected String CallBackNumber
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["CallBackNo"])
                       ? string.Empty
                       : Request.QueryString["CallBackNo"];
        }
    }

    protected String Zip
    {
        get { return string.IsNullOrEmpty(Request.QueryString["Zip"]) ? string.Empty : Request.QueryString["Zip"]; }
    }



    # endregion
    private dynamic callDetailsModel = new ExpandoObject();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // format phone no.
            var commonCode = new CommonCode();
            bool setData = false;
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"].ToLower() == "no")
            {
                divAddNotes.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                if (CallId > 0)
                {
                    
                    ECall call = new CallCenterCallRepository().GetCallCenterEntity(CallId);
                    if (call.CallNotes != null && call.CallNotes.Count > 0 && call.CallNotes[0] != null)
                    {
                        txtNotes.Text = call.CallNotes[0].Notes;
                    }
                    spIncomingPhone.InnerText = callDetailsModel.IncomingPhone = commonCode.FormatPhoneNumberGet(call.IncomingPhoneLine);
                    spCallersPhone.InnerText = callDetailsModel.CallersPhone = commonCode.FormatPhoneNumberGet(call.CallersPhoneNumber);
                    spCallBackNumber.InnerText = callDetailsModel.CallBackNumber = commonCode.FormatPhoneNumberGet(call.CallBackNumber);
                    if (Session["SourceCode"] != null)
                        spSourceCode.InnerText = callDetailsModel.SourceCode = Session["SourceCode"].ToString();

                    spSearchCustomerID.InnerText = callDetailsModel.CalledCustomerId = call.CalledCustomerID > 0 ? call.CalledCustomerID.ToString() : "";

                    spCallInfo.Visible = true;
                    divCallDetail.Visible = true;

                    if (CurrentProspectCustomer != null)
                    {
                        var prospectCustomer = CurrentProspectCustomer;
                        callDetailsModel.Name = spName.InnerText = prospectCustomer.FirstName + " " + prospectCustomer.LastName;

                        if (prospectCustomer.Address != null && prospectCustomer.Address.ZipCode != null)
                            spZipCode.InnerText = callDetailsModel.Zip = prospectCustomer.Address.ZipCode.Zip;

                        spCallBackNumber.InnerText = callDetailsModel.CallBackPhoneNumber = prospectCustomer.CallBackPhoneNumber != null
                                                         ? commonCode.FormatPhoneNumberGet(
                                                             prospectCustomer.CallBackPhoneNumber.ToString())
                                                         : spCallBackNumber.InnerText;

                        setData = true;
                    }
                }
            }


            if (Request.QueryString["CustomerID"] != null)
            {
                var customerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
                SetCustomerandpackageDetails(customerId);
                setData = true;
            }
            else
            {
                if (CustomerId > 0)
                    setData = true;

                SetCustomerandpackageDetails(CustomerId);
            }

            if (!setData) SetNewCustomerData();
            LogAudit(ModelType.View, callDetailsModel,CustomerId);
        }

    }

    private void SetCustomerandpackageDetails(long customerId)
    {
        if (customerId > 0)
        {
            ICustomerRepository customerRepository = new CustomerRepository();

            var customer = customerRepository.GetCustomer(customerId);

            if (customer != null)
                SetCustomerData(customer);
        }

        if (EventId > 0)
        {
            SetEventData(EventId);
            if ((RegistrationFlow.PackageId > 0 || RegistrationFlow.TestIds != null) && !RegistrationFlow.AppointmentSlotIds.IsNullOrEmpty())
                SetPackageAndTestDetails(EventId);
        }
    }

    private void SetPackageAndTestDetails(long eventId)
    {
        var packageId = RegistrationFlow != null ? RegistrationFlow.PackageId : 0;

        //var testIds = RegistrationFlow != null && RegistrationFlow.TestIds != null ? RegistrationFlow.TestIds as List<long> : new List<long>();

        var testIds = RegistrationFlow != null && RegistrationFlow.AddOnTestIds != null ? RegistrationFlow.AddOnTestIds as List<long> : new List<long>();

        var packageRepository = IoC.Resolve<IEventPackageRepository>();
        var testRepository = IoC.Resolve<IEventTestRepository>();

        var package = packageId > 0 ? packageRepository.GetByEventAndPackageIds(eventId, packageId).Package : null;

        string packageAndTestNames = string.Empty;

        if (package != null && !package.Tests.IsNullOrEmpty())
        {
            packageAndTestNames = package.Name + ", ";
            //var packageTests = package.Tests.Select(t => t.Id);

            //if (testIds != null) testIds.RemoveAll(t => packageTests.Contains(t));
        }

        var tests = !testIds.IsNullOrEmpty() ? testRepository.GetByEventAndTestIds(eventId, testIds).Select(t => t.Test).ToArray() : null;

        packageAndTestNames += tests.IsNullOrEmpty()
                                   ? string.Empty
                                   : string.Join(", ", tests.Select(t => t.Name).ToArray());

        packageAndTestNames = tests.IsNullOrEmpty()
                                  ? packageAndTestNames.Remove(packageAndTestNames.LastIndexOf(","))
                                  : packageAndTestNames;

        if (!string.IsNullOrEmpty(packageAndTestNames))
        {
            spPackageName.InnerText = packageAndTestNames;

            var slotService = IoC.Resolve<IEventSchedulingSlotService>();
            if (RegistrationFlow != null  && !RegistrationFlow.AppointmentSlotIds.IsNullOrEmpty())
                spAppointTime.InnerHtml =
                    slotService.GetHeadSlotintheChain(RegistrationFlow.AppointmentSlotIds).StartTime.ToString("hh:mm tt");

            spPackageInfo.Visible = true;
        }
    }

    private void SetEventData(long eventId)
    {
        var eventService = IoC.Resolve<IEventService>();
        var eventHostViewData = eventService.GetById(eventId);

        if (eventHostViewData != null)
        {
            spEventName.InnerText = callDetailsModel.EventName = eventHostViewData.Name;
            spEventDate.InnerText = callDetailsModel.EventDate = eventHostViewData.EventDate.ToString("MM/dd/yyyy");

            spEventInfo.Visible = true;
            divDetail.Visible = true;
            var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
            var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(eventId);
            if (hospitalPartnerId > 0)
            {
                var organizationRepository = IoC.Resolve<IOrganizationRepository>();
                var hospitalPartner = organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                spHospitalPartnerName.InnerText = callDetailsModel.HospitalPartnerName = hospitalPartner.Name;
                spSponsorInfo.Visible = true;
            }
        }
    }

    private void SetCustomerData(Customer customer)
    {
        spCustomerID.InnerText = callDetailsModel.CustomerId = customer.CustomerId.ToString();
        spCustName.InnerText = callDetailsModel.Name = customer.Name.FullName;
        spCustEmail.InnerText = callDetailsModel.Email = customer.Email != null && !string.IsNullOrEmpty(customer.Email.ToString()) ? customer.Email.ToString() : "N/A";

        spCustAge.InnerText = callDetailsModel.Age = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.GetDetailAge() : string.Empty;

        spCustGender.InnerText = callDetailsModel.Gender = customer.Gender.ToString();
        spCustDOB.InnerText = callDetailsModel.DateOfBirth = customer.DateOfBirth.HasValue
                                  ? customer.DateOfBirth.Value.ToString("MM/dd/yyyy")
                                  : "N/A";


        spCustomerInfo.Visible = true;
    }


    private void SetNewCustomerData()
    {
        spName.InnerText = callDetailsModel.Name = FirstName + " " + LastName;

        spZipCode.InnerText = callDetailsModel.Zip = Zip;
        spCallBackNumber.InnerText = callDetailsModel.CallBackNumber = CallBackNumber;
        spCallInfo.Visible = true;
        divCallDetail.Visible = true;

        if (RegistrationFlow != null)
            spSourceCode.InnerText = RegistrationFlow.CallSourceCode;
    }

    protected void imgSaveNotes_Click(object sender, ImageClickEventArgs e)
    {
        //var objNotes = new ECallCenterNotes();
        //objNotes.CallID = CallId;
        //objNotes.Notes = txtNotes.Text;
        if (string.IsNullOrWhiteSpace(txtNotes.Text)) return;
        if (CallId > 0)
        {
            var callCenterRepository = IoC.Resolve<ICallCenterNotesRepository>();

            var callCenterNotes = new CallCenterNotes
            {
                CallId = CallId,
                Notes = txtNotes.Text,
                IsActive = true,
                NotesSequence = 1
            };

            callCenterRepository.Save(callCenterNotes);
        }

        if (CustomerId > 0)
        {
            var currentUser = IoC.Resolve<ISessionContext>().UserSession;
            var customerRegistrationNotes = new CustomerCallNotes
            {
                CustomerId = CustomerId,
                EventId =
                    EventId > 0 ? EventId : EventIdHiddenField.Value == "" || EventIdHiddenField.Value == "0" ? null : (long?)EventIdHiddenField.Value.ToLong(),
                Notes = txtNotes.Text,
                NotesType = CustomerRegistrationNotesType.AppointmentNote,
                DataRecorderMetaData = new DataRecorderMetaData
                {
                    DateCreated = DateTime.Now,
                    DataRecorderCreator = new OrganizationRoleUser(currentUser.CurrentOrganizationRole.OrganizationRoleUserId)
                }
            };

            var customerRegistrationNotesRepository = IoC.Resolve<IUniqueItemRepository<CustomerCallNotes>>();
            customerRegistrationNotesRepository.Save(customerRegistrationNotes);
        }
        dvNotesStatus.InnerText = "Notes added";

        if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
        {
            txtNotes.Text = "";
            dvNotesStatus.InnerText = "";
            divAddNotes.Style.Add(HtmlTextWriterStyle.Display, "none");

        }
    }

}
