<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="Franchisor_Masters_ContractDetails" CodeBehind="ContractDetails.aspx.cs" %>

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
        function hidediv() {
            if (document.getElementById) { // DOM3 = IE5, NS6 
                //document.getElementById('bottom_bdr_master').style.visibility = 'hidden'; 
            }
            else if (document.layers) { // Netscape 4
                //document.hideshow.visibility = 'hidden'; 
            }
            else { // IE 4 
                //document.all.hideshow.style.visibility = 'hidden'; 
            }
            //HandleValidators(false);
        }

        function showdiv() {
            if (document.getElementById) { // DOM3 = IE5, NS6 
                //document.getElementById('bottom_bdr_master').style.visibility = 'visible'; 
            }
            else if (document.layers) { // Netscape 4
                //document.hideshow.visibility = 'visible'; 
            }
            else { // IE 4 
                //document.all.hideshow.style.visibility = 'visible'; 
            }
            //HandleValidators(true);
        }



        function EmptyBoxes() {

            var txtName = document.getElementById(arrcontractelemclientid[2]);
            var txtDescription = document.getElementById(arrcontractelemclientid[3]);
            var ddlstate = document.getElementById(arrcontractelemclientid[4]);
            var txtContract = document.getElementById("<%= this.txtContract.ClientID %>");
            var popuptitle = document.getElementById('<%= this.sppopuptitle.ClientID %>');
            var txtStartDate = document.getElementById("<%=this.txtStartDate.ClientID %>");
            var txtEndDate = document.getElementById("<%=this.txtEndDate.ClientID %>");

            popuptitle.innerHTML = 'Add New Contract';
            txtContract.value = '';
            txtName.value = '';
            txtDescription.value = '';
            ddlstate.options[0].selected = true;
            txtStartDate.value = "";
            txtEndDate.value = "";
        }

        function HandleValidators() {
            ////debugger
            var txtName = document.getElementById('<%= txtName.ClientID %>');

            if (isBlank(txtName, 'Contract Name'))
                return false;

            //            if(trim(txtName.value) == '')
            //            {
            //                document.getElementById('diverrorsummary').innerHTML='<li>Please specify the contract name.</li>';
            //                return false;
            //            }

            var iChars = "!@#$%^&*()+=-[]\\\';,./{}|\":<>?";

            for (var i = 0; i < trim(txtName.value).length; i++) {
                if (iChars.indexOf(trim(txtName.value).charAt(i)) != -1) {
                    document.getElementById('diverrorsummary').innerHTML = '<li>Special characters are not allowed in the contract name. Please remove them and try again.</li>';
                    return false;
                }
            }
            if (!checkDropDown(document.getElementById('<%= this.ddlstate.ClientID %>'), 'State'))
                return false;
            if (isBlank(document.getElementById('<%= this.txtContract.ClientID %>'), 'Contract'))
                return false;

            var txtStartDate = document.getElementById("<%=this.txtStartDate.ClientID %>");
            if (isBlank(txtStartDate, "Start Date"))
            { return false; }
            if (ValidateDate(txtStartDate.value, "Start Date") == false)
            { return false; }
            if (checkDate(txtStartDate.value, "Start Date") == false)
            { return false; }

            var txtEndDate = document.getElementById("<%=this.txtEndDate.ClientID %>");
            if (isBlank(txtEndDate, "End Date"))
            { return false; }
            if (ValidateDate(txtEndDate.value, "End Date") == false)
            { return false; }
            if (checkDate(txtEndDate.value, "End Date") == false)
            { return false; }
        }

        function mastercheckboxclick() {
            if (arrcontractelemclientid == null)
                return;

            var grdContract = document.getElementById(arrcontractelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;

            while (rowcount < grdContract.rows[0].cells[0].childNodes.length) {
                if (grdContract.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT") {
                    mstrchkbox = grdContract.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }

            rowcount = 1;
            var nodecount = 0;

            while (rowcount < grdContract.rows.length) {
                if (rowcount == 1) {
                    while (nodecount < grdContract.rows[rowcount].cells[0].childNodes.length) {
                        if (grdContract.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT") {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }
                if (grdContract.rows[rowcount].cells.length > 1)
                    grdContract.rows[rowcount].cells[0].childNodes[nodecount].checked = mstrchkbox.checked;
                rowcount = rowcount + 1;
            }
            MultiSelect();

        }


        function checkallboxes() {
            if (arrcontractelemclientid == null)
                return;

            var grdContract = document.getElementById(arrcontractelemclientid[0]);
            var rowcount = 0;
            var mstrchkbox;

            while (rowcount < grdContract.rows[0].cells[0].childNodes.length) {
                if (grdContract.rows[0].cells[0].childNodes[rowcount].tagName == "INPUT") {
                    mstrchkbox = grdContract.rows[0].cells[0].childNodes[rowcount];
                    break;
                }
                rowcount = rowcount + 1;
            }

            rowcount = 1;
            MultiSelect();

            var nodecount = 0;
            while (rowcount < (grdContract.rows.length)) {
                if (rowcount == 1) {
                    while (nodecount < grdContract.rows[rowcount].cells[0].childNodes.length) {
                        if (grdContract.rows[rowcount].cells[0].childNodes[nodecount].tagName == "INPUT") {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }

                if (grdContract.rows[rowcount].cells.length > 1) {
                    if (grdContract.rows[rowcount].cells[0].childNodes[nodecount].checked == false) {
                        mstrchkbox.checked = false;
                        return;
                    }
                }
                rowcount = rowcount + 1;
            }

            mstrchkbox.checked = true;

        }

        function ConfirmMultiselect(type) {////debugger
            if (MultiSelect() >= 1 && (type == 'Deleted')) {
                var answer = confirm("Are you sure you want to delete Contract(s) ? ")
                return answer;
            }
            else if (MultiSelect() >= 1 && (type == 'Activate')) {
                answer = confirm("Are you sure you want to Activate Contract(s)? ")
                return answer;
            }
            else if (MultiSelect() >= 1 && (type == 'DeActivate')) {
                answer = confirm("Are you sure you want to Deactivate Contract(s)? ")
                return answer;
            }
            else if (MultiSelect() == 0) {
                alert("Please select atleast one item from the table");
                return false;
            }

        }

        function MultiSelect() {  // //debugger

            if (arrcontractelemclientid == null)
                return;

            var selectcount = 0;
            var selectedrow = 0;
            var txtName = document.getElementById(arrcontractelemclientid[2]);
            var txtDescription = document.getElementById(arrcontractelemclientid[3]);
            var grdContract = document.getElementById(arrcontractelemclientid[0]);
            var hfContractID = document.getElementById(arrcontractelemclientid[5]);
            //            if(arrcheckboxids!= null)
            //            {
            var arrlength = grdContract.rows.length;
            var count = 1;
            var nodecount = 0;
            while (count < arrlength) {
                if (count == 1) {
                    while (nodecount < grdContract.rows[count].cells[0].childNodes.length) {
                        if (grdContract.rows[count].cells[0].childNodes[nodecount].tagName == "INPUT") {
                            break;
                        }
                        nodecount = nodecount + 1;
                    }
                }

                if (grdContract.rows[count].cells.length <= 1) {
                    count = count + 1;
                    continue;
                }
                if (grdContract.rows[count].cells[0].childNodes[nodecount].checked == true) {
                    selectcount = selectcount + 1;
                    selectedrow = count + 1;
                    if (selectcount > 1) {
                        var btnEdit = document.getElementById(arrcontractelemclientid[1]);
                        btnEdit.disabled = true;
                        btnEdit.src = "../../Images/edit-button-d.gif"
                        hidediv();
                        txtName.value = "";
                        txtDescription.value = "";
                        hfContractID.value = "";
                        return selectcount
                    }
                }
                count = count + 1;
            }

            //}
            // //debugger
            btnEdit = document.getElementById(arrcontractelemclientid[1]);
            btnEdit.disabled = false;
            btnEdit.src = "../../Images/edit_butt_master.gif"
            if (selectcount == 1) {
            }
            else {
                txtName.value = "";
                txtDescription.value = "";
                hfContractID.value = "";
            }
            return selectcount;
        }

        function EditContract(aContractID) {
            var aContract = "aContract" + aContractID;
            aContract = document.getElementById(aContract);
            var pNode = aContract.parentNode.parentNode;
            showdiv();
            var sppopuptitle = document.getElementById("<%=this.sppopuptitle.ClientID %>");
            sppopuptitle.innerHTML = "Edit Contract";
            var txtName = document.getElementById('<%= txtName.ClientID %>');
            var txtDescription = document.getElementById('<%= txtDescription.ClientID %>');
            var grdContract = document.getElementById('<%= grdContract.ClientID %>');
            var ddlstate = document.getElementById('<%= ddlstate.ClientID %>');
            var hfContractID = document.getElementById('<%= hfContractID.ClientID %>');
            var txtContract = document.getElementById('<%=this.txtContract.ClientID %>');
            var txtStartDate = document.getElementById("<%=this.txtStartDate.ClientID %>");
            var txtEndDate = document.getElementById("<%=this.txtEndDate.ClientID %>");

            var loopcount = 0;
            var ininput = 0;
            var conpos = 0;
            while (loopcount < pNode.cells[1].childNodes.length) {
                if (pNode.cells[7].childNodes[loopcount].tagName == "INPUT") {
                    conpos = loopcount;
                }
                loopcount = loopcount + 1;

            }
            txtName.value = pNode.cells[1].childNodes[conpos].innerHTML; //innerHTML;

            if (pNode.cells[2].innerHTML == '&nbsp;')
                txtDescription.value = '';
            else
                txtDescription.value = pNode.cells[2].innerHTML;

            var statename = pNode.cells[3].innerHTML;
            loopcount = 0;
            ininput = 0;
            conpos = 0;
            while (loopcount < pNode.cells[7].childNodes.length) {
                if (pNode.cells[7].childNodes[loopcount].tagName == "INPUT") {
                    if (ininput == 0) {
                        conpos = loopcount;
                    }

                }
                loopcount = loopcount + 1;

            }
            txtContract.value = pNode.cells[7].childNodes[conpos].value;
            var statecount = 0;

            while (statecount < ddlstate.options.length) {
                if (ddlstate.options[statecount].innerHTML == statename) {
                    ddlstate.options[statecount].selected = true;
                    break;
                }
                statecount = statecount + 1;
            }
            txtStartDate.value = pNode.cells[4].innerHTML;
            txtEndDate.value = pNode.cells[5].innerHTML;
            hfContractID.value = pNode.rowIndex - 1;
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
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Contract Details</span>
                    <span class="headingright_default">
                        <asp:LinkButton ID="addNewContract" runat="server" Text="+ Add new Contract" OnClientClick="EmptyBoxes();" /></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="divbuttonsrow">
                <div class="master_buttons_row">
                    <div class="master_buttons_con">
                        <a href=""></a>
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="../../Images/del-button_master.gif"
                            OnClientClick="return ConfirmMultiselect('Deleted')" OnClick="btnDelete_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href=""></a>
                        <asp:ImageButton runat="server" ID="btnActivate" ImageUrl="../../Images/activate_butt_master.gif"
                            OnClientClick="return ConfirmMultiselect('Activate')" OnClick="btnActivate_Click" />
                    </div>
                    <div class="master_buttons_con">
                        <a href=""></a>
                        <asp:ImageButton runat="server" ID="btnDeActivate" ImageUrl="../../Images/deactivate_butt_master.gif"
                            OnClientClick="return ConfirmMultiselect('DeActivate')" OnClick="btnDeActivate_Click" />
                    </div>
                </div>
            </div>
            <div class="main_area_bdr_Editdata_fcr">
                <asp:GridView runat="server" ID="grdContract" AutoGenerateColumns="False" DataKeyNames="ContractID"
                    CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdContract_RowDataBound"
                    AllowSorting="True" AllowPaging="True" OnPageIndexChanging="grdContract_PageIndexChanging"
                    OnSorting="grdContract_Sorting">
                    <Columns>
                        <asp:BoundField Visible="False"></asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <input type="checkbox" id="chkMaster1" runat="server" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" id="chkRowChild" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="StateID" Visible="False" HeaderText="ContractID"></asp:BoundField>
                        <%--<asp:BoundField DataField="contractname" HeaderText="Contract" SortExpression="contractname">
                        </asp:BoundField>--%>
                        <asp:TemplateField HeaderText="Contract" SortExpression="contractname">
                            <ItemTemplate>
                                <a href='javascript:void(0);' id='aContract<%#DataBinder.Eval(Container.DataItem, "ContractID")%>'
                                    onclick='EditContract(<%#DataBinder.Eval(Container.DataItem, "ContractID")%>);'>
                                    <%#DataBinder.Eval(Container.DataItem, "contractname")%></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="description" HeaderText="Description"></asp:BoundField>
                        <asp:BoundField DataField="State" HeaderText="State" SortExpression="State"></asp:BoundField>
                        <asp:BoundField DataField="StartDate" HeaderText="StartDate"></asp:BoundField>
                        <asp:BoundField DataField="EndDate" HeaderText="EndDate"></asp:BoundField>
                        <asp:BoundField DataField="active" HeaderText="Status"></asp:BoundField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField runat="server" ID="hfContract" Value='<%# DataBinder.Eval(Container.DataItem, "contract") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                        <span class="orngheadtxt_heading" runat="server" id="sppopuptitle">Add New Contract
                        </span><span style="float: right">
                            <asp:ImageButton runat="server" ID="ibtnclosesymbol" ImageUrl="~/App/Images/close-button-symbol.gif" />
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="border-top: solid 1px #ccc; padding-top: 5px;">
                        <span style="float: right;"><span class="graysmalltxt_default"><span class="reqiredmark">
                            <sup>*</sup> </span>Mandatory Fields</span> </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletext1b_default">Contract Name:<span class="reqiredmark"><sup>*</sup>
                        </span></span><span class="inputfldnowidth_default">
                            <asp:TextBox runat="server" ID="txtName" CssClass="inputf_def" Width="180px"> </asp:TextBox>
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletext1b_default">State:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfldnowidth_default">
                            <asp:DropDownList runat="server" ID="ddlstate" CssClass="inputf_def" Width="185px">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletext1b_default">Contract:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputfldnowidth_default">
                            <asp:TextBox runat="server" ID="txtContract" TextMode="MultiLine" Rows="3" CssClass="inputf_def"
                                Width="180px"> </asp:TextBox>
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletext1b_default">Start Date:<span class="reqiredmark"><sup>*</sup>
                        </span></span><span style="float: left"><span style="float: left; width: 72px;">
                            <asp:TextBox ID="txtStartDate" runat="server" Width="70px"></asp:TextBox>
                            <span style="font-size: 7pt; padding: 0px; margin: 0px;">mm/dd/yyyy</span> </span>
                            <span class="calendarcntrl_editp">
                                <asp:ImageButton ID="imgCalendarStartDate" runat="server" CssClass="" ImageUrl="~/App/Images/calendar-icon.gif"
                                    AlternateText="Click to show calendar" />
                            </span>
                            <ajaxToolkit:CalendarExtender ID="calStartDate" runat="server" Animated="true" Format="MM/dd/yyyy"
                                PopupButtonID="imgCalendarStartDate" TargetControlID="txtStartDate">
                            </ajaxToolkit:CalendarExtender>
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletext1b_default">End Date:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span style="float: left"><span style="float: left; width: 72px;">
                            <asp:TextBox ID="txtEndDate" runat="server" Width="70px"></asp:TextBox>
                            <span style="font-size: 7pt; padding: 0px; margin: 0px;">mm/dd/yyyy</span> </span>
                            <span class="calendarcntrl_editp">
                                <asp:ImageButton ID="imgCalendarEndDate" runat="server" CssClass="" ImageUrl="~/App/Images/calendar-icon.gif"
                                    AlternateText="Click to show calendar" />
                            </span>
                            <ajaxToolkit:CalendarExtender ID="calEndDate" runat="server" Animated="true" Format="MM/dd/yyyy"
                                PopupButtonID="imgCalendarEndDate" TargetControlID="txtEndDate">
                            </ajaxToolkit:CalendarExtender>
                        </span>
                    </p>
                    <p class="innermain_pop_l" style="margin-top: 5px">
                        <span class="titletext1b_default">Description:</span> <span class="inputfldnowidth_default">
                            <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" Rows="3" CssClass="inputf_def"
                                Width="180px"> </asp:TextBox>
                        </span>
                    </p>
                    <asp:HiddenField ID="hfContractID" runat="server" />
                    <p class="innermain_pop_l" style="margin-top: 5px;">
                        <span class="buttoncon_default">
                            <asp:ImageButton runat="server" ID="btnSave" ImageUrl="../../Images/save-button.gif"
                                OnClick="btnSave_Click" OnClientClick="return HandleValidators();" />
                        </span><span class="buttoncon_default">
                            <asp:ImageButton runat="server" ID="btnCancel" ImageUrl="../../Images/cancel-button.gif"
                                Width="57" Height="25" OnClientClick="$find('mdlPopup').hide(); return false;"
                                OnClick="btnCancel_Click" />
                        </span>
                    </p>
                </div>
            </div>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="addNewContract"
        PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol"
        BehaviorID="mdlPopup" />
</asp:Content>
