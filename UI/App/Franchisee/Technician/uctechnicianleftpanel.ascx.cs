using System;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Enum;
using Falcon.App.UI.Extentions;

public partial class Franchisee_Technician_uctechnicianleftpanel : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSearch.Attributes.Add("onKeyDown", "return keypress_AllowNumericAndAlphanumeric(event);");
        imgSearch.Attributes.Add("onClick", "return ValidateSearch();");
    }
   
    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {        
        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        string strShowAppoinmentCustomer = string.Empty;
        strShowAppoinmentCustomer = "False";
        if (txtSearch.Text.Length > 0)
        {
            if (currentOrgRole.CheckRole((long)Roles.Technician))
            {
                // ** Begin Check Added to get the showcustomer flag
                if (ddlSearch.SelectedItem.Text == "Customer")
                {
                    if (chkShowCustomer.Checked == true)
                    {
                        strShowAppoinmentCustomer = "True";
                    }
                }
                // ** End Check Added to get the showcustomer flag
                txtSearch.Text = txtSearch.Text.Replace("'", "''");
                if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Customer")
                {
                    Int32 tempSearch = 0;
                    if (!Int32.TryParse(txtSearch.Text, out tempSearch))
                    {
                        tempSearch = 0;
                        Response.RedirectUser(ResolveUrl("TechnicianCustomerList.aspx?QuickNavigation=Yes" + "&ShowAll=" + strShowAppoinmentCustomer + "&CustomerName=" + txtSearch.Text));
                    }
                    else
                        Response.RedirectUser(ResolveUrl("TechnicianCustomerDetails.aspx?CustomerID=" + txtSearch.Text));
                }
                else if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Event")
                {
                    Int32 tempsearch = 0;
                    if (!Int32.TryParse(txtSearch.Text, out tempsearch))
                    {
                        tempsearch = 0;
                        Response.RedirectUser(ResolveUrl("SearchEvents.aspx?QuickNavigation=Yes" + "&EventName=" + txtSearch.Text));
                    }
                    else
                    {
                        var eventRepository = IoC.Resolve<IUniqueItemRepository<Event>>();
                        try
                        {
                           var eventDetail= eventRepository.GetById(Convert.ToInt64(txtSearch.Text));
                           Response.RedirectUser(ResolveUrl("EventCustomerList.aspx?QuickNavigation=Yes" + "&EventID=" + eventDetail.Id));
                        }
                        catch
                        {
                            Page.ClientScript.RegisterStartupScript(typeof(string), "jscode_invalideventid", "alert('invalid event id.');", true);
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            Response.RedirectUser(ResolveUrl("TechnicianCustomerList.aspx"));
        }
    }
   
}
