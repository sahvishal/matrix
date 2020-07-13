using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Finance;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Repositories.Users;
using System.Linq;
using System.Web.UI.HtmlControls;
using Falcon.App.UI.App.BasePageClass;
using Falcon.App.UI.Extentions;
using Falcon.App.Core.Scheduling.Interfaces;

namespace Falcon.App.UI.App.Common
{
    public partial class SearchCustomer : BasePage
    {
        private string GuId
        {
            get
            {
                return string.IsNullOrEmpty(Request.QueryString["guid"]) ? hfGuId.Value : Request.QueryString["guid"];
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

        public string StateId
        {
            get
            {
                return ddlstate.SelectedValue;
            }
        }

        private const string DDL_VALUE_ID = "Id";
        private const string DDL_TEXT_NAME = "Name";

        private CustomerType CustomerType
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["Customer"]))
                {
                    switch (Request.QueryString["Customer"])
                    {
                        case "Existing":
                            return CustomerType.Existing;
                        default:
                            return CustomerType.New;
                    }
                }
                return CustomerType.New;
            }
        }

        private int? EventId
        {
            get
            {
                if (!string.IsNullOrEmpty(Request.QueryString["EventID"]))
                {
                    int eventId;
                    if (Int32.TryParse(Request.QueryString["EventID"], out eventId))
                        return eventId;
                }
                return null;
            }
        }
        //Good Property
        private long CustomerId
        {
            get
            {
                long customerId = 0;
                if (!string.IsNullOrEmpty(txtCustomerID.Text.Trim()))
                {
                    Int64.TryParse(txtCustomerID.Text.Trim(), out customerId);
                }
                return customerId;
            }
            set { RegistrationFlow.CustomerId = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SetTitles();

            if (CustomerType == CustomerType.Existing)
            {
                dvTitle.InnerText = "Technician Existing Customer";
            }

            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["guid"]))
                {
                    hfGuId.Value = Guid.NewGuid().ToString();
                    var registrationFlow = new RegistrationFlowModel
                    {
                        GuId = hfGuId.Value
                    };
                    RegistrationFlow = registrationFlow;
                }

                txtFirstName.Focus();
                BindStateDropDown();

                ClientScript.RegisterStartupScript(typeof(string), "jscode_setFirstNameFocus", "setFocusFirstName();", true);
            }

            SetJavaScriptEvents();
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindCustomerDataGrid();
        }

        protected void grdCustomerHistory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var customers = GetCustomersbyFilter();

            grdCustomerHistory.PageIndex = e.NewPageIndex;
            grdCustomerHistory.DataSource = customers;
            grdCustomerHistory.DataBind();
        }

        protected void grdCustomerHistory_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null && e.Row.DataItem is Core.Users.Domain.Customer)
            {
                var customer = e.Row.DataItem as Core.Users.Domain.Customer;
                if (customer != null)
                {
                    var customerNameLiteral = e.Row.FindControl("CustomerNameLiteral") as Literal;
                    if (customerNameLiteral != null)
                    {
                        customerNameLiteral.Text = customer.Name.ToString();
                    }

                    var address = e.Row.FindControl("AddressLiteral") as Literal;
                    if (address != null)
                    {
                        address.Text = customer.Address.ToString();
                    }
                    var dob = e.Row.FindControl("DOBLiteral") as Literal;

                    var phone = e.Row.FindControl("PhoneLiteral") as Literal;
                    if(phone !=null)
                    {
                        phone.Text = customer.HomePhoneNumber.ToString();
                    }

                    if(dob!=null && customer.DateOfBirth.HasValue)
                    {
                        dob.Text = customer.DateOfBirth.Value.ToShortDateString();
                    }
                   
                    if (customer.UserLogin != null && !string.IsNullOrEmpty(customer.UserLogin.HintQuestion) && !string.IsNullOrEmpty(customer.UserLogin.HintAnswer))
                    {   
                        var spHintQues = (HtmlContainerControl)e.Row.FindControl("spHintQues");
                        var spHintAns = (HtmlContainerControl)e.Row.FindControl("spHintAns");
                        spHintQues.InnerText = customer.UserLogin.HintQuestion;
                        spHintAns.InnerText = customer.UserLogin.HintAnswer;
                    }
                    else
                    {
                        var hintQa = (HtmlContainerControl)e.Row.FindControl("divHintQA");
                        hintQa.InnerText = "-NA-";
                    }
                }
            }
        }

        protected void grdCustomerHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int customerId;
            if (!Int32.TryParse(e.CommandName, out customerId))
                return;

            if (e.CommandName == "Page") { return; }
            CustomerId = customerId;
            if (EventId.HasValue)
            {
              
                var eventProductTypeRepository = IoC.Resolve<IEventProductTypeRepository>();
                var customereventProductType = eventProductTypeRepository.GetByEventIdAndCustomerId(EventId.Value, customerId);
                if (customereventProductType.Count() > 0)
                {
                    var service = IoC.Resolve<IRefundRequestService>();
                    var result = service.CheckifCancelAppointmentRequestExistsforaCustomer(EventId.Value, customerId);
                    if (result)
                    {
                        divErrorMsg.Visible = true;
                        divErrorMsg.InnerText = "Customer has cancelled the appointment for this event, the cancellation request is in process. Re-registration is not allowed unless the request is resolved.";
                        return;
                    }

                    Response.RedirectUser("RegisterCustomer/RegisterCustomer.aspx?Customer=Existing&Action=Forward&EventID=" + EventId + "&guid=" + GuId);
                }
                else
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerText = "Customer Product not match from Event Product list.";
                    return;
                }
            }
            else
            {
                Response.RedirectUser("RegisterCustomer/RegisterCustomer.aspx?Customer=Existing&Action=Forward" + "&guid=" + GuId);
            }
        }

        protected void lnkSkipNewCustomer_Click(object sender, EventArgs e)
        {
       
            string queryString = string.Concat("FirstName=", txtFirstName.Text.Trim(), "&LastName=", txtLastName.Text,
                                               "&ZipCode=", txtZip.Text, "&State=", ddlstate.SelectedItem.Value);

            CustomerId = 0;
            if (EventId.HasValue)
            {
                Response.RedirectUser("RegisterCustomer/RegisterCustomer.aspx?Customer=New&EventID=" + EventId + "&" + queryString + "&guid=" + GuId);
            }
            else
            {
                Response.RedirectUser("RegisterCustomer/RegisterCustomer.aspx?" + queryString + "&guid=" + GuId);
            }
        }

        #region Method

        private void BindStateDropDown()
        {
            IStateRepository stateRepository = new StateRepository();
            var states = stateRepository.GetAllStates();

            ddlstate.DataSource = states;
            ddlstate.DataTextField = DDL_TEXT_NAME;
            ddlstate.DataValueField = DDL_VALUE_ID;
            ddlstate.DataBind();
            ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
        }

        private void BindCustomerDataGrid()
        {
            
            try
            {
                var customers = GetCustomersbyFilter();

                if (customers.Count > 0)
                {
                    divGrdCust.Visible = true;
                    divGrdCust.Style["display"] = string.Empty;
                    divSkipNewCustomer.Visible = true;

                    grdCustomerHistory.DataSource = customers;
                    grdCustomerHistory.DataBind();
                }
                else
                {
                    divGrdCust.Visible = false;
                    divSkipNewCustomer.Visible = true;
                    divErrorMsg.InnerText = "No Record found";
                    divErrorMsg.Visible = true;
                }
            }
            catch (Exception)
            {
                divGrdCust.Visible = false;
                divSkipNewCustomer.Visible = true;
                divErrorMsg.InnerText = "No Record found";
                divErrorMsg.Visible = true;

            }
        }
        
        private List<Core.Users.Domain.Customer> GetCustomersbyFilter()
        {
            ICustomerRepository customerRepository = new CustomerRepository();
            
            DateTime? registrationDate = null;
            if (!string.IsNullOrEmpty(txtRegDate.Text))
            {
                DateTime regDate;
                if (DateTime.TryParse(txtRegDate.Text, out regDate))
                    registrationDate = regDate;
            }
            string phoneNumber = string.Empty;
            if(!string.IsNullOrEmpty(txtPhone.Text))
            {
                phoneNumber = txtPhone.Text.Replace("(", "").Replace(")", "").Replace("-", "");
            }

            var customers = customerRepository.GetCustomerByFilters(txtFirstName.Text, txtLastName.Text, CustomerId,
                                                                    Convert.ToInt64(ddlstate.SelectedValue),
                                                                    txtCity.Text,
                                                                    txtZip.Text, registrationDate, phoneNumber);
            var filter = new
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                CustomerId,
                State = ddlstate.SelectedItem.Text == "Select State" ? "" : ddlstate.SelectedItem.Text,
                City = txtCity.Text,
                Zip = txtZip.Text,
                RegistrationDate = registrationDate.HasValue ? registrationDate.Value.ToShortDateString():""
            };
            LogFilterListPairAudit(filter, customers);
            if (customers.Count() > 20)
            {
                divMoreResults.Visible = true;
                //Customers = Customers.Skip((pageNumber - 1)*pageSize).Take(pageSize).ToList();
            }

            return customers;
        }

        private void SetTitles()
        {
            Page.Title = "Search Customer";
            var masterPage = (Franchisee_Technician_TechnicianMaster) Master;
            if(masterPage!=null)
            {
                masterPage.settitle("Search Customer");
                masterPage.SetBreadcrumb = "<a href=\"/Scheduling/Event/Index?showUpcoming=true\">Dashboard></a>";
            }
        }

        private void SetJavaScriptEvents()
        {
            txtFirstName.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtLastName.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtCustomerID.Attributes.Add("onKeyDown", "return txtkeypress_numeric(event);");
            txtRegDate.Attributes.Add("onblur", "setFocusState();");
        }
        #endregion
    }
}