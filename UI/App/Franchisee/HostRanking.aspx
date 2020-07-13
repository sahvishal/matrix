<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master" Title="Host Ranking"
    AutoEventWireup="true" CodeBehind="HostRanking.aspx.cs" Inherits="Falcon.App.UI.App.Franchisee.HostRanking" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="jQuery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <jQuery:JQueryToolkit runat="server" ID="JQuery" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryJTip="true"></jQuery:JQueryToolkit>
    <div id="ImageDisplayDiv" title="Host Image" style="float: left; width: 640px;">
        <img src="" alt="" width="640px" id="HostImageImg" />
    </div>

    <script language="javascript" type="text/javascript">
                
        function ValidateHostRanking()
        {
            if($("#<%= this.HostRankingDropDown.ClientID %> option:selected").length < 1
                || $("#<%= this.HostRankingDropDown.ClientID %> option:selected").attr("value") == "0")
            {
                alert("Please select a Host Ranking.")
                return false;
            }
            
            if($.trim($("#<%= this.CommentsTextBox.ClientID %>").val()).length < 1)
            {
                alert("Please provide some comments for the rating given.")
                return false;
            }
            
            return true;          
        }

    </script>

    <script language="javascript" type="text/javascript">
        
        $(document).ready(function(){
            $('#ImageDisplayDiv').dialog({ width: 680, height: 510, autoOpen: false, resizable: false, draggable: false, overflow: "visible" });
        });
        
        function InvokeServiceMethod(messageUrl, parameter, successFunction)
        {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function(result) {
                    successFunction(result);
                },
                error: function(a, b, c) {
                    alert("Oops! a problem occured in the system.");
                }
            });
        }
    
        function ManageShowHideInnerPrevRatingdiv(actionToPerform)
        {
            $(".collapse-img").toggle();
            
            if(actionToPerform == 'show')
                $(".prev-rating-byfranchisee").show();
            else
                $(".prev-rating-byfranchisee").hide();
        }
        
        function OpenImageDisplyDialog(sourcePath)
        {
            $('#HostImageImg').attr('src', sourcePath);
            $('#ImageDisplayDiv').dialog('open');        
        }
    
    </script>

    <script language="javascript" type="text/javascript">
    
        function onHostChange()
        {
            if($("#<%= this.HostDropDown.ClientID %> option:selected").attr("value") == "0")
            {
                alert("Please select a host to Rate.");
                return;
            }
            
            var hostId = $("#<%= this.HostDropDown.ClientID %> option:selected").attr("value");
            
            InitiateLoadHostRankingData(hostId);
        }
        
        function InitiateLoadHostRankingData(hostId)
        {
            var parameter = "{'hostId' : '" + hostId + "'}"; 
            
            var messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostFacilityViabilityforHSC") %>'; 
            InvokeServiceMethod(messageUrl, parameter, LoadRankingByHSC);
            
            messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostFacilityViabilityforTechnician") %>'; 
            InvokeServiceMethod(messageUrl, parameter, LoadRankingByTechnician);
            
            messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostFacilityViabilityforFranchisee") %>'; 
            InvokeServiceMethod(messageUrl, parameter, LoadRankingByFranchisee);
            
            messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostFacilityImagesByTechnician") %>'; 
            InvokeServiceMethod(messageUrl, parameter, LoadImagesbyTech);            
            
            messageUrl = '<%= ResolveUrl("~/App/Controllers/HostFacilityRankingController.asmx/GetHostFacilityImagesByHsc") %>'; 
            InvokeServiceMethod(messageUrl, parameter, LoadImagesbyHsc);
        }
    
    </script>

    <script language="javascript" type="text/javascript">
    
        function LoadImagesbyTech(result)
        {
            if(result.d == null || result.d.length < 1)
            {
                $(".technician-images").toggle();                
                return;
            }
                
            $.each(result.d, function(){
                $("#HostInfrastructureImagebyTechnicianDiv").append(GetHTMLforanImageObject(this));
            });
            $("#HostInfrastructureImagebyTechnicianDiv img:first").addClass("active");
                                    
            SortVisibility('slideshow2', $("#HostInfrastructureImagebyTechnicianDiv img.active"));
        }
        
        function LoadImagesbyHsc(result)
        {
            if(result.d == null || result.d.length < 1)
            {
                $(".hsc-images").toggle();
                return;
            }
                
            $.each(result.d, function(){
                $("#HostInfrastructureImagebyHSCDiv").append(GetHTMLforanImageObject(this));
            });
            
            $("#HostInfrastructureImagebyHSCDiv img:first").addClass("active");
                        
            SortVisibility('slideshow1', $("#HostInfrastructureImagebyHSCDiv img.active"));
        }
        
        function GetHTMLforanImageObject(imgObject)
        {
            html = "<img src='" + imgObject.Path + "' style='height:80px; wdith:120px; cursor:pointer;' onclick='OpenImageDisplyDialog(this.src);' alt='' />";
            return html;
        }
    
        function LoadRankingByTechnician(result)
        {
            if(result.d == null)
            {
                //HideRatingSection();
                $("#TechRatingNASpan").show();
                return;    
            }
            
            $("#HostRankingByTechSpan").html(result.d.Ranking.Name);
            $("#CommentsByTechSpan").html(result.d.Notes);
        }
    
        function LoadRankingByHSC(result)
        {
            if(result.d == null)
            {
                //HideRatingSection();
                $("#HSCRatingNASpan").show();
                return;
            }
            
            if(result.d.NumberOfPlugPoints!=null)
                $("#NumOfPlugPointsSPan").html(result.d.NumberOfPlugPoints);
                
            if(result.d.RoomNeedsCleared != null)
                $("#RoomNeedsClearedSpan").html(result.d.RoomNeedsCleared ? "Yes" : "No");
                
            $("#RoomSizeSpan").html(result.d.RoomSize);
            
            if(result.d.InternetAccess != null)
                $("#InternetAccessSpan").html(result.d.InternetAccess.Name);
                
            if(result.d.Ranking != null)
                $("#HostRankingHSCSpan").html(result.d.Ranking.Name);
        }
        
        function LoadRankingByFranchisee(result)
        {
            if(result.d == null)
            {
                return;               
            }
            
            $("#HostRankingByFranchiseeSpan").html(result.d.Ranking.Name);
            $("#FranchiseeCommentsSpan").html(result.d.Notes);
            $("#PrevRatingByFranchiseeDiv").show();
        }
                 
        function HideRatingSection()
        {
            $("#RatingByFranchiseeDiv").hide();
            $("#<%= this.SaveButton.ClientID %>").hide();
        }
                                    
    </script>
    
    
    <script language="javascript" type="text/javascript">

        function slideSwitch(imgToShow, activetr, imgGroup) {
            
            $("." + imgGroup).parent().find('.next-img-navigator').hide();
            $("." + imgGroup).parent().find('.previous-img-navigator').hide();   
            
            activetr.addClass('last-active');

            imgToShow.css({opacity: 0.0})
                .addClass('active')
                .animate({opacity: 1.0}, 1000, function() {
                    activetr.removeClass('active last-active');
                });
                
            SortVisibility(imgGroup, imgToShow);
        }

        function FetchNext(imgGroup)
        {   
            var $active = $('.' + imgGroup + ' img.active');

            if ( $active.length == 0 ) $active = $('.' + imgGroup + ' img:last');

            var $next = FindNext(imgGroup, $active);
                
            if($active.attr('src') == $next.attr('src')) 
            { return; }
                           
            slideSwitch($next, $active, imgGroup);
        }

        function FindNext(imgGroup, activeImg)
        {
            var $next = $('.' + imgGroup + ' img:last');
            if(activeImg.next().length > 0)
            {
                $next = activeImg.next();
            }        
            return $next;
        }
        
        function FindPrevious(imgGroup, activeImg)
        {
            var $prev = $('.' + imgGroup + ' img:first');
            
            if(activeImg.prev().length > 0)
            {
                $prev = activeImg.prev();
            }        
            return $prev;
        }

        function FetchPrevious(imgGroup)
        {  
            var $active = $('.' + imgGroup + ' img.active');

            if ( $active.length == 0 ) $active = $('.' + imgGroup + ' img:first');

            var $prev = FindPrevious(imgGroup, $active);
                        
            if($active.attr('src') == $prev.attr('src'))
            { return; }
                          
            slideSwitch($prev, $active, imgGroup);
        }
        
        function SortVisibility(imgGroup, currentDiv)
        {
            var nextDiv = FindNext(imgGroup, currentDiv);
            var prevDiv = FindPrevious(imgGroup, currentDiv);
            
            $("." + imgGroup).parent().find('.next-img-navigator').show();
            $("." + imgGroup).parent().find('.previous-img-navigator').show();   
            
            if(nextDiv.attr('src') == currentDiv.attr('src'))
            {
                $("." + imgGroup).parent().find('.next-img-navigator').hide();
            }
            
            if(prevDiv.attr('src') == currentDiv.attr('src'))
            {
                $("." + imgGroup).parent().find('.previous-img-navigator').hide();
            }
        }

    </script>

<style type="text/css">
    /*** set the width and height to match your images **/
    
    .slideshow
    {   position:relative;
        height: 100px;
        width: 190px;
    }
            
    .slideshow IMG
    {        
    	position: absolute;
    	top: 0;
    	left: 0;
    	z-index: 8;
        opacity: 0.0;
        width: 120px;
    }
        
    .slideshow IMG.active
    {
        z-index: 10;
        opacity: 1.0;
    }
    
    .slideshow IMG.last-active
    {
        z-index: 9;
    }
    
</style>

    <div class="wrapper_inpg">
        <h1>
            Host Ranking</h1>
        <div class="hr">
        </div>
        <div class="hdiv_hr" style="display: none;">
            <label class="bold">
                Host:</label>
            <asp:DropDownList ID="HostDropDown" runat="server" Width="200px">
            </asp:DropDownList>
        </div>
        <div class="left" style="width: 560px">
            <div class="grybox">
                <h4>
                    <u>HSC</u><span id="HSCRatingNASpan" style="display: none;"> (Not Available) </span>
                </h4>
                <div class="wrow">
                    <span class="blabel_hr">No of Plug Points:</span> <span id="NumOfPlugPointsSPan"
                        class="nlabel_hr_med"></span><span class="blabel_hr">Room Size:</span> <span id="RoomSizeSpan"
                            class="nlabel_hr_med"></span>
                </div>
                <div class="wrow">
                    <span class="blabel_hr">Room Needs Cleared:</span> <span id="RoomNeedsClearedSpan"
                        class="nlabel_hr_med"></span><span class="blabel_hr">Internet Access:</span>
                    <span id="InternetAccessSpan" class="nlabel_hr_med"></span>
                </div>
                <div class="wrow">
                    <span class="blabel_hr">Host Ranking:</span> <span id="HostRankingHSCSpan" class="nlabel_hr_large">
                    </span>
                </div>
            </div>
            <div class="grybox">
                <h4>
                    <u>Technician</u><span id="TechRatingNASpan" style="display: none;"> (Not Available)
                    </span>
                </h4>
                <div class="wrow">
                    <span class="blabel_hr">Host Ranking:</span> <span id="HostRankingByTechSpan" class="nlabel_hr_large">
                    </span>
                </div>
                <div class="wrow">
                    <span class="blabel_hr">Comments:</span> <span id="CommentsByTechSpan" class="nlabel_hr_large">
                    </span>
                </div>
            </div>
        </div>
        <div class="left" style="width: 190px">
            <div class="imgthumb_div hsc-images">
                <label class="lblbg">
                    Images (HSC):</label>
                <div id="HostInfrastructureImagebyHSCDiv" class="slideshow slideshow1">
                </div>
                <div class="left" style="width: 180px; text-align: center;">
                    <img src="/app/Images/calander-leftarrow-btn.gif" alt="" class="previous-img-navigator"
                        onclick="FetchPrevious('slideshow1');" />
                    <img src="/app/Images/calander-rightarrow-btn.gif" alt="" class="next-img-navigator"
                        onclick="FetchNext('slideshow1');" />
                </div>
            </div>
            <div class="imgthumb_div hsc-images" style="display: none;">
                <label class="lblbg">
                    Images (HSC):</label>
                <img src="/App/Images/no-img-available.gif" style="width:180px;" alt="No Image Available" />
            </div>
            <div class="imgthumb_div technician-images">
                <label class="lblbg">
                    Images (Technician):</label>
                <div id="HostInfrastructureImagebyTechnicianDiv" class="slideshow slideshow2">
                </div>
                <div class="left" style="width: 180px; text-align: center;">
                    <img src="/app/Images/calander-leftarrow-btn.gif" alt="" class="previous-img-navigator"
                        onclick="FetchPrevious('slideshow2');" />
                    <img src="/app/Images/calander-rightarrow-btn.gif" alt="" class="next-img-navigator"
                        onclick="FetchNext('slideshow2');" />
                </div>
            </div>
            <div class="imgthumb_div technician-images" style="display: none;">
                <label class="lblbg">
                    Images (Technician):</label>
                <img src="/App/Images/no-img-available.gif" style="width:180px;" alt="No Image Available" />
            </div>
        </div>
        
        <div id="PrevRatingByFranchiseeDiv" class="fltrdv" style="display: none;">
            <span class="mt_img">
                <img src="/App/Images/plus-sign.gif" alt="" style="display: block; cursor: pointer;"
                    onclick="ManageShowHideInnerPrevRatingdiv('show');" class="collapse-img" />
                <img src="/App/Images/minus-signs.gif" alt="" style="display: none; cursor: pointer;"
                    onclick="ManageShowHideInnerPrevRatingdiv('hide');" class="collapse-img" />
            </span><span class="blktext13px_default">Previous comments given by franchisee </span>
            <div id="PrevRatingByFranchiseeInnerDiv" style="display: none;" class="prev-rating-byfranchisee">
                <div class="boxrow">
                    <span class="blabel_hr">Host Ranking:</span> <span id="HostRankingByFranchiseeSpan"
                        class="nlabel_hr_large"></span>
                </div>
                <div class="boxrow">
                    <span class="blabel_hr">Comments:</span> <span id="FranchiseeCommentsSpan" class="nlabel_hr_large">
                    </span>
                </div>
            </div>
        </div>
        <div id="RatingByFranchiseeDiv" class="fltrdv">
            <div class="boxrow">
                <span class="blabel_hr">Host Ranking:</span>
                <asp:DropDownList ID="HostRankingDropDown" runat="server" Width="200px">
                </asp:DropDownList>
            </div>
            <div class="boxrow">
                <span class="blabel_hr">Comments:</span>
                <asp:TextBox ID="CommentsTextBox" runat="server" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox>
            </div>
        </div>
        <div class="prow mt_medium">
            <div class="rgt">
                <asp:Button runat="server" ID="CancelButton" CssClass="button" Text="Cancel" OnClick="CancelButton_Click" />
                <asp:Button runat="server" ID="SaveButton" CssClass="button" Text="Save" OnClientClick="return ValidateHostRanking();" OnClick="SaveButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
