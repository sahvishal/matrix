using System;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.DataAccess.User;
using Falcon.Entity.Other;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.Public.Account
{
    public partial class ResetPasswordStep3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reset Password Step-3";

            string strUserId = string.Empty;
            string strPassword = string.Empty;
            long userId = 0;

            var randomStringGenerator = new RandomStringGenerator();

            if (Request.QueryString["Action"] != null)
            {
                // Case - Retrieve Password

                if (Request.QueryString["Action"] == "Password")
                {
                    if (Session["Email"] != null)
                    {
                        strPassword = randomStringGenerator.GetRandomString(5);
                        strUserId = Session["Email"].ToString();

                        EUser[] objEUser = null;
                        var userdal = new UserDAL();
                        var listUser = userdal.GetUserPersonalDetails(strUserId);

                        if (listUser != null) objEUser = listUser.ToArray();

                        if (objEUser != null && objEUser.Length > 0) userId = objEUser[0].UserID;


                        if (objEUser != null && objEUser.Length > 0 && objEUser[0].EMail1.Trim() != "")
                        {
                            divHeading.InnerText = "Retrieve Password";
                            div1.InnerText = "Password retrieved successfully.";
                            spnMessage.InnerText = "A link to reset your password has been sent to the email address registered with us. Please check your email and use the link to change the password.";

                            SendParsedMailPassword(userId);
                        }
                        else
                        {
                            //Update auto generated password into DB 
                            var userLoginService = IoC.Resolve<IUserLoginService>();
                            var sessionContext = IoC.Resolve<ISessionContext>();
                            userLoginService.ForceChangePassword(userId, strPassword, true, sessionContext.UserSession.CurrentOrganizationRole.OrganizationRoleUserId, false);

                            // UnLock Account
                            ReleaseUserLoginLock(userId);

                            // If E-mail not found the display password on screen
                            divHeading.InnerText = "Retrieve Password";
                            div1.InnerText = "Password retrieved successfully.";
                            spnMessage.InnerHtml = "Your temporary password is <strong>" + strPassword + "</strong>";
                            //spnBack.Visible = false;
                        }
                        Session["Email"] = "";
                    }
                }
                // Case - Retrieve Username
                else if (Request.QueryString["Action"] == "UserId")
                {
                    divHeading.InnerText = "Retrieve Username";
                    div1.InnerText = "Username retrieved successfully.";
                    spnMessage.InnerText = "An email has been sent to your email address with user detail. Please check your email.";
                    //spnBack.Visible = false;
                }
                // Case - Contact Customer Call Center
                else if (Request.QueryString["Action"] == "SkipHintQuestionForPassword")
                {
                    if (Session["Email"] != null)
                    {
                        strUserId = Session["Email"].ToString();

                        EUser[] objEUser = null;
                        var userdal = new UserDAL();
                        var listUser = userdal.GetUserPersonalDetails(strUserId);

                        if (listUser != null) objEUser = listUser.ToArray();

                        if (objEUser != null && objEUser.Length > 0)
                            userId = objEUser[0].UserID;
                        
                        if (objEUser != null && objEUser.Length > 0 && objEUser[0].EMail1.Trim() != "")
                        {
                            divHeading.InnerText = "Retrieve Password";
                            div1.InnerText = "Password retrieved successfully.";
                            spnMessage.InnerText = "A link to reset your password has been sent to the email address registered with us. Please check your email and use the link to change the password.";
                            
                            SendParsedMailPassword(userId);

                        }
                        else
                        {
                            divHeading.InnerText = "Retrieve Password";
                            div1.InnerHtml = "We are unable to retrieve your password due to incomplete information required for verification.<br><br> Please Call at <span style='color:#00A5E6;' font-weight:bold>" + IoC.Resolve<ISettings>().PhoneTollFree + "</span> for more assistance.";
                            spnMessage.InnerText = "";
                        }
                        Session["Email"] = "";
                    }
                    else
                    {
                        divHeading.InnerText = "Retrieve Password";
                        div1.InnerHtml = "We are unable to retrieve your password due to incomplete information required for verification.<br><br> Please Call at <span style='color:#00A5E6;' font-weight:bold>" + IoC.Resolve<ISettings>().PhoneTollFree + "</span> for more assistance.";
                        spnMessage.InnerHtml = "";
                    }

                }
                else if (Request.QueryString["Action"] == "SkipHintQuestionForUserName")
                {
                    if (Session["Email"] != null)
                    {
                        EUser[] objEUser = null;
                        var userdal = new UserDAL();
                        var listUser = userdal.GetUserPersonalDetails(Session["Email"].ToString());

                        if (listUser != null) objEUser = listUser.ToArray();

                        if (objEUser != null && objEUser.Length > 0 && objEUser[0].EMail1.Trim() != "")
                        {
                            SendParsedMailUserName(objEUser[0].UserID);
                            divHeading.InnerText = "Retrieve Username";
                            div1.InnerText = "Username retrieved successfully.";
                            spnMessage.InnerText = "An email has been sent to your email address with user detail. Please check your email.";

                        }
                        else
                        {
                            divHeading.InnerText = "Retrieve Username";
                            div1.InnerHtml = "We are unable to retrieve your username due to incomplete information required for verification.<br><br> Please Call at <span style='color:#00A5E6;' font-weight:bold>" + IoC.Resolve<ISettings>().PhoneTollFree + "</span> for more assistance.";
                            spnMessage.InnerHtml = "";
                        }
                        Session["Email"] = "";
                    }
                    else
                    {
                        divHeading.InnerText = "Retrieve Username";
                        div1.InnerHtml = "We are unable to retrieve your password due to incomplete information required for verification.<br><br> Please Call at <span style='color:#00A5E6;' font-weight:bold>" + IoC.Resolve<ISettings>().PhoneTollFree + "</span> for more assistance.";
                        spnMessage.InnerHtml = "";
                    }
                }
                // Case - Customer Id
                if (Request.QueryString["Action"] == "CustomerId")
                {
                    if (Session["Email"] != null)
                    {
                        EUser[] objEUser = null;
                        var userdal = new UserDAL();
                        var listUser = userdal.GetUserPersonalDetails(Session["Email"].ToString());

                        if (listUser != null) objEUser = listUser.ToArray();

                        bool mailsent = true;
                        if (objEUser != null && objEUser.Length > 0 && objEUser[0].EMail1.Trim() != "")
                        {
                            mailsent = SendParsedMailUserName(objEUser[0].UserID);
                            divHeading.InnerText = "Retrieve Username";
                            div1.InnerText = "Username retrieved successfully.";
                            spnMessage.InnerText = "An email has been sent to your email address with user detail. Please check your email.";

                        }
                        else
                        {
                            divHeading.InnerText = "Retrive  Username";
                            div1.InnerText = "Username retrived successfully.";
                            spnMessage.InnerHtml = "Your Username is : <strong>" + HttpUtility.HtmlEncode(Session["Email"]) + "</strong>";
                        }
                        if (mailsent)
                        {
                            errordiv.InnerHtml = "";
                            div1.Visible = true;
                            spnMessage.Visible = true;
                        }
                        Session["Email"] = "";
                    }
                }
            }
        }
        private void ReleaseUserLoginLock(long userId)
        {
            if (userId > 0)
            {
                var userLoginRepository = IoC.Resolve<IUserLoginRepository>();
                userLoginRepository.ReleaseUserLoginLock(userId);
            }
        }

        private bool SendParsedMailPassword(long userId)
        {
            var userRepository = IoC.Resolve<IUserRepository<User>>();
            var user = userRepository.GetUser(userId);
            var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();
            var orgRoleUserList = organizationRoleUserRepository.GetOrganizationRoleUserCollectionforaUser(userId);

            var customerRegistrationService = IoC.Resolve<ICustomerRegistrationService>();
            customerRegistrationService.SendResetPasswordMail(userId, user.Name.FullName, orgRoleUserList[0].Id, Request.Url.AbsolutePath);

            return true;
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
