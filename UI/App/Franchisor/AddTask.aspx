<%@ Page Language="C#" MasterPageFile="~/App/Franchisor/FranchisorMaster.master"
    AutoEventWireup="true" Inherits="App_Franchisor_AddTask" Codebehind="AddTask.aspx.cs" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<script src="/App/JavascriptFiles/MaskEdit.js" language="javascript" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">

    var GB_ROOT_DIR = "../Wizard/greybox/";
    
    
        function ValidateInputs()
        {
       
            if(isBlank(document.getElementById('<%= this.txtSubject.ClientID %>'), 'Subject'))
            return false;

//            var ddlstatus=document.getElementById('<%=this.ddlStatus.ClientID%>');
//            var ddlpriority=document.getElementById('<%=this.ddlPriority.ClientID%>');
//            if(!checkDropDown(ddlstatus,'Status'))
//            return false;                           
//            if(!checkDropDown(ddlpriority,'Priority'))
//            return false;  
             
         var txtDueDate=document.getElementById('<%= this.txtduedate.ClientID %>');
         if (txtDueDate.value !='')
         {         
            if(ValidateDate(txtDueDate.value,'Due date')==false)
            {
            return false;
            }
            if(checkDate(txtDueDate.value,'Start Date')==false)
            {return false;}
            
         }
       }
    function FilterTime(key, textbox, dFilterMask)
    {
        return dFilter(key, textbox, dFilterMask);
    }

    function AddSlotAutoFill(textbox)
    {
        dFilter_AutoFill(textbox);
    }
    </script>

    <script type="text/javascript" src="../Wizard/greybox/AJS.js"></script>

    <script type="text/javascript" src="../Wizard/greybox/AJS_fx.js"></script>

    <script type="text/javascript" src="../Wizard/greybox/gb_scripts.js"></script>

    <%--<link href="../Wizard/greybox/gb_styles.css" rel="stylesheet" type="text/css" />--%>
    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="headingbox_default">
            <p><img src="/App/Images/specer.gif" width="700" height="5" /></p>
                    <div class="orngheadtxt_default" runat="server" id="sptitle">
                        Add a Task</div>
                </div>
                <p><img src="/App/Images/specer.gif" width="700" height="1" /></p>
                <p class="graylinefull_default"><img src="/App/Images/specer.gif" width="1" height="1" /></p>
                            
            <div class="maindivredmsgbox" id="divErrorMsg" enableviewstate="false" visible="false"
                runat="server">
            </div>
            <div class="main_area_bdr">
                <p class="main_container_row_default">
                    <span class="titletext_default">Subject:<span class="reqiredmark"><sup>*</sup> </span>
                    </span><span class="inputfldnowidth_default">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="inputf_def" Width="600px"></asp:TextBox></span>
                </p>
                <p class="main_container_row_default">
                    <span class="titletext_default">Status:</span> <span class="inputfieldconleft_default">
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="inputf_def" Width="120px">
                        </asp:DropDownList>
                    </span><span class="titletext_default">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                        Priority:</span> <span class="inputfieldright_default">
                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="inputf_def" Width="117px">
                        </asp:DropDownList></span>
                </p>
               <p class="main_container_row_default">
               <span class="titletext_default">Due Date &amp; Time:</span> 
                    <span class="inputfldnowidth_default" style="Width:100px">
                        <asp:TextBox ID="txtduedate" runat="server" CssClass="inputf_def" Width="95px"></asp:TextBox>                        
                        <span style="float:left; font-size: 7pt;">(mm/dd/yyyy)</span>
                        </span>
                    <span class="calendarcntrl_default">
                        <asp:ImageButton runat="Server" ImageUrl="~/App/Images/calendar-icon.gif" ID="calendarimgbutton"
                            AlternateText="Click to show calendar" />
                        <ajaxToolkit:CalendarExtender ID="extTaskDueDate" runat="server" Format="MM/dd/yyyy"
                            Animated="true" PopupButtonID="calendarimgbutton" TargetControlID="txtduedate">
                        </ajaxToolkit:CalendarExtender>
                    </span>
                    <span class="inputfieldright_default">
                    <asp:TextBox ID="txtStartTime" runat="server" Width="80px" CssClass="inputf_def" onblur="javascript:AddSlotAutoFill(this);" onkeydown="javascript:return FilterTime(event.keyCode, this, '##:## AM');"></asp:TextBox>
                    <br />       
             <span class="inputfieldob_amv" style="font-size: 7pt;">(hh:mm)</span>
            </span>
            </p>
                <p class="main_container_row_default">
                    <span class="titletext_default">Add Notes:</span> <span class="inputfldnowidth_default">
                        <asp:TextBox ID="TxtNotes" runat="server" CssClass="inputf_def" TextMode="MultiLine"
                            Rows="8" Width="720px"></asp:TextBox></span>
                </p>
                <p>
                    <img src="../Images/specer.gif" width="20" height="10" />
                </p>
            </div>
            <div class="headbg2_box_default">
                <div class="buttoncon_default">
                 <asp:ImageButton ID="btnSave" runat="server" OnClientClick="return ValidateInputs();"
                        CssClass="" ImageUrl="~/App/Images/save-button.gif" OnClick="btnSave_Click" />
                   
                </div>
                <div class="button_con_savencancel" id="divCloseAndCreate" runat="server">
                    <asp:ImageButton ID="btn_CloseAndCreate" runat="server" CssClass="" ImageUrl="~/App/Images/savencreatenew-btn.gif" OnClick="btn_CloseAndCreate_Click" OnClientClick="return ValidateInputs();" />
                </div>
                <div class="buttoncon_default">
                    <asp:ImageButton ID="btnCancle" runat="server" CssClass="" ImageUrl="~/App/Images/cancel-button.gif"
                        OnClick="btnCancle_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
