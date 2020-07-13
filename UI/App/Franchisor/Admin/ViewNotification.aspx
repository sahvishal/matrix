<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"  AutoEventWireup="true" Inherits="App_Franchisor_Admin_ViewNotification" ValidateRequest="false" Codebehind="ViewNotification.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script language="javascript" type="text/javascript">

    function ViewNotificationCenter()
    {
        
        var hidBack= document.getElementById('<%= this.hidBack.ClientID %>');
        hidCustomerID = document.getElementById('<%= this.hidCustomerID.ClientID %>');
        //alert(hidBack.value);
        //alert(hidCustomerID.value);
        if(hidBack.value =="mode1")
        {
            window.location.href="NotificationCenter.aspx?mode=1";
        }
        else if(hidBack.value =="mode2")
        {
            window.location.href=hidCustomerID.value+ "&tab=1";            
        }
        
        return false;
    }
</script>
<div class="mainbody_outer">
    <div class="mainbody_inner">
        <div class="main_area_bdrnone">
            <div class="orngheadtxt_default" style="padding-top: 8px; float: left;">
                View Notification</div>
                <div style="float:right; padding-top:10px;"> <a href="NotificationCenter.aspx" title="View Notification Center">View Notification Center</a> </div>
             <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <p class="graylinefull_default"><img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p><img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
            <div class="maindivgreenmsgbox" id="divMessage" enableviewstate="false" visible="false"
            runat="server">
            </div>
            <p class="main_container_row_default"><span class="orngbold14_default" style="float:left;">Recipient Information</span></p>
            <p><img src="/App/Images/specer.gif" width="725px" height="5px" /></p> 
            <div class="maindivgreenmsgbox" id="errordiv" enableviewstate="false" visible="false" runat="server">
            </div>   
             <div class="divmainbody_cd">
             <div class="detailboxtop_cd" style="margin-bottom:5px;">
                <div class="leftphotodiv_cd">
                    <p>
                        <img src="/App/Images/specer.gif" width="5px" height="50px" /></p>
                    <p class="divphoto_cd">
                        <asp:Image runat="server" ID="imgMyPicture" Width="130px" Height="178px" ImageUrl="~/App/Images/No-Image-Found.gif" /></p>
                </div>
                <div class="custdetails_cd">
                    <p>
                        <img src="/App/Images/specer.gif" width="5px" height="40px" /></p>
                        <p class="custdetailsrow_cd">
                            <span class="orngheadtxt16_default" style="float: left" runat="server" id="spCustomerName">John Drisdale</span>
                        </p>
                        <p class="custdetailsrow_cd">
                            <span runat="server" id="spEmail">john@drisdale.com</span>
                        </p>
                        <p>
                            <img src="/App/Images/specer.gif" width="200px" height="5px" /></p>
                        <p class="custdetailsrow_cd">
                            <span class="titletextnowidth_default">Customer ID:</span> <span id="spcutomerid"
                                runat="server" class="custidtxtbox_cd"></span><span class="titletextnowidth_default">
                                    Gender:</span> <span id="spGender" runat="server" class="normaltextnowidth_default"
                                        style="width: 48px"></span><span class="titletextnowidth_default">Date of Birth:</span>
                            <span id="spdob" runat="server" class="normaltextnowidth_default">12/12/1982</span>
                        </p>
                        <p class="custdetailsrow_cd">
                            <span class="titletextnowidth_default">User Name:</span> <span id="spUserName" runat="server"
                                class="normaltextnowidth_default"></span>
                        </p>
                       
                        <p class="custdetailsrow_cd">
                            <span class="titletextnowidth_default">Address:</span> <span id="spAddress" runat="server"
                                class="normaltextnowidth_default"></span>
                        </p>
                        
                       <p class="custdetailsrow_cd">
                            <span class="titletextnowidth_default">Phone Number:</span> <span id="spPhone"
                                runat="server" class="normaltextnowidth_default"></span>
                        </p>
                        <p class="custdetailsrow_cd">
                            <span class="titletextnowidth_default">Sign up Date:</span> 
                            <span class="normaltextnowidth_default"
                                style="padding-right: 150px" id="spSignUpDate" runat="server"></span><span class="titletextnowidth_default">
                                    Last Logged IN:</span> <span class="normaltextnowidth_default" id="spLastLogin" runat="server">
                                    </span>
                        </p></div>
            </div>              
             </div>
             <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>   
              <p class="main_container_row_default"><span class="orngbold14_default" style="float:left;">Notification Information
            </span></p>   
              <p><img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
            <p class="graylinefull_default"><img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
            <p><img src="/App/Images/specer.gif" width="725px" height="5px" /></p>   
             <div class="divbottomboxes_cd">
                                    <div class="divbluboxbodybg_cd" id="divmain" runat="server">
                                        <p>
                                            <img src="/App/Images/specer.gif" width="600" height="15" /></p>
                                        <p class="bigbluboxrow_cd">
                                            <span class="blutxt14ptbold_cd">
                                                       <span></span></span>
                                            
                                        </p>
                                        <p>
                                            <img src="/App/Images/specer.gif" width="600" height="5" /></p>
                                        <p class="bigbluboxrow_cd">
                                            <span class="titletext1a_default">Notification Time:</span>
                                             <span class="normaltextnowidth_default" runat="server" id="spNotificationTime"> mm/dd/yyyy @ hh:mm pm </span>
                                        </p>
                                        <p class="bigbluboxrow_cd">
                                            <span class="titletext1a_default">Notification Type:</span> 
                                            <span class="normaltextnowidth_default" runat="server" id="spNotificationType">Account Creation Notification </span>
                                        </p>
                                        <p class="bigbluboxrow_cd">
                                            <span class="titletext1a_default">Notification Medium:</span>
                                             <span class="normaltextnowidth_default" runat="server" id="spNotificationMedium"> 
                                            <img alt="" runat= "server" id="imgMedium" src="/App/Images/call-icon.gif"/> </span>
                                        </p>
                                        <p class="bigbluboxrow_cd">
                                            <span class="titletext1a_default">Notification Sender:</span>
                                             <span class="normaltextnowidth_default" runat="server" id="spSender"> System/Name of CC Rep  </span>
                                        </p>
                                        <p class="bigbluboxrow_cd">
                                            <span class="titletext1a_default">Subject:</span>
                                             <span class="normaltextnowidth_default">  <asp:TextBox ID="txtSubject" runat="server" CssClass="inputf_def" Width="550px"></asp:TextBox>  </span>
                                        </p>
                                        
                                        <div class="bigbluboxrow_cd">
                                            <span class="titletext1a_default">Body/Message/Notes:</span>
                                             <span class="normaltextnowidth_default">                                              
                                             <textarea cols="40" rows="30" id="content1" name="content1" class="inputf_def">
		                                       <%=strBody%>
	                                        </textarea>
                                             </span>
                                       </div>
                                        <p><img src="/App/Images/specer.gif" width="600" height="15" /></p>
                                    </div>
                                    <div class="divbluboxbotbg_cd" id="divbottom" runat="server">
                                        <img src="/App/Images/specer.gif" width="50" height="5" /></div>
                                </div>
               
            <p class="main_container_row_default">
            <span class="buttoncon_default"> <asp:ImageButton runat="server" ID="ibtnclose" ToolTip="Close" 
                    ImageUrl="~/App/Images/close-button.gif" OnClientClick="return ViewNotificationCenter();" /></span>
            <span style="float:right; padding-right:5px;"><asp:ImageButton runat="server"  ToolTip="Save and Sent To client"
                    ID="ImageButton1" ImageUrl="/App/Images/savensendclient-btn.gif" 
                    onclick="ImageButton1_Click" /></span>
            </p>
            <asp:HiddenField ID="hidBack" runat="server" />
            <asp:HiddenField ID="hidCustomerID" runat="server" />
         </div>
    </div>
</div>
<!-- Load PunyMCE and all plugins -->
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/puny_mce.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/textcolor/textcolor.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/paste.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/image/image.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/link/link.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/emoticons/emoticons.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/editsource/editsource.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/forceblocks.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/bbcode.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/entities.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/protect.js"></script>
<script type="text/javascript" src="../../JavascriptFiles/js/punymce/plugins/safari2x.js"></script>

<!-- Optional language pack -->


<!-- Load PunyMCE and setup basic editor -->
<script type="text/javascript">
var editor1 = new punymce.Editor({
	id : 'content1',
	//toolbar : 'bold,italic,underline,strike,increasefontsize,decreasefontsize,ul,ol,indent,outdent,left,center,right,style,textcolor,removeformat,link,unlink,image,emoticons,editsource',
	toolbar : 'bold,italic,underline,strike,increasefontsize,decreasefontsize,ul,ol,indent,outdent,left,center,right,style,textcolor,removeformat,link,unlink,editsource',
	//plugins : 'Paste,Image,Emoticons,Link,ForceBlocks,Protect,TextColor,EditSource,Safari2x,Entities',
	plugins : 'Paste,Link,ForceBlocks,Protect,TextColor,EditSource,Safari2x,Entities',
	min_width : 545,
	entities : 'numeric'
});
</script>

</asp:Content>