using System;
using System.Web;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MarketingPartner;
using Falcon.App.Lib;
using Falcon.App.Infrastructure.Repositories.Users;

public partial class App_UCCommon_UCCustomerLeftInfo : System.Web.UI.UserControl
{

    private string _custNameString = string.Empty;

    public string CustName
    {
        get { return _custNameString; }
        set { _custNameString = value; }
    }

    public bool IsExpressAdvocate
    {
        get
        {
            var marketingPartnerDal = new MarketingPartnerDAL();
            return marketingPartnerDal.CheckExpressAdvocate((int)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        }
    }
    public Boolean AdvocateView
    {

        set
        {
            if (value)
            {
                dvChangeAdvocateType.Style["display"] = "block";

                var marketingPartnerDal = new MarketingPartnerDAL();
                if (marketingPartnerDal.CheckExpressAdvocate((int)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId))
                {
                    AdvocateLink.Style["display"] = "none";
                    divAdvanceAdvocate.Style["display"] = "block";
                    dvToAdvanced.Style["display"] = "block";
                }
                else
                {
                    AdvocateLink.Style["display"] = "block";
                    divAdvanceAdvocate.Style["display"] = "none";
                    dvToExpress.Style["display"] = "block";
                }

                dvCustInfo.Style["display"] = "none";

                
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        SetCustomerDetails((int)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        var marketingPartnerDal = new MarketingPartnerDAL();
        //TODO:It will nork since Affiliate is not working
        //SetMonetizedView(marketingPartnerDal.CheckMonetizedAdvocate((int)IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId));
    }


    /// <summary>
    /// Set the customer detail
    /// </summary>
    /// <param name="customerid"></param>
    private void SetCustomerDetails(int customerid)
    {
        ICustomerRepository customerRepository = new CustomerRepository();
        var objCustomer = customerRepository.GetCustomer(customerid);

        if (objCustomer != null)
        {
            var objCCode = new CommonCode();
            //objCCode.GetPicture(objCustomer.)
            
            string userid = objCustomer.Id.ToString();
            string username = objCustomer.NameAsString;

            spCustomerName.InnerHtml = HttpUtility.HtmlEncode(username);

            ViewState["FirstName"] = objCustomer.Name.FirstName;
            ViewState["MiddleName"] = objCustomer.Name.MiddleName;
            ViewState["LastName"] = objCustomer.Name.LastName;

            Session["UserName"] = username;
            Session["UserID"] = userid;
            Session["UserMail"] = objCustomer.Email.ToString();

            spAddress.InnerText = objCustomer.Address.ToString();

            var changePasswordUrl = "/App/Common/ChangePassword.aspx?UserID=" + userid + "&UserEmail=" + objCustomer.Email;
            achangepassword.HRef = "javascript:popupmenu('" + changePasswordUrl + "','390','200');";
            achangepassword.Attributes.Add("onclick", "return confirm('Are you sure you want to reset password?');");
            //achangepassword.Attributes.Add("Rel", "gb_page_center[392, 200]");

            CustName = username;

        }

    }

    private void SetMonetizedView(bool isMonetized)
    {
        divPaymentHistory.Style["display"] = isMonetized  ? "block" : "none";
    }

}
