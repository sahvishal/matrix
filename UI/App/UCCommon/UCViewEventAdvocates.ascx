<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewEventAdvocates.ascx.cs" Inherits="HealthYes.Web.App.UCCommon.UCViewEventAdvocates" %>
<script language="javascript" type="text/javascript">
        
    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();
    function requestFailed(){}
    
    // Advocate
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    function ViewAdvocates(eventid,pagenumber,pagesize)
    {
                HideAllDiv();            
                document.getElementById('divLoading').style.display = 'block';
                url="/App/Common/AsyncViewEventAdvocate.aspx?type=Advocate";
                // request parameters               
                url = url + "&eventid=" + eventid;
                url=url + "&pageindex=" + pagenumber;
                url=url + "&pagesize=" + pagesize;
                // alert(url);
                // seminars
                 postRequest.url = url;
	             postRequest.successCallback = SetAdvocateGrid;
	             postRequest.failureCallback = requestFailed();
                 postRequest.post("");
    }
    function SetAdvocateGrid(httpRequest)
        {        
            var result= httpRequest.responseText;
            if(result.indexOf('No Record Found') > -1 )
            {
                document.getElementById('divNoRecord').style.display = 'block';
            }
            else if(result.indexOf('Some Error occured') > -1 )
            {
                document.getElementById('divUCAdvocate').innerHTML = httpRequest.responseText;
                document.getElementById('divUCAdvocate').style.display = 'block';
                document.getElementById('divAdvocate').style.display = 'block';
            }
            else 
            {
                document.getElementById('divUCAdvocate').innerHTML = httpRequest.responseText ;
                document.getElementById('divUCAdvocate').style.display = 'block';
                document.getElementById('divAdvocate').style.display='block';
            }
            document.getElementById('divLoading').style.display = 'none';
    }
    
    // Advocate
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
</script>
<div style="float:left; width:746px" id="divUCAdvocate">
</div>