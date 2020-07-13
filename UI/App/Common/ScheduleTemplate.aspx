<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Common_ScheduleTemplate" Title="Untitled Page"
    CodeBehind="ScheduleTemplate.aspx.cs" %>

<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true" IncludeJQueryMaskInput="true" />
    <style type="text/css">
        .wrapper_pop
        {
            float: left;
            width: 302px;
            padding: 10px;
            background-color: #f5f5f5;
        }
        .wrapperin_pop
        {
            float: left;
            width: 278px;
            border: solid 2px #4888AB;
            padding: 10px;
            background-color: #fff;
        }
        .innermain_pop
        {
            float: left;
            width: 278px;
        }
        .prenextband
        {
            float: left;
            width: 266px;
            border: solid 1px #CCCCCC;
            background-color: #DFE7ED;
            padding: 4px 5px 4px 5px;
        }
        .innermain_1_pop
        {
            float: left;
            width: 263px;
            padding-top: 5px;
        }
        .calright
        {
            float: right;
        }
    </style>
    <style type="text/css">
        .maincontentrow_sne
        {
            float: left;
            width: 743px;
            padding: 0px 3px 3px 3px;
        }
        .titletxtbld_sne
        {
            float: left;
            font-weight: bold;
            width: 100px;
            padding: 0px 5px 0px 5px;
        }
        .inputconnowidth_sne
        {
            float: left;
            width: auto;
        }
        .inputfield_ccrep
        {
            border: 1px solid #769FBF;
        }
        .titletxtbld_sne
        {
            float: left;
            font-weight: bold;
            width: 100px;
            padding: 0px 5px 0px 5px;
        }
        .inputfield_ccrep
        {
            border: 1px solid #769FBF;
        }
        .chkboxlistrow_sne
        {
            float: left;
            width: 610px;
        }
        .radiotxtoption_sne
        {
            float: left;
            width: 200px;
            padding-right: 100;
        }
        .chkboxlist_sne
        {
            float: left;
            width: 610px;
            border: 1px solid #769FBF;
            height: 100px;
            overflow-y: scroll;
        }
        .chklistboxfranchisee_sne
        {
            width: 590px;
            border: 0;
            padding: 5px;
            float: left;
        }
        .halfcontentrow_sne
        {
            float: left;
            width: 280px;
            padding: 0px 3px 3px 3px;
        }
        .instmainbox_sne
        {
            float: left;
            width: 425px;
            padding: 8px;
            background-color: #EFF8F7;
        }
        .mainrowinstbox_sne
        {
            float: left;
            width: 400px;
        }
        .instbox_sne
        {
            float: left;
            width: 425px;
        }
        .headbg2_box_amv
        {
            float: left;
            width: 753px;
            padding-top: 5px;
            padding-bottom: 10px;
        }
    </style>
    <script language="javascript" type="text/javascript">


        $(document).ready(function () {
            $.mask.definitions['~'] = '[AP]';
            $('.mask-time').mask('99:99~M');

            $('#pnlmodalpopup').dialog({ autoOpen: false, width: 300, modal: true, title: 'Generate Time Slots', resizable: false });
        });



        function openDialogue() {
            $('#pnlmodalpopup').dialog("open");
        }

        function fillappointment() {
            var txttimeslots = document.getElementById('<%= this.txttimeslots.ClientID %>');
            var valstart = $('#ddlHHStartTime').val() + ":" + $('#<%=ddlMMStartTime.ClientID %>').val() + " " + $('#ddlAMPMStartTime').val();
            var valend = $('#ddlHHEndTime').val() + ":" + $('#<%=ddlMMEndTime.ClientID %>').val() + " " + $('#ddlAMPMEndTime').val();
            var valduration = Number(document.getElementById('<%= this.txtduration.ClientID %>').value);
            

            if (!CheckTimeExceedEndTime(valend, valstart)) {
                alert("End Time can not be less than start time");
                return false;
            }

            if (isBlank(document.getElementById('<%= this.txtduration.ClientID %>'), 'Duration'))
                return false;

            txttimeslots.value = '';
            txttimeslots.value = valstart;
            var vallastcalculated = valstart;
            while (true) {
                var hrstart = Number(GetHours(vallastcalculated));
                var minstart = Number(GetMinutes(vallastcalculated));
                var ampmstart = GetAMPM(vallastcalculated);


                var mincalculated = minstart + valduration;
                var hrcalculated = hrstart;
                var ampmcalculated = ampmstart;

                if (mincalculated >= 60) {
                    while (mincalculated >= 60) {
                        hrcalculated = hrcalculated + 1;
                        mincalculated = mincalculated - 60;
                    }
                }

                if (hrcalculated >= 12)
                    ampmcalculated = 'PM';

                if (hrcalculated > 12) {
                    hrcalculated = hrcalculated - 12;
                }


                if (hrcalculated < 10)
                    hrcalculated = '0' + hrcalculated;

                if (mincalculated < 10)
                    mincalculated = '0' + mincalculated;

                var valcalculated = hrcalculated + ':' + mincalculated + ' ' + ampmcalculated;
                if (CheckTimeExceedEndTime(valcalculated, valend) == true)
                    break;

                vallastcalculated = valcalculated;
                txttimeslots.value = txttimeslots.value + '\n' + valcalculated;
            }

            $('#pnlmodalpopup').dialog("close");    
            return false;
        }

        function CheckTimeExceedEndTime(valcalculated, valendtime) {
            //debugger
            if (GetAMPM(valcalculated) == 'PM' && GetAMPM(valendtime) == 'AM')
                return true;

            if (GetAMPM(valcalculated) == GetAMPM(valendtime)) {
                if (Number(GetHours(valcalculated)) != 12 && (Number(GetHours(valcalculated)) > Number(GetHours(valendtime))))
                    return true;

                if (Number(GetHours(valendtime)) == 12 && (Number(GetHours(valcalculated)) < Number(GetHours(valendtime))))
                    return true;

                if (Number(GetHours(valcalculated)) == Number(GetHours(valendtime))) {
                    if (Number(GetMinutes(valcalculated)) >= Number(GetMinutes(valendtime)))
                        return true;
                }

            }
            return false;
        }

        function GetAMPM(valTime) {
            valTime = trim(valTime);

            var returnval = valTime.substring(valTime.length - 2, valTime.length);
            if (returnval == 'AM' || returnval == 'PM' || returnval == 'am' || returnval == 'pm')
                return returnval;

            return null;
        }

        function GetHours(valTime) {
            valTime = trim(valTime);
            var returnval = valTime.substring(0, valTime.indexOf(":"));

            return returnval;
        }

        function GetMinutes(valTime) {
            valTime = trim(valTime);
            var returnval = valTime.substring(valTime.indexOf(":") + 1, valTime.indexOf(":") + 3);

            return returnval;
        }


        function HandleDivHide(valuediv) {
            document.getElementById('divlistfranchisee').style.display = valuediv;
        }

        function HandleValidations() {
            //debugger
            if (isBlank(document.getElementById('<%= this.txtschedulename.ClientID %>'), 'Template Name'))
                return false;

            if (isBlank(document.getElementById('<%= this.txttimeslots.ClientID %>'), 'Time Slots'))
                return false;

            if (CheckValidTime() == false)
                return false;

            var listcheckfranchsiee = document.getElementById('<%= this.chklstFranchisee.ClientID %>');
            if (listcheckfranchsiee == null)
                return true;

            if (document.getElementById('<%= this.rbtAllFranchisee.ClientID %>').checked == true)
                return true;

            var rowcount = 0;
            var childnode1 = 0;
            var childnode2 = 0;
            while (rowcount < listcheckfranchsiee.rows.length) {
                if (rowcount == 0) {
                    while (childnode1 < listcheckfranchsiee.rows[rowcount].cells[0].childNodes.length) {
                        if (listcheckfranchsiee.rows[rowcount].cells[0].childNodes[childnode1].tagName == "INPUT")
                            break;
                        childnode1 = childnode1 + 1;
                    }
                }

                if (listcheckfranchsiee.rows[rowcount].cells[0].childNodes[childnode1].checked == true)
                    return true;

                if (listcheckfranchsiee.rows[rowcount].cells.length > 1) {
                    if (listcheckfranchsiee.rows[rowcount].cells[1].childNodes[childnode1].checked == true)
                        return true;
                }


                rowcount = rowcount + 1;
            }

            alert('Select atleast on Franchisee, or make it global by selecting All Franchisee option.');
            return false;
        }



        function CheckValidTime() {
            var timeslotstring = document.getElementById('<%= this.txttimeslots.ClientID %>').value;
            var timeslotarray = timeslotstring.split("\n");

            var arraycount = 0;
            while (arraycount < timeslotarray.length) {
                if (validatetime(trim(timeslotarray[arraycount])) == false)
                    return false;
                arraycount = arraycount + 1;
            }
            return true;
        }


        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }


        function DisplaySuccessMessage(bolEdit) {
            //debugger

            if (bolEdit == true) {
                alert('Schedule Template saved succesfully.');
            }
            else {
                alert('Schedule Template edited succesfully.');
            }

            var currentpathname = window.location.pathname.toLowerCase();
            window.location = currentpathname.replace("scheduletemplate", "viewtemplate");

        }
        
        
    
    </script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Technician Register Customer</span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="maincontentrow_sne">
                    <div>
                        <img src="../Images/CCRep/specer.gif" width="740" height="4px" /></div>
                    <p class="maincontentrow_sne">
                        <span class="titletxtbld_sne">Schedule Name:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="inputconnowidth_sne">
                            <asp:TextBox ID="txtschedulename" runat="server" CssClass="inputfield_ccrep" Width="300px"></asp:TextBox>
                        </span><span class="titletxtbld_sne" style="float: right">Is Active?
                            <asp:CheckBox ID="chkisactive" runat="server" /></span>
                    </p>
                    <p class="maincontentrow_sne">
                        <span class="titletxtbld_sne">Description:</span> <span class="inputconnowidth_sne">
                            <asp:TextBox ID="txtdescription" TextMode="MultiLine" Rows="3" runat="server" CssClass="inputfield_ccrep"
                                Width="605px"></asp:TextBox>
                        </span>
                    </p>
                    <div>
                        <img src="../Images/CCRep/specer.gif" width="740" height="1px" /></div>
                    <p runat="server" id="pFranchiseeList" class="maincontentrow_sne" style="margin-bottom: 5px;">
                        <span class="titletxtbld_sne">Franchisee:<span class="reqiredmark"><sup>*</sup> </span>
                        </span><span class="chkboxlistrow_sne"><span class="chkboxlistrow_sne"><span class="radiotxtoption_sne">
                            <asp:RadioButton onClick="HandleDivHide('none');" runat="server" ID="rbtAllFranchisee"
                                Checked="true" GroupName="Franchisee" Text="All Franchisees" />
                        </span><span class="radiotxtoption_sne">
                            <asp:RadioButton onClick="HandleDivHide('block');" ID="rbtSpecFranch" runat="server"
                                GroupName="Franchisee" Text="Specific Franchisee" />
                        </span></span><span style="display: none;" id="divlistfranchisee" class="chkboxlist_sne">
                            <asp:CheckBoxList runat="server" ID="chklstFranchisee" CssClass="chklistboxfranchisee_sne"
                                RepeatColumns="2" RepeatDirection="Horizontal">
                            </asp:CheckBoxList>
                        </span></span>
                    </p>
                    <div>
                        <img src="../Images/CCRep/specer.gif" width="740" height="1px" /></div>
                    <p class="halfcontentrow_sne">
                        <span class="titletxtbld_sne">Time Slots:<span class="reqiredmark"><sup>*</sup> </span>
                            <span style="font-size: 11px; font-weight: normal"><a href="#" runat="server" id="lnkGenerateApp"
                                style="font-size: 11px" onclick="openDialogue();">Generate Appointments</a></span>
                        </span><span class="inputconnowidth_sne">
                            <asp:TextBox ID="txttimeslots" TextMode="MultiLine" Rows="10" runat="server" CssClass="inputfield_ccrep"
                                Width="150px"></asp:TextBox></span>
                    </p>
                    <div class="instmainbox_sne">
                        <p class="mainrowinstbox_sne">
                            <span class="headinginstbox_sne">Instructions:</span>
                        </p>
                        <div class="instbox_sne">
                            <div>
                                <ol>
                                    <li>Please enter one slot per line in the text area on the left.</li>
                                    <li>Only am and pm format times are allowed, eg. 9:15 AM, 3:20 PM </li>
                                    <li>If you want to accept more than one appointment at the same time please enter the
                                        time slot twice, one below the other. E.g. 9:15 AM and then again 9:15 AM in the
                                        next line.</li>
                                    <li>When an event is created, these time slots will be used to open appointment times
                                        for the customer to register specified event.</li>
                                </ol>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="headbg2_box_amv">
                <div class="buttoncon_default">
                    <asp:ImageButton ID="btnSave" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                        OnClientClick="return HandleValidations();" OnClick="btnSave_Click" /></div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="btnCancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="btnCancel_Click" /></div>
            </div>
        </div>
    </div>
    <div id="pnlmodalpopup" style="display: none;">
        <p class="innermain_pop" style="border-top: solid 1px #ccc;">
            <span style="float: right; margin-top: 3px;"><span class="graysmalltxt_default"><span
                class="reqiredmark"><sup>*</sup> </span>Mandatory Fields</span> </span>
        </p>
        <p class="innermain_pop" style="margin-top: 2px;">
            <span class="titletextsmall_default" style="width:80px">Start Time:<span class="reqiredmark"><sup>*</sup>
            </span></span>
            <span class="inputfldnowidth_default">
                <select id="ddlHHStartTime" style="width: 50px; height:25px;">
                    <option value="01">01</option>
	                <option value="02">02</option>
	                <option value="03">03</option>
	                <option value="04">04</option>
	                <option value="05">05</option>
	                <option value="06">06</option>
	                <option value="07">07</option>
	                <option value="08">08</option>
	                <option value="09">09</option>
	                <option value="10">10</option>
	                <option value="11">11</option>
	                <option value="12">12</option>
                </select>                
                <asp:DropDownList ID="ddlMMStartTime" runat="server" Width="50px" Height="25px">
                </asp:DropDownList>
                <select id="ddlAMPMStartTime" style="width: 50px; height:25px;">
	                <option value="AM">AM</option>
	                <option value="PM">PM</option>
                </select>
            </span>
        </p>
        <p class="innermain_pop" style="margin-top: 2px;">
            <span class="titletextsmall_default">End Time:<span class="reqiredmark"><sup>*</sup></span></span>
            <span class="inputfldnowidth_default">
                <select id="ddlHHEndTime" style="width: 50px; height:25px;">
	                <option value="01">01</option>
	                <option value="02">02</option>
	                <option value="03">03</option>
	                <option value="04">04</option>
	                <option value="05">05</option>
	                <option value="06">06</option>
	                <option value="07">07</option>
	                <option value="08">08</option>
	                <option value="09">09</option>
	                <option value="10">10</option>
	                <option value="11">11</option>
	                <option value="12">12</option>
                </select>
                <asp:DropDownList ID="ddlMMEndTime" runat="server" Width="50px" Height="25px">
                </asp:DropDownList>
                <select id="ddlAMPMEndTime" style="width: 50px; height:25px;">
	                <option value="AM">AM</option>
	                <option value="PM">PM</option>
                </select>
            </span>
        </p>
        <p class="innermain_pop" style="margin-top: 2px;">
            <span class="titletextsmall_default">Duration:<span class="reqiredmark"><sup>*</sup>
            </span>&nbsp;&nbsp;&nbsp;</span> <span class="inputfldnowidth_default">
                <asp:TextBox ID="txtduration" runat="server" CssClass="inputf_def" Width="60px"></asp:TextBox>&nbsp;(in
                mins)</span>
        </p>
        <p class="innermain_pop">
            <span class="calright">
                <asp:ImageButton ID="ibtnGenerate" OnClientClick="return fillappointment();" runat="server"
                    ImageUrl="~/App/Images/generate-btn.gif" /></span>
        </p>
    </div>
</asp:Content>
