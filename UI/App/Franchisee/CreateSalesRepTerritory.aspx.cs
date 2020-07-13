using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.App.UI.Extentions;
using Falcon.Entity.Other;
using Falcon.App.Lib;
using Falcon.DataAccess.Franchisor;
//using HealthYes.Web.UI.FranchisorService;

public partial class App_Franchisee_CreateSalesRepTerritory : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Create SalesRep Territory";
        Franchisor_FranchisorMaster obj = (Franchisor_FranchisorMaster)Master;
        obj.SetBreadCrumbRoot = "<a href=\"/App/Franchisor/Dashboard.aspx\">DashBoard</a>";
        obj.hideucsearch();

        if (Request.QueryString["TerritoryID"] != null)
        {
            Page.Title = "Edit SalesRep Territory";
            dvTitle.InnerText = "Edit SalesRep Territory";
            obj.settitle("Edit Territory");
        }
        else
        {
            Page.Title = "Create SalesRep Territory";
            dvTitle.InnerText = "Create SalesRep Territory";
            obj.settitle("Create SalesRep Territory");
        }

        if (!IsPostBack)
        {
            if (Request.QueryString["ParentTerritoryID"] != null)
                fillZipDetails(Request.QueryString["ParentTerritoryID"].ToString());
            if (Request.QueryString["TerritoryID"] != null && Request.QueryString["TerritoryID"].ToString().Trim().Length > 0)
            {
                FillTerritoryDetails(Request.QueryString["TerritoryID"].ToString());
            }
        }
    }

    public long ContextKey
    {
        get
        {
            return IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationId;
        }
    }

    protected void imgBtnCancel_Click(object sender, ImageClickEventArgs e)
    {
        Response.RedirectUser("/App/Franchisee/ViewTerritory.aspx");
    }
    protected void imgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        hfZipID.Value = hfZipID.Value.Substring(0, hfZipID.Value.Length - 1);
        char[] split = new char[1];
        split[0] = ',';
        string[] ZipID = hfZipID.Value.Split(split);
        int salesrepid = 0;
        if (txtSalesRep.Text.Trim().Length > 0)
        {

            try
            {
                salesrepid = Int32.Parse(txtSalesRep.Text.Substring(txtSalesRep.Text.IndexOf(":") + 1, txtSalesRep.Text.IndexOf("]") - (txtSalesRep.Text.IndexOf(":") + 1)));

            }
            catch
            {
                salesrepid = 0;
            }
        }

        var objTerritory = new ETerritory();
        objTerritory.Name = txtSubTerritoryName.Text;
        objTerritory.Description = txtDescription.Text;
        objTerritory.TerritorySalesRepID = salesrepid;
        objTerritory.ParentTerritoryID = Convert.ToInt32(Request.QueryString["ParentTerritoryID"]);
        objTerritory.Type = 1;//sub territory
        objTerritory.TerritoryID = 0;
        objTerritory.IsActive = true;
        var objMap = new List<ETerritoryZipMap>();

        for (int count = 0; count < ZipID.Length; count++)
        {
            var objZip = new ETerritoryZipMap();
            objZip.ZipID = Convert.ToInt32(ZipID[count]);
            objZip.IsActive = true;
            objMap.Add(objZip);

        }
        objTerritory.TerritoryZipMap = objMap;


        objTerritory.CreatedBy = Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.UserId);

        Int64 returnresult = new Int64();
        if (Request.QueryString["TerritoryID"] != null)
        {
            objTerritory.TerritoryID = Convert.ToInt32(Request.QueryString["TerritoryID"].ToString());
            //objFranchisorService.UpdateTerritory(objTerritory, out returnresult, out temp);
            returnresult = UpdateTerritory(objTerritory);
        }
        else
        {
            //objFranchisorService.AddTerritory(objTerritory, out returnresult, out temp);
            returnresult = AddTerritory(objTerritory);
        }
        if (returnresult > 0)
        {
            Response.RedirectUser("/App/Franchisee/ViewTerritory.aspx");
        }
    }

    # region "Methods"

    private void fillZipDetails(string territoryid)
    {
        //FranchisorService objFranService = new FranchisorService();
        var objFranchisorDal = new FranchisorDAL();
        //HealthYes.Web.UI.FranchisorService.ETerritory objTerritory = new HealthYes.Web.UI.FranchisorService.ETerritory();
        var objTerritory = new Falcon.Entity.Other.ETerritory();
        //objTerritory = objFranService.GetFranchiseeTerritoryDetail(territoryid);

        //mode - 0 for Franchisee Territory Detail
        objTerritory = objFranchisorDal.GetTerritoryDetail(territoryid, 0);
        ddlZip.Items.Clear();
        ddlZip.Items.Add(new ListItem("Select Zip", "0"));
        //if (objTerritory != null && objTerritory.TerritoryZipMap != null && objTerritory.TerritoryZipMap.Length > 0)
        if (objTerritory != null && objTerritory.TerritoryZipMap != null && objTerritory.TerritoryZipMap.Count > 0)
        {
            spTerritoryName.InnerText = objTerritory.Name;
            //for (int count = 0; count < objTerritory.TerritoryZipMap.Length; count++)
            for (int count = 0; count < objTerritory.TerritoryZipMap.Count; count++)
            {
                ddlZip.Items.Add(new ListItem(objTerritory.TerritoryZipMap[count].ZipDetail, objTerritory.TerritoryZipMap[count].ZipID.ToString()));
            }
        }
    }

    private void FillTerritoryDetails(string territoryid)
    {
        //FranchisorService objFranService = new FranchisorService();
        var objFranchisorDal = new FranchisorDAL();
        //HealthYes.Web.UI.FranchisorService.ETerritory objTerritory = new HealthYes.Web.UI.FranchisorService.ETerritory();
        var objTerritory = new Falcon.Entity.Other.ETerritory();
        //objTerritory = objFranService.GetSalesTerritoryDetail(territoryid);

        //mode - 1 for SalesRep Territory Detail
        objTerritory = objFranchisorDal.GetTerritoryDetail(territoryid, 1);

        if (objTerritory != null)
        {
            txtSubTerritoryName.Text = objTerritory.Name;
            txtDescription.Text = objTerritory.Description;
            txtSalesRep.Text = objTerritory.FranchiseeName;

            //if (objTerritory.TerritoryZipMap != null && objTerritory.TerritoryZipMap.Length > 0)
            if (objTerritory.TerritoryZipMap != null && objTerritory.TerritoryZipMap.Count > 0)
            {
                //for (int count = 0; count < objTerritory.TerritoryZipMap.Length; count++)
                for (int count = 0; count < objTerritory.TerritoryZipMap.Count; count++)
                {
                    ClientScript.RegisterArrayDeclaration("ZipDetailArray", "'" + objTerritory.TerritoryZipMap[count].ZipDetail + "'");
                }
                ClientScript.RegisterStartupScript(typeof(string), "jscode_fillZipDetails", "fillZipDetails(ZipDetailArray);", true);
            }
        }
    }

    public Int64 UpdateTerritory(ETerritory objTerritory)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = franchisorDAL.SaveTerritory(objTerritory, 1);
        if (returnresult > 0)
        {
            for (int count = 0; count < objTerritory.TerritoryZipMap.Count; count++)
            {
                objTerritory.TerritoryZipMap[count].TerritoryID = Convert.ToInt32(returnresult);
                returnresult = franchisorDAL.SaveTerritoryZip(objTerritory.TerritoryZipMap[count], 0);
            }
        }
        return returnresult;
    }

    public Int64 AddTerritory(ETerritory objTerritory)
    {
        FranchisorDAL franchisorDAL = new FranchisorDAL();
        Int64 returnresult = franchisorDAL.SaveTerritory(objTerritory, 0);
        if (returnresult > 0)
        {
            for (int count = 0; count < objTerritory.TerritoryZipMap.Count; count++)
            {
                objTerritory.TerritoryZipMap[count].TerritoryID = Convert.ToInt32(returnresult);
                returnresult = franchisorDAL.SaveTerritoryZip(objTerritory.TerritoryZipMap[count], 0);
            }
        }
        return returnresult;
    }
    # endregion
}
