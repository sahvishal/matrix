using System;
using System.Web.UI.WebControls;
using Falcon.App.Lib;
using Falcon.DataAccess.Master;


namespace Falcon.App.UI.Public.UCPublic
{
    public partial class UCPCPInfo : System.Web.UI.UserControl
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        public string FirstName
        {
            get { return txtphyfname.Text; }
            set { txtphyfname.Text = value; }
        }

        public string MiddleName
        {
            get { return txtphymname.Text; }
            set { txtphymname.Text = value; }
        }

        public string LastName
        {
            get { return txtphylname.Text; }
            set { txtphylname.Text = value; }
        }

        public string Address1
        {
            get { return txtphyaddress1.Text; }
            set { txtphyaddress1.Text = value; }
        }

        public string Address2
        {
            get { return txtphyaddress2.Text; }
            set { txtphyaddress2.Text = value; }
        }

        public string Phone
        {
            get { return objCommonCode.FormatPhoneNumber(txtPhyPhone.Text); }
            set { txtPhyPhone.Text = value; }
        }
        public string AlternatePhone
        {
            get { return objCommonCode.FormatPhoneNumber(txtPhyPhoneOther.Text); }
            set { txtPhyPhoneOther.Text = value; }
        }
        public string Email
        {
            get { return txtphyemail.Text; }
            set { txtphyemail.Text = value; }
        }
        public string AlternateEmail
        {
            get { return txtPhyEmailOther.Text; }
            set { txtPhyEmailOther.Text = value; }
        }
        public string City
        {
            get { return txtphyCity.Text; }
            set { txtphyCity.Text = value; }
        }


        public string State
        {
            get { return ddlphystate.SelectedValue; }
            set
            {
                if (ddlphystate.Items.Count == 0)
                {
                    GetDropDownInfo();
                }
                if (ddlphystate.Items.FindByValue(value) != null)
                {
                    ddlphystate.SelectedValue = value;
                }
            }
        }

        public string StateName
        {
            get { return ddlphystate.SelectedItem.Text; }
        }

        public string Zip
        {
            get { return txtphyzip.Text; }
            set { txtphyzip.Text = value; }
        }

        public string Fax
        {
            get { return objCommonCode.FormatPhoneNumber(txtPhyFax.Text); }
            set { txtPhyFax.Text = value; }
        }

        public string WebsiteUrl
        {
            get { return txtWebsite.Text; }
            set { txtWebsite.Text = value; }
        }

        public string CountryId
        {
            get { return ViewState["CountryID"].ToString(); }
            set { ViewState["CountryID"] = value; }
        }

        public string MaillingAddress1
        {
            get { return txtphyMaillingaddress1.Text; }
            set { txtphyMaillingaddress1.Text = value; }
        }

        public string MaillingAddress2
        {
            get { return txtphyMaillingaddress2.Text; }
            set { txtphyMaillingaddress2.Text = value; }
        }


        public string MaillingCity
        {
            get { return txtphyMaillingCity.Text; }
            set { txtphyMaillingCity.Text = value; }
        }


        public string MaillingState
        {
            get { return ddlphyMaillingstate.SelectedValue; }
            set
            {
                if (ddlphyMaillingstate.Items.Count == 0)
                {
                    GetDropDownInfo();
                }
                if (ddlphyMaillingstate.Items.FindByValue(value) != null)
                {
                    ddlphyMaillingstate.SelectedValue = value;
                }
            }
        }

        public string MaillingStateName
        {
            get { return ddlphyMaillingstate.SelectedItem.Text; }
        }

        public string MaillingZip
        {
            get { return txtphyMaillingzip.Text; }
            set { txtphyMaillingzip.Text = value; }
        }

        public bool IsMaillingAddressSame
        {
            get { return chkMaillingAddressSame.Checked; }
            set { chkMaillingAddressSame.Checked = value; }
        }
        public bool IsPcpAddressVerified
        {
            get { return chkVerifiedPcpInfo.Checked; }
            set { chkVerifiedPcpInfo.Checked = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (ddlphystate.Items.Count == 0)
                {
                    GetDropDownInfo();
                }
            }
        }

        private void GetDropDownInfo()
        {
            var masterDal = new MasterDAL();
            var objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();

            string strCountryId = objcountry[0].CountryID.ToString();
            ViewState["CountryID"] = objcountry[0].CountryID.ToString();
            CountryId = ViewState["CountryID"].ToString();

            var objstate = masterDal.GetState(string.Empty, 3);

            ddlphystate.Items.Clear();
            ddlphystate.Items.Add(new ListItem("Select State", "0"));

            ddlphyMaillingstate.Items.Clear();
            ddlphyMaillingstate.Items.Add(new ListItem("Select State", "0"));

            for (int icount = 0; icount < objstate.Count; icount++)
            {
                if (objstate[icount].Country.CountryID.ToString().Equals(strCountryId))
                {
                    ddlphystate.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));
                    ddlphyMaillingstate.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));
                }
            }

        }

    }
}