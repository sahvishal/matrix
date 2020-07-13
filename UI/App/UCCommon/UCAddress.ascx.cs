using System;
using System.Web.UI.WebControls;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Geo.Impl;
using Falcon.App.Lib;
using Falcon.App.Core.Application.Exceptions;

public partial class App_UCCommon_UCAddress : System.Web.UI.UserControl
{
    private string strCountry = string.Empty;
    private string strZipID = string.Empty;
    private string strCityID = string.Empty;
    private short _tabIndex;
    
    // format phone no.
    CommonCode objCommonCode = new CommonCode();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected override void OnInit(EventArgs e)
    {
        FillState();
    }

    public string Address
    {
        get { return txtaddress1.Text; }
        set { txtaddress1.Text = value; }
    }
    public string AddressSuit
    {
        get { return txtAddress2.Text; }
        set { txtAddress2.Text = value; }
    }
    public string City
    {
        get { return txtCity.Text; }
        set { txtCity.Text = value; }
    }
    public string CityID
    {
        get { return strCityID; }
        set { strCityID = value; }
    }
    
    public string State
    {
        get { return ddlState.SelectedValue; }
        set
        {
            if (ddlState.Items.FindByValue(value) != null)
            {
                ddlState.SelectedValue=value;
            }
        }
    }

    public string StateText
    {
        get { return ddlState.SelectedItem.Text; }
        set
        {
            var item = ddlState.Items.FindByText(value);
            if (item != null)
            {
                item.Selected = true;
            }
        }
    }
    public string Zip
    {
        get { return txtZip.Text; }
        set { txtZip.Text = value;}
    }
    public string ZipID
    {
        get { return strZipID; }
        set { strZipID = value; }
    }
    
    public string PhoneCell
    {
        get { return objCommonCode.FormatPhoneNumberGet(txtphonecell.Text); }
        set { txtphonecell.Text = value; }
    }
    public string PhoneHome
    {
        get { return objCommonCode.FormatPhoneNumberGet(txtphonehome.Text); }
        set { txtphonehome.Text = value; }
    }
    public string PhoneOther
    {
        get { return objCommonCode.FormatPhoneNumberGet(txtphoneother.Text); }
        set { txtphoneother.Text = value; }
    }
    public string Email
    {
        get { return txtEmail1.Text; }
        set { txtEmail1.Text = value; }
    }
    public string EmailOther
    {
        get { return txtEmail2.Text; }
        set { txtEmail2.Text = value; }
    }
    public string Country
    {
        get { return strCountry; }
        set { strCountry = value; }
    }
    public short TabIndex
    {
        get
        {
            return _tabIndex;
        }
        set
        {
            _tabIndex = value;
            txtaddress1.TabIndex = (short)(value++);
            txtAddress2.TabIndex = (short)(value++);
            txtCity.TabIndex = (short)(value++);
            ddlState.TabIndex = (short)(value++);
            txtZip.TabIndex = (short)(value++);
            txtphonecell.TabIndex = (short)(value++);
            txtphonehome.TabIndex = (short)(value++);
            txtphoneother.TabIndex = (short)(value++);
            txtEmail1.TabIndex = (short)(value++);
            txtEmail2.TabIndex = (short)(value++);
        }
    }   

    public string ValidateCityStateZip(string city,string state,string zipCode, string prefix)
    {
        string strMessage = string.Empty;
        try
        {
            IAddressRepository addressRepository = new AddressRepository();
            addressRepository.ValidateAddress(new Address("line1", "", city, state, zipCode, "USA"));
        }
        catch (InvalidAddressException ex)
        {
            strMessage = ex.Message;
        }

        return strMessage;
    }

    /// <summary>
    /// Fill all State
    /// </summary>
    public void FillState()
    {
        IStateRepository stateRepository = new StateRepository();
        var states = stateRepository.GetAllStates();

        ddlState.Items.Clear();

        ddlState.DataSource = states;
        ddlState.DataTextField = "Name";
        ddlState.DataValueField = "Id";
        ddlState.DataBind();

        ddlState.Items.Insert(0, new ListItem("Select State", "0"));
    }
    
}
