using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Infrastructure.Application.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class CustomerConsentDataReportService : ICustomerConsentDataReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly ISettings _settings;
        private readonly ICustomSettingManager _customSettingManager;

        private readonly ILogger _logger;
        private const int PageSize = 100;

        public CustomerConsentDataReportService(ICustomerRepository customerRepository, ICorporateAccountRepository corporateAccountRepository,
            ILogManager logManager, ISettings settings, ICustomSettingManager customSettingManager)
        {
            _logger = logManager.GetLogger("CustomerConsentDataReport");
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _settings = settings;
            _customSettingManager = customSettingManager;
        }

        public void GetCustomerConsentDataReport()
        {
            try
            {
                var accounts = _corporateAccountRepository.GetAllCorporateAccountToSendConsentData();
                if (accounts.IsNullOrEmpty())
                {
                    _logger.Info("No Account marked to Send Consent Data to Matrix");
                    return;
                }

                foreach (var corporateAccount in accounts)
                {
                    try
                    {
                        _logger.Info("starting for Account " + corporateAccount.Tag);

                        var serviceReportSettings = string.Format(_settings.CustomerConsentDataReportSettingPath, corporateAccount.Tag);
                        var customSettings = _customSettingManager.Deserialize(serviceReportSettings);

                        var fromDate = customSettings.LastTransactionDate;

                        customSettings.LastTransactionDate = DateTime.Now;
                        _customSettingManager.SerializeandSave(serviceReportSettings, customSettings);

                        var filter = new CustomerConsentDataListModelFilter
                        {
                            AccountId = corporateAccount.Id,
                            Tag = corporateAccount.Tag,
                            FromDate = fromDate
                        };
                        var pageNumber = 1;
                        var destinationFoler = Path.Combine(_settings.CustomerConsentDataFilePath, corporateAccount.Tag);

                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);

                        var fileName = "CustomerConsentDataReport_" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                        var destinationFile = Path.Combine(destinationFoler, fileName);

                        DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);

                        WriteHeader(destinationFile);

                        var index = 1;
                        while (true)
                        {
                            int totalRecords = 0;
                            var customers = _customerRepository.GetCustomerConsentDataReport(filter, pageNumber, PageSize, out totalRecords);

                            if (customers != null)
                            {
                                foreach (var customer in customers)
                                {
                                    _logger.Info("CustomerId:" + customer.CustomerId);

                                    _logger.Info(index + " out of " + totalRecords);
                                    index++;

                                    var model = new CustomerConsentDataViewModel();
                                    model.AcesId = customer.AcesId;

                                    if (!string.IsNullOrEmpty(customer.HomePhoneNumber.ToString()) && (fromDate == null || (customer.PhoneHomeConsentUpdateDate.HasValue && customer.PhoneHomeConsentUpdateDate.Value >= fromDate)))
                                    {
                                        model.TelephoneNumber = customer.HomePhoneNumber.FormatPhoneNumber;
                                        model.ConsentType = ((PatientConsent)customer.PhoneHomeConsentId).GetDescription();
                                        model.ConsentDateTime = customer.PhoneHomeConsentUpdateDate;
                                        WriteData(model, destinationFile);
                                    }

                                    if (!string.IsNullOrEmpty(customer.MobilePhoneNumber.ToString()) && (fromDate == null || (customer.PhoneCellConsentUpdateDate.HasValue && customer.PhoneCellConsentUpdateDate.Value >= fromDate)))
                                    {
                                        model.TelephoneNumber = customer.MobilePhoneNumber.FormatPhoneNumber;
                                        model.ConsentType = ((PatientConsent)customer.PhoneCellConsentId).GetDescription();
                                        model.ConsentDateTime = customer.PhoneCellConsentUpdateDate;
                                        WriteData(model, destinationFile);
                                    }

                                    if (!string.IsNullOrEmpty(customer.OfficePhoneNumber.ToString()) && (fromDate == null || (customer.PhoneOfficeConsentUpdateDate.HasValue && customer.PhoneOfficeConsentUpdateDate.Value >= fromDate)))
                                    {
                                        model.TelephoneNumber = customer.OfficePhoneNumber.FormatPhoneNumber;
                                        model.ConsentType = ((PatientConsent)customer.PhoneOfficeConsentId).GetDescription();
                                        model.ConsentDateTime = customer.PhoneOfficeConsentUpdateDate;
                                        WriteData(model, destinationFile);
                                    }
                                }
                            }

                            if ((pageNumber * PageSize) >= totalRecords)
                                break;

                            pageNumber++;
                        }

                        if (_settings.CustomerConsentDataReportSendToSftp)
                        {
                            if (ExportReportOnMatrixSftp(fileName, destinationFile))
                                _logger.Info("File posted on client SFTP");
                            else
                                _logger.Info("File didn't posted,some error occurred.");
                        }

                        _logger.Info("completed for Account " + corporateAccount.Tag);

                    }
                    catch (Exception ex)
                    {
                        _logger.Error("some error occurred while creating customer consent data report for Account " + corporateAccount.Tag);
                        _logger.Error("Message: " + ex.Message);
                        _logger.Error("Stack Trace: " + ex.StackTrace);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void WriteHeader(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);

            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var members = (typeof(CustomerConsentDataViewModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
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

        private void WriteData(CustomerConsentDataViewModel model, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(CustomerConsentDataViewModel)).GetMembers();
                var values = new List<string>();
                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);
                    if (propInfo != null)
                    {
                        if (propInfo.PropertyType == typeof(FeedbackMessageModel) || propInfo.PropertyType == typeof(IEnumerable<OrderedPair<string, string>>))
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
                        values.Add(obj.ToString());

                }

                streamWriter.Write(string.Join(Delimiter, values.ToArray()) + Environment.NewLine);


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

        private bool ExportReportOnMatrixSftp(string fileName, string sourcePath)
        {
            var destinationPathOnSftp = _settings.CustomerConsentDataReportSftpPath;

            destinationPathOnSftp = destinationPathOnSftp.Replace("/", "\\");

            _logger.Info("Destination Path:  " + destinationPathOnSftp);
            _logger.Info("File Name:  " + fileName);
            _logger.Info("Source Path: " + sourcePath);

            var processFtp = new ProcessFtp(_logger, _settings.MatrixSftpHost, _settings.MatrixSftpUserName, _settings.MatrixSftpPassword);
            return processFtp.UploadSingleFile(sourcePath, destinationPathOnSftp, fileName);
        }
    }
}
