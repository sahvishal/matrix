<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewEventActivity.ascx.cs" Inherits="Falcon.App.UI.App.UCCommon.UCViewEventActivity" %>
<script language="javascript" type="text/javascript">
        
    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();
    function requestFailed(){}
    
    // Event Activity
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    function ViewEventActivity(eventid,pagenumber,pagesize,sortcolumn,sortorder)
    {
                HideAllDiv();
                // display loading gif
                document.getElementById('divLoading').style.display = 'block';
                url="/App/Common/AsyncViewEventActivity.aspx?type=Activities";
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
	             postRequest.successCallback = SetActivityGrid;
	             postRequest.failureCallback = requestFailed();
                 postRequest.post("");
   }
  function SetActivityGrid(httpRequest)
  {        
            var result= httpRequest.responseText;
            if(result.indexOf('No Record Found') > -1 )
            {
                document.getElementById('divUCActivity').innerHTML ='';
                document.getElementById('divUCActivity').style.display = 'none';
                document.getElementById('divNoRecord').style.display = 'block';
            }
            else if(result.indexOf('Some Error occured') > -1 )
            {
                document.getElementById('divUCActivity').innerHTML = httpRequest.responseText;
                document.getElementById('divUCActivity').style.display = 'block';
                document.getElementById('divActivity').style.display = 'block';
            }
            else 
            {
                document.getElementById('divUCActivity').innerHTML = httpRequest.responseText ;
                document.getElementById('divUCActivity').style.display = 'block';
                document.getElementById('divActivity').style.display='block';
            }
            document.getElementById('divLoading').style.display = 'none';
  }
  
 
    // Event Activity 
    // ------------------------------------------------------------------------------------------------------------------------------------------------------

</script>
<div style="float:left; width:746px" id="divUCActivity">
</div>