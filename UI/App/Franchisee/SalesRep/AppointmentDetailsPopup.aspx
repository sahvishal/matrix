<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" AutoEventWireup="True" Inherits="App_Franchisee_SalesRep_AppointmentDetailsPopup" Codebehind="AppointmentDetailsPopup.aspx.cs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="msgbox_urm">
                            
                            <div class="msgboxrow_urm">
                                <div class="topbg_mbox_urm">
                                    <img src="../../Images/specer.gif" width="1px" height="1px" /></div>
                                <div class="midbg_mbox_urm">
                                    <p class="msgboxinnerrow_urm">
                                        <span class="headtxtmsgbox_urm">Appointment Details </span>
                                        <span class="closebtn_urm">
                                            <asp:ImageButton ID="ibtnClose" runat="server" ImageUrl="~/App/Images/close-button-symbol.gif" />
                                        </span>
                                    </p>
                                    <p class="graylinembox_urm">
                                        <img src="../../Images/specer.gif" width="1px" height="1px" /></p>
                                    <p>
                                        <img src="../../Images/specer.gif" height="5px" width="8px" /></p>
                                    <p class="msgboxinnerrow_urm">
                                        <span class="ttxtnowidthnormal_default">Start Time:</span> 
                                        <span class="inputfldnowidth_default"> <asp:TextBox ID="TextBox1" runat="server" CssClass="inputf_def" Width="60px"></asp:TextBox></span>
                                        <span class="ttxtnowidthnormal_default">&nbsp;&nbsp;End Time:</span>
                                        <span class="inputfldnowidth_default"> <asp:TextBox ID="TextBox2" runat="server" CssClass="inputf_def" Width="60px"></asp:TextBox></span>        
                                        
                                    </p>
                                    <p class="msgboxinnerrow_urm">
                                        <span class="ttxtnowidthnormal_default">Duration:&nbsp;&nbsp;&nbsp;</span> 
                                        <span class="inputfldnowidth_default"> <asp:TextBox ID="TextBox3" runat="server" CssClass="inputf_def" Width="60px"></asp:TextBox></span>
                                    </p>
                                    <p class="msgboxinnerrow_urm">
                                        <span class="buttoncon3_default">
                                            <asp:ImageButton ID="ibtnCancelTeam" runat="server" ImageUrl="~/App/Images/generate-btn.gif" /></span>
                                        </p>
                                </div>
                                <div class="botbg_mbox_urm">
                                    <img src="../../Images/specer.gif" width="1px" height="1px" /></div>
                            </div>
                        </div>
 
 </asp:Content>
