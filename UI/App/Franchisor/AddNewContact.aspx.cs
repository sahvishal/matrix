using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;

public partial class App_Franchisor_AddNewContact : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Add New Contact";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Add New Contact");

        obj.hideucsearch();
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/ViewContact.aspx\">Contact</a>";
        
        if (!IsPostBack)
        {
            ViewState["ReferedURL"] = Request.UrlReferrer.PathAndQuery;
            if (ViewState["ReferedURL"] != null && ViewState["ReferedURL"].ToString() != "")
            {
                ViewState["ReferedURL"] = ViewState["ReferedURL"].ToString().Replace("&Action=Alert", "");
            }
            
            GetDropDownInfo();
            string ProspectID = string.Empty;
            string ContactID = string.Empty;
            if (Request.QueryString["ProspectID"] != null)
            {
                ProspectID = Request.QueryString["ProspectID"];
                ViewState["ProspectID"] = ProspectID;
                SelectHostProspect(Convert.ToInt32(ProspectID));
            }
            else if (Request.QueryString["HostID"] != null)
            {
                ProspectID = Request.QueryString["HostID"];
                ViewState["ProspectID"] = ProspectID;
                SelectHostProspect(Convert.ToInt32(ProspectID));
            }
            if (Request.QueryString["ContactID"] != null )
            {
                obj.settitle("Edit Contact");
                this.Page.Title = "Edit Contact";
                pgtitile.InnerHtml = "Edit Contact";
                ContactID = Request.QueryString["ContactID"];
                ViewState["ContactID"] = ContactID;
                this.FillContactData();
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void GetDropDownInfo()
    {
        MasterDAL masterDal = new MasterDAL();
        var objstate = masterDal.GetState(string.Empty, 3);

        ddlState.Items.Add(new ListItem("Select State", "0"));
        for (int jcount = 0; jcount < objstate.Count; jcount++)
        {
           ddlState.Items.Add(new ListItem(objstate[jcount].Name, objstate[jcount].StateID.ToString()));
        }

        ddlContactType.Items.Insert(0, new ListItem("Select Type", "0"));
        ddlContactType.Items.Insert(1, new ListItem("Work Contact", "1"));
        ddlContactType.Items.Insert(2, new ListItem("Non Work Contact", "2"));

        var prospectContactRoleRepository = IoC.Resolve<IProspectContactRoleRepository>(); 
        var listProspectContactRole = prospectContactRoleRepository.GetAllProspectContactRole();
        EProspectContactRole[] arrprospectcontactrole = null;

        if (listProspectContactRole != null)
        {
            var listproscontrole = new List<EProspectContactRole>();
            foreach (var drproscont in listProspectContactRole)
            {
                var objproscontrole = new EProspectContactRole();
                objproscontrole.ProspectContactRoleID = drproscont.FirstValue;
                objproscontrole.ProspectContactRoleName = drproscont.SecondValue;
                listproscontrole.Add(objproscontrole);
            }
            arrprospectcontactrole = listproscontrole.ToArray();
        }

        chklistContactRole.DataValueField = "ProspectContactRoleID";
        chklistContactRole.DataTextField = "ProspectContactRoleName";

        chklistContactRole.DataSource = arrprospectcontactrole;
        chklistContactRole.DataBind();

        if (Request.QueryString["PrimaryContact"] != null)
        {
            ListItem lsttemp = chklistContactRole.Items.FindByText("Primary Contact");
            if (lsttemp != null) lsttemp.Selected = true;
        }
    }

    private void SaveContact()
    {


        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        //FranchisorService service = new FranchisorService();
        EContact objContact = new EContact();

        //objContact.Address = new HealthYes.Web.UI.FranchisorService.EAddress();
        objContact.Address = new EAddress();

        //Now Address is not saved in TblAddress
                
        if (ViewState["ContactID"] != null)
        {
            objContact.ContactID = Convert.ToInt32(ViewState["ContactID"].ToString());
        }
        //Now Address is saved in TblContact only. No link with TblAddress
        objContact.Address.Address1 = txtAddress.Text;
        objContact.Address.City = txtCity.Text;
        objContact.Address.Country = "US";
        objContact.Address.State = ddlState.SelectedIndex > 0 ? ddlState.SelectedItem.Text : "";
        objContact.Address.Zip = txtZip.Text;

        objContact.EMail = txtEMail.Text;
        objContact.FirstName = txtFName.Text;
        objContact.MiddleName = txtMName.Text;
        objContact.LastName = txtLName.Text;
        objContact.OrganizationName = txtOrganisation.Text;
        objContact.WebSite = txtWebsite.Text;
        objContact.PhoneCell = objCommonCode.FormatPhoneNumber(txtPhoneCell.Text);
        objContact.PhoneHome = objCommonCode.FormatPhoneNumber(txtPhoneHome.Text);
        objContact.PhoneOffice = objCommonCode.FormatPhoneNumber(txtPhoneOffice.Text);
        objContact.Phone1Extension = txtExt.Text;
        objContact.Gender = rbtMale.Checked;
        objContact.DateOfBirth = txtBday.Text;
        objContact.DesignationTitle = txtJobtitle.Text;
        objContact.EmailWork = txtEmailOffice.Text;
                
        objContact.ContactType = Convert.ToInt32(ddlContactType.SelectedValue);
        objContact.Fax = objCommonCode.FormatPhoneNumber(txtFax.Text);
        objContact.Note = txtNotes.Text.Length > 0 ? txtNotes.Text : "";
        objContact.Title = txtTitle.Text;

        int prospectid = 0;
        prospectid = this.ExtractProspectID();

        if (prospectid > 0)
        {

            objContact.ArrayProspectIDs = new long[1];
            objContact.ArrayProspectIDs[0] = prospectid;

            int arraylength = 0;
            for (int icount = 0; icount < chklistContactRole.Items.Count; icount++)
            {
                if (chklistContactRole.Items[icount].Selected)
                    arraylength++;
            }
            if (arraylength > 0)
            {
                //int jcount = 0;
                //objContact.ListProspectContactRole = new EProspectContactRole[arraylength];
                objContact.ListProspectContactRole = new List<EProspectContactRole>();
                for (int icount = 0; icount < chklistContactRole.Items.Count; icount++)
                {
                    if (chklistContactRole.Items[icount].Selected)
                    {
                        objContact.ListProspectContactRole.Add(new EProspectContactRole()
                                                                   {
                                                                       ProspectContactRoleID =
                                                                           Convert.ToInt16(
                                                                           chklistContactRole.Items[icount].Value),
                                                                       ProspectID = prospectid
                                                                   });
                                                                             

                        //objContact.ListProspectContactRole[jcount] = new EProspectContactRole();
                        //objContact.ListProspectContactRole[jcount].ProspectContactRoleID = Convert.ToInt16(chklistContactRole.Items[icount].Value);
                        //objContact.ListProspectContactRole[jcount].ProspectID = prospectid;
                        //jcount++;
                    }
                }
            }
        }

        var currentsession = IoC.Resolve<ISessionContext>().UserSession;

        long tempResult;
        //bool tempResult1;

        if (ViewState["ContactID"] != null)
        {
            if (prospectid > 0)
            {
                //service.UpdateContactDetail(objContact, usershellmodulerole1, out tempResult, out tempResult1);
                tempResult = UpdateContactDetail(objContact, currentsession.UserId.ToString(), currentsession.CurrentOrganizationRole.OrganizationId.ToString(),
                                    currentsession.CurrentOrganizationRole.RoleId.ToString());
            }
            else
            {
                FranchisorDAL franchisorDAL = new FranchisorDAL();
                tempResult = franchisorDAL.SaveContact(objContact, Convert.ToInt32(EOperationMode.Update),
                                                               Convert.ToInt32(currentsession.UserId.ToString()));
                //service.UpdateContact(objContact, usershellmodulerole1, out tempResult, out tempResult1);
            }
        }
        else
        {
            if (prospectid > 0)
            {
                //service.SaveProspectContact(objContact, usershellmodulerole1, out tempResult, out tempResult1);
                tempResult = SaveProspectContact(objContact, currentsession.UserId.ToString(), currentsession.CurrentOrganizationRole.OrganizationId.ToString(),
                                    currentsession.CurrentOrganizationRole.RoleId.ToString());
            }
            else
            {
                FranchisorDAL franchisorDAL = new FranchisorDAL();
                tempResult = franchisorDAL.SaveContact(objContact, Convert.ToInt32(EOperationMode.Insert),
                                                       Convert.ToInt32(currentsession.UserId.ToString()));
                //service.SaveContact(objContact, usershellmodulerole1, out tempResult, out tempResult1);
            }
        }
        // Assign prospect to salesrep
        if (prospectid > 0)
        {
            if (currentsession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
            {
                Int64 iProspectId = prospectid;

                FranchisorDAL franchisorDAL = new FranchisorDAL();
                franchisorDAL.AssignProspect(1, iProspectId, Convert.ToInt64(currentsession.UserId));

                //service.AssignProspect(iProspectId, true, Convert.ToInt64(usershellmodulerole1.UserID), true);
            }
        }
        if (ViewState["ReferedURL"].ToString().ToLower().IndexOf("/createeventwizard/step1.aspx") >= 0)
        {
            string strUpdateProspectHost = "/App/Common/CreateEventWizard/Step1.aspx";
            if (Request.QueryString["EventId"] != null)
                strUpdateProspectHost = strUpdateProspectHost + "?EventId=" + Request.QueryString["EventId"];
            if (Request.QueryString["Type"] != null)
            {
                if (strUpdateProspectHost.IndexOf("?") >= 0)
                    strUpdateProspectHost = strUpdateProspectHost + "&HostID=" + ViewState["ProspectID"] + "&Type=Selected";
                else
                    strUpdateProspectHost = strUpdateProspectHost + "?HostID=" + ViewState["ProspectID"] + "&Type=Selected";
            }
            Response.RedirectUser(strUpdateProspectHost);
        }
        else
            Response.RedirectUser(ViewState["ReferedURL"].ToString());
        //Response.RedirectUser(ViewState["ReferedURL"].ToString());
    }

    public string StateId { get { return ddlState.SelectedValue; } }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="userID"></param>
    /// <param name="shell"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public Int64 SaveProspectContact(EContact contact, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        //Int64 returnresult = franchisorDAL.SaveNewProspectContact(contact, Convert.ToInt32(EOperationMode.Insert), prospectid, Convert.ToInt32(userID));
        Int64 returnresult = franchisorDAL.SaveContact(contact, Convert.ToInt32(EOperationMode.Insert), Convert.ToInt32(userID));
        if (returnresult > 0 && contact.ArrayProspectIDs != null)
        {
            foreach (Int64 prospectid in contact.ArrayProspectIDs)
            {
                franchisorDAL.SaveProspectContact(returnresult, prospectid, true);
                if (contact.ListProspectContactRole != null && contact.ListProspectContactRole.Count > 0)
                {
                    List<EProspectContactRole> listprospectcontactroleFORDAL = new List<EProspectContactRole>();
                    foreach (EProspectContactRole objproscontrole in contact.ListProspectContactRole)
                    {
                        if (objproscontrole.ProspectID == prospectid)
                            listprospectcontactroleFORDAL.Add(objproscontrole);
                    }

                    if (listprospectcontactroleFORDAL.Count > 0)
                        franchisorDAL.SaveProspectContactRoleMapping(listprospectcontactroleFORDAL, returnresult, prospectid);
                }
            }
        }

        return returnresult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="userID"></param>
    /// <param name="shell"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public Int64 UpdateContactDetail(EContact contact, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        //Int64 returnresult = franchisorDAL.SaveNewProspectContact(contact, Convert.ToInt32(EOperationMode.Update), prospectid, Convert.ToInt32(userID));
        Int64 returnresult = franchisorDAL.SaveContact(contact, Convert.ToInt32(EOperationMode.Update), Convert.ToInt32(userID));
        if (returnresult >= 0) returnresult = contact.ContactID;
        else returnresult = -1;

        if (returnresult > 0 && contact.ArrayProspectIDs != null)
        {
            foreach (Int64 prospectid in contact.ArrayProspectIDs)
            {
                franchisorDAL.SaveProspectContact(returnresult, prospectid, true);
                List<EProspectContactRole> listprospectcontactroleFORDAL = new List<EProspectContactRole>();
                if (contact.ListProspectContactRole != null && contact.ListProspectContactRole.Count > 0)
                {
                    foreach (EProspectContactRole objproscontrole in contact.ListProspectContactRole)
                    {
                        if (objproscontrole.ProspectID == prospectid)
                            listprospectcontactroleFORDAL.Add(objproscontrole);
                    }
                }
                //if (listprospectcontactroleFORDAL.Count > 0)
                franchisorDAL.SaveProspectContactRoleMapping(listprospectcontactroleFORDAL, returnresult, prospectid);
            }
        }
        return returnresult;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="iprospectid"></param>
    private void SelectHostProspect(int iprospectid)
    {
        if (iprospectid > 0)
        { 
            var hostRepository = IoC.Resolve<IHostRepository>(); 
            var prospect = hostRepository.GetProspectById(iprospectid);
            if (prospect != null)
            {
                rbtNone.Checked = false;
                if (prospect.IsHost)
                {
                    rbtHost.Checked = true;
                    txthost.Text = prospect.OrganizationName + "[ID:" + iprospectid + "]";
                    ClientScript.RegisterStartupScript(typeof(string), "jshandlecontactrel", " onclickHost();", true);
                }
                else
                {
                    rbtprospect.Checked = true;
                    txtprospect.Text = prospect.OrganizationName + "[ID:" + iprospectid + "]";
                    ClientScript.RegisterStartupScript(typeof(string), "jshandlecontactrel", " onclickProspect();", true);
                }
            }

            if (Request.QueryString["ProspectID"] != null || Request.QueryString["HostID"] != null)
            {
                rbtHost.Enabled = false;
                rbtprospect.Enabled = false;
                rbtNone.Enabled = false;
                txthost.Enabled = false;
                txtprospect.Enabled = false;
            }
        }
    }

    /// <summary>
    /// Extract ProspectID from Host or Prospect TextBox.
    /// </summary>
    /// <returns></returns>
    private int ExtractProspectID()
    {
        int iprospectid = 0;
        string prospectstring = "";

        if (rbtHost.Checked)
        {
            prospectstring = txthost.Text;
        }
        else if (rbtprospect.Checked)
        {
            prospectstring = txtprospect.Text;
        }
        
        if (prospectstring.Trim().Length < 1) return 0;

        if (!Int32.TryParse(prospectstring, out iprospectid))
        {
            prospectstring = prospectstring.IndexOf("[") >= 0 ? prospectstring.Substring(prospectstring.IndexOf("["), prospectstring.IndexOf("]") - prospectstring.IndexOf("[") + 1) : prospectstring;
            prospectstring = prospectstring.IndexOf("ID:") >= 0 ? prospectstring.Substring(prospectstring.IndexOf(":") + 1, prospectstring.IndexOf("]") - prospectstring.IndexOf(":") - 1) : "0";
            Int32.TryParse(prospectstring, out iprospectid);
        }

        return iprospectid;
    }

    private void FillContactData()
    {
        //FranchisorService service = new FranchisorService();
        EContact contact = null;

        int iprospectid = 0;

        FranchisorDAL objDAL = new FranchisorDAL();
        contact = objDAL.GetContactByID(Convert.ToInt32(ViewState["ContactID"].ToString()), 0, out iprospectid);

        //contact = service.GetContactByID(Convert.ToInt32(ViewState["ContactID"].ToString()), true, out iprospectid, out bolprospectid);

        SelectHostProspect(iprospectid);

        if (contact != null)
        {
            
            txtAddress.Text=contact.Address.Address1;
            txtCity.Text=contact.Address.City;
            
            if (ddlState.Items.FindByText(contact.Address.State) != null)
                ddlState.Items.FindByText(contact.Address.State).Selected = true;

            txtZip.Text = contact.Address.Zip;
            txtEMail.Text = contact.EMail;
            txtFName.Text = contact.FirstName;
            txtMName.Text = contact.MiddleName;
            txtLName.Text = contact.LastName;
            txtOrganisation.Text = contact.OrganizationName;
            txtWebsite.Text = contact.WebSite;
            txtPhoneCell.Text = contact.PhoneCell;
            txtPhoneHome.Text = contact.PhoneHome;
            txtPhoneOffice.Text = contact.PhoneOffice;
            txtExt.Text = contact.Phone1Extension;

            if (contact.DateOfBirth.Trim().Length > 0) txtBday.Text = Convert.ToDateTime(contact.DateOfBirth).ToString("MM/dd/yyyy");
            
            txtEmailOffice.Text = contact.EmailWork;

            txtFax.Text = contact.Fax;
            ddlContactType.SelectedValue = contact.ContactType.ToString();
            if (contact.Gender.ToString().Equals("True"))
                rbtMale.Checked = true;
            else
                rbtFeMale.Checked = true;

            txtNotes.Text = contact.Note;
            txtTitle.Text = contact.Title;
            txtJobtitle.Text = contact.DesignationTitle;

            //if (contact.ListProspectContactRole != null && contact.ListProspectContactRole.Length > 0)
            if (contact.ListProspectContactRole != null && contact.ListProspectContactRole.Count > 0)
            {
                foreach (EProspectContactRole objprospectcontactrole in contact.ListProspectContactRole)
                {
                    if (chklistContactRole.Items.FindByValue(objprospectcontactrole.ProspectContactRoleID.ToString()) != null)
                        chklistContactRole.Items.FindByValue(objprospectcontactrole.ProspectContactRoleID.ToString()).Selected = true;
                }
            }
        }
               
    }

    protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
    {
        SaveContact();        
    }

    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        if (ViewState["ReferedURL"].ToString().ToLower().IndexOf("/createeventwizard/step1.aspx") >= 0)
        {
            string strUpdateProspectHost = "/App/Common/CreateEventWizard/Step1.aspx";
            if (Request.QueryString["EventId"] != null)
                strUpdateProspectHost = strUpdateProspectHost + "?EventId=" + Request.QueryString["EventId"];
            if (Request.QueryString["Type"] != null)
            {
                if (strUpdateProspectHost.IndexOf("?") >= 0)
                    strUpdateProspectHost = strUpdateProspectHost + "&HostID=" + ViewState["ProspectID"] + "&Type=Selected";
                else
                    strUpdateProspectHost = strUpdateProspectHost + "?HostID=" + ViewState["ProspectID"] + "&Type=Selected";
            }
            Response.RedirectUser(strUpdateProspectHost);
        }
        else
            Response.RedirectUser(ViewState["ReferedURL"].ToString());
        //Response.RedirectUser(ViewState["ReferedURL"].ToString());
    }

}
