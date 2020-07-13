using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.MedicalVendor;
using Falcon.DataAccess.Master;
using Falcon.DataAccess.Other;
using Falcon.Entity.MedicalVendor;
using Falcon.Entity.Other;
using Falcon.App.Lib;

namespace HealthYes.Web.App.Franchisor.HospitalPartner
{
    public partial class AddHospitalFacility : System.Web.UI.Page
    {
        #region "Events"
        protected void Page_Load(object sender, EventArgs e)
        {
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.settitle("Add Hospital Facility");
            obj.hideucsearch();
            Page.Title = "Add Hospital Partner Facility";
            sptitle.InnerText = "Add Hospital Partner Facility";
            obj.SetBreadCrumbRoot = "<a href=\"#\">Hospital Partner</a>";

            if (!Page.IsPostBack)
            {
                GetDropDownInfo();
                ddlMedicalVendor.Attributes.Add("onchange", "GetCampaignGridTable();");

                if (Request["FacilityID"] != null && Request["FacilityID"] != "")
                {
                    hidFacilityId.Value = Request["FacilityID"].ToString();
                    
                    obj.settitle("Edit Hospital Facility");
                    Page.Title = "Edit Hospital Partner Facility";
                    sptitle.InnerText = "Edit Hospital Partner Facility";
                    obj.hideucsearch();
                    obj.SetBreadCrumbRoot = "<a href=\"#\">Hospital Partner</a>";

                    GetFacility(Convert.ToInt32(Request["FacilityID"]));
                }
                else
                {
                    hidFacilityId.Value = "";
                    hidCampaignID.Value = "";
                }

                if (Request.UrlReferrer != null)
                {
                    ViewState["ReferredUrl"] = Request.UrlReferrer.PathAndQuery;
                }
            }
            // Load Campaigns
            if (ddlMedicalVendor.SelectedIndex > -1 && ddlMedicalVendor.SelectedValue!="")
            {
                ClientScript.RegisterStartupScript(typeof(string), "loadcampaigns", "GetCampaignGridTable();", true);
            }

           
        }
        
        protected void ibtnsave_Click(object sender, ImageClickEventArgs e)
        {
            // Save Records
            this.SaveFacility();
        }

        protected void ibtncancel_Click(object sender, ImageClickEventArgs e)
        {
            // Redirect To Page
            if (ViewState["ReferredUrl"] != null && (string) ViewState["ReferredUrl"] != "")
            {
                Response.RedirectUser(this.ResolveUrl(ViewState["ReferredUrl"].ToString()));
            }
            else
            {
                // Manage Hospital Facility
                Response.RedirectUser(this.ResolveUrl("App/Franchisor/HospitalPartner/ManageHospitalPartnerFacility.aspx"));
            }
        }
        #endregion

        #region "Methods"

        public void SaveFacility()
        {

            var otherDal = new OtherDAL();

            // format phone no.
            CommonCode objCommonCode = new CommonCode();

            EZip checkCityZip = otherDal.CheckCityZip(txtCity.Text, txtZip.Text, ddlState.SelectedValue);
            if (checkCityZip.CityID == 0)
            {
                divErrorMsg.InnerText = "City name entered for address is not valid.";
                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }
            else if (checkCityZip.CityID > 0 && checkCityZip.ZipID == 0)
            {
                divErrorMsg.InnerText = "Zipcode entered for address, corresponding to its city name, is not valid.";
                divErrorMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }


            EHospitalFacility objEHospitalFacility = new EHospitalFacility();
            objEHospitalFacility.Address = new EAddress();

            
            Int64 userid = IoC.Resolve<ISessionContext>().UserSession.UserId;
            string strCampaignIds = string.Empty;
            
            objEHospitalFacility.FacilityName = txtFacilityName.Text;
            if (ddlMedicalVendor.SelectedIndex > -1)
            {
                objEHospitalFacility.HospitalPartnerId = Convert.ToInt64(ddlMedicalVendor.SelectedValue);
            }
            if (ViewState["AddressID"] != null)
                objEHospitalFacility.Address.AddressID = Convert.ToInt32(ViewState["AddressID"]);

            objEHospitalFacility.Address.Address1 = txtAddress1.Text;
            objEHospitalFacility.Address.Address2 = txtAddress2.Text;
            objEHospitalFacility.Address.PhoneNumber = objCommonCode.FormatPhoneNumber(txtPhonePrimary.Text);
            objEHospitalFacility.PhoneCell = objCommonCode.FormatPhoneNumber(txtPhoneCell.Text);
            objEHospitalFacility.Address.CityID = checkCityZip.CityID;
            if (ddlState.SelectedIndex > -1)
                objEHospitalFacility.Address.StateID = Convert.ToInt32(ddlState.SelectedValue);
            if (!string.IsNullOrEmpty(hfCountryID.Value))
            {
                objEHospitalFacility.Address.CountryID = Convert.ToInt32(hfCountryID.Value);
            }

            objEHospitalFacility.Address.ZipID = checkCityZip.ZipID;
            objEHospitalFacility.Email = txtEmail.Text;
            if (!string.IsNullOrEmpty(Request["FacilityID"]))
            {
                objEHospitalFacility.HospitalFacilityID = Convert.ToInt64(Request["FacilityID"]);
            }
            // Assign Campaigns
            if (!string.IsNullOrEmpty(hidCampaignID.Value))
            {
                strCampaignIds = hidCampaignID.Value;
                strCampaignIds = strCampaignIds.Replace(",,", ",");
            }

            if (objEHospitalFacility.HospitalFacilityID > 0)
            {
                UpdateHospitalFacilty(objEHospitalFacility, userid, strCampaignIds);
            }
            else
            {
                SaveHospitalFacilty(objEHospitalFacility, userid, strCampaignIds);
            }
        
        // Redirect To Page
            if (ViewState["ReferredUrl"] != null && (string) ViewState["ReferredUrl"] != "")
            {
                Response.RedirectUser(this.ResolveUrl(ViewState["ReferredUrl"].ToString()));
            }
            else
            {
                // Manage Hospital Facility
                Response.RedirectUser(this.ResolveUrl("App/Franchisor/HospitalPartner/ManageHospitalPartnerFacility.aspx"));
            }
        }

        public Int64 SaveHospitalFacilty(EHospitalFacility objHospitalFacility, Int64 userId, string strCampaignIDs)
        {
            Int64 returnvalue = -1;

            MedicalVendorDAL objmvmvuerDal = new MedicalVendorDAL();
            returnvalue = objmvmvuerDal.SaveHospitalFacilty(objHospitalFacility, 2, userId);

            if (returnvalue > 0)
            {
                objmvmvuerDal.SaveHospitalFaciltyCompaign(objHospitalFacility.HospitalFacilityID, "", 2);

                foreach (string strCampaign in strCampaignIDs.Split(new char[] { ',' }))
                {
                    if (!string.IsNullOrEmpty(strCampaign) && strCampaign.Length > 0)
                    {
                        objmvmvuerDal.SaveHospitalFaciltyCompaign(returnvalue, strCampaign, 1);
                    }
                }
            }
            return returnvalue;
        }

        public Int64 UpdateHospitalFacilty(EHospitalFacility objHospitalFacility, Int64 userId, string strCampaignIDs)
        {
            Int64 returnvalue = -1;

            MedicalVendorDAL objmvmvuerDal = new MedicalVendorDAL();
            returnvalue = objmvmvuerDal.SaveHospitalFacilty(objHospitalFacility, 2, userId);

            if (returnvalue > 0)
            {
                
                objmvmvuerDal.SaveHospitalFaciltyCompaign(objHospitalFacility.HospitalFacilityID, "", 2);

                foreach (string strCampaign in strCampaignIDs.Split(new char[] { ',' }))
                {
                    if (!string.IsNullOrEmpty(strCampaign) && strCampaign.Length > 0)
                    {
                        objmvmvuerDal.SaveHospitalFaciltyCompaign(returnvalue, strCampaign, 1);
                    }
                }
            }
            return returnvalue;
        }
        
        private void GetDropDownInfo()
        {
            // Bind State and get country
            MasterDAL masterDal = new MasterDAL();
            ECountry[] objcountry = masterDal.GetCountry(string.Empty, 3).ToArray();

            hfCountryID.Value = objcountry[0].CountryID.ToString();

            var objstate = masterDal.GetState(string.Empty, 3);

            ddlState.Items.Clear();
            ddlState.Items.Add(new ListItem("Select State", "0"));

            for (int icount = 0; icount < objstate.Count; icount++)
            {
                if (objstate[icount].Country.CountryID.ToString().Equals(hfCountryID.Value))
                {
                    ddlState.Items.Add(new ListItem(objstate[icount].Name, objstate[icount].StateID.ToString()));
                }
            }

            // Bind Medical Vendor
            
            MedicalVendorDAL objmvmvuerDal = new MedicalVendorDAL();
            var listMedicalVendor = objmvmvuerDal.GetMedicalVendor();

            if ((listMedicalVendor == null) || (listMedicalVendor.Count == 0))
            {
                ddlMedicalVendor.Items.Clear();
                ddlMedicalVendor.Items.Add(new ListItem("No Medical Vendor Found", ""));
                return;
            }

            EMedicalVendor[] objEMedicalVendor = listMedicalVendor.ToArray();

            ddlMedicalVendor.Items.Clear();
            ddlMedicalVendor.Items.Add(new ListItem("Select Medical Vendor", ""));

            for (int icount = 0; icount < objEMedicalVendor.Length; icount++)
            {
                ddlMedicalVendor.Items.Add(new ListItem(objEMedicalVendor[icount].BusinessName, objEMedicalVendor[icount].MedicalVendorID.ToString()));
            }
        }

        private void GetFacility(int facilityId)
        {
            string strCampaignIDs;

            MedicalVendorDAL objmvmvuerDAL = new MedicalVendorDAL();
            var objEHospitalFacility = objmvmvuerDAL.GetHospitalFacilityDetails(facilityId, 1, out strCampaignIDs);

            if (objEHospitalFacility != null)
            {
                txtFacilityName.Text = objEHospitalFacility.FacilityName;
                if (ddlMedicalVendor.Items.FindByValue(objEHospitalFacility.HospitalPartnerId.ToString()) != null)
                {
                    ddlMedicalVendor.SelectedValue = objEHospitalFacility.HospitalPartnerId.ToString();
                }
                txtAddress1.Text = objEHospitalFacility.Address.Address1;
                txtAddress2.Text = objEHospitalFacility.Address.Address2;
                txtCity.Text = objEHospitalFacility.Address.City;

                ViewState["AddressID"] = objEHospitalFacility.Address.AddressID;

                if (ddlState.Items.FindByValue(objEHospitalFacility.Address.StateID.ToString()) != null)
                {
                    ddlState.SelectedValue = objEHospitalFacility.Address.StateID.ToString();
                }
                txtZip.Text = objEHospitalFacility.Address.ZipID.ToString();
                txtEmail.Text = objEHospitalFacility.Email;
                txtPhoneCell.Text = objEHospitalFacility.PhoneCell;
                txtPhonePrimary.Text = objEHospitalFacility.Address.PhoneNumber;
            }
            ddlMedicalVendor.Enabled = false;
            if (!string.IsNullOrEmpty(strCampaignIDs))
            {
                foreach (string strCampaign in strCampaignIDs.Split(new char[] { ',' }))
                {
                    if (!string.IsNullOrEmpty(strCampaign) && strCampaign.Length > 0)
                    {
                        hidCampaignID.Value = hidCampaignID.Value + strCampaign + ",";
                    }
                }
            }
        }
        #endregion
    }
}
