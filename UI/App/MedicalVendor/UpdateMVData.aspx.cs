using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.MedicalVendor;
using Falcon.DataAccess.Other;
using Falcon.Entity.MedicalVendor;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Enum;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Finance.Enum;

public partial class MedicalVendor_UpdateMVData : System.Web.UI.Page
{
    #region Event
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Medical Vendor User";
        MedicalVendor_MedicalVendorMaster obj;
        obj = (MedicalVendor_MedicalVendorMaster)this.Master;
        obj.SetBreadCrumbRoot = "<a href=\"/App/MedicalVendor/ProfilePage.aspx\">Medical Vendor</a>";

        //obj.HideUcSearch();
        string IsEdit = string.Empty;
        if (!IsPostBack)
        {
            if (Request.QueryString["IsEdit"] != null)
            {
                IsEdit = Request.QueryString["IsEdit"].ToString();
                ViewState["IsEdit"] = IsEdit;
            }
            GetDropDownInfo();
            FillMedicalVendor();

           
        }
    }
    /// <summary>
    /// Cancel the current operation and redirect to the MedicalVendor home page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Cancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(ResolveUrl("~/App/MedicalVendor/ProfilePage.aspx"));
    }
    /// <summary>
    /// Save medical vendor info
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Save_Click(object sender, ImageClickEventArgs e)
    {
        SaveMedicalVendor();
    }
    /// <summary>
    /// raise the Country dropdown index change event and Refill the 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddlcountry = (DropDownList)sender;
    //    FillState(ddlcountry.ID);
    //}
    /// <summary>
    /// Change the city dropdown on change the state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddlstate = (DropDownList)sender;
    //    FillCity(ddlstate.ID);
    //}

    #endregion

    #region Methods

    /// <summary>
    /// this method save the MedicalVendor data to the database
    /// </summary>
    private void SaveMedicalVendor()
    {
        OtherDAL otherDal = new OtherDAL();
        EZip objbuzip, objzip;

        objbuzip = otherDal.CheckCityZip(txtBuCity.Text, txtBZip.Text, ddlBState.SelectedValue);
        objzip = otherDal.CheckCityZip(txtCity.Text, txtZip.Text, ddlState.SelectedValue);
        
        if (objbuzip.CityID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bujscode", "alert('City name entered for bussiness address is not valid.');", true);
            return ;
        }
        else if (objbuzip.CityID > 0 && objbuzip.ZipID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "bujscode", "alert('Zip Code entered for bussiness address, corresponding to its city name, is not valid.');", true);
            return ;
        }

        if (objzip.CityID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "alert('City name entered for contact address is not valid.');", true);
            return ;
        }
        else if (objzip.CityID > 0 && objzip.ZipID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "alert('Zip Code entered for contact address, corresponding to its city name, is not valid.');", true);
            return ;
        }

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        //MVUserService service = new MVUserService();
        EMedicalVendor MedicalVendor = new EMedicalVendor();

        EAddress address = new EAddress();
        EAddress Baddress = new EAddress();
        EUser user = new EUser();
        /// fill the default data. Edited data will be overwrite

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        MedicalVendor = OrganizationUser.GetMedicalVendor(currentSession);
        MedicalVendor.BusinessName = txtVName.Text;
        MedicalVendor.BusinessFax = objCommonCode.FormatPhoneNumber(txtBFax.Text);
        MedicalVendor.BusinessPhone = objCommonCode.FormatPhoneNumber(txtBPhone.Text);
        MedicalVendor.Description = txtMVDesc.Text;

        Baddress.Address1 = txtBAddress1.Text;
        Baddress.Address2 = txtBAddress2.Text;
        Baddress.CityID = objbuzip.CityID;
        Baddress.StateID = Convert.ToInt32(ddlBState.SelectedValue);
        Baddress.CountryID = Convert.ToInt32(hfBusinessCountryID.Value);
        Baddress.ZipID = objbuzip.ZipID;

        MedicalVendor.BusinessAddress = Baddress;

        address.Address1 = txtAddress1.Text;
        address.Address2 = txtAddress2.Text;
        address.CityID = objzip.CityID;
        address.StateID = Convert.ToInt32(ddlState.SelectedValue);
        address.CountryID = Convert.ToInt32(hfCountryID.Value);
        address.ZipID = objzip.ZipID;


        MedicalVendor.MVUser.User.FirstName = txtFName.Text;
        MedicalVendor.MVUser.User.MiddleName = txtMName.Text;
        MedicalVendor.MVUser.User.LastName = txtLName.Text;
        MedicalVendor.MVUser.User.PhoneHome = objCommonCode.FormatPhoneNumber(txtPhoneHome.Text);
        MedicalVendor.MVUser.User.PhoneOffice = objCommonCode.FormatPhoneNumber(txtPhoneOther.Text);
        MedicalVendor.MVUser.User.PhoneCell = objCommonCode.FormatPhoneNumber(txtPhoneCell.Text);
        MedicalVendor.MVUser.User.EMail1 = txtEmail.Text;
        MedicalVendor.MVUser.User.EMail2 = txtEmail2.Text;
        MedicalVendor.MVUser.User.HomeAddress = address;
        MedicalVendor.MVUser.User.SSN = txtSSN.Text;
        MedicalVendor.MVUser.User.DOB = Convert.ToDateTime(txtDOB.Text).ToString();
        Ucupdatephotopanel1.GetAllImages();
        MedicalVendor.MVUser.MyPicture = Ucupdatephotopanel1.MyImage;
        MedicalVendor.MVUser.TeamPicture = Ucupdatephotopanel1.TeamImage;
        //MedicalVendor.MVUser.OtherPictures = Ucupdatephotopanel1.Images.ToArray();
        MedicalVendor.MVUser.OtherPictures = Ucupdatephotopanel1.Images;

        MedicalVendor.SpecialInstruction = txtSplInstruction.Text;
        MedicalVendor.AccountHolder = txtAccountHolder.Text;
        MedicalVendor.AccountNumber = txtAccountNo.Text;
        MedicalVendor.AccountType = txtAccountType.Text;
        MedicalVendor.BankName = txtBankName.Text;
        MedicalVendor.RountingNumber = txtRoutingNumber.Text;
        MedicalVendor.Memo = txtMemo.Text;
        MedicalVendor.PaymentMode = (int)(Falcon.App.Core.Enum.EPaymentType)Enum.Parse(typeof(Falcon.App.Core.Enum.EPaymentType), ddlPayMode.SelectedItem.Value);
        MedicalVendor.Interval = (int)(PaymentFrequency)Enum.Parse(typeof(PaymentFrequency), ddlInterval.SelectedItem.Value);


        Int64 returnresult;
        


        if ((ViewState["IsEdit"]!=null) &&   (ViewState["IsEdit"].ToString() != string.Empty))
        {
            MedicalVendorDAL medicalvendorDAL = new MedicalVendorDAL();
            returnresult = medicalvendorDAL.SaveMedicalVendor(MedicalVendor, Convert.ToInt32(EOperationMode.Update), currentSession.CurrentOrganizationRole.OrganizationId.ToString());
            if (returnresult == 0)
            {
                returnresult = 9999991;
            }

            Response.RedirectUser(ResolveUrl("~/App/MedicalVendor/ProfilePage.aspx"));
        }


    }
    /// <summary>
    /// Fill the Mediacl vendor data from the Mediacl vendor  session object
    /// </summary>
    private void FillMedicalVendor()
    {
        var objMedicalVendor = new EMedicalVendor();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        objMedicalVendor = OrganizationUser.GetMedicalVendor(currentSession);
        txtVName.Text = objMedicalVendor.BusinessName;
        txtFName.Text = objMedicalVendor.MVUser.User.FirstName;
        txtMName.Text = objMedicalVendor.MVUser.User.MiddleName;
        txtLName.Text = objMedicalVendor.MVUser.User.LastName;
        DateTime DOB = Convert.ToDateTime(objMedicalVendor.MVUser.User.DOB);
        txtDOB.Text = DOB.ToString("MM/dd/yyyy");
        txtSSN.Text = objMedicalVendor.MVUser.User.SSN;
        txtAddress1.Text = objMedicalVendor.MVUser.User.HomeAddress.Address1;
        txtAddress2.Text = objMedicalVendor.MVUser.User.HomeAddress.Address2;
        txtMVDesc.Text = objMedicalVendor.Description;
        hfCountryID.Value= objMedicalVendor.MVUser.User.HomeAddress.CountryID.ToString();

        ddlState.SelectedValue = objMedicalVendor.MVUser.User.HomeAddress.StateID.ToString();

        txtCity.Text = objMedicalVendor.MVUser.User.HomeAddress.City.ToString();

        txtZip.Text = objMedicalVendor.MVUser.User.HomeAddress.Zip;
        txtPhoneHome.Text = objMedicalVendor.MVUser.User.PhoneHome;
        txtPhoneCell.Text = objMedicalVendor.MVUser.User.PhoneCell;
        txtPhoneOther.Text = objMedicalVendor.MVUser.User.PhoneOffice;
        txtEmail.Text = objMedicalVendor.MVUser.User.EMail1;
        txtEmail2.Text = objMedicalVendor.MVUser.User.EMail2;
        txtSpecialization.Text = objMedicalVendor.MVUser.MVUserSpecialization.Name;
        ///spSignature.InnerText = medicalvendor[0].MVUser.MVUserSpecialization.Name;
        txtContract.Text = objMedicalVendor.Contract.Name;

        txtBAddress1.Text = objMedicalVendor.BusinessAddress.Address1;
        txtBAddress2.Text = objMedicalVendor.BusinessAddress.Address2;

       hfBusinessCountryID.Value = objMedicalVendor.BusinessAddress.CountryID.ToString();
        //FillState(ddlBCountry.ID);
        ddlBState.SelectedValue = objMedicalVendor.BusinessAddress.StateID.ToString();
        //FillCity(ddlBState.ID);
        txtBuCity.Text = objMedicalVendor.BusinessAddress.City.ToString();
        txtBZip.Text = objMedicalVendor.BusinessAddress.Zip;
        txtBPhone.Text = objMedicalVendor.BusinessPhone;
        txtBFax.Text = objMedicalVendor.BusinessFax;
        txtVendorType.Text = objMedicalVendor.MedicalVendorType.Name;
        Ucupdatephotopanel1.MyImage = objMedicalVendor.MVUser.MyPicture;
        Ucupdatephotopanel1.TeamImage = objMedicalVendor.MVUser.TeamPicture;
        Ucupdatephotopanel1.Images = objMedicalVendor.MVUser.OtherPictures.ToList();

        txtBankName.Text = objMedicalVendor.BankName;
        txtAccountHolder.Text = objMedicalVendor.AccountHolder;
        txtAccountNo.Text = objMedicalVendor.AccountNumber;
        txtAccountType.Text = objMedicalVendor.AccountType;
        txtRoutingNumber.Text = objMedicalVendor.RountingNumber;
        txtMemo.Text = objMedicalVendor.RountingNumber;
        txtSplInstruction.Text = objMedicalVendor.SpecialInstruction;
        ddlPayMode.SelectedValue = ((Falcon.App.Core.Enum.EPaymentType)objMedicalVendor.PaymentMode).ToString();
        ddlInterval.SelectedValue = ((PaymentFrequency)objMedicalVendor.Interval).ToString();

    }
    /// <summary>
    /// Fill all the DropDown Data. 
    /// </summary>
    private void GetDropDownInfo()
    {
        MasterDAL masterDal = new MasterDAL();
        var objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();
        
        hfCountryID.Value = objcountry[0].CountryID.ToString();
        hfBusinessCountryID.Value = objcountry[0].CountryID.ToString();


        var objstate = masterDal.GetState(string.Empty, 3);
        ddlState.Items.Clear();
        ddlState.Items.Add(new ListItem("Select State", "0"));

        ddlBState.Items.Clear();
        ddlBState.Items.Add(new ListItem("Select State", "0"));

        for (int icount = 0; icount < objstate.Count; icount++)
        {
            if (objstate[icount].Country.CountryID.ToString().Equals(hfCountryID.Value))
                ddlState.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));

            if (objstate[icount].Country.CountryID.ToString().Equals(hfBusinessCountryID.Value))
                ddlBState.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));

        }
        
        ddlPayMode.Items.Insert(0, "Select Mode");
        ddlPayMode.Items.Insert(1, Falcon.App.Core.Enum.EPaymentType.CashPayment.ToString());
        ddlPayMode.Items.Insert(2, Falcon.App.Core.Enum.EPaymentType.ChequePayment.ToString());
        ddlPayMode.Items.Insert(3, Falcon.App.Core.Enum.EPaymentType.CreditCardPayment.ToString());
        ddlPayMode.Items.Insert(4, Falcon.App.Core.Enum.EPaymentType.DemandDraftPayment.ToString());
        ddlPayMode.Items.Insert(5, Falcon.App.Core.Enum.EPaymentType.MoneyOrderPayment.ToString());
        
        ddlInterval.Items.Insert(0, "Select Interval");
        ddlInterval.Items.Insert(1, PaymentFrequency.Weekly.ToString());
        ddlInterval.Items.Insert(2, PaymentFrequency.BiWeekly.ToString());
        ddlInterval.Items.Insert(3, PaymentFrequency.Monthly.ToString());

    }
    
    #endregion

}