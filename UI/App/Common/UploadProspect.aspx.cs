using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Other;
using System.IO;
using System.Web.UI.WebControls;
using Falcon.App.Infrastructure.Repositories;
using System.Linq;
using Falcon.App.Infrastructure.Users.Repositories;
using Falcon.App.Core.Users.Enum;

public partial class Franchisor_UploadProspect : Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Franchisor_FranchisorMaster obj;
            obj = (Franchisor_FranchisorMaster)this.Master;
            obj.settitle("Upload Prospects");
            obj.hideucsearch();

            ddlListType.Attributes.Add("onchange", "ChangeProspectList();");

            var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

            if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
            {
                obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/Dashboard.aspx\">DashBoard</a>";
                spnFranchiess.InnerText = "Franchisee:";
                hidRole.Value = "FranchisorAdmin";
            }
            else if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
            {
                obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/Dashboard.aspx\">DashBoard</a>";
                spnFranchiess.InnerText = "SalesRep:";
                hidRole.Value = "FranchiseeAdmin";
            }
            else if (orgUser.CheckRole((long)Roles.SalesRep))
            {
                obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisee/SalesRep/Dashboard.aspx\">DashBoard</a>";
                spnFranchiess.Style.Add(HtmlTextWriterStyle.Display, "none");
                ddlSalesPerson.Style.Add(HtmlTextWriterStyle.Display, "none");
                hidRole.Value = "SalesRep";
            }
            // Load Prospect Type
            LoadProspectType();
            BindFranchiseeSalesRep();
        }
    }

    protected void ibtnPreviewUpload_Click(object sender, ImageClickEventArgs e)
    {
        DataSet ds = new DataSet();
        string uploadedfilename = string.Empty;
        string saveFolder = string.Empty;
        string saveFile = string.Empty;
        decimal dFileSizeB = 0;
        decimal dFileSizeKB = 0;
        decimal dFileSizeMB = 0;

        // Check rolls and redirect

        // Manage UI for host as well as customer prospect
        if (ddlListType.SelectedItem.Text.Equals("Host Prospect"))
        {
            spnFranchiess.Style.Add(HtmlTextWriterStyle.Display, "block");
            ddlSalesPerson.Style.Add(HtmlTextWriterStyle.Display, "block");
            lnkSampleUpladFile.HRef = "/App/Franchisor/ProspectSample.csv";
        }
        else
        {
            spnFranchiess.Style.Add(HtmlTextWriterStyle.Display, "none");
            ddlSalesPerson.Style.Add(HtmlTextWriterStyle.Display, "none");
            lnkSampleUpladFile.HRef = "/App/Franchisor/ProspectCustomerSample.csv";
        }
        if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.SalesRep))
        {
            spnFranchiess.Style.Add(HtmlTextWriterStyle.Display, "none");
            ddlSalesPerson.Style.Add(HtmlTextWriterStyle.Display, "none");
        }

        if (FileUpload1.HasFile)
        {
            dFileSizeB = FileUpload1.PostedFile.ContentLength;
            dFileSizeKB = (dFileSizeB / 1024);
            dFileSizeMB = (dFileSizeB / 1048576);
            // If The File size is grater than 5 MB
            if (dFileSizeMB > 5)
            {
                errordiv.InnerText = "The Maximum File Size should be 5 MB";
                errordiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }
            Session["FileSizeKB"] = decimal.Round(dFileSizeKB, 2).ToString();
            uploadedfilename = FileUpload1.FileName.ToLower();
            string fileExtension = string.Empty;
            string filePrimaryFileName = string.Empty;

            if (!string.IsNullOrEmpty(uploadedfilename))
            {
                fileExtension = uploadedfilename.Substring(uploadedfilename.LastIndexOf('.') + 1, uploadedfilename.Length - uploadedfilename.LastIndexOf('.') - 1);
                filePrimaryFileName = uploadedfilename.Substring(0, uploadedfilename.LastIndexOf('.'));
            }
            if (fileExtension.Equals("csv"))
            {
                //saveFolder = ConfigurationManager.AppSettings["UploadCSVFolder"];
                //saveFolder = Server.MapPath(saveFolder);
                var mediaRepository = IoC.Resolve<IMediaRepository>();
                saveFolder = mediaRepository.GetUploadCsvMediaFileLocation().PhysicalPath;

                saveFile = filePrimaryFileName + "_" + DateTime.Now.ToFileTimeUtc() + ".csv";
                FileUpload1.SaveAs(saveFolder + saveFile);

                // Validate File [all fields that is in CSV format]
                if (ddlListType.SelectedItem.Text.Equals("Host Prospect"))
                {
                    if (!ValidateCSVColumn(saveFolder + saveFile))
                    {
                        errordiv.InnerText = "The Fields in CSV file are not correct as in the sample CSV format.<br>For correct format,please download the sample CSV file.";
                        errordiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                        return;

                    }
                }
                else
                {
                    if (!ValidateCustomerCSV(saveFolder + saveFile))
                    {
                        errordiv.InnerText = "The Fields in CSV file are not correct as in the sample CSV format.<br>For correct format,please download the sample CSV file.";
                        errordiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                        return;
                    }
                }


                // Uploaded file name with path in session
                Session["UploadedFile"] = saveFolder + saveFile;
            }
            else
            {
                errordiv.InnerText = "You can upload only .csv file format";
                errordiv.Style.Add(HtmlTextWriterStyle.Display, "block");
                return;
            }
        }
        else
        {
            errordiv.InnerText = "Please , Browse and select the file to Upload";
            errordiv.Style.Add(HtmlTextWriterStyle.Display, "block");
            return;
        }

        if (!string.IsNullOrEmpty(txtListName.Text))
            Session["ListName"] = txtListName.Text;

        if (!string.IsNullOrEmpty(txtListSource.Text))
            Session["ListSource"] = txtListSource.Text;

        if (ddlListType.SelectedIndex >= 0)
        {
            Session["ListType"] = ddlListType.SelectedItem.Text;
            Session["ListTypeID"] = ddlListType.SelectedItem.Value;
        }

        if (!string.IsNullOrEmpty(saveFile))
            Session["ListFileName"] = saveFile;

        if (!string.IsNullOrEmpty(uploadedfilename))
            Session["ListFileName1"] = uploadedfilename;

        // Assigned To FranchiessID
        int FranchiessID = 0;
        if (ddlSalesPerson.SelectedIndex > -1)
        {
            FranchiessID = Convert.ToInt32(ddlSalesPerson.SelectedValue);
        }

        if (FranchiessID > 0)
        {
            Session["FranchiessID"] = FranchiessID.ToString();
        }
        Response.RedirectUser("/App/Common/UploadProspectPreview.aspx");
    }

    protected void ibtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;

        if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisor/Dashboard.aspx"));
        }
        else if (orgUser.CheckRole((long)Roles.FranchiseeAdmin))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisee/Dashboard.aspx"));
        }
        else if (orgUser.CheckRole((long)Roles.SalesRep))
        {
            Response.RedirectUser(this.ResolveUrl("/App/Franchisee/SalesRep/Dashboard.aspx"));
        }
    }

    /// <Manage Prospect List>
    /// 
    /// </Manage>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkManageProspectList_Click(object sender, EventArgs e)
    {
        Response.RedirectUser("/App/Common/ManageProspectList.aspx");
    }





    private void LoadProspectType()
    {

        FranchisorDAL objFranchisorDal = new FranchisorDAL();
        EProspectListType[] objProspectListType = null;
        var listProspectListType = objFranchisorDal.GetProspectListType(1);
        if (listProspectListType != null)
            objProspectListType = listProspectListType.ToArray();

        DataTable dtProspectListType = new DataTable();

        dtProspectListType.Columns.Add("ProspectListTypeID", typeof(Int64));
        dtProspectListType.Columns.Add("ProspectListType");

        if (objProspectListType != null)
        {
            for (int icount = 0; icount < objProspectListType.Length; icount++)
            {
                dtProspectListType.Rows.Add(new object[] { objProspectListType[icount].ProspectListTypeID, objProspectListType[icount].ProspectListName });
            }
        }
        ddlListType.DataSource = dtProspectListType;
        ddlListType.DataValueField = "ProspectListTypeID";
        ddlListType.DataTextField = "ProspectListType";
        ddlListType.DataBind();
    }
    /// <summary>
    /// Validate Columns for host prospects
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool ValidateCSVColumn(string filePath)
    {
        bool blnValidate = true;
        DataTable dtCSV = new DataTable();
        string csvContent = string.Empty;
        using (StreamReader reader = new StreamReader(filePath))
        {
            ///To ceate table columns
            string row = reader.ReadLine();
            string strColumn1 = string.Empty;
            if (row.Split(new char[] { '|' }).Length < 27 || row.Split(new char[] { '|' }).Length > 27)
            {
                blnValidate = false;
            }
            else
            {
                foreach (string strColumn in row.Split(new char[] { '|' }))
                {
                    strColumn1 = strColumn.ToUpper();
                    if (
                        strColumn1.Equals("COMPANY_NAME") ||
                        strColumn1.Equals("ADDRESS") || strColumn1.Equals("CITY") ||
                        strColumn1.Equals("STATE") || strColumn1.Equals("ZIP_CODE") ||
                        strColumn1.Equals("PHONE") || strColumn1.Equals("SALUTATION") ||
                        strColumn1.Equals("LAST_NAME") || strColumn1.Equals("FIRST_NAME") ||
                        strColumn1.Equals("GENDER") || strColumn1.Equals("EMAIL") ||
                        strColumn1.Equals("CONTACT_TITLE") || strColumn1.Equals("CONTACT_ROLE") ||
                        strColumn1.Equals("FAX_NUMBER") || strColumn1.Equals("INFOUSA_ID") ||
                        strColumn1.Equals("SECONDARY_ADDRESS") || strColumn1.Equals("SECONDARY_CITY") ||
                        strColumn1.Equals("SECONDARY_STATE") || strColumn1.Equals("SECONDARY_ZIP_CODE") ||
                        strColumn1.Equals("ACTUAL_MEMBERSHIP") || strColumn1.Equals("ACTUAL_ATTENDANCE") ||
                        strColumn1.Equals("WEB_SITE") || strColumn1.Equals("PROSPECT_TYPE") ||
                        strColumn1.Equals("PROSPECT_STATUS") || strColumn1.Equals("PRODUCTION_DATE1") ||
                        strColumn1.Equals("SOURCE") || strColumn1.Equals("FILLER")
                        )
                        blnValidate = true;
                    else
                    {
                        blnValidate = false;
                        break;
                    }
                }
            }
        }
        return blnValidate;
    }

    /// <summary>
    /// Validate Customer rospects
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public bool ValidateCustomerCSV(string filePath)
    {
        bool blnValidate = true;
        DataTable dtCSV = new DataTable();
        string csvContent = string.Empty;
        using (StreamReader reader = new StreamReader(filePath))
        {
            ///To ceate table columns
            string row = reader.ReadLine();
            string strColumn1 = string.Empty;
            if (row.Split(new char[] { '|' }).Length < 10 || row.Split(new char[] { '|' }).Length > 10)
            {
                blnValidate = false;
            }
            else
            {
                foreach (string strColumn in row.Split(new char[] { '|' }))
                {
                    strColumn1 = strColumn.ToUpper();
                    if (strColumn1.Equals("LAST_NAME") || strColumn1.Equals("FIRST_NAME") ||
                        strColumn1.Equals("ADDRESS") || strColumn1.Equals("CITY") ||
                        strColumn1.Equals("STATE") || strColumn1.Equals("ZIP_CODE") ||
                        strColumn1.Equals("PHONE") || strColumn1.Equals("DOB") ||
                        strColumn1.Equals("EMAIL") || strColumn1.Equals("SOURCE")
                        )
                        blnValidate = true;
                    else
                    {
                        blnValidate = false;
                        break;
                    }

                }
            }

        }
        return blnValidate;
    }

    /// <summary>
    /// Binds all Sales Rep Drop Down
    /// </summary>
    private void BindFranchiseeSalesRep()
    {
        //Fill salesrep or franchisee dropdown
        var orgUser = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole;
        
        if (orgUser.CheckRole((long)Roles.FranchiseeAdmin))
        {
            LoadSalesRepDropDownList();
        }
        else if (orgUser.CheckRole((long)Roles.FranchisorAdmin))
        {
            LoadFranchisee();
        }
        else if (orgUser.CheckRole((long)Roles.SalesRep))
        {
            ddlSalesPerson.Enabled = false;
        }
    }
    private void LoadSalesRepDropDownList()
    {
        long franchiseeId = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        ISalesRepresentativeRepository salesRepresentativeRepository =
            new SalesRepresentativeRepository();

        List<SalesRepresentative> salesRepresentatives = salesRepresentativeRepository.
            GetSalesRepresentativesForFranchisee(franchiseeId).OrderBy(sr => sr.Name.FullName).ToList();
        var namesAndIds = salesRepresentatives.Select(s => new { s.Name.FullName, s.SalesRepresentativeId });
        if (namesAndIds.Count() > 0)
        {
            ddlSalesPerson.DataSource = namesAndIds;
            ddlSalesPerson.DataTextField = "FullName";
            ddlSalesPerson.DataValueField = "SalesRepresentativeId";
            ddlSalesPerson.DataBind();
            ddlSalesPerson.Items.Insert(0, new ListItem("Select SalesRep", "0"));
        }
        else
        {
            ddlSalesPerson.Items.Add(new ListItem("Select SalesRep", "0"));
        }
    }
    private void LoadFranchisee()
    {
        IOrganizationRepository franchiseeRepository = new OrganizationRepository();
        var franchisees =
            franchiseeRepository.GetOrganizationCollection(OrganizationType.Franchisee).OrderBy(fr => fr.Name).ToList();
        var namesAndIds = franchisees.Select(f => new { f.Name, f.Id });

        ddlSalesPerson.DataSource = namesAndIds;
        ddlSalesPerson.DataTextField = "Name";
        ddlSalesPerson.DataValueField = "Id";
        ddlSalesPerson.DataBind();
        ddlSalesPerson.Items.Insert(0, new ListItem("Select Franchisee", "0"));
        ddlSalesPerson.SelectedValue = "0";
    }



}
