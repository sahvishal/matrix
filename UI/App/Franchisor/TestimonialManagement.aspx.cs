using System;
using System.Web.UI;

namespace Falcon.App.UI.App.Franchisor
{
    public partial class TestimonialManagement : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var obj = (Franchisor_FranchisorMaster)this.Master;
            obj.hideucsearch();
            obj.HideLeftContainer=true;
            obj.settitle("Manage Testimonials");
            obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";

            if (!IsPostBack)
            {
                
            }
        }
    }
}
