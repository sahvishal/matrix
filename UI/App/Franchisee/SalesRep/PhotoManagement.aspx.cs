using System;
using System.Data;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.Lib;
using Falcon.DataAccess.Franchisee;
using Falcon.App.Core.Enum;
using Falcon.Entity.Franchisee;
using System.Collections.Generic;
using Falcon.App.UI.Lib;


public partial class Franchisee_SalesRep_PhotoManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillData();
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

        foreach (string strOtherImagePath in franchiseeuser.OtherPictures)
        {
            dtPhoto.Rows.Add(new object[] { "", strOtherImagePath });
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
            franchiseeuser.MyPicture = "~" + strtemp;
        }

        strtemp = ucteamphoto.SaveImage(strfolderpath + "TeamPic" + DateTime.Now.ToString("yyyyMMddhhmmss"));
        if (strtemp != string.Empty)
        {
            franchiseeuser.TeamPicture = "~" + strtemp;
        }

        for (Int16 icount = 0; icount < 12; icount++)
        {
            UCCommon_ucphotopanel Ucphotopanel1 = (UCCommon_ucphotopanel)grdphotoother.Rows[icount].FindControl("Ucphotopanel1");
            strtemp = Ucphotopanel1.SaveImage(strfolderpath +icount +  DateTime.Now.ToString("yyyyMMddhhmmss"));

            if (strtemp != string.Empty)
            {
                franchiseeuser.OtherPictures[icount] = "~" + strtemp;
            }
        }

        var usershellmodulerole1 = new Falcon.Entity.User.EUserShellModuleRole();
        usershellmodulerole1.RoleID = currentSession.CurrentOrganizationRole.RoleId.ToString();
        usershellmodulerole1.ShellID = currentSession.CurrentOrganizationRole.OrganizationId.ToString();
        usershellmodulerole1.UserID = currentSession.UserId.ToString();

        var franchiseeDal = new FranchiseeDAL();

        long returnresult = franchiseeDal.SaveFranchiseeUserImages(franchiseeuser, Convert.ToInt32(EOperationMode.Update),usershellmodulerole1.UserID,usershellmodulerole1.ShellID,usershellmodulerole1.RoleID);
        if (returnresult == 0)
        {
            returnresult = 9999991;
        }

        System.Text.StringBuilder strJSCloseWindow = new System.Text.StringBuilder();
        strJSCloseWindow.Append(" <script language = 'Javascript'>window.close(); </script>");
        ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJSCloseWindow.ToString());
                      

    }
}
