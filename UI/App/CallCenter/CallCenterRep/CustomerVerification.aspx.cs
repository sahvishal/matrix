using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.CallQueues;
using Falcon.App.Core.CallQueues.Domain;
using Falcon.App.Core.CallQueues.Enum;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Deprecated;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Extensions;

public partial class App_CallCenter_CallCenterRep_CustomerVerification : Page
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
            return new ProspectCustomer()
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    CallBackPhoneNumber = new PhoneNumber() { Number = CallBackNumber },
                    Address = new Address() { ZipCode = new ZipCode() { Zip = Zip } },
                    Source = ProspectCustomerSource.CallCenter,
                    Tag = ProspectCustomerTag.CallCenterSignup,
                    TagUpdateDate = DateTime.Now
                };
        }
        set { RegistrationFlow.ProspectCustomerId = value.Id; }
    }

    protected long? CallId
    {
        get
        {
            long callId = 0;
            callId = RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            return callId > 0 ? (long?)callId : null;
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

    protected String CustomerId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["CustomerId"])
                       ? string.Empty
                       : Request.QueryString["CustomerId"];
        }
    }

    protected string MemberId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["MemberId"])
                       ? string.Empty
                       : Request.QueryString["MemberId"];
        }
    }

    protected string Hicn
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["Hicn"])
                       ? string.Empty
                       : Request.QueryString["Hicn"];
        }
    }

    protected string MbiNumber
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["MbiNumber"])
                       ? string.Empty
                       : Request.QueryString["MbiNumber"];
        }
    }

    protected string PhoneNumber
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["PhoneNumber"])
                       ? string.Empty
                       : Request.QueryString["PhoneNumber"];
        }
    }

    protected string EmailId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["EmailId"])
                       ? string.Empty
                       : Request.QueryString["EmailId"];
        }
    }


    private List<ECustomers> _customerDataZip;

    private List<ECustomers> _customerData;

    public OrganizationRoleUserModel CurrentOrganizationRole
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        }
    }

    private long CallCenterOrganizationId { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        RegistrationFlow.CanSaveConsentInfo = false;
        Page.Title = "Customer Verification";
        CallCenter_CallCenterMaster1 obj;
        obj = (CallCenter_CallCenterMaster1)this.Master;
        obj.SetTitle("Customer Verification");
        obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";

        obj.hideucsearch();

        CallCenterOrganizationId = 0;
        if (CurrentOrganizationRole.CheckRole((long)Roles.CallCenterRep))
        {
            CallCenterOrganizationId = CurrentOrganizationRole.OrganizationId;
        }
        if (!IsPostBack)
        {
            if (CallId != null)
                hfCallStartTime.Value = new CallCenterCallRepository().GetCallStarttime(CallId.Value);

            if (CallId != null && !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName) && !string.IsNullOrWhiteSpace(CallBackNumber))
            {
                IProspectCustomerRepository prospectCustomerRepository = new ProspectCustomerRepository();
                var listProspectCustomerViewData =
                    prospectCustomerRepository.GetProspectCustomersWithFiltersforCallCenterRep(FirstName, LastName, CallBackNumber.Replace("(", "").Replace(")", "").Replace("-", ""));
                if (listProspectCustomerViewData != null)
                {
                    if (listProspectCustomerViewData.Count > 10)
                    {
                        ProspectGridView.DataSource = listProspectCustomerViewData.GetRange(0, 10);
                        ProspectGridView.DataBind();
                        ProspectCustomerWarningContainerDiv.Style[HtmlTextWriterStyle.Display] = "block";
                    }
                    else
                    {
                        ProspectGridView.DataSource = listProspectCustomerViewData;
                        ProspectGridView.DataBind();
                    }
                    hfheader.Value = "divHeaderProspect";
                }
                else
                {
                    ProspectCustomerNoResultFoundContainerDiv.Style[HtmlTextWriterStyle.Display] = "block";
                    ProspectCustomerContainerDiv.Style[HtmlTextWriterStyle.Display] = "none";
                }
            }
            else
            {
                ProspectCustomerNoResultFoundContainerDiv.Style[HtmlTextWriterStyle.Display] = "block";
                ProspectCustomerContainerDiv.Style[HtmlTextWriterStyle.Display] = "none";
            }
            var masterDal = new MasterDAL();
            if (!String.IsNullOrWhiteSpace(Zip))
            {
                _customerDataZip = masterDal.SearchCustomersOnCall(FirstName.Replace("'", "''"), LastName.Replace("'", "''"), Zip, 1, CallBackNumber, CustomerId, MemberId, Hicn, PhoneNumber, EmailId, CallCenterOrganizationId, MbiNumber);
                if (_customerDataZip != null && _customerDataZip.Count > 0)
                {
                    grdCustomerListZIP.DataSource = _customerDataZip;
                    grdCustomerListZIP.DataBind();

                    pnlZIP.Enabled = true;

                    hfheader.Value = "divHeaderZIP";
                    divNoResultsMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divResultsMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "block");
                    if (_customerDataZip.Count > 20)
                    {
                        divMoreResultsMatchingZip.Visible = true;
                    }
                }
                else
                {
                    //pnlZIP.Enabled = false;
                    divNoResultsMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "block");
                    divResultsMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "none");

                    //hfheader.Value = "divHeaderOTHERS";
                }
            }
            else
            {
                //pnlZIP.Enabled = false;
                divNoResultsMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "block");
                divResultsMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "none");

                //hfheader.Value = "divHeaderOTHERS";
            }


            _customerData = masterDal.SearchCustomersOnCall(FirstName.Replace("'", "''"), LastName.Replace("'", "''"), Zip, 0, CallBackNumber, CustomerId, MemberId, Hicn, PhoneNumber, EmailId, CallCenterOrganizationId, MbiNumber);

            if (_customerData != null && _customerData.Count > 0)
            {
                divNoResultsWithoutMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "none");
                divResultsWithoutMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "block");
                grdCustomerList.DataSource = _customerData;
                grdCustomerList.DataBind();

                if (_customerData.Count > 20)
                {
                    divMoreResultsWithoutMatchingZip.Visible = true;
                }
                hfheader.Value = "divHeaderOTHERS";
            }
            else
            {
                divNoResultsWithoutMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "block");
                divResultsWithoutMatchingZip.Style.Add(HtmlTextWriterStyle.Display, "none");
                //pnlOTHERS.Enabled = false;
                //divResults.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (_customerDataZip != null && _customerDataZip.Count > 0)
                hfheader.Value = "divHeaderZIP";
            else if (_customerData != null && _customerData.Count > 0)
                hfheader.Value = "divHeaderOTHERS";

        }
        Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_tabSelection", "sel_caption('" + hfheader.Value + "');", true);
        switch (hfheader.Value)
        {
            case "divHeaderOTHERS":
                tbpnlContainer.ActiveTab = pnlOTHERS;
                break;
            case "divHeaderZIP":
                tbpnlContainer.ActiveTab = pnlZIP;
                break;
            case "divHeaderProspect":
                tbpnlContainer.ActiveTab = pnlProspect;
                break;

            default:
                return;
        }

        if (RegistrationFlow.CallQueueCustomerId > 0)
        {
            var callQueueCustomerRepository = IoC.Resolve<ICallQueueCustomerRepository>();
            var callQueueRepository = IoC.Resolve<ICallQueueRepository>();
            var callQueueCriteriaRepository = IoC.Resolve<ICallQueueCriteriaRepository>();

            var callQueueCustomer = callQueueCustomerRepository.GetById(RegistrationFlow.CallQueueCustomerId);
            var callQueue = callQueueRepository.GetById(callQueueCustomer.CallQueueId);
            CallQueueCriteria callQueueCriteria = null;
            if (callQueueCustomer.CallQueueCriteriaId.HasValue && callQueueCustomer.CallQueueCriteriaId.Value > 0)
                callQueueCriteria = callQueueCriteriaRepository.GetById(callQueueCustomer.CallQueueCriteriaId.Value);

            if (callQueue.ScriptId.HasValue && callQueue.ScriptId.Value > 0)
            {
                var scriptRepository = IoC.Resolve<IScriptRepository>();
                var script = scriptRepository.GetById(callQueue.ScriptId.Value);

                var scriptText = string.Empty;
                if (callQueueCriteria != null && callQueueCriteria.CriteriaId == (long)QueueCriteria.PhysicianPartner)
                {
                    var userSession = IoC.Resolve<ISessionContext>().UserSession;
                    var pcpRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();

                    var pcp = callQueueCustomer.CustomerId.HasValue ? pcpRepository.Get(callQueueCustomer.CustomerId.Value) : null;

                    if (pcp != null)
                        scriptText = "Hi, this is " + HttpUtility.HtmlEncode(userSession.FullName) + " calling on behalf of " + HttpUtility.HtmlEncode(pcp.Name.FullName) + " and Physician partner office. ";
                }
                ScriptTextDiv.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(scriptText + script.ScriptText, true);
            }
        }

    }

    protected void grdCustomerList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataTable dt = BindCustomerList(_customerData);
            DataRowView drv = dt.DefaultView[(grdCustomerList.PageSize * grdCustomerList.PageIndex) + e.Row.RowIndex];

            var aShow = (HtmlAnchor)e.Row.FindControl("aShow");

            var selectCustomerLink = (LinkButton)e.Row.FindControl("SelectCustomerLink");
            var selectDNCCustomerLink = (LinkButton)e.Row.FindControl("DNCSelectCustomerLink");

            var doNotContactInfoImage = (System.Web.UI.WebControls.Image)e.Row.FindControl("doNotContactInfoImage");
            var doNotMailInfoImage = (System.Web.UI.WebControls.Image)e.Row.FindControl("doNotMailInfoImage");

            var doNotContactReasonSpan = (Label)e.Row.FindControl("doNotContactReasonSpan");
            var doNotContactReasonNotesSpan = (Label)e.Row.FindControl("doNotContactReasonNotesSpan");

            long doNotContactReasonId = Convert.ToInt64(string.IsNullOrEmpty(drv["DoNotContactReasonId"].ToString()) ? "0" : drv["DoNotContactReasonId"].ToString());
            long doNotContactReasonNotesId = Convert.ToInt64(string.IsNullOrEmpty(drv["DoNotContactReasonNotesId"].ToString()) ? "0" : drv["DoNotContactReasonNotesId"].ToString());
            long doNotContactTypeId = Convert.ToInt64(string.IsNullOrEmpty(drv["DoNotContactTypeId"].ToString()) ? "0" : drv["DoNotContactTypeId"].ToString());

            if (doNotContactReasonId > 0)
            {
                var item = (DoNotContactReason)doNotContactReasonId;
                doNotContactReasonSpan.Text = item.GetDescription();

                selectDNCCustomerLink.Visible = true;
                selectCustomerLink.Visible = false;

                if (doNotContactTypeId == (long)DoNotContactType.DoNotMail)
                {
                    doNotMailInfoImage.Visible = true;
                    doNotContactInfoImage.Visible = false;
                }
                else
                {
                    doNotMailInfoImage.Visible = false;
                    doNotContactInfoImage.Visible = true;
                }

                if (doNotContactReasonNotesId > 0)
                {
                    var notes = IoC.Resolve<INotesRepository>().Get(doNotContactReasonNotesId);
                    doNotContactReasonNotesSpan.Text = notes.Text;
                }
            }
            else
            {
                selectDNCCustomerLink.Visible = false;
                selectCustomerLink.Visible = true;
            }



            if (drv["HintQuestion"].ToString() == "" || drv["HintAnswer"].ToString() == "")
            {
                aShow.InnerText = "-NA-";
                aShow.HRef = "";
            }
            else
                aShow.Attributes.Add("onclick", "ShowHintQuesAns('" + drv["HintQuestion"].ToString().Replace("'", "*") + "','" + drv["HintAnswer"].ToString().Replace("'", "*") + "');");

            if (drv["IsEligible"] != null && drv["IsEligible"].ToString() == "False")
            {
                selectCustomerLink.Attributes.Add("onclick", "return AlertInEligibleCustomer()");
            }
        }
    }

    protected void grdCustomerList_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCustomerList.PageIndex = e.NewPageIndex;

        BindCustomerList(_customerData);
        grdCustomerList.DataSource = _customerData;
        grdCustomerList.DataBind();
    }

    protected void ibtnskiptocustomer_Click(object sender, ImageClickEventArgs e)
    {
        if (RegistrationFlow != null)
            RegistrationFlow.CustomerId = 0;
        SaveProspectCustomer();
        if (CurrentProspectCustomer.Id > 0)
            Response.RedirectUser("CustomerOptions.aspx?guid=" + GuId);
        else
        {
            Response.RedirectUser("CustomerOptions.aspx?FirstName=" + FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&guid=" + GuId);//+ (string.IsNullOrEmpty(CustomerId) ? "" : "&CustomerId=" + CustomerId)
        }
    }

    private void SaveProspectCustomer()
    {

        if (CurrentProspectCustomer != null && !string.IsNullOrEmpty(CurrentProspectCustomer.FirstName) && !string.IsNullOrEmpty(CurrentProspectCustomer.LastName) && CurrentProspectCustomer.CallBackPhoneNumber != null && !string.IsNullOrEmpty(CurrentProspectCustomer.CallBackPhoneNumber.ToString()) && CurrentProspectCustomer.CallBackPhoneNumber.ToString() != "(___)-___-____")
        {
            IUniqueItemRepository<ProspectCustomer> uniqueItemRepository = new ProspectCustomerRepository();
            var prospectCustomer = uniqueItemRepository.Save(CurrentProspectCustomer);
            CurrentProspectCustomer = prospectCustomer;

            if (CallId != null && CallId > 0 && prospectCustomer.Id > 0)
            {
                var callWizardService = new CallCenterCallWizardService();
                callWizardService.BindCurrentCallToProspectCustomer(CallId.Value, prospectCustomer.Id, IoC.Resolve<ISessionContext>().UserSession.UserId);
            }
        }
    }

    protected void grdCustomerListZIP_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = BindZip(_customerDataZip);
            DataRowView drv = dt.DefaultView[(grdCustomerList.PageSize * grdCustomerList.PageIndex) + e.Row.RowIndex];

            var selectDNCCustomerLink = (LinkButton)e.Row.FindControl("DNCSelectCustomerLink");
            var selectCustomerLink = (LinkButton)e.Row.FindControl("SelectCustomerLink");

            var doNotContactInfoImage = (System.Web.UI.WebControls.Image)e.Row.FindControl("doNotContactInfoImage");
            var doNotMailInfoImage = (System.Web.UI.WebControls.Image)e.Row.FindControl("doNotMailInfoImage");

            var doNotContactReasonSpan = (Label)e.Row.FindControl("doNotContactReasonSpan");
            var doNotContactReasonNotesSpan = (Label)e.Row.FindControl("doNotContactReasonNotesSpan");

            long doNotContactReasonId = Convert.ToInt64(string.IsNullOrEmpty(drv["DoNotContactReasonId"].ToString()) ? "0" : drv["DoNotContactReasonId"].ToString());
            long doNotContactReasonNotesId = Convert.ToInt64(string.IsNullOrEmpty(drv["DoNotContactReasonNotesId"].ToString()) ? "0" : drv["DoNotContactReasonNotesId"].ToString());
            long doNotContactTypeId = Convert.ToInt64(string.IsNullOrEmpty(drv["DoNotContactTypeId"].ToString()) ? "0" : drv["DoNotContactTypeId"].ToString());

            if (doNotContactReasonId > 0)
            {
                var item = (DoNotContactReason)doNotContactReasonId;
                doNotContactReasonSpan.Text = item.GetDescription();

                selectDNCCustomerLink.Visible = true;
                selectCustomerLink.Visible = false;

                if (doNotContactTypeId == (long)DoNotContactType.DoNotMail)
                {
                    doNotMailInfoImage.Visible = true;
                    doNotContactInfoImage.Visible = false;
                }
                else
                {
                    doNotMailInfoImage.Visible = false;
                    doNotContactInfoImage.Visible = true;
                }

                if (doNotContactReasonNotesId > 0)
                {
                    var notes = IoC.Resolve<INotesRepository>().Get(doNotContactReasonNotesId);
                    doNotContactReasonNotesSpan.Text = notes.Text;
                }
            }
            else
            {
                selectDNCCustomerLink.Visible = false;
                selectCustomerLink.Visible = true;
            }


            var aShow1 = (HtmlAnchor)e.Row.FindControl("aShow1");
            if (drv["HintQuestion"].ToString() == "" || drv["HintAnswer"].ToString() == "")
            {
                aShow1.InnerText = "-NA-";
                aShow1.HRef = "";
            }
            else
                aShow1.Attributes.Add("onclick", "ShowHintQuesAns('" + drv["HintQuestion"].ToString().Replace("'", "*") + "','" + drv["HintAnswer"].ToString().Replace("'", "*") + "');");

            if (drv["IsEligible"] != null && drv["IsEligible"].ToString() == "False")
            {
                selectCustomerLink.Attributes.Add("onclick", "return AlertInEligibleCustomer()");
            }
        }
    }

    protected void grdCustomerListZIP_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdCustomerListZIP.PageIndex = e.NewPageIndex;
        BindZip(_customerDataZip);
        grdCustomerListZIP.DataSource = _customerDataZip;
        grdCustomerListZIP.DataBind();
    }

    protected void ibtnSearchAgain_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["Type"] != null && Request.QueryString["Type"].ToString() == "RegExistCustForSameEvent")
        {
            Response.RedirectUser("/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?Type=RegExistCustForSameEvent&guid=" + GuId);
        }
        else
            Response.RedirectUser("/App/CallCenter/CallCenterRep/BasicCallInfo.aspx?guid=" + GuId);
    }

    protected void SelectPropsectCustomerLink_Click(object sender, EventArgs e)
    {
        long prospectCustomerId = Convert.ToInt64(((LinkButton)sender).CommandArgument);

        IProspectCustomerRepository prospectCustomerRepository = new ProspectCustomerRepository();
        var prospectCustomer = prospectCustomerRepository.GetProspectCustomer(prospectCustomerId);
        CurrentProspectCustomer = prospectCustomer;

        if (CallId != null && CallId > 0)
        {
            var callWizardService = new CallCenterCallWizardService();
            callWizardService.BindCurrentCallToProspectCustomer(CallId.Value, prospectCustomer.Id, IoC.Resolve<ISessionContext>().UserSession.UserId);
        }

        Response.RedirectUser("CustomerOptions.aspx?guid=" + GuId);
    }

    private DataTable BindZip(IList<ECustomers> customerZipData)
    {

        if (customerZipData == null)
        {
            var masterDal = new MasterDAL();
            _customerDataZip = masterDal.SearchCustomersOnCall(FirstName, LastName, Zip, 1, CallBackNumber, CustomerId, MemberId, Hicn, PhoneNumber, EmailId, CallCenterOrganizationId, MbiNumber);
        }

        var dtcustomerlist = new DataTable("CustomerList");
        dtcustomerlist.Columns.Add("CustomerID");
        dtcustomerlist.Columns.Add("CustomerName");
        dtcustomerlist.Columns.Add("Address");
        dtcustomerlist.Columns.Add("State");
        dtcustomerlist.Columns.Add("City");
        dtcustomerlist.Columns.Add("Zip");
        dtcustomerlist.Columns.Add("DOB");
        dtcustomerlist.Columns.Add("HintQuestion");
        dtcustomerlist.Columns.Add("HintAnswer");
        dtcustomerlist.Columns.Add("UserId");
        dtcustomerlist.Columns.Add("MemberId");
        dtcustomerlist.Columns.Add("Hicn");
        dtcustomerlist.Columns.Add("Tag");
        dtcustomerlist.Columns.Add("CustomTag");
        dtcustomerlist.Columns.Add("Copay");
        dtcustomerlist.Columns.Add("MedicarePlanName");
        dtcustomerlist.Columns.Add("IsEligible");
        dtcustomerlist.Columns.Add("PreApprovedTest");
        dtcustomerlist.Columns.Add("DoNotContactReasonId");
        dtcustomerlist.Columns.Add("DoNotContactReasonNotesId");
        dtcustomerlist.Columns.Add("DoNotContactTypeId");
        if (customerZipData == null || customerZipData.Count <= 0)
        {
            return null;
        }


        for (int icount = 0; icount < customerZipData.Count; icount++)
        {
            string address = CommonCode.AddressMultiLine(customerZipData[icount].User.HomeAddress.Address1,
                                                         customerZipData[icount].User.HomeAddress.Address2,
                                                         customerZipData[icount].User.HomeAddress.City,
                                                         customerZipData[icount].User.HomeAddress.State,
                                                         customerZipData[icount].User.HomeAddress.Zip);

            string customername = customerZipData[icount].User.FirstName;
            if (customerZipData[icount].User.MiddleName.Length > 0)
            {
                customername += " " + customerZipData[icount].User.MiddleName;
            }
            customername += " " + customerZipData[icount].User.LastName;
            string dob = "-N/A-";
            if (customerZipData[icount].User.DOB.Length > 0)
            {
                dob = Convert.ToDateTime(customerZipData[icount].User.DOB).ToString("MM/dd/yyyy");
            }

            var customerId = customerZipData[icount].CustomerID;


            dtcustomerlist.Rows.Add(new object[]
                                            {
                                                customerId, customername, address,
                                                customerZipData[icount].User.HomeAddress.State,
                                                customerZipData[icount].User.HomeAddress.City,
                                                customerZipData[icount].User.HomeAddress.Zip, dob,
                                                customerZipData[icount].User.Question, customerZipData[icount].User.Answer,customerZipData[icount].User.UserID
                                                ,customerZipData[icount].MemberId,customerZipData[icount].Hicn,customerZipData[icount].Tag, string.IsNullOrEmpty(customerZipData[icount].CustomTag) ? "N/A" : customerZipData[icount].CustomTag,
                                                customerZipData[icount].Copay,customerZipData[icount].MedicarePlanName,customerZipData[icount].IsEligible,
                                                string.IsNullOrEmpty(customerZipData[icount].PreApprovedTest)? "N/A": customerZipData[icount].PreApprovedTest,
                                                  customerZipData[icount].DoNotContactReasonId,
                                                customerZipData[icount].DoNotContactReasonNotesId,
                                                customerZipData[icount].DoNotContactTypeId
                                            });
            //if (icount == 19)
            //{
            //    break;
            //}
        }
        var dataView = new DataView { Table = dtcustomerlist };
        return dataView.ToTable(true, new[]
                                              {
                                                  "CustomerID", "CustomerName", "Address", "State", "City", "Zip", "DOB",
                                                  "HintQuestion", "HintAnswer","UserId", "MemberId", "Hicn","Tag","CustomTag","Copay","MedicarePlanName","IsEligible", "PreApprovedTest","DoNotContactReasonId","DoNotContactReasonNotesId","DoNotContactTypeId"
                                              });

    }

    private DataTable BindCustomerList(IList<ECustomers> customerData)
    {
        if (customerData == null)
        {
            var masterDal = new MasterDAL();
            _customerData = masterDal.SearchCustomersOnCall(FirstName, LastName, Zip, 0, CallBackNumber, CustomerId, MemberId, Hicn, PhoneNumber, EmailId, CallCenterOrganizationId, MbiNumber);
        }

        var dtcustomerlist = new DataTable("CustomerList");
        dtcustomerlist.Columns.Add("CustomerID");
        dtcustomerlist.Columns.Add("CustomerName");
        dtcustomerlist.Columns.Add("Address");
        dtcustomerlist.Columns.Add("State");
        dtcustomerlist.Columns.Add("City");
        dtcustomerlist.Columns.Add("Zip");
        dtcustomerlist.Columns.Add("DOB");
        dtcustomerlist.Columns.Add("HintQuestion");
        dtcustomerlist.Columns.Add("HintAnswer");
        dtcustomerlist.Columns.Add("UserId");
        dtcustomerlist.Columns.Add("MemberId");
        dtcustomerlist.Columns.Add("Hicn");
        dtcustomerlist.Columns.Add("Tag");
        dtcustomerlist.Columns.Add("CustomTag");
        dtcustomerlist.Columns.Add("Copay");
        dtcustomerlist.Columns.Add("MedicarePlanName");
        dtcustomerlist.Columns.Add("IsEligible");
        dtcustomerlist.Columns.Add("PreApprovedTest");
        dtcustomerlist.Columns.Add("DoNotContactReasonId");
        dtcustomerlist.Columns.Add("DoNotContactReasonNotesId");
        dtcustomerlist.Columns.Add("DoNotContactTypeId");
        if (customerData == null || customerData.Count <= 0)
        {
            return null;
        }

        for (int icount = 0; icount < customerData.Count; icount++)
        {
            string address = CommonCode.AddressMultiLine(customerData[icount].User.HomeAddress.Address1,
                                                         customerData[icount].User.HomeAddress.Address2,
                                                         customerData[icount].User.HomeAddress.City,
                                                         customerData[icount].User.HomeAddress.State,
                                                         customerData[icount].User.HomeAddress.Zip);

            string customername = customerData[icount].User.FirstName;
            if (customerData[icount].User.MiddleName.Length > 0)
            {
                customername += " " + customerData[icount].User.MiddleName;
            }
            customername += " " + customerData[icount].User.LastName;
            string dob = "-N/A-";
            if (customerData[icount].User.DOB.Length > 0)
            {
                dob = Convert.ToDateTime(customerData[icount].User.DOB).ToString("MM/dd/yyyy");
            }

            dtcustomerlist.Rows.Add(new object[]
                                            {
                                                customerData[icount].CustomerID, customername, address,
                                                customerData[icount].User.HomeAddress.State,
                                                customerData[icount].User.HomeAddress.City,
                                                customerData[icount].User.HomeAddress.Zip, dob,
                                                customerData[icount].User.Question, customerData[icount].User.Answer,customerData[icount].User.UserID
                                                ,customerData[icount].MemberId,customerData[icount].Hicn,customerData[icount].Tag,string.IsNullOrEmpty(customerData[icount].CustomTag) ? "N/A" : customerData[icount].CustomTag,
                                                customerData[icount].Copay,customerData[icount].MedicarePlanName,customerData[icount].IsEligible,
                                                string.IsNullOrEmpty(customerData[icount].PreApprovedTest)? "N/A": customerData[icount].PreApprovedTest,
                                                customerData[icount].DoNotContactReasonId,
                                                customerData[icount].DoNotContactReasonNotesId,
                                                customerData[icount].DoNotContactTypeId,
                                            });
            //if (icount == 19)
            //{
            //    break;
            //}
        }
        var dataView = new DataView { Table = dtcustomerlist };
        DataTable dt = dataView.ToTable(true, new[]
                                                      {
                                                          "CustomerID", "CustomerName", "Address", "State", "City","Zip", "DOB",
                                                          "HintQuestion", "HintAnswer","UserId", "MemberId", "Hicn", "Tag","CustomTag","Copay","MedicarePlanName","IsEligible", "PreApprovedTest","DoNotContactReasonId","DoNotContactReasonNotesId","DoNotContactTypeId"
                                                      });
        return dt;

    }

    protected void SelectCustomerLink_Click(object sender, EventArgs e)
    {
        var commandArg = ((LinkButton)sender).CommandArgument.Split(',');
        long customerId = 0;
        long.TryParse(commandArg[0], out customerId);
        if (customerId > 0)
        {
            if (CallId.HasValue && CallId.Value > 0)
            {
                var customerRepository = IoC.Resolve<ICustomerRepository>();
                var customer = customerRepository.GetCustomer(customerId);

                if (!string.IsNullOrEmpty(customer.Tag))
                {
                    var callRepository = IoC.Resolve<CallCenterCallRepository>();
                    var accountRepository = IoC.Resolve<ICorporateAccountRepository>();
                    var account = accountRepository.GetByTag(customer.Tag);

                    var call = callRepository.GetById(CallId.Value);
                    call.HealthPlanId = account.Id;
                    callRepository.Save(call);
                }
            }

            if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "RegExistCustForSameEvent")
                Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerID=" + customerId + "&Type=RegExistCustForSameEvent&guid=" + GuId);
            else
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CustomerOptions.aspx?CustomerID=" + customerId + "&guid=" + GuId);
        }
        else
        {
            long userId = 0;
            long.TryParse(commandArg[1], out userId);
            var userRepository = IoC.Resolve<IUserRepository<Customer>>();
            var customer = userRepository.GetUser(userId);
            var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
            var userLogin = userLoginRepository.GetByUserId(userId);
            customer.UserLogin = userLogin;
            customer.AddedByRoleId = (long)Roles.CallCenterRep;
            var customerService = IoC.Resolve<ICustomerService>();
            var userSession = IoC.Resolve<ISessionContext>().UserSession;

            customerService.SaveCustomer(customer, userSession.CurrentOrganizationRole.OrganizationRoleUserId);
            customerId = customer.CustomerId;
            if (Request.QueryString["Type"] != null && Request.QueryString["Type"] == "RegExistCustForSameEvent")
                Response.RedirectUser("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerID=" + customerId + "&Type=RegExistCustForSameEvent&guid=" + GuId);
            else
                Response.RedirectUser("/App/CallCenter/CallCenterRep/CustomerOptions.aspx?CustomerID=" + customerId + "&guid=" + GuId);
        }
    }

    protected void DNCSelectCustomerLink_Click(object sender, EventArgs e)
    {
        var commandArg = ((LinkButton)sender).CommandArgument;
        long customerId = 0;
        long.TryParse(commandArg, out customerId);
        Response.RedirectUser("CallCenterRepCustomerDetails.aspx?CustomerID=" + customerId + "&guid=" + GuId);
    }

}
