<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Franchisee_Technician_GenerateDepositeSlip" Codebehind="GenerateDepositeSlip.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Deposit Slip</title>
    <style type="text/css">
        P{padding:0px; margin:0px;}
   .maindiv_bs{float:left; width:379px; border:solid 1px #ccc;}
   .routingdiv{float:left; width:25px; padding-top:160px;}
   .lefttxt_bs{float:left; width:105px;}
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
   .dollars{ width:74px; text-align:right;}
   .cents{width:50px; text-align:right;}
   .totalarrow_bs{float:left; width:12px; height:33px; margin-right:5px;}
   .totaltxt_bs{float:left; width:50px; font:normal 10px arial; line-height:10px;}
    </style>
    <script language="javascript" type="text/javascript">
    function popupmenu2(choice,wt,ht)
    {
        
        var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=yes,scrollbars=yes,menubar=no,width=" + wt + ",height=" + ht;
        confirmWin = window.open(choice,'theconfirmWin',winOpts);
    }
    </script>   
</head>
<body>
    <form id="form1" runat="server">
    <div class="maindiv_bs">
    <div class="routingdiv"><img src="../../Images/routingno-accno-img.gif" alt="" /></div>
        <div class="lefttxt_bs">
            <span style="margin-bottom:30px; float:left; font:13px/1.5em arial,helvetica,tahoma" ><%=IoC.Resolve<ISettings>().CompanyName %></span>
            <span style="margin-bottom:10px"><img src="/App/Images/boa-logo.gif" alt="" /> </span>
            <div class="txtcodeshow_bs">
                <div class="txtcoderow_bs">
                <span class="dollersign_bs"> <img src="/App/Images/dollersignbig-bs.gif" alt="" /></span>
                <span class="txtcodemaindiv" id="spnTotalImageAmount" runat="server">               
                
                <%--<img src="/App/Images/txtcode_5.gif" alt="" />
                <img src="/App/Images/comma-bs.gif" alt="" />               
                <img src="/App/Images/dott-bs.gif" alt="" />--%>
                
                </span>
                <span class="dollersign_bs"> <img src="/App/Images/dollersignsmall-bs.gif" alt="" /></span>
                </div>
            </div>
        
        </div>
        <div class="maininnerdiv_bs">
        <p class="maininnerrows_bs" style="padding-bottom:10px"> DEPOSIT TICKET </p>
        <%--<p class="maininnerrows_bs" style="padding-bottom:10px"><span class="capsboldtxt_bs"> FOR CLEAR COPY, PRESS FIRMLY</span></p>--%>
        <p class="maininnerrows_bs" style="margin-bottom:5px;">
        <span class="titletxt_bs">Date </span>
        <span class="normaltxt_bs"> <asp:Label ID="lbldate" runat="server" > 12-12-2008</asp:Label></span></p>
        <div class="maininnerrows_bs">
        <table cellpadding="0" cellspacing="0" border="0" class="gridtop">
        <tr style="padding:0px; margin:0px; background-color:#ccc;">
        <td style="padding:0px; margin:0px;"><img src="/App/Images/specer.gif" width="114" height="1" alt="" /></td>
        <td style="padding:0px; margin:0px;"><img src="/App/Images/specer.gif" width="62" height="1" alt="" /></td>
        <td style="padding:0px; margin:0px;"><img src="/App/Images/specer.gif" width="62" height="1" alt="" /></td>
        </tr>
        <tr>
        <td>&nbsp;</td>
        <td class="dollars" style="text-align:right">Dollars</td>
        <td class="cents" style="text-align:right">Cents</td>
        </tr>
        <%--<tr>
        <td class="paymenttype">CURRENCY</td>
        <td class="dollars">&nbsp;</td>
        <td>&nbsp;</td>
        </tr>--%>
        <tr>
        <td class="paymenttype"><b>CASH</b></td>
        <td style="text-align:right" class="dollars" id="tdCashDollar" runat="server">&nbsp;</td>
        <td style="text-align:right" class="cents" id="tdCashCent" runat="server">&nbsp;</td>
        </tr>
         <tr>
        <td class="paymenttype"><b>CHECKS</b></td>
        <td style="text-align:right" class="dollars" id="tdChequeDollar" runat="server">&nbsp;</td>
        <td style="text-align:right" class="cents" id="tdChequeCent" runat="server">&nbsp;</td>
        </tr>
        </table>
        </div>
        <div class="maininnerrows_bs">
        <asp:GridView ID="grdDepositeSlip" runat="server" CssClass="gridtop" 
                ShowFooter="true" ShowHeader="false" GridLines="None" 
                AutoGenerateColumns="false" onrowdatabound="grdDepositeSlip_RowDataBound" >
                    <Columns>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                            <span id="spnSerialNumber" runat="server"><%# DataBinder.Eval(Container.DataItem, "SerialNo")%>.&nbsp;</span>
                            <span id="spnCheckNumber" runat="server">
                                <%# DataBinder.Eval(Container.DataItem, "ChequeNumber")%>
                            </span>                            
                            <br /> 
                            <span id="spnName" runat="server" style="font-size:smaller">
                                <%# DataBinder.Eval(Container.DataItem, "Name")%>                           
                            </span>
                            </ItemTemplate>
                             <FooterTemplate>
                             <div style="float:left; width:106px;">
                             <span class="totalarrow_bs"><img src="/App/Images/arrow-total-bs.gif" /></span>
                             <span class="totaltxt_bs">Please Re-Enter Total here</span>
                             <span style="float:left; padding-top:5px; font-weight:bold"> Total</span>                                   
                             </div>                            
                             </FooterTemplate>
                            <ItemStyle CssClass="paymenttype" />
                        </asp:TemplateField>                      
                         <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                            <div style="text-align:right">
                            <span id="spnAmountMain" runat="server" ><%# DollarAmount(DataBinder.Eval(Container.DataItem, "Amount"))%></span>
                            </div>
                            </ItemTemplate>
                            
                            <ItemStyle CssClass="cents" />
                              <FooterTemplate>
                             <div style="float:left; width:54px; text-align:right">
                             <span id="spnTotalAmountDollarFooter" runat="server">2454</span>                             
                             </div>                            
                             </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID">
                            <ItemTemplate>
                             <div style="text-align:right">
                            <span id="spnAmountDecimal" runat="server"><%# CentAmount(DataBinder.Eval(Container.DataItem, "Amount"))%></span>
                            </div>
                            </ItemTemplate>
                            <ItemStyle CssClass="cents" />
                             <FooterTemplate>
                             <div style="float:left; width:54px; text-align:right">
                             <span id="spnTotalAmountCentFooter" runat="server">54</span>                             
                             </div>                            
                             </FooterTemplate>
                        </asp:TemplateField>
                         </Columns>
                </asp:GridView>
         <span id="spnNoRecord" runat="server" style="visibility:hidden;display:none">
         <br /><b>No Customers found for selected event.</b><br/><br />
         </span>
        </div>
        <p class="maininnerrows_bs"><span style=" float:left; width:240px; border:solid 1px #e5e5e5">PLEASE BE SURE ALL ITEMS ARE PROPERLY ENDORSED</span> </p> 
       <p class="maininnerrows_bs"><img src="/App/Images/specer.gif" width="100px" height="10px" /></p> 
        </div>
     </div> 
    </form>
</body>
</html>
