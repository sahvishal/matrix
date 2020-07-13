using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;
using Falcon.App.Lib;
//using HealthYes.Web.UI.MVUserService;
using Falcon.App.Core.Enum;
using EPaymentType=Falcon.App.Core.Enum.EPaymentType;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Finance.Enum;

public partial class App_MedicalVendor_ProfilePage : System.Web.UI.Page
{
    EMedicalVendor[] medicalvendor;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Medical Vendor Profile";
        MedicalVendor_MedicalVendorMaster obj;
        obj = (MedicalVendor_MedicalVendorMaster)this.Master;
        obj.SetBreadCrumbRoot = "<a href=\"#\">Medical Vendor</a>";
        // obj.HideUcSearch();
        if (!IsPostBack)
        {
            FillMedicalVendorData();
        }
    }
    /// <summary>
    /// get the Medical Vendor Data  and fill the session object
    /// </summary>
    private void FillMedicalVendorData()
    {
        
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        

        MedicalVendorDAL medicalvendorDAL = new MedicalVendorDAL();
        var listmedicalvendor = medicalvendorDAL.GetMedicalVendor(IoC.Resolve<ISessionContext>().UserSession.UserId.ToString(), Convert.ToInt64(IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationId), Roles.MedicalVendorAdmin.ToString(), 1);

        if (listmedicalvendor != null) medicalvendor = listmedicalvendor.ToArray();        

        name.InnerText = medicalvendor[0].MVUser.User.FirstName + " " + medicalvendor[0].MVUser.User.MiddleName + " " + medicalvendor[0].MVUser.User.LastName;
        dvDescription.InnerText = medicalvendor[0].Description;
        spFname.InnerText = medicalvendor[0].MVUser.User.FirstName;
        spMname.InnerText = medicalvendor[0].MVUser.User.MiddleName;
        spLname.InnerText = medicalvendor[0].MVUser.User.LastName;

        ///new changes
        DateTime DOB = Convert.ToDateTime(medicalvendor[0].MVUser.User.DOB);
        spDOB.InnerText = DOB.ToString("MMMM dd, yyyy");
        spSSN.InnerText = medicalvendor[0].MVUser.User.SSN;

        spPayMode.InnerText = ((EPaymentType)medicalvendor[0].PaymentMode).ToString();
        spPayInterval.InnerText = ((PaymentFrequency)medicalvendor[0].Interval).ToString();


        ///
        spAddress1.InnerText = medicalvendor[0].MVUser.User.HomeAddress.Address1;
        spAddress2.InnerText = medicalvendor[0].MVUser.User.HomeAddress.Address2;
        spState.InnerText = medicalvendor[0].MVUser.User.HomeAddress.State;
        spCountry.InnerText = medicalvendor[0].MVUser.User.HomeAddress.Country;
        spCity.InnerText = medicalvendor[0].MVUser.User.HomeAddress.City;
        spZip.InnerText = medicalvendor[0].MVUser.User.HomeAddress.Zip;
        spPhoneHome.InnerText = objCommonCode.FormatPhoneNumberGet(medicalvendor[0].MVUser.User.PhoneHome);
        spPhoneCell.InnerText = objCommonCode.FormatPhoneNumberGet(medicalvendor[0].MVUser.User.PhoneCell);
        spPhoneOther.InnerText = objCommonCode.FormatPhoneNumberGet(medicalvendor[0].MVUser.User.PhoneOffice);
        spEmail1.InnerText = medicalvendor[0].MVUser.User.EMail1;
        spEmail2.InnerText = medicalvendor[0].MVUser.User.EMail2;
        spSpecialization.InnerText = medicalvendor[0].MVUser.MVUserSpecialization.Name;
        ///spSignature.InnerText = medicalvendor[0].MVUser.MVUserSpecialization.Name;
        spContract.InnerText = medicalvendor[0].Contract.Name;
         CommonCode objCCode = new CommonCode();

         imgmyphto.ImageUrl = objCCode.GetPicture(Request.MapPath(medicalvendor[0].MVUser.MyPicture), medicalvendor[0].MVUser.MyPicture);
         imgmyteam.ImageUrl = objCCode.GetPicture(Request.MapPath(medicalvendor[0].MVUser.TeamPicture), medicalvendor[0].MVUser.TeamPicture);
         dvRole.InnerText = IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.RoleAlias;
        /// fill business details

        spBAddress1.InnerText = medicalvendor[0].BusinessAddress.Address1;
        spBAddress2.InnerText = medicalvendor[0].BusinessAddress.Address2;
        spBState.InnerText = medicalvendor[0].BusinessAddress.State;
        spBCountry.InnerText = medicalvendor[0].BusinessAddress.Country;
        spBCity.InnerText = medicalvendor[0].BusinessAddress.City;
        spBZip.InnerText = medicalvendor[0].BusinessAddress.Zip;
        spBPhone.InnerText = objCCode.FormatPhoneNumberGet(medicalvendor[0].BusinessPhone);
        spBFax.InnerText = objCCode.FormatPhoneNumberGet(medicalvendor[0].BusinessFax);
        spBVendorType.InnerText = medicalvendor[0].MedicalVendorType.Name;
        ucOtherPhoto.Images = medicalvendor[0].MVUser.OtherPictures.ToList();
    }

    /// <summary>
    /// Invoke the model POP up for big image
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPhoto_Click(object sender, EventArgs e)
    {
        LinkButton templink = (LinkButton)sender;
        ContentPlaceHolder item = (ContentPlaceHolder)templink.NamingContainer;
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");

        if (((LinkButton)(sender)).CommandName == "MyPhoto")
        { imgLargeImage.Src = imgmyphto.ImageUrl; }

        ModalPopupExtender.Show();

    }
}
