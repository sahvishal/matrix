<%@ Control Language="C#" AutoEventWireup="true" Inherits="App_UCCommon_ucQADiv" Codebehind="ucQADiv.ascx.cs" %>
<div class="maintopcontainerqa" style="display:none;visibility:none" id="divQA" runat="server">
    <div class="qaredbar_common" id="divQAMain" runat="server">QA</div>
    <script type="text/javascript">
        $(document).ready(function () {
            var decoded = $("<textarea/>").html($("#<%= divQAMain.ClientID %>").html()).text();
            $("#<%= divQAMain.ClientID %>").html(decoded);
        });

    </script>
</div>
