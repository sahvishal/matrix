<%@ Page Language="C#" MasterPageFile="~/App/Franchisee/Technician/TechnicianMaster.master"
    AutoEventWireup="true" Inherits="Franchisee_Technician_UploadResults"
    Title="Upload Results" Codebehind="UploadResults.aspx.cs" %>

<%@ Register Assembly="MattBerseth.WebControls.AJAX" Namespace="MattBerseth.WebControls.AJAX.Progress"
    TagPrefix="mb" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



<style type="text/css">
#olist li {
  display:list-item !important;
  list-style-type:decimal !important;
}
</style>

<link rel="Stylesheet" href="/App/Stylesheets/_assets/css/progress.css" />
<link rel="Stylesheet" href="/App/Stylesheets/_assets/css/upload.css" />


        <script type="text/javascript">
        var intervalID = 0;
        var progressBar;
        var fileUpload;
        var formchild;
        var eventtext = '';
        var eventidbox = '';
                
        function pageLoad(){
            //  attach to the upload click event and grab a reference to
            //  the progress bar
            //$addHandler($get('upload'), 'click', onUploadClick);
            //progressBar = document.getElementById('<%= this.progress.ClientID %>');
            
            progressBar = $find('<%= this.progress.ClientID %>');    
        }
        
        function register(param_form, param_fileUpload, param_eventidbox){
            //  register the form
            this.formchild = param_form;
            this.fileUpload = param_fileUpload;
            this.eventidbox = param_eventidbox;
        }        
        
        function onUploadClick(){
            //  todo: insert any regex to do any simple validation checks on
            //  the client.
            
            var valcheck = eventidbox.value.replace(/ /g, '');
                       
            if(valcheck.length < 1)
            {
                alert('Please enter some EventID.');
                return;
            }
            
            var vaild = fileUpload.value.length > 0;
            if(vaild){
                //  disable the upload button
                //$get('upload').disabled = 'disabled';
                
                //  update the message
                updateMessage('info', 'Initializing upload ...');
                
                //  submit the form containing the fileupload
                this.formchild.submit();
                
                //  hide the frame
                Sys.UI.DomElement.addCssClass($get('uploadFrame'), 'hidden');
                
                //  zero out the progressbar and show it
                progressBar.set_percentage(0);
                progressBar.show();                
                
                //  start polling to check on the progress ...
                intervalID = window.setInterval(function(){
                    PageMethods.GetUploadStatus(function(result){
                        if(result){
                            //  update the progressbar to the new value
                            progressBar.set_percentage(result.percentComplete);
                            //  upadte the message
                            updateMessage('info', result.message);
                            
                            if(result == 100){
                                //  clear the interval
                                window.clearInterval(intervalID);                        
                            }
                        }
                    });
                }, 500);                
            }
            else{
                //  todo: insert what ever error message makes sense for
                //  the validation that was done.
                alert('You need to select a file.');
                onComplete('error', 'You need to select a file.');
            }
        }       
    
        function onComplete(type, msg){
        //debugger
            //  clear the interval
            window.clearInterval(intervalID);
            //  display the message
            updateMessage(type, msg);
            //  hide the progress bar
            progressBar.hide();
            progressBar.set_percentage(0);
            var status = $get('status');
            status.style.display = 'none';
            
            //  show the frame
            Sys.UI.DomElement.removeCssClass($get('uploadFrame'), 'hidden');
            
        }
        
        function updateMessage(type, value){
        //debugger
            var status = $get('status');
            status.style.display = 'block';
            status.innerHTML = value;
            //  remove all styles
            status.className = '';
            Sys.UI.DomElement.addCssClass(status, type);
        }
            
   
        </script>


    <div class="mainbody_outer">
        <div class="mainbody_inner">
            <div class="main_area_bdrnone">
                <p><img src="/App/Images/specer.gif" alt="" width="700px" height="5px" /></p>
                <div class="headingbox_top_body" style="width: 753px;">
                    <span class="orngheadtxt_heading" style="float: left;" runat="server" id="Span1">Upload
                        Results</span> <span class="headingright_default"><a href="manageuploadedresult.aspx">
                            Manage Current Uploads</a> </span>
                </div>
                <p><img src="/App/Images/specer.gif" alt="" width="700px" height="2px" /></p>
                <p class="graylinefull_common"><img src="../../Images/specer.gif" alt="" width="1px" height="1px" /></p>
                <p><img src="../../Images/specer.gif" alt="" width="700px" height="5px" /></p>
            </div>
            <div class="main_area_bdrnone">
                <div class="divmainbody_cd">
                    <div class="grayboxtop_cl">
                        <p class="grayboxtopbg_cl">
                            <img src="/app/Images/specer.gif" width="746" height="6" alt="" /></p>
                        <p class="grayboxheader_cl">
                        </p>
                        <div class="lgtgraybox_cl">
                            <iframe id="uploadFrame" frameborder="0" scrolling="no" width="700px" height="170px"
                                src="Upload.aspx"></iframe>
                            <mb:progresscontrol id="progress" runat="server" cssclass="vista" style="padding-left: 5px;
                                display: none;" value="0" mode="Manual" speed=".4" width="98%" />
                            <div id="status" class="info" style="float: left; padding-left: 5px; display: none">
                            </div>
                        </div>
                </div>
                </div>
                <div><img src="/App/Images/specer.gif" alt="" width="740px" height="20px" /></div>
                <div class="lgtgraybox_cl">
                    <div class="blueboxtopbg_ur"><img src="/App/Images/specer.gif" alt="" width="746px" height="6px" /></div>
                    <div class="instructiontxt_ur">
                       <p class="lgtgrayboxrow_cl"><span class="blktextbig_default">Upload Instructions:</span></p>
                       <div class="lgtgrayboxrow_cl">
                          <table>
                            <tr><td valign=top>1. </td><td valign=top>Export the data from each screening device (Cardiovision, GE Insight, Sonosite, EKG/ECG) to your laptop/computer.</td></tr>
                            <tr><td valign=top>2. </td><td valign=top>Create a folder on your laptop/computer with the Event ID (e.g., 104). You can get the Event ID from the
                                event list on the dashboard or by searching for it. It is available from several locations.</td>
                            </tr>
                            <tr><td valign=top>3. </td><td valign=top>Under the Event ID folder, create a sub-folder for each machine. The folder names should be:
                                <b>cardiovision, osteo,</b><b>sono</b> and <b>EKG/ECG</b>.</td>
                            </tr>
                            <tr><td valign=top>4. </td><td valign=top>Copy the results (all data files and exported files) from each machines into the respective folders
                                created in the previous step.</td>
                            </tr>
                            <tr><td valign=top>5. </td><td valign=top>Zip the all the files starting at the Event ID folder.</td></tr>
                            <tr><td valign=top>6. </td><td valign=top>Browse and select this zip file from your computer and upload it using this screen.</td></tr>
                            <tr><td valign=top>7. </td><td valign=top>Below is an example of how the folders should look on your local computer and in the zip file that you upload.</td></tr>
                         </table>
                       </div>
                       <div class="lgtgrayboxrow_cl" style="text-align: center"><img src="/App/Images/Upload_Instruction.gif" alt="" /></div>
                       <div><img src="/App/Images/specer.gif" width="740px" alt="" height="20px" /></div>
                    </div>
                    <div class="blueboxbotbg_cl"><img src="/App/Images/specer.gif" width="746px" alt="" height="6px" /></div>
                </div>
                <div><img src="/App/Images/specer.gif" width="740px" alt="" height="20px" /></div>
            </div>
        </div>
    </div>
   
</asp:Content>
