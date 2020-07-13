<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_Technician_UploadLog"
    Title="Untitled Page" Codebehind="UploadLog.aspx.cs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script language="javascript" type="text/javascript">

    

    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                <div class="headingbox_top_body" style="width:753px;">
                    <span class="orngheadtxt_heading">Upload Log</span> 
                    <span class="headingright_default"><a href="ManageUploadedResult.aspx">Manage Current Uploads</a></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" alt="" width="700px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="../../Images/specer.gif" width="1px" alt="" height="1px" /></p>
                <p>
                    <img src="../../Images/specer.gif" width="700px" height="5px" /></p>
            </div>
            <div class="main_area_bdrnone">
                <div class="divmainbody_cd">
                    <div class="grayboxtop_cl">
                        <p class="grayboxtopbg_cl">
                            <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                        <p class="grayboxheader_cl">
                            Log Details</p>
                        <div class="lgtgraybox_cl">
                            <p>
                                <img src="../../Images/specer.gif" width="700px" height="5px" /></p>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletext_default">File Name: </span>
                                <span class="ttxtwidthnormal_default" id="spfilename" runat="server"> 104.Zip (14 MB) </span>
                                <span class="titletext_default">Uploaded By:</span> 
                                <span class="ttxtwidthnormalsmall_default" id="sptechname" runat="server"> </span>
                            </p>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletext_default">Uploaded Date: </span>
                                <span class="ttxtwidthnormal_default" runat="server" id="spuploaddate"> </span>
                                <span class="titletext_default">Uploaded Time:</span>
                                <span class="ttxtwidthnormalsmall_default" runat="server" id="spuploadtime"> </span>
                            </p>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletext_default">Event: </span>
                                <span class="ttxtnowidthnormal_default" runat="server" id="speventdetail">
                                    << Host Name >> , << Address >>, << City >>, << State >>, << Zip >> </span>
                            </p>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletext_default">Event Date: </span>
                                <span class="ttxtwidthnormal_default" runat="server" id="speventdate">
                                    << Date of Event >></span> 
                                <span class="titletextnowidth_default">Customers Screened:</span>
                                <span class="ttxtwidthnormalsmall_default" runat="server" id="spcustomertotal"><< Count >> </span>
                            </p>
                            <p class="lgtgrayboxrow_cl">
                                <span class="titletext_default">Status: </span><span class="ttxtnowidthnormal_default">
                                    <span class="greentxt_default"><b>Success (<span id="spsuccesspercentage" runat="server"> </span>%)</b>
                                    </span> &nbsp; /&nbsp;
                                    <span class="redtxt_default"><b>Failed (<span id="spfailedpercentage" runat="server"> </span>%)</b></span>
                                </span>
                            </p>
                            <p>
                                <img src="/App/Images/specer.gif" width="740px" height="20px" /></p>
                        </div>
                    </div>
                    <div>
                        <img src="/App/Images/specer.gif" width="740px" alt="" height="10px" /></div>
                                         
                    <div class="grayboxtop_cl" style="width:746px; float:left; padding:5px 0px 5px 0px;">
                        <asp:TextBox runat="server" ReadOnly="true" Rows="20" Width="740px" TextMode="MultiLine" ID="txtLogContent">
                        
                        </asp:TextBox>
                    </div>
                    
                </div>
            </div>
        </div>
    </div>
</asp:Content>
