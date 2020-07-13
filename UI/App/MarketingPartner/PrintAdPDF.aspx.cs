using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using Falcon.DataAccess.Master;
using Falcon.Entity.Other;

public partial class App_MarketingPartner_PrintAdPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strFileName = Request.QueryString["FileName"];
        string strEventId = Request.QueryString["EventID"];
        string strSourceCode = Request.QueryString["SourceCode"];
        string serverName = ConfigurationManager.AppSettings["MMPAth"];
        string strContent = getContent(serverName + strFileName);
        ////////////TO UPDATE THE SMART TAGS
        strContent = strContent.Replace("[SourceCode]", strSourceCode);
        var masterDal = new MasterDAL();
        //EventService.EEvent[] objEvent = objEventService.GetEvent("235", "1");
        Int64 eventid;
        Int64.TryParse(strEventId, out eventid);
        List<EEvent> objEvent = masterDal.SearchFreeEventDetails(eventid, "", string.Empty, string.Empty, "", "", "", 0, 1);
        string strAddress = objEvent[0].Host.Address.Address1 + "<br />" + HttpUtility.HtmlEncode(objEvent[0].Host.Address.City) + "," + HttpUtility.HtmlEncode(objEvent[0].Host.Address.State) + " " + HttpUtility.HtmlEncode(objEvent[0].Host.Address.Zip);

        strContent = strContent.Replace("[EventVenue]", strAddress);
        strContent = strContent.Replace("[HostName]", HttpUtility.HtmlEncode(objEvent[0].Host.Name));
        strContent = strContent.Replace("[EventDate]", Convert.ToDateTime(objEvent[0].EventDate).ToString("MM/dd/yyyy"));
        //////////////

        dvPrintAd.InnerHtml = System.Web.Security.AntiXss.AntiXssEncoder.HtmlEncode(strContent, true);
    }
    private string getContent(string strPath)
    {
        HttpWebRequest wReq;
        HttpWebResponse wResp;
        Stream rStream;
        // Place the web request to the server by specifying the URL 
        wReq = (HttpWebRequest)WebRequest.Create(strPath);
        // No need for a persistant connection
        wReq.KeepAlive = false;
        // The link that referred us to the URL
        //////////wReq.Referer = txtReferrer.Text;
        // The user agent of the browser
        //////// wReq.UserAgent = txtUserAgent.Text;
        // Get the response from the server
        wResp = (HttpWebResponse)wReq.GetResponse();
        // Display the header of the response
        string strHeader = wResp.Headers.ToString();

        // Get a stream to read the body of the response
        rStream = wResp.GetResponseStream();
        // Needed for looping through the buffer
        int bufCount = 0;
        // Buffer in which we're going to store data coming from the server
        byte[] byteBuf = new byte[1024];
        // Loop as long as there's data in the buffer
        string strBody = string.Empty;
        do
        {
            // Fill the buffer with data
            bufCount = rStream.Read(byteBuf, 0, byteBuf.Length);

            if (bufCount != 0)
            {

                // Transform the bytes into ASCII text and append to the textbox
                strBody = strBody + Encoding.ASCII.GetString(byteBuf, 0, bufCount);
            }
        }
        while (bufCount > 0);

        return strBody;
    }
}
