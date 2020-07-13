using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.MedicalVendor;
using Falcon.DataAccess.Other;
using Falcon.DataAccess.User;
using Falcon.DataAccess.Master;
using Falcon.Entity.MedicalVendor;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using EUser = Falcon.Entity.Other.EUser;

public partial class MedicalVendor_MVUserUpdatePersonalData : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Medical Vendor User";
        errordiv.InnerHtml = "";
        MedicalVendor_MedicalVendorMaster obj = (MedicalVendor_MedicalVendorMaster)this.Master;
        obj.SetBreadCrumbRoot = "<a href=\"#\">Vendors</a>";
        if (!IsPostBack)
        {
            Ucupdatephotopanel1.TeamImageVisible = false;
            FillTest();
            GetDropDownInfo();
            this.FillMvUserData();


        }
        ClientScript.RegisterArrayDeclaration("jselemshiddenfields", "'" + hfcityid.ClientID.ToString() + "'");
        ClientScript.RegisterArrayDeclaration("jselemshiddenfields", "'" + hfstateid.ClientID.ToString() + "'");

    }

    private void SaveMedicalVendor()
    {
        OtherDAL otherDal = new OtherDAL();
        EZip objczip;

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        objczip = otherDal.CheckCityZip(txtCity.Text, txtZip.Text, ddlState.SelectedValue);

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

        EMVMVUser emvmvUser = new EMVMVUser();
        EMedicalVendor medicalVendor = new EMedicalVendor();

        if (ViewState["AuditRequired"] != null)
            emvmvUser.AuditRequired = Convert.ToBoolean(ViewState["AuditRequired"]);

        medicalVendor.BusinessName = ddlVendorName.SelectedItem.Text;
        if (ViewState["MedicalVendorID"] != null)
        {
            medicalVendor.MedicalVendorID = Convert.ToInt32(ViewState["MedicalVendorID"].ToString());
        }
        else
            medicalVendor.MedicalVendorID = Convert.ToInt32(ddlVendorName.SelectedValue);
        EAddress address = new EAddress();
        address.Address1 = txtAddress1.Text;
        address.Address2 = txtAddress2.Text;
        address.CityID = objczip.CityID;
        address.StateID = Convert.ToInt32(ddlState.SelectedValue);
        address.CountryID = Convert.ToInt32(hfCountryID.Value);
        address.ZipID = objczip.ZipID;

        EUser user = new EUser();
        if (ViewState["UserID"] != null)
        {
            user.UserID = Convert.ToInt32(ViewState["UserID"].ToString());
        }
        user.FirstName = txtFirstName.Text;
        user.MiddleName = txtMiddleName.Text;
        user.LastName = txtLastName.Text;
        user.PhoneCell = objCommonCode.FormatPhoneNumber(txtPhoneC.Text);
        user.PhoneHome = objCommonCode.FormatPhoneNumber(txtPhoneH.Text);
        user.PhoneOffice = objCommonCode.FormatPhoneNumber(txtPhoneO.Text);
        user.DOB = txtDOB.Text;
        user.SSN = txtSSN.Text;
        user.EMail1 = txtEmail1.Text;
        user.EMail2 = txtEmail2.Text;

        user.HomeAddress = address;

        var reference = new EReferences[3];
        reference[0] = new EReferences { Name = string.Empty, EMail = string.Empty };
        reference[1] = new EReferences { Name = string.Empty, EMail = string.Empty };
        reference[2] = new EReferences { Name = string.Empty, EMail = string.Empty };

        EMVUserSpecialization userSpecialization = new EMVUserSpecialization();
        userSpecialization.MVUserSpecilaizationID = Convert.ToInt32(ddlSpecialization.SelectedValue);

        EMVUserClassification emvUserClassification = new EMVUserClassification();
        emvUserClassification.MVUserClassificationID = Convert.ToInt32(ViewState["ClassificationID"]);


        EMVUser emvUser = new EMVUser();
        Ucupdatephotopanel1.GetAllImages();
        emvUser.OtherPictures = Ucupdatephotopanel1.Images;
        emvUser.MyPicture = Ucupdatephotopanel1.MyImage;


        if (ViewState["MVUserID"] != null)
        {
            emvUser.MVUserID = Convert.ToInt32(ViewState["MVUserID"].ToString());
        }
        emvUser.User = user;
        emvUser.References = reference.ToList();
        emvUser.MVUserSpecialization = userSpecialization;
        emvUser.MVUserClassification = emvUserClassification;
        emvUser.Address = address;
        //// For Resume
        string resumePath = ViewState["Resume"].ToString();
        string signPath = ViewState["Signature"].ToString();
        if ((hfResume.Value == "1") && fileResume.HasFile)
        {
            string filePath = Request.MapPath(ConfigurationManager.AppSettings["MVUploadResume"].ToString());
            resumePath = ConfigurationManager.AppSettings["MVUploadResume"].ToString();
            var fileInfo = new FileInfo(fileResume.FileName);
            if (!(fileInfo.Extension.Equals(".doc") || fileInfo.Extension.Equals(".docx") || fileInfo.Extension.Equals(".rtf") || fileInfo.Extension.Equals(".txt")))
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "Invalid file format. It should be either of type doc, docx, rtf or txt";
                return;
            }
            else
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string saveFileName = fileResume.FileName + DateTime.Now.ToFileTimeUtc() + fileInfo.Extension;
                if (fileResume.HasFile)
                {
                    fileResume.SaveAs(filePath + "\\" + saveFileName);
                }
                resumePath = resumePath + "/" + saveFileName;
            }
        }
        emvUser.Resume = resumePath;
        ////////////////////////signature//////////////////////////////////
        if ((hfSignature.Value == "1") && (fileSignature.FileName.Trim() != ""))
        {
            if (fileSignature.HasFile)
            {
                string signFilePath = Request.MapPath(ConfigurationManager.AppSettings["MVUploadSignature"].ToString());
                signPath = ConfigurationManager.AppSettings["MVUploadSignature"].ToString();

                var fileInfo = new FileInfo(fileSignature.FileName);
                if (!(fileInfo.Extension.ToLower().Equals(".jpeg") || fileInfo.Extension.ToLower().Equals(".jpg")))
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerHtml = "Please Check the file extension.It should be either of type jpg or jpeg";
                    return;
                }
                else
                {
                    if (!Directory.Exists(signFilePath))
                    {
                        Directory.CreateDirectory(signFilePath);
                    }
                    string saveFileName = fileSignature.FileName.Substring(0, fileSignature.FileName.IndexOf(".")) + DateTime.Now.ToFileTimeUtc() + fileInfo.Extension;
                    if (fileSignature.HasFile)
                    {
                        fileSignature.PostedFile.SaveAs(signFilePath + "\\" + saveFileName);
                    }
                    signPath = signPath + "/" + saveFileName;
                }
            }
        }

        emvUser.DigitalSignature = signPath;
        emvmvUser.MedicalVendor = medicalVendor;

        if (ViewState["IsAuthorizationAllowed"] != null)
            emvmvUser.IsAuthorizationsAllowed = Convert.ToBoolean(ViewState["IsAuthorizationAllowed"]);

        if (ViewState["CutoffDate"] != null)
            emvmvUser.CutOffDate = ViewState["CutoffDate"].ToString();
        if (ViewState["ShowEarningAmount"] != null)
            emvmvUser.ShowEarningAmount = Convert.ToBoolean(ViewState["ShowEarningAmount"]);

        emvmvUser.MVUser = emvUser;

        Int64 returnresult;

        var eUserShellModuleRole = new EUserShellModuleRole
                                                        {
                                                            RoleID = "1",
                                                            ShellID = "1",
                                                            UserID = "1"
                                                        };

        var medicalvendorDal = new MedicalVendorDAL();
        returnresult = medicalvendorDal.SaveMedicalVendorUserProfile(emvmvUser, Convert.ToInt32(EOperationMode.Update), eUserShellModuleRole.UserID, Convert.ToInt64(eUserShellModuleRole.ShellID), eUserShellModuleRole.RoleID);

        if (txtPassword.Text.Length > 0)
        {
            var userLoginService = IoC.Resolve<IUserLoginService>();
            var userContext = IoC.Resolve<SessionContext>();
            userLoginService.ResetPassword(Convert.ToInt32(userContext.UserSession.UserId), txtPassword.Text, false, userContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId,false);
        }

        Response.RedirectUser(this.ResolveUrl("MedicalVendorUserProfile.aspx"));
    }

    private void FillMvUserData()
    {

        var medicalvendorDal = new MedicalVendorDAL();
        List<EMVMVUser> emvmvUsers = medicalvendorDal.GetMedicalVendorMedicalVendorUserProfile(IoC.Resolve<SessionContext>().UserSession.UserId.ToString(), 1);

        if (emvmvUsers != null)
        {
            ViewState["AuditRequired"] = emvmvUsers[0].AuditRequired;
            ViewState["UserID"] = emvmvUsers[0].MVUser.User.UserID;
            ViewState["MedicalVendorID"] = emvmvUsers[0].MedicalVendor.MedicalVendorID;
            ViewState["MVUserID"] = emvmvUsers[0].MVUser.MVUserID;
            ViewState["strResumeURL"] = emvmvUsers[0].MVUser.Resume;
            ViewState["CutoffDate"] = emvmvUsers[0].CutOffDate;
            ViewState["ShowEarningAmount"] = emvmvUsers[0].ShowEarningAmount;
            if ((ViewState["strResumeURL"] == null) || (Convert.ToString(ViewState["strResumeURL"]) == ""))
            {
                spDwnResume.Visible = false;
            }
            else
            {
                spDwnResume.Visible = true;

                ClientScript.RegisterStartupScript(typeof(Page), "DwnResume", "<script language='javascript'  type='text/javascript' >var aDwnResume=document.getElementById('aDwnResume'); aDwnResume.href='" + emvmvUsers[0].MVUser.Resume + "'; </script>");
            }
            ViewState["strSignatureURL"] = emvmvUsers[0].MVUser.DigitalSignature;
            if ((ViewState["strSignatureURL"] == null) || (Convert.ToString(ViewState["strSignatureURL"]) == ""))
            {

                spDwnSignature.Visible = false;
            }
            else
            {
                spDwnSignature.Visible = true;
                ClientScript.RegisterStartupScript(typeof(Page), "DwnSign", "<script language='javascript'  type='text/javascript' >var aDwnSign=document.getElementById('aDwnSign'); aDwnSign.href='" + emvmvUsers[0].MVUser.DigitalSignature + "'; </script>");
            }

            ddlVendorName.SelectedValue = emvmvUsers[0].MedicalVendor.MedicalVendorID.ToString();
            // txtDateApplied.Text = "";
            txtFirstName.Text = emvmvUsers[0].MVUser.User.FirstName;
            txtLastName.Text = emvmvUsers[0].MVUser.User.LastName;
            txtMiddleName.Text = emvmvUsers[0].MVUser.User.MiddleName;
            ddlSpecialization.SelectedValue = emvmvUsers[0].MVUser.MVUserSpecialization.MVUserSpecilaizationID.ToString();
            //  ddlClassification.SelectedValue = mvmvuser[0].MVUser.MVUserClassification.MVUserClassificationID.ToString();
            if (emvmvUsers[0].MVUser.User.DOB == "")
                txtDOB.Text = "";
            else
            {
                DateTime DOB = Convert.ToDateTime(emvmvUsers[0].MVUser.User.DOB);
                txtDOB.Text = DOB.ToString("MM/dd/yyyy");
            }
            txtSSN.Text = emvmvUsers[0].MVUser.User.SSN;
            ViewState["IsAuthorizationAllowed"] = emvmvUsers[0].IsAuthorizationsAllowed;

            ////////////////////business infor///////////////////////////////////////
            txtAddress1.Text = emvmvUsers[0].MVUser.User.HomeAddress.Address1;
            txtAddress2.Text = emvmvUsers[0].MVUser.User.HomeAddress.Address2;
            hfCountryID.Value = emvmvUsers[0].MVUser.User.HomeAddress.CountryID.ToString();
            //FillState();
            ddlState.SelectedValue = emvmvUsers[0].MVUser.User.HomeAddress.StateID.ToString();
            //FillCity();
            txtCity.Text = emvmvUsers[0].MVUser.User.HomeAddress.City.ToString();
            txtZip.Text = emvmvUsers[0].MVUser.User.HomeAddress.Zip.ToString();
            txtPhoneC.Text = emvmvUsers[0].MVUser.User.PhoneCell;
            txtPhoneH.Text = emvmvUsers[0].MVUser.User.PhoneHome;
            txtPhoneO.Text = emvmvUsers[0].MVUser.User.PhoneOffice;
            txtEmail1.Text = emvmvUsers[0].MVUser.User.EMail1;
            txtEmail2.Text = emvmvUsers[0].MVUser.User.EMail2;
            ViewState["Resume"] = emvmvUsers[0].MVUser.Resume;
            ViewState["Signature"] = emvmvUsers[0].MVUser.DigitalSignature;
            ViewState["ClassificationID"] = emvmvUsers[0].MVUser.MVUserClassification.MVUserClassificationID.ToString();

            Ucupdatephotopanel1.Images = emvmvUsers[0].MVUser.OtherPictures.ToList();
            Ucupdatephotopanel1.MyImage = emvmvUsers[0].MVUser.MyPicture;

            DataTable dtpackagetest = new DataTable();
            dtpackagetest.Columns.Add("TestID");
            dtpackagetest.Columns.Add("Test");
            dtpackagetest.Columns.Add("PayRate");

            EMVTestPayRate[] userpayrate = emvmvUsers[0].MVUser.MVTestPayRate.ToArray();
            if (userpayrate != null)
            {
                for (int icount = 0; icount < userpayrate.Length; icount++)
                {
                    dtpackagetest.Rows.Add(new object[] { userpayrate[icount].Test.TestID, userpayrate[icount].Test.Name, userpayrate[icount].PayRate });
                }
            }
            ddlVendorName.Enabled = false;
        }
    }

    private void GetVendorSpecification()
    {
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        var listMVSpecialization = medicalVendorDal.GetMVUserSpecialization(string.Empty, 3);
        Falcon.Entity.MedicalVendor.EMVUserSpecialization[] medicalvendorspecialization = null;

        if (listMVSpecialization != null) medicalvendorspecialization = listMVSpecialization.ToArray();

        if (medicalvendorspecialization.Length > 0)
        {
            ddlSpecialization.Items.Add(new ListItem("Select Specilization", "0"));
            for (int count = 0; count < medicalvendorspecialization.Length; count++)
            {
                ddlSpecialization.Items.Add(new ListItem(medicalvendorspecialization[count].Name, medicalvendorspecialization[count].MVUserSpecilaizationID.ToString()));

            }
        }

    }


    private void GetMedicalVendor()
    {
        MedicalVendorDAL medicalVendorDal = new MedicalVendorDAL();
        List<EMedicalVendor>  medicalVendors = medicalVendorDal.GetAllMedicalVendor(string.Empty, 0);
        if (medicalVendors.Count > 0)
        {
            ddlVendorName.Items.Add(new ListItem("Select Vendor", "0"));
            for (int count = 0; count < medicalVendors.Count; count++)
            {
                ddlVendorName.Items.Add(new ListItem(medicalVendors[count].BusinessName.ToString(), medicalVendors[count].MedicalVendorID.ToString()));
            }
        }
    }

    private void FillTest()
    {
        FranchisorDAL masterDAL = new FranchisorDAL();
        // Gets All Active Tests
        var testobject = masterDAL.GetTest(string.Empty, 3);

        DataTable dtTest = new DataTable();
        dtTest.Columns.Add("TestId", typeof(Int64));
        dtTest.Columns.Add("Test");

        if (testobject != null)
        {
            for (int icount = 0; icount < testobject.Count; icount++)
            {
                dtTest.Rows.Add(new object[] { testobject[icount].TestID, testobject[icount].Name });
            }
        }
        ViewState["DataTableTest"] = dtTest;

    }

    private void ResetAll()
    {
        txtAddress1.Text = "";
        txtAddress2.Text = "";
        txtZip.Text = "";
        txtFirstName.Text = "";
        txtMiddleName.Text = "";
        txtLastName.Text = "";
        txtDOB.Text = "";
        // txtSSN.Text = "";
        txtPhoneC.Text = "";
        txtPhoneH.Text = "";
        txtPhoneO.Text = "";
        txtEmail1.Text = "";
        txtEmail2.Text = "";
        //txtRefName1.Text = "";
        //txtRefEmail1.Text = "";
        //txtRefName2.Text = "";
        //txtRefEmail2.Text = "";
        //txtRefName3.Text = "";
        //txtRefEmail3.Text = "";
        ddlSpecialization.SelectedIndex = 0;
        // ddlClassification.SelectedIndex = 0;
        ddlVendorName.SelectedIndex = 0;
        //  txtDateApplied.Text = DateTime.Now.ToString("MM-dd-yyyy");
        // txtDateApplied.ReadOnly = true;
    }

    protected void grdtextpayrates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox chktemp = (CheckBox)e.Row.FindControl("chkrowchild");
            TextBox txtTemp = (TextBox)e.Row.FindControl("txtpayrate");

            if (chktemp != null)
            {
                chktemp.Attributes["onClick"] = "enabletextbox('" + chktemp.ClientID + "','" + txtTemp.ClientID + "');";
            }
            ClientScript.RegisterStartupScript(typeof(Page), "jsscript" + e.Row.DataItemIndex, "<script language='javascript'  type='text/javascript' > var txtpayrates = document.getElementById('" + txtTemp.ClientID + "'); txtpayrates.disabled = 'disabled'; </script>");

        }
    }

    private void GetDropDownInfo()
    {
        MasterDAL masterDal = new MasterDAL();
        Falcon.Entity.Other.ECountry[] objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();

        hfCountryID.Value = objcountry[0].CountryID.ToString();

        var objstate = masterDal.GetState(string.Empty, 3);

        ddlState.Items.Clear();
        ddlState.Items.Add(new ListItem("Select State", "0"));

        for (int icount = 0; icount < objstate.Count; icount++)
        {
            if (objstate[icount].Country.CountryID.ToString().Equals(hfCountryID.Value))
                ddlState.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));
        }

        GetVendorSpecification();
        GetMedicalVendor();
    }

    protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
    {
        SaveMedicalVendor();

    }

    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(this.ResolveUrl("MedicalVendorUserProfile.aspx"));
    }


}
