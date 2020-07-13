using System;
using System.Linq;
using System.Transactions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.ValueTypes;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

public partial class CallCenter_AddCallCenterManager : System.Web.UI.Page
{

    public long ManagerId
    {
        get
        {
            long managerId = 0;
            if (Request.QueryString["CallCenterCallCenterUserId"] != null)
                long.TryParse(Request.QueryString["CallCenterCallCenterUserId"], out managerId);
            return managerId;
        }
    }

    /// <summary>
    /// Page Load Event sets header properties and calls the 
    /// procedures to fill all dropdowns and input boxes, if
    /// the page is opened for editing.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;

        if (ManagerId > 0)
        {
            Page.Title = "Edit Call Center Manager";
            obj.settitle("Edit Call Center Manager");
            txtUserName.Enabled = false;
            ViewState["CallCenterUserId"] = ManagerId;
        }
        else
        {
            Page.Title = "Add Call Center Manager";
            obj.settitle("Add Call Center Manager");
        }

        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ViewCallCenterManager.aspx\">View Call Center Manager</a>";

        if (!IsPostBack)
        {
            GetDropDownInfo();
            if (ManagerId > 0)
            {
                sptitle.InnerText = "Edit Call Center Manager";
                ViewState["IsEdit"] = true;
                FillCallCenterManagerInfo();
            }
            //txtdob.Attributes.Add("ReadOnly", "readonly");
            txtzip.Attributes.Add("onKeyDown", "return txtkeypress(event);");

        }
    }

    /// <summary>
    /// Calls the procedures to save info in database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        bool returnresult;
        if (ViewState["IsEdit"] == null)
        {
            returnresult = SaveCallCenterUser();
        }
        else
        {
            returnresult = UpdateCallCenterManager();
        }

        if (returnresult)
            Response.RedirectUser("ViewCallCenterManager.aspx");
    }

    /// <summary>
    /// cancels all the work done on the page and redirects to
    /// view call center manager page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("ViewCallCenterManager.aspx");
    }


    /// <summary>
    /// Fetches the country, state, city and callcenter lists
    /// from database, to fill the respective dropdown boxes.
    /// </summary>
    private void GetDropDownInfo()
    {
        // Fill State
        var stateRepository = IoC.Resolve<IStateRepository>();

        var states = stateRepository.GetAllStates();
        ddlstate.Items.Clear();

        ddlstate.Items.Clear();
        ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
        ddlstate.DataSource = states;
        ddlstate.DataTextField = "Name";
        ddlstate.DataValueField = "Id";
        ddlstate.DataBind();



        // Fill call Center
        var organizationRepository = IoC.Resolve<IOrganizationRepository>();

        var callCenters = organizationRepository.GetOrganizationIdNamePairs(OrganizationType.CallCenter);

        ddlcallcenter.DataSource = callCenters;
        ddlcallcenter.DataTextField = "FirstValue";
        ddlcallcenter.DataValueField = "SecondValue";
        ddlcallcenter.DataBind();
        ddlcallcenter.Items.Insert(0, new ListItem("Select CallCenter", "0"));

    }

    /// <summary>
    /// This procedure is invoked if this page
    /// is opened for editing the already exisiting 
    /// Call Manager.
    /// </summary>
    /// <param name="callcenteruserid"></param>
    private void FillCallCenterManagerInfo()
    {
        var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
        var orgRoleUser = orgRoleUserRepository.GetOrganizationRoleUser(ManagerId);

        var userService = IoC.Resolve<IUserService>();

        var user = userService.GetUser(ManagerId);


        txtfname.Text = user.Name.FirstName;
        txtmname.Text = user.Name.MiddleName;
        txtlname.Text = user.Name.LastName;
        txtphonecell.Text = user.MobilePhoneNumber.ToString();
        txtphonehome.Text = user.HomePhoneNumber.ToString();
        txtphoneother.Text = user.OfficePhoneNumber.ToString();
        txtemail.Text = user.Email.ToString();

        txtemailother.Text = user.AlternateEmail.ToString();
        //txtssn.Text = manageruser.SSN;
        if (user.DateOfBirth != null)
            txtdob.Text = Convert.ToDateTime(user.DateOfBirth).ToShortDateString();

        var address = user.Address;

        txtaddress1.Text = address.StreetAddressLine1;
        txtaddress2.Text = address.StreetAddressLine2;
        txtzip.Text = address.ZipCode.Zip;
        ddlstate.Items.FindByText(address.State).Selected = true;
        txtCity.Text = address.City;
        ddlcallcenter.SelectedValue = orgRoleUser.OrganizationId.ToString();
    }

    /// <summary>
    /// This procedure creates a new Call Center manager
    /// from the values filled in input boxes.
    /// </summary>
    /// <returns></returns>
    private bool SaveCallCenterUser()
    {
        var userRepository = IoC.Resolve<IUserRepository<User>>();

        if (userRepository.UserNameExists(txtUserName.Text))
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "User Name not available. Please try another User Name.";
            return false;
        }

        // Set User
        var user = BuildUserModel(null);

        if (user == null) return false;

        var userService = IoC.Resolve<IUserService>();

        try
        {
            using (var scope = new TransactionScope())
            {
                userService.SaveUserforOrganization(Convert.ToInt64(ddlcallcenter.SelectedValue),
                                                    Roles.CallCenterManager, user);
                scope.Complete();
            }
            return true;

        }
        catch (Exception)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Error while saving data!";
            return false;
        }

    }

    /// <summary>
    /// This procedure updates an existing Call Center manager
    /// with the values filled in input boxes.
    /// </summary>
    /// <returns></returns>
    private bool UpdateCallCenterManager()
    {
        var userService = IoC.Resolve<IUserService>();

        var callCenterManager = userService.GetUser(ManagerId);
        var user = BuildUserModel(callCenterManager);
        if (user == null) return false;

        try
        {
            using (var scope = new TransactionScope())
            {
                userService.SaveUserforOrganization(Convert.ToInt64(ddlcallcenter.SelectedValue), Roles.CallCenterManager, user);
                scope.Complete();
            }
            return true;
        }
        catch (Exception)
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Error while saving data!";
            return false;
        }
    }

    private User BuildUserModel(User callCenterManager)
    {


        var userRepository = IoC.Resolve<IUserRepository<User>>();
        var countryRepository = IoC.Resolve<ICountryRepository>();

        var user = new User();

        if (callCenterManager != null)
        {
            user.Id = callCenterManager.Id;
            user.DefaultRole = callCenterManager.DefaultRole;
        }

        user.Name = new Name(txtfname.Text, txtmname.Text, txtlname.Text);

        var userAddress = new Address();
        userAddress.StreetAddressLine1 = txtaddress1.Text;
        userAddress.StreetAddressLine2 = txtaddress2.Text;
        userAddress.Country = countryRepository.GetAll().FirstOrDefault().Name;//new CountryRepository().GetById(Convert.ToInt32(hfBusinessCountryID.Value)).Name;
        userAddress.State = ddlstate.SelectedItem.Text;
        userAddress.City = txtCity.Text;
        userAddress.ZipCode = new ZipCode() { Zip = txtzip.Text };

        var addressRepository = IoC.Resolve<IAddressRepository>();

        try
        {
            if (!addressRepository.ValidateAddress(userAddress)) return null;
        }
        catch (InvalidAddressException exception)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bijscode", "alert('" + exception.Message + "');", true);
            return null;
        }

        if (callCenterManager != null) userAddress.Id = callCenterManager.Address.Id;
        user.Address = userAddress;

        user.HomePhoneNumber = new PhoneNumber() { Number = txtphonehome.Text }.ToNumber();
        user.OfficePhoneNumber = new PhoneNumber() { Number = txtphoneother.Text }.ToNumber();
        user.MobilePhoneNumber = new PhoneNumber() { Number = txtphonecell.Text }.ToNumber();


        if (!string.IsNullOrWhiteSpace(txtemail.Text))
        {
            user.Email = new Email(txtemail.Text);
        }

        if (!string.IsNullOrWhiteSpace(txtemailother.Text))
        {
            user.AlternateEmail = new Email(txtemailother.Text);
        }

        if ((callCenterManager == null) || (callCenterManager.Email.ToString() != txtemail.Text))
        {
            if (!userRepository.UniqueEmail(user.Email.ToString()))
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "Contact email already exists. Please try another email.";
                return null;
            }
        }

        if (((callCenterManager == null) || (callCenterManager.AlternateEmail.ToString() != txtemailother.Text)) && user.AlternateEmail != null)
        {
            if (!userRepository.UniqueEmail(user.AlternateEmail.ToString()))
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "Alternate Contact email already exists. Please try another email.";
                return null;
            }
        }

        if (!string.IsNullOrWhiteSpace(txtdob.Text))
        {
            user.DateOfBirth = Convert.ToDateTime(txtdob.Text);
        }

        //Are we using the SSN value?
        if (callCenterManager == null)
        {
            user.UserLogin = new UserLogin { UserName = txtUserName.Text, Password = txtPassword.Text };
        }
        else
        {
            user.UserLogin = callCenterManager.UserLogin;
        }

        return user;
    }



}