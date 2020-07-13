using System;
using System.Data;
using Falcon.App.Core.Application;
using Falcon.DataAccess.Franchisor;
using Falcon.Entity.Franchisor;
using Falcon.App.Core.Enum;
using Falcon.App.Lib;
using Falcon.App.UI.Lib;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

public partial class Franchisor_PhotoManagement : System.Web.UI.Page
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

        EFranchisorUser franchisoruser = OrganizationUser.GetFranchisorUser(currentSession);
        DataTable dtPhoto = new DataTable();
        dtPhoto.Columns.Add("Caption", typeof(String));
        dtPhoto.Columns.Add("Path", typeof(String));

        ISettings settings = IoC.Resolve<ISettings>();

        Int32 intMaxPicCount = settings.MaximumPictureCount;
        Int32 intCounter = 0;
        foreach (string strOtherImagePath in franchisoruser.OtherPictures)
        {
            if (intCounter < intMaxPicCount)
            {
                dtPhoto.Rows.Add(new object[] { "", strOtherImagePath });
                intCounter++;
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

        EFranchisorUser franchisoruser = OrganizationUser.GetFranchisorUser(currentSession);

        string strtemp = string.Empty;

        strtemp = ucmyphoto.SaveImage(strfolderpath + "MyPic" + DateTime.Now.ToString("yyyyMMddhhmmss"));

        if (strtemp != string.Empty)
        {
            franchisoruser.MyPicture = "~/App" + strtemp;
        }

        strtemp = ucteamphoto.SaveImage(strfolderpath + "TeamPic" + DateTime.Now.ToString("yyyyMMddhhmmss"));
        if (strtemp != string.Empty)
        {
            franchisoruser.TeamPicture = "~/App" + strtemp;
        }

        ISettings settings = IoC.Resolve<ISettings>();
        Int32 intMaxPicCount = settings.MaximumPictureCount;
        for (Int16 icount = 0; icount < intMaxPicCount; icount++)
        {

            UCCommon_ucphotopanel Ucphotopanel1 = (UCCommon_ucphotopanel)grdphotoother.Rows[icount].FindControl("Ucphotopanel1");
            strtemp = Ucphotopanel1.SaveImage(strfolderpath + icount + DateTime.Now.ToString("yyyyMMddhhmmss"));

            if (strtemp != string.Empty)
            {
                franchisoruser.OtherPictures[icount] = "~/App" + strtemp;
            }
        }
        
        
        Int64 returnresult;

        FranchisorDAL franchisorDal = new FranchisorDAL();
        returnresult = franchisorDal.SaveFranchisorUserImages(franchisoruser, Convert.ToInt32(EOperationMode.Update),
                                                              currentSession.UserId.ToString(), currentSession.CurrentOrganizationRole.OrganizationId.ToString(),
                                                              currentSession.CurrentOrganizationRole.RoleId.ToString());
        if (returnresult == 0)
        {
            returnresult = 9999991;
        }

        var listfranchisoruser = franchisorDal.GetFranchisorUser(currentSession.CurrentOrganizationRole.OrganizationId.ToString(), currentSession.UserId.ToString(), 1);

        if (listfranchisoruser != null && listfranchisoruser.Count > 0) franchisoruser = listfranchisoruser[0];
        
        System.Text.StringBuilder strJSCloseWindow = new System.Text.StringBuilder();
        strJSCloseWindow.Append(" <script language = 'Javascript'>window.close(); </script>");
        ClientScript.RegisterStartupScript(typeof(string), "JSCode", strJSCloseWindow.ToString());


    }

    
}
