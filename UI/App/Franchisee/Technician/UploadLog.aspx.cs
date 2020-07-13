using System;
using System.IO;
using System.Web;
using Falcon.DataAccess.Master;

public partial class App_Franchisee_Technician_UploadLog : System.Web.UI.Page
{

    #region "Form Events"
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = "Result File Parsing Log";
        Franchisee_Technician_TechnicianMaster obj;
        obj = (Franchisee_Technician_TechnicianMaster)this.Master;
        if (Request.QueryString["UploadZipInfoID"] != null)
        {
            SetUploadedFileDetail(Convert.ToInt32(Request.QueryString["UploadZipInfoID"]));
        }
        //this.Session["UploadInfo"] = new UploadInfo { IsReady = false };
    }

    #endregion


    #region "User Built Functions"

    /// <summary>
    /// 
    /// </summary>
    /// <param name="uploadZipInfoId"></param>
    private void SetUploadedFileDetail(Int32 uploadZipInfoId)
    {
        var masterDal = new MasterDAL();
        var eUploadZipInfos = masterDal.GetListUploadedFiles("", "", "", "", 0, "", uploadZipInfoId, 2)[0];

        string filename = eUploadZipInfos.FileName.Substring(eUploadZipInfos.FileName.LastIndexOf("\\") + 1, eUploadZipInfos.FileName.Length - eUploadZipInfos.FileName.LastIndexOf("\\") - 1);
        Decimal filesize = (Convert.ToDecimal(eUploadZipInfos.FileSize) / (1024 * 1024));
        filesize = Decimal.Round(filesize, 2);

        spfilename.InnerHtml = HttpUtility.HtmlEncode(filename) + " </br> (" + HttpUtility.HtmlEncode(filesize) + " MB)";
        speventdetail.InnerHtml = HttpUtility.HtmlEncode(eUploadZipInfos.Event.Host.Name) + ", " + HttpUtility.HtmlEncode(eUploadZipInfos.Event.Host.Address.Address1) + ", " + HttpUtility.HtmlEncode(eUploadZipInfos.Event.Host.Address.City) + ", " + HttpUtility.HtmlEncode(eUploadZipInfos.Event.Host.Address.State) + ", " + HttpUtility.HtmlEncode(eUploadZipInfos.Event.Host.Address.Zip);
        speventdate.InnerHtml = Convert.ToDateTime(eUploadZipInfos.Event.EventDate).ToShortDateString();
        spuploaddate.InnerHtml = Convert.ToDateTime(eUploadZipInfos.UploadStartTime).ToShortDateString();
        spuploadtime.InnerHtml = Convert.ToDateTime(eUploadZipInfos.UploadStartTime).ToShortTimeString();
        spcustomertotal.InnerHtml = eUploadZipInfos.TotalCount.ToString();

        string firstname = eUploadZipInfos.UploadedBy.FranchiseeUser.User.FirstName;
        string middlename = eUploadZipInfos.UploadedBy.FranchiseeUser.User.MiddleName;
        string lastname = eUploadZipInfos.UploadedBy.FranchiseeUser.User.LastName;

        sptechname.InnerText = firstname + (middlename.Length > 0 ? " " + middlename + " " : " ") + lastname;

        if (eUploadZipInfos.TotalCount > 0)
        {
            spsuccesspercentage.InnerHtml = Decimal.Round(Convert.ToDecimal(((Decimal)(eUploadZipInfos.TotalCount - eUploadZipInfos.FailureCount) / eUploadZipInfos.TotalCount) * 100), 2).ToString();
            spfailedpercentage.InnerHtml = Decimal.Round(Convert.ToDecimal(((Decimal)eUploadZipInfos.FailureCount / eUploadZipInfos.TotalCount) * 100), 2).ToString();
        }

        ReadFromTextFiles(eUploadZipInfos.LogFilePath);

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="strFilePath"></param>
    private void ReadFromTextFiles(string strFilePath)
    {
        StreamReader objstreamreader = File.OpenText(strFilePath);
        while (objstreamreader.Peek() != -1)
        {
            txtLogContent.Text += objstreamreader.ReadLine() + "\n";
        }
        objstreamreader.Close();
        
    }

    #endregion

}
