<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisee_CreateSalesRepTerritory" Title="Untitled Page"
    CodeBehind="CreateSalesRepTerritory.aspx.cs" %>

<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" />

    <script type="text/javascript">
    
        String.prototype.trim = function() { return this.replace(/^\s+|\s+$/, ''); };
        
        var Array_zipCode=new Array();
        var count=0;
        var startTable="<div><table class=\"divgrid_cl\" cellspacing=\"0\" border=\"0\" style=\"border-collapse: collapse;\">";
        var headerTable="<tr class=\"row1\"><th scope=\"col\">ZipCode Details</th><th scope=\"col\">Action</th></tr>";
        var endTable="</table></div>";
        
        function addZipCode()
        {//debugger
            var ddlZip=document.getElementById("<%=this.ddlZip.ClientID %>");
            //checking for blank value
            if(ddlZip.selectedIndex==0)
            {
                alert("Please select zipcode to add.");
                return false;
            }
            
            //checking for duplicate entry
            for(icount=0; icount<count; icount++)
            {
                if(Array_zipCode[icount]==ddlZip.options[ddlZip.selectedIndex].text)
                {
                    alert("This zipcode has been already added");
                    return false;
                }
            }
            
            Array_zipCode[count]=ddlZip.options[ddlZip.selectedIndex].text;
            count++;
            
            //display the records
            var divGrd =document.getElementById("divGrd");
            if(Array_zipCode.length>6)
            {
                divGrd.style.height="200px";
                divGrd.style.overflowY="scroll";
            }
            else
            {
                divGrd.style.overflowY="hidden";
            }
            
            var contentTable="";
            for(icount=0; icount<count; icount++)
            {
                var row=icount%2;
                if(row==0)
                {
                    contentTable= contentTable + "<tr class=\"row2\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
                else
                {
                    contentTable= contentTable + "<tr class=\"row3\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
            }
            divGrd.innerHTML=startTable + headerTable + contentTable + endTable;
            ddlZip.selectedIndex=0;
            return false;
        }
        
        function deleteZipCode(zipCode)
        {//debugger
            var check=confirm("Are you sure to remove this Zipcode from the list?");
            if(check==false)
            {
                return false;
            }
            var tempArray_zipCode=new Array();
            var jcount=0;
            for(icount=0; icount<count; icount++)
            {
                if(Array_zipCode[icount]==zipCode)
                    continue;
                tempArray_zipCode[jcount]=Array_zipCode[icount];
                jcount++;
            }
            //display the records
            var divGrd =document.getElementById("divGrd");
            var contentTable="";
            Array_zipCode=tempArray_zipCode;
            
            if(Array_zipCode.length>6)
            {
                divGrd.style.height="200px";
                divGrd.style.overflowY="scroll";
            }
            else
            {
                divGrd.style.overflowY="hidden";
            }
            
            for(icount=0; icount<jcount; icount++)
            {
                var row=icount%2;
                if(row==0)
                {
                    contentTable= contentTable + "<tr class=\"row2\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
                else
                {
                    contentTable= contentTable + "<tr class=\"row3\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
            }
            if(Array_zipCode.length>0)
                divGrd.innerHTML=startTable + headerTable + contentTable + endTable;
            else
                 divGrd.innerHTML="";
            tempArray_zipCode=null;
            count=jcount;
            return false;
        }
        
        function saveZipCode()
        {//debugger
            var txtSubTerritoryName=document.getElementById("<%=this.txtSubTerritoryName.ClientID %>");
            var txtSalesRep=document.getElementById("<%=this.txtSalesRep.ClientID %>");
            if(isBlank(txtSubTerritoryName, 'Sub Territory Name'))
                return false;
            if(isBlank(txtSalesRep,'SalesRep'))
                return false;
                
            if(count==0)
            {
                alert("Please add zipcode for your territory.");
                return false;
            }
            var hfZipID=document.getElementById("<%=this.hfZipID.ClientID %>");
            hfZipID.value="";
            for(icount=0; icount<count; icount++)
            {
                var startIndex=Array_zipCode[icount].indexOf(":") + 1;
                var endIndex=Array_zipCode[icount].indexOf("]");
                var ZipID=Array_zipCode[icount].substring(startIndex,endIndex);
                hfZipID.value = hfZipID.value + ZipID + ",";
            }
            return true;
        }
        
        function fillZipDetails(ZipDetailArray)
        {//debugger
            var divGrd =document.getElementById("divGrd");
            var contentTable="";
            Array_zipCode=ZipDetailArray;
            count=Array_zipCode.length;
            
            if(Array_zipCode.length>6)
            {
                divGrd.style.height="200px";
                divGrd.style.overflowY="scroll";
            }
            else
            {
                divGrd.style.overflowY="hidden";
            }
            
            for(icount=0; icount<count; icount++)
            {
                var row=icount%2;
                if(row==0)
                {
                    contentTable= contentTable + "<tr class=\"row2\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
                else
                {
                    contentTable= contentTable + "<tr class=\"row3\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
            }
            divGrd.innerHTML=startTable + headerTable + contentTable + endTable;
            ZipDetailArray=null;
        }
        
        function AddAllZipCodes()
        {//debugger
            Array_zipCode=null;
            Array_zipCode=new Array();
            count=0;
            var ddlZip=document.getElementById("<%=this.ddlZip.ClientID %>");
            for(icount=1; icount<ddlZip.length; icount++)
            {
                Array_zipCode[count]=ddlZip.options[icount].text;
                count++;
            }
            
            //check records count
            var divGrd =document.getElementById("divGrd");
            if(Array_zipCode.length>6)
            {
                divGrd.style.height="200px";
                divGrd.style.overflowY="scroll";
            }
            else
            {
                divGrd.style.overflowY="hidden";
            }
            //display the records
            
            var contentTable="";
            for(icount=0; icount<count; icount++)
            {
                var row=icount%2;
                if(row==0)
                {
                    contentTable= contentTable + "<tr class=\"row2\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
                else
                {
                    contentTable= contentTable + "<tr class=\"row3\"><td>" + Array_zipCode[icount] + "</td><td><img src='/App/Images/delete.gif' alt='Delete' onclick='deleteZipCode(\"" + Array_zipCode[icount] + "\");'></td></tr>"
                }
            }
            divGrd.innerHTML=startTable + headerTable + contentTable + endTable;
            ddlZip.selectedIndex=0;
            return false;
        }
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_top_body">
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <span class="orngheadtxt_heading" id="dvTitle" runat="server">Create SalesRep Territory</span>
                </div>
            </div>
            <div class="main_area_bdr">
                <p class="main_container_row_default">
                    <span class="titletextlarge_default">Territory Name:</span> <span class="inputfldnowidth_default"
                        id="spTerritoryName" runat="server"></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletextlarge_default">Name:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox runat="server" ID="txtSubTerritoryName" CssClass="inputf_ga" Width="300px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletextlarge_default">Description:</span> <span class="inputfldnowidth_default">
                        <asp:TextBox runat="server" ID="txtDescription" CssClass="inputf_ga" Width="300px"></asp:TextBox>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletextlarge_default">SalesRep:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:TextBox runat="server" ID="txtSalesRep" CssClass="inputf_ga auto-search-franchisee"
                            Width="300px"></asp:TextBox>
                        <br />
                        <span style="font-size: 8pt; color: #666;"><i>Select from the auto complete list.</i></span>
                    </span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletextlarge_default">ZipCode<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputfldnowidth_default">
                        <asp:DropDownList ID="ddlZip" runat="server" Width="308px">
                        </asp:DropDownList>
                    </span><span style="float: left; width: 70px; padding-left: 10px;">
                        <asp:ImageButton ID="imgBtnAdd" runat="server" ImageUrl="~/App/Images/add-btn.gif"
                            OnClientClick="return addZipCode();" />
                    </span><span style="float: left; width: 70px; padding-left: 10px;">
                        <img src="/App/Images/addall-btn.jpg" alt="Add All" onclick="AddAllZipCodes();" />
                    </span>
                </p>
                <div style="float: left; width: 380px; margin-left: 155px;">
                    <%--<p class="blueboxtopbg_cl"><img src="/App/Images/specer.gif" width="400" height="5" /></p>--%>
                    <div style="float: left; width: 380px; overflow-x: hidden; overflow-y: auto;" id="divGrd">
                    </div>
                    <%--<p class="blueboxbotbg_cl"><img src="/App/Images/specer.gif" width="400" height="5" /></p>--%>
                </div>
                <p class="main_container_row_default">
                    <span style="float: right; width: 70px;">
                        <asp:ImageButton ID="imgBtnSave" runat="server" OnClientClick="return saveZipCode();"
                            OnClick="imgBtnSave_Click" ImageUrl="~/App/Images/save-button.gif" />
                    </span><span style="float: right; width: 70px;">
                        <asp:ImageButton ID="imgBtnCancel" runat="server" ImageUrl="~/App/Images/cancel-button.gif"
                            OnClick="imgBtnCancel_Click" />
                    </span>
                </p>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hfZipID" Value="" runat="server" />
    <asp:HiddenField ID="hfCount" Value="0" runat="server" />
    <asp:HiddenField ID="hfZipDetails" Value="" runat="server" />

    <script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
        
        $('.auto-search-franchisee').autoComplete({
            autoChange: true,
            url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetFranchiseeByPrefixTextAndContextKey")%>',
            type: "POST",
            data: "prefixText",
            contextKey: "<%=ContextKey %>"
        });
    });
    
    </script>

</asp:Content>
