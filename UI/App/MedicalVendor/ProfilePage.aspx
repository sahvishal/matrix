<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master" AutoEventWireup="true" Inherits="App_MedicalVendor_ProfilePage" Title="Untitled Page" Codebehind="ProfilePage.aspx.cs" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Src="~/App/UCCommon/ucimagelist.ascx" TagName="ucimagelist" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <script language="javascript" type="text/javascript">
<!--

function IMG1_onclick() {

}

// -->
    </script>

    <%--  <asp:ScriptManager runat="server" id="ScManager">
    </asp:ScriptManager>--%>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
        
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p><img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Medical Vendor Profile</span>
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
                            <div class="main_content_designation">
                                <span runat="server" id="dvRole">Manager </span>
                            </div>
                            <div class="main_content_about_profile" runat="server" id="dvDescription" style="display:none;">
                            </div>
                            <div class="main_content_about_txt">
                                <span runat="server" id="spabtfrnch"></span>
                            </div>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Business Address</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address1:</span> <span class="inputfieldcon_profile"
                                    runat="server" id="spBAddress1"></span><span class="titletext_profile">Business Phone:</span>
                                <span class="inputfieldcon_profile" id="spBPhone" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address2:</span> <span class="inputfieldcon_profile"
                                    id="spBAddress2" runat="server"></span><span class="titletext_profile">Business Fax:</span>
                                <span class="inputfieldcon_profile" id="spBFax" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Country:</span> <span class="inputfieldcon_profile"
                                    id="spBCountry" runat="server"></span><span class="titletext_profile">Vendor Type:</span>
                                <span class="inputfieldcon_profile" id="spBVendorType" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">State:</span> <span class="inputfieldcon_profile"
                                    id="spBState" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">City:</span> <span class="inputfieldcon_profile"
                                    id="spBCity" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Zip:</span> <span class="inputfieldcon_profile" id="spBZip"
                                    runat="server"></span>
                            </p>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Primary Contact Details</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">First Name:</span> <span class="inputfieldcon_profile"
                                    id="spFname" runat="server"></span><span class="titletext_profile">Middle Name:</span>
                                <span class="inputfieldcon_profile" id="spMname" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Last Name:</span> <span class="inputfieldcon_profile"
                                    id="spLname" runat="server"></span><span class="titletext_profile">Specialization:</span>
                                <span class="inputfieldcon_profile" id="spSpecialization" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Date Of Birth:</span> <span class="inputfieldcon_profile"
                                    id="spDOB" runat="server"></span><span class="titletext_profile">SSN:</span>
                                <span class="inputfieldcon_profile" id="spSSN" runat="server"></span>
                            </p>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Primary Contact Address Details</div>
                            </div>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address1:</span> <span class="inputfieldcon_profile"
                                    id="spAddress1" runat="server"></span><span class="titletext_profile">Phone(Home):</span>
                                <span class="inputfieldcon_profile" id="spPhoneHome" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Address2:</span> <span class="inputfieldcon_profile"
                                    id="spAddress2" runat="server"></span><span class="titletext_profile">Phone(Cell):</span>
                                <span class="inputfieldcon_profile" id="spPhoneCell" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Country:</span> <span class="inputfieldcon_profile"
                                    id="spCountry" runat="server"></span><span class="titletext_profile">Phone(Other):</span>
                                <span class="inputfieldcon_profile" id="spPhoneOther" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">State:</span> <span class="inputfieldcon_profile"
                                    id="spState" runat="server"></span><span class="titletext_profile">Email:</span>
                                <span class="inputfieldcon_profile" id="spEmail1" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">City:</span> <span class="inputfieldcon_profile"
                                    id="spCity" runat="server"></span><span class="titletext_profile">Other Email:</span>
                                <span runat="server" class="inputfieldcon_profile" id="spEmail2"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Zip:</span> <span class="inputfieldcon_profile" runat="server"
                                    id="spZip"></span>
                            </p>
                            <div class="headbg_box_profile">
                                <div class="head_text_profile">
                                    Other Details</div>
                            </div>
                            <p class="main_container_row_profile">
                                <%--<span class="titletext_profile">My Signature:</span>
                <span class="inputfieldcon_profile" id="spSignature" runat="server">----</span>--%>
                                <span class="titletext_profile">Contract:</span> <span class="inputfieldcon_profile"
                                    id="spContract" runat="server"></span><span class="titletext_profile">Payment Interval:</span>
                                <span id="spPayInterval" class="inputfieldcon_profile" runat="server"></span>
                            </p>
                            <p class="main_container_row_profile">
                                <span class="titletext_profile">Payment Mode:</span> <span id="spPayMode" class="inputfieldcon_profile"
                                    runat="server"></span>
                            </p>
                            <%--<div class="main_container_editbutton">
                <div class="main_content_editbutton">
                <a href="UpdateFranchisorData.aspx?IsEdit=true">
                <img src="../Images/edit-button.gif" width="57" height="25" /></a></div>
                </div>--%>
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
                                <asp:LinkButton runat="server" ID="lnkMyPhoto" CommandName="MyPhoto" OnClick="lnkPhoto_Click">
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
                                    Width="150px" />
                                <%--<img src="../Images/my-team.jpg" width="150" height="107" />--%>
                         </asp:LinkButton>   </div>
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
        <uc1:ucimagelist ID="ucOtherPhoto" runat="server"></uc1:ucimagelist>
    </div>
    <div class="main_container_editbutton1">
        <div class="main_content_editbutton">
            <a href="UpdateMVData.aspx?IsEdit=true">
                <img src="../Images/edit-button.gif" width="57" height="25" id="imgEdit" runat="server" /></a></div>
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
