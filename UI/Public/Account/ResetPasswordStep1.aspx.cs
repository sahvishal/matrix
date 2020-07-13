using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.User;
using Falcon.Entity.Other;
using System.Text.RegularExpressions;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Public.Account
{
    public partial class ResetPasswordStep1 : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reset Password Step-1";
            //errordiv.InnerHtml = "";
            // Validate Reset password
            btnResetPassword.Attributes.Add("onClick", "return ValidationReset();");
            btnRetriveUserId.Attributes.Add("onClick", "return ValidateEmailCustomerID();");
                
            CheckLockUnlockUser();
        
        }
        
        private bool IsNumeric(string strToTest)
        {
            Regex reNum = new Regex(@"^\d+$");
            return reNum.Match(strToTest).Success;
        }

        protected void btnResetPassword_Click1(object sender, ImageClickEventArgs e)
        {

            if (ViewState["IsLock"] != null)
            {
                if (ViewState["IsLock"].ToString().Equals("false"))
                {

                    UserDAL objUser = new UserDAL();
                    objUser.SaveClient(IpAddress(), "Password");
                    long returnresult = objUser.CheckForLogin(txtUserId.Text.Trim());
                    //errordiv.InnerHtml = "";
                    if (returnresult == -1)
                    {
                        divError.Visible = true;
                        divError.InnerText = "Username does not exists.";
                        txtUserId.Text = "";
                    }
                    else
                    {
                        // Redirect the user to next screen to ask hint question and password
                        Session["Email"] = txtUserId.Text.Trim();
                        Response.RedirectUser("ResetPasswordStep2.aspx?Action=Password");

                    }
                }
            }
        }
        protected void btnRetriveUserId_Click1(object sender, ImageClickEventArgs e)
        {
            // Code to read email address or customer id

            if (ViewState["IsLock"] != null)
            {
                if (ViewState["IsLock"].ToString().Equals("false"))
                {
                    //If user enters the valid email address
                    UserDAL objUser = new UserDAL();

                    string strUserId = string.Empty;
                    objUser.SaveClient(IpAddress(), "UserId");

                    // check for customer id
                    if (IsNumeric(txtEmailOrCustomerId.Text))
                    {
                        // Retrieve userid from DB
                        strUserId = objUser.CheckForLoginByCustomerId(Convert.ToInt64(txtEmailOrCustomerId.Text));

                        if (strUserId == "")
                        {
                            divError.Visible = true;
                            divError.InnerText = "Customer id does not exists.";
                            txtUserId.Text = "";
                        }
                        else
                        {
                            // Redirect the user to next screen to ask hint question and password
                            Session["Email"] = strUserId;
                            Response.RedirectUser("ResetPasswordStep2.aspx?Action=Username");
                        }
                    }
                    else
                    {
                        // check for email address
                        strUserId = objUser.CheckForLoginByEmail(txtEmailOrCustomerId.Text);
                        if (strUserId == "")
                        {
                            divError.Visible = true;
                            divError.InnerText = "E-mail id does not exists.";
                            txtUserId.Text = "";
                        }
                        else
                        {
                            // Retieve UserId and Send the mail 

                            EUser[] objEUser = null;
                            var userdal = new UserDAL();

                            var listUser = userdal.GetUserPersonalDetails(strUserId);
                            if (listUser != null) objEUser = listUser.ToArray();


                            bool mailsent = true;
                            if (objEUser[0].EMail1.Trim() != "")
                            {
                                mailsent = SendParsedMailUserName(objEUser[0].UserID);//SendParsedMail("WelcomeUserName", strUserId, "");
                            }
                            else
                            {
                                divError.InnerHtml = "Your UserId is <strong>" + HttpUtility.HtmlEncode(strUserId) + "</strong>";
                            }
                            if (mailsent == true)
                            {
                                Response.RedirectUser("./ResetPasswordStep3.aspx?Action=UserId");
                            }
                            else
                            {
                                divError.Visible = true;
                                divError.InnerHtml = "Error in retrieving Username. Please contact " + HttpUtility.HtmlEncode(IoC.Resolve<ISettings>().SupportEmail)  + " for help.";

                            }
                        }
                    }
                }
            }
        }
        private string IpAddress()
        {
            string strIpAddress = string.Empty;
            if (Request.UserHostAddress != null)
            {
                strIpAddress = Request.UserHostAddress.ToString();
            }
            else
            {
                strIpAddress = Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return strIpAddress;
        }

        private void CheckLockUnlockUser()
        {
            DataSet dsIpDetails = new DataSet();
            UserDAL objUser = new UserDAL();
            dsIpDetails = objUser.GetClient(IpAddress());
            if (dsIpDetails != null)
            {
                if (dsIpDetails.Tables.Count > 0)
                {
                    if (dsIpDetails.Tables[0].Rows.Count > 0)
                    {
                        DateTime lastLogged = Convert.ToDateTime(dsIpDetails.Tables[0].Rows[0]["UpdatedOn"]);
                        int Attempt = Convert.ToInt16(dsIpDetails.Tables[0].Rows[0]["Attempts"]);
                        if (lastLogged.AddMinutes(30) >= DateTime.Now && Attempt >= 10)
                        {
                            // Code To Display
                            divError.Visible = true;
                            divError.InnerText = "Due to excessive attempts your IP has been blocked. Please try again later after 30 minutes.";
                            ViewState["IsLock"] = "true";
                            btnResetPassword.Enabled = false;
                            btnRetriveUserId.Enabled = false;
                            txtUserId.Enabled = false;
                            txtEmailOrCustomerId.Enabled = false;

                        }
                        else if (lastLogged.AddMinutes(30) <= DateTime.Now && Attempt >= 10)
                        {
                            // Code Reset the attempt.
                            objUser.DeleteClient(IpAddress());
                            ViewState["IsLock"] = "false";
                            btnResetPassword.Visible = true;
                            btnRetriveUserId.Visible = true;
                            txtUserId.Enabled = true;
                            txtEmailOrCustomerId.Enabled = true;
                        }
                        else
                        {
                            ViewState["IsLock"] = "false";

                        }
                    }
                    else
                    {
                        ViewState["IsLock"] = "false";
                    }
                }
            }
            else
            {
                ViewState["IsLock"] = "false";
            }
        }

        private bool SendParsedMailUserName(long userId)
        {
            var notifier = IoC.Resolve<INotifier>();
            var emailNotificationModelsFactory = IoC.Resolve<IEmailNotificationModelsFactory>();
            var userRepository = IoC.Resolve<IUserRepository<User>>();
            var user = userRepository.GetUser(userId);
            var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            var orgRoleUserList = organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(userId);

            var loginIssueSendUserName = emailNotificationModelsFactory.GetWelcomeWithUserNameNotificationModel(user.UserLogin.UserName, user.Name.FullName, user.DataRecorderMetaData.DateCreated);
            notifier.NotifySubscribersViaEmail(NotificationTypeAlias.LoginIssuesSendUsername, EmailTemplateAlias.LoginIssuesSendUsername, loginIssueSendUserName, user.Id, orgRoleUserList[0].Id, Request.Url.AbsolutePath);
            return true;
        }
     
    }
}
