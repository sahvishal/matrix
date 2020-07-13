<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcShippingDetails.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.UcShippingDetails" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="JQueryToolkit" runat="server" IncudeJQueryJTip="true" />

<script language="javascript" type="text/javascript">
    $(document).ready(function() {
        $('.jTip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
    });

</script>

<style type="text/css">
    .wrapper_sd
    {
        float: left;
        width: 540px;
        padding: 3px 0 3px 0;
    }
    .wrapper_sd .hrow
    {
        float: left;
        width: 100%;
        padding-top: 5px;
    }
    .wrapper_sd .hrow1
    {
        float: left;
        width: 100%;
        padding: 10px 5px;
    }
    .wrapper_sd .hrow .lbl
    {
        float: left;
        width: 105px;
        padding: 0 5px 0 10px;
    }
    .wrapper_sd .inputtxt
    {
        border: 1px solid #7F9DB9;
        background-color: #fff;
        z-index: -5;
        font: normal 12px arial;
        color: #333;
        padding: 2px;
        float: left;
    }
    .blutxt_sd
    {
        color: #009fc3;
        font-weight: bold;
    }
    .divbg_sd
    {
        float: left;
        width: 540px;
        padding: 5px 5px;
        background: #f8f8f8;
    }
    .divbg_sd .lbl
    {
        float: left;
        padding-right: 5px;
    }
</style>

<script type="text/javascript" language="javascript">
    
//    $(function() {
//            $('.main-shipping-table').find('.main-shipping-table-row input:radio:first').attr('checked', true);
////            $('.main-shipping-table').find('.main-shipping-table-row input:radio:first').click();
//        });
        
    function ShowShippingAddress() {
        var radioShippingAddressNo = document.getElementById("<%=RadioShippingAddressNo.ClientID %>");
        if (radioShippingAddressNo.checked) {
            var divShippingAddress = document.getElementById("<%=DivShippingAddress.ClientID %>");
            divShippingAddress.style.display = "block";
        }
    }

    function HideShippingAddress() {
        var radioShippingAddressYes = document.getElementById("<%=RadioShippingAddressYes.ClientID %>");
        if (radioShippingAddressYes.checked) {
            var divShippingAddress = document.getElementById("<%=DivShippingAddress.ClientID %>");
            divShippingAddress.style.display = "none";
        }
    }

    function ValidateShippingAddress() {
        var radioShippingAddressNo = document.getElementById("<%=RadioShippingAddressNo.ClientID %>");
        if (radioShippingAddressNo.checked) {
            var txtAddress1 = document.getElementById("<%= txtAddress1.ClientID %>");
            if (isBlank(txtAddress1, "Shipping Address"))
            { return false; }

            var txtCity = document.getElementById("<%= txtCity.ClientID %>");
            if (isBlank(txtCity, "City for the Shipping Address"))
            { return false; }
           
            
            var stateDropDown = document.getElementById("<%= StateDropDown.ClientID %>");
            if ((checkDropDown(stateDropDown, "State for the Shipping Address") == false))
            { return false; }
            var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");

            if (isBlank(txtZip, "Zip for the Shipping Address")) {
                return false;
            }
        }
        return true;
    }

    
</script>

<script type="text/javascript" language="javascript">
    var states;
    
    function BindShippingSateDropDown(stateList) {//debugger;
        $('#' + '<%=StateDropDown.ClientID %> >option').remove();

        if (stateList.length > 0) {
            $('#' + '<%=StateDropDown.ClientID %>').append($('<option></option>').val('0').html('Select State'));
            for (var i = 0; i < stateList.length; i++) {
                if (stateList[i].CountryId == $('#' + '<%=ddlCountry.ClientID %>').val())
                    $('#' + '<%=StateDropDown.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
            }
        }
        else {
            $('#' + '<%=StateDropDown.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
        }
        if ($('#<%=hfstate.ClientID %>').val() != '') {
            $("#<%= StateDropDown.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);
        }
    }

    function SetState() {
        $('#<%=hfstate.ClientID %>').val($('#<%=StateDropDown.ClientID %> option:selected').text());
    }
    
    $(document).ready(function () {// debugger;       
        if ('<%=ShippingOptionId.HasValue %>'=='False')
        {            
            $('.main-shipping-table').find('.main-shipping-table-row input:radio:first').attr('checked', true);
            $('.main-shipping-table').find('.main-shipping-table-row input:radio:first').click();
        }
        states=<%= GetStates() %>;
        
        BindShippingSateDropDown(states);
        
        $('#<%=ddlCountry.ClientID %>').bind("change", function () { BindShippingSateDropDown(states); });
        $('#<%=StateDropDown.ClientID %>').bind("change", function () { SetState(); });
    }); 
</script>
<asp:HiddenField ID="hfstate" runat="server" />
<div class="wrapper_sd" style="width:420px;">
    <asp:GridView ID="grdvShippingOption" runat="server" AutoGenerateColumns="false"
        ShowHeader="false" GridLines="None" CssClass="gridselectpackage main-shipping-table">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <span style="float: left; width: 40px;">
                        <input type='radio' id='rbtn<%#DataBinder.Eval(Container.DataItem,"Id") %>' name='ShippingOption'
                            onclick='selectResultOrder("<%#DataBinder.Eval(Container.DataItem,"Id") %>")' />
                    </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <span id="spTitle<%#DataBinder.Eval(Container.DataItem,"Id") %>" style="padding-right: 5px">
                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                    </span><span class="jTip" title='Description/Disclaimer!|<%#DataBinder.Eval(Container.DataItem,"Description") %>|<br /><strong><%#DataBinder.Eval(Container.DataItem,"Disclaimer") %></strong><br />'
                        id="spMoreInfo"><span class="smalltxtblu">[More Info]</span> </span>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <span style="float: left; width: 60px;"><span style="float: left; padding-right: 4px;">
                        $</span> <span style="float: left;" id='spSalePrice<%# DataBinder.Eval(Container.DataItem, "Id")%>'><%# DataBinder.Eval(Container.DataItem, "Price")%></span> </span>
                </ItemTemplate>
                <ItemStyle ForeColor="#E78839" />
            </asp:TemplateField>
        </Columns>
        <RowStyle CssClass="row2 main-shipping-table-row" />
    </asp:GridView>
</div>
<div class="wrapper_sd">
    <div class="hrow1">
        <span class="left blutxt_sd" style="font:normal 12px Arial;">Is Shipping Address is same as your Contact Address?</span>
        <span class="right">
            <asp:RadioButton ID="RadioShippingAddressYes" runat="server" Text="Yes" GroupName="ShiipingAddress"  style="font:normal 12px Arial;"/>
            <asp:RadioButton ID="RadioShippingAddressNo" runat="server" Text="No" GroupName="ShiipingAddress"  style="font:normal 12px Arial;"/>
        </span>
    </div>
</div>
<div class="wrapper_sd" id="DivShippingAddress" runat="server" style="font:normal 12px Arial;">
    <div class="hrow">
        <label class="lbl">
            Address<sup>*</sup></label>
        <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputtxt" Width="300px"></asp:TextBox>
    </div>
    <div class="hrow">
        <label class="lbl">
            Suite, Apt, etc.</label>
        <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputtxt" Width="300px"></asp:TextBox>
    </div>
    <div class="hrow">
        <label class="lbl">
            Country<sup>*</sup></label>
        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="inputtxt" Width="150px">
        </asp:DropDownList>
    </div>
    <div class="hrow">
        <label class="lbl">
            State<sup>*</sup></label>
        <asp:DropDownList ID="StateDropDown" runat="server" CssClass="inputtxt" Width="150px">
        </asp:DropDownList>
    </div>      
    <div class="hrow">
        <label class="lbl">
            City<sup>*</sup></label>
        <asp:TextBox ID="txtCity" runat="server" CssClass="inputtxt" Width="100px"></asp:TextBox>
    </div>      
    <div class="hrow">
        <label class="lbl">
            Zip Code<sup>*</sup></label>
        <asp:TextBox ID="txtZip" runat="server" CssClass="inputtxt" Width="100px"></asp:TextBox>
    </div>
</div>