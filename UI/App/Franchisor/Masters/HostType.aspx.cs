using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;
//using HealthYes.Web.UI.FranchisorService;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
//using EUserShellModuleRole=HealthYes.Web.UI.FranchisorService.EUserShellModuleRole;
using Falcon.DataAccess.Franchisor;

public partial class Franchisor_Masters_HostType : System.Web.UI.Page
{
    /// <summary>
    /// post back of page is checked.all the active hosttype from database are loaded into the memory
    /// and array consisting client ids of the elements is created..
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Host Type";
        divErrorMsg.InnerText = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("HostType");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortHostType"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchHostType(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetHostType();
            }
        }

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrhosttypeelemclientid", "'" + grdHostType.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrhosttypeelemclientid", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrhosttypeelemclientid", "'" + txtName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrhosttypeelemclientid", "'" + txtDescription.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrhosttypeelemclientid", "'" + hfHostTypeID.ClientID + "'");

    }

    /// <summary>
    /// This method searches for the hosttype by name entered.
    /// </summary>
    /// <param name="searchtext"></param>
    private void SearchHostType(string searchtext)
    {
        //FranchisorService service = new FranchisorService();
        //HealthYes.Web.UI.FranchisorService.EProspectType[] hosttype = service.GetProspectTypeByName(searchtext);
        FranchisorDAL objFranchisorDal=new FranchisorDAL();
        Falcon.Entity.Other.EProspectType[] hosttype = null;
        //mode - 2 for Get Prospect Type By Name
        var listHostType = objFranchisorDal.GetProspectType(searchtext, 2);
        if (listHostType != null)
            hosttype = listHostType.ToArray();
        //HostTypeService.HostTypeService service = new HostTypeService.HostTypeService();
        //HostTypeService.EHostType[] hosttype;
        //hosttype = service.GetHostTypeByName(searchtext);

        DataTable dtHostType = new DataTable();
        dtHostType.Columns.Add("HostTypeID");
        dtHostType.Columns.Add("name");
        dtHostType.Columns.Add("description");
        dtHostType.Columns.Add("Active");

        if (hosttype.Length > 0)
        {
            for (int icount = 0; icount < hosttype.Length; icount++)
            {
                if (hosttype[icount].Active.ToString().Equals("True"))
                {
                    dtHostType.Rows.Add(new object[] { hosttype[icount].ProspectTypeID, hosttype[icount].Name, hosttype[icount].Description, "Active" });
                }
                else
                    dtHostType.Rows.Add(new object[] { hosttype[icount].ProspectTypeID, hosttype[icount].Name, hosttype[icount].Description, "Deactivated" });
            }


            if ((SortDirection)ViewState["SortHostType"] == SortDirection.Descending)
            {
                dtHostType.DefaultView.Sort = "name desc";
            }
            else
            {
                dtHostType.DefaultView.Sort = "name asc";
            }

            dtHostType = dtHostType.DefaultView.ToTable();

            grdHostType.DataSource = dtHostType;

            ViewState["DSGRID"] = dtHostType;

            grdHostType.DataBind();
            txtName.Text = "";
            txtDescription.Text = "";
            hfHostTypeID.Value = "";

            btnActivate.Enabled = true;
            btnDeActivate.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            grdHostType.Visible = true;
            divGrdHostType.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "No Records Found";
            //ClientScript.RegisterStartupScript(typeof(string), "jscode", "DisableAll();", true);
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            grdHostType.Visible = false;
            divGrdHostType.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }

    /// <summary>
    /// this method fills the datagrid with relevant information
    /// about the hosttypes. 
    /// </summary>
    private void GetHostType()
    {
        //FranchisorService service = new FranchisorService();
        //HealthYes.Web.UI.FranchisorService.EProspectType[] hosttype = service.GetAllProspectType();
        FranchisorDAL objFranchisorDal = new FranchisorDAL();
        Falcon.Entity.Other.EProspectType[] hosttype = null;
        //mode - 2 for Get All Prospect Type
        var listHostType = objFranchisorDal.GetProspectType(string.Empty, 3);
        if (listHostType != null)
            hosttype = listHostType.ToArray();
        //HostTypeService.HostTypeService service = new HostTypeService.HostTypeService();
        //HostTypeService.EHostType[] hosttype;
        //hosttype= service.GetAllHostType();

        DataTable dtHostType = new DataTable();
        dtHostType.Columns.Add("HostTypeID");
        dtHostType.Columns.Add("name");
        dtHostType.Columns.Add("description");
        dtHostType.Columns.Add("Active");

        if (hosttype.Length > 0)
        {
            for (int icount = 0; icount < hosttype.Length; icount++)
            {
                if (hosttype[icount].Active.ToString().Equals("True"))
                {
                    dtHostType.Rows.Add(new object[] { hosttype[icount].ProspectTypeID, hosttype[icount].Name, hosttype[icount].Description, "Active" });
                }
                else
                    dtHostType.Rows.Add(new object[] { hosttype[icount].ProspectTypeID, hosttype[icount].Name, hosttype[icount].Description, "Deactivated" });
            }


            if ((SortDirection)ViewState["SortHostType"] == SortDirection.Descending)
            {
                dtHostType.DefaultView.Sort = "name desc";
            }
            else
            {
                dtHostType.DefaultView.Sort = "name asc";
            }

            dtHostType = dtHostType.DefaultView.ToTable();

            grdHostType.DataSource = dtHostType;
            ViewState["DSGRID"] = dtHostType;

            grdHostType.DataBind();

            txtName.Text = "";
            txtDescription.Text = "";
            hfHostTypeID.Value = "";
            grdHostType.Visible = true;
            btnActivate.Enabled = true;
            btnDeActivate.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            divGrdHostType.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = "No Records Found";
            //ClientScript.RegisterStartupScript(typeof(string), "jscode", "DisableAll();", true);
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            grdHostType.Visible = false;
            divGrdHostType.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
    }

    /// <summary>
    /// this method is used for adding new and updating the information regarding the hosttype which is
    /// called on clicking save button.
    /// </summary>
    private void UpdateHostType()
    {

        //FranchisorService service = new FranchisorService();
        //HealthYes.Web.UI.FranchisorService.EProspectType hosttype = new HealthYes.Web.UI.FranchisorService.EProspectType();
        FranchisorDAL objFranchisorDal=new FranchisorDAL();
        var hosttype = new Falcon.Entity.Other.EProspectType();
        hosttype.Description = txtDescription.Text;
        hosttype.Name = txtName.Text;

        hosttype.Active = true;
        Int64 returnresult;
        if (hfHostTypeID.Value.ToString().Equals(""))
        {
            //service.AddProspectType(hosttype , usershellmodulerole1, out returnresult, out temp);
            returnresult=objFranchisorDal.SaveProspectType(hosttype, Convert.ToInt32(EOperationMode.Insert));
        }
        else
        {
            hosttype.ProspectTypeID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdHostType.Rows[Convert.ToInt32(hfHostTypeID.Value)].DataItemIndex]["HostTypeID"]);
            //service.UpdateProspectType(hosttype, usershellmodulerole1, out returnresult, out temp);
            returnresult=objFranchisorDal.SaveProspectType(hosttype, Convert.ToInt32(EOperationMode.Update));
        }
        divErrorMsg.Visible = true;
        divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
        hfHostTypeID.Value = "";
        GetHostType();

    }

    /// <summary>
    /// this method is called on save button click which calls UpdateHostType 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateHostType();

        this.ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used to delete the selected HostType(s) from the database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        var hostTypeIds = GetSelectedHostType();
        FranchisorDAL objFranchisorDal=new FranchisorDAL();

        if (hostTypeIds.Length > 0)
        {
            returnresult = objFranchisorDal.SaveProspectType(hostTypeIds, Convert.ToInt32(EOperationMode.Delete));
            GetHostType();
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfHostTypeID.Value = "";
        }
    }

    /// <summary>
    /// this method is to get list of selected HostType(s) in the grid. 
    /// </summary>
    /// <returns></returns>
    //private HealthYes.Entity.Other.EProspectType[] GetSelectedHostType()
    private string GetSelectedHostType()
    {
        StringBuilder strHostTypeID = new StringBuilder(String.Empty);
        for (int i = 0; i < grdHostType.Rows.Count; i++)
        {
            HtmlInputCheckBox chkHostTypeSelecter = new HtmlInputCheckBox();
            chkHostTypeSelecter = (HtmlInputCheckBox)grdHostType.Rows[i].FindControl("chkRowChild");
            if (chkHostTypeSelecter.Checked == true)
            {
                strHostTypeID.Append("," + Convert.ToString(((DataTable)(ViewState["DSGRID"])).Rows[grdHostType.Rows[i].DataItemIndex]["HostTypeID"]));
                
            }
        }
        strHostTypeID.Remove(0, 1);
        return strHostTypeID.ToString();
    }

    /// <summary>
    /// this method is used for deactivating the selected HostType(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        var hostTypeIds = GetSelectedHostType();
        if (hostTypeIds.Length > 0)
        {
            var objFranchisorDal = new FranchisorDAL();
            returnresult = objFranchisorDal.SaveProspectType(hostTypeIds, Convert.ToInt32(EOperationMode.DeActivate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfHostTypeID.Value = "";
            GetHostType();
        }
    }

    /// <summary>
    /// this method is used for activating the selected HostType(s).
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        Int64 returnresult;
        var hostTypeIds = GetSelectedHostType();
        
        
        if (hostTypeIds.Length > 0)
        {
            FranchisorDAL objFranchisorDal = new FranchisorDAL();
            returnresult = objFranchisorDal.SaveProspectType(hostTypeIds, Convert.ToInt32(EOperationMode.Activate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfHostTypeID.Value = "";
            GetHostType();
        }
    }

    /// <summary>
    /// this method is fired on row data bound of the grid.
    /// javascript methods "mastercheckboxclick()" and "checkallboxes()" are added during runtime
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdHostType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                //ViewState["mastercheckboxid"] = chktempheader.ClientID;
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                //ClientScript.RegisterArrayDeclaration("arrcheckboxids", "'" + chktemprow.ClientID + "'");
                //if (ViewState["mastercheckboxid"] != null)
                chktemprow.Attributes["onClick"] = "checkallboxes()";
            }

            LinkButton lnkBtnHostType = (LinkButton)e.Row.FindControl("lnkBtnHostType");
            lnkBtnHostType.OnClientClick = "return EditHostType('" + lnkBtnHostType.ClientID + "')";
            
        }
    }

    /// <summary>
    /// this method is used to control the paging.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdHostType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdHostType.PageIndex = e.NewPageIndex;
        grdHostType.DataSource = (DataTable)ViewState["DSGRID"];
        grdHostType.DataBind();
    }

    /// <summary>
    /// this method is used for makin modular popup visible for editing purpose
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Host Type";
        this.ModalPopupExtender.Show();
    }

    /// <summary>
    /// this method is used to close the modular popup
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender.Hide();
    }

    /// <summary>
    /// this method is used for controling the sorting.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdHostType_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtHostType = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortHostType"] == SortDirection.Descending)
        {
            dtHostType.DefaultView.Sort = "name asc";
            ViewState["SortHostType"] = SortDirection.Ascending;
        }
        else
        {
            dtHostType.DefaultView.Sort = "name desc";
            ViewState["SortHostType"] = SortDirection.Descending;
        }
        dtHostType = dtHostType.DefaultView.ToTable();

        grdHostType.DataSource = dtHostType;
        ViewState["DSGRID"] = dtHostType;

        grdHostType.DataBind();
    }
}
