using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class App_Common_PDFCustomerList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //DataTable dtEvent = (DataTable)Session["PrintCustomerList"];
        //LoadGrid(dtEvent);
        ViewState["SortExp"] = "DateCreated";
        ViewState["SortDir"] = SortDirection.Descending;
        spDate.InnerText = DateTime.Now.AddDays(5).ToLongDateString();
        LoadData();

        //GeneratePDF();


    }

    private void GeneratePDF()
    {
        string pdfname = "CustomerListPDF_" + DateTime.Now.ToFileTimeUtc() + ".pdf";
        string servermappath = Server.MapPath("/pdf/" + pdfname);

        string newpdfpath = Request.Url.AbsoluteUri.Replace(Request.Url.AbsolutePath, "/App/Common/PDFCustomerList.aspx");

        var pdfConverterPath = Server.MapPath(@"~\bin");

        pdfname = IoC.Resolve<IPdfGenerator>().Generate(newpdfpath, servermappath, pdfConverterPath);

        Response.RedirectUser("~/pdf/" + pdfname);
    }

    private void LoadData()
    {
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        var masterDal = new MasterDAL();
        EEvent objevent;
        string rolename = "";
        bool abondonedCustomer = false;
        if (Request.QueryString["RoleName"] != null)
            rolename = Request.QueryString["RoleName"].ToString();

        if (rolename == "FranchiseeAdmin")
        {
            divCustomer.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        else
        {
            divCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
        if (Request.QueryString.Count < 3)
        {
            long pageCount;
            objevent = masterDal.GetCustomerList(0, "", "", "", "", "", "", 0, 0, 0, 1, 10, out pageCount);
        }
        else
        {
            int customerid = 0; string customername = ""; 
            string city = ""; string state = ""; 
            string zip = ""; string startdate = "";
            string enddate = ""; int franchiseeid = 0; int datetype = 0;
           

            if (Request.QueryString["CustomerID"] != null && Request.QueryString["CustomerID"].ToString().Trim().Length > 0)
            {
                customerid = Convert.ToInt32(Request.QueryString["CustomerID"]);
                if (customerid > 0)
                {
                    spCustomerID.InnerText = customerid.ToString();
                }
                else
                {
                    spCustomerID.InnerText = "-N/A-";  
                }
               
            }

            if (Request.QueryString["FranchiseeID"] != null && Request.QueryString["FranchiseeID"].ToString().Trim().Length > 0)
            {
                franchiseeid = Convert.ToInt32(Request.QueryString["FranchiseeID"]);
                if (franchiseeid > 0)
                {
                    spFranchiseeID.InnerText = franchiseeid.ToString();
                }
                else
                {
                    spFranchiseeID.InnerText = "-N/A-";
                }
                if (rolename == "FranchiseeAdmin")
                {
                    divCustomer.Style.Add(HtmlTextWriterStyle.Display, "none");
                }
                else
                {
                    divCustomer.Style.Add(HtmlTextWriterStyle.Display, "block");
                }
            }

            if (Request.QueryString["CustomerName"] != null)
            {
                if (Request.QueryString["CustomerName"].ToString().Trim().Length > 0)
                {
                    customername = Convert.ToString(Request.QueryString["CustomerName"]);
                    spCustomerName.InnerText = customername;
                }
                else
                {
                    spCustomerName.InnerText = "-N/A-";  
                }
            }

            if (Request.QueryString["City"] != null )
            {
                if (Request.QueryString["City"].ToString().Trim().Length > 0)
                {
                    city = Convert.ToString(Request.QueryString["City"]);
                    spCity.InnerText = city;
                }
                else
                {
                    spCity.InnerText = "-N/A-";  
                }
            }

            if (Request.QueryString["State"] != null )
            {
                if (Request.QueryString["State"].ToString().Trim().Length > 0)
                {
                    state = Convert.ToString(Request.QueryString["State"]);
                    spState.InnerText = state;
                }
                else
                {
                    spState.InnerText = "-N/A-";  
                }
            }


            if (Request.QueryString["Zip"] != null && Request.QueryString["Zip"].ToString().Trim().Length > 0)
            {
                if (Request.QueryString["Zip"].ToString().Trim().Length > 0)
                {
                    zip = Convert.ToString(Request.QueryString["Zip"]);
                    spZip.InnerText = zip;
                }
                else
                {
                    spZip.InnerText = "-N/A-";  
                }
            }


            if (Request.QueryString["StartDate"] != null )
            {
                if (Request.QueryString["StartDate"].ToString().Trim().Length > 0)
                {
                    startdate = Convert.ToString(Request.QueryString["StartDate"]);
                    spStartDate.InnerText = startdate;
                }
                else
                {
                    spStartDate.InnerText = "-N/A-";  
                }
            }

            if (Request.QueryString["EndDate"] != null )
            {
                if (Request.QueryString["EndDate"].ToString().Trim().Length > 0)
                {
                    enddate = Convert.ToString(Request.QueryString["EndDate"]);
                    spEndDate.InnerText = enddate;
                }
                else
                {
                    spEndDate.InnerText = "-N/A-";  
                }
            }
            
            if (Request.QueryString["DateType"] != null)
            {
                if (Request.QueryString["DateType"].ToString().Trim().Length > 0)
                {
                    datetype = Convert.ToInt32(Request.QueryString["DateType"]);
                    if (datetype == 0)
                    {
                        spDateRangeBucket.InnerText = "Signup Date";
                        ViewState["SortExp"] = "DateCreated";
                    }
                    else if (datetype == 1)
                    {
                        spDateRangeBucket.InnerText = "Attended Customers";
                        ViewState["SortExp"] = "EventDate";
                    }
                    else if (datetype == 2)
                    {
                        spDateRangeBucket.InnerText = "Customer Date";
                        ViewState["SortExp"] = "RegDate";
                    }
                    else if (datetype == 3)
                        spDateRangeBucket.InnerText = "Paid Customers";
                }

            }
            if (Request.QueryString["Abondoned"] != null)
            {
                if (Request.QueryString["Abondoned"].ToString().Trim().Length > 0 && Convert.ToBoolean(Request.QueryString["Abondoned"].ToString()) == true)
                {
                    abondonedCustomer = Convert.ToBoolean(Request.QueryString["Abondoned"]);
                    spHeaderText.InnerText = "Customer List (Customers who did not register for any event)";
                }

            }

            long pagecount;
            if (abondonedCustomer == false)
            {
                objevent = masterDal.SearchFranchisorCustomerList(customerid, customername, city, state, zip, startdate, enddate, franchiseeid, datetype, 0,0,out pagecount);
            }
            else
            {
                objevent = masterDal.GetCustomerList(customerid,  customername, city, state, zip, startdate, enddate, franchiseeid,  datetype, 2, 0, 0, out pagecount);
            }

        }

        
        
        DataTable dtcustomer = new DataTable();
        dtcustomer.Columns.Add("Name");
        dtcustomer.Columns.Add("Email");
        dtcustomer.Columns.Add("Phone");
        dtcustomer.Columns.Add("RegDate");
        dtcustomer.Columns.Add("EventDate");
        dtcustomer.Columns.Add("Marketing");
        dtcustomer.Columns.Add("Address");
        dtcustomer.Columns.Add("RestAddress");
        dtcustomer.Columns.Add("Event");
        dtcustomer.Columns.Add("Host");
        dtcustomer.Columns.Add("Package");
        dtcustomer.Columns.Add("AddressID");
        dtcustomer.Columns.Add("FranchiseeID");
        dtcustomer.Columns.Add("CustomerID");
        dtcustomer.Columns.Add("TotalRevenue", typeof(float));
        dtcustomer.Columns.Add("State");
        dtcustomer.Columns.Add("City");
        dtcustomer.Columns.Add("Country");
        dtcustomer.Columns.Add("Zip");
        dtcustomer.Columns.Add("AddedBY");
        dtcustomer.Columns.Add("DateCreated", typeof(DateTime));
        if (objevent != null)
        {

            for (int jcount = 0; jcount < objevent.Customer.Count; jcount++)
            {
                string address = objevent.Customer[jcount].Customer.BillingAddress.Address1;
                string restaddress = objevent.Customer[jcount].Customer.BillingAddress.City + " " + objevent.Customer[jcount].Customer.BillingAddress.State + " " + objevent.Customer[jcount].Customer.BillingAddress.Country + " " + objevent.Customer[jcount].Customer.BillingAddress.Zip;

                string username = string.Empty;
                if (objevent.Customer[jcount].Customer.User.MiddleName.Length > 0)
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.MiddleName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }
                else
                {
                    username = objevent.Customer[jcount].Customer.User.FirstName + " " + objevent.Customer[jcount].Customer.User.LastName;
                }

                string role = string.Empty;
                switch (objevent.Customer[jcount].Customer.AddedBy.ToString())
                {
                    case "10":
                        role = "Call Center";
                        break;
                    case "8":
                        role = "Walk Ins";
                        break;
                    default:
                        role = "Internet";
                        break;
                }
                string eventdate = "-N/A-";
                if (objevent.Customer[jcount].Customer.User.DOB != null && objevent.Customer[jcount].Customer.User.DOB.ToString().Length > 0)
                {
                    eventdate = objevent.Customer[jcount].Customer.User.DOB;
                }
                
                string regdateShort = "-N/A-";

                if (objevent.Customer[jcount].Customer.User.DateApplied != null && objevent.Customer[jcount].Customer.User.DateApplied.ToString().Length > 0)
                {
                    regdateShort = objevent.Customer[jcount].Customer.User.DateApplied.ToString("MM/dd/yyyy");
                }
                dtcustomer.Rows.Add(new object[] { username, objevent.Customer[jcount].Customer.User.EMail1, objCommonCode.FormatPhoneNumberGet(objevent.Customer[jcount].Customer.User.PhoneOffice), 
                                                        objevent.Customer[jcount].Customer.User.DateApplied.ToLongDateString(),eventdate,objevent.Customer[jcount].Customer.Gender,address,restaddress,objevent.Customer[jcount].Customer.CollectionMode,
                                                        objevent.Customer[jcount].Customer.ContactMethod,objevent.Customer[jcount].EventPackage.Package.PackageName,objevent.Customer[jcount].Customer.User.HomeAddress.AddressID,
                                                        objevent.Customer[jcount].TechnicianID,objevent.Customer[jcount].Customer.CustomerID, objevent.Customer[jcount].PaymentDetail.Amount,objevent.Customer[jcount].Customer.BillingAddress.State,objevent.Customer[jcount].Customer.BillingAddress.City,objevent.Customer[jcount].Customer.BillingAddress.Country,objevent.Customer[jcount].Customer.BillingAddress.Zip,role,regdateShort
                                                       });
            }

           
        }

        if (abondonedCustomer == true)
        {
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = false;
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
            //grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = false;
        }
        if (abondonedCustomer == false)
        {

            grdCustomerList.Columns[grdCustomerList.Columns.Count - 3].Visible = true;
            grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = true;
            if (Request.QueryString["RoleName"] != null)
            {
                rolename = Request.QueryString["RoleName"].ToString();

                if (rolename == "FranchisorAdmin")
                {
                    grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = true;
                }
                else
                {
                    grdCustomerList.Columns[grdCustomerList.Columns.Count - 2].Visible = false;
                    grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = false;
                }

                if (rolename == "SalesRep")
                {
                    grdCustomerList.Columns[grdCustomerList.Columns.Count - 1].Visible = false;
                }
            }
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " asc";
        }
        else
        {
            dtcustomer.DefaultView.Sort = ViewState["SortExp"].ToString() + " desc";
        }
        dtcustomer = dtcustomer.DefaultView.ToTable();
        grdCustomerList.DataSource = dtcustomer;
        grdCustomerList.DataBind();

        

    }
    
}
