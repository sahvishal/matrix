using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
//using HealthYes.Web.UI.FranchisorService;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;
using Falcon.App.Core.Enum;

public partial class App_Franchisor_ViewContact : System.Web.UI.Page
{
    #region "Form Events"

    enum EViewType { GRID = 0, BUSINESSCARD = 1 };
    enum EListType { ALL, PROSPECT, SEARCH, CHARACTER };

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Manage Contacts";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.setpoductitle("Manage Contacts", "Contacts");
        
        var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
            obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ManageProspect.aspx\">Dashboard </a>";
        else if (orgUser.CheckRole((long)Roles.SalesRep))
            obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/Dashboard.aspx\">Dashboard </a>";

        string ProspectID = string.Empty;
        if (!IsPostBack)
        {
            
            if (Session["ViewTypeContact"] != null)
                ViewState["ViewType"] = (EViewType)Session["ViewTypeContact"];
            else
                ViewState["ViewType"] = EViewType.BUSINESSCARD;


            ViewState["SortExp"] = "FirstName";
            ViewState["SortDir"] = SortDirection.Descending;
            if (Request.QueryString["Action"] != null)
            {
                ClientScript.RegisterStartupScript(typeof(string), "JScode", "alert('Contact" + " " + Request.QueryString["Action"].ToString().Trim() + " " + "successfully.');", true);
            }

            ViewState["PageNumber"] = 1;
            if (Request.QueryString["ProspectID"] != null)
            {
                ViewState["ListType"] = EListType.PROSPECT;
                ProspectID = Request.QueryString["ProspectID"].ToString();
                Session["ProspectID"] = ProspectID;
                divalphabetsearch.Visible = false;
                this.GetContactsByProspectID();
            }
            else if (Request.QueryString["searchtext"] != null)
            {
                int sessionprospect =0;
                if (Session["ProspectID"] != null)
                {
                    sessionprospect = Convert.ToInt32(Session["ProspectID"]);
                    divalphabetsearch.Visible = false;
                }

                ViewState["ListType"] = EListType.SEARCH;
                SearchContact(Request.QueryString["searchtext"].ToString(), sessionprospect);
            }
            else
            {
                Session["ProspectID"] = null;
                ViewState["ListType"] = EListType.ALL;
                this.GetAllContacts();
            }
        }
        else
        {
            if (Request.Form["__EVENTTARGET"] != null)
            {
                switch (Request.Form["__EVENTTARGET"].ToString())
                {
                    case "Alphabet":
                        this.GetContactsByCharacter(Request.Form["__EVENTARGUMENT"].ToString());
                        break;

                    case "ViewChange":
                        if ((EViewType)ViewState["ViewType"] == EViewType.BUSINESSCARD)
                            ViewState["ViewType"] = EViewType.GRID;
                        else
                            ViewState["ViewType"] = EViewType.BUSINESSCARD;

                        Session["ViewTypeContact"] = (EViewType)ViewState["ViewType"];
                        FecthRecordsonViewChange();

                        break;
                    
                    case "PageNumber":
                        ViewState["PageNumber"] = Request.Form["__EVENTARGUMENT"].ToString();
                        this.ChangePageNumber();
                        break;
                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtNewContact_Click(object sender, EventArgs e)
    {
        if (Session["ProspectID"] != null)
            Response.RedirectUser("/App/Franchisor/AddNewContact.aspx?ProspectID=" + Convert.ToInt32((string)Session["ProspectID"]));
        else
            Response.RedirectUser("/App/Franchisor/AddNewContact.aspx");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdContacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chklistname1");
        if (chktempheader != null)
        {
            chktempheader.Attributes["onClick"] = "GridMasterCheck()";
        }

        HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
        if (chktemprow != null)
        {
            chktemprow.Attributes["onClick"] = "GridChildCheck();";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        int contactid = 0;
        for (int i = 0; i < grdContacts.Rows.Count; i++)
        {
            HtmlInputCheckBox chkPackageSelecter = new HtmlInputCheckBox();
            chkPackageSelecter = (HtmlInputCheckBox)grdContacts.Rows[i].FindControl("chkRowChild");

            if (chkPackageSelecter.Checked == true)
            {
                contactid = Convert.ToInt32(grdContacts.DataKeys[i].Value);
            }
        }
        if (contactid > 0)
        {
            if (Session["ProspectID"] != null)
            {
                Response.RedirectUser("~/App/Franchisor/AddNewContact.aspx?ProspectID=" + Session["ProspectID"].ToString() + "&ContactID=" + contactid.ToString());
            }
            else
            {
                Response.RedirectUser("~/App/Franchisor/AddNewContact.aspx?ProspectID=" + (string)Session["ProspectID"] + "&ContactID=" + contactid.ToString());
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        
        if ((EViewType)ViewState["ViewType"] == EViewType.BUSINESSCARD)
        {
            foreach (string str in hfdlcontact.Value.Split(new char[] { ',' }))
            {
                Int32 contactid = 0;
                if (Int32.TryParse(str.Trim(), out contactid))
                {
                    var franchisorDal = new FranchisorDAL();
                    franchisorDal.RemoveContact(contactid, 0);
                }

            }
            hfdlcontact.Value = "";
        }
        else
        {
            for (int i = 0; i < grdContacts.Rows.Count; i++)
            {
                var chkRowTemp = (HtmlInputCheckBox)grdContacts.Rows[i].FindControl("chkRowChild");

                if (chkRowTemp.Checked)
                {
                    Int32 contactid = Convert.ToInt32(grdContacts.DataKeys[i].Value);
                    var franchisorDal = new FranchisorDAL();
                    franchisorDal.RemoveContact(contactid, 0);
                }
            }
        }
        divErrorMsg.Visible = true;
        divErrorMsg.InnerText = "Contact(s) deleted successfully.";
        GetAllContacts();

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void grdContacts_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dtContact = (DataTable)ViewState["DSGRID"];
        if (((SortDirection)ViewState["SortDir"] == SortDirection.Descending) || (ViewState["SortExp"].ToString() != e.SortExpression))
        {
            dtContact.DefaultView.Sort = e.SortExpression + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtContact.DefaultView.Sort = e.SortExpression + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        dtContact = dtContact.DefaultView.ToTable();
        ViewState["SortExp"] = e.SortExpression;
        ViewState["DSGRID"] = dtContact;
        grdContacts.DataSource = dtContact;
        grdContacts.DataBind();
    }
    
    #endregion

    #region "User Events"

    /// <summary>
    /// 
    /// </summary>
    private void FecthRecordsonViewChange()
    {
        if ((EListType)ViewState["ListType"] == EListType.SEARCH)
        {
            int sessionprospectid = 0;
            if (Session["ProspectID"] != null) sessionprospectid = Convert.ToInt32(Session["ProspectID"]);

            SearchContact(ViewState["SearchString"].ToString(), sessionprospectid);
        }
        if ((EListType)ViewState["ListType"] == EListType.PROSPECT)
        {
            GetContactsByProspectID();
        }
        if ((EListType)ViewState["ListType"] == EListType.CHARACTER)
        {
            GetContactsByCharacter(ViewState["SearchString"].ToString());
        }
        if ((EListType)ViewState["ListType"] == EListType.ALL)
        {
            GetAllContacts();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="searchname"></param>
    /// <param name="sessionprospectid"></param>
    private void SearchContact(string searchname, int sessionprospectid)
    {
        if ((EViewType)ViewState["ViewType"] == EViewType.BUSINESSCARD) ViewState["PageSize"] = 10;
        else ViewState["PageSize"] = 30;

        //FranchisorService service = new FranchisorService();
        if ((EListType)ViewState["ListType"] != EListType.SEARCH) ViewState["PageNumber"] = 1;

        int itotalcount = 0;

        //EContact[] arrContact = service.GetContactByName(sessionprospectid, true, searchname, Convert.ToInt32(ViewState["PageNumber"]), true, Convert.ToInt16(ViewState["PageSize"]), true, out itotalcount, out boltotalcountspecified);

        FranchisorDAL objDAL = new FranchisorDAL();
        var listContact = objDAL.GetContacts(sessionprospectid, searchname, 1, Convert.ToInt32(ViewState["PageNumber"]),
                                             Convert.ToInt16(ViewState["PageSize"]), out itotalcount);
        EContact[] arrContact = null;
        if (listContact != null) arrContact = listContact.ToArray();

        LoadGrid(arrContact, itotalcount);

        ViewState["ListType"] = EListType.SEARCH;
        ViewState["SearchString"] = searchname;
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetAllContacts()
    {
        if ((EViewType)ViewState["ViewType"] == EViewType.BUSINESSCARD) ViewState["PageSize"] = 10;
        else ViewState["PageSize"] = 30;

        //FranchisorService service = new FranchisorService();
        if ((EListType)ViewState["ListType"] != EListType.ALL) ViewState["PageNumber"] = 1;

        int itotalcount = 0;

        //EContact[] arrContact = service.GetAllContact(Convert.ToInt32(ViewState["PageNumber"]), true, Convert.ToInt16(ViewState["PageSize"]), true, out itotalcount, out boltotalcountspecified);

        FranchisorDAL objDAL = new FranchisorDAL();
        var listContact = objDAL.GetContacts(0, "", 2, Convert.ToInt32(ViewState["PageNumber"]),
                                             Convert.ToInt16(ViewState["PageSize"]), out itotalcount);

        EContact[] arrContact = null;
        if (listContact != null) arrContact = listContact.ToArray();

        LoadGrid(arrContact, itotalcount);
        ViewState["ListType"] = EListType.ALL;
    }

    private void GetContactsByProspectID()
    {
        if ((EViewType)ViewState["ViewType"] == EViewType.BUSINESSCARD) ViewState["PageSize"] = 10;
        else ViewState["PageSize"] = 30;

        //FranchisorService service = new FranchisorService();
        if ((EListType)ViewState["ListType"] != EListType.PROSPECT) ViewState["PageNumber"] = 1;

        int itotalcount = 0;

        //EContact[] arrContact = service.GetContactByProspectID(Convert.ToInt32(Session["ProspectID"].ToString()), true, Convert.ToInt32(ViewState["PageNumber"]), true, Convert.ToInt16(ViewState["PageSize"]), true, out itotalcount, out boltotalcountspecified);

        FranchisorDAL objDAL = new FranchisorDAL();
        var listContact = objDAL.GetContacts(Convert.ToInt32(Session["ProspectID"].ToString()), string.Empty, 0,
                                             Convert.ToInt32(ViewState["PageNumber"]),
                                             Convert.ToInt16(ViewState["PageSize"]), out itotalcount);

        EContact[] arrContact = null;
        if (listContact != null) arrContact = listContact.ToArray();

        LoadGrid(arrContact, itotalcount);
        ViewState["ListType"] = EListType.PROSPECT;
    }

    private void GetContactsByCharacter(string strcharacter)
    {
        if ((EViewType)ViewState["ViewType"] == EViewType.BUSINESSCARD) ViewState["PageSize"] = 10;
        else ViewState["PageSize"] = 30;

        //FranchisorService service = new FranchisorService();
        if ((EListType)ViewState["ListType"] != EListType.CHARACTER) ViewState["PageNumber"] = 1;

        int itotalcount = 0;

        //EContact[] arrContact = service.GetContactByFilterCharacter(strcharacter, Convert.ToInt32(ViewState["PageNumber"]), true, Convert.ToInt16(ViewState["PageSize"]), true, out itotalcount, out boltotalcountspecified);

        FranchisorDAL objDAL = new FranchisorDAL();
        var listContact = objDAL.GetContacts(0, strcharacter, 3, Convert.ToInt32(ViewState["PageNumber"]),
                                             Convert.ToInt16(ViewState["PageSize"]), out itotalcount);
        EContact[] arrContact = null;
        if (listContact != null) arrContact = listContact.ToArray();

        LoadGrid(arrContact, itotalcount);
        ViewState["ListType"] = EListType.CHARACTER;
        ViewState["SearchString"] = strcharacter;

        this.ClientScript.RegisterStartupScript(typeof(string), "jscodeActiveAlphabet", "document.getElementById('alpha" + strcharacter + "').className = 'activealphabetvaluebox'; ", true);
    }

    private void ChangePageNumber()
    {
        if ((EListType)ViewState["ListType"] == EListType.CHARACTER)
        {
            this.GetContactsByCharacter(ViewState["SearchString"].ToString());
        }
        else if ((EListType)ViewState["ListType"] == EListType.SEARCH)
        {
            if(Session["ProspectID"] == null)
                this.SearchContact(ViewState["SearchString"].ToString(), 0);
            else
                this.SearchContact(ViewState["SearchString"].ToString(), Convert.ToInt32(Session["ProspectID"]));
        }
        else if ((EListType)ViewState["ListType"] == EListType.ALL)
        {
            this.GetAllContacts();
        }
        else if ((EListType)ViewState["ListType"] == EListType.ALL)
        {
            this.GetContactsByProspectID();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="arrContact"></param>
    private void LoadGrid(EContact[] arrContact, int itotalcount)
    {
        if (arrContact != null && arrContact.Length > 0)
        {
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            DataTable tblContact = new DataTable();
            
            aBusinessView.HRef = "";
            aGridView.HRef = "";
            aGridView.Style[HtmlTextWriterStyle.Cursor] = "default";
            aBusinessView.Style[HtmlTextWriterStyle.Cursor] = "default";

            tblContact.Columns.Add("ContactID", typeof(Int32));
            //tblContact.Columns.Add("ProspectID", typeof(Int32));
            tblContact.Columns.Add("FirstName");
            tblContact.Columns.Add("LastName");
            tblContact.Columns.Add("Address");
            tblContact.Columns.Add("Email");
            tblContact.Columns.Add("PhoneOffice");
            tblContact.Columns.Add("PhoneHome");
            tblContact.Columns.Add("PhoneCell");
            tblContact.Columns.Add("Fax");
            tblContact.Columns.Add("ContactType");

            foreach (EContact objContact in arrContact)
            {
                string address = "";
                string name = string.Empty;
                if (objContact.Address.Address1.Length > 0)
                {
                    address = CommonClass.FormatAddress(objContact.Address.Address1, objContact.Address.Address2,
                                            objContact.Address.City, objContact.Address.State, objContact.Address.Zip.ToString());
                }
                name = CommonClass.FormatName(objContact.FirstName, "", objContact.LastName);

                tblContact.Rows.Add(objContact.ContactID, objContact.FirstName, objContact.LastName, address, objContact.EMail, objCommonCode.FormatPhoneNumberGet(objContact.PhoneOffice), objCommonCode.FormatPhoneNumberGet(objContact.PhoneHome), objCommonCode.FormatPhoneNumberGet(objContact.PhoneCell), objCommonCode.FormatPhoneNumberGet(objContact.Fax), objContact.County);

            }

            divErrorMsg.Visible = false;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.ImageUrl = "../Images/del-button.gif";

            divViewGrid.Visible = false;
            divViewBusinessCards.Visible = false;

            if ((EViewType)ViewState["ViewType"] == EViewType.GRID)
            {
                aBusinessView.HRef = "javascript:onViewChange();";
                aBusinessView.Style[HtmlTextWriterStyle.Cursor] = "pointer";
                divViewGrid.Visible = true;
                grdContacts.DataSource = tblContact;
                grdContacts.DataBind();
                btnDelete.OnClientClick = "return validate('Delete');";
                divViewBusinessCards.EnableViewState = false;
                dlContacts.EnableViewState = false;
                tblGridPaging.InnerHtml = ImplementPaging(Convert.ToInt32(ViewState["PageNumber"]), Convert.ToInt16(ViewState["PageSize"]), itotalcount);
            }
            else
            {
                aGridView.HRef = "javascript:onViewChange();";
                aGridView.Style[HtmlTextWriterStyle.Cursor] = "pointer";

                dlContacts.Visible = true;
                tblListPaging.Visible = true;

                divViewBusinessCards.Visible = true;

                dlContacts.DataSource = tblContact;
                dlContacts.DataBind();
                btnDelete.OnClientClick = "return DeleteDlist();";
                divViewGrid.EnableViewState = false;
                grdContacts.EnableViewState = false;
                tblListPaging.InnerHtml = ImplementPaging(Convert.ToInt32(ViewState["PageNumber"]), Convert.ToInt16(ViewState["PageSize"]), itotalcount);
            }
            
        }
        else
        {
            if ((EViewType)ViewState["ViewType"] == EViewType.GRID)
            {
                divViewBusinessCards.Visible = false;
                divViewGrid.Visible = false;
            }
            else
            {
                divViewGrid.Visible = false;
                dlContacts.Visible = false;
                tblListPaging.Visible = false;
            }
            
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = (String)GetGlobalResourceObject("Resource", "msgNoRecordFound");
            btnEdit.ImageUrl = "../Images/edit-button-disable.gif";
            btnDelete.ImageUrl = "../Images/del-button-d.gif";
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
        }

    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pagenumber"></param>
    /// <param name="pagesize"></param>
    /// <param name="recordcount"></param>
    /// <returns></returns>
    private string ImplementPaging(int pagenumber, short pagesize, int recordcount)
    {

        if (recordcount <= pagesize) return "";

        // Calculates Total number of pages possible
        int numberofpages = recordcount / pagesize;
        if ((pagesize * numberofpages) != recordcount) numberofpages++;

        int minpagenumtodisplay, maxpagenumtodisplay;

        //Calculates first and last page number to display in paging tab, so as to decide whole range
        minpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 1) : ((((pagenumber / 10) - 1) * 10) + 1);
        maxpagenumtodisplay = (pagenumber % 10) > 0 ? (((pagenumber / 10) * 10) + 10) : ((pagenumber / 10) * 10);

        if (maxpagenumtodisplay > numberofpages)
        {
            if ((maxpagenumtodisplay - numberofpages) < minpagenumtodisplay) minpagenumtodisplay = minpagenumtodisplay - (maxpagenumtodisplay - numberofpages);
            maxpagenumtodisplay = numberofpages;
        }

        // Forms the paging tab string
        string pagingtableHTML = "<table  style=\"border:none; float:left; \"><tr> ";

        if (recordcount > 10 && minpagenumtodisplay > 1) // Applied if number of pages are greater than 10 and number of records are more than page size
        {
            pagingtableHTML += "<td><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(minpagenumtodisplay - 1) + "')\">...</a></td>";
        }

        // Forms the Paging Number HTML .... for the range
        for (int icount = minpagenumtodisplay; icount <= maxpagenumtodisplay; icount++)
        {
            if (pagenumber == icount)
                pagingtableHTML += "<td style=\" padding:4px; \">" + Convert.ToString(icount) + "</td>";
            else
                pagingtableHTML += "<td style=\" padding:4px;\"><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(icount) + "')\">" + Convert.ToString(icount) + "</a></td>";
        }

        if (numberofpages > 10 && maxpagenumtodisplay < numberofpages) // Applied if number of pages are greater than 10 and there are still more pages to come.
        {
            pagingtableHTML += "<td><a href=\"javascript:__doPostBack('PageNumber','" + Convert.ToString(maxpagenumtodisplay + 1) + "')\">...</a></td>";
        }

        pagingtableHTML += " </tr></table>";
        return pagingtableHTML;
    }
    
    #endregion

}
