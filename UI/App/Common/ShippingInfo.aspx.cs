using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.DependencyResolution;
using Falcon.DataAccess.Other;
using Falcon.Entity.Other;
using Falcon.App.Lib;

public partial class App_Common_ShippingInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            FillDeliveryMode();
            FillState();
            if (Request.QueryString["OrderID"] != null && Request.QueryString["OrderShippingInformationID"] != null)
            {
                FillShippingInfo();
            }
        }

    }

    protected void imgBtnSubmit_Click(object sender, ImageClickEventArgs e)
    {
        var otherDal = new OtherDAL();
        EOrderShippingInformation objShippingInfo = new EOrderShippingInformation();

        EZip objzip = otherDal.CheckCityZip(txtCity.Text, txtZip.Text, ddlstate.SelectedItem.Value);
        if (objzip.CityID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "JSCode_CityValidation", "alert('City Name entered is not correct.'); ", true);
            return;
        }
        else if (objzip.ZipID == 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "JSCode_ZipValidation", "alert('Zip Code entered is not correct.'); ", true);
            return;
        }
        objShippingInfo.OrderShippingInformationID = Convert.ToInt32(Request.QueryString["OrderShippingInformationID"].ToString());
        objShippingInfo.Carrier = Convert.ToInt32(ddlcarrier.SelectedValue);
        objShippingInfo.CarrierTransactionNumber = txtcarriertno.Text;
        objShippingInfo.ShippingDate = Convert.ToDateTime(txtShippingDate.Text).ToString();
        objShippingInfo.ShippingNotes = txtShippingNotes.Text;
        objShippingInfo.ShippingAddressID = Convert.ToInt32(hfAddressID.Value);
        objShippingInfo.TrackingNumber = txtTrackingNo.Text;

        objShippingInfo.ShippingAddress = new EAddress();
        objShippingInfo.ShippingAddress.AddressID = Convert.ToInt32(hfAddressID.Value);
        objShippingInfo.ShippingAddress.Address1 = txtAddress1.Text;
        objShippingInfo.ShippingAddress.Address2 = txtAddress2.Text;
        objShippingInfo.ShippingAddress.StateID = Convert.ToInt32(ddlstate.SelectedValue);
        objShippingInfo.ShippingAddress.CityID = objzip.CityID;
        objShippingInfo.ShippingAddress.ZipID = objzip.ZipID;


        objShippingInfo.LastModifiedBy = Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.OrganizationRoleUserId);
        objShippingInfo.LastModifiedByRole = Convert.ToInt32(IoC.Resolve<ISessionContext>().UserSession.CurrentOrganizationRole.RoleId);

        Int64 returnresult = otherDal.UpdateShippingInfo(objShippingInfo);
        if (returnresult > 0)
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode_savesuccessful", "parent.parent.GB_hide(); ", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(typeof(string), "jscode_saveerror", "alert('Shipping Information not saved successfully.'); ", true);
        }

    }
    # region

    private void FillState()
    {
        var masterDal = new Falcon.DataAccess.Master.MasterDAL();
        List<Falcon.Entity.Other.EState> states = masterDal.GetState(string.Empty, 3);
        ddlstate.DataSource = states;
        ddlstate.DataTextField = "Name";
        ddlstate.DataValueField = "StateID";
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("Select State", "0"));
    }
    private void FillDeliveryMode()
    {
        var otherDal = new OtherDAL();
        ECarrier[] objCarrier;
        objCarrier = otherDal.GetAllCarrier().ToArray();

        if (objCarrier != null && objCarrier.Length > 0)
        {
            for (int count = 0; count < objCarrier.Length; count++)
            {

                ddlcarrier.Items.Add(new ListItem(objCarrier[count].Carrier, objCarrier[count].CarrierID.ToString()));
            }
        }
        ddlcarrier.Items.Insert(0, new ListItem("Select Delivery Mode", "0"));

    }

    private void FillShippingInfo()
    {
        var otherDal = new OtherDAL();
        EOrderShippingInformation objShippingInfo = new EOrderShippingInformation();
        objShippingInfo = otherDal.GetShippingInfo(Convert.ToInt32(Request.QueryString["OrderID"].ToString()), Convert.ToInt32(Request.QueryString["OrderShippingInformationID"].ToString()));

        ddlcarrier.Items.FindByValue(objShippingInfo.Carrier.ToString()).Selected = true;
        txtcarriertno.Text = objShippingInfo.CarrierTransactionNumber;
        txtTrackingNo.Text = objShippingInfo.TrackingNumber;
        if (objShippingInfo.ShippingDate != "")
            txtShippingDate.Text = Convert.ToDateTime(objShippingInfo.ShippingDate).ToShortDateString();
        else
            txtShippingDate.Text = System.DateTime.Now.ToShortDateString();

        txtShippingNotes.Text = objShippingInfo.ShippingNotes;
        txtAddress1.Text = objShippingInfo.ShippingAddress.Address1;
        txtAddress2.Text = objShippingInfo.ShippingAddress.Address2;
        ddlstate.Items.FindByText(objShippingInfo.ShippingAddress.State).Selected = true;
        txtCity.Text = objShippingInfo.ShippingAddress.City;
        txtZip.Text = objShippingInfo.ShippingAddress.Zip;

        hfAddressID.Value = objShippingInfo.ShippingAddressID.ToString();
    }

    # endregion

}
