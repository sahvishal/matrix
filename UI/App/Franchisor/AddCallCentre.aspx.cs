using System;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

public partial class CallCenter_AddCallCentre : Page
{

    public long CountryId
    {
        get
        {
            var countryRepository = IoC.Resolve<ICountryRepository>();
            return countryRepository.GetAll().FirstOrDefault().Id;
        }
    }

    public long CallCenterId
    {
        get
        {
            long callCenterId = 0;
            if (Request.QueryString["CallCenterID"] != null)
            {
                long.TryParse(Request.QueryString["CallCenterID"], out callCenterId);
            }
            return callCenterId;
            
            
        }
    }

    private IAddressRepository _addressRepository; 

    protected void Page_Load(object sender, EventArgs e)
    {
        var obj = (Franchisor_FranchisorMaster)this.Master;
       
        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ViewCallCentre.aspx\">View Call Center</a>";
        if (IsPostBack) return;

        GetDropDownInfo();
        if (CallCenterId > 0)
        {
            Page.Title = "Edit Call Center";
            obj.settitle("Edit Call Center");
            sptitle.InnerText = "Edit Call Center";
            txtUserName.Enabled = false;
            FillCallCenter();
        }
        else
        {
            Page.Title = "Add Call Center";
            obj.settitle("Add Call Center");
        }

        sptitle.InnerText = "Add Call Center";
        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "none");
       
        txtzip1.Attributes.Add("onKeyDown", "return txtkeypress(event);");
        txtzip2.Attributes.Add("onKeyDown", "return txtkeypress(event);");
    }
    
    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        _addressRepository = IoC.Resolve<IAddressRepository>();
        
        bool returnresult;
        if (CallCenterId == 0)
        {
            returnresult = SaveCallCenter();
            if (returnresult)
                Response.RedirectUser("viewcallcentre.aspx?Action=Added");
        }
        else
        {
            returnresult = UpdateCallCenter(CallCenterId);
            if (returnresult)
                Response.RedirectUser("viewcallcentre.aspx?Action=Updated");
        }


        divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
    }
    
    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("ViewCallCentre.aspx");
    }


    private bool SaveCallCenter()
    {
        // format phone no.

        var userRepository = IoC.Resolve<IUserRepository<User>>();

        if (userRepository.UserNameExists(txtUserName.Text))
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "User Name not available. Please try another User Name.";
            return false;
        }

        // Set Organization

        var organizationCreateModel = BuildOrganizationCreateModel();

        // Set User
        var user = BuildDefaultUser(null);

        if (organizationCreateModel == null || user == null) return false;

        var organziationRepository = IoC.Resolve<IOrganizationService>();
        var userService = IoC.Resolve<IUserService>();

        try
        {
            using (var scope = new TransactionScope())
            {
                var organizationId = organziationRepository.Create(organizationCreateModel);
                userService.SaveDefaultUserforOrganization(organizationId, OrganizationType.CallCenter, user);
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
        catch (Exception)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Error while saving data!";
            return false;
        }
    }

  
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

        ddlstate1 = fillState(ddlstate1);
        ddlstate2 = fillState(ddlstate2);
    }

    private OrganizationEditModel BuildOrganizationCreateModel()
    {
        var organizationCreateModel = new OrganizationEditModel();

        organizationCreateModel.Name = txtbname.Text;
        organizationCreateModel.OrganizationType = OrganizationType.CallCenter;

        organizationCreateModel.Description = txtabtmself.Text;


        var businessAddress = new AddressEditModel();
        businessAddress.StreetAddressLine1 = txtaddress1.Text;
        businessAddress.StreetAddressLine2 = string.Empty;
        businessAddress.CountryId = CountryId;//new CountryRepository().GetById(Convert.ToInt32(hfBusinessCountryID.Value)).Name;
        businessAddress.StateId = Convert.ToInt32(ddlstate1.SelectedItem.Value);
        businessAddress.City = txtBuCity.Text;
        businessAddress.ZipCode = txtzip1.Text ;
        
        organizationCreateModel.BusinessAddress = businessAddress;

        //Have to remove this
        organizationCreateModel.PhoneNumber = new PhoneNumber() { Number = txtbphone.Text }.ToNumber();
        organizationCreateModel.FaxNumber = new PhoneNumber() { Number = txtbfax.Text }.ToNumber();

        return organizationCreateModel;
    }

    private User BuildDefaultUser(User defaultUserforOrganization)
    {
        var userRepository = IoC.Resolve<IUserRepository<User>>();
        

        var user = new User();

        if (defaultUserforOrganization != null) user = defaultUserforOrganization;

        user.Name = new Name(txtfname.Text, txtmname.Text, txtlname.Text);

        var userAddress = new Address();
        userAddress.StreetAddressLine1 = txtcntaddress1.Text;
        userAddress.StreetAddressLine2 = string.Empty;
        userAddress.CountryId = CountryId;//new CountryRepository().GetById(Convert.ToInt32(hfBusinessCountryID.Value)).Name;
        userAddress.State = ddlstate2.SelectedItem.Text;
        userAddress.City = txtCCity.Text;
        userAddress.ZipCode = new ZipCode() { Zip = txtzip2.Text };


        try
        {
            if (!_addressRepository.ValidateAddress(userAddress)) return null;
        }
        catch (InvalidAddressException exception)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bijscode", "alert('" + exception.Message + "');", true);
            return null;
        }

        if (defaultUserforOrganization != null) userAddress.Id = defaultUserforOrganization.Address.Id;
        user.Address = userAddress;

        user.HomePhoneNumber = new PhoneNumber() { Number = txtphonehome.Text }.ToNumber();
        user.OfficePhoneNumber = new PhoneNumber() { Number = txtphoneother.Text }.ToNumber();
        user.MobilePhoneNumber = new PhoneNumber() { Number = txtphonecell.Text }.ToNumber();
        
        if (!string.IsNullOrWhiteSpace(txtEmail1.Text))
        {
            user.Email = new Email(txtEmail1.Text);
        }

        if (!string.IsNullOrWhiteSpace(txtEmail2.Text))
        {
            user.AlternateEmail = new Email(txtEmail2.Text);
        }

        if (user.Email != null)
        {
            if ((defaultUserforOrganization == null) || (defaultUserforOrganization.Email.ToString() != txtEmail1.Text))
            {
                if (!userRepository.UniqueEmail(user.Email.ToString()))
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerText = "Contact email already exists. Please try another email.";
                    return null;
                }
            }
        }

        if (user.AlternateEmail != null)
        {
            if ((defaultUserforOrganization == null) ||
                (defaultUserforOrganization.AlternateEmail.ToString() != txtEmail2.Text))
            {
                if (!userRepository.UniqueEmail(user.AlternateEmail.ToString()))
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerText = "Contact email already exists. Please try another email.";
                    return null;
                }
            }
        }

        if (!string.IsNullOrWhiteSpace(txtDOB.Text))
        {
            user.DateOfBirth = Convert.ToDateTime(txtDOB.Text);
        }

        //Are we using the SSN value?
        if (defaultUserforOrganization == null)
            user.UserLogin = new UserLogin {UserName = txtUserName.Text, Password = txtPassword.Text};
        else
        {
            user.UserLogin = defaultUserforOrganization.UserLogin;
        }

        return user;
    }

    private void FillCallCenter()
    {
        //Fetch CallCenter as Organization
        var organziationService = IoC.Resolve<IOrganizationService>();
        var callCenterCreateModel = organziationService.GetOrganizationCreateModel(CallCenterId);


        txtabtmself.Text = callCenterCreateModel.Description;
        txtbname.Text = callCenterCreateModel.Name;
        
        txtbphone.Text = callCenterCreateModel.PhoneNumber != null ? callCenterCreateModel.PhoneNumber.ToString() : string.Empty;
        txtbfax.Text = callCenterCreateModel.FaxNumber != null ? callCenterCreateModel.FaxNumber.ToString(): string.Empty;

        var businessAddress = callCenterCreateModel.BusinessAddress;
        txtaddress1.Text = businessAddress.StreetAddressLine1;
        ddlstate1.Items.FindByValue(businessAddress.StateId.ToString()).Selected = true;
        txtBuCity.Text = businessAddress.City;
        txtzip1.Text = businessAddress.ZipCode;

        //Fetch call center user
        var userService = IoC.Resolve<IUserService>();
        var user = userService.GetDefaultUserforOrganization(CallCenterId, OrganizationType.CallCenter);

        txtfname.Text = user.Name.FirstName;
        txtmname.Text = user.Name.MiddleName;
        txtlname.Text = user.Name.LastName;

        if (user.DateOfBirth != null)
        {
            txtDOB.Text = user.DateOfBirth.Value.ToShortDateString();
        }
        //We need it?
        //txtSSN.Text = contactuser.SSN;

        txtphonecell.Text = user.MobilePhoneNumber.ToString();
        txtphonehome.Text = user.HomePhoneNumber.ToString();
        txtphoneother.Text = user.OfficePhoneNumber.ToString();
        if (user.Email != null)
            txtEmail1.Text = user.Email.ToString();
        if (user.AlternateEmail != null)
            txtEmail2.Text = user.AlternateEmail.ToString();

        var address = user.Address;
        txtcntaddress1.Text = address.StreetAddressLine1;

        ddlstate2.Items.FindByText(address.State).Selected = true;
        txtCCity.Text = address.City;
        txtzip2.Text = address.ZipCode.Zip;

    }

    private bool UpdateCallCenter(long callCenterId)
    {
        var organziationRepository = IoC.Resolve<IOrganizationService>();
        var userService = IoC.Resolve<IUserService>();

        var organizationCreateModel = BuildOrganizationCreateModel();

        // Set User
        var defaultUserforOrganization = userService.GetDefaultUserforOrganization(callCenterId, OrganizationType.CallCenter);

        var user = BuildDefaultUser(defaultUserforOrganization);

        if (organizationCreateModel == null || user == null) return false;


        organizationCreateModel.Id = callCenterId;

        try
        {
            using (var scope = new TransactionScope())
            {
                var organizationId = organziationRepository.Create(organizationCreateModel);
                userService.SaveDefaultUserforOrganization(organizationId, OrganizationType.CallCenter, user);
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
        catch (Exception)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = "Error while saving data!";
            return false;
        }
    }


}
