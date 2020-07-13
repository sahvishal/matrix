<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_Masters_MarketingSource" Title="Untitled Page"
    CodeBehind="MarketingSource.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .wrapper_pop_l
        {
            float: left;
            width: 335px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop_l
        {
            float: left;
            width: 311px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop_l
        {
            float: left;
            width: 301px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function hidediv() { ////debugger
            if (document.getElementById) { // DOM3 = IE5, NS6 
                //  document.getElementById('bottom_bdr_master').style.visibility = 'hidden'; 


            }
            else if (document.layers) { // Netscape 4
                // document.hideshow.visibility = 'hidden'; 

            }
            else { // IE 4 
                // document.all.hideshow.style.visibility = 'hidden'; 

            }
            //HandleValidators(false);

        }

        function showdiv() {
            if (document.getElementById) { // DOM3 = IE5, NS6 
                // document.getElementById('bottom_bdr_master').style.visibility = 'visible'; 
            }
            else if (document.layers) { // Netscape 4
                // document.hideshow.visibility = 'visible'; 
            }
            else { // IE 4 
                //  document.all.hideshow.style.visibility = 'visible'; 
            }
            //HandleValidators(true);

        }



        function EmptyBoxes() {
            // //debugger
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            var txtName = document.getElementById('<%= this.txtName.ClientID %>');
            var txtNotes = document.getElementById('<%= this.txtNotes.ClientID %>');
            var hfMarketingSourceID = document.getElementById('<%= this.hfMarketingSourceID.ClientID %>');

            txtName.value = '';
            txtNotes.value = '';
            popuptitle.innerHTML = 'Add New Marketing Source';
            hfMarketingSourceID.value = "";

        }


        function HandleValidators() {
            ////debugger
            var txtName = document.getElementById("<%= this.txtName.ClientID %>");

            if (isBlank(txtName, 'Marketing Source')) {
                return false;
            }
            return true;
        }




        function GridMasterCheck() {
            //debugger
            Grid_MasterCheckBoxClick("<%= this.grdMarketingSource.ClientID %>");

            var btnDelete = document.getElementById("<%= this.btnDelete.ClientID %>");
            var btnActivate = document.getElementById("<%= this.btnActivate.ClientID %>");
            var btnDeActivate = document.getElementById("<%= this.btnDeActivate.ClientID %>");
            var objtemp = document.createElement("INPUT");
            var numcount2 = Grid_MultiSelect("<%= this.grdMarketingSource.ClientID %>", objtemp)
            if (numcount2 == 0) {
                btnDelete.disabled = true;
                btnActivate.disabled = true;
                btnDeActivate.disabled = true;
            }
            else if (numcount2 > 0) {
                btnDelete.disabled = false;
                btnActivate.disabled = false;
                btnDeActivate.disabled = false;
            }

        }

        function GridChildCheck() {
            Grid_ChildCheckBoxClick("<%= this.grdMarketingSource.ClientID %>");
            var objtemp = document.createElement("INPUT");
            var numcount2 = Grid_MultiSelect("<%= this.grdMarketingSource.ClientID %>", objtemp)
            var btnDelete = document.getElementById("<%= this.btnDelete.ClientID %>");
            var btnActivate = document.getElementById("<%= this.btnActivate.ClientID %>");
            var btnDeActivate = document.getElementById("<%= this.btnDeActivate.ClientID %>");
            if (numcount2 < 1) {

                btnDelete.disabled = true;
                btnActivate.disabled = true;
                btnDeActivate.disabled = true;
            }
            else if (numcount2 > 0) {
                btnDelete.disabled = false;
                btnActivate.disabled = false;
                btnDeActivate.disabled = false;
            }

        }

        function validate(type) {
            //debugger
            var objtemp = document.createElement("INPUT");
            var numcount = Grid_MultiSelect("<%= this.grdMarketingSource.ClientID %>", objtemp);

            if (numcount >= 1 && (type == "Delete")) {
                var answer = confirm("Are you sure you want to delete Marketing Source(s) ? ")
                return answer;
            }
            else if (numcount >= 1 && (type == "Acivate")) {
                var answer = confirm("Are you sure you want to acivate Marketing Source(s) ? ")
                return answer;
            }
            else if (numcount >= 1 && (type == "DeAcivate")) {
                var answer = confirm("Are you sure you want to deacivate the selected Marketing Source(s) ? ")
                return answer;
            }
            else if (numcount == 0) {
                alert("Please select atleast one item from the grid");
                return false;
            }

        }
        function EditMarketingSource(lnkBtnID) { //debugger
            var selectcount = 0;
            var selectedrow = 0;
            var txtName = document.getElementById("<%= this.txtName.ClientID %>");
            var txtNotes = document.getElementById("<%= this.txtNotes.ClientID %>");
            var grdMarketingSource = document.getElementById("<%= this.grdMarketingSource.ClientID %>");
            var hfMarketingSourceID = document.getElementById("<%= this.hfMarketingSourceID.ClientID %>");

            var count = 0;

            var nodecount = 0;
            while (count < (grdMarketingSource.rows.length - 1)) {
                while (nodecount < grdMarketingSource.rows[count + 1].cells[1].childNodes.length) {
                    if (grdMarketingSource.rows[count + 1].cells[1].childNodes[nodecount].nodeName == "A")
                        break;
                    nodecount++;
                }

                if (grdMarketingSource.rows[count + 1].cells[1].childNodes[nodecount].id == lnkBtnID) {
                    showdiv();
                    txtName.value = grdMarketingSource.rows[count + 1].cells[1].childNodes[nodecount].innerHTML;
                    if (grdMarketingSource.rows[count + 1].cells[2].innerHTML == "&nbsp;")
                        txtNotes.value = '';
                    else
                        txtNotes.value = grdMarketingSource.rows[count + 1].cells[2].innerHTML;

                    hfMarketingSourceID.value = count;
                    break;
                }

                count++;
            }
            //debugger
            var sppopuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            sppopuptitle.innerHTML = "Edit Marketing Source";
            $find('mdlPopup').show();

            return false;
        }
     
    </script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Marketing Source</span>
                    <span class="headingright_default">
                        <asp:LinkButton ID="addNewMarketingSource" runat="server" Text="+ Add new Marketing Source"
                            OnClientClick='EmptyBoxes();' /></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <%--******************* Buttons Row above Grid ***************** --%>
            <div class="divbuttonsrow">
                <div class="master_buttons_row">
                    <div class="master_buttons_con">
                        <a href=""></a>
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/App/Images/del-button_master.gif"
                            OnClientClick="return validate('Delete');" OnClick="btnDelete_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href=""></a>
                        <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="~/App/Images/activate_butt_master.gif"
                            OnClientClick="return validate('Acivate');" OnClick="btnActivate_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href=""></a>
                        <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="~/App/Images/deactivate_butt_master.gif"
                            OnClientClick="return validate('DeAcivate');" OnClick="btnDeActivate_Click" />
                    </div>
                </div>
            </div>
            <%--**********************************************************--%>
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdMarketingSource" AutoGenerateColumns="false"
                    DataKeyNames="MarketingSourceID" CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdMarketingSource_RowDataBound"
                    EnableSortingAndPagingCallbacks="False" AllowPaging="true" PageSize="25" OnPageIndexChanging="grdMarketingSource_PageIndexChanging"
                    AllowSorting="True" OnSorting="grdMarketingSource_Sorting">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" class="master_chkboxbox" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" class="master_chkboxbox" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="name" HeaderText="HostType" SortExpression="name desc">
                            </asp:BoundField>--%>
                        <asp:TemplateField SortExpression="Source desc" HeaderText="Marketing Source">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkBtnMarketingSource" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Source") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="notes" HeaderText="Notes"></asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status"></asp:BoundField>
                        <asp:BoundField DataField="MarketingSourceID" Visible="false" />
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="PopUp">
        <div class="wrapper_pop_l">
            <div class="wrapperin_pop_l">
                <div class="innermain_pop_l">
                    <p class="innermain_pop_l">
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Add new Marketing
                            Source</span> <span style="float: right">
                                <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                            </span>
                    </p>
                    <p class="innermain_pop_l" style="border-top: solid 1px #ccc; padding-top: 5px;">
                        <span style="float: right;"><span class="graysmalltxt_default"><span class="reqiredmark">
                            <sup>*</sup> </span>Mandatory Fields</span> </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletextsmallbld_default">Source:<span class="reqiredmark"><sup>*</sup>
                        </span></span><span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtName" runat="server" CssClass="inputf_def" Width="215px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletextsmallbld_default">Notes:<span class="reqiredmark"><sup>*</sup>
                        </span></span><span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtNotes" TextMode="MultiLine" Rows="3" runat="server" Width="215px"
                                CssClass="inputf_def"></asp:TextBox>
                        </span>
                    </p>
                    <div class="innermain_pop_l" style="margin-top: 5px; display:none;">
                        <fieldset>
                            <legend>Territories </legend>
                            <asp:CheckBoxList runat="server" ID="TerritoriesCheckbox" RepeatColumns="2" RepeatDirection="Horizontal"
                                Height="100px" Style="overflow-x: hidden; overflow-y: scroll;" />
                        </fieldset>
                    </div>
                    <asp:HiddenField ID="hfMarketingSourceID" runat="server" />
                    <p class="innermain_pop_l" style="margin-top: 5px;">
                        <span class="buttoncon_default">
                            <asp:ImageButton runat="server" CausesValidation="true" ID="btnSave" ImageUrl="~/App/Images/save-button.gif"
                                OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />
                        </span><span class="buttoncon_default">
                            <asp:ImageButton runat="server" CausesValidation="true" ID="btnCancel" ImageUrl="~/App/Images/cancel-button.gif"
                                OnClientClick="$find('mdlPopup').hide(); return false;" OnClick="btnCancel_Click" />
                        </span>
                    </p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewMarketingSource"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol"
        BehaviorID="mdlPopup" />
</asp:Content>
