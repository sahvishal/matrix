<%@ Page Language="C#" MasterPageFile="~/App/MedicalVendor/MedicalVendorMaster.master"
 AutoEventWireup="true" Inherits="App_MedicalVendor_CustomerMedicalHistory" Codebehind="CustomerMedicalHistory.aspx.cs" %>
<%@ Register Src="../UCCommon/ucMedicalHistory.ascx" TagName="ucMedicalHistory" TagPrefix="uc1" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

   <div class="mainbody_outer_ecl">
        <div class="mainbody_inner_ecl">
        <div class="main_area_bdrnone">
        <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700" height="5" /></p>
                    <span class="orngheadtxt_heading">Health Assessment 
                    </span>
                </div>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="700" height="2" /></p>
            <p class="graylinefull_common">
                <img src="/App/Images/specer.gif" width="1" height="1" /></p>
            <p>
                <img src="/App/Images/specer.gif" width="700" height="5" /></p>
            
            <div class="main_area_bdr_ecl">
                <div class="main_content_area_ecl">
                    <uc1:ucMedicalHistory ID="UcMedicalHistory1" runat="server" />
                </div>
            </div>
            
            <div class="headbg2_box_editp">
                <div class="save_button_editp">
                    <asp:ImageButton ID="ibtnsave" runat="server" ImageUrl="/App/Images/save-button.gif" OnClientClick="return saveData();" OnClick="ibtnsave_Click" />
                </div>
                <div class="cancel_button_editp">
                    <asp:ImageButton ID="ibtncancel" runat="server" ImageUrl="/App/Images/cancel-button.gif" OnClick="ibtncancel_Click" />
                </div>
            </div>
            
        </div>
    </div>

    <script language="javascript" type="text/javascript">

        $(document).ready(function () { getHealthAssesmentForm('<%= CustomerId %>'); });

        function saveData() {
            if (dataSaveFired) return true;

            saveHealthAssesmentForm(function () {
                dataSaveFired = true;
                $("#<%= ibtnsave.ClientID %>").click();
            });

            return false;
        }

        var dataSaveFired = false;

    </script>
   
</asp:Content>