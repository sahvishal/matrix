using System;
using System.Web.UI.WebControls;
using Falcon.App.Lib;

public partial class UCCommon_ucphotopanel : System.Web.UI.UserControl
{    
    /// <summary>
    /// 
    /// </summary>
    public string ImagePath
    {
        get { return imgImage.ImageUrl; }
        set {
            CommonCode objCCode = new CommonCode();
            imgImage.ImageUrl =objCCode.GetPicture(Request.MapPath(value),value);
        }
    }
    public string ImageCaption
    {
        get { return txtCaption.Text; }
        set { txtCaption.Text = value; }
    }

    public Unit ImageX
    {

        set { imgImage.Width = value; }
    }
    public Unit ImageY
    {

        set { imgImage.Height = value; }
    }
    //public string PanelCaption
    //{
    //    set { Panel1.GroupingText = value; }
    //}
    public string SaveImage(string strFileName)
    {
        string strreturnpath = string.Empty;
        if (FileUpload1.HasFile)
        {
            strreturnpath = strFileName + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName);
            FileUpload1.SaveAs(Server.MapPath("~\\App") + strreturnpath);
            return (strreturnpath);
        }
        else
        {
            return string.Empty;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void FileUpload1_DataBinding(object sender, EventArgs e)
    {

    }
}
