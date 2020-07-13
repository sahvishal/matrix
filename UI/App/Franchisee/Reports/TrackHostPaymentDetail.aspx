<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    CodeBehind="TrackHostPaymentDetail.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.Reports.TrackHostPaymentDetail"
    Title="Track Host Payments" EnableEventValidation="false" %>
<%@ Import Namespace="Falcon.App.Core.Sales.Enum" %>
<%@ Register Src="~/App/UCCommon/ListPager.ascx" TagName="Pager" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="Message" TagPrefix="uc" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagPrefix="ToolKit" TagName="JQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ToolKit:JQuery ID="JQuryToolkit" runat="server" IncludeJQueryUI="true" IncudeJQueryJTip="true" />

      <script type="text/javascript">
    function ValidateFilter()
    {
        var PaymentDueDateFrom = document.getElementById("<%=this.PaymentDueDateFrom.ClientID %>");
        var PaymentDueDateTo = document.getElementById("<%=this.PaymentDueDateTo.ClientID %>");
        
        if (PaymentDueDateFrom.value != "")
        {
            if (!ValidateDate(PaymentDueDateFrom.value, 'Start Due Date '))
                        return false;
        }
        if (PaymentDueDateTo.value != "")
        {
            if (!ValidateDate(PaymentDueDateTo.value, 'End Due Date '))
                        return false;
        }
        if ( (PaymentDueDateFrom.value != "") && (PaymentDueDateTo.value != ""))
        {
            if(!CompareTwoDates1(PaymentDueDateFrom.value, PaymentDueDateTo.value))
            {
                    alert("End Due Date should be greater or equals to Start Due Date");
                    return false;
            }
        }
        return true;    
    }
        $(document).ready(function() {

            $('.amount-text').numeric({ allow: "." });
            $('.txtAmount').numeric({ allow: "." });
            
            var currentDate = new Date();
            currentDate = new Date(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate() + 1);
            $(".date-picker-from").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker-to").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $(".date-picker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: (2008 + ":" + currentDate.getFullYear() + 10),
                defaultDate: currentDate,
                maxDate: new Date("01/01/2020"),
                minDate: new Date(2008, currentDate.getMonth(), currentDate.getDate() + 10)
            });

            $('.auto-search-event').numeric();
        });
        function HideNotesDialog()
        {
            $('#HostPaymentNotes').dialog('close');
            return false;
        }
        var paymentStatus = '';
        var paymentStatusText=''
        var paymentStatusCurrent='';
        var hostPaymentId = '';
        var hostId='';
        var amount = '';
        var paymentDate='';
        var paymentMode='';
        var organizationRoleUserId='';
        var currentIndex = '';
        var paymentOrDeposit ='';
        var taxIdNumber='';
        var depositType='';
        var lastModifiedDate = '';
        function UpdateNotes(currentButton)
        {
            //debugger;
            paymentStatus = $(currentButton).parents('tr').find('select option:selected').val();
            paymentStatusText = $(currentButton).parents('tr').find('select option:selected').text();
            paymentStatusCurrent = paymentmode= $(currentButton).parents('tr').find('.currentPaymentStatus').text();
            hostPaymentId = $(currentButton).parents('tr').find('.host-payment-id').html();
            hostId = $(currentButton).parents('tr').find('.host-id').html();
            taxIdNumber = $(currentButton).parents('tr').find('.host-taxIdNumber').html();            
            amount = $(currentButton).parents('tr').find('.amount-text').text();
            paymentOrDeposit = $(currentButton).parents('tr').find('.paymentDeposit').text();
            depositType = $(currentButton).parents('tr').find('.DepositType').html();
            currentIndex = $(currentButton).parents('tr');
            $('#HostPaymentNotes').find('.txtAmount').val(amount);
            $('#HostPaymentNotes').find('.taxIdNumber').val(taxIdNumber);
            
            if (paymentStatusCurrent == '<%= HostPaymentStatus.Paid%>' && paymentStatus == '<%= (long) HostPaymentStatus.Pending%>')
            {
                var answer = confirm  ("Are you sure to change payment status from Paid to Pending?\n Click on OK wil result in loosing the last payment transaction record.");
                if (!answer) return false;
            }
            else if (paymentStatusCurrent == '<%= HostPaymentStatus.Refunded%>' && paymentStatus == '<%= (long) HostPaymentStatus.Paid%>')
            {
                var answer = confirm  ("Are you sure to change payment status from Refunded to Paid?\n Click on OK wil result in loosing the last payment transaction record.");
                if (!answer) return false;
            }
            
            // make taxIdNumber as required
            var dialogTitle='Payment Record Details';
            if (paymentStatus== '<%= (long) HostPaymentStatus.Paid %>')
            {
                $('#HostPaymentNotes').find('.divTaxNumber').show();
                dialogTitle = 'Payment Record Details';
                $('#HostPaymentNotes').find('.date-label').html('Date Paid:<SPAN class=reqiredmark><SUP>*</SUP></SPAN>');
                //$('#HostPaymentNotes').find('.txtAmount').attr('disabled','disabled');
            }
            else if (paymentStatus == '<%= (long) HostPaymentStatus.Refunded %>')
            {
                $('#HostPaymentNotes').find('.divTaxNumber').hide();
                dialogTitle = 'Refund Record Details';
                $('#HostPaymentNotes').find('.date-label').html('Date Refund:<SPAN class=reqiredmark><SUP>*</SUP></SPAN>');
                $('#HostPaymentNotes').find('.taxIdNumber').val('');
            }
            else {$('#HostPaymentNotes').find('.divTaxNumber').hide();}
            
            $('#HostPaymentNotes').find('.datePaid').val('');
            $('#HostPaymentNotes').find('.notes-text').val('');
            if (paymentStatus == '<%= (long) HostPaymentStatus.Paid%>' || paymentStatus == '<%= (long) HostPaymentStatus.Refunded%>')
            {
                $('#HostPaymentNotes').dialog({ width: 360, height: 290, autoOpen: false, resizable: false, draggable: false, overflow: "visible" });
                $('#HostPaymentNotes').data('title.dialog',dialogTitle);
                $('#HostPaymentNotes').dialog('open');
            }
            else 
            {
                // save directly the status.
                UpdateStatusAndNotes();
            }
            return false;
        }
        function ValidateStatusAndNotes()
        {
            
            // If Pending or Receivable
            if (paymentStatus == '<%= (long) HostPaymentStatus.Pending%>' || paymentStatus == '<%= (long) HostPaymentStatus.Refunded%>')
            return true;
            
            if (isBlank(document.getElementById("<%=this._txtAmount.ClientID %>"), "Payment/Deposit amount"))
            { return false; }
            else if($('#' + '<%=_paymentMode.ClientID %>').val()<=0 )
            {
                alert('Payment/Deposit Method can not left blank');
                document.getElementById("<%=_paymentMode.ClientID %>").focus();
                return false;
            }
            else if (isBlank(document.getElementById("<%=this._datePaid.ClientID %>"), "Payment date "))
            { return false; }
            else if (isBlank(document.getElementById("<%=this._paymentNotes.ClientID %>"), "Notes "))
            { return false; }
            else if (!ValidateDate(document.getElementById("<%=this._datePaid.ClientID %>").value, 'Payment date '))
            return false;
            else if (!CompareDateWithCurrentDate1(document.getElementById("<%=this._datePaid.ClientID %>").value))
            {
                alert('Payment date should be less than or equals to current date.');
                document.getElementById("<%=_datePaid.ClientID %>").focus();
                return false;
            }
            // TODO:While refunding deposit which is adjusted to cost of event, 
            else return true;
        }
        function UpdateStatusAndNotes()
        {
            if (ValidateStatusAndNotes()==false) return false;
            
            var successFunction = function(result)
            {
                if (result.d)
                {
                    $('#HostPaymentNotes').dialog('close');                    
                    BindPaymentDropDown(paymentStatus);
                    currentIndex.find('.currentPaymentStatus').text(paymentStatusText);
                    currentIndex.find('.Last-Modifed-Date').text(paymentDate);
                    if (paymentStatus == '<%= (long) HostPaymentStatus.Pending%>')
                    {
                        currentIndex.find('.currentPrintButton').hide();
                    }
                    else
                    {
                        currentIndex.find('.currentPrintButton').show();
                    }
                    alert('Payment status has been updated.');                    
                    
                    // Disable row
                    //if (paymentStatus == '<%= (long) HostPaymentStatus.Refunded %>')
                    //{
                    //    currentIndex.attr('disabled','disabled');
                    //    currentIndex.find('.paymentstatus').attr('disabled','disabled');
                    //    currentIndex.find('.updaterecord').attr('disabled','disabled');
                    //}
                }
                else
                {
                    alert('Due to some DB related error the Payment Status has not been updated');
                }
            }
            
            var notes = $('#HostPaymentNotes').find('.notes-text').val();
            var amount = $('#HostPaymentNotes').find('.txtAmount').val();
            paymentDate = $('#HostPaymentNotes').find('.datePaid').val();
            organizationRoleUserId = document.getElementById("<%=this._organizationRoleUserId.ClientID %>").value;
            paymentMode = $('#' + '<%=_paymentMode.ClientID %>').val();
            if (paymentMode=='Check') paymentMode = '<%= (long) HostPaymentType.Check %>';
            else if (paymentMode=='CreditCard') paymentMode= '<%= (long) HostPaymentType.CreditCard%>';
            
            if ($('#HostPaymentNotes').find('.taxIdNumber').val()!='')
            {
                taxIdNumber = $('#HostPaymentNotes').find('.taxIdNumber').val();
            }
            var isDeposit=false;
            if(paymentOrDeposit.trim() == 'Deposit') isDeposit=true;
            
            var parameter = "{'hostPaymentId':'" + hostPaymentId + "'";
            parameter += ",'amount':'" + amount + "'";
            parameter += ",'hostPaymentStatus':'" + paymentStatus + "'";
            parameter += ",'hostPaymentType':'" + paymentMode + "'";
            parameter += ",'notes':'" + notes + "'";
            parameter += ",'paymentDate':'" + paymentDate + "'";
            parameter += ",'organizationRoleUserId':'" + organizationRoleUserId + "'";
            parameter += ",'hostId':'" + hostId + "'";
            parameter += ",'taxIdNumber':'" + taxIdNumber + "'";
            parameter += ",'isDeposit':'" + isDeposit + "'}";
            
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/HostPaymentController.asmx/UpdateHostPaymentStatusAndNotes")%>';
            InvokeService(messageUrl, parameter, successFunction);
        }
        

        function InvokeService(messageUrl, parameter, successFunction) {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function(result) {
                    successFunction(result);
                },
                error: function(a, b, c) {

                    alert("Oops! something went wrong.");
                }
            });
        }
        
        function BindPaymentDropDown(_paymentStatus)
        {
            //debugger;
            var isDeposit=false;
            if(paymentOrDeposit.trim() == 'Deposit') isDeposit=true;
            if (isDeposit && depositType == '<%= DepositType.Refunded.ToString() %>' && _paymentStatus == '<%= (long) HostPaymentStatus.Paid%>')
            {
                _paymentStatus ='<%= (long) HostPaymentStatus.Receivable %>';
                paymentStatusText = '<%= HostPaymentStatus.Receivable.ToString() %>';
            }

            var _paymentStatusDropDown =currentIndex.find('.paymentstatus');
            $(_paymentStatusDropDown).find('option').remove();
            
            if (_paymentStatus == '<%= (long) HostPaymentStatus.Pending%>')
            {
                $(_paymentStatusDropDown).append($('<option></option>').val('<%= (long) HostPaymentStatus.Paid %>').html('<%= HostPaymentStatus.Paid.ToString() %>'));
            }
            else if (_paymentStatus == '<%= (long) HostPaymentStatus.Paid%>')
            {
                $(_paymentStatusDropDown).append($('<option></option>').val('<%= (long) HostPaymentStatus.Pending%>').html('<%= HostPaymentStatus.Pending.ToString() %>'));
                $(_paymentStatusDropDown).append($('<option></option>').val('<%= (long) HostPaymentStatus.Refunded%>').html('<%= HostPaymentStatus.Refunded.ToString() %>'));
            }
            else if (_paymentStatus == '<%= (long) HostPaymentStatus.Receivable%>')
            $(_paymentStatusDropDown).append($('<option></option>').val('<%= (long) HostPaymentStatus.Refunded%>').html('<%= HostPaymentStatus.Refunded.ToString() %>'));
            else if (_paymentStatus == '<%= (long) HostPaymentStatus.Refunded%>')
            $(_paymentStatusDropDown).append($('<option></option>').val('<%= (long) HostPaymentStatus.Paid %>').html('<%= HostPaymentStatus.Paid.ToString() %>'));           
        }
    </script>
    
    <script type="text/javascript" language="javascript">
        function popupmenu(eventId) {
            //debugger
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=yes,menubar=no,width=650,height=650";
            confirmWin = window.open('/App/Franchisee/Reports/RoomRentPrintReciept.aspx?EventId=' + eventId, 'theconfirmWin', winOpts);
        }
    </script>

    <div class="wrapper_ecl">
        <h1 class="left">
            Track Host Payments</h1>
		<div class="lgnd_rgt">
			<img src="/App/Images/legend-eventstatus.gif" alt="Event Status" title="Event Status" />
		</div>
        <uc:Message ID="MessageBox" runat="server" />
        <div class="chklistdiv">
            <div class="boxrow">
                <label>
                    Event ID:</label>
                <asp:TextBox ID="EventId" runat="server" Width="80px" CssClass="mrgnrgt auto-search-event"
                    MaxLength="12" />
                <label>
                    Due Date:</label>
                <asp:TextBox ID="PaymentDueDateFrom" runat="server" Width="80px" CssClass="date-picker-from"
                    MaxLength="12" />&nbsp;-To-&nbsp;<asp:TextBox ID="PaymentDueDateTo" runat="server"
                        Width="80px" CssClass="mrgnrgt date-picker-to" MaxLength="12" />
                <label>
                    Status:</label>
                <asp:DropDownList ID="PaymentStatusSearch" runat="server" AppendDataBoundItems="true"
                    Height="22px" EnableViewState="true" CssClass="mrgnrgt" />
                <label>
                    Type:</label>
                <asp:DropDownList ID="PaymentTypeSearch" runat="server" AppendDataBoundItems="true"
                    Height="22px" CssClass="mrgnrgt" Width="90px" EnableViewState="true" />
                <asp:Button ID="resetSearch" Text="Clear" CssClass="button clear-button" runat="server"
                    OnClick="resetSearch_Click" />
                <asp:Button ID="searchRecord" Text="Filter" CssClass="button" runat="server" OnClick="searchRecord_Click" OnClientClick="return ValidateFilter();" />
            </div>
        </div>
        <div class="divgrd_thp" style="overflow-x:auto">
            <uc:Pager ID="PaymentDetailPagerTop" runat="server" OnPageIndexChanged="PaymentDetailPagerTop_PageIndexChanged" />
            <asp:GridView ID="PaymentDetailsGrid" runat="server" GridLines="none" AutoGenerateColumns="false"
                CssClass="grd_tsd select-table" OnRowDataBound="PaymentDetailsGrid_RowDataBound" Width="950px">
                <Columns>
                    <asp:TemplateField HeaderText="Event">
                        <ItemTemplate>
                            <span class="host-payment-id" runat="server" id="EventSpan" style="display: none">
                                <%#DataBinder.Eval(Container.DataItem,"Id")%></span>
                             <span class="host-id" style="display: none"><%#DataBinder.Eval(Container.DataItem,"HostId")%></span>
                             <span class="host-taxIdNumber" style="display: none"><%#DataBinder.Eval(Container.DataItem, "TaxIdNumber")%></span>
                             <span class="DepositType" style="display: none"><%#DataBinder.Eval(Container.DataItem, "DepositApplicablityMode")%></span>
                             <span class="bold">[<a href="#"
                                    id="EventWizardAnchor" runat="server"><%# DataBinder.Eval(Container.DataItem,"EventId")%></a>]</span>
                            <span>
                                <%#DataBinder.Eval(Container.DataItem,"Name")%>
                                <br />
                                <span id="eventAddress" runat="server"></span></span><br />
                                <span id="_eventStatus" runat="server"></span></span><br />
                                <span id="_paymentStatus" runat="server"></span></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Payable to">
                        <ItemTemplate>
                            <asp:Literal ID="hostPaybaleTo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"PayableTo")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Attention of">
                        <ItemTemplate>
                            <asp:Literal ID="hostAttentionOf" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MailingAttentionOf")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Deliver to">
                        <ItemTemplate>
                            <asp:Literal ID="hostDeliverTo" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"MailingOrganizationName")%>' />
                            <br />
                            <span id="deliverToAddress" runat="server"></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <span class="left" style="width:60px">$
                                <span ID="_amount" runat="server" class="amount-text"/>                                
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Due Date">
                        <ItemTemplate>
                            <asp:Literal ID="dueDate" runat="server" />
                            <br /><span>Event Date:<br /><%#Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "EventDate")).ToString("MM/dd/yyyy")%></span>
                            <br /><span id="_eventDateIcon" runat="server"></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <span id="paymentType" runat="server" class="paymentDeposit"></span>
                            <br />Last Modified Date:<br /><span id="_lastModifiedDate" runat="server" class="Last-Modifed-Date">N/A</span>
                            
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Payment
                            <br />
                            Mode</HeaderTemplate>
                        <ItemTemplate>
                            <span id="paymentMode" runat="server" class="payment-mode"></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Cancellation Date
                            <br />
                            (for full Refund)
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:Literal ID="cancellationDate" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>                    
                    <asp:TemplateField HeaderText="Current Status/Change To">
                        <ItemTemplate>
                            <span class="currentPaymentStatus"><%#DataBinder.Eval(Container.DataItem,"Status").ToString()%></span><br /><br />
                            <asp:DropDownList ID="paymentStatusDropDown" runat="server" Height="22px" Width="80px" CssClass="paymentstatus">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Update">
                        <ItemTemplate>
                            <asp:Button ID="UpdateButton" CssClass="button updaterecord" runat="server" Text="Update" OnClientClick="return UpdateNotes(this);" style="width:60px" />
                            <span class="currentPrintButton" id="_spanPrintButton" runat="server"><input type="button" class="button" value="Print" onclick='javascript:popupmenu(<%# DataBinder.Eval(Container.DataItem,"EventId")%>)' style="width:60px" /></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <RowStyle CssClass="row2" />
                <AlternatingRowStyle CssClass="row3" />
                <HeaderStyle CssClass="row1" />
            </asp:GridView>
        </div>
        <div class="left" style="padding-left: 100px; margin-top: 20px; display: none" id="dvNoQueueItemFound" runat="server">
            <div class="divnoitemfound_custdbrd">
                <p class="divnoitemtxt_custdbrd">
                    <span class="orngbold18_default">No Record Found!</span>
                </p>
            </div>
        </div>
    </div>
    <div id="HostPaymentNotes" title="Payment Record Details" style="display:none" >
	<div class="jdrow">
		<div class="lftb_thp">
			<label class="jdtlbl">Amount:<span class="reqiredmark"><sup>*</sup></span></label> &nbsp;<asp:TextBox id="_txtAmount" runat="server" Width="100px" CssClass="txtAmount"></asp:TextBox><br />
			<div class="drow"><label class="jdtlbl">Method:<span class="reqiredmark"><sup>*</sup></span></label>			 
             &nbsp;<asp:DropDownList ID="_paymentMode" runat="server" Height="22px" CssClass="paymentmode">
                            </asp:DropDownList>
             </div>
			<div class="drow"><label class="jdtlbl date-label">Date Paid:<span class="reqiredmark"><sup>*</sup></span></label> &nbsp;<asp:TextBox id="_datePaid" runat="server" Width="100px" CssClass="date-picker datePaid" ></asp:TextBox></div>
			<div class="drow divTaxNumber"><label class="jdtlbl">TaxId Number:</label> &nbsp;<asp:TextBox id="_taxIdNumber" runat="server" Width="100px" CssClass="taxIdNumber" ></asp:TextBox></div>
		</div>
		<div class="jdrow">
			<label class="jdtlbl">Notes:<span class="reqiredmark"><sup>*</sup></span></label> &nbsp;<asp:TextBox ID="_paymentNotes" runat="server" TextMode="MultiLine" CssClass="notes-text"
            Width="210px" />
		</div>
		<div class="jdrow">
				<asp:Button ID="UpdateNotesButton" runat="server" CssClass="rgt button_jt" Width="120px" OnClientClick="return UpdateStatusAndNotes();"
            Text="Update Payment" /> <span class="btn_jd"><asp:Button ID="_cancelButton" runat="server" CssClass="button_jt" Text="Cancel" OnClientClick="HideNotesDialog();" /></span>

		</div>
	</div>
    </div>
    <script type="text/javascript">
        $(document).ready(function() {
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 300 });
        });
    </script>
<input type="hidden" id="_organizationRoleUserId" runat="server" />
</asp:Content>
