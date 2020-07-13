<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="True" Inherits="Franchisor_UploadProspect" Title="Upload Prospects"
    CodeBehind="UploadProspect.aspx.cs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .mainbody_outer_u_prospects
        {
            float: right;
            width: 777px;
            background-color: #fff;
            margin-top: 5px;
        }
        .mainbody_inner_u_prospects
        {
            width: 763px;
            margin-left: 14px;
            margin-bottom: 5px;
        }
        .main_area_bdr_u_prospects
        {
            float: left;
            width: 751px;
            border: 1px solid #E5E5E5;
            margin-top: 5px;
            margin-bottom: 5px;
        }
        .main_container_row_u_prospects
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 3px;
            padding-right: 5px;
            padding-bottom: 3px;
        }
        .main_container_rowtop_u_prospects
        {
            float: left;
            width: 734px;
            padding-left: 10px;
            padding-top: 8px;
            padding-right: 5px;
            padding-bottom: 10px;
        }
        .normaltxt_u_prospects
        {
            font: bold 12px arial;
            color: #333;
        }
        .normaltxt_u_prospects a:link
        {
            font: normal 12px arial;
            color: #287AA8;
            text-decoration: underline;
        }
        .normaltxt_u_prospects a:visited
        {
            font: normal 12px arial;
            color: #287AA8;
            text-decoration: underline;
        }
        .normaltxt_u_prospects a:hover
        {
            font: normal 12px arial;
            color: #FF6600;
            text-decoration: underline;
        }
        .uploadbox_u_prospects
        {
            float: left;
            width: 740px;
            padding-top: 5px;
            padding-bottom: 10px;
        }
        .uploadbox2_u_prospects
        {
            float: left;
            width: 740px;
            padding-bottom: 10px;
        }
        .uploadtxt_u_prospects
        {
            float: left;
            font: bold 12px arial;
            color: #000000;
            padding-top: 5px;
            padding-left: 10px;
            padding-right: 5px;
        }
        .uploatxtbox_u_prospects
        {
            float: left;
            width: 150px;
        }
        .inputf_u_prospects
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .buttonb_u_prospects_browse
        {
            float: left;
            padding-left: 5px;
        }
        .buttonb_u_prospects
        {
            float: right;
            padding-right: 10px;
        }
        .uploadbutt_u_prospects
        {
            float: left;
            font: bold 12px arial;
            color: #000000;
            padding-left: 138px;
            margin-top: 5px;
            width: 550px;
        }
        .franchisees_u_prospects
        {
            float: left;
            font: bold 12px arial;
            color: #000000;
            padding-left: 25px;
            padding-top: 20px;
            width: 122px;
            margin-bottom: 5px;
        }
        .buttonfs_u_prospects
        {
            float: left;
            padding-left: 10px;
            padding-top: 15px;
            padding-bottom: 30px;
        }
        .leftbox_u_prospects
        {
            float: left;
            width: 306px;
            border: 1px solid #E5E5E5;
            margin: 15px;
        }
        .selectfranchisee_u_prospects
        {
            float: left;
            font: bold 12px arial;
            color: #333333;
            padding-top: 5px;
            width: 700px;
            padding-bottom: 5px;
        }
        .buttonsf_u_prospects
        {
            float: left;
            padding-left: 10px;
            padding-bottom: 10px;
        }
        .headbg_boxu_prospects
        {
            float: left;
            width: 753px;
            background-color: #E1F1F8;
            height: 24px;
            margin-bottom: 3px;
        }
        .head_textu_prospects
        {
            float: left;
            width: 740px;
            padding-left: 10px;
            padding-top: 5px;
            padding-bottom: 5px;
            font: bold 12px arial;
            color: #000000;
        }
        .selectalllnk_up
        {
            float: left;
            width: 201px;
            font: normal 12px arial;
            color: #000000;
            padding-left: 10px;
            padding-top: 30px;
            padding-bottom: 5px;
        }
        .divmaingrids_up
        {
            float: left;
            width: 701px;
            padding: 5px 5px 5px 10px;
        }
        .divgridlistname_up
        {
            float: left;
            width: 234px;
            border-style: none;
            margin-bottom: 5px;
            padding: 5px 5px 5px 10px;
        }
        .gridlistname_up
        {
            float: left;
            width: 234px;
            border-style: none;
        }
        .headerlistnamedefault
        {
            float: left;
            width: 234px;
            font: bold 12px arial;
            color: #000000;
            border: 2px solid #fff;
            background-color: #CEE1F4;
        }
        .headerchkboxlname_up
        {
            float: left;
            width: 24px;
            border-right: 2px solid #fff;
            height: 22px;
            padding-left: 4px;
        }
        .itemchkboxlname_up
        {
            float: left;
            width: 24px;
            border-right: 2px solid #fff;
            height: 22px;
            padding-left: 4px;
        }
        .headerlinstname_up
        {
            float: left;
            width: 195px;
            height: 22px;
            padding-left: 4px;
        }
        .itemslinstname_up
        {
            float: left;
            width: 195px;
            height: 22px;
            padding-left: 4px;
        }
        .itemlistnamedefault
        {
            float: left;
            width: 234px;
            font: normal 12px arial;
            color: #000000;
            border: 2px solid #fff;
            background-color: #EBEBEB;
        }
        .altitemlistnamedefault
        {
            float: left;
            width: 234px;
            font: normal 12px arial;
            color: #000000;
            border: 2px solid #fff;
            background-color: #F7F7F7;
        }
        .divgridfranchiseename_up
        {
            float: left;
            width: 504px;
            border-style: none;
            padding: 5px 5px 5px 10px;
        }
        .gridfranchiseename_up
        {
            float: left;
            width: 504px;
            border-style: none;
        }
        .headerfranchiseenamedefault
        {
            float: left;
            width: 500px;
            border: 2px solid #fff;
            font: bold 12px arial;
            color: #000000;
            background-color: #CEE1F4;
        }
        .headerchkboxfname_up
        {
            float: left;
            width: 24px;
            border-right: 2px solid #fff;
            height: 22px;
            padding-left: 4px;
        }
        .itemchkboxfname_up
        {
            float: left;
            width: 24px;
            border-right: 2px solid #fff;
            height: 22px;
            padding-left: 4px;
        }
        .headerfranchiseename_up
        {
            float: left;
            width: 127px;
            height: 22px;
            padding-left: 4px;
            border-right: 2px solid #fff;
        }
        .itemsfranchiseename_up
        {
            float: left;
            width: 127px;
            height: 22px;
            padding-left: 4px;
            border-right: 2px solid #fff;
        }
        .headerfranchiseeadd_up
        {
            float: left;
            width: 210px;
            height: 22px;
            border-right: 2px solid #fff;
            padding-left: 4px;
        }
        .itemsfranchiseeadd_up
        {
            float: left;
            width: 210px;
            height: 22px;
            border-right: 2px solid #fff;
            padding-left: 4px;
        }
        .headerfranchiseeph_up
        {
            float: left;
            width: 101px;
            height: 22px;
            padding-left: 4px;
        }
        .itemsfranchiseeph_up
        {
            float: left;
            width: 101px;
            height: 22px;
            padding-left: 4px;
        }
        .itemfranchiseenamedefault
        {
            float: left;
            width: 500px;
            border: 2px solid #fff;
            font: normal 12px arial;
            color: #000000;
            background-color: #EBEBEB;
        }
        .altitemfranchiseenamedefault
        {
            float: left;
            width: 500px;
            border: 2px solid #fff;
            font: normal 12px arial;
            color: #000000;
            background-color: #F7F7F7;
        }
        .save_button_u_prospects
        {
            float: right;
            width: 56px;
            height: 32px;
            margin-bottom: 10px;
            padding-right: 14px;
        }
        .clear_button_u_prospects
        {
            float: left;
            width: 200px;
            height: 32px;
            padding-left: 5px;
            margin-bottom: 10px;
        }
    </style>
    <style type="text/css">
        .inputfield140pxleft_cnp
        {
            float: left;
            width: 280px;
            margin-right: 150px;
            font: bold 12px arial;
            color: #333;
        }
        .inputfield140pxrgt_cnp
        {
            float: left;
            width: 280px;
            font: bold 12px arial;
            color: #333;
        }
    </style>

    <script language="javascript" type="text/javascript">

        function ValidateInputs() {
            var txtFileName = document.getElementById("<%= this.txtListName.ClientID %>");
            if (isBlank(txtFileName, "List name"))
            { return false; }

            var txtFileUpload = document.getElementById("<%= this.FileUpload1.ClientID %>");
            if (txtFileUpload.value == '') {
                alert("Please browse a file to upload");
                txtFileUpload.focus();
                return false;
            }


            var ddlSalesPerson = document.getElementById("<%= this.ddlSalesPerson.ClientID %>");

            //   var sindex = document.getElementById("<%= this.ddlListType.ClientID %>").selectedIndex;
            //   var selected_text = document.getElementById("<%= this.ddlListType.ClientID %>").options[sindex].text;
            //    
            //   if (selected_text=='Host Prospect')
            //   {
            //        if (isBlank(txtFileUpload,"Assigned To"))
            //             {return false;}
            //   }
        }

        function ChangeProspectList() {
            var hidRole = document.getElementById("<%= this.hidRole.ClientID %>");
            var spnFranchiess = document.getElementById("<%= this.spnFranchiess.ClientID %>");
            var ddlSalesPerson = document.getElementById("<%= this.ddlSalesPerson.ClientID %>");
            var lnkSampleUpladFile = document.getElementById("<%= this.lnkSampleUpladFile.ClientID %>");

            var sindex = document.getElementById("<%= this.ddlListType.ClientID %>").selectedIndex;
            var selected_text = document.getElementById("<%= this.ddlListType.ClientID %>").options[sindex].text;

            if (hidRole.value != 'SalesRep') {
                if (selected_text == 'Host Prospect') {
                    spnFranchiess.style.display = 'block';
                    ddlSalesPerson.style.display = 'block';
                    lnkSampleUpladFile.href = '/App/Franchisor/ProspectSample.csv';
                }
                else {
                    spnFranchiess.style.display = 'none';
                    ddlSalesPerson.style.display = 'none';
                    lnkSampleUpladFile.href = '/App/Franchisor/ProspectCustomerSample.csv';
                }
            }
        }

    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" alt="" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Create Prospect List</span>
                    <span class="headingright_default">
                        <asp:LinkButton ID="lnkManageProspectList" runat="server" Text="+Manage Prospect List"
                            OnClick="lnkManageProspectList_Click" /></span> <span class="headingright_default">
                    </span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" alt="" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" alt="" /></p>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" alt="" /></p>
            </div>
            <%--Error  Div--%>
            <div class="maindivredmsgbox" id="errordiv" runat="server" style="display: none;
                margin-bottom: 5px;">
            </div>
            <div class="main_area_bdrnone">
                <span class="graybold12_default">Here you can upload a file of Pipe Delimited/Separate Values (CSV) for prospects. Please see the instructions below for Upload process.</span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="10px" alt="" /></p>
            <div class="main_area_bdrnone">
                <asp:Panel ID="pnlUpload" runat="server" DefaultButton="ibtnPreviewUpload">
                    <p class="main_container_row_default">
                        <span class="orngbold16_default" id="spnInnerTitle" runat="server">STEP 1: Upload Prospect
                            List </span>
                    </p>
                    <p class="main_container_row_default">
                        <span class="inputfield140pxleft_cnp">List Name:<span class="reqiredmark"><sup>*</sup></span>
                            <asp:TextBox ID="txtListName" runat="server" CssClass="inputf_def" Width="280px"></asp:TextBox>
                        </span><span class="inputfield140pxrgt_cnp">List Source:
                            <asp:TextBox ID="txtListSource" runat="server" CssClass="inputf_def" Width="280px"></asp:TextBox>
                        </span>
                    </p>
                    <p class="main_container_row_default">
                        <span class="inputfield140pxleft_cnp">List Type:
                            <asp:DropDownList ID="ddlListType" runat="server" CssClass="inputf_def" Width="285px">
                            </asp:DropDownList>
                        </span><span class="inputfield140pxrgt_cnp">File/CSV (Max Size 5MB):<span class="reqiredmark"><sup>*</sup></span>
                            <asp:FileUpload ID="FileUpload1" runat="server" size="38px" CssClass="inputf_def"
                                Width="285px" />
                        </span>
                    </p>
                    <p class="main_container_row_default">
                        <span class="inputfield140pxleft_cnp"><span class="inputfield140pxleft_cnp" id="spnFranchiess"
                            runat="server">Franchisee:</span> <span class="inputfield140pxleft_cnp">
                                <asp:DropDownList ID="ddlSalesPerson" runat="server" Width="200px">
                                </asp:DropDownList>
                            </span></span>
                    </p>
                    <p class="main_container_row_default" style="margin-top: 5px;">
                        <span class="buttoncon4_default">
                            <asp:ImageButton ID="ibtnPreviewUpload" runat="server" ImageUrl="~/App/Images/preview-upload-btn.gif"
                                OnClick="ibtnPreviewUpload_Click" OnClientClick="return ValidateInputs()" /></span>
                        <span class="buttoncon_default">
                            <asp:ImageButton ID="ibtnCancel" runat="server" ImageUrl="~/App/Images/cancel-button.gif"
                                OnClick="ibtnCancel_Click" />
                        </span>
                    </p>
                    <div class="main_container_row_default">
                        <img src="/App/Images/specer.gif" alt="" width="2px" height="5px" /></div>
                    <div class="lgtgraybox_cl">
                        <div class="blueboxtopbg_ur">
                            <img src="/App/Images/specer.gif" alt="" width="746px" height="6px" /></div>
                        <div class="instructiontxt_ur">
                            <p class="lgtgrayboxrow_cl">
                                <span class="blktextbig_default">Upload Instructions:</span></p>
                            <div class="lgtgrayboxrow_cl">
                                <table>
                                    <tr>
                                        <td valign="top">
                                            1.
                                        </td>
                                        <td valign="top">
                                            Please Make sure the format of the CSV is similar to sample file (View sample <a href="/App/Franchisor/ProspectSample.csv"  id="lnkSampleUpladFile" runat="server">CSV</a> file). 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            2.
                                        </td>
                                        <td valign="top">
                                            After you click on “Preview Upload“, you will get a chance to review the uploaded file and you can proceed or opt out – by pressing cancel. 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            3.
                                        </td>
                                        <td valign="top">
                                            Based on contact role, primary/secondary contact will be created for the prospect. 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            4.
                                        </td>
                                        <td valign="top">
                                            If a territory is assigned to the sales rep, she can see the prospects which fall within the assigned territory.
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <div class="blueboxbotbg_cl">
                            <img src="/App/Images/specer.gif" width="746px" alt="" height="6px" /></div>
                    </div>
                    <div class="main_container_row_default">
                        <img src="/App/Images/specer.gif" width="2px" alt="" height="20px" /></div>
                </asp:Panel>
            </div>
        </div>
    </div>
    <input type="hidden" id="hidRole" runat="server" />
</asp:Content>
