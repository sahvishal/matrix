using System;
using System.Dynamic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing;
using Falcon.App.Core.Marketing.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using Falcon.App.Core.Geo;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.Core.Audit.Enum;
using Falcon.App.Core.Interfaces;
using Falcon.App.UI.Extentions;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.UI;
using Falcon.App.UI.HtmlHelpers;


public partial class App_UCCommon_UCEditCustomer : BaseUserControl
{
    private dynamic customerLogEditModel = new ExpandoObject();
    private string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
        }
    }

    private long m_userid;

    public long UserID
    {
        get
        {
            return m_userid;
        }
        set
        {
            m_userid = value;
            GetDropDownInfo();
            GetCustomerData();

            LogAudit(ModelType.View, customerLogEditModel, CustomerId);
        }
    }

    public long CustomerId
    {
        get
        {
            long customerId = 0;
            if (ViewState["CustomerId"] != null)
            {
                long.TryParse(ViewState["CustomerId"].ToString(), out customerId);
            }
            return customerId;
        }
        set { ViewState["CustomerId"] = value; }
    }
    protected bool EnableSmsNotification
    {
        get
        {
            var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
            return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EnableSmsNotification));
        }
    }

    protected bool IsRoleCallCenterAgentOrTechnician
    {
        get
        {
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            return (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.Technician));
        }
    }

    protected bool EnableVoiceMailNotification
    {
        get
        {
            var configurationSettingRe = IoC.Resolve<IConfigurationSettingRepository>();
            return Convert.ToBoolean(configurationSettingRe.GetConfigurationValue(ConfigurationSettingName.EnableVoiceMailNotification));
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.UrlReferrer != null)
                ViewState["RedirectSource"] = Request.UrlReferrer.PathAndQuery;

            //   rlstcntmethod.Attributes.Add("onClick", "CheckContactMethod();");
            if (Request.QueryString["Master"] != null)
            {
                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferedURL"] = Request.QueryString["Master"].Equals("EventCustomer") ? Request.UrlReferrer.AbsolutePath : Request.UrlReferrer.PathAndQuery;
                }
            }

            if (Request.QueryString["OpenAsPopUp"] != null)
                ViewState["OpenAsPopUp"] = true;

        }
        chkPCPDetails.Attributes.Add("onClick", "HandlePCPPanel();");
        Page.ClientScript.RegisterStartupScript(typeof(string), "jscode", " HandlePCPPanel(); ", true);

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        if (currentOrgRole.CheckRole((long)Roles.CallCenterRep) || currentOrgRole.CheckRole((long)Roles.Technician) || currentOrgRole.CheckRole((long)Roles.NursePractitioner))
        {
            MarketingSourceDropDown.Enabled = false;
        }
    }

    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        if (UpdateCustomerInfo())
        {
            if (ViewState["OpenAsPopUp"] != null)
            {
                if (Request.QueryString["ReloadParent"] != null)
                {
                    var customerRepository = IoC.Resolve<ICustomerRepository>();
                    var customer = customerRepository.GetCustomer(CustomerId);

                    var editModel = AutoMapper.Mapper.Map<User, UserEditModel>(customer);
                    var customerModel = AutoMapper.Mapper.Map<Customer, CustomerEditModel>(customer);

                    editModel.CustomerProfile = customerModel;

                    var st = new StringBuilder();
                    var js = new JavaScriptSerializer();
                    js.Serialize(editModel, st);

                    Page.ClientScript.RegisterStartupScript(typeof(string), "jsclose",
                                                                 "alert('Customer Updated!'); window.close(); parent.opener.ReloadCustomer(" +
                                                                 st + ");", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(typeof(string), "jsclose", "alert('Customer Updated!'); window.close();", true);
                }
                return;
            }

            if (Request.QueryString["Master"] != null)
            {
                string redirecturl = ViewState["ReferedURL"].ToString();
                if (Session["ParameterString"] != null && Request.QueryString["Master"].Equals("EventCustomer"))
                {
                    redirecturl = ViewState["ReferedURL"].ToString();
                    if (redirecturl.IndexOf("?") >= 0)
                        redirecturl += "&" + Convert.ToString(Session["ParameterString"]);
                    else
                        redirecturl += "?" + Convert.ToString(Session["ParameterString"]);
                }
                Response.RedirectUser(redirecturl);
            }
            else
            {
                var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
                if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    if (ViewState["RedirectSource"] != null)
                    {
                        if (ViewState["RedirectSource"].ToString().IndexOf("?") > 0)
                            Response.RedirectUser(ViewState["RedirectSource"] + "&EventID=" + Request.QueryString["EventID"]);
                        else
                            Response.RedirectUser(ViewState["RedirectSource"] + "?EventID=" + Request.QueryString["EventID"]);

                    }
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Action=Edit"));
                }
                else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Action=Edit"));
                }
                else if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    if (Request.QueryString["CustomerID"] != null && Request.QueryString["EventID"] != null)
                    {
                        Response.RedirectUser(ResolveUrl("/App/Franchisor/EventCustomerResult.aspx?EventID=" + Request.QueryString["EventID"]));
                    }
                    else
                    {
                        Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Action=Edit" + "&guid=" + GuId));
                    }

                }
                else if (currentOrgRole.CheckRole((long)Roles.CallCenterRep))
                {
                    if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                    {
                        Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Action=Edit&Call=No" + "&guid=" + GuId));
                    }
                    else
                    {
                        Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Action=Edit" + "&guid=" + GuId));
                    }
                }
                else if (currentOrgRole.CheckRole((long)Roles.Technician) || currentOrgRole.CheckRole((long)Roles.NursePractitioner))
                {
                    if (Request.QueryString["CustomerID"] != null && Request.QueryString["EventID"] != null)
                    {
                        Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianEventCustomerResult.aspx?EventID=" + Request.QueryString["EventID"]));
                    }
                    else
                    {
                        Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Action=Edit" + "&guid=" + GuId));
                    }
                }
            }
        }
    }

    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["OpenAsPopUp"] != null)
        {
            Page.ClientScript.RegisterStartupScript(typeof(string), "jsclose", "window.close();", true);
            return;
        }

        if (Request.QueryString["Master"] != null)
        {
            string redirecturl = ViewState["ReferedURL"].ToString();
            if (Session["ParameterString"] != null && Request.QueryString["Master"].Equals("EventCustomer"))
            {
                redirecturl = ViewState["ReferedURL"].ToString();
                if (redirecturl.IndexOf("?") >= 0)
                    redirecturl += "&" + Convert.ToString(Session["ParameterString"]);
                else
                    redirecturl += "?" + Convert.ToString(Session["ParameterString"]);
            }
            Response.RedirectUser(redirecturl);

        }
        else
        {
            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            if (currentOrgRole.CheckRole((long)Roles.FranchiseeAdmin))
            {
                if (ViewState["RedirectSource"] != null)
                {
                    if (ViewState["RedirectSource"].ToString().IndexOf("?") > 0)
                    {
                        if (Request.QueryString["EventID"] != null)
                            Response.RedirectUser(ViewState["RedirectSource"] + "&EventID=" + Request.QueryString["EventID"]);
                        else
                            Response.RedirectUser(ViewState["RedirectSource"].ToString());
                    }
                    else
                    {
                        if (Request.QueryString["EventID"] != null)
                            Response.RedirectUser(ViewState["RedirectSource"] + "?EventID=" + Request.QueryString["EventID"]);
                        else
                            Response.RedirectUser(ViewState["RedirectSource"].ToString());
                    }
                }
                Response.RedirectUser(ResolveUrl("/App/Franchisee/FranchiseeCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"]));
            }
            else if (currentOrgRole.CheckRole((long)Roles.SalesRep))
            {
                Response.RedirectUser(ResolveUrl("/App/Franchisee/SalesRep/SalesRepCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"]));
            }
            else if (currentOrgRole.CheckRole((long)Roles.FranchisorAdmin))
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["EventID"] != null)
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisor/EventCustomerResult.aspx?EventID=" + Request.QueryString["EventID"]));
                }
                else
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId));
                }
            }
            else if (currentOrgRole.CheckRole((long)Roles.CallCenterRep))
            {
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Call=No" + "&guid=" + GuId));
                }
                else
                {
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/CallCenterRepCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId));
                }
            }
            else if (currentOrgRole.CheckRole((long)Roles.Technician) || currentOrgRole.CheckRole((long)Roles.NursePractitioner))
            {
                if (Request.QueryString["CustomerID"] != null && Request.QueryString["EventID"] != null)
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianEventCustomerResult.aspx?EventID=" + Request.QueryString["EventID"] + "&guid=" + GuId));
                }
                else
                {
                    Response.RedirectUser(ResolveUrl("/App/Franchisee/Technician/TechnicianCustomerDetails.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&guid=" + GuId));
                }
            }
        }
    }

    private void GetDropDownInfo()
    {
        ddlrace.Items.Clear();
        ddlrace.Items.Add(new ListItem("Select Race", "0"));
        ddlrace.Items.Add(new ListItem(Race.Caucasian.ToString(), Convert.ToString((short)Race.Caucasian)));
        ddlrace.Items.Add(new ListItem(Race.AfricanAmerican.ToString(), Convert.ToString((short)Race.AfricanAmerican)));
        ddlrace.Items.Add(new ListItem(Race.Hispanic.ToString(), Convert.ToString((short)Race.Hispanic)));
        ddlrace.Items.Add(new ListItem(Race.Asian.ToString(), Convert.ToString((short)Race.Asian)));
        ddlrace.Items.Add(new ListItem(Race.NativeAmerican.ToString(), Convert.ToString((short)Race.NativeAmerican)));
        ddlrace.Items.Add(new ListItem(Race.Latino.ToString(), Convert.ToString((short)Race.Latino)));
        ddlrace.Items.Add(new ListItem(Race.DeclinesToReport.GetDescription(), Convert.ToString((short)Race.DeclinesToReport)));
        ddlrace.Items.Add(new ListItem(Race.Other.ToString(), Convert.ToString((short)Race.Other)));

        var countryRepository = IoC.Resolve<ICountryRepository>();
        ddlCountry.DataSource = countryRepository.GetAll();
        ddlCountry.DataTextField = "Name";
        ddlCountry.DataValueField = "Id";
        ddlCountry.DataBind();
        //ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
        ddlCountry.Items[0].Selected = true;

        var marketingSourceService = IoC.Resolve<IMarketingSourceService>();
        var marketingSources = marketingSourceService.FetchMarketingSourceByZip("");
        MarketingSourceDropDown.DataSource = marketingSources;
        MarketingSourceDropDown.DataBind();
        MarketingSourceDropDown.Items.Insert(0, new ListItem("", ""));

        var nameValuePairs = DoNotContactReason.PassedAway.GetNameValuePairs();
        nameValuePairs = nameValuePairs.Where(x => x.FirstValue != (int)DoNotContactReason.Other).ToList();
        nameValuePairs.Add(new OrderedPair<int, string>((int)DoNotContactReason.Other, DoNotContactReason.Other.GetDescription()));
        ReasonDoNotContactDropdown.DataTextField = "SecondValue";
        ReasonDoNotContactDropdown.DataValueField = "FirstValue";
        ReasonDoNotContactDropdown.DataSource = nameValuePairs;
        ReasonDoNotContactDropdown.DataBind();
        ReasonDoNotContactDropdown.Items.Insert(0, new ListItem("-- Reason --", "0"));

        nameValuePairs = DoNotContactType.DoNotContact.GetNameValuePairs();
        TypeDoNotContactDropdown.DataTextField = "SecondValue";
        TypeDoNotContactDropdown.DataValueField = "FirstValue";
        TypeDoNotContactDropdown.DataSource = nameValuePairs;
        TypeDoNotContactDropdown.DataBind();
        TypeDoNotContactDropdown.Items.Insert(0, new ListItem("-- Type --", "0"));

        BestTimeToCallDropdown.Items.Clear();
        var bestTimeToCallTypes = BestTimeToCall.Morning.GetNameValuePairs();
        BestTimeToCallDropdown.DataSource = bestTimeToCallTypes;
        BestTimeToCallDropdown.DataTextField = "SecondValue";
        BestTimeToCallDropdown.DataValueField = "FirstValue";
        BestTimeToCallDropdown.DataBind();
        BestTimeToCallDropdown.Items.Insert(0, (new ListItem("--Select--", "0")));

        //CustomerTagDropdown.Items.Clear();
        //var customerTags = CustomerTag.PhysicianPartner.GetNameValuePairs();
        //CustomerTagDropdown.DataSource = customerTags;
        //CustomerTagDropdown.DataTextField = "SecondValue";
        //CustomerTagDropdown.DataValueField = "FirstValue";
        //CustomerTagDropdown.DataBind();
        //CustomerTagDropdown.Items.Insert(0, (new ListItem("--Select--", "0")));

        ddlIsEligible.Items.Clear();
        ddlIsEligible.Items.Add(new ListItem("Select", "-1"));
        ddlIsEligible.Items.Add(new ListItem(EligibleStatus.Yes.ToString(), Convert.ToString((short)EligibleStatus.Yes)));
        ddlIsEligible.Items.Add(new ListItem(EligibleStatus.No.ToString(), Convert.ToString((short)EligibleStatus.No)));

        ddActivity.Items.Clear();
        //var uploadActivityTypes = UploadActivityType.OnlyMail.GetNameValuePairs();
        var activityTypeRepository = IoC.Resolve<IActivityTypeRepository>();
        var uploadActivityTypes = activityTypeRepository.GetAll();
        ddActivity.DataSource = uploadActivityTypes;
        ddActivity.DataTextField = "Name";
        ddActivity.DataValueField = "Id";
        ddActivity.DataBind();
        ddActivity.Items.Insert(0, (new ListItem("--Select--", "0")));

        PreferredLanguageDropDown.Items.Clear();
        var languageRepository = IoC.Resolve<ILanguageRepository>();
        var languages = languageRepository.GetAll().OrderBy(x => x.Name);
        PreferredLanguageDropDown.DataSource = languages;
        PreferredLanguageDropDown.DataTextField = "Name";
        PreferredLanguageDropDown.DataValueField = "Id";
        PreferredLanguageDropDown.DataBind();
        PreferredLanguageDropDown.Items.Insert(0, (new ListItem("--Select--", "0")));
        PreferredLanguageDropDown.Items[0].Selected = true;

        ddlPreferredContactType.Items.Clear();
        var lookupReporsitory = IoC.Resolve<ILookupRepository>();
        var preferredContactTypes = lookupReporsitory.GetByLookupId((long)PreferredContactType.Email);
        ddlPreferredContactType.DataSource = preferredContactTypes.OrderBy(x => x.DisplayName);
        ddlPreferredContactType.DataTextField = "DisplayName";
        ddlPreferredContactType.DataValueField = "Id";
        ddlPreferredContactType.DataBind();
        ddlPreferredContactType.Items.Insert(0, new ListItem("--Select--", "0"));

        ddlPatientConsentPrimary.Items.Clear();
        var consentDropDown = DropDownHelper.GetPatientPhoneConsent();
        ddlPatientConsentPrimary.DataSource = consentDropDown;
        ddlPatientConsentPrimary.DataTextField = "Text";
        ddlPatientConsentPrimary.DataValueField = "Value";
        ddlPatientConsentPrimary.DataBind();

        ddlPatientConsentOffice.Items.Clear();
        ddlPatientConsentOffice.DataSource = consentDropDown;
        ddlPatientConsentOffice.DataTextField = "Text";
        ddlPatientConsentOffice.DataValueField = "Value";
        ddlPatientConsentOffice.DataBind();

        ddlPatientConsentCell.Items.Clear();
        ddlPatientConsentCell.DataSource = consentDropDown;
        ddlPatientConsentCell.DataTextField = "Text";
        ddlPatientConsentCell.DataValueField = "Value";
        ddlPatientConsentCell.DataBind();
    }

    public string GetStates()
    {
        var stateRepository = IoC.Resolve<IStateRepository>();
        var states = stateRepository.GetAllStates();
        return new JavaScriptSerializer().Serialize(states);
    }

    private void GetCustomerData()
    {
        var objCommonCode = new CommonCode();
        var customer = IoC.Resolve<ICustomerRepository>().GetCustomerByUserId(UserID);

        var customerEligibility = IoC.Resolve<ICustomerEligibilityRepository>().GetByCustomerIdAndYear(customer.CustomerId, DateTime.Today.Year);

        customerLogEditModel.CustomerId = CustomerId = customer.CustomerId;

        //EUser user = customers[0].User;
        var address = customer.Address;
        customerLogEditModel.HomeAddress = address;

        txtaddress1.Text = address.StreetAddressLine1;
        txtaddress2.Text = address.StreetAddressLine2;

        hfstate.Value = customer.Address.StateId.ToString();
        ddlCountry.SelectedValue = address.CountryId.ToString();
        txtcity.Text = address.City;

        if (customer.Height != null)
        {
            customerLogEditModel.Feet = ddlFeet.SelectedValue = customer.Height.Feet.ToString();
            customerLogEditModel.Inches = ddlInch.SelectedValue = customer.Height.Inches.ToString();
        }

        customerLogEditModel.Weight = txtweight.Text = customer.Weight != null ? customer.Weight.Pounds.ToString() : "";
        if (customer.Waist.HasValue && customer.Waist.Value > 0)
            customerLogEditModel.Waist = txtwaist.Text = customer.Waist.Value.ToString("0.0");

        customerLogEditModel.Gender = customer.Gender;
        customerLogEditModel.Race = customer.Race;
        ListItem tmpgender = ddlgender.Items.FindByText(customer.Gender.ToString());
        if (tmpgender != null)
            tmpgender.Selected = true;

        Race race = customer.Race;
        //Enum.TryParse(customers[0].Race, true, out race);

        ListItem tmprace = ddlrace.Items.FindByText(race.GetDescription());
        if (tmprace != null)
            tmprace.Selected = true;

        customerLogEditModel.Zip = txtzip.Text = address.ZipCode.ToString();
        customerLogEditModel.FirstName = txtfname.Text = customer.Name.FirstName;
        customerLogEditModel.MiddleName = txtmname.Text = customer.Name.MiddleName;
        customerLogEditModel.LastName = txtlname.Text = customer.Name.LastName;
        customerLogEditModel.EMail1 = txtEmail1.Text = customer.Email != null ? customer.Email.ToString() : "";
        customerLogEditModel.EMail2 = txtotheremail.Text = customer.AlternateEmail != null ? customer.AlternateEmail.ToString() : "";
        customerLogEditModel.PhoneHome = txtphonehome.Text = customer.HomePhoneNumber != null ? objCommonCode.FormatPhoneNumber(customer.HomePhoneNumber.ToString()) : "";
        customerLogEditModel.PhoneOffice = txtphoneoffice.Text = customer.HomePhoneNumber != null ? objCommonCode.FormatPhoneNumber(customer.OfficePhoneNumber.ToString()) : "";
        customerLogEditModel.PhoneCell = txtphonecell.Text = customer.HomePhoneNumber != null ? objCommonCode.FormatPhoneNumber(customer.MobilePhoneNumber.ToString()) : "";
        customerLogEditModel.PhoneOfficeExtension = PhoneOfficeExtension.Text = customer.PhoneOfficeExtension ?? "";

        customerLogEditModel.Employer = Employer.Text = customer.Employer;
        customerLogEditModel.EmergencyContactName = EmergencyContactName.Text = customer.EmergencyContactName;
        customerLogEditModel.EmergencyContactRelationship = EmergencyContactRelationship.Text = customer.EmergencyContactRelationship;
        customerLogEditModel.EmergencyContactPhoneNumber = EmergencyContactPhoneNumber.Text = customer.EmergencyContactPhoneNumber != null ? objCommonCode.FormatPhoneNumber(customer.EmergencyContactPhoneNumber.ToString()) : "";

        if (customer.DoNotContactReasonNotesId.HasValue && customer.DoNotContactReasonNotesId > 0)
        {
            var notes = IoC.Resolve<INotesRepository>().Get(customer.DoNotContactReasonNotesId.Value);
            customerLogEditModel.DoNotContactReasonNotes = ReasonDoNotContactnotes.Text = notes.Text;
        }

        if (customer.DoNotContactTypeId.HasValue && customer.DoNotContactTypeId > 0)
        {
            var item = TypeDoNotContactDropdown.Items.FindByValue(customer.DoNotContactTypeId.Value.ToString());
            customerLogEditModel.DoNotContactType = customer.DoNotContactTypeId.Value.ToString();
            if (item != null)
                item.Selected = true;
        }

        if (customer.DoNotContactReasonId.HasValue && customer.DoNotContactReasonId > 0)
        {
            var item = ReasonDoNotContactDropdown.Items.FindByValue(customer.DoNotContactReasonId.Value.ToString());
            customerLogEditModel.DoNotContactReason = customer.DoNotContactReasonId.Value.ToString();
            if (item != null)
                item.Selected = true;
        }

        if (customer.PreferredContactType.HasValue && customer.PreferredContactType > 0)
        {
            var item = ddlPreferredContactType.Items.FindByValue(customer.PreferredContactType.Value.ToString());
            customerLogEditModel.PreferredContactType = customer.PreferredContactType.Value.ToString();
            if (item != null)
                item.Selected = true;
        }

        if (!string.IsNullOrEmpty(customer.LastScreeningDate))
        {
            DateTime lastScreeningDate;
            customerLogEditModel.LastScreeningDate = LastScreeningDateTextbox.Text = DateTime.TryParse(customer.LastScreeningDate, out lastScreeningDate) ? lastScreeningDate.ToShortDateString() : string.Empty;
        }
        else
        {
            LastScreeningDateContainerSpan.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        var settings = IoC.Resolve<ISettings>();

        customerLogEditModel.EmployeeId = EmployeeIdTextbox.Text = customer.EmployeeId.Trim();

        if (customerEligibility != null && customerEligibility.IsEligible.HasValue)
        {
            ListItem tmpIsEligble = ddlIsEligible.Items.FindByText((customerEligibility.IsEligible == true ? EligibleStatus.Yes : EligibleStatus.No).ToString());
            if (tmpIsEligble != null)
                tmpIsEligble.Selected = true;
        }

        if (customer.ActivityId.HasValue && customer.ActivityId.Value > 0)
            customerLogEditModel.Activity = ddActivity.SelectedValue = customer.ActivityId.Value.ToString();

        customerLogEditModel.InsuranceId = InsuranceIdTextbox.Text = customer.InsuranceId.Trim();
        customerLogEditModel.Ssn = SsnTextbox.Text = customer.Ssn.Trim();

        if (settings.CaptureEmployeeId || settings.CaptureInsuranceId)
        {
            if (settings.CaptureEmployeeId)
                EmployeeIdContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
            else
                EmployeeIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");

            if (settings.CaptureInsuranceId)
                InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "block");
            else
                InsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
            EmployeeIdInsuranceIdContainer.Style.Add(HtmlTextWriterStyle.Display, "none");

        var toolTipRepository = IoC.Resolve<IToolTipRepository>();
        var insuranceIdLabel = toolTipRepository.GetToolTipContentByTag(ToolTipType.InsuranceIdLabel);
        insuranceIdLabel = string.IsNullOrEmpty(insuranceIdLabel) ? "Insurance Id:" : (insuranceIdLabel + ":");
        InsuranceIdLabel.InnerHtml = insuranceIdLabel;

        if (customer.LanguageId.HasValue)
        {
            var languageRepository = IoC.Resolve<ILanguageRepository>();
            var language = languageRepository.GetById(customer.LanguageId.Value);
            if (language != null)
            {
                //customerLogEditModel.PreferredLanguage = PreferredLanguageTextbox.Text = language.Name;
                customerLogEditModel.LanguageName = language.Name;
                PreferredLanguageDropDown.SelectedValue = language.Id.ToString();
            }
        }

        //PreferredLanguageTextbox.Text = customer.PreferredLanguage.Trim();
        if (customer.BestTimeToCall.HasValue && customer.BestTimeToCall.Value > 0)
            customerLogEditModel.BestTimeToCall = BestTimeToCallDropdown.SelectedValue = customer.BestTimeToCall.Value.ToString();

        ViewState["HintQuestion"] = customer.UserLogin.HintQuestion;
        ViewState["HintAnswer"] = customer.UserLogin.HintAnswer;

        if (customer.DateOfBirth.HasValue)
        {
            customerLogEditModel.Dob = txtDOB.Text = customer.DateOfBirth.Value.ToString("MM/dd/yyyy");
        }

        customerLogEditModel.MarketingSource = MarketingSourceDropDown.SelectedValue = customer.MarketingSource;
        if (customer.EnableTexting)
        {
            rbtnEnableTexting.Items[0].Selected = true;
            customerLogEditModel.EnableTexting = true;
        }
        else
        {
            rbtnEnableTexting.Items[1].Selected = true;
            customerLogEditModel.EnableTexting = false;
        }

        if (customer.EnableVoiceMail)
        {
            rbtnEnableVoiceMail.Items[0].Selected = true;
            customerLogEditModel.EnableVoiceMail = true;
        }
        else
        {
            rbtnEnableVoiceMail.Items[1].Selected = true;
            customerLogEditModel.EnableVoiceMail = false;
        }

        if (customer.EnableEmail)
        {
            rbtnEnableEmail.Items[0].Selected = true;
            customerLogEditModel.EnableEmail = true;
        }
        else
        {
            rbtnEnableEmail.Items[1].Selected = true;
            customerLogEditModel.EnableEmail = false;
        }

        customerLogEditModel.MedicareId = MedicareIdTextbox.Text = customer.Hicn.Trim();
        customerLogEditModel.MbiNumber = MbiNumberTextbox.Text = customer.Mbi.Trim();
        customerLogEditModel.MedicareAdvantageNumber = MedicareAdvantageNumber.Text = customer.MedicareAdvantageNumber.Trim();
        customerLogEditModel.MedicareAdvantagePlanName = MedicareAdvantagePlanName.Text = customer.MedicareAdvantagePlanName.Trim();
        //if (customer.Tag.HasValue && customer.Tag.Value > 0)
        //    CustomerTagDropdown.SelectedValue = customer.Tag.Value.ToString();

        if (customer.PhoneHomeConsentId > 0)
        {
            ddlPatientConsentPrimary.SelectedValue = customer.PhoneHomeConsentId.ToString();
        }
        if (customer.PhoneCellConsentId > 0)
        {
            ddlPatientConsentCell.SelectedValue = customer.PhoneCellConsentId.ToString();
        }
        if (customer.PhoneOfficeConsentId > 0)
        {
            ddlPatientConsentOffice.SelectedValue = customer.PhoneOfficeConsentId.ToString();
        }

        var primaryCarePhysicianRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();
        var pcp = primaryCarePhysicianRepository.Get(CustomerId);
        if (pcp == null)
            return;
        HasPcpHiddenField.Value = Boolean.TrueString;


        chkPCPDetails.Checked = true;
        divPcp.Visible = true;
        divPcp.Style["display"] = "block";


        customerLogEditModel.FirstName = UCPCPInfo1.FirstName = pcp.Name.FirstName;
        customerLogEditModel.MiddleName = UCPCPInfo1.MiddleName = pcp.Name.MiddleName;
        customerLogEditModel.LastName = UCPCPInfo1.LastName = pcp.Name.LastName;
        customerLogEditModel.Email = UCPCPInfo1.Email = pcp.Email != null ? pcp.Email.ToString() : string.Empty; ;
        customerLogEditModel.Phone = UCPCPInfo1.Phone = !string.IsNullOrEmpty(objCommonCode.FormatPhoneNumber(pcp.Primary.ToString()))
                ? objCommonCode.FormatPhoneNumber(pcp.Primary.ToString())
                : string.Empty;
        customerLogEditModel.AlternatePhone = UCPCPInfo1.AlternatePhone = !string.IsNullOrEmpty(objCommonCode.FormatPhoneNumber(pcp.Secondary.ToString()))
               ? objCommonCode.FormatPhoneNumber(pcp.Secondary.ToString())
               : string.Empty;
        customerLogEditModel.Fax = UCPCPInfo1.Fax = !string.IsNullOrEmpty(objCommonCode.FormatPhoneNumber(pcp.Fax.ToString()))
               ? objCommonCode.FormatPhoneNumber(pcp.Fax.ToString())
               : string.Empty;
        customerLogEditModel.AlternateEmail = UCPCPInfo1.AlternateEmail = pcp.SecondaryEmail != null ? pcp.SecondaryEmail.ToString() : string.Empty;
        customerLogEditModel.WebsiteUrl = UCPCPInfo1.WebsiteUrl = pcp.Website;


        Page.ClientScript.RegisterStartupScript(typeof(string), "jscode", " HandlePCPPanel(); ", true);

        if (pcp.Address != null)
        {
            UCPCPInfo1.Address1 = pcp.Address.StreetAddressLine1;
            UCPCPInfo1.Address2 = pcp.Address.StreetAddressLine2;
            UCPCPInfo1.City = pcp.Address.City;
            UCPCPInfo1.State = pcp.Address.StateId.ToString();
            UCPCPInfo1.Zip = pcp.Address.ZipCode.Zip;
            customerLogEditModel.PcpAddress = pcp.Address;
        }

        if (pcp.MailingAddress != null)
        {
            UCPCPInfo1.MaillingAddress1 = pcp.MailingAddress.StreetAddressLine1;
            UCPCPInfo1.MaillingAddress2 = pcp.MailingAddress.StreetAddressLine2;
            UCPCPInfo1.MaillingCity = pcp.MailingAddress.City;
            UCPCPInfo1.MaillingState = pcp.MailingAddress.StateId.ToString();
            UCPCPInfo1.MaillingZip = pcp.MailingAddress.ZipCode.Zip;
            customerLogEditModel.MailingAddress = pcp.MailingAddress;
        }

        UCPCPInfo1.IsMaillingAddressSame = IsMailingAddressSame(pcp);

        if (pcp.Address != null && pcp.MailingAddress == null)
        {
            UCPCPInfo1.MaillingAddress1 = pcp.Address.StreetAddressLine1;
            UCPCPInfo1.MaillingAddress2 = pcp.Address.StreetAddressLine2;
            UCPCPInfo1.MaillingCity = pcp.Address.City;
            UCPCPInfo1.MaillingState = pcp.Address.StateId.ToString();
            UCPCPInfo1.MaillingZip = pcp.Address.ZipCode.Zip;
        }
        if (pcp.IsPcpAddressVerified.HasValue && pcp.IsPcpAddressVerified.Value)
            UCPCPInfo1.IsPcpAddressVerified = true;
        else
            UCPCPInfo1.IsPcpAddressVerified = false;
    }

    private bool IsMailingAddressSame(PrimaryCarePhysician pcp)
    {
        if (pcp.Address == null && pcp.MailingAddress == null) return true;
        if (pcp.Address != null && pcp.MailingAddress == null) return true;
        if (pcp.Address == null && pcp.MailingAddress != null) return true;
        return (pcp.MailingAddress.Id == pcp.Address.Id);
    }

    private bool UpdateCustomerInfo()
    {
        try
        {
            var isAdmin = (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId) == (long)Roles.FranchisorAdmin;
            var currentOrganizationRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            var customerRepository = IoC.Resolve<ICustomerRepository>();
            var customerEligibilityService = IoC.Resolve<ICustomerEligibilityService>();

            var customerService = IoC.Resolve<ICustomerService>();
            var customer = customerRepository.GetCustomer(CustomerId);
            var oldActivityType = customer.ActivityId;

            var customerDonotContactTypeIdOld = customer.DoNotContactTypeId;
            var customerDoNotContactReasonIdOld = customer.DoNotContactReasonId;
            //if (TypeDoNotContactDropdown.SelectedIndex > 0)
            //{
            //    customer.DoNotContactTypeId = (long?)long.Parse(TypeDoNotContactDropdown.SelectedItem.Value);
            //    customer.DoNotContactReasonId = (long?)long.Parse(ReasonDoNotContactDropdown.SelectedItem.Value);

            //    if (!string.IsNullOrEmpty(ReasonDoNotContactnotes.Text.Trim()))
            //    {
            //        var notesRepository = IoC.Resolve<INotesRepository>();
            //        Notes notes;
            //        if (customer.DoNotContactReasonNotesId.HasValue && customer.DoNotContactReasonNotesId > 0)
            //        {
            //            notes = notesRepository.Get(customer.DoNotContactReasonNotesId.Value);
            //            notes.Text = ReasonDoNotContactnotes.Text;
            //            notes.DataRecorderMetaData.DateModified = DateTime.Now;
            //            notes.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
            //        }
            //        else
            //        {
            //            notes = new Notes
            //            {
            //                Text = ReasonDoNotContactnotes.Text,
            //                DataRecorderMetaData = new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null)
            //            };
            //        }
            //        notes = ((IRepository<Notes>)notesRepository).Save(notes);
            //        customer.DoNotContactReasonNotesId = notes.Id;
            //    }
            //    LogAudit(ModelType.Edit, customer, customer.CustomerId);
            //    customerService.SaveCustomer(customer);
            //}
            //else
            //{
            if (!customerRepository.UniqueEmail(CustomerId, txtEmail1.Text))
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_UniqueEmail",
                                                        "alert('This email address is already registered! Please use different email address.');",
                                                        true);
                return false;
            }
            var stateRepository = IoC.Resolve<IStateRepository>();
            var state = stateRepository.GetState(Convert.ToInt64(hfstate.Value));
            var address = new Address(txtaddress1.Text, txtaddress2.Text, txtcity.Text, state.Name,
                                      txtzip.Text, ddlCountry.SelectedItem.Text);



            customer.Name = new Name
                                {
                                    FirstName = txtfname.Text,
                                    MiddleName = txtmname.Text,
                                    LastName = txtlname.Text
                                };

            address.Id = customer.Address.Id;
            customer.Address = address;

            string officePhoneNumber = PhoneNumber.Create(txtphoneoffice.Text, PhoneNumberType.Office).ToString();
            string mobilePhoneNumber = PhoneNumber.Create(txtphonecell.Text, PhoneNumberType.Mobile).ToString();
            string homePhoneNumber = PhoneNumber.Create(txtphonehome.Text, PhoneNumberType.Home).ToString();

            var previousIncorrectPhoneNumberStatus = customer.IsIncorrectPhoneNumber;
            var currentIncorrectPhoneNumberStatus = true;

            if ((customer.OfficePhoneNumber != null && customer.OfficePhoneNumber.ToString() != officePhoneNumber) ||
               (customer.MobilePhoneNumber != null && customer.MobilePhoneNumber.ToString() != mobilePhoneNumber) ||
              (customer.HomePhoneNumber != null && customer.HomePhoneNumber.ToString() != homePhoneNumber))
            {
                customer.IsIncorrectPhoneNumber = false;
                customer.IncorrectPhoneNumberMarkedDate = null;
                currentIncorrectPhoneNumberStatus = customer.IsIncorrectPhoneNumber;
            }

            var commonCode = new CommonCode();
            customer.HomePhoneNumber = new PhoneNumber
                                           {
                                               PhoneNumberType = PhoneNumberType.Home,
                                               Number = commonCode.FormatPhoneNumber(txtphonehome.Text)
                                           };

            customer.OfficePhoneNumber = new PhoneNumber
                                             {
                                                 PhoneNumberType = PhoneNumberType.Office,
                                                 Number = commonCode.FormatPhoneNumber(txtphoneoffice.Text)
                                             };
            customer.PhoneOfficeExtension = PhoneOfficeExtension.Text;
            customer.MobilePhoneNumber = new PhoneNumber
                                             {
                                                 PhoneNumberType = PhoneNumberType.Mobile,
                                                 Number = commonCode.FormatPhoneNumber(txtphonecell.Text)
                                             };

            if (!string.IsNullOrEmpty(txtEmail1.Text))
                customer.Email = new Email(txtEmail1.Text);
            else
                customer.Email = null;

            if (!string.IsNullOrEmpty(txtotheremail.Text))
                customer.AlternateEmail = new Email(txtotheremail.Text);
            else
                customer.AlternateEmail = null;

            customer.Height = new Height(Convert.ToInt64(ddlFeet.SelectedValue),
                                         Convert.ToInt64(ddlInch.SelectedValue));
            customer.Race = (Race)Enum.Parse(typeof(Race), ddlrace.SelectedValue);

            customer.DoNotContactTypeId = TypeDoNotContactDropdown.SelectedIndex > 0 ? (long?)long.Parse(TypeDoNotContactDropdown.SelectedItem.Value) : null;
            customer.DoNotContactReasonId = ReasonDoNotContactDropdown.SelectedIndex > 0 ? (long?)long.Parse(ReasonDoNotContactDropdown.SelectedItem.Value) : null;
            customer.PreferredContactType = ddlPreferredContactType.SelectedIndex > 0 ? (long?)long.Parse(ddlPreferredContactType.SelectedItem.Value) : null;

            customer.EnableTexting = rbtnEnableTexting.SelectedValue == "true";
            customer.EnableVoiceMail = rbtnEnableVoiceMail.SelectedValue == "true";
            customer.EnableEmail = rbtnEnableEmail.SelectedValue == "true";
            long donotContactType = 0;
            long donotContactReasonId = 0;



            long.TryParse(TypeDoNotContactDropdown.SelectedItem.Value, out donotContactType);
            long.TryParse(ReasonDoNotContactDropdown.SelectedItem.Value, out donotContactReasonId);

            if (donotContactType > 0 && donotContactReasonId > 0)
            {
                customer.DoNotContactTypeId = donotContactType;
                customer.DoNotContactReasonId = donotContactReasonId;

                if ((customerDoNotContactReasonIdOld == null || customerDoNotContactReasonIdOld != donotContactReasonId) || (customerDonotContactTypeIdOld == null || customerDonotContactTypeIdOld != donotContactType))
                {
                    customer.DoNotContactUpdateDate = DateTime.Now;
                    customer.DoNotContactUpdateSource = (long)DoNotContactSource.Manual;
                }

                if (!string.IsNullOrEmpty(ReasonDoNotContactnotes.Text.Trim()))
                {
                    var notesRepository = IoC.Resolve<INotesRepository>();
                    Notes notes;
                    if (customer.DoNotContactReasonNotesId.HasValue && customer.DoNotContactReasonNotesId > 0)
                    {
                        notes = notesRepository.Get(customer.DoNotContactReasonNotesId.Value);
                        notes.Text = ReasonDoNotContactnotes.Text;
                        notes.DataRecorderMetaData.DateModified = DateTime.Now;
                        notes.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                    }
                    else
                    {
                        notes = new Notes
                        {
                            Text = ReasonDoNotContactnotes.Text,
                            DataRecorderMetaData = new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null)
                        };
                    }
                    notes = ((IRepository<Notes>)notesRepository).Save(notes);
                    customer.DoNotContactReasonNotesId = notes.Id;
                }
            }
            else
            {
                customer.DoNotContactTypeId = null;
                customer.DoNotContactReasonNotesId = null;
                customer.DoNotContactReasonId = null;
                customer.DoNotContactUpdateDate = null;
                customer.DoNotContactUpdateSource = null;

                //if (!string.IsNullOrEmpty(ReasonDoNotContactnotes.Text.Trim()))
                //{
                //    var notesRepository = IoC.Resolve<INotesRepository>();
                //    Notes notes;
                //    if (customer.DoNotContactReasonNotesId.HasValue && customer.DoNotContactReasonNotesId > 0)
                //    {
                //        notes = notesRepository.Get(customer.DoNotContactReasonNotesId.Value);
                //        notes.Text = ReasonDoNotContactnotes.Text;
                //        notes.DataRecorderMetaData.DateModified = DateTime.Now;
                //        notes.DataRecorderMetaData.DataRecorderModifier =
                //            new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                //    }
                //    else
                //    {
                //        notes = new Notes
                //                    {
                //                        Text = ReasonDoNotContactnotes.Text,
                //                        DataRecorderMetaData =
                //                            new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null)
                //                    };
                //    }
                //    notes = ((IRepository<Notes>)notesRepository).Save(notes);
                //    customer.DoNotContactReasonNotesId = notes.Id;
                //}
            }

            if (txtDOB.Text.Trim().Length > 0)
                customer.DateOfBirth = Convert.ToDateTime(txtDOB.Text);

            if (!string.IsNullOrWhiteSpace(LastScreeningDateTextbox.Text))
            {
                customer.LastScreeningDate = LastScreeningDateTextbox.Text;
            }
            else if (string.IsNullOrWhiteSpace(LastScreeningDateTextbox.Text) &&
                     !string.IsNullOrWhiteSpace(customer.LastScreeningDate))
            {
                customer.LastScreeningDate = "Not Available";
            }

            double weight;
            if (txtweight.Text.Trim().Length > 0 && Double.TryParse(txtweight.Text.Trim(), out weight))
            {
                customer.Weight = new Weight(weight);
            }
            else
            {
                customer.Weight = null;
            }

            decimal waist;
            if (txtwaist.Text.Trim().Length > 0 && decimal.TryParse(txtwaist.Text.Trim(), out waist))
            {
                customer.Waist = waist;
            }
            else
            {
                customer.Waist = null;
            }

            if (ddlgender.SelectedItem.Text == Gender.Male.ToString())
                customer.Gender = Gender.Male;
            else if (ddlgender.SelectedItem.Text == Gender.Female.ToString())
                customer.Gender = Gender.Female;
            else
                customer.Gender = Gender.Unspecified;

            customer.Employer = Employer.Text;
            customer.EmergencyContactName = EmergencyContactName.Text;
            customer.EmergencyContactRelationship = EmergencyContactRelationship.Text;
            customer.EmergencyContactPhoneNumber = new PhoneNumber()
                                                       {
                                                           PhoneNumberType = PhoneNumberType.Office,
                                                           Number =
                                                               commonCode.FormatPhoneNumber(
                                                                   EmergencyContactPhoneNumber.Text)
                                                       };

            customer.MarketingSource = Request.Form[MarketingSourceDropDown.UniqueID + "_hidden"] ?? string.Empty;

            customer.EmployeeId = EmployeeIdTextbox.Text.Trim();
            EligibleStatus eligiblestatus;

            bool? selectedEligibility = null;

            if (!IsRoleCallCenterAgentOrTechnician)
            {
                if (Enum.TryParse(ddlIsEligible.SelectedValue, out eligiblestatus) && Enum.IsDefined(typeof(EligibleStatus), eligiblestatus))
                {
                    if (EligibleStatus.Yes == eligiblestatus)
                        selectedEligibility = true;
                    else if (EligibleStatus.No == eligiblestatus)
                        selectedEligibility = false;
                }
                else
                    selectedEligibility = null;
            }

            if (isAdmin)
            {
                var activityId = Convert.ToInt64(ddActivity.SelectedValue);
                customer.ActivityId = activityId > 0 ? activityId : (long?)null;
                if (oldActivityType != customer.ActivityId)
                { customer.ActivityTypeIsManual = true; }
            }

            customer.InsuranceId = InsuranceIdTextbox.Text.Trim();

            var prefferedLanguage = PreferredLanguageDropDown.SelectedItem.Text;
            if (!string.IsNullOrEmpty(prefferedLanguage))
            {
                var languageRepository = IoC.Resolve<ILanguageRepository>();
                var currentSession = IoC.Resolve<ISessionContext>().UserSession;
                var languageService = IoC.Resolve<ILanguageService>();
                var language = languageRepository.GetByName(prefferedLanguage) ??
                               languageService.AddLanguage(prefferedLanguage, currentSession.CurrentOrganizationRole.OrganizationRoleUserId);

                customer.LanguageId = language.Id;
            }
            else
            {
                customer.LanguageId = null;
            }

            //customer.PreferredLanguage = PreferredLanguageTextbox.Text.Trim();
            customer.BestTimeToCall = Convert.ToInt64(BestTimeToCallDropdown.SelectedValue);
            customer.Ssn = SsnTextbox.Text.Replace("-", "").Trim();

            customer.Hicn = MedicareIdTextbox.Text.Trim();
            customer.Mbi = MbiNumberTextbox.Text.Trim();
            customer.MedicareAdvantageNumber = MedicareAdvantageNumber.Text.Trim();
            customer.MedicareAdvantagePlanName = MedicareAdvantagePlanName.Text.Trim();
            //customer.Tag = Convert.ToInt64(CustomerTagDropdown.SelectedValue);

            customer.PhoneHomeConsentId = long.Parse(ddlPatientConsentPrimary.SelectedValue);
            customer.PhoneCellConsentId = long.Parse(ddlPatientConsentCell.SelectedValue);
            customer.PhoneOfficeConsentId = long.Parse(ddlPatientConsentOffice.SelectedValue);

            var logger = IoC.Resolve<ILogManager>().GetLogger<Global>();
            customerService.SaveCustomer(customer, currentOrganizationRole.OrganizationRoleUserId);
            //always save eligibility after saving customer , because history is maintained by SaveCustomer/SaveCustomerOnly function.
            if (!IsRoleCallCenterAgentOrTechnician)
                customerEligibilityService.Save(customer.CustomerId, DateTime.Today.Year, selectedEligibility, currentOrganizationRole.OrganizationRoleUserId, logger);

            LogAudit(ModelType.Edit, customer, customer.CustomerId);
            if (UpdateShippingAddressCheckbox.Checked)
                customerService.UpdateCustomerShippingAddress(customer.CustomerId);

            if (previousIncorrectPhoneNumberStatus && !currentIncorrectPhoneNumberStatus)
            {
                var customerNotesService = IoC.Resolve<ICustomerNotesService>();
                customerNotesService.SavePhoneNumberUpdatedMessage(customer.CustomerId, currentOrganizationRole.OrganizationRoleUserId);
            }
            var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
            eventCustomerRepository.UpdateEnableTexting(customer.CustomerId, customer.EnableTexting);
            if (!UpdatePcpInfo(customer.CustomerId))
                return false;
            // }

            var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
            var prospectCustomer = prospectCustomerRepository.GetProspectCustomerByCustomerId(customer.CustomerId);

            if (prospectCustomer != null)
            {
                if (customer.DoNotContactTypeId.HasValue)
                {
                    prospectCustomerRepository.UpdateDoNotCallStatus(prospectCustomer.Id, ProspectCustomerConversionStatus.Declined);
                }
                else
                {
                    if (prospectCustomer.Status == (long)ProspectCustomerConversionStatus.Declined)
                    {
                        var conversionStatus = prospectCustomer.IsConverted.HasValue && prospectCustomer.IsConverted.Value ? ProspectCustomerConversionStatus.Converted : ProspectCustomerConversionStatus.NotConverted;
                        prospectCustomerRepository.UpdateDoNotCallStatus(prospectCustomer.Id, conversionStatus);
                    }
                }
            }

        }
        catch (InvalidAddressException ex)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodecityvalidate", "alert('" + ex.Message + "');", true);
            return false;
        }
        catch (Exception ex)
        {

            this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodecityvalidate", "alert('" + ex.Message + "');", true);
            return false;
        }

        return true;
    }

    /// <summary>
    /// 
    /// </summary>
    private bool UpdatePcpInfo(long customerId)
    {
        var countryRepository = IoC.Resolve<ICountryRepository>();
        var countryId = countryRepository.GetAll().FirstOrDefault().Id;

        var primaryCarePhysicianRepository = IoC.Resolve<IPrimaryCarePhysicianRepository>();

        PrimaryCarePhysician pcp = null;
        long oldPcpId = 0;
        bool isPcpAlredayVerified = false;

        if (!chkChangePcp.Checked)
        {
            pcp = primaryCarePhysicianRepository.Get(customerId);
        }

        if (pcp != null)
        {
            oldPcpId = pcp.Id;
            isPcpAlredayVerified = pcp.IsPcpAddressVerified.HasValue && pcp.IsPcpAddressVerified.Value;
        }

        var currentOrganizationRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        if (chkPCPDetails.Checked)
        {
            if (Convert.ToInt64(PhysicianMasterIdHiddenField.Value) > 0)
            {
                var physicianMasterRepository = IoC.Resolve<IPhysicianMasterRepository>();
                var physicianMaster = physicianMasterRepository.GetById(Convert.ToInt64(PhysicianMasterIdHiddenField.Value));

                if (pcp == null)
                {
                    pcp = new PrimaryCarePhysician
                    {
                        Name = new Name(physicianMaster.FirstName, physicianMaster.MiddleName, physicianMaster.LastName),
                        Primary = physicianMaster.PracticePhone,
                        Fax = physicianMaster.PracticeFax,
                        PrefixText = physicianMaster.PrefixText,
                        SuffixText = physicianMaster.SuffixText,
                        CredentialText = physicianMaster.CredentialText,
                        Npi = physicianMaster.Npi,
                        PhysicianMasterId = physicianMaster.Id,
                        CustomerId = CustomerId,
                        DataRecorderMetaData = new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null),
                        IsActive = true
                    };
                }
                else
                {
                    pcp.Name = new Name(physicianMaster.FirstName, physicianMaster.MiddleName, physicianMaster.LastName);
                    pcp.Primary = physicianMaster.PracticePhone;
                    pcp.Fax = physicianMaster.PracticeFax;
                    pcp.PrefixText = physicianMaster.PrefixText;
                    pcp.SuffixText = physicianMaster.SuffixText;
                    pcp.CredentialText = physicianMaster.CredentialText;
                    pcp.Npi = physicianMaster.Npi;
                    pcp.PhysicianMasterId = physicianMaster.Id;
                    pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                    pcp.DataRecorderMetaData.DateModified = DateTime.Now;
                    pcp.IsActive = true;
                }

                pcp = UpdatePcpAddressesFromMaster(physicianMaster, pcp);

            }
            else
            {
                if (pcp == null)
                {
                    pcp = new PrimaryCarePhysician
                    {
                        Name = new Name(UCPCPInfo1.FirstName, UCPCPInfo1.MiddleName, UCPCPInfo1.LastName),
                        Primary = string.IsNullOrEmpty(UCPCPInfo1.Phone) ? null : PhoneNumber.Create(UCPCPInfo1.Phone, PhoneNumberType.Home),
                        Secondary = string.IsNullOrEmpty(UCPCPInfo1.AlternatePhone) ? null : PhoneNumber.Create(UCPCPInfo1.AlternatePhone, PhoneNumberType.Office),
                        Fax = string.IsNullOrEmpty(UCPCPInfo1.Fax) ? null : PhoneNumber.Create(UCPCPInfo1.Fax, PhoneNumberType.Unknown),
                        Email = string.IsNullOrEmpty(UCPCPInfo1.Email) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.Email),
                        SecondaryEmail = string.IsNullOrEmpty(UCPCPInfo1.AlternateEmail) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.AlternateEmail),
                        Website = UCPCPInfo1.WebsiteUrl,
                        CustomerId = customerId,
                        DataRecorderMetaData = new DataRecorderMetaData(currentOrganizationRole.OrganizationRoleUserId, DateTime.Now, null),
                        IsActive = true
                    };
                }
                else
                {
                    pcp.Name = new Name(UCPCPInfo1.FirstName, UCPCPInfo1.MiddleName, UCPCPInfo1.LastName);
                    pcp.Primary = string.IsNullOrEmpty(UCPCPInfo1.Phone) ? null : PhoneNumber.Create(UCPCPInfo1.Phone, PhoneNumberType.Home);
                    pcp.Secondary = string.IsNullOrEmpty(UCPCPInfo1.AlternatePhone) ? null : PhoneNumber.Create(UCPCPInfo1.AlternatePhone, PhoneNumberType.Office);
                    pcp.Fax = string.IsNullOrEmpty(UCPCPInfo1.Fax) ? null : PhoneNumber.Create(UCPCPInfo1.Fax, PhoneNumberType.Unknown);
                    pcp.Email = string.IsNullOrEmpty(UCPCPInfo1.Email) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.Email);
                    pcp.SecondaryEmail = string.IsNullOrEmpty(UCPCPInfo1.AlternateEmail) ? new Email(string.Empty, string.Empty) : new Email(UCPCPInfo1.AlternateEmail);
                    pcp.Website = UCPCPInfo1.WebsiteUrl;
                    pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                    pcp.DataRecorderMetaData.DateModified = DateTime.Now;
                    pcp.IsActive = true;
                }

                if (UCPCPInfo1.Address1.Trim().Length > 0 && UCPCPInfo1.State != "0" && UCPCPInfo1.City.Trim().Length > 0 && UCPCPInfo1.Zip.Trim().Length > 0)
                {
                    long addressId = 0;
                    if (pcp.Address != null)
                        addressId = pcp.Address.Id;

                    pcp.Address = new Address(addressId)
                    {
                        StreetAddressLine1 = UCPCPInfo1.Address1,
                        StreetAddressLine2 = UCPCPInfo1.Address2,
                        City = UCPCPInfo1.City,
                        StateId = Convert.ToInt64(UCPCPInfo1.State),
                        ZipCode = new ZipCode(UCPCPInfo1.Zip),
                        CountryId = countryId
                    };

                }
                else
                    pcp.Address = null;

                SetPcpMaillingAddress(pcp, countryId);
            }

            pcp = primaryCarePhysicianRepository.Save(pcp);

            var isPcpAddressVerified = false;
            if (Convert.ToInt64(PhysicianMasterIdHiddenField.Value) > 0)
            {
                isPcpAddressVerified = chkVerifiedPcpInfo.Checked;
            }
            else
            {
                isPcpAddressVerified = UCPCPInfo1.IsPcpAddressVerified;
            }

            if (pcp.Id != oldPcpId || isPcpAlredayVerified != isPcpAddressVerified)
            {
                pcp.IsPcpAddressVerified = isPcpAddressVerified;
                pcp.PcpAddressVerifiedBy = currentOrganizationRole.OrganizationRoleUserId;
                pcp.PcpAddressVerifiedOn = DateTime.Now;
                pcp.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(currentOrganizationRole.OrganizationRoleUserId);
                pcp.DataRecorderMetaData.DateModified = DateTime.Now;

                pcp = primaryCarePhysicianRepository.Save(pcp);

                var eventCustomerRepository = IoC.Resolve<IEventCustomerRepository>();
                var futureEventCustomer = eventCustomerRepository.GetEventCustomerForFurtureEventsByCustomerId(customerId);

                if (futureEventCustomer != null && futureEventCustomer.Any())
                {
                    var eventCustomerIds = futureEventCustomer.Select(x => x.Id).ToArray();
                    var eventCustomerPrimaryCarePhysicianRepository = IoC.Resolve<IEventCustomerPrimaryCarePhysicianRepository>();
                    var eventCustomerPrimaryCarePhysicians = eventCustomerPrimaryCarePhysicianRepository.GetEventCustomerPrimaryCarePhysicianByIds(eventCustomerIds);
                    foreach (var ecPcp in eventCustomerPrimaryCarePhysicians)
                    {
                        var eventCustomerPrimarycarePhysician = new EventCustomerPrimaryCarePhysician
                        {
                            EventCustomerId = ecPcp.EventCustomerId,
                            PrimaryCarePhysicianId = pcp.Id,
                            IsPcpAddressVerified = isPcpAddressVerified,
                            PcpAddressVerifiedOn = DateTime.Now,
                            PcpAddressVerifiedBy = currentOrganizationRole.OrganizationRoleUserId
                        };

                        eventCustomerPrimaryCarePhysicianRepository.Save(eventCustomerPrimarycarePhysician);
                    }
                }
            }


        }
        else
        {
            primaryCarePhysicianRepository.DecativatePhysician(customerId, currentOrganizationRole.OrganizationRoleUserId);
        }

        return true;
    }

    private void SetPcpMaillingAddress(PrimaryCarePhysician pcp, long countryId)
    {
        if (UCPCPInfo1.IsMaillingAddressSame || IsMailingAddressSame())
        {
            pcp.MailingAddress = null;
            return;
        }

        long mailingAddressId = 0;

        if (pcp.MailingAddress != null && (pcp.Address == null || pcp.MailingAddress.Id != pcp.Address.Id))
        {
            mailingAddressId = pcp.MailingAddress.Id;
        }

        pcp.MailingAddress = new Address(mailingAddressId)
        {
            StreetAddressLine1 = UCPCPInfo1.MaillingAddress1,
            StreetAddressLine2 = UCPCPInfo1.MaillingAddress2,
            City = UCPCPInfo1.MaillingCity,
            StateId = Convert.ToInt64(UCPCPInfo1.MaillingState),
            ZipCode = new ZipCode(UCPCPInfo1.MaillingZip),
            CountryId = countryId
        };
    }
    private bool IsMailingAddressSame()
    {
        return UCPCPInfo1.MaillingAddress1 == UCPCPInfo1.Address1 && UCPCPInfo1.MaillingAddress2 == UCPCPInfo1.Address2 &&
               UCPCPInfo1.MaillingCity == UCPCPInfo1.City && UCPCPInfo1.MaillingStateName == UCPCPInfo1.StateName;
    }

    private PrimaryCarePhysician UpdatePcpAddressesFromMaster(PhysicianMaster physicianMaster, PrimaryCarePhysician pcp)
    {
        var stateRepository = IoC.Resolve<IStateRepository>();

        if (physicianMaster.PracticeAddress1.Trim().Length > 0 && physicianMaster.PracticeState.Trim().Length > 0 && physicianMaster.PracticeCity.Trim().Length > 0 && physicianMaster.PracticeZip.Trim().Length > 0)
        {

            var state = stateRepository.GetStatebyCode(physicianMaster.PracticeState) ?? stateRepository.GetState(physicianMaster.PracticeState);
            long addressId = 0;
            if (pcp.Address != null)
                addressId = pcp.Address.Id;

            pcp.Address = SetPCPAddressFromPhysicianMaster(addressId, physicianMaster.PracticeAddress1, physicianMaster.PracticeAddress2, physicianMaster.PracticeCity, state.Id, state.CountryId, physicianMaster.PracticeZip);
        }
        else
            pcp.Address = null;

        if (!isPhysicianMasterMailinAddressSame(physicianMaster) && physicianMaster.MailingAddress1.Trim().Length > 0 && physicianMaster.MailingState.Trim().Length > 0 && physicianMaster.MailingCity.Trim().Length > 0 && physicianMaster.MailingZip.Trim().Length > 0)
        {
            var state = stateRepository.GetStatebyCode(physicianMaster.MailingState) ?? stateRepository.GetState(physicianMaster.MailingState);
            long addressId = 0;

            if (pcp.MailingAddress != null && (pcp.Address != null && pcp.MailingAddress.Id != pcp.Address.Id))
                addressId = pcp.MailingAddress.Id;

            pcp.MailingAddress = SetPCPAddressFromPhysicianMaster(addressId, physicianMaster.MailingAddress1, physicianMaster.MailingAddress2, physicianMaster.MailingCity, state.Id, state.CountryId, physicianMaster.MailingZip);
        }
        else
            pcp.MailingAddress = null;

        return pcp;
    }

    private Address SetPCPAddressFromPhysicianMaster(long addressId, string address1, string address2, string city, long stateId, long countryid, string zipcode)
    {
        return new Address(addressId)
        {
            StreetAddressLine1 = address1,
            StreetAddressLine2 = address2,
            City = city,
            StateId = stateId,
            ZipCode = new ZipCode(zipcode),
            CountryId = countryid
        };
    }

    private bool isPhysicianMasterMailinAddressSame(PhysicianMaster physicianMaster)
    {
        if (physicianMaster.PracticeAddress1.Trim().Length <= 0 || physicianMaster.MailingAddress1.Trim().Length <= 0) return true;

        return physicianMaster.PracticeAddress1.Trim() == physicianMaster.MailingAddress1.Trim() && physicianMaster.PracticeState.Trim() == physicianMaster.MailingState.Trim() && physicianMaster.PracticeCity.Trim() == physicianMaster.MailingCity.Trim() && physicianMaster.PracticeZip.Trim() == physicianMaster.MailingZip.Trim();
    }

}