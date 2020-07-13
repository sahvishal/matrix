<%@ Control Language="C#" AutoEventWireup="true" Inherits="UCCommon_ucphotopanel" Codebehind="ucphotopanel.ascx.cs" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<script language="javascript" type="text/javascript">
<!--



// -->
</script>

<div class="maindivphotopanel">
    <div class="seconeddivphotopanel">
        <asp:Image runat="server" ID="imgImage" Width="150px" Height="107px" ImageUrl="~/App/Images/myphoto6.jpg" />
    </div>
    <div class="thirddivphotopanel">
        <div class="fourdivpanelphtopanel">
            <asp:FileUpload ID="FileUpload1" runat="server" OnDataBinding="FileUpload1_DataBinding" />&nbsp;
        </div>
        <div class="fifthdivphotopanel">
            <asp:TextBox runat="server" ID="txtCaption" ReadOnly="true" Visible="False"></asp:TextBox>&nbsp;
            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" TargetControlID="txtCaption"
                WatermarkCssClass="" WatermarkText="Caption" runat="server">
            </cc1:TextBoxWatermarkExtender>
        </div>
    </div>
</div>


			    
			
			    
    			
		      
		      
		        
 