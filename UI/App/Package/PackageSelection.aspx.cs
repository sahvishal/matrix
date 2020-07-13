using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Enum;

namespace Falcon.App.UI.App.Package
{
    public partial class PackageSelection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ItemCartControl.EventId = 1896;
            ItemCartControl.RoleId = (long) Roles.CallCenterRep;
        }
    }
}
