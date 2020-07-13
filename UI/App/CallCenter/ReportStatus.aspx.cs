using System;
using System.Collections.Generic;
using System.Data;
using Falcon.DataAccess.Master;
using Falcon.App.Core.Deprecated;
using Falcon.App.Core.Deprecated.Utility;
using EEvent=Falcon.Entity.Other.EEvent;

public partial class CallCenter_ReportStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /// get the customer detail
        /// 
        var masterDal = new MasterDAL();
        Int32 intCustomerId = 0;

        if (Request.QueryString["CustomerID"] != null)
        {
            intCustomerId = Convert.ToInt32(Request.QueryString["CustomerID"]);
            ViewState["intCustomerID"] = intCustomerId;

            

            Falcon.Entity.Other.ECustomers objCustomer = masterDal.SearchCustomers(intCustomerId, "", "", "", "", "", 1, null, "", "")[0];

            string strCustname = CommonClass.FormatName(objCustomer.User.FirstName, objCustomer.User.MiddleName, objCustomer.User.LastName);
            dvCustName.InnerText = strCustname;
            string strCustAddress = CommonClass.FormatAddress(objCustomer.User.HomeAddress.Address1, objCustomer.User.HomeAddress.Address2, objCustomer.User.HomeAddress.City, objCustomer.User.HomeAddress.State, objCustomer.User.HomeAddress.Zip);
            dvCustAddress.InnerText = strCustAddress;
            dvCustEmail.InnerText = objCustomer.User.EMail1;
            
        }

        List<EEvent> customerEvent = masterDal.GetCustomerEventPackageDetails(intCustomerId.ToString() , 1);
        DataTable tbltemp1 = new DataTable();
      
        tbltemp1.Columns.Add("EventID");
        tbltemp1.Columns.Add("EventName");
        tbltemp1.Columns.Add("Date");
        tbltemp1.Columns.Add("City");
        tbltemp1.Columns.Add("AppointmentTime");
        tbltemp1.Columns.Add("PackageAvailed");
        tbltemp1.Columns.Add("PaymentMethod");
        tbltemp1.Columns.Add("ReportStatus");
        tbltemp1.Columns.Add("HealthInformation");

        for (Int32 intCounter=0; intCounter < customerEvent.Count; intCounter++)
        {
            string strEventDate = Convert.ToDateTime(customerEvent[intCounter].EventDate).ToString("MMM dd yyyy");
            
            string strAppointmentStartTime = Convert.ToDateTime(customerEvent[intCounter].Customer[0].EventAppointment.StartTime).ToString("hh:mm");
            string strAppointmentEndTime = Convert.ToDateTime(customerEvent[intCounter].Customer[0].EventAppointment.EndTime).ToString("hh:mm");
            
            string strAppointmentTime = strAppointmentStartTime.ToString() + " - " + strAppointmentEndTime.ToString();
            string strPackage = customerEvent[intCounter].Customer[0].EventPackage.Package.PackageName;
            string strReportStatus = customerEvent[intCounter].Customer[0].Interpreted.ToString();
            string strPayMethod = customerEvent[intCounter].Customer[0].PaymentDetail.PaymentType.Name;

         tbltemp1.Rows.Add(new object[] { customerEvent[intCounter].EventID,customerEvent[intCounter].Name,
           strEventDate ,customerEvent[intCounter].Host.Address.City ,
             strAppointmentTime,strPackage,strPayMethod,strReportStatus,"Health Info"});
        
        }

        
        grideventhistory_rs.DataSource = tbltemp1;
        grideventhistory_rs.DataBind();
    }

}
