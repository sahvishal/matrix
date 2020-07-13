<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucsearchbox" Codebehind="ucsearchbox.ascx.cs" %>

<script language="javascript" type="text/javascript">
    function cleartext() { document.getElementById("txtsearch").value = ""; }
</script>


<div class="searchtabtxt2">
    Search <span id="spsearchtype" runat="server">Country</span>:
</div>

<div class="searchtabinput">
    <input type="text" id="txtsearch" onkeypress="return onsearchtextkeypress(event);" style="width:90px;" class="searchtabinputf" name="textfield" size="20" />
    <%--<asp:TextBox runat="server" ID="txtsearch" CssClass="searchtabinputf"></asp:TextBox>--%>
</div>

<div class="searchtabgobutton">    
    <a id="aclickgo" href='javascript:searchquery();' > 
        <img src= '<%= ResolveUrl("~/App/Images/go-button.gif") %>' width="44" height="20" /></a>
        <a id="a1" href='javascript:cleartext();'> 
        <img src= '<%= ResolveUrl("~/App/Images/Clear-butt.gif") %>' width="48" height="20" />
    </a>
</div>
