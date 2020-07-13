using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Core.Application;
using Falcon.App.Lib;
using Falcon.App.Core.Interfaces;
using Falcon.App.DependencyResolution;

public partial class UCCommon_ucupdatephotopanel : System.Web.UI.UserControl
{
    #region "Variables & Properties"
    protected Int32 IMAGE_LIST_COUNT = ImageCount();
    private List<string> strOtherImages;
       
    /// <summary>
    /// List of image paths to be assigned to datalist 
    /// </summary>
    public List<string> Images
    {
        get { return strOtherImages; }
        set { strOtherImages = value; }
    }
    /// <summary>
    /// Team Photo Url Property
    /// </summary>
    public string TeamImage
    {
        get { return imgteamphoto.Src; }
        set {
            CommonCode objCode = new CommonCode();
            imgteamphoto.Src = objCode.GetPicture(Request.MapPath(value), value);
           
        }
    }
    /// <summary>
    /// User Photo Url Property
    /// </summary>
    public string MyImage
    {
        get { return imgmyphoto.Src; }
        set {
            CommonCode objCode = new CommonCode();
            imgmyphoto.Src =objCode.GetPicture(Request.MapPath(value),value);
        }
    }
    /// <summary>
    /// Team Photo Container Visible Property
    /// </summary>
    public bool TeamImageVisible
    {
        get { return divTeamPhoto.Visible; }
        set 
        {
            divTeamPhoto.Visible = value;
            if (value == false)
            {
                ddlphototype.Items.RemoveAt(2);

            }
            
        }
    }
    /// <summary>
    /// User Photo Container Visible Property
    /// </summary>
    public bool MyImageVisible
    {
        get { return divMyPhoto.Visible; }
        set 
        { 
            divMyPhoto.Visible = value;
            if (value == false)
            {
                ddlphototype.Items.RemoveAt(1);
               // ddlphototype.Items[1].Visible = false;
            }
            else
            {
               // ddlphototype.Items[1].Visible = true;
            }
        }
    }
    /// <summary>
    /// Data List Container visible property.
    /// </summary>
    public bool ListOtherPhotoVisible
    {
        get { return divOtherImages.Visible; }
        set 
        { 
            divOtherImages.Visible = value;
            if (value == false)
            {
                ddlphototype.Items.RemoveAt(3); //ddlphototype.Items[3].Visible = false;
            }
            else
            {
               // ddlphototype.Items[3].Visible = true;
            }
        }
    }
    /// <summary>
    /// Photo Type Visible Property.
    /// </summary>
    public bool PhotoTypeVisible
    {
        get
        {
            return divPhotoType.Visible;
        }
        set
        {
            divPhotoType.Visible = value;
            if (value == false)
            {
                ddlphototype.SelectedValue = "1";
            }
        }
    }
    /// <summary>
    /// MyPhoto Header visible property
    /// </summary>
    public bool MyPhotoHeaderVisible
    {
        get
        {
            return divMyPhotoHeader.Visible;
        }
        set
        {
            divMyPhotoHeader.Visible = value;
        }
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            ISettings settings = IoC.Resolve<ISettings>();
            hfimagecount.Value = settings.MaximumPictureCount.ToString();

            DataTable tblimages = new DataTable();
            tblimages.Columns.Add("Image");

            if (strOtherImages != null)
            {
                CommonCode objCCode = new CommonCode();
                foreach (string str in strOtherImages)
                {
                    if (str != null && str != string.Empty)
                    {
                        string strPath = objCCode.GetPicture(Request.MapPath(str), str);
                        tblimages.Rows.Add(new object[] { ResolveUrl(strPath) });
                    }
                }
            }
            ViewState["tblimages"] = tblimages;
            dlotherimages.DataSource = tblimages;
            dlotherimages.DataBind();
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");
        //Panel2.Style.Add(HtmlTextWriterStyle.Display, "none");
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkdelete_Click(object sender, EventArgs e)
    {
        DataListItem itemcontainer = (DataListItem)((LinkButton)sender).NamingContainer;
        DataTable tblimages = (DataTable)ViewState["tblimages"];

        tblimages.Rows[itemcontainer.ItemIndex].Delete();
        ViewState["tblimages"] = tblimages;
        dlotherimages.DataSource = tblimages;
        dlotherimages.DataBind();
        
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        string filename = "";
        switch (Convert.ToInt32(ddlphototype.SelectedItem.Value))
        {
            case 1:
                filename = "MyPhoto" + DateTime.Now.ToFileTimeUtc().ToString();
                imgmyphoto.Src = SetImageinFolder(hfuploadval.Value, filename);
                break;

            case 2:
                filename = "TeamPhoto" + DateTime.Now.ToFileTimeUtc().ToString();
                imgteamphoto.Src = SetImageinFolder(hfuploadval.Value, filename);
                break;

            case 3:
                if (dlotherimages.Items.Count >= IMAGE_LIST_COUNT)
                    return;

                DataTable tblimages = (DataTable)ViewState["tblimages"];

                filename = "OP" +  "_" + DateTime.Now.ToFileTimeUtc().ToString();
                string imgsavepath = SetImageinFolder(hfuploadval.Value, filename);
                
                bool rowadded = false;

                if (rowadded == false)
                {
                    tblimages.Rows.Add(new object[] { imgsavepath });
                }
                ViewState["tblimages"] = tblimages;
                dlotherimages.DataSource = tblimages;
                dlotherimages.DataBind();

                break;
        }

    }


    private static Int32 ImageCount()
    {
        ISettings settings = IoC.Resolve<ISettings>();
        return settings.MaximumPictureCount;
    }

    protected void imgClick_Click(object sender, EventArgs e)
    {
        LinkButton templink = (LinkButton)sender;
        DataListItem item = (DataListItem)templink.NamingContainer;

        HtmlImage tempimage = (HtmlImage)item.FindControl("imgotherphoto");
        //tempimage.Width = Convert.ToInt16(Panel1.Width.Value - 20);
        //tempimage.Height = Convert.ToInt16(Panel1.Height.Value - 20);

        
        imgLargeImage.Src = tempimage.Src;
        //Panel1.Controls.Add(new LiteralControl("<img src='" + tempimage.Src + "' style='width:470px; height:250px; float:left;'/>"));
        //Panel1..BackImageUrl = tempimage.Src;
        ModalPopupExtender.Show();
        //ModalPopupExtender1.Show();

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");
        //Panel2.Style.Add(HtmlTextWriterStyle.Display, "block");
        /* code for assigning image url to the image ctrl in panel */

    }

    /// <summary>
    /// 
    /// </summary>
    public void GetAllImages()
    {
        
        //if (divMyPhoto.Visible == true)
        //{
            
        //    imgmyphoto.Src = SetImageinFolder(imgmyphoto.Src, filename);
        //}

        //if (divTeamPhoto.Visible == true)
        //{
            
        //    imgteamphoto.Src = SetImageinFolder(imgteamphoto.Src, filename);
        //}

        if (divOtherImages.Visible == true)
        {
            List<string> listimages = new List<string>();
            int listimagecount = 0;

            for (int icount = 0; icount < dlotherimages.Items.Count; icount++)
            {
                HtmlImage imgotherphoto_list = (HtmlImage)dlotherimages.Items[icount].FindControl("imgotherphoto");
                if (imgotherphoto_list != null)
                {
                    
                    //listimages[listimagecount] = imgotherphoto_list.Src;
                    listimages.Add(imgotherphoto_list.Src);
                    listimagecount++;
                }
            }

            while (listimagecount < 12)
            {
                //listimages[listimagecount] = "";
                listimages.Add("");
                listimagecount++;
            }
            strOtherImages = listimages;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="strcurfilepath"></param>
    /// <param name="newfilename"></param>
    /// <returns></returns>
    private string SetImageinFolder(string strcurfilepath, string newfilename)
    {
        string IMAGE_PATH = Request.MapPath(ConfigurationManager.AppSettings["ImageFolder"].ToString());
        string SAVE_PATH = ConfigurationManager.AppSettings["ImageFolder"].ToString();

        if (!Directory.Exists(IMAGE_PATH))
            Directory.CreateDirectory(IMAGE_PATH);
        string strcurphysicalpath = "";

        try
        {
            strcurphysicalpath = Request.MapPath(strcurfilepath);
        }
        catch (Exception)
        {
            strcurphysicalpath = strcurfilepath;
        }

        FileInfo info = new FileInfo(strcurphysicalpath);
        if (info.DirectoryName != IMAGE_PATH || !File.Exists(info.FullName))
        {
            string newfile = IMAGE_PATH + "\\" + newfilename + Path.GetExtension(info.FullName);
            string pathstring = SAVE_PATH + "/" + newfilename + Path.GetExtension(info.FullName);
            imguploader.SaveAs(newfile);
            //File.Copy(strcurphysicalpath, newfile); 
            //File.Create(newfile);
            return pathstring;
        }
        return strcurfilepath;
    }

    //private void DeleteAll

    
    #region "Commented Code"
    //tblimages.Rows.Add(new object[] { "1", "../Images/myphoto1.jpg" });
    //tblimages.Rows.Add(new object[] { "2", "../Images/myphoto2.jpg" });
    //tblimages.Rows.Add(new object[] { "3", "../Images/myphoto3.jpg" });
    //tblimages.Rows.Add(new object[] { "4", "../Images/myphoto4.jpg" });
    //tblimages.Rows.Add(new object[] { "5", "../Images/myphoto5.jpg" });
    //tblimages.Rows.Add(new object[] { "6", "../Images/myphoto6.jpg" });
    //tblimages.Rows.Add(new object[] { "7", "../Images/myphoto2.jpg" });
    //tblimages.Rows.Add(new object[] { "8", "../Images/myphoto4.jpg" });
    #endregion


    protected void lnkteamphoto_Click(object sender, EventArgs e)
    {
        imgLargeImage.Src = imgteamphoto.Src;
        
        ModalPopupExtender.Show();
        //ModalPopupExtender1.Show();

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");
        //Panel2.Style.Add(HtmlTextWriterStyle.Display, "block");
    }
    protected void lnkmyphoto_Click(object sender, EventArgs e)
    {
        imgLargeImage.Src = imgmyphoto.Src;
        
        ModalPopupExtender.Show();
        //ModalPopupExtender1.Show();

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");
        //Panel2.Style.Add(HtmlTextWriterStyle.Display, "block");
    }
}
