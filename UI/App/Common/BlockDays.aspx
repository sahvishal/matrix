<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="App_Common_BlockDays" Codebehind="BlockDays.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="maindivblockdays_common" style="border:solid 1px #E5E5E5">
    <div class="mainrowblockdays_common" >
    <p class="mainrowblockdays_common">
    <span class="titletextsmallbold_default">Date:</span>
    <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox1" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
    </p>
    <p class="mainrowblockdays_common">
    <span class="titletextsmallbold_default">Reason:</span>
    <span class="inputfldnowidth_default"><asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Rows="4" CssClass="inputf_def" Width="400px"></asp:TextBox></span>
    </p>
    <p class="mainrowblockdays_common">
    <span class="titletextsmallbold_default"><img src="../Images/specer.gif" width="70px" height="1px" /></span>
    <span class="inputfldnowidth_default">
        <asp:CheckBox ID="CheckBox1" Text="Is Active?" runat="server" /> </span>
    </p>
    
    <div class="mainrowblockdays_common" style="height:100px; overflow-y:auto">
    <asp:GridView runat="server" ID="grdblockdays" CssClass="gridchkbox" GridLines="None" AutoGenerateColumns="false">
                        <Columns>                           
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name">
                            </asp:BoundField>
                            <asp:BoundField DataField="Address" HeaderText="Address">
                            </asp:BoundField>
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
    
    </div>
    
    <p><img src="../Images/specer.gif" width="500px" height="10px" /></p>
    <p class="mainrowblockdays_common">
    <span class="buttoncon_default"><asp:ImageButton  runat="server" ID="ibtnsave" ImageUrl="~/App/Images/save-button.gif" /></span>
    <span class="buttoncon_default"><asp:ImageButton  runat="server" ID="ImageButton1" ImageUrl="~/App/Images/cancel-btn.gif" /></span>
    </p>
    </div>





    </div>
</asp:Content>
