using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.MedicalVendor;
using Falcon.Entity.MedicalVendor;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Deprecated.Utility;
using Falcon.App.Lib;

public partial class MedicalVendor_ContactMV : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Contact Medical Vendor";
        if (!IsPostBack)
        {
            ViewState["SortContactFranchisee"] = SortDirection.Ascending;
            GetContactMedicalVendor();
        }
    }

    private void GetContactMedicalVendor()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        var sessionContext = IoC.Resolve<SessionContext>().UserSession;

        var medicalVendorDal = new MedicalVendorDAL();
        List<EMVMVUser> medicalVendorAdmin = medicalVendorDal.GetMedicalVendorAdmin(sessionContext.CurrentOrganizationRole.OrganizationId.ToString(), 2);

        var dataSource = new DataTable();
        dataSource.Columns.Add("MVMVUserID");
        dataSource.Columns.Add("Name");
        dataSource.Columns.Add("Address");
        dataSource.Columns.Add("Phone");
        dataSource.Columns.Add("Email");

        if (medicalVendorAdmin != null)
        {
            for (int index = 0; index < medicalVendorAdmin.Count; index++)
            {
                string formatName = CommonClass.FormatName(medicalVendorAdmin[index].MVUser.User.FirstName, medicalVendorAdmin[index].MVUser.User.MiddleName, medicalVendorAdmin[index].MVUser.User.LastName);
                string formatAddress = CommonClass.FormatAddress(medicalVendorAdmin[index].MedicalVendor.BusinessAddress.Address1, medicalVendorAdmin[index].MedicalVendor.BusinessAddress.Address2, medicalVendorAdmin[index].MedicalVendor.BusinessAddress.City, medicalVendorAdmin[index].MedicalVendor.BusinessAddress.State, medicalVendorAdmin[index].MedicalVendor.BusinessAddress.Zip);
                dataSource.Rows.Add(new object[] { medicalVendorAdmin[index].MedicalVendorMVUserID, formatName, formatAddress, objCommonCode.FormatPhoneNumberGet(medicalVendorAdmin[index].MedicalVendor.BusinessPhone), medicalVendorAdmin[index].MVUser.User.EMail1 });
            }
        }

        gridcontactfranchisee.DataSource = dataSource;
        gridcontactfranchisee.DataBind();
    }

    protected void gridcontactfranchisee_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }

    protected void gridcontactfranchisee_Sorting(object sender, GridViewSortEventArgs e)
    {
    }

}
