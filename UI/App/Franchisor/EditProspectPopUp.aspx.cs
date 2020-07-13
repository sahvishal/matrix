using System;
using System.Data;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Xml;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;

public partial class App_Franchisor_EditProspectPopUp : System.Web.UI.Page
{
    protected const int COUNTRY_ID = 1;
    protected const string COUNTRY_NAME = "USA";
    /// <summary>
    /// Page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            ddlFeederPromotionStatus.Attributes.Add("onchange", "PromoteChange();");
            ddlhostStatus.Attributes.Add("onchange", "HostStatusChange();");
            ddlViableHost.Attributes.Add("onchange", "ViableHostChange();");

            chkMailingAddress.Attributes["onClick"] = "CheckMailingAddress();";
            rbtnDepositsRequired.Attributes.Add("onclick", "DepositeRequires();");
            rbtnFeeRequired.Attributes.Add("onclick", "FeeRequires();");
            ddlHostedInPast.Attributes.Add("onchange", "CheckValiable();");
            ibtnCancel.Attributes.Add("onClick", "CancelWindow();");

            ViewState["FranchiseeID"] = null;
            GetDropDownInfo();
           // ViewState["RefferedUrl"] = Request.UrlReferrer.PathAndQuery;
            string ProspectID = string.Empty;

            txtActualMembers.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtAttendence.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtzipBilling.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtzipMailing.Attributes.Add("onKeyDown", "return txtkeypress(event);");
            txtFacilitiesFee.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");
            txtAmount.Attributes.Add("onKeyDown", "return AllowNumericOnly(event);");

            gridtitle.InnerText = "Create New Prospect";
            if (Request.QueryString["Action"] != null)
            {
                ClientScript.RegisterStartupScript(typeof(string), "sfjscode", "alert('Prospect has been added successfully .');", true);
            }

            if (Request.QueryString["ProspectID"] != null && Request.QueryString["IsHost"]==null)
            {
                gridtitle.InnerText = "Edit Prospect";
                this.Page.Title = "Edit Prospect";
                spnProspectHostTitle.InnerHtml = "Prospect";

                ProspectID = Request.QueryString["ProspectID"].ToString();                
                ViewState["ProspectID"] = ProspectID;
                ViewState["IsHost"] = 0;
                this.FillProspect(false);
            }
            else if (Request.QueryString["ProspectID"] != null && Request.QueryString["IsHost"] != null)
            {
                gridtitle.InnerText = "Edit Host";
                this.Page.Title = "Edit Host";
                spnProspectHostTitle.InnerText = "Host";

                ProspectID = Request.QueryString["ProspectID"].ToString();
                ViewState["ProspectID"] = ProspectID;
                ViewState["IsHost"] = 1;
                this.FillProspect(true);
                hidProspectType.Value = "host";
                ClientScript.RegisterStartupScript(typeof(string), "jsopenmandatory", " OpenMandatoryfields(); ", true);
            }
        }
        if (Request.QueryString["ProspectID"] != null && Request.QueryString["IsHost"] == null)
        {
            gridtitle.InnerText = "Edit Prospect";
            this.Page.Title = "Edit Prospect";
            spnProspectHostTitle.InnerHtml = "Prospect";
        }
        else if (Request.QueryString["ProspectID"] != null && Request.QueryString["IsHost"] != null)
        {
            gridtitle.InnerText = "Edit Host";
            this.Page.Title = "Edit Host";
            spnProspectHostTitle.InnerHtml = "Host";
        }
        
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
            if (txtaddress1Mailing.Text != "")
                divMailingAddress.Style.Add(HtmlTextWriterStyle.Display, "block");
            else divMailingAddress.Style.Add(HtmlTextWriterStyle.Display, "none");
            if (!IsPostBack)
                chkMailingAddress.Checked = true;
        }

    }

    /// <summary>
    /// Hosated In Past Text Dropdown.
    /// </summary>
    private void HostedInPastList()
    {
        XmlTextReader reader = new XmlTextReader(Server.MapPath("HostedInPast.Xml"));

        reader.WhitespaceHandling = WhitespaceHandling.None;
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(reader);
        XmlNodeList _names = xmlDoc.GetElementsByTagName("Name");
        for (int i = 0; i < _names.Count; i++)
        {
            if (_names[i].InnerText != null && _names[i].InnerText != "")
            {
                ClientScript.RegisterArrayDeclaration("HostedInPastWith", "'" + _names[i].InnerText + "'");
            }
        }
        reader.Close(); ;
        StringBuilder sb = new StringBuilder();
        sb.Append(" var obj = actb(document.getElementById('" + txtHostedInPast.ClientID + "'), HostedInPastWith);");
        ClientScript.RegisterStartupScript(typeof(string), "jscodeHostedInPast", sb.ToString(), true);

    }

    /// <summary>
    /// Save Prospect
    /// </summary>
    private void SaveProspect()
    {
        //FranchisorService service = new FranchisorService();
        EProspect prospect = new EProspect();
        EAddress addressbilling = new EAddress();
        EAddress addressmailing = new EAddress();
        EProspectDetails objEProspectDetails = new EProspectDetails();
        prospect.ProspectDetails = new EProspectDetails();
        bool blnIsHost = false;

        OtherDAL otherDal = new OtherDAL();
        EZip zipobjbilling = otherDal.CheckCityZip(txtcityBilling.Text, txtzipBilling.Text, ddlstateBilling.SelectedValue);

        EZip zipobjmailing=new EZip();

        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        if (txtzipBilling.Text != "")
        {
            if (zipobjbilling.CityID == 0)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "City name for address is not valid. <br> Please Try again.";

                //ClientScript.RegisterStartupScript(typeof(string), "jscodebilling", "alert('City name for billing address is not valid. <br> Please Try again.');", true);                
                return;

            }
            else if (zipobjbilling.CityID > 0 && zipobjbilling.ZipID == 0)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerHtml = "Address Zip code for the corresponding city is not valid. <br> Please Try again.";

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
                    divErrorMsg.InnerHtml = "City name for mailing address is not valid. <br> Please Try again.";

                    //ClientScript.RegisterStartupScript(typeof(string), "jscodemailing", "alert('City name for mailing address is not valid. <br> Please Try again.');", true);
                    return;
                }
                else if (zipobjmailing.CityID > 0 && zipobjmailing.ZipID == 0)
                {
                    divErrorMsg.Visible = true;
                    divErrorMsg.InnerHtml = "Mailing address Zip code for the corresponding city is not valid. <br> Please Try again.";

                    //ClientScript.RegisterStartupScript(typeof(string), "jscodemailing", "alert('Mailing address Zip code for the corresponding city is not valid. <br> Please Try again.');", true);
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
        if (txtcphoneoffice.Text.Trim().Equals("(___)-___-____"))
            txtcphoneoffice.Text = "";
        prospect.PhoneOffice = objCommonCode.FormatPhoneNumber(txtcphoneoffice.Text);
        prospect.PhoneOther = "";

        prospect.Notes = txtNotes.Text;

        if (ViewState["IsHost"].ToString().Equals("1"))
        {
            prospect.IsHost = true;
            blnIsHost = true;
        }
        else
            prospect.IsHost = false;

        addressbilling.Address1 = txtaddress1Billing.Text;
        addressbilling.Address2 = txtaddress2Billing.Text;

        
        if (Convert.ToInt32(ddlstateBilling.SelectedValue) > 0)
        {
            addressbilling.State = ddlstateBilling.SelectedItem.Text;
            addressbilling.StateID = Convert.ToInt32(ddlstateBilling.SelectedItem.Value);
        }
        else
        {
            addressbilling.State = string.Empty;
        }

        addressbilling.ZipID = txtzipBilling.Text.Length > 0 ? Convert.ToInt32(txtzipBilling.Text) : 0;
        addressbilling.City = txtcityBilling.Text;
        if (txtFax.Text.Trim().Equals("(___)-___-____"))
            txtFax.Text = "";
        addressbilling.Fax = objCommonCode.FormatPhoneNumber(txtFax.Text);

        prospect.Address = addressbilling;

        if (blnIsHost) addressbilling.ZipID = txtzipBilling.Text.Length > 0 ? zipobjbilling.ZipID : 0;
        else addressbilling.ZipID = txtzipBilling.Text.Length > 0 ? Convert.ToInt32(txtzipBilling.Text) : 0;

        addressbilling.CityID = txtcityBilling.Text.Length > 0 ? zipobjbilling.CityID : 0;

        addressbilling.Country = COUNTRY_NAME;
        addressbilling.CountryID = COUNTRY_ID;

        // If mailing address is provided
        if (chkMailingAddress.Checked == true)
        {
            addressmailing.IsMailing = true;
            addressmailing.Address1 = txtaddress1Mailing.Text;
            addressmailing.Address2 = txtaddress2Mailing.Text;

            if (Convert.ToInt32(ddlstateMailing.SelectedValue) > 0)
            {
                addressmailing.State = ddlstateMailing.SelectedItem.Text;
                addressmailing.StateID = Convert.ToInt32(ddlstateBilling.SelectedItem.Value);
            }
            else
            {
                addressmailing.State = string.Empty;
            }
            
            if (blnIsHost) addressmailing.ZipID = txtzipMailing.Text.Length > 0 ? zipobjmailing.ZipID : 0;
            else addressmailing.ZipID = txtzipMailing.Text.Length > 0 ? Convert.ToInt32(txtzipMailing.Text) : 0;

            addressmailing.City = txtcityMailing.Text;
            addressmailing.CityID = txtcityMailing.Text.Length > 0 ? zipobjmailing.CityID : 0;
            addressmailing.Zip = txtzipMailing.Text;
            addressmailing.Fax = "";

            addressmailing.Country = COUNTRY_NAME;
            addressmailing.CountryID = COUNTRY_ID;
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
            prospect.FranchiseeID = arrtemp;
            //prospect.FranchiseeID = arrtemp.ToArray();
        }


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

        Session["Popup"] = "True";
        if (blnIsHost)
        {
            UpdateHostWithContacts(prospect, currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                                currentSession.CurrentOrganizationRole.RoleId.ToString());
        }
        else
        {
            UpdateProspectWithContact(prospect, currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                                currentSession.CurrentOrganizationRole.RoleId.ToString());
        }
        
        ClientScript.RegisterStartupScript(typeof(Page), "Edit Prospect Host", "<script language='javascript'  type='text/javascript' > CloseWindow(); </script>");

    }

    public Int64 UpdateHostWithContacts(EProspect prospect, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = franchisorDAL.SaveHost(prospect, Convert.ToInt32(EOperationMode.Update), userID, shell, role);
        Int64 ContctID = 0;
        Int64 returnContactID = 0;
        int prospectid = 0;
        if (returnresult == 0)
        {
            prospectid = Convert.ToInt32(prospect.ProspectID);

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
                        //Delete the same record
                        franchisorDAL.SaveProspectContact(prospect.Contact[i].ContactID, prospectid, false);
                    }
                }
            }
            if (ContctID > 0 || prospectid > 0 && (prospect.ContactMeeting != null))
            {
                prospect.ContactMeeting.ProspectID = prospectid;
                prospect.ContactMeeting.Contact.ContactID = Convert.ToInt32(returnContactID);
                franchisorDAL.SaveMeeting(prospect.ContactMeeting, Convert.ToInt32(EOperationMode.Insert));
            }
        }
        return returnresult;
    }


    /// <summary>
    /// To update prospect detail
    /// </summary>
    /// <param name="prospectList"></param>
    /// <param name="userID"></param>
    /// <param name="shell"></param>
    /// <param name="role"></param>
    /// <returns></returns>
    public Int64 UpdateProspectWithContact(EProspect prospect, string userID, string shell, string role)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = franchisorDAL.SaveProspect(prospect, Convert.ToInt32(EOperationMode.Update), userID, shell, role);
        Int64 returnContactID = 0;
        int prospectid = 0;

        if (returnresult == 0)
        {
            prospectid = Convert.ToInt32(prospect.ProspectID);

            if (prospect.AddressMailing != null)
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


    /// <summary>
    /// Fill Prospect in case of edit prospect
    /// </summary>
    private void FillProspect(bool blnIsHost)
    {
        //FranchisorService service = new FranchisorService();
        EProspect[] prospect = null;

        if (blnIsHost == false)
        {
            FranchisorDAL objDAL = new FranchisorDAL();
            var listProspect = objDAL.GetProspectDetails(ViewState["ProspectID"].ToString(), 4);
            if (listProspect != null) prospect = listProspect.ToArray();
            //prospect = service.GetProspectDetailsBYProspectID(Convert.ToInt32(ViewState["ProspectID"].ToString()), true);
        }
        else
        {
            FranchisorDAL objDAL = new FranchisorDAL();
            var listProspect = objDAL.GetHostDetails(ViewState["ProspectID"].ToString(), 1);
            if (listProspect != null) prospect = listProspect.ToArray();
            //prospect = service.GetHostDetailsBYHostID(Convert.ToInt32(ViewState["ProspectID"].ToString()), true);
        }

        if (prospect != null)
        {

            ViewState["ProspectID"] = prospect[0].ProspectID;
            ViewState["AddressIDBilling"] = prospect[0].Address.AddressID;
            ViewState["AddressIDMailing"] = prospect[0].AddressMailing.AddressID;
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

            if (prospect[0].PhoneOffice.Trim().Equals("(___)-___-____"))
                txtcphoneoffice.Text = "";
            else txtcphoneoffice.Text = prospect[0].PhoneOffice.ToString();


            txtwebaddress.Text = prospect[0].WebSite.ToString();
            // Billing Zip
            if (prospect[0].Address.ZipID.ToString() != "0")
                txtzipBilling.Text = prospect[0].Address.ZipID.ToString();
            else txtzipBilling.Text = "";

            // Mailing Zip
            if (prospect[0].AddressMailing.ZipID.ToString() != "0")
                txtzipMailing.Text = prospect[0].AddressMailing.ZipID.ToString();
            else txtzipMailing.Text = "";

            txtFax.Text = prospect[0].Address.Fax;
            txtNotes.Text = prospect[0].Notes;


            
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
            txtFacilitiesFee.Text = prospect[0].ProspectDetails.FacilitiesFee;
            int flagShowDivFee = 0;
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

        }

    }

    /// <summary>
    /// Bind all drop downs
    /// </summary>
    private void GetDropDownInfo()
    {
        var masterDal = new MasterDAL();
        var objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();
        
        var objstate = masterDal.GetState(string.Empty, 3);
        
        ddlstateBilling.Items.Add(new ListItem("Select State", "0"));
        ddlstateMailing.Items.Add(new ListItem("Select State", "0"));

        for (int jcount = 0; jcount < objstate.Count; jcount++)
        {
            ddlstateBilling.Items.Add(new ListItem(objstate[jcount].Name, objstate[jcount].StateID.ToString()));
            ddlstateMailing.Items.Add(new ListItem(objstate[jcount].Name, objstate[jcount].StateID.ToString()));
        }
        GetHostType();

    }

    /// <summary>
    /// Bind Type of Hosts 
    /// </summary>
    private void GetHostType()
    {
        FranchisorDAL objDAL = new FranchisorDAL();
        var listProspectType = objDAL.GetProspectType(string.Empty, 3);
        EProspectType[] ptype = null;
        if (listProspectType != null) ptype = listProspectType.ToArray();

        if (ptype.Length > 0)
        {
            ddlHostType.Items.Add(new ListItem("Select Type", "0"));
            for (int count = 0; count < ptype.Length; count++)
            {
                ddlHostType.Items.Add(new ListItem(ptype[count].Name.ToString(), ptype[count].ProspectTypeID.ToString()));
            }
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

    

    
    
}
