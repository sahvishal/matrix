<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucHospitalPartnerBanner.ascx.cs" Inherits="App_UCCommon_ucHospitalPartnerBanner" %>
<div class="main_row_custdbrd">
    <span id='spHPBanner' runat="server"></span>
    <script type="text/javascript">
        $(document).ready(function () {
            var decoded = $("<textarea/>").html($("#<%= spHPBanner.ClientID %>").html()).text();
            $("#<%= spHPBanner.ClientID %>").html(decoded);
        });

    </script>
</div>
