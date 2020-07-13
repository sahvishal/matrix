using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.App.UI.Extentions;
using Falcon.Entity.Other;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Franchisor;

public partial class App_Franchisor_AddMeeting : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Add New Meeting";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster) this.Master;
        obj.settitle("Add Meeting");
        obj.SetBreadCrumbRoot = "<a href=\"#\">DashBoard</a>";
        obj.hideucsearch();

        if (!string.IsNullOrEmpty(Request["IsHost"]) && Request["IsHost"].Equals("True"))
        {
            spnName.InnerHtml = "Host Name:";
            spnAddress.InnerHtml = "Host Address:";
            spnType.InnerHtml = "Host Type:";
        }
        else
        {
            spnName.InnerHtml = "Prospect Name:";
            spnAddress.InnerHtml = "Prospect Address:";
            spnType.InnerHtml = "Prospect Type:";
        }
        if (!Page.IsPostBack)
        {
            // Fill Default Date and Time
            if (Request.QueryString["ContactMeetingID"] == null)
            {
                txtStartDate.Text = string.Format("{0:d}", DateTime.Now);
                txtStartTime.Text = string.Format("{0:t}", DateTime.Now);
            }

            radioNone.Attributes.Add("onclick", "hideDivFollwoUpAction();");
            radioFollowAction.Attributes.Add("onclick", "ShowDivFollwoUpAction();");
            chkboxCall.Attributes["onClick"] = "HideShowCall();";
            chkboxMeeting.Attributes["onClick"] = "HideShowMeeting();";
            chkboxTask.Attributes["onClick"] = "HideShowTask();";
            GetStatus();
            FillDuration();
            FillContactList();

            // Put prospect id in viewstate
            if (!string.IsNullOrEmpty(Request.QueryString["ProspectID"]))
            {
                ViewState["ProspectID"] = Convert.ToInt64(Request.QueryString["ProspectID"]);
                divProspectDetails.Style.Add(HtmlTextWriterStyle.Display, "block");
                Int64 ProspectId = 0;
                ProspectId = Convert.ToInt64(Request.QueryString["ProspectID"]);
                GetProspectDetails(ProspectId);
            }
            else
            {
                divProspectDetails.Style.Add(HtmlTextWriterStyle.Display, "none");
                divTab.Style.Add(HtmlTextWriterStyle.Display, "none");
                divCloseAndCreate.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
            if (Request.QueryString["Date"] != null)
            {
                string strDate = Request.QueryString["Date"];
                DateTime dtEventDate;


                if (DateTime.TryParse(strDate, out dtEventDate) == true)
                {
                    txtStartDate.Text = dtEventDate.ToShortDateString();
                }
            }

            if (Request.QueryString["Parent"] != null)
            {
                ViewState["ReferedURL"] = Request.UrlReferrer.PathAndQuery;
                if (ViewState["ReferedURL"] != null && ViewState["ReferedURL"].ToString() != "")
                {
                    ViewState["ReferedURL"] = ViewState["ReferedURL"].ToString().Replace("&Action=Alert", "");
                }
                if (Request.QueryString["ContactMeetingID"] != null)
                {
                    heading.InnerText = "Edit Meeting";
                    obj.settitle("Edit Meeting");
                    this.Page.Title = "Edit meeting";
                    ViewState["ContactMeetingID"] = Request.QueryString["ContactMeetingID"].ToString();
                    this.FillMeeting();

                    contactForm1.Style.Add("display", "block");
                }
            }

            if (Request.QueryString["ContactMeetingID"] != null && Request.QueryString["Parent"] == null)
            {
                heading.InnerText = "Edit Meeting";
                obj.settitle("Edit Meeting");
                this.Page.Title = "Edit meeting";
                ViewState["ContactMeetingID"] = Request.QueryString["ContactMeetingID"].ToString();
                this.FillMeeting();
                contactForm1.Style.Add("display", "block");
            }


            if (Request.QueryString["ContactID"] != null && Request["ContactID"]!="" && Request["ContactID"]!="0")
            {

                hfContactId.Value = Request["ContactID"];
                ClientScript.RegisterStartupScript(typeof (string), "jscodeselectcontact", "SelectContact();", true);


                int iprospectid;

                FranchisorDAL objDAL = new FranchisorDAL();
                var contact = objDAL.GetContactByID(Convert.ToInt32(Request.QueryString["ContactID"].ToString()), 0,
                                                    out iprospectid);


                if (contact != null)
                {
                    ViewState["cntctid"] = contact.ContactID;
                    hfContactId.Value = contact.ContactID.ToString();
                }
            }
        }

        pnlSearch.Style.Add(HtmlTextWriterStyle.Display, "none");
        
    }

    private void FillMeeting()
    {
        
        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        MasterDAL objMasterDal=new MasterDAL();
        var listContactMeeting = objMasterDal.GetMeetings(ViewState["ContactMeetingID"].ToString(), 1, (int)currentSession.UserId, (int)currentSession.CurrentOrganizationRole.OrganizationId, (int)currentSession.CurrentOrganizationRole.RoleId, 0);
        EContactMeeting[] meeting = null;
        if (listContactMeeting != null)
            meeting = listContactMeeting.ToArray();
        if (meeting != null)
        {
            divFutureAction.Style.Add(HtmlTextWriterStyle.Display, "none");
            //lnkNewContact.Visible = false;
            divAddNewContact.Style.Add(HtmlTextWriterStyle.Display, "none");

            divCloseAndCreate.Style.Add("display", "none");
            divCloseAndCreate.Style.Add("visibility", "hidden");

            ViewState["ContactMeetingID"] = meeting[0].ContactMeetingID;
            txtSubject.Text = meeting[0].Subject;
            
            if (meeting[0].StartDate != null && meeting[0].StartDate != "")
                txtStartDate.Text = Convert.ToDateTime(meeting[0].StartDate).ToShortDateString();
            else txtStartDate.Text = "";
            if (meeting[0].StartTime != null && meeting[0].StartTime != "")
                txtStartTime.Text = Convert.ToString(Convert.ToDateTime(meeting[0].StartTime).ToShortTimeString());
            else txtStartTime.Text = "";
            

            ddlStatus.SelectedValue = Convert.ToString(meeting[0].CallStatus.CallStatusID);

            int Duration = Convert.ToInt32(meeting[0].Duration);
            if (Duration > 0)
            {
                if (ddlDuration.Items.FindByValue(Duration.ToString()) != null)
                {
                    ddlDuration.SelectedIndex = -1;
                    ddlDuration.Items.FindByValue(Duration.ToString()).Selected = true;
                }
            }
            txtDescription.Text  = meeting[0].Description ;
            ViewState["cntctid"] = meeting[0].Contact.ContactID;
            
            hfContactId.Value = meeting[0].Contact.ContactID.ToString();
            ClientScript.RegisterStartupScript(typeof(string), "jscodeselectcontact", "SelectContact();", true);

            txtVenue.Text = meeting[0].Venue;
        }


    }

    private void GetStatus()
    {
        MasterDAL objMaster=new MasterDAL();
        var listCallStatus = objMaster.GetCallStatusType(string.Empty, 3);
        ECallStatus[] status = null;
        if (listCallStatus != null)
            status = listCallStatus.ToArray();
        if (status.Length > 0)
        {

            for (int count = 0; count < status.Length; count++)
            {
                ddlStatus.Items.Add(new ListItem(status[count].Status.ToString(), status[count].CallStatusID.ToString()));
            }
            ddlStatus.SelectedIndex = -1;
            ddlStatus.Items.FindByText("Planned").Selected = true;
        }
    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        fillgrid();
    }

    private void fillgrid()
    {
        Int64 ProspectID = 0;

        if (ViewState["ProspectID"] != null && (string) ViewState["ProspectID"] != "")
        {
            ProspectID = Convert.ToInt64(ViewState["ProspectID"]);
        }

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        MasterDAL objMasterDal=new MasterDAL();
        var listContact = objMasterDal.SearchContact(txtFirstName.Text, txtState.Text, txtCity.Text, txtZip.Text, 1, Convert.ToInt32(currentSession.UserId), Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId), Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId), txtCustomerID.Text, ProspectID);
        Falcon.Entity.Other.EContact[] contact = null;
        if (listContact != null)
            contact = listContact.ToArray();
        DataTable tbltemp = new DataTable();
        tbltemp.Columns.Add("FullName");
        tbltemp.Columns.Add("Address");
        tbltemp.Columns.Add("Email");

        tbltemp.Columns.Add("ContactID");

        if (contact != null && contact.Length > 0)
        {
            for (int i = 0; i < contact.Length; i++)
            {

                string address = string.Empty;
                if (contact[i].Address.Address1.Trim().Length > 0)
                    address = contact[i].Address.Address1;
                if (contact[i].Address.City.Trim().Length > 0)
                    address = address + "," + contact[i].Address.City;
                if (contact[i].Address.State.Trim().Length > 0)
                    address = address + "," + contact[i].Address.State;
                if (contact[i].Address.Zip.Trim().Length > 0)
                    address = address + "," + contact[i].Address.Zip;
                if (address.Length > 0 && address.Substring(0, 1) == ",")
                    address = address.Substring(1);
                tbltemp.Rows.Add(contact[i].FirstName + " " + contact[i].LastName, address, contact[i].EMail, contact[i].ContactID);

            }

        }
        ViewState["TblContacts"] = tbltemp;
        GridView.Style["display"] = "block";
        dgcontactlist.DataSource = tbltemp;
        dgcontactlist.DataBind();
        if (contact.Length <= 1)
        {
            textfound.InnerHtml = "&nbsp Result found";
        }
        else
        {
            textfound.InnerHtml = "&nbsp Results found";
        }
        if (contact.Length == 0)
        {
            imggridupper.Style.Add(" display", "none");
            imggridlower.Style.Add(" display", "none"); 
        }
        countcontact.InnerHtml = "&nbsp;" + contact.Length.ToString();
        spMMSearchImg.Style["display"] = "none";

    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {

        divGridView.Visible = false;
        mainbody.Visible = false;
        contactForm1.Style.Add("display", "block");
        
        bool value= SaveMeeting();
        
        if (value == false)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode", "alert('This is not valid user,Please complete the information');", true);
            return;
        }
        if (Request.QueryString["Parent"] != null)
        {
            Response.RedirectUser(ViewState["ReferedURL"].ToString());
        }
        else if (Request.QueryString["ProspectID"] != null)
        {
            if (Request.QueryString["IsHost"] != null)
                Response.RedirectUser("../Franchisee/SalesRep/SalesRepManageHost.aspx");
            else
                Response.RedirectUser("../Franchisee/SalesRep/SalesRepManageProspects.aspx");
        }   
        else
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ViewMeetings.aspx"));
        }
    }

    private bool SaveMeeting()
    {
        string strUser = null;
        string strRole = null;
        string strShell = null;
        decimal minutes = 0;
        Int64 ProspectID = 0;
        
        MasterDAL objMasterDal=new MasterDAL();
        var meeting = new Falcon.Entity.Other.EContactMeeting();

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        
        long temp;
        meeting.CallStatus = new Falcon.Entity.Other.ECallStatus();
        meeting.Contact = new Falcon.Entity.Other.EContact();

        if (ViewState["ContactMeetingID"] != null)
        {
            meeting.ContactMeetingID = Convert.ToInt32(ViewState["ContactMeetingID"]);
            meeting.ProspectID = 0;
        }

        meeting.Subject = txtSubject.Text;
        meeting.Description  = txtDescription.Text;

        meeting.StartDate = txtStartDate.Text;

        if (txtStartTime.Text != null && txtStartTime.Text != "")
        {
            DateTime dt = Convert.ToDateTime(string.Format("{0:T}", txtStartTime.Text));
            int Hour = Convert.ToInt16(dt.ToString("hh"));

            if ((dt.Minute > 60) || (dt.Second >= 60) || (Hour > 12))
            {
                return false;
            }
            meeting.StartTime = txtStartTime.Text;
        }
        else 
            meeting.StartTime = "";
                

        minutes = Convert.ToInt32(ddlDuration.SelectedValue);
        meeting.Duration = minutes;

        //What is this ?? - Bidhan
        meeting.AssignedToUserId = Convert.ToInt32(strUser);
        meeting.AssignedToShellID = Convert.ToInt32(strShell);
        meeting.AssignedToRoleID = Convert.ToInt32(strRole);
        
        meeting.CreatedByUserId = Convert.ToInt32(currentSession.UserId);
        meeting.CreatedByShellID = Convert.ToInt32(currentSession.CurrentOrganizationRole.OrganizationId);
        meeting.CreatedByRoleID = Convert.ToInt32(currentSession.CurrentOrganizationRole.RoleId);


        meeting.Reminder = false;
        meeting.CallStatus.CallStatusID = Convert.ToInt32(ddlStatus.SelectedValue);
        meeting.Venue = txtVenue.Text;

        // Assign Prospect
        if (!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            ProspectID = Convert.ToInt64(Request["ProspectID"]);
        }
        meeting.ProspectID = ProspectID;
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
                        EContactMeeting ContactMeeting = new EContactMeeting();
                        ContactMeeting.CallStatus = new ECallStatus();
                        ContactMeeting.Contact = new EContact();

                        ContactMeeting.Contact.ContactID = Convert.ToInt32(strAllContactCall[i]);

                        ContactMeeting.IsActive = true;
                        ContactMeeting.ContactMeetingID = meeting.ContactMeetingID;
                        ContactMeeting.CreatedByUserId = meeting.CreatedByUserId;
                        ContactMeeting.CreatedByShellID = meeting.CreatedByShellID;
                        ContactMeeting.CreatedByRoleID = meeting.CreatedByRoleID;
                        ContactMeeting.AssignedToUserId = meeting.AssignedToUserId;
                        ContactMeeting.AssignedToShellID = meeting.AssignedToShellID;
                        ContactMeeting.AssignedToRoleID = meeting.AssignedToRoleID;
                        ContactMeeting.ProspectID = meeting.ProspectID;
                        ContactMeeting.Duration = meeting.Duration;
                        ContactMeeting.Subject = meeting.Subject;
                        ContactMeeting.Description = meeting.Description;
                        ContactMeeting.StartDate = meeting.StartDate;
                        ContactMeeting.StartTime = meeting.StartTime;
                        ContactMeeting.CallStatus.CallStatusID = meeting.CallStatus.CallStatusID;
                        ContactMeeting.Venue = meeting.Venue;
                        if (ViewState["ContactMeetingID"] != null)
                        {
                            if (ViewState["ContactMeetingID"].ToString() != string.Empty)
                            {
                                temp = objMasterDal.SaveMeeting(ContactMeeting, Convert.ToInt32(EOperationMode.Update));
                            }
                        }
                        else
                        {
                            temp = objMasterDal.SaveMeeting(ContactMeeting, Convert.ToInt32(EOperationMode.Insert));
                        }
                    }
                }
            }
        }
        else
        {
            if (ViewState["ContactMeetingID"] != null)
            {
                if (ViewState["ContactMeetingID"].ToString() != string.Empty)
                {
                    temp = objMasterDal.SaveMeeting(meeting, Convert.ToInt32(EOperationMode.Update));
                }
            }
            else
            {
                temp = objMasterDal.SaveMeeting(meeting, Convert.ToInt32(EOperationMode.Insert));
            }
        }

        // Add Call 
        if (chkboxCall.Checked)
        {
            EContactCall FollowUpCall = new EContactCall();

            FollowUpCall.CallStatus = new ECallStatus();
            FollowUpCall.Contact = new EContact();

            FollowUpCall.IsActive = true;
            FollowUpCall.CreatedByUserId = meeting.CreatedByUserId;
            FollowUpCall.CreatedByShellID = meeting.CreatedByShellID;
            FollowUpCall.CreatedByRoleID = meeting.CreatedByRoleID;
            FollowUpCall.AssignedToUserId = meeting.AssignedToUserId;
            FollowUpCall.AssignedToShellID = meeting.AssignedToShellID;
            FollowUpCall.AssignedToRoleID = meeting.AssignedToRoleID;
            FollowUpCall.Contact.ContactID = meeting.Contact.ContactID;
            FollowUpCall.ProspectID = meeting.ProspectID;
            FollowUpCall.Duration = 0;
            //FollowUpCall.ContactCallID = meeting.ContactCallID;
            FollowUpCall.CallResult = 0;
            FollowUpCall.FutureAction = 0;

            // 
            FollowUpCall.Subject = txtCallSubject.Text;
            FollowUpCall.Notes = "";
            FollowUpCall.StartDate = txtCallStartDate.Text;
            FollowUpCall.StartTime = txtCallStartTime.Text;
            temp = objMasterDal.SaveCall(FollowUpCall, Convert.ToInt32(EOperationMode.Insert));
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
            objEContactMeeting.AssignedToUserId = meeting.AssignedToUserId;
            objEContactMeeting.AssignedToShellID = meeting.AssignedToShellID;
            objEContactMeeting.AssignedToRoleID = meeting.AssignedToRoleID;
            objEContactMeeting.CreatedByUserId = meeting.CreatedByUserId;
            objEContactMeeting.CreatedByShellID = meeting.CreatedByShellID;
            objEContactMeeting.CreatedByRoleID = meeting.CreatedByRoleID;
            objEContactMeeting.Contact.ContactID = meeting.Contact.ContactID;
            objEContactMeeting.ProspectID = meeting.ProspectID;

            temp = objMasterDal.SaveMeeting(objEContactMeeting, Convert.ToInt32(EOperationMode.Insert));
        }

        // Add Task
        if (chkboxTask.Checked)
        {
            if ((!string.IsNullOrEmpty(txtTask.Text)) || (!string.IsNullOrEmpty(txtTaskDueDate.Text)) || (!string.IsNullOrEmpty(txtTaskDueTime.Text)))
            {
                var masterDal = new Falcon.DataAccess.Master.MasterDAL();
                var task = new Falcon.Entity.Other.ETask();

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


                task.ProspectID = meeting.ProspectID;
                task.ContactID = meeting.Contact.ContactID;
                task.CreatedBY = Convert.ToInt32(currentSession.UserId);
                task.ModifiedBY = Convert.ToInt32(currentSession.UserId);

                temp = masterDal.SaveTask(task, Convert.ToInt32(EOperationMode.Insert), currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(), currentSession.CurrentOrganizationRole.RoleId.ToString());
                if (temp == 0)
                {
                    temp = 9999990;
                }

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
        if (Request.QueryString["Referrer"] != null)
        {
            string strReferrer = Request.QueryString["Referrer"].ToString();
            if ((strReferrer != string.Empty) && (strReferrer == "Calendar"))
            {
                Response.RedirectUser(this.ResolveUrl("~/App/Common/Calendar.aspx"));
            }
        }
        return true;
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
        if (Request.QueryString["Parent"] != null)
        {
            Response.RedirectUser(ViewState["ReferedURL"].ToString());
        }
        else
        {
            Response.RedirectUser(this.ResolveUrl("~/App/Franchisor/ViewMeetings.aspx"));
        }
   
    }

    protected void btnCloseAndCreate_Click(object sender, ImageClickEventArgs e)
    {
        bool value = SaveMeeting();
        hfContactId.Value = "";
        hfContactName.Value = "";
        txtSubject.Text = "";
        // Default values for startdate and starttime
        txtStartDate.Text = string.Format("{0:d}", DateTime.Now);
        txtStartTime.Text = string.Format("{0:t}", DateTime.Now);
        txtVenue.Text = "";
        if (ddlStatus.Items.FindByText("Planned") != null)
        {
            ddlStatus.SelectedIndex = -1;
            ddlStatus.Items.FindByText("Planned").Selected = true;
        }
        if (ddlDuration.Items.FindByValue("5") != null)
        {
            ddlDuration.SelectedIndex = -1;
            ddlDuration.Items.FindByValue("5").Selected = true;
        }
        txtDescription.Text = "";
        ClientScript.RegisterStartupScript(typeof(string), "jscodeMeetingAdded", "alert('Meeting added sucessfully.');", true);
        return;
        
    }

    
    protected void dgcontactlist_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgcontactlist.PageIndex = e.NewPageIndex;
        dgcontactlist.DataSource = (DataTable)ViewState["TblContacts"];
        dgcontactlist.DataBind();
    }
    /// <summary>
    /// Fill Duration
    /// </summary>
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

    private void GetProspectDetails(Int64 prospectid)
    {
        int iprospectid = Convert.ToInt32(prospectid);

        
        EProspect[] prospect = null;

        FranchisorDAL objDAL = new FranchisorDAL();
        

        if (!string.IsNullOrEmpty(Request["IsHost"]))
        {
            if (Request["IsHost"].Equals("True"))
            {
               var listProspect = objDAL.GetHostDetails(iprospectid.ToString(), 1);
                if (listProspect != null) prospect = listProspect.ToArray();
            }
            else
            {
                var listProspect = objDAL.GetProspectDetails(iprospectid.ToString(), 4);
                if (listProspect != null) prospect = listProspect.ToArray();
                
            }
        }
        else
        {
            var listProspect = objDAL.GetProspectDetails(iprospectid.ToString(), 4);
            if (listProspect != null) prospect = listProspect.ToArray();
            
        }




        if (prospect != null)
        {
            spProspectName2.InnerText = prospect[0].OrganizationName.ToString();
            string strAddress = string.Empty;

            // Address
            if (!string.IsNullOrEmpty(prospect[0].Address.Address1))
            {
                strAddress = strAddress + prospect[0].Address.Address1 + ", ";
            }
            // Suit
            if (!string.IsNullOrEmpty(prospect[0].Address.Address2))
            {
                strAddress = strAddress + prospect[0].Address.Address2 + ", ";
            }
            // City
            if (!string.IsNullOrEmpty(prospect[0].Address.City))
            {
                strAddress = strAddress + HttpUtility.HtmlEncode(prospect[0].Address.City) + ", ";
            }
            // State
            if (!string.IsNullOrEmpty(prospect[0].Address.State))
            {
                strAddress = strAddress + HttpUtility.HtmlEncode(prospect[0].Address.State) + ", ";
            }
            // ZipID
            if (prospect[0].Address.ZipID > 0)
            {
                strAddress = strAddress + HttpUtility.HtmlEncode(prospect[0].Address.ZipID) + ", ";
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

            spURL.InnerHtml = prospect[0].WebSite.Length > 0 ? HttpUtility.HtmlEncode(prospect[0].WebSite) : "-N/A-";
            
            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            if (prospect[0].PhoneCell.Length > 0)
            {
                spPhone.InnerHtml = objCommonCode.FormatPhoneNumberGet(prospect[0].PhoneCell);
            }
            else if (prospect[0].PhoneOffice.Length > 0)
            {
                spPhone.InnerHtml = objCommonCode.FormatPhoneNumberGet(prospect[0].PhoneOffice);
            }
            else if (prospect[0].PhoneOther.Length > 0)
            {
                spPhone.InnerHtml = objCommonCode.FormatPhoneNumberGet(prospect[0].PhoneOther);
            }
            else
            {
                spPhone.InnerHtml = "-N/A-";
            }

            string email = "-N/A-";
            string eventname = "-N/A-";
            string eventdate = "-N/A-";
            string spnTemp = "-N/A-";

            if (prospect[0].EMailID.Length > 0)
            {
                email = prospect[0].EMailID;
            }
            if ((prospect[0].EMailID.Length > 0))
            {
                spOther.InnerText = email;
            }
            else
            {
                spOther.InnerText = "-N/A-";
            }

            if (prospect[0].LastEventName.Length > 0)
            {
                eventdate = Convert.ToDateTime(prospect[0].LastEventDate).ToLongDateString();
                eventname = prospect[0].LastEventName;
            }
            // Prospect type
            if (!string.IsNullOrEmpty(prospect[0].ProspectType.Name))
            {
                spnProspectType.InnerText = prospect[0].ProspectType.Name;
            }
            else spnProspectType.InnerText = "-N/A-";
            // Members/Employees
            if (prospect[0].ActualMembership > 0)
            {
                spnMembersEmployees.InnerText = prospect[0].ActualMembership.ToString();
            }
            else spnMembersEmployees.InnerText = "-N/A-";
            // Actual Attendence
            if (prospect[0].Attendance > 0)
            {
                spnAttendence.InnerText = prospect[0].Attendance.ToString();
            }
            else spnAttendence.InnerText = "-N/A-";
            // Facilities Fee
            if (!string.IsNullOrEmpty(prospect[0].ProspectDetails.FacilitiesFee))
            {
                spnFacilitiesFee.InnerText = prospect[0].ProspectDetails.FacilitiesFee;
            }
            else spnFacilitiesFee.InnerText = "-N/A-";
            // Will Promote
            if (prospect[0].WillCommunicate >= 0)
            {
                switch (prospect[0].WillCommunicate)
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
                spnWillPromote.InnerText = spnTemp;
                spnTemp = "";
            }
            // Will Host
            if (prospect[0].ProspectDetails.WillHost >= 0)
            {
                switch (prospect[0].ProspectDetails.WillHost)
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
                spnWillHost.InnerText = spnTemp;
                spnTemp = "";
            }
            // Viable Host Site
            if (prospect[0].ProspectDetails.ViableHostSite >= 0)
            {
                if (prospect[0].ProspectDetails.ViableHostSite == 0)
                {
                    spnTemp = "No";
                }
                else if (prospect[0].ProspectDetails.ViableHostSite == 1)
                {
                    spnTemp = "Yes";
                }
                else if (prospect[0].ProspectDetails.ViableHostSite == 2)
                {
                    spnTemp = "Unknown";
                }
                else spnTemp = "-N/A-";
                spnViableHostSite.InnerText = spnTemp;
                spnTemp = "";
            }
        }
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

    private void FillContactList()
    {
        if (!string.IsNullOrEmpty(Request["ProspectID"]))
        {
            Int64 ProspectId = Convert.ToInt64(Request["ProspectID"]);
            FranchisorDAL objDAL = new FranchisorDAL();
            var listContact = objDAL.GetContactByProspect(ProspectId, 0);
            EContact[] objContacts = null;

            if (listContact != null) objContacts = listContact.ToArray();

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
                divGridContacts.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            tbltemp.DefaultView.Sort = "FullName asc";
            grdContacts.DataSource = tbltemp;
            grdContacts.DataBind();

        }
    }

    protected void HandleSave(object sender, EventArgs e)
    {
        SaveContact();
    }

    private void SaveContact()
    {
        int rownumber = 0;
        var objFranchisorDal = new FranchisorDAL();
        var objContact = ucMiniAddNewContact1.GetFields(out rownumber);
        objContact.Address = new Falcon.Entity.Other.EAddress();

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

            for (int i = 0; i < objContact.ListProspectContactRole.Count; i++)
            {
                objContact.ListProspectContactRole[i].ProspectID = iProspectID[0];
            }
            if (!string.IsNullOrEmpty(hidContactIDEdit.Value))
            {
                objContact.ContactID = Convert.ToInt32(hidContactIDEdit.Value);
                tempResult = UpdateContactDetail(objContact, currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                                 currentSession.CurrentOrganizationRole.RoleId.ToString());
            }
            else
            {
                tempResult = SaveProspectContact(objContact, currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
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

    public Int64 UpdateContactDetail(EContact contact, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = franchisorDAL.SaveContact(contact, Convert.ToInt32(EOperationMode.Update), Convert.ToInt32(userID));
        if (returnresult >= 0) returnresult = contact.ContactID;
        else returnresult = -1;

        if (returnresult > 0 && contact.ArrayProspectIDs != null)
        {
            foreach (Int64 prospectid in contact.ArrayProspectIDs)
            {
                franchisorDAL.SaveProspectContact(returnresult, prospectid, true);
                var listprospectcontactroleFORDAL = new List<EProspectContactRole>();
                if (contact.ListProspectContactRole != null && contact.ListProspectContactRole.Count > 0)
                {
                    foreach (EProspectContactRole objproscontrole in contact.ListProspectContactRole)
                    {
                        if (objproscontrole.ProspectID == prospectid)
                            listprospectcontactroleFORDAL.Add(objproscontrole);
                    }
                }
                franchisorDAL.SaveProspectContactRoleMapping(listprospectcontactroleFORDAL, returnresult, prospectid);
            }
        }
        return returnresult;
    }

    public Int64 SaveProspectContact(EContact contact, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = franchisorDAL.SaveContact(contact, Convert.ToInt32(EOperationMode.Insert), Convert.ToInt32(userID));
        if (returnresult > 0 && contact.ArrayProspectIDs != null)
        {
            foreach (Int64 prospectid in contact.ArrayProspectIDs)
            {
                franchisorDAL.SaveProspectContact(returnresult, prospectid, true);
                if (contact.ListProspectContactRole != null && contact.ListProspectContactRole.Count > 0)
                {
                    var listprospectcontactroleFORDAL = new List<EProspectContactRole>();
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
}
