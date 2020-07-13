<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncViewEventActivity.aspx.cs" Inherits="Falcon.App.UI.App.Common.AsyncViewEventActivity" EnableEventValidation="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<style type="text/css">
    /*---------- bubble tooltip -----------*/
    a.tt
    {
        position: relative;
        z-index: 24;
        color: #287AA8;
        font-weight: normal;
        text-decoration: none;
    }
    a.tt span
    {
        display: none;
    }
    /*background:; ie hack, something must be changed in a for ie to execute it*/
    a.tt:hover
    {
        z-index: 25;
        color: #ff6600;
        text-decoration: none;
    }
    a.tt:hover span.tooltip
    {
        display: block;
        position: absolute;
        top: 0px;
        left: 0;
        padding: 15px 0 0 0;
        width: 200px;
        color: #287AA8;
        text-align: left;
        filter: alpha(opacity:90);
        khtmlopacity: 0.90;
        mozopacity: 0.90;
        opacity: 0.90;
        text-decoration: none;
    }
    a.tt:hover span.top
    {
        display: block;
        padding: 30px 8px 0;
        background: url(/App/Images/bubble.gif) no-repeat top;
        text-decoration: none;
    }
    a.tt:hover span.middle
    {
        /* different middle bg for stretch */
        display: block;
        padding: 0 8px;
        background: url(/App/Images/bubble_filler.gif) repeat bottom;
        color: #000;
        text-decoration: none;
    }
    a.tt:hover span.bottom
    {
        display: block;
        padding: 3px 8px 10px;
        color: #ff6600;
        background: url(/App/Images/bubble.gif) no-repeat bottom;
        text-decoration: none;
    }
    
  .greybox_anp
    {
        float: left;
        width: 500px;
        padding:10px;
        background-color: #fff;
        border: solid 2px #ccc;
    }
    .greybox_anp .row
    {
        float: left;
        width: 494px;
        font-weight: bold;
    }
        .inputfield110px_anp
    {
        float: left;
        width: 110px;
        font: bold 12px arial;
        color: #000;
    }
</style>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView runat="server" ID="grdViewEventActivity" AutoGenerateColumns="False"
                        CssClass="divgrid_cl" GridLines="None" OnRowDataBound="grdViewEventActivity_RowDataBound">
                        <Columns>
                          <asp:BoundField DataField="Date" HeaderText="Date">
                            </asp:BoundField>
                            <asp:BoundField DataField="DaysToEvent" HeaderText="Days to Event">
                            </asp:BoundField>
                             <asp:TemplateField HeaderText="Description">
                                <ItemTemplate>
                               <%# DataBinder.Eval(Container.DataItem, "Type") %>:&nbsp;
                               <%#DataBinder.Eval(Container.DataItem, "Subject")%> <br />
                                <a href="javascript:void(0);" class="tt" runat="server" id="ahrefToolTipIsPaid"><b>Notes</b> 
                                        <span class="tooltip">
                                            <span class="top"></span>
                                            <span class="middle" id="spndefcursor" onmouseover="changetodefault('spndefcursor');" onmouseout="changetopointer('spndefcursor');">                                            
                                           <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                            </span>
                                            <span class="bottom"></span>
                                        </span>
                                    </a>
                                 </ItemTemplate>
                             </asp:TemplateField>
                             <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <span id="spnStatus" runat="server" style="display:none;">
                                    <%# DataBinder.Eval(Container.DataItem, "Status")%>
                                    </span>
                                    <a href="javascript:ViewEventActivityTaskCallMeeting('<%# DataBinder.Eval(Container.DataItem, "Type") %>',<%# DataBinder.Eval(Container.DataItem, "ID") %>);">View </a>
                                    &nbsp;|&nbsp;
                                    <span id="spnMarkComplete" runat="server">
                                    <a href="javascript:ChangeActivityStatus('<%# DataBinder.Eval(Container.DataItem, "Type") %>',<%# DataBinder.Eval(Container.DataItem, "ID") %>);">Mark Complete</a>
                                    </span>
                                </ItemTemplate>
                             </asp:TemplateField> 
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
    </div>
    </form>
</body>
</html>
