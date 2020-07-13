using System;
using System.Text;
using System.Web;
using Falcon.DataAccess.Franchisor; 

public partial class App_Common_AsyncEditContactProspect : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        StringBuilder sb=new StringBuilder();
        string strRole = "";

        if (!string.IsNullOrEmpty(Request["ContactID"]))
        {
            int ContactID = Convert.ToInt32(Request["ContactID"]);
            //FranchisorService service = new FranchisorService();
            //EContact objContact = new EContact();
            int tempResult;
            //bool tempResult1;            

            //objContact = service.GetContactByID(ContactID, true, out tempResult, out tempResult1);
            FranchisorDAL objDAL = new FranchisorDAL();
            var objContact = objDAL.GetContactByID(ContactID, 0, out tempResult);
            if (objContact != null)
            {
                sb.Append(HttpUtility.HtmlEncode(objContact.ContactID) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.Title) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.FirstName) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.MiddleName) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.LastName)+ "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.PhoneOffice) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.Phone1Extension) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.PhoneHome) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.PhoneCell) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.EMail) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.EmailWork) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.Gender) + "|");                
                if (!string.IsNullOrEmpty(objContact.DateOfBirth))
                {
                    sb.Append(Convert.ToString(Convert.ToDateTime(objContact.DateOfBirth).ToString("MM/dd/yyyy")) + "|");
                }
                else sb.Append(HttpUtility.HtmlEncode(objContact.DateOfBirth) + "|");

                sb.Append(HttpUtility.HtmlEncode(objContact.DesignationTitle) + "|");
                sb.Append(HttpUtility.HtmlEncode(objContact.Note) + "|");

                if (objContact.ListProspectContactRole != null)
                {
                    //for (int rcount = 0; rcount < objContact.ListProspectContactRole.Length; rcount++)
                    for (int rcount = 0; rcount < objContact.ListProspectContactRole.Count; rcount++)
                    {
                        if (objContact.ListProspectContactRole[rcount].ProspectContactRoleID.ToString().Trim() != "")
                        {
                            strRole = strRole + objContact.ListProspectContactRole[rcount].ProspectContactRoleID.ToString().Trim() + ",";
                        }
                    }
                }
                sb.Append(HttpUtility.HtmlEncode(strRole) + "|");
            }
            divMain.InnerHtml = sb.ToString();
        }
        
    }
}
