using System;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using Falcon.App.Lib;
using Falcon.App.Core.Application.Impl;
using Falcon.App.UI.Extentions;

namespace Falcon.App.UI.App.Franchisee
{
    public partial class HostRanking : System.Web.UI.Page
    {
        public long HostId
        {
            get
            {
                if (Request.QueryString["HostId"] != null)
                    ViewState["HostId"] = Convert.ToInt64(Request.QueryString["HostId"]);

                if(ViewState["HostId"] == null) ViewState["HostId"] = 0;

                return Convert.ToInt64(ViewState["HostId"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.hideucsearch();
            obj.SetBreadCrumbRoot = "";
            obj.settitle("Host Ranking");

            if (!IsPostBack)
            {
                GetDropDownInfo();
                ViewState["UrlReferrer"] = Request.UrlReferrer.PathAndQuery;
                if (HostId > 0)
                    ClientScript.RegisterStartupScript(typeof(string), "js_LoadHostData", "InitiateLoadHostRankingData(" + HostId + ")", true);
            }
        }

        private void GetDropDownInfo()
        {
            HostRankingDropDown.DataTextField = "Name";
            HostRankingDropDown.DataValueField = "PersistenceLayerId";
            HostRankingDropDown.DataSource = HostViabilityRanking.HostRankings;
            HostRankingDropDown.DataBind();

            HostRankingDropDown.Items.Insert(0, new ListItem("Select Rank", "0"));
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.RedirectUser(ViewState["UrlReferrer"].ToString());
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            IHostFacilityRankingService _hostFacilityRankingService = new HostFacilityRankingService();
            var hostFacilityViability = new HostFacilityViability();

            hostFacilityViability.HostId = HostId;
            hostFacilityViability.Notes = CommentsTextBox.Text;
            hostFacilityViability.Ranking = HostViabilityRanking.HostRankings.Find(ranking => ranking.PersistenceLayerId == Convert.ToInt32(HostRankingDropDown.SelectedItem.Value));
            hostFacilityViability.CreatedOn = DateTime.Now;

            var organizationRoleUser = new OrganizationRoleUserRepository().GetOrganizationRoleUser(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);

            hostFacilityViability.CreatedBy = organizationRoleUser;
            _hostFacilityRankingService.SaveHostFacilityRanking(hostFacilityViability);
            Response.RedirectUser(ViewState["UrlReferrer"].ToString());
        }

    }
}
