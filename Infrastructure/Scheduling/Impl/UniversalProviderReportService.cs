using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;
using System.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class UniversalProviderReportService : IUniversalProviderReportService
    {
        private readonly ISettings _settings;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ILogger _logger;
        private const int PageSize = 100;
        private readonly string _folderArchivedPath;

        public UniversalProviderReportService(ILogManager logManager, ISettings settings, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ICorporateAccountRepository corporateAccountRepository)
        {
            _settings = settings;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _logger = logManager.GetLogger("UniversalProviderReport");
            _folderArchivedPath = settings.UniversalProviderArchivedFilePath;
        }

        public void GetUniversalProviderReport()
        {
            try
            {
                var corporateAccounts = _corporateAccountRepository.GetAllCorporateAccountToSendPatientDataToAces();

                if (corporateAccounts.IsNullOrEmpty())
                {
                    _logger.Info("No corporate for Send Patient Data");
                    return;
                }

                var distinctClientIds = corporateAccounts.Where(x => !string.IsNullOrWhiteSpace(x.ClientId)).Select(t => t.ClientId).Distinct();

                foreach (var clientId in distinctClientIds)
                {
                    var accountBasedOnClientId = corporateAccounts.Where(a => a.ClientId == clientId);
                    GenerateReportForShortName(accountBasedOnClientId);
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void GenerateReportForShortName(IEnumerable<CorporateAccount> accounts)
        {
            var distinctAcesClientShortName = accounts.Where(x => !string.IsNullOrWhiteSpace(x.AcesClientShortName)).Select(t => t.AcesClientShortName)
              .Distinct();

            foreach (var acesClientShortName in distinctAcesClientShortName)
            {

                var accountShortNamewise = accounts.Where(d => d.AcesClientShortName == acesClientShortName);

                if (!accountShortNamewise.IsNullOrEmpty())
                {
                    _logger.Info("starting for Shortname " + acesClientShortName);
                    var destinationFoler = _settings.UniversalProviderFilePath;

                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(_folderArchivedPath);

                    var fileNameWithoutExtention = acesClientShortName + "_Universal_Provider";
                    var fileName = fileNameWithoutExtention + ".txt";

                    var destinationFile = Path.Combine(destinationFoler, fileName);

                    if (DirectoryOperationsHelper.IsFileExist(destinationFile))
                    {
                        var archiveFileName = fileNameWithoutExtention + "_" + DateTime.Today.AddDays(-1).ToString("ddMMyyyy") + ".txt";
                        var archiveFilePath = Path.Combine(_folderArchivedPath, archiveFileName);
                        DirectoryOperationsHelper.DeleteFileIfExist(archiveFilePath);
                        DirectoryOperationsHelper.Move(destinationFile, archiveFilePath);
                    }

                    WriteCsvHeader(destinationFile);

                    foreach (var account in accountShortNamewise)
                    {
                        try
                        {
                            _logger.Info("starting for account " + account.Tag);

                            GenerateUniversalProviderList(account, destinationFile);

                            _logger.Info("completed for Account " + account.Tag);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("some error occurred while created Member List for Account " + account.Tag);
                            _logger.Error("Message: " + exception.Message);
                            _logger.Error("Stack Trace: " + exception.StackTrace);
                        }
                    }

                    if (DirectoryOperationsHelper.IsFileExist(destinationFile))
                    {
                        _logger.Info("Universal Provider Report generated : " + destinationFile);

                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(_settings.UniversalProviderFileSftpPath);

                        _logger.Info("Deleting old files from SFTP.");
                        DirectoryOperationsHelper.DeleteFileIfExist(Path.Combine(_settings.UniversalProviderFileSftpPath, acesClientShortName + "_Universal_Provider.txt"));
                        _logger.Info("Old files deleted from SFTP.");

                        _logger.Info("Copying file to SFTP location : " + _settings.UniversalProviderFileSftpPath);
                        var sftpFilePath = Path.Combine(_settings.UniversalProviderFileSftpPath, fileName);
                        DirectoryOperationsHelper.Copy(destinationFile, sftpFilePath);
                        _logger.Info("File copied : " + sftpFilePath);
                    }
                }
            }


        }

        private void GenerateUniversalProviderList(CorporateAccount account, string destinationFile)
        {

            var pageNumber = 1;

            while (true)
            {
                var filter = new UniversalProviderListModelFilter
                {
                    Tag = account.Tag,
                    AccountId = account.Id
                };

                int totalRecords = 0;
                var primaryCarePhysicaianCollection = _primaryCarePhysicianRepository.GetPrimaryCarePhysicians(filter, pageNumber, PageSize, out totalRecords);

                if (!primaryCarePhysicaianCollection.IsNullOrEmpty())
                {
                    var collection = new List<UniversalProviderViewModel>();

                    foreach (var primaryCarePhysician in primaryCarePhysicaianCollection)
                    {
                        var model = GetProviderViewModel(primaryCarePhysician, account);

                        collection.Add(model);
                    }

                    WriteCsv(collection, destinationFile);

                    _logger.Info((pageNumber * PageSize) + " out of " + totalRecords + " completed");
                }

                if ((pageNumber * PageSize) >= totalRecords)
                    break;

                pageNumber++;
            }
        }

        private UniversalProviderViewModel GetProviderViewModel(PrimaryCarePhysician primaryCarePhysician, CorporateAccount account)
        {
            var model = new UniversalProviderViewModel
            {
                ClientID = account.ClientId,
                ClientProviderId = primaryCarePhysician.Id.ToString(),
                FirstName = primaryCarePhysician.Name != null ? ClearText(primaryCarePhysician.Name.FirstName) : string.Empty,
                MiddleName = primaryCarePhysician.Name != null ? ClearText(primaryCarePhysician.Name.MiddleName) : string.Empty,
                LastName = primaryCarePhysician.Name != null ? ClearText(primaryCarePhysician.Name.LastName) : string.Empty,
                Suffix = primaryCarePhysician.SuffixText,
                TaxonomyCode = string.Empty,
                Gender = string.Empty,
                Npi = string.Empty,
                TelephoneNumber1 = CleanPhone(primaryCarePhysician.Primary),
                FaxTelephoneNumber = CleanPhone(primaryCarePhysician.Fax),
                SecureFaxTelephoneNumber = string.Empty,
                EmailAddress = (primaryCarePhysician.Email != null ? primaryCarePhysician.Email.ToString() : string.Empty),
                WebSiteAddress = string.Empty
            };

            if (primaryCarePhysician.Address != null && !primaryCarePhysician.Address.IsEmpty())
            {
                model.Street1 = ClearText(primaryCarePhysician.Address.StreetAddressLine1);
                model.Street2 = ClearText(primaryCarePhysician.Address.StreetAddressLine2);
                model.City = primaryCarePhysician.Address.City;
                model.State = primaryCarePhysician.Address.StateCode;
                model.Zip = primaryCarePhysician.Address.ZipCode != null ? primaryCarePhysician.Address.ZipCode.Zip : string.Empty;
            }

            if (primaryCarePhysician.MailingAddress != null && !primaryCarePhysician.MailingAddress.IsEmpty())
            {
                model.Street1 = ClearText(primaryCarePhysician.MailingAddress.StreetAddressLine1);
                model.Street2 = ClearText(primaryCarePhysician.MailingAddress.StreetAddressLine2);
                model.City = primaryCarePhysician.MailingAddress.City;
                model.State = primaryCarePhysician.MailingAddress.StateCode;
                model.Zip = primaryCarePhysician.MailingAddress.ZipCode != null ? primaryCarePhysician.MailingAddress.ZipCode.Zip : string.Empty;
            }

            return model;
        }

        private string CleanPhone(PhoneNumber phoneNumber)
        {
            if (phoneNumber == null || phoneNumber.IsEmpty()) return string.Empty;

            var number = phoneNumber.ToString();

            if (!string.IsNullOrWhiteSpace(number))
            {
                var cleanPhone = number.Replace("(", "").Replace(")", "").Replace("-", "");
                cleanPhone = cleanPhone.Replace("_", "");
                cleanPhone = cleanPhone.Replace(" ", "");

                return cleanPhone;
            }

            return string.Empty;
        }

        private void WriteCsvHeader(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var members = (typeof(UniversalProviderViewModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                            continue;
                    }
                    else
                        continue;

                    var propertyName = memberInfo.Name;
                    var isHidden = false;

                    var attributes = propInfo.GetCustomAttributes(false);

                    if (!attributes.IsNullOrEmpty())
                    {
                        foreach (var attribute in attributes)
                        {
                            if (attribute is HiddenAttribute)
                            {
                                isHidden = true;
                                break;
                            }
                            if (attribute is DisplayNameAttribute)
                            {
                                propertyName = (attribute as DisplayNameAttribute).DisplayName;
                            }
                        }
                    }

                    if (isHidden) continue;

                    header.Add(propertyName);
                }

                streamWriter.Write(string.Join(Delimiter, header.ToArray()) + Environment.NewLine);
            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File header: " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private void WriteCsv(IEnumerable<UniversalProviderViewModel> collection, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(UniversalProviderViewModel)).GetMembers();

                foreach (var model in collection)
                {
                    var values = new List<string>();

                    foreach (var memberInfo in members)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);
                        if (propInfo != null)
                        {
                            if (propInfo.PropertyType == typeof(FeedbackMessageModel))
                                continue;
                        }
                        else
                            continue;

                        bool isHidden = false;
                        FormatAttribute formatter = null;

                        var attributes = propInfo.GetCustomAttributes(false);
                        if (!attributes.IsNullOrEmpty())
                        {
                            foreach (var attribute in attributes)
                            {
                                if (attribute is HiddenAttribute)
                                {
                                    isHidden = true;
                                    break;
                                }
                                if (attribute is FormatAttribute)
                                {
                                    formatter = (FormatAttribute)attribute;
                                }
                            }
                        }

                        if (isHidden) continue;
                        var obj = propInfo.GetValue(model, null);
                        if (obj == null)
                            values.Add(string.Empty);
                        else if (formatter != null)
                            values.Add(formatter.ToString(obj));
                        else
                            values.Add(obj.ToString());//EscapeString(obj.ToString())

                    }

                    streamWriter.Write(string.Join(Delimiter, values.ToArray()) + Environment.NewLine);
                }


            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File : " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }
            finally
            {
                streamWriter.Close();
                streamWriter.Dispose();
                fs.Close();
                fs.Dispose();
            }
        }

        private string Delimiter
        {
            get { return "|"; }
        }

        private void DeleteUnUsedFolder(string filePath, string fileName)
        {
            try
            {
                var enddate = DateTime.Today.AddDays(-7);
                var existingFiles = new List<string>();
                for (var date = DateTime.Today; enddate < date; date = date.AddDays(-1))
                {
                    string filename = fileName + date.ToString("yyyyMMdd") + ".txt";
                    existingFiles.Add(filename);
                }
                var files = DirectoryOperationsHelper.GetFiles(filePath, fileName + "*.txt");
                foreach (string file in files)
                {
                    if (existingFiles.Any(x => file.EndsWith(x)))
                    {
                        continue;
                    }
                    DirectoryOperationsHelper.DeleteFileIfExist(file);
                }

            }
            catch (Exception ex)
            {
                _logger.Error("While creating CSV File : " + ex.Message + "\n\t" + ex.StackTrace + "\n\n");
            }

        }

        private string ClearText(string textToBeClean)
        {
            if (string.IsNullOrWhiteSpace(textToBeClean)) return string.Empty;
            textToBeClean = textToBeClean.Trim();

            var cleanText = Regex.Replace(textToBeClean, @"[\n\r\t|]", ",");

            return cleanText;
        }
    }
}