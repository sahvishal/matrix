<%@ Page Language="C#" AutoEventWireup="true" Inherits="App_Franchisee_Technician_UploadTestImages"
    CodeBehind="UploadTestImages.aspx.cs" %>

<%@ Import Namespace="Falcon.App.Core.Application.Domain" %>
<%@ Import Namespace="Falcon.App.Core.Medical.Enum" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <link href="../../StyleSheets/Technician.css" rel="stylesheet" type="text/css" />
    <link href="/Content/Styles/jquery.qtip.min.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="/Scripts/jquery-1.5.2.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.qtip.min.js"></script>
    <script type="text/javascript" src="/Scripts/jquery.tmpl.min.js"></script>
    <script type="text/javascript" src="/Scripts/json2.min.js"></script>
    <script type="text/javascript" src="/Scripts/flowplayer-3.2.6.js"></script>
    <script type="text/javascript" src="/Scripts/Video/video.js"></script>
    <link href="/Scripts/Video/video-js.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">

        function UploadClick() {
            var fileExpression = /^.+(.gif|.GIF|.svg|.SVG|.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.PNG|.png|.avi|.AVI|.wmv|.WMV|.mov|.MOV|.mp4|.MP4|.flv|.FLV|.pdf|.PDF)$/;
            var isComplete = false;

            $('.file-upload').each(function () {
                if ($.trim($(this).val()).length > 0 && fileExpression.exec($.trim($(this).val())) == null) {
                    alert('Only valid Image file types (gif, bmp, pdf, svg, png, jpg or jpeg) and video files (wmv, mov, mp4, flv or avi) are allowed!');
                    isComplete = true;
                    return;
                }
            });

            if (!isComplete) {
                var isFilled = false;
                $('.file-upload').each(function () {
                    if ($.trim($(this).val()).length > 0) {
                        isFilled = true;
                        return;
                    }
                });

                if (!isFilled) {
                    alert('Atleast select one file to upload.');
                    return false;
                }

                if ('<%= RestricttoOne.ToString() %>' == '<%= Boolean.TrueString %>' && $(".media-block").length > 0) {
                    var result = confirm("Do you want to override the existing media?");
                    if (result == false) {
                        return false;
                    }
                }

                return true;
            }
            else
                return false;
        }

        var media = null;
        function getJsonToDisplay() {
            <% switch (Test)
               {
                    case TestType.AAA:%>
                    media = parent.getAaaMedia();
                    <%
                    break;
                    case TestType.AwvAAA:
                    %>
                    media = parent.getAwvAaaMedia();
                    <%
                    break;
                    case TestType.Stroke:
                    %>
                    media = parent.getStrokeMedia();
                    <%
                    break;
                    case TestType.AwvCarotid:
                    %>
                    media = parent.getAwvCarotidMedia();
                    <%
                    break;
                    case TestType.Lead:
                    %>
                    media = parent.getLeadMedia();
                    <%
                    break;
                    case TestType.Echocardiogram:
                    %>
                    media = parent.getEchoMedia();
                    <%
                    break;
                    case TestType.AwvEcho:
                    %>
                    media = parent.getAwvEchoMedia();
                    <%
                    break;
                    case TestType.IMT:
                    %>
                    media = parent.getImtMedia();
                    <%
                    break;
                    case TestType.Thyroid:
                    %>
                    media = parent.getThyroidMedia();
                    <%
                    break;
                    case TestType.EKG:
                    %>
                    media = parent.getEkgMedia();
                    <%
                    break;
                    case TestType.PulmonaryFunction:
                    %>
                    media = parent.getPulmonaryMedia();
                    <%
                    break;
                    case TestType.Spiro:
                    %>
                    media = parent.getSpiroMedia();
                    <%
                    break;
                    case TestType.AwvSpiro:
                    %>
                    media = parent.getAwvSpiroMedia();
                    <%
                    break;
                    case TestType.PPAAA:
                    %>
                    media = parent.getPpAaaMedia();
                    <%
                    break;
                    case TestType.PPEcho:
                    %>
                    media = parent.getPpEchoMedia();
                    <%
                    break;
                    case TestType.HCPAAA:
                    %>
                    media = parent.getHcpAaaMedia();
                    <%
                    break;
                    case TestType.HCPCarotid:
                    %>
                    media = parent.getHcpCarotidMedia();
                    <%
                    break;
                    case TestType.HCPEcho:
                    %>
                    media = parent.getHcpEchoMedia();
                    <%
                    break;
                    case TestType.QuantaFloABI:
                    %>
                    media = parent.getQuantaFloABIMedia();
                    <%
                    break;
                    case TestType.AwvEkg:
                    %>
                    media = parent.getAwvEkgMedia();
                    <%
                    break;
                    case TestType.AwvEkgIPPE:
                    %>
                    media = parent.getAwvEkgIpppeMedia();
                    <%
                    break;
               }%>

            if (media != null) {
                $("#<%= JsonForImageObject.ClientID %>").val(JSON.stringify(media));
                setImagestoDisplay();
                renderImages();
            }
        }

        var displayImgObjects = new Object();

        function setImagestoDisplay() {
            var index = 0;
            displayImgObjects = new Object();
            $.each(media, function () {
                displayImgObjects[index] = new Object();
                displayImgObjects[index].FileName = this.File.Path;
                displayImgObjects[index].File = parent.getUrlPrefix() + this.File.Path;
                displayImgObjects[index].FileType = this.File.Type;

                if (this.File.Type == '<%= (int)FileType.Video %>') {
                    displayImgObjects[index].Thumbnail = "/Content/Images/MovieThumb.gif";
                }
                else {
                    displayImgObjects[index].Thumbnail = parent.getUrlPrefix() + this.Thumbnail.Path;
                }

                displayImgObjects[index].Key = index;
                index++;
            });
        }

        function renderImages() {
            $("#divImgContainer").empty();
            var totalAmount = 0;
            $.each(displayImgObjects, function (key, img) {
                $("#imageList").tmpl(img).appendTo("#divImgContainer");
            });
            registerQtipForDiv();
        }

        
        function registerQtipForDiv() {
            $(".thumbnail-img").click(function () {
                $('div.img-displaydiv').empty();
                var imgSrc = $(this).parent().find("span input[type=hidden]").val();
                $('div.img-displaydiv').html("<img style='width:450px; height: 380px; padding-top:10px;' src='" + imgSrc + "' alt='' />");
            });

            $(".video-img").click(function () {
                $('div.img-displaydiv').empty();
                var imgSrc = $(this).parent().find("span input[type=hidden]").val();
                //debugger;
                var fileExtensionRegularExpression = /(?:\.([^.]+))?$/;
                if (fileExtensionRegularExpression.exec(imgSrc)[1] == "flv") {
                    $('div.img-displaydiv').html("<a href='" + imgSrc + "' style='display: block; width: 600px; height: 380px; margin: auto;' id='player'></a>");

                    flowplayer("player", "/Content/Flash/flowplayer-3.2.7.swf", {
                        clip: {
                            onBeforeFinish: function () {
                                return false;
                            }
                        }
                    });
                } else {
                    var videoHtml = "<video id='video_player_2' class='video-js vjs-default-skin' controls width='600' height='380' data-setup='{}'>";
                    videoHtml = videoHtml + "<source src="+ imgSrc + " type='video/mp4' />";
                    videoHtml = videoHtml + "</video>";
                    $('div.img-displaydiv').html(videoHtml);

                    VideoJS(document.getElementById('video_player_2'), { "controls": true, "loop": true, "preload": "auto" }, function () {
                        // Player (this) is initialized and ready.
                        this.play();
                    });
                }

            });

            $(".clear-img").click(function () {
                $('div.img-displaydiv').html("<img src='/App/Images/no-img-available.gif' style='width:350px;' />");
            });
        }

        function removeImage(key) {
            delete displayImgObjects[key];
            delete media[key];
            correctMedia();
            setImagestoDisplay();

            if (media == null || media.length < 1) $("#<%= JsonForImageObject.ClientID %>").val("");
            else
                $("#<%= JsonForImageObject.ClientID %>").val(JSON.stringify(media));

                <% switch (Test)
                   {
                        case TestType.AAA:%>
                        parent.LoadNewImagesAAA(media, false);
                        <%
                        break;
                        case TestType.AwvAAA:
                        %>
                        parent.LoadNewImagesAwvAaa(media, false);
                        <%
                        break;
                        case TestType.Stroke:
                        %>
                        parent.LoadNewImagesCarotid(media, false);
                        <%
                        break;
                        case TestType.AwvCarotid:
                        %>
                        parent.LoadNewImagesAwvCarotid(media, false);
                        <%
                        break;
                        case TestType.Lead:
                        %>
                        parent.LoadNewImagesLead(media, false);
                        <%
                        break;
                        case TestType.Echocardiogram:
                        %>
                        parent.LoadNewMediaEcho(media, false);
                        <%
                        break;
                        case TestType.AwvEcho:
                        %>
                        parent.LoadNewMediaAwvEcho(media, false);
                        <%
                        break;
                        case TestType.IMT:
                        %>
                        parent.LoadNewImagesImt(media, false);
                        <%
                        break;
                        case TestType.Thyroid:
                        %>
                        parent.LoadNewImagesThyroid(media, false);
                        <%
                        break;
                        case TestType.EKG:
                        %>
                        parent.LoadNewImagesEkg(media, false);
                        <%
                        break;
                        case TestType.PulmonaryFunction:
                        %>
                        parent.LoadNewImagesPulmonary(media, false);
                        <%
                        break;
                        case TestType.Spiro:
                        %>
                        parent.LoadNewImagesSpiro(media, false);
                        <%
                        break;
                        case TestType.AwvSpiro:
                        %>
                        parent.LoadNewImagesAwvSpiro(media, false);
                        <%
                        break;
                        case TestType.PPAAA:
                        %>
                        parent.LoadNewImagesPpAAA(media, false);
                        <%
                        break;
                        case TestType.PPEcho:
                        %>
                        parent.LoadNewMediaPpEcho(media, false);
                        <%
                        break;
                        case TestType.HCPAAA:
                        %>
                        parent.LoadNewImagesHcpAAA(media, false);
                        <%
                        break;
                        case TestType.HCPCarotid:
                        %>
                        parent.LoadNewImagesHcpCarotid(media, false);
                        <%
                        break;
                        case TestType.HCPEcho:
                        %>
                        parent.LoadNewMediaHcpEcho(media, false);
                        <%
                        break;
                         case TestType.QuantaFloABI:
                        %>
                        parent.LoadNewImagesQuantaFloABI(media, false);
                        <%
                        break;
                        case TestType.AwvEkg:
                        %>
                        parent.LoadNewImagesAwvEkg(media, false);
                        <%
                        break;
                        case TestType.AwvEkgIPPE:
                        %>
                        parent.LoadNewImagesAwvEkgIppe(media, false);
                        <%
                        break;
                }%>

            renderImages();
        }

        function correctMedia() {
            var a = media.pop();
            if (a != null)
                correctMedia();
            else
                return;

            media.push(a);
        }

        function setValues() {
            $("#<%= ImageLocationPrefix.ClientID %>").val(parent.getLocationPrefix());
            $("#<%= ImageUrlPrefix.ClientID %>").val(parent.getUrlPrefix());
        }

    </script>
    <script id="imageList" type="text/x-jquery-tmpl">
        <div class="media-block" style="width: 165px; float: left;">
            <div style='width:10px; float:left;'>${Key + 1}</div>
            <div style='width: 152px; float:left;'>
                <p style="width: 130px; text-align:center; float: left; padding: 5px 10px 5px 10px;">
                    <img src='${Thumbnail}' alt='Click to View' class=${FileType == '<%= (int)FileType.Image %>' ? 'thumbnail-img' : 'video-img'} style='cursor:pointer;' />
                    <span style='display:none;'> <input type='hidden' value='${File}' /> </span>
                </p>
                <p title='${FileName}'
                    style="width: 150px; float: left; overflow: hidden; text-overflow: ellipsis;
                    text-align: center;">
                    (${FileName})
                </p>
            </div>
            <p style="width: 150px; float: left; text-align: center">
                <a href="javascript:removeImage(${Key});"> remove </a>
            </p>
            
        </div>       
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; float: left; background-color: #fff;">
        <div id="imgdisplaydiv" class="img-displaydiv" style="clear: both; display: block;
            height: 430px; text-align: center; width: 95%; padding-left: 2%; padding-right: 2%;
            vertical-align: middle; padding-bottom: 10px; border-bottom: solid 1px grey;">
            <img src="/App/Images/no-img-available.gif" alt="" style="width: 350px; height: 300px;" />
        </div>
        <fieldset style="float: left; width: 30%;">
            <legend>
                <h4>
                    Media
                </h4>
            </legend>
            <div id="divImgContainer" style="overflow: auto; width: 98%; height: 170px;">
            </div>
        </fieldset>
        <fieldset style="float: left; width: 62%;">
            <legend>
                <h4>
                    Upload Media
                </h4>
            </legend>
            <div id="fileuploaddiv" class="divbottom_uti" style="width: 98%; height: 170px;">
                <div style="float: left;">
                    <asp:GridView runat="server" ID="gvUploadFiles" GridLines="none" AutoGenerateColumns="false"
                        CssClass="gvfileupload_uti" ShowHeader="false">
                        <Columns>
                            <asp:TemplateField ItemStyle-CssClass="gvfileuploaditem_uti">
                                <ItemTemplate>
                                    <asp:FileUpload ID="fluploadImage" runat="server" Size="45px" Width="150px" CssClass="file-upload" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="clear: both; float: right;">
                    <asp:Button ID="btnUpload" runat="server" OnClientClick="return UploadClick();" OnClick="btnUpload_Click"
                        Text="Upload" /></div>
            </div>
        </fieldset>
    </div>
    <!-- this will install flowplayer inside previous A- tag. -->
    <asp:HiddenField runat="server" ID="JsonForImageObject" Value="" />
    <asp:HiddenField runat="server" ID="ImageLocationPrefix" Value="" />
    <asp:HiddenField runat="server" ID="ImageUrlPrefix" Value="" />
    </form>
</body>
</html>
