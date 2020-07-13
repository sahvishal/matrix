<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Message.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.Message" %>
<div id="MessagesDiv" runat="server" enableviewstate="false" style="margin: 5px; clear: both"></div>
<script type="text/javascript"> 
$(document).ready(function(){
            var decoded = $("<textarea/>").html($("#<%=MessagesDiv.ClientID %> .ui-state-highlight").html()).text();
            $("#<%=MessagesDiv.ClientID %> .ui-state-highlight").html(decoded); 
    
            var decoded1 = $("<textarea/>").html($("#<%=MessagesDiv.ClientID %> .ui-state-error").html()).text();
            $("#<%=MessagesDiv.ClientID %> .ui-state-error").html(decoded1);
});
    </script>