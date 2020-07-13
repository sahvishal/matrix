<%@ Page Language="C#" Title="Marketing Break-Ups" AutoEventWireup="true" MasterPageFile="~/App/MarketingPartner/MarketingPartner.master"
    CodeBehind="CategoryCustomerReport.aspx.cs" Inherits="HealthYes.Web.App.MarketingPartner.CategoryCustomerReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%-- Grid script starts here --%>
            <script type="text/javascript">

                function getSummary(CategoryId) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                    var hfDuration = document.getElementById('<%=hfDuration.ClientID %>');
                    
                    var dvSummaryResult = document.getElementById("dvSummaryResult");
                    dvSummaryResult.innerHTML = "";
                    var imgSummaryLoading = document.getElementById("imgSummaryLoading");
                    imgSummaryLoading.style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=Summary&CategoryId=" + CategoryId + "&PageNumber=1&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttpSummary();
                    if (XmlHttpSummary) {
                        //Setting the event handler for the response
                        XmlHttpSummary.onreadystatechange = SummaryResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttpSummary.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttpSummary.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }


                function SummaryResponse() {
                    if (XmlHttpSummary == null)
                        CreateXmlHttpSummary();
                    //To make sure receiving response data from server is completed
                    if (XmlHttpSummary.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttpSummary.status == 200) // response status is OK
                        {
                            if (XmlHttpSummary.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdSummaryLoaded.ClientID%>').value = "True";

                                document.getElementById("dvSummaryResult").innerHTML = XmlHttpSummary.responseText;
                                document.getElementById("imgSummaryLoading").style.display = "none";

                                XmlHttpSummary = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdSummaryLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }


                function getPayment(CategoryId, PageNumber) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                    var hfDuration = document.getElementById('<%=hfDuration.ClientID %>');
                    var dvGridPaymentResult = document.getElementById("dvGridPaymentResult");
                    dvGridPaymentResult.innerHTML = "";
                    var imgPaymentLoading = document.getElementById("imgPaymentLoading");
                    imgPaymentLoading.style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=AdvocatePayment&CategoryId=" + CategoryId + "&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = PaymentResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }


                function PaymentResponse() {
                    if (XmlHttp == null)
                        CreateXmlHttp();
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdPaymentLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridPaymentResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgPaymentLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdPaymentLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }

                function getAdvocate(CategoryId, PageNumber) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                    var hfDuration = document.getElementById('<%=hfDuration.ClientID %>');
                    SetDetailsTitle(CategoryId, txtStartDate.value, txtEndDate.value, hfDuration.value);
                    var dvGridAdvocateResult = document.getElementById("dvGridAdvocateResult");
                    dvGridAdvocateResult.innerHTML = "";
                    var imgAdvocateLoading = document.getElementById("imgAdvocateLoading");
                    imgAdvocateLoading.style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=AdvocateSearch&CategoryId=" + CategoryId + "&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = AdvocateResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }


                function AdvocateResponse() {
                    if (XmlHttp == null)
                        CreateXmlHttp();
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdAdvocateLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridAdvocateResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgAdvocateLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdAdvocateLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }
                
    var XmlHttpSummary           
function CreateXmlHttpSummary() {
   


	var versionList = ["Msxml2.XMLHTTP", "Microsoft.XMLHTTP"] ;
	for(var count = 0; count<= versionList.length; count++)
	{
		try
		{
			XmlHttpSummary = new ActiveXObject(versionList[count]);
			return XmlHttpSummary ; // return the XMLHttp object
		}
		catch(objCreationError)
		{ 
			// Do nothing 
		}
	}
	//Creating object of XMLHTTP in Mozilla and Safari 
	if(!XmlHttpSummary && typeof XMLHttpRequest != "undefined") 
	{
		XmlHttpSummary = new XMLHttpRequest();
		return XmlHttpSummary;
	}
	throw new Error("Unable to create the XMLHttp object.");
}            
 var XmlHttp           
function CreateXmlHttp() {
   


	var versionList = ["Msxml2.XMLHTTP", "Microsoft.XMLHTTP"] ;
	for(var count = 0; count<= versionList.length; count++)
	{
		try
		{
			XmlHttp = new ActiveXObject(versionList[count]);
			return XmlHttp ; // return the XMLHttp object
		}
		catch(objCreationError)
		{ 
			// Do nothing 
		}
	}
	//Creating object of XMLHTTP in Mozilla and Safari 
	if(!XmlHttp && typeof XMLHttpRequest != "undefined") 
	{
		XmlHttp = new XMLHttpRequest();
		return XmlHttp;
	}
	throw new Error("Unable to create the XMLHttp object.");
}
            
                 function getCampaign( CategoryId,PageNumber) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                    var hfDuration = document.getElementById('<%=hfDuration.ClientID %>');
                     var dvGridCampaignResult=document.getElementById("dvGridCampaignResult");
                    dvGridCampaignResult.innerHTML = "";
                    var imgCampaignLoading=document.getElementById("imgCampaignLoading");
                    imgCampaignLoading.style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=AdvocateCampaign&CategoryId=" + CategoryId + "&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = CampaignResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }


                function CampaignResponse() {
                    if(XmlHttp==null)
                    CreateXmlHttp();
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdCampaignLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridCampaignResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgCampaignLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdCampaignLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }



                function ViewMM(CampaignID, CampaignName, CampaignStart, CampaignEnd, Commission) {
                    //var strQueryString='CampaignID='+ CampaignID + '&CampaignName='+ CampaignName +'&Strat='+ CampaignStart +'&End='+ CampaignEnd +'&Commission='+ Commission ;
                    var strQueryString = 'CampaignID=' + CampaignID;
                    var load = window.open('/App/MarketingPartner/MMPopup.aspx?' + strQueryString, '', 'scrollbars=no,menubar=no,height=650,width=904,resizable=no,toolbar=no,left=50,top=10');

                }
             
            
                function getCustomer(CategoryId, PageNumber) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                    var hfDuration= document.getElementById('<%=hfDuration.ClientID %>');
                    document.getElementById("dvGridCustomerResult").innerHTML = "";
                    document.getElementById("imgCustomerLoading").style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=AdvocateCustomer&CategoryId=" + CategoryId + "&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = CustomerResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }
                function getPaidCustomer(CategoryId, PageNumber) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                     var hfDuration= document.getElementById('<%=hfDuration.ClientID %>');
                    document.getElementById("dvGridPaidCustomerResult").innerHTML = "";
                    document.getElementById("imgPaidCustomerLoading").style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=AdvocateCustomer&CategoryId=" + CategoryId + "&PaymentStatus=Paid&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = PaidCustomerResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }
                function CustomerResponse() {
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdCustomerLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridCustomerResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgCustomerLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdCustomerLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }
                function PaidCustomerResponse() {
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdCustomerLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridPaidCustomerResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgPaidCustomerLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdCustomerLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }
             
           
                function getSignup(  CategoryId,PageNumber) {
                        var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                     var hfDuration= document.getElementById('<%=hfDuration.ClientID %>');
                    document.getElementById("dvGridSignupResult").innerHTML = "";
                    document.getElementById("imgSignupLoading").style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=AdvocateSignup&CategoryId=" + CategoryId + "&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = SignupResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }
                function SignupResponse() {
                    
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdSignupLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridSignupResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgSignupLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdSignupLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }

             
            
                function getCall(CategoryId, PageNumber) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                    var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                     var hfDuration= document.getElementById('<%=hfDuration.ClientID %>');
                    document.getElementById("dvGridCallResult").innerHTML = "";
                    document.getElementById("imgCallLoading").style.display = "block";
                    var requestUrl = "AscCategoryCustomer.aspx?Type=Call&CategoryId=" + CategoryId + "&PageNumber=" + PageNumber + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = CallResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }
                function CallResponse() {
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                document.getElementById('<%=this.hdCallLoaded.ClientID%>').value = "True";

                                document.getElementById("dvGridCallResult").innerHTML = XmlHttp.responseText;
                                document.getElementById("imgCallLoading").style.display = "none";

                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            document.getElementById('<%=this.hdCallLoaded.ClientID%>').value = "";
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }

             
            
                function getGraph(CategoryId) {
                    var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
            var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
             var hfDuration= document.getElementById('<%=hfDuration.ClientID %>');
                    //document.getElementById("dvGraphResult").innerHTML = "";
                    ///document.getElementById("imgCallLoading").style.display = "block";
             var requestUrl = "AscCategoryCustomer.aspx?Type=Graph&CategoryId=" + CategoryId + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value + "&Duration=" + hfDuration.value;
                    CreateXmlHttp();
                    if (XmlHttp) {
                        //Setting the event handler for the response
                        XmlHttp.onreadystatechange = GrpahResponse;
                        //Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
                        XmlHttp.open("GET", requestUrl, true);
                        //Sends the request to server
                        XmlHttp.send(null);
                    }
                    else // Browser does not support XMLHTTPRequest object
                    {

                        alert("Browser does not support XMLHTTPRequest object.");
                    }


                }
                function GrpahResponse() {
                    //To make sure receiving response data from server is completed
                    if (XmlHttp.readyState == 4) {
                        // To make sure valid response is received from the server, 200 means response received is OK
                        // alert(XmlHttp.responseText);
                        if (XmlHttp.status == 200) // response status is OK
                        {
                            if (XmlHttp.responseText != "") {
                                ///document.getElementById("result").innerHTML = XmlHttp.responseText;
                                var responsetext = XmlHttp.responseText;
                                var arrresponsetext = responsetext.split(", ");
                                arrresponsetext[0] = arrresponsetext[0].replace('https:', 'http:');
                                document.getElementById('imgGrpah').src = arrresponsetext[0];
                                XmlHttp = null;
                                // Load the response in the Document
                            }
                        }
                        else {
                            alert("There was a problem retrieving data from the server.");
                        }
                    }

                }

             
           
                function Activate(control, affiliateid) {
                    var a = document.getElementById(control);
                    var spnIndicator = document.getElementById('spnIndicator');

                    if (a.innerHTML == 'Activate') {

                        spnIndicator.style.display = 'block';
                        ///ActivateDeactivate(1,affiliateid);
                        ret = AutoCompleteService.ChangeAffiliateApprovedStatus(affiliateid, 1);

                        a.innerHTML = 'DeActivate';
                        spnIndicator.style.display = 'none';
                    }
                    else {
                        spnIndicator.style.display = 'block';
                        ///ActivateDeactivate(0,affiliateid);
                        ret = AutoCompleteService.ChangeAffiliateApprovedStatus(affiliateid, 0);

                        a.innerHTML = 'Activate';
                        spnIndicator.style.display = 'none';
                    }
                    alert("Advocate status changed successfully.");
                    return false;
                }
                function ViewAdvocate(CategoryId) {
                    
                    var hfCategoryID = document.getElementById('<%=this.hfCategoryID.ClientID%>');
                    hfCategoryID.value = CategoryId;
                    View('Advocate');
                    
                }
                
                function ViewTab()
                {
                    var hfCategoryID = document.getElementById('<%=this.hfCategoryID.ClientID%>');
                    hfCategoryID.value = 0;
                    View('Advocate');
                    
                }

                function View(type) {                   
                    

                    var dvSignup = document.getElementById('<%=this.dvSignup.ClientID%>');
                    var dvCampaign = document.getElementById('<%=this.dvCampaign.ClientID%>');
                    var dvCustomer = document.getElementById('<%=this.dvCustomer.ClientID%>');
                    var dvPayment = document.getElementById('<%=this.dvPayment.ClientID%>');
                    var dvHistory = document.getElementById('<%=this.dvHistory.ClientID%>');
                    var dvPaidCustomer = document.getElementById('<%=this.dvPaidCustomer.ClientID%>');
                    var dvCall = document.getElementById('<%=this.dvCall.ClientID%>');
                    var dvGraph = document.getElementById('<%=this.dvGraph.ClientID%>');
                    var dvAdvocate = document.getElementById('<%=this.dvAdvocate.ClientID%>');
                   
                    var imgSignup = document.getElementById('<%=this.imgSignup.ClientID%>');
                    var imgCampaign = document.getElementById('<%=this.imgCampaign.ClientID%>');
                    var imgCustomer = document.getElementById('<%=this.imgCustomer.ClientID%>');
                    var imgPayment = document.getElementById('<%=this.imgPayment.ClientID%>');
                    var imgHistory = document.getElementById('<%=this.imgHistory.ClientID%>');
                    var imgPaidCustomer = document.getElementById('<%=this.imgPaidCustomer.ClientID%>');
                    var imgCall = document.getElementById('<%=this.imgCall.ClientID%>');
                    var imgCustomerGraph = document.getElementById('<%=this.imgCustomerGraph.ClientID%>');
                    var imgAdvocate = document.getElementById('<%=this.imgAdvocate.ClientID%>');
                    
                    var hfView = document.getElementById('<%=this.hfView.ClientID%>');
                    hfView.value = type;
               
                    dvSignup.style.display = 'none';
                    dvCampaign.style.display = 'none';
                    dvCustomer.style.display = 'none';
                    dvPaidCustomer.style.display = 'none';
                    dvPayment.style.display = 'none';
                    dvCall.style.display = 'none';
                    dvHistory.style.display = 'none';
                    dvGraph.style.display = 'none';
                    dvAdvocate.style.display = 'none';
                    

                    imgSignup.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/signups-blutab-off.gif") %>';
                    imgCampaign.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/campaigns-taboff.gif") %>';
                    imgCustomer.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Cusotmers-taboff.gif") %>';
                    imgPaidCustomer.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/PaidCusotmers-taboff.gif") %>';
                    imgPayment.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Payments-taboff.gif") %>';
                    imgHistory.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/history-taboff.gif") %>';
                    imgCall.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Calls-taboff.gif") %>';
                    imgCustomerGraph.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Graph-taboff.gif") %>';
                    imgAdvocate.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Advocates-taboff.gif") %>';
                    
                   
                    
                    if (type == 'Signup') {
                        dvSignup.style.display = 'block';
                        imgSignup.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/signups-blutab-on.gif") %>';
                        getSignup(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);
                       
                    }
                    else if (type == 'Campaign') {
                        dvCampaign.style.display = 'block';
                        imgCampaign.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/campaigns-tabon.gif") %>';
                        getCampaign(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);
                       
                    }
                    else if (type == 'Advocate') {
                        dvAdvocate.style.display = 'block';
                        imgAdvocate.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Advocates-tabon.gif") %>';
                        getAdvocate(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);

                    }
                    else if (type == 'Customer') {
                        dvCustomer.style.display = 'block';
                        imgCustomer.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Cusotmers-tabon.gif") %>';
                        getCustomer(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);
                        
                    }
                    else if (type == 'PaidCustomer') {

                        dvPaidCustomer.style.display = 'block';
                        imgPaidCustomer.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/PaidCusotmers-tabon.gif") %>';
                        getPaidCustomer(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);
                        
                    }

                    else if (type == 'Call') {

                        dvCall.style.display = 'block';
                        imgCall.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Calls-tabon.gif") %>';

                        getCall(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);
                       
                    }
                    else if (type == 'Payment') {
                        dvPayment.style.display = 'block';
                        imgPayment.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Payments-tabon.gif") %>';
                        getPayment(document.getElementById('<%=this.hfCategoryID.ClientID%>').value, 1);
                    }
                    else if (type == 'Graph') {

                        dvGraph.style.display = 'block';
                        imgCustomerGraph.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/Graph-tabon.gif") %>';
                        getGraph(document.getElementById('<%=this.hfCategoryID.ClientID%>').value);

                    }
                    else if (type == 'History') {
                        /// return;
                        dvHistory.style.display = 'block';
                        imgHistory.src = '<%=ResolveUrl("~/App/Images/MarketingPartner/history-tabon.gif") %>';

                    }
                    return false;
                }
               
             
                </script>
<%-- Grid script ends here --%>
    <script type="text/javascript" src="../../JavascriptFiles/HttpRequest.js"></script>

    <script language="javascript" type="text/javascript">
    
    function ClearDateSearch()
    {
                var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
                txtStartDate.value = "";
                txtEndDate.value = "";
                return false;
         
    }
        
        function ValidateDate() 
            {
                var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
                var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
             
                if ((txtStartDate.value == "") && (txtEndDate.value == ""))
                {
                    alert("Please enter some search criteria");
                    return false;
                }
                else if ((txtStartDate.value != "") && (txtEndDate.value == "")) 
                {
                    alert("Please enter End Date");
                    return false;
                }
                else if ((txtStartDate.value == "") && (txtEndDate.value != "")) {
                    alert("Please enter Start Date");
                    return false;
                }
            }
    
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();
        
        function requestFailed()
        {}

        function StartGetChart(Duration, selimage) {
            
            var hfDuration = document.getElementById('<%=hfDuration.ClientID %>');
            hfDuration.value=Duration;            
            
            var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
            var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
            
            txtStartDate.value = "";
            txtEndDate.value = "";
            
            ViewTab();
            getSummary(document.getElementById('<%=this.hfCategoryID.ClientID%>').value);
            
            document.getElementById('divgridCategoryCustomer').style.display = 'none';
            postRequest.url = "AsyncChartCampaignCategory.aspx?CategoryCustomer=true&Duration=" + Duration + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value;
	        postRequest.successCallback = SetChartImage;
	        postRequest.post("");

	        document.getElementById('imgchart').src = "/App/Images/indicator_chartbox.gif";
	        document.getElementById('imgCStoday').src = "/App/Images/MarketingPartner/today-tab-off_mp.gif";
	        document.getElementById('imgCSWeek').src = "/App/Images/MarketingPartner/last7-gtab-off.gif";
	        document.getElementById('imgCSMonth').src = "/App/Images/MarketingPartner/last30-gtab-off.gif";
	        document.getElementById('imgCSAll').src = "/App/Images/MarketingPartner/All-tab-off_mp.gif";
	        
	        
	        var selsrc = document.getElementById(selimage).src;	        
	        document.getElementById(selimage).src = selsrc.replace('off', 'on');
	        document.getElementById('divgridCategoryCustomer').style.display = 'block';
        }
        function StartGetChartDateRange(Duration, selimage) {
            var hfDuration = document.getElementById('<%=hfDuration.ClientID %>');
            hfDuration.value=Duration;
            
            var txtStartDate = document.getElementById('<%=txtStartDate.ClientID %>');
            var txtEndDate = document.getElementById('<%=txtEndDate.ClientID %>');
            
            ViewTab();
            getSummary(document.getElementById('<%=this.hfCategoryID.ClientID%>').value);
            
            document.getElementById('divgridCategoryCustomer').style.display = 'none';
            postRequest.url = "AsyncChartCampaignCategory.aspx?CategoryCustomer=true&Duration=" + Duration + "&startdate=" + txtStartDate.value + "&enddate=" + txtEndDate.value;
            postRequest.successCallback = SetChartImage;
            postRequest.post("");

            document.getElementById('imgchart').src = "/App/Images/indicator_chartbox.gif";
            document.getElementById('imgCStoday').src = "/App/Images/MarketingPartner/today-tab-off_mp.gif";
            document.getElementById('imgCSWeek').src = "/App/Images/MarketingPartner/last7-gtab-off.gif";
            document.getElementById('imgCSMonth').src = "/App/Images/MarketingPartner/last30-gtab-off.gif";
            document.getElementById('imgCSAll').src = "/App/Images/MarketingPartner/All-tab-off_mp.gif";

            var selsrc = document.getElementById(selimage).src;
            document.getElementById(selimage).src = selsrc.replace('off', 'on');
            document.getElementById('divgridCategoryCustomer').style.display = 'block';
        }
        function SetChartImage(httpRequest)
        {
            var responsetext = httpRequest.responseText;

            var index = responsetext.indexOf(",,");
            var imgsource = responsetext.substring(0, index);

            var mapIndex1 = responsetext.indexOf("<map");
            var mapIndex2 = responsetext.indexOf("</map>");

            var imgchart=document.getElementById('imgchart');
            imgchart.src = imgsource;

            if (mapIndex1 != -1) {
                var map = responsetext.substring(mapIndex1, mapIndex2 + 6);
                var divMap=document.getElementById('divMap');
                divMap.innerHTML = map;

            }

            var gridIndex1 = responsetext.indexOf("<!--Start Category Grid-->");
            var gridIndex2 = responsetext.indexOf("<!--End Category Grid-->");
            if (gridIndex1 != -1) {
                var grid = responsetext.substring(gridIndex1 + 26, gridIndex2);

                document.getElementById('divgridCategoryCustomer').innerHTML = grid;
                var tableIndex1 = responsetext.indexOf("<table");

                if (tableIndex1 == -1) {
                    document.getElementById('divData').style.display = 'none';
                    document.getElementById('dvNoRecordFound').style.display = 'block';
                    
                }
                else {
                    document.getElementById('divData').style.display = 'block';
                    document.getElementById('dvNoRecordFound').style.display = 'none';
                }
            }
            
        }
        function SetDetailsTitle(categoryid, startdate, enddate, duration) {
            var spcategory = document.getElementById('<%=spcategory.ClientID %>');
            var spStartDate = document.getElementById('<%=spStartDate.ClientID %>');
            var spEndDate = document.getElementById('<%=spEndDate.ClientID %>');
            
                    var currentTime = new Date();
                    var month = currentTime.getMonth() + 1;
                    var day = currentTime.getDate();
                    var year = currentTime.getFullYear();
            var todayDate= month + "/" + day + "/" + year;
            
            if ((startdate != '') && (enddate != '')) {
                spStartDate.innerHTML = " from " + startdate;
                spEndDate.innerHTML = " to " + enddate;
            }
            else 
            {
                if (duration == "Today") {
                    spStartDate.innerHTML = " from " + todayDate;
                    spEndDate.innerHTML = " to " + todayDate;
                }
                else if (duration == "Week") {
                    var d = new Date();
                    d.setDate(d.getDate() - 6);
                    spStartDate.innerHTML = " from " + (d.getMonth() + 1) + "/" + (d.getDate()) + "/" + (d.getFullYear());
                    spEndDate.innerHTML = " to " + todayDate;

                }
                else if (duration == "Month") {
                    var d = new Date();
                    d.setDate(d.getDate() - 29);
                    spStartDate.innerHTML = " from " + (d.getMonth() + 1) + "/" + (d.getDate()) + "/" + (d.getFullYear());
                    spEndDate.innerHTML = " to " + todayDate;
                }
                else 
                {
                    spStartDate.innerHTML = "";
                    spEndDate.innerHTML = "";
                }
            }

            if (categoryid == 0) { spcategory.innerHTML = 'All'; }
            if (categoryid == 1) { spcategory.innerHTML = 'Grassroot'; }
            if (categoryid == 2) { spcategory.innerHTML = 'Print'; }
            if (categoryid == 3) { spcategory.innerHTML = 'Advocate Group'; }
            if (categoryid == 4) { spcategory.innerHTML = 'Internet'; }
            if (categoryid == 5) { spcategory.innerHTML = 'Direct Mail'; }
            if (categoryid == 6) { spcategory.innerHTML = 'Other'; }
        }
    </script>

    <div class="mainbody_outer">
        <asp:HiddenField ID="hfDuration" runat="server" />
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body" style="width: 753px;">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" alt="" /></p>
                    <span class="orngheadtxt_heading" runat="server" id="sptitle">Marketing Break-Up</span>
                  
                </div> 
                 <p >
                    
                     <span class="titletextnowidth_default"  style="margin-right: 20px">Show records from:</span> 
                     <span class="dateinputfldnowidth_cl">Start
                                        Date&nbsp;<asp:TextBox ID="txtStartDate" runat="server" 
                                CssClass="inputf_def" Width="70px"></asp:TextBox>
                                
                                    </span><span class="calendarcntrl_default">
                                    <cc1:CalendarExtender ID="calStart" runat="server" TargetControlID="txtStartDate"
                                        PopupButtonID="imgCalendarStart" Animated="true" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                                        <asp:ImageButton ID="imgCalendarStart" runat="server" ImageUrl="~/App/Images/calendar-icon.gif"
                                            CssClass=""></asp:ImageButton>
                                    </span><span class="dateinputfldnowidth_cl">&nbsp;&nbsp;End Date &nbsp;<asp:TextBox
                                        ID="txtEndDate" runat="server" CssClass="inputf_def" Width="70px"></asp:TextBox>
                                    </span><span class="calendarcntrl_default">
                                        <cc1:CalendarExtender ID="calEnd" runat="server" TargetControlID="txtEndDate" PopupButtonID="imgCalendarEnd"
                                        Animated="true" Format="MM/dd/yyyy">
                                    </cc1:CalendarExtender>
                            <asp:ImageButton ID="imgCalendarEnd" runat="server" ImageUrl="~/App/Images/calendar-icon.gif"
                                            CssClass=""></asp:ImageButton>
                                         </span>  
                                     <span class="button_con_nowidth">
                                        <asp:ImageButton ID="ibtnClear" runat="server" OnClientClick="return ClearDateSearch();" ImageUrl="~/App/Images/clear-btn.gif" />  
                                     </span>
                                      <span class="button_con_nowidth">
                                        <asp:ImageButton ID="ibtnFilter" runat="server" OnClientClick="return ValidateDate();" ImageUrl="~/App/Images/Filter-btn.gif" onclick="ibtnFilter_Click" />
                                     </span>
                                          
                                           
                                   
                        </p>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="2px" /></p>
                <p class="graylinefull_common">
                    <img src="/App/Images/specer.gif" width="1px" height="1px" /></p>
                <p>
                    <img src="/App/Images/specer.gif" width="750px" height="10px" /></p>
            </div>
            <div class="main_area_bdrnone">
                <div style="float: left; width: 710px; height: 27px">
                    <a href="javascript:StartGetChart('Today', 'imgCStoday');">
                        <img id="imgCStoday" src="/App/Images/MarketingPartner/today-tab-off_mp.gif" alt="" /></a>
                    <a href="javascript:StartGetChart('Week', 'imgCSWeek');">
                        <img id="imgCSWeek" src="/App/Images/MarketingPartner/last7-gtab-off.gif" alt="" /></a>
                    <a href="javascript:StartGetChart('Month', 'imgCSMonth');">
                        <img id="imgCSMonth" src="/App/Images/MarketingPartner/last30-gtab-off.gif" alt="" /></a>
                    <a href="javascript:StartGetChart('All', 'imgCSAll');">
                        <img id="imgCSAll" src="/App/Images/MarketingPartner/All-tab-off_mp.gif" alt="" /></a>
                </div>
                <div id="divData" style="float: left; width: 748px; height: 270px; border: solid 1px #D9E9FF">
                    <div id="divgridCategoryCustomer" style="float: left; width: 300px; height: 270px;
                        border-right: solid 1px #D9E9FF; background-color: #EFF8FD;">
                    </div>
                    <div style="float: left; width: 446px;">
                        <div id="divcschart" style="float: left">
                            <img id="imgchart" src="../../Images/indicator_chartbox.gif" usemap="#chartCategoryCustomerImageMap"
                                alt="" />
                            <div id="divMap">
                            </div>
                        </div>
                    </div>
                </div>
                
                  <div id="dvNoRecordFound"  style="display: none; float: left; width: 724px;
                    border: solid 1px #DFEEF5; padding: 10px 0px 10px 20px; text-align: center">
                    <div class="divnoitemfound1_custdbrd">
                        <p class="divnoitemtxt_custdbrd">
                            <span class="orngbold18_default">No Record Found</span>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    

    
    
    
    <%-- Grid starts here --%>
    <asp:HiddenField ID="hfView" runat="server" Value="Campaign" />
    <asp:HiddenField ID="hfCategoryID" runat="server"  />
     <asp:HiddenField ID="hfSalesRep" runat="server" />
    <div class="orngbuttons_pw1" style="display: none; text-align: center;" id="spnIndicator">
        <img src='<%=ResolveUrl("~/App/Images/indicator.gif") %>' />
    </div>
    <div class="mainbody_outer" style="display: block" id="dvCustomerDetails" runat="server">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="orngheadtxt_heading" style="padding-top: 8px; float: left;" id="dvLabel" runat="server">
                    <span id="spAdvName" runat="server"></span> Details for 
                    <span id="spcategory" runat="server" style="padding-right:5px">ALL</span><span id="spStartDate" runat="server"></span>
                    <span id="spEndDate" runat="server"></span>
                </div>
            </div>
            
 <%--  ##################################################--%>
<!-- Start Summary -->
            <asp:HiddenField ID="hdSummaryLoaded" runat="server" /> 

                
                <div id="dvSummaryResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgSummaryLoading">
                <img src="/App/Images/indicatorbig.gif" />
               
                </div>
               
           
<!-- End Summary -->
<%--  ##################################################--%>      
  <div class="divmainbody_cd" style="margin-top: 5px;display:none">
    <fieldset style="margin: 0px; padding: 0px;">
        <legend class="legendhead_default" style="font-size:14px;">Summary</legend>
            <div class="legendrow_default">
                <div class="mainwrapper_ad">                    
                    <div class="innerswrapperl_ad">
                        <p class="headtxt">Performance:</p>
                        <p class="rows">
                            <span class="ttext_ad">Prospects:</span>
                            <span class="dtext_ad">
                                <span id="spProspects" runat="server"></span>
                                <span id="spProspectPercent" runat="server"></span>
                            </span>
                        </p>
                          <p class="rows">
                            <span class="ttext_ad">Signups:</span>
                            <span class="dtext_ad">
                                <span id="spSignup" runat="server"></span>
                                <span id="spSignUpPercent" runat="server"></span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Customers:</span>
                            <span class="dtext_ad">
                                <span id="spCustomer" runat="server"></span>
                                <span id="spCustomerPercent" runat="server"></span>
                            </span>
                         </p>
                    </div>
                    
                     <div class="innerswrapperl_ad">
                      <p class="headtxt">Expenses:</p>
                        <p class="rows">
                            <span class="ttext_ad">Total Expenses:</span>
                            <span class="dtext_ad">
                               <span id="spExpences" runat="server"></span>
                            </span>
                        </p>
                          <p class="rows">
                            <span class="ttext_ad">Pending Commission:</span>
                            <span class="dtext_ad">
                                <span id="spPendingCommission" runat="server">$.00</span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Realized Commission:</span>
                            <span class="dtext_ad">
                                 <span id="spRealizedCommission" runat="server">$.00</span>
                            </span>
                         </p>
                     </div>
                     
                      <div class="innerswrapperr_ad">
                      <p class="headtxt">Revenue:</p>
                        <p class="rows">
                            <span class="ttext_ad">Total Revenue:</span>
                            <span class="dtext_ad">
                              <span id="spTotalRevenue" runat="server"></span>
                              <span id="spTotalRevenuePercent" runat="server"></span>
                            </span>
                        </p>
                          <p class="rows">
                            <span class="ttext_ad">Phone:</span>
                            <span class="dtext_ad">
                               <span id="spPhRevenue" runat="server"></span>
                               <span id="spPhRevenuePercent" runat="server"></span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Internet:</span>
                            <span class="dtext_ad">
                                 <span id="spInterRevenue" runat="server"></span> 
                                <span id="spInterRevenuePercent" runat="server"></span> 
                            </span>
                         </p>
                         <p class="rows">
                            <span class="ttext_ad">WalkIn:</span>
                            <span class="dtext_ad">
                                 <span id="spWalkinRevenue" runat="server"></span>
                                <span id="spWalkinRevenuePercent" runat="server"></span>
                            </span>
                         </p>
                     </div>
                </div>
                
                <div class="mainwrapperb_ad">                    
                    <div class="innerswrapperl_ad" style="padding-top:5px;">
                        <p class="headtxt">Phone:</p>
                        <p class="rows">
                            <span class="ttext_ad">Calls:</span>
                            <span class="dtext_ad">
                                <span id="spPhCall" runat="server">N/A</span>
                                <span id="spPhCallPercent" runat="server">N/A</span>
                            </span>
                        </p>
                          <p class="rows">
                            <span class="ttext_ad">Prospects:</span>
                            <span class="dtext_ad">
                                 <span id="spPhProspects" runat="server">N/A</span>
                                 <span id="spPhProspectsPercent" runat="server">N/A</span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Signups:</span>
                            <span class="dtext_ad">
                                <span id="spPhSignup" runat="server"></span>
                             <span id="spPhSignupPercent" runat="server"></span>
                            </span>
                         </p>
                         <p class="rows">
                            <span class="ttext_ad">Customers:</span>
                            <span class="dtext_ad">
                                <span id="spPhCustomer" runat="server"></span>
                                <span id="spPhCustomerPercent" runat="server"></span>
                            </span>
                         </p>
                    </div>
                    
                     <div class="innerswrapperl_ad" style="padding-top:5px;">
                      <p class="headtxt">Internet:</p>
                        <p class="rows">
                            <span class="ttext_ad">Clicks:</span>
                            <span class="dtext_ad">
                               <span id="spInClick" runat="server" >N/A</span>
                               <span id="spInClickPercent" runat="server" >N/A</span>
                            </span>
                        </p>
                          <p class="rows">
                            <span class="ttext_ad">Prospects:</span>
                            <span class="dtext_ad">
                                <span id="spInProspect" runat="server">N/A</span>
                                <span id="spInProspectPercent" runat="server">N/A</span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Signups:</span>
                            <span class="dtext_ad">
                                 <span id="spInSignup" runat="server"></span>
                                 <span id="spInSignupPercent" runat="server"></span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Customers:</span>
                            <span class="dtext_ad">
                                <span id="spInCustomer" runat="server"></span>
                                 <span id="spInCustomerPercent" runat="server"></span>
                            </span>
                         </p>
                     </div>
                     
                      <div class="innerswrapperr_ad" style="padding-top:5px;">
                      <p class="headtxt">Walkin:</p>
                        <p class="rows">
                            <span class="ttext_ad">Prospects:</span>
                            <span class="dtext_ad">
                               <span id="spWProspect" runat="server">N/A</span> 
                              <span id="spWProspectPercent" runat="server">N/A</span>
                            </span>
                        </p>
                          <p class="rows">
                            <span class="ttext_ad">Signups:</span>
                            <span class="dtext_ad">
                               <span id="spWSignup" runat="server"></span>
                                <span id="spWSignupPercent" runat="server"></span>
                            </span>
                         </p>
                          <p class="rows">
                            <span class="ttext_ad">Customers:</span>
                            <span class="dtext_ad">
                                 <span id="spWCustomer" runat="server"></span>
                                 <span id="spWCustomerPercent" runat="server"></span>
                            </span>
                         </p>
                     </div>
                </div>
                
                
                
            </div>
        </fieldset>
   </div>
  
  
            
           
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="10px" /></p>
            <p class="main_row_custdbrd" style="height: 27px;">
             <span style="float:left">
                <a href="javascript:void(0);">
                    <a href="javascript:void(0);"><img id="imgAdvocate" runat="server" src='~/App/Images/MarketingPartner/Advocates-taboff.gif' onclick="View('Advocate')" /></a>
                    <img id="imgCampaign" runat="server" src='~/App/Images/MarketingPartner/campaigns-tabon.gif' onclick="View('Campaign')" />
                </a>
                <a href="javascript:void(0);"><img id="imgSignup" runat="server" alt="" src='~/App/Images/MarketingPartner/signups-blutab-off.gif' onclick="View('Signup')" /></a>
                <a href="javascript:void(0);"><img id="imgCustomer" alt="" runat="server" src='~/App/Images/MarketingPartner/Cusotmers-taboff.gif' onclick="View('Customer')" /></a>
                <a href="javascript:void(0);"><img id="imgPaidCustomer" alt="" runat="server" src='~/App/Images/MarketingPartner/PaidCusotmers-taboff.gif' onclick="View('PaidCustomer')" /></a>
                <a href="javascript:void(0);"><img id="imgCall" alt="" runat="server" src='~/App/Images/MarketingPartner/Calls-taboff.gif' onclick="View('Call')" /></a>
                <a href="javascript:void(0);"><img id="imgPayment" alt="" runat="server" src='~/App/Images/MarketingPartner/Payments-taboff.gif' onclick="View('Payment')" /></a>
                <a href="javascript:void(0); "><img id="imgCustomerGraph" alt="" runat="server" src='~/App/Images/MarketingPartner/graph-taboff.gif' onclick="View('Graph')" /></a>
                <a href="javascript:alert('Please check this in next release'); "> <img style="display:none" id="imgHistory" runat="server" src='~/App/Images/MarketingPartner/history-taboff.gif' onclick="View('History')" /></a>
             </span>
                  
                  
                  
            </p>
            <%--  ##################################################--%>
            <!-- Start Grid Campaigns -->
            <asp:HiddenField ID="hdCampaignLoaded" runat="server" />
             <div style="float: left; display: none" id="dvCampaign" runat="server">
                
                <div id="dvGridCampaignResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgCampaignLoading">
                <img src="/App/Images/indicatorbig.gif" />
               
                </div>
               
            </div>
            <!-- End Grid Campaigns -->
            <%--  ##################################################--%>
            <%--  ##################################################--%>
            <!-- Start Grid SignUp -->
            <asp:HiddenField ID="hdSignupLoaded" runat="server" />
             <div style="float: left; display: none" id="dvSignup" runat="server">
                
                <div id="dvGridSignupResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgSignupLoading">
                <img src="/App/Images/indicatorbig.gif" />
               
                </div>
                
                                
                
            </div>
         
            <!-- End Grid Signup -->
            <%--  ##################################################--%>
            
            <%--  ##################################################--%>
            <!-- Start Grid customer -->
            <asp:HiddenField ID="hdCustomerLoaded" runat="server" />
             <div style="float: left; display: none" id="dvCustomer" runat="server">
                
                <div id="dvGridCustomerResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgCustomerLoading">
                <img src="/App/Images/indicatorbig.gif" />
               
                </div>
                
                                
                
            </div>
            
            <!-- End Grid Customer -->
            <%--  ##################################################--%>
            
             <%--  ##################################################--%>
            <!-- Start Grid customer -->
            <asp:HiddenField ID="hdPaidCustomerLoaded" runat="server" />
             <div style="float: left; display: none" id="dvPaidCustomer" runat="server">
               <div id="dvGridPaidCustomerResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgPaidCustomerLoading">
                <img src="/App/Images/indicatorbig.gif" />
             </div>
             
            </div>
            
            <!-- End Grid Customer -->
            <%--  ##################################################--%>
              <%--  ##################################################--%>
            <!-- Start Grid Call -->
            <asp:HiddenField ID="hdCallLoaded" runat="server" />
             <div style="float: left; display: none" id="dvCall" runat="server">
               <div id="dvGridCallResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgCallLoading">
                <img src="/App/Images/indicatorbig.gif" />
             </div>
             
            </div>
            
            <!-- End Grid Call -->
            <%--  ##################################################--%>
            <%--  ##################################################--%>
             <!-- Start Grid Payment -->
            <asp:HiddenField ID="hdPaymentLoaded" runat="server" />
             <div style="float: left; display: none" id="dvPayment" runat="server">
                
                <div id="dvGridPaymentResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgPaymentLoading">
                <img src="/App/Images/indicatorbig.gif" />
               
                </div>
               
            </div>
            <!-- End Grid Payment -->
            <%--  ##################################################--%>
          
            <%--  ##################################################--%>
            <!-- Start Graph -->
            <div id="dvGraph"  style="float: left; width: 714px; display: none; padding: 10px 10px 10px 20px;
            border: solid 1px #DFEEF5;" runat="server">
                    <img id="imgGrpah" src="../../Images/indicator_chartbox.gif"  alt="" />                            
            
            </div>
            <!-- End Graph -->
            <%--  ##################################################--%>
            
            <%--  ##################################################--%>
            <!-- Start Grid Payment -->
            <div style="float: left; display: none" id="dvHistory" runat="server">
                <div id="Div2" runat="server" style="width: 714px; padding: 10px 10px 10px 20px;
                    float: left; border: solid 1px #DFEEF5; display: none">
                    <div class="divnoitemfound1_custdbrd">
                        <p class="divnoitemtxt_custdbrd">
                            <span class="orngbold18_default">No Record Found</span>
                        </p>
                    </div>
                </div>
                <div id="Div3" runat="server">
                    <div style="float: left; width: 746px">
                    </div>
                </div>
            </div>
            <!-- End Grid Payment -->
            <%--  ##################################################--%>
             <%--  ##################################################--%>
            <!-- Start Grid Campaigns -->
            <asp:HiddenField ID="hdAdvocateLoaded" runat="server" />
             <div style="float: left; display: none" id="dvAdvocate" runat="server">
                
                <div id="dvGridAdvocateResult"   style="float: left; width: 746px"></div>
                <div style="float:left; width:744px; border:solid 1px #DFEEF5; height:120px; padding-top:70px; text-align:center; display:none" id="imgAdvocateLoading">
                <img src="/App/Images/indicatorbig.gif" />
               
                </div>
               
            </div>
            <!-- End Grid Campaigns -->
            <%--  ##################################################--%>
        </div>
        <p>
            <img src="/App/Images/specer.gif" width="725px" height="40px" alt="" /></p>
    </div>
    <%-- Grid Ends Here--%>
</asp:Content>
