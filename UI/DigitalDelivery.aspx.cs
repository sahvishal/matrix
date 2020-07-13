using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Net;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Deprecated.Enum;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.DependencyResolution;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.UI
{
    public partial class DigitalDelivery : Page
    {
        readonly string _domain = ConfigurationManager.AppSettings["DigitalDeliveryDomain"];
        readonly string _userName = ConfigurationManager.AppSettings["DigitalDeliveryUserName"];
        readonly string _password = ConfigurationManager.AppSettings["DigitalDeliveryPassword"];
        private readonly CryptographyService _cryptographyService = new DigitalDeliveryCryptographyService();

        protected void Page_Load(object sender, EventArgs e)
        {
            long eventId;
            string key;
            string fileType;
            string fileRequest;
            string[] keyAll;

            if (Request["Key"] != null && Convert.ToString(Request["Key"]) != "")
            {
                var currentSesion = IoC.Resolve<ISessionContext>().UserSession;
                if (currentSesion == null)
                {
                    ShowErrorMessage("Unauthorized Access, Please login into application to access any digital resource.");
                    return;
                }
                var currentUserContext = currentSesion.CurrentOrganizationRole;

                key = Request["Key"];
                key = key.Replace(" ", "+");
                string decryptedKey = _cryptographyService.Decrypt(key);

                if (key.Equals(decryptedKey))
                {
                    ShowErrorMessage("Unauthorized Access");
                    return;
                }

                fileType = EPDFType.ClinicalForm.ToString();
                keyAll = decryptedKey.Split('~');
                long customerId;
                if (keyAll.Length > 3)
                {
                    fileType = keyAll[0];
                    eventId = Convert.ToInt64(keyAll[1]);
                    customerId = Convert.ToInt64(keyAll[2]);
                    fileRequest = keyAll[3];
                }
                else
                {
                    ShowErrorMessage(decryptedKey);
                    return;
                }
                string fileName = string.Empty;
                var mediaRepository = IoC.Resolve<IMediaRepository>();
                if ((!string.IsNullOrEmpty(fileType)) && (fileType.Equals(EPDFType.ClinicalForm.ToString()) || fileType.Equals(EPDFType.ResultPdf.ToString()) || fileType.Equals(EPDFType.ResultPdfWithImages.ToString())
                    || fileType.Equals(EPDFType.ViewResult.ToString()) || fileType.Equals(EPDFType.All.ToString()) || fileType.Equals(EPDFType.PaperOnly.ToString()) || fileType.Equals(EPDFType.OnlineOnly.ToString())
                    || fileType.Equals(EPDFType.CdContent.ToString()) || fileType.Equals(EPDFType.PcpResultReport.ToString()) || fileType.Equals(EPDFType.AllPcpResultReportOnly.ToString()) ||
                    fileType.Equals(EPDFType.EAwvPreventionPlanReport.ToString()) || fileType.Equals(EPDFType.AllEawvPreventionPlanReportOnly.ToString()) || fileType.Equals(EPDFType.HealthPlanReport.ToString()) ||
                    fileType.Equals(EPDFType.AllHealthPlanReportOnly.ToString()) || fileType.Equals(EPDFType.IpResultPdf.ToString())))
                {
                    if ((!string.IsNullOrEmpty(fileRequest)) && (eventId > 0))
                    {
                        if (fileRequest.ToUpper().Equals("ALL") && (currentUserContext.GetSystemRoleId == (long)Roles.FranchisorAdmin || currentUserContext.GetSystemRoleId == (long)Roles.FranchiseeAdmin
                            || currentUserContext.GetSystemRoleId == (long)Roles.Technician))
                        {
                            string zipUrl = string.Empty;

                            if (fileType.Equals(EPDFType.All.ToString()))
                            {
                                fileName = mediaRepository.GetAllPremiumPdfName(eventId) + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId).Url + fileName;
                            }
                            else if (fileType.Equals(EPDFType.PaperOnly.ToString()))
                            {
                                fileName = mediaRepository.GetAllPremiumPdfPaperCopyOnly(eventId) + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId).Url + fileName;
                            }
                            else if (fileType.Equals(EPDFType.OnlineOnly.ToString()))
                            {
                                fileName = mediaRepository.GetAllPremiumPdfOnlineOnly(eventId) + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId).Url + fileName;
                            }
                            else if (fileType.Equals(EPDFType.AllPcpResultReportOnly.ToString()))
                            {
                                fileName = mediaRepository.GetAllPremiumPdfPcpOnly(eventId) + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId).Url + fileName;
                            }
                            else if (fileType.Equals(EPDFType.AllEawvPreventionPlanReportOnly.ToString()))
                            {
                                fileName = mediaRepository.GetAllPremiumPdfEawvReportOnly(eventId) + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId).Url + fileName;
                            }
                            else if (fileType.Equals(EPDFType.AllHealthPlanReportOnly.ToString()))
                            {
                                fileName = mediaRepository.GetAllPremiumPdfHealthPlanReportOnly(eventId) + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId).Url + fileName;
                            }
                            else if (fileType.Equals(EPDFType.CdContent.ToString()))
                            {
                                fileName = eventId + ".zip";
                                zipUrl = mediaRepository.GetResultPacketMediaLocation(eventId, false).Url + fileName;
                                //ResumableFile(zipUrl, fileName);
                                //DownloadZipFile(zipUrl, fileName);
                            }
                            WriteZipFile(zipUrl, fileName);
                        }
                        else if (fileRequest.ToUpper().Equals("SINGLE"))
                        {

                            if (currentUserContext.CheckRole((long)Roles.Customer) || currentUserContext.CheckRole((long)Roles.Technician) || currentUserContext.CheckRole((long)Roles.FranchiseeAdmin)
                                || currentUserContext.CheckRole((long)Roles.FranchisorAdmin) || currentUserContext.CheckRole((long)Roles.HospitalPartnerCoordinator)
                                || currentUserContext.CheckRole((long)Roles.HospitalFacilityCoordinator) || currentUserContext.CheckRole((long)Roles.NursePractitioner) || currentUserContext.CheckRole((long)Roles.CorporateAccountCoordinator))
                            {
                                string pdfUrl = string.Empty;

                                if (fileType.Equals(EPDFType.ClinicalForm.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForResultReport();
                                    pdfUrl = mediaRepository.GetClinicalFormResultPdfLocation(eventId, customerId).Url + fileName;
                                }
                                else if (fileType.Equals(EPDFType.ResultPdf.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForResultReport();
                                    pdfUrl = mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).Url + fileName;

                                }
                                else if (fileType.Equals(EPDFType.ResultPdfWithImages.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForResultReportWithImages();
                                    pdfUrl = mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).Url + fileName;

                                }
                                else if (fileType.Equals(EPDFType.ResultPdfPaperBack.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForResultReportPaperBack();
                                    pdfUrl = mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).Url + fileName;

                                }
                                else if (fileType.Equals(EPDFType.PcpResultReport.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForPcpResultReport();
                                    pdfUrl = mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).Url + fileName;

                                }
                                else if (fileType.Equals(EPDFType.EAwvPreventionPlanReport.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForEawvPreventionPlanReport();
                                    pdfUrl = mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).Url + fileName;

                                }
                                else if (fileType.Equals(EPDFType.HealthPlanReport.ToString()))
                                {
                                    fileName = mediaRepository.GetPdfFileNameForHealthPlanResultReport();
                                    pdfUrl = mediaRepository.GetPremiumVersionResultPdfLocation(eventId, customerId).Url + fileName;

                                }
                                else if (fileType.Equals(EPDFType.CdContent.ToString()))
                                {
                                    fileName = customerId + ".zip";
                                    pdfUrl = mediaRepository.GetCdContentFolderLocation(eventId).Url + fileName;
                                    WriteZipFile(pdfUrl, fileName);
                                }
                                else if (fileType.Equals(EPDFType.ViewResult.ToString()))
                                {
                                    var viewResultUrl = "/App/Common/Results.aspx?eventId=" + eventId + "&customerid=" + customerId;
                                    Server.Transfer(viewResultUrl);
                                    return;
                                }
                                else if (fileType.Equals(EPDFType.IpResultPdf.ToString()))
                                {
                                    var customer = IoC.Resolve<ICustomerRepository>().GetCustomer(customerId);
                                    var eventData = IoC.Resolve<Falcon.App.Core.Scheduling.Interfaces.IEventRepository>().GetById(eventId);
                                    fileName = mediaRepository.GetPdfFileNameForIpResultPdf(customer.CustomerId, customer.AcesId, customer.Name.FirstName, customer.Name.LastName, eventData.EventDate.Year);
                                    pdfUrl = mediaRepository.GetIpResultPdfLocation(eventId, customerId).Url + fileName;
                                }
                                if (currentUserContext.CheckRole((long)Roles.Customer))
                                    SaveDigitalAccessTrackingDetail(fileType.Replace("_", " "), pdfUrl);
                                WritePdfFile(pdfUrl, fileName);
                            }
                        }
                        else
                        {
                            ShowErrorMessage("Unauthorized Access");
                            return;
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Unauthorized Access");
                    return;
                }
            }
            else
            {
                ShowErrorMessage("Unauthorized Access");
                return;
            }
        }

        private void WritePdfFile(string url, string fileName)
        {
            try
            {
                //var client = new WebClient
                //                 {
                //                     Credentials =
                //                         new NetworkCredential(_userName, _password, _domain)
                //                 };
                var client = new WebClient();
                byte[] buffer = client.DownloadData(url);

                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                //Response.AddHeader("Content-Type", "application/pdf");
                Response.AddHeader("Content-Disposition", "inline; target=_blank; filename=" + HttpUtility.HtmlEncode(fileName));
                Response.BinaryWrite(buffer);

            }
            catch (Exception ex)
            {
                Response.Write("No PDF file found. Error: " + HttpUtility.HtmlEncode(ex.Message));
            }
            finally
            {
                //Response.Flush();
                Response.End();
            }
        }

        private void WriteZipFile(string url, string fileName)
        {
            try
            {
                //var client = new WebClient
                //                 {
                //                     Credentials =
                //                         new NetworkCredential(_userName, _password, _domain)
                //                 };
                var client = new WebClient();
                byte[] buffer = client.DownloadData(url);

                Response.Clear();
                Response.ClearHeaders();
                Response.ContentType = "application/zip";
                Response.AddHeader("content-disposition", "attachment; filename=" + HttpUtility.HtmlEncode(fileName));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(buffer);

            }
            catch (Exception ex)
            {
                Response.Write("No PDF file found. Error: " + ex.Message);
            }
            finally
            {
                //Response.Flush();
                Response.End();
            }
        }

        private void ShowErrorMessage(string errorMessage)
        {
            _spErrorMsg.InnerText = errorMessage;
            _divMessageMsg.Style.Add(HtmlTextWriterStyle.Display, "block");
            _divProgressBar.Style.Add(HtmlTextWriterStyle.Display, "none");

        }

        private void SaveDigitalAccessTrackingDetail(string type, string fileName)
        {
            var userSession = IoC.Resolve<ISessionContext>().UserSession;
            var organizationRoleUser = userSession.CurrentOrganizationRole.OrganizationRoleUserId;
            var loginLog = IoC.Resolve<IUserLoginLogRepository>().GetCurrentLoggedInLogforUser(userSession.UserId);

            if (loginLog != null)
            {
                IUniqueItemRepository<DigitalAssetAccessLog> uniqueItemRepository = new DigitalAssetAccessLogRepository();
                var digitalAssetAccessLog = new DigitalAssetAccessLog
                {
                    UserLoginLogId = loginLog.Id,
                    OrganizationRoleUserId = organizationRoleUser,
                    DigitalAssetType = type,
                    DigitalAsset = fileName,
                    AccessedOn = DateTime.Now
                };
                uniqueItemRepository.Save(digitalAssetAccessLog);
            }
        }

    }
}