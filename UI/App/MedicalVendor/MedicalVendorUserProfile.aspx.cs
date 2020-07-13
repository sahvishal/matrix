using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Lib;
using Falcon.App.Core.Application.Impl;
using Falcon.App.UI.App.MedicalVendor;

public partial class MedicalVendor_MedicalVendorUserProfile : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "MVUser Profile";
        MedicalVendor_MedicalVendorMaster obj;
        obj = (MedicalVendor_MedicalVendorMaster)Master;
        obj.SetBreadCrumbRoot = "<a href=\"#\">MV User</a>";
        if (!IsPostBack)
        {
            FillMvUserData();
        }
    }

    protected void ibtnedit_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(ResolveUrl("~/App/MedicalVendor/MVUserUpdatePersonalData.aspx"));
    }

    private void FillMvUserData()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();
        long physicianId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;

        ITestRepository testRepository = new TestRepository();
        IPhysicianRepository physicianRepository = new PhysicianRepository();

        var medicalVendorDal = new MedicalVendorDAL();
        bool allowAuthorizations;
        bool allowEvaluations;

        //TODO: To Repair
        medicalVendorDal.GetMVUserFunctionalities(physicianId, out allowAuthorizations, out allowEvaluations);

        decimal currentPayrate = 0.00M;
        if (allowEvaluations)
        {
            currentPayrate = physicianRepository.GetCurrentPayrate(physicianId);
            List<Test> tests = testRepository.GetPermittedTestsForaPhysician(physicianId);

            CurrentPayrateSpan.InnerHtml = string.Format("{0:c}", currentPayrate);
            PermittedTestsRepeater.DataSource = tests.OrderBy(t => t.Name);
            PermittedTestsRepeater.DataBind();

        }
        List<EMVMVUser> medicalVendorUserProfile = medicalVendorDal.GetMedicalVendorMedicalVendorUserProfile(IoC.Resolve<ISessionContext>().UserSession.UserId.ToString(), 1);

        vendorname.InnerText = medicalVendorUserProfile[0].MedicalVendor.BusinessName;
        name.InnerText = medicalVendorUserProfile[0].MVUser.User.FirstName + " " + medicalVendorUserProfile[0].MVUser.User.MiddleName + " " + medicalVendorUserProfile[0].MVUser.User.LastName;
        fname.InnerText = medicalVendorUserProfile[0].MVUser.User.FirstName;
        mname.InnerText = medicalVendorUserProfile[0].MVUser.User.MiddleName;
        lname.InnerText = medicalVendorUserProfile[0].MVUser.User.LastName;
        if (medicalVendorUserProfile[0].MVUser.Resume != "")
        {
            aDwnResume.HRef = medicalVendorUserProfile[0].MVUser.Resume;
            aDwnResume.Disabled = false;
        }
        else
        {
            aDwnResume.Disabled = true;
        }
        if (medicalVendorUserProfile[0].MVUser.DigitalSignature != "")
        {
            aDwnSign.Disabled = false;
            aDwnSign.HRef = medicalVendorUserProfile[0].MVUser.DigitalSignature;
        }
        else
        {
            aDwnSign.Disabled = true;
        }
        specialization.InnerText = medicalVendorUserProfile[0].MVUser.MVUserSpecialization.Name;
        classification.InnerText = medicalVendorUserProfile[0].MVUser.MVUserClassification.Name;
        DateTime DOB = Convert.ToDateTime(medicalVendorUserProfile[0].MVUser.User.DOB);
        // DateTime DOA = Convert.ToDateTime(mvmvuser[0]reateDate);
        address1.InnerText = medicalVendorUserProfile[0].MVUser.User.HomeAddress.Address1;
        address2.InnerText = medicalVendorUserProfile[0].MVUser.User.HomeAddress.Address2;
        state.InnerText = medicalVendorUserProfile[0].MVUser.User.HomeAddress.State;
        country.InnerText = medicalVendorUserProfile[0].MVUser.User.HomeAddress.Country;
        city.InnerText = medicalVendorUserProfile[0].MVUser.User.HomeAddress.City;
        zip.InnerText = medicalVendorUserProfile[0].MVUser.User.HomeAddress.ZipID.ToString();
        phonehome.InnerText = objCommonCode.FormatPhoneNumberGet(medicalVendorUserProfile[0].MVUser.User.PhoneHome);
        phonecell.InnerText = objCommonCode.FormatPhoneNumberGet(medicalVendorUserProfile[0].MVUser.User.PhoneCell);
        phoneother.InnerText = objCommonCode.FormatPhoneNumberGet(medicalVendorUserProfile[0].MVUser.User.PhoneOffice);
        email1.InnerText = medicalVendorUserProfile[0].MVUser.User.EMail1;
        email2.InnerText = medicalVendorUserProfile[0].MVUser.User.EMail2;
        dob.InnerText = DOB.ToString("MMMM dd, yyyy");
        ssn.InnerText = medicalVendorUserProfile[0].MVUser.User.SSN;
        var objCCode = new CommonCode();

        imgmyphto.ImageUrl = objCCode.GetPicture(Request.MapPath(medicalVendorUserProfile[0].MVUser.MyPicture), medicalVendorUserProfile[0].MVUser.MyPicture);
        if (medicalVendorUserProfile[0].MVUser.References.Count <= 0)
        {
            refname1.InnerText = "";
            refemail1.InnerText = "";
            refname2.InnerText = "";
            refemail2.InnerText = "";
            refname3.InnerText = "";
            refemail3.InnerText = "";
        }
        if (medicalVendorUserProfile[0].MVUser.References.Count == 1)
        {
            refname1.InnerText = medicalVendorUserProfile[0].MVUser.References[0] == null ? "" : medicalVendorUserProfile[0].MVUser.References[0].Name;
            refemail1.InnerText = medicalVendorUserProfile[0].MVUser.References[0] == null ? "" : medicalVendorUserProfile[0].MVUser.References[0].EMail;

        }
        if (medicalVendorUserProfile[0].MVUser.References.Count == 2)
        {
            refname2.InnerText = medicalVendorUserProfile[0].MVUser.References[1] == null ? "" : medicalVendorUserProfile[0].MVUser.References[1].Name;
            refemail2.InnerText = medicalVendorUserProfile[0].MVUser.References[1] == null ? "" : medicalVendorUserProfile[0].MVUser.References[1].EMail;
        }
        if (medicalVendorUserProfile[0].MVUser.References.Count == 3)
        {
            refname1.InnerText = medicalVendorUserProfile[0].MVUser.References[0] == null ? "" : medicalVendorUserProfile[0].MVUser.References[0].Name;
            refemail1.InnerText = medicalVendorUserProfile[0].MVUser.References[0] == null ? "" : medicalVendorUserProfile[0].MVUser.References[0].EMail;
            refname2.InnerText = medicalVendorUserProfile[0].MVUser.References[1] == null ? "" : medicalVendorUserProfile[0].MVUser.References[1].Name;
            refemail2.InnerText = medicalVendorUserProfile[0].MVUser.References[1] == null ? "" : medicalVendorUserProfile[0].MVUser.References[1].EMail;
            refname3.InnerText = medicalVendorUserProfile[0].MVUser.References[2] == null ? "" : medicalVendorUserProfile[0].MVUser.References[2].Name;
            refemail3.InnerText = medicalVendorUserProfile[0].MVUser.References[2] == null ? "" : medicalVendorUserProfile[0].MVUser.References[2].EMail;
        }

        //spdateApplied.InnerText = DOA.ToString("MMMM dd, yyyy");
        Ucimagelist1.Images = medicalVendorUserProfile[0].MVUser.OtherPictures.ToList();
    }

    protected void lnkPhoto_Click(object sender, EventArgs e)
    {
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");

        if (((LinkButton)(sender)).CommandName == "MyPhoto")
        { imgLargeImage.Src = imgmyphto.ImageUrl; }
        //else if (((LinkButton)(sender)).CommandName == "TeamPhoto")
        //{ imgLargeImage.Src = imgmyteam.ImageUrl; }
        ModalPopupExtender.Show();
    }

}
