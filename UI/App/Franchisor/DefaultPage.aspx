<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="true" Inherits="Franchisor_DefaultPage" Title="Untitled Page" Codebehind="DefaultPage.aspx.cs" %>


<%@ Register Src="~/App/UCCommon/ucimagelist.ascx" TagName="ucimagelist" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="mainbody_outer">
            <div class="mainbody_inner">
                <div class="mainbody_inner_left">
                </div>
                <div class="mainbody_inner_mid">
                    <div class="mainbody_titletxtleft">
                        Default Page
                    </div>
                </div>
                <div class="mainbody_inner_right">
                </div>
                <div class="main_area_bdr">
                    <div class="main_content_area">
                        <div class="main_content_area_topbg">
                            <img src="../Images/maincontent-topbg.gif" width="563" height="4" /></div>
                        <div class="main_content_area_midbg">
                            <div class="main_content_area_inner">
                                <div class="main_content_name">
                                    <span runat="server" id="spfrnchname"> Dale W. Wood </span></div>
                                <div class="main_content_designation">
                                    <span runat="server" id="spfrnchdesg"> Manager </span> </div>
                                <div class="main_content_about_title">
                                    About Myself</div>
                                <div class="main_content_about_txt">
                                    <span runat="server" id="spabtfrnch"> With a twist to the common list of habits that are useful to establish, here are
                                    7 habits that you do best to avoid. Just like finding habits that can be useful
                                    for you it’s important to find the habits that are holding you back. They can easily
                                    become such a normal, everyday part of life that you hardly notice it (or how it’s
                                    affecting you). </span> </div>
                                <div class="main_content_contact_title">
                                    Contact Details:</div>
                                <div class="main_content_contact_txt">
                                    <div class="contact_left_main">
                                        <div class="content_contact_left">
                                            Address1:
                                            <br />
                                            Address2:
                                            <br />
                                            Phone (home):<br />
                                            Phone (Cell):<br />
                                            Phone (Other):<br />
                                            Email Address1:<br />
                                            Email Address2:<br />
                                            Date of Birth:<br />
                                            SSN:</div>
                                    </div>
                                    <div class="contact_right_main">
                                        <div class="content_contact_right">
                                            <span runat="server" id="spaddress1"> 20 Prospect Ave, Hackensack, NJ 07601 </span> <br />
                                            <span runat="server" id="spaddress2"> 20 Prospect Ave, Hackensack, NJ 07601 </span> <br />
                                            <span runat="server" id="sptel1"> +234-345-6567 </span> <br />
                                            <span runat="server" id="sptel2"> +234-345-6567 </span> <br />
                                            <span runat="server" id="sptel3"> +234-345-6567 </span><br />
                                            <span runat="server" id="spemail1"> yasirdrabu@healthyes.com </span> <br />
                                            <span runat="server" id="spemail2"> y.drabu@gmail.com </span> <br />
                                            <span runat="server" id="spdob"> November 09, 1973 </span> <br />
                                            <span runat="server" id="spssn"> 758647264598 </span> </div>
                                    </div>
                                </div>
                                <div class="main_container_editbutton">
                                    <div class="main_content_editbutton">
                                        <a href="#">
                                            <img src="../Images/edit-button.gif" width="57" height="25" /></a></div>
                                </div>
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
                                    <asp:Image runat="server" ID="imgmyphto" ImageUrl="~/App/Images/my-photo.jpg" Height="107px" Width="150px" />
                                    <%--<img src="../Images/my-photo.jpg" width="150" height="107" />--%> </div>
                            </div>
                            <div class="right_frame_botbg">
                                <div class="right_frame_text">
                                    <span runat="server" id="spcaptname"> Dale W. Wood </span></div>
                            </div>
                        </div>
                        <div class="right_frame_main">
                            <div class="right_frame_topbg">
                                <img src="../Images/frame-topbg.gif" width="165" height="8" /></div>
                            <div class="right_frame_midbg">
                                <div class="right_frame_image">
                                    <asp:Image runat="server" ID="imgmyteam" ImageUrl="~/App/Images/my-team.jpg" Height="107px" Width="150px" />
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
        
        <div class="mainbody_outer_bottom">
            <uc1:ucimagelist ID="Ucimagelist1" runat="server" />
        </div>
        <%--<%# ResolveUrl("~/App/Images/my-team.jpg")%>
        <img src='<%# ResolveUrl("Images/my-team.jpg")%>' />
        <asp:Image runat="server" ID="Image1" ImageUrl="~/App/Images/my-team.jpg" Height="107px" Width="150px" />--%>
</asp:Content>

