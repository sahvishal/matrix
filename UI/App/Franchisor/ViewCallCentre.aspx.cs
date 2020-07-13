using System;
using System.Data;
using System.Collections;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Services;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.CallCenter;
using Falcon.Entity.CallCenter;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;



public partial class CallCenter_ViewCallCentre : Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "View Call Center";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Call Center");
        obj.SetBreadCrumbRoot = "<a href='#'>Vendors</a>";
        
        if (!IsPostBack)
        {
            
            if (Request.QueryString["searchtext"] != null)
                SearchCallCenter(Request.QueryString["searchtext"].ToString());
            else
                this.GetCallCenterData();

            if (Request.QueryString["Action"] != null && Request.QueryString["Action"].ToString() == "Added")
            {
                errordiv.Visible = true;
                errordiv.InnerText = "Record(s) added sucessfully.";
            }
            else if (Request.QueryString["Action"] != null && Request.QueryString["Action"].ToString() == "Updated")
            {
                errordiv.Visible = true;
                errordiv.InnerText = "Record(s) updated sucessfully.";
            }
        }

    }

    
    protected void grdCallCentre_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "checkallboxes()";
            }
        }
    }

   
    
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int callcenterid = 0;
        for (int i = 0; i < grdCallCentre.Rows.Count; i++)
        {
            var chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)grdCallCentre.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked)
            {
                callcenterid =  Convert.ToInt32(grdCallCentre.DataKeys[i].Value);
                break;
            }
        }
        if (callcenterid > 0)
        {
            Response.RedirectUser("AddCallCentre.aspx?CallCenterID=" + callcenterid.ToString());
        }
    }

    
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        var isDeleted = true;
        string employeeNotDeleted = string.Empty;
        var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();

        for (int i = 0; i < grdCallCentre.Rows.Count; i++)
        {
            var chkRowTemp = (HtmlInputCheckBox)grdCallCentre.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked)
            {
                isDeleted = organizationRoleUserRepository.DeactivateAllOrganizationRoleUserForOrganization(Convert.ToInt64(grdCallCentre.DataKeys[i].Value));
                if (!isDeleted)
                {
                    employeeNotDeleted = grdCallCentre.DataKeys[i].Value + ", ";
                }
                else
                {
                    var organizationRepository = IoC.Resolve<IOrganizationRepository>();
                    organizationRepository.Deactivate(Convert.ToInt64(grdCallCentre.DataKeys[i].Value));
                }
            }
        }

        GetCallCenterData();

        errordiv.Visible = true;
        errordiv.InnerHtml = !string.IsNullOrWhiteSpace(employeeNotDeleted) ? string.Format("Call Center Vendors with Ids {0} could not be deleted!.", employeeNotDeleted) : string.Format("Deleted successful for the selected records!.");
    }

   
    protected void addNewCallCenter_Click(object sender, EventArgs e)
    {
        Response.RedirectUser("AddCallCentre.aspx");
    }

   
    private void GetCallCenterData()
    {
        var service = IoC.Resolve<IOrganizationService>(); 
        var model = service.GetOrganizationListModel(OrganizationType.CallCenter);

        if (model != null && model.Organizations != null && model.Organizations.Count() > 0)
        {
            grdCallCentre.DataSource = model.Organizations;
            grdCallCentre.DataBind();
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
    }

    
    private void SearchCallCenter(string searchtext)
    {
        var service = IoC.Resolve<IOrganizationService>();
        var model = service.GetOrganizationListModel(OrganizationType.CallCenter, searchtext);

        if (model != null && model.Organizations != null && model.Organizations.Count() > 0)
        {
            grdCallCentre.DataSource = model.Organizations;
            grdCallCentre.DataBind();
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
    }



}
