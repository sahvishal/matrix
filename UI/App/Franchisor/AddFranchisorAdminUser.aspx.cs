using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Franchisor;
using Falcon.Entity.Other;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;

public partial class Franchisor_AddFranchisorAdminUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Franchisor User";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        if (Request.QueryString["FranchisorFranchisorUserID"] != null)
        {
            dvTitle.InnerText = "Edit Franchisor Admin User";
            obj.settitle("Edit Franchisor User");
        }
        else
        {
            dvTitle.InnerText = "Add New Franchisor Admin User";
            obj.settitle("Add Franchisor User");
        }
        obj.hideucsearch();
        string FranchisorFranchisorUserID = string.Empty;
        if (!IsPostBack)
        {
            GetDropDownInfo();
            if (Request.QueryString["FranchisorFranchisorUserID"] != null)
            {
                FranchisorFranchisorUserID = Request.QueryString["FranchisorFranchisorUserID"].ToString();
                ViewState["FranchisorFranchisorUserID"] = FranchisorFranchisorUserID;
                this.FillFranchisorData();
            }

           
        }

    }

    /// <summary>
    /// this method save the franchisor data to the database
    /// </summary>
    private void SaveFranchisor()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        OtherDAL otherDal = new OtherDAL();
        EZip objczip = otherDal.CheckCityZip(txtCity.Text, txtzip1.Text, ddlstate.SelectedValue);

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

        EFranchisorFranchisorUser franchisorfranchisoruser = new EFranchisorFranchisorUser();
        EFranchisorUser franchisoruser = new EFranchisorUser();
        EFranchisor franchisor = new EFranchisor();


        franchisor.Active = true;
        //HealthYes.Web.UI.FranchisorFranchisorUserService.EAddress address = new HealthYes.Web.UI.FranchisorFranchisorUserService.EAddress();
        var address = new Falcon.Entity.Other.EAddress();
        
        address.Address1 = txtaddress1.Text;
        address.Address2 = string.Empty;
        address.CityID = objczip.CityID;
        address.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        address.CountryID = Convert.ToInt32(hfCountryID.Value);
        address.ZipID = objczip.ZipID;

        //HealthYes.Web.UI.FranchisorFranchisorUserService.EUser user = new HealthYes.Web.UI.FranchisorFranchisorUserService.EUser();
        var user = new Falcon.Entity.Other.EUser();

        user.FirstName = txtfname.Text;
        user.MiddleName = txtMiddleName.Text.Length == 0 ? "" : txtMiddleName.Text;
        user.LastName = txtlname.Text;
        user.SSN = txtSSN.Text.Length == 0 ? "" : txtSSN.Text;
        user.DOB = Convert.ToDateTime(txtDOB.Text).ToString();
        user.PhoneHome = txtphonehome.Text.Length == 0 ? "" : objCommonCode.FormatPhoneNumber(txtphonehome.Text);
        user.PhoneOffice = txtphoneother.Text.Length == 0 ? "" : objCommonCode.FormatPhoneNumber(txtphoneother.Text);
        user.PhoneCell = txtphonecell.Text.Length == 0 ? "" : objCommonCode.FormatPhoneNumber(txtphonecell.Text);
        user.EMail1 = txtEmail1.Text;
        user.EMail2 = txtEmail2.Text.Length == 0 ? "" : txtEmail2.Text;
        user.HomeAddress = address;
        
        Ucupdatephotopanel1.GetAllImages();
        franchisoruser.OtherPictures = Ucupdatephotopanel1.Images;
        //franchisoruser.OtherPictures = Ucupdatephotopanel1.Images.ToArray();
        franchisoruser.TeamPicture = Ucupdatephotopanel1.TeamImage;
        franchisoruser.MyPicture = Ucupdatephotopanel1.MyImage;
        franchisoruser.User = user;
        franchisorfranchisoruser.Franchisor = franchisor;
        franchisorfranchisoruser.FranchisorUser = franchisoruser;

        var sessionContext = IoC.Resolve<ISessionContext>();

        if (ViewState["FranchisorFranchisorUserID"] != null && ViewState["Email"].ToString().Equals(txtEmail1.Text.Trim()))
        {
            if (ViewState["FranchisorFranchisorUserID"].ToString() != string.Empty)
            {
                FranchisorDAL franchisorDal = new FranchisorDAL();
                var listFranchisorFranchisorUser =
                    franchisorDal.GetFranchisorFranchisorUser(ViewState["FranchisorFranchisorUserID"].ToString(), 1);
                EFranchisorFranchisorUser[] FFUser = null;

                if (listFranchisorFranchisorUser != null) FFUser = listFranchisorFranchisorUser.ToArray();

                if (FFUser != null)
                {
                    franchisorfranchisoruser.FranchisorUser.User.UserID = Convert.ToInt32(ViewState["UserID"].ToString());

                    franchisorDal.SaveFranchisorFranchisorUser(franchisorfranchisoruser,
                                                               Convert.ToInt32(EOperationMode.Update), sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);
                    
                    Response.RedirectUser(ResolveUrl("~/App/Franchisor/FranchisorAdminUser.aspx?Action=Edited"));
                }
            }
        }
        else
        {
            IUserRepository<User> userRepository = IoC.Resolve<IUserRepository<User>>();
            if (userRepository.UserNameExists(txtEmail1.Text))
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "Contact email already exists. Please try another email.";
                return;
            }
            if (ViewState["FranchisorFranchisorUserID"] != null)
            {
                if (ViewState["FranchisorFranchisorUserID"].ToString() != string.Empty)
                {
                    FranchisorDAL franchisorDal = new FranchisorDAL();
                    var listFranchisorFranchisorUser =
                        franchisorDal.GetFranchisorFranchisorUser(
                            ViewState["FranchisorFranchisorUserID"].ToString(), 1);
                    EFranchisorFranchisorUser[] FFUser = null;

                    if (listFranchisorFranchisorUser != null)
                    {
                        FFUser = listFranchisorFranchisorUser.ToArray();
                    }

                    if (FFUser != null)
                    {
                        franchisorfranchisoruser.FranchisorUser.User.UserID =
                            Convert.ToInt32(ViewState["UserID"].ToString());
                        franchisorDal.SaveFranchisorFranchisorUser(franchisorfranchisoruser,
                            Convert.ToInt32(EOperationMode.Update), sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);

                        Response.RedirectUser(ResolveUrl("~/App/Franchisor/FranchisorAdminUser.aspx?Action=Edited"));
                    }
                }
            }
            else
            {
                //service.AddFranchisorFranchisorUser(franchisorfranchisoruser, usershellmodulerole1, out returnresult, out temp);

                FranchisorDAL franchisorDal = new FranchisorDAL();
                franchisorDal.SaveFranchisorFranchisorUser(franchisorfranchisoruser,
                    Convert.ToInt32(EOperationMode.Insert), sessionContext.UserSession.CurrentOrganizationRole.OrganizationId);

                Response.RedirectUser(ResolveUrl("~/App/Franchisor/FranchisorAdminUser.aspx?Action=Added"));
            }
        }
    }
    /// <summary>
    /// Fill the Franchisor data from the Franchisor session object
    /// </summary>
    private void FillFranchisorData()
    {
        FranchisorDAL franchisorDal = new FranchisorDAL();
        var listFranchisorFranchisorUser =
            franchisorDal.GetFranchisorFranchisorUser(ViewState["FranchisorFranchisorUserID"].ToString(), 1);
        EFranchisorFranchisorUser[] franchisoruser = null;

        if (listFranchisorFranchisorUser != null) franchisoruser = listFranchisorFranchisorUser.ToArray();


        if (franchisoruser != null)
        {
            ViewState["UserID"] = franchisoruser[0].FranchisorUser.User.UserID;
            txtfname.Text = franchisoruser[0].FranchisorUser.User.FirstName;
            txtlname.Text = franchisoruser[0].FranchisorUser.User.LastName;
            txtMiddleName.Text = franchisoruser[0].FranchisorUser.User.MiddleName;
            txtphonecell.Text = franchisoruser[0].FranchisorUser.User.PhoneCell;
            txtphonehome.Text = franchisoruser[0].FranchisorUser.User.PhoneHome;
            txtphoneother.Text = franchisoruser[0].FranchisorUser.User.PhoneOffice;
            txtEmail1.Text = franchisoruser[0].FranchisorUser.User.EMail1;
            ViewState["Email"] = franchisoruser[0].FranchisorUser.User.EMail1;
            txtEmail2.Text = franchisoruser[0].FranchisorUser.User.EMail2;
            txtSSN.Text = franchisoruser[0].FranchisorUser.User.SSN;
            if (franchisoruser[0].FranchisorUser.User.DOB.Length > 0)
            {
                txtDOB.Text = Convert.ToDateTime(franchisoruser[0].FranchisorUser.User.DOB).ToShortDateString();
            }
            else
                txtDOB.Text = "";

            //Ucupdatephotopanel1.Images = franchisoruser[0].FranchisorUser.OtherPictures;
            Ucupdatephotopanel1.Images = new List<string>();
            foreach (var images in franchisoruser[0].FranchisorUser.OtherPictures)
            {
                Ucupdatephotopanel1.Images.Add(images);
            }
            
            Ucupdatephotopanel1.TeamImage = franchisoruser[0].FranchisorUser.TeamPicture;
            Ucupdatephotopanel1.MyImage = franchisoruser[0].FranchisorUser.MyPicture;

            txtaddress1.Text = franchisoruser[0].FranchisorUser.Address.Address1;
           // txtAddress2.Text = franchisoruser[0].FranchisorUser.Address.Address2;
            txtzip1.Text = franchisoruser[0].FranchisorUser.Address.Zip;
            hfCountryID.Value= franchisoruser[0].FranchisorUser.User.HomeAddress.CountryID.ToString();
            //FillState();
            ddlstate.SelectedValue = franchisoruser[0].FranchisorUser.User.HomeAddress.StateID.ToString();
            //FillCity();
            txtCity.Text = franchisoruser[0].FranchisorUser.User.HomeAddress.City.ToString();
        }
    }

    /// <summary>
    /// Cancel the current operation and redirect to the Franchisor home page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(ResolveUrl("~/App/Franchisor/FranchisorAdminUser.aspx"));
    }

    /// <summary>
    /// Fill all the DropDown Data. 
    /// </summary>
    private void GetDropDownInfo()
    {
        var masterDal = new MasterDAL();
        Falcon.Entity.Other.ECountry[] objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();

        hfCountryID.Value = objcountry[0].CountryID.ToString();
        var objstate = masterDal.GetState(string.Empty, 3);

        ddlstate.Items.Clear();
        ddlstate.Items.Add(new ListItem("Select State", "0"));

        for (int icount = 0; icount < objstate.Count; icount++)
        {
            if (objstate[icount].Country.CountryID.ToString().Equals(hfCountryID.Value))
                ddlstate.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));
        }
        
    }
    
    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        SaveFranchisor();
    }

}
