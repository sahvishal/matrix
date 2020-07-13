<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Franchisor_PrintRecieptSmall" Codebehind="PrintRecieptSmall.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
    <link href="../StyleSheets/UC.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="maindiv_prsmall">
    <p class="contentrow_prsmall"> <img src="../Images/header-smallprintrec.gif" /> </p>
    <p class="grayline_prsmall"><img src="../Images/specer.gif" width="1px" height="1px" /></p>
    <p class="headerbg_prsmall">Patient Details</p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Name:</span>
    <span class="lbltxt_prsmall" style="width:200px;">Jose Carlos</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Customer ID:</span>
    <span class="lbltxt_prsmall" style="width:162px;">#523AS</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Package Details:</span>
    <span class="lbltxt_prsmall" style="width:140px;">133:00</span>
    </p>
    <p class="contentrow_prsmall">
    <span class="chkboxcon_prsmall"> <asp:CheckBox ID="CheckBox1" runat="server" /></span>
    <span class="normaltxt_prsmall">Abdominal Aortic Aneursym (AAA) Screening</span>
    </p>
    <p class="contentrow_prsmall">
    <span class="chkboxcon_prsmall"> <asp:CheckBox ID="CheckBox2" runat="server" /></span>
    <span class="normaltxt_prsmall">Stroke / Carotid Artery Disease Screening</span>
    </p>
    <p class="contentrow_prsmall">
    <span class="chkboxcon_prsmall"> <asp:CheckBox ID="CheckBox3" runat="server" /></span>
    <span class="normaltxt_prsmall">Peripheral Artery Disease (PAD) Screening</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Event ID:</span>
    <span class="lbltxt_prsmall" style="width:185px;">Jose Carlos</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Amount Paid:</span>
    <span class="lbltxt_prsmall" style="width:155px;">Jose Carlos</span>
    </p>
    
    <p class="txtrow_prsmall">
    <span class="bldtxt_prsmall">Method:</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bulletboxcon_prsmall"> <img src="../Images/gray-box-bullet.gif" /> </span>
    <span class="normaltxt_prsmall">Go to Public website <%= IoC.Resolve<ISettings>().SiteUrl%> </span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bulletboxcon_prsmall"> <img src="../Images/gray-box-bullet.gif" /> </span>
    <span class="normaltxt_prsmall">Click on Login  </span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bulletboxcon_prsmall"> <img src="../Images/gray-box-bullet.gif" /> </span>
    <span class="normaltxt_prsmall">Enter User Name</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bulletboxcon_prsmall"> <img src="../Images/gray-box-bullet.gif" /> </span>
    <span class="normaltxt_prsmall">Enter Password and click Login button</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bulletboxcon_prsmall"> <img src="../Images/gray-box-bullet.gif" /> </span>
    <span class="normaltxt_prsmall">Answer Sequrity Questions</span>
    </p>
    <p class="txtrow_prsmall">
    <span class="bulletboxcon_prsmall"> <img src="../Images/gray-box-bullet.gif" /> </span>
    <span class="normaltxt_prsmall">Re-enter the Password</span>
    </p>
    <p class="graylinedotted_prsmall"><img src="../Images/specer.gif" width="1px" height="1px" /></p>
    
    <p class="headerbgbig_prsmall"> Health <em>YES</em>! Coupon</p>
    <p class="bigtxtrow_prsmall">
    <span class="bigfont_prsmall">$10</span>
    <span class="bigfont2_prsmall">OFF</span>
    </p>
     <p class="bigtxtrow_prsmall">
     <span class="smallbldtxt_prsmall">good for any purchase over $120.00</span>
     </p>
     <p class="grayheaderbg_prsmall">
     <span class="graytxtleft_prsmall">Expires March 31st, 2008</span>
     <span class="graytxtright_prsmall">Coupon code: HYCIO254</span>
     </p>
    
    </div>
    </form>

</body>
</html>
 