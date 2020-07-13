using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Falcon.DataAccess.Master;

namespace Falcon.App.UI.App.Common.CreateEventWizard
{
    public partial class AsyncContactAddress : System.Web.UI.Page
    {
        string XmlDeclartion = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";

        long _affiliateID, _eventId, _userId;
        string _city=string.Empty;
        string _state=string.Empty;
        long _zipcode;
        string _address1=string.Empty;
        string _address2=string.Empty;
        string _firstName=string.Empty;
        string _middleName=string.Empty;
        string _lastName=string.Empty;
        //bool _isPrimaryContact=false;
        //bool _isAddress=false;
        //bool _isContact=false;
        int _returnValue = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Type"] != null)
                {
                    // affiliateId
                    if (Request.QueryString["AffiliateID"] != null)
                    {
                        _affiliateID = Convert.ToInt64(Request.QueryString["AffiliateID"]);
                    }
                    // eventID
                    if (Request.QueryString["EventId"] != null)
                    {
                        _eventId = Convert.ToInt64(Request.QueryString["EventId"]);
                    }
                    // userId
                    if (Request.QueryString["UserId"] != null)
                    {
                        _userId = Convert.ToInt64(Request.QueryString["UserId"]);
                    }
                    // Address1
                    if (Request.QueryString["Address1"] != null)
                    {
                        _address1 = Convert.ToString(Request.QueryString["Address1"]);
                    }
                    // Address2
                    if (Request.QueryString["Address2"] != null)
                    {
                        _address2 = Convert.ToString(Request.QueryString["Address2"]);
                    }
                    // city
                    if (Request.QueryString["city"] != null)
                    {
                        _city= Convert.ToString(Request.QueryString["city"]);
                    }
                    // state
                    if (Request.QueryString["state"] != null)
                    {
                        _state = Convert.ToString(Request.QueryString["state"]);
                    }
                    // zipcode
                    if (Request.QueryString["zip"] != null)
                    {
                        _zipcode = Convert.ToInt64(Request.QueryString["zip"]);
                    }
                    //// isPrimaryContact
                    //if (Request.QueryString["isPrimaryContact"] != null)
                    //{
                    //    if (Request.QueryString["isPrimaryContact"] == "true")
                    //        _isPrimaryContact = true;
                    //}
                    //// isAddress
                    //if (Request.QueryString["isAddress"] != null)
                    //{
                    //    if (Request.QueryString["isAddress"] == "true")
                    //        _isAddress= true;
                    //}
                    //// isContact
                    //if (Request.QueryString["isContact"] != null)
                    //{
                    //    if (Request.QueryString["isContact"] == "true")
                    //        _isContact = true;
                    //}
                    // firstName
                    if (Request.QueryString["firstName"] != null)
                    {
                        _firstName = Convert.ToString(Request.QueryString["firstName"]);
                    }
                    // middleName
                    if (Request.QueryString["middleName"] != null)
                    {
                        _middleName = Convert.ToString(Request.QueryString["middleName"]);
                    }
                    // lastName
                    if (Request.QueryString["lastName"] != null)
                    {
                        _lastName = Convert.ToString(Request.QueryString["lastName"]);
                    }
                    var objMasterDal = new MasterDAL();
                    _returnValue= objMasterDal.SavePrintOrderDetails(_affiliateID, _eventId, _address1, _address2, _city, _state,_zipcode,_firstName, _middleName, _lastName, _userId);

                    if (_returnValue == -1)
                    {
                        XmlDeclartion = XmlDeclartion + "<result>Error</result>";
                    }
                    else
                    {
                        XmlDeclartion = XmlDeclartion + "<result>Sucess</result>";
                    }
                    Response.Write(XmlDeclartion);
                }
            }
            catch
            {
                Response.End();
            }
            finally
            {
                Response.End();
            }

        }
    }
}
