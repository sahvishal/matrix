using System;
using System.Data;
using Falcon.App.Core.Application;
using Falcon.App.Core.Enum;
//using HealthYes.Web.UI.FranchiseeUserService;
using Falcon.DataAccess.Franchisee;
using Falcon.Entity.Franchisee;
using Falcon.App.Lib;
using Falcon.Entity.User;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;
//using EUserShellModuleRole=HealthYes.Web.UI.FranchiseeUserService.EUserShellModuleRole;

public partial class Franchisee_PhotoManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                FillData();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
    private void FillData()
    {

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;

        EFranchiseeUser franchiseeuser = OrganizationUser.GetFranchiseeUser(currentSession);

        ucmyphoto.ImagePath = franchiseeuser.MyPicture;
        ucteamphoto.ImagePath = franchiseeuser.TeamPicture;

        DataTable dtPhoto = new DataTable();
        dtPhoto.Columns.Add("Caption", typeof(String));
        dtPhoto.Columns.Add("Path", typeof(String));

        ISettings settings = IoC.Resolve<ISettings>();

        Int32 intMaxPicCount = settings.MaximumPictureCount;
        Int32 intCounter = 0;
        foreach (string strOtherImagePath in franchiseeuser.OtherPictures)
        {
            if (intCounter < intMaxPicCount)
            {
                dtPhoto.Rows.Add(new object[] { "", strOtherImagePath });

            }
        }
        grdphotoother.DataSource = dtPhoto;
        grdphotoother.DataBind();
    }       

    protected void btnupdatedown_Click(object sender, EventArgs e)
    {
        string strfolderpath = "/Images/TestUpload/";
        // Loop through each Image control

        var currentSession = IoC.Resolve<ISessionContext>().UserSession;
        EFranchiseeUser franchiseeuser = OrganizationUser.GetFranchiseeUser(currentSession);

        string strtemp = string.Empty;

        strtemp = ucmyphoto.SaveImage(strfolderpath +"MyPic"+ DateTime.Now.ToString("yyyyMMddhhmmss"));

        if (strtemp != string.Empty)
        {
            franchiseeuser.MyPicture = "~/App" + strtemp;
        }

        strtemp = ucteamphoto.SaveImage(strfolderpath + "TeamPic" + DateTime.Now.ToString("yyyyMMddhhmmss"));
        if (strtemp != string.Empty)
        {
            franchiseeuser.TeamPicture = "~/App" + strtemp;
        }
        ISettings settings = IoC.Resolve<ISettings>();

        Int32 intMaxPicCount = settings.MaximumPictureCount;
        for (Int16 icount = 0; icount < intMaxPicCount; icount++)
        {
            UCCommon_ucphotopanel Ucphotopanel1 = (UCCommon_ucphotopanel)grdphotoother.Rows[icount].FindControl("Ucphotopanel1");
            strtemp = Ucphotopanel1.SaveImage(strfolderpath +icount +  DateTime.Now.ToString("yyyyMMddhhmmss"));

            if (strtemp != string.Empty)
            {
                franchiseeuser.OtherPictures[icount] = "~/App" + strtemp;
            }
        }
        
        FranchiseeDAL franchiseeDAL = new FranchiseeDAL();        

        
        EUserShellModuleRole usershellmodulerole1 = new EUserShellModuleRole();
        usershellmodulerole1.RoleID = currentSession.CurrentOrganizationRole.RoleId.ToString();
        usershellmodulerole1.ShellID = currentSession.CurrentOrganizationRole.OrganizationId.ToString();
        usershellmodulerole1.UserID = currentSession.UserId.ToString();

        franchiseeDAL.SaveFranchiseeUserImages(franchiseeuser, Convert.ToInt32(EOperationMode.Update), usershellmodulerole1.UserID,usershellmodulerole1.ShellID,usershellmodulerole1.RoleID);
        
        var strJsCloseWindow = new System.Text.StringBuilder();
        strJsCloseWindow.Append(" <script language = 'Javascript'>window.close(); </script>");
        ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJsCloseWindow.ToString());
                      

    }
}
