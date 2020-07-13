using System;
using System.Data;

namespace Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer
{
    public partial class BetterValuePackagesOffered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable tbltemp = new DataTable();
            tbltemp.Columns.Add("radio");
            tbltemp.Columns.Add("package");

            tbltemp.Rows.Add(new object[] { "", "" });
            tbltemp.Rows.Add(new object[] { "", "" });
            tbltemp.Rows.Add(new object[] { "", "" });
            tbltemp.Rows.Add(new object[] { "", "" });
            tbltemp.Rows.Add(new object[] { "", "" });
            tbltemp.Rows.Add(new object[] { "", "" });


            grdbettrpackages.DataSource = tbltemp;
            grdbettrpackages.DataBind();
        }
    }
}
