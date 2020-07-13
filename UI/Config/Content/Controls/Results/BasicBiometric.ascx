<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BasicBiometric.ascx.cs"
    Inherits="Falcon.App.UI.Config.Content.Controls.Results.BasicBiometric" %>
<div id="BasicBiometricDiv" runat="server" class="contentrow" style="display: none;">
    <fieldset style="padding: 5px; border-radius: 4px;">
        <legend>
            <h2>
                Basic Biometric Results</h2>
        </legend>
        <% if (Disabled)
           {%>
        <div class="lrow">
            <strong>Blood Pressure: </strong>&nbsp;&nbsp; <b>Systolic: </b>
            <input type="text" id="systolicbp" disabled="disabled" class="input_bdrbot input_width_small" />
            &nbsp;&nbsp; <b>Diastolic: </b>
            <input type="text" id="diastolicbp" disabled="disabled" class="input_bdrbot input_width_small" />
            &nbsp;&nbsp;<strong>Pulse Rate: </strong>&nbsp;&nbsp;
            <input type="text" id="pulseratebb" disabled="disabled" class="input_bdrbot input_width_small" />
            &nbsp;&nbsp; <b>Tested Arm: </b>&nbsp;&nbsp;
            <input type="radio" id="rightArmBp" disabled="disabled" name="bpMeasurement" />
            Right &nbsp;&nbsp;
            <input type="radio" id="leftArmBp" disabled="disabled" name="bpMeasurement" />
            Left&nbsp;&nbsp;&nbsp;&nbsp;
            <% if (EnableAbnormalBp)
               { %>
                <input type="checkbox" id="isElevatedBp" />
                Abnormal
            <% }
               else
               { %>
                <input type="checkbox" id="isElevatedBp" disabled="disabled" />
                Abnormal
            <% } %>
        </div>
        <%
           }
           else
           {%>
        <div class="lrow">
            <strong>Blood Pressure: </strong>&nbsp;&nbsp; <b>Systolic: </b>
            <input type="text" id="systolicbp" class="input_bdrbot input_width_small" />
            &nbsp;&nbsp; <b>Diastolic: </b>
            <input type="text" id="diastolicbp" class="input_bdrbot input_width_small" />
            &nbsp;&nbsp;<strong>Pulse Rate: </strong>&nbsp;&nbsp;
            <input type="text" id="pulseratebb" class="input_bdrbot input_width_small" />
            &nbsp;&nbsp; <b>Tested Arm: </b>&nbsp;&nbsp;
            <input type="radio" id="rightArmBp" name="bpMeasurement" />
            Right &nbsp;&nbsp;
            <input type="radio" id="leftArmBp" name="bpMeasurement" />
            Left&nbsp;&nbsp;&nbsp;&nbsp;
            <input type="checkbox" id="isElevatedBp" />
            Abnormal
        </div>
        <%
           }%>
    </fieldset>
</div>
