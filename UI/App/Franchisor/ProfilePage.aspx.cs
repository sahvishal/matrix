using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
//using HealthYes.Web.UI.FranchisorUserService;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Franchisor;
using Falcon.App.Lib;

public partial class Franchisor_ProfilePage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Franchisor Profile";
        Franchisor_FranchisorMaster obj;
        obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Profile");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Franchisor Admin</a>";
        obj.hideucsearch();
        if (!IsPostBack)
        {
            FillFranchisorData();
        }
    }
  
    private void FillFranchisorData()
    {
        
        Int32 userid = Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.UserId);
        Int32 shellid = Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId);
                
        // format phone no.
        CommonCode objCommonCode = new CommonCode();

        FranchisorDAL franchisorDAL = new FranchisorDAL();
        var franchisoruser = franchisorDAL.GetFranchisorUser(shellid.ToString(), userid.ToString(), 1);

        if (franchisoruser != null)
        {            

            name.InnerText = franchisoruser[0].User.FirstName + " " + franchisoruser[0].User.MiddleName + " " +
                             franchisoruser[0].User.LastName;
            spfrnchname.InnerText = franchisoruser[0].User.FirstName;
            spfrnchmname.InnerText = franchisoruser[0].User.MiddleName;
            spfrnchLname.InnerText = franchisoruser[0].User.LastName;
            DateTime DOB = Convert.ToDateTime(franchisoruser[0].User.DOB);
            dvRole.InnerText = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleDisplayName;
            spaddress1.InnerText = franchisoruser[0].Address.Address1;
            spaddress2.InnerText = franchisoruser[0].Address.Address2;
            spState.InnerText = franchisoruser[0].Address.State;
            spCountry.InnerText = franchisoruser[0].Address.Country;
            spCity.InnerText = franchisoruser[0].Address.City;
            spZip.InnerText = franchisoruser[0].Address.Zip;
            sptelHome.InnerText = objCommonCode.FormatPhoneNumberGet(franchisoruser[0].User.PhoneHome);
            sptelCell.InnerText = objCommonCode.FormatPhoneNumberGet(franchisoruser[0].User.PhoneCell);
            sptelOther.InnerText = objCommonCode.FormatPhoneNumberGet(franchisoruser[0].User.PhoneOffice);
            spemail1.InnerText = franchisoruser[0].User.EMail1;
            spemail2.InnerText = franchisoruser[0].User.EMail2;
            spdob.InnerText = DOB.ToString("MMMM dd, yyyy");
            spssn.InnerText = franchisoruser[0].User.SSN;
            CommonCode objCCode = new CommonCode();

            imgmyphto.ImageUrl = objCCode.GetPicture(Request.MapPath(franchisoruser[0].MyPicture),
                                                     franchisoruser[0].MyPicture);
            imgmyteam.ImageUrl = objCCode.GetPicture(Request.MapPath(franchisoruser[0].TeamPicture),
                                                     franchisoruser[0].TeamPicture);
            Ucimagelist1.Images = franchisoruser[0].OtherPictures;

            //var listImage = new List<string>();
            //foreach (var strImage in franchisoruser[0].OtherPictures)
            //{
            //    listImage.Add(strImage);
            //}
            //Ucimagelist1.Images = listImage;

            spDesc.InnerText = franchisoruser[0].ShellDescription;
        }

    }
    protected void lnkPhoto_Click(object sender, EventArgs e)
    {
        LinkButton templink = (LinkButton)sender;
        ContentPlaceHolder item = (ContentPlaceHolder)templink.NamingContainer;
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");

        if (((LinkButton)(sender)).CommandName == "MyPhoto")
        { imgLargeImage.Src = imgmyphto.ImageUrl; }
        else if (((LinkButton)(sender)).CommandName == "TeamPhoto")
        { imgLargeImage.Src = imgmyteam.ImageUrl; }
        ModalPopupExtender.Show();
       
    }
}
