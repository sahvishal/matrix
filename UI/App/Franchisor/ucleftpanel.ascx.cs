using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.Core.Enum;
using Falcon.App.UI.Extentions;

public partial class App_Franchisor_ucleftpanel : UserControl
{
    private bool reDirect = true;
    public bool Redirect
    {
        set { reDirect = value; }
        get { return reDirect; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSearch.Attributes.Add("onKeyDown", "return keypress_AllowNumericAndAlphanumeric(event);");
        imgSearch.Attributes.Add("onClick", "return ValidateSearch();");
        if (!IsPostBack)
        {
            BindDropDown();
        }

        var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        if (orgUser.CheckRole((long)Roles.SalesRep))
        {
            ListItem obj = ddlSearch.Items.FindByValue("Customer");
            if (obj != null)
            {
                ddlSearch.Items.Remove(obj);
                divShowCustomer.Style.Add(HtmlTextWriterStyle.Display,"none");               
            }
        }
        else if (orgUser.CheckRole((long)Roles.FranchisorAdmin) || orgUser.CheckRole((long)Roles.FranchiseeAdmin))
        {
            ListItem obj = ddlSearch.Items.FindByValue("Prospect");
            if (obj != null)
            {
                ddlSearch.Items.Remove(obj);
            }
            obj = new ListItem();
            obj = ddlSearch.Items.FindByValue("Host");
            if (obj != null)
            {
                ddlSearch.Items.Remove(obj);
            }
        }
        if (hidDropDownValue.Value != null && hidDropDownValue.Value != "")
        {
            ListItem obj = ddlSearch.Items.FindByValue(hidDropDownValue.Value);
            if (obj != null)
            {
                ddlSearch.SelectedIndex = -1;
                ddlSearch.Items.FindByValue(hidDropDownValue.Value).Selected = true;
            }
        }
    }

    private void BindDropDown()
    {
        ListItem li = new ListItem();
        li.Text="Prospect";li.Value="Prospect";
        ddlSearch.Items.Add(li);

        li = new ListItem();
        li.Text="Host";li.Value="Host";
        ddlSearch.Items.Add(li);

        li = new ListItem();
        li.Text="Customer";li.Value="Customer";
        ddlSearch.Items.Add(li);

        li = new ListItem();
        li.Text="Event";li.Value="Event";
        ddlSearch.Items.Add(li);
    }

    public void SetLinks(DataTable dtTable)
    {
        //if (dtTable.Rows.Count > 10)
        //    divContainer.Style.Add(HtmlTextWriterStyle.Height, "1100px");
        //else
        //    divContainer.Style.Add(HtmlTextWriterStyle.Height, "800px");
        CommonCode.SetLeftNavigation(dtTable, _divQuickLinks);
    }

    public void SetRecent(DataTable dtTable)
    {
        CommonCode.SetLeftNavigation(dtTable, _divRecentlyVisitedLinks);
    }

    protected void imgSearch_Click(object sender, ImageClickEventArgs e)
    {
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        
        string strShowAppoinmentCustomer = string.Empty;
        strShowAppoinmentCustomer = "False";
        
        if (ddlSearch.SelectedIndex > -1)
        {
            hidDropDownValue.Value = ddlSearch.SelectedItem.Text;
        }
        if (Redirect)
        {
            if (txtSearch.Text.Length > 0)
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

                if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                {
                    ddlSearch.Items.FindByValue("Event").Enabled = true;
                    txtSearch.Text = txtSearch.Text.Replace("'", "''");
                    //check for prospect
                    if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Prospect")
                    {
                        Int32 tempsearch = 0;
                        if (!Int32.TryParse(txtSearch.Text, out tempsearch))
                        {
                            Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepManageProspects.aspx?prospectname=" + txtSearch.Text + "&QuickSearch=True");
                        }
                        else
                        {
                            Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Prospect&ProspectID=" + txtSearch.Text);
                        }
                    }
                    // check for host
                    else if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Host")
                    {
                        Int32 tempsearch = 0;
                        if (!Int32.TryParse(txtSearch.Text, out tempsearch))
                        {
                            Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepManageHost.aspx?hostname=" + txtSearch.Text + "&QuickSearch=True");
                        }
                        else
                        {
                            Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepProspectDetails.aspx?Type=Host&ProspectID=" + txtSearch.Text);
                        }
                    }
                    // check for event
                    else if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Event")
                    {
                        Int32 tempsearch = 0;
                        if (!Int32.TryParse(txtSearch.Text, out tempsearch))
                        {
                            Response.RedirectUser("~/Scheduling/Event/Index?Name=" + txtSearch.Text);
                            //Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepViewEvent.aspx?QuickNavigation=Yes" + "&EventName=" + txtSearch.Text);
                        }
                        else
                        {
                            //Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepViewEvent.aspx?QuickNavigation=Yes" + "&EventID=" + txtSearch.Text);
                            Response.RedirectUser("~/App/Common/EventDetails.aspx?QuickNavigation=Yes" + "&EventID=" + txtSearch.Text);
                        }
                    }

                }
                else if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    txtSearch.Text = txtSearch.Text.Replace("'", "''");
                    if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Customer")
                    {
                        Int32 tempSearch = 0;                        
                        if (!Int32.TryParse(txtSearch.Text, out tempSearch))
                        {
                            Response.RedirectUser("FranchiseeCustomerList.aspx?QuickNavigation=Yes" + "&ShowAll=" + strShowAppoinmentCustomer + "&CustomerName=" + txtSearch.Text + "%");
                        }
                        else
                            Response.RedirectUser("FranchiseeCustomerDetails.aspx?CustomerID=" + txtSearch.Text);
                    }
                    else if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Event")
                    {
                        Int32 tempsearch = 0;
                        if (!Int32.TryParse(txtSearch.Text, out tempsearch))
                        {
                            Response.RedirectUser("~/Scheduling/Event/Index?Name=" + txtSearch.Text);
                           // Response.RedirectUser("FranchiseeViewEvent.aspx?QuickNavigation=Yes" + "&EventName=" + txtSearch.Text);
                        }
                        else
                        {
                            //Response.RedirectUser("FranchiseeViewEvent.aspx?QuickNavigation=Yes" + "&EventID=" + txtSearch.Text);
                            Response.RedirectUser("~/App/Common/EventDetails.aspx?QuickNavigation=Yes" + "&EventID=" + txtSearch.Text);
                        }
                    }

                }
                else if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    txtSearch.Text = txtSearch.Text.Replace("'", "''");
                    if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Customer")
                    {
                        Int32 tempSearch = 0;
                        if (!Int32.TryParse(txtSearch.Text, out tempSearch))
                        {
                            Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCustomerList.aspx?QuickNavigation=Yes" + "&ShowAll=" + strShowAppoinmentCustomer + "&CustomerName=" + txtSearch.Text + "%"));
                            //Response.RedirectUser("FranchisorCustomerList.aspx?QuickNavigation=Yes" + "&CustomerName=" + txtSearch.Text + "%");
                        }
                        else
                        {
                            Response.RedirectUser(ResolveUrl("/App/Franchisor/FranchisorCustomerDetails.aspx?CustomerID=" + txtSearch.Text));
                         //   Response.RedirectUser("FranchisorCustomerDetails.aspx?CustomerID=" + txtSearch.Text);
                        }
                    }
                    else if (txtSearch.Text.Length > 0 && ddlSearch.SelectedItem.Text == "Event")
                    {
                        Int32 tempsearch = 0;
                        if (!Int32.TryParse(txtSearch.Text, out tempsearch))
                        {
                            Response.RedirectUser("~/Scheduling/Event/Index?Name=" + txtSearch.Text);
                            //Response.RedirectUser(this.ResolveUrl("/App/Franchisor/FranchisorViewEvent.aspx?QuickNavigation=Yes" + "&EventName=" + txtSearch.Text));
                        }
                        else
                        {
                            //Response.RedirectUser(this.ResolveUrl("/App/Franchisor/FranchisorViewEvent.aspx?QuickNavigation=Yes" + "&EventID=" + txtSearch.Text));
                            Response.RedirectUser("~/App/Common/EventDetails.aspx?QuickNavigation=Yes" + "&EventID=" + txtSearch.Text);
                        }
                    }
                }

            }
            else
            {
                if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
                {
                    Response.RedirectUser("~/Scheduling/Event/Index?showUpcoming=true");
                    //Response.RedirectUser("~/App/Franchisee/SalesRep/SalesRepViewEvent.aspx");
                }
                else if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchisorAdmin))
                {
                    Response.RedirectUser("FranchisorCustomerList.aspx");
                }
                else if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin))
                {
                    Response.RedirectUser("FranchiseeCustomerList.aspx");
                }
            }
            
        }
            
        
    }

}
