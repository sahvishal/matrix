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
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;

namespace HealthYes.Web.App.Franchisor
{
    public partial class ManageHospitalPartnerFacility : System.Web.UI.Page
    {
        # region "Events"
        protected void Page_Load(object sender, EventArgs e)
        {
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/Dashboard.aspx\">DashBoard</a>";
            obj.hideucsearch();
            obj.settitle("Manage Hospital Partner Facility");
            Page.Title = "Manage Hospital Partner Facility";
            if (!IsPostBack)
            {
                //HealthYes.Web.UI.MVUserService.MVUserService objMVUserService = new HealthYes.Web.UI.MVUserService.MVUserService();
                //HealthYes.Web.UI.MVUserService.EHospitalFacility[] objLHF = objMVUserService.GetAllActiveHPFacility();

                MedicalVendorDAL mvDAL = new MedicalVendorDAL();
                var listHospitalFacility = mvDAL.GetHospitalFacility("", 0);
                EHospitalFacility[] objLHF = null;

                if (listHospitalFacility != null) objLHF = listHospitalFacility.ToArray();

                BindData(objLHF);
            }
        }

        protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //HealthYes.Web.UI.MVUserService.MVUserService objMVUserService = new HealthYes.Web.UI.MVUserService.MVUserService();
            //HealthYes.Web.UI.MVUserService.EHospitalFacility[] objLHF = objMVUserService.SearchHPFacility(txtHPFacility.Text.Trim());

            MedicalVendorDAL mvDAL = new MedicalVendorDAL();
            var listHospitalFacility = mvDAL.GetHospitalFacility(txtHPFacility.Text.Trim(), 1);

            EHospitalFacility[] objLHF = null;
            if (listHospitalFacility != null) objLHF = listHospitalFacility.ToArray();

            BindData(objLHF);
        }

        protected void grdhospitalpartner_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdhospitalpartner.PageIndex = e.NewPageIndex;
            DataTable dt = (DataTable)ViewState["tblHF"];
            grdhospitalpartner.DataSource = dt;
            grdhospitalpartner.DataBind();
        }

        protected void lnkDeleteHF_Click(object sender, EventArgs e)
        {
            LinkButton lnkDeleteHF = (LinkButton)sender;
            int facilityid = Convert.ToInt32(lnkDeleteHF.CommandArgument);

            MedicalVendorDAL mvDAL = new MedicalVendorDAL();
            mvDAL.DeleteHospitalFacility(facilityid);

            //HealthYes.Web.UI.MVUserService.MVUserService objMVUserService = new HealthYes.Web.UI.MVUserService.MVUserService();
            //objMVUserService.DeleteHospitalFacility(facilityid, true);

            //HealthYes.Web.UI.MVUserService.EHospitalFacility[] objLHF = objMVUserService.SearchHPFacility(txtHPFacility.Text.Trim());

            var listHospitalFacility = mvDAL.GetHospitalFacility(txtHPFacility.Text.Trim(), 1);

            EHospitalFacility[] objLHF = null;
            if (listHospitalFacility != null) objLHF = listHospitalFacility.ToArray();

            BindData(objLHF);
            
        }

        # endregion

        # region "Methods"

        //private void BindData(HealthYes.Web.UI.MVUserService.EHospitalFacility[] objLHF)
        private void BindData(EHospitalFacility[] objLHF)
        {
            DataTable tbltemp = new DataTable();
            tbltemp.Columns.Add("FacilityID");
            tbltemp.Columns.Add("FacilityName");
            tbltemp.Columns.Add("HospitalPartnerId");
            tbltemp.Columns.Add("MedicalVendor");
            tbltemp.Columns.Add("Address1");
            tbltemp.Columns.Add("Address2");
            tbltemp.Columns.Add("City");
            tbltemp.Columns.Add("State");
            tbltemp.Columns.Add("Zip");
            tbltemp.Columns.Add("Address");

            if (objLHF != null && objLHF.Length > 0)
            {
                for (int count = 0; count < objLHF.Length; count++)
                {
                    string address = Falcon.App.Lib.CommonCode.AddressMultiLine(objLHF[count].Address.Address1, objLHF[count].Address.Address2, objLHF[count].Address.City, objLHF[count].Address.State, objLHF[count].Address.Zip);

                    tbltemp.Rows.Add(new object[] { 
                                                objLHF[count].HospitalFacilityID
                                                ,objLHF[count].FacilityName
                                                ,objLHF[count].HospitalPartnerId
                                                ,objLHF[count].MedicalVendor
                                                ,objLHF[count].Address.Address1
                                                ,objLHF[count].Address.Address2
                                                ,objLHF[count].Address.City
                                                ,objLHF[count].Address.State
                                                ,objLHF[count].Address.Zip
                                                ,address});
                }
                ViewState["tblHF"] = tbltemp;
                grdhospitalpartner.DataSource = tbltemp;
                grdhospitalpartner.DataBind();

                Span1.InnerHtml = "Total &nbsp;" ;
                Span2.InnerText = objLHF.Length.ToString() + " Results Found";
                divGrd.Style.Add(HtmlTextWriterStyle.Display, "block");
            }
            else
            {
                Span1.InnerHtml = "Total &nbsp;";
                Span2.InnerText = "0 Results Found";
                divGrd.Style.Add(HtmlTextWriterStyle.Display, "none");
            }
        }

        # endregion

        

        
    }
}
