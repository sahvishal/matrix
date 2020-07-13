using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class Franchisee_Dashboard : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Dashboard");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        if (!IsPostBack)
        {
            if (Session["LastLoginTime"] != null && Session["LastLoginTime"].ToString().Trim() != "")
            {
                spLastLogin.InnerText = "Last login: " + Convert.ToDateTime(Session["LastLoginTime"].ToString()).ToString("MMMM dd, yyyy, hh:mm tt");
            }
            else
            {
                divLastLogin.Visible = false;
            }
           
        }
    }

    private void CreateMenus(DataTable tblmenus)
    {
        tblmenus.DefaultView.RowFilter = "ParentModuleID = 0";

        DataView vwmnutop = new DataView(tblmenus, "ParentModuleID = 0", "MenuOrder asc", DataViewRowState.CurrentRows);
        rec_menucreate(vwmnutop, tblmenus, treeFranchisor.Nodes);
    }

    private void rec_menucreate(DataView vw, DataTable tblmenus, TreeNodeCollection clitem)
    {
        for (int count = 0; count < vw.Count; count++)
        {
            if (!vw[count]["TargetURL"].ToString().Equals(""))
            {
                TreeNode objNode = new TreeNode(vw[count]["Name"].ToString(), vw[count]["ModuleID"].ToString(), vw[count]["ImageURL"].ToString(), vw[count]["TargetURL"].ToString(), "_self");
                clitem.Add(objNode);
            }
            else
            {
                TreeNode objNode = new TreeNode(vw[count]["Name"].ToString(), vw[count]["ModuleID"].ToString(), vw[count]["ImageURL"].ToString(), "javascript:void(0);", "_self");
                clitem.Add(objNode);
            }

            tblmenus.DefaultView.RowFilter = "ParentModuleID = " + vw[count]["ModuleID"].ToString();

            if (tblmenus.DefaultView.Count <= 0)
                continue;
            DataView vwchild = new DataView(tblmenus, "ParentModuleID = " + vw[count]["ModuleID"].ToString(), "MenuOrder asc", DataViewRowState.CurrentRows);
            rec_menucreate(vwchild, tblmenus, clitem[count].ChildNodes);
        }

    }
}
