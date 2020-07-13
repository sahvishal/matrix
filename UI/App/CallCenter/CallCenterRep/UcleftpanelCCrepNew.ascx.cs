using System;

public partial class App_CallCenter_CallCenterRep_UcleftpanelCCrepNew : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void SetDetails(string Total, string Average, string maxCall, string minCall)
    {
        spTotal.InnerText = Total;
        spAvg.InnerText = Average;
        spMax.InnerText = maxCall;
        spMin.InnerText = minCall;
    }
    public void SetRecentCalls(string recent1, string recent2)
    {
        spRecent1.InnerText = recent1;
        spRecent2.InnerText = recent2;

    }

}
