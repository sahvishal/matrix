<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewEventPrintOrders.ascx.cs" Inherits="HealthYes.Web.App.UCCommon.UCViewEventPrintOrders" %>
<script language="javascript" type="text/javascript">
        
    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();
    function requestFailed(){}
    
    // Print Orders
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    function ViewPrintOrders(eventid,pagenumber,pagesize,sortcolumn,sortorder)
    {
                HideAllDiv();
                // display loading gif
                document.getElementById('divLoading').style.display = 'block';
                url="/App/Common/AsyncViewEventPrintOrder.aspx?type=PrintOrder";
                // request parameters               
                url = url + "&eventid=" + eventid;
                url=url + "&pageindex=" + pagenumber;
                url=url + "&pagesize=" + pagesize;
                if (sortorder!='' && sortcolumn!='')
                {
                    url=url + "&sortorder=" + sortorder;
                    url=url + "&sortcolumn=" + sortcolumn;
                }
                // alert(url);
                // seminars
                 postRequest.url = url;
	             postRequest.successCallback = SetPrintOrderGrid;
	             postRequest.failureCallback = requestFailed();
                 postRequest.post("");
   }
  function SetPrintOrderGrid(httpRequest)
  {        
            var result= httpRequest.responseText;
            if(result.indexOf('No Record Found') > -1 )
            {
                document.getElementById('divUCPrintOrders').innerHTML ='';
                document.getElementById('divUCPrintOrders').style.display = 'none';
                document.getElementById('divNoRecord').style.display = 'block';
            }
            else if(result.indexOf('Some Error occured') > -1 )
            {
                document.getElementById('divUCPrintOrders').innerHTML = httpRequest.responseText;
                document.getElementById('divUCPrintOrders').style.display = 'block';
                document.getElementById('divPrintOrders').style.display = 'block';
            }
            else 
            {
                document.getElementById('divUCPrintOrders').innerHTML = httpRequest.responseText ;
                document.getElementById('divUCPrintOrders').style.display = 'block';
                document.getElementById('divPrintOrders').style.display='block';
            }
            document.getElementById('divLoading').style.display = 'none';
            $('.jtipImagePrintOrder').cluetip({splitTitle: '|',cursor: 'pointer',tracking: true,cluetipClass: 'jtip', arrows: true, dropShadow: false, ajaxCache: false, hoverIntent: false,width:400 });
  }
  
  function PendingFunctionality()
  {
        alert("Pending Functionality.");
        return false;
  }
    
    // Print Orders
    // ------------------------------------------------------------------------------------------------------------------------------------------------------

</script>
<div style="float:left; width:746px" id="divUCPrintOrders">
</div>