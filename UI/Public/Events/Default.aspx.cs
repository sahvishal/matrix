using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.Public.Events
{
    public partial class EventDefault : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Search Events";

            if (!IsPostBack)
            {
                divSearchResult.Visible = false;
                divSearchResult.Style.Add(HtmlTextWriterStyle.Display, "none");
                divSearchResult.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

                Page.Title = "Search Events";

                ViewState["SortExp"] = "Distance";
                ViewState["SortDir"] = SortDirection.Ascending;

                if (Request.QueryString["z"] != null && Request.QueryString["m"] != null)
                {

                    long corporateId = 0;
                    if (Request.QueryString["cor"] != null && long.TryParse(Request.QueryString["cor"], out corporateId) == true)
                    {
                        var corpRepository = IoC.Resolve<IUniqueItemRepository<CorporateAccount>>();
                        string url = "";
                        try
                        {
                            var corp = corpRepository.GetById(corporateId);
                            if (corp == null || string.IsNullOrEmpty(corp.AccountCode))
                            {
                               url = string.Format("/Scheduling/Online/LocationAndAppointmentSlot?ZipCode={0}&Radius={1}", Request.QueryString["z"], Request.QueryString["m"]);
                            }

                            if (corp != null)
                                url = string.Format("/Scheduling/Online/LocationAndAppointmentSlot?ZipCode={0}&Radius={1}&CorpCode=" + corp.AccountCode, Request.QueryString["z"], Request.QueryString["m"]);
                        }
                        catch (Exception ex)
                        {
                            IoC.Resolve<ILogManager>().GetLogger<Global>().Error(ex.Message);
                            url = string.Format("/Scheduling/Online/LocationAndAppointmentSlot?ZipCode={0}&Radius={1}", Request.QueryString["z"], Request.QueryString["m"]);
                        }

                        Response.RedirectUser(url);
                    }
                    else
                    {
                        Response.RedirectUser(string.Format("/Scheduling/Online/LocationAndAppointmentSlot?ZipCode={0}&Radius={1}", Request.QueryString["z"], Request.QueryString["m"]));
                    }
                }
                if (Request.QueryString["MMZip"] != null)
                {
                    Response.RedirectUser(string.Format("/Scheduling/Online/LocationAndAppointmentSlot?ZipCode={0}", Request.QueryString["MMZip"]));
                }
                if (Request.QueryString["ic"] != null && Request.QueryString["z"] != null)
                {
                    Response.RedirectUser(string.Format("/Scheduling/Online/LocationAndAppointmentSlot?InvitationCode={0}", Request.QueryString["ic"]));
                }
                else if (Request.QueryString["ic"] != null)
                {
                    Response.RedirectUser(string.Format("/Scheduling/Online/LocationAndAppointmentSlot?InvitationCode={0}", Request.QueryString["ic"]));
                }

                Response.RedirectUser(string.Format("/Scheduling/Online/LocationAndAppointmentSlot"));
            }
        }

    }
}