<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcEventAppointment.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.UcEventAppointment" %>
<%@ Register Src="JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
    IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" IncudeJTemplate="true"
    IncudeJQuerySelectable="true" IncudeJQueryJTip="true" IncludeAjax="true" />
<script language="javascript" type="text/javascript">
    $(document).ready(function () {
        $('.jTip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false });
    });

</script>
<script src="/App/jquery/js/json2.js" type="text/javascript"></script>
<div class="legend_slot" style="display: none; width: 420px">
    <img src="/App/Images/CCRep/legend-slots.gif" alt="" />
</div>
<div class="dgselecttime_pw" id="_divAppointmentSlots" runat="server" style="width: 400px">
</div>
<div id="slotidsHiddenContainer">
<input type="hidden" id="hfSlotIds" runat="server" />    
</div>

<script language="javascript" type="text/javascript">

    var _appointmentTime = "";
    var _hideConfirmationMessageMethod = null;
    var _setOrderSummaryAppointmentTime = null;
    var _screeningTime = <%= ScreeningTime %>;

    function getSlotView() {//debugger;

        var arr = null;
        if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
            eval('arr = [' + $("#<%= hfSlotIds.ClientID %>").val() + ']');
        }

        var testIds = null;
        if ($.trim('<%= TestIds %>').length > 0) {
            eval('testIds = [' + '<%= TestIds %>' + ']');
         }

        $.ajax({
            url: '/Scheduling/AppointmentSlot/Select',
            type: 'Post',
            cache: false,
            contentType: "application/json; charset=utf-8",
            dataType: 'html',
            data: "{'eventId' : <%= EventId.Value %>, 'screeningTime' :" + _screeningTime + ", 'selectedSlotIds' : " + JSON.stringify(arr) + ", 'packageId' : " + <%= PackageId%> + ", 'testIds' : " + JSON.stringify(testIds) + "}",
            success: function (result) {
                $("#<%= _divAppointmentSlots.ClientID %>").html(result);                

                _methodReffromParentForSuccessonSelectAppointment = onSuccessSelectAppointment;
                _methodReffromParentForSuccessonChangeAppointment = onSuccessChangeAppointment;
                _methodReffromParentForFailureonSelectAppointment = getSlotView;
            },
            error: function (arg1, arg2) {

            }
        });
    }

    getSlotView();    

    function onSuccessSelectAppointment(slots) {
        var slotString = "";

        var count = 1;
        $.each(slots, function () {
            
            if (count < slots.length)
                slotString += this.Id + ", ";
            else
                slotString += this.Id;

            count++;

        });
        //debugger;
        _appointmentTime = slots[0].StartTimeString;

        if (_setOrderSummaryAppointmentTime != null)
            _setOrderSummaryAppointmentTime(_appointmentTime);

        $("#<%= hfSlotIds.ClientID %>").val(slotString);

        getSlotView();
    }

    function onSuccessChangeAppointment() {//debugger;
        $("#<%= hfSlotIds.ClientID %>").val("");
        
        _appointmentTime = "";
        if (_hideConfirmationMessageMethod != null)
            _hideConfirmationMessageMethod();

        if (_setOrderSummaryAppointmentTime != null)
            _setOrderSummaryAppointmentTime('0');

        getSlotView();
    }

    function isAppointmentSelected() {
        if ($.trim($("#<%= hfSlotIds.ClientID %>").val()).length > 0) {
            return true;
        }

        return false;
    }

    function getAppointmentTime() {//debugger;
        return _appointmentTime;
    }

</script>
