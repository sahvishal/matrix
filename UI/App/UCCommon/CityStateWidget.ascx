<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CityStateWidget.ascx.cs"
    Inherits="Falcon.App.UI.App.UCCommon.CityStateWidget" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<style type="text/css">
    #results
    {
        position: absolute;
        float: left;
        display: none;
        background-color: #fff;
        height: 100px;
        overflow-y: auto;
        overflow-x: hidden;
        font-size: 11px;
        border: solid 1px #7F9DB9;
    }
    .searchresult
    {
        height: 20px;
        width: 200px;
        border-bottom: 1px solid #7F9DB9;
        vertical-align: top;
        background: #f5f5f5;
    }
    .small
    {
        font: normal 9px arial;
    }
    .searchresult:hover
    {
        background-color: #ddd;
        cursor: hand;
    }
    .match
    {
        background-color: Yellow;
    }
</style>
<div>
    <JQueryControl:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="false" IncludeSexyComboBox="false" />

    <script language="javascript" type="text/javascript">
    
    $(document).ready(function() 
        {
            $('.ddl-state').change(function()
            {
                $(".txtSearch").val('');
            });
        
            $(".txtSearch").keyup(function() {
                    $("#results").empty();
                    
                    var searchString = $(".txtSearch").val();
                    
                    if(searchString.length < 3)
                    {
                        return;
                    }
                    var parameter = "{'prefixText':'" + searchString + "'";
                    parameter += ",'stateName':'" + $('.ddl-state').val() + "'}";
                    var messageUrl = '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByStateAndPrefixText")%>';
                    
                    InvokeService(messageUrl,parameter,FillCity);                  
            });
        });
    
    function FillCity(cities)
    {
         for (var i = 0; i < cities.d.length; i++) 
         {
            var currentSearchItem = cities.d[i];
            var htmlElement = $("<div class='searchresult'>" + currentSearchItem.Name + "</div>");
            $("#results").append(htmlElement);
        }
    
        $(".searchresult").each(function(i) {
            $(this).click(function() {
                $(".txtSearch").val(cities.d[i].Name);
                $(".city_id").val(cities.d[i].CityID);
                $("#results").hide();
            });
        });
        $("#results").show();
    }
    
    
    function InvokeService(messageUrl, parameter, successFunction)
    {
         $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json", 
                url: messageUrl,
                data: parameter,
                success: function(result) 
                {
                       successFunction(result);
                },
                error: function(a,b,c)
                {
                    alert(errorMessage);
                }
        })
    }
    
    </script>

</div>
<div>
    <div class="hrow">
        <label>
            City:<sup>*</sup></label>
        <div class="spnfld">
            <input type="text" id="_txtSearchBox" class="txtSearch" runat="server" />
            <br />
            <div id="results" class="">
            </div>
        </div>
    </div>
    <div class="hrow">
        <label>
            State:<sup>*</sup></label>
        <span class="spnfld">
            <asp:DropDownList ID="_ddlState" runat="server" CssClass="ddl-state" />
        </span>
    </div>
    <input type="hidden" id="_hdnCityId" class="city_id" runat="server" />
</div>
