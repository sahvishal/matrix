using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Shipping;
using Falcon.App.Infrastructure.Repositories.Users;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class UcShippingDetails : UserControl
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

        private const string DDL_VALUE_ID = "Id";
        private const string DDL_TEXT_NAME = "Name";

        private bool isStateFilled = false;

        private Core.Users.Domain.Customer _customer;

        private long CustomerId
        {
            get
            {
                return !string.IsNullOrEmpty(Request.QueryString["CustomerID"])
                           ? Convert.ToInt64(Request.QueryString["CustomerID"])
                           : RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
            }
        }

        protected long? ShippingOptionId
        {
            get
            {
                if (RegistrationFlow != null && RegistrationFlow.ShippingOptionId > 0)
                    return RegistrationFlow.ShippingOptionId;
                return null;
            }
        }

        private bool _showFreeOption = true;

        private bool _showOnlineOption = false;

        public bool ShowFreeOption { get { return _showFreeOption; } set { _showFreeOption = value; } }

        public bool ShowOnlineOption { get { return _showOnlineOption; } set { _showOnlineOption = value; } }

        public bool RemovePaidOption { get; set; }

        public EventType EventType { get; set; }

        public long AccountId { get; set; }

        public long EventId { get; set; }

        public List<long> TestIds { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RadioShippingAddressNo.Attributes.Add("onclick", "ShowShippingAddress();");
                RadioShippingAddressYes.Attributes.Add("onclick", "HideShippingAddress();");

                if (!isStateFilled)
                    BindDropDown();

                if (CustomerId != 0)
                {
                    GetCustomerData();
                }
                else if (IoC.Resolve<ISessionContext>().UserSession != null)
                {
                    IUserRepository<Core.Users.Domain.Customer> userRepository =
                           new UserRepository<Core.Users.Domain.Customer>();
                    var user = userRepository.GetUser(IoC.Resolve<ISessionContext>().UserSession.UserId);
                    if (user != null)
                        BindShippingAddress(user.Address);
                }

                BindShippingOptions();
            }
        }

        private void BindDropDown()
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            var countries = countryRepository.GetAll();
            ddlCountry.DataSource = countries;
            ddlCountry.DataTextField = DDL_TEXT_NAME;
            ddlCountry.DataValueField = DDL_VALUE_ID;
            ddlCountry.DataBind();
            ddlCountry.Items[0].Selected = true;
            //ddlCountry.Items.Insert(0, new ListItem("Select Country", "0"));
        }

        public string GetStates()
        {
            var stateRepository = IoC.Resolve<IStateRepository>();
            var states = stateRepository.GetAllStates();
            return new JavaScriptSerializer().Serialize(states);
        }

        private void BindShippingOptions()
        {
            IShippingOptionRepository shippingOptionRepository = new ShippingOptionRepository();
            List<ShippingOption> shippingOptions = null;
            var shippingOptionsToBind = new List<ShippingOption>();

            var eventTestRepository = IoC.Resolve<IEventTestRepository>();

            var awvTestIds = new[] { (long)TestType.AWV, (long)TestType.Medicare, (long)TestType.AwvSubsequent };
            var awvTests = eventTestRepository.GetByEventAndTestIds(EventId, awvTestIds);
            var hasAwvTestOnly = false;

            if (awvTests != null && awvTests.Any() && TestIds != null && TestIds.All(awvTestIds.Contains))
            {
                var onlineShippingOption = shippingOptionRepository.GetOnlineShippingOption();
                shippingOptionsToBind.Add(onlineShippingOption);
                hasAwvTestOnly = true;
            }
            else
            {
                if (EventType == EventType.Corporate && AccountId > 0)
                {
                    var onlineShippingOption = shippingOptionRepository.GetOnlineShippingOption();
                    shippingOptions = shippingOptionRepository.GetAllShippingOptionForCorporate(AccountId);
                    if (shippingOptions == null || shippingOptions.Count == 0)
                    {
                        shippingOptionsToBind.Add(onlineShippingOption);
                    }
                    else if (shippingOptions.Count == 1)
                    {
                        if (shippingOptions.Where(so => so.Price == 0).Any())
                            shippingOptionsToBind.AddRange(shippingOptions);
                        else
                        {
                            shippingOptionsToBind.Add(onlineShippingOption);
                            shippingOptionsToBind.AddRange(shippingOptions);
                        }
                    }
                    else
                    {
                        shippingOptionsToBind.Add(onlineShippingOption);
                        shippingOptionsToBind.AddRange(shippingOptions);
                    }
                }
                else
                {
                    var settings = IoC.Resolve<ISettings>();
                    var selectFreeShippingByDefault = settings.SelectFreeShippingByDefault;

                    var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
                    var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(EventId);

                    if (hospitalPartnerId > 0)
                    {
                        var hospitalPartner = hospitalPartnerRepository.GetHospitalPartnerforaVendor(hospitalPartnerId);
                        shippingOptions = shippingOptionRepository.GetAllShippingOptionForHospitalPartner(hospitalPartnerId);
                        if (shippingOptions != null)
                            shippingOptions = shippingOptions.OrderBy(so => so.Price).ToList();

                        //if (selectFreeShippingByDefault)
                        //{
                        //    if (ShowOnlineOption && hospitalPartner.ShowOnlineShipping)
                        //    {
                        //        var onlineShippingOption = shippingOptionRepository.GetOnlineShippingOption();
                        //        shippingOptionsToBind.Add(onlineShippingOption);
                        //    }
                        //    if (shippingOptions != null && shippingOptions.Count > 0)
                        //    {
                        //        shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price == 0).Select(so => so));
                        //        shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price > 0).Select(so => so).OrderByDescending(so => so.Price));
                        //    }
                        //}
                        //else
                        //{
                        if (shippingOptions != null && shippingOptions.Count > 0)
                        {

                            shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price == 0).Select(so => so));
                            shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price > 0).Select(so => so).OrderByDescending(so => so.Price));
                        }

                        //if (ShowOnlineOption && hospitalPartner.ShowOnlineShipping)
                        //{
                        //    var onlineShippingOption = shippingOptionRepository.GetOnlineShippingOption();
                        //    shippingOptionsToBind.Add(onlineShippingOption);
                        //}
                        //}

                    }
                    else
                    {
                        shippingOptions = shippingOptionRepository.GetAllShippingOptionsForBuyingProcess().OrderBy(so => so.Price).ToList();
                        if (shippingOptions.Count > 0)
                        {
                            if (!ShowFreeOption)
                                shippingOptions.RemoveAll(sOption => sOption.Price == 0);
                            if (RemovePaidOption)
                                shippingOptions.RemoveAll(sOption => sOption.Price > 0);
                        }

                        //if (selectFreeShippingByDefault)
                        //{
                        //    if (ShowOnlineOption)
                        //    {
                        //        var onlineShippingOption = shippingOptionRepository.GetOnlineShippingOption();
                        //        shippingOptionsToBind.Add(onlineShippingOption);
                        //    }
                        //    if (shippingOptions.Count > 0)
                        //    {
                        //        shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price == 0).Select(so => so));
                        //        shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price > 0).Select(so => so).OrderByDescending(so => so.Price));

                        //    }
                        //}
                        //else
                        //{
                        if (shippingOptions.Count > 0)
                        {
                            shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price == 0).Select(so => so));
                            shippingOptionsToBind.AddRange(shippingOptions.Where(so => so.Price > 0).Select(so => so).OrderByDescending(so => so.Price));

                        }

                        //    if (ShowOnlineOption)
                        //    {
                        //        var onlineShippingOption = shippingOptionRepository.GetOnlineShippingOption();
                        //        shippingOptionsToBind.Add(onlineShippingOption);
                        //    }
                        //}
                    }
                }
            }

            if (shippingOptionsToBind.Count > 0)
            {
                grdvShippingOption.DataSource = shippingOptionsToBind;
                grdvShippingOption.DataBind();

                if (ShippingOptionId.HasValue && !hasAwvTestOnly)
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JS_SelectFirstOption", "$(document).ready(function () { FirstTimeLoad(" + ShippingOptionId.Value + "); });", true);
                else
                    Page.ClientScript.RegisterStartupScript(typeof(string), "JS_SelectFirstOption", "$(document).ready(function () { FirstTimeLoad(" + shippingOptionsToBind[0].Id + "); });", true);
            }
        }

        private void BindShippingAddress(Address address)
        {
            txtAddress1.Text = address.StreetAddressLine1;
            txtAddress2.Text = address.StreetAddressLine2;
            ddlCountry.SelectedValue = address.CountryId.ToString();
            txtCity.Text = address.City;
            hfstate.Value = address.State;
            txtZip.Text = address.ZipCode.Zip;
            RadioShippingAddressYes.Checked = true;
            RadioShippingAddressNo.Checked = false;
            DivShippingAddress.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        public Address SaveShippingAddress()
        {
            try
            {
                var addressService = IoC.Resolve<IAddressService>();
                var shippingAddress = new Address
                                          {
                                              StreetAddressLine1 = txtAddress1.Text,
                                              StreetAddressLine2 = txtAddress2.Text,
                                              City = txtCity.Text,
                                              State = hfstate.Value,
                                              ZipCode = new ZipCode { Zip = txtZip.Text },
                                              Country = ddlCountry.SelectedItem.Text
                                          };
                return addressService.SaveTemporaryAfterSanitizing(shippingAddress);
            }
            catch (Exception)
            {
                //MaintainAfterFailedPostBack();showOrderCatalog();
                Page.ClientScript.RegisterStartupScript(typeof(string), "JS_ShippingAddressValidation",
                    "ShowShippingAddress();FirstTimeLoad('" + (ShippingOptionId.HasValue ? ShippingOptionId.Value.ToString() : "0") + "');alert('" + "Given city, state, and zip is not valid." + "');", true);

            }
            return null;
        }

        public Core.Users.Domain.Customer GetCustomerData()
        {
            if (_customer == null || _customer.CustomerId != CustomerId)
            {
                ICustomerRepository customerRepository = new CustomerRepository();
                _customer = customerRepository.GetCustomer(CustomerId);
            }
            if (_customer != null && _customer.Address != null)
            {
                if (!isStateFilled)
                    BindDropDown();

                BindShippingAddress(_customer.Address);
            }
            var hideFreeOnlineOption = false;

            if (_customer != null)
            {
                hideFreeOnlineOption = _customer.Email == null || string.IsNullOrEmpty(_customer.Email.ToString());
            }

            if (ShowOnlineOption && EventType != EventType.Corporate && hideFreeOnlineOption)
            {
                ShowOnlineOption = false;
            }

            return _customer;
        }
    }
}