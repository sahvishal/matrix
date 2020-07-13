<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_AddMeeting" CodeBehind="AddMeeting.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/App/UCCommon/ucMiniAddNewContact.ascx" TagName="ucMiniAddNewContact"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>

    <script type="text/javascript" src="../JavascriptFiles/HttpRequest.js"></script>

    <style type="text/css">
        .titletext_anp
        {
            float: left;
            width: 100px;
            margin-right: 5px;
            padding-top: 3px;
            font: bold 12px arial;
            color: #000;
        }
        .inputf_anp
        {
            float: left;
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 1px;
        }
        .inputfieldrightcon_anp
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
        }
        .list_anp
        {
            border: 1px solid #7F9DB9;
            background-color: #fff;
            font: normal 12px arial;
            color: #333;
            padding: 2px;
        }
        .inputfieldrightcon_anp
        {
            float: left;
            width: 180px;
            font: normal 12px arial;
            color: #000;
        }
.titletext_anp{ float:left; width:100px; margin-right:5px; padding-top:3px; font:bold 12px arial; color:#000;}
.inputf_anp{float:left; border: 1px solid #7F9DB9; Background-color:#fff; font: normal 12px arial; color:#333; padding:1px;}
.inputfieldrightcon_anp{ float:left; width:180px; font:normal 12px arial; color:#000;}
.list_anp{ border: 1px solid #7F9DB9; Background-color:#fff; font: normal 12px arial; color:#333; padding:2px;}
.inputfieldrightcon_anp{ float:left; width:180px; font:normal 12px arial; color:#000;}
.inputfield180px_anp  { float: left; width: 185px; margin-right: 45px; Font:bold 12px arial; color:#000; } 
.inputfield300px_anp  { float: left; width: 300px; Font:bold 12px arial; color:#000; } 
.inputfield480px_anp  { float: left; width: 458px; Font:bold 12px arial; color:#000; padding-left:22px; }  
.inputfield140px_anp  { float: left; width: 140px; margin-right: 30px; Font:bold 12px arial; color:#000; }
.greybox_anp{ float: left; width: 500px; padding:10px; background-color:#eee; border:solid 1px #e6e6e6; } 
.greybox_anp .row{ float: left; width: 480px; font-weight:bold;}
    </style>

    <script language="javascript" type="text/javascript">
     
    function validation()
    {

        GetAllContacts();
        if(isBlank(document.getElementById('<%= this.txtSubject.ClientID %>'), 'Subject'))
            return false;

        var txtStartDate=document.getElementById('<%= this.txtStartDate.ClientID %>');

        if (txtStartDate.value!='' && txtStartDate.value.length > 0)
        {
            if(ValidateDate(txtStartDate.value,'Start date')==false)
            {
                return false;
            }
            if(checkDate(txtStartDate.value,'Start Date')==false)
            {return false;}
        }
        var radioFollowAction=document.getElementById("<%=this.radioFollowAction.ClientID %>");
        if(radioFollowAction.checked==true)
        {
            var chkboxCall=document.getElementById("<%=this.chkboxCall.ClientID %>");  
            var chkboxMeeting=document.getElementById("<%=this.chkboxMeeting.ClientID %>"); 
            var chkboxTask=document.getElementById("<%=this.chkboxTask.ClientID %>");
            
            var txtCallSubject=document.getElementById("<%=this.txtCallSubject.ClientID %>");
            var txtCallStartDate=document.getElementById("<%=this.txtCallStartDate.ClientID %>");
            var txtCallStartTime=document.getElementById("<%=this.txtCallStartTime.ClientID %>");
            var txtMeetingStartDate=document.getElementById("<%=this.txtMeetingStartDate.ClientID %>");
            var txtMeetingStartTime=document.getElementById("<%=this.txtMeetingStartTime.ClientID %>");
//            var txtTask=document.getElementById("<%=this.txtTask.ClientID %>");
            
            if(chkboxCall.checked==true)
            {
                if(isBlank(txtCallSubject, 'Follow Up Call Subject'))
                    return false;
                if(isBlank(txtCallStartDate, 'Follow Up Call Start Date'))
                    return false;
//                if(isBlank(txtCallStartTime, 'Follow Up Call Start Time'))
//                    return false;
            }
            if(chkboxMeeting.checked==true)
            {
                if(isBlank(txtMeetingStartDate, 'Follow Up Meeting Start Date'))
                    return false;
                if(isBlank(txtMeetingStartTime, 'Follow Up Meeting Start Time'))
                    return false;
            }
//            if(chkboxTask.checked==true)
//            {
//                if(isBlank(txtTask, 'Follow Up Task'))
//                    return false;
//            }
            if(txtCallStartDate.value!="")
            {
                if(ValidateDate(txtCallStartDate.value,'Follow Up Call Start Date')==false)
                {
                    return false;
                }
                if(checkDate(txtCallStartDate.value,'Follow Up Call Start Date')==false)
                {return false;}
            }
            if(txtMeetingStartDate.value!="")
            {
                if(ValidateDate(txtMeetingStartDate.value,'Follow Up Meeting Start Date')==false)
                {
                    return false;
                }
                if(checkDate(txtMeetingStartDate.value,'Follow Up Meeting Start Date')==false)
                {return false;}
            }
            var txtTaskDueDate=document.getElementById("<%=this.txtTaskDueDate.ClientID %>");
            if(txtTaskDueDate.value!="")
            {
                if(ValidateDate(txtTaskDueDate.value,'Follow Up Task Due Date')==false)
                {
                    return false;
                }
                if(checkDate(txtTaskDueDate.value,'Follow Up Task Due Date')==false)
                {return false;}
            }
        }
    }
         
    function resetall()
    {
        document.getElementById('<%=this.mainbody.ClientID%>').style.display="none";
        document.getElementById('<%= this.divGridView.ClientID %>').style.display="none";
        return false;
    }
         
    function addContact(fullname,id)
    {

        var contactid=document.getElementById('<%=this.hfContactId.ClientID%>');
        var contactName=document.getElementById('<%=this.hfContactName.ClientID%>');

        name.innertext=fullname;
        name.value=fullname;
        contactid.value=id;   
        contactName.value=fullname;

        if(document.getElementById('<%=this.dgcontactlist.ClientID%>')!=null)
        document.getElementById('<%=this.dgcontactlist.ClientID%>').style.display="none";
                
        if (document.getElementById('<%=this.contactForm1.ClientID%>')!=null)
        document.getElementById('<%=this.contactForm1.ClientID%>').style.display="block";
        
        if (document.getElementById('<%=this.mainbody.ClientID%>')!=null)
        document.getElementById('<%=this.mainbody.ClientID%>').style.display="none";
        
        if(document.getElementById('<%=this.imggridupper.ClientID%>')!=null)
        document.getElementById('<%=this.imggridupper.ClientID%>').style.display="none";
        
        if(document.getElementById('<%=this.imggridlower.ClientID%>')!=null)
        document.getElementById('<%=this.imggridlower.ClientID%>').style.display="none";
        
        if($find('mdlPopup')!=null)
        $find('mdlPopup').hide();

    }      
    function check()
    {
    alert("Please check this in next release.");
    }
    
    function hide()
    {
      
      var Fn= document.getElementById('<%= this.txtFirstName.ClientID %>');
      var cty=   document.getElementById('<%= this.txtCity.ClientID %>');
      var Zip=  document.getElementById('<%= this.txtZip.ClientID %>');
      var st= document.getElementById('<%= this.txtState.ClientID %>');
      var cst= document.getElementById('<%= this.txtCustomerID.ClientID %>');
      if(Fn.value=='' && cty.value=='' && Zip.value=='' && st.value=='' && cst.value=='')
      {
      alert("Please enter at least one Field value to Search.");
      return false;
      }
       if ((isNumericOnly(cst,"CustomerID")!=true))
                {return false;}  
     
        document.getElementById('<%=this.contactForm1.ClientID%>').style.display="none";        
    
    
    }
    
    function ShowPopUp()
    {
        document.getElementById('<%= this.txtFirstName.ClientID %>').value = '';
        document.getElementById('<%= this.txtCity.ClientID %>').value = '';
        document.getElementById('<%= this.txtZip.ClientID %>').value = '';
        document.getElementById('<%= this.txtState.ClientID %>').value = '';
        document.getElementById('<%= this.txtCustomerID.ClientID %>').value = ''; 
        
        $find('mdlPopup').show();
        document.getElementById("<%= this.mainbody.ClientID %>").style.display="none";
        document.getElementById("<%= this.divGridView.ClientID %>").style.display="none";
        
        document.getElementById("<%= this.mainbody.ClientID %>").style.display="none";
        document.getElementById("<%= this.divGridView.ClientID %>").style.display="none";
        document.getElementById("<%= this.textfound.ClientID %>").innerHTML='';
        var spMMSearchImg =document.getElementById('<%=this.spMMSearchImg.ClientID%>');
        spMMSearchImg.style.display='none'; 
        return false;
    }
    
    function SearchCriteria()
    {
        var txtFirstName=document.getElementById("<%= this.txtFirstName.ClientID %>");
        var txtState=document.getElementById("<%=this.txtState.ClientID %>");
        var txtCity=document.getElementById("<%=this.txtCity.ClientID %>");
        var txtZip=document.getElementById("<%=this.txtZip.ClientID %>");
        var txtCustomerID=document.getElementById("<%=this.txtCustomerID.ClientID %>");
        
        if(txtFirstName.value=="" && txtState.value=="" && txtCity.value=="" && txtZip.value=="" && txtCustomerID.value=="")
        {
            alert("Please enter at least one field value to Search");
            return false;
        }
        var mainbody=document.getElementById("<%= this.mainbody.ClientID %>");
        mainbody.style.display='block';
        document.getElementById("<%= this.countcontact.ClientID %>").innerHTML='';
        document.getElementById("<%= this.textfound.ClientID %>").innerHTML='Searching please wait';
        
        var spMMSearchImg=document.getElementById("<%= this.spMMSearchImg.ClientID %>");
        spMMSearchImg.style.display='block';  
        return true;
    }
    function ShowAddContactPopup()
    {                
        ClearContactFields();
        SetContactTitle('Add New Contact');        
        $find('mdlPopup1').show();
        return false;
    }
    
    function HideAddContactPopup()
    {
        $find('mdlPopup1').hide();
        return false;
    }
    
    function ValidatePopUp()
    {
        
    }
    function txtkeypress(evt)
    {
            return KeyPress_NumericAllowedOnly(evt);
    }
    function FilterTime(key, textbox, dFilterMask)
    {
        return dFilter(key, textbox, dFilterMask);
    }

    function AddSlotAutoFill(textbox)
    {
        dFilter_AutoFill(textbox);
    }
    
    function MeetingDetails()
    {
        // Set Tab Status in Hidden Field
        var HidTabStatus=document.getElementById("<%=this.HidTabStatus.ClientID %>");
        HidTabStatus.value=1;
                
        var imgBtnMeetingDetails=document.getElementById("<%=this.imgBtnMeetingDetails.ClientID %>");
        imgBtnMeetingDetails.src="/App/Images/meetingdetails-tab-on.gif";
        
        var imgBtnMeetingHistory=document.getElementById("<%=this.imgBtnMeetingHistory.ClientID %>");
        imgBtnMeetingHistory.src="/App/Images/MarketingPartner/history-taboff.gif";
        
        var DivMeetingDetails=document.getElementById("<%=this.DivMeetingDetails.ClientID %>");
        DivMeetingDetails.style.display="block";
        
        var DivMeetingHistory=document.getElementById("<%=this.DivMeetingHistory.ClientID %>");
        DivMeetingHistory.style.display="none";       
        return false;
    }
    
    function MeetingHistory()
    {
        // Set Tab Status in Hidden Field
        var HidTabStatus=document.getElementById("<%=this.HidTabStatus.ClientID %>");
        HidTabStatus.value=2;
        
        var imgBtnMeetingDetails=document.getElementById("<%=this.imgBtnMeetingDetails.ClientID %>");
        imgBtnMeetingDetails.src="/App/Images/meetingdetails-tab-off.gif";
        
        var imgBtnMeetingHistory=document.getElementById("<%=this.imgBtnMeetingHistory.ClientID %>");
        imgBtnMeetingHistory.src="/App/Images/MarketingPartner/history-tabon.gif";
        
        var DivMeetingDetails=document.getElementById("<%=this.DivMeetingDetails.ClientID %>");
        DivMeetingDetails.style.display="none";
        
        var DivMeetingHistory=document.getElementById("<%=this.DivMeetingHistory.ClientID %>");
        DivMeetingHistory.style.display="block";       
        return false;       
    }

    function EditContact(SelectedContactID)
    {
        ClearContactFields();
        hidContactID=document.getElementById('<%= this.hidContactID.ClientID %>');
        document.getElementById('<%= this.hidContactIDEdit.ClientID %>').value=SelectedContactID;        
        hidContactID.value=SelectedContactID;        
        FillGrid(hidContactID.value);
        return false;
    }
    
    function FillGrid(ContactID)
    {
        //alert(ContactID);
        var postRequest1 = new HttpRequest();
        postRequest1.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest1.failureCallback = requestFailed();
        //alert("AsyncEditContactProspect.aspx?ContactID="+ ContactID);
        postRequest1.url ="AsyncEditContactProspect.aspx?ContactID="+ ContactID;
	    postRequest1.successCallback = setGrid;
	    postRequest1.post("");
	    return false;
    }
    function setGrid(httpRequest1)
    {
        var xmlDoc = httpRequest1.responseXML;
        var result=httpRequest1.responseText;
        //alert(result);
        var firstindex=result.indexOf('divMain');       
        var lastindex=result.lastIndexOf('</div>');       
        var mainresult=result.substring(firstindex+9,lastindex);
        //alert(mainresult);
        SetContactTitle('Edit Contact');
        SetContact(mainresult);
        $find('mdlPopup1').show();
        return false;
    }
    function requestFailed()
    {}
    
    function GetAllContacts()
    {
        var HidAllContactID=document.getElementById('<%= this.HidAllContactID.ClientID %>');
        HidAllContactID.value='';
        var grdContacts=document.getElementById('<%= this.grdContacts.ClientID %>');
        var rowcount=0;
        var cellnode=0;
        if (grdContacts)
        {
            while(rowcount < grdContacts.rows.length)
              {
                   if(grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id==undefined)
                   cellnode=1;
                   if(grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id=='chkContact')
                   {
                        if(grdContacts.rows[rowcount].cells[0].childNodes[cellnode].checked)
                        {
                            HidAllContactID.value = HidAllContactID.value + grdContacts.rows[rowcount].cells[0].childNodes[cellnode].value + ',';
                        }
                   }               
                   rowcount = rowcount + 1;
              }
              //alert(HidAllContactID.value);  
        }         
    }
    
    function hideDivFollwoUpAction()
    {
        var divFollwoUpAction=document.getElementById("divFollwoUpAction");
        divFollwoUpAction.style.display="none";
    }
    function ShowDivFollwoUpAction()
    {
        var divFollwoUpAction=document.getElementById("divFollwoUpAction");
        divFollwoUpAction.style.display="block";
//        var chkboxCall=document.getElementById("<%=this.chkboxCall.ClientID %>");
//        var chkboxMeeting=document.getElementById("<%=this.chkboxMeeting.ClientID %>");
//        var chkboxTask=document.getElementById("<%=this.chkboxTask.ClientID %>");
//        chkboxCall.checked=false; 
//        chkboxMeeting.checked=false;
//        chkboxTask.checked=false;
        
    }
    function HideShowCall()
    {
        var chkboxCall=document.getElementById("<%=this.chkboxCall.ClientID %>");
        var divCall=document.getElementById("divCall");
        if(chkboxCall.checked==true)
        {
            divCall.style.display="block";
        }
        else
        {
            divCall.style.display="none";
        }
    }
    
    function HideShowMeeting()
    {
        var chkboxMeeting=document.getElementById("<%=this.chkboxMeeting.ClientID %>");
        var divMetting=document.getElementById("divMetting");
        if(chkboxMeeting.checked==true)
        {
            divMetting.style.display="block";
        }
        else
        {
            divMetting.style.display="none";
        }
    }
    function HideShowTask()
    {
        var chkboxTask=document.getElementById("<%=this.chkboxTask.ClientID %>");
        var pTask=document.getElementById("pTask");
        if(chkboxTask.checked==true)
        {
            pTask.style.display="block";
        }
        else
        {
            pTask.style.display="none";
        }
    }
    
    function SelectContact()
    {
        var hidContactID=document.getElementById('<%= this.hfContactId.ClientID %>');        
        var grdContacts=document.getElementById('<%= this.grdContacts.ClientID %>');
        var rowcount=0;
        var cellnode=0;
        if (grdContacts)
        {
            while(rowcount < grdContacts.rows.length)
              {
                   if(grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id==undefined)
                   cellnode=1;
                   if(grdContacts.rows[rowcount].cells[0].childNodes[cellnode].id=='chkContact')
                   {
                        if(grdContacts.rows[rowcount].cells[0].childNodes[cellnode].value==hidContactID.value)
                        {
                            grdContacts.rows[rowcount].cells[0].childNodes[cellnode].checked=true;   
                        }
                   }               
                   rowcount = rowcount + 1;
              }
              //alert(HidAllContactID.value);  
        }  
    }
    
    </script>

    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <div class="headingbox_default">
                    <div class="orngheadtxt_default" id="heading" runat="server">
                        Add Meeting</div>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="700px" height="8px" /></p>
                <div class="maindivinnerrow_feedback" id="divProspectDetails" runat="server">
                    <%--Begin Prospect Details--%>
                    <div class="divtoptxtbox_hd">
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd" id="spnName" runat="server">Prospect Name:</span>
                            <span class="inputfieldconleft_default" id="spProspectName2" runat="server"></span>
                            <span class="divtopboxttext_hd">URL:</span> <span class="inputfieldconright_default"
                                id="spURL" runat="server"></span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd" id="spnAddress" runat="server">Prospect Address:</span>
                            <span class="inputfieldconleft_default" id="spAddress" runat="server"></span><span
                                class="divtopboxttext_hd">Phone No:</span> <span class="inputfieldconright_default"
                                    id="spPhone" runat="server"></span>
                        </p>
                        <p class="divtopboxrow_hd">
                            <span class="divtopboxttext_hd">Email:</span> <span class="inputfieldconleft_default"
                                id="spOther" runat="server"></span><span class="divtopboxttext_hd" id="spnType" runat="server">
                                    Prospect Type:</span> <span class="inputfieldconright_default" id="spnProspectType"
                                        runat="server"></span>
                        </p>
                        <p class="divtopboxrow_hd" style="display:none;">
                            <span class="divtopboxttext_hd">Attendance:</span> <span class="inputfieldconleft_default"
                                id="spnAttendence" runat="server"></span><span class="divtopboxttext_hd">Members:</span>
                            <span class="inputfieldconright_default" id="spnMembersEmployees" runat="server">
                            </span>
                        </p>
                        <p class="divtopboxrow_hd" style="display:none;">
                            <span class="divtopboxttext_hd">Will Promote:</span> <span class="inputfieldconleft_default"
                                id="spnWillPromote" runat="server"></span><span class="divtopboxttext_hd">Facilities
                                    Fee($):</span> <span class="inputfieldconright_default" id="spnFacilitiesFee" runat="server">
                                    </span>
                        </p>
                        <p class="divtopboxrow_hd" style="display:none;">
                            <span class="divtopboxttext_hd">Viable Host Site:</span> <span class="inputfieldconleft_default"
                                id="spnViableHostSite" runat="server"></span><span class="divtopboxttext_hd">Will Host:</span>
                            <span class="inputfieldconright_default" id="spnWillHost" runat="server"></span>
                        </p>
                    </div>
                    <%--End Prospect Details--%>
                </div>
                <p>
                    <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
                <div style="float: left; height: 27px; width: 746px; display:none;" id="divTab" runat="server">
                    <asp:ImageButton ID="imgBtnMeetingDetails" runat="server" ImageUrl="~/App/Images/meetingdetails-tab-on.gif"
                        OnClientClick="return MeetingDetails();"></asp:ImageButton>
                    <asp:ImageButton ID="imgBtnMeetingHistory" runat="server" ImageUrl="~/App/Images/MarketingPartner/history-taboff.gif"
                        OnClientClick="return MeetingHistory();"></asp:ImageButton>
                </div>
                <div id="contactForm1" runat="server" style="float: left; width: 746px;">
                    <asp:Panel ID="pnlAddMeeting" runat="server" DefaultButton="btnSave">
                        <div class="main_area_bdr" style="margin-top: 0px; border-color: #D4ECF6;" id="DivMeetingDetails"
                            runat="server">
                            <asp:HiddenField runat="server" ID="hfContactId" />
                            <asp:HiddenField runat="server" ID="hfContactName" />
                            <%--<p class="main_container_row_default">
                                <span class="titletext_default">Contact:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtContact" runat="server" CssClass="inputf_def" Width="150px" ReadOnly="True"></asp:TextBox>
                                </span><span>&nbsp;<asp:LinkButton ID="lnkBtnSearchContact" runat="server" Text="Search Contact"
                                    OnClientClick="return ShowPopUp();"></asp:LinkButton></span> &nbsp; <span>
                                        <asp:LinkButton ID="lnkBtnAddContact" runat="server" Text="Add Contact" OnClientClick="return ShowAddContactPopup();"></asp:LinkButton>
                                    </span>
                            </p>--%>
                            <div class="main_container_row_default">
                                <div class="titletext_default" style="">Meeting With:</div>
                                <div class="inputfldnowidth_default" style="width:500px;">
                                <div style="float:left; width:500px;">
                                <div class="inputfldnowidth_default" style="margin-right:25px; display: none;" runat="server" id="divGridContacts">
                                    <asp:GridView ID="grdContacts" DataKeyNames="ContactID" runat="server" CssClass=""
                                        GridLines="None" AutoGenerateColumns="false" ShowHeader="false" OnRowDataBound="grdContacts_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <%--<input type="radio" id="rbtnPCP"  name="PCP" value="<%# DataBinder.Eval(Container.DataItem, "ContactID")%>"  onclick="return SetContact(this);" />--%>
                                                    <input type="checkbox" id="chkContact" name="PCP" value="<%# DataBinder.Eval(Container.DataItem, "ContactID")%>" />
                                                    <span id="spnContactID" style="visibility: hidden">
                                                        <%# DataBinder.Eval(Container.DataItem, "ContactID")%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <span id="spnFullName" runat="server">
                                                        <%# DataBinder.Eval(Container.DataItem, "FullName")%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <span id="spnTitle" runat="server">&nbsp;<%# DataBinder.Eval(Container.DataItem, "Title")%>
                                                    </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <span id="spnUpdate" runat="server">&nbsp;[&nbsp; <a href="#" title="Update Contact"
                                                        onclick='return EditContact(<%# DataBinder.Eval(Container.DataItem, "ContactID")%>);'>
                                                        Update</a> &nbsp;|&nbsp;<a href="javascript:void(0);" class="tt" runat="server" id="a1"
                                                            title='<%# DataBinder.Eval(Container.DataItem, "Title")%>'> View notes <span class="tooltip">
                                                                <span class="top"></span><span class="middle" id="spndefcursor" onmouseover="changetodefault('spndefcursor');" onmouseout="changetopointer('spndefcursor');">
                                                                    <%# DataBinder.Eval(Container.DataItem, "Notes")%>
                                                                </span><span class="bottom"></span></span></a>&nbsp;] </span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                </div>
                                 <div style="float:left; width:500px;">
                                     <div class="inputfldnowidth_default" id="divAddNewContact" runat="server">
                                     <asp:LinkButton Text="+ Add New Contact" ID="lnkNewContact" runat="server" OnClientClick="return ShowAddContactPopup();"></asp:LinkButton>
                                     </div>
                                  </div>
                                 </div>
                            </div>
                            <p class="main_container_row_default">
                                <span class="titletext_default">Subject:<span class="reqiredmark"><sup>*</sup> </span>
                                </span><span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtSubject" runat="server" CssClass="inputf_def" Width="600px"></asp:TextBox></span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletext_default">Start Date & Time:</span><span class="inputfielddate_default">
                                    <asp:TextBox ID="txtStartDate" runat="server" CssClass="inputf_def" Width="80px"></asp:TextBox>
                                    <span style="float: left; font-size: 7pt;">(mm/dd/yyyy)</span> </span><span class="calendarcntrl_default">
                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="Imgbtncalender"
                                            AlternateText="Click to show calendar" />
                                        <ajaxToolkit:CalendarExtender ID="extTaskStartDate" runat="server" Format="MM/dd/yyyy"
                                            Animated="true" PopupButtonID="Imgbtncalender" TargetControlID="txtStartDate">
                                        </ajaxToolkit:CalendarExtender>
                                    </span><span class="scripticon_default"></span><span class="inputfieldright_default">
                                        <asp:TextBox ID="txtStartTime" runat="server" Width="80px" CssClass="inputf_def"
                                            onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox><br />
                                        <span class="inputfieldob_amv" style="font-size: 7pt;">(hh:mm)</span> </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletext_default">Meeting Venue:</span> <span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtVenue" runat="server" CssClass="inputf_def" Rows="1" Width="250px"
                                        TextMode="MultiLine"></asp:TextBox>
                                </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletext_default" style="padding-top: 0px">Status:</span><span class="inputfldnowidth_default">
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputf_def" Width="110px">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletext_default">Duration:</span> <span class="inputfieldconleft_default">
                                    <asp:DropDownList ID="ddlDuration" runat="server" AutoPostBack="false" Width="110px">
                                    </asp:DropDownList>
                                </span>
                            </p>
                            <p class="main_container_row_default">
                                <span class="titletext_default">Notes:</span> <span class="inputfldnowidth_default">
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="inputf_def" TextMode="MultiLine" 
                                        Rows="8" Width="720px"></asp:TextBox></span>
                            </p>
                            <div id="divFutureAction" runat="server" style="float: left; display: block; visibility: visible">
                                <p class="main_container_row_default">
                                    <span class="titletextsmallbld1_default" style="width: 78px">Future Action:</span>
                                    <span class="inputfieldconleft_default">
                                        <asp:RadioButton ID="radioNone" runat="server" Text="None" Checked="true" GroupName="FollowUpAction" />
                                    </span>
                                </p>
                                <p class="main_container_row_default">
                                    <span class="titletextsmallbld1_default" style="width: 78px">
                                        <img src="../Images/specer.gif" width="78px" height="1px" /></span> <span class="inputfieldconleft_default">
                                            <asp:RadioButton ID="radioFollowAction" runat="server" Text="Follow up Action" GroupName="FollowUpAction" /></span>
                                </p>
                                <div class="main_container_row_default">
                                    <div class="titletextsmallbld1_default" style="width: 78px">
                                        <img src="../Images/specer.gif" width="78px" height="1px" /></div>
                                    <div class="greybox_anp" id="divFollwoUpAction" style="display: none;">
                                        <p class="row">
                                            <asp:CheckBox ID="chkboxCall" runat="server" Text="Follow up Call" />
                                        </p>
                                        <div id="divCall" style="display: none;">
                                            <p class="row">
                                                <span class="inputfield480px_anp">Subject:<span class="reqiredmark"><sup>*</sup></span><asp:TextBox
                                                    ID="txtCallSubject" runat="server" Width="458px" CssClass="inputf_anp"></asp:TextBox></span>
                                            </p>
                                            <p class="row">
                                                <span class="inputfield480px_anp"><span class="inputfield140px_anp">Start Date:<span
                                                    class="reqiredmark"><sup>*</sup></span><asp:TextBox ID="txtCallStartDate" runat="server"
                                                        Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                    <span class="calendarcntrl_default">
                                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="ImageButton1" /></span></span>
                                                    <span class="inputfield140px_anp">Time:<asp:TextBox
                                                        ID="txtCallStartTime" runat="server" Width="140px" CssClass="inputf_anp" onblur="javascript:AddSlotAutoFill(this);"
                                                        onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                                        (hh:mm)</span> </span>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" Format="MM/dd/yyyy"
                                                    Animated="true" PopupButtonID="ImageButton1" TargetControlID="txtCallStartDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </p>
                                            <p class="row">
                                                <img src="../Images/specer.gif" width="5px" height="5px" /></p>
                                        </div>
                                        <p class="row">
                                            <asp:CheckBox ID="chkboxMeeting" runat="server" Text="Follow up Meeting" />
                                        </p>
                                        <div id="divMetting" style="display: none;">
                                            <p class="row">
                                                <span class="inputfield480px_anp"><span class="inputfield140px_anp">Start Date:<span
                                                    class="reqiredmark"><sup>*</sup></span><asp:TextBox ID="txtMeetingStartDate" runat="server"
                                                        Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                    <span class="calendarcntrl_default">
                                                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="ImageButton2" /></span></span>
                                                    <span class="inputfield140px_anp">Time:<span class="reqiredmark"><sup>*</sup></span><asp:TextBox
                                                        ID="txtMeetingStartTime" runat="server" Width="110px" CssClass="inputf_anp" onblur="javascript:AddSlotAutoFill(this);"
                                                        onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                                        (hh:mm)</span> <span class="inputfield110px_anp">Venue:
                                                            <asp:TextBox ID="TextBox1" runat="server" Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                        </span></span>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" Format="MM/dd/yyyy"
                                                    Animated="true" PopupButtonID="ImageButton2" TargetControlID="txtMeetingStartDate">
                                                </ajaxToolkit:CalendarExtender>
                                            </p>
                                            <p class="row">
                                                <img src="../Images/specer.gif" width="5px" height="5px" /></p>
                                        </div>
                                        <p class="row">
                                            <asp:CheckBox ID="chkboxTask" runat="server" Text="Follow up Task" />
                                        </p>
                                        <div id="pTask" style="display: none;">
                                            <p class="row">
                                                <span class="inputfield480px_anp">
                                                    <asp:TextBox ID="txtTask" runat="server" Width="458px" CssClass="inputf_anp"></asp:TextBox>
                                                </span>
                                            </p>
                                            <p class="row">
                                                <span class="inputfield480px_anp">
                                                    <span class="inputfield140px_anp">Due Date:(mm/dd/yyyy)
                                                        <asp:TextBox ID="txtTaskDueDate" runat="server" Width="110px" CssClass="inputf_anp"></asp:TextBox>
                                                        <span class="calendarcntrl_default">
                                                            <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="ImageButton3" />
                                                        </span>
                                                        <span class="">
                                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" Animated="true" Format="MM/dd/yyyy"
                                                                PopupButtonID="ImageButton3" TargetControlID="txtTaskDueDate">
                                                            </ajaxToolkit:CalendarExtender>
                                                        </span>
                                                    </span>
                                                    <span class="inputfield140px_anp">Time:
                                                        <asp:TextBox ID="txtTaskDueTime" runat="server" Width="140px" CssClass="inputf_anp"
                                                            onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                                                        (hh:mm)
                                                    </span> 
                                                </span>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="headbg2_box_default">
                            <div class="buttoncon_default">
                                <asp:ImageButton ID="btnSave" runat="server" CssClass="" ImageUrl="~/App/Images/save-button.gif"
                                    OnClientClick="return validation();" OnClick="btnSave_Click" />
                            </div>
                            <div class="button_con_savencancel" id="divCloseAndCreate" runat="server">
                                <asp:ImageButton ID="btnCloseAndCreate" runat="server" CssClass="" ImageUrl="~/App/Images/savencreatenew-btn.gif"
                                    OnClientClick="return validation();" OnClick="btnCloseAndCreate_Click" />
                            </div>
                            <div class="buttoncon_default">
                                <asp:ImageButton ID="btnCancel" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                                    OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="main_area_bdr" runat="server" id="DivMeetingHistory" style="margin-top: 0px;
                        border-color: #D4ECF6; display: none;">
                        <%--Begin Call Details Grid--%>
                        <div class="dgdefault" id="divMeetings" runat="server" style="padding: 0px 10px 0px 10px;">
                            <div style="float: left; width: 733px">
                                <asp:GridView DataKeyNames="ID" ID="grdAll" runat="server" CssClass="divgrid_cl"
                                    AutoGenerateColumns="False" GridLines="None">
                                    <AlternatingRowStyle CssClass="row3" />
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div style="float: left; width: 100%;">
                                                    <span class="titletextsmallbld_default">
                                                        <%# DataBinder.Eval(Container.DataItem, "StartDate")%>
                                                    </span><span style="float: left; width: 500px;"><span class="ttxtwidthnormal_default">
                                                        <span class="btextblu">
                                                            <%# DataBinder.Eval(Container.DataItem, "Type")%></span>
                                                        <%# DataBinder.Eval(Container.DataItem, "Subject")%>
                                                    </span><span class="ttxtwidthnormal_default"><span class="btextblu">
                                                        <%# DataBinder.Eval(Container.DataItem, "TypeText")%></span>
                                                        <%# DataBinder.Eval(Container.DataItem, "ContactName")%>
                                                    </span><span class="ttxtwidthnormal_default">
                                                        <%# DataBinder.Eval(Container.DataItem, "Notes")%></span> </span>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle CssClass="row1" />
                                    <RowStyle CssClass="row2" />
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="norcrdmsg_acp" style="display: none;" id="divNoResultsAll" runat="server">
                            <span class="norcrdmsgtxt_acp">No Result Found.</span>
                        </div>
                        <%--End Call Details Grid--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel ID="pnlSearch" runat="server" DefaultButton="ibtnSearch">
        <div class="divmainbody_cd" style="background-color: #fff;" id="searchcretaria">
            <div class="grayboxtop_cl">
                <p class="grayboxheader_crlist_am">
                    <span class="headertxt_crlist">Search Contact</span> <span class="rightclosebtn_crlist">
                        <asp:ImageButton runat="server" ID="ibtnclose" ImageUrl="~/App/Images/close-button-symbol.gif" />
                    </span>
                </p>
                <div class="lgtgraybox_cl">
                    <p>
                        <img src="../Images/specer.gif" width="700px" height="5px" /></p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletextsmallbold_default">Name:</span> <span class="inputfldnowidth_cl">
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="inputf_def" Width="100px"></asp:TextBox></span>
                        <span class="titlenowdth_cl">State:</span> <span class="inputfldnowidth_cl">
                            <asp:TextBox ID="txtState" runat="server" CssClass="inputf_def" Width="80px"></asp:TextBox></span>
                        <span class="titlenowdth_cl">City:</span> <span class="inputfldnowidth_cl">
                            <asp:TextBox ID="txtCity" runat="server" CssClass="inputf_def" Width="80px"></asp:TextBox></span>
                        <span class="titlenowdth_cl">Zip:</span> <span class="inputfldnowidth_cl">
                            <asp:TextBox ID="txtZip" runat="server" CssClass="inputf_def" Width="60px"></asp:TextBox></span>
                    </p>
                    <p>
                        <img src="../Images/specer.gif" width="700px" height="5px" /></p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="titletextsmallbold_default">Contact ID:</span> <span class="inputfldnowidth_cl">
                            <asp:TextBox ID="txtCustomerID" runat="server" CssClass="inputf_def" Width="62px"
                                MaxLength="7"></asp:TextBox></span>
                    </p>
                    <p>
                        <%-- <img src="../Images/specer.gif" width="700px" height="5px" />--%>
                    </p>
                    <div id="divCustomer" runat="server">
                    </div>
                    <p>
                        <img src="/App/Images/specer.gif" width="700px" height="5px" /></p>
                    <p class="lgtgrayboxrow_cl">
                        <span class="buttoncon_default">
                            <asp:ImageButton ID="ibtnSearch" runat="server" ImageUrl="~/App/Images/search-smallbtn.gif"
                                OnClientClick="return SearchCriteria()" OnClick="ibtnSearch_Click" /></span>
                        <span class="buttoncon_default">
                            <asp:ImageButton ID="ibtnReset" runat="server" ImageUrl="~/App/Images/reset-btn.gif"
                                OnClientClick="return resetall();" /></span>
                    </p>
                </div>
            </div>
            <p>
                <img src="/App/Images/specer.gif" width="725px" height="5px" /></p>
            <%-- <p class="divmainbody_cd">
                        <span class="buttoncon_default"><asp:ImageButton ID="ibtnReset"   runat="server" ImageUrl="~/App/Images/reset-btn.gif" OnClientClick="return resetall();" /></span>
                        <span class="buttoncon_default"><asp:ImageButton ID="ibtnSearch"   runat="server" ImageUrl="~/App/Images/search-smallbtn.gif" OnClick="ibtnSearch_Click"  OnClientClick="return hide();"/></span>
                    </p>--%>
            <p>
                <img src="../Images/specer.gif" width="700px" height="5px" /></p>
            <asp:UpdatePanel ID="upEvents" runat="server">
                <ContentTemplate>
                    <div id="mainbody" class="divmainbody_cd" runat="server">
                        <div style="float: left" id="countcontact" class="blueheadtxt_regcust" runat="server">
                            1</div>
                        <div id="spMMSearchImg" runat="server" style="float: left;">
                            <img src='../Images/ajaxloader.gif' alt="" />
                        </div>
                        <div id="textfound" class="blueheadtxt_regcust" runat="server">
                            Results found</div>
                    </div>
                    <p>
                        <img height="5" src="/App/Images/specer.gif" width="700" /></p>
                    <p class="graylinefull_default">
                        <img height="1" src="/App/Images/specer.gif" width="1" /></p>
                    <p>
                        <img height="10" src="/App/Images/specer.gif" width="725" /></p>
                    <div id="divGridView" class="grayboxtop_cl" runat="server">
                        <p id="imggridupper" class="blueboxtopbg_cl" runat="server">
                            <img height="6" src="../Images/specer.gif" width="746" /></p>
                        <%-- ************ grid start here *************--%>
                        <div id="GridView" class="grayboxtop_cl" runat="server">
                            <asp:GridView ID="dgcontactlist" runat="server" CssClass="divgrid_cl" GridLines="None"
                                AutoGenerateColumns="false" OnPageIndexChanging="dgcontactlist_PageIndexChanging"
                                AllowPaging="true" PageSize="10">
                                <Columns>
                                    <asp:BoundField DataField="FullName" HeaderText="Full Name"></asp:BoundField>
                                    <asp:BoundField DataField="Address" HeaderText="Address"></asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <span id="spContact" onclick="addContact('<%# DataBinder.Eval(Container.DataItem, "FullName")%>','<%# DataBinder.Eval(Container.DataItem, "ContactID")%>')">
                                                <a href="#" onclick="addContact('<%# DataBinder.Eval(Container.DataItem, "FullName")%>','<%# DataBinder.Eval(Container.DataItem, "ContactID")%>')">
                                                    Select</a> </span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="row1" />
                                <RowStyle CssClass="row2" />
                                <AlternatingRowStyle CssClass="row3" />
                            </asp:GridView>
                        </div>
                        <%-- ************ grid End here *************--%><p style="display: none" id="imggridlower"
                            class="blueboxbotbg_cl" runat="server">
                            <img height="6" src="/App/Images/specer.gif" width="746" /></p>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ibtnSearch" EventName="Click"></asp:AsyncPostBackTrigger>
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </asp:Panel>
    <%--<ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="lnkBtnSearchContact"
        PopupControlID="pnlSearch" BackgroundCssClass="modalBackground" CancelControlID="ibtnclose"
        BehaviorID="mdlPopup" />--%>
    <asp:LinkButton runat="server" ID="lnktemp"></asp:LinkButton>
    <asp:Panel ID="pnlAddContact" runat="server" Style="display: none;">
        <uc1:ucMiniAddNewContact ID="ucMiniAddNewContact1" runat="server" Onclicking="HandleSave" />
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="lnkNewContact"
        PopupControlID="pnlAddContact" BackgroundCssClass="modalBackground" CancelControlID="lnktemp"
        BehaviorID="mdlPopup1" />
    <asp:HiddenField ID="HidTabStatus" runat="server" />
    <input type="hidden" id="hidContactID" runat="server" />
    <input type="hidden" id="hidContactIDEdit" runat="server" />
    <asp:HiddenField ID="HidAllContactID" runat="server" /> 
</asp:Content>
