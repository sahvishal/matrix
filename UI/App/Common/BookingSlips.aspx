<%@ Page Language="C#" AutoEventWireup="True" Inherits="App_Common_BookingSlips" Codebehind="BookingSlips.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        P{padding:0px; margin:0px;}
   .maindiv_bs{float:left; width:329px; border:solid 1px #ccc;}
   .lefttxt_bs{float:left; width:85px;}
   .maininnerdiv_bs{float:left; width:244px;}
   .maininnerrows_bs{float:left; width:242px; text-align:center; font:normal 12px arial;}
   .capsboldtxt_bs{font:bold 12px arial;}
   .titletxt_bs{float:left; font:bold 12px arial; color:#000; margin-right:5px;}
   .normaltxt_bs{float:left; font:normal 12px arial; color:#000;}
   .txtcodeshow_bs{float:left; width:56px; padding-left:27px;}
   .txtcoderow_bs{float:left; width:27px;}
   .dollersign_bs{float:left; width:27px; height:23px;}
   .txtcodemaindiv{float:left; width:27px;}
   
   .gridtop { BORDER: #e5e5e5 1px solid; BORDER-COLLAPSE: collapse; BACKGROUND-COLOR: #fff; width:100%; }
   .gridtop TD { BORDER: #e5e5e5 1px solid; PADDING:4px; text-align:left; vertical-align:top; }
   .gridtop TH { BORDER: #e5e5e5 1px solid; text-align:left; PADDING:4px 4px 4px 10px; color:#000; vertical-align:top;}
   .paymenttype{width:100px;}
   .dollars{width:74px;}
   .cents{width:50px;}
   .totalarrow_bs{float:left; width:12px; height:33px; margin-right:5px;}
   .totaltxt_bs{float:left; width:50px; font:normal 10px arial; line-height:10px;}
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maindiv_bs">
        <div class="lefttxt_bs">
            <span style="margin-bottom:30px; float:left"><img src="../Images/bookingslips-img.gif" alt="" /></span>
            <span style="margin-bottom:10px"><img src="../Images/boa-logo.gif" alt="" /> </span>
            <div class="txtcodeshow_bs">
                <div class="txtcoderow_bs">
                <span class="dollersign_bs"> <img src="../Images/dollersignbig-bs.gif" alt="" /></span>
                <span class="txtcodemaindiv">
                <img src="../Images/txtcode_1.gif" alt="" />
                <img src="../Images/txtcode_2.gif" alt="" />
                <img src="../Images/comma-bs.gif" alt="" />
                <img src="../Images/txtcode_3.gif" alt="" />
                <img src="../Images/txtcode_4.gif" alt="" />
                <img src="../Images/txtcode_5.gif" alt="" />
                 <img src="../Images/comma-bs.gif" alt="" />
                 <img src="../Images/txtcode_6.gif" alt="" />
                <img src="../Images/txtcode_7.gif" alt="" />
                <img src="../Images/txtcode_8.gif" alt="" />
                <img src="../Images/dott-bs.gif" alt="" />
                 <img src="../Images/txtcode_9.gif" alt="" />
                <img src="../Images/txtcode_0.gif" alt="" />                
                </span>
                <span class="dollersign_bs"> <img src="../Images/dollersignsmall-bs.gif" alt="" /></span>
                </div>
            </div>
        
        </div>
        <div class="maininnerdiv_bs">
        <p class="maininnerrows_bs" style="padding-bottom:10px"> DEPOSIT TICKET </p>
        <p class="maininnerrows_bs" style="padding-bottom:10px"><span class="capsboldtxt_bs"> FOR CLEAR COPY, PRESS FIRMLY</span></p>
        <p class="maininnerrows_bs" style="margin-bottom:5px;">
        <span class="titletxt_bs">Date </span>
        <span class="normaltxt_bs"> <asp:Label ID="lbldate" runat="server" > 12-12-2008</asp:Label></span></p>
        <div class="maininnerrows_bs">
        <table cellpadding="0" cellspacing="0" border="0" class="gridtop">
<%--        <tr>
        <td><img src="../Images/specer.gif" width="105" height="1" alt="" /></td>
        <td><img src="../Images/specer.gif" width="65" height="1" alt="" /></td>
        <td><img src="../Images/specer.gif" width="32" height="1" alt="" /></td>
        </tr>--%>
        <tr>
        <td>&nbsp;</td>
        <td class="dollars">Dollars</td>
        <td class="cents">Cents</td>
        </tr>
        <tr>
        <td class="paymenttype">CURRENCY</td>
        <td class="dollars">&nbsp;</td>
        <td>&nbsp;</td>
        </tr>
        <tr>
        <td class="paymenttype">C0INS</td>
        <td class="dollars">&nbsp;</td>
        <td class="cents">&nbsp;</td>
        </tr>
         <tr>
        <td class="paymenttype">CHECKS</td>
        <td class="dollars">&nbsp;</td>
        <td class="cents">&nbsp;</td>
        </tr>
        </table>
        </div>
        <div class="maininnerrows_bs">
        <asp:GridView ID="dgbookingslips" runat="server" CssClass="gridtop" ShowFooter="true" ShowHeader="false" GridLines="None" AutoGenerateColumns="false" >
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>1.</ItemTemplate>
                             <FooterTemplate>
                             <div style="float:left">
                             <span class="totalarrow_bs"><img src="../Images/arrow-total-bs.gif" /></span>
                             <span class="totaltxt_bs">Please Re-Enter Total here</span>
                             <span style="float:left; padding-top:5px; font-weight:bold"> Total</span>
                             </div>
                             </FooterTemplate>
                            <ItemStyle CssClass="paymenttype" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate><a href="#"><%# DataBinder.Eval(Container.DataItem, "Dollars")%></a></ItemTemplate>
                            <ItemStyle CssClass="dollars" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate><a href="#"><%# DataBinder.Eval(Container.DataItem, "Cents")%></a></ItemTemplate>
                            <ItemStyle CssClass="cents" />
                        </asp:TemplateField>
                         </Columns>
                </asp:GridView>
        </div>
        <p class="maininnerrows_bs"><span style=" float:left; width:240px; border:solid 1px #e5e5e5">PLEASE BE SURE ALL ITEMS ARE PROPERLY ENDORSED</span> </p> 
       <p class="maininnerrows_bs"><img src="../Images/specer.gif" width="100px" height="10px" /></p> 
        </div>
     </div> 
    </form>
</body>
</html>
