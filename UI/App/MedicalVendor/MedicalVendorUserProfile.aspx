<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master"
    AutoEventWireup="true" Inherits="MedicalVendor_MedicalVendorUserProfile" CodeBehind="MedicalVendorUserProfile.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/ucimagelist.ascx" TagName="ucimagelist" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Medical Vendor User Profile</span>
                    <span class="headingright_default"></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
            </div>
            <div class="main_area_bdr">
                <div class="main_content_area">
                    <div class="main_content_area_topbg">
                        <img alt="" src="../Images/maincontent-topbg.gif" width="563" height="4" /></div>
                    <div class="main_content_area_midbg">
                        <div class="main_content_area_inner">
                            <div class="main_content_name">
                                <span runat="server" id="name"></span>
                            </div>
                            <div class="main_content_designation">
                                <span runat="server" id="designation"></span>
                            </div>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    About Medical Vendor User</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Vendor Name:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="vendorname"></span><span class="titletext_profile">Specialization:</span>
                                <span class="inputfieldcon_profile" runat="server" id="specialization"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">First Name:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="fname"></span><span class="titletext_profile">Middle Name:</span>
                                <span class="inputfieldcon_profile" runat="server" id="mname"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Last Name:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="lname"></span><span class="titletext_profile">Date Applied:</span>
                                <span class="inputfieldcon_profile" runat="server" id="dateapplied"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Date of Birth:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="dob"></span><span class="titletext_profile">SSN:</span> <span
                                        class="inputfieldcon_profile" runat="server" id="ssn"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Clasification:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="classification"></span><span class="titletext_profile">Signature</span>
                                <span class="inputfieldcon_profile" runat="server" id="signature"><a id="aDwnSign"
                                    href="" runat="server" target="_blank">Download Signature</a> </span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Resume:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="resume"><a id="aDwnResume" runat="server" href="">Download Resume</a>
                                </span>
                            </p>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Contact Details</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address1:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="address1"></span><span class="titletext_profile">Phone(Home):</span>
                                <span class="inputfieldcon_profile" runat="server" id="phonehome"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address2:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="address2"></span><span class="titletext_profile">Phone(Cell):</span>
                                <span class="inputfieldcon_profile" runat="server" id="phonecell"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Country:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="country"></span><span class="titletext_profile">Phone(Other):</span>
                                <span class="inputfieldcon_profile" runat="server" id="phoneother"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">State:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="state"></span><span class="titletext_profile">Email:</span>
                                <span class="inputfieldcon_profile" runat="server" id="email1"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">City:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="city"></span><span class="titletext_profile">Other Email:</span>
                                <span class="inputfieldcon_profile" runat="server" id="email2"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Zip:</span> <span class="inputfieldcon_profile" runat="server"
                                    id="zip"></span>
                            </p>
                            <div style="visibility: hidden; display: none;">
                                <div class="headbg_box_profile">
                                    <div class="head_text_profile">
                                        References</div>
                                </div>
                                <p class="main_container_row_profile">
                                    <span class="titletext_profile">Name:</span> <span class="inputfieldcon_profile"
                                        runat="server" id="refname1"></span><span class="titletext_profile">Email:</span>
                                    <span class="inputfieldcon_profile" runat="server" id="refemail1"></span>
                                </p>
                                <p class="main_container_row_profile">
                                    <span class="titletext_profile">Name:</span> <span class="inputfieldcon_profile"
                                        runat="server" id="refname2"></span><span class="titletext_profile">Email:</span>
                                    <span class="inputfieldcon_profile" runat="server" id="refemail2"></span>
                                </p>
                                <p class="main_container_row_profile">
                                    <span class="titletext_profile">Name:</span> <span class="inputfieldcon_profile"
                                        runat="server" id="refname3"></span><span class="titletext_profile">Email:</span>
                                    <span class="inputfieldcon_profile" runat="server" id="refemail3"></span>
                                </p>
                            </div>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Payrate &amp; Permitted Tests</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Current Payrate:</span> 
                                <span id="CurrentPayrateSpan" runat="server" class="inputfieldcon_profile"></span>
                                <br />
                                <span class="titletext_profile">Permitted Tests</span>
                                <ul>
                                <asp:Repeater ID="PermittedTestsRepeater" runat="server">
                                    <ItemTemplate>
                                        <li style="float: none"><%# Eval("Name") %></li>
                                    </ItemTemplate>
                                </asp:Repeater>
                                </ul>
                            </p>
                        </div>
                    </div>
                    <div class="main_content_area_botbg">
                        <img alt="" src="../Images/maincontent-botbg.gif" width="563" height="6" /></div>
                </div>
                <div class="right_pannel_main">
                    <div class="right_frame_main">
                        <div class="right_frame_topbg">
                            <img alt="" src="../Images/frame-topbg.gif" width="165" height="8" /></div>
                        <div class="right_frame_midbg">
                            <div class="right_frame_image">
                                <asp:LinkButton runat="server" ID="lnkMyPhoto" CommandName="MyPhoto" OnClick="lnkPhoto_Click">
                                    <asp:Image runat="server" ID="imgmyphto" ImageUrl="~/App/Images/my-photo.jpg" Height="107px"
                                        Width="150px" /></asp:LinkButton>
                                <%--<img src="../Images/my-photo.jpg" width="150" height="107" />--%>
                            </div>
                        </div>
                        <div class="right_frame_botbg">
                            <div class="right_frame_text">
                                <span runat="server" id="myphoto">My Photo</span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="mainbody_outer_bottom">
                <uc1:ucimagelist ID="Ucimagelist1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="main_container_editbutton1" style="margin-top: 5px;">
        <div class="main_content_editbutton">
            <asp:ImageButton ID="ibtnedit" runat="server" CssClass="" ImageUrl="../Images/edit-button.gif"
                OnClick="ibtnedit_Click" /></div>
    </div>
    <div>
        <asp:Panel ID="Panel1" runat="server" CssClass="panelclass_imglist">
            <div style="width: 487px; background-color: Gray; float: left; text-align: right;
                padding-right: 3px; padding-top: 3px;">
                <asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>
            <div class="maindiv_imgp">
                <div class="innerdiv_imgp">
                    <img runat="server" id="imgLargeImage" src='' style="width: 460px; height: 250px;" />
                    <%--<div class="closediv_imgp"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>--%>
                </div>
            </div>
        </asp:Panel>
        <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lnktemphidden"
            PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="ibtnclosesymbol" />
        <asp:LinkButton ID="lnktemphidden" runat="server" Visible="true"></asp:LinkButton>
    </div>
</asp:Content>
