<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="CallCenter_ViewCallCentre" Title="Untitled Page"
    CodeBehind="ViewCallCentre.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" language="javascript">

        function mastercheckboxclick() {
            ////debugger

            var grdcallcenter = document.getElementById('<%= this.grdCallCentre.ClientID %>');
            var rowcount = 0;
            var mstrchkbox;

            while (rowcount < grdcallcenter.rows[0].cells[0].childNodes.length) {
                if (grdcallcenter.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT") {
                    mstrchkbox = grdcallcenter.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }


            rowcount = 1;
            var nodecount = 0;
            while (rowcount < grdcallcenter.rows.length) {
                if (rowcount == 1) {
                    while (nodecount < grdcallcenter.rows[rowcount].cells[0].childNodes.length) {
                        if (grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT") {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if (grdcallcenter.rows[rowcount].cells.length > 1)
                    grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
            MultiSelect();

        }


        function checkallboxes() {
            ////debugger

            var grdcallcenter = document.getElementById('<%= this.grdCallCentre.ClientID %>');
            var rowcount = 0;
            var mstrchkbox;

            while (rowcount < grdcallcenter.rows[0].cells[0].childNodes.length) {
                if (grdcallcenter.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT") {
                    mstrchkbox = grdcallcenter.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }

            rowcount = 1;
            MultiSelect();

            var nodecount = 0;
            while (rowcount < grdcallcenter.rows.length) {
                if (rowcount == 1) {
                    while (nodecount < grdcallcenter.rows[rowcount].cells[0].childNodes.length) {
                        if (grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT") {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if (grdcallcenter.rows[rowcount].cells.length > 1) {
                    if (grdcallcenter.rows[rowcount].cells[0].childNodes[nodecount].checked == false) {
                        mstrchkbox.checked = false;
                        return;
                    }
                }
                rowcount = rowcount + 1;
            }

            mstrchkbox.checked = true;
        }

        function MultiSelect() {

            var selectcount = 0;
            var selectedrow = 0;

            var grdcallcenter = document.getElementById('<%= this.grdCallCentre.ClientID %>');
            if (grdcallcenter == null)
                return 0;

            if (grdcallcenter.rows == null)
                return 0;

            var arrlength = grdcallcenter.rows.length;
            var count = 1;
            var nodecount = 0;
            while (count < arrlength) {
                if (count == 1) {
                    while (nodecount < grdcallcenter.rows[count].cells[0].childNodes.length) {
                        if (grdcallcenter.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT") {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }

                if (grdcallcenter.rows[count].cells.length <= 1) {
                    count = count + 1;
                    continue;
                }

                if (grdcallcenter.rows[count].cells[0].childNodes[nodecount].checked == true) {
                    selectcount = selectcount + 1;
                    selectedrow = count + 1;

                    if (selectcount > 1) {
                        //                     var btnEdit= document.getElementById('<%= this.btnEdit.ClientID %>');
                        //                     btnEdit.disabled=true;
                        //                     btnEdit.src="../Images/edit-button-d.gif";
                        //hfcallcentreid.value=  "";
                        return selectcount;
                    }
                }
                count = count + 1;
            }

            //         var btnEdit= document.getElementById('<%= this.btnEdit.ClientID %>');
            //          btnEdit.disabled=false;
            //         btnEdit.src="../Images/edit_butt_master.gif"
            if (selectcount == 1) {
            }
            else {
                //hfcallcentreid.value = "";
            }
            return selectcount;
        }

        function ConfirmMultiselect(type) {////debugger
            if (MultiSelect() > 1) {
                var answer = confirm("All the selected Items will be " + type + " ")
                return answer;
            }
            else if (MultiSelect() == 0) {
                alert("Please select atleast one item from the table");
                return false;
            }
            else if ((type == 'Deleted') && (MultiSelect() == 1)) {
                var answer = confirm("The selected item will be deleted")
                return answer;
            }
        }

        function EditCallCentre() {
            var selcount = MultiSelect()
            if (selcount > 1) {
                //              var btnEdit= document.getElementById('<%= this.btnEdit.ClientID %>');
                //               btnEdit.disabled=true;
                //               btnEdit.src="../Images/edit-button-d.gif";
                return false;
            }
            else if (selcount == 0) {
                alert('Please select one item from the table');
                return false;
            }
            return true;
        }

    </script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Call Center</span>
                    <span class="headingright_default">
                        <asp:LinkButton ID="addNewCallCenter" runat="server" Text="+ Add new Call Center"
                            OnClick="addNewCallCenter_Click" /></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>            
            <div class="maindivredmsgbox" id="errordiv" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <%--******************* Buttons Row above Grid ***************** --%>
            <div class="divbuttonsrow">
                <asp:HiddenField runat="server" ID="hfcallcentreid" />
                <%--<div class="pagealerttxtCNT" id="errordiv" runat="server">
                    </div>--%>
                <div class="master_buttons_row">
                    <div class="master_buttons_con" style="visibility: hidden; display: none">
                        <a href="javascript:showdiv()"></a>
                        <asp:ImageButton runat="server" ID="btnEdit" OnClientClick="return EditCallCentre()"
                            ImageUrl="~/App/Images/edit_butt_master.gif" OnClick="btnEdit_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/App/Images/del-button_master.gif"
                            OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
                    </div>
                </div>
            </div>
            <%--**********************************************************--%>
            <div class="main_area_bdrnone">
                <asp:GridView runat="server" ID="grdCallCentre" AutoGenerateColumns="false" CssClass="divgrid_cl"
                    GridLines="None" OnRowDataBound="grdCallCentre_RowDataBound" DataKeyNames="Id">
                    <Columns>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Business Name">
                            <ItemTemplate>
                                <a href="AddCallCentre.aspx?CallCenterID=<%# DataBinder.Eval(Container.DataItem, "Id")%>">
                                    <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Address" HtmlEncode="false" HeaderText="Address"></asp:BoundField>
                        <asp:BoundField DataField="PhoneNumber" HeaderText="Phone"></asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="row2" />
                    <HeaderStyle CssClass="row1" />
                    <AlternatingRowStyle CssClass="row3" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
