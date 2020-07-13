<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Customer/CustomerMaster.master"
    CodeBehind="MyTestimony.aspx.cs" Inherits="Falcon.App.UI.App.Customer.MyTestimony"
    Title="My Testimony" %>
<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.Core.Interfaces" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Register Src="~/App/UCCommon/UCCustomerLeftInfo.ascx" TagName="CustomerUC" TagPrefix="CustLeft" %>
<%@ Register Src="~/App/UCCommon/Message.ascx" TagName="messages" TagPrefix="messagecontrol" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"/>
    <script language="javascript" type="text/javascript">
        function TestimonialTextValidation()
        { 
            var testimonialText = document.getElementById("<%=_testimonialText.ClientID %>");
            if (testimonialText.value == "")
            {
                alert("Please enter testimonial text.");
                return false;
            }
            return true;
        }
        
        function TestimonialVideoValidation()
        { 
            var uploadVedio = document.getElementById("<%=_uploadVedio.ClientID %>");
            if (uploadVedio.value=="")
            {
                alert("Please select a video to upload.");
                return false;
            }
            if(!ValidateVideoFile(uploadVedio.value))
            {
                alert("Please select a valid video file to upload.");
                return false;
            }
            
            return true;
        }
        
        function ValidateVideoFile(filePath)
        {
            var parts = filePath.split('.'); 
            var fileExtension= parts[parts.length-1];
            
            var videoFileExtensionArray=new Array("3g2","3gp","asf","asx","avi","flv","mov","mp4","mpg","rm","swf","vob","wmv");
            
            var isValidVideoFile = false;
            for(var count=0; count<videoFileExtensionArray.length; count++)
            {
                if(videoFileExtensionArray[count]==fileExtension.toLowerCase())
                {
                    isValidVideoFile= true;
                    break;
                }
            }
            return isValidVideoFile;
        }
        
        function GetFileSize(filePath)
        {
            
	        alert(size + " bytes");
	        return size;
        }
        function ClearTestimonialText()
        {
            document.getElementById("<%=_testimonialText.ClientID %>").text="";
            return false;
        }
    </script>

    <div class="maindiv_custdbrd">
        <div class="mindivbgblue_custdbrd">
            <span class="divheadtxt_custdbrd"><%= IoC.Resolve<ISettings>().CompanyName %><sup>&reg;</sup> Wellness Dashboard</span>
            <div class="wrapper_llb" id="divLastLogin" runat="server" style="margin-top: 2px">
                <div class="wrapperin_llb">
                    <div>
                        <span id="spLastLogin" runat="server">Last login time</span></div>
                </div>
            </div>
        </div>
        <div id="Div1" class="leftcon_main_custdbrd" style="margin-bottom: 5px">
            <CustLeft:CustomerUC ID="uc1" runat="server" OnLoad="SetName" />
        </div>
        <div class="wrapper_inpg">
            <h1>
                My Testimony</h1>
            <div class="hr">
            </div>
            <div id="_divMessage" runat="server" style="display: none">
                <messagecontrol:messages ID="_messageControl" runat="server" />
            </div>
            <div class="tesimny_row" style="margin: 0">
                <div class="testimony_bg">
                    Testimonials</div>
                <div class="testimony_txt">
                    are a key ingredient to educating the public about underlying asymptomatic disease,
                    and how <%= IoC.Resolve<ISettings>().CompanyName %><sup>&reg;</sup> Screenings can help detect risk factors.
                </div>
            </div>
            <div class="tesimny_row mt_medium">
                <h3>
                    Please take a moment to submit either:
                </h3>
                <div class="type_tstimny">
                    <img src="/App/Images/headerfname_arrow.gif" alt="" />
                    <span class="txt">Written Testimonial </span>
                </div>
                <div class="type_tstimny">
                    <img src="/App/Images/headerfname_arrow.gif" alt="" /><span
                        class="txt">Video Testimonial</span></div>
            </div>
			<div class="save_life">
				   <span class="orngbold12_default">The Testimonial you provide can help in saving a life!</span> <br />
                   <span class="bold">Note:</span> All testimonials are submitted for review, and if approved will be used to
                    educate others about the benefit of <%= IoC.Resolve<ISettings>().CompanyName %><sup>&reg;</sup> screenings.</div>
            <div class="gboxtypes">
                <div class="type_tstimny">
                    <img src="/App/Images/customer/writen-testimonial-icon.gif" alt="Written Testimonial" />
                    <span class="txt graybold14_default">Written Testimonial</span> <span class="rgt">[
                        <a href="#">view sample</a> ]</span>
                </div>
                <div class="fldrow">
                    Please type your story in the box below & click submit.</div>
                <asp:TextBox ID="_testimonialText" runat="server" TextMode="MultiLine" Rows="4" Width="340px"></asp:TextBox>
                <div class="rgt mt_medium">
                    <asp:Button ID="_clearButton" runat="server" CssClass="button" Text="Clear"  OnClientClick="ClearTestimonialText()"/>
                    <asp:Button ID="_submitButton" runat="server" CssClass="button" Text="Submit" OnClientClick="return TestimonialTextValidation();"
                        OnClick="_submitButton_Click" /></div>
                <div class="fldrow graysmalltxt_default" style="display: none">
                    Note: All testimonials are submitted for review, and if approved will be used to
                    educate others about the benefit of <%= IoC.Resolve<ISettings>().CompanyName %><sup>&reg;</sup> screenings.</div>
            </div>
            <div class="gboxtypes">
                <div class="type_tstimny">
                    <img src="/App/Images/customer/video-testimonial-icon.gif" alt="Written Testimonial" />
                    <span class="txt graybold14_default">Video Testimonial</span> <span class="rgt">[ <a
                        href="#">view sample</a> ]</span>
                </div>
                <div class="fldrow">
                    Please upload your recorded video below which is already saved on your computer.</div>
                <div class="fldrow mt_medium">
                    <span class="blkbold12_default">Upload File: </span>
                    <asp:FileUpload ID="_uploadVedio" runat="server" size="36" CssClass="inputf_def" />
                    <div class="rgt mt_medium">
                        <asp:Button ID="_uploadVedioButton" runat="server" CssClass="button" Text="Upload"
                            OnClientClick="return TestimonialVideoValidation();" OnClick="_uploadVedioButton_Click" /></div>
                </div>                
            </div>
        </div>
    </div>
</asp:Content>
