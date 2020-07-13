<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="Falcon.App.UI.App.Common.EditCustomer" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register src="../UCCommon/UCEditCustomer.ascx" tagname="UCEditCustomer" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <script src="../JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>" type="text/javascript" language="javascript"></script>
    <script src="/scripts/jquery-1.5.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        
    body, html {font: normal 12px Arial, Helvetica, tahoma; background-color: #fff; margin:0px; color:#000; line-height: 1.5em; height: 101%;}
    form{ margin: 0; padding:0; }
    img{ border:0px; }
    p{margin:0px; padding:0px;}
    span{margin:0px; padding:0px;}
    /*********************************************  Edit Customer Common clases  *************************************** */
    .mainbody_outer_fcr{ float:left; width:777px; background-color:#fff; margin-top:5px; }
    .mainbody_inner_fcr{ width:763px; margin-left:14px; margin-bottom:5px}
    .main_area_bdr_Editdata_fcr{ float:left; width:753px; border:1px solid #E5E5E5; margin-top:5px;}
    .head_text_editp{ float:left; width:740px; padding-left:10px; padding-top:5px; padding-bottom:5px; font:bold 12px arial; color:#000000;}
    .main_container_row_editp{ float:left; width:734px; padding-left:10px; padding-top:3px; padding-right:5px; padding-bottom:3px;}
    .titletext_editp{ float:left; width:110px; margin-right:5px; padding-top:3px; font:bold 12px arial; color:#000;}
    .inputfieldcon_editp{ float:left; width:180px; margin-right:85px; padding-top:0px; font:bold 12px arial; color:#000;}
    .inputf_editp{ border: 1px solid #7F9DB9; Background-color:#fff; font: normal 12px arial; color:#333; padding:2px;}
    .headbg_boxtop_editp{ float:left; width:753px; background-color:#E1F1F8; height:24px; margin-bottom:0px; }
    .head_text_editp{ float:left; width:740px; padding-left:10px; padding-top:5px; padding-bottom:5px; font:bold 12px arial; color:#000000;}
    .reqiredmark{font:normal 11px arial; color:Red; }
.inputfieldareacon_editp{ float:left; width:600px; padding-top:0px;}
.inputfieldrightcon_editp{ float:left; width:180px; font:normal 12px arial; color:#000; font:bold 12px arial; color:#000;}
    
.titletextnowidth_default1{ float:left;padding-top:0px; margin-left:40px;}
.ttxtnowidthnormal_default{ float:left; margin-right:5px; padding-top:3px; font-weight:normal;}
.orngheadtxt_heading{float:left; font:bold 20px arial; color:#F37C00;}
.headingbox_top_body{float:left; padding:0px 5px 0px 0px; width:100%;}
.pgnosymbol_common{float:left; width:38px; height:39px;}
.pgnosymbolvsmall_common{float:left; width:26px; height:27px; margin-top:4px;}
.orngheadtxt16_common{float:left; font:bold 16px arial; color:#F47E1C; padding:10px 0px 0px 5px;}
.inputfldnowidth_default{ float:left; margin:0px; padding:0px;}
    
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <div><asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        
        <uc1:UCEditCustomer ID="UCEditCustomer1" runat="server" />
        
    </div>
    </form>
</body>
</html>
