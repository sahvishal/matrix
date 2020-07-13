using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;

public partial class App_UCCommon_ucManageOrder : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtCustID.Attributes.Add("onKeyDown", "return txtkeypress(event);");

            hfRoleID.Value = IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId.ToString();
            hfUserID.Value = IoC.Resolve<ISessionContext>().UserSession.UserId.ToString();

            FillDeliveryMode();
            GetAllOrder();
        }

    }

    protected void ibtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SearchOrder();
    }

    protected void dgManageOrder_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = (DataTable)ViewState["DSGRID"];
            DataRowView drv = dt.DefaultView[(dgManageOrder.PageSize * dgManageOrder.PageIndex) + e.Row.RowIndex];

            HtmlContainerControl spNotAccepted = (HtmlContainerControl)e.Row.FindControl("spNotAccepted");
            HtmlContainerControl spAccepted = (HtmlContainerControl)e.Row.FindControl("spAccepted" );
            HtmlContainerControl spPrint = (HtmlContainerControl)e.Row.FindControl("spPrint");

            HtmlContainerControl spShippingInfo = (HtmlContainerControl)e.Row.FindControl("spShippingInfo");
            HtmlContainerControl spOrder = (HtmlContainerControl)e.Row.FindControl("spOrder");
            HtmlAnchor ashippingInfo = (HtmlAnchor)e.Row.FindControl("ashippingInfo");

            if (drv["IsAccepted"].ToString() == "Not Accepted")
            {
                spNotAccepted.Style.Add(HtmlTextWriterStyle.Display, "block");
                spAccepted.Style.Add(HtmlTextWriterStyle.Display, "none");
                spShippingInfo.Style.Add(HtmlTextWriterStyle.Display, "none");
                spPrint.Style.Add(HtmlTextWriterStyle.Display, "none");
                HtmlAnchor aNotAccepted = (HtmlAnchor)e.Row.FindControl("aNotAccepted");
                if (drv["PaymentStatus"].ToString() == "Unpaid")
                {
                    aNotAccepted.Attributes.Add("onclick", "alert('Order can not be processed because it is unpaid.');");
                }
                else
                {
                    aNotAccepted.Attributes.Add("onclick", "return AcceptOrder('" + drv["OrderID"].ToString() + "','" + spNotAccepted.ClientID + "','" + spAccepted.ClientID + "','" + spPrint.ClientID + "','" + spShippingInfo.ClientID + "')");
                }
                //aNotAccepted.Attributes.Add("onclick", "return AcceptOrder('" + drv["OrderID"].ToString() + "','" + spNotAccepted.ClientID + "','" + spAccepted.ClientID + "','" + spPrint.ClientID + "','" + spShippingInfo.ClientID + "','" + drv["OrderShippingInformationID"].ToString() + "','" + spOrder.ClientID + "','" + ashippingInfo.ClientID + "')");

            }
            else
            {
                spNotAccepted.Style.Add(HtmlTextWriterStyle.Display, "none");
                spAccepted.Style.Add(HtmlTextWriterStyle.Display, "block");
                spPrint.Style.Add(HtmlTextWriterStyle.Display, "block");
                spShippingInfo.Style.Add(HtmlTextWriterStyle.Display, "block");

                //spShippingInfo.InnerHtml="<a href='/App/Common/ShippingInfo.aspx?OrderID=" + drv["OrderID"].ToString() + "&OrderShippingInformationID=" + drv["OrderShippingInformationID"].ToString() + "' id='aShippingInfo' rel='gb_page_center[565, 428]'>" + drv["OrderID"].ToString() + "</a>";

            }
            ashippingInfo.HRef = "/App/Common/ShippingInfo.aspx?OrderID=" + drv["OrderID"].ToString() + "&OrderShippingInformationID=" + drv["OrderShippingInformationID"].ToString();
            HtmlContainerControl spPending = (HtmlContainerControl)e.Row.FindControl("spPending");
            HtmlContainerControl spDelivered=(HtmlContainerControl)e.Row.FindControl("spDelivered");
            if(drv["Status"].ToString() == "Pending")
            {
                spPending.Style.Add(HtmlTextWriterStyle.Display,"block");
                spDelivered.Style.Add(HtmlTextWriterStyle.Display,"none");
            }
            else
            {
                spPending.Style.Add(HtmlTextWriterStyle.Display,"none");
                spDelivered.Style.Add(HtmlTextWriterStyle.Display,"block");
            }
        }
    }

    protected void dgManageOrder_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        dgManageOrder.PageIndex = e.NewPageIndex;
        dgManageOrder.DataSource = (DataTable)ViewState["DSGRID"];
        dgManageOrder.DataBind();
    }

    protected void ddlRecords_SelectedIndexChanged(object sender, EventArgs e)
    {
        SearchOrder();
    }

    protected void imgBtnReadyToShip_Click(object sender, ImageClickEventArgs e)
    {
        imgBtnReadyToShip.ImageUrl = "~/App/Images/readytoship-tab-on.gif";
        imgBtnDelivered.ImageUrl = "~/App/Images/Delivered-tab-off.gif";
        imgBtnUpcomingOrders.ImageUrl = "~/App/Images/Upcoming-tab-off.gif";

        var otherDal = new OtherDAL();
        DataSet ds = otherDal.GetOrderDetail("", "", "", 0, Convert.ToInt32(ddlOrderStatus.Items.FindByText("Pending").Value), Convert.ToInt32(ddlDeliveryMode.Items.FindByText("Select Delivery Mode").Value), 1);

        BindOrderList(ds);
        dgManageOrder.Columns[7].Visible = true;
    }
    protected void imgBtnDelivered_Click(object sender, ImageClickEventArgs e)
    {
        imgBtnReadyToShip.ImageUrl = "~/App/Images/readytoship-tab-off.gif";
        imgBtnDelivered.ImageUrl = "~/App/Images/Delivered-tab-on.gif";
        imgBtnUpcomingOrders.ImageUrl = "~/App/Images/Upcoming-tab-off.gif";

        var otherDal = new OtherDAL();
        DataSet ds = otherDal.GetOrderDetail("", "", "", 0, Convert.ToInt32(ddlOrderStatus.Items.FindByText("Delivered").Value), Convert.ToInt32(ddlDeliveryMode.Items.FindByText("Select Delivery Mode").Value), 1);

        BindOrderList(ds);
        dgManageOrder.Columns[7].Visible = true;
    }
    protected void imgBtnUpcomingOrders_Click(object sender, ImageClickEventArgs e)
    {
        imgBtnReadyToShip.ImageUrl = "~/App/Images/readytoship-tab-off.gif";
        imgBtnDelivered.ImageUrl = "~/App/Images/Delivered-tab-off.gif";
        imgBtnUpcomingOrders.ImageUrl = "~/App/Images/Upcoming-tab-on.gif";

        var otherDal = new OtherDAL();
        DataSet ds = otherDal.SearchOrderForUpcomingEvents();

        BindOrderList(ds);

        dgManageOrder.Columns[7].Visible = false;
    }

    # region "Methods"

    private void FillDeliveryMode()
    {
        var otherDal = new OtherDAL();
        ECarrier[] objCarrier = otherDal.GetAllCarrier().ToArray();

        if (objCarrier != null && objCarrier.Length > 0)
        {
            for (int count = 0; count < objCarrier.Length; count++)
            {

                ddlDeliveryMode.Items.Add(new ListItem(objCarrier[count].Carrier, objCarrier[count].CarrierID.ToString()));
            }
        }
        ddlDeliveryMode.Items.Insert(0, new ListItem("Select Delivery Mode", "0"));

    }

    private void GetAllOrder()
    {
        imgBtnReadyToShip.ImageUrl = "~/App/Images/readytoship-tab-on.gif";
        imgBtnDelivered.ImageUrl = "~/App/Images/Delivered-tab-off.gif";
        imgBtnUpcomingOrders.ImageUrl = "~/App/Images/Upcoming-tab-off.gif";

        var otherDal = new OtherDAL();
        DataSet ds =otherDal.GetOrderDetail("", "", "", 0, Convert.ToInt32(ddlOrderStatus.SelectedValue), Convert.ToInt32(ddlDeliveryMode.SelectedValue), 0);

        BindOrderList(ds);
    }

    private void SearchOrder()
    {
        if (ddlOrderStatus.SelectedItem.Text == "Pending")
        {
            imgBtnReadyToShip.ImageUrl = "~/App/Images/readytoship-tab-on.gif";
            imgBtnDelivered.ImageUrl = "~/App/Images/Delivered-tab-off.gif";
            imgBtnUpcomingOrders.ImageUrl = "~/App/Images/Upcoming-tab-off.gif";
        }
        else if (ddlOrderStatus.SelectedItem.Text == "Delivered")
        {
            imgBtnReadyToShip.ImageUrl = "~/App/Images/readytoship-tab-off.gif";
            imgBtnDelivered.ImageUrl = "~/App/Images/Delivered-tab-on.gif";
            imgBtnUpcomingOrders.ImageUrl = "~/App/Images/Upcoming-tab-off.gif";
        }
        int custId=0;
        if (txtCustID.Text.Trim() != "")
            custId = Convert.ToInt32(txtCustID.Text);
        var otherDal = new OtherDAL();
        DataSet ds = otherDal.GetOrderDetail(txtCustName.Text.Replace("'", "''"), txtStartDate.Text, txtEndDate.Text, custId, Convert.ToInt32(ddlOrderStatus.SelectedValue), Convert.ToInt32(ddlDeliveryMode.SelectedValue), 1);
        BindOrderList(ds);
        dgManageOrder.Columns[7].Visible = true;
    }
    private void BindOrderList(DataSet ds)
    {
        DataTable dtOrder = new DataTable();
        dtOrder.Columns.Add("OrderID");
        dtOrder.Columns.Add("CustomerID");
        dtOrder.Columns.Add("CustomerName");
        dtOrder.Columns.Add("Address1");
        dtOrder.Columns.Add("City");
        dtOrder.Columns.Add("State");
        dtOrder.Columns.Add("ZipCode");
        dtOrder.Columns.Add("OrderType");
        dtOrder.Columns.Add("CreatedBy");
        dtOrder.Columns.Add("CreatedByRole");
        dtOrder.Columns.Add("PaymentStatus");
        dtOrder.Columns.Add("Status");
        dtOrder.Columns.Add("IsAccepted");
        dtOrder.Columns.Add("OrderShippingInformationID");
        dtOrder.Columns.Add("ShippingDate");
        dtOrder.Columns.Add("Carrier");
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
        {
            spNoOfOrders.InnerHtml = ds.Tables[0].Rows.Count.ToString();
            divGrid.Style.Add(HtmlTextWriterStyle.Display, "block");
            dvNoOrderFound.Style.Add(HtmlTextWriterStyle.Display, "none");
            for (int count = 0; count < ds.Tables[0].Rows.Count; count++)
            {
                dtOrder.Rows.Add(new object[]{ds.Tables[0].Rows[count]["OrderID"].ToString(),
                                                ds.Tables[0].Rows[count]["CustomerID"].ToString(),
                                                ds.Tables[0].Rows[count]["CustomerName"].ToString(),
                                                ds.Tables[0].Rows[count]["Address1"].ToString(),
                                                ds.Tables[0].Rows[count]["City"].ToString(),
                                                ds.Tables[0].Rows[count]["State"].ToString(),
                                                ds.Tables[0].Rows[count]["ZipCode"].ToString(),
                                                ds.Tables[0].Rows[count]["OrderType"].ToString(),
                                                ds.Tables[0].Rows[count]["CreatedBy"].ToString(),
                                                ds.Tables[0].Rows[count]["CreatedByRole"].ToString(),
                                                ds.Tables[0].Rows[count]["PaymentStatus"].ToString(),
                                                //Convert.ToString((OrderStatus)(Convert.ToInt16(ds.Tables[0].Rows[count]["Status"]))),
                                                ds.Tables[0].Rows[count]["IsAccepted"].ToString(),
                                                ds.Tables[0].Rows[count]["OrderShippingInformationID"].ToString(),
                                                Convert.ToDateTime(ds.Tables[0].Rows[count]["ShippingDate"].ToString()).ToShortDateString(),
                                                ds.Tables[0].Rows[count]["Carrier"].ToString(),
                                                });

            }
            if (dtOrder.Rows.Count <= 10)
            {
                ddlRecords.Enabled = false;
            }
            else
            {
                ddlRecords.Enabled = true;
                dgManageOrder.PageSize = Convert.ToInt32(ddlRecords.SelectedValue);
            }

            ViewState["DSGRID"] = dtOrder;
            dgManageOrder.DataSource = dtOrder;
            dgManageOrder.DataBind();

        }
        else
        {
            ddlRecords.Enabled = false;
            spNoOfOrders.InnerText = "0";
            divGrid.Style.Add(HtmlTextWriterStyle.Display, "none");
            dvNoOrderFound.Style.Add(HtmlTextWriterStyle.Display, "block");
        }
    }
    # endregion




}
