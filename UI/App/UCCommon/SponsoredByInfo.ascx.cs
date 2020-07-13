using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.UCCommon
{
    public partial class SponsoredByInfo : UserControl
    {
        private long EventId
        {
            get
            {
                long eventId;
                if(Request.QueryString["EventId"]!=null)
                {
                    if (Int64.TryParse(Request.QueryString["EventId"], out eventId))
                        return eventId;
                }
                else if (Session["EventID"] != null && !string.IsNullOrEmpty(Session["EventID"].ToString()))
                {
                    if (Int64.TryParse(Session["EventID"].ToString(), out eventId))
                        return eventId;
                }
                return 0;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(EventId>0)
            {
                var hospitalPartnerRepository = IoC.Resolve<IHospitalPartnerRepository>();
                var hospitalPartnerId = hospitalPartnerRepository.GetHospitalPartnerIdForEvent(EventId);
                if (hospitalPartnerId > 0)
                {
                    var organizationRepository = IoC.Resolve<IOrganizationRepository>();
                    var hospitalPartner = organizationRepository.GetOrganizationbyId(hospitalPartnerId);
                    SponsoredByDiv.InnerText = "Sponsored By - " + hospitalPartner.Name;
                    SponsoredByDiv.Style.Add(HtmlTextWriterStyle.Display,"block");
                }
            }
        }
    }
}