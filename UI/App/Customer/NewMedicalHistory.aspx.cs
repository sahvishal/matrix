using System;
using System.Linq;
using System.Web.UI;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Customer
{
    public partial class NewMedicalHistory : Page
    {
        protected long CustomerId { get; set; }
        protected long EventId { get; set; }
        protected bool ReadOnly { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Health Assessment Form";

            if (Request.QueryString["CustomerID"] != null)
            {
                CustomerId = Convert.ToInt64(Request.QueryString["CustomerID"]);
            }

            if (Request.QueryString["EventId"] != null)
            {
                EventId = Convert.ToInt64(Request.QueryString["EventId"]);
            }

            var answers = IoC.Resolve<IHealthAssessmentRepository>().Get(CustomerId, EventId);
            if (answers != null && answers.Any())
            {
                var answer = answers.First();
                var eventRepository = IoC.Resolve<IEventRepository>();
                var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();

                var eventData = eventRepository.GetById(EventId);

                if (answer.DataRecorderMetaData != null && answer.DataRecorderMetaData.DataRecorderCreator != null && answer.DataRecorderMetaData.DataRecorderCreator.Id > 0)
                {
                    var orgRoleUser = organizationRoleUserRepository.GetOrganizationRoleUser(answer.DataRecorderMetaData.DataRecorderCreator.Id);
                    if (answer.DataRecorderMetaData.DateCreated.Date >= eventData.EventDate.Date && orgRoleUser.RoleId != (long) Roles.Customer)
                    {
                        ReadOnly = true;
                        ibtnSave.Visible = false;
                    }
                }
            }
        }
        
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(Request.QueryString["OpenJQueryDialog"]))
                ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "parent.ClosePopUp();", true);
            else
                ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "window.close(); parent.parent.GB_hide();", true);
        }
    }
}