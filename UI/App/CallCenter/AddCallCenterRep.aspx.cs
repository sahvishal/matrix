using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.UI.Extentions;


public partial class CallCenter_AddCallCenterRep : Page
{
    public long CallCenterRepId
    {
        get
        {
            long callCenterRepId = 0;
            if (Request.QueryString["EmployeeID"] != null)
            {
                long.TryParse(Request.QueryString["EmployeeID"], out callCenterRepId);
            }
            return callCenterRepId;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Add Call Center Rep";
        CallCenter_CallCenterMaster obj;
        obj = (CallCenter_CallCenterMaster)this.Master;
        obj.settitle("Add Call Center Rep");
        obj.SetBreadCrumbRoot = "<a href=\"/App/CallCenter/ViewCallCenterRep.aspx\">Employee Management</a>";

        txtStartDate.Text = DateTime.Now.ToShortDateString();

        if (IsPostBack) return;

        txtStartDate.Attributes.Add("Readonly", "Readonly");
        GetDropDownInfo();

        if (CallCenterRepId == 0) return;


        txtUserName.Enabled = false;

        FillCcRepData();
        dvTitle.InnerText = "Edit Call Center Rep";
        obj.settitle("Edit Call Center Rep");
        Page.Title = "Edit Call Center Rep";
    }

    private void GetDropDownInfo()
    {
        var stateRepository = IoC.Resolve<IStateRepository>();

        var states = stateRepository.GetAllStates();
        ddlState.Items.Clear();
        ddlState.DataSource = states;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Id";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem("Select State", "0"));
    }

    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("ViewCallCenterRep.aspx");
    }


    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        bool isSuccessful;
        if (Request.QueryString["EmployeeID"] == null)
        {
            isSuccessful = CreateCcRep();
        }
        else
        {
            isSuccessful = UpdateCcRep();
        }
        if (isSuccessful)
            Response.RedirectUser("ViewCallCenterRep.aspx");
    }

    private bool UpdateCcRep()
    {
        var userService = IoC.Resolve<ICallCenterRepService>();

        // Set User
        var callCenterRep = userService.GetUser(CallCenterRepId);
        var user = BuildUserModel(callCenterRep);
        if (user == null) return false;

        callCenterRep.CallCenterRepId = CallCenterRepId;
        callCenterRep.CanRefund = user.CanRefund;
        callCenterRep.CanChangeNotes = user.CanChangeNotes;
        try
        {
            userService.SaveCallCenterRep(callCenterRep, IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId);
            return true;
        }
        catch (Exception)
        {
            errordiv.Visible = true;
            errordiv.InnerText = "Error while saving data!";
            return false;
        }
    }

    private bool CreateCcRep()
    {
        var userRepository = IoC.Resolve<IUserRepository<User>>();

        if (userRepository.UserNameExists(txtUserName.Text))
        {
            errordiv.Visible = true;
            errordiv.InnerText = "User Name not available. Please try another User Name.";
            return false;
        }

        // Set User
        var user = BuildUserModel(null);
        if (user == null) return false;
        var callcenterRepService = IoC.Resolve<ICallCenterRepService>();

        try
        {
            callcenterRepService.SaveCallCenterRep(user, (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId));
            return true;
        }
        catch (Exception)
        {
            errordiv.Visible = true;
            errordiv.InnerText = "Error while saving data!";
            return false;
        }

    }


    private CallCenterRep BuildUserModel(User callCenterRep)
    {
        var userRepository = IoC.Resolve<IUserRepository<User>>();
        var countryRepository = IoC.Resolve<ICountryRepository>();
        var addressRepository = IoC.Resolve<IAddressRepository>();

        var user = new CallCenterRep();

        if (callCenterRep != null) user.Id = callCenterRep.Id;

        user.Name = new Name(txtfname.Text, txtMiddleName.Text, txtlname.Text);

        var userAddress = new Address();
        userAddress.StreetAddressLine1 = txtaddress1.Text;
        userAddress.StreetAddressLine2 = txtAddress2.Text;
        userAddress.Country = countryRepository.GetAll().FirstOrDefault().Name;
        userAddress.State = ddlState.SelectedItem.Text;
        userAddress.City = txtCity.Text;
        userAddress.ZipCode = new ZipCode { Zip = txtzip1.Text };

        try
        {
            if (!addressRepository.ValidateAddress(userAddress)) return null;
        }
        catch (InvalidAddressException exception)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bijscode", "alert('" + exception.Message + "');", true);
            return null;
        }

        if (callCenterRep != null) userAddress.Id = callCenterRep.Address.Id;
        user.Address = userAddress;

        user.HomePhoneNumber = new PhoneNumber { Number = txtphonehome.Text }.ToNumber();
        user.OfficePhoneNumber = new PhoneNumber { Number = txtphoneother.Text }.ToNumber();
        user.MobilePhoneNumber = new PhoneNumber { Number = txtphonecell.Text }.ToNumber();

        if (!string.IsNullOrWhiteSpace(txtEmail1.Text))
        {
            user.Email = new Email(txtEmail1.Text);
        }

        if (!string.IsNullOrWhiteSpace(txtEmail2.Text))
        {
            user.AlternateEmail = new Email(txtEmail2.Text);
        }

        if ((callCenterRep == null) || (callCenterRep.Email.ToString() != txtEmail1.Text))
        {
            if (!userRepository.UniqueEmail(user.Email.ToString()))
            {
                errordiv.Visible = true;
                errordiv.InnerText = "Contact email already exists. Please try another email.";
                return null;
            }
        }

        if ((callCenterRep == null) || (callCenterRep.AlternateEmail != null) && (callCenterRep.AlternateEmail.ToString() != txtEmail2.Text))
        {

            if (user.AlternateEmail != null && !userRepository.UniqueEmail(user.AlternateEmail.ToString()))
            {
                errordiv.Visible = true;
                errordiv.InnerText = "Contact email already exists. Please try another email.";
                return null;
            }
        }

        if (!string.IsNullOrWhiteSpace(txtDob.Text))
        {
            user.DateOfBirth = Convert.ToDateTime(txtDob.Text);
        }

        user.CanRefund = chkCanDoRefund.Checked;
        user.CanChangeNotes = chkChangeNotes.Checked;

        user.UserLogin = callCenterRep == null ? new UserLogin { UserName = txtUserName.Text, Password = txtPassword.Text, IsSecurityQuestionVerified = false } : callCenterRep.UserLogin;


        return user;
    }

    private void FillCcRepData()
    {

        var userService = IoC.Resolve<ICallCenterRepService>();
        var user = userService.GetUser(CallCenterRepId);

        //txtStartDate.Text =  sDate.ToString("MM/dd/yyyy");
        txtfname.Text = user.Name.FirstName;
        txtlname.Text = user.Name.LastName; ;
        txtMiddleName.Text = user.Name.MiddleName; ;
        txtphonecell.Text = user.MobilePhoneNumber.ToString();
        txtphonehome.Text = user.HomePhoneNumber.ToString();
        txtphoneother.Text = user.OfficePhoneNumber.ToString();
        txtEmail1.Text = user.Email.ToString();
        txtEmail2.Text = user.AlternateEmail.ToString();

        DateTime dob = Convert.ToDateTime(user.DateOfBirth);
        txtDob.Text = dob.ToString("MM/dd/yyyy");
        txtaddress1.Text = user.Address.StreetAddressLine1;
        txtAddress2.Text = user.Address.StreetAddressLine2;
        txtzip1.Text = user.Address.ZipCode.Zip;
        ddlState.Items.FindByText(user.Address.State).Selected = true;
        txtCity.Text = user.Address.City;
        chkCanDoRefund.Checked = user.CanRefund;
        chkChangeNotes.Checked = user.CanChangeNotes;
    }

}
