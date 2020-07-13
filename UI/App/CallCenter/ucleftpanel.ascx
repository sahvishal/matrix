<%@ Control Language="C#" AutoEventWireup="true" Inherits="ucleftpanel" Codebehind="ucleftpanel.ascx.cs" %>

<script language="javascript" type="text/javascript">
    
    var pnlhgt;
    var heightlimit;
    var curtabopen;

    function CallExpandTab(divid, imgopen, imgdown)
    {
        
        if(document.getElementById(divid).style.height!='0px')
            return;
        
        pnlhgt=0;
        CollapseAllTab();
        
        document.getElementById(imgopen).style.visibility = 'visible';
        document.getElementById(imgdown).style.visibility = 'hidden';
        
        document.getElementById(imgopen).style.display = 'block';
        document.getElementById(imgdown).style.display = 'none';

        heightlimit = 120;
        document.getElementById(divid).style.height = "0px";
        
        curtabopen = divid;
        ExpandLeftTab();
    }

    function ExpandLeftTab()
    {
        
        pnlhgt = pnlhgt + 1;
        document.getElementById('' + curtabopen + '').style.height=pnlhgt + 'px';
        delaypanel();
    }

    function CollapseAllTab()
    {
        document.getElementById('divkpiweek').style.height = "0px";
        document.getElementById('divkpimonth').style.height = "0px";
        document.getElementById('divkpiyear').style.height = "0px";
        document.getElementById('divkpilife').style.height = "0px";
        document.getElementById('divsearchleft').style.height = "0px";
        
        document.getElementById('imgwopen').style.visibility = "hidden";
        document.getElementById('imgmopen').style.visibility = "hidden";
        document.getElementById('imgyopen').style.visibility = "hidden";
        document.getElementById('imglopen').style.visibility = "hidden";
        document.getElementById('imgsopen').style.visibility = "hidden";
        
        document.getElementById('imgwopen').style.display = "none";
        document.getElementById('imgmopen').style.display = "none";
        document.getElementById('imgyopen').style.display = "none";
        document.getElementById('imglopen').style.display = "none";
        document.getElementById('imgsopen').style.display = "none";
        
        document.getElementById('imgwdown').style.visibility = "visible";
        document.getElementById('imgmdown').style.visibility = "visible";
        document.getElementById('imgydown').style.visibility = "visible";
        document.getElementById('imgldown').style.visibility = "visible";
        document.getElementById('imgsdown').style.visibility = "visible";
        
        document.getElementById('imgwdown').style.display = "block";
        document.getElementById('imgmdown').style.display = "block";
        document.getElementById('imgydown').style.display = "block";
        document.getElementById('imgldown').style.display = "block";
        document.getElementById('imgsdown').style.display = "block";
        
    }

    function delaypanel()
    {
        if(pnlhgt < heightlimit)
            setTimeout('ExpandLeftTab()',2);
    }
    
</script>

<div class="leftcontainer_inner">
    <div class="leftheader">
        <div>Quick Nav</div>
    </div>    
    <div class="quicknav_headings">
        <div class="quicknav_headings_txt">
            KPI’s This Week</div>
        <div class="quicknav_arrow">
            <a href="javascript:CallExpandTab('divkpiweek','imgwopen','imgwdown');">
                <img id="imgwopen" src= '<%= ResolveUrl("~/App/Images/arrow-up.gif") %>' width="13" height="13" style="visibility:visible; display:block;" />
                <img id="imgwdown" src= '<%= ResolveUrl("~/App/Images/arrow-down.gif") %>' width="13" height="13" style="visibility:hidden; display:none;" /></a></div>
    </div>
    <div id="divkpiweek" class="quicknav_data" style="height: 120px; overflow: hidden;">
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtwevents" ReadOnly="true" Text="4" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Events
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtwclients" ReadOnly="true" Text="15" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Clients
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtwrevenue" ReadOnly="true" Text="$1,500.00" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Revenue
            </div>
        </div>
    </div>
    
    <div class="quicknav_headingstwo">
        <div class="quicknav_headings_txt">
            KPI’s This Month</div>
        <div class="quicknav_arrow">
            <a href="javascript:CallExpandTab('divkpimonth','imgmopen','imgmdown');">
                <img id="imgmopen"  src='<%= ResolveUrl("~/App/Images/arrow-up.gif") %>' width="13" height="13" style="visibility:hidden; display:none;" />
                <img id="imgmdown" src= '<%= ResolveUrl("~/App/Images/arrow-down.gif") %>' height="13" style="visibility:visible; display:block;" />
                </a></div>
    </div>
    <div id="divkpimonth" class="quicknav_data" style="height: 0px; overflow: hidden;">
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtmevents" ReadOnly="true" Text="4" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Events
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtmclients" ReadOnly="true" Text="15" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Clients
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtmrevenue" ReadOnly="true" Text="$1,500.00" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Revenue
            </div>
        </div>
    </div>
    
    <div class="quicknav_headingstwo">
        <div class="quicknav_headings_txt">
            KPI’s This Year</div>
        <div class="quicknav_arrow">
            <a href="javascript:CallExpandTab('divkpiyear','imgyopen','imgydown');">
                <img id="imgyopen" src='<%= ResolveUrl("~/App/Images/arrow-up.gif") %>' width="13" height="13" style="visibility:hidden; display:none;" />
                <img id="imgydown" src= '<%= ResolveUrl("~/App/Images/arrow-down.gif") %>' width="13" height="13" style="visibility:visible; display:block;" />
                </a></div>
    </div>
    <div id="divkpiyear" class="quicknav_data" style="height: 0px; overflow: hidden;">
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtyevents" ReadOnly="true" Text="25" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Events
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtyclients" ReadOnly="true" Text="145" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Clients
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtyrevenue" ReadOnly="true" Text="$2,1500" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Revenue
            </div>
        </div>
    </div>
    
    <div class="quicknav_headingstwo">
        <div class="quicknav_headings_txt">
            KPI’s Lifetime</div>
        <div class="quicknav_arrow">
            <a href="javascript:CallExpandTab('divkpilife','imglopen','imgldown');">
                <img id="imglopen" src='<%= ResolveUrl("~/App/Images/arrow-up.gif") %>' width="13" height="13" style="visibility:hidden; display:none;" />
                <img id="imgldown" src= '<%= ResolveUrl("~/App/Images/arrow-down.gif") %>' width="13" height="13" style="visibility:visible; display:block;" /></a>
        </div>
    </div>
    <div id="divkpilife" class="quicknav_data" style="height: 0px; overflow: hidden;">
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <asp:TextBox runat="server" ID="txtlevent" ReadOnly="true" Text="165" CssClass="quicknav_data_input" ></asp:TextBox>
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
            </div>
            <div class="quicknav_data_txt">
                Events
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtlclients" ReadOnly="true" Text="1500" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Clients
            </div>
        </div>
        <div class="data_container">
            <div class="quicknav_data_inputarea">
                <%--<input type="text" class="quicknav_data_input" name="textfield" size="20" />--%>
                <asp:TextBox runat="server" ID="txtlrevenue" ReadOnly="true" Text="$5,01,50" CssClass="quicknav_data_input" ></asp:TextBox>
            </div>
            <div class="quicknav_data_txt">
                Revenue
            </div>
        </div>
    </div>
    
    <div class="quicknav_headingstwo">
        <div class="quicknav_headings_txt">
            Search</div>
        <div class="quicknav_arrow">
            <a href="javascript:CallExpandTab('divsearchleft','imgsopen','imgsdown');">
                <img id="imgsopen" src='<%= ResolveUrl("~/App/Images/arrow-up.gif") %>' width="13" height="13" style="visibility:hidden; display:none;" />
                <img id="imgsdown" src= '<%= ResolveUrl("~/App/Images/arrow-down.gif") %>' width="13" height="13" style="visibility:visible; display:block;" /></a>
        </div>
    </div>
    <div id="divsearchleft" class="quicknav_data" style="height: 0px; overflow: hidden;">
        <div class="search_data_container">
            <select name="" class="listmenu_search">
                <option selected="selected">Select All</option>
            </select>
            <%--<input type="text" value="" class="inputf_search" size="20" />--%>
            <asp:TextBox runat="server" ID="txtlpnlsearch" CssClass="inputf_search" ></asp:TextBox>
        </div>
        <div class="search_data_container1">
            <div class="search_buttgo">
                <input name="" type="image" src = '<%= ResolveUrl("~/App/Images/search-go-btn.gif") %>'  width="25" height="20"
                    border="0" /></div>
        </div>
    </div>
    
</div>
