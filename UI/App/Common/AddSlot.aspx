<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Common_AddSlot" Codebehind="AddSlot.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" style="padding:0px; margin:0px;">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
form{ margin: 0; padding:0; }
img{ border:0px; }
p{margin:0px; padding:0px;}
span{margin:0px; padding:0px;} 
        
        .msgboxrow_urm
        {
            float: left;
            width: 288px;
        }
        .toparrow_urm
        {
            float: left;
            padding-left: 213px;
        }
        .topbg_mbox_urm
        {
            float: left;
            width: 290px;
            height: 6px;
            background-image: url(../Images/top-boxbg-urm.png);
            background-repeat: no-repeat;
        }
        .midbg_mbox_urm
        {
            float: left;
            width: 274px;
            height:138px;
            padding: 0px 8px 0px 8px;
        }
        .msgboxinnerrow_urm
        {
            float: left;
            width: 274px;
            padding-top:5px;
        }
        .msgboxinnerrow1_urm
        {
            float: left;
            width: 274px;
            padding: 5px 0px 5px 0px;
        }
        .msgboxinnerrowmf_urm
        {
            float: left;
            width: 274px;
            margin: 0px;
        }
        .botbg_mbox_urm
        {
            float: left;
            width: 290px;
            height: 6px;
            /*background-image: url(../Images/bot-boxbg-urm.png); */
            background-color:#F5EFC9;
        }
        .headtxtmsgbox_urm
        {
            float: left;
            font: bold 18px arial;
            color: #ED8313;
        }
        .closebtn_urm
        {
            float: right;
            width: 21px;
        }
        .graylinembox_urm
        {
            float: left;
            width: 274px;
            display: block;
            height: 1px;
            background-color: #CCCCCC;
        }
        .titletxt_urm
        {
            float: left;
            width: 115px;
            padding-top: 5px;
            font:bold 12px arial;
        }
        .inputfldconmbox_urm
        {
            float: left;
            width: 140px;
        }
        .chkboxmbox_urm
        {
            float: left;
            width: 20px;
            margin-right: 5px;
        }
        .txtchkbox_urm
        {
            float: left;
            font-size: 11px;
            padding-top: 2px;
        }
        .inputfldnowidth_default
        {
            float: left;
            margin: 0px;
            padding: 0px;
        }
        .inputf_def
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            z-index: -5;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .btnrow_mbox
        {
            float: right;
            padding-right: 10px;
            margin: 0px;
            padding: 0px;
        }
        
        .watermarktxt
        {
        	Color:#ccc; 
        	font-style:italic;
        }
        
    </style>
    
    <script src="../JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" language="javascript" type="text/javascript"></script>
    <script src="../JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
    
    <script type="text/javascript" language="javascript">
    
        function validateaddslot()
        {
            if(isBlank(document.getElementById('<%= this.txtstarttime.ClientID %>'), 'Start Time'))
                return false;
                
            if(!IsValidSlotTime(document.getElementById('<%= this.txtstarttime.ClientID %>').value))
                return false;
            
            if(document.getElementById('<%= this.txtendtime.ClientID %>').value != '' && document.getElementById('<%= this.txtendtime.ClientID %>').value != 'Optional')
            {
                if(!IsValidSlotTime(document.getElementById('<%= this.txtendtime.ClientID %>').value))
                    return false;
            }
        }
        
        function FilterTime(key, textbox, dFilterMask)
        {
            return dFilter(key, textbox, dFilterMask);
        }

	    function AddSlotAutoFill(textbox)
        {
            dFilter_AutoFill(textbox);
        }
    
    function IsValidSlotTime(timeStr) 
    {
    var timePat = /^(\d{1,2}):(\d{2})(:(\d{2}))?(\s?(AM|am|PM|pm))?$/;

    var matchArray = timeStr.match(timePat);
    if (matchArray == null) {
    alert("Time is not in a valid format.");
    return false;
    }
    hour = matchArray[1];
    minute = matchArray[2];
    second = matchArray[4];
    ampm = matchArray[6];

    if (second=="") { second = null; }
    if (ampm=="") { ampm = null; }

    if (hour < 0  || hour > 23) 
    {
        alert("Hour must be between 1 and 12 Or (0 and 23)");
        return false;
    }
    
    if (hour <= 12 && ampm == null) 
    {
        if (confirm("Please indicate which time format you are using.  OK = Standard Time, CANCEL = Military Time")) 
        {
            alert("You must specify AM or PM.");
            return false;
        }
    }
    
    if  (hour > 12 && ampm != null) 
    {
        alert("Hour factor should be less than equal to 12.");
        return false;
    }
    
    if (minute<0 || minute > 59) 
    {
        alert ("Minute must be between 0 and 59.");
        return false;
    }
    
    if (second != null && (second < 0 || second > 59)) 
    {
        alert ("Second must be between 0 and 59.");
        return false;
    }
    return true;
}
    
    </script>
    

</head>

<body style="padding:0px; margin:0px;">
    <form id="form1" runat="server" style="padding:0px; margin:0px;">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="msgboxrow_urm">
        <div class="midbg_mbox_urm">
            <p class="msgboxinnerrow_urm">
                <span class="headtxtmsgbox_urm">Appointment Slot:</span> 
            </p>
             <p><img alt="" src="../Images/specer.gif" width="274px" height="5px" /></p>
            <p class="graylinembox_urm"><img alt="" src="~/app/Images/specer.gif" width="270px" height="1px" /></p>
            <p><img src="../Images/specer.gif" width="270px" height="5px" alt="" /></p>
            <p class="msgboxinnerrow_urm">
                <span class="titletxt_urm">Start Time:</span> <span class="inputfldnowidth_default">
                    <asp:TextBox ID="txtstarttime" runat="server" Width="133px" CssClass="inputf_def" onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                </span>
            </p>
            <p class="msgboxinnerrow_urm">
                <span class="titletxt_urm">End Time:</span> <span class="inputfldnowidth_default">
                    <asp:TextBox ID="txtendtime" runat="server" Width="133px" CssClass="inputf_def" onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                </span>
                <cc1:TextBoxWatermarkExtender runat="server" ID="wmeffectendtime" TargetControlID="txtendtime"
                    WatermarkText="Optional" WatermarkCssClass="watermarktxt">
                </cc1:TextBoxWatermarkExtender>
            </p>
            <p class="msgboxinnerrow_urm">
                <span class="titletxt_urm">
                    <img height="1" src="~/app/Images/specer.gif" width="110" />
                </span><span class="btnrow_mbox" style="padding-right: 20px;">
                    <asp:ImageButton ID="ibtnAddSlot" runat="server" CssClass="" ImageUrl="~/App/Images/add-btn.gif"
                        OnClick="ibtnAddSlot_Click" OnClientClick="return validateaddslot();" ValidationGroup="addslot" />
                </span>
            </p>
             <p><img src="../Images/specer.gif" width="270px" height="5px" alt="" /></p>
        </div>
    </div>
    </form>
</body>

</html>
