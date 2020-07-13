//*****************************************************************************
// HttpRequest
//   Defines a object for making asynchronous HTTP GET and POST requests.
//
//   It is basically a wrapper for the XmlHttpRequest object that hides
//   differences between browsers and makes it easier to set up callback
//   functions.
//-----------------------------------------------------------------------------
// Constructor:
//
//   HttpRequest()
//     Creates a new instance of the HttpRequest object.
//
//     Notes: Be sure to set the url property before calling get() or post().
//     Likewise, if you want to process the response, set the successCallback
//     property. To process errors on an unsuccessful request, set the
//     failureCallback property (see below).
//-----------------------------------------------------------------------------
// Properties:
//
//   successCallback
//     A function to be called when a GET or POST request completes
//     successfully (i.e., the HTTP status is "200 OK"). The function should
//     accept one argument which will be the HttpRequest object that made the
//     request
//
//   failureCallback
//     A function to be called when a GET or POST request completes
//     unsuccessfully (i.e., the HTTP status is anything other than "200 OK").
//     The function should accept one argument which will be the HttpRequest
//     object that made the request
//
//   url
//     The URL to send the request to. It should not include a query string.
//
//   queryString
//     A query string to append to the URL.
//
//   username
//     Username for authentication, if required.
//
//   password
//     Password for authentication, if required.
//
//   status
//     The status of the response returned from a request. This will be an
//     HTTP status code. For example, a sucessful call returns 200.
//
//   statusText
//     The text associated with the status code. For example, the text for HTTP
//     status code 404 is "Object Not Found".
//
//   responseText
//     A string representing the data returned from a request.
//
//   responseXML
//     A DOM document object representing the XML returned from a request.
//-----------------------------------------------------------------------------
// Methods:
//
//   abort()
//     Aborts a request that is in currently progress.
//
//   setRequestHeader(name, value)
//     Sets the specified request header.
//
//   getRequestHeader(name)
//     Returns the value of the specified request header.
//
//   removeRequestHeader(name, value)
//     Removes the the specified request header.
//
//   clearRequestHeaders()
//     Removes all request headers.
//
//   get()
//     Performs an asynchronous GET request.
//
//   post(data)
//     Performs an asynchronous POST request, passing the given data. Be sure
//     to set the "Content-Type" request header appropriately prior to calling
//     post().
//
//   getResponseHeader(name)
//     Returns the value of the named response header returned from a request.
//
//   getAllResponseHeaders()
//     Returns a string containing all the response headers returned from a
//     request.
//*****************************************************************************

// Define a list of Microsoft XML HTTP ProgIDs.
HttpRequest.prototype.MS_PROGIDS = new Array(
	"Msxml2.XMLHTTP.7.0",
	"Msxml2.XMLHTTP.6.0",
	"Msxml2.XMLHTTP.5.0",
	"Msxml2.XMLHTTP.4.0",
	"MSXML2.XMLHTTP.3.0",
	"MSXML2.XMLHTTP",
	"Microsoft.XMLHTTP"
);

// Define constants.
HttpRequest.prototype.READY_STATE_UNINITIALIZED = 0;
HttpRequest.prototype.READY_STATE_LOADING       = 1;
HttpRequest.prototype.READY_STATE_LOADED        = 2;
HttpRequest.prototype.READY_STATE_INTERACTIVE   = 3;
HttpRequest.prototype.READY_STATE_COMPLETED     = 4;

// Define properties.
HttpRequest.prototype.successCallback = null;
HttpRequest.prototype.failureCallback = null;
HttpRequest.prototype.url             = null;
HttpRequest.prototype.username        = null;
HttpRequest.prototype.password        = null;
HttpRequest.prototype.requestHeaders  = new Array();
HttpRequest.prototype.status          = null;
HttpRequest.prototype.statusText      = null;
HttpRequest.prototype.responseXML     = null;
HttpRequest.prototype.responseText    = null;

// Define methods.
HttpRequest.prototype.abort                 = HttpRequestAbort;
HttpRequest.prototype.setRequestHeader      = HttpRequestSetRequestHeader;
HttpRequest.prototype.clearRequestHeaders   = HttpRequestClearRequestHeaders;
HttpRequest.prototype.get                   = HttpRequestGet;
HttpRequest.prototype.post                  = HttpRequestPost;
HttpRequest.prototype.initiateRequest       = HttpRequestInitiateRequest;
HttpRequest.prototype.getResponseHeader     = HttpRequestGetResponseHeader;
HttpRequest.prototype.getAllResponseHeaders = HttpRequestGetAllResponseHeaders;

//=============================================================================
// Contructor function.
//=============================================================================
function HttpRequest()
{
	// Create the appropriate HttpRequest object for the browser.
	this.xmlHttpRequest = null;

	if (window.XMLHttpRequest != null)
		this.xmlHttpRequest = new window.XMLHttpRequest();
	else if (window.ActiveXObject != null)
	{
		// Must be IE, find the right ActiveXObject.
		var success = false;
		for (var i = 0; i < HttpRequest.prototype.MS_PROGIDS.length && !success; i++)
		{
			try
			{
				this.xmlHttpRequest = new ActiveXObject(HttpRequest.prototype.MS_PROGIDS[i]);
				success = true;
			}
			catch (ex)
			{}
		}
	}

	// If we couldn't create one, display an error and exit
	if (this.xmlHttpRequest == null)
	{
		alert("Error in HttpRequest():\n\nCannot create an XMLHttpRequest object.");
		return;
	}
}

//=============================================================================
// Methods.
//=============================================================================

function HttpRequestAbort()
{
	this.xmlHttpRequest.abort();
}

function HttpRequestSetRequestHeader(name, value)
{
	// If the header name already exists, replace the value.
	for (var i = 0; i < this.requestHeaders.length; i++)
	{
		var pair = this.requestHeaders[i].split("\n");
		if (pair[0].toLowerCase() == name.toLowerCase())
		{
			this.requestHeaders[i] = name + "\n" + value;
			return;
		}
	}

	// Otherwise, add it as a new item.
	var n = this.requestHeaders.length;
	this.requestHeaders.push(name + "\n" + value);
}

function HttpRequestClearRequestHeaders()
{
	this.requestHeaders = new Array();
}

function HttpRequestGet()
{
	this.initiateRequest("GET", null);
}

function HttpRequestPost(data)
{
	this.initiateRequest("POST", data);
}

function HttpRequestGetResponseHeader(name)
{
	return this.xmlHttpRequest.getResponseHeader(name);
}

function HttpRequestGetAllResponseHeaders()
{
	return this.xmlHttpRequest.getAllResponseHeaders();
}

//=============================================================================
// Internal method to make the actual request.
//=============================================================================
function HttpRequestInitiateRequest(method, data)
{
	// For IE, abort any current request.
	if (window.ActiveXObject != null)
		this.abort();

	// Clear all response fields.
	this.status       = null;
	this.statusText   = null;
	this.responseText = null;
	this.responseXML  = null;

	// Set up the callback functions.
	var refObj = this;
	this.xmlHttpRequest.onreadystatechange =
		function()
		{
			refObj.readyState = refObj.xmlHttpRequest.readyState
			if (refObj.readyState == HttpRequest.prototype.READY_STATE_COMPLETED)
			{
				refObj.status       = refObj.xmlHttpRequest.status;
				refObj.statusText   = refObj.xmlHttpRequest.statusText;
				refObj.responseText = refObj.xmlHttpRequest.responseText;
				refObj.responseXML  = refObj.xmlHttpRequest.responseXML;
				if (refObj.status == 200)
				{
					if (refObj.successCallback != null)
						refObj.successCallback(refObj);
				}
				else
				{
					if (refObj.failureCallback != null)
						refObj.failureCallback(refObj);
				}
			}
		}

	// Initialize the request.
	var url = this.url;
	if (this.queryString != null)
		url = url + "?" + this.queryString;
	this.xmlHttpRequest.open(method, url, true, this.username, this.password);

	// Set request headers (this must be done after the request is opened).
	for (var i = 0; i < this.requestHeaders.length; i++)
	{
		var pair = this.requestHeaders[i].split("\n");	
		this.xmlHttpRequest.setRequestHeader(pair[0], pair[1]);
	}

	// Start the request, passing any POST data.
	this.xmlHttpRequest.send(data);
}

function StringToXML(strRequest) {
    try //Internet Explorer
    {
        xmlDoc = new ActiveXObject("Microsoft.XMLDOM");
        xmlDoc.async = "false";
        xmlDoc.loadXML(strRequest);
        return xmlDoc;
    }
    catch (e) {
        try //Firefox, Mozilla, Opera, etc.
        {
            parser = new DOMParser();
            xmlDoc = parser.parseFromString(strRequest, "text/xml");
            return xmlDoc;
        }
        catch (e) { alert(e.message) }
    }


}