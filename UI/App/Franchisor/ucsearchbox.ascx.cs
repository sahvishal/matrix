using System;

public partial class ucsearchbox : System.Web.UI.UserControl
{
    //public String SearchType
    //{
    //    get { return spsearchtype.InnerText; }
    //    set { spsearchtype.InnerText = value; }
    //}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //aclickgo.Attributes["onClick"] = "";
    }

    public void setuctitle(string title)
    {
        spsearchtype.InnerHtml = title;
    }

}
