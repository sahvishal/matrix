<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCWellnessSeminar.ascx.cs" Inherits="HealthYes.Web.App.UCCommon.UCWellnessSeminar" %>
<script language="javascript" type="text/javascript">
        
    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();
    function requestFailed(){}
    
    // Begin Welness
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    function ViewWellness(eventid,pagenumber,pagesize,sortcolumn,sortorder)
    {
               
                HideAllDiv();
                document.getElementById('divLoading').style.display = 'block';
                url="/App/Common/AsyncWellness.aspx?type=Wellness";
                // request parameters               
                url = url + "&eventid=" + eventid;
                url=url + "&pageindex=" + pagenumber;
                url=url + "&pagesize=" + pagesize;
                url=url + "&sortorder=" + sortorder;
                url=url + "&sortcolumn=" + sortcolumn;
                
                // alert(url);
                // seminars
                    postRequest.url = url;
	                postRequest.successCallback = SetWelnessSeminar;
	                postRequest.failureCallback = requestFailed();
                    postRequest.post("");
    }
    function SetWelnessSeminar(httpRequest)
        {        
            var result= httpRequest.responseText;
            //RedirectToLogin(result);
            if(result.indexOf('No Record Found') > -1 )
            {
                document.getElementById('divNoRecord').style.display = 'block';
            }
            else if(result.indexOf('Some Error occured') > -1 )
            {
                document.getElementById('divUCWellness').innerHTML = httpRequest.responseText;
                document.getElementById('divUCWellness').style.display = 'block';
                document.getElementById('divWellness').style.display = 'block';
            }
            else 
            {
                document.getElementById('divUCWellness').innerHTML = httpRequest.responseText ;
                document.getElementById('divUCWellness').style.display = 'block';
                document.getElementById('divWellness').style.display = 'block';
                $('.jtip').cluetip({splitTitle: '|',cursor: 'pointer',tracking: true,cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false,width:400 });
            }
            
            document.getElementById('divLoading').style.display = 'none';
    }
    
    // End Welness
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
</script>
<div style="float:left; width:746px" id="divUCWellness">
</div>