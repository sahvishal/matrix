using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using Falcon.Entity.Other;
using Falcon.Entity.User;
using Falcon.DataAccess.Master;
using System.Collections.Generic;

public partial class App_Franchisor_AddCallProspect : System.Web.UI.Page
{
    # region Event

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Add New Call";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Add Call");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        if (!string.IsNullOrEmpty(Request["IsHost"]) && Request["IsHost"].Equals("True"))
        {
            heading.InnerText = "Add Call To Host";
            lnkEditProspect.Text = "Edit Host";
            spnName.InnerText = "Host Name:";
            spnAddress.InnerHtml = "Host Address:";
            spnType.InnerText = "Host Type:";
            hfProspectType.Value = "Host";
        }
        else
        {
            heading.InnerText = "Add Call To Prospect";
            lnkEditProspect.Style.Add(HtmlTextWriterStyle.Display, "block");
            lnkEditProspect.Style.Add(HtmlTextWriterStyle.Visibility, "visible");
            spnName.InnerText = "Prospect Name:";
            spnAddress.InnerText = "Prospect Address:";
            spnType.InnerText = "Prospect Type:";
            hfProspectType.Value = "Prospect";
            lnkEditProspect.Text = "Edit Prospect";
        }

        if (Request.QueryString["ContactCallID"] == null)
        {
            //txtContact.Text = hfContactName.Value;
        }

        // Set Tab Status
        if (!string.IsNullOrEmpty(HidTabStatus.Value))
        {
            if (HidTabStatus.Value.Equals("1"))
            {
                // Show Call Details
                DivCallDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                imgBtnCallDetails.ImageUrl = "/App/Images/MarketingPartner/calldetails-tab-on.gif";
                imgBtnCallHistory.ImageUrl = "/App/Images/MarketingPartner/history-taboff.gif";
                DivCallHistory.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            else if (HidTabStatus.Value.Equals("2"))
            {
                // Show Call Details
                DivCallDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                imgBtnCallDetails.ImageUrl = "/App/Images/MarketingPartner/calldetails-tab-off.gif";
                imgBtnCallHistory.ImageUrl = "/App/Images/MarketingPartner/history-tabon.gif";
                DivCallHistory.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
        }
        if (!Page.IsPostBack)
        {
            // Fill Default Date and Time
            txtStartDate.Text = string.Format("{0:d}", DateTime.Now);
            txtStartTime.Text = string.Format("{0:t}", DateTime.Now);

            ViewState["SortDir"] = SortDirection.Descending;
            ViewState["SortExp"] = "StartDate";

            radioNone.Attributes.Add("onclick", "hideDivFollwoUpAction();");
            radioFollowAction.Attributes.Add("onclick", "ShowDivFollwoUpAction();");
            chkboxCall.Attributes["onClick"] = "HideShowCall();";
            chkboxMeeting.Attributes["onClick"] = "HideShowMeeting();";
            chkboxTask.Attributes["onClick"] = "HideShowTask();";

            dropdowninfo();
            FillDuration();

            // Fill all the contacts
            FillContactList();

            if (!string.IsNullOrEmpty(Request.QueryString["ProspectID"]))
            {
                divProspectDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                Int64 ProspectId = 0;
                ProspectId = Convert.ToInt64(Request.QueryString["ProspectID"]);
                hfProspectID.Value = ProspectId.ToString();
                ViewState["ProspectID"] = ProspectId.ToString();
                hfProsectID.Value = ProspectId.ToString();
                GetProspectDetails(ProspectId);
                LoadGrids(Convert.ToInt32(ProspectId));
                if (!string.IsNullOrEmpty(Request["ContactID"]))
                {
                    hidContactID.Value = Request["ContactID"];
                    ClientScript.RegisterStartupScript(typeof(string), "jscodeselectcontact", "SelectContact();", true);
                }
            }
            else
            {
                divProspectDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                divTab.Style.Add(HtmlTextWriterStyle.Display, "none");
                divBtnCloseNCreate.Style.Add(HtmlTextWriterStyle.Display, "none");
            }

            if (Request.QueryString["Date"] != null)
            {
                string strDate = Request.QueryString["Date"].ToString();
                DateTime dtEventDate;


                if (DateTime.TryParse(strDate, out dtEventDate) == true)
                {
                    txtStartDate.Text = dtEventDate.ToShortDateString();

                }
            }
            if (Request.QueryString["Parent"] != null)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["trk_url"]) && Request.QueryString["trk_url"].Length > 0)
                {
                    ViewState["ReferedURL"] = Request.QueryString["trk_url"];
                }
                else
                {
                    ViewState["ReferedURL"] = Request.UrlReferrer.PathAndQuery;
                }
            }
            if (Request.QueryString["ContactCallID"] != null)
            {
                heading.InnerText = "Edit Call";
                obj.settitle("Edit Call");
                this.Page.Title = "Edit Call";
                ViewState["ContactCallID"] = Request.QueryString["ContactCallID"];
                this.FillCall();
                divBtnCloseNCreate.Style.Add(HtmlTextWriterStyle.Display, "none");

            }
        }

    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        // Save Call
        bool value = SaveCall(true);
        if (value == false)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "alert('This is not valid user,Please complete the information');", true);
            return;
        }
        // Redirect to page
        if (Request.QueryString["ProspectID"] != null)
        {
            if (Request.QueryString["IsHost"] != null)
                Response.RedirectUser("../Franchisee/SalesRep/SalesRepManageHost.aspx");
            else
                Response.RedirectUser("../Franchisee/SalesRep/SalesRepManageProspects.aspx");
        }
        else
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ViewCall.aspx"));
        }
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        if (Request.QueryString["Referrer"] != null)
        {
            string strReferrer = Request.QueryString["Referrer"].ToString();
            if ((strReferrer != string.Empty) && (strReferrer == "Calendar"))
            {
                Response.RedirectUser(this.ResolveUrl("~/App/Common/Calendar.aspx"));
            }
        }
        else if (Request.QueryString["Parent"] != null)
        {
            if (ViewState["ReferedURL"] != null && ViewState["ReferedURL"].ToString() != "")
            {
                ViewState["ReferedURL"] = ViewState["ReferedURL"].ToString().Replace("&Action=Alert", "");
            }
            Response.RedirectUser(ViewState["ReferedURL"].ToString());
        }
        else
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ViewCall.aspx"));
        }

    }

    protected void btnCloseAndCreate_Click(object sender, ImageClickEventArgs e)
    {
        //ConatctForm.Style.Add("display", "block");

        if (Session["Popup"] == null)
        {
            bool value = SaveCall(false);
            DateTime dt = Convert.ToDateTime(string.Format("{0:T}", txtStartTime.Text));
            int Hour = Convert.ToInt16(dt.ToString("hh"));

            if ((dt.Minute > 60) || (dt.Second >= 60) || (Hour > 12))
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscode", "alert('This is not Valid Time');", true);
                return;
            }
            if (value == false)
            {
                ClientScript.RegisterStartupScript(typeof(string), "jscode", "alert('This is not valid user,Please complete the information');", true);
                return;
            }
            // Reset all values
            txtSubject.Text = "";
            txtNotes.Text = "";
            txtCallStartDate.Text = "";
            txtCallSubject.Text = "";
            txtCallStartTime.Text = "";
            txtMeetingStartDate.Text = "";
            txtVenue.Text = "";
            txtMeetingStartTime.Text = "";
            txtTask.Text = "";

            if (!string.IsNullOrEmpty(Request.QueryString["ProspectID"]))
            {
                Session["Popup"] = null;
                LoadGrids(Convert.ToInt32(Request.QueryString["ProspectID"]));
                ClientScript.RegisterStartupScript(typeof(string), "jscodecalladded", "alert('Call added sucessfully.');", true);
            }
        }
        else
        {
            Session["Popup"] = null;
        }
    }

    /// <summary>
    /// Save contact in datatable
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnSaveContact_Click(object sender, ImageClickEventArgs e)
    {
        SaveContact();
    }

    protected void grdContacts_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            RadioButton rbt = (RadioButton)e.Row.FindControl("rbtnPCP");

            if (rbt != null)
            {
                rbt.Attributes["onClick"] = "return PCPSelect(" + rbt.ClientID + ")";
            }
        }
    }

    protected void HandleSave(object sender, EventArgs e)
    {
        SaveContact();

    }
    #endregion

    # region Functions


    private void FillCall()
    {
        MasterDAL masterDal = new MasterDAL();
        //// 
        List<EContactCall> calls = masterDal.GetCalls(ViewState["ContactCallID"].ToString(), 1, IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId, 0);

        if (calls != null)
        {
            divGridContacts.Style.Add(HtmlTextWriterStyle.Display, "none");
            divFutureAction.Style.Add(HtmlTextWriterStyle.Display, "none");
            lnkNewContact.Visible = false;

            if (calls.Count > 0)
            {
                ViewState["ContactCallID"] = calls[0].ContactCallID;
                txtSubject.Text = calls[0].Subject;

                txtStartDate.Text = !string.IsNullOrEmpty(calls[0].StartDate)
                                        ? Convert.ToDateTime(calls[0].StartDate).ToShortDateString()
                                        : "";

                txtStartTime.Text = !string.IsNullOrEmpty(calls[0].StartTime) ? Convert.ToString(Convert.ToDateTime(calls[0].StartTime).ToShortTimeString()) : "";

                ddlType.SelectedValue = calls[0].IsInbound ? Convert.ToString(1) : Convert.ToString(2);
                ddlStatus.SelectedValue = Convert.ToString(calls[0].CallStatus.CallStatusID);
                txtNotes.Text = calls[0].Notes;

                // Fill Duration
                int Duration = Convert.ToInt32(calls[0].Duration);
                if (Duration > 0)
                {
                    if (ddlDuration.Items.FindByValue(Duration.ToString()) != null)
                    {
                        ddlDuration.Items.FindByValue(Duration.ToString()).Selected = true;
                    }
                }
                // select call result radio button
                if (calls[0].CallResult == 1)
                {
                    rbnCallResultNoAnswer.Checked = true;
                }
                else if (calls[0].CallResult == 2)
                {
                    rbnCallResultLeftVoiceMail.Checked = true;
                }
                else if (calls[0].CallResult == 3)
                {
                    rbnCallResultTaledToPerson.Checked = true;
                }
            }

        }
    }

    private void dropdowninfo()
    {
        Gettypes();
        Getstatus();
    }

    private void Getstatus()
    {

        //ContactCallService service = new ContactCallService();
        //HealthYes.Web.UI.ContactCallService.ECallStatus[] status = service.GetAllActiveCallStatus();     

        MasterDAL objcallstatusDAl = new MasterDAL();
        //Mode '3' is used here for fetching All Active Call Statuses
        var listCallStatus = objcallstatusDAl.GetCallStatusType(string.Empty, 3);
        ECallStatus[] status = null;
        if (listCallStatus != null) status = listCallStatus.ToArray();

        if (status.Length > 0)
        {
            //ddlStatus.Items.Add(new ListItem("Select Status", "0"));
            for (int count = 0; count < status.Length; count++)
            {
                ddlStatus.Items.Add(new ListItem(status[count].Status.ToString(), status[count].CallStatusID.ToString()));
            }
            if (ddlStatus.Items.FindByText("Held") != null)
            {
                ddlStatus.Items.FindByText("Held").Selected = true;
            }

        }
    }

    private void Gettypes()
    {
        //ddlType.Items.Add(new ListItem("Select Type", "0"));
        ddlType.Items.Add(new ListItem("Inbound", "1"));
        ddlType.Items.Add(new ListItem("Outbound", "2"));

        if (ddlType.Items.FindByText("Outbound") != null)
        {
            ddlType.Items.FindByText("Outbound").Selected = true;
        }
    }


    private bool SaveCall(bool BlnSaveAndCreate)
    {

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        string strUser = null;
        string strRole = null;
        string strShell = null;

        MasterDAL masterDal = new MasterDAL();
        ClientScript.RegisterStartupScript(typeof(string), "jscodereturnallcontacts", "", true);


        long temp;
        Int64 ProspectID = 0;
        decimal minutes = 0;
        int CallResult = 0;


        EContactCall call = new EContactCall();

        call.CallStatus = new ECallStatus();
        call.Contact = new EContact();

        if (ViewState["ContactCallID"] != null)
        {
            call.ContactCallID = Convert.ToInt32(ViewState["ContactCallID"]);
        }

        call.Subject = txtSubject.Text;
        call.Notes = txtNotes.Text;
        call.IsInbound = (ddlType.SelectedItem.Text.Equals("Inbound")) ? true : false;
        call.StartDate = txtStartDate.Text;
        call.StartTime = txtStartTime.Text;
        minutes = Convert.ToInt32(ddlDuration.SelectedValue);
        call.Duration = minutes;

        call.AssignedToUserId = Convert.ToInt32(strUser);
        call.AssignedToShellID = Convert.ToInt32(strShell);
        call.AssignedToRoleID = Convert.ToInt32(strRole);


        call.CreatedByUserId = Convert.ToInt32(currentSession.UserId);
        call.CreatedByShellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
        call.CreatedByRoleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);
        call.CallStatus.CallStatusID = Convert.ToInt32(ddlStatus.SelectedValue);

        if (rbnCallResultNoAnswer.Checked == true)
        {
            CallResult = 1;
        }
        else if (rbnCallResultLeftVoiceMail.Checked == true)
        {
            CallResult = 2;
        }
        else if (rbnCallResultTaledToPerson.Checked == true)
        {
            CallResult = 3;
        }
        call.CallResult = CallResult;
        int FutureAction = 0;

        if (rbnCallResultTaledToPerson.Checked == true)
        {
            FutureAction = 1;
        }
        call.FutureAction = FutureAction;

        // If Call subject is blank
        if (txtSubject.Text == null || txtSubject.Text.Trim() == "")
        {
            call.Subject = "No Subject";
            call.CallResult = 1;
        }

        // Assign Prospect
        if (!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            ProspectID = Convert.ToInt64(Request["ProspectID"]);
        }
        call.ProspectID = ProspectID;

        if (!string.IsNullOrEmpty(HidAllContactID.Value))
        {
            string strAllContact = HidAllContactID.Value;
            string[] strAllContactCall = strAllContact.Split(',');

            if (strAllContactCall.Length > 0)
            {
                for (int i = 0; i < strAllContactCall.Length; i++)
                {
                    if (!string.IsNullOrEmpty(strAllContactCall[i]))
                    {
                        EContactCall ContactCall = new EContactCall();
                        ContactCall.CallStatus = new ECallStatus();
                        ContactCall.Contact = new EContact();

                        ContactCall.Contact.ContactID = Convert.ToInt32(strAllContactCall[i]);

                        ContactCall.IsActive = true;
                        ContactCall.CreatedByUserId = call.CreatedByUserId;
                        ContactCall.CreatedByShellID = call.CreatedByShellID;
                        ContactCall.CreatedByRoleID = call.CreatedByRoleID;
                        ContactCall.AssignedToUserId = call.AssignedToUserId;
                        ContactCall.AssignedToShellID = call.AssignedToShellID;
                        ContactCall.AssignedToRoleID = call.AssignedToRoleID;
                        ContactCall.ProspectID = call.ProspectID;
                        ContactCall.IsInbound = call.IsInbound;
                        ContactCall.Duration = call.Duration;
                        ContactCall.CallResult = call.CallResult;
                        ContactCall.FutureAction = call.FutureAction;
                        ContactCall.Subject = call.Subject;
                        ContactCall.Notes = call.Notes;
                        ContactCall.StartDate = call.StartDate;
                        ContactCall.StartTime = call.StartTime;
                        ContactCall.CallStatus.CallStatusID = call.CallStatus.CallStatusID;


                        if (ViewState["ContactCallID"] != null)
                        {
                            if (ViewState["ContactCallID"].ToString() != string.Empty)
                            {
                                temp = masterDal.SaveCall(ContactCall, Convert.ToInt32(EOperationMode.Update));
                            }
                        }
                        else
                        {
                            temp = masterDal.SaveCall(ContactCall, Convert.ToInt32(EOperationMode.Insert));
                        }
                    }
                }
            }
        }
        else
        {
            if (ViewState["ContactCallID"] != null)
            {
                if (ViewState["ContactCallID"].ToString() != string.Empty)
                {
                    temp = masterDal.SaveCall(call, Convert.ToInt32(EOperationMode.Update));
                }
            }
            else
            {
                temp = masterDal.SaveCall(call, Convert.ToInt32(EOperationMode.Insert));
            }
        }

        // Add Call 
        if (chkboxCall.Checked)
        {
            EContactCall FollowUpCall = new EContactCall();

            FollowUpCall.CallStatus = new ECallStatus();
            FollowUpCall.Contact = new EContact();

            FollowUpCall.IsActive = true;
            FollowUpCall.CreatedByUserId = call.CreatedByUserId;
            FollowUpCall.CreatedByShellID = call.CreatedByShellID;
            FollowUpCall.CreatedByRoleID = call.CreatedByRoleID;
            FollowUpCall.AssignedToUserId = call.AssignedToUserId;
            FollowUpCall.AssignedToShellID = call.AssignedToShellID;
            FollowUpCall.AssignedToRoleID = call.AssignedToRoleID;
            FollowUpCall.Contact.ContactID = call.Contact.ContactID;
            FollowUpCall.ProspectID = call.ProspectID;
            FollowUpCall.IsInbound = call.IsInbound;
            FollowUpCall.Duration = 0;
            FollowUpCall.ContactCallID = call.ContactCallID;
            FollowUpCall.CallResult = 0;
            FollowUpCall.FutureAction = 0;

            // 
            FollowUpCall.Subject = txtCallSubject.Text;
            FollowUpCall.Notes = "";
            FollowUpCall.StartDate = txtCallStartDate.Text;
            FollowUpCall.StartTime = txtCallStartTime.Text;

            temp = masterDal.SaveCall(FollowUpCall, Convert.ToInt32(EOperationMode.Insert));
        }
        //Add Meeting 
        if (chkboxMeeting.Checked)
        {
            EContactMeeting objEContactMeeting = new EContactMeeting();
            objEContactMeeting.Contact = new EContact();
            objEContactMeeting.CallStatus = new ECallStatus();

            objEContactMeeting.StartDate = txtMeetingStartDate.Text;
            objEContactMeeting.StartTime = txtMeetingStartTime.Text;
            objEContactMeeting.Venue = txtVenue.Text;
            objEContactMeeting.Subject = "";
            objEContactMeeting.Description = "";
            objEContactMeeting.AssignedToUserId = call.AssignedToUserId;
            objEContactMeeting.AssignedToShellID = call.AssignedToShellID;
            objEContactMeeting.AssignedToRoleID = call.AssignedToRoleID;
            objEContactMeeting.CreatedByUserId = call.CreatedByUserId;
            objEContactMeeting.CreatedByShellID = call.CreatedByShellID;
            objEContactMeeting.CreatedByRoleID = call.CreatedByRoleID;
            objEContactMeeting.Contact.ContactID = call.Contact.ContactID;
            objEContactMeeting.ProspectID = call.ProspectID;

            temp = masterDal.SaveMeeting(objEContactMeeting, Convert.ToInt32(EOperationMode.Insert));
        }

        // Add Task
        if (chkboxTask.Checked)
        {
            if ((!string.IsNullOrEmpty(txtTask.Text)) || (!string.IsNullOrEmpty(txtTaskDueDate.Text)) ||
                (!string.IsNullOrEmpty(txtTaskDueTime.Text)))
            {
                var task = new ETask();

                task.TaskStatusType = new Falcon.Entity.Other.ETaskStatusType();
                task.TaskPriorityType = new Falcon.Entity.Other.ETaskPriorityType();
                task.TaskType = new Falcon.Entity.Other.ETaskType();
                task.UserShellModule = new Falcon.Entity.User.EUserShellModuleRole();
                
                task.Active = true;
                task.Subject = txtTask.Text;
                if (txtTaskDueDate.Text != "")
                    task.DueDate = txtTaskDueDate.Text;
                if (txtTaskDueTime.Text != "")
                    task.DueTime = txtTaskDueTime.Text;
                task.Notes = "";
                task.StartDate = DateTime.Now.ToString();
                task.StartTime = DateTime.Now.ToString();


                task.UserShellModule.ShellID = currentSession.CurrentOrganizationRole.OrganizationId.ToString();
                task.UserShellModule.RoleShellID = (int)currentSession.CurrentOrganizationRole.OrganizationRoleUserId;
                task.UserShellModule.RoleID = currentSession.CurrentOrganizationRole.RoleId.ToString();
                task.UserShellModule.UserID = currentSession.UserId.ToString();

                task.ProspectID = call.ProspectID;
                task.ContactID = call.Contact.ContactID;
                task.CreatedBY = Convert.ToInt32(currentSession.UserId);
                task.ModifiedBY = task.CreatedBY;


                temp = masterDal.SaveTask(task, Convert.ToInt32(EOperationMode.Insert),
                                          currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                          currentSession.CurrentOrganizationRole.RoleId.ToString());

            }
        }
        // Assign prospect to salesrep
        if (ProspectID > 0)
        {
            if (currentSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
            {
                FranchisorDAL franchisorDAL = new FranchisorDAL();
                franchisorDAL.AssignProspect(1, ProspectID, Convert.ToInt64(currentSession.UserId));
            }
        }

        // If Redirect Specify
        if (BlnSaveAndCreate)
        {
            if (Request.QueryString["Referrer"] != null)
            {
                string strReferrer = Request.QueryString["Referrer"].ToString();
                if ((strReferrer != string.Empty) && (strReferrer == "Calendar"))
                {
                    Response.RedirectUser(this.ResolveUrl("~/App/Common/Calendar.aspx"));
                }
            }
            else if (Request.QueryString["Parent"] != null)
            {
                if (ViewState["ReferedURL"] != null && ViewState["ReferedURL"].ToString() != "")
                {
                    ViewState["ReferedURL"] = ViewState["ReferedURL"].ToString().Replace("&Action=Alert", "");
                }

                Response.RedirectUser(ViewState["ReferedURL"].ToString());
            }
        }
        return true;
    }

    //saves new contact
    private void SaveContact()
    {
        if (Session["Popup"] != null && (string)Session["Popup"] != "")
        {
            if (Session["Popup"].Equals("True"))
            {
                Session["Popup"] = null;
                // Fill Contact With Grid.
                FillContactList();
                return;
            }
        }


        int rownumber = 0;

        EContact objContact = ucMiniAddNewContact1.GetFields(out rownumber);

        objContact.Address = new EAddress();

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        long tempResult = 0;

        // empty address fields
        objContact.Address.City = "";
        objContact.Address.State = "";
        objContact.Address.Country = "";
        objContact.Address.Address1 = "";
        objContact.Address.Address2 = "";
        objContact.Address.Zip = "";

        // Save contact as well as prospect contact
        if (ViewState["ProspectID"] != null && Request["ProspectID"] != "")
        {
            Int64[] iProspectID = new Int64[1];
            iProspectID[0] = Convert.ToInt64(ViewState["ProspectID"]);
            objContact.ArrayProspectIDs = iProspectID;

            //for (int i = 0; i < objContact.ListProspectContactRole.Length; i++)
            for (int i = 0; i < objContact.ListProspectContactRole.Count; i++)
            {
                objContact.ListProspectContactRole[i].ProspectID = iProspectID[0];
            }
            if (!string.IsNullOrEmpty(hidContactIDEdit.Value))
            {
                objContact.ContactID = Convert.ToInt32(hidContactIDEdit.Value);

                tempResult = this.UpdateContactDetail(objContact, currentSession.UserId.ToString(),
                                                      currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                                      currentSession.CurrentOrganizationRole.RoleId.ToString());

            }
            else
            {
                tempResult = this.SaveProspectContact(objContact, currentSession.UserId.ToString(),
                                                      currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                                      currentSession.CurrentOrganizationRole.RoleId.ToString());

            }
        }


        if (tempResult >= 0)
        {

            if (!string.IsNullOrEmpty(hidContactIDEdit.Value))
            {
                hidContactIDEdit.Value = null;
                ClientScript.RegisterStartupScript(typeof(string), "sfjscodecontact", "alert('Contact updated successfully.');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(typeof(string), "sfjscodecontact", "alert('Contact added successfully.');", true);
            }
            ModalPopupExtender1.Hide();
            // Fill Contact With Grid.
            FillContactList();
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(string), "sfjscodecontact", "alert('Contact not added successfully.');", true);
            ModalPopupExtender1.Hide();
        }
    }

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

    private void FillDuration()
    {
        ListItem li;
        for (int i = 5; i <= 100; i += 5)
        {
            li = new ListItem();
            li.Text = i.ToString() + " mins";
            li.Value = i.ToString();
            ddlDuration.Items.Add(li);
        }
    }
    private void FillContactList()
    {
        //GetContactByProspect
        if (!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            Int64 ProspectId = Convert.ToInt64(Request["ProspectID"]);

            FranchisorDAL objDAL = new FranchisorDAL();
            var listContacts = objDAL.GetContactByProspect(ProspectId, 0);

            EContact[] objContacts = null;
            if (listContacts != null) objContacts = listContacts.ToArray();

            DataTable tbltemp = new DataTable();

            tbltemp.Columns.Add("ContactID");
            tbltemp.Columns.Add("FullName");
            tbltemp.Columns.Add("Title");
            tbltemp.Columns.Add("Notes");

            if (objContacts != null && objContacts.Length > 0)
            {
                string Notes = string.Empty;
                for (int i = 0; i < objContacts.Length; i++)
                {
                    Notes = objContacts[i].ContactNotes[0].Notes;
                    if (Notes == "") Notes = "Not Available";
                    tbltemp.Rows.Add(objContacts[i].ContactID, objContacts[i].FirstName + " " + objContacts[i].LastName, objContacts[i].DesignationTitle, Notes);
                }
            }
            tbltemp.DefaultView.Sort = "FullName asc";
            grdContacts.DataSource = tbltemp;
            grdContacts.DataBind();

        }
    }


    private void GetProspectDetails(Int64 prospectid)
    {
        int iprospectid = Convert.ToInt32(prospectid);

        List<EProspect> prospects = null;
        FranchisorDAL objDAL = new FranchisorDAL();

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        if (!string.IsNullOrEmpty(Request["IsHost"]))
        {
            if (Request["IsHost"].Equals("True"))
            {
                prospects = objDAL.GetHostDetails(iprospectid.ToString(), 1);
            }
            else
            {
                prospects = objDAL.GetProspectDetails(iprospectid.ToString(), 4);
            }
        }
        else
        {
            prospects = objDAL.GetProspectDetails(iprospectid.ToString(), 4);
        }

        if (prospects != null)
        {
            spProspectName2.InnerText = prospects[0].OrganizationName.ToString();
            string strAddress = string.Empty;

            //txtProspectNotes.Text = prospect[0].Notes;

            // Address
            if (!string.IsNullOrEmpty(prospects[0].Address.Address1))
            {
                strAddress = strAddress + prospects[0].Address.Address1 + ", ";
            }
            // Suit
            if (!string.IsNullOrEmpty(prospects[0].Address.Address2))
            {
                strAddress = strAddress + prospects[0].Address.Address2 + ", ";
            }
            // City
            if (!string.IsNullOrEmpty(prospects[0].Address.City))
            {
                strAddress = strAddress + HttpUtility.HtmlEncode(prospects[0].Address.City) + ", ";
            }
            // State
            if (!string.IsNullOrEmpty(prospects[0].Address.State))
            {
                strAddress = strAddress + HttpUtility.HtmlEncode(prospects[0].Address.State) + ", ";
            }
            // ZipID
            if (prospects[0].Address.ZipID > 0)
            {
                strAddress = strAddress + HttpUtility.HtmlEncode(prospects[0].Address.ZipID) + ", ";
            }

            

            if (strAddress.Length > 0)
            {
                if ((strAddress.Substring(strAddress.Length - 2, 2) == ", "))
                {
                    strAddress = strAddress.Substring(0, strAddress.Length - 2);
                }
                if (strAddress.Length > 0)
                {
                    if ((strAddress.Substring(strAddress.Length - 1, 1) == ","))
                    {
                        strAddress = strAddress.Substring(0, strAddress.Length - 1);
                    }
                }
                if (strAddress.Length > 0)
                {
                    if ((strAddress.Substring(0, 1) == ","))
                    {
                        strAddress = strAddress.Substring(1, strAddress.Length - 1);
                    }
                }
                else strAddress = "-N/A-";
            }
            else strAddress = "-N/A-";
            spAddress.InnerText = strAddress;

            spURL.Text = prospects[0].WebSite.Length > 0 ? HttpUtility.HtmlEncode(prospects[0].WebSite) : "-N/A-";
            if (prospects[0].PhoneCell.Length > 0)
            {
                spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospects[0].PhoneCell);
            }
            else if (prospects[0].PhoneOffice.Length > 0)
            {
                spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospects[0].PhoneOffice);
            }
            else if (prospects[0].PhoneOther.Length > 0)
            {
                spPhone.InnerText = objCommonCode.FormatPhoneNumberGet(prospects[0].PhoneOther);
            }
            else
            {
                spPhone.InnerText = "-N/A-";
            }

            string email = "-N/A-";
            string spnTemp = "-N/A-";

            if (prospects[0].EMailID.Length > 0)
            {
                email = prospects[0].EMailID;
            }
            if ((prospects[0].EMailID.Length > 0))
            {
                spOther.InnerText = email;
            }
            else
            {
                spOther.InnerText = "-N/A-";
            }

            // Prospect type
            if (!string.IsNullOrEmpty(prospects[0].ProspectType.Name))
            {
                spnProspectType.InnerText = prospects[0].ProspectType.Name;
            }
            else spnProspectType.InnerText = "-N/A-";
            // Members/Employees
            if (prospects[0].ActualMembership > 0)
            {
                spnMembersEmployees.InnerText = prospects[0].ActualMembership.ToString();
            }
            else spnMembersEmployees.InnerText = "-N/A-";
            // Actual Attendence
            if (prospects[0].Attendance > 0)
            {
                spnAttendence.InnerText = prospects[0].Attendance.ToString();
            }
            else spnAttendence.InnerText = "-N/A-";
            // Facilities Fee
            if (!string.IsNullOrEmpty(prospects[0].ProspectDetails.FacilitiesFee))
            {
                spnFacilitiesFee.InnerText = prospects[0].ProspectDetails.FacilitiesFee;
            }
            else spnFacilitiesFee.InnerText = "-N/A-";
            // Will Promote
            if (prospects[0].WillCommunicate >= 0)
            {
                switch (prospects[0].WillCommunicate)
                {
                    case 0:
                        spnTemp = "No";
                        break;
                    case 1:
                        spnTemp = "Yes";
                        break;
                    case 2:
                        spnTemp = "Unknown";
                        break;
                    default:
                        spnTemp = "-N/A-";
                        break;
                }
                spnWillPromote.InnerHtml = spnTemp;
            }
            // Will Host
            if (prospects[0].ProspectDetails.WillHost >= 0)
            {
                switch (prospects[0].ProspectDetails.WillHost)
                {
                    case 0:
                        spnTemp = "No";
                        break;
                    case 1:
                        spnTemp = "Yes";
                        break;
                    case 2:
                        spnTemp = "Unknown";
                        break;
                    default:
                        spnTemp = "-N/A-";
                        break;
                }
                spnWillHost.InnerHtml = spnTemp;
            }
            // Viable Host Site
            if (prospects[0].ProspectDetails.ViableHostSite >= 0)
            {
                if (prospects[0].ProspectDetails.ViableHostSite == 0)
                {
                    spnTemp = "No";
                }
                else if (prospects[0].ProspectDetails.ViableHostSite == 1)
                {
                    spnTemp = "Yes";
                }
                else if (prospects[0].ProspectDetails.ViableHostSite == 2)
                {
                    spnTemp = "Unknown";
                }
                else spnTemp = "-N/A-";
                spnViableHostSite.InnerHtml = spnTemp;
            }
        }
    }
    
    #endregion

    #region All

    private void GetAll(Int64 ProspectId)
    {
        if (ProspectId > 0)
        {
            MasterDAL masterDal = new MasterDAL();
            EContactCall[] objEContactCalls = null;
            var listEContactCalls = masterDal.GetCallsMeetingsTasks(0, ProspectId);
            if (listEContactCalls != null) objEContactCalls = listEContactCalls.ToArray();

            //ContactCallService service = new ContactCallService();
            //EContactCall[] objEContactCalls = service.GetCallsMeetingsTasks(ProspectId, true);
            BindAll(objEContactCalls);
        }
    }

    private void BindAll(EContactCall[] objEContactCalls)
    {
        DataTable dtAll = new DataTable();
        dtAll.Columns.Add("Type");
        dtAll.Columns.Add("TypeText");
        dtAll.Columns.Add("ID");
        dtAll.Columns.Add("Subject");
        dtAll.Columns.Add("Notes");
        dtAll.Columns.Add("StartDate");
        dtAll.Columns.Add("ContactName");
        dtAll.Columns.Add("AssignedBy");
        dtAll.Columns.Add("DateModified");

        if (objEContactCalls != null && objEContactCalls.Length > 0)
        {
            string strTypeText = string.Empty;
            string strNotes = string.Empty;
            string strType = string.Empty;
            string strStartDate = string.Empty;
            for (int icount = 0; icount < objEContactCalls.Length; icount++)
            {
                if (objEContactCalls[icount].Type.Trim() == "Calls")
                {
                    strTypeText = "Talk to:";
                    strType = "Call:";
                }
                else if (objEContactCalls[icount].Type.Trim() == "Meetings")
                {
                    strTypeText = "Met with:";
                    strType = "Meeting:";
                }
                else if (objEContactCalls[icount].Type.Trim() == "Tasks")
                {
                    strTypeText = "";
                    strType = "Task:";
                }
                strNotes = objEContactCalls[icount].Notes;
                if (strNotes == null || strNotes == "") strNotes = "Notes : N/A ";
                strStartDate = objEContactCalls[icount].StartDate;
                if (strStartDate != null && strStartDate != "") strStartDate = strStartDate + ":";

                dtAll.Rows.Add(new object[] { strType,
                                                strTypeText,
                                                objEContactCalls[icount].ContactCallID, 
                                                objEContactCalls[icount].Subject,
                                                strNotes,                                                
                                                strStartDate,                                                
                                                objEContactCalls[icount].Contact.FirstName,                                                                                           
                                                objEContactCalls[icount].UserShellModule.UserName,
                                                objEContactCalls[icount].StartTime
                                               });
                strNotes = ""; strType = ""; strTypeText = "";
            }
            dtAll = dtAll.DefaultView.ToTable();


            ViewState["GRDALL"] = dtAll;
            grdAll.DataSource = dtAll;
            grdAll.DataBind();

            divNoResultsAll.Style.Add(HtmlTextWriterStyle.Display, "block");
            divNoResultsAll.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {

            divNoResultsAll.Style.Add(HtmlTextWriterStyle.Display, "none");
            divNoResultsAll.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
    }

    protected void grdAll_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdAll.PageIndex = e.NewPageIndex;
        grdAll.DataSource = (DataTable)ViewState["GRDNOTES"];
        grdAll.DataBind();
    }
    #endregion

    #region Load Calls Tasks Meetings

    private void LoadGrids(int prospectID)
    {
        GetAll(Convert.ToInt64(prospectID));
    }

    #endregion
}
