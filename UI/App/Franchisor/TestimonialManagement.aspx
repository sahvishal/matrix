<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    CodeBehind="TestimonialManagement.aspx.cs" Inherits="Falcon.App.UI.App.Franchisor.TestimonialManagement"
    Title="Testimonial Management" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="_jQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" />

    <script type="text/javascript" language="javascript">
    
        var PAGE_SIZE = 10;
        var totalNumberOfTestimonials;
        var currentPage = 1;
        var activeTab;
        var gender='Male'
        
        $(document).ready(function() {
            var $tabs = $('#tabs').tabs();
            $('#TestimonialTextDiv').dialog({ autoOpen: false, width: 500, buttons: { 'Close': function() { $(this).dialog('close'); } } });
            BindTestimonials('submitted')
        });
        
        function InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction) {
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
                    errorFunction();
                }
            });
        }
            
        $.ajaxSetup({ cache: false });
    </script>
    
    <%--Show Submitted Testimonials--%>
    <script type="text/javascript" language="javascript">
        function ShowSubmittedTestimonial(testimonialType, pageNumber, pageSize)
        {
            var SubmittedTestimonialDiv = $('#SubmittedTestimonialDiv');
            SubmittedTestimonialDiv.html('');
            SubmittedTestimonialDiv.addClass('loading');
            
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/GetAllSubmittedTestimonial")%>';
            var parameter = "{'pageNumber':'" + pageNumber + "'";
            parameter += ",'pageSize':'" + pageSize + "'}";
            
            var successFunction = function(returnData) 
            {
                SubmittedTestimonialDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/CustomerTestimonialAggregate.html") %>');
                SubmittedTestimonialDiv.setParam('TestimonialType', testimonialType);
                
                SubmittedTestimonialDiv.processTemplate(returnData.d);
                $('.col-disposition').show();
                $('.age-header').hide();
                $('#ToggleDiv').hide();
                $('.col_action').show();
                
            }
            
            var numberOfRecordsFunction = function(returnData) 
            { 
                if(returnData.d!=null)
                    return returnData.d.length;
                else 
                    return 0; 
            }
            
            var noRecordsFunction = function() 
            {
                if(pageNumber>1)
                {
                    $('#ViewOrdersPager').hide();
                    GoToPage(pageNumber - 1);
                }
                else
                    SubmittedTestimonialDiv.html('There is no submitted testimonials.');
               
            }
            
            var completeFunction = function() { SubmittedTestimonialDiv.removeClass('loading'); Paginate();}
            
            var errorFunction = function() {
                alert('The details of submitted testimonials could not be loaded due to an internal server error.');
            }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
        }
    </script>

    <%--Show Accepted Testimonials--%>
    <script type="text/javascript" language="javascript">
        function ShowAcceptedTestimonial(testimonialType, pageNumber, pageSize)
        {
            var AcceptedTestimonialDiv = $('#AcceptedTestimonialDiv');
            AcceptedTestimonialDiv.html('');
            AcceptedTestimonialDiv.addClass('loading');
            
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/GetAllAcceptedTestimonial")%>';
            var parameter = "{'gender':'" + gender +"'";
            parameter += ",'pageNumber':'" + pageNumber + "'";
            parameter += ",'pageSize':'" + pageSize + "'}";
            
            var successFunction = function(returnData) 
            {
                AcceptedTestimonialDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/CustomerTestimonialAggregate.html") %>');
                AcceptedTestimonialDiv.setParam('TestimonialType', testimonialType);
                
                AcceptedTestimonialDiv.processTemplate(returnData.d);
                $('.col-disposition').show();
                $('.age-header').hide();
                $('#ToggleDiv').show();
                $('.col_action').hide();
            }
            
            var numberOfRecordsFunction = function(returnData) 
            { 
                if(returnData.d!=null)
                    return returnData.d.length;
                else 
                    return 0; 
            }
            
            var noRecordsFunction = function() 
            {
               AcceptedTestimonialDiv.html('There is no accepted testimonials.');
            }
            
            var completeFunction = function() { AcceptedTestimonialDiv.removeClass('loading'); Paginate();}
            
            var errorFunction = function() {
                alert('The details of accepted testimonials could not be loaded due to an internal server error.');
            }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
        }
    </script>

    <%--Show Declined Testimonials--%>
    <script type="text/javascript" language="javascript">
        function ShowDeclinedTestimonial(testimonialType, pageNumber, pageSize)
        {
            var DeclinedTestimonialDiv = $('#DeclinedTestimonialDiv');
            DeclinedTestimonialDiv.html('');
            DeclinedTestimonialDiv.addClass('loading');
            
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/GetAllDeclinedTestimonial")%>';
            var parameter = "{'pageNumber':'" + pageNumber + "'";
            parameter += ",'pageSize':'" + pageSize + "'}";
            
            var successFunction = function(returnData) 
            {
                DeclinedTestimonialDiv.setTemplateURL('<%= ResolveUrl("~/App/Templates/CustomerTestimonialAggregate.html") %>');
                DeclinedTestimonialDiv.setParam('TestimonialType', testimonialType);
                
                DeclinedTestimonialDiv.processTemplate(returnData.d);
                $('.col-disposition').hide();
                $('.age-header').hide();
                $('#ToggleDiv').hide();
                $('.col_action').hide();
            }
            
            var numberOfRecordsFunction = function(returnData) 
            { 
                if(returnData.d!=null)
                    return returnData.d.length;
                else 
                    return 0;
            }
            
            var noRecordsFunction = function() 
            {
                DeclinedTestimonialDiv.html('There is no declined testimonials.');
            }
            
            var completeFunction = function() { DeclinedTestimonialDiv.removeClass('loading'); Paginate();}
            
            var errorFunction = function() {
                alert('The details of declined testimonials could not be loaded due to an internal server error.');
            }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction, false);
        }
    </script>
    
    <%--Change Testimonial Status--%>
    <script type="text/javascript" language="javascript">
        function ChangeTestimonialStatus(testimonialId,status)
        {
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/ChangeTestimonialStatus")%>';
            var parameter = "{'isAccepted':'" + status + "'";
            parameter += ",'testimonialId':'" + testimonialId +"'}";
            
            var successFunction = function(resultData) 
            {
                if (!resultData.d)
                {
                    if(status=='true')
                        alert('The testimonial is not accepted.');
                    else
                        alert('The testimonial is not declined.');
                }
                else
                {
                    if(status=='true')
                        alert("The testimonial has been accepted.");
                    else
                        alert("The testimonial has been declined.");
                    totalNumberOfTestimonials = totalNumberOfTestimonials - 1;
                    ShowSubmittedTestimonial('submitted', currentPage, PAGE_SIZE);
                }
            }
            var errorFunction = function() 
            {
                if(status=='true') 
                    alert('There was some error while accepting testimonial .');
                else
                    alert('There was some error while declining testimonial .');
            }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }
    </script>
    
    <%--Update Rank--%>
    <script type="text/javascript" language="javascript">
        function UpdateTestimonialRank(testimonialId, rankDropdownId)
        {
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/UpdateTestimonialRank")%>';
            var parameter = "{'rank':'" + $('#' + rankDropdownId).val() + "'";
            parameter += ",'testimonialId':'" + testimonialId +"'}";
            
            var successFunction = function(resultData) 
            {
                if (!resultData.d)
                    alert('Rank has not been updated .');
                else
                     alert('Rank has been updated .');
            }
            var errorFunction = function() 
            {
                alert('There was some error while updating rank.');
            }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }
    </script>
    
    <%--Set Testimonial Rank--%>
    <script type="text/javascript" language="javascript">
        function SetTestimonialRank(rankDropdownId, rank)
        {
            for(var count=1; count<=10; count++)
            {
                //$('.rank').append($('<option></option>').val(count).html(count));
                $('#' + rankDropdownId).append($('<option></option>').val(count).html(count));
            }
            if(rank!=null)
                $('#' + rankDropdownId).val(rank);
        }
    </script>
    
    <%--Bind Testimonial Data--%>
    <script type="text/javascript" language="javascript">
        function BindTestimonials(testimonialType)
        {
            activeTab = testimonialType;
            currentPage = 1;
            var messageUrl;
            var parameter = "{}";
            if(activeTab=="submitted")
                messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/GetAllSubmittedTestimonialCount")%>';
            else if(activeTab=="accepted")
            {
                messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/GetAllAcceptedTestimonialCount")%>';
                parameter = "{'gender':'" + gender + "'}";
            }
            else if(activeTab=="declined")
                messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/GetAllDeclinedTestimonialCount")%>';
            
            
            var successFunction = function(returnData) 
            {
                totalNumberOfTestimonials = returnData.d;
                if(activeTab=="submitted")
                    ShowSubmittedTestimonial(activeTab, currentPage, PAGE_SIZE);
                else if(activeTab=="accepted")
                    ShowAcceptedTestimonial(activeTab, currentPage, PAGE_SIZE);
                else if(activeTab=="declined")
                    ShowDeclinedTestimonial(activeTab, currentPage, PAGE_SIZE);
                
            }
            
            var numberOfRecordsFunction = function(returnData) 
            { 
                if(returnData.d!=null)
                    return returnData.d;
                else 
                    return 0; 
            }
            
            var noRecordsFunction = function() {
                if(activeTab=="submitted")
                    $('#SubmittedTestimonialDiv').html('There is no submitted testimonials.');
                else if(activeTab=="accepted")
                    $('#AcceptedTestimonialDiv').html('There is no accepted testimonials.');
                else if(activeTab=="declined")
                    $('#DeclinedTestimonialDiv').html('There is no declined testimonials.');
                
                $('#ViewOrdersPager').hide();
            }
            
            var completeFunction = function() {}
            
            var errorFunction = function() {
                alert('The details of submitted testimonials could not be loaded due to an internal server error.');
            }
            LoadAjax(messageUrl, parameter, successFunction, errorFunction, completeFunction, numberOfRecordsFunction, noRecordsFunction,false);
        }
    </script>
    
    <%--Paging methods--%>
    <script type="text/javascript" language="javascript">
         function Paginate() {
            var previousPageLink = $('#PrevPageLink');
            var nextPageLink = $('#NextPageLink');
            var numberOfPages = totalNumberOfTestimonials / PAGE_SIZE;
            if(numberOfPages > Math.ceil(numberOfPages))
                numberOfPages = Math.ceil(numberOfPages) + 1;
            else
                numberOfPages = Math.ceil(numberOfPages);   
                
            if (currentPage == 1) {
                previousPageLink.hide();
            }
            else {
                previousPageLink.show();
                previousPageLink.unbind();
                previousPageLink.click(LoadPreviousPage);
            }
            if (currentPage >= numberOfPages) {
                nextPageLink.hide();
            }
            else {
                nextPageLink.show();
                nextPageLink.unbind();
                nextPageLink.click(LoadNextPage);
            }

            var pages = $("#ViewOrderPages");
            pages.html('');
            if(numberOfPages>1)
            {   
                for (var i = 1; i <= numberOfPages; i++) 
                {
                    if(currentPage==i)
                        $("<label></label>").text(i).appendTo(pages);
                    else
                        $("<a href='javascript:void(0)' onclick='GoToPage(" + i + ")'></a>").text(i).appendTo(pages);
                }
            }
                      

            $('#ViewOrdersPager').show();
        }
        function LoadPreviousPage() {
            return GoToPage(currentPage - 1);
        }

        function LoadNextPage() {
            return GoToPage(currentPage + 1);
        }

        function GoToPage(page) {
            currentPage = page;
            if(activeTab=="submitted")
                ShowSubmittedTestimonial(activeTab, currentPage, PAGE_SIZE);
            else if(activeTab=="accepted")
                ShowAcceptedTestimonial(activeTab, currentPage, PAGE_SIZE);
            else if(activeTab=="declined")
                ShowDeclinedTestimonial(activeTab, currentPage, PAGE_SIZE);
            return false;
        }
    </script>
    
    <%--Toggle Accepted Testimonials--%>
    <script type="text/javascript" language="javascript">
        function Toggle()
        {
            var toggleHtml=gender;
            gender=$('#ToggleAnchor').text();
            $('#ToggleAnchor').text(toggleHtml);
            BindTestimonials('accepted');
        }
    </script>
    
    <%--View Testimonial Text--%>
    <script type="text/javascript" language="javascript">
        function ShowTestimonialText(testimonialId)
        {
            $('#TestimonialTextDiv').dialog('open');
            
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/ViewTestimonialText")%>';
            var parameter = "{'testimonialId':'" + testimonialId + "'}";
                        
            var successFunction = function(resultData) 
            {
                $('#TestimonialTextDiv').text(resultData.d);
            }
            var errorFunction = function() 
            {
                $('#TestimonialTextDiv').text('Due to some error testimonial text can not be viewed.');
            }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
        }
        
        function DownloadTestimonialVideo(testimonialId)
        {
            var messageUrl = '<%=ResolveUrl("~/App/Controllers/CustomerTestimoialController.asmx/ViewTestimonialVideo")%>';
            var parameter = "{'testimonialId':'" + testimonialId + "'}";
                        
            var successFunction = function(resultData) 
            {
                window.location=resultData.d;
            }
            var errorFunction = function() 
            {
                alert("Due to some error testimonial video can not be downloaded");
            }
            InvokeAsyncService(messageUrl, parameter, successFunction, errorFunction);
            
        }
    </script>
    
    <div class="wrapper_ecl">
        <h1 class="left mt_img">
            Testimonial Management</h1>
        <div class="divgrd_thp mt_medium">
            <div id="tabs">
                <ul>
                    <li><a href="#SubmittedTestimonialDiv" onclick="return BindTestimonials('submitted');">
                        Submitted</a></li>
                    <li><a href="#AcceptedTestimonialDiv" onclick="return BindTestimonials('accepted');">
                        Accepted</a></li>
                    <li><a href="#DeclinedTestimonialDiv" onclick="return BindTestimonials('declined');">
                        Declined</a></li>
                </ul>
                <div id="SubmittedTestimonialDiv">
                </div>
                <div>
                    <div class="jspagingdiv mt_medium" id="ToggleDiv">
                        Toggle:<a href="javascript:void(0)" id="ToggleAnchor" onclick="Toggle();">Female</a>
                    </div>
                    <div id="AcceptedTestimonialDiv">
                    </div>
                </div>
                <div id="DeclinedTestimonialDiv">
                </div>
                <div id="ViewOrdersPager" style="display:none" class="jspagingdiv">
                    <a href="#" id="PrevPageLink"><img src="/App/Images/btn_previous_pgn.gif" alt="Previous Page" title="Previous Page" /></a> <span id="ViewOrderPages"></span>
                    <a href="#" id="NextPageLink"> <img src="/App/Images/btn_next_pgn.gif" alt="Next Page" title="Next Page" /></a>
                </div>
            </div>
        </div>
    </div>
    <div id="TestimonialTextDiv" title="Testimonial Text" style="display: none"></div>
</asp:Content>
