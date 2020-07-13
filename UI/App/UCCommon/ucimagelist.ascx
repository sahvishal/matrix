<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucimagelist" Codebehind="ucimagelist.ascx.cs" %>

 <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>

    <div class="mainbody_inner_bottom" style="margin-bottom:0px">
    
        <div class="mainbody_inner_left">
        </div>
        <div class="mainbody_inner_mid_bot">
            Other Photos</div>
        <div class="mainbody_inner_right">
        </div>
        
        <div class="main_area_bdrbottom">
            <div class="main_area_bottom">
            
                <asp:DataList runat="server" ID="lstotherphotos" RepeatColumns="6" RepeatDirection="horizontal" CssClass="listotherphotosUC">
                    <ItemTemplate>
                    
                        <div class="photo_frame_main">  
                            <div class="photo_frame_topbg"> <img src="/App/Images/photoframe_topbg.gif" /></div><div class="photo_frame_midbg"><div class="photo_frame_image">
                              <asp:LinkButton runat="server" id="imgClick" OnClick="imgClick_Click"> <img runat="server" id="image1" src='<%# this.ResolveUrl(DataBinder.Eval(Container.DataItem, "Image").ToString()) %>' style="width:90px; height:57px;" /></asp:LinkButton>
                            </div></div>
                            <div class="photo_frame_botbg">
                                <div class="photo_frame_text"></div>
                            </div>
                        </div>
                    
                    </ItemTemplate>
                    <AlternatingItemStyle CssClass="defitemstylelstotherphotosUC" />
                    <ItemStyle CssClass="defitemstylelstotherphotosUC" />
                </asp:DataList>
            
                
                <div class="previous_maincontainer">
                    <div class="previous_text">
                        <asp:LinkButton runat="server" ID="lnkprevious" Enabled="false" Text="<< Previous" OnClick="lnknavigation_Click" CommandName="Navigation" CommandArgument="P"></asp:LinkButton>
                    </div>
                    <div class="next_maincontainer">
                        <div class="next_text">
                            <asp:LinkButton Text="Next >>" runat="server" ID="lnknext" OnClick="lnknavigation_Click" CommandName="Navigation" CommandArgument="N"> </asp:LinkButton> </div>
                    </div>
                    
                  <%--  <div class="uploadbutton_maincontainer">
                        <div class="upload_button_maincontainer">
                            <div class="upload_button">
                                <div class="upload_buttontext">
                                    <a href="../common/popup-uploadphoto.htm" onmousedown="MM_openBrWindow('../common/popup-uploadphoto.htm','photos','width=350,height=150')">
                                        Upload Photos </a>
                                </div>
                            </div>
                        </div>
                    </div>--%>
                    
                </div>
                
                <asp:Panel ID="Panel1" runat="server" CssClass="panelclass_imglist"  >
                    <div class="maindiv_imgp">        <div class="innerdiv_imgp">    <img runat="server" id="imgLargeImage" src='' style="width:470px; height:250px;" />    <%--<div class="closediv_imgp"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>--%>
                   
                    </div>
                    </div>
                </asp:Panel>
                
                <ajaxtoolkit:modalpopupextender id="ModalPopupExtender" runat="server" targetcontrolid="lnktemphidden"
                popupcontrolid="Panel1" backgroundcssclass="modalBackground" cancelcontrolid="ibtnclosesymbol" />
                
                <ajaxtoolkit:modalpopupextender id="ModalPopupExtender1" runat="server" targetcontrolid="LinkButton1"
                popupcontrolid="Panel2" backgroundcssclass="modalBackground" X="0" Y="0" cancelcontrolid="ibtnclosesymbol" />
                
                <asp:Panel ID="Panel2" runat="server" CssClass="top_panel_bar" >
                <div style="float:right; padding-right:3px; padding-top:3px;"><asp:ImageButton ID="ibtnclosesymbol" runat="server" CssClass="" ImageUrl="~/App/Images/close-button-symbol.gif" /></div>
                </asp:Panel>
                
            </div>
             <asp:LinkButton ID="lnktemphidden" runat="server" Visible="true"></asp:LinkButton>
             <asp:LinkButton ID="LinkButton1" runat="server" Visible="true"></asp:LinkButton>
        </div>
    </div>
<script language="javascript" type="text/javascript" src="/App/JavascriptFiles/wz_tooltip.js"></script>   
