using System;
using System.Web.UI;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Deprecated.Repository;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class EventRequest : System.Web.UI.Page
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

        protected long CallId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
            }
        }

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CustomerType"]))
                {
                    switch (Request.QueryString["CustomerType"])
                    {
                        case "Existing":
                            return CustomerType.Existing;
                        default:
                            return CustomerType.New;
                    }
                }
                switch (CustomerId)
                {
                    case 0:
                        return CustomerType.New;
                    default:
                        return CustomerType.Existing;
                }
            }
        }

        protected long CustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        protected long CurrentProspectCustomerId
        {
            get
            {
                return RegistrationFlow != null ? RegistrationFlow.ProspectCustomerId : 0;
            }
            set
            {
                RegistrationFlow.ProspectCustomerId = value;
            }

        }

        private string FirstName
        {
            get 
            {
                if (!string.IsNullOrEmpty(Request.QueryString["FirstName"]))
                    return Convert.ToString(Request.QueryString["FirstName"]);

                return string.Empty;
            }
        }

        private string LastName
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["LastName"]))
                    return Convert.ToString(Request.QueryString["LastName"]);

                return string.Empty;
            }
        }

        private string CallBackNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["CallBackNo"]))
                    return Convert.ToString(Request.QueryString["CallBackNo"]);

                return string.Empty;
            }
        }

        private string Zip
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Zip"]))
                    return Convert.ToString(Request.QueryString["Zip"]);

                return string.Empty;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Callback Prospect";
            var masterPage = Master as CallCenter_CallCenterMaster1;
            if (masterPage != null)
            {
                masterPage.SetBreadCrumbRoot = "";
                masterPage.hideucsearch();
                masterPage.SetTitle("");
            }
            if (!IsPostBack)
            {
                FillDropDown();
                if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
                {
                    divCall.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divCall.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    var repository = new CallCenterCallRepository();
                    hfCallStartTime.Value = repository.GetCallStarttime(CallId);
                }
                if (CustomerId > 0)
                {
                    var customerRepositoy = IoC.Resolve<ICustomerRepository>();
                    var customer = customerRepositoy.GetCustomer(CustomerId);
                    FirstNameTextbox.Value = customer.Name.FirstName;
                    LastNameTextbox.Value = customer.Name.LastName;
                    PhoneNumberTextbox.Value = customer.HomePhoneNumber.ToString();
                    EmailTextbox.Value = customer.Email.ToString();
                    StreetAddressLine1Textbox.Value = customer.Address.StreetAddressLine1;
                    StreetAddressLine2Textbox.Value = customer.Address.StreetAddressLine2;
                    StateTextbox.Value = customer.Address.State;
                    CityTextbox.Value = customer.Address.City;
                    ZipTextbox.Value = customer.Address.ZipCode.Zip;
                }
                else if(CurrentProspectCustomerId > 0 )
                {
                    var prospectCustomerRepository = IoC.Resolve<IProspectCustomerRepository>();
                    var prospectCustomer = prospectCustomerRepository.GetProspectCustomer(CurrentProspectCustomerId);
                    FirstNameTextbox.Value = prospectCustomer.FirstName;
                    LastNameTextbox.Value = prospectCustomer.LastName;
                    PhoneNumberTextbox.Value = prospectCustomer.CallBackPhoneNumber.ToString();
                    EmailTextbox.Value = prospectCustomer.Email.ToString();
                    ZipTextbox.Value = prospectCustomer.Address.ZipCode.Zip;
                }
                else
                {
                    FirstNameTextbox.Value = FirstName;
                    LastNameTextbox.Value = LastName;
                    PhoneNumberTextbox.Value = CallBackNumber;
                    ZipTextbox.Value = Zip;
                }
            }
        }

        protected void imgBack_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No")
            {
                if (CustomerType == CustomerType.Existing)
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerType=Existing&CustomerID=" +
                        Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&Call=No" + "&guid=" + GuId));
                else
                    Response.RedirectUser(
                        "/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?RegCustomerSearchEvent=New&FirstName=" +
                        FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&Call=No" + "&guid=" + GuId);
            }
            else
            {
                if (CustomerType == CustomerType.Existing)
                    Response.RedirectUser(ResolveUrl("/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?CustomerType=Existing&CustomerID=" +
                        Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId));
                else
                    Response.RedirectUser(
                        "/App/CallCenter/CallCenterRep/ExistingCustomer/RegCustomerSearchEvent.aspx?RegCustomerSearchEvent=New&FirstName=" +
                        FirstName + "&LastName=" + LastName + "&CallBackNo=" + CallBackNumber + "&Zip=" + Zip + "&guid=" + GuId);
            }
        }

        private void FillDropDown()
        {
            var tagRepository = IoC.Resolve<ITagRepository>();
            var tags = tagRepository.GetTags(ProspectCustomerSource.CallCenter);

            if(!tags.IsNullOrEmpty())
            {
                CallDispositionDropdown.DataSource = tags;
                CallDispositionDropdown.DataTextField = "Name";
                CallDispositionDropdown.DataValueField = "Alias";
                CallDispositionDropdown.DataBind();
            }
        }
    }
}