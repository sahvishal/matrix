using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Franchisor;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Lib; 
using Falcon.App.UI.Lib;

public partial class Franchisor_UpdateFranchisorData : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Franchisor User";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Edit Profile");
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ProfilePage.aspx\">Franchisor Admin</a>";

        obj.hideucsearch();
        string IsEdit = string.Empty;
        if (!IsPostBack)
        {
            if (Request.QueryString["IsEdit"] != null)
            {
                IsEdit = Request.QueryString["IsEdit"].ToString();
                ViewState["IsEdit"] = IsEdit;
            }
            GetDropDownInfo();
            FillFranchisorData();
            //txtDOB.Attributes.Add("Readonly", "readonly");

            
        }
    }
    
    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        SaveFranchisor();
    }
    
    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(ResolveUrl("~/App/Franchisor/ProfilePage.aspx"));
    }
    
    private void SaveFranchisor()
    {
        OtherDAL otherDal = new OtherDAL();
        EZip objczip;

        objczip = otherDal.CheckCityZip(txtCity.Text, txtzip1.Text, ddlState.SelectedValue);

        if (objczip.CityID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bujscode", "alert('City name entered for contact address is not valid.');", true);
            return;
        }
        else if (objczip.CityID > 0 && objczip.ZipID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bujscode", "alert('Zip Code entered for contact address, corresponding to its city name, is not valid.');", true);
            return;
        }

        EFranchisorUser franchisoruser = new EFranchisorUser();
        var address = new Falcon.Entity.Other.EAddress();
        var user = new Falcon.Entity.Other.EUser();
        // format phone no.
        CommonCode objCommonCode = new CommonCode();


        franchisoruser.Active = true;

        address.Address1 = txtaddress1.Text;
        address.Address2 = txtAddress2.Text;
        address.CityID = objczip.CityID;
        address.StateID = Convert.ToInt32(ddlState.SelectedValue);
        address.CountryID = Convert.ToInt32(hfCountryID.Value);
        address.ZipID = objczip.ZipID;
        user.FirstName = txtfname.Text;
        user.MiddleName = txtMiddleName.Text;
        user.LastName = txtlname.Text;
        user.SSN = txtSSN.Text;
        user.DOB = Convert.ToDateTime(txtDOB.Text).ToString();
        user.PhoneHome = objCommonCode.FormatPhoneNumber(txtphonehome.Text);
        user.PhoneOffice = objCommonCode.FormatPhoneNumber(txtphoneother.Text);
        user.PhoneCell = objCommonCode.FormatPhoneNumber(txtphonecell.Text);
        user.EMail1 = txtEmail1.Text;
        user.EMail2 = txtEmail2.Text;
        franchisoruser.User = user;
        franchisoruser.Address = address;
        Int64 returnresult;

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        
        
        franchisoruser.ShellDescription = txtabtmself.Text;

        FranchisorDAL franchisorDAL = new FranchisorDAL();
        if (ViewState["IsEdit"].ToString() != string.Empty)
        {
            franchisoruser.User.UserID = Convert.ToInt32(currentSession.UserId);


            returnresult = franchisorDAL.SaveFranchisorUser(franchisoruser, Convert.ToInt32(EOperationMode.Update),
                                                            currentSession.CurrentOrganizationRole.OrganizationId.ToString());
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }

            if (txtPassword.Text.Length > 0)
            {
                var userLoginService = IoC.Resolve<IUserLoginService>();
                userLoginService.ResetPassword(Convert.ToInt32(currentSession.UserId), txtPassword.Text, false, currentSession.CurrentOrganizationRole.OrganizationRoleUserId,false);
            }
            Response.RedirectUser(ResolveUrl("~/App/Franchisor/ProfilePage.aspx"));
        }
        else
        {
            returnresult = franchisorDAL.SaveFranchisorUser(franchisoruser, Convert.ToInt32(EOperationMode.Insert),
                                                            currentSession.CurrentOrganizationRole.OrganizationId.ToString());
            if (returnresult == 0)
            {
                returnresult = 9999990;
            }

        }


    }    

    private void FillFranchisorData()
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var Franchisoruser = OrganizationUser.GetFranchisorUser(currentSession);
        txtfname.Text = Franchisoruser.User.FirstName;
        txtlname.Text = Franchisoruser.User.LastName;
        txtMiddleName.Text = Franchisoruser.User.MiddleName;
        txtphonecell.Text = Franchisoruser.User.PhoneCell;
        txtphonehome.Text = Franchisoruser.User.PhoneHome;
        txtphoneother.Text = Franchisoruser.User.PhoneOffice;
        txtEmail1.Text = Franchisoruser.User.EMail1;
        txtEmail2.Text = Franchisoruser.User.EMail2;
        txtSSN.Text = Franchisoruser.User.SSN;
        DateTime DOB = Convert.ToDateTime(Franchisoruser.User.DOB);
        txtDOB.Text = DOB.ToString("MM/dd/yyyy");
        txtaddress1.Text = Franchisoruser.Address.Address1;
        txtAddress2.Text = Franchisoruser.Address.Address2;
        txtzip1.Text = Franchisoruser.Address.Zip;
        hfCountryID.Value = Franchisoruser.Address.CountryID.ToString();
        ddlState.SelectedValue = Franchisoruser.Address.StateID.ToString();
        txtCity.Text = Franchisoruser.Address.City.ToString();
        txtabtmself.Text = Franchisoruser.ShellDescription;

    }
    
    private void GetDropDownInfo()
    {
        var masterDal = new MasterDAL();
        var objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();
        
        hfCountryID.Value = objcountry[0].CountryID.ToString();

        var objstate = masterDal.GetState(string.Empty, 3);

        ddlState.Items.Clear();
        ddlState.Items.Add(new ListItem("Select State", "0"));

        for (int icount = 0; icount < objstate.Count; icount++)
        {
            if (objstate[icount].Country.CountryID.ToString().Equals(hfCountryID.Value))
                ddlState.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));
        }

    }

}
