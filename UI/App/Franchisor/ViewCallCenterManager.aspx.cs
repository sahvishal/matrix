using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.Core.Enum;

//using HealthYes.Web.UI.CallCenterService;
using Falcon.App.UI.Extentions;

public partial class CallCenter_ViewCallCenterManager : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Call Center Manager";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Call Center Manager");
        obj.SetBreadCrumbRoot = "<a href='#'> Vendors </a>";

        if (!IsPostBack)
        {
            if (Request.QueryString["searchtext"] != null)
                SearchCallCenterUserList(Request.QueryString["searchtext"].ToString());
            else
                GetCallCenterUserList();

        }
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int callcentercallcenteruserid = 0;
        for (int i = 0; i < gridviewccm.Rows.Count; i++)
        {
            HtmlInputCheckBox chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)gridviewccm.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked == true)
            {
                callcentercallcenteruserid = Convert.ToInt32(gridviewccm.DataKeys[i].Value);
                break;
            }
        }
        if (callcentercallcenteruserid > 0)
        {
            Response.RedirectUser("AddCallCenterManager.aspx?CallCenterCallCenterUserID=" + callcentercallcenteruserid.ToString());
        }
    }


    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        var isDeleted = true;
        string employeeNotDeleted = string.Empty;
        var organizationRoleUserRepository = IoC.Resolve<IOrganizationRoleUserRepository>();

        for (int i = 0; i < gridviewccm.Rows.Count; i++)
        {
            var chkRowTemp = (HtmlInputCheckBox)gridviewccm.Rows[i].FindControl("chkRowChild");
            if (chkRowTemp.Checked)
            {
                isDeleted = organizationRoleUserRepository.DeactivateOrganizationRoleUser(
                    Convert.ToInt32(gridviewccm.DataKeys[i].Value));
                if (!isDeleted)
                {
                    employeeNotDeleted = gridviewccm.DataKeys[i].Value + ", ";
                }
            }
        }

        GetCallCenterUserList();

        errordiv.Visible = true;
        errordiv.InnerHtml = !string.IsNullOrWhiteSpace(employeeNotDeleted) ? string.Format("Call Center Managers with Ids {0} could not be deleted!.", employeeNotDeleted) : string.Format("Deleted successful for the selected records!.");

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gridviewccm_RowDataBound(object sender, GridViewRowEventArgs e)
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

    private void GetCallCenterUserList()
    {

        var callCenterManager =
            IoC.Resolve<IUsersListModelRepository>().GetUserListModelByRole(Roles.CallCenterManager).Collection;

        if (callCenterManager.Count() > 0)
        {
            gridviewccm.DataSource = callCenterManager;
            gridviewccm.DataBind();
        }
        else
        {
            errordiv.Visible = true;
            errordiv.InnerHtml = "No Record Found";
        }


    }

    private void SearchCallCenterUserList(string searchtext)
    {
        var organizationUsersModelRepository = IoC.Resolve<IUsersListModelRepository>();

        var callCenterManager = organizationUsersModelRepository.GetUserListModelByRole(Roles.CallCenterManager,searchtext);

        if (callCenterManager.Collection.GetEnumerator().Current != null)
        {
            gridviewccm.DataSource = callCenterManager.Collection;
            gridviewccm.DataBind();
        }
        else
        {
            errordiv.Visible = true;
            errordiv.InnerHtml = "No Record Found";
        }

    }





}
