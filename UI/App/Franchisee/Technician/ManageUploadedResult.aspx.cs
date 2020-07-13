using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//using HealthYes.Web.UI.FranchiseeFranchiseeUserService;
using Falcon.DataAccess.Franchisee;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_Franchisee_Technician_ManageUploadedResult : System.Web.UI.Page
{


    #region "Form Events"
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Result Files Listing";
        Franchisee_Technician_TechnicianMaster obj;
        obj = (Franchisee_Technician_TechnicianMaster)this.Master;
        //obj.SetTitle("View Customer Results");
        //obj.SetBreadcrumb = "<a href=\"HomePage.aspx\">DashBoard</a>";
        if (!IsPostBack)
        {
            this.GetAllDropDownInfo();
            this.GetListUploadedFiles(false);

            txtStartDate.Attributes.Add("ReadOnly", "ReadOnly");
            txtEndDate.Attributes.Add("ReadOnly", "ReadOnly");
            ViewState["SortExp"] = "FileName";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        else
        {
            if (Request.Params["__EVENTTARGET"] != null && Request.Params["__EVENTTARGET"].ToString().Equals("Reset"))
            {
                this.GetListUploadedFiles(false);
            }
        }
    }

    /// <summary>
    /// Fetches List of Uploaded files based on search parameters supplied.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        this.GetListUploadedFiles(true);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dguploadresults_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dguploadresults.PageIndex = e.NewPageIndex;
        dguploadresults.DataSource = (DataTable)ViewState["DSGRID"];
        dguploadresults.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        dguploadresults.PageSize = Convert.ToInt32(ddlRecords.SelectedItem.Value);
        dguploadresults.DataSource = (DataTable)ViewState["DSGRID"];
        dguploadresults.DataBind();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkSortFile_Click(object sender, EventArgs e)
    {
        LinkButton lnktemp = (LinkButton)sender;
        DataTable dtuploadzipinfo = (DataTable)ViewState["DSGRID"];

        if (ViewState["SortExp"].ToString() != lnktemp.CommandArgument)
            ViewState["SortDir"] = SortDirection.Descending;

        ViewState["SortExp"] = lnktemp.CommandArgument;
        if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
        {
            dtuploadzipinfo.DefaultView.Sort = lnktemp.CommandArgument + " asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }
        else
        {
            dtuploadzipinfo.DefaultView.Sort = lnktemp.CommandArgument + " desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }

        dtuploadzipinfo = dtuploadzipinfo.DefaultView.ToTable();

        dguploadresults.DataSource = dtuploadzipinfo;
        dguploadresults.DataBind();

        ViewState["DSGRID"] = dtuploadzipinfo;
    }

    #endregion
    

    #region "User Built Functions"
    
    /// <summary>
    /// Get List of All Uploaded files for test results, based on parameter supplied
    /// Whether to fetch all records or filtered records.
    /// </summary>
    /// <param name="isfilteredrecords"></param>
    private void GetListUploadedFiles(bool isfilteredrecords)
    {
        var masterDal = new MasterDAL();
        var uploadZipInfos = new List<EUploadZipInfo>();

        if (isfilteredrecords == false)
        {
            uploadZipInfos = masterDal.GetListUploadedFiles("", "", "", "", 0, "", 0, 0);
        }
        else
        {
            uploadZipInfos = masterDal.GetListUploadedFiles(txtFileName.Text, txtevent.Text, txtStartDate.Text, txtEndDate.Text, Convert.ToInt32(ddluploadedby.SelectedItem.Value), Convert.ToInt32(ddlstatus.SelectedItem.Value) > 0 ? ddlstatus.SelectedItem.Text : "", 0, 1);
        }

        var dtuploadzipinfo = new DataTable();
        dtuploadzipinfo.Columns.Add("UploadZipInfoID");
        dtuploadzipinfo.Columns.Add("FileName");
        dtuploadzipinfo.Columns.Add("FilePath");
        dtuploadzipinfo.Columns.Add("UploadDate", typeof(DateTime));
        dtuploadzipinfo.Columns.Add("FileSize");
        dtuploadzipinfo.Columns.Add("Host");
        dtuploadzipinfo.Columns.Add("EventDate");
        dtuploadzipinfo.Columns.Add("CustomerScreened");
        dtuploadzipinfo.Columns.Add("TechnicianID");
        dtuploadzipinfo.Columns.Add("TechnicianName");
        dtuploadzipinfo.Columns.Add("HoursAfterEvent"); 
        dtuploadzipinfo.Columns.Add("SuccessRate");
        dtuploadzipinfo.Columns.Add("TotalRecords");
        dtuploadzipinfo.Columns.Add("FailRecords");
        dtuploadzipinfo.Columns.Add("RecordsNotInZip");
        dtuploadzipinfo.Columns.Add("UploadTime");
        dtuploadzipinfo.Columns.Add("ParseTime");
        dtuploadzipinfo.Columns.Add("LogURL");
        dtuploadzipinfo.Columns.Add("EventID");
        string physicalpathpart = ConfigurationManager.AppSettings["PathInDB"].ToLower().ToString();
        string apppathpart = ConfigurationManager.AppSettings["PathToVIEW"].ToLower().ToString();
        decimal successrate = 0.00M;
        string logurl = "";

        foreach (EUploadZipInfo objzipinfo in uploadZipInfos)
        {
            try
            {
                logurl = "<a href=\"javascript:alert('Log Not Ready Yet.');\">Log </a>";
                successrate = 0.00M;
                string filePath = objzipinfo.FileName;
                filePath = filePath.ToLower().Replace(physicalpathpart, apppathpart);
                filePath = filePath.Replace("\\", "/");

                string filename = objzipinfo.FileName.Substring(objzipinfo.FileName.LastIndexOf("\\") + 1, objzipinfo.FileName.Length - objzipinfo.FileName.LastIndexOf("\\") - 1);
                Decimal filesize = Convert.ToDecimal(objzipinfo.FileSize) / (1024 * 1024);
                filesize = Decimal.Round(filesize, 2);


                if (objzipinfo.TotalCount > 0)
                {
                    successrate = decimal.Ceiling(Convert.ToDecimal((Convert.ToDecimal(objzipinfo.TotalCount - objzipinfo.FailureCount) / Convert.ToDecimal(objzipinfo.TotalCount)) * 100));
                    logurl = "<a href='uploadlog.aspx?UploadZipInfoID=" + objzipinfo.UploadZipInfoID.ToString() + "'>Log </a>";
                }

                string hostdetails = objzipinfo.Event != null ? objzipinfo.Event.Host.Name : "";

                ListItem itemdropdown = ddluploadedby.Items.FindByValue(objzipinfo.UploadedBy.FranchiseeFranchiseeUserID.ToString());

                DateTime dtUploadedAt = Convert.ToDateTime(objzipinfo.UploadStartTime);
                DateTime dtEventEndAt = objzipinfo.Event != null ? Convert.ToDateTime(objzipinfo.Event.EventDate).Date.Add(Convert.ToDateTime(objzipinfo.Event.EventEndTime).TimeOfDay) : DateTime.Now;
                TimeSpan tsdiff = dtUploadedAt.Subtract(dtEventEndAt);

                if (objzipinfo.Event != null)
                    dtuploadzipinfo.Rows.Add(new object[] { objzipinfo.UploadZipInfoID, filename, filePath, Convert.ToDateTime(objzipinfo.UploadStartTime).ToShortDateString(), 
                                                            filesize, hostdetails, Convert.ToDateTime(objzipinfo.Event.EventDate).ToLongDateString(), 
                                                            objzipinfo.Event.CustomerCount, objzipinfo.UploadedBy.FranchiseeFranchiseeUserID, 
                                                            itemdropdown.Text, Convert.ToInt32(tsdiff.TotalHours).ToString(), successrate.ToString(), 
                                                            objzipinfo.TotalCount, objzipinfo.FailureCount, objzipinfo.RecordsNotFoundCount.ToString(), 
                                                            objzipinfo.UploadTime, objzipinfo.ParseTime, logurl, objzipinfo.Event.EventID });
            }
            catch
            {

            }
        }

        if (dtuploadzipinfo.Rows.Count <= 0)
        {
            spnumreordsound.InnerHtml = " (No Records Found)";
            dguploadresults.DataSource = null;
            dguploadresults.DataBind();
            divUploadResults.Style.Add(HtmlTextWriterStyle.Display, "none");
            ddlRecords.Enabled = false;
            return;
        }
        else
        {
            spnumreordsound.InnerHtml = " (" + dtuploadzipinfo.Rows.Count.ToString() + " Records Found)";
            divUploadResults.Style.Add(HtmlTextWriterStyle.Display, "block");
            ddlRecords.Enabled = true;
        }

        ViewState["DSGRID"] = dtuploadzipinfo;
        dguploadresults.DataSource = dtuploadzipinfo;
        dguploadresults.DataBind();
    }

    /// <summary>
    /// Fills all the drop down with values from db
    /// </summary>
    private void GetAllDropDownInfo()
    {
        //FranchiseeFranchiseeUserService objservice = new FranchiseeFranchiseeUserService();

        List<Falcon.Entity.Franchisee.EFranchiseeFranchiseeUser> arrfranchiseeuser;

        var franchiseeDal = new FranchiseeDAL();
        arrfranchiseeuser = franchiseeDal.GetFranchiseeEmployeeByName("", 0, 6);

        for (int icount = 0; icount < arrfranchiseeuser.Count; icount++)
        {
            string techname = arrfranchiseeuser[icount].FranchiseeUser.User.FirstName;
            techname += arrfranchiseeuser[icount].FranchiseeUser.User.MiddleName.Length > 0 ? " " + arrfranchiseeuser[icount].FranchiseeUser.User.MiddleName : "";
            techname += arrfranchiseeuser[icount].FranchiseeUser.User.LastName.Length > 0 ? " " + arrfranchiseeuser[icount].FranchiseeUser.User.LastName : "";
            ddluploadedby.Items.Add(new ListItem(techname, arrfranchiseeuser[icount].FranchiseeFranchiseeUserID.ToString()));
        }

        ddluploadedby.Items.Insert(0, new ListItem("Select Technician", "0"));
    }

    #endregion


}
