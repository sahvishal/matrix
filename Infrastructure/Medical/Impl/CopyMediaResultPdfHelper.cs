using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using HtmlAgilityPack;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using File = System.IO.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CopyMediaResultPdfHelper : ICopyMediaResultPdfHelper
    {
        private const string RadioUnchecked = @"content/radio-unchecked.png";
        private const string RadioChecked = @"content/radio-checked.png";
        private const string CheckboxUnchecked = @"content/checkbox-unchecked.png";
        private const string CheckboxChecked = @"content/checkbox-checked.png";
        private const string AutoRunShell = "ShellRun.exe";
        private const string AutoRuninf = "AUTORUN.INF";
        private const string StringforContentDirectory = "content";
        private const string StringforMediaDirectory = "media";

        private readonly IMediaRepository _mediaRepository;
        private readonly ISettings _settings;

        public CopyMediaResultPdfHelper(IMediaRepository mediaRepository, ISettings settings)
        {
            _mediaRepository = mediaRepository;
            _settings = settings;
        }

        public void CopyOverMedia(long eventId, long customerId, string saveFilePath, IEnumerable<ResultMedia> resultMedia)
        {
            if (resultMedia == null || resultMedia.Count() < 1) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!DirectoryOperationsHelper.IsDirectoryExist(supportDestDirectoryPath))
                DirectoryOperationsHelper.CreateDirectory(supportDestDirectoryPath);

            var mediaPath = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath;
            foreach (var media in resultMedia)
            {
                if (media.File.Type == FileType.Image)
                {
                    DirectoryOperationsHelper.DeleteFileIfExist(supportDestDirectoryPath + "\\" + media.File.Path);
                    System.IO.File.Copy(mediaPath + media.File.Path, supportDestDirectoryPath + "\\" + media.File.Path);
                }
            }
        }

        public void CopyOverAwvEkgGraph(long eventId, long customerId, string saveFilePath, AwvEkgTestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!DirectoryOperationsHelper.IsDirectoryExist(supportDestDirectoryPath))
                DirectoryOperationsHelper.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;

            using (Image img = Image.FromFile(input))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void SetMediaForTestResult(IEnumerable<ResultMedia> testMedia, string sectionName, string testName, HtmlDocument doc)
        {
            string html = "";
            int counter = 0;
            foreach (var media in testMedia)
            {
                if (media.File.Type != FileType.Image) continue;

                if (counter % 6 == 0)
                {
                    html += (counter == 0 ? "" : "</tr></table>") + "<table class='result-images-container'> ";
                }

                if (counter == 0)
                {
                    html += "<tr><td class='page-title' style='padding-bottom:15px;' colspan='2'> " + testName + " Media </td></tr>";
                }

                if (counter % 2 == 0)
                {
                    html += (counter % 6 == 0) ? "<tr>" : "</tr><tr>";
                }

                html += "<td><img style='width:430px; height: 335px;' src='" + StringforMediaDirectory + "/" + media.File.Path + "' alt='' /> </td>";

                counter++;
            }

            if (counter > 0)
            {
                html += counter % 2 == 0 ? "</tr></table>" : "<td></td></tr></table>";
                var selectedMode = doc.DocumentNode.SelectSingleNode("//div[@id='" + sectionName + "']");
                if (selectedMode != null)
                {
                    selectedMode.SetAttributeValue("style", "display:block;");
                    selectedMode.InnerHtml = html;
                }
            }
        }

        public void SetSingleMediaForTestResult(ResultMedia media, string sectionName, string testName, HtmlDocument doc)
        {
            string html = "";

            if (media.File.Type != FileType.Image) return;

            html += "<table class='result-images-container'><tr><td class='page-title' style='text-align: center; padding-bottom:15px;'> " + testName + " Media </td></tr>";
            html += "<tr><td style='text-align: center;'><img style='height: 850px;' src='" + StringforMediaDirectory + "/" + media.File.Path + "' alt='' /> </td>";
            html += "</tr></table>";

            var selectedMode = doc.DocumentNode.SelectSingleNode("//div[@id='" + sectionName + "']");
            if (selectedMode != null)
            {
                selectedMode.SetAttributeValue("style", "display:block;");
                selectedMode.InnerHtml = html;
            }
        }

        public void UpdateHTMLWithImages(HtmlDocument doc)
        {
            UpdateCheckboxImage(doc);
            UpdateRadioImage(doc);
        }

        private void UpdateRadioImage(HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("//input[@type='radio']");
            if (nodes == null) return;

            foreach (var node in nodes)
            {
                var imgTag = @"<img style='padding-left:2px;padding-right:2px;'/>";

                var imgNode = HtmlNode.CreateNode(imgTag);

                imgNode.SetAttributeValue("src", RadioUnchecked);

                var attribute = node.Attributes["checked"];

                if (attribute != null && attribute.Value.ToLower() == "checked")
                {
                    imgNode.SetAttributeValue("src", RadioChecked);
                }



                node.ParentNode.ReplaceChild(imgNode, node);
            }
        }

        private void UpdateCheckboxImage(HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("//input[@type='checkbox']");
            if (nodes == null) return;

            foreach (var node in nodes)
            {
                var imgTag = @"<img style='padding-left:2px;padding-right:2px;'/>";

                var imgNode = HtmlNode.CreateNode(imgTag);

                imgNode.SetAttributeValue("src", CheckboxUnchecked);

                var attribute = node.Attributes["checked"];

                if (attribute != null && attribute.Value.ToLower() == "checked")
                {
                    imgNode.SetAttributeValue("src", CheckboxChecked);
                }



                node.ParentNode.ReplaceChild(imgNode, node);
            }
        }

        public void CopyOverSupportDirectorytotheDestination(string saveFilePath, string sourceFilePath, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians, bool moveSupportMediaFolder = false, bool copySupportMediaOtherThanPhysician = true)
        {
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);
            var sourceDirectory = Path.GetDirectoryName(sourceFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforContentDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            if (copySupportMediaOtherThanPhysician)
            {
                foreach (var filePath in Directory.GetFiles(sourceDirectory + @"\" + StringforContentDirectory))
                {
                    var fileName = Path.GetFileName(filePath);
                    if (fileName == AutoRunShell || fileName == AutoRuninf)
                    {
                        DirectoryOperationsHelper.DeleteFileIfExist(destinationDirectory + @"\" + Path.GetFileName(filePath));
                        File.Copy(filePath, destinationDirectory + @"\" + Path.GetFileName(filePath));
                    }
                    else
                    {
                        DirectoryOperationsHelper.DeleteFileIfExist(supportDestDirectoryPath + @"\" + Path.GetFileName(filePath));
                        File.Copy(filePath, supportDestDirectoryPath + @"\" + Path.GetFileName(filePath));
                    }
                }
            }

            if (moveSupportMediaFolder)
            {

                var supportmediaDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
                if (!Directory.Exists(supportmediaDestDirectoryPath))
                    Directory.CreateDirectory(supportmediaDestDirectoryPath);

                foreach (var filePath in Directory.GetFiles(sourceDirectory + @"\" + StringforMediaDirectory))
                {
                    File.Copy(filePath, supportmediaDestDirectoryPath + @"\" + Path.GetFileName(filePath));
                }

            }

            CopyOverRequiredFiletosupportDirectory(supportDestDirectoryPath, physicians);
        }

        private void CopyOverRequiredFiletosupportDirectory(string destinationDirectory, IEnumerable<CustomerScreeningEvaluatinPhysicianViewModel> physicians)
        {
            var mediumLogo = destinationDirectory + @"\" + Path.GetFileName(_settings.MediumLogoLocation);
            var smallLogo = destinationDirectory + @"\" + Path.GetFileName(_settings.SmallLogoLocation);
            var largeLogo = destinationDirectory + @"\" + Path.GetFileName(_settings.LargeLogoLocation);

            if (!File.Exists(mediumLogo))
            {
                File.Copy(_settings.MediumLogoLocation, mediumLogo);
            }
            if (!File.Exists(smallLogo))
            {
                File.Copy(_settings.SmallLogoLocation, smallLogo);
            }

            if (!File.Exists(largeLogo))
            {
                File.Copy(_settings.LargeLogoLocation, largeLogo);
            }

            if (physicians != null)
            {
                foreach (var physician in physicians)
                {
                    var physicianSignFilePath = _mediaRepository.GetPhysicianSignatureMediaFileLocation().PhysicalPath + physician.PhysicianSignatureFilePath;

                    if (!File.Exists(physicianSignFilePath)) continue;

                    if (File.Exists(destinationDirectory + @"\" + physician.PhysicianSignatureFilePath)) continue;

                    File.Copy(physicianSignFilePath, destinationDirectory + @"\" + physician.PhysicianSignatureFilePath);
                }
            }
        }

        public void CopyOverEkgGraph(long eventId, long customerId, string saveFilePath, EKGTestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;
            using (Image img = Image.FromFile(input))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void CopyOverAwvEkgIppeGraph(long eventId, long customerId, string saveFilePath, AwvEkgIppeTestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;
            using (Image img = Image.FromFile(input))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void CopyOverSpiroGraph(long eventId, long customerId, string saveFilePath, SpiroTestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;
            using (Image img = Image.FromFile(input))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                //img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void CopyOverAwvSpiroGraph(long eventId, long customerId, string saveFilePath, AwvSpiroTestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;
            using (Image img = Image.FromFile(input))
            {
                //rotate the picture by 90 degrees and re-save the picture as a Jpeg
                //img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void CopyOverFloChecAbiPdf(long eventId, long customerId, string saveFilePath, FloChecABITestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;
            using (Image img = Image.FromFile(input))
            {
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public void CopyOverQuantaFloABIPdf(long eventId, long customerId, string saveFilePath, QuantaFloABITestResult testResult)
        {
            if (testResult == null || testResult.ResultImage == null) return;
            var destinationDirectory = Path.GetDirectoryName(saveFilePath);

            var supportDestDirectoryPath = destinationDirectory + @"\" + StringforMediaDirectory;
            if (!Directory.Exists(supportDestDirectoryPath))
                Directory.CreateDirectory(supportDestDirectoryPath);

            string input = _mediaRepository.GetResultMediaFileLocation(customerId, eventId).PhysicalPath +
                           testResult.ResultImage.File.Path;
            using (Image img = Image.FromFile(input))
            {
                img.Save(supportDestDirectoryPath + "\\" + testResult.ResultImage.File.Path, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }
    }
}
