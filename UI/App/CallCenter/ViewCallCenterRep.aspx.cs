using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.UI.Extentions;
using Roles = Falcon.App.Core.Enum.Roles;
using Falcon.App.Core.Extensions;

public partial class CallCenter_ViewCallCenterRep : System.Web.UI.Page
{
    #region "Form Events"
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Call Center Rep";
        manager.RegisterPostBackControl(btnDelete);
        CallCenter_CallCenterMaster obj;
        obj = (CallCenter_CallCenterMaster)this.Master;
        obj.settitle("Call Center Rep");
        obj.SetBreadCrumbRoot = "<a href='CallCenterManagerDashboard.aspx'> Dashboard </a>";
        obj.showsearch();
        if (IsPostBack) return;

        if (Request.QueryString["searchtext"] != null)
            SearchCallCenterUserList(Request.QueryString["searchtext"].ToString());
        else
            GetCallCenterUserList();

        if (Request.QueryString["Action"] != null && Request.QueryString["Action"].ToString() == "Added")
        {
            errordiv.InnerText = "Record(s) added successfully";
            errordiv.Visible = true;
        }
        else if (Request.QueryString["Action"] != null && Request.QueryString["Action"].ToString() == "Edited")
        {
            errordiv.InnerText = "Record(s) updated successfully";
            errordiv.Visible = true;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int callcentercallcenteruserid = 0;
        for (int i = 0; i < gridviewccrep.Rows.Count; i++)
        {
            HtmlInputCheckBox chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)gridviewccrep.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked == true)
            {
                callcentercallcenteruserid = Convert.ToInt32(gridviewccrep.Rows[i].Cells[5].Text);
                break;
            }
        }
        if (callcentercallcenteruserid > 0)
        {
            Response.RedirectUser("AddCallCenterRep.aspx?EmployeeID=" + callcentercallcenteruserid.ToString());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();

        for (int i = 0; i < gridviewccrep.Rows.Count; i++)
        {
            var chkRowTemp = (HtmlInputCheckBox)gridviewccrep.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked)
            {
                organizationRoleUserRepository.DeactivateOrganizationRoleUser(
                    Convert.ToInt32(gridviewccrep.Rows[i].Cells[5].Text));
            }
        }

        GetCallCenterUserList();

        errordiv.Visible = true;
        //Refactor this
        errordiv.InnerText = "Users Deleted!";

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridviewccrep_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "GridMasterCheck()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "GridChildCheck();";
            }
        }
    }


    #endregion

    private void GetCallCenterUserList()
    {

        var organizationUsersModelRepository = IoC.Resolve<IUsersListModelRepository>();

        var callCenterManager = organizationUsersModelRepository.GetUserListModelByRole(Roles.CallCenterRep, IoC.Resolve<SessionContext>().UserSession.CurrentOrganizationRole.OrganizationId);
        
        if (callCenterManager.Collection.Count() > 0)
        {
            gridviewccrep.DataSource = callCenterManager.Collection;
            gridviewccrep.DataBind();
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchCallCenterUserList(string searchtext)
    {
        var organizationUsersModelRepository = IoC.Resolve<IUsersListModelRepository>();

        var callCenterManager = organizationUsersModelRepository.GetUserListModelByRole(Roles.CallCenterRep,searchtext);

        if (callCenterManager.Collection.GetEnumerator().Current != null)
        {
            gridviewccrep.DataSource = callCenterManager.Collection;
            gridviewccrep.DataBind();
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }

    }



}
