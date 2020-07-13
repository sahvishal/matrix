<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Franchisee_SalesRep_TemplateTimeSlots" Codebehind="TemplateTimeSlots.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" style="overflow-y:scroll;" >
<head runat="server">
    <title>Untitled Page</title>
    <link href="../../StyleSheets/Wizardstyle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        
        function CheckParentWindow()
        {
            if(document.getElementById('<%= this.hfcheck.ClientID %>').value != "")
                return;
            var selvalue = parent.parent.ReturnChangeScheduleTemplate();
            document.getElementById('<%= this.hfcheck.ClientID %>').value = "Something";
            __doPostBack('GetValue', selvalue);
        }
    
    </script>
</head>
<body onload="CheckParentWindow();">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:HiddenField runat="server" ID="hfcheck" Value="" />
        <div class="maindiv_tts">
        <p class="immerrow_tts">
        <span id="spschedtemplatename" runat="server" class="titletextnowidth_default"></span>
        </p>
        <p><img src="../../Images/specer.gif" width="200px" height="5px" /></p>
          
            <div class="immerrow_tts">
                <asp:Gridview runat="server" CssClass="gridbg_tts" ID="gvtimeslots" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <span class="halfrow_tts" style="font-weight:bold; text-align:left;"> TimeSlot </span>
                                <span class="midspace_tts" style="font-weight:bold;">-</span>
                                <span class="halfrow2_tts" style="font-weight:bold; "> Patients per slot </span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <p class="gridrow_tts">
                                    <span class="halfrow_tts"> <%# DataBinder.Eval(Container.DataItem, "TimeSlot")%> </span>
                                    <span class="midspace_tts" style="text-align:center;">-</span>
                                    <span class="halfrow2_tts" style="text-align:center;"> <%# DataBinder.Eval(Container.DataItem, "NumberPatient")%> </span>
                                </p>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:Gridview>
            </div>
            
            <%--<p class="butoncell_sr">
                <span class="btncon_sr">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App/Images/close-button.gif" />
                </span>
            </p>--%>
            
        </div>
    </form>
</body>
</html>
