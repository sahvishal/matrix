using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Falcon.App.Core.Application.Impl;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.User;

namespace Falcon.App.UI.Public.Account
{
    public partial class ResetPasswordStep2 : Page
    {
        DataTable dtQues;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reset Password Step-2";
        
            if (!IsPostBack)
            {
                if (Request.QueryString["Action"] != null)
                {
                    if (Request.QueryString["Action"] == "Password")
                    {
                        divHeading.InnerText = "Retrieve Password";
                    }
                    else if (Request.QueryString["Action"] == "Username")
                    {
                        divHeading.InnerText = "Retrieve Username";
                    }
                }
                SelectSequrityQuestion();
            }
            CheckLockUnlockUser();
        }
        private void SelectSequrityQuestion()
        {
            var queryString = "HintQuestion";

            if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"] == "Password")
                {
                    queryString = "SkipHintQuestionForPassword";
                    divHeading.InnerText = "Retrieve Password";
                }
                else if (Request.QueryString["Action"] == "Username")
                {
                    queryString = "SkipHintQuestionForUserName";
                    divHeading.InnerText = "Retrieve Username";
                }
            }

            var objDal = new UserDAL();
            dtQues = new DataTable();
            if (Session["Email"] != null)
            {
                dtQues = ((DataSet)objDal.ChooseSecurityQuestion(Session["Email"].ToString())).Tables[0];            
                if (dtQues.Rows.Count > 0)
                {
                    string ques = dtQues.Rows[0]["Question"].ToString();
                    if (ques != "" && dtQues.Rows[0]["Answer"].ToString() != "")
                    {
                        ViewState["Ques"] = dtQues;
                        ques = HttpUtility.HtmlEncode(ques);
                        divQues.InnerHtml = ques.IndexOf("?") > 0 ? ques : ques + "?";
                    }
                    else
                        Response.RedirectUser("./ResetPasswordStep3.aspx?Action=" + queryString);
                }
                else
                {
                    Response.RedirectUser("./ResetPasswordStep3.aspx?Action=" + queryString);
                }
            }        
        }
   
        protected void ibtnContinue_Click(object sender, ImageClickEventArgs e)
        {


            if (ViewState["IsLock"] != null)
            {
                if (ViewState["IsLock"].ToString().Equals("false"))
                {
                    if (dtQues == null)
                        dtQues = (DataTable)ViewState["Ques"];

                    CryptographyService cryptographyService = new PasswordCryptographyService();
                    string answer = cryptographyService.Decrypt(dtQues.Rows[0]["Answer"].ToString());
                    
                    var objUser = new UserDAL();
                    objUser.SaveClient(IpAddress(), "UserId");

                    if (!answer.ToLower().Equals(txtAnswer.Text.ToLower()))
                    {
                        divError.Visible = true;
                        divError.InnerText = "Answer of Security question is not correct.";

                    }
                    else
                    {
                        if (Request.QueryString["Action"] != null)
                        {
                            if (Request.QueryString["Action"] == "Password")
                            {
                                Response.RedirectUser("./ResetPasswordStep3.aspx?Action=Password");
                            }
                            else if (Request.QueryString["Action"] == "Username")
                            {
                                Response.RedirectUser("./ResetPasswordStep3.aspx?Action=CustomerId");
                            }

                        }

                    }
                }
            }
        }

        private string IpAddress()
        {
            string strIpAddress = Request.UserHostAddress ?? Request.ServerVariables["REMOTE_ADDR"];
            return strIpAddress;
        }

        private void CheckLockUnlockUser()
        {
            var objUser = new UserDAL();
            var dsIpDetails = objUser.GetClient(IpAddress());
            if (dsIpDetails != null)
            {
                if (dsIpDetails.Tables.Count > 0)
                {
                    if (dsIpDetails.Tables[0].Rows.Count > 0)
                    {
                        DateTime lastLogged = Convert.ToDateTime(dsIpDetails.Tables[0].Rows[0]["UpdatedOn"]);
                        int attempt = Convert.ToInt16(dsIpDetails.Tables[0].Rows[0]["Attempts"]);
                        if (lastLogged.AddMinutes(30) >= DateTime.Now && attempt >= 10)
                        {
                            // Code To Display
                            divError.Visible = true;
                            divError.InnerText = "Due to excessive attempts your IP has been blocked. Please try again later after 30 minutes.";
                            ViewState["IsLock"] = "true";
                            ibtnContinue.Enabled = false;
                            txtAnswer.Enabled = false;

                        }
                        else if (lastLogged.AddMinutes(30) <= DateTime.Now && attempt >= 10)
                        {
                            // Code Reset the attempt.
                            objUser.DeleteClient(IpAddress());
                            ViewState["IsLock"] = "false";
                            ibtnContinue.Enabled = false;
                            txtAnswer.Enabled = false;
                        }
                        else
                        {
                            ViewState["IsLock"] = "false";

                        }
                    }
                }
            }
            else
                ViewState["IsLock"] = "false";
        }
    }
}



