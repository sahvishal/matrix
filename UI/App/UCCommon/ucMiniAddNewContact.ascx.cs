using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using Falcon.App.Lib;

//using HealthYes.Web.UI.FranchisorService;

public partial class App_UCCommon_ucMiniAddNewContact : UserControl
{
    public event EventHandler clicking;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var prospectContactRoleRepository = IoC.Resolve<IProspectContactRoleRepository>();
            var listProspectContactRole = prospectContactRoleRepository.GetAllProspectContactRole();
            var listContactRole = new List<EProspectContactRole>();
            if (listProspectContactRole != null)
            {

                foreach (var drproscont in listProspectContactRole)
                {
                    var objproscontrole = new EProspectContactRole();
                    objproscontrole.ProspectContactRoleID = drproscont.FirstValue;
                    objproscontrole.ProspectContactRoleName = drproscont.SecondValue;
                    listContactRole.Add(objproscontrole);
                }

            }

            listContactRole.ForEach(x => chkRoleContact.Items.Add(new ListItem(System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(x.ProspectContactRoleName, true), System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(x.ProspectContactRoleID.ToString(), true))));
            //EProspectContactRole[] prospectContactRole = null;
            //if (listContactRole != null) prospectContactRole = listContactRole.ToArray();

            //for (int pcount = 0; pcount < prospectContactRole.Length; pcount++)
            //{
            //    chkRoleContact.Items.Add(new ListItem(prospectContactRole[pcount].ProspectContactRoleName, HttpUtility.UrlEncode(prospectContactRole[pcount].ProspectContactRoleID.ToString())));
            //}
        }

        for (int icount = 0; icount < chkRoleContact.Items.Count; icount++)
            this.Page.ClientScript.RegisterArrayDeclaration("ArrCheckBoxValue", chkRoleContact.Items[icount].Value);

        txtPhoneExtension.Attributes.Add("onKeyDown", "return txtkeypress(event);");

    }

    protected void Onclicking()
    {
        if (clicking != null)
        {
            clicking(this, new System.EventArgs());
        }
    }

    public void HideRole()
    {
        divRole.Style["display"] = "none";
    }

    public void ShowRole()
    {
        divRole.Style["display"] = "block";
    }

    public void SetFields(DataView dv, Int64 contactID, int RowNumber)
    {
        ViewState["ContactID"] = contactID;
        ViewState["RowNumber"] = RowNumber;

        int position = 0;
        if (contactID <= 0) position = RowNumber;

        txtTitle.Text = Convert.ToString(dv[position]["Salutation"]);
        txtFName.Text = Convert.ToString(dv[position]["FirstName"]);
        txtMName.Text = Convert.ToString(dv[position]["MiddleName"]);
        txtLName.Text = Convert.ToString(dv[position]["LastName"]);
        txtPhoneOffice.Text = Convert.ToString(dv[position]["Phone"]);
        txtPhoneExtension.Text = Convert.ToString(dv[position]["PhoneExtension"]);
        txtEmailContact.Text = Convert.ToString(dv[position]["Email"]);
        txtTitleContact.Text = Convert.ToString(dv[position]["Title"]);
        txtBday.Text = Convert.ToString(dv[position]["DateOfBirth"]);
        txtFax.Text = Convert.ToString(dv[position]["Fax"]);
        txtPhoneHome.Text = Convert.ToString(dv[position]["PhoneHome"]);
        txtPhoneCell.Text = Convert.ToString(dv[position]["PhoneCell"]);
        txtSecondaryEmail.Text = Convert.ToString(dv[position]["SecondaryEmail"]);
        txtNotesContact.Text = Convert.ToString(dv[position]["ContactNote"]);
        if (Convert.ToBoolean(dv[position]["Gender"]))
        {
            rbtMale.Checked = true;
            rbtFemale.Checked = false;
        }
        else
        {
            rbtMale.Checked = false;
            rbtFemale.Checked = true;
        }


        string strRole = Convert.ToString(dv[position]["Role"]);
        //strRole = strRole.Substring(0, strRole.Length - 1);
        string[] strRoles = strRole.Split(',');
        for (int rcount = 0; rcount < strRoles.Length; rcount++)
        {
            for (int pcount = 0; pcount < chkRoleContact.Items.Count; pcount++)
            {
                if (strRoles[rcount].Trim() == chkRoleContact.Items[pcount].Value)
                {
                    chkRoleContact.Items[pcount].Selected = true;
                }
                else
                {
                    chkRoleContact.Items[pcount].Selected = false;
                }
            }
        }
        txtNotesContact.Text = Convert.ToString(dv[position]["ContactNote"]);

    }



    public EContact GetFields(out int rownumber)
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        EContact objcontact = new EContact();
        //objcontact = new EContact();

        if (ViewState["RowNumber"] != null)
            rownumber = Convert.ToInt32(ViewState["RowNumber"]);
        else
            rownumber = -1;

        if (ViewState["ContactID"] != null)
            objcontact.ContactID = Convert.ToInt32(ViewState["ContactID"]);
        else
            objcontact.ContactID = 0;

        objcontact.Title = txtTitle.Text;
        objcontact.FirstName = txtFName.Text;
        objcontact.LastName = txtLName.Text;
        objcontact.MiddleName = txtMName.Text;
        objcontact.PhoneOffice = objCommonCode.FormatPhoneNumber(txtPhoneOffice.Text);
        objcontact.WebSite = "";
        objcontact.Phone1Extension = txtPhoneExtension.Text;

        objcontact.EMail = txtEmailContact.Text;
        objcontact.PhoneCell = objCommonCode.FormatPhoneNumber(txtPhoneCell.Text);
        objcontact.PhoneHome = objCommonCode.FormatPhoneNumber(txtPhoneHome.Text);
        objcontact.EmailWork = txtSecondaryEmail.Text;
        objcontact.DateOfBirth = txtBday.Text;
        objcontact.Fax = objCommonCode.FormatPhoneNumber(txtFax.Text);

        objcontact.DesignationTitle = txtTitleContact.Text;
        objcontact.Gender = Convert.ToBoolean(rbtMale.Checked);
        List<EProspectContactRole> prospectRole = new List<EProspectContactRole>();
        for (int pcount = 0; pcount < chkRoleContact.Items.Count; pcount++)
        {
            if (chkRoleContact.Items[pcount].Selected)
            {
                EProspectContactRole eprospect = new EProspectContactRole();
                eprospect.ProspectContactRoleID = Convert.ToInt16(chkRoleContact.Items[pcount].Value);
                eprospect.ProspectContactRoleName = Convert.ToString(chkRoleContact.Items[pcount].Text);
                prospectRole.Add(eprospect);
            }

        }
        //objcontact.ListProspectContactRole = prospectRole.ToArray();
        objcontact.ListProspectContactRole = prospectRole;

        objcontact.Note = txtNotesContact.Text;

        ViewState["ContactID"] = null;
        ViewState["RowNumber"] = -1;

        return objcontact;
    }

    protected void ibtnSaveContact_Click(object sender, ImageClickEventArgs e)
    {
        Onclicking();
    }
    // 
    public void SetFields(EContact objEContact)
    {
        if (objEContact != null)
        {
            txtTitle.Text = objEContact.Title;
            txtFName.Text = objEContact.FirstName;
            txtMName.Text = objEContact.MiddleName;
            txtLName.Text = objEContact.LastName;
            txtPhoneOffice.Text = objEContact.PhoneOffice;
            txtPhoneExtension.Text = objEContact.Phone1Extension;
            txtEmailContact.Text = objEContact.EMail;
            txtTitleContact.Text = objEContact.DesignationTitle;
            txtBday.Text = objEContact.DateOfBirth;
            txtFax.Text = objEContact.Fax;
            txtPhoneHome.Text = objEContact.PhoneHome;
            txtPhoneCell.Text = objEContact.PhoneCell;
            txtSecondaryEmail.Text = objEContact.EmailWork;
            txtNotesContact.Text = objEContact.Note;

            //for (int rcount = 0; rcount < objEContact.ListProspectContactRole.Length; rcount++)
            for (int rcount = 0; rcount < objEContact.ListProspectContactRole.Count; rcount++)
            {
                for (int pcount = 0; pcount < chkRoleContact.Items.Count; pcount++)
                {
                    if (objEContact.ListProspectContactRole[rcount].ProspectContactRoleID.ToString().Trim() == chkRoleContact.Items[pcount].Value)
                    {
                        chkRoleContact.Items[pcount].Selected = true;
                    }
                }
            }
        }
    }

    public string ContactTitle
    {
        set
        {
            pgtitle.InnerHtml = value;
        }
    }

    public string FirstName
    {
        get { return txtFName.Text; }
    }
    public string MiddleName
    {
        get { return txtMName.Text; }
    }
    public string LastName
    {
        get { return txtLName.Text; }
    }

}
