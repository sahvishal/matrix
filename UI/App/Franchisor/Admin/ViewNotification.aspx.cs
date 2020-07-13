using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisor;
using Falcon.App.Lib;
//using HealthYes.Web.UI.NotificationService;

public partial class App_Franchisor_Admin_ViewNotification : Page
{
    protected string strBody = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "View Notification";
        Franchisor_FranchisorMaster obj;

        obj = (Franchisor_FranchisorMaster)Master;
        obj.settitle("View Notification");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();
        divMessage.InnerText = "";
        if (!IsPostBack)
        {
            Int64 NotificationID;
            if (Request["NotificationID"] != null && Request["NotificationID"] != "")
            {
                NotificationID = Convert.ToInt64(Request["NotificationID"]);
                ViewState["NotificationID"] = NotificationID.ToString();
                if (Session["StartDate"] != null)
                {
                    hidBack.Value = "mode1";
                }
                else if (Request["mode"] != null)
                {
                    hidBack.Value = "mode2";
                    hidCustomerID.Value = Request.UrlReferrer.OriginalString;
                }
                LoadNotification(NotificationID);

            }
            //Request["content1"] -- Get content
        }

    }

    private void LoadNotification(Int64 NotificationID)
    {
        //NotificationService objNotificationService = new NotificationService();
        //HealthYes.Web.UI.NotificationService.ENotificationOther objENotificationOther = new HealthYes.Web.UI.NotificationService.ENotificationOther();

        CommonCode objCCode = new CommonCode();

        FranchisorDAL objDAL = new FranchisorDAL();
        var objENotificationOther = objDAL.GetNotificationViewOther(NotificationID);

        //objENotificationOther = objNotificationService.GetNotificationViewOther(NotificationID, true);

        spCustomerName.InnerText = objENotificationOther.CustomerName;
        spEmail.InnerText = objENotificationOther.Email;
        spcutomerid.InnerText = objENotificationOther.CustomerID.ToString();

        if (objENotificationOther.ImagePath != null && objENotificationOther.ImagePath.Length > 0)
        {
            imgMyPicture.ImageUrl = objCCode.GetPicture(Request.MapPath(objENotificationOther.ImagePath), objENotificationOther.ImagePath);
        }
        //if (objENotificationOther.ImagePath != "")
        //{
        //    if (File.Exists(objENotificationOther.ImagePath))
        //    {
        //        imgMyPicture.ImageUrl = objENotificationOther.ImagePath;
        //    }
        //    else
        //    {
        //        imgMyPicture.ImageUrl = "~/App/Images/No-Image-Found.gif";
        //    }
        //}
        //else
        //{
        //    imgMyPicture.ImageUrl = "~/App/Images/No-Image-Found.gif";

        //}
        spGender.InnerText = objENotificationOther.Gender;
        spdob.InnerText = objENotificationOther.Dob;
        spUserName.InnerText = objENotificationOther.Username;
        spAddress.InnerText = objENotificationOther.Address;
        spPhone.InnerText = objCCode.FormatPhoneNumberGet(objENotificationOther.PhoneNo);
        spSignUpDate.InnerText = objENotificationOther.SignUpDate;
        if (objENotificationOther.LastLoginDate.Equals("1/1/1901") || objENotificationOther.LastLoginDate.Equals("01/01/1901") || objENotificationOther.LastLoginDate.Equals("1/1/1901 12:00:00 AM"))
        {
            spLastLogin.InnerText = "Never Logged In";
        }
        else
        {
            spLastLogin.InnerText = objENotificationOther.LastLoginDate;
        }

        if (objENotificationOther.NotificationDate != "")
        {
            objENotificationOther.NotificationDate = objENotificationOther.NotificationDate.Replace("@", " @ ");
            objENotificationOther.NotificationDate = objENotificationOther.NotificationDate.Replace("@  ", "@ ");
            objENotificationOther.NotificationDate = objENotificationOther.NotificationDate.Replace("PM", " PM");
            objENotificationOther.NotificationDate = objENotificationOther.NotificationDate.Replace("AM", " AM");

        }

        spNotificationTime.InnerText = objENotificationOther.NotificationDate;

        spNotificationType.InnerText = objENotificationOther.NotificationType;
        if (objENotificationOther.NotificationMedium.Equals("Email"))
        {
            imgMedium.Src = @"/App/Images/Email-icon.gif";
            imgMedium.Alt = "Email";
        }
        else if (objENotificationOther.NotificationMedium.Equals("Phone"))
        {
            imgMedium.Src = @"/App/Images/Phone-icon.gif";
            imgMedium.Alt = "Phone";
            ImageButton1.Visible = false;
        }
        else if (objENotificationOther.NotificationMedium.Equals("SMS"))
        {
            imgMedium.Src = @"/App/Images/Phone-icon.gif";
            imgMedium.Alt = "Phone";
        }
        else if (objENotificationOther.NotificationMedium.Equals("Fax"))
        {
            imgMedium.Src = @"/App/Images/Phone-icon.gif";
            imgMedium.Alt = "Phone";
            ImageButton1.Visible = false;
        }

        if (objENotificationOther.NotificationMedium.Equals("Email") && string.IsNullOrEmpty(objENotificationOther.Email))
        {
            ImageButton1.Visible = false;
        }
        else if (objENotificationOther.NotificationMedium.Equals("SMS") && string.IsNullOrEmpty(objENotificationOther.PhoneNo))
        {
            ImageButton1.Visible = false;
        }

        spSender.InnerText = objENotificationOther.ServicedBy;
        txtSubject.Text = objENotificationOther.MailSubject;
        //txtBody.Text = objENotificationOther.MailBody;
        strBody = objENotificationOther.MailBody;
        //Request["content1"]

    }

    private void ReServiced(Int64 NotificationID)
    {
        string JSCode = string.Empty;
        Int64 returnvalue = 0;

        string strEmailSubject = string.Empty;
        string strEmailBody = string.Empty;

        if (txtSubject.Text != "")
        {
            strEmailSubject = txtSubject.Text;
        }
        if (Request["content1"] != null && Request["content1"] != "")
        {
            strEmailBody = Request["content1"].ToString();
        }

        var notifiation = IoC.Resolve<INotificationRepository>().GetById(NotificationID);

        var objDAL = new FranchisorDAL();
        returnvalue = objDAL.NotificationReServiced(NotificationID, @"App\Franchisor\Admin\ViewNotification.aspx.cs", IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, notifiation.NotificationMedium.Medium, strEmailSubject, strEmailBody, 2);


        JSCode = "Notification save and sent to client successfully. ";

        divMessage.InnerHtml = JSCode;
        divMessage.Visible = true;
        strBody = strEmailBody;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Int64 NotificationID;
        if (ViewState["NotificationID"] != null && ViewState["NotificationID"].ToString() != "")
        {
            NotificationID = Convert.ToInt64(ViewState["NotificationID"]);
            // Update Email body and resend the mail to customer.
            ReServiced(NotificationID);
        }
    }

}
