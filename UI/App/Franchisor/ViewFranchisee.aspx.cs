using System;
using System.Linq;
using System.Web.UI.WebControls;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Core.Users.Enum;

public partial class Franchisor_ViewFranchisee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "View Franchisee";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.setpoductitle("View Franchisee", "Franchisee");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Franchisee</a>";

        if (!IsPostBack)
        {
            ViewState["SortContactFranchisee"] = SortDirection.Ascending;
            if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"].ToString().Trim().Equals("Added"))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Franchisee added successfully.');", true);
                }
                else if (Request.QueryString["Action"].ToString().Trim().Equals("Updated"))
                {
                    ClientScript.RegisterStartupScript(typeof(string), "JSCode", "alert('Franchisee updated successfully.');", true);
                }
            }
            if (Request.QueryString["searchtext"] != null)
            {
                SearchContactFranchisee(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetContactFranchisee();
            }
        }
    }

    private void GetContactFranchisee()
    {
        var service = IoC.Resolve<IOrganizationService>();
        var model = service.GetOrganizationListModel(OrganizationType.Franchisee);

        if (model != null && model.Organizations != null && model.Organizations.Count() > 0)
        {
            gridcontactfranchisee.DataSource = model.Organizations;
            gridcontactfranchisee.DataBind();
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
    }

    private void SearchContactFranchisee(string searchtext)
    {
        var service = IoC.Resolve<IOrganizationService>(); 
        var model = service.GetOrganizationListModel(OrganizationType.Franchisee, searchtext);

        if (model != null && model.Organizations != null && model.Organizations.Count() > 0)
        {
            gridcontactfranchisee.DataSource = model.Organizations;
            gridcontactfranchisee.DataBind(); 
            errordiv.Visible = false;
        }
        else
        {
            errordiv.InnerText = "No Records Found";
            errordiv.Visible = true;
        }
    }

    protected void gridcontactfranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gridcontactfranchisee.PageIndex = e.NewPageIndex;
        //gridcontactfranchisee.DataSource = (DataTable)ViewState["DSGRID"];
        //gridcontactfranchisee.DataBind();
    }

    protected void gridcontactfranchisee_Sorting(object sender, GridViewSortEventArgs e)
    {
        //DataTable dtFranchiseeUser = (DataTable)ViewState["DSGRID"];
        //if ((SortDirection)ViewState["SortContactFranchisee"] == SortDirection.Descending)
        //{
        //    dtFranchiseeUser.DefaultView.Sort = "businessname asc";
        //    ViewState["SortContactFranchisee"] = SortDirection.Ascending;
        //}
        //else
        //{
        //    dtFranchiseeUser.DefaultView.Sort = "businessname desc";
        //    ViewState["SortContactFranchisee"] = SortDirection.Descending;
        //}
        //dtFranchiseeUser = dtFranchiseeUser.DefaultView.ToTable();

        //gridcontactfranchisee.DataSource = dtFranchiseeUser;
        //ViewState["DSGRID"] = dtFranchiseeUser;

        //gridcontactfranchisee.DataBind();
    }

    protected void gridcontactfranchisee_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //if (Convert.ToInt32(((DataTable)ViewState["DSGRID"]).Rows[e.Row.DataItemIndex]["HasPod"]) == 0)
            //{
            //    Image img = new Image();
            //    img.ImageUrl = "/App/Images/Unallocated-star.png";
            //    e.Row.Cells[1].Controls.Add(img);
            //}
        }
    }

}
