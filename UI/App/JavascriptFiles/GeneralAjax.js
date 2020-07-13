// JScript File


var XmlHttp;//Global XMLHTTP Request object


/*********************************************************************************
* Function:		        CreateXmlHttp
* DESCRIPTION:          This function creates the XMLHttp object.
* PARAMETERS:           N/A
* RETURNS:              Set up the global XMLHttp object
* Modification History:
***********************************************************************************/
function CreateXmlHttp()
{
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

function ActivateDeactivate(value,affiliateid)
{
   var requestUrl="AjaxServer.aspx?Activate="+value+"&AffiliateId="+affiliateid+"&Mode=1";
   CreateXmlHttp();
   if(XmlHttp)
   {
			//Setting the event handler for the response
			XmlHttp.onreadystatechange = HandleResponseforAffiliate;
			//Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			//Sends the request to server
			XmlHttp.send(null);		
	}
	else // Browser does not support XMLHTTPRequest object
	{
		alert("Browser does not support XMLHTTPRequest object." );		
	}  
	
}
function HandleResponseforAffiliate()
{
 //To make sure receiving response data from server is completed
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		// alert(XmlHttp.responseText);
		if(XmlHttp.status == 200) // response status is OK
		{		
			if(XmlHttp.responseText!="")
			{
		
			 alert("Affiliate's status changed successfully.");
			 XmlHttp=null;     
			// Load the response in the Document
		   }			
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
	}
		
}


function SendWelComeMail(username,password,defaultNumber,toEmail,DefaultPromocode,Name)
{ 

   var requestUrl="AjaxServer.aspx?Mode=2&username="+username+"&password="+password+"&defaultNumber="+defaultNumber+"&toEmail="+toEmail+"&DefaultPromocode="+DefaultPromocode+"&name="+Name;
   CreateXmlHttp();
   if(XmlHttp)
   {
			//Setting the event handler for the response
			XmlHttp.onreadystatechange = HandleResponseforWelcomeMail;
			//Initializes the request object with GET (METHOD of posting), Request URL and sets the request as asynchronous.
			XmlHttp.open("GET", requestUrl,  true);
			//Sends the request to server
			XmlHttp.send(null);		
	}
	else // Browser does not support XMLHTTPRequest object
	{
		alert("Browser does not support XMLHTTPRequest object." );		
	}       
        
	        
}
function HandleResponseforWelcomeMail()
{
 //To make sure receiving response data from server is completed
	if(XmlHttp.readyState == 4)
	{
		// To make sure valid response is received from the server, 200 means response received is OK
		// alert(XmlHttp.responseText);
		if(XmlHttp.status == 200) // response status is OK
		{		
			if(XmlHttp.responseText!="")
			{
		
			 alert("Welcome mail Sent Successfully.");
			 XmlHttp=null;   
			// Load the response in the Document
		   }			
		}
		else
		{
			alert("There was a problem retrieving data from the server." );
		}
	}
		  
}