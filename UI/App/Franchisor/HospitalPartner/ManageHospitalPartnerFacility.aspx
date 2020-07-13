<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    CodeBehind="ManageHospitalPartnerFacility.aspx.cs" Inherits="HealthYes.Web.App.Franchisor.ManageHospitalPartnerFacility" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script type="text/javascript" language="javascript">
    String.prototype.trim = function() { return this.replace(/^\s+|\s+$/, ''); };
    function validateSearch()
    {
        var txtHPFacility=document.getElementById("<%=this.txtHPFacility.ClientID %>");
        if(txtHPFacility.value.trim()=="")
        {
            alert("Please enter Facility Name to search.");
            return false;
        }
    }
</script>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="sptitle" runat="server">Manage Hospital Partner
                        Facility</span> <span class="headingright_default"><a href="AddHospitalFacility.aspx"
                            id="aAddHospitalFacility">+ Add new Facilities </a></span>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            </div>
            <div class="grayboxtop_cl">
                <p class="grayboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="6" alt="" /></p>
                <p class="grayboxheader_cl">
                    <span style="float: left">Filter/Search</span></p>
                <div class="lgtgraybox_cl">
                    <p class="lgtgrayboxrow_cl" style="padding-top: 10px;">
                        <span class="titletextnowidth_default">Facility Name:</span> <span class="inputfldnowidth_default">
                            <asp:TextBox ID="txtHPFacility" runat="server" CssClass="inputf_def" Width="200px"></asp:TextBox>
                        </span><span class="button_con_nowidth">
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif" OnClientClick="return validateSearch();" OnClick="ibtnSearch_Click" />
                        </span>
                        <p class="lgtgrayboxrow_cl">
                            <img src="/App/Images/specer.gif" width="10" height="6" alt="" /></p>
                    </p>
                </div>
                <p class="grayboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="4" /></p>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="10px" /></p>
            <div class="divmainbody_cd">
                <span class="blkheadtxt_regcust" id="Span1" runat="server" style="float: left;">Total:</span>
                <span class="blueheadtxt_regcust" id="Span2" runat="server" style="float: left;">10 Results Found</span>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="750px" height="5px" /></p>
            <div style="float: left; width: 746px" id="divGrd" runat="server">
                <p class="blueboxtopbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" /></p>
                <div style="float: left; width: 746px">
                    <asp:GridView runat="server" ID="grdhospitalpartner" AutoGenerateColumns="False"
                        CssClass="divgrid_cl" GridLines="None" AllowPaging="True" PageSize="10" 
                        onpageindexchanging="grdhospitalpartner_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="Facility Info">
                                <ItemTemplate>
                                    <span style="font-weight:bold;"><%#DataBinder.Eval(Container.DataItem, "FacilityName")%></span>
                                    <br />
                                    <%#DataBinder.Eval(Container.DataItem,"Address") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MedicalVendor" HeaderText="Hospital Partner"></asp:BoundField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <a href='AddHospitalFacility.aspx?FacilityID=<%#DataBinder.Eval(Container.DataItem,"FacilityID") %>'>Edit</a>
                                    &nbsp;|&nbsp; 
                                    <asp:LinkButton ID="lnkDeleteHF" runat="server" Text="Delete" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"FacilityID") %>' OnClientClick="return confirm('Are you sure to delete this facility?');" onclick="lnkDeleteHF_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="row2" />
                        <HeaderStyle CssClass="row1" />
                        <AlternatingRowStyle CssClass="row3" />
                    </asp:GridView>
                </div>
                <p class="blueboxbotbg_cl">
                    <img src="/App/Images/specer.gif" width="746" height="5" /></p>
            </div>
        </div>
    </div>
</asp:Content>
