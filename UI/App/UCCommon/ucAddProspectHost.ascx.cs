using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Infrastructure.Sales.Repositories;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.App.Infrastructure.Repositories.Users;
using Falcon.App.Infrastructure.Service;
using System.Linq;
using Falcon.App.Core.Extensions;
using System.IO;

public partial class App_UCCommon_ucAddProspectHost : UserControl
{
    [Serializable]
    class HostImageViewData
    {
        public long Id { get; set; }
        public string Path { get; set; }
        public decimal Size { get; set; }
        public string FileName { get; set; }
        public long ImageType { get; set; }
    }

    DataTable dtContact = null;
    public long OrganizationRoleUserId
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId;
        }
    }

    public long UserRole
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.GetSystemRoleId;
        }
    }

    public OrganizationRoleUserModel OrgUser
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        }
    }

    private string _physicalPath = "";
    private string _virtualPath = "";

    enum RoomNeedsCleared { Yes = 1, No = 2 }

    List<HostImageViewData> HostImages
    {
        get
        {
            if (ViewState["HostImages"] == null) ViewState["HostImages"] = new List<HostImageViewData>();
            return ViewState["HostImages"] as List<HostImageViewData>;
        }

        set
        {
            ViewState["HostImages"] = value;
        }
    }
   

    protected void Page_Load(object sender, EventArgs e)
    {
        // Fill in Past Text Drop Down
        HostedInPastList();
        var repository = IoC.Resolve<IMediaRepository>();
        var mediaLocation = repository.GetHostImagesFileLocation();
        _physicalPath = mediaLocation.PhysicalPath;
        _virtualPath = mediaLocation.Url;

        if (!IsPostBack)
        {
            ddlFeederPromotionStatus.Attributes.Add("onchange", "PromoteChange();");
            ddlhostStatus.Attributes.Add("onchange", "HostStatusChange();");
            ddlViableHost.Attributes.Add("onchange", "ViableHostChange();");


            chkMailingAddress.Attributes["onClick"] = "CheckMailingAddress();";
            rbtnDepositsRequired.Attributes.Add("onclick", "DepositeRequires();");
            rbtnFeeRequired.Attributes.Add("onclick", "FeeRequires();");
            ddlHostedInPast.Attributes.Add("onchange", "CheckValiable();");

            radioNone.Attributes.Add("onclick", "hideDivFollwoUpAction();");
            radioFollowAction.Attributes.Add("onclick", "ShowDivFollwoUpAction();");
            chkboxCall.Attributes["onClick"] = "HideShowCall();";
            chkboxMeeting.Attributes["onClick"] = "HideShowMeeting();";
            chkboxTask.Attributes["onClick"] = "HideShowTask();";

            ViewState["FranchiseeID"] = null;
            GetDropDownInfo();
            if (Request.UrlReferrer != null)
            {
                if (Request.UrlReferrer.Query != null && Request.UrlReferrer.Query != "")
                {
                    ViewState["RefferedUrl"] = Request.UrlReferrer.PathAndQuery;
                }
                else if (Request["Parent"] != null && Request["Parent"] != "")
                {
                    ViewState["RefferedUrl"] = Request.UrlReferrer.PathAndQuery + "?Parent=" + Request["Parent"];
                }
                else
                {
                    ViewState["RefferedUrl"] = Request.UrlReferrer.PathAndQuery;
                }


            }
            string ProspectID = string.Empty;

            txtActualMembers.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtAttendence.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtzipBilling.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtzipMailing.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtFacilitiesFee.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
            txtAmount.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");

            if (Request.QueryString["ProspectID"] != null || Request.QueryString["HostID"] != null)
            {
                if (OrgUser.CheckRole((long)Roles.FranchisorAdmin))
                {
                    LoadFranchisee();
                    ibtnConvert.Style.Add(HtmlTextWriterStyle.Display, "none");
                    ibtnConvert.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                }
                else
                {
                    divAssign.Style.Add(HtmlTextWriterStyle.Display, "none");
                    divAssign.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    ibtnConvert.Style.Add(HtmlTextWriterStyle.Display, "block");
                    ibtnConvert.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
                }
                if (Request.QueryString["HostID"] != null)
                {
                    ibtnConvert.Style.Add(HtmlTextWriterStyle.Display, "none");
                    ibtnConvert.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
                    if (Request.QueryString["Action"] != null)
                    {
                        if (Request.QueryString["Action"] != "" && Request.QueryString["Action"] == "ConvertToHost")
                        {
                            divheading.InnerText = "Convert To Host";
                            spnMailingAddress.InnerText = "Host Mailing Address:";
                            divProspectDetails.InnerText = "Host Details";
                            spnProspectStatus.InnerText = "Host Category:";
                        }
                    }
                }
                if (Request.QueryString["ProspectID"] != null) ProspectID = Request.QueryString["ProspectID"].ToString();
                if (Request.QueryString["HostID"] != null) ProspectID = Request.QueryString["HostID"].ToString();

                ViewState["ProspectID"] = ProspectID;
                this.FillProspect();
            }
            // create prospect/host, the default state should be the territory state.
            else
            {
                IStateRepository stateRepository = new StateRepository();
                try
                {
                    var state = stateRepository.GetTerritoryStatesByOrganizationRoleUserId(OrganizationRoleUserId);
                    if (state != null)
                    {
                        ListItem listItemState = ddlstateBilling.Items.FindByValue(state.Id.ToString());
                        ddlstateBilling.ClearSelection();
                        if (listItemState != null) listItemState.Selected = true;
                    }
                }
                catch
                {

                }

            }
            // Display Contacts
            DisplayContacts();
        }
        pnlFranchisee.Style.Add(HtmlTextWriterStyle.Display, "none");


        if (Convert.ToInt16(rbtnDepositsRequired.SelectedValue) == 1)
        {
            spnDepositeAmount.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else spnDepositeAmount.Style.Add(HtmlTextWriterStyle.Display, "none");

        if (ddlHostedInPast.SelectedValue == "1")
        {
            spnHostedInPast.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else spnHostedInPast.Style.Add(HtmlTextWriterStyle.Display, "none");

        if (txtaddress1Billing.Text.Trim().Equals(txtaddress1Mailing.Text.Trim()))
        {
            if (chkMailingAddress.Checked == false)
                divMailingAddress.Style.Add(HtmlTextWriterStyle.Display, "none");
            else divMailingAddress.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            if (!IsPostBack && txtaddress1Mailing.Text != "")
            {
                chkMailingAddress.Checked = true;
            }

            if (txtaddress1Mailing.Text != "")
            {
                divMailingAddress.Style.Add(HtmlTextWriterStyle.Display, "block");
                chkMailingAddress.Checked = true;
            }
            else
            {
                divMailingAddress.Style.Add(HtmlTextWriterStyle.Display, "none");
                chkMailingAddress.Checked = false;
            }
        }
        if (rbtnFeeRequired.SelectedValue == "1")
        {
            divFee.Style.Add(HtmlTextWriterStyle.Display, "block");
        }

        //TODO: 
        if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"] == "SaveProspectHost")
        {
            SaveProspect();
        }

    }

    /// <summary>
    /// Save prospect Button Click 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        SaveProspect();
    }

    /// <summary>
    /// Convert to Host button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnConvert_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser(this.ResolveUrl("~/App/Common/AddNewHost.aspx?HostID=" + Convert.ToInt32(ViewState["ProspectID"].ToString()) + "&Action=ConvertToHost"));
    }

    /// <summary>
    /// Command item for contact Grid.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Command_Button_Click(Object sender, CommandEventArgs e)
    {
        Int32 ContactID = 0;
        ImageButton lnkEditdelete = (ImageButton)sender;
        int rownumber = ((GridViewRow)lnkEditdelete.NamingContainer).DataItemIndex;
        switch (e.CommandName)
        {
            case "EditContact":
                ContactID = Convert.ToInt32(e.CommandArgument.ToString());
                EditContact(ContactID, rownumber);
                break;
            case "DeleteContact":
                ContactID = Convert.ToInt32(e.CommandArgument.ToString());
                DeleteContact(ContactID, rownumber);
                break;
        }
    }

    /// <summary>
    /// Button Click Event (Assign to Franchiess)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnAssignFranchisee_Click(object sender, ImageClickEventArgs e)
    {
        ArrayList arrFracnhiseeId = new ArrayList();
        for (int i = 0; i < dgFranchiseeList.Items.Count; i++)
        {
            HtmlInputCheckBox chkRowTemp = new HtmlInputCheckBox();
            chkRowTemp = (HtmlInputCheckBox)dgFranchiseeList.Items[i].FindControl("chkRowChild");

            if (chkRowTemp.Checked == true)
            {
                arrFracnhiseeId.Add(dgFranchiseeList.DataKeys[i].ToString());
            }
        }
        //foreach (string strFranchiseeId in arrFracnhiseeId)
       // {
           // Int32 franchiseeID = Convert.ToInt32(strFranchiseeId);

           // FranchisorDAL objDAL = new FranchisorDAL();
           // var listFranchiseeFranchiseeuser = objDAL.GetFranchiseeFranchiseeUserID(franchiseeID);
        
        //}
        this.Page.ClientScript.RegisterStartupScript(typeof(string), "bujscode", "alert('Prospect has been assigned to franchisee(s) successfully.');", true);
        //ModalPopupExtenderFranchisee.Hide();

    }

    /// <summary>
    /// Button Click (Cancel Button)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        if ((Request.QueryString["Action"] != null && Request.QueryString["Action"] == "ConvertToHost"))
        {
            if (OrgUser.CheckRole((long)Roles.FranchisorAdmin))
                Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ManageProspect.aspx?ProspectID=" + Convert.ToInt32(ViewState["ProspectID"]) + "&Action=Alert"));
            else
                Response.RedirectUser(this.ResolveUrl("~/App/Franchisee/SalesRep/SalesRepManageProspects.aspx?Action=Added"));
        }
        else if (ViewState["RefferedUrl"].ToString().ToLower().IndexOf("/createeventwizard/step1.aspx") >= 0)
        {
            string strUpdateProspectHost = "/App/Common/CreateEventWizard/Step1.aspx";
            if (Request.QueryString["Type"] != null)
            {
                if (strUpdateProspectHost.IndexOf("?") >= 0)
                    strUpdateProspectHost = strUpdateProspectHost + "&HostID=" + ViewState["ProspectID"].ToString() + "&Type=Selected";
                else
                    strUpdateProspectHost = strUpdateProspectHost + "?HostID=" + ViewState["ProspectID"].ToString() + "&Type=Selected";
            }
            Response.RedirectUser(strUpdateProspectHost);
        }
        else
            Response.RedirectUser(ViewState["RefferedUrl"].ToString());

    }

    protected void HandleSave(object sender, EventArgs e)
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        //SaveContact(0, txtTitle.Text, txtFName.Text, txtLName.Text, txtMName.Text, txtPhoneOffice.Text, txtPhoneExtension.Text, txtFaxContact.Text, txtEmailContact.Text, txtTitleContact.Text, ddlRoleContact.SelectedValue, txtNotesContact.Text);
        CreateContactTable();

        int rownumber = 0;
        EContact objcontact = ucMiniAddNewContact1.GetFields(out rownumber);
        string strRole = string.Empty;
        //for (int pcount = 0; pcount < objcontact.ListProspectContactRole.Length; pcount++)
        for (int pcount = 0; pcount < objcontact.ListProspectContactRole.Count; pcount++)
        {
            strRole = strRole + objcontact.ListProspectContactRole[pcount].ProspectContactRoleID + ",";
        }
        if (strRole != null && strRole.Length > 0) strRole = strRole.Substring(0, strRole.Length - 1);

        SaveContact(objcontact.ContactID, objcontact.Title, objcontact.FirstName, objcontact.LastName, objcontact.MiddleName, objcontact.DateOfBirth,
            objCommonCode.FormatPhoneNumber(objcontact.PhoneHome), objCommonCode.FormatPhoneNumber(objcontact.PhoneCell), objCommonCode.FormatPhoneNumber(objcontact.PhoneOffice), objcontact.Phone1Extension, objcontact.EMail, objcontact.EmailWork,
            objcontact.DesignationTitle, objcontact.Gender, strRole, objcontact.Note, rownumber, objcontact.Fax);


        DisplayContacts();
        hidContactID.Value = "";
    }

    /// <summary>
    /// Button Click (AssignToFranchiess)
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnAssign_Click(object sender, ImageClickEventArgs e)
    {
        //ModalPopupExtenderFranchisee.Show();
    }

    /// <summary>
    /// Item data bound Franchiess Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgFranchiseeList_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        HtmlInputCheckBox chktempheader = (HtmlInputCheckBox)e.Item.FindControl("chklistname1");
        if (chktempheader != null)
        {
            chktempheader.Attributes["onClick"] = "GridFMasterCheck()";
        }

        HtmlInputCheckBox chktemprow = (HtmlInputCheckBox)e.Item.FindControl("chkRowChild");
        if (chktemprow != null)
        {
            chktemprow.Attributes["onClick"] = "GridFChildCheck();";
        }
    }

    protected void HostImagesDataList_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            var dataSource = (HostImageViewData)e.Item.DataItem;

            if (dataSource != null)
            {
                var imageTypeDropDown = (DropDownList)e.Item.FindControl("ImageTypeDropDown");

                if (imageTypeDropDown != null)
                    BindImageTypeDropDown(imageTypeDropDown);

                var listItem = imageTypeDropDown.Items.FindByValue(Convert.ToString(dataSource.ImageType));
                if (listItem != null) listItem.Selected = true;
            }
        }
    }
    
    private void BindImageTypeDropDown(DropDownList dropDownImageType)
    {
        var listImageType = HostImageType.HostImageTypes;

        dropDownImageType.DataValueField = "PersistenceLayerId";
        dropDownImageType.DataTextField = "Name";

        dropDownImageType.DataSource = listImageType;
        dropDownImageType.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="objPhoneExtension"></param>
    /// <returns></returns>
    protected string BindExtension(object objPhoneExtension)
    {
        string PhoneExtension = string.Empty;
        PhoneExtension = (string)objPhoneExtension;
        if (PhoneExtension == "")
        {
            PhoneExtension = "";
        }
        else PhoneExtension = " - " + PhoneExtension;
        return PhoneExtension;
    }

    /// <summary>
    /// Bind all drop downs
    /// </summary>
    private void GetDropDownInfo()
    {
        MasterDAL masterDal = new MasterDAL();
        ECountry[] objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();

        var objstate = masterDal.GetState(string.Empty, 3);

        ViewState["CountryID"] = objcountry[0].CountryID;
        ViewState["CountryName"] = objcountry[0].Name;

        ddlstateBilling.Items.Add(new ListItem("Select State", "0"));
        ddlstateMailing.Items.Add(new ListItem("Select State", "0"));

        for (int jcount = 0; jcount < objstate.Count; jcount++)
        {
            ddlstateBilling.Items.Add(new ListItem(objstate[jcount].Name, objstate[jcount].StateID.ToString()));
            ddlstateMailing.Items.Add(new ListItem(objstate[jcount].Name, objstate[jcount].StateID.ToString()));
        }
        GetHostType();
        Getstatus();

        HostRankingDropDown.Items.Clear();

        HostRankingDropDown.DataTextField = "Name";
        HostRankingDropDown.DataValueField = "PersistenceLayerId";
        HostRankingDropDown.DataSource = HostViabilityRanking.HostRankings;
        HostRankingDropDown.DataBind();

        HostRankingDropDown.Items.Insert(0, new ListItem("Rank Host Site:", "0"));

        InternetAccessDropDown.Items.Clear();

        InternetAccessDropDown.DataTextField = "Name";
        InternetAccessDropDown.DataValueField = "PersistenceLayerId";
        InternetAccessDropDown.DataSource = InternetAccess.InternetAccessTypes;
        InternetAccessDropDown.DataBind();

        InternetAccessDropDown.Items.Insert(0, new ListItem("Internet Access:", "0"));

        RoomClearedRadioButtonList.Items.Clear();
        RoomClearedRadioButtonList.Items.Add(new ListItem(RoomNeedsCleared.Yes.ToString(), Convert.ToString((int)RoomNeedsCleared.Yes)));
        RoomClearedRadioButtonList.Items.Add(new ListItem(RoomNeedsCleared.No.ToString(), Convert.ToString((int)RoomNeedsCleared.No)));

        HostConfirmationRadioButtonList.Items.Clear();
        var hostSiteConfirmationTypes = HostSiteConfirmation.Verbally.GetNameValuePairs();

        HostConfirmationRadioButtonList.DataTextField = "SecondValue";
        HostConfirmationRadioButtonList.DataValueField = "FirstValue";
        HostConfirmationRadioButtonList.DataSource = hostSiteConfirmationTypes;
        HostConfirmationRadioButtonList.DataBind();

        BindImageTypeDropDown(UploaderImageTypeDropDown);
    }

    /// <summary>
    /// Get Call Status
    /// </summary>
    private void Getstatus()
    {
        var objMasterDal = new MasterDAL();
        var listCallStatus = objMasterDal.GetCallStatusType(string.Empty, 3);
        Falcon.Entity.Other.ECallStatus[] status = null;
        if (listCallStatus != null)
            status = listCallStatus.ToArray();
        if (status != null)
            if (status.Length > 0)
            {
                for (int count = 0; count < status.Length; count++)
                {
                    if (status[count].Status.ToString().Equals("Planned"))
                    {
                        ViewState["ContactCallStatusID"] = status[count].CallStatusID.ToString();
                        break;
                    }
                }

            }
    }

    /// <summary>
    /// Bind Type of Hosts 
    /// </summary>
    private void GetHostType()
    {
        var objDAL = new FranchisorDAL();
        var listProspectType = objDAL.GetProspectType(string.Empty, 0);
        EProspectType[] ptype = null;

        if (listProspectType != null) ptype = listProspectType.OrderBy(p=>p.Name).ToArray();

        if (ptype != null)
            if (ptype.Length > 0)
            {
                ddlHostType.Items.Add(new ListItem("Select Type", "0"));
                foreach (EProspectType t in ptype)
                {
                    ddlHostType.Items.Add(new ListItem(t.Name, t.ProspectTypeID.ToString()));
                }
            }
    }

    /// <summary>
    /// Create Contact DataTable
    /// </summary>
    private void CreateContactTable()
    {
        if (ViewState["dtContact"] != null)
        {
            dtContact = (DataTable)ViewState["dtContact"];
        }
        else
        {
            dtContact = new DataTable();

            DataColumn[] myColumn = new DataColumn[1];
            myColumn[0] = new DataColumn();
            myColumn[0].ColumnName = "ID";
            myColumn[0].DataType = System.Type.GetType("System.Int32");

            dtContact.Columns.Add(myColumn[0]);

            dtContact.Columns.Add("Salutation");
            dtContact.Columns.Add("FirstName");
            dtContact.Columns.Add("LastName");
            dtContact.Columns.Add("MiddleName");
            dtContact.Columns.Add("DateOfBirth");
            dtContact.Columns.Add("PhoneHome");
            dtContact.Columns.Add("PhoneCell");
            dtContact.Columns.Add("Phone");
            dtContact.Columns.Add("PhoneExtension");
            dtContact.Columns.Add("Fax");
            dtContact.Columns.Add("Email");
            dtContact.Columns.Add("SecondaryEmail");
            dtContact.Columns.Add("Title");
            dtContact.Columns.Add("Role");
            dtContact.Columns.Add("Gender");
            dtContact.Columns.Add("ContactNote");
            dtContact.Columns.Add("IsDeleted");


            ViewState["dtContact"] = dtContact;
        }
    }

    /// <summary>
    /// Save Contact in DataTable
    /// </summary>
    /// <param name="salutation"></param>
    /// <param name="FirstName"></param>
    /// <param name="LastName"></param>
    /// <param name="MiddleName"></param>
    /// <param name="Phone"></param>
    /// <param name="PhoneExtension"></param>
    /// <param name="Fax"></param>
    /// <param name="Email"></param>
    /// <param name="Title"></param>
    /// <param name="Role"></param>
    /// <param name="ContactNote"></param>
    private void SaveContact(Int64 ID, string salutation, string FirstName, string LastName, string MiddleName, string dateofbirth,
                                string phonehome, string phonecell, string Phone, string PhoneExtension, string Email,
                                string secondaryemail, string Title, bool? blGender, string Role, string ContactNote, int rownumber, string Fax)
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        if (ViewState["dtContact"] == null) CreateContactTable();
        dtContact = (DataTable)ViewState["dtContact"];
        int position = 0;
        bool isnewrow = true;

        if (ID > 0)
        {
            dtContact.DefaultView.RowFilter = "ID=" + ID.ToString();
            if (dtContact.DefaultView.Count > 0) isnewrow = false;
        }
        else if (rownumber < 0 && ID == 0)
        {
            isnewrow = true;
        }
        else { isnewrow = false; position = rownumber; }

        if (!isnewrow)
        {
            DataView dv = dtContact.DefaultView;
            dv[position]["Salutation"] = salutation;
            dv[position]["FirstName"] = FirstName;
            dv[position]["MiddleName"] = MiddleName;
            dv[position]["LastName"] = LastName;
            dv[position]["DateOfBirth"] = dateofbirth;

            dv[position]["PhoneHome"] = objCommonCode.FormatPhoneNumberGet(phonehome);
            dv[position]["PhoneCell"] = objCommonCode.FormatPhoneNumberGet(phonecell);
            dv[position]["Phone"] = objCommonCode.FormatPhoneNumberGet(Phone);
            dv[position]["PhoneExtension"] = PhoneExtension;
            dv[position]["Fax"] = objCommonCode.FormatPhoneNumberGet(Fax);
            dv[position]["SecondaryEmail"] = secondaryemail;
            dv[position]["Email"] = Email;
            dv[position]["Title"] = Title;
            dv[position]["Gender"] = blGender;
            dv[position]["Role"] = Role;
            dv[position]["ContactNote"] = ContactNote;
            dv[position]["IsDeleted"] = "False";
        }
        else
        {
            DataRow myRow;
            myRow = dtContact.NewRow();

            myRow["ID"] = ID;
            myRow["Salutation"] = salutation;
            myRow["FirstName"] = FirstName;
            myRow["LastName"] = LastName;
            myRow["MiddleName"] = MiddleName;
            myRow["DateOfBirth"] = dateofbirth;
            myRow["PhoneHome"] = objCommonCode.FormatPhoneNumberGet(phonehome);
            myRow["PhoneCell"] = objCommonCode.FormatPhoneNumberGet(phonecell);

            myRow["Phone"] = objCommonCode.FormatPhoneNumberGet(Phone);
            myRow["PhoneExtension"] = PhoneExtension;
            myRow["Fax"] = objCommonCode.FormatPhoneNumberGet(Fax);
            myRow["Email"] = Email;
            myRow["SecondaryEmail"] = secondaryemail;
            myRow["Title"] = Title;
            myRow["Gender"] = blGender;
            myRow["Role"] = Role;
            myRow["ContactNote"] = ContactNote;
            myRow["IsDeleted"] = "False";
            dtContact.Rows.Add(myRow);
        }

        dtContact.DefaultView.RowFilter = "IsDeleted=False";
        ViewState["dtContact"] = dtContact;
    }

    /// <summary>
    ///  Display Contacts in Grid
    /// </summary>    
    private void DisplayContacts()
    {
        if (ViewState["dtContact"] != null)
        {
            dtContact = (DataTable)ViewState["dtContact"];
            if (dtContact.DefaultView.Count > 0)
            {
                dtContact.DefaultView.RowFilter = "IsDeleted=False";
                grdContacts.DataSource = dtContact;
                grdContacts.DataBind();
                dvNoContactFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else
            {
                grdContacts.DataSource = dtContact;
                grdContacts.DataBind();
                dvNoContactFound.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }
    }

    /// <summary>
    /// Edit Contact in Datatable
    /// </summary>
    /// <param name="ContactID"></param>
    private void EditContact(Int32 ContactID, int rownumber)
    {
        if (ViewState["dtContact"] != null)
        {
            dtContact = (DataTable)ViewState["dtContact"];

            DataView dv = dtContact.DefaultView;

            if (ContactID > 0)
                dv.RowFilter = "ID=" + ContactID;
            else
                dtContact.DefaultView.RowFilter = "IsDeleted=False";

            hidContactID.Value = ContactID.ToString();
            if (dv.Count > 0)
            {
                ucMiniAddNewContact1.SetFields(dv, ContactID, rownumber);
                ucMiniAddNewContact1.ContactTitle = "Edit Contact";
                ModalPopupExtender1.Show();
            }
        }
    }

    /// <summary>
    /// Delete Contact form Datatable
    /// </summary>
    /// <param name="ContactID"></param>
    private void DeleteContact(Int32 ContactID, int rownumber)
    {
        if (ViewState["dtContact"] != null)
        {
            dtContact = (DataTable)ViewState["dtContact"];
            if (dtContact.Rows.Count > 0)
            {
                if (ContactID > 0)
                {
                    DataView dv = dtContact.DefaultView;
                    dv.RowFilter = "ID=" + ContactID.ToString();
                    if (dv.Count > 0)
                    {
                        dv[0]["IsDeleted"] = "True";
                    }
                }
                else if (rownumber >= 0) { dtContact.Rows[rownumber]["IsDeleted"] = "True"; }
                dtContact.DefaultView.RowFilter = "IsDeleted=False";
            }
            hidContactID.Value = "";
            DisplayContacts();
        }
    }

    /// <summary>
    /// Save Prospect
    /// </summary>
    private void SaveProspect()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        //FranchisorService service = new FranchisorService();
        EProspect prospect = new EProspect();
        EAddress addressbilling = new EAddress();
        EAddress addressmailing = new EAddress();
        EProspectDetails objEProspectDetails = new EProspectDetails();
        prospect.ProspectDetails = new EProspectDetails();

        OtherDAL otherDal = new OtherDAL();
        EZip zipobjbilling = otherDal.CheckCityZip(txtcityBilling.Text, txtzipBilling.Text, ddlstateBilling.SelectedValue);
        EZip zipobjmailing = null;

        if (txtzipBilling.Text != "")
        {
            if (zipobjbilling.CityID == 0)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = txtcityBilling.Text + " is not a valid city in state " + ddlstateBilling.SelectedItem.Text;

                //ClientScript.RegisterStartupScript(typeof(string), "jscodebilling", "alert('City name for billing address is not valid. <br> Please Try again.');", true);                
                return;

            }
            else if (zipobjbilling.CityID > 0 && zipobjbilling.ZipID == 0)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "For Zip Code " + txtzipBilling.Text + " no matching city, state found.";

                //ClientScript.RegisterStartupScript(typeof(string), "jscodebilling", "alert('Billing address Zip code for the corresponding city is not valid. <br> Please Try again.');", true);
                return;

            }
        }
        if (chkMailingAddress.Checked == true)
        {
            zipobjmailing = otherDal.CheckCityZip(txtcityMailing.Text, txtzipMailing.Text, ddlstateMailing.SelectedValue);
            if (txtzipMailing.Text != "")
            {
                if (zipobjmailing.CityID == 0)
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerText = txtcityMailing.Text + " is not a valid city in state " + ddlstateMailing.SelectedItem.Text;
                    return;
                }
                else if (zipobjmailing.CityID > 0 && zipobjmailing.ZipID == 0)
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerText = "For Zip Code " + txtzipMailing.Text + " no matching city, state found.";
                    return;


                }
            }
        }

        if (ViewState["ProspectID"] != null)
        {
            prospect.ProspectID = Convert.ToInt32(ViewState["ProspectID"].ToString());
        }

        if (ViewState["AddressIDBilling"] != null)
        {
            addressbilling.AddressID = Convert.ToInt32(ViewState["AddressIDBilling"].ToString());
        }

        prospect.OrganizationName = txtOrgName.Text;
        prospect.WebSite = txtwebaddress.Text;

        EProspectType prospecttype = new EProspectType();
        prospecttype.ProspectTypeID = Convert.ToInt32(ddlHostType.SelectedValue.ToString());
        prospect.ProspectType = prospecttype;

        prospect.ActualMembership = txtActualMembers.Text.Length > 0 ? Convert.ToDecimal(txtActualMembers.Text) : 0;
        prospect.Attendance = txtAttendence.Text.Length > 0 ? Convert.ToDecimal(txtAttendence.Text) : 0;

        prospect.EMailID = txtEmail.Text;
        prospect.PhoneCell = "";
        prospect.PhoneOffice = objCommonCode.FormatPhoneNumber(txtcphoneoffice.Text);
        prospect.PhoneOther = "";

        prospect.Notes = txtNotes.Text;
        prospect.TaxIdNumber = (!string.IsNullOrEmpty(_taxIdNumber.Text)) ? _taxIdNumber.Text : "";

        addressbilling.Address1 = txtaddress1Billing.Text;
        addressbilling.Address2 = txtaddress2Billing.Text;

        addressbilling.Country = ViewState["CountryName"].ToString();//ddlcountryBilling.SelectedItem.Text;
        addressbilling.CountryID = Convert.ToInt32(ViewState["CountryID"]);
        if (Convert.ToInt32(ddlstateBilling.SelectedValue) > 0)
        {
            addressbilling.State = ddlstateBilling.SelectedItem.Text;
            addressbilling.StateID = Convert.ToInt32(ddlstateBilling.SelectedItem.Value);
        }
        else
        {
            addressbilling.State = string.Empty;
        }

        if (hfViewType.Value == "host") addressbilling.ZipID = txtzipBilling.Text.Length > 0 ? zipobjbilling.ZipID : 0;
        else addressbilling.ZipID = txtzipBilling.Text.Length > 0 ? Convert.ToInt32(txtzipBilling.Text) : 0;

        addressbilling.City = txtcityBilling.Text;
        addressbilling.CityID = txtcityBilling.Text.Length > 0 ? zipobjbilling.CityID : 0;
        addressbilling.Zip = txtzipBilling.Text;

        if (txtFax.Text.Trim().Equals("(___)-___-____"))
            txtFax.Text = "";

        addressbilling.Fax = objCommonCode.FormatPhoneNumber(txtFax.Text);

        prospect.Address = addressbilling;

        // If mailing address is provided
        if (chkMailingAddress.Checked == true)
        {
            addressmailing.IsMailing = true;
            addressmailing.Address1 = txtaddress1Mailing.Text;
            addressmailing.Address2 = txtaddress2Mailing.Text;

            addressmailing.Country = ViewState["CountryName"].ToString();// ddlcountryMailing.SelectedItem.Text;
            addressmailing.CountryID = Convert.ToInt32(ViewState["CountryID"]);
            if (Convert.ToInt32(ddlstateMailing.SelectedValue) > 0)
            {
                addressmailing.State = ddlstateMailing.SelectedItem.Text;
                addressmailing.StateID = Convert.ToInt32(ddlstateBilling.SelectedItem.Value);
            }
            else
            {
                addressmailing.State = string.Empty;
            }


            if (hfViewType.Value == "host") addressmailing.ZipID = txtzipMailing.Text.Length > 0 ? zipobjmailing.ZipID : 0;
            else addressmailing.ZipID = txtzipMailing.Text.Length > 0 ? Convert.ToInt32(txtzipMailing.Text) : 0;

            addressmailing.City = txtcityMailing.Text;
            addressmailing.CityID = txtcityMailing.Text.Length > 0 ? zipobjmailing.CityID : 0;
            addressmailing.Zip = txtzipMailing.Text;
        }
        // Mailing address is same as billing address
        else
        {
            addressmailing.Address1 = addressbilling.Address1;
            addressmailing.Address2 = addressbilling.Address2;
            addressmailing.City = addressbilling.City;
            addressmailing.State = addressbilling.State;
            addressmailing.Zip = addressbilling.Zip;
            addressmailing.Country = addressbilling.Country;

            addressmailing.CityID = addressbilling.CityID;
            addressmailing.StateID = addressbilling.StateID;
            addressmailing.ZipID = addressbilling.ZipID;
            addressmailing.CountryID = addressbilling.CountryID;

            addressmailing.IsMailing = true;
        }

        if (ViewState["AddressIDMailing"] != null)
        {
            addressmailing.AddressID = Convert.ToInt32(ViewState["AddressIDMailing"].ToString());
        }

        prospect.AddressMailing = addressmailing;
        prospect.FollowDate = DateTime.Now.ToShortDateString();
        prospect.WillCommunicate = Convert.ToInt32(ddlFeederPromotionStatus.SelectedValue);
        if (ddlFeederPromotionStatus.SelectedValue.Equals("0"))
        {
            prospect.ReasonWillCommunicate = txtWillPromote.Text;
        }

        if (ViewState["FranchiseeID"] != null)
        {
            ArrayList arrtemp = (ArrayList)ViewState["FranchiseeID"];
            //prospect.FranchiseeID = arrtemp.ToArray();
            prospect.FranchiseeID = arrtemp;
        }

        prospect.IsHost = true;
        if (hfViewType.Value != "host")
            prospect.IsHost = false;
        else
        {
            prospect.CallCenterNotes = CallCenterNotesTextbox.Text;
            prospect.TechnicianNotes = TechnicianNotesTextbox.Text;
        }

        if (ViewState["dtContact"] != null)
        {
            dtContact = (DataTable)ViewState["dtContact"];
            prospect.Contact = new List<EContact>();

            for (int i = 0; i < dtContact.Rows.Count; i++)
            {
                // Add all contacts to prospect
                prospect.Contact.Add(new EContact()
                                         {
                                             ContactID = Convert.ToInt32(dtContact.Rows[i]["ID"]),
                                             Title = Convert.ToString(dtContact.Rows[i]["Salutation"]),
                                             FirstName = Convert.ToString(dtContact.Rows[i]["FirstName"]),
                                             LastName = Convert.ToString(dtContact.Rows[i]["LastName"]),
                                             MiddleName = Convert.ToString(dtContact.Rows[i]["MiddleName"]),
                                             PhoneOffice = objCommonCode.FormatPhoneNumber(Convert.ToString(dtContact.Rows[i]["Phone"])),
                                             PhoneCell = objCommonCode.FormatPhoneNumber(Convert.ToString(dtContact.Rows[i]["PhoneCell"])),
                                             PhoneHome = objCommonCode.FormatPhoneNumber(Convert.ToString(dtContact.Rows[i]["PhoneHome"])),
                                             WebSite = "",
                                             Phone1Extension = Convert.ToString(dtContact.Rows[i]["PhoneExtension"]),
                                             Fax = objCommonCode.FormatPhoneNumber(Convert.ToString(dtContact.Rows[i]["Fax"])),
                                             DateOfBirth = Convert.ToString(dtContact.Rows[i]["DateOfBirth"]),
                                             EMail = Convert.ToString(dtContact.Rows[i]["Email"]),
                                             EmailWork = Convert.ToString(dtContact.Rows[i]["SecondaryEmail"]),
                                             DesignationTitle = Convert.ToString(dtContact.Rows[i]["Title"]),
                                             Gender = Convert.ToBoolean(dtContact.Rows[i]["Gender"])
                                         });

                string prospectcontactrole = Convert.ToString(dtContact.Rows[i]["Role"]);


                int innercount = 0;
                if (prospectcontactrole != "")
                {
                    foreach (string str in prospectcontactrole.Split(new char[] { ',' }))
                    {
                        if (innercount == 0)
                        {
                            prospect.Contact[i].ListProspectContactRole = new List<EProspectContactRole>();
                        }

                        prospect.Contact[i].ListProspectContactRole.Add(new EProspectContactRole()
                                                                            {
                                                                                ProspectContactRoleID =
                                                                                    Convert.ToInt16(str.Trim())
                                                                            });

                        innercount++;
                    }
                }
                if (Convert.ToString(dtContact.Rows[i]["IsDeleted"]) == "True")
                {
                    prospect.Contact[i].IsDeleted = true;
                }

                prospect.Contact[i].ContactNotes = new List<EContactNotes>();
                prospect.Contact[i].ContactNotes.Add(new EContactNotes() { Notes = Convert.ToString(dtContact.Rows[i]["ContactNote"]) });


                prospect.Contact[i].OrganizationName = "";
                prospect.Contact[i].County = "";
                prospect.Contact[i].Note = "";

                EAddress objEAddress = new EAddress();
                objEAddress.Address1 = ""; objEAddress.Address2 = "";
                objEAddress.City = ""; objEAddress.State = "";
                objEAddress.Country = ""; objEAddress.Zip = "";
                prospect.Contact[i].Address = objEAddress;
            }
            ViewState["dtContact"] = null;
        }
        else
        {
            prospect.Contact = null;
        }
        if (ViewState["PrimarContactID"] != null)
        {
            prospect.Contact[0].ContactID = Convert.ToInt32(ViewState["PrimarContactID"].ToString());
        }
        prospect.Status = ddlProspectStatus.SelectedValue;
        // Save prospect details

        objEProspectDetails.FacilitiesFee = txtFacilitiesFee.Text;

        string strPaymentMethod = string.Empty;
        foreach (ListItem li in chkPaymentMethod.Items)
        {
            if (li.Selected == true)
            {
                if (strPaymentMethod == "")
                    strPaymentMethod = li.Value;
                else
                    strPaymentMethod = strPaymentMethod + "," + li.Value;
            }
        }
        objEProspectDetails.PaymentMethod = strPaymentMethod;
        objEProspectDetails.DepositsRequire = Convert.ToInt16(rbtnDepositsRequired.SelectedValue);

        if (rbtnDepositsRequired.SelectedValue.Equals("1"))
        {
            objEProspectDetails.DepositsAmount = txtAmount.Text.Length > 0 ? Convert.ToDecimal(txtAmount.Text) : 0.0m;
        }
        objEProspectDetails.WillHost = Convert.ToInt16(ddlhostStatus.SelectedValue);
        objEProspectDetails.ViableHostSite = Convert.ToInt16(ddlViableHost.SelectedValue);
        objEProspectDetails.HostedInPast = Convert.ToInt16(ddlHostedInPast.SelectedValue);


        if (ddlhostStatus.SelectedValue.Equals("0"))
        {
            objEProspectDetails.ReasonWillHost = txtWillHost.Text;
        }
        if (ddlViableHost.SelectedValue.Equals("0"))
        {
            objEProspectDetails.ReasonViableHostSite = txtViableHostSite.Text;
        }
        if (ddlHostedInPast.SelectedValue.Equals("0"))
        {
            objEProspectDetails.ReasonHostedInPast = txtHostInPast.Text;
        }
        if (ddlHostedInPast.SelectedValue.Equals("1"))
        {
            objEProspectDetails.HostedInPastWith = txtHostedInPast.Text;
        }

        if (ViewState["ProspectDetailsID"] != null)
        {
            objEProspectDetails.ProspectDetailID = Convert.ToInt32(ViewState["ProspectDetailsID"].ToString());
        }
        prospect.ProspectDetails = objEProspectDetails;

        prospect.ContactMeeting = null;
        prospect.ContactCall = null;
        prospect.Task = null;
        
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        if (chkboxCall.Checked == true)
        {
            prospect.ContactCall = new EContactCall();
            prospect.ContactCall.CallStatus = new ECallStatus();
            prospect.ContactCall.Subject = txtCallSubject.Text;
            prospect.ContactCall.StartDate = txtCallStartDate.Text;

            if (!string.IsNullOrEmpty(txtCallStartTime.Text))
                prospect.ContactCall.StartTime = txtCallStartTime.Text;
            else prospect.ContactCall.StartTime = "";

            prospect.ContactCall.Notes = "";
            prospect.ContactCall.CallStatus = new ECallStatus();
            prospect.ContactCall.IsActive = true;

            if (ViewState["ContactCallStatusID"] != null && (string)ViewState["ContactCallStatusID"] != "")
            {
                prospect.ContactCall.CallStatus.CallStatusID = Convert.ToInt32(ViewState["ContactCallStatusID"]);
            }
            
            prospect.ContactCall.AssignedToUserId = Convert.ToInt32(currentSession.UserId);
            prospect.ContactCall.AssignedToShellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
            prospect.ContactCall.AssignedToRoleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);


            prospect.ContactCall.CreatedByUserId = Convert.ToInt32(currentSession.UserId);
            prospect.ContactCall.CreatedByShellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
            prospect.ContactCall.CreatedByRoleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);

        }

        if (chkboxMeeting.Checked == true)
        {
            prospect.ContactMeeting = new EContactMeeting();
            prospect.ContactMeeting.StartDate = txtMeetingStartDate.Text;
            prospect.ContactMeeting.StartTime = txtMeetingStartTime.Text;
            prospect.ContactMeeting.Description = "";
            prospect.ContactMeeting.Subject = "No Subject";
            prospect.ContactMeeting.Venue = txtVenue.Text;
            prospect.ContactMeeting.IsActive = true;
            prospect.ContactMeeting.CallStatus = new ECallStatus();

            prospect.ContactMeeting.AssignedToUserId = Convert.ToInt32(currentSession.UserId);
            prospect.ContactMeeting.AssignedToShellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
            prospect.ContactMeeting.AssignedToRoleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);
            
            prospect.ContactMeeting.CreatedByUserId = Convert.ToInt32(currentSession.UserId);
            prospect.ContactMeeting.CreatedByShellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
            prospect.ContactMeeting.CreatedByRoleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);

        }
        if (chkboxTask.Checked == true)
        {
            if ((!string.IsNullOrEmpty(txtTask.Text)) || (!string.IsNullOrEmpty(txtTaskDueDate.Text)) || (!string.IsNullOrEmpty(txtTaskDueTime.Text)))
            {
                prospect.Task = new ETask();
                prospect.Task.Subject = txtTask.Text;
                if (txtTaskDueDate.Text != "")
                    prospect.Task.DueDate = txtTaskDueDate.Text;
                if (txtTaskDueTime.Text != "")
                    prospect.Task.DueTime = txtTaskDueTime.Text;
                prospect.Task.TaskStatusType = new ETaskStatusType();
                prospect.Task.TaskPriorityType = new ETaskPriorityType();
                prospect.Task.UserShellModule = new EUserShellModuleRole();

                prospect.Task.UserShellModule.UserID = currentSession.UserId.ToString();
                prospect.Task.UserShellModule.ShellID = currentSession.CurrentOrganizationRole.OrganizationId.ToString();
                prospect.Task.UserShellModule.RoleID = currentSession.CurrentOrganizationRole.RoleId.ToString();

                prospect.Task.CreatedBY = Convert.ToInt32(currentSession.UserId);
                prospect.Task.ModifiedBY = Convert.ToInt32(currentSession.UserId);
            }
        }
        long tempResult;
        string strUpdateProspectHost = string.Empty;

        if (ViewState["ProspectID"] != null)
        {
            if (ViewState["ProspectID"].ToString() != string.Empty)
            {
                this.UpdateProspectHost(prospect, currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                        currentSession.CurrentOrganizationRole.RoleId.ToString());

                if ((Request.QueryString["Action"] != null && Request.QueryString["Action"] == "ConvertToHost"))
                {
                    if (OrgUser.CheckRole((long)Roles.FranchisorAdmin) || OrgUser.CheckRole((long)Roles.FranchiseeAdmin))
                    {
                        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ManageHost.aspx?Action=Added"));
                    }
                    else if (OrgUser.CheckRole((long)Roles.SalesRep))
                    {
                        Response.RedirectUser(this.ResolveUrl("~/App/Franchisee/SalesRep/SalesRepManageHost.aspx?Action=Added"));
                    }
                }
                else
                {
                    if (ViewState["RefferedUrl"] != null && (string)ViewState["RefferedUrl"] != "")
                    {
                        strUpdateProspectHost = ViewState["RefferedUrl"].ToString();
                        if (Request.UrlReferrer.Query != null && Request.UrlReferrer.Query != "")
                        {
                            if (strUpdateProspectHost.ToLower().IndexOf("/createeventwizard/step1.aspx") == -1)
                            {
                                if (strUpdateProspectHost.IndexOf("Action=Alert") == -1)
                                {
                                    strUpdateProspectHost = strUpdateProspectHost + "&Action=Alert";
                                }
                            }
                            else
                            {
                                strUpdateProspectHost = "/App/Common/CreateEventWizard/Step1.aspx";
                                if (Request.QueryString["EventId"] != null)
                                    strUpdateProspectHost = strUpdateProspectHost + "?EventId=" + Request.QueryString["EventId"];
                                if (Request.QueryString["Type"] != null)
                                {
                                    if (strUpdateProspectHost.IndexOf("?") >= 0)
                                        strUpdateProspectHost = strUpdateProspectHost + "&HostID=" + ViewState["ProspectID"].ToString() + "&Type=Selected";
                                    else
                                        strUpdateProspectHost = strUpdateProspectHost + "?HostID=" + ViewState["ProspectID"].ToString() + "&Type=Selected";
                                }
                                
                            }
                        }
                    }
                    Response.RedirectUser(this.ResolveUrl(strUpdateProspectHost));
                }
            }

        }
        else
        {

            tempResult = this.AddProspectHost(prospect, currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                        currentSession.CurrentOrganizationRole.RoleId.ToString());
            if (tempResult > 0)
            {
                if (prospect.IsHost)
                {
                    //strUpdateProspectHost = "alert('Host added successfully!');";
                    if (OrgUser.CheckRole((long)Roles.FranchisorAdmin) || OrgUser.CheckRole((long)Roles.FranchiseeAdmin))
                    {
                        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ManageHost.aspx?Type=Host&Action=Added"));
                    }
                    else if (OrgUser.CheckRole((long)Roles.SalesRep))
                    {
                        Response.RedirectUser(this.ResolveUrl("~/App/Franchisee/SalesRep/SalesRepManageHost.aspx?Action=Added&Type=Host"));
                    }
                }
                else
                {
                    if (OrgUser.CheckRole((long)Roles.FranchisorAdmin) || OrgUser.CheckRole((long)Roles.FranchiseeAdmin))
                        Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ManageProspect.aspx?Type=Prospect&Action=Added"));
                    else
                        Response.RedirectUser(this.ResolveUrl("~/App/Franchisee/SalesRep/SalesRepManageProspects.aspx?Action=Added&Type=Prospect"));
                }
            }
            // The host or prospect is duplicate
            else if (tempResult == -1)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "A host with this name and address already exists.<br>If you are not able to find the host in the system, please contact your supervisor to add this host to your account";
                return;
            }
        }

    }

    /// <summary>
    /// To add prospect detail
    /// </summary>
    /// <param name="prospectList"></param>
    /// <param name="userID"></param>
    /// <param name="shell"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public Int64 AddProspectHost(EProspect prospect, string userID, string shell, string role)
    {
        //TODO: SRE
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = 0;

        if (!prospect.IsHost)
            returnresult = franchisorDAL.SaveProspect(prospect, Convert.ToInt32(EOperationMode.Insert), userID, shell, role);
        else
            returnresult = franchisorDAL.SaveHost(prospect, Convert.ToInt32(EOperationMode.Insert), userID, shell, role);

        Int32 prospectid = 0;
        if (returnresult > 0) prospectid = Convert.ToInt32(returnresult);
        else return -1;

        var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        var organizationRoleUser = new OrganizationRoleUserRepository().GetOrganizationRoleUser(currentOrgRole.OrganizationRoleUserId);

        if (currentOrgRole.CheckRole((long)Roles.SalesRep) && prospect.IsHost)
        {
            int saveResultFacilityRanking = SaveHostFacilityRanking(prospectid, organizationRoleUser);
            if (saveResultFacilityRanking < 0) return saveResultFacilityRanking;
        }

        SaveHostImages(prospectid, organizationRoleUser);

        // Save prospect mailing address
        if (prospectid > 0 && prospect.AddressMailing != null && !prospect.IsHost)
        {
            franchisorDAL.SaveProspectAddress(prospect.AddressMailing, prospectid);
        }
        // Save prospect details
        if (prospectid > 0 && prospect.ProspectDetails != null)
        {
            franchisorDAL.SaveProspectDetails(prospect.ProspectDetails, prospectid);
        }

        Int64 returnContactID = 0;
        // Save prospect contacts
        if (prospectid > 0 && prospect.Contact != null && prospect.Contact.Count > 0)
        {
            for (int i = 0; i < prospect.Contact.Count; i++)
            {
                // If the contact has not marked as deleted record.
                if (!prospect.Contact[i].IsDeleted)
                {
                    returnContactID = franchisorDAL.SaveContact(prospect.Contact[i], Convert.ToInt32(EOperationMode.Insert), Convert.ToInt32(userID));
                    if (returnContactID > 0)
                    {
                        franchisorDAL.SaveProspectContact(returnContactID, prospectid, true);
                        franchisorDAL.SaveProspectContactRoleMapping(prospect.Contact[i].ListProspectContactRole, returnContactID, prospectid);
                    }
                }
            }
        }
        // Save Contact Call
        if (prospect.ContactCall != null)
        {
            prospect.ContactCall.Contact = new EContact();
            prospect.ContactCall.Contact.ContactID = Convert.ToInt32(returnContactID);
            prospect.ContactCall.ProspectID = prospectid;
            // Save Call With Contact Or Prospect Relation
            franchisorDAL.SaveCall(prospect.ContactCall, Convert.ToInt32(EOperationMode.Insert));
        }
        if (prospect.ContactMeeting != null)
        {
            prospect.ContactMeeting.Contact = new EContact();
            prospect.ContactMeeting.Contact.ContactID = Convert.ToInt32(returnContactID);
            prospect.ContactMeeting.ProspectID = prospectid;
            franchisorDAL.SaveMeeting(prospect.ContactMeeting, Convert.ToInt32(EOperationMode.Insert));
        }
        if (prospect.Task != null)
        {
            prospect.Task.ProspectID = prospectid;
            prospect.Task.ContactID = Convert.ToInt32(returnContactID);
            franchisorDAL.SaveTask(prospect.Task, Convert.ToInt32(EOperationMode.Insert), userID, shell, role);
        }

        return returnresult;

    }

    private int SaveHostFacilityRanking(long hostId, OrganizationRoleUser organizationRoleUser)
    {
        if (HostRankingDropDown.SelectedIndex < 1 && InternetAccessDropDown.SelectedIndex < 0
            && NumberPlugPointsTextBox.Text.Trim().Length < 1 && HostConfirmationRadioButtonList.SelectedIndex < 0
            && RoomClearedRadioButtonList.SelectedIndex < 0 && RoomSizeTextBox.Text.Trim().Length < 1) return 0;

        IHostFacilityRankingService _hostFacilityRankingService = new HostFacilityRankingService();
        var hostFacilityViability = new HostFacilityViability();

        if (HostRankingDropDown.SelectedIndex > 0)
            hostFacilityViability.Ranking = HostViabilityRanking.HostRankings.Find(ranking => ranking.PersistenceLayerId == Convert.ToInt32(HostRankingDropDown.SelectedItem.Value));

        if (InternetAccessDropDown.SelectedIndex > 0)
            hostFacilityViability.InternetAccess = InternetAccess.InternetAccessTypes.Find(internetAccess => internetAccess.PersistenceLayerId == Convert.ToInt32(InternetAccessDropDown.SelectedItem.Value));

        if (NumberPlugPointsTextBox.Text.Trim().Length > 0)
            hostFacilityViability.NumberOfPlugPoints = (Int16?)Convert.ToInt16(NumberPlugPointsTextBox.Text.Trim());

        if (HostConfirmationRadioButtonList.SelectedIndex >= 0)
        {
            if (Convert.ToInt32(HostConfirmationRadioButtonList.SelectedItem.Value) == (int)HostSiteConfirmation.Visually)
                hostFacilityViability.IsConfirmedVisually = true;
            else
                hostFacilityViability.IsConfirmedVisually = false;
        }

        if (RoomClearedRadioButtonList.SelectedIndex >= 0)
        {
            if (Convert.ToInt32(RoomClearedRadioButtonList.SelectedItem.Value) == (int)RoomNeedsCleared.Yes)
                hostFacilityViability.RoomNeedsCleared = true;
            else
                hostFacilityViability.RoomNeedsCleared = false;
        }

        hostFacilityViability.RoomSize = RoomSizeTextBox.Text.Trim();

        //if(HostConfirmationRadioButtonList.

        hostFacilityViability.HostId = hostId;

        hostFacilityViability.CreatedBy = organizationRoleUser;
        hostFacilityViability.CreatedOn = DateTime.Now;

        try
        {
            _hostFacilityRankingService.SaveHostFacilityRanking(hostFacilityViability);
        }
        catch
        {
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = "Some error occured while saving Host Facility Ranking.";

            return -2;
        }

        return 0;
    }

    private void SaveAddressLatitudeLongitude(long addressId)
    {
        IAddressRepository addressRepository = new AddressRepository();
        addressRepository.UpdateAddressLatitudeAndLongitude(addressId, string.Empty, string.Empty, OrganizationRoleUserId, false);
        addressRepository.UpdateGoogleMapVerificatioStatus(addressId, null, OrganizationRoleUserId);
    }

    /// <summary>
    /// To update prospect detail
    /// </summary>
    /// <param name="prospectList"></param>
    /// <param name="userID"></param>
    /// <param name="shell"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public Int64 UpdateProspectHost(EProspect prospect, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = 0;
        if (!prospect.IsHost)
            returnresult = franchisorDAL.SaveProspect(prospect, Convert.ToInt32(EOperationMode.Update), userID, shell, role);
        else
        {
            returnresult = franchisorDAL.SaveHost(prospect, Convert.ToInt32(EOperationMode.Update), userID, shell, role);
            // Reset host Address (Latitude and Longitude)
            if (hfViewType.Value == "host" && prospect.IsHost)
            {
                if (prospect.Address.AddressID > 0)
                    SaveAddressLatitudeLongitude(prospect.Address.AddressID);
            }
        }
        Int64 returnContactID = 0;
        int prospectid = 0;

        if (returnresult == 0)
        {
            prospectid = Convert.ToInt32(prospect.ProspectID);

            var currentOrgRole = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
            var organizationRoleUser = new OrganizationRoleUserRepository().GetOrganizationRoleUser(currentOrgRole.OrganizationRoleUserId);

            if (currentOrgRole.CheckRole((long)Roles.SalesRep) && prospect.IsHost)
            {
                int saveResultFacilityRanking = SaveHostFacilityRanking(prospectid, organizationRoleUser);
                if (saveResultFacilityRanking < 0) return saveResultFacilityRanking;
            }

            SaveHostImages(prospectid, organizationRoleUser);

            if (prospect.AddressMailing != null && !prospect.IsHost)
            {
                // Save prospect mailing address
                franchisorDAL.SaveProspectAddress(prospect.AddressMailing, prospectid);
            }
            // Save prospect details
            if (prospect.ProspectDetails != null)
            {
                franchisorDAL.SaveProspectDetails(prospect.ProspectDetails, prospectid);
            }

            if (prospect.Contact != null && prospect.Contact.Count > 0)
            {
                for (int i = 0; i < prospect.Contact.Count; i++)
                {

                    if (prospect.Contact[i].IsDeleted == false)
                    {
                        // Save Prospect Communication
                        //returnContactID = franchisorDAL.SaveNewProspectContact(prospect.Contact[i], 2, prospectid, Convert.ToInt32(userID));
                        if (prospect.Contact[i].ContactID > 0)
                        {
                            returnContactID = franchisorDAL.SaveContact(prospect.Contact[i], Convert.ToInt32(EOperationMode.Update), Convert.ToInt32(userID));
                            if (returnContactID >= 0) returnContactID = prospect.Contact[i].ContactID;
                            else returnContactID = -1;
                        }
                        else
                            returnContactID = franchisorDAL.SaveContact(prospect.Contact[i], Convert.ToInt32(EOperationMode.Insert), Convert.ToInt32(userID));

                        if (returnContactID > 0)
                        {
                            franchisorDAL.SaveProspectContact(returnContactID, prospectid, true);
                            franchisorDAL.SaveProspectContactRoleMapping(prospect.Contact[i].ListProspectContactRole, returnContactID, prospectid);
                        }
                    }
                    else
                    {
                        //Deactivates the same record
                        franchisorDAL.SaveProspectContact(prospect.Contact[i].ContactID, prospectid, false);
                    }

                }

            }
        }
        if (prospect.ContactCall != null)
        {
            prospect.ContactCall.Contact = new EContact();
            prospect.ContactCall.Contact.ContactID = Convert.ToInt32(returnContactID);
            prospect.ContactCall.ProspectID = prospectid;
            franchisorDAL.SaveCall(prospect.ContactCall, Convert.ToInt32(EOperationMode.Insert));
        }
        if (prospect.ContactMeeting != null)
        {
            prospect.ContactMeeting.Contact = new EContact();
            prospect.ContactMeeting.Contact.ContactID = Convert.ToInt32(returnContactID);
            prospect.ContactMeeting.ProspectID = prospectid;
            franchisorDAL.SaveMeeting(prospect.ContactMeeting, Convert.ToInt32(EOperationMode.Insert));
        }
        if (prospect.Task != null)
        {
            prospect.Task.ContactID = Convert.ToInt32(returnContactID);
            prospect.Task.ProspectID = prospectid;
            franchisorDAL.SaveTask(prospect.Task, Convert.ToInt32(EOperationMode.Insert), userID, shell, role);
        }

        return returnresult;
    }

    public void SetViewType(bool ishost)
    {
        if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
            HostFacilityContainerDiv.Style[HtmlTextWriterStyle.Display] = "block";

        if (ishost)
        {
            hfViewType.Value = "host";
            Page.ClientScript.RegisterStartupScript(typeof(string), "jsopenmandatory", " OpenMandatoryfields(); ", true);
            // hide convert to host link
            ibtnConvert.Style.Add(HtmlTextWriterStyle.Display, "none");
            ibtnConvert.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");

            divheading.InnerText = "Create New Host";
            divTitle.InnerText = "Host";

            CallCenterNotesDiv.Style[HtmlTextWriterStyle.Display] = "block";
            TechnicianNotesDiv.Style[HtmlTextWriterStyle.Display] = "block";

            if (Request.QueryString["HostID"] != null)
            {
                divheading.InnerText = "Edit Host";
                if (Request["Action"] != null && Request["Action"].Equals("ConvertToHost"))
                {
                    divheading.InnerText = "Convert To Host";
                }
            }

            spnMailingAddress.InnerText = "Host Mailing Address:";
            divProspectDetails.InnerText = "Host Details";
            spnProspectStatus.InnerText = "Host Category:";
            _divTaxNumber.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        else
        {
            hfViewType.Value = "prospect";
            divheading.InnerHtml = "Create New Prospect";
            divTitle.InnerText = "Prospect";
            ibtnConvert.Style.Add(HtmlTextWriterStyle.Display, "none");
            ibtnConvert.Style.Add(HtmlTextWriterStyle.Visibility, "hidden");
            _divTaxNumber.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (Request.QueryString["ProspectID"] != null)
            {
                divheading.InnerText = "Edit Prospect";
                // show convert to host link
                ibtnConvert.Style.Add(HtmlTextWriterStyle.Display, "block");
                ibtnConvert.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            }
        }


    }

    /// <summary>
    /// Fill Prospect in case of edit prospect
    /// </summary>
    private void FillProspect()
    {
        EProspect[] prospect = null;
        FranchisorDAL objDAL = new FranchisorDAL();

        if (hfViewType.Value == "host" && Request.QueryString["Action"] == null)
        {
            spnMailingAddress.InnerText = "Host Mailing Address:";
            divProspectDetails.InnerText = "Host Details";
            spnProspectStatus.InnerText = "Host Status:";
            
            var listProspect = objDAL.GetHostDetails(ViewState["ProspectID"].ToString(), 1);
            if (listProspect != null) prospect = listProspect.ToArray();
        }
        else if (hfViewType.Value != "host" || (Request.QueryString["Action"] != null && Request.QueryString["Action"] == "ConvertToHost"))
        {
            var listProspect = objDAL.GetProspectDetails(ViewState["ProspectID"].ToString(), 4);
            if (listProspect != null) prospect = listProspect.ToArray();
        }

        if (prospect != null)
        {
            ViewState["ProspectID"] = prospect[0].ProspectID;
            if (!(Request.QueryString["Action"] != null && Request.QueryString["Action"] == "ConvertToHost")) ViewState["AddressIDBilling"] = prospect[0].Address.AddressID;
            if (!(Request.QueryString["Action"] != null && Request.QueryString["Action"] == "ConvertToHost")) ViewState["AddressIDMailing"] = prospect[0].AddressMailing.AddressID;
            ViewState["ProspectDetailsID"] = prospect[0].ProspectDetails.ProspectDetailID;

            txtaddress1Billing.Text = prospect[0].Address.Address1.ToString();
            txtaddress2Billing.Text = prospect[0].Address.Address2;

            txtaddress1Mailing.Text = prospect[0].AddressMailing.Address1.ToString();
            txtaddress2Mailing.Text = prospect[0].AddressMailing.Address2;

            txtEmail.Text = prospect[0].EMailID.ToString();
            // Billing State
            if (prospect[0].Address.State.Length > 0)
            {
                int selectedindex = Convert.ToInt32(ddlstateBilling.Items.FindByText(prospect[0].Address.State.Trim()).Value);
                ddlstateBilling.SelectedValue = selectedindex.ToString();
            }
            else
            {
                ddlstateBilling.SelectedValue = "0";
            }
            // Mailing State
            if (prospect[0].AddressMailing.State.Length > 0)
            {
                int selectedindex = Convert.ToInt32(ddlstateMailing.Items.FindByText(prospect[0].AddressMailing.State.Trim()).Value);
                ddlstateMailing.SelectedValue = selectedindex.ToString();
            }
            else
            {
                ddlstateMailing.SelectedValue = "0";
            }
            txtcityBilling.Text = prospect[0].Address.City;
            txtcityMailing.Text = prospect[0].AddressMailing.City;

            txtOrgName.Text = prospect[0].OrganizationName.ToString();
            txtcphoneoffice.Text = prospect[0].PhoneOffice.ToString();

            SetCalCenterandTechnicianNotes(prospect[0]);

            txtwebaddress.Text = prospect[0].WebSite.ToString();
            // Billing Zip
            if (prospect[0].Address.Zip != "0")
                txtzipBilling.Text = prospect[0].Address.Zip;
            else txtzipBilling.Text = "";

            // Mailing Zip
            if (prospect[0].AddressMailing.Zip != "0")
                txtzipMailing.Text = prospect[0].AddressMailing.Zip;
            else txtzipMailing.Text = "";

            txtFax.Text = prospect[0].Fax;
            _taxIdNumber.Text = (!string.IsNullOrEmpty(prospect[0].TaxIdNumber)) ? prospect[0].TaxIdNumber : "";
            //txtNotes.Text = prospect[0].Notes;

            // check mailing address is same as billing address
            if (prospect[0].Address.Address1.Equals(prospect[0].AddressMailing.Address1)
            && (prospect[0].Address.Address2.Equals(prospect[0].AddressMailing.Address2))
            && (prospect[0].Address.City.Equals(prospect[0].AddressMailing.City))
            && (prospect[0].Address.State.Equals(prospect[0].AddressMailing.State))
            && (prospect[0].Address.Zip == prospect[0].AddressMailing.Zip))
            //&& (prospect[0].Address.CountryID == prospect[0].AddressMailing.CountryID)
            {
                chkMailingAddress.Checked = false;
            }
            else chkMailingAddress.Checked = true;

            
            IHostFacilityRankingService hostFacilityRankingService = new HostFacilityRankingService();
            var hostFacilityViability = hostFacilityRankingService.GetHostFacilityRankingByHSC(prospect[0].ProspectID);

            if (hostFacilityViability != null)
            {
                if (hostFacilityViability.Ranking != null)
                {
                    var hostRankingItem = HostRankingDropDown.Items.FindByValue(hostFacilityViability.Ranking.PersistenceLayerId.ToString());
                    if (hostRankingItem != null)
                        hostRankingItem.Selected = true;
                }

                if (hostFacilityViability.InternetAccess != null)
                {
                    var internetAccessItem = InternetAccessDropDown.Items.FindByValue(hostFacilityViability.InternetAccess.PersistenceLayerId.ToString());
                    if (internetAccessItem != null)
                        internetAccessItem.Selected = true;
                }

                if (hostFacilityViability.RoomNeedsCleared != null)
                {
                    if (hostFacilityViability.RoomNeedsCleared.Value)
                        RoomClearedRadioButtonList.Items[0].Selected = true;
                    else
                        RoomClearedRadioButtonList.Items[1].Selected = true;
                }

                RoomSizeTextBox.Text = hostFacilityViability.RoomSize;

                if (hostFacilityViability.NumberOfPlugPoints != null)
                    NumberPlugPointsTextBox.Text = hostFacilityViability.NumberOfPlugPoints.Value.ToString();

                if (hostFacilityViability.IsConfirmedVisually != null)
                {
                    if (hostFacilityViability.IsConfirmedVisually.Value)
                    {
                        var listItem = HostConfirmationRadioButtonList.Items.FindByValue(Convert.ToString((int)HostSiteConfirmation.Visually));
                        if (listItem != null) listItem.Selected = true;
                    }
                    else
                    {
                        var listItem = HostConfirmationRadioButtonList.Items.FindByValue(Convert.ToString((int)HostSiteConfirmation.Verbally));
                        if (listItem != null) listItem.Selected = true;
                    }
                }
            }

            IHostRepository hostRepository = new HostRepository();
            var hostImages = hostRepository.GetHostImages(prospect[0].ProspectID);

            hostImages = hostImages.FindAll(hostImage => hostImage.UploadedBy.RoleId == (long)Roles.SalesRep || GetParentRoleIdByRoleId(hostImage.UploadedBy.RoleId) == (long)Roles.SalesRep);

            if (hostImages.Count > 0)
            {
                hostImages.ForEach(hostImage => HostImages.Add(new HostImageViewData
                {
                    Id = hostImage.Id,
                    Path = _virtualPath + hostImage.Path,
                    ImageType = hostImage.ImageType.PersistenceLayerId
                }));

                HostImagesDataList.DataSource = HostImages;
                HostImagesDataList.DataBind();
            }

            //fill all contacts
            if (prospect[0].Contact != null && prospect[0].Contact[0] != null)
            {
                // Create contact data table
                CreateContactTable();
                Int64 ContactID;
                string strSaluctation = string.Empty;
                string strFirstName = string.Empty;
                string strMiddleName = string.Empty;
                string strLastName = string.Empty;
                string strPhone = string.Empty;
                string strPhoneExtension = string.Empty;
                string strFax = string.Empty;
                string strEmail = string.Empty;
                string strTitle = string.Empty;

                bool? blGender;
                string strContactNotes = string.Empty;
                // Insert All Record in Datatable
                //for (int icount = 0; icount < prospect[0].Contact.Length; icount++)
                for (int icount = 0; icount < prospect[0].Contact.Count; icount++)
                {
                    ContactID = prospect[0].Contact[icount].ContactID;
                    strSaluctation = prospect[0].Contact[icount].Title;
                    strFirstName = prospect[0].Contact[icount].FirstName;
                    strMiddleName = prospect[0].Contact[icount].MiddleName;
                    strLastName = prospect[0].Contact[icount].LastName;
                    strPhone = prospect[0].Contact[icount].PhoneOffice;
                    if (strPhone.Trim().Equals("(___)-___-____")) strPhone = "";

                    strPhoneExtension = prospect[0].Contact[icount].Phone1Extension;

                    strFax = prospect[0].Contact[icount].Fax;
                    if (strFax.Trim().Equals("(___)-___-____")) strFax = "";
                    strEmail = prospect[0].Contact[icount].EMail;
                    strTitle = prospect[0].Contact[icount].DesignationTitle;

                    //strRole = prospect[0].Contact[icount].Primary.ToString();
                    string strRole = string.Empty;
                    if (prospect[0].Contact[icount].ListProspectContactRole != null)
                    {
                        //for (int pcount = 0; pcount < prospect[0].Contact[icount].ListProspectContactRole.Length; pcount++)
                        for (int pcount = 0; pcount < prospect[0].Contact[icount].ListProspectContactRole.Count; pcount++)
                        {
                            strRole = strRole + prospect[0].Contact[icount].ListProspectContactRole[pcount].ProspectContactRoleID + ", ";
                        }
                        strRole = strRole.Remove(strRole.LastIndexOf(", "));
                    }

                    blGender = prospect[0].Contact[icount].Gender;
                    string strdob = prospect[0].Contact[icount].DateOfBirth;
                    string secondaryemail = prospect[0].Contact[icount].EmailWork;
                    string phonehome = prospect[0].Contact[icount].PhoneHome;
                    string phonecell = prospect[0].Contact[icount].PhoneCell;

                    strContactNotes = prospect[0].Contact[icount].ContactNotes[0].Notes;
                    SaveContact(ContactID, strSaluctation, strFirstName, strLastName, strMiddleName, strdob, phonehome, phonecell,
                                strPhone, strPhoneExtension, strEmail, secondaryemail, strTitle, blGender, strRole, strContactNotes, 0, strFax);
                }
                DisplayContacts();
            }
            if (prospect[0].ProspectType != null)
            {
                ddlHostType.SelectedValue = prospect[0].ProspectType.ProspectTypeID.ToString();
            }

            if (!prospect[0].ActualMembership.ToString().Equals("0"))
            {
                txtActualMembers.Text = prospect[0].ActualMembership.ToString();
            }
            else
            {
                txtActualMembers.Text = "";
            }
            if (!prospect[0].Attendance.ToString().Equals("0"))
            {
                txtAttendence.Text = prospect[0].Attendance.ToString();
            }
            else
            {
                txtAttendence.Text = "";
            }
            if (ddlFeederPromotionStatus.Items.FindByValue(prospect[0].WillCommunicate.ToString().Trim()).Value != null)
            {
                ddlFeederPromotionStatus.SelectedValue = prospect[0].WillCommunicate.ToString().Trim();
            }
            if (ddlFeederPromotionStatus.SelectedValue.Equals("0"))
            {
                spWillPromote.Style.Add(HtmlTextWriterStyle.Display, "block");
                txtWillPromote.Text = prospect[0].ReasonWillCommunicate.Trim();
            }
            int flagShowDivFee = 0;
            txtFacilitiesFee.Text = prospect[0].ProspectDetails.FacilitiesFee;
            if (prospect[0].ProspectDetails.FacilitiesFee != "")
            {
                flagShowDivFee = 1;
            }

            // checked payment method checkbox
            if (prospect[0].ProspectDetails.PaymentMethod.Length > 1)
            {
                chkPaymentMethod.Items[0].Selected = true;
                chkPaymentMethod.Items[1].Selected = true;
                flagShowDivFee = 1;
            }
            else
            {
                if (chkPaymentMethod.Items.FindByValue(prospect[0].ProspectDetails.PaymentMethod) != null)
                {
                    chkPaymentMethod.SelectedValue = prospect[0].ProspectDetails.PaymentMethod;
                    flagShowDivFee = 1;
                }
            }
            // Deposite requires checkbox
            if (prospect[0].ProspectDetails.DepositsRequire == 1)
            {
                rbtnDepositsRequired.Items[0].Selected = true;
                rbtnDepositsRequired.Items[1].Selected = false;
                spnDepositeAmount.Style.Add(HtmlTextWriterStyle.Display, "block");
                flagShowDivFee = 1;
            }
            else
            {
                rbtnDepositsRequired.Items[1].Selected = true;
                rbtnDepositsRequired.Items[0].Selected = false;
                spnDepositeAmount.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            txtAmount.Text = prospect[0].ProspectDetails.DepositsAmount.ToString();
            if (prospect[0].ProspectDetails.DepositsAmount != 0)
            {
                flagShowDivFee = 1;
            }

            if (flagShowDivFee == 1)
            {
                divFee.Style.Add(HtmlTextWriterStyle.Display, "block");
                rbtnFeeRequired.Items[1].Selected = false;
                rbtnFeeRequired.Items[0].Selected = true;
            }
            else
            {
                rbtnFeeRequired.Items[1].Selected = true;
                rbtnFeeRequired.Items[0].Selected = false;
                divFee.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (ddlhostStatus.Items.FindByValue(prospect[0].ProspectDetails.WillHost.ToString().Trim()) != null)
            {
                ddlhostStatus.SelectedValue = prospect[0].ProspectDetails.WillHost.ToString().Trim();
            }

            if (ddlViableHost.Items.FindByValue(prospect[0].ProspectDetails.ViableHostSite.ToString().Trim()) != null)
            {
                ddlViableHost.SelectedValue = prospect[0].ProspectDetails.ViableHostSite.ToString().Trim();
            }

            if (ddlHostedInPast.Items.FindByValue(prospect[0].ProspectDetails.HostedInPast.ToString().Trim()) != null)
            {
                ddlHostedInPast.SelectedValue = prospect[0].ProspectDetails.HostedInPast.ToString().Trim();
            }

            if (ddlhostStatus.SelectedValue.Equals("0"))
            {
                spWillHost.Style.Add(HtmlTextWriterStyle.Display, "block");
                txtWillHost.Text = prospect[0].ProspectDetails.ReasonWillHost;
            }
            if (ddlViableHost.SelectedValue.Equals("0"))
            {
                spViableHostSite.Style.Add(HtmlTextWriterStyle.Display, "block");
                txtViableHostSite.Text = prospect[0].ProspectDetails.ReasonViableHostSite;
            }
            if (ddlHostedInPast.SelectedValue.Equals("0"))
            {
                spHostInPast.Style.Add(HtmlTextWriterStyle.Display, "block");
                txtHostInPast.Text = prospect[0].ProspectDetails.ReasonHostedInPast;
            }

            if (prospect[0].ProspectDetails.HostedInPast == 1)
            {
                txtHostedInPast.Text = prospect[0].ProspectDetails.HostedInPastWith;
                spnHostedInPast.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else spnHostedInPast.Style.Add(HtmlTextWriterStyle.Display, "none");
            ddlProspectStatus.SelectedValue = prospect[0].Status;
        }

    }

    private long GetParentRoleIdByRoleId(long roleId)
    {
        var roleRepository = IoC.Resolve<IRoleRepository>();
        var role = roleRepository.GetByRoleId(roleId);

        if (role == null) return 0;

        return role.ParentId ?? 0;
    }

    private void SetCalCenterandTechnicianNotes(EProspect prospect)
    {
        if (prospect == null || !prospect.IsHost) return;

        var notes= IoC.Resolve<IHostRepository>().GetCallCenterandTechnicianNotesforgivenHost(prospect.ProspectID);
        if (notes == null) return;

        CallCenterNotesTextbox.Text = notes.FirstValue;
        TechnicianNotesTextbox.Text = notes.SecondValue;
    }

    /// <summary>
    /// Hosted In Past Text Dropdown.
    /// </summary>
    private void HostedInPastList()
    {
        OtherDAL otherDal = new OtherDAL();
        //TODO Drive it through Configuration
        string HealthFairCompetitor = otherDal.GetConfigurationValue("Competitor");
        if (!string.IsNullOrEmpty(HealthFairCompetitor))
        {
            char separator = '|';
            string[] names = HealthFairCompetitor.Split(separator);
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i] != "")
                {
                    this.Page.ClientScript.RegisterArrayDeclaration("HostedInPastWith", "'" + names[i] + "'");
                }
            }
            //reader.Close(); ;
            StringBuilder sb = new StringBuilder();
            sb.Append(" var obj = actb(document.getElementById('" + txtHostedInPast.ClientID + "'), HostedInPastWith);");
            this.Page.ClientScript.RegisterStartupScript(typeof(string), "jscodeHostedInPast", sb.ToString(), true);
        }
    }

    /// <summary>
    /// Load list of Franchiess
    /// </summary>
    void LoadFranchisee()
    {
        var organizationService = IoC.Resolve<IOrganizationService>();
        var franchiseeList = organizationService.GetOrganizationListModel(OrganizationType.Franchisee);
        if(franchiseeList!=null)
        {
            dgFranchiseeList.DataSource = franchiseeList.Organizations;
            dgFranchiseeList.DataBind();
        }
    }

    protected void UploadButton_Click(object sender, EventArgs e)
    {
        int counter = 1;

        counter = UploadHostImage(HostImageUploader, counter);

        HostImagesDataList.DataSource = HostImages;
        HostImagesDataList.DataBind();
    }

    private int UploadHostImage(FileUpload fileUploader, int counter)
    {
        if (fileUploader.FileName.Trim().Length < 1)
            return counter;

        var hostImage = new HostImageViewData();

        string fileExtension = new FileInfo(fileUploader.FileName).Extension;
        string fileName = "HostImage_" + DateTime.Now.ToFileTimeUtc() + counter + fileExtension;
        
        fileUploader.SaveAs(_physicalPath + fileName);
        hostImage.Path = _virtualPath + fileName;
        hostImage.Size = fileUploader.FileBytes.Length;
        hostImage.FileName = fileName;
        hostImage.ImageType = Convert.ToInt64(UploaderImageTypeDropDown.SelectedItem.Value);

        HostImages.Add(hostImage);
        return counter + 1;
    }

    protected void DeleteLinkButton_Click(object sender, EventArgs e)
    {
        LinkButton linkButton = (LinkButton)sender;
        int index = ((DataListItem)linkButton.NamingContainer).ItemIndex;

        HostImages.RemoveAt(index);

        HostImagesDataList.DataSource = HostImages;
        HostImagesDataList.DataBind();
    }

    private List<HostImage> FetchDatafromViewData()
    {
        var hostImageDO = new List<HostImage>();
        int index = 0;
        HostImages.ForEach(hostImage =>
        {
            hostImageDO.Add(new HostImage(hostImage.Id)
                {
                    Path = hostImage.FileName,
                    FileSize = hostImage.Size,
                    Title = hostImage.FileName,
                    Type = FileType.Image,
                    ImageType = GetHostImageType(index)
                }
                ); index++;
        });
        return hostImageDO;
    }

    private HostImageType GetHostImageType(int index)
    {
        if (HostImagesDataList.Items != null && HostImagesDataList.Items.Count > index)
        {
            var itemImage = HostImagesDataList.Items[index];

            var imageTypeDropDown = (DropDownList)itemImage.FindControl("ImageTypeDropDown");

            return HostImageType.HostImageTypes.Find(imageType => imageType.PersistenceLayerId == Convert.ToInt32(imageTypeDropDown.SelectedItem.Value));
        }

        return HostImageType.HostInfrastructure;
    }

    private void SaveHostImages(long hostId, OrganizationRoleUser organizationRoleUser)
    {
        var hostImagesToSave = FetchDatafromViewData();

        hostImagesToSave.ForEach(hostImage =>
        {
            if (hostImage.Id > 0) return;
            hostImage.UploadedBy = organizationRoleUser; hostImage.UploadedOn = DateTime.Now;
        });

        IHostRepository hostRepository = new HostRepository();
        var hostImagesAlreadyInDB = hostRepository.GetHostImages(hostId);

        if (hostImagesAlreadyInDB.Count > 0)
        {
            var hostImagesToBeDeleted = hostImagesAlreadyInDB.FindAll(hostImageInDb =>
            {
                var selectedRecord = hostImagesToSave.Find(hostImage => hostImage.Id == hostImageInDb.Id);
                if (selectedRecord == null) return true;
                return false;
            });
            if (hostImagesToBeDeleted.Count > 0)
                hostRepository.DeleteHostImages(hostId, hostImagesToBeDeleted.Select(hostImage => hostImage.Id).ToList());
        }

        if (hostImagesToSave.Count > 0)
        {
            var hostImages = hostImagesToSave.FindAll(hostImage => hostImage.Id < 1);
            if (hostImages.Count > 0)
                hostRepository.SaveHostImages(hostId, hostImages);

            hostImages = hostImagesToSave.FindAll(hostImage => hostImage.Id > 0);
            if (hostImages.Count > 0)
                hostRepository.UpdateHostImages(hostId, hostImages);
        }

    }


}
