<%@ Page Language="C#" MasterPageFile="~/App/CallCenter/CallCenterMaster.master" AutoEventWireup="true" Inherits="CallCenter_ViewCallCenterRep"
    Title="Untitled Page" Codebehind="ViewCallCenterRep.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <script type="text/javascript" language="javascript">
    
    function GridMasterCheck()
    {
        Grid_MasterCheckBoxClick("<%= this.gridviewccrep.ClientID %>");
        var grdControl=document.getElementById("<%= this.gridviewccrep.ClientID %>");
        var rowcount =0;
        while(rowcount < grdControl.rows[0].cells[0].childNodes.length)
            {
                if(grdControl.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT")
                    {   
                     var mstrchkbox = grdControl.rows[0].cells[0].childNodes[rowcount];
                      break;
                    }
                rowcount = rowcount + 1;
            }
        
        if (mstrchkbox.checked ==true)
        { SetEdit(false)}
         else
         { SetEdit(true)}
    }
    
    function GridChildCheck()
    {//debugger
        Grid_ChildCheckBoxClick("<%= this.gridviewccrep.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccrep.ClientID %>", objtemp);
        if(numcount == "1")
        {
//         Grid_EnableEditbutton("<%= this.btnEdit.ClientID %>");
//         SetEdit(true)
        }
        else
         { 
//         Grid_DisableEditbutton("<%= this.btnEdit.ClientID %>");
//           SetEdit(false)
         }
    }
    
    function CheckForDelete()
    {
        
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccrep.ClientID %>", objtemp);
        if(numcount == 0)
        {
            alert("Please select atleast one item from the list");
            return false;
        }
        var answer = confirm ("All the selected Items will be deleted. ")
        return answer;
    }
    
    function CheckForEdit()
    {
        
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.gridviewccrep.ClientID %>", objtemp);
        if(numcount != 1)
        {
            alert("Please select one item from the list.");
            return false;
        }
        return true;
    }

    </script>

    <ajaxToolkit:ToolkitScriptManager runat="server" ID="manager">
    </ajaxToolkit:ToolkitScriptManager>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
          <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading">View Call Centre Rep</span>
                    <span class="headingright_default"> <a href="AddCallCenterRep.aspx">+ Add Call Centre Rep</a></span>
                </div>
            </div> 
             <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
              <p class="graylinefull_default"><img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false" runat="server"></div>
            <div class="main_area_bdrnone">
              <%-- <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <contenttemplate>--%>
                <div class="divbuttonsrow">
                    <%--<div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>--%>
                    <div class="master_buttons_row">
                        <div class="master_buttonssmall_con">
                            <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../Images/del-button.gif"
                                OnClientClick="return CheckForDelete();" OnClick="btnDelete_Click" />
                        </div>
                        <div class="master_buttonssmall_con" style="visibility:hidden; display:none;">
                            <asp:ImageButton runat="server" ID="btnEdit" Enabled="true" ImageUrl="../Images/edit-button.gif"
                                OnClientClick="return CheckForEdit();" OnClick="btnEdit_Click" />
                        </div>
                    </div>
                </div>
                <div class="divgridviewccrep">
                    <asp:GridView runat="server" ID="gridviewccrep" AutoGenerateColumns="false" CssClass="divgrid_cl"
                        GridLines="None" OnRowDataBound="gridviewccrep_RowDataBound">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name" AccessibleHeaderText="name" SortExpression="Name">
                                <ItemTemplate>
                                    <a href="AddCallCenterRep.aspx?EmployeeID=<%# DataBinder.Eval(Container.DataItem, "organizationRoleUserId")%>">
                                        <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Address" HtmlEncode="false" HeaderText="Address">
                            </asp:BoundField>
                            <asp:BoundField DataField="Phone" HeaderText="Start Date" DataFormatString="{0:dd-MMM-yyyy}"
                                HtmlEncode="false">
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email" HtmlEncode="false">
                            </asp:BoundField> 
                            <asp:BoundField DataField="organizationRoleUserId"  HeaderText="organizationRoleUserId" HtmlEncode="false" HeaderStyle-CssClass = "hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle CssClass="row1" />
                        <RowStyle CssClass="row2" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
               <%-- <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnDelete" EventName="OnClick"></asp:AsyncPostBackTrigger>
                            </Triggers>
                </contenttemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </div>

</asp:Content>
