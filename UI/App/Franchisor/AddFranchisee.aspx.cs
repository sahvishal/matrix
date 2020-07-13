using System;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Operations.Repositories;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Operations;
using Falcon.App.Core.Operations.Domain;
using Falcon.App.Core.Geo;
using System.Collections.Generic;
using Falcon.App.UI.Extentions;

public partial class Franchisor_AddFranchisee : Page
{

    public long FranchiseeId
    {
        get
        {
            long franchiseeId = 0;

            if (Request.QueryString["FranchiseeId"] != null)
                long.TryParse(Request.QueryString["FranchiseeId"], out franchiseeId);

            return franchiseeId;
        }
    }
    public long _countryId;

    /// <summary>
    /// Set up the page, and fill the data.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        var obj = (Franchisor_FranchisorMaster)this.Master;
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/FranchiseeApplication.aspx\">Franchisee</a>";
        obj.hideucsearch();

        errormsg.InnerText = "";

        if (FranchiseeId > 0)
        {
            Page.Title = "Edit Franchisee";
            sppoptitle.InnerText = "Edit Franchisee";
            obj.settitle("Edit Franchisee");
        }
        else
            obj.settitle("Add Franchisee");

        if (!IsPostBack)
        {
            GetDropDownInfo();
            chkBiAddress.Checked = false;
            if (Request.QueryString["Action"] != null)
            {
                ClientScript.RegisterStartupScript(typeof(string), "sfjicode", "alert('Franchisee has been created please update Pod and other details');", true);
            }

            if (FranchiseeId > 0)
            {
                GetFranchiseeData();
                GetDefaultuserData();
            }
        }
        SetBillingAddress();
    }

    /// <summary>
    /// Fill all the DropDown Data. 
    /// </summary>
    private void GetDropDownInfo()
    {
        IStateRepository stateRepository = new StateRepository();
        var states = stateRepository.GetAllStates();

        var fillState = new Func<DropDownList, DropDownList>(ddl =>
        {
            ddl.Items.Clear();

            ddl.DataSource = states;
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Id";
            ddl.DataBind();

            ddl.Items.Insert(0, new ListItem("Select State", "0"));
            return ddl;
        });

        ddlBiState = fillState(ddlBiState);
        ddlBuState = fillState(ddlBuState);

        FillPod();
    }

    /// <summary>
    /// cancel the Operation and redirect to the Franchiosr home page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Cancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("~/App/Franchisor/ViewFranchisee.aspx");
    }

    /// <summary>
    /// Save the Franchisee data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        var isSuccessful = SaveData();
        if (isSuccessful)
        {
            Response.RedirectUser(FranchiseeId < 1
                                  ? "~/App/Franchisor/ViewFranchisee.aspx?Action=Added"
                                  : "~/App/Franchisor/ViewFranchisee.aspx?Action=Updated");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    protected void SetBillingAddress()
    {
        divBillingAddress.Disabled = !chkBiAddress.Checked;
        txtBiAddress1.Enabled = (chkBiAddress.Checked);
        txtBiAddress2.Enabled = (chkBiAddress.Checked);
        ddlBiState.Enabled = (chkBiAddress.Checked);
        txtBiCity.Enabled = (chkBiAddress.Checked);
        txtBiZip.Enabled = (chkBiAddress.Checked);
    }

    #region "Save Data"
    private bool SaveData()
    {
        var organziationService = IoC.Resolve<IOrganizationService>();
        var userService = IoC.Resolve<IUserService>();
        var countryRepository = IoC.Resolve<ICountryRepository>();
        _countryId = countryRepository.GetAll().FirstOrDefault().Id;

        FranchiseeEditModel franchiseeEditModel = null;
        User user = null;

        if (FranchiseeId > 0)
        {
            franchiseeEditModel = organziationService.GetFranchiseeCreateModel(FranchiseeId);
            user = userService.GetDefaultUserforOrganization(FranchiseeId, OrganizationType.Franchisee);
        }

        var userRepository = IoC.Resolve<IUserRepository<User>>();
        if (user == null || user.Email.ToString() != UCAddress1.Email)
        {
            if (!userRepository.UniqueEmail(UCAddress1.Email))
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "Contact email already exists. Please try another email.";
                return false;
            }
        }

        franchiseeEditModel = SetFranchiseeData(franchiseeEditModel);
        user = SetDefaulUserData(user);

        if (FranchiseeId == 0 && userRepository.UserNameExists(LoginIdTextbox.Text))
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Please specify a unique user name.";
            return false;
        }

        if (franchiseeEditModel == null || user == null)
        {
            return false;
        }

        try
        {
            using (var scope = new TransactionScope())
            {
                var organizationId = organziationService.CreateFranchisee(franchiseeEditModel);
                userService.SaveDefaultUserforOrganization(organizationId, OrganizationType.Franchisee, user);
                scope.Complete();
                return true;
            }
        }
        catch (InvalidAddressException ex)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Invalid Address Exception. Exception Message : " + ex.Message;
            return false;
        }
        catch (Exception ex)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Some database error occured. Exception Message : " + ex.Message;
            return false;
        }
    }

    private bool ValidateAddress(Address address)
    {
        IAddressRepository addressRepository = new AddressRepository();
        try
        {
            var isValid = addressRepository.ValidateAddress(address);
            return isValid;
        }
        catch (InvalidAddressException ex)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bijscode", "alert('" + ex.Message + "');", true);
            return false;
        }
    }

    private bool CheckifAddressisEmpty(Address address)
    {
        if (string.IsNullOrEmpty(address.StreetAddressLine1) && string.IsNullOrEmpty(address.State) && string.IsNullOrEmpty(address.City) && address.ZipCode == null)
        {
            return true;
        }
        return false;
    }

    private FranchiseeEditModel SetFranchiseeData(FranchiseeEditModel franchiseeEditModel)
    {
        if (franchiseeEditModel == null) franchiseeEditModel = new FranchiseeEditModel();

        franchiseeEditModel.Name = txtFranchiseeName.Text;
        franchiseeEditModel.Description = txtDesciption.Text;

        var address = new AddressEditModel();
        address.StreetAddressLine1 = txtbuaddress1.Text;
        address.StreetAddressLine2 = txtbuaddress2.Text;
        address.CountryId = _countryId;

        if (ddlBuState.SelectedIndex > 0)
            address.StateId = Convert.ToInt32(ddlBuState.SelectedItem.Value);
        address.City = txtBuCity.Text;
        if (!string.IsNullOrEmpty(txtBuZip.Text)) address.ZipCode = txtBuZip.Text;

        if (!address.IsEmpty())
        {
            if (franchiseeEditModel.BusinessAddress != null) address.Id = franchiseeEditModel.BusinessAddress.Id;

            franchiseeEditModel.BusinessAddress = address;
        }
        else
        {
            franchiseeEditModel.BusinessAddress = null;
        }

        if (!chkBiAddress.Checked)
        {
            address = new AddressEditModel();
            address.StreetAddressLine1 = txtBiAddress1.Text;
            address.StreetAddressLine2 = txtBiAddress2.Text;
            address.CountryId = _countryId;
            if (ddlBiState.SelectedIndex > 0)
                address.StateId = Convert.ToInt32(ddlBiState.SelectedItem.Value);
            address.City = txtBiCity.Text;
            if (!string.IsNullOrEmpty(txtBiZip.Text)) address.ZipCode = txtBiZip.Text;

            if (!address.IsEmpty())
            {
                if (franchiseeEditModel.BillingAddress != null) address.Id = franchiseeEditModel.BillingAddress.Id;

                franchiseeEditModel.BillingAddress = address;
            }
            else
            {
                franchiseeEditModel.BillingAddress = null;
            }
        }
        else
        {
            address.Id = 0;
            if (franchiseeEditModel.BillingAddress != null) address.Id = franchiseeEditModel.BillingAddress.Id;
            franchiseeEditModel.BillingAddress = address;
        }

        franchiseeEditModel.FaxNumber = new PhoneNumber() { Number = txtBuFax.Text };
        franchiseeEditModel.PhoneNumber = new PhoneNumber() { Number = txtBuPhone.Text };

        var pods = new List<Pod>();
        foreach (ListItem item in PodCheckboxList.Items)
        {
            pods.Add(new Pod(Convert.ToInt64(item.Value)));
        }

        franchiseeEditModel.AllocatedPods = pods.ToArray();
        return franchiseeEditModel;
    }

    private User SetDefaulUserData(User user)
    {
        if (user == null) user = new User();
        user.Name = new Name(txtFName.Text, txtMName.Text, txtLName.Text);

        var address = new Address();
        address.StreetAddressLine1 = UCAddress1.Address;
        address.StreetAddressLine2 = UCAddress1.AddressSuit;
        address.State = UCAddress1.StateText;
        address.City = UCAddress1.City;
        address.CountryId = _countryId;

        if (!string.IsNullOrEmpty(UCAddress1.Zip)) address.ZipCode = new ZipCode() { Zip = UCAddress1.Zip };

        var isEmpty = CheckifAddressisEmpty(address);
        if (!isEmpty)
        {
            if (!ValidateAddress(address)) return null;
            if (user.Address != null) address.Id = user.Address.Id;
            user.Address = address;
        }
        else
        {
            user.Address = null;
        }

        if (!string.IsNullOrEmpty(txtDOB.Text))
        {
            user.DateOfBirth = Convert.ToDateTime(txtDOB.Text);
        }

        user.MobilePhoneNumber = string.IsNullOrEmpty(UCAddress1.PhoneCell) ? new PhoneNumber() { Number = UCAddress1.PhoneCell }.ToNumber() : null;
        user.HomePhoneNumber = string.IsNullOrEmpty(UCAddress1.PhoneHome) ? new PhoneNumber() { Number = UCAddress1.PhoneHome }.ToNumber() : null;
        user.OfficePhoneNumber = string.IsNullOrEmpty(UCAddress1.PhoneOther) ? new PhoneNumber() { Number = UCAddress1.PhoneOther }.ToNumber() : null;

        if (!string.IsNullOrEmpty(UCAddress1.Email))
        {
            user.Email = new Email(UCAddress1.Email);
        }

        if (!string.IsNullOrEmpty(UCAddress1.EmailOther))
        {
            user.AlternateEmail = new Email(UCAddress1.EmailOther);
        }

        if (user.Id == 0)
        {
            user.UserLogin = new UserLogin();
            user.UserLogin.UserName = LoginIdTextbox.Text;
            user.UserLogin.Password = PasswordTextbox.Text;
        }

        return user;
    }

    #endregion

    #region "Fetch Data"
    private void GetFranchiseeData()
    {
        var organziationService = IoC.Resolve<IOrganizationService>();
        var franchiseeCreateModel = organziationService.GetFranchiseeCreateModel(FranchiseeId);

        txtFranchiseeName.Text = franchiseeCreateModel.Name;
        txtDesciption.Text = franchiseeCreateModel.Description;

        var address = franchiseeCreateModel.BusinessAddress;
        if (address != null)
        {
            txtbuaddress1.Text = address.StreetAddressLine1;
            txtbuaddress2.Text = address.StreetAddressLine2;
            if (address.StateId > 0)
                ddlBuState.Items.FindByValue(address.StateId.ToString()).Selected = true;

            txtBuCity.Text = address.City;
            if (!string.IsNullOrEmpty(address.ZipCode)) txtBuZip.Text = address.ZipCode;
        }

        address = franchiseeCreateModel.BillingAddress;
        if (address != null)
        {
            txtBiAddress1.Text = address.StreetAddressLine1;
            txtBiAddress2.Text = address.StreetAddressLine2;
            if (address.StateId > 0)
                ddlBiState.Items.FindByValue(address.StateId.ToString()).Selected = true;

            txtBiCity.Text = address.City;
            if (!string.IsNullOrEmpty(address.ZipCode)) txtBiZip.Text = address.ZipCode;
        }

        if (franchiseeCreateModel.AllocatedPods != null)
        {
            foreach (var item in franchiseeCreateModel.AllocatedPods)
            {
                var listItem = new ListItem(item.Name, item.Id.ToString());
                listItem.Selected = true;
                PodCheckboxList.Items.Add(listItem);
            }
        }


        txtBuFax.Text = franchiseeCreateModel.FaxNumber != null ? franchiseeCreateModel.FaxNumber.Number : string.Empty;
        txtBuPhone.Text = franchiseeCreateModel.PhoneNumber != null ? franchiseeCreateModel.PhoneNumber.Number : string.Empty;
    }

    private void GetDefaultuserData()
    {
        var userService = IoC.Resolve<IUserService>();
        var user = userService.GetDefaultUserforOrganization(FranchiseeId, OrganizationType.Franchisee);

        txtFName.Text = user.Name.FirstName;
        txtMName.Text = user.Name.MiddleName;
        txtLName.Text = user.Name.LastName;
        UCAddress1.Address = user.Address.StreetAddressLine1;
        UCAddress1.AddressSuit = user.Address.StreetAddressLine2;
        if (user.DateOfBirth != null)
        {
            txtDOB.Text = user.DateOfBirth.Value.ToShortDateString();
        }

        UCAddress1.StateText = user.Address.State;
        UCAddress1.City = user.Address.City;
        UCAddress1.Zip = user.Address.ZipCode.Zip;

        UCAddress1.PhoneCell = user.MobilePhoneNumber != null ? user.MobilePhoneNumber.Number : string.Empty;
        UCAddress1.PhoneHome = user.HomePhoneNumber != null ? user.HomePhoneNumber.Number : string.Empty;
        UCAddress1.PhoneOther = user.OfficePhoneNumber != null ? user.OfficePhoneNumber.Number : string.Empty;

        UCAddress1.Email = user.Email.ToString();
        UCAddress1.EmailOther = user.AlternateEmail != null ? user.AlternateEmail.ToString() : string.Empty;
    }
    #endregion

    private void FillPod()
    {
        IPodRepository podRepository = new PodRepository();
        var pods = podRepository.GetUnallocatedPods();

        PodCheckboxList.DataSource = pods;
        PodCheckboxList.DataTextField = "Name";
        PodCheckboxList.DataValueField = "Id";
        PodCheckboxList.DataBind();
    }
}
