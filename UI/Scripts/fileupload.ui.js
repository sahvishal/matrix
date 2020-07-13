function fu_createUploader(prefix, allowedExt) {
    //debugger;
    var uploader =
        new qq.FileUploader({
            element: document.getElementById(prefix + '-fileuploader'),
            action: '/FileManager/Uploader/Index',
            debug: true,
            allowedExtensions: allowedExt,
            params: {},
            multiple: false,
            onComplete: function (id, fileName, responseJSON) {
                //debugger;
                if (responseJSON.success) {
                    var parent = $("#" + prefix + "-filemodeldiv");
                    parent.find("[name*='FileName']").val(responseJSON.FileName);
                    parent.find("[name*='FolderPath']").val(responseJSON.FolderPath);
                    parent.find("[name*='Caption']").val(responseJSON.Caption);
                    parent.find("[name*='Url']").val(responseJSON.Url);
                    parent.find("[name*='FileSize']").val(responseJSON.FileSize);
                    parent.find("[name*='IsTemporaryLocated']").val(responseJSON.IsTemporaryLocated);
                    parent.find("[name*='FileType']").val(responseJSON.FileType);
                    parent.find("[name*='.MimeType']").val(responseJSON.MimeTypeId);
                    parent.find("[name*='.Id']").val(responseJSON.Id);
                    parent.find("[name*='.PhisicalPath']").val(responseJSON.PhisicalPath);
                    parent.find("[name*='.UploadedBy']").val(responseJSON.UploadedBy);
                    parent.parents(".image-container:first").find(".remove-input-div").show();
                    fu_loadView(parent.find(".file-display-div"), responseJSON, prefix, allowedExt);
                }
            }
        });
}

function fu_loadView(targetElement, data, prefix, allowedExt) {
    //debugger;
    $(targetElement).html("<img src='/Content/Images/ajax-loader.gif' alt='' />");

    $.ajax({
        url: '/FileManager/Uploader/FileView',
        type: 'POST',
        contentType: 'application/json; charset=utf-8',
        data: "{ model : " + JSON.stringify(data) + ",prefix : '" + prefix + "',allowedExt:'" + allowedExt + "' }",
        success: function (result) {
            $(targetElement).html(result);
        },
        error: function () {
            $(targetElement).html("<h4>Some error while loading up your request! </h4>");
        }
    });
}



function removeUploadedFile(caller, prefix, fileTypeExtention) {
    //debugger;
    var imageParent = caller.parents(".image-container:first");

    if (imageParent.length < 0) {
        return;
    }

    var confirmRes = confirm("Are you sure about removing the file? Click 'OK' to continue!");

    if (confirmRes == false) return;

    $.ajax({
        url: '/FileManager/Uploader/FileHolder?prefix=' + prefix + '&fileTypeExtention=' + fileTypeExtention,
        type: 'GET',
        success: function (data) {
            imageParent.replaceWith(data);
        }
    });
}