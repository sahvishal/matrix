using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Finance.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.MedicalVendor;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Finance.Domain;
using System.Transactions;
using Falcon.Entity.MedicalVendor;
using Falcon.App.Core.Interfaces;

public partial class MedicalVendor_MedicalVendor : Page
{

    public long MedicalVendorId
    {
        get
        {
            long medicalVendorId = 0;
            if (Request.QueryString["MedicalVendorId"] != null)
            {
                long.TryParse(Request.QueryString["MedicalVendorId"], out medicalVendorId);
            }
            return medicalVendorId;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        var obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Add Medical Vendor");
        Page.Title = "Medical Vendor";
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"#\">Vendors</a>";

        txtDateApplied.Text = DateTime.Now.ToShortDateString();
        txtDateApplied.Enabled = false;
        gridtitle.InnerHtml = "Add New Medical Vendor";

        if (!IsPostBack)
        {
            chkHospitalPartner.Attributes.Add("onClick", "showHideHospitalPartnerDeatils();");
            rbtnLHosPrtTerOption.Attributes.Add("onClick", "showHideHospitalPartnerDeatils();");

            GetDropDownInfo();
            if (Request.QueryString["Action"] != null)
            {
                ClientScript.RegisterStartupScript(typeof(string), "sfjicode", "alert('Medical Vendor has been created please update its details');", true);
            }
            if (MedicalVendorId > 0)
            {
                Page.Title = "Edit Medical Vendor";
                gridtitle.InnerHtml = "Edit Medical Vendor";
                GetData();
            }

            txtPayRateCustomer.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            ViewState["ClickCount"] = 0;
        }

        ClientScript.RegisterStartupScript(Page.GetType(), "js_ShowHP", "showHideHospitalPartnerDeatils();", true);
        SetBillingAddress();
    }

    #region "Getdata"

    private void GetData()
    {
        GetMedicalVendorData();
        GetDefaultuserData();
    }

    private void GetMedicalVendorPaymentInstructions(PaymentInstructions instructions)
    {
        if (instructions == null) return;

        txtAccountHolder.Text = instructions.AccountHolderName;
        txtAccountNo.Text = instructions.AccountNumber;

        ddlAccountType.Items.FindByValue(Convert.ToString((int)instructions.AccountType)).Selected = true;
        ddlInterval.Items.FindByValue(Convert.ToString((int)instructions.Interval)).Selected = true;
        ddlPayMode.Items.FindByValue(Convert.ToString((int)instructions.PaymentMode)).Selected = true;

        txtBankName.Text = instructions.BankName;
        txtMemo.Text = instructions.Memo;

        txtRoutingNumber.Text = instructions.RoutingNumber;
        txtSplInstruction.Text = instructions.SpecialInsructions;
    }

    private void GetMedicalVendorData()
    {
        var organziationService = IoC.Resolve<IOrganizationService>();
        var medicalVendorCreateModel = organziationService.GetMedicalVendorCreateModel(MedicalVendorId);

        txtVendorName.Text = medicalVendorCreateModel.OrganizationEditModel.Name;
        DescriptionTextbox.Text = medicalVendorCreateModel.OrganizationEditModel.Description;
        ddlContracts.Items.FindByValue(medicalVendorCreateModel.ContractId.ToString()).Selected = true;
        //txtPayRateCustomer.Text = medicalVendorCreateModel.CustomerPayRate.ToString();
        ddlVendorType.Items.FindByValue(Convert.ToString((int)medicalVendorCreateModel.MedicalVendorType)).Selected = true;

        //GetMedicalVendorPaymentInstructions(medicalVendorCreateModel.PaymentInstructions);

        if (medicalVendorCreateModel.IsHospitalPartner)
            GetHospitalPartnerData();

        var address = medicalVendorCreateModel.OrganizationEditModel.BusinessAddress;
        if (address != null)
        {
            txtAddress1.Text = address.StreetAddressLine1;
            txtAddress2.Text = address.StreetAddressLine2;
            if (address.StateId > 0)
                ddlState.Items.FindByValue(address.StateId.ToString()).Selected = true;

            txtCity.Text = address.City;
            if (!string.IsNullOrEmpty(address.ZipCode)) txtZip.Text = address.ZipCode;
        }

        address = medicalVendorCreateModel.OrganizationEditModel.BillingAddress;
        if (address != null)
        {
            txtBiAddress1.Text = address.StreetAddressLine1;
            txtBiAddress2.Text = address.StreetAddressLine2;
            if (address.StateId > 0)
                ddlBiState.Items.FindByValue(address.StateId.ToString()).Selected = true;

            txtBiCity.Text = address.City;
            if (!string.IsNullOrEmpty(address.ZipCode)) txtBiZip.Text = address.ZipCode;
        }

        txtBusinessFax.Text = medicalVendorCreateModel.OrganizationEditModel.FaxNumber != null ? medicalVendorCreateModel.OrganizationEditModel.FaxNumber.Number : string.Empty;
        txtBusinessPhone.Text = medicalVendorCreateModel.OrganizationEditModel.PhoneNumber != null ? medicalVendorCreateModel.OrganizationEditModel.PhoneNumber.Number : string.Empty;

        //foreach (ListItem item in PermittedTestCheckboxList.Items)
        //{
        //    var selectedTest = (from test in medicalVendorCreateModel.PermittedTests
        //                        where Convert.ToString((long)test) == item.Value
        //                        select (int)test).FirstOrDefault();

        //    if (selectedTest > 0) item.Selected = true;
        //}
    }

    private void GetDefaultuserData()
    {
        var user = IoC.Resolve<IUserService>().GetDefaultUserforOrganization(MedicalVendorId, OrganizationType.MedicalVendor);

        txtFirstName.Text = user.Name.FirstName;
        txtMiddleName.Text = user.Name.MiddleName;
        txtLastName.Text = user.Name.LastName;
        UCAddress1.Address = user.Address.StreetAddressLine1;
        UCAddress1.AddressSuit = user.Address.StreetAddressLine2;
        if (user.DateOfBirth != null)
        {
            txtCDOB.Text = user.DateOfBirth.Value.ToShortDateString();
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

    private void GetHospitalPartnerData()
    {
        var repository = IoC.Resolve<IHospitalPartnerRepository>();
        var hospitalPartner = repository.GetHospitalPartnerforaVendor(MedicalVendorId);

        if (hospitalPartner != null)
        {
            chkHospitalPartner.Checked = true;
            txtAssociatedPhNo.Text = hospitalPartner.AssociatedPhoneNumber.ToString();
            //if (hospitalPartner.TerritoryId > 0)
            //{
            //    rbtnLHosPrtTerOption.Items.FindByValue("2").Selected = true;
            //    ddlTerritory.SelectedValue = hospitalPartner.TerritoryId.ToString();
            ////}
            //else if (hospitalPartner.IsGlobal)
            //{
            //    rbtnLHosPrtTerOption.Items.FindByValue("1").Selected = true;
            //}

            var packageRepository = IoC.Resolve<IPackageRepository>();
            var packages = packageRepository.GetPackagesByHospitalPartner(MedicalVendorId);

            foreach (var package in packages)
            {
                var item = packagesList.Items.FindByValue(package.Id.ToString());
                if (item != null)
                    item.Selected = true;
            }
        }
    }

    #endregion

    #region "Save Data"

    private long _countryId;

    private bool SaveData()
    {
        var organziationService = IoC.Resolve<IOrganizationService>();
        var userService = IoC.Resolve<IUserService>();
        var countryRepository = IoC.Resolve<ICountryRepository>();
        _countryId = countryRepository.GetAll().FirstOrDefault().Id;

        MedicalVendorEditModel medicalVendorEditModel = null;
        User user = null;

        if (MedicalVendorId > 0)
        {
            medicalVendorEditModel = organziationService.GetMedicalVendorCreateModel(MedicalVendorId);
            user = userService.GetDefaultUserforOrganization(MedicalVendorId, OrganizationType.MedicalVendor);
        }

        var userRepository = IoC.Resolve<IUserRepository<User>>();
        if (user == null || (user.Email.ToString() != UCAddress1.Email))
        {
            if (!userRepository.UniqueEmail(UCAddress1.Email))
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "Contact email already exists. Please try another email.";
                return false;
            }
        }

        medicalVendorEditModel = SetMedicalVendorData(medicalVendorEditModel);
        user = SetDefaulUserData(user);

        if (MedicalVendorId == 0 && userRepository.UserNameExists(txtUserName.Text))
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = "Please specify a unique user name.";
            return false;
        }

        if (medicalVendorEditModel == null || user == null)
        {
            return false;
        }

        try
        {
            using (var scope = new TransactionScope())
            {
                var organizationId = organziationService.CreateMedicalVendor(medicalVendorEditModel);
                userService.SaveDefaultUserforOrganization(organizationId, OrganizationType.MedicalVendor, user);
                SaveHospitalPartner(organizationId);
                scope.Complete();
                return true;
            }
        }
        catch (InvalidAddressException ex)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Some database error occured. Exception Message : " + ex.Message;
            return false;
        }
        catch (Exception ex)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Some database error occured. Exception Message : " + ex.Message;
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

    private PaymentInstructions SetMedicalVendorPaymentInstructions(PaymentInstructions instructions)
    {
        if (instructions == null) instructions = new PaymentInstructions();
        instructions.AccountHolderName = txtAccountHolder.Text;
        instructions.AccountNumber = txtAccountNo.Text;

        if (ddlAccountType.SelectedIndex > 0)
            instructions.AccountType = (AccountType)Convert.ToInt32(ddlAccountType.SelectedValue);

        instructions.BankName = txtBankName.Text;
        if (ddlInterval.SelectedIndex > 0)
            instructions.Interval = (PaymentFrequency)Convert.ToInt32(ddlInterval.SelectedValue);

        instructions.Memo = txtMemo.Text;
        if (ddlPayMode.SelectedIndex > 0)
            instructions.PaymentMode = (VendorPaymentMode)Convert.ToInt32(ddlPayMode.SelectedValue);

        instructions.RoutingNumber = txtRoutingNumber.Text;
        instructions.SpecialInsructions = txtSplInstruction.Text;

        return instructions;
    }

    private MedicalVendorEditModel SetMedicalVendorData(MedicalVendorEditModel medicalVendorEditModel)
    {
        if (medicalVendorEditModel == null) medicalVendorEditModel = new MedicalVendorEditModel();

        medicalVendorEditModel.OrganizationEditModel.Name = txtVendorName.Text;
        medicalVendorEditModel.OrganizationEditModel.Description = DescriptionTextbox.Text;
        medicalVendorEditModel.ContractId = Convert.ToInt64(ddlContracts.SelectedItem.Value);
        //medicalVendorEditModel.EvaluationMode = EvaluationMode.Customer; // This is default for the time being
        //medicalVendorEditModel.CustomerPayRate = Convert.ToDecimal(txtPayRateCustomer.Text);
        medicalVendorEditModel.MedicalVendorType = Convert.ToInt32(ddlVendorType.SelectedValue);
        medicalVendorEditModel.IsHospitalPartner = chkHospitalPartner.Checked;

        #region "Setting Addresses"
        var address = new AddressEditModel();
        address.StreetAddressLine1 = txtAddress1.Text;
        address.StreetAddressLine2 = txtAddress2.Text;
        address.CountryId = _countryId;

        if (ddlState.SelectedIndex > 0)
            address.StateId = Convert.ToInt32(ddlState.SelectedItem.Value);
        address.City = txtCity.Text;
        if (!string.IsNullOrEmpty(txtZip.Text)) address.ZipCode = txtZip.Text;


        if (!address.IsEmpty())
        {
            if (medicalVendorEditModel.OrganizationEditModel.BusinessAddress != null) address.Id = medicalVendorEditModel.OrganizationEditModel.BusinessAddress.Id;

            medicalVendorEditModel.OrganizationEditModel.BusinessAddress = address;
        }
        else
        {
            medicalVendorEditModel.OrganizationEditModel.BusinessAddress = null;
        }

        if (!chkBiAddress.Checked)
        {
            address = new AddressEditModel();
            address.StreetAddressLine1 = txtBiAddress1.Text;
            address.StreetAddressLine2 = txtBiAddress2.Text;
            address.CountryId = _countryId;
            if (ddlBiState.SelectedIndex > 0)
                address.StateId = Convert.ToInt32(ddlBiState.SelectedItem.Text);
            address.City = txtBiCity.Text;
            if (!string.IsNullOrEmpty(txtBiZip.Text)) address.ZipCode = txtBiZip.Text;

            if (!address.IsEmpty())
            {
                if (medicalVendorEditModel.OrganizationEditModel.BillingAddress != null) address.Id = medicalVendorEditModel.OrganizationEditModel.BillingAddress.Id;

                medicalVendorEditModel.OrganizationEditModel.BillingAddress = address;
            }
            else
            {
                medicalVendorEditModel.OrganizationEditModel.BillingAddress = null;
            }
        }
        else
        {
            address.Id = 0;
            if (medicalVendorEditModel.OrganizationEditModel.BillingAddress != null) address.Id = medicalVendorEditModel.OrganizationEditModel.BillingAddress.Id;
            medicalVendorEditModel.OrganizationEditModel.BillingAddress = address;
        }
        #endregion

        medicalVendorEditModel.OrganizationEditModel.FaxNumber = new PhoneNumber() { Number = txtBusinessFax.Text };
        medicalVendorEditModel.OrganizationEditModel.PhoneNumber = new PhoneNumber() { Number = txtBusinessPhone.Text };

        //medicalVendorEditModel.PaymentInstructions =
        //    SetMedicalVendorPaymentInstructions(medicalVendorEditModel.PaymentInstructions);


        var selectedItems = (from item in PermittedTestCheckboxList.Items.OfType<ListItem>()
                             where item.Selected
                             select (TestType)Convert.ToInt32(item.Value)).ToArray();

        if (selectedItems.Length < 1)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bijscode", "alert('Please select a test.');", true);
            return null;
        }

        //medicalVendorEditModel.PermittedTests = selectedItems;

        return medicalVendorEditModel;
    }

    private User SetDefaulUserData(User user)
    {
        if (user == null) user = new User();
        user.Name = new Name(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text);

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
            if (user.Address != null) address.Id = user.Address.Id;
            user.Address = address;
        }
        else
        {
            user.Address = null;
        }

        if (!string.IsNullOrEmpty(txtCDOB.Text))
        {
            user.DateOfBirth = Convert.ToDateTime(txtCDOB.Text);
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
            user.UserLogin.UserName = txtUserName.Text;
            user.UserLogin.Password = txtPassword.Text;
        }

        return user;
    }

    #endregion

    private void GetVendorType()
    {
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        var medicalVendorTypes = medicalVendorDal.GetMedicalVendorType(string.Empty, 0);

        if (medicalVendorTypes != null && medicalVendorTypes.Count > 0)
        {
            ddlVendorType.DataTextField = "Name";
            ddlVendorType.DataValueField = "MedicalVendorTypeID";
            ddlVendorType.DataSource = medicalVendorTypes;
            ddlVendorType.DataBind();
        }
        ddlVendorType.Items.Insert(0, new ListItem("Select Type", "0"));
    }

    private void GetContract()
    {
        MasterDAL masterDal = new MasterDAL();
        var contract = masterDal.GetContract(string.Empty, 3);

        if (contract != null && contract.Count > 0)
        {
            ddlContracts.DataTextField = "Name";
            ddlContracts.DataValueField = "ContractID";
            ddlContracts.DataSource = contract;
            ddlContracts.DataBind();
        }
        ddlContracts.Items.Insert(0, new ListItem("Select Contract", "0"));

    }

    /// <summary>
    /// Gets the drop down info.
    /// </summary>
    private void GetDropDownInfo()
    {
        var stateRepository = IoC.Resolve<IStateRepository>();
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
        ddlState = fillState(ddlState);
        ddlBiState = fillState(ddlBiState);

        GetVendorType();
        GetContract();

        var testRepository = IoC.Resolve<ITestRepository>();
        var tests = testRepository.GetAll();
        PermittedTestCheckboxList.DataTextField = "Name";
        PermittedTestCheckboxList.DataValueField = "Id";
        PermittedTestCheckboxList.DataSource = tests;
        PermittedTestCheckboxList.DataBind();

        ddlPayMode.Items.Add(new ListItem("Select Mode", "0"));
        ddlPayMode.Items.Add(new ListItem(VendorPaymentMode.Check.ToString(), Convert.ToString((int)VendorPaymentMode.Check)));
        ddlPayMode.Items.Add(new ListItem(VendorPaymentMode.Wire.ToString(), Convert.ToString((int)VendorPaymentMode.Wire)));

        ddlInterval.Items.Add(new ListItem("Select Interval", "0"));
        ddlInterval.Items.Add(new ListItem(PaymentFrequency.Weekly.ToString(), Convert.ToString((int)PaymentFrequency.Weekly)));
        ddlInterval.Items.Add(new ListItem(PaymentFrequency.BiWeekly.ToString(), Convert.ToString((int)PaymentFrequency.BiWeekly)));
        ddlInterval.Items.Add(new ListItem(PaymentFrequency.Monthly.ToString(), Convert.ToString((int)PaymentFrequency.Monthly)));

        ddlAccountType.Items.Add(new ListItem("Select Account Type", "0"));
        ddlAccountType.Items.Add(new ListItem(AccountType.Checking.ToString(),
                                              Convert.ToString((int)AccountType.Checking)));
        ddlAccountType.Items.Add(new ListItem(AccountType.Savings.ToString(),
                                              Convert.ToString((int)AccountType.Savings)));

        ddlEvaluation.Items.Add(new ListItem("Select Mode", "0"));
        ddlEvaluation.Items.Add(new ListItem(EvaluationMode.Customer.ToString(),
                                              Convert.ToString((int)EvaluationMode.Customer)));
        ddlEvaluation.Items[ddlEvaluation.Items.Count - 1].Selected = true;

        ddlEvaluation.Items.Add(new ListItem(EvaluationMode.Test.ToString(),
                                              Convert.ToString((int)EvaluationMode.Test)));

        ddlEvaluation.Enabled = false;

        //fill Territory
        var territoryRepository = IoC.Resolve<ITerritoryRepository>();
        var territories = territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.HospitalPartner);
        if (territories != null && territories.Count() > 0)
        {
            ddlTerritory.DataSource = territories;
            ddlTerritory.DataTextField = "SecondValue";
            ddlTerritory.DataValueField = "FirstValue";
            ddlTerritory.DataBind();
        }

        ddlTerritory.Items.Insert(0, new ListItem("Select Territory", "0"));

        var packageRepository = IoC.Resolve<IPackageRepository>();
        var packages = packageRepository.GetAll();
        if (packages != null && packages.Count > 0)
        {
            packagesList.DataSource = packages;
            packagesList.DataTextField = "Name";
            packagesList.DataValueField = "Id";
            packagesList.DataBind();
            packagesList.RepeatColumns = 2;

        }
    }

    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        var isSuccessful = SaveData();
        if (isSuccessful)
        {
            Response.RedirectUser("~/App/Franchisor/ViewMedicalVendor.aspx");
        }
    }

    protected void DisableElements()
    {
        txtVendorName.Enabled = false;
        txtDateApplied.Enabled = false;
        ddlVendorType.Enabled = false;
    }

    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("~/App/Franchisor/ViewMedicalVendor.aspx");
    }

    protected void SetBillingAddress()
    {
        divBillingAddress.Disabled = !chkBiAddress.Checked;
        txtBiAddress1.Enabled = (chkBiAddress.Checked);
        txtBiAddress2.Enabled = (chkBiAddress.Checked);
        ddlBiState.Enabled = (chkBiAddress.Checked);
        txtBiCity.Enabled = (chkBiAddress.Checked);
        txtBiZip.Enabled = (chkBiAddress.Checked);
    }

    private void SaveHospitalPartner(long medicalVendorId)
    {
        if (!chkHospitalPartner.Checked) return;

        var hospitalPartner = new EHospitalPartner();
        hospitalPartner.AssociatedPhoneNumber =
            new PhoneNumber { Number = txtAssociatedPhNo.Text }.ToNumber().ToString();

        if (rbtnLHosPrtTerOption.SelectedValue == "1")
            hospitalPartner.IsGlobal = true;
        else
        {
            hospitalPartner.IsGlobal = false;
            hospitalPartner.TerritoryID = Convert.ToInt32(ddlTerritory.SelectedValue);
        }

        hospitalPartner.IsActive = true;

        var currentOrgRoleUserId =
            IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        hospitalPartner.CreatedBy = currentOrgRoleUserId;
        hospitalPartner.ModifiedBy = currentOrgRoleUserId;
        hospitalPartner.MedicalVendorID = medicalVendorId;

        var packageIds = (from ListItem item in packagesList.Items where item.Selected select Convert.ToInt64(item.Value)).ToList();

        var dal = new MedicalVendorDAL();
        dal.SaveHospitalPartner(hospitalPartner, 1, 1, null, packageIds);
    }

}
