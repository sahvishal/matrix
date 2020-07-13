using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

public partial class App_Franchisor_Admin_testimonials : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TODO: Not sure whether it is in use or not.
        CheckBox1.Text = "I Agree by giving" + IoC.Resolve<ISettings>().CompanyName + "the right to use testimonials";
    }
}
