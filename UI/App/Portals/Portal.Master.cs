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

namespace Falcon.App.UI.App.Portals
{
    public partial class Portal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         spcurdate.InnerText = DateTime.Now.ToString("dddd, dd MMMM, yyyy");
        }
    }
}
