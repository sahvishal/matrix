using System;
using System.Web.UI;

namespace HealthYes.Web.App.Common
{
    public partial class MedicalHistory : System.Web.UI.Page
    {

        protected long CustomerId { get; set; }

        protected long EventId { get; set; }

        protected bool ShowKyn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (Request.QueryString["showkyn"] != null)
            {
                ShowKyn = Convert.ToBoolean(Request.QueryString["showkyn"]);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString["ReturnPage"].ToLower().Equals("entry"))
            {
                if (ShowKyn)
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "parent.opener.setMedicalHistory(); window.close(); parent.opener.reloadPageForKyn();", true);
                else
                    ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "parent.opener.setMedicalHistory(); window.close();", true);
            }
            else if (Request.QueryString["ReturnPage"].ToLower().Equals("ecrl"))
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "window.close();", true);
            }
            else if (Request.QueryString["ReturnPage"].ToLower().Equals("addnotes"))
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "window.close();window.opener.reloadWindow()", true);
            }
            else
                ClientScript.RegisterStartupScript(typeof(string), "jscode_MedHistoryClose", "parent.parent.location.reload(); window.close();", true);
        }
    }
}
