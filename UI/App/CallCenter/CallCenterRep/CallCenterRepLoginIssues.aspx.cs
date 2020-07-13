using System;
using System.Collections.Generic;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.CallCenter.Enum;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.UI.Extentions;
using Falcon.App.UI.Helper;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Lib;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Deprecated.Repository;

public partial class App_CallCenter_CallCenterRepLoginIssues : Page
{
    
    private string GuId
    {
        get
        {
            return string.IsNullOrEmpty(Request.QueryString["guid"]) ? "" : Request.QueryString["guid"];
        }
    }

    private RegistrationFlowModel RegistrationFlow
    {
        get
        {
            if (!string.IsNullOrEmpty(GuId))
            {
                return Session[GuId] as RegistrationFlowModel;
            }
            return null;
        }
    }

    protected long CallId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CallId : 0;
        }
        set { RegistrationFlow.CallId = value; }
    }

    protected long CustomerId
    {
        get
        {
            return RegistrationFlow != null ? RegistrationFlow.CustomerId : 0;
        }
    }

    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "CallCenterRep Login Issues";
        CallCenter_CallCenterMaster1 obj;
        obj = (CallCenter_CallCenterMaster1)this.Master;
        obj.SetTitle("CallCenterRep Login Issues");
        obj.SetBreadCrumbRoot = "<a href=\"/CallCenter/CallCenterRepDashboard/Index\">Dashboard</a>";
        if (!IsPostBack)
        {

            var callCenterCallRepo = new CallCenterCallRepository();

            hfCallStartTime.Value = callCenterCallRepo.GetCallStarttime(CallId);
            if (ViewState["UrlReferer"] == null)
            {
                if (Request.UrlReferrer != null) ViewState["UrlReferer"] = Request.UrlReferrer.PathAndQuery;
            }

            SetCustomerDetails();

        }
    }
    protected void imgbtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        //Case 1 :User Don't have anything
        spbtnNext.Style.Add(HtmlTextWriterStyle.Display, "none");
        spbtnReset.Style.Add(HtmlTextWriterStyle.Display, "block");
        imgbtnResolved.Style.Add(HtmlTextWriterStyle.Display, "block");
        if (chkUserName.Checked == true && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";

            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spMsg.InnerHtml = getScript("ManualVerificationScript");
            divMail.InnerText = "";
            ViewstateNull();
            ViewState["Case1"] = "set";
        }
        //Case 2 :User Only have Email
        else if (chkUserName.Checked == true && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("True"))
        {
            image3.Src = "/App/Images/page2symbolvsmall.gif";
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";

            SimpleSecondaryVerification(CustomerId);
            spMsg.InnerText = "We will be sending your username and reset password link through email.";
            ViewstateNull();
            ViewState["Case2"] = spPwd.InnerHtml.ToString().Trim();
        }
        //Case 3 :User Only have Hint Security Question
        else if (chkUserName.Checked == true && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");

            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "block");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            spPwd.Style.Add(HtmlTextWriterStyle.Display, "block");
            spPwd.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "block");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Visibility, "visible");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "block");
            spUserN.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            divMail.InnerText = "";

            SecurityQuestionVerification(CustomerId);
            spMsg.InnerText = "Use the same username and Temporary password.";
            ViewstateNull();
            ViewState["Case3"] = spPwd.InnerHtml.ToString().Trim();
        }
        //Case 4 :User Have Hint Security Question & Email
        else if (chkUserName.Checked == true && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("True"))
        {
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";

            SecurityQuestionVerification(CustomerId);
            spMsg.InnerText = "We will be sending your username and reset password link through email.";
            ViewstateNull();
            ViewState["Case4"] = spPwd.InnerHtml.ToString().Trim();

        }
        //Case 5 :User Only have Password
        else if (chkUserName.Checked == true && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            //divVerification.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

            //divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            spMsg.InnerHtml = getScript("ManualVerificationScript");
            divMail.InnerText = "";
            ViewstateNull();
            ViewState["Case5"] = "set";

            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        //Case 6 :User Have Password & Email
        else if (chkUserName.Checked == true && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("True"))
        {
            image3.Src = "/App/Images/page2symbolvsmall.gif";
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "block");

            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "block");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");

            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";

            SimpleSecondaryVerification(CustomerId);
            spMsg.InnerText = "We will be sending your username through email.";
            ViewstateNull();
            ViewState["Case6"] = "set";

        }
        //Case 7:User Have Password & Hint Security Question
        else if (chkUserName.Checked == true && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "block");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "block");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";
            SecurityQuestionVerification(CustomerId);
            spMsg.InnerText = "Use login credentials for login.";
            ViewstateNull();
            ViewState["Case7"] = "set";


        }
        //Case 8:User Have Password, Hint Security Question & Email
        else if (chkUserName.Checked == true && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("True"))
        {
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";

            SecurityQuestionVerification(CustomerId);
            spMsg.InnerText = "We will be sending your username through email.";
            ViewstateNull();
            ViewState["Case8"] = "set";

        }
        //Case 9:User Only have User Name
        else if (chkUserName.Checked == false && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            //image4.Src = "/App/Images/page3symbolvsmall.gif";

            //divVerification.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

            //divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            //spPwd.Style.Add(HtmlTextWriterStyle.Display, "block");

            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            //spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "block");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spMsg.InnerText = "";
            divMail.InnerText = "";
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");

            spMsg.InnerHtml = getScript("ManualVerificationScript");

            ViewstateNull();
            ViewState["Case9"] = "set";
        }
        //Case 10:User Have User Name & Email
        else if (chkUserName.Checked == false && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("True"))
        {
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divResolution.Style.Add(HtmlTextWriterStyle.Display, "none");

            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "none");

            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spMsg.InnerText = "";
            divMail.InnerText = "";
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            spMsg.InnerText = "We will be sending the reset password link through email.";

            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.InnerText = GetRandomString(5, true);
            ViewstateNull();
            ViewState["Case10"] = spPwd.InnerHtml.ToString().Trim();

        }
        //Case 11:User have User Name & Hint Security Question
        else if (chkUserName.Checked == false && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "block");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "block");

            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.InnerText = "";
            SecurityQuestionVerification(CustomerId);
            spMsg.InnerText = "Use login credentials for login.";
            ViewstateNull();
            ViewState["Case11"] = spPwd.InnerText.ToString().Trim();


        }
        //Case 12:User have UserName, Hint Security Question & Email
        else if (chkUserName.Checked == false && chkPassword.Checked == true && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("True"))
        {
            image4.Src = "/App/Images/page3symbolvsmall.gif";
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            spMsg.InnerText = "";
            divMail.InnerText = "";
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            SecurityQuestionVerification(CustomerId);
            spMsg.InnerText = "We will be sending the reset password link through email.";
            ViewstateNull();
            ViewState["Case12"] = spPwd.InnerHtml.ToString().Trim();

        }
        //Case 13:User have User Name & Password
        else if (chkUserName.Checked == false && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            spMsg.InnerText = "No Problem! During login they will be forced to set up the security question";

            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            ViewstateNull();
            ViewState["Case13"] = "set";
        }

        //Case 14:User have User Name, Password & Email
        else if (chkUserName.Checked == false && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("False") && hfEmail.Value.Equals("True"))
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            spMsg.InnerText = "No Problem! During login they will be forced to set up the security question";

            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.InnerText = "";
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            ViewstateNull();
            ViewState["Case14"] = "set";
        }

        //Case 15:User have User Name, Password & Hint Security Question
        else if (chkUserName.Checked == false && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("False"))
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            spMsg.InnerText = "Your account has been unlocked, you can login by using your previous login credentials";
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");

            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            divMail.InnerText = "";
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            ViewstateNull();
            ViewState["Case15"] = "set";
        }
        //Case 16:User have All(User Name, Password, Hint Security Question & Email)
        else if (chkUserName.Checked == false && chkPassword.Checked == false && hfSecurityQustion.Value.Equals("True") && hfEmail.Value.Equals("True") && chkAccountLocked.Checked == false)
        {
            image4.Src = "/App/Images/page2symbolvsmall.gif";
            spMsg.InnerText = getScript("BestCase");

            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.InnerText = "";
            ViewstateNull();
            ViewState["Case16"] = "set";
        }

        //Case 17: Account Locked
        else if (chkAccountLocked.Checked && chkUserName.Checked == false && chkPassword.Checked == false)
        {
            image3.Src = "/App/Images/page2symbolvsmall.gif";
            image4.Src = "/App/Images/page3symbolvsmall.gif";

            // release account
            ReleaseUserLoginLock();

            spMsg.InnerText = "";
            spMsg.InnerText = "Your account has been unlocked, you can login by using your previous login credentials";
            divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "block");
            divResolution.Style.Add(HtmlTextWriterStyle.Display, "block");
            divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
            divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");

            divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "block");
            divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "block");

            spUserN.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourUserName.Style.Add(HtmlTextWriterStyle.Display, "none");

            spYourPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            spPwd.Style.Add(HtmlTextWriterStyle.Display, "none");

            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.InnerText = "";
            ViewstateNull();
            ViewState["Case17"] = "set";
        }
        // UnLock Account
        if (chkAccountLocked.Checked || chkPassword.Checked)
        {
            ReleaseUserLoginLock();
            if (chkAccountLocked.Checked && ViewState["Case17"] == null && ViewState["Case15"] == null)
                spMsg.InnerHtml = string.IsNullOrEmpty(spMsg.InnerHtml) ? "<br />Your account has been unlocked." : spMsg.InnerHtml + "<br />Your account has been unlocked.";
        }
    }

    private void ReleaseUserLoginLock()
    {

        IoC.Resolve<IUserLoginRepository>().ReleaseUserLoginLock(IoC.Resolve<IOrganizationRoleUserRepository>().GetOrganizationRoleUser(CustomerId).UserId);

    }

    private void DisplayInfoDiv(bool displayStatus)
    {
        if (displayStatus)
        {
            divMail.Style.Add(HtmlTextWriterStyle.Display, "block");
            divMail.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
        }
        else
        {
            divMail.Style.Add(HtmlTextWriterStyle.Display, "none");
            divMail.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
        }
    }

    protected void imgbtnResolved_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["Case1"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
            ViewState["Case1"] = null;
        }
        else if (ViewState["Case2"] != null)
        {
            //string resetPwdQueryString = SetPassword(ViewState["Case2"].ToString());
            bool mailsentUserName = SendParsedMailUserName();
            bool mailsentPassword = SendParsedMailPassword();
            if (mailsentUserName == true && mailsentPassword == true)
            {
                divMail.InnerText = "The Login Issue has been resolved successfully.The User Name & Reset Password Link has been sent to Customer's email.";
                DisplayInfoDiv(true);
            }
            ViewState["Case2"] = null;
        }
        else if (ViewState["Case3"] != null)
        {
            SetPassword(ViewState["Case3"].ToString());
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case4"] != null)
        {
            //string resetPwdQueryString = SetPassword(ViewState["Case4"].ToString());
            bool mailsentUserName = SendParsedMailUserName();
            bool mailsentPassword = SendParsedMailPassword();
            if (mailsentUserName == true && mailsentPassword == true)
            {
                divMail.InnerText = "The Login Issue has been resolved successfully.The User Name &  Reset Password Link has been sent to Customer's email.";
                DisplayInfoDiv(true);
            }
        }
        else if (ViewState["Case5"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case6"] != null)
        {
            bool mailsentUserName = SendParsedMailUserName();
            if (mailsentUserName)
            {
                divMail.InnerText = "The Login Issue has been resolved successfully.The User Name has been sent to Customer's email.";
                DisplayInfoDiv(true);
            }
        }
        else if (ViewState["Case7"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case8"] != null)
        {
            bool mailsentUserName = SendParsedMailUserName();
            if (mailsentUserName)
            {
                divMail.InnerText = "The Login Issue has been resolved successfully.The User Name has been sent to Customer's email.";
                DisplayInfoDiv(true);
            }
        }
        else if (ViewState["Case9"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";

        }
        else if (ViewState["Case10"] != null)
        {
            //string resetPwdQueryString = SetPassword(ViewState["Case10"].ToString());
            bool mailsentPassword = SendParsedMailPassword();
            if (mailsentPassword)
            {
                divMail.InnerText = "The Login Issue has been resolved successfully.The Reset Password Link has been sent to Customer's email.";
                DisplayInfoDiv(true);
            }
        }
        else if (ViewState["Case11"] != null)
        {
            SetPassword(ViewState["Case11"].ToString());
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case12"] != null)
        {
            //string resetPwdQueryString = SetPassword(ViewState["Case12"].ToString());
            bool mailsentPassword = SendParsedMailPassword();
            if (mailsentPassword == true)
            {
                divMail.InnerText = "The Login Issue has been resolved successfully.The Reset Password Link has been sent to Customer's email.";
                DisplayInfoDiv(true);
            }
        }
        else if (ViewState["Case13"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case14"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case15"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case16"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        else if (ViewState["Case17"] != null)
        {
            DisplayInfoDiv(true);
            divMail.InnerText = "The Login Issue has been resolved successfully";
        }
        if (!(Request.QueryString["Call"] != null && Request.QueryString["Call"] == "No"))
        {
            var repository = new CallCenterCallRepository();
            var call = repository.GetCallCenterEntity(CallId);
            EndCall();
            StartCall(call.CalledCustomerID);

        }
        Response.RedirectUser("CustomerOptions.aspx?CustomerID=" + Request.QueryString["CustomerID"] + "&Name=" + Request.QueryString["Name"] + "&guid=" + GuId);
    }
    protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
    {

        if (ViewState["UrlReferer"] != null)
        {
            Response.RedirectUser(ViewState["UrlReferer"].ToString());
        }
        else
        {
            Response.RedirectUser("CustomerOptions.aspx");
        }
    }
    protected void ibtReset_Click(object sender, ImageClickEventArgs e)
    {
        spbtnNext.Style.Add(HtmlTextWriterStyle.Display, "block");
        spbtnReset.Style.Add(HtmlTextWriterStyle.Display, "none");
        divSecurityQuestionHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
        divSecurityQuestion.Style.Add(HtmlTextWriterStyle.Display, "none");
        divVerificationHeading.Style.Add(HtmlTextWriterStyle.Display, "none");
        divVerification.Style.Add(HtmlTextWriterStyle.Display, "none");
        divResolutionheading.Style.Add(HtmlTextWriterStyle.Display, "none");
        divResolution.Style.Add(HtmlTextWriterStyle.Display, "none");
        imgbtnResolved.Style.Add(HtmlTextWriterStyle.Display, "none");
        chkAccountLocked.Checked = false;
        chkPassword.Checked = false;
        chkUserName.Checked = false;

    }


    #endregion

    #region Methods
    private void SetCustomerDetails()
    {
        var customerRepository = IoC.Resolve<ICustomerRepository>();
        var customer = customerRepository.GetCustomer(CustomerId);

        if (customer != null)
        {
            var objCCode = new CommonCode();
            
            string userLogin = customer.UserLogin.UserName;

            string username = customer.Name.FullName;


            spdob.InnerText = customer.DateOfBirth != null ? customer.DateOfBirth.Value.ToString("MM/dd/yyyy") : "";
            spCustomerName.InnerText = username;
            spUserName.InnerText = userLogin;
            spEmail.InnerText = customer.Email != null ? customer.Email.ToString() : "";
            hfEmail.Value = customer.Email != null && customer.Email.ToString().Length > 0 ? "True" : "False";
            spAddress.InnerText = CommonCode.AddressSingleLine(customer.Address.StreetAddressLine1, customer.Address.StreetAddressLine2, customer.Address.City, customer.Address.State, customer.Address.ZipCode.ToString());
            spPhone.InnerText = customer.HomePhoneNumber != null && customer.HomePhoneNumber.ToString().Length > 0 ? objCCode.FormatPhoneNumberGet(customer.HomePhoneNumber.ToString()) : "-N/A-";
            if (!string.IsNullOrEmpty(customer.UserLogin.HintQuestion))
            {
                spHintSecurityQuestion.InnerText = customer.UserLogin.HintQuestion;
                spAnswer.InnerText = customer.UserLogin.HintAnswer.Length > 0 ? customer.UserLogin.HintAnswer : "-N/A-";
                hfSecurityQustion.Value = "True";
            }

        }
    }

    public static string GetRandomString(int length, bool isNumeric)
    {
        var ranString = new System.Text.StringBuilder(length);
        int charIndex;
        if (!isNumeric)
        {
            for (int i = 1; i <= length; i++)
            {
                // allow only digits and letters
                do
                {
                    charIndex = RandomNumberHelper.Between(48, 123);
                } while (!((charIndex >= 48 && charIndex <= 57) ||
                (charIndex >= 65 && charIndex <= 90) || (charIndex >= 97 && charIndex <= 122)));

                // add the random char to the ranString being built
                ranString.Append(Convert.ToChar(charIndex));
            }
        }
        else
        {
            string strRandomNumber = string.Empty;
            for (int i = 1; i <= length; i++)
            {
                charIndex = RandomNumberHelper.Between(1, 9999);
                if (i > 1 && strRandomNumber.Length > length)
                    break;
                strRandomNumber = strRandomNumber + charIndex.ToString();
            }
            ranString.Append(strRandomNumber.Substring(0, length));
        }
        return ranString.ToString();
    }

    private void SimpleSecondaryVerification(long customerid)
    {

        var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(customerid);
        if (customer != null)
        {
            spDOB1.InnerText = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.ToString("MM/dd/yyyy") : "";
            spAddress1.InnerText = CommonCode.AddressSingleLine(customer.Address.StreetAddressLine1, customer.Address.StreetAddressLine2, customer.Address.City, customer.Address.State, customer.Address.ZipCode.ToString());

            string userLogin = customer.UserLogin.UserName;
            spUserN.InnerText = userLogin;
            spPwd.InnerText = GetRandomString(5, true);

        }
    }

    private void SetPassword(string password)
    {
        var orgRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
        var orgRoleUser = orgRoleUserRepository.GetOrganizationRoleUser(CustomerId);

        var sessionContext = IoC.Resolve<ISessionContext>();


        var userLoginService = IoC.Resolve<IUserLoginService>();
        userLoginService.ForceChangePassword(orgRoleUser.UserId, password, true, sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, false);
    }

    private bool SendParsedMailUserName()
    {
        var notifier = IoC.Resolve<INotifier>();
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var customerRepository = IoC.Resolve<ICustomerRepository>();
        var customer = customerRepository.GetCustomer(CustomerId);

        var loginIssueSendUserName = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(customer.UserLogin.UserName, customer.Name.FullName, customer.DateCreated);
        notifier.NotifySubscribersViaEmail(NotificationTypeAlias.LoginIssuesSendUsername, EmailTemplateAlias.LoginIssuesSendUsername, loginIssueSendUserName, customer.Id, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);

        return true;
    }

    private bool SendParsedMailPassword()
    {
        var notifier = IoC.Resolve<INotifier>();
        var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        var customerRepository = IoC.Resolve<ICustomerRepository>();
        var customer = customerRepository.GetCustomer(CustomerId);

        var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
        customerRegistrationService.SendResetPasswordMail(customer.Id, customer.Name.FullName, currentSession.CurrentOrganizationRole.OrganizationRoleUserId, Request.Url.AbsolutePath);
        return true;
    }

    private void SecurityQuestionVerification(long customerid)
    {
        var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(customerid);
        if (customer != null)
        {
            string userLogin = customer.UserLogin.UserName;
            spUserN.InnerText = userLogin;
            spPwd.InnerText = GetRandomString(5, true);
            spHintSecurityQuestion.InnerText = customer.UserLogin.HintQuestion;
            spAnswer.InnerText = customer.UserLogin.HintAnswer;
        }
    }

    private void ViewstateNull()
    {
        ViewState["Case1"] = null;
        ViewState["Case2"] = null;
        ViewState["Case3"] = null;
        ViewState["Case4"] = null;
        ViewState["Case5"] = null;
        ViewState["Case6"] = null;
        ViewState["Case7"] = null;
        ViewState["Case8"] = null;
        ViewState["Case9"] = null;
        ViewState["Case10"] = null;
        ViewState["Case11"] = null;
        ViewState["Case12"] = null;
        ViewState["Case13"] = null;
        ViewState["Case14"] = null;
        ViewState["Case15"] = null;
        ViewState["Case16"] = null;
        ViewState["Case17"] = null;
    }

    private string getScript(string scriptName)
    {
        //CallCenterService CService = new CallCenterService();
        //EScript[] objManualVerificationScript;
        //objManualVerificationScript = CService.GetScriptByName(scriptName);

        CallCenterDAL masterDal = new CallCenterDAL();
        return masterDal.GetScript(scriptName, 2)[0].ScriptText;
    }

    private void StartCall(long calledCustomerid)
    {
        var objCcRepCall = new ECall();

        if (CallId > 0)
        {
            var repository = new CallCenterCallRepository();
            var call = repository.GetCallCenterEntity(CallId);

            objCcRepCall.IncomingPhoneLine = call.IncomingPhoneLine;
            objCcRepCall.CallersPhoneNumber = call.CallersPhoneNumber;
        }

        objCcRepCall.CallCenterCallCenterUserID = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        objCcRepCall.TimeCreated = DateTime.Now.ToString();
        objCcRepCall.CalledCustomerID = calledCustomerid;
        objCcRepCall.CallNotes = new List<ECallCenterNotes>();

        var callcenterDal = new CallCenterDAL();
        CallId = callcenterDal.UpdateCall(objCcRepCall);
    }

    private void EndCall()
    {
        var repository = new CallCenterCallRepository();
        var objCall = repository.GetCallCenterEntity(CallId);

        objCall.TimeEnd = DateTime.Now.ToString();
        objCall.Status = (long)CallStatus.Attended;

        var callcenterDal = new CallCenterDAL();
        callcenterDal.UpdateCall(objCall);
    }

    #endregion

}

