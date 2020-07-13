<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App/CallCenter/NewCallCenterMaster.master"
    Inherits="Falcon.App.UI.App.CallCenter.CallCenterRep.ExistingCustomer.CallCenterRepExistingCustomer"
    CodeBehind="ExistingCustomer.aspx.cs" EnableEventValidation="false" %>

<%@ Import Namespace="Falcon.App.Core.Application" %>
<%@ Import Namespace="Falcon.App.DependencyResolution" %>
<%@ Import Namespace="Falcon.App.Core.Users.Domain" %>
<%@ Register TagPrefix="uc" Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc:JQueryToolkit ID="_jQueryToolkit" runat="server" IncludeAjax="true" IncludeJQueryUI="true"
        IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" IncludeJQueryMaskInput="true" IncludeSexyComboBox="true" />
    <script type="text/javascript" src="../../../JavascriptFiles/validations.js?v=<%=DateTime.Now.Ticks %>"></script>
    <script type="text/javascript" src="../../../JavascriptFiles/HttpRequest.js"></script>
    <script src="../../../JavascriptFiles/actb.js" type="text/javascript"></script>
    <script type="text/javascript" src="../../../JavaScriptFiles/common.js"></script>
    <script type="text/javascript" language="javascript">
        //var UserNameResult=false;
        var postRequest = new HttpRequest();
        postRequest.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        postRequest.failureCallback = requestFailed();

        function CheckContactMethod(ContactType1) {
            //debugger

            /// for existing customers we are not displaying username so here
            /// spUserName.style.display code is commented.
            var spRequiredPhone = document.getElementById("spRequiredPhone");
            var spRequiredmail = document.getElementById("spRequiredmail");
            var spUserName = document.getElementById("spUserName");
            var ContactType = document.getElementById(ContactType1);
            if (ContactType.value == "rbtPhone") {
                //spRequiredPhone.style.display = ""; 
                //spRequiredmail.style.display = "none"; 
                //spUserName.style.display = ""; 
            }
            else {
                //spRequiredPhone.style.display = "none"; 
                //spRequiredmail.style.display = ""; 
                //spUserName.style.display = "none"; 
            }
        }
        function findPos(obj) {

            var curleft = curtop = 0;
            var curWidth = obj.offsetWidth;
            var curHeight = obj.offsetHeight;
            if (obj.offsetParent) {
                curleft = obj.offsetLeft
                curtop = obj.offsetTop
                while (obj = obj.offsetParent) {
                    curleft += obj.offsetLeft
                    curtop += obj.offsetTop
                }
            }

            return { left: curleft - 2 * curWidth - 20, top: curtop, right: curleft - curWidth, bottom: curleft - curHeight };
        }


        function showTipBubble() {
            var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");
            var bubbleContent = document.getElementById("<%= this.bubbleContent.ClientID %>");
            var bubble = document.getElementById('bubble');
            var bubbleContent = document.getElementById('bubbleContent');
            var oInput;
            var bolValidDate;
            if (ValidateDate(txtDOB.value, "Date Of Birth") == false) {
                bolValidDate = false;
                return false;
            }
            var age = Age(txtDOB.value);
            if (age < 40) {
                var pos = findPos(txtDOB);
                bubble.style.top = pos.top + 'px';
                bubble.style.left = pos.left + 'px';
                bubble.style.display = 'block';
                var frameid = 'newiframe';
                var newframe = document.getElementById("newiframe");
                if (newframe == null) {
                    var newframe = document.createElement("iframe");
                    newframe.setAttribute("id", frameid);
                    document.body.appendChild(newframe);
                }
                var browserName = navigator.appName;
                newframe.border = 0;
                newframe.style.height = bubble.offsetHeight;
                newframe.style.width = bubble.offsetWidth;
                newframe.style.position = 'absolute';
                newframe.style.left = bubble.offsetLeft;
                newframe.style.top = bubble.offsetTop;
                newframe.style.display = 'block';
                if (browserName == "Netscape") {
                    newframe.style.display = "none";
                }
                else {
                    if (browserName == "Microsoft Internet Explorer") {

                    }
                    else {

                    }
                }
            }
            else {
                bubble.style.display = 'none';
                if (document.getElementById("newiframe") != null) {
                    document.getElementById("newiframe").style.display = 'none';
                }
            }
            return false;
        }
        function closeDiv() {
            var bubble = document.getElementById('bubble');
            bubble.style.display = 'none';
            document.getElementById("newiframe").style.display = "none"
        }

        function ShowScript() {
            var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");
            var age = Age(txtDOB.value);
            var spimgscript = document.getElementById("spimgscript");
            if (age < 40) {
                spimgscript.style.display = "block";
            }
            else {
                spimgscript.style.display = "none";
            }
        }

        function requestFailed() {
        }

        //        function CheckUserName() {
        //            //debugger
        //            var txtUserName = document.getElementById("<%= this.txtUserName.ClientID %>");
        //            if (txtUserName.value == "") {
        //                alert("User name cannot be empty");
        //                return false;
        //            }
        //            postRequest.url = "ExistingCustomerCall.aspx?CheckUserName=" + txtUserName.value;
        //            postRequest.successCallback = UserNameResult;
        //            postRequest.post("");
        //            return false;
        //        }

        function UserNameResult(httpRequest) {
            spUsernameResult.style.visibility = "visible";
            if (httpRequest.responseText == "False") {
                spUsernameResult.innerHTML = "This user name already exist";
                // UserNameResult=true;
            }
            else {
                spUsernameResult.innerHTML = "This user name is available";
                //UserNameResult=false; 
            }
        }
        
        function Reset() {
            ///Contact Person Details 
            var txtFName = document.getElementById("<%= this.txtFName.ClientID %>");
            var txtMName = document.getElementById("<%= this.txtMName.ClientID %>");
            var txtLName = document.getElementById("<%= this.txtLName.ClientID %>");
            var txtAddress1 = document.getElementById("<%= this.txtAddress1.ClientID %>");
            var txtAddress2 = document.getElementById("<%= this.txtAddress2.ClientID %>");
            var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");
            var ddlState = document.getElementById("<%= this.ddlState.ClientID %>");
            var ddlCountry = document.getElementById("<%= this.ddlCountry.ClientID %>");
            var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");
            var rbtEmail = document.getElementById("<%= this.rbtEmail.ClientID %>");
            var rbtPhone = document.getElementById("<%= this.rbtPhone.ClientID %>");
            var txtHPhone = document.getElementById("<%= this.txtHPhone.ClientID %>");
            var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");
            var txtEmail = document.getElementById("<%= this.txtEmail.ClientID %>");
            
            var ddlFeet = document.getElementById("<%=this.ddlFeet.ClientID %>");
            var ddlInch = document.getElementById("<%=this.ddlInch.ClientID %>");
            var txtweight = document.getElementById("<%= this.txtweight.ClientID %>");
            var ddlrace = document.getElementById("<%= this.ddlrace.ClientID %>");
            var txtUserName = document.getElementById("<%= this.txtUserName.ClientID %>");
            var txtPassword = document.getElementById("<%=this.txtPassword.ClientID %>");
            var hfCustomer = document.getElementById("<%=hfCustomer.ClientID %>");
            var medicareAdvantageNumber = document.getElementById("<%=MedicareAdvantageNumber.ClientID %>");
            var medicareId = document.getElementById("<%=MedicareIdTextbox.ClientID %>");
            var mbiNumber = document.getElementById("<%=MbiNumberTextbox.ClientID %>");

            txtFName.value = "";
            txtMName.value = "";
            txtLName.value = "";
            txtAddress1.value = "";
            txtAddress2.value = "";
            txtCity.value = "";
            ddlState.selectedIndex = 0;
            ddlCountry.selectedIndex = 0;
            txtZip.value = "";
            txtHPhone.value = "";
            txtDOB.value = "";
            txtEmail.value = "";
            
            ddlFeet.selectedIndex = 0;
            ddlInch.selectedIndex = 0;
            txtweight.value = "";
            ddlrace.selectedIndex = 0;

            medicareAdvantageNumber.value = "";
            medicareId.value = "";
            mbiNumber.value = "";

            if (hfCustomer.value != "Existing") {
                txtUserName.value = "";
                txtPassword.value = "";
            }
        }
        
        function Validation() {
            ///Contact Person Details 
            var txtFName = document.getElementById("<%= this.txtFName.ClientID %>");
            var txtLName = document.getElementById("<%= this.txtLName.ClientID %>");
            var txtAddress1 = document.getElementById("<%= this.txtAddress1.ClientID %>");
            var txtAddress2 = document.getElementById("<%= this.txtAddress2.ClientID %>");
            var txtCity = document.getElementById("<%= this.txtCity.ClientID %>");
            var ddlState = document.getElementById("<%= this.ddlState.ClientID %>");
            var ddlCountry = document.getElementById("<%= this.ddlCountry.ClientID %>");
            var txtZip = document.getElementById("<%= this.txtZip.ClientID %>");
            var rbtEmail = document.getElementById("<%= this.rbtEmail.ClientID %>");
            var rbtPhone = document.getElementById("<%= this.rbtPhone.ClientID %>");
            var txtHPhone = document.getElementById("<%= this.txtHPhone.ClientID %>");
            var txtDOB = document.getElementById("<%= this.txtDOB.ClientID %>");
            var txtEmail = document.getElementById("<%= this.txtEmail.ClientID %>");
            var txtEmail2 = document.getElementById("<%= this.txtEmail2.ClientID %>");
            
            var divHintQA = document.getElementById("<%=this.divHintQA.ClientID %>");
            var txtAnswer = document.getElementById("<%=this.txtAnswer1.ClientID %>");
            var txtUserName = document.getElementById("<%= this.txtUserName.ClientID %>");
            var txtPassword = document.getElementById("<%=this.txtPassword.ClientID %>");
            var hfCustomer = document.getElementById("<%=this.hfCustomer.ClientID %>");
            var rbtnGender = document.getElementById("<%=this.rbtnGender.ClientID %>");
            var ddlPreferredContactType = document.getElementById("<%=this.ddlPreferredContactType.ClientID %>");

            var enableTexting = $("input:radio[name$='rbtnEnableTexting']");
            var txtCPhone = $("input:text[name$='txtCPhone']");
            var preferredLanguage = document.getElementById("<%=PreferredLanguageDropDown.ClientID %>");

            var txtOPhone = $("input:text[name$='txtOPhone']");
            var phoneHomeConsent = document.getElementById("<%=this.ddlPatientConsentPrimary.ClientID %>");
            var phoneCellConsent = document.getElementById("<%=this.ddlPatientConsentCell.ClientID %>");
            var phoneOfficeConsent = document.getElementById("<%=this.ddlPatientConsentOffice.ClientID %>");

            if (isBlank(txtFName, "First Name")) {
                return false;
            }
            if (isBlank(txtLName, "Last Name")) {
                return false;
            }
            if (isBlank(txtAddress1, "Address")) {
                return false;
            }
            if (checkLength(txtAddress1, 500, "Address")) {
                return false;
            }
            if (checkLength(txtAddress2, 500, "Suite,Appts,etc.")) {
                return false;
            }
            if (isBlank(txtCity, "City for Personal Information")) {
                return false;
            }
            if (checkDropDown(ddlState, "State for Personal Information") == false) {
                return false;
            }

            /*if (isBlank(preferredLanguage,"Language")) {
                return false;
            }*/
            if ($(preferredLanguage).val() == "0" || $(preferredLanguage).val() == "") {
                alert("Please select preferred language");
                return false;
            }

            if (isBlank(txtZip, "Zip")) {
                return false;
            }
            
            if ('<%= PasswordNotTobeValidate%>' == '<%= Boolean.FalseString %>') {
                if (hfCustomer.value != "Existing") {
                    if (isBlank(txtUserName, "User Name"))
                    { return false; }
                    if( $("#<%= changePasswordPara.ClientID %>").is(":visible") == false)
                    {
                        if (isBlank(txtPassword, "Password")) {
                            return false;
                        }
                        if (txtPassword.value.length < 5) {
                            alert('Password should be of 5 digits');
                            return false;
                        }
                    }
                }
            }
            

            txtEmail.value = $.trim(txtEmail.value);

            if (txtEmail.value != "") {
                if (validateEmail(txtEmail, "Email") != true) {
                    return false;
                }
            }
            
            txtEmail2.value = $.trim(txtEmail2.value);

            if (txtEmail2.value != "") {
                if (validateEmail(txtEmail2, "Email") != true) {
                    return false;
                }
            }

            if (isBlank(txtHPhone, "Phone(Home)")) {
                return false;
            }
            if (txtHPhone.value == "(___)-___-____") {
                alert('Phone(Home) cannot be left blank');
                return false;
            }
            if (isBlank(txtDOB, "Date of Birth"))
            { return false; }
            if (ValidateDate(txtDOB.value, "Date Of Birth") == false)
            { return false; }
            if (checkDate(txtDOB.value, "Date Of Birth") == false)
            { return false; }
            if (CheckValidDOB(txtDOB, "Date Of Birth can't be future date") == false)
            { return false; }
            /// No nead to check user name as creently we are not checking it for existing customer
            //      if (isBlank(txtUserName, "User Name")) {
            //         return false; 
            //         }
            if (rbtnGender.rows[0].cells[0].childNodes[0].checked == false && rbtnGender.rows[0].cells[1].childNodes[0].checked == false) {
                alert("Please select your gender");
                return false;
            }
            if ('<%= EnableSmsNotification %>' == '<%= Boolean.TrueString %>') {
                if ($("input:radio[name$='rbtnEnableTexting']").is(":checked") == false) {
                    alert("Please select SMS alert");
                    return false;
                }
                if ($("input:radio[name$='rbtnEnableTexting']").is(":checked") && $("input:radio[name$='rbtnEnableTexting']:checked").val() == 'true' && $(txtCPhone).val() == "") {
                    alert("Please provide your cell number");
                    return false;
                }
            }

            if ('<%= EnableVoiceMailNotification %>' == '<%= Boolean.TrueString %>') {
                if ($("input:radio[name$='rbtnEnableVoiceMail']").is(":checked") == false) {
                    alert("Please select Voice Mail alert");
                    return false;
                }
                if ($("input:radio[name$='rbtnEnableVoiceMail']").is(":checked") && $("input:radio[name$='rbtnEnableVoiceMail']:checked").val() == 'true' && $(txtHPhone).val() == "") {
                    alert("Please provide your Phone(Home) number");
                    return false;
                }
            }

            //            var ddlFeet = document.getElementById("<%= this.ddlFeet.ClientID %>");
            //            if (checkDropDown(ddlFeet, "Feet for Height") == false)
            //            { return false; }

            //            var txtweight = document.getElementById("<%= this.txtweight.ClientID %>");
            //            if (isBlank(txtweight, "Weight"))
            //                return false;

            //            var ddlrace = document.getElementById("<%= this.ddlrace.ClientID %>");

            //            if (checkDropDown(ddlrace, "Race") == false)
            //            { return false; }
            if ($("#<%= InsuranceIdRequiredHiddenField.ClientID %>").val() == '<%= Boolean.TrueString %>') {
                if ($("#<%= InsuranceIdTextbox.ClientID %>").val().trim() == '') {
                    alert("Please enter "+ $("#<%= InsuranceIdLabelHiddenField.ClientID %>").val() +".");
                    return false;
                }
            }
            
            if ($("#<%= MedicareIdRequiredHiddenField.ClientID %>").val() == '<%= Boolean.TrueString %>') {
                if ($("#<%= MedicareIdTextbox.ClientID %>").val().trim() == '') {
                    alert("Please enter Medicare Id.");
                    return false;
                }
            }
            
            if ($("input[name='<%=MarketingSourceDropDown.UniqueID %>_hidden']").val() == '') {
                alert("Option for How did you hear about <%= IoC.Resolve<ISettings>().CompanyName %>?");
                return false;
            }

            if ('<%= IsInboundCall %>' == '<%= Boolean.TrueString %>' && '<%= IncomingPhoneLineRequired %>' == '<%= Boolean.TrueString %>') {
                if ($('#<%=IncomingPhoneLineTextBox.ClientID %>').val() == '') {
                    alert("Please enter incoming phone line.");
                    return false;
                }
            }
            
            if ('<%= IsInboundCall %>' == '<%= Boolean.TrueString %>') {
                if ($('#<%=CallersPhoneNumberTextBox.ClientID %>').val() == '') {
                    alert("Please enter Caller's Phone Number.");
                    return false;
                }
            }
            
            if($.trim($(txtEmail).val()) == '' && $(ddlPreferredContactType).val() === '<%= (long)Falcon.App.Core.Users.Enum.PreferredContactType.Email %>')
            {
                $(txtEmail).focus();
                alert("Please provide email id as you have selected Email as your preferred contact.");
                return false;
            }  
            
            if ($(phoneOfficeConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtOPhone).val() == "(___)-___-____" || $(txtOPhone).val() == "")) {
                alert("Enter Phone(Office) to save consent");
                return false;
            }
            if ($(phoneCellConsent).val() != '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>' && ($(txtCPhone).val() == "(___)-___-____" || $(txtCPhone).val() == "")) {
                alert("Enter Phone(Cell) to save consent");
                return false;
            }
            
            if((txtEmail.value != "" || txtEmail2.value != "") && $("input:radio[name$='rbtnEnableEmail'][value='false']").is(":checked"))
            {
                $("input:radio[name$='rbtnEnableEmail']").focus();
                var isContinue = confirm('Consent for Email is set to No. Do you wish to continue?');

                if(!isContinue)
                    return false;
            }

            if ($(phoneCellConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>'
                && $(phoneOfficeConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>'
                && $(phoneHomeConsent).val() == '<%= (long)Falcon.App.Core.Users.Enum.PatientConsent.Unknown%>') {
                var isContinue = confirm("Consent for all phone numbers is set to Unknown. Do you want to continue?");
                
                if (!isContinue)
                    return false;
            }

            return true;
        }

        function CallEnd() {
            postRequest.url = "ExistingCustomerCall.aspx?CallEnd=True";
            postRequest.post("");
            window.location = "/../../CallCenter/CallCenterRepDashboard/Index";
        }

        function popupmenu2(choice, wt, ht) {
            var winOpts = "toolbar=no,location=no,directories=no,status=no,scrolling=auto,scrollbars=no,menubar=no,width=" + wt + ",height=" + ht;
            confirmWin = window.open(choice, 'theconfirmWin', winOpts);
            window.open(choice, 'theconfirmWin', winOpts);
        }
        function setFocusGender() {//debugger
            var rbtnGender = document.getElementById("<%=this.rbtnGender.ClientID %>");
            rbtnGender.rows[0].cells[0].childNodes[0].focus();
        }

        function keypress_userName(evt) {
            //debugger
            var key = (evt.which ? evt.which : ((evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode : 0)));
            if (evt.shiftKey == false) {
                if ((key >= 48 && key <= 57) || key == 9 || key == 13 || key == 8 || key == 190 || key == 189 || key == 109 || (key >= 65 && key <= 90) || (key >= 96 && key <= 105)) {
                    return true;
                }
            }
            else if (evt.shiftKey == true) {
                if (key == 109 || key == 189 || key == 95 || (key >= 65 && key <= 90)) {

                    return true;
                }
            }
            return false;

        }

        function keyUp_userName(evt) {//debugger
            var spNotAvailable = document.getElementById("<%=this.spNotAvailable.ClientID %>");
            var spAvailable = document.getElementById("<%=this.spAvailable.ClientID %>");
            var spCheckAvailable = document.getElementById("<%=this.spCheckAvailable.ClientID %>");
            var spMinChar = document.getElementById("<%=this.spMinChar.ClientID %>");

            if (document.getElementById("<%=this.txtUserName.ClientID %>").value.length > 5) {
                spMinChar.style.display = "none";
                spNotAvailable.style.display = "none";
                spAvailable.style.display = "none";
                spCheckAvailable.style.display = "block";
                CheckUserNameAvailability();
            }
            else {
                alert("User Name can not be less than 6 digits");
                spMinChar.style.display = "block";
                spNotAvailable.style.display = "none";
                spAvailable.style.display = "none";
                spCheckAvailable.style.display = "none";
                $("#<%=this.txtUserName.ClientID %>").focus();
            }
            return true;
        }

        function OnComplete(arg) {

            var spAvailable = document.getElementById("<%=this.spAvailable.ClientID %>");
            var spNotAvailable = document.getElementById("<%=this.spNotAvailable.ClientID %>");
            var spCheckAvailable = document.getElementById("<%=this.spCheckAvailable.ClientID %>");
            spCheckAvailable.style.display = "none";
            if (arg == true) {
                spAvailable.style.display = "block";
                spNotAvailable.style.display = "none";

            }
            else {
                spNotAvailable.style.display = "block";
                spAvailable.style.display = "none";
            }
        }
        function OnTimeOut(arg) {
            //alert("Request timeout occurred. Please try again or restart the application to get the requested task done.");
        }

        function OnError(arg) {
            alert("Error occurred while processing your request. Please try again or restart the application to get the requested task done.");
        }

        function CheckUserNameAvailability() {//debugger
            var txtUserName = document.getElementById("<%=this.txtUserName.ClientID %>");
            var hfUserID = document.getElementById("<%=this.hfUserID.ClientID %>");
            if (isBlank(txtUserName, "User name")) {
                return false;
            }

            $.ajax({ url: '/App/AutoCompleteService.asmx/CheckUserNameAvailability', type: 'POST', contentType: "application/json; charset=utf-8", data: "{'userName': '" + txtUserName.value + "', 'userId': " + hfUserID.value + " }", dataType: 'json', success: function (result) { OnComplete(result.d); }, error: function () { OnError(); } });

            //ret =AutoCompleteService.CheckUserNameAvailability(txtUserName.value, hfUserID.value, OnComplete, OnTimeOut, OnError);
            return (true);
        }

        function GeneratePassword() {
            var randVal = Math.round(10000 + (Math.random() * (99999 - 10000)));
            var txtPassword = document.getElementById("<%=this.txtPassword.ClientID %>");
            txtPassword.value = randVal;
            return false;
        }

        function GenerateUserName() {
            //            var txtFName = document.getElementById("<%= this.txtFName.ClientID %>");
            //            var txtLName = document.getElementById("<%= this.txtLName.ClientID %>");
            //            var userName = $.trim(txtFName.value) + "." + $.trim(txtLName.value);
            //            var txtUserName = document.getElementById("<%=this.txtUserName.ClientID %>");
            //            txtUserName.value = userName;
            //            var spMinChar = document.getElementById("<%=this.spMinChar.ClientID %>");
            //            if (txtUserName.value.length > 5) { spMinChar.style.display = "none"; }
            //            CheckUserNameAvailability();
            //            txtUserName.focus();
            //            return false;
            var firstName = $('#<%=txtFName.ClientID %>').val().replace(/ /g, '');
            var lastName = $('#<%=txtLName.ClientID %>').val().replace(/ /g, '');
            SetUserName(firstName + "." + lastName);
        }

        var attemptCount = 0;
        function SetUserName(userName) {
            var messageUrl = '<%= ResolveUrl("~/App/AutoCompleteService.asmx/CheckUserNameAvailability") %>';
            var parameter = "{'userName':'" + userName + "',";
            parameter += "'userId':'" + $('#<%=hfUserID.ClientID %>').val() + "'}";

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                url: messageUrl,
                data: parameter,
                success: function (result) {
                    var spAvailable = document.getElementById("<%=spAvailable.ClientID %>");
                    var spNotAvailable = document.getElementById("<%=spNotAvailable.ClientID %>");
                    var spCheckAvailable = document.getElementById("<%=spCheckAvailable.ClientID %>");
                    var spMinChar = document.getElementById("<%=spMinChar.ClientID %>");
                    spCheckAvailable.style.display = "none";
                    spMinChar.style.display = "none";
                    if (result.d) {
                        spAvailable.style.display = "block";
                        spNotAvailable.style.display = "none";
                        $('#<%=txtUserName.ClientID %>').val(userName);
                        attemptCount = 0;
                    }
                    else {
                        //spNotAvailable.style.display = "block";
                        //spAvailable.style.display = "none";
                        attemptCount += 1;
                        SetUserName(userName + attemptCount);
                    }
                },
                error: function (a, b, c) {
                    alert(a.responseText);
                }
                
            });
            //alert('ghjghjk');
        }

        function txtkeypress(evt) {
            return KeyPress_NumericAllowedOnly(evt);
        }

        function hideShowEmailConsentDiv()
        {
            var email1 = $(document.getElementById('<%= txtEmail.ClientID %>'));
            var otheremail = $(document.getElementById('<%= txtEmail2.ClientID %>'));

            if($.trim(email1.val()) != "" || $.trim(otheremail.val()) != "")
            {
                $("#dvEmailConsent").show();
                if('<%= CurrentCustomer == null || CurrentCustomer.EnableEmail == true %>' == 'True')
                    $("input:radio[name$='rbtnEnableEmail'][value='true']").attr('checked','checked');
                else
                    $("input:radio[name$='rbtnEnableEmail'][value='false']").attr('checked','checked');
            }
            else
            { 
                $("#dvEmailConsent").hide();
                $("input:radio[name$='rbtnEnableEmail'][value='false']").attr('checked','checked');
            }
        }
    </script>
    <%--Dive for above 40 script ----------------%>
    <div id="bubble" class="maindiv_mbox" style="display: none; position: absolute; left: 0px; top: 0px; z-index: 100">
        <div class="mainarea_mbox">
            <div class="topbg_mbox">
                <img src="../../../Images/specer.gif" width="1px" height="1px" />
            </div>
            <div class="midbox_mbox">
                <p class="btnrow_mbox">
                    <%--<a href="#" onclick="closeDiv">
                        <img src="../../../Images/close-mbox.gif" id="dvClose" onclick="closeDiv()" />
                    </a>--%>
                    <asp:ImageButton ImageUrl="~/App/Images/close-mbox.gif" ID="btnCloseDiv" OnClientClick="closeDiv(); return false;"
                        runat="server" />
                </p>
                <p class="rowinside_mbox" id="bubbleContent" runat="server">
                </p>
            </div>
            <div class="botbg_mbox">
                <img src="../../../Images/specer.gif" width="1px" height="1px" />
            </div>
        </div>
        <div class="arrowbox_mbox">
            <img src="../../../Images/arrow-msgbox.png" />
        </div>
    </div>
    <%-- ------------------%>
    <div class="wrapper_inpg">
        <%--<h1>
            Call Centre Rep Dashboard</h1>--%>
        <div class="maindivredmsgbox" id="errordiv" runat="server" visible="false">
        </div>
        <div class="contnr_bdr">
            <div class="pgnosymbol_regcust" id="StepSymbolDiv" runat="server">
                <img src="/App/Images/CCRep/page2symbol.gif" alt="" />
            </div>
            <div class="middivrow_regcust">
                <p class="orngheadtxt_regcust" runat="server" id="StepTitleContainer">
                    Existing Customer
                </p>
                <div class="fline_regcust">
                </div>
                <p class="normaltxt_regcust" id="spRegisterScript" runat="server">
                </p>
                <div class="fline_regcust">
                </div>
                <p class="subheadingbg_ccrep" style="margin: 5px 0px 0px 0px;">
                    Personal Information
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">First Name:<sup class="reqiredmark">*</sup></span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtFName" runat="server" CssClass="inputfield_ccrep" Width="135px"></asp:TextBox></span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Middle Name:</span> <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtMName" runat="server" CssClass="inputfield_ccrep" Width="135px"></asp:TextBox></span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Last Name:<sup class="reqiredmark">*</sup></span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtLName" runat="server" CssClass="inputfield_ccrep" Width="135px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Address:<sup class="reqiredmark">*</sup></span> <span
                        class="inputconleft_regcust">
                        <asp:TextBox ID="txtAddress1" runat="server" CssClass="inputfield_ccrep" Width="135px"></asp:TextBox></span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Suite,Appts,etc.:</span> <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtAddress2" runat="server" CssClass="inputfield_ccrep" Width="135px"></asp:TextBox></span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Country:<sup class="reqiredmark">*</sup></span> <span
                        class="inputconleft_regcust">
                        <asp:DropDownList ID="ddlCountry" runat="server" Width="110px" CssClass="inputfield_ccrep">
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">State:<sup class="reqiredmark">*</sup></span> <span
                        class="inputconleft_regcust">
                        <asp:DropDownList runat="server" ID="ddlState" Width="130px" CssClass="inputfield_ccrep ddl-states">
                        </asp:DropDownList>
                    </span><span class="titletxt_regcust" style="display: none">Contact Method:</span>
                    <span class="inputconright_regcust" style="display: none">
                        <asp:RadioButton ID="rbtEmail" runat="server" Checked="True" GroupName="ContactMethod" />
                        Email &nbsp;&nbsp;<asp:RadioButton ID="rbtPhone" runat="server" GroupName="ContactMethod" />
                        Phone</span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">City:<sup class="reqiredmark">*</sup></span> <span
                        class="inputconleft_regcust">
                        <asp:TextBox runat="server" ID="txtCity" Width="110px" CssClass="inputfield_ccrep auto-Search"
                            autocomplete="off"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Zip:<sup class="reqiredmark">*</sup></span> <span
                        class="inputconleft_regcust">
                        <asp:TextBox ID="txtZip" runat="server" CssClass="inputfield_ccrep" Width="70px"></asp:TextBox></span>
                </p>
                <p class="subheadingbg_ccrep">
                    Contact Details
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Email:</span> <span class="inputconright_regcust"
                        style="width: 150px;">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="inputfield_ccrep" Width="140px" onchange="hideShowEmailConsentDiv()"></asp:TextBox></span>
                    <span class="lnktxt_regcust"><a href="#" style="font: normal 12px arial; color: #287AA8;"
                        class="jtip" title='Why we need this? | Email Address will help us in communicating with you in various occasion. e.g. password change, password reset, Appointment reminder etc.'>Why we need this?</a></span>
                </p>

                <div id="dvEmailConsent" class="middivrownopad_regcust_popup enableTexting" style="width: 330px">
                    <span style="width: 210px; padding: 0 5px; float: left">Do you wish to receive Email?:</span>
                    <div class="inputconnowidth_regcust enableTexting">
                        <asp:RadioButtonList ID="rbtnEnableEmail" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="true">Yes</asp:ListItem>
                            <asp:ListItem Value="false">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>

                <p class="middivrow_regcust">

                    <span class="titletxt_regcust">Phone(Home):<sup class="reqiredmark">*</sup></span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtHPhone" runat="server" CssClass="inputfield_ccrep mask-phone" Width="140px"></asp:TextBox>
                    </span>
                    
                    <span class="titletxt_regcust" style="width: 50px;">Consent:</span>
                    <asp:DropDownList ID="ddlPatientConsentPrimary" runat="server" Width="90px" CssClass="inputf_pw">
                    </asp:DropDownList>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Phone(Office):</span>

                    <span class="inputconleft_regcust" style="width: 90px;">
                        <asp:TextBox ID="txtOPhone" runat="server" CssClass="inputfield_ccrep mask-phone" Width="90px"></asp:TextBox>
                    </span>
                    <span class="inputconleft_regcust" style="width: 40px;padding-right: 0px;">
                        <asp:TextBox ID="PhoneOfficeExtension" placeholder="Ext" runat="server" CssClass="inputfield_ccrep" Width="40px"></asp:TextBox>
                    </span>
                    
                    <span class="titletxt_regcust" style="width: 50px;">Consent:</span>
                    <asp:DropDownList ID="ddlPatientConsentOffice" runat="server" Width="90px" CssClass="inputf_pw">
                    </asp:DropDownList>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Phone(Cell):</span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtCPhone" runat="server" CssClass="inputfield_ccrep mask-phone" Width="140px"></asp:TextBox>
                    </span>
                    
                    <span class="titletxt_regcust" style="width: 50px;">Consent:</span>
                    <asp:DropDownList ID="ddlPatientConsentCell" runat="server" Width="90px" CssClass="inputf_pw">
                    </asp:DropDownList>
                </p>
                <p class="middivrownopad_regcust_popup enableTexting" style="width: 225px">
                    <span style="width: 300px; padding: 0 5px; float: left">Do you wish to receive a SMS alert?<span class="reqiredmark"><sup>*</sup></span>:</span>
                    <div class="inputconnowidth_regcust enableTexting">
                        <asp:RadioButtonList ID="rbtnEnableTexting" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="true">Yes</asp:ListItem>
                            <asp:ListItem Value="false">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </p>
                <p class="middivrow_regcust"></p>
                <p class="middivrownopad_regcust_popup enableVoiceMail" style="width: 225px">
                    <span style="width: 300px; padding: 0 5px; float: left">Do you want to receive Voice Mail alert?<span class="reqiredmark"><sup>*</sup></span>:</span>
                    <div class="inputconnowidth_regcust enableVoiceMail">
                        <asp:RadioButtonList ID="rbtnEnableVoiceMail" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="true">Yes</asp:ListItem>
                            <asp:ListItem Value="false">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </p>
                <div class="middivrow_regcust" runat="server" id="divExistinggCust">
                    <p class="middivrow_regcust">
                        <span id="spUserName"><span class="titletxt_regcust">Username:<sup class="reqiredmark">*</sup></span>
                            <span class="inputconright_regcust">
                                <asp:TextBox ID="txtUserName" runat="server" CssClass="inputfield_ccrep" Width="140px"></asp:TextBox>
                            </span></span><span style="float: right; width: 50%"><a id="generateUserName" onclick="GenerateUserName();"
                                href="javascript:void(0);">Generate Username</a> </span><span style="float: left; padding-left: 5px; padding-top: 2px; font-style: italic;"><span id="spCheckAvailable"
                                    runat="server" style="float: left; width: 215px; padding: 7px 2px 0px 0px; display: none; font-size: 11px;">
                                    <img id="img1" runat="server" src="/App/Images/check_available.gif" alt="Username available" />Checking
                                        for username availability... </span><span id="spMinChar" runat="server" style="float: left; width: 215px; padding: 4px 2px 0px 0px; font-size: 11px; color: Red; display: none;">
                                            <img id="img2" runat="server" src="/App/Images/not-available.gif" alt="Minimum of 6 characters required" />Minimum
                                            of 6 characters required! </span><span id="spNotAvailable" runat="server" style="float: left; width: 215px; padding: 4px 2px 0px 0px; font-size: 11px; color: Red; display: none;">
                                                <img id="imgAvailable" runat="server" src="/App/Images/not-available.gif" alt="Username not available" />Not
                                                Available! </span><span id="spAvailable" runat="server" style="float: left; width: 215px; padding: 4px 0px 0px 0px; display: none; font-size: 11px; color: Green">
                                                    <img id="imgNotAvailable" runat="server" src="/App/Images/available.gif" alt="Username available" />Available!
                                                </span></span>
                    </p>
                    <p class="middivrow_regcust" id="changePasswordPara" style="display: none;" runat="server">
                        <input type="checkbox" id="changePasswordChkBox" style="margin-left: 100px;" />
                        Change Password
                    </p>
                    <p class="middivrow_regcust" id="pPassword" runat="server">
                        <span class="titletxt_regcust">Password:<sup class="reqiredmark">*</sup></span>
                        <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtPassword" MaxLength="5" runat="server" CssClass="inputfield_ccrep" autocomplete="off"
                                Width="140px"></asp:TextBox>
                            <span style="font: normal 10px arial; color: #aaaaaa; float: right;">(5 digit numeral
                                allowed)</span> </span><span style="float: right; width: 50%"><a id="lnkGeneratePassword"
                                    onclick="GeneratePassword();" href="javascript:void(0);">Generate Password</a>
                                </span>
                    </p>
                </div>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Preferred Contact:</span> <span class="inputconleft_regcust">
                        <asp:DropDownList ID="ddlPreferredContactType" runat="server" Width="145px" CssClass="inputf_pw">
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="subheadingbg_ccrep">
                    Additional Information
                </p>
                <p class="middivrow_regcust">

                    <span class="titletxt_regcust">Date of Birth:<span class="reqiredmark"><sup>*</sup></span></span>
                    <span class="inputcondob_regcust">
                        <asp:TextBox ID="txtDOB" runat="server" CssClass="inputf_def mask-date" Width="85px"></asp:TextBox>
                        <span style="font-size: 7pt; padding: 0px; margin: 0px;">mm/dd/yyyy</span> </span>
                    <span class="lnktxt_regcust"><a href="#" style="font: normal 12px arial; color: #287AA8;"
                        class="jtip" title='Why we need this? | Age is consider a risk factor by our reviewing physicians. It help them to accurately understand your screening results and provide you with better recommendations.'>Why we need this?</a></span> <span class="scripticon_default" id="spimgscript" style="display: none;">
                            <asp:ImageButton ID="imgscript" OnClientClick="return showTipBubble();" runat="server"
                                CssClass="" ImageUrl="~/App/Images/script-icon.gif" /></span>
                </p>
                <p class="middivrownopad_regcust_popup" style="width: 90px">
                    <span class="titletxt_regcust">Gender<span class="reqiredmark"><sup>*</sup></span>:</span>
                    <div class="inputconnowidth_regcust">
                        <asp:RadioButtonList ID="rbtnGender" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                        </asp:RadioButtonList>
                        <%--//TODO Bidhan Check This--%>
                    </div>
                    <span class="lnktxt_regcust"><a href="#" style="font: normal 12px arial; color: #287AA8;"
                        class="jtip" title='Why we need this? |<%= IoC.Resolve<ISettings>().CompanyName %> requires clients to provide a gender details because gender is 
                        an important factor for health screening. Secondly, physicians require the information prior to review of screening results.'>Why we need this?</a></span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Height:</span> <span class="inputfieldrightcon_editp"
                        style="width: 140px;"><span class="inputfldnowidth_default">
                            <asp:DropDownList ID="ddlFeet" runat="server" Width="40px">
                                <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            </asp:DropDownList>
                        </span><span class="ttxtnowidthnormal_default">ft</span> <span class="inputfldnowidth_default">
                            <asp:DropDownList ID="ddlInch" runat="server" Width="40px">
                                <asp:ListItem Text="0" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            </asp:DropDownList>
                        </span><span class="ttxtnowidthnormal_default">in</span> </span><span class="titletxt_regcust"
                            style="width: 60px;">Weight:</span> <span class="inputconright_regcust" style="width: 90px;">
                                <asp:TextBox ID="txtweight" runat="server" CssClass="inputf_editp" Width="50px"></asp:TextBox>
                                <span style="color: #666;">(lbs)</span> </span><span class="lnktxt_regcust"><a href="#"
                                    style="font: normal 12px arial; color: #287AA8;" class="jtip" title='Why we need this? | Height and Weight are consider a risk factor by our reviewing physicians. It help them to accurately understand your screening results and provide you with better recommendations.'>Why we need this?</a></span>
                </p>
                <p>
                    <span class="titletxt_regcust">Race:</span> <span class="inputconleft_regcust">
                        <asp:DropDownList ID="ddlrace" runat="server" Width="135px">
                            <asp:ListItem Text="Select Race"></asp:ListItem>
                            <asp:ListItem Text="Caucasian"></asp:ListItem>
                            <asp:ListItem Text="African American"></asp:ListItem>
                            <asp:ListItem Text="Hispanic"></asp:ListItem>
                            <asp:ListItem Text="Asian"></asp:ListItem>
                            <asp:ListItem Text="Native American"></asp:ListItem>
                            <asp:ListItem Text="Other"></asp:ListItem>
                        </asp:DropDownList>
                    </span><span class="lnktxt_regcust"><a href="#" style="font: normal 12px arial; color: #287AA8;"
                        class="jtip" title='Why we need this? | Race is consider a risk factor by our reviewing physicians. It help them to accurately understand your screening results and provide you with better recommendations.'>Why we need this?</a></span>
                </p>
                <p class="middivrow_regcust" id="InsuranceIdContainer" runat="server">
                    <span class="titletxt_regcust">
                        <span id="InsuranceIdLabel" runat="server">Insurance Id<span id="InsuranceIdRequiredMark" class="reqiredmark"><sup>*</sup></span></span>:
                    </span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="InsuranceIdTextbox" runat="server" CssClass="inputf_editp" Width="150px"></asp:TextBox>
                    </span>
                    <asp:HiddenField runat="server" ID="InsuranceIdRequiredHiddenField" />
                    <asp:HiddenField runat="server" ID="InsuranceIdLabelHiddenField" />
                </p>
                <p class="middivrow_regcust" id="SsnContainer" runat="server">
                    <span class="titletxt_regcust">
                        <span>SSN</span>:
                    </span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="SsnTextbox" runat="server" CssClass="inputf_editp mask-ssn" Width="110px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">
                        <span>Medicare Id<span id="MedicareIdRequiredMark" class="reqiredmark"><sup>*</sup></span></span>:
                    </span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="MedicareIdTextbox" runat="server" CssClass="inputf_editp" Width="150px"></asp:TextBox>
                    </span>
                    <asp:HiddenField runat="server" ID="MedicareIdRequiredHiddenField" />
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">
                        <span>MBI Number</span>:
                    </span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="MbiNumberTextbox" runat="server" CssClass="inputf_editp" Width="150px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Medicare Advantage Number:
                    </span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="MedicareAdvantageNumber" runat="server" CssClass="inputf_editp" Width="150px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Medicare Plan Name:
                    </span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="MedicareAdvantagePlanName" runat="server" CssClass="inputf_editp" Width="150px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="orngsmalltxt_regcust">How did you hear about
                        <%= IoC.Resolve<ISettings>().CompanyName %>!?</span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Marketing Source:<sup class="reqiredmark">*</sup></span>
                    <span class="inputconleft_regcust">
                        <asp:DropDownList runat="server" ID="MarketingSourceDropDown" Style="width: 200px;">
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="normaltxt_regcust" style="font-size: 11px;">
                    E.g. Internet, Radio, Email, Flyer, Friend, Magazine, Television etc.
                </p>

                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Incoming Phone Line:</span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="IncomingPhoneLineTextBox" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Caller's Phone Number:<sup id="callersPhoneNumberAstrik" class="reqiredmark">*</sup></span>
                    <span class="inputconleft_regcust">
                        <asp:TextBox ID="CallersPhoneNumberTextBox" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Preferred Language:<sup class="reqiredmark">*</sup>
                    </span>
                    <%--<span class="inputconleft_regcust">
                        <asp:TextBox ID="PreferredLanguageTextbox" runat="server" CssClass="inputf_pw" Width="200px"></asp:TextBox>
                    </span>--%>
                    <span class="inputconleft_regcust">
                        <asp:DropDownList runat="server" ID="PreferredLanguageDropDown" Style="width: 200px;">
                        </asp:DropDownList>
                    </span>
                </p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Best Time to Call:</span>
                    <span class="inputconleft_regcust">
                        <asp:DropDownList runat="server" ID="BestTimeToCallDropdown" Style="width: 200px;">
                        </asp:DropDownList>
                    </span>
                </p>

                <p class="subheadingbg_ccrep">Alternate Contact Information</p>
                <p class="middivrow_regcust">
                    <span class="titletxt_regcust">Alternate Email:</span> <span class="inputconleft_regcust">
                        <asp:TextBox ID="txtEmail2" runat="server" CssClass="inputfield_ccrep" Width="135px" onchange="hideShowEmailConsentDiv()"></asp:TextBox></span>
                </p>

                <div id="divHintQA" runat="server" style="display: none;" enableviewstate="true">
                    <p class="middivrow_regcust">
                        <span class="titletxt_regcust">Hint Question:</span> <span class="inputconleft_regcust">
                            <asp:DropDownList ID="ddlQues1" runat="server" Width="315px" CssClass="inputf_pw">
                            </asp:DropDownList>
                        </span>
                    </p>
                    <p class="middivrow_regcust">
                        <span class="titletxt_regcust">Hint Answer:</span> <span class="inputconleft_regcust">
                            <asp:TextBox ID="txtAnswer1" runat="server" CssClass="inputf_pw" Width="310px"></asp:TextBox>
                        </span>
                    </p>
                </div>
                <div class="fline_regcust">
                </div>
                <p class="buttoncell_ccrep" style="width: 200px;">
                    <span class="buttoncon_ccrep">
                        <asp:ImageButton ID="ibtnBack" runat="server" ImageUrl="~/App/Images/back-buton.gif"
                            OnClick="ibtnBack_Click" />
                    </span><span class="buttoncon_ccrep">
                        <asp:ImageButton ID="imgReset" runat="server" ImageUrl="/App/Images/reset-btn.gif"
                            OnClientClick="Reset(); return false;" /></span> <span class="buttoncon_ccrep">
                                <asp:ImageButton ID="imgNext" runat="server" ImageUrl="/App/Images/next-buton.gif"
                                    OnClientClick="return Validation()" OnClick="imgNext_Click" />
                            </span>
                </p>
            </div>
            <div class="rightdivrow_regcust" id="divCall" runat="server">
                <div class="timeboard_ccrep_dboard">
                    <div class="timeboxbg_ccrep_dboard">
                        <p class="tboxrow_ccrep_dboard">
                            <span class="timetxt_ccrep_dboard"><span id="HH"></span>:<span id="MM"></span>:<span
                                id="SS"></span></span>
                        </p>
                        <p class="tboxrowformat_ccrep_dboard">
                            <span class="smallgraytxt_ccrep">(HH:MM:SS)</span>
                        </p>
                        <p class="tboxrowbtm_ccrep_dboard">
                            <span class="whttxt_ccrep_dboard">Call in Progress</span>
                        </p>
                    </div>
                </div>
                <div class="endcall_ccrep_dboard" style="margin-top: 5px">
                    <span class="endtbtn_ccrep_dboard">
                        <asp:ImageButton ID="imgEndCall" runat="server" ImageUrl="~/App/Images/CCRep/endcallbtn.gif"
                            OnClientClick="closeScriptPopup(); CallNotes(); return false;" />
                    </span>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript" language="javascript">

        function BindSateDropDown(stateList) {//debugger;
            $('#' + '<%=ddlState.ClientID %> >option').remove();

            if (stateList.length > 0) {
                $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val('0').html('Select State'));
                for (var i = 0; i < stateList.length; i++) {
                    if (stateList[i].CountryId == $('#' + '<%=ddlCountry.ClientID %>').val())
                        $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val(stateList[i].Id).html(stateList[i].Name));
                }
            }
            else {
                $('#' + '<%=ddlState.ClientID %>').append($('<option></option>').val('0').html('No State Found'));
            }
            if ($('#<%=hfstate.ClientID %>').val() != '') {
                $("#<%= ddlState.ClientID %> option:contains('" + $('#<%=hfstate.ClientID %>').val() + "')").first().attr('selected', true);
            }
        }

        function SetState() {
            $('#<%=hfstate.ClientID %>').val($('#<%=ddlState.ClientID %> option:selected').text());
        }
    
    </script>
    <script type="text/javascript" language="javascript">
        var states;
        $(document).ready(function () {
            states=<%= GetStates() %>;
            BindSateDropDown(states);

            checkAndOpenScriptPopup();

            $("#<%= MarketingSourceDropDown.ClientID %>").sexyCombo({hiddenSuffix: '_hidden', emptyText: 'Type here for quick search', triggerSelected: true});

            $('#<%=ddlCountry.ClientID %>').bind("change", function () { BindSateDropDown(states); });
            
            $('.jtip').cluetip({ splitTitle: '|', cursor: 'pointer', tracking: true, cluetipClass: 'jtip', arrows: true, dropShadow: false, hoverIntent: false, width: 400 });

            $('.auto-Search').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                type: "POST",
                data: "prefixText",
                contextKey: $('.ddl-states option:selected').val()
            });

            $('.ddl-states').change(function () {
                $('.auto-Search').autoComplete({
                    autoChange: true,
                    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCityByContextKeyAndPrefixText")%>',
                    type: "POST",
                    data: "prefixText",
                    contextKey: $('.ddl-states option:selected').val()
                });
                SetState();
            });

            $('.mask-phone').mask('(999)-999-9999');
            
            $('.mask-ssn').mask('***-**-****');

            $('.mask-date').mask('99/99/9999');

            if ('<%= IsInboundCall %>' == '<%= Boolean.TrueString %>') {
                $('.inbound-call').show();
            }
            else{
                $('.inbound-call').hide();
            }

            
            <% if (string.IsNullOrEmpty(ZipCode))
               {%>

            $('.auto-SearchMarketingSource').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/FetchMarketingSourceByTerritory")%>',
                type: "POST",
                data: "prefixText",
                pickContextKeyfrom : '<%=txtZip.ClientID%>'
            });
            <%
               }
               else
               {%>

            $('.auto-SearchMarketingSource').autoComplete({
                autoChange: true,
                url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/FetchMarketingSourceByTerritory")%>',
                type: "POST",
                data: "prefixText",
                contextKey : '<%=ZipCode%>'
            });
            <%
               }%>
            
            if('<%= EnableSmsNotification %>' == '<%= Boolean.FalseString %>')
            {
                $(".enableTexting").hide();
            }
            else
            {
                $(".enableTexting").show();
            }

            if('<%= EnableVoiceMailNotification %>' == '<%= Boolean.FalseString %>')
            {
                $(".enableVoiceMail").hide();
            }
            else
            {
                $(".enableVoiceMail").show();
            }


            
            if ($("#<%= MedicareIdRequiredHiddenField.ClientID %>").val() == '<%= Boolean.TrueString %>') {
                $("#MedicareIdRequiredMark").show();
            } else {
                $("#MedicareIdRequiredMark").hide();
            }
            
            if ($("#<%= InsuranceIdRequiredHiddenField.ClientID %>").val() == '<%= Boolean.TrueString %>') {
                $("#InsuranceIdRequiredMark").show();
            } else {
                $("#InsuranceIdRequiredMark").hide();
            }
            
            if ('<%= IsInboundCall %>' == '<%= Boolean.TrueString %>') {
                $("#callersPhoneNumberAstrik").show();
            } else {
                $("#callersPhoneNumberAstrik").hide();
            }
            if ($('#<%= isPageOpenedByBackClick.ClientID %>').val() == 'true') {
                $("#<%= changePasswordPara.ClientID %>").show();
                $("#<%= pPassword.ClientID %>").hide();
            } else { 
                $("#<%= changePasswordPara.ClientID %>").hide();
                $("#<%= pPassword.ClientID %>").show();
            }
            $('#changePasswordChkBox').change(function() {
                if ($('#changePasswordChkBox').is(":checked")) {
                    $("#<%= changePasswordPara.ClientID %>").hide();
                    $("#<%= pPassword.ClientID %>").show();
                }
            });
            
            hideShowEmailConsentDiv();
        });
        
    </script>
    <asp:HiddenField runat="server" ID="hfCallStartTime" />
    <asp:HiddenField ID="hfCustomer" runat="server" Value="New" />
    <asp:HiddenField ID="hfUserID" Value="0" runat="server" />
    <asp:HiddenField ID="isPageOpenedByBackClick" runat="server" />
    <asp:HiddenField ID="hfstate" runat="server" />
    <script language="javascript" type="text/javascript">
        //// this will run after page is load
        var hfCallStartTime = document.getElementById("<%= this.hfCallStartTime.ClientID %>");
        StartTimer(hfCallStartTime);
    </script>
    <script type="text/javascript">
        (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
            (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
            m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
        })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

        ga('create', 'UA-957361-18', 'auto');
        ga('send', 'pageview');

        
    </script>
</asp:Content>
