<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCViewEventCampaigns.ascx.cs" Inherits="HealthYes.Web.App.UCCommon.UCViewEventCampaigns" %>
<script language="javascript" type="text/javascript">
        
    var postRequest = new HttpRequest();
    postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
    postRequest.failureCallback = requestFailed();
    function requestFailed(){}
    
    // Campaigns
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    function ViewCampaigns(eventid,pagenumber,pagesize)
    {
                HideAllDiv();
                // display loading gif
                document.getElementById('divLoading').style.display = 'block';
                url="/App/Common/AsyncViewEventCampaigns.aspx?type=Campaign";
                // request parameters               
                url = url + "&eventid=" + eventid;
                url=url + "&pageindex=" + pagenumber;
                url=url + "&pagesize=" + pagesize;
                // alert(url);
                // seminars
                 postRequest.url = url;
	             postRequest.successCallback = SetCampaignGrid;
	             postRequest.failureCallback = requestFailed();
                 postRequest.post("");
    }
    function SetCampaignGrid(httpRequest)
        {       
            var result= httpRequest.responseText;
            //alert(result);
            if(result.indexOf('No Record Found') > -1 )
            {
                document.getElementById('divNoRecord').style.display = 'block';
            }
            else if(result.indexOf('Some Error occured') > -1 )
            {
                document.getElementById('divUCCampaigns').innerHTML = httpRequest.responseText;
                document.getElementById('divUCCampaigns').style.display = 'block';
                document.getElementById('divCampaigns').style.display = 'block';
            }
            else 
            {
                document.getElementById('divUCCampaigns').innerHTML = httpRequest.responseText ;
                document.getElementById('divUCCampaigns').style.display = 'block';
                document.getElementById('divCampaigns').style.display='block';
            }
            document.getElementById('divLoading').style.display = 'none';
    }
    
    // Campaign
    // ------------------------------------------------------------------------------------------------------------------------------------------------------
    
    function ViewMM(CampaignID,CampaignName,CampaignStart,CampaignEnd,Commission)
    {
        //var strQueryString='CampaignID='+ CampaignID + '&CampaignName='+ CampaignName +'&Strat='+ CampaignStart +'&End='+ CampaignEnd +'&Commission='+ Commission ;
        var strQueryString='CampaignID='+ CampaignID  ;
        var load = window.open('/App/MarketingPartner/MMPopup.aspx?'+ strQueryString,'','scrollbars=no,menubar=no,height=650,width=904,resizable=no,toolbar=no,left=50,top=10');
    }

</script>
<div style="float:left; width:746px" id="divUCCampaigns">
</div>