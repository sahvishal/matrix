using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

//using HealthYes.Web.UI.FranchisorFranchisorUserService;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Franchisor;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
//using EUserShellModuleRole=HealthYes.Web.UI.FranchisorFranchisorUserService.EUserShellModuleRole;

public partial class Franchisor_FranchisorAdminUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        Page.Title = "Franchisor Admin User";
        divErrorMsg.InnerHtml = "";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("FranchisorAdminUser");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortFAUser"] = SortDirection.Ascending;
            if (Request.QueryString["Action"] != null)
            {
                if (Request.QueryString["Action"].ToString() == "Added")
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerHtml = "You have addded a Admin User, please use search at top to retrieve the recently added Admin user ";
                }
                else if (Request.QueryString["Action"].ToString() == "Edited")
                {
                    divErrorMsg.InnerHtml = "Record(s) updated successfully";
                    divErrorMsg.Visible = true;
                }
            }
            if (Request.QueryString["searchtext"] != null)
            {
                SearchFAUser(Request.QueryString["searchtext"].ToString());
            }
            else
            {
                GetFAUser();
            }

        }

    }
    
    private void SearchFAUser(string searchtext)
    {

        
        FranchisorDAL franchisorDal = new FranchisorDAL();
        var listFranchisorFranchisorUser = franchisorDal.GetFranchisorFranchisorUser(searchtext, 2);
        EFranchisorFranchisorUser[] franchisoruser = null;


        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        if (listFranchisorFranchisorUser != null) franchisoruser = listFranchisorFranchisorUser.ToArray();

        DataTable dtFAUser = new DataTable();
        dtFAUser.Columns.Add("FranchisorFranchisorUserID");
        dtFAUser.Columns.Add("name");
        dtFAUser.Columns.Add("address");
        dtFAUser.Columns.Add("phonecell");
        dtFAUser.Columns.Add("UserID");

        string strAddress=string.Empty;

        if (franchisoruser != null && franchisoruser.Length > 0)
        {
            for (int icount = 0; icount < franchisoruser.Length; icount++)
            {
                strAddress = Falcon.App.Lib.CommonCode.AddressSingleLine(franchisoruser[icount].FranchisorUser.User.HomeAddress.Address1,franchisoruser[icount].FranchisorUser.User.HomeAddress.Address2,franchisoruser[icount].FranchisorUser.User.HomeAddress.City,franchisoruser[icount].FranchisorUser.User.HomeAddress.State,franchisoruser[icount].FranchisorUser.User.HomeAddress.Zip);
                dtFAUser.Rows.Add(new object[] { franchisoruser[icount].FranchisorFranchisorUserID, franchisoruser[icount].FranchisorUser.User.FirstName + " " + franchisoruser[icount].FranchisorUser.User.LastName, strAddress, objCommonCode.FormatPhoneNumberGet(franchisoruser[icount].FranchisorUser.User.PhoneCell.ToString()), franchisoruser[icount].FranchisorUser.User.UserID.ToString() });

            }
        }
        else
        {
            divErrorMsg.InnerText = "No records found";
            divErrorMsg.Visible = true;
        }

        if ((SortDirection)ViewState["SortFAUser"] == SortDirection.Descending)
        {
            dtFAUser.DefaultView.Sort = "name desc";
        }
        else
        {
            dtFAUser.DefaultView.Sort = "name asc";
        }

        dtFAUser = dtFAUser.DefaultView.ToTable();
        dtFAUser.DefaultView.RowFilter = "UserID <> " + IoC.Resolve<ISessionContext>().UserSession.UserId;
        grdFAUser.DataSource = dtFAUser.DefaultView;

        ViewState["DSGRID"] = dtFAUser;

        grdFAUser.DataBind();
        //grdFAUser.Sort("name", SortDirection.Ascending);
        hfFranchisorUserID.Value = "";
    }

    private void GetFAUser()
    {

        FranchisorDAL franchisorDAL = new FranchisorDAL();
        var listFranchisorFranchisorUser = franchisorDAL.GetFranchisorFranchisorUser(IoC.Resolve<ISessionContext>().UserSession.UserId.ToString(), 3);
        EFranchisorFranchisorUser[] franchisoruser = null;

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        if (listFranchisorFranchisorUser != null) franchisoruser = listFranchisorFranchisorUser.ToArray();

        DataTable dtFAUser = new DataTable();
        dtFAUser.Columns.Add("FranchisorFranchisorUserID");
        dtFAUser.Columns.Add("name");
        dtFAUser.Columns.Add("address");
        dtFAUser.Columns.Add("phonecell");
        dtFAUser.Columns.Add("UserID");
        string strAddress = string.Empty;

        if (franchisoruser != null)
        {
            for (int icount = 0; icount < franchisoruser.Length; icount++)
            {
                strAddress = Falcon.App.Lib.CommonCode.AddressSingleLine(franchisoruser[icount].FranchisorUser.User.HomeAddress.Address1, franchisoruser[icount].FranchisorUser.User.HomeAddress.Address2, franchisoruser[icount].FranchisorUser.User.HomeAddress.City, franchisoruser[icount].FranchisorUser.User.HomeAddress.State, franchisoruser[icount].FranchisorUser.User.HomeAddress.Zip);

                dtFAUser.Rows.Add(new object[] { franchisoruser[icount].FranchisorFranchisorUserID, franchisoruser[icount].FranchisorUser.User.FirstName + " " + franchisoruser[icount].FranchisorUser.User.LastName, strAddress, objCommonCode.FormatPhoneNumberGet(franchisoruser[icount].FranchisorUser.User.PhoneCell.ToString()), franchisoruser[icount].FranchisorUser.User.UserID.ToString() });

            }
        }

        if ((SortDirection)ViewState["SortFAUser"] == SortDirection.Descending)
        {
            dtFAUser.DefaultView.Sort = "name desc";
        }
        else
        {
            dtFAUser.DefaultView.Sort = "name asc";
        }

        dtFAUser = dtFAUser.DefaultView.ToTable();

        grdFAUser.DataSource = dtFAUser;

        ViewState["DSGRID"] = dtFAUser;

        grdFAUser.DataBind();
        //grdFAUser.Sort("name", SortDirection.Ascending);//always sorts in descending order.
        hfFranchisorUserID.Value = "";
    }

    //protected void btnSave_Click(object sender, ImageClickEventArgs e)
    //{

    //}


    //private HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser[] GetSelectedFAUser()
    //{
    //    System.Collections.ArrayList ListFAUser= new ArrayList();


    //    for (int i = 0; i < grdFAUser.Rows.Count; i++)
    //    {
    //        HtmlInputCheckBox chkFAUserSelecter = new HtmlInputCheckBox();
    //        chkFAUserSelecter = (HtmlInputCheckBox)grdFAUser.Rows[i].FindControl("chkRowChild");
    //        if (chkFAUserSelecter.Checked == true)
    //        {
    //            grdFAUser.Rows[i].RowState = DataControlRowState.Selected;
    //            HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser franchisoruser = new HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser();
    //            franchisoruser.FranchisorFranchisorUserID = Convert.ToInt32(grdFAUser.DataKeys[grdFAUser.PageSize * (grdFAUser.PageIndex) + i].Value);
    //            franchisoruser.FranchisorFranchisorUserID = Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdFAUser.Rows[i].DataItemIndex]["FranchisorFranchisorUserID"]);
    //            ListFAUser.Add(franchisoruser);
    //        }
    //    }

    //    HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser[] FranchisorUsers = new HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser[ListFAUser.Count];
    //    for (int i = 0; i < ListFAUser.Count; i++)
    //    {
    //        FranchisorUsers[i] = new HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser();
    //        FranchisorUsers[i] = (HealthYes.Web.UI.FranchisorFranchisorUserService.EFranchisorFranchisorUser)ListFAUser[i];
    //    }

    //    return FranchisorUsers;
    //}


    private string GetSelectedFAUser()
    {
        string strSelectedFAUser = "";

        for (int i = 0; i < grdFAUser.Rows.Count; i++)
        {
            HtmlInputCheckBox chkFAUserSelecter = (HtmlInputCheckBox)grdFAUser.Rows[i].FindControl("chkRowChild");
            if (chkFAUserSelecter.Checked == true)
            {
                grdFAUser.Rows[i].RowState = DataControlRowState.Selected;

                strSelectedFAUser +=
                    Convert.ToInt32(
                        ((DataTable) (ViewState["DSGRID"])).Rows[grdFAUser.Rows[i].DataItemIndex][
                            "FranchisorFranchisorUserID"]) + ", ";
                
            }
        }

        if (strSelectedFAUser.Length > 0)
            strSelectedFAUser = strSelectedFAUser.Remove(strSelectedFAUser.LastIndexOf(", "));

        return strSelectedFAUser;
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedFAUserIDs = GetSelectedFAUser();

        if (strSelectedFAUserIDs.Length > 0)
        {
            FranchisorDAL franchisorDal = new FranchisorDAL();
            var returnresult = franchisorDal.SaveFranchisorFranchisorUser(strSelectedFAUserIDs,
                                                                      Convert.ToInt32(EOperationMode.DeActivate));
            if (returnresult == 0)
            {
                returnresult = 9999993;
            }

            //service.DeactivateFranchisorFranchisorUser(FrancchisorUsers, usershellmodulerole, out returnresult, out temp);

            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Record(s) deleted sucessfully"; //(String)GetGlobalResourceObject("Resource", "msgDatabaseResult" + returnresult.ToString());
            hfFranchisorUserID.Value = "";
            GetFAUser();
        }
    }

    
    protected void grdFAUser_RowDataBound(object sender, GridViewRowEventArgs e)
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
            string franchisorFranchisorID = ((System.Data.DataRowView)(e.Row.DataItem)).Row.ItemArray[0].ToString();
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");

            if (franchisorFranchisorID == "1")
            {
                chktemprow.Disabled = true;
            }
            else
            {
                
                if (chktemprow != null)
                {
                    chktemprow.Attributes["onClick"] = "GridChildCheck()";
                }
            }
        }
    }

    protected void grdFAUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

        grdFAUser.PageIndex = e.NewPageIndex;
        grdFAUser.DataSource = (DataTable)ViewState["DSGRID"];
        grdFAUser.DataBind();
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int franchisoruserid = 0;
        for (int icount = 0; icount < grdFAUser.Rows.Count; icount++)
        {
            HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)grdFAUser.Rows[icount].FindControl("chkRowChild");
            if (chktemprow.Checked==true)
            {
                franchisoruserid = Convert.ToInt32(grdFAUser.DataKeys[icount].Value);
                break;
            }
        }
        Response.RedirectUser(ResolveUrl("~/App/Franchisor/AddFranchisorAdminUser.aspx?FranchisorFranchisorUserID=" + franchisoruserid.ToString()));
       // Response.RedirectUser("AddFranchisorAdminUser.aspx?FranchisorFranchisorUserID=" + franchisoruserid.ToString());
    }

    protected void grdFAUser_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtFAUser = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortFAUser"] == SortDirection.Descending)
        {
            dtFAUser.DefaultView.Sort = "name asc";
            ViewState["SortFAUser"] = SortDirection.Ascending;
        }
        else
        {
            dtFAUser.DefaultView.Sort = "name desc";
            ViewState["SortFAUser"] = SortDirection.Descending;
        }
        dtFAUser = dtFAUser.DefaultView.ToTable();

        grdFAUser.DataSource = dtFAUser;
        ViewState["DSGRID"] = dtFAUser;

        grdFAUser.DataBind();
    }

    protected void addNewAdminUser_Click(object sender, EventArgs e)
    {
        Response.RedirectUser(ResolveUrl("~/App/Franchisor/AddFranchisorAdminUser.aspx"));
       // Response.RedirectUser("AddFranchisorAdminUser.aspx");
    }
}
