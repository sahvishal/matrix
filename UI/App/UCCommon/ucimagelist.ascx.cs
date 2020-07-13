using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Falcon.App.Lib;

public partial class ucimagelist : System.Web.UI.UserControl
{
    private List<string> strOtherImages;

    public List<string> Images
    {
        set { strOtherImages = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable tblimages = new DataTable();

            //tblimages.Columns.Add("ImageID");
            tblimages.Columns.Add("Image");

            //tblimages.Rows.Add(new object[] { "1", "../Images/myphoto1.jpg" });
            //tblimages.Rows.Add(new object[] { "2", "../Images/myphoto2.jpg" });
            //tblimages.Rows.Add(new object[] { "3", "../Images/myphoto3.jpg" });
            //tblimages.Rows.Add(new object[] { "4", "../Images/myphoto4.jpg" });
            //tblimages.Rows.Add(new object[] { "5", "../Images/myphoto5.jpg" });
            //tblimages.Rows.Add(new object[] { "6", "../Images/myphoto6.jpg" });
            //tblimages.Rows.Add(new object[] { "7", "../Images/myphoto2.jpg" });
            //tblimages.Rows.Add(new object[] { "8", "../Images/myphoto4.jpg" });

            //lstotherphotos.DataSource = tblimages;
            //lstotherphotos.DataBind();
            if (strOtherImages != null)
            {
                CommonCode objCCode = new CommonCode();
                foreach (string str in strOtherImages)
                {
                    if ((str!=null) && (str!=string.Empty))
                    {
                        
                      string  strPath = objCCode.GetPicture(Request.MapPath(str),str);
                      tblimages.Rows.Add(new object[] { ResolveUrl(strPath) });
                    }
                }

                ViewState["tblimages"] = tblimages;
                AttachDataSource(tblimages);
            }
        }
        Panel1.Style.Add(HtmlTextWriterStyle.Display, "none");

    }

    private void AttachDataSource(DataTable tblimages)
    {
        PagedDataSource pdsimages = new PagedDataSource();
        pdsimages.AllowPaging = true;
        pdsimages.PageSize = 6;
        pdsimages.CurrentPageIndex = 0;
        pdsimages.DataSource = tblimages.DefaultView;
        ViewState["CurrentPageIndex"] = 0;

        if (pdsimages.PageCount == 1)
            lnknext.Enabled = false;

        lstotherphotos.DataSource = pdsimages;
        lstotherphotos.DataBind();
    }

    protected void lnknavigation_Click(object sender, EventArgs e)
    {
        if (!IsPostBack)
            return;
        LinkButton btntemp = (LinkButton)sender;
        PagedDataSource pdsimages = new PagedDataSource();
        pdsimages.AllowPaging = true;
        pdsimages.PageSize = 6;
        int currentpage = Convert.ToInt32(ViewState["CurrentPageIndex"]);
        int pagecount;
        
        if (btntemp != null)
        {
            
            DataTable tblimages = (DataTable)ViewState["tblimages"];
            pagecount = Convert.ToInt32(Math.Ceiling((Double)tblimages.Rows.Count / 6.00));

            if (btntemp.CommandName == "Navigation")
            {
                if (pagecount <= 1)
                {
                    lnkprevious.Enabled = false;
                    lnknext.Enabled = false;
                }
                else
                {
                    lnkprevious.Enabled = true;
                    lnknext.Enabled = true;
                }
            }

            if (btntemp.CommandArgument == "P")
            {
                if (currentpage == 0)
                    return;
                if (currentpage == 1)
                    lnkprevious.Enabled = false;

                pdsimages.CurrentPageIndex = currentpage - 1;
                ViewState["CurrentPageIndex"] = currentpage - 1;
            }
            else
            {
                if (currentpage == pagecount - 1)
                    return;
                if (currentpage == pagecount - 2)
                    lnknext.Enabled = false;

                pdsimages.CurrentPageIndex = currentpage + 1;
                ViewState["CurrentPageIndex"] = currentpage + 1;
            }
            pdsimages.DataSource = tblimages.DefaultView;
            //pagecount = pdsimages.PageCount;

            lstotherphotos.DataSource = pdsimages;
            lstotherphotos.DataBind();

        }

    }

    protected void imgClick_Click(object sender, EventArgs e)
    {
        LinkButton templink = (LinkButton)sender;
        DataListItem item = (DataListItem)templink.NamingContainer;

        HtmlImage tempimage = (HtmlImage)item.FindControl("image1");
        //tempimage.Width = Convert.ToInt16(Panel1.Width.Value - 20);
        //tempimage.Height = Convert.ToInt16(Panel1.Height.Value - 20);

        Panel1.Style.Add(HtmlTextWriterStyle.Display, "block");
        imgLargeImage.Src = tempimage.Src;
        //Panel1.Controls.Add(new LiteralControl("<img src='" + tempimage.Src + "' style='width:470px; height:250px; float:left;'/>"));
        //Panel1..BackImageUrl = tempimage.Src;
        ModalPopupExtender.Show();
        ModalPopupExtender1.Show();
        /* code for assigning image url to the image ctrl in panel */

    }
}
