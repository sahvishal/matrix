<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_ProfilePage" Title="Franchisor Profile" Codebehind="ProfilePage.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

<%@ Register Src="~/App/UCCommon/ucimagelist.ascx" TagName="ucimagelist" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
       <div class="mainbody_outer">
        <div class="mainbody_inner">
        
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Franchisor Profile</span>
                    <span class="headingright_default"></span>
                </div>
                <p><img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="main_area_bdr">
                <div class="main_content_area">
                    <div class="main_content_area_topbg">
                        <img src="../Images/maincontent-topbg.gif" width="563" height="4" /></div>
                    <div class="main_content_area_midbg">
                        <div class="main_content_area_inner">
                            <div class="main_content_name">
                                <span runat="server" id="name">Dale W. Wood </span>
                            </div>
                            <div class="main_content_designation" id="dvRole" runat="server">
                                <span runat="server" id="spfrnchdesg">Manager </span>
                            </div>
                            
                            <div class="main_content_about_txt">
                                <span runat="server" id="spabtfrnch"></span>
                            </div>
                            
                            <div class="headbg_box_profile">
                           <div class="head_text_profile"> About Franchisor</div>
                            </div>
                            
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">First Name:</span> <span class="inputfieldcon_profile" id="spfrnchname" runat="server">
                                    Dale</span> <span class="titletext_profile">Middle Name:</span> <span class="inputfieldcon_profile" id="spfrnchmname" runat="server">
                                        Wekkan</span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Last Name:</span> <span class="inputfieldcon_profile" id="spfrnchLname" runat="server">
                                    Wood</span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Date of Birth:</span> <span class="inputfieldcon_profile" id="spdob" runat="server">
                                    November 09, 1973</span> <span class="titletext_profile">SSN:</span> <span class="inputfieldcon_profile" id="spssn" runat="server">
                                        #AE75864</span>
                            </p>
                            <div class="main_content_about_profile" id="spDesc" runat="server" style="display:none;">
                                With a twist to the common list of habits that are useful to establish, here are
                                7 habits that you do best to avoid. Just like finding habits that can be useful
                                for you it’s important to find the habits that are holding you back. They can easily
                                become such a normal, everyday part of life that you hardly notice it (or how it’s
                                affecting you).
                            </div>
                            <%--<div class="hr">
                                <hr />
                            </div>--%>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Contact Details</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address1:</span> <span class="inputfieldcon_profile" id="spaddress1" runat="server">
                                    20 Prospect Ave, Hackensack</span> <span class="titletext_profile">Phone(Home):</span>
                                <span class="inputfieldcon_profile" id="sptelHome" runat="server">+234-345-6567</span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Suite,Apt,etc:</span> <span class="inputfieldcon_profile" id="spaddress2" runat="server">
                                    20 Prospect Ave, Hackensack</span> <span class="titletext_profile">Phone(Cell):</span>
                                <span class="inputfieldcon_profile" id="sptelCell" runat="server">+234-345-6567</span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Country:</span> <span class="inputfieldcon_profile" id="spCountry" runat="server">
                                    +234-345-6567</span> <span class="titletext_profile">Phone(Other):</span> <span class="inputfieldcon_profile" id="sptelOther" runat="server">
                                        +234-345-6567</span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">State:</span> <span class="inputfieldcon_profile" id="spState" runat="server">+234-345-6567</span>
                                <span class="titletext_profile">Email:</span> <span class="inputfieldcon_profile" id="spemail1" runat="server">yasirdrabu@healthyes.com</span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">City:</span> <span runat="server" class="inputfieldcon_profile" id="spCity">
                                    Florida</span> <span class="titletext_profile">Other Email:</span> <span runat="server"
                                        class="inputfieldcon_profile" id="spemail2">ydrabu@gmail.com</span>
                            </p>
                            
                            <p class="main_container_row_profile">
                            <span class="titletext_profile">Zip:</span> <span runat="server" class="inputfieldcon_profile" id="spZip">
                            670392</span>
                            </p>
                            
                        </div>
                    </div>
                    <div class="main_content_area_botbg">
                        <img src="/App/Images/maincontent-botbg.gif " width="563" height="6" /></div>
                </div>
                <div class="right_pannel_main">
                    <div class="right_frame_main">
                        <div class="right_frame_topbg">
                            <img src="../Images/frame-topbg.gif" width="165" height="8" /></div>
                        <div class="right_frame_midbg">
                            <div class="right_frame_image">
                               <asp:LinkButton runat="server" id="lnkMyPhoto" CommandName="MyPhoto" OnClick="lnkPhoto_Click"  >
                                 <asp:Image runat="server" ID="imgmyphto" ImageUrl="~/App/Images/my-photo.jpg" Height="107px"
                                    Width="150px" /></asp:LinkButton>
                                <%--<img src="../Images/my-photo.jpg" width="150" height="107" />--%>
                            </div>
                        </div>
                        <div class="right_frame_botbg">
                            <div class="right_frame_text">
                                <span runat="server" id="spcaptname">My Picture</span></div>
                        </div>
                    </div>
                    <div class="right_frame_main">
                        <div class="right_frame_topbg">
                            <img src="../Images/frame-topbg.gif" width="165" height="8" /></div>
                        <div class="right_frame_midbg">
                            <div class="right_frame_image">
                              <asp:LinkButton runat="server" id="lnkTeamPhoto" CommandName="TeamPhoto" OnClick="lnkPhoto_Click"  >
                                  <asp:Image runat="server" ID="imgmyteam" ImageUrl="~/App/Images/my-team.jpg" Height="107px"
                                    Width="150px" /></asp:LinkButton>
                                <%--<img src="../Images/my-team.jpg" width="150" height="107" />--%>
                            </div>
                        </div>
                        <div class="right_frame_botbg">
                            <div class="right_frame_text">
                                My Team</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
                        <contenttemplate>
<DIV class="mainbody_outer_bottom"><uc1:ucimagelist id="Ucimagelist1" runat="server" ></uc1:ucimagelist> </DIV>
</contenttemplate></asp:UpdatePanel>
    <div class="main_container_editbutton">
                                <div class="main_content_editbutton">
                                    <a href="UpdateFranchisorData.aspx?IsEdit=true">
                                        <img src="../Images/edit-button.gif" width="57" height="25" /></a></div>
                            </div>
  <div>

  <asp:Panel ID="Panel1" runat="server" CssClass="panelclass_imglist"  >
                    <div style="width: 487px; background-color:Gray; float:left; text-align:right; padding-right:3px; padding-top:3px;"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>
                    <div class="maindiv_imgp">        
                        <div class="innerdiv_imgp">    
                            <img runat="server" id="imgLargeImage" src='' style="width:460px; height:250px;" />    <%--<div class="closediv_imgp"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>--%>
                        </div>
                    </div>
                </asp:Panel>
                
                <ajaxtoolkit:modalpopupextender id="ModalPopupExtender"  runat="server" targetcontrolid="lnktemphidden"
                popupcontrolid="Panel1" backgroundcssclass="modalBackground" cancelcontrolid="ibtnclosesymbol" />
                
                <asp:LinkButton ID="lnktemphidden" runat="server" Visible="true"></asp:LinkButton>

                </div>
</asp:Content>
