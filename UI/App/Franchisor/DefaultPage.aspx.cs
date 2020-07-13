using System;

public partial class Franchisor_DefaultPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //EBMSSession objbmssession = BMSSessionManagement.GetBMSSessionObject();
        //UserService.UserService userservice = new UserService.UserService();
        //UserService.EUserShellModuleRole[] eusershellmodulerole;
        //eusershellmodulerole = userservice.GetRoleShellByUserID(4, true);
        //objbmssession.UserShellModuleRoleObject = eusershellmodulerole;
        
        Page.Title = "Default Page";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("");
        obj.hideucsearch();
        //obj.FindControl("")
        
    }

   
}
