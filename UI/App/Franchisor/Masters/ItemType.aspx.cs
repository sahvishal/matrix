using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.DataAccess.Franchisor;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;
using Falcon.App.Core.Enum;
using EItemType = Falcon.Entity.Other.EItemType;
using ETest = Falcon.Entity.Franchisor.ETest;

public partial class Franchisor_Masters_ItemType : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Page.Title = "Inventory Name";

        var obj = (Franchisor_FranchisorMaster)this.Master;
        obj.settitle("Inventory Name");
        obj.SetBreadCrumbRoot = "<a href=\"#\">Master</a>";

        if (!IsPostBack)
        {
            ViewState["SortDir"] = SortDirection.Ascending;
            if (Request.QueryString["searchtext"] != null)
            {
                SearchInventoryItem(Request.QueryString["searchtext"]);
            }
            else
            {
                GetInventoryItem();
            }
            GetAllTests();
            GetAllItemTypes();


            Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        }
        for (int icount = 0; icount < rbtlstconsumable.Items.Count; icount++)
        {
            if (rbtlstconsumable.Items[icount].Text.IndexOf("TestsAssociated") > -1)
                rbtlstconsumable.Items[icount].Attributes["onClick"] = "makevisiblediv('True');";
            else
                rbtlstconsumable.Items[icount].Attributes["onClick"] = "makevisiblediv('False');";
        }
    }

    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        var dtInventoryItem = (DataTable)ViewState["DSGRID"];
        if (hfItemTypeID.Value != "")
        {
            int InventoryItemID = Convert.ToInt32(grdItemType.DataKeys[Convert.ToInt32(hfItemTypeID.Value)].Value);
            dtInventoryItem.DefaultView.RowFilter = "name = '" + txtName.Text + "' and InventoryItemID <> '" + InventoryItemID + "'";
            int rowcount = dtInventoryItem.DefaultView.Count;
            if (rowcount > 0)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "Cannot be Updated. Name already exist";
            }
            else
            {
                UpdateItemType();
            }
        }
        else
        {
            dtInventoryItem.DefaultView.RowFilter = "name = '" + txtName.Text + "'";
            int rowcount = dtInventoryItem.DefaultView.Count;
            if (rowcount > 0)
            {
                divErrorMsg.Visible = true;
                divErrorMsg.InnerText = "Cannot be Updated. Name already exist";
            }
            else
            {
                UpdateItemType();
            }
        }
    }

    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedInventoryItem = GetSelectedInventoryItemIDs();

        
        if (strSelectedInventoryItem.Length > 0)
        {
            var masterDal = new MasterDAL();
            var returnresult = masterDal.SaveInventoryItem(strSelectedInventoryItem,
                                                       Convert.ToInt32(EOperationMode.Delete));
            
            GetInventoryItem();
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                        ? "Item has been deleted."
                                        : "Item has not been deleted due to internal error.";
            hfItemTypeID.Value = "";
        }
    }

    protected void btnDeActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedInventoryItem = GetSelectedInventoryItemIDs();
        
        if (strSelectedInventoryItem.Length > 0)
        {

            var masterDal = new MasterDAL();
            var returnresult = masterDal.SaveInventoryItem(strSelectedInventoryItem.ToString(),
                                                       Convert.ToInt32(EOperationMode.DeActivate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = returnresult == 0
                                        ? "Item has been deactivated."
                                        : "Item has not been deactivated due to internal error.";
            hfItemTypeID.Value = "";
            GetInventoryItem();
        }
    }

    protected void btnActivate_Click(object sender, ImageClickEventArgs e)
    {
        string strSelectedInventoryItem = GetSelectedInventoryItemIDs();
        if (strSelectedInventoryItem.Length > 0)
        {
        var masterDal = new MasterDAL();
           var returnresult = masterDal.SaveInventoryItem(strSelectedInventoryItem,
                                                       Convert.ToInt32(EOperationMode.Activate));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = returnresult == 0
                                       ? "Item has been activated."
                                       : "Item has not been activated due to internal error.";
            hfItemTypeID.Value = "";
            GetInventoryItem();
        }
    }

    protected void grdItemType_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            var chktempheader = (HtmlInputCheckBox)e.Row.FindControl("chkMaster1");
            if (chktempheader != null)
            {
                chktempheader.Attributes["onClick"] = "GridMasterCheck()";
            }
        }
        else if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var chktemprow = (HtmlInputCheckBox)e.Row.FindControl("chkRowChild");
            if (chktemprow != null)
            {
                chktemprow.Attributes["onClick"] = "GridChildCheck()";
            }
            var lnkBtnInventoryName = (LinkButton)e.Row.FindControl("lnkBtnInventoryName");
            lnkBtnInventoryName.OnClientClick = "return EditInventoryName('" + lnkBtnInventoryName.ClientID + "')";
        }
    }

    protected void grdItemType_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdItemType.PageIndex = e.NewPageIndex;
        grdItemType.DataSource = (DataTable)ViewState["DSGRID"];
        grdItemType.DataBind();
    }

    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        sppopuptitle.InnerText = "Edit Inventory Item";
        
        var hftemp = (HiddenField)grdItemType.Rows[Convert.ToInt32(hfItemTypeID.Value)].FindControl("hfitemtypeid");

        Int32 itemtypeid = Convert.ToInt32(hftemp.Value);
        rbtlstconsumable.SelectedValue = itemtypeid.ToString();
        if (rbtlstconsumable.SelectedItem.Text.IndexOf("TestsAssociated") > -1)
        {
            Int32 itemid = Convert.ToInt32(grdItemType.DataKeys[Convert.ToInt32(hfItemTypeID.Value)].Value);

            EInventoryItemTest[] testobj = null;

            var masterDal = new MasterDAL();
            //Mode '1' is used for Getting Inventory Item acc. to InventoryID
            var listInventoryItemTest = masterDal.GetInventoryItemTestbyInventoryID(itemid.ToString(), 1);

            if (listInventoryItemTest != null) testobj = listInventoryItemTest.ToArray();

            for (int icount = 0; icount < chklsttestassociated.Items.Count; icount++)
            {
                chklsttestassociated.Items[icount].Selected = false;
            }

            for (int count = 0; count < testobj.Length; count++)
            {
                for (int icount = 0; icount < chklsttestassociated.Items.Count; icount++)
                {
                    if (chklsttestassociated.Items[icount].Value == testobj[count].TestID.ToString())
                    {
                        chklsttestassociated.Items[icount].Selected = true;
                        break;
                    }
                }
            }
            ClientScript.RegisterStartupScript(typeof(string), "jscript", "<script language='javascript' type='text/javascript'> makevisiblediv('true'); </script>");
        }
        else
            ClientScript.RegisterStartupScript(typeof(string), "jscript", "<script language='javascript' type='text/javascript'> makevisiblediv('false'); </script>");

        ModalPopupExtender.Show();
    }

    protected void grdItemType_Sorting(object sender, GridViewSortEventArgs e)
    {
        var dtinventoryitem = (DataTable)ViewState["DSGRID"];

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Ascending)
        {
            dtinventoryitem.DefaultView.Sort = "name desc";
            ViewState["SortDir"] = SortDirection.Descending;
        }
        else
        {
            dtinventoryitem.DefaultView.Sort = "name asc";
            ViewState["SortDir"] = SortDirection.Ascending;
        }

        dtinventoryitem = dtinventoryitem.DefaultView.ToTable();
        grdItemType.DataSource = dtinventoryitem;
        grdItemType.DataBind();

        ViewState["DSGRID"] = dtinventoryitem;

    }
    
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        for (int icount = 0; icount < chklsttestassociated.Items.Count; icount++)
        {
            chklsttestassociated.Items[icount].Selected = false;
        }
        rbtlstconsumable.SelectedIndex = -1;
        ModalPopupExtender.Hide();
    }

    private void SearchInventoryItem(string searchtext)
    {
        EInventoryItem[] inventoryitem = null;
        var masterDal = new MasterDAL();
        // Mode '2' is used for Getting Inventory Items by Name
        var listInventoryItem = masterDal.GetInventoryItem(searchtext, 2);

        if (listInventoryItem != null) inventoryitem = listInventoryItem.ToArray();

        var dtInventoryItem = new DataTable();
        dtInventoryItem.Columns.Add("InventoryItemID", typeof(Int32));
        dtInventoryItem.Columns.Add("name");
        dtInventoryItem.Columns.Add("description");
        dtInventoryItem.Columns.Add("ItemType");
        dtInventoryItem.Columns.Add("ItemTypeID", typeof(Int32));
        dtInventoryItem.Columns.Add("active");

        if (inventoryitem != null && inventoryitem.Length > 0)
        {
            for (int icount = 0; icount < inventoryitem.Length; icount++)
            {
                if (inventoryitem[icount].Active.ToString().Equals("True"))
                {
                    dtInventoryItem.Rows.Add(new object[] { inventoryitem[icount].InventoryItemID, inventoryitem[icount].Name, inventoryitem[icount].Description, inventoryitem[icount].ItemType.Name, inventoryitem[icount].ItemType.ItemTypeID, "Active" });
                }
                else
                    dtInventoryItem.Rows.Add(new object[] { inventoryitem[icount].InventoryItemID, inventoryitem[icount].Name, inventoryitem[icount].Description, inventoryitem[icount].ItemType.Name, inventoryitem[icount].ItemType.ItemTypeID, "Deactivated" });
            }
            divErrorMsg.Visible = false;
        }

        if ((SortDirection)ViewState["SortDir"] == SortDirection.Descending)
        {
            dtInventoryItem.DefaultView.Sort = "name desc";
        }
        else
        {
            dtInventoryItem.DefaultView.Sort = "name asc";
        }
        dtInventoryItem = dtInventoryItem.DefaultView.ToTable();

        if (dtInventoryItem.Rows.Count < 1)
        {
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;

            divErrorMsg.InnerText = "No Records Found";
            divErrorMsg.Visible = true;
        }

        grdItemType.DataSource = dtInventoryItem;
        ViewState["DSGRID"] = dtInventoryItem;
        grdItemType.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";
        hfItemTypeID.Value = "";
    }

    private void GetInventoryItem()
    {
        EInventoryItem[] inventoryitem = null;
        var masterDal = new MasterDAL();
        // Mode '0' is used for Getting All Inventory Items 
        var listInventoryItem = masterDal.GetInventoryItem(string.Empty, 0);

        if (listInventoryItem != null) inventoryitem = listInventoryItem.ToArray();

        var dtInventoryItem = new DataTable();
        dtInventoryItem.Columns.Add("InventoryItemID", typeof(Int32));
        dtInventoryItem.Columns.Add("name");
        dtInventoryItem.Columns.Add("description");
        dtInventoryItem.Columns.Add("ItemType");
        dtInventoryItem.Columns.Add("ItemTypeID", typeof(Int32));
        dtInventoryItem.Columns.Add("active");

        if (inventoryitem != null && inventoryitem.Length > 0)
        {
            for (int icount = 0; icount < inventoryitem.Length; icount++)
            {
                if (inventoryitem[icount].Active.ToString().Equals("True"))
                {
                    dtInventoryItem.Rows.Add(new object[] { inventoryitem[icount].InventoryItemID, inventoryitem[icount].Name, inventoryitem[icount].Description, inventoryitem[icount].ItemType.Name, inventoryitem[icount].ItemType.ItemTypeID, "Active" });
                }
                else
                    dtInventoryItem.Rows.Add(new object[] { inventoryitem[icount].InventoryItemID, inventoryitem[icount].Name, inventoryitem[icount].Description, inventoryitem[icount].ItemType.Name, inventoryitem[icount].ItemType.ItemTypeID, "Deactivated" });
            }
        }

        if (dtInventoryItem.Rows.Count < 1)
        {
            btnActivate.Enabled = false;
            btnDeActivate.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            divErrorMsg.InnerText = "No Records Found";
            divErrorMsg.Visible = true;
        }

        grdItemType.DataSource = dtInventoryItem;
        ViewState["DSGRID"] = dtInventoryItem;
        grdItemType.DataBind();

        txtName.Text = "";
        txtDescription.Text = "";
        hfItemTypeID.Value = "";
    }

    private void UpdateItemType()
    {
      
        var inventoryitem = new EInventoryItem();

        inventoryitem.Name = txtName.Text;
        inventoryitem.Description = txtDescription.Text;
       
        inventoryitem.ItemType = new EItemType
                                     {
                                         ItemTypeID = Convert.ToInt32(rbtlstconsumable.SelectedItem.Value)
                                     };

        if (rbtlstconsumable.SelectedItem.Text.IndexOf("TestsAssociated") > -1)
        {
            inventoryitem.Test = new List<ETest>();

            //itemlen = 0;
            for (int icount = 0; icount < chklsttestassociated.Items.Count; icount++)
            {
                if (chklsttestassociated.Items[icount].Selected == true)
                {
                    var test = new ETest();
                    test.TestID = Convert.ToInt32(chklsttestassociated.Items[icount].Value);
                    inventoryitem.Test.Add(test);
                }
            }
        }

        long addinvitem = 0;
        var masterDal = new MasterDAL();

        if (hfItemTypeID.Value.ToString().Equals(""))
        {
            addinvitem = masterDal.SaveInventoryItem(inventoryitem, Convert.ToInt32(EOperationMode.Insert));
            divErrorMsg.Visible = true;
            divErrorMsg.InnerHtml = addinvitem == 0
                                       ? "Item has been added successfully."
                                       : "Item has not been added due to internal error.";
        }
        else
        {
            inventoryitem.InventoryItemID = Convert.ToInt32(grdItemType.DataKeys[Convert.ToInt32(hfItemTypeID.Value)].Value);

            addinvitem = masterDal.SaveInventoryItem(inventoryitem, Convert.ToInt32(EOperationMode.Update));
            if (addinvitem == 0)
            {
                addinvitem = 9999991;
            }

            divErrorMsg.Visible = true;
            divErrorMsg.InnerText = addinvitem == 0
                                      ? "Item has been updated successfully."
                                      : "Item has not been updated due to internal error.";
        }


        hfItemTypeID.Value = "";
        GetInventoryItem();

    }
    
    private string GetSelectedInventoryItemIDs()
    {
        String strSelectedInvItems = "";

        for (int i = 0; i < grdItemType.Rows.Count; i++)
        {
            var chkItemTypeSelecter = (HtmlInputCheckBox)grdItemType.Rows[i].FindControl("chkRowChild");
            if (chkItemTypeSelecter.Checked == true)
            {
                strSelectedInvItems +=
                     Convert.ToInt32(
                         ((DataTable)(ViewState["DSGRID"])).Rows[grdItemType.Rows[i].DataItemIndex]["InventoryItemID"]) + ", ";
            }
        }

        if (strSelectedInvItems.Length > 0)
            strSelectedInvItems = strSelectedInvItems.Remove(strSelectedInvItems.LastIndexOf(", "));

        return strSelectedInvItems;
    }

    private void GetAllTests()
    {
        var franchisorDal = new FranchisorDAL();
        List<ETest> testobject = franchisorDal.GetTest(string.Empty, 3);

        chklsttestassociated.Items.Clear();
        for (int icount = 0; icount < testobject.Count; icount++)
        {
            chklsttestassociated.Items.Add(new ListItem(HttpUtility.HtmlEncode(testobject[icount].Name), HttpUtility.HtmlEncode(testobject[icount].TestID.ToString())));
        }

    }

    private void GetAllItemTypes()
    {
        var masterDal = new MasterDAL();

        List<EItemType> itemtypeobj = masterDal.GetItemType(string.Empty, 0);

        rbtlstconsumable.Items.Clear();

        for (int icount = 0; icount < itemtypeobj.Count; icount++)
        {
            if (itemtypeobj[icount].TestAssociated == true)
                rbtlstconsumable.Items.Add(new ListItem(HttpUtility.HtmlEncode(itemtypeobj[icount].Name) + " - TestsAssociated", HttpUtility.HtmlEncode(itemtypeobj[icount].ItemTypeID.ToString())));
            else
                rbtlstconsumable.Items.Add(new ListItem(HttpUtility.HtmlEncode(itemtypeobj[icount].Name), HttpUtility.HtmlEncode(itemtypeobj[icount].ItemTypeID.ToString())));

        }

    }

    protected void lnkBtnInventoryName_Click(object sender, EventArgs e)
    {
        sppopuptitle.InnerText = "Edit Inventory Item";

        var hftemp = (HiddenField)grdItemType.Rows[Convert.ToInt32(hfItemTypeID.Value)].FindControl("hfitemtypeid");

        Int32 itemtypeid = Convert.ToInt32(hftemp.Value);
        rbtlstconsumable.SelectedValue = itemtypeid.ToString();

        if (rbtlstconsumable.SelectedItem.Text.IndexOf("TestsAssociated") > -1)
        {
            Int32 itemid = Convert.ToInt32(grdItemType.DataKeys[Convert.ToInt32(hfItemTypeID.Value)].Value);
            
            EInventoryItemTest[] testobj = null;

            var masterDal = new MasterDAL();
            //Mode '1' is used for Getting Inventory Item acc. to InventoryID
            var listInventoryItemTest = masterDal.GetInventoryItemTestbyInventoryID(itemid.ToString(), 1);

            if (listInventoryItemTest != null) testobj = listInventoryItemTest.ToArray();

            for (int icount = 0; icount < chklsttestassociated.Items.Count; icount++)
            {
                chklsttestassociated.Items[icount].Selected = false;
            }

            for (int count = 0; count < testobj.Length; count++)
            {
                for (int icount = 0; icount < chklsttestassociated.Items.Count; icount++)
                {
                    if (chklsttestassociated.Items[icount].Value == testobj[count].TestID.ToString())
                    {
                        chklsttestassociated.Items[icount].Selected = true;
                        break;
                    }
                }
            }
            ClientScript.RegisterStartupScript(typeof(string), "jscript", "<script language='javascript' type='text/javascript'> makevisiblediv('true'); </script>");
        }
        else
            ClientScript.RegisterStartupScript(typeof(string), "jscript", "<script language='javascript' type='text/javascript'> makevisiblediv('false'); </script>");

        ModalPopupExtender.Show();
    }

}
