<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Public/Public.master"
    Inherits="Falcon.App.UI.Public.Events.EventDefault" EnableEventValidation="false"
    CodeBehind="Default.aspx.cs" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 
     <script type="text/javascript" language="javascript">

        function popupmenu2(choice, wt, ht) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            window.open(choice, 'theconfirmWin', winOpts);
        }

        function popupgmap(choice, wt, ht) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            window.open(choice, 'theconfirmWin', winOpts);
        }

    </script>
    <%-- Header Image --%>
    <div>
        <img src="/Content/Images/step1_public.gif" alt="Step 1 of Registration" />
    </div>
        
    <%-- Search Results Summary --%>
    <div runat="server" id="divSearchResult">
        <h2 runat="server" id="spResults" style="margin-left: 5px;">
        </h2>
        <div id="spInfo" runat="server" class="info-box">
            <u>Click</u> on the Register Now button to register for the event of your choice.
            If you need help finding an event, please call <strong>
                <%= IoC.Resolve<ISettings>().PhoneTollFree%></strong>
        </div>
       
    </div>
    
    <div style="margin: 10px; padding: 5px;">
        <h3>
            Did not find the Event you were looking for?</h3>
        <h4>
            <a href="/">&lt;&lt; Search Again with a different zip code</a></h4>
    </div>
</asp:Content>
