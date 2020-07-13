<%@ Page Language="C#" EnableSessionState="ReadOnly" Async="true" %>

<%@ Import Namespace="Falcon.App.Core.Enum" %>
<%@ Import Namespace="Falcon.DataAccess.Master" %>
<%@ Import Namespace="Falcon.Entity.Franchisee" %>
<%@ Import Namespace="Falcon.Entity.Other" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/App/UCCommon/JQueryToolkit.ascx" TagName="JQueryToolkit" TagPrefix="JQueryControl" %>
<%@ Import Namespace="System.IO" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>

    <script runat="server">
        
        private string shellId = string.Empty;
        
        public string ContextKey
        {
            get
            {
                return shellId;
            }
            set
            {
                shellId = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["ShellID"] != null)
                    ContextKey = Request.QueryString["ShellID"].ToString();

                if (this.IsPostBack)
                {
                    UploadInfo uploadInfo = this.Session["UploadInfo"] as UploadInfo;
                    //  let the webservie know that we are not yet ready
                    uploadInfo.IsReady = false;

                    //  do some basic validation
                    if (this.fileupload.PostedFile != null && this.fileupload.PostedFile.ContentLength > 0 && Request.QueryString["TechnicianID"] != null && Request.QueryString["RoleID"] != null)
                    {
                        // this block is for fetching eventid
                        string eventid = "";
                        string eventname = txtEvent.Text;
                        Int32 tryintparse = 0;
                        if (Int32.TryParse(eventname, out tryintparse))
                            eventid = tryintparse.ToString();
                        else
                        {
                            int startpoint = eventname.IndexOf("[ID:");
                            if (startpoint < 0)
                            {
                                //ClientScript.RegisterStartupScript(typeof(string), "jscode", " alert('Please provide eventid in square brackets.');", true);
                                ScriptManager.RegisterStartupScript(this, typeof(Franchisee_Technician_UploadResults), "progress", " alert('Please provide eventid also.'); window.parent.onComplete('error', 'Please provide eventid also.');", true);
                                return;
                            }

                            int length = (eventname.Length - 1) - (startpoint + 4);

                            if (startpoint > 0)
                            {
                                eventid = eventname.Substring(startpoint + 4, length);
                            }

                            if (eventid.Length < 1)
                            {
                                //ClientScript.RegisterStartupScript(typeof(string), "jscode", " alert('Please provide eventid in square brackets.');", true);
                                ScriptManager.RegisterStartupScript(this, typeof(Franchisee_Technician_UploadResults), "progress", " alert('Please provide eventid also.'); window.parent.onComplete('error', 'Please provide eventid also.');", true);
                                return;
                            }
                        }


                        var masterDal = new MasterDAL();
                        int isFutureEvent = masterDal.CheckIffutureEvent(Convert.ToInt64(eventid));
                        //0 if event is future event
                        if (isFutureEvent == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Franchisee_Technician_UploadResults), "progress", " alert('Results for future event can\\'t be uploaded.');window.parent.onComplete('error', 'Results for future event can\\'t be uploaded.');", true);
                            return;
                        }

                        //  build the local path
                        string path = ConfigurationManager.AppSettings["UploadResultFolder"].ToString();
                        if (!System.IO.Directory.Exists(path)) System.IO.Directory.CreateDirectory(path);

                        string fileName = Path.GetFileName(this.fileupload.PostedFile.FileName);
                        string fullpath = renamefile(Path.Combine(path, fileName), eventid, Request.QueryString["TechnicianID"].ToString());

                        //  build the strucutre and stuff it into session
                        uploadInfo.ContentLength = this.fileupload.PostedFile.ContentLength;
                        uploadInfo.FileName = fileName;
                        uploadInfo.UploadedLength = 0;


                        /* Preparing object for Insertion in DB */
                        //HealthYes.Web.UI.TestService.TestService service = new HealthYes.Web.UI.TestService.TestService();
                        EUploadZipInfo objuploadzipinfo = new EUploadZipInfo();

                        objuploadzipinfo.FileName = fullpath;
                        objuploadzipinfo.FileSize = fileupload.FileBytes.Length.ToString();
                        objuploadzipinfo.UploadStartTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                        //  todo: execute any special logic if the file already exists ...

                        //  let the polling process know that we are done initializing ...
                        uploadInfo.IsReady = true;

                        //  DEMOWARE: set the buffer size to something larger.
                        //  the smaller the buffer the longer it will take to
                        //  download, but the more precise your progress bar will be.
                        //  to large of a value and the progress bar will make real large jumps
                        int bufferSize = 1;
                        byte[] buffer = new byte[bufferSize];

                        //  write the byte to disk
                        using (FileStream fs = new FileStream(fullpath, FileMode.Create))
                        {
                            //  aslong was we haven't written everything ...
                            while (uploadInfo.UploadedLength < uploadInfo.ContentLength)
                            {
                                //  fill the buffer from the input stream
                                int bytes = this.fileupload.PostedFile.InputStream.Read(buffer, 0, bufferSize);
                                //  write the bytes to the file stream
                                fs.Write(buffer, 0, bytes);
                                //  update the number the webservice is polling on
                                uploadInfo.UploadedLength += bytes;
                            }
                        }


                        objuploadzipinfo.UploadedBy = new EFranchiseeFranchiseeUser
                                                          {
                                                              FranchiseeFranchiseeUserID =
                                                                  Convert.ToInt32(Request.QueryString["TechnicianID"]),
                                                              RoleID = Convert.ToInt32(Request.QueryString["RoleID"])
                                                          };
                        objuploadzipinfo.UploadEndTime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                        objuploadzipinfo.Event = new EEvent { EventID = Convert.ToInt32(eventid) };
                        objuploadzipinfo.UploadSuccessful = true;
                        objuploadzipinfo.PreviousFileDiscarded = chkDiscardPrevFile.Checked;

                        MasterDAL testresultdal = new MasterDAL();
                        testresultdal.SaveUploadZipInfo(objuploadzipinfo, Convert.ToInt16(EOperationMode.Insert));

                        txtEvent.Text = "";
                        //txtZip.Text = "";

                        //  let the parent page know we have processed the uplaod
                        const string js = "alert('Results has been uploaded successfully.');window.parent.onComplete('success', '{0} has been uploaded successfully.');";
                        ScriptManager.RegisterStartupScript(this, typeof(Franchisee_Technician_UploadResults), "progress", string.Format(js, fileName), true);
                    }
                    else
                    {
                        //  let the parent page know we have processed the uplaod
                        const string js = "alert('There was a problem with the file.');window.parent.onComplete('error', 'There was a problem with the file.');";
                        ScriptManager.RegisterStartupScript(this, typeof(Franchisee_Technician_UploadResults), "progress", js, true);
                    }
                    chkDiscardPrevFile.Checked = false;
                    //  let the webservie know that we are not yet ready
                    uploadInfo.IsReady = false;
                }
            }
            catch (Exception)
            {
                chkDiscardPrevFile.Checked = false;
            }
        }

        private string renamefile(string filename, string eventid, string technicianid)
        {

            string newfilename = Path.GetDirectoryName(filename) + "\\" + eventid + "_" + technicianid + "_" + DateTime.Now.ToFileTimeUtc() + System.IO.Path.GetExtension(filename);
            return newfilename;
        }
         
    </script>

    <style type="text/css">
        BODY
        {
            margin: 0;
            padding: 0;
        }
    </style>
    <link rel="Stylesheet" href="/App/StyleSheets/_assets/css/upload.css" />
</head>
<body style="background-color: #F5F5F5;">
    <form id="form" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="scriptManager" runat="server" />
    <JQueryControl:JQueryToolkit ID="JQueryToolkit1" runat="server" IncludeJQueryUI="true"
        IncludeJTemplate="true" IncudeJQueryJTip="true" IncudeJQueryAutoComplete="true" />

    <script type="text/javascript">
        function pageLoad(sender, args){  
        //debugger      
            //  register the form and upload elements
            window.parent.register(
                $get('<%= this.form.ClientID %>'), 
                $get('<%= this.fileupload.ClientID %>'),
                $get('<%= this.txtEvent.ClientID %>')
            );
        }
         
        function filleventbox()
        {
            document.getElementById('<%= this.txtEvent.ClientID %>').value = window.parent.eventtext;
        }
        
        function onUploadClick()
        {
            var fileExpression = /^.+\.((zip))$/;
            
            if($.trim($('.auto-search-events').val()).length < 1)
            {
                window.parent.alert('Please select a event to upload file for.');
                return;
            }
            
            if($.trim($('.fileupload-control').val()).length < 1)
            {
                window.parent.alert('Please select a zip file to upload.');
                return;
            }
            
            if ($.trim($('.fileupload-control').val()).length > 0 && fileExpression.exec($.trim($('.fileupload-control').val().toLowerCase())) == null) 
            {
                window.parent.alert('Only zip files are allowed!');
                return;
            }
            
            window.parent.onUploadClick();
        }
        
        function CheckDiscardBoxClick()
        {
            var chkDiscard = document.getElementById('<%= this.chkDiscardPrevFile.ClientID %>');
            if(chkDiscard.checked) alert('This is Critical.\n\nThis will discard/delete previous file and records, irrespective of what state results are in.');
        }
        
    </script>

    <div style="float: left; width: 700px;">
        <p>
            <img src="/App/Images/specer.gif" alt="" width="700px" height="5px" /></p>
        <p class="lgtgrayboxrow_cl">
            <asp:CheckBox runat="server" ID="chkDiscardPrevFile" Text="Discard, If Any, Previous File"
                onclick="CheckDiscardBoxClick();" />
        </p>
        <p>
            <img src="/App/Images/specer.gif" alt="" width="700px" height="5px" /></p>
        <p class="lgtgrayboxrow_cl">
            <span class="titletext_default">Select Event:</span> <span class="inputfldnowidth_default">
                <asp:TextBox ID="txtEvent" runat="server" CssClass="inputf_def auto-search-events "
                    Width="400px"></asp:TextBox>
                &nbsp;</span>
        </p>
        <p>
            <img src="/App/Images/specer.gif" alt="" width="700px" height="5px" /></p>
        <p class="lgtgrayboxrow_cl">
            <span class="titletext_default">Test Result Zip File: </span><span class="inputfieldcon_ur_fileupload">
                <asp:FileUpload ID="fileupload" runat="server" CssClass="inputf_ur_fileupload fileupload-control" Width="400px" />
            </span>
        </p>
        <p class="uploadbuttrow_ur" id="upload">
            <span class="buttoncon3_default"><a href="javascript:onUploadClick();">
                <img src="/App/Images/uploadnew-button.gif" alt="" />
            </a></span>
        </p>
    </div>

    <script type="text/javascript" language="javascript">
    
    $(document).ready(function(){
    
        var contextKey = "<%= this.ContextKey %>";
        
        $('.auto-search-events').autoComplete({
		    autoChange: true,
		    url: '<%=ResolveUrl("~/App/AutoCompleteService.asmx/GetCompletedEvents")%>',
		    type: "POST",
		    data: "prefixText",
		    contextKey: contextKey
        });

    });
    
    </script>

    </form>
</body>
</html>
