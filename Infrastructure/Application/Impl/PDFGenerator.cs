using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Enum;
using Falcon.App.Core.Application.ViewModels;
using StackExchange.Redis;
using WebSupergoo.ABCpdf10;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class PdfGenerator : IPdfGenerator
    {
        private string _sourcePath;
        private string _destinationPath;

        public WkHtmltoPdfSwitches Switches { get; set; }
        public bool AllowLoadingJavascriptbeforePdfGenerate { get; set; }
        public string PaperSize { get; set; }

        private string _fileName;
        private readonly ISettings _settings;

        const int WaitForSeconds = 30;
        //private ConnectionMultiplexer _redis;
        //private ConnectionMultiplexer ConnectionMultiplexer
        //{
        //    get
        //    {
        //        if (_redis == null || !_redis.IsConnected)
        //        {
        //            var settings = new Settings();
        //            var config = ConfigurationOptions.Parse(settings.RedisServerHost);
        //            config.KeepAlive = WaitForSeconds;
        //            config.ConnectTimeout = 5000;
        //            _redis = ConnectionMultiplexer.Connect(config);
        //        }
        //        return _redis;
        //    }
        //}

        public PdfGenerator(WkHtmltoPdfSwitches defaultSwitches)
        {
            Switches = defaultSwitches;
            AllowLoadingJavascriptbeforePdfGenerate = false;
            PaperSize = "Letter";
            _settings = new Settings();
        }

        public PdfGenerator()
        {
            Switches = new WkHtmltoPdfSwitches();
            PaperSize = "Letter";
            _settings = new Settings();
        }

        public void SetDefaultSwitch(WkHtmltoPdfSwitches defaultSwitches)
        {
            Switches = defaultSwitches;
        }

        public string Generate(string sourcePath, string destinationPath, string pdfConverterPath = "", string fileName = "")
        {
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(_fileName) ? Guid.NewGuid() + ".pdf" : fileName + ".pdf";

            var outputpath = _destinationPath + _fileName;

            var url = new Uri(_sourcePath, UriKind.Absolute);
            if (url.Scheme != Uri.UriSchemeHttp && url.Scheme != Uri.UriSchemeHttps)
                return null;
            /*
            if (_sourcePath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (outputpath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (_destinationPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;
            if (pdfConverterPath.IndexOfAny(Path.GetInvalidPathChars()) != -1)
                return null;

            _process = new Process();

            var startInfo = new ProcessStartInfo
                            {
                                FileName = string.IsNullOrWhiteSpace(pdfConverterPath) ? @"wkhtmltopdf.exe" : pdfConverterPath + @"/wkhtmltopdf.exe",
                                Arguments = Switches + " \"" + _sourcePath + "\" " + outputpath,
                                UseShellExecute = false, // needs to be false in order to redirect output
                                RedirectStandardOutput = true,
                                RedirectStandardError = true,
                                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                                WorkingDirectory = _destinationPath
                            };
            _process.StartInfo = startInfo;
            _process.Start();

            // read the output here...
            var output = _process.StandardOutput.ReadToEnd();
            //var error = _process.StandardError.ReadToEnd();

            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();
            */
            var fName = string.IsNullOrWhiteSpace(pdfConverterPath) ? @"wkhtmltopdf.exe" : pdfConverterPath + @"/wkhtmltopdf.exe";
            var args = Switches + " \"" + _sourcePath + "\" " + outputpath;
            var pub = new GeneratePdfRequest { FileName = fName, Arguments = args, DestinationPath = _destinationPath };

            var success = GetUrlPdfResponse(pub);

            // if 0, it worked
            return (success) ? _fileName : null;

        }

        private bool GetUrlPdfResponse(GeneratePdfRequest pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();
            var elapsedSeconds = 0;
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.GeneratePdfRequestQueue, serialisedObject);
            sub.Publish(RequestSubcriberChannelNames.GeneratePdfRequestChannel, "");

            var value = string.Empty;
            while (string.IsNullOrEmpty(value))
            {
                elapsedSeconds++;
                value = db.StringGet(pub.Guid);
                if (!string.IsNullOrEmpty(value))
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return value == "Completed";
                }

                Thread.Sleep(1000);
                if (elapsedSeconds == WaitForSeconds)
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return false;
                }
            }
            return true;
        }

        public string Generate(StringBuilder htmlStream, string destinationPath, string pdfConverterPath = "", string fileName = "")
        {

            _destinationPath = destinationPath;
            _fileName = string.IsNullOrWhiteSpace(fileName) ? Guid.NewGuid() + ".pdf" : fileName + ".pdf";

            /*
            _process = new Process();
            var startInfo = new ProcessStartInfo
            {
                FileName = string.IsNullOrWhiteSpace(pdfConverterPath) ? @"wkhtmltopdf.exe" : pdfConverterPath + @"\wkhtmltopdf.exe",
                Arguments = Switches + " " + "-" + " " + _destinationPath + _fileName,
                UseShellExecute = false, // needs to be false in order to redirect output
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true, // redirect all 3, as it should be all 3 or none
                WorkingDirectory = destinationPath
            };


            _process.StartInfo = startInfo;
            _process.Start();

            var streamWriter = _process.StandardInput;
            streamWriter.Write(htmlStream.ToString());
            streamWriter.Close();

            // read the output here...
            string output = _process.StandardOutput.ReadToEnd();

            // ...then wait n milliseconds for exit (as after exit, it can't read the output)
            _process.WaitForExit(30000);

            int returnCode = _process.ExitCode;

            _process.Close();
             * 
             * */
            var fName = string.IsNullOrWhiteSpace(pdfConverterPath) ? @"wkhtmltopdf.exe" : pdfConverterPath + @"\wkhtmltopdf.exe";
            var args = Switches + " " + "-" + " " + _destinationPath + _fileName;
            var pub = new HtmlStreamPdfRequest { FileName = fName, Arguments = args, DestinationPath = _destinationPath, HtmlStream = htmlStream.ToString() };

            var success = GetHtmlStreamPdfResponse(pub);
            // if 0, it worked
            return (success) ? _fileName : null;
        }

        private bool GetHtmlStreamPdfResponse(HtmlStreamPdfRequest pub)
        {
            IDatabase db = RedisConnection.ConnectionMultiplexer.GetDatabase(_settings.RedisDatabaseKey);
            ISubscriber sub = RedisConnection.ConnectionMultiplexer.GetSubscriber();
            var elapsedSeconds = 0;
            var serialisedObject = Newtonsoft.Json.JsonConvert.SerializeObject(pub);
            db.ListLeftPush(RequestSubcriberChannelNames.HtmlStreamPdfRequestQueue, serialisedObject);
            sub.Publish(RequestSubcriberChannelNames.HtmlStreamPdfRequestChannel, "");

            var value = string.Empty;
            while (string.IsNullOrEmpty(value))
            {
                elapsedSeconds++;
                value = db.StringGet(pub.Guid);
                if (!string.IsNullOrEmpty(value))
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return value == "Completed";
                }

                Thread.Sleep(1000);
                if (elapsedSeconds == WaitForSeconds)
                {
                    db.KeyDelete(pub.Guid, CommandFlags.FireAndForget);
                    return false;
                }
            }
            return true;
        }

        public void GeneratePdf(string pageurl, string fileSavePath, bool showFooterText = false, string footerText = "", string coverSheetPages = "", string customizedLetter = "", string contentpages = "", string kynFile = "", string bloodLetter = "",
            string doctorLetter = "", string corporateFluffLetter = "", bool isPpCustomer = false, string awvTestResult = "", bool isPcpReport = false, bool generatePcpLetter = false, string scannedDocumentsPdf = "", string eawvPdfReport = "",
            string focAttestation = "", string attestationForm = "", bool hasSectionToDisplay = true, string mammogram = "", string ifobt = "", string urineMicroalbumin = "", string participantLetter = "", string chlamydia = "",
            string awvBoneMass = "", string osteoporosis = "", string quantaFloAbi = "", string hkyn = "", string mybioCheckAssessment = "", string memberLetter = "", string greenFormAttestation = "", string dpn = "")
        {
            var finalReport = new Doc();

            int prePrintedCount = 0;

            var beforFinalReportDoc = new Doc();

            try
            {
                if (coverSheetPages != "")
                {
                    var participantLetterDoc = new Doc();
                    var doctorLetterDoc = new Doc();
                    var customizedLetterDoc = new Doc();
                    var contentpagesDoc = new Doc();
                    var eawvPdfDoc = new Doc();

                    var memberLetterDoc = new Doc();
                    var greenFormAttestationDoc = new Doc();
                    try
                    {
                        //Cover Sheet
                        beforFinalReportDoc.Read(coverSheetPages);

                        if (!string.IsNullOrWhiteSpace(greenFormAttestation))
                        {
                            greenFormAttestationDoc.Read(greenFormAttestation);
                            beforFinalReportDoc.Append(greenFormAttestationDoc);
                        }

                        //Member Letter 
                        if (!string.IsNullOrEmpty(memberLetter))
                        {
                            memberLetterDoc.Read(memberLetter);
                            beforFinalReportDoc.Append(memberLetterDoc);
                        }

                        if (!string.IsNullOrEmpty(participantLetter))
                        {
                            participantLetterDoc.Read(participantLetter);
                            beforFinalReportDoc.Append(participantLetterDoc);
                        }

                        //Doctor letter
                        if (!string.IsNullOrEmpty(doctorLetter))
                        {
                            doctorLetterDoc.Read(doctorLetter);
                            beforFinalReportDoc.Append(doctorLetterDoc);
                        }
                        //Customized Letter Hospital Partner no default letter
                        if (!string.IsNullOrEmpty(customizedLetter))
                        {
                            customizedLetterDoc.Read(customizedLetter);
                            beforFinalReportDoc.Append(customizedLetterDoc);
                        }

                        if (!string.IsNullOrEmpty(contentpages))
                        {
                            contentpagesDoc.Read(contentpages);
                            beforFinalReportDoc.Append(contentpagesDoc);
                        }

                        if (!string.IsNullOrEmpty(eawvPdfReport))
                        {
                            eawvPdfDoc.Read(eawvPdfReport);
                            beforFinalReportDoc.Append(eawvPdfDoc);
                        }

                        prePrintedCount = beforFinalReportDoc.PageCount;

                    }
                    catch (Exception exception)
                    {

                        throw exception;
                    }
                    finally
                    {

                        participantLetterDoc.Clear();
                        participantLetterDoc.Dispose();

                        doctorLetterDoc.Clear();
                        doctorLetterDoc.Dispose();

                        customizedLetterDoc.Clear();
                        customizedLetterDoc.Dispose();

                        contentpagesDoc.Clear();
                        contentpagesDoc.Dispose();

                        eawvPdfDoc.Clear();
                        eawvPdfDoc.Dispose();

                        memberLetterDoc.Clear();
                        memberLetterDoc.Dispose();

                        greenFormAttestationDoc.Clear();
                        greenFormAttestationDoc.Dispose();
                    }
                }

                if (hasSectionToDisplay)
                {
                    finalReport.Rect.Inset(40, 70);
                    //pdfDoc.Rect.
                    finalReport.MediaBox.String = PaperSize;
                    finalReport.Rect.String = finalReport.MediaBox.String;
                    finalReport.Page = finalReport.AddPage();
                    finalReport.HtmlOptions.PageCachePurge();
                    finalReport.HtmlOptions.Timeout = 90000;


                    if (AllowLoadingJavascriptbeforePdfGenerate)
                        finalReport.HtmlOptions.UseScript = true;

                    int imageToChain = finalReport.AddImageUrl(pageurl, true, 950, true);

                    while (true)
                    {
                        if (!finalReport.Chainable(imageToChain))
                            break;
                        finalReport.Page = finalReport.AddPage();
                        imageToChain = finalReport.AddImageToChain(imageToChain);
                    }

                    footerText = string.IsNullOrEmpty(footerText) ? string.Empty : footerText + " | ";
                    int pageCount = finalReport.PageCount + prePrintedCount;
                    for (int pageNumber = 1; pageNumber <= finalReport.PageCount; pageNumber++)
                    {

                        finalReport.PageNumber = pageNumber;
                        if (showFooterText)
                        {
                            int pNum = pageNumber + prePrintedCount;

                            string txt = footerText + "Page: " + pNum + " of " + pageCount;

                            finalReport.Color.String = "0 0 0"; //Dark grey text

                            finalReport.TextStyle.VPos = 0.98;
                            finalReport.TextStyle.HPos = (pageNumber % 2) == 0 ? 0.10 : 0.80;

                            finalReport.AddFont("Arial");
                            //Add the page number
                            finalReport.AddText(txt);


                            //Add a line above page number
                            finalReport.AddLine(21, 40, 590, 40);
                        }

                        //Flatten page
                        finalReport.Flatten();
                    }
                }



                if (!string.IsNullOrEmpty(kynFile))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(kynFile);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                AppendPdf(finalReport, hkyn);

                if (!string.IsNullOrEmpty(bloodLetter))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(bloodLetter);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                if (!string.IsNullOrEmpty(corporateFluffLetter))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(corporateFluffLetter);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                if (!string.IsNullOrEmpty(awvTestResult))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(awvTestResult);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                if (!string.IsNullOrEmpty(scannedDocumentsPdf))
                {
                    var inputScannedPdfDoc = new Doc();
                    try
                    {
                        inputScannedPdfDoc.Read(scannedDocumentsPdf);
                        finalReport.Append(inputScannedPdfDoc);
                    }
                    finally
                    {
                        inputScannedPdfDoc.Clear();
                        inputScannedPdfDoc.Dispose();
                    }
                }

                AppendPdf(finalReport, focAttestation);
                AppendPdf(finalReport, attestationForm);
                AppendPdf(finalReport, mammogram);
                AppendPdf(finalReport, ifobt);
                AppendPdf(finalReport, urineMicroalbumin);
                AppendPdf(finalReport, chlamydia);
                AppendPdf(finalReport, awvBoneMass);
                AppendPdf(finalReport, osteoporosis);
                AppendPdf(finalReport, quantaFloAbi);
                AppendPdf(finalReport, mybioCheckAssessment);
                AppendPdf(finalReport, dpn);

                if (coverSheetPages != "")
                {
                    try
                    {
                        beforFinalReportDoc.Append(finalReport);
                        beforFinalReportDoc.Save(fileSavePath);
                    }
                    catch (Exception exception)
                    {

                        throw exception;
                    }

                }
                else
                {
                    finalReport.Save(fileSavePath);
                }

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                finalReport.Clear();
                finalReport.Dispose();

                beforFinalReportDoc.Clear();
                beforFinalReportDoc.Dispose();
            }
        }

        private static void AppendPdf(Doc finalReport, string sourceDocPath)
        {
            if (!string.IsNullOrEmpty(sourceDocPath))
            {
                var sourceDocPdfDoc = new Doc();
                try
                {
                    sourceDocPdfDoc.Read(sourceDocPath);
                    finalReport.Append(sourceDocPdfDoc);
                }
                finally
                {
                    sourceDocPdfDoc.Clear();
                    sourceDocPdfDoc.Dispose();
                }
            }
        }

        public void GeneratePdfForHaf(string pageurl, string fileSavePath, string corporateSurveyPdf = "", string basicBiometricFile = "", string focAttestationFile = "", string corporateCheckListPdf = "", string annualComprehensiveExamPdf = "",
            string memberInformationProfilePdf = "")
        {
            var finalReport = new Doc();

            try
            {
                finalReport.Rect.Inset(40, 70);
                //pdfDoc.Rect.
                finalReport.MediaBox.String = PaperSize;
                finalReport.Rect.String = finalReport.MediaBox.String;
                finalReport.Page = finalReport.AddPage();
                finalReport.HtmlOptions.PageCachePurge();
                finalReport.HtmlOptions.Timeout = 90000;

                if (AllowLoadingJavascriptbeforePdfGenerate)
                    finalReport.HtmlOptions.UseScript = true;

                int imageToChain = finalReport.AddImageUrl(pageurl, true, 950, true);

                while (true)
                {
                    if (!finalReport.Chainable(imageToChain))
                        break;
                    finalReport.Page = finalReport.AddPage();
                    imageToChain = finalReport.AddImageToChain(imageToChain);
                }

                for (int pageNumber = 1; pageNumber <= finalReport.PageCount; pageNumber++)
                {

                    finalReport.PageNumber = pageNumber;
                    //Flatten page
                    finalReport.Flatten();
                }

                if (!string.IsNullOrEmpty(basicBiometricFile))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(basicBiometricFile);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                if (!string.IsNullOrEmpty(corporateSurveyPdf))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(corporateSurveyPdf);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                if (!string.IsNullOrEmpty(focAttestationFile))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(focAttestationFile);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }
                if (!string.IsNullOrEmpty(corporateCheckListPdf))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(corporateCheckListPdf);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }
                if (!string.IsNullOrEmpty(annualComprehensiveExamPdf))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(annualComprehensiveExamPdf);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }
                if (!string.IsNullOrEmpty(memberInformationProfilePdf))
                {
                    var inputPdfDoc = new Doc();
                    try
                    {
                        inputPdfDoc.Read(memberInformationProfilePdf);
                        finalReport.Append(inputPdfDoc);
                    }
                    finally
                    {
                        inputPdfDoc.Clear();
                        inputPdfDoc.Dispose();
                    }
                }

                finalReport.Save(fileSavePath);

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                finalReport.Clear();
                finalReport.Dispose();
            }
        }

        public void GetPdffilesfromLocationandMergeintoOne(string sourcePath, string destinationFileName)
        {
            var files = Directory.GetFiles(sourcePath, "*.pdf");
            Merge(destinationFileName, files);
        }


        public void Merge(string parentFile, IEnumerable<string> filesToMerge)
        {
            var outputPdfDoc = new Doc();
            if (File.Exists(parentFile))
            {
                outputPdfDoc.Read(parentFile);
            }

            try
            {
                foreach (string file in filesToMerge)
                {
                    var inputPdfDoc = new Doc();
                    inputPdfDoc.Read(file);
                    outputPdfDoc.Append(inputPdfDoc);
                    inputPdfDoc.Clear();
                    inputPdfDoc.Dispose();
                }

                outputPdfDoc.Save(parentFile);
            }
            finally
            {
                outputPdfDoc.Clear();
                outputPdfDoc.Dispose();
            }
        }

        public void ExtractPdfPages(string sourcePath, string destinationPath, int startPageNumber, int endPageNumber)
        {
            var sourceDoc = new Doc();
            sourceDoc.Read(sourcePath);
            var sourceCount = sourceDoc.PageCount;

            if (endPageNumber > sourceCount)
            {
                throw new IndexOutOfRangeException(string.Format("Unable to extract pages from {0}.\nNumber of pages in source document less than end page number.", sourcePath));
            }

            var destinationDoc = new Doc();
            destinationDoc.MediaBox.String = sourceDoc.MediaBox.String;
            destinationDoc.Rect.String = destinationDoc.MediaBox.String;
            destinationDoc.Rect.Magnify(0.5, 0.5);
            destinationDoc.Rect.Inset(10, 10);

            for (int i = startPageNumber; i <= endPageNumber; i++)
            {
                destinationDoc.Page = destinationDoc.AddPage();
                destinationDoc.AddImageDoc(sourceDoc, i, null);
                destinationDoc.FrameRect();
            }
            destinationDoc.Save(destinationPath);
        }

        public string ExtractPdfPagesFromEnd(string sourcePath, string destinationPath, int numberOfPages)
        {
            var sourceDoc = new Doc();
            sourceDoc.Read(sourcePath);
            var sourceCount = sourceDoc.PageCount;

            if (numberOfPages > sourceCount)
            {
                throw new IndexOutOfRangeException(string.Format("Unable to extract pages from {0}.\nNumber of pages in source document less than required number of pages : {1}.", sourcePath, numberOfPages));
            }

            var destinationDoc = new Doc();
            destinationDoc.MediaBox.String = sourceDoc.MediaBox.String;
            destinationDoc.Rect.String = destinationDoc.MediaBox.String;

            for (var i = sourceCount - numberOfPages + 1; i <= sourceCount; i++)
            {
                destinationDoc.Page = destinationDoc.AddPage();
                destinationDoc.AddImageDoc(sourceDoc, i, null);
                destinationDoc.FrameRect();
            }

            destinationDoc.Save(destinationPath);
            return destinationPath;
        }

        public void GenerateHtml(string body, string destinationPath, string pageUrl, string destinationPdfPath)
        {
            DirectoryOperationsHelper.DeleteFileIfExist(destinationPath);
            var cssPath = _settings.AppUrl + "/Config/Content/ResultPacket/content/FinalPdf.css";
            using (FileStream fs = new FileStream(destinationPath, FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine("<html>");
                    w.WriteLine("<head>");
                    w.WriteLine("<link rel='Stylesheet' type='text/css' href='" + cssPath + "'>");
                    w.WriteLine("</head>");
                    w.WriteLine("<body>");
                    w.WriteLine("<div class='mainContainer-wopb'>");
                    w.WriteLine("<div style='margin-left:60px'>");
                    w.WriteLine("<div style='width: 810px; padding: 20px; height: 960px; margin: 0px auto; font-size: 12px;'>");
                    w.WriteLine(body);
                    w.WriteLine("</div>");
                    w.WriteLine("</div>");
                    w.WriteLine("</div>");
                    w.WriteLine("</body>");
                    w.WriteLine("</html>");
                }
            }
            if (DirectoryOperationsHelper.IsFileExist(destinationPath))
            {
                DirectoryOperationsHelper.DeleteFileIfExist(destinationPdfPath);
                GeneratePdf(pageUrl, destinationPdfPath);
            }
        }

    }
}
