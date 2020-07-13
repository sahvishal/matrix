using System;
using Falcon.App.Core.Application;
using Falcon.App.DependencyResolution;

namespace Falcon.App.UI.App.Common
{
    public partial class BarCodeFeeder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var textToBarcode = Request.QueryString["Text"];

            if (String.IsNullOrWhiteSpace(textToBarcode)) return;

            var barCodeGenerator =  IoC.Resolve<IBarCodeGenerator>();

            var byteArray = barCodeGenerator.GenerateCode128WithoutCheckSum(textToBarcode);
            
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=barcode.jpg");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.BinaryWrite(byteArray);
        }
    }
}