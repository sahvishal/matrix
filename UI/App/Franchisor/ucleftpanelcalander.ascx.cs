using System.Data;
using Falcon.App.Lib;

public partial class App_Franchisor_leftpanelcalander : System.Web.UI.UserControl
{
    public void SetLinks(DataTable dtTable)
    {
        //CommonCode.SetLeftNavigation(dtTable, _divQuickLinks);

        var tbltemp = new DataTable();
        tbltemp.Columns.Add("territory");

        tbltemp.Rows.Add(new object[] { ""});

        TerritoryDtl.DataSource = tbltemp;
        TerritoryDtl.DataBind();

        DataTable tbltemp1 = new DataTable();
        tbltemp1.Columns.Add("territory");

        tbltemp1.Rows.Add(new object[] { "" });

        PodDtl.DataSource = tbltemp1;
        PodDtl.DataBind();
    }

}
