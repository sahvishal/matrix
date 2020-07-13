<%@ Control Language="C#" AutoEventWireup="true" Inherits="UCCommon_ucupdatephotopanel" Codebehind="ucupdatephotopanel.ascx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    
 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<link href="../StyleSheets/Franchisor.css" rel="stylesheet" type="text/css" />
<link href="../StyleSheets/UC.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" language="javascript">

   
    
    function checkdropdown()
    {
        //debugger
//        if(navigator.appName == "Netscape")
//        {
//            return false;
//        }
         var hfimage = document.getElementById('<%= this.hfimagecount.ClientID %>');
        var CONST_LIST_ITEM_COUNT = hfimage.value;

        if(CONST_LIST_ITEM_COUNT == 0)
            CONST_LIST_ITEM_COUNT = 12;
            
        var uploadelement = document.getElementById('<%= this.imguploader.ClientID %>');
                        
        if(uploadelement.value == '')
        {
            alert("Please choose a file to display");
            return false;
        }
                
        var hfuploadval = document.getElementById('<%= this.hfuploadval.ClientID %>');
        hfuploadval.value = uploadelement.value;
        
        var drpdownphototype = document.getElementById('<%= this.ddlphototype.ClientID %>');
        if(drpdownphototype == null)
            return true;
            
        var selIndex = drpdownphototype.selectedIndex;
            
        var check = true;
        if(drpdownphototype.options[selIndex].value == "0")
        {
            alert("Please select a phototype first.");
            return false;
        }
        else if(drpdownphototype.options[selIndex].value == "1")
        {
            var myphotoimage = document.getElementById('<%= this.imgmyphoto.ClientID %>');
            if(myphotoimage.src != null && myphotoimage.src != '')
                check = confirm("This type already has an image attached. Do you want to replace it?");
//           
        }
        else if(drpdownphototype.options[selIndex].value == "2")
        {
            var teamphotoimage = document.getElementById('<%= this.imgteamphoto.ClientID %>');
            if(teamphotoimage.src != null && teamphotoimage.src != '')
                check = confirm("This type already has an image attached. Do you want to replace it?");
//            
        }       
        else if(drpdownphototype.options[selIndex].value == "3")
        {
        
            var listotherphoto = document.getElementById('<%= this.dlotherimages.ClientID %>');
            if(listotherphoto != null)
            {
                if(listotherphoto.rows != null)
                {
                    var icount = 0;
                    var itemcount = 0;
                    var outofloop = false;
                    while(icount < listotherphoto.rows.length)
                    {
                        var innericount = 0;
                        while(innericount < listotherphoto.rows[icount].cells.length)
                        {
                            if(listotherphoto.rows[icount].cells[innericount].childNodes.length < 1)
                            {
                                outofloop = true;
                                break;
                            }
                            itemcount = itemcount + 1;
                            innericount = innericount + 1;
                        }
                        if(outofloop == true)
                            break;
                        icount = icount + 1;
                    }
                    
                    if(itemcount >= CONST_LIST_ITEM_COUNT)
                    {
                        alert("Only " + CONST_LIST_ITEM_COUNT + " images are allowed in the list. Please delete one to add new.");
                        check = false;
                    }
                }
            }
           
        }
        
        if(check == false)
        {
            drpdownphototype.options[0].selected = true;
            return false; 
        }
        
        return true;
            
    }

</script>

<div class="rowcontainer_ucphoto">
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>--%>
    <div runat="server" id="divTeamPhoto" class="maincontainer_ucphoto">
    <div class="headercontainer_ucphoto">
        <div class="headertxt_ucphoto">Team Photo:</div></div>
        <div class="imagecontainer_ucphoto">
            <%--<asp:Image runat="server" ID="imgteamphoto" ImageUrl="~/App/Images/my-team.jpg" Width="100px" Height="70px" />--%>
            <asp:LinkButton runat="server" id="lnkteamphoto" OnClick="lnkteamphoto_Click" > <img runat="server" id="imgteamphoto" alt="Preview not available" src='~/App/Images/my-team.jpg' style="width:100px; height:70px;" /> </asp:LinkButton>
        </div>
 
    </div>
    
    <div runat="server" id="divMyPhoto" class="maincontainer_ucphoto"> 
    <div class="headercontainer_ucphoto" id="divMyPhotoHeader" runat="server">
        <div class="headertxt_ucphoto" >My Photo:</div></div>
        <div class="imagecontainer_ucphoto">
            <asp:LinkButton runat="server" id="lnkmyphoto" OnClick="lnkmyphoto_Click" > <img id="imgmyphoto" runat="server" alt="Preview not available" src='~/App/Images/my-team.jpg' style="width:100px; height:70px;" /> </asp:LinkButton>
        </div>
    </div>
    
    
    <div runat="server" id="divOtherImages" class="rowcontainer_ucphoto">
        <div class="headercontainerbig_ucphoto">
        <div class="headertxt_ucphoto"> Other Photos: </div></div>
        <div class="imagecontainerbig_ucphoto"> 
            <asp:DataList runat="server" ID="dlotherimages" RepeatColumns="3" RepeatDirection="Horizontal" >
                <ItemTemplate>
                    <span class="otherphoto_ucphoto"> 
                        <asp:LinkButton runat="server" id="imgClick" OnClick="imgClick_Click"> <img alt="Preview not available" src='<%# DataBinder.Eval(Container.DataItem, "Image") %>' id="imgotherphoto" runat="server" width="100" height="70" /> </asp:LinkButton>
                    </span>
                    <span class="dellnkphoto_ucphoto"> 
                        <asp:LinkButton id="lnkdelete" runat="server" Text="Delete" OnClick="lnkdelete_Click"></asp:LinkButton>
                    </span>
                </ItemTemplate>
                <ItemStyle Width="240px" />
            </asp:DataList>
        </div>
    </div>
    
                 
    <%--</ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnUpload" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>--%>
    
    <div class="maincon_upphoto_ucphoto">
        <asp:Panel runat="server" ID="pnluploadimages" GroupingText="Upload Image" CssClass="divtoolupdtephoto_ucphoto">
           <div><img src="/App/Images/specer.gif" width="360px" height="10px" /></div>
            <div id="divPhotoType" runat="server" style="float:left; width:390px;">
                <span class="phototype_ucphoto" style="text-align:left">Photo Type:</span>
                <span class="listphototype_ucphoto"> 
                    <asp:DropDownList runat="server" ID="ddlphototype" Width="232px">
                        <asp:ListItem Text="Select PhotoType" Value="0"></asp:ListItem>
                        <asp:ListItem Text="My Photo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Team Photo" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Other Photos" Value="3"></asp:ListItem>
                    </asp:DropDownList> 
                </span>
            </div>
            <div><img src="/App/Images/specer.gif" width="360px" height="10px" /></div>
            <div style="float:left; width:390px;">
            <span class="phototype_ucphoto" style="text-align:left"> Browse: </span>
            <span style="float:left"><asp:FileUpload ID="imguploader" runat="server" Width="235px" /></span>
            <span class="uploadbutton_ucphoto" style="float:left">
                <asp:Button runat="server" ID="btnUpload" Text="Upload" OnClick="btnUpload_Click" OnClientClick="return checkdropdown();" />
            </span></div><asp:HiddenField ID="hfuploadval" runat="server" />
        </asp:Panel>
    </div>
    <asp:HiddenField runat="server" ID="hfimagecount" />

</div>

                <asp:Panel ID="Panel1" runat="server" CssClass="panelclass_imglist"  >
                    <div class="closebutton_ucphoto"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>
                    <div class="maindiv_imgp">        
                        <div class="innerdiv_imgp">    
                            <img runat="server" id="imgLargeImage" src='' style="width:460px; height:250px;" />    <%--<div class="closediv_imgp"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>--%>
                        </div>
                    </div>
                </asp:Panel>
                
                <ajaxtoolkit:modalpopupextender id="ModalPopupExtender"  runat="server" targetcontrolid="lnktemphidden"
                popupcontrolid="Panel1" backgroundcssclass="modalBackground" cancelcontrolid="ibtnclosesymbol" />
                
                <asp:LinkButton ID="lnktemphidden" runat="server" Visible="true"></asp:LinkButton>