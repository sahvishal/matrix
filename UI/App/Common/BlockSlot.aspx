<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Common_BlockSlot" Codebehind="BlockSlot.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="padding:0px; margin:0px;">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        p{padding:0;margin:0}
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
            padding: 8px 8px 0px 8px;
            background-image: url(../Images/mid-boxbg-urm.png);
            background-repeat: repeat-y;
        }
        .msgboxinnerrow_urm
        {
            float: left;
            width: 274px;
            margin: 5px 0px 5px 0px;
        }
        .msgboxinnerrow1_urm
        {
            float: left;
            width: 274px;
            margin: 5px 0px 5px 0px;
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
            background-image: url(../Images/bot-boxbg-urm.png);
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
            padding-right: 5px;
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
    
    <script language="javascript" type="text/javascript">
        
    function validateblockslot()
    {
        if(isBlank(document.getElementById('<%= this.txtReason.ClientID %>'), 'Reason'))
            return false;
    }    
    </script>
    
</head>
<body style="padding:0px; margin:0px;">
    <form id="form1" runat="server">
    <div>
        <div class="msgboxrow_urm">
        <div class="midbg_mbox_urm">
            <p class="msgboxinnerrow_urm">
                <span class="headtxtmsgbox_urm">Block Appointment</span>
            </p>
            <p class="graylinembox_urm">
                <img src="~/app/Images/specer.gif" width="1" height="1" /></p>
            <div class="msgboxinnerrow_urm">
                <asp:TextBox ID="txtReason" TextMode="MultiLine" Rows="7" runat="server" Width="265px"
                    CssClass="inputf_def"></asp:TextBox>
            </div>
            <p class="msgboxinnerrow_urm">
                <span class="titletxt_urm">
                    <img src="~/app/Images/specer.gif" width="110" height="1" />
                </span><span class="btnrow_mbox">
                    <asp:ImageButton ID="ibtnBlockSlot" runat="server" CssClass="" ImageUrl="~/App/Images/block-btn.gif"
                        OnClientClick=" return validateblockslot();" OnClick="ibtnBlockSlot_Click"></asp:ImageButton>
                </span>
            </p>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
