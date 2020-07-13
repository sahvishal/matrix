using System;
using System.Collections;
using System.Web;
using System.Web.Services;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Enum;
using System.IO;
using System.Configuration;

namespace HealthYes.Web.App.Common
{
    /// <summary>
    /// Summary description for $codebehindclassname$
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class BulkPDF : IHttpHandler
    {
        string CustomerResultsReportPDFSavePath = ConfigurationManager.AppSettings["CustomerResultsReportPDFSavePath"];
        string CustomerResultsReportPDFPath = ConfigurationManager.AppSettings["CustomerResultsReportPDFPath"];
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (CustomerResultsReportPDFSavePath != null && CustomerResultsReportPDFPath != null && context.Request.QueryString["EventID"] != null)
            {
                string pdftype = EPDFType.ClinicalForm.ToString();
                if (context.Request.QueryString["PDFType"] != null)
                {
                    pdftype = context.Request.QueryString["PDFType"].ToString();
                }

                //Get some file names
                string allresultfilepath = "";
                string allresultpdfurl = "";
                string[] files = GetFiles(context.Request.QueryString["EventID"], pdftype, out allresultfilepath, out allresultpdfurl);

                if (files.Length > 0)
                {
                    throw new NotImplementedException();

                    ////Open the output document
                    //Doc outputPdfDoc = new Doc();

                    //foreach (string file in files)
                    //{
                    //    //open input document
                    //    Doc inputPdfDoc = new Doc();
                    //    inputPdfDoc.Read(file);
                    //    outputPdfDoc.Append(inputPdfDoc);
                    //    inputPdfDoc.Clear();

                    //}
                    //outputPdfDoc.Save(allresultfilepath);

                    //outputPdfDoc.Clear();
                    //context.Response.Write(allresultpdfurl);
                }
                else
                {
                    context.Response.Write("No Results has been uploaded");
                    //ClientScript.RegisterStartupScript(typeof(string), "jscode_PrintBulkPDFError", "", true);
                }

            }
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private string[] GetFiles(string eventID, string pdftype, out string allresultfilepath, out string allresultpdfurl)
        {
            string extractingpdfpath = "";
            string extractingpdfurl = "";
            if (pdftype.Equals(EPDFType.ClinicalForm.ToString()))
            {
                extractingpdfpath = CustomerResultsReportPDFSavePath + eventID.ToString() + "\\" + ConfigurationManager.AppSettings["ClinicalFormFolderName"];
                extractingpdfurl = CustomerResultsReportPDFPath + eventID.ToString() + "/" + ConfigurationManager.AppSettings["ClinicalFormFolderName"];
            }
            else
            {
                extractingpdfpath = CustomerResultsReportPDFSavePath + eventID.ToString() + "\\" + ConfigurationManager.AppSettings["ResultPDFFolderName"];
                extractingpdfurl = CustomerResultsReportPDFPath + eventID.ToString() + "/" + ConfigurationManager.AppSettings["ResultPDFFolderName"];
            }


            if (File.Exists(extractingpdfpath + "\\AllResults_" + eventID + ".pdf"))
            {
                DirectoryOperationsHelper.Delete(extractingpdfpath + "\\AllResults_" + eventID + ".pdf");
            }

            allresultfilepath = extractingpdfpath + "\\AllResults_" + eventID + ".pdf";
            allresultpdfurl = extractingpdfurl + "/AllResults_" + eventID + ".pdf";

            ArrayList list = new ArrayList();
            DirectoryInfo dirInfo = new DirectoryInfo(extractingpdfpath);

            if (dirInfo.Exists)
            {
                FileInfo[] fileInfos = dirInfo.GetFiles("*.pdf");
                foreach (FileInfo info in fileInfos)
                {
                    if (info.Name.IndexOf("protected") == -1)
                        list.Add(info.FullName);
                }
            }
            return (string[])list.ToArray(typeof(string));
        }
    }
}
