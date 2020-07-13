using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

using Falcon.App.Core.Enum;


public partial class Franchisor_Masters_Item : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Item";
        divErrorMsg.InnerText = "";
        var obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Item");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";
        if (!IsPostBack)
        {
            ViewState["SortItem"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                
                SearchItems(Request.QueryString["searchtext"]);
            }
            else
            {
                GetAllItems();
            }
            GetAllActiveInventory();
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + grdItem.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + txtItemCode.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + txtSKUCode.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + txtManfName.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + txtManfID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + ddlInventory.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + btnEdit.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + hfItemID.ClientID + "'");
        ClientScript.RegisterArrayDeclaration("arrjsitemselements", "'" + txtNote.ClientID + "'");
        
    }

    protected void grdItem_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "mastercheckboxclick()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "checkallboxes()";
            }
            var lnkBtnItemCode = (LinkButton)e.Row.FindControl("lnkBtnItemCode");
            lnkBtnItemCode.OnClientClick = "return EditItemCode('" + lnkBtnItemCode.ClientID + "')";
        }
    }

    protected void grdItem_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdItem.PageIndex = e.NewPageIndex;
        grdItem.DataSource = (DataTable)ViewState["DSGRID"];
        grdItem.DataBind();
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string strItemIDs = this.GetAllSelectedItems();

        if (strItemIDs.Length > 0)
        {
            var masterDal = new MasterDAL();
            var returnresult = masterDal.SaveItem(strItemIDs, Convert.ToInt32(EOperationMode.Delete));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                        ? "Item has been deleted."
                                        : "Item has not been deleted due to internal error.";
            hfItemID.Value = "";
            GetAllItems();
        }
    }

    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
       string strItemIDs = GetAllSelectedItems();

        if (strItemIDs.Length > 0)
        {
            var masterDal = new MasterDAL();
            var returnresult = masterDal.SaveItem(strItemIDs, Convert.ToInt32(EOperationMode.Activate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                       ? "Item has been activated."
                                       : "Item has not been activated due to internal error.";
            hfItemID.Value = "";
            GetAllItems();
        }
    }

    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strItemIDs = this.GetAllSelectedItems();

        if (strItemIDs.Length > 0)
        {
            var masterDal = new MasterDAL();
            var returnresult = masterDal.SaveItem(strItemIDs.ToString(), Convert.ToInt32(EOperationMode.DeActivate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                       ? "Item has been deactivated."
                                       : "Item has not been deacivated due to internal error.";
            hfItemID.Value = "";
            GetAllItems();
        }
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        ClientScript.RegisterStartupScript(typeof(string), "jsedit", "<script language='javascript'> EditItem(false); </script>");
        ModalPopupExtender.Show();
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        UpdateItem();
    }

    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        ModalPopupExtender.Hide();
    }

    protected void grdItem_Sorting(object sender, GridViewSortEventArgs e)
    {
        var tblitem = (DataTable)ViewState["DSGRID"];
        if ((SortDirection)ViewState["SortItem"] == SortDirection.Descending)
        {
            tblitem.DefaultView.Sort = "manufacturername asc";
            ViewState["SortItem"] = SortDirection.Ascending;
        }
        else
        {
            tblitem.DefaultView.Sort = "manufacturername desc";
            ViewState["SortItem"] = SortDirection.Descending;
        }
        tblitem = tblitem.DefaultView.ToTable();

        grdItem.DataSource = tblitem;
        ViewState["DSGRID"] = tblitem;

        grdItem.DataBind();
    }
   
    private void GetAllItems()
    {
        var masterDal = new MasterDAL();

        // To use '0' as mode for the argument.
        EItem[] itemarrayobject = masterDal.GetItem(string.Empty, 0).ToArray(); 

        var tblitem = new DataTable();
        tblitem.Columns.Add("ItemID", typeof(int));
        tblitem.Columns.Add("ItemCode");
        tblitem.Columns.Add("SKUCode");
        tblitem.Columns.Add("ManufacturerName");
        tblitem.Columns.Add("ManufacturerID");
        tblitem.Columns.Add("InventoryItemID");
        tblitem.Columns.Add("Active");
        tblitem.Columns.Add("Note");

        if (itemarrayobject != null && itemarrayobject.Length>0)
        {
            for (int icount = 0; icount < itemarrayobject.Length; icount++)
            {
                if (itemarrayobject[icount].Active.ToString().Equals("True"))
                {
                    tblitem.Rows.Add(new object[] { itemarrayobject[icount].ItemID, itemarrayobject[icount].ItemCode, itemarrayobject[icount].SKUCode, itemarrayobject[icount].ManufacturerName, itemarrayobject[icount].ManufacturerID, itemarrayobject[icount].InventoryItemID, "Active", itemarrayobject[icount].Notes });
                }
                else
                    tblitem.Rows.Add(new object[] { itemarrayobject[icount].ItemID, itemarrayobject[icount].ItemCode, itemarrayobject[icount].SKUCode, itemarrayobject[icount].ManufacturerName, itemarrayobject[icount].ManufacturerID, itemarrayobject[icount].InventoryItemID, "Deactivated", itemarrayobject[icount].Notes });
            }
            btnEdit.Enabled = true;
            btnDeActivate.Enabled = true;
            btnActivate.Enabled = true;
            btnDelete.Enabled = true;

        }
        else
        {
            btnEdit.Enabled = false;
            btnDeActivate.Enabled = false;
            btnActivate.Enabled = false;
            btnDelete.Enabled = false;

            divErrorMsg.InnerText = "No Recors Found";
            divErrorMsg.Visible = true;
        }

        tblitem.DefaultView.Sort = "ItemCode asc";
        tblitem = tblitem.DefaultView.ToTable();
        grdItem.DataSource = tblitem;
        ViewState["DSGRID"] = tblitem;

        grdItem.DataBind();

    }
    
    private void SearchItems(string searchtext)
    {
        var masterDal = new MasterDAL();

        // To use '2' as mode for the argument.
        EItem[] itemarrayobject = masterDal.GetItem(searchtext, 2).ToArray();

        var tblitem = new DataTable();
        tblitem.Columns.Add("ItemID", typeof(int));
        tblitem.Columns.Add("ItemCode");
        tblitem.Columns.Add("SKUCode");
        tblitem.Columns.Add("ManufacturerName");
        tblitem.Columns.Add("ManufacturerID");
        tblitem.Columns.Add("InventoryItemID");
        tblitem.Columns.Add("Active");
        tblitem.Columns.Add("Note");
        if (itemarrayobject != null && itemarrayobject.Length > 0)
        {
            for (int icount = 0; icount < itemarrayobject.Length; icount++)
            {
                if (itemarrayobject[icount].Active.ToString().Equals("True"))
                {
                    tblitem.Rows.Add(new object[] { itemarrayobject[icount].ItemID, itemarrayobject[icount].ItemCode, itemarrayobject[icount].SKUCode, itemarrayobject[icount].ManufacturerName, itemarrayobject[icount].ManufacturerID, itemarrayobject[icount].InventoryItemID, "Active", itemarrayobject[icount].Notes });
                }
                else
                    tblitem.Rows.Add(new object[] { itemarrayobject[icount].ItemID, itemarrayobject[icount].ItemCode, itemarrayobject[icount].SKUCode, itemarrayobject[icount].ManufacturerName, itemarrayobject[icount].ManufacturerID, itemarrayobject[icount].InventoryItemID, "Deactivated", itemarrayobject[icount].Notes });
            }
            btnEdit.Enabled = true;
            btnDeActivate.Enabled = true;
            btnActivate.Enabled = true;
            btnDelete.Enabled = true;

            
        }
        else
        {
            btnEdit.Enabled = false;
            btnDeActivate.Enabled = false;
            btnActivate.Enabled = false;
            btnDelete.Enabled = false;

            divErrorMsg.InnerText = "No Records Found";
            divErrorMsg.Visible = true;
        }
        if ((SortDirection)ViewState["SortItem"] == SortDirection.Descending)
        {
            tblitem.DefaultView.Sort = "manufacturername desc";
        }
        else
        {
            tblitem.DefaultView.Sort = "manufacturername asc";
        }

        tblitem = tblitem.DefaultView.ToTable();

        grdItem.DataSource = tblitem;

        ViewState["DSGRID"] = tblitem;

        grdItem.DataSource = tblitem;
        grdItem.DataBind();
        
        hfItemID.Value = "";
    }
    
    private void GetAllActiveInventory()
    {
        var masterDal = new MasterDAL();
        var listInventoryItem = masterDal.GetInventoryItem(string.Empty, 3);
        EInventoryItem[] invitemobject = null;

        if (listInventoryItem != null) invitemobject = listInventoryItem.ToArray();

        if (invitemobject.Length > 0)
        {
            ddlInventory.Items.Add(new ListItem("Select Inventory Name","0"));
            
            for (int count = 0; count < invitemobject.Length; count++)
            {
                if (IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.CheckRole((long)Roles.FranchiseeAdmin) && invitemobject[count].ItemType.TestAssociated)
                    continue;
                
                ddlInventory.Items.Add(new ListItem(invitemobject[count].Name, invitemobject[count].InventoryItemID.ToString()));

            }
        }
        
    }
  
    private string GetAllSelectedItems()
    {
        string strItemIDs = "";

        for (int i = 0; i < grdItem.Rows.Count; i++)
        {
            var chkItemTypeSelecter = new HtmlInputCheckBox();
            chkItemTypeSelecter = (HtmlInputCheckBox)grdItem.Rows[i].FindControl("chkRowChild");
            if (chkItemTypeSelecter.Checked == true)
            {
                strItemIDs += Convert.ToInt32(((DataTable)(ViewState["DSGRID"])).Rows[grdItem.Rows[i].DataItemIndex]["ItemID"]) + ",";
            }
        }
        strItemIDs = strItemIDs.Remove(strItemIDs.LastIndexOf(","));

        return strItemIDs;
    }

    private void UpdateItem()
    {
        var objitem = new EItem
                          {
                              ItemCode = txtItemCode.Text,
                              SKUCode = txtSKUCode.Text,
                              ManufacturerName = txtManfName.Text,
                              ManufacturerID = txtManfID.Text,
                              InventoryItemID = Convert.ToInt32(ddlInventory.SelectedItem.Value),
                              Notes = txtNote.Text
                          };

        long addinvitem = 0;
        divErrorMsg.Visible = true;
        var masterDal = new MasterDAL();
        if (hfItemID.Value.Equals(""))
        {
            addinvitem = masterDal.SaveItem(objitem, Convert.ToInt32(EOperationMode.Insert));
            divErrorMsg.InnerText = addinvitem == 999998 ? "Item code already exits." : "Item has been added successfully.";
        }
        else
        {
           objitem.ItemID = Convert.ToInt32(grdItem.DataKeys[Convert.ToInt32(hfItemID.Value)].Value);
           
            addinvitem = masterDal.SaveItem(objitem, Convert.ToInt32(EOperationMode.Update));

            divErrorMsg.InnerText = addinvitem == 0 ? "Item has been updated successfully." : "Item has been not updated due to internal error";
        }

        hfItemID.Value = "";
        GetAllItems();
    }

}
