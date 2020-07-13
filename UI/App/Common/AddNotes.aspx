<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="App_Common_AddNotes" CodeBehind="AddNotes.aspx.cs" %>
<%@ Register Src="~/App/UCCommon/UcEventRegistrationSummary.ascx" TagName="EventDetail" TagPrefix="UC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">
        function DeleteCofirmation() {
            if (confirm('Are you sure you want to delete this note?'))
            { return true }
            else
            { return false }
        }

        function EditCofirmation() {
            if (confirm('Are you sure you want to edit this note?'))
            { return true }
            else
            { return false }
        }
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
			<h1 runat="server" id="dvTitle" class="left">Cancel Appointments</h1>            
            <div class="main_area_bdr">
            <div  class="welcomemsgbox_addnotes" >
            <UC:EventDetail ID="_eventDetail" runat="server" />   
            </div>        
                <p>
                    <img src="../Images/specer.gif" width="700px" height="10px" /></p>
                <p class="main_container_row_default">
                    <span class="orngbold16_default">Add Notes</span></p>
                <div style="border-bottom: solid 1px #E5E5E5; float: left;">
                    <p class="main_container_row_default">
                        <span class="titletextsmallbold_default">Notes:</span> <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtnotes" runat="server" TextMode="MultiLine" Rows="5" CssClass="inputf_def"
                                Text="" Width="645px"></asp:TextBox></span>
                    </p>
                    <p>
                        <img src="../Images/specer.gif" width="700px" height="5px" /></p>
                <p>
                    <img src="../Images/specer.gif" width="700px" height="10px" /></p>
                <p class="main_container_row_default">
                    <span class="buttoncon_default">
                        <asp:ImageButton runat="server" ID="ImgBtnFinish" ImageUrl="~/App/Images/finish-button.gif"
                            OnClick="ImgBtnFinish_Click" />
                    </span>
                </p>
            </div>
            <p>
                <img src="../Images/specer.gif" width="700px" height="5px" /></p>
        </div>
    </div>
    <asp:HiddenField ID="hfCustNotesID" Value="0" runat="server" />
</asp:Content>
