<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_ViewContact" Codebehind="ViewContact.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .wrapper_bcard
        {
            float: left;
            width: 320px;
            margin-right: 8px;
            height: 140px;
        }
        .wrapper_bcard .topbg
        {
            float: left;
            width: 317px;
            background-image: url(../images/topbg_bcard.gif);
            background-repeat: no-repeat;
            height: 3px;
        }
        .wrapper_bcard .header
        {
            float: left;
            width: 305px;
            border-left: solid 1px #BBCBDA;
            border-right: solid 1px #BBCBDA;
            font: normal 12px arial;
            background: url(/app/images/headerbg-bcard.gif) repeat-x;
            height: 20px;
            padding: 4px 5px 4px 5px;
        }
        .wrapper_bcard .header .chkbox
        {
            float: left;
        }
        .wrapper_bcard .body
        {
            float: left;
            width: 305px;
            border-left: solid 1px #BBCBDA;
            border-right: solid 1px #BBCBDA;
            font: normal 12px arial;
            padding: 5px;
            height: 90px;
        }
        .wrapper_bcard .body .row
        {
            float: left;
            width: 289px;
            font: normal 12px arial;
            padding: 5px 8px 5px 10px;
        }
        .wrapper_bcard .botbg
        {
            float: left;
            width: 317px;
            background-image: url(/app/images/botbg_bcard.gif);
            background-repeat: no-repeat;
            height: 2px;
        }
        .alphabetvaluebox
        {
            float: left;
            width: 38px;
            padding-top: 5px;
            height: 23px;
            text-align: center;
            background-image: url(../images/alphabetbg_bcard.gif);
            background-repeat: no-repeat;
        }
        .alphabetvaluebox a.link
        {
            text-decoration: none;
        }
        .alphabetvaluebox a.visited
        {
            text-decoration: none;
        }
        .activealphabetvaluebox
        {
            float: left;
            width: 38px;
            padding-top: 5px;
            color: #000;
            height: 23px;
            text-align: center;
            background-image: url(../images/active-tab.gif);
            background-repeat: no-repeat;
        }
        .activealphabetvaluebox a
        {
            color: #000;
            text-decoration: none;
        }
        .activealphabetvaluebox a.link
        {
            text-decoration: none;
            color: #000;
        }
        .activealphabetvaluebox a.visited
        {
            text-decoration: none;
            color: #000;
        }
        .headbg2_box_v_prospects
        {
            float: left;
            width: 753px;
            padding: 5px 0px 5px 0px;
        }
        .cancel_button_v_prospects
        {
            float: right;
            width: 56px;
            height: 32px;
            padding: 0px 5px 0px 0px;
        }
        .save_button_v_prospects
        {
            float: right;
            width: 60px;
            height: 32px;
            padding: 0px 5px 0px 0px;
        }
        .divgridviewcontacts
        {
            float: left;
            width: 751px;
            border-style: none;
        }
    </style>

    <script type="text/javascript" language="javascript">
    
    function GridMasterCheck()
    {
       
        Grid_MasterCheckBoxClick("<%= this.grdContacts.ClientID %>");

             var objtemp = document.createElement("INPUT");
             var numcount2 = Grid_MultiSelect("<%= this.grdContacts.ClientID %>", objtemp)

        
    }
    
    function GridChildCheck()
    {
        Grid_ChildCheckBoxClick("<%= this.grdContacts.ClientID %>");
        var objtemp = document.createElement("INPUT");
        var numcount2 = Grid_MultiSelect("<%= this.grdContacts.ClientID %>", objtemp)
//        if(numcount2 == 1)
//        {
//             var btnEdit= document.getElementById("<%= this.btnEdit.ClientID %>");
//             btnEdit.disabled=false;
//             btnEdit.src="/App/Images/edit-button.gif";
//        } 
//        else
//        {
//            var btnEdit= document.getElementById("<%= this.btnEdit.ClientID %>");
//             btnEdit.disabled=true;
//             btnEdit.src="/App/Images/edit-button-disable.gif";
//        } 
              
    }  
    
    function validate(type)
    {
    //debugger
        var objtemp = document.createElement("INPUT");
        var numcount = Grid_MultiSelect("<%= this.grdContacts.ClientID %>", objtemp);
        
            if (numcount >=1 && (type=="Delete"))
            {
                var answer = confirm ("Are you sure you want to delete Contact(s) ? ")
                return answer;
            }
            else if (numcount==1 && (type=="Edit"))
            {
                 var answer = confirm ("Are you sure you want to Edit Contact ? ")
                return answer;
            }
           
            else if (numcount==0)
            {
                alert("Please select atleast one item from the grid.");
                return false;
            }
       
    }
    
    function DeleteDlist()
    {
        var hfcollection = document.getElementById('<%= this.hfdlcontact.ClientID %>').value;
        if (hfcollection.length < 1)
        {
            alert("Please select atleast one item from the List.");
            return false;
        }
    }
    
    
    function onAlphabetClick(alphabet)
    {
        __doPostBack('Alphabet', alphabet);
    }
    
    function onViewChange()
    {
        __doPostBack('ViewChange', '');
    }

    function onclickcheckboxdlist(chkbox, contactid)
    {
        var hfcollection = document.getElementById('<%= this.hfdlcontact.ClientID %>').value;
        if(chkbox.checked)
        {
            if(hfcollection.length > 0)
                hfcollection = hfcollection + ", " + contactid;
            else
                hfcollection = contactid;
        }
        else
        {
            if(hfcollection.indexOf(", " + contactid) >= 0)
                hfcollection = hfcollection.replace(", " + contactid, "");
            else
                hfcollection = hfcollection.replace(contactid, "");
        }
        document.getElementById('<%= this.hfdlcontact.ClientID %>').value = hfcollection;
    }

    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750" height="5" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Manage Contacts</span>
                    <span class="headingright_default">
                        <asp:LinkButton ID="lbtNewContact" runat="server" Text="+ Add new Contact" OnClick="lbtNewContact_Click" /></span>
                </div>
            </div>
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <div class="headbg2_box_v_prospects">
                    <div style="float: left; padding-left: 10px;">
                        <a runat="server" id="aGridView" href="javascript:onViewChange();"><b>Grid View</b></a>&nbsp;|&nbsp;<a
                            runat="server" id="aBusinessView" href="javascript:onViewChange();"><b>Business Card</b></a>
                    </div>
                    <div class="cancel_button_v_prospects">
                        <asp:ImageButton runat="server" ID="btnDelete" ImageUrl="~/App/Images/del-button.gif"
                            OnClientClick="return validate('Delete');" OnClick="btnDelete_Click" /></div>
                    <div class="save_button_v_prospects" style="visibility: hidden; display: none;">
                        <asp:ImageButton runat="server" ID="btnEdit" Enabled="false" ImageUrl="~/App/Images/edit-button-disable.gif"
                            OnClientClick="return validate('Edit');" OnClick="btnEdit_Click" /></div>
                </div>
                <div runat="server" id="divViewGrid" class="divgridviewcontacts">
                    <div style="float: left; width: 750px;">
                        <asp:GridView ID="grdContacts" runat="server" CssClass="divgrid_cl" AutoGenerateColumns="False"
                            DataKeyNames="ContactID" GridLines="None" OnRowDataBound="grdContacts_RowDataBound">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <input type="checkbox" id="chklistname1" runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" id="chkRowChild" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <a style="text-decoration: none;" href='<%# this.ResolveUrl("~/App/Franchisor/AddNewContact.aspx?ContactID="+ DataBinder.Eval(Container.DataItem, "ContactID")) %>'>
                                            <%# DataBinder.Eval(Container.DataItem, "FirstName")%>&nbsp;<%# DataBinder.Eval(Container.DataItem, "LastName")%>
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                <asp:BoundField DataField="PhoneOffice" HeaderText="Phone Office"></asp:BoundField>
                                <asp:BoundField DataField="PhoneHome" HeaderText="Phone Home"></asp:BoundField>
                                <asp:BoundField DataField="PhoneCell" HeaderText="Phone Cell"></asp:BoundField>
                                <asp:BoundField DataField="Fax" HeaderText="Fax"></asp:BoundField>
                            </Columns>
                            <HeaderStyle CssClass="row1" />
                            <RowStyle CssClass="row2" />
                            <AlternatingRowStyle CssClass="row3" />
                        </asp:GridView>
                    </div>
                    <div runat="server" id="tblGridPaging" style="float: left; width: 750px;">
                    </div>
                </div>
                <div runat="server" id="divViewBusinessCards" style="width: 750px; float: left;">
                    <div style="width: 692px; float: left; padding: 0px 0px 11px 10px;">
                        <div style="float: left; width: 692px;">
                            <asp:DataList runat="server" ID="dlContacts" DataKeyField="ContactID" RepeatColumns="2"
                                RepeatDirection="Horizontal">
                                <ItemTemplate>
                                    <div class="wrapper_bcard">
                                        <div class="topbg">
                                            <img src="../Images/specer.gif" height="10px" width="212px" alt="" />
                                        </div>
                                        <div class="header">
                                            <span class="chkbox">
                                                <input type="checkbox" id="chkRowChild" onclick="onclickcheckboxdlist(this, '<%# DataBinder.Eval(Container.DataItem, "ContactID")%>');" />
                                            </span><span style="float: left;">
                                                <%# DataBinder.Eval(Container.DataItem, "LastName") %>
                                                <%# DataBinder.Eval(Container.DataItem, "FirstName").ToString().Length > 0? ", " + DataBinder.Eval(Container.DataItem, "FirstName").ToString() : "" %>
                                            </span>
                                        </div>
                                        <div class="body">
                                            <p class="row">
                                                <span class="orngbold12_default">
                                                    <%# DataBinder.Eval(Container.DataItem, "FirstName") %>&nbsp;<%# DataBinder.Eval(Container.DataItem, "LastName") %></span>
                                            </p>
                                            <p class="row">
                                                <%# DataBinder.Eval(Container.DataItem, "PhoneOffice").ToString().Length > 0 ? DataBinder.Eval(Container.DataItem, "PhoneOffice").ToString() + "<br />" : ""%>
                                                <%# DataBinder.Eval(Container.DataItem, "Email") %>
                                            </p>
                                            <p class="row">
                                                <span style="float: right; padding-right: 5px"><a href='<%# this.ResolveUrl("~/App/Franchisor/AddNewContact.aspx?ContactID="+ DataBinder.Eval(Container.DataItem, "ContactID")) %>'>
                                                    Edit </a></span>
                                            </p>
                                        </div>
                                        <div class="botbg">
                                            <img src="../Images/specer.gif" height="1px" width="1px" alt="" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                        <div runat="server" id="tblListPaging" style="float: left; width: 692px;">
                        </div>
                    </div>
                    <asp:HiddenField runat="server" ID="hfdlcontact" Value="" />
                    <div style="width: 38px; padding: 0px 5px 10px 5px; float: left;" runat="server" id="divalphabetsearch">
                        <table cellpadding="3" cellspacing="0" style="border-collapse: collapse; text-align: center;
                            float: left;">
                            <tr style="margin-bottom: 5px;">
                                <td id="alphaA" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('A');">A</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaB" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('B');">B</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaC" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('C');">C</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaD" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('D');">D</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaE" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('E');">E</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaF" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('F');">F</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaG" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('G');">G</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaH" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('H');">H</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaI" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('I');">I</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaJ" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('J');">J</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaK" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('K');">K</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaL" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('L');">L</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaM" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('M');">M</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaN" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('N');">N</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaO" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('O');">O</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaP" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('P');">P</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaQ" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('Q');">Q</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaR" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('R');">R</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaS" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('S');">S</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaT" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('T');">T</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaU" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('U');">U</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaV" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('V');">V</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaW" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('W');">W</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaX" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('X');">X</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaY" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('Y');">Y</a>
                                </td>
                            </tr>
                            <tr>
                                <td id="alphaZ" class="alphabetvaluebox">
                                    <a href="javascript:onAlphabetClick('Z');">Z</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
