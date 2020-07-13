<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master"
AutoEventWireup="true" CodeBehind="ApproveInvoice.aspx.cs" Inherits="Falcon.App.UI.App.MedicalVendor.ApproveInvoice" Title="Medical Vendor Invoice Approval" %>
<%@ Import Namespace="Falcon.App.Core.Enum"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

<link type="text/css" href="<%=ResolveUrl("~/App/jquery/css/ui-lightness/jquery-ui-1.7.2.custom.css")%>" rel="Stylesheet" />	

<div id="divMainOuter" runat="server" style="float:left; display:block; width:100%; padding: 5px">
    <div class="orngheadtxt_heading">Invoice Approval</div>
     
    <div style="clear:both;" >
        &nbsp;
    </div>    
	
    <div id="SuccessMessageDiv" class="ui-widget"  style="display:none">
        <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;"> 
            <p><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span>
            <strong>Thank you!</strong> Your invoice has been approved. The invoice will be sent for prior payment processing.</p>
            
            <p><a href="<%=ResolveUrl("~/App/MedicalVendor/MVUserDashboard.aspx")%>">Go back to Dashboard</a></p>
        </div>
    </div>
        
    
  <div id="ApprovalButtonDiv"  style="text-align:right;padding:5px;margin-top: -40px">
        <a href="<%= ResolveUrl("~/App/MedicalVendor/MVUserDashboard.aspx") %>" >Cancel</a>&nbsp;
        <a href="#" class="ui-state-default ui-corner-all" style="padding: 5px; font-size: larger"
            id="ApprovalButton" onclick="ApproveInvoice()">Approve</a>	            
  </div>
    
     <div id="ProcessApprovalDiv" style="display:none">
       <p>Please wait...</p>
  	    <br />   	             
        <img src="../Images/indicatorbig.gif" />
     </div>
    
    <div id="MedicalVendorInvoiceDiv">
        <p>Loading invoice. Please wait...</p>
  	    <br />   	             
        <img src="../Images/indicatorbig.gif" />
    </div>
</div>  
<%--TODO: *Jquery include Remove*--%>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery-1.3.2.min.js")%>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/jquery-jtemplate.js")%>"></script>
<script type="text/javascript" src="<%=ResolveUrl("~/App/jquery/js/Formatter.js")%>"></script>
    

<script type="text/javascript" language="javascript">
    var _invoice;

    $(document).ready(function() {    
        
        var messageUrl = "<%=ResolveUrl("~/App/Controllers/MedicalVendorPaymentWebService.asmx/GetOldestUnapprovedInvoiceForMedicalVendorUser")%>";
        var parameter = "{'medicalVendorMedicalVenderUserId':'" + <%=_medicalVendorMedicalVenderUserId%> + "'}";       
                                    
        $.ajax({
            type: "POST",
            url: messageUrl,
            data: parameter,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(returnData) {                
                    {                                                 
                        $("#MedicalVendorInvoiceDiv").setTemplateURL('<%=ResolveUrl("~/App/Templates/MedicalVendorInvoice.html")%>');                       
                        $("#MedicalVendorInvoiceDiv").processTemplate(returnData.d);
                        
                        _invoice = returnData.d
                        
                        // TODO: Move to CSS
                        $("#MedicalVendorInvoiceItemTable th").css("background-color", "#DDF0F7");
                        $("#MedicalVendorInvoiceItemTable tr:even").css("background-color", "#EFF8FD");
                        $("#MedicalVendorInvoiceItemTable tr:odd").css("background-color", "#F8FCFF");
                        
                        var canSeeEarning = eval('<%=_canSeeEarnings.ToString().ToLower()%>');
                        
                        if (!canSeeEarning)
                        {
                            HideAmounts();
                        } 
                    }
            },    
            error: function() {                
                    {   
                        $("#MedicalVendorInvoiceDiv").html("Error.");                           
                    }
            }                    
        });                        
    })
    
    function HideAmounts()
    {
        $('.amt').hide();
    }
    
    function ApproveInvoice()
    {
        $("#ApprovalButtonDiv").hide('slow');
        $("#MedicalVendorInvoiceDiv").hide('slow');
        $("#ProcessApprovalDiv").show();
             
        var messageUrl = "<%=ResolveUrl("~/App/Controllers/MedicalVendorPaymentWebService.asmx/ChangeInvoiceApprovalStatus")%>";
        var parameter = "{'invoiceId':'" + _invoice.Id + "'";       
            parameter += ",'approvalStatus':'" + <%= (int)ApprovalStatus.Approved %> + "'}";  
            
        $.ajax({
                type: "POST",
                url: messageUrl,
                data: parameter,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function(returnData) {                
                        {
                            $("#ProcessApprovalDiv").hide();                                                                                                
                            $("#SuccessMessageDiv").show('slow');                            
                        }
                },    
                error: function() {                
                        {   
                            $("#MedicalVendorInvoiceDiv").html("Error.");                           
                        }
                }                    
            });              
    
    }
</script>

</asp:Content>