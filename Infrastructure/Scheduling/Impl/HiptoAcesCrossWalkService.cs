using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class HiptoAcesCrossWalkService : IHiptoAcesCrossWalkService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IHiptoAcesCrossWalkFactory _hiptoAcesCrossWalkFactory;
        private readonly ILogger _logger;
        private const int PageSize = 100;
        private readonly string _folderPath;
        private readonly string _clientLocationFolder;

        private IEnumerable<CorporateAccount> _corporateAccount;

        public HiptoAcesCrossWalkService(ICustomerRepository customerRepository, ICorporateAccountRepository corporateAccountRepository, IHiptoAcesCrossWalkFactory hiptoAcesCrossWalkFactory,
            ILogManager logManager, ISettings settings)
        {
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _hiptoAcesCrossWalkFactory = hiptoAcesCrossWalkFactory;
            _logger = logManager.GetLogger("HiptoAcesCrossWalk");

            _folderPath = settings.HiptoAcesCrossWalkReportFilePath;
            _clientLocationFolder = settings.ClientSftpPathForHipToAces;
        }


        public void GetHiptoAcesCrossWalkCustomerReport()
        {
            try
            {
                _corporateAccount = _corporateAccountRepository.GetAllCorporateAccountToSendPatientDataToAces();
                var sourcePath = Path.Combine(_folderPath, DateTime.Today.ToString("yyyyMMdd"));
                if (_corporateAccount.IsNullOrEmpty())
                {
                    _logger.Info("Account not found to send CrossWalk File.");
                    return;
                }

                var acesShortNames = _corporateAccount.Where(x => !string.IsNullOrWhiteSpace(x.AcesClientShortName)).Select(t => t.AcesClientShortName)
                    .Distinct();

                foreach (var acesClientShortName in acesShortNames)
                {
                    GetCustomersRecordAsPerShortName(acesClientShortName, sourcePath);
                }

                CopyFileToClientLocation(sourcePath);

            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }
        }

        private void CopyFileToClientLocation(string folderPath)
        {
            _logger.Info("Source Path CopyFileToClientLocation : " + folderPath);

            if (DirectoryOperationsHelper.IsDirectoryExist(_clientLocationFolder))
            {
                _logger.Info("Destination Location Exists: " + _clientLocationFolder);

                if (DirectoryOperationsHelper.IsDirectoryExist(folderPath))
                {
                    _logger.Info("Source Path Exists: " + folderPath);

                    var crossfilePath = DirectoryOperationsHelper.GetFiles(folderPath);
                    if (!crossfilePath.IsNullOrEmpty())
                    {
                        _logger.Info("Number of Crosswalk Found:" + crossfilePath);

                        foreach (var filePath in crossfilePath)
                        {
                            var fileName = Path.GetFileName(filePath);
                            if (string.IsNullOrWhiteSpace(fileName)) continue;

                            var destinationFileName = Path.Combine(_clientLocationFolder, fileName);
                            DirectoryOperationsHelper.Copy(filePath, destinationFileName);
                            _logger.Info("Source: " + filePath);
                            _logger.Info("Destination: " + destinationFileName);
                        }
                    }
                    else
                    {
                        _logger.Info("No Crosswalk Found");
                    }
                }
            }
            else
            {
                _logger.Info("Destination Path not exist : " + _clientLocationFolder);
            }
        }

        public void GetCustomersRecordAsPerShortName(string acesClientShortName, string folderPath)
        {
            try
            {
                var accountShortNamewise = _corporateAccount.Where(a => a.AcesClientShortName == acesClientShortName);

                var destinationFoler = folderPath;
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);
                _logger.Info("Directory Created: " + folderPath);

                var fileName = acesClientShortName + "_HipToAcesCrosswalk_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".txt";
                var destinationFile = Path.Combine(folderPath, fileName);

                DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);


                _logger.Info("starting for account AcesClientShortName " + acesClientShortName);

                foreach (var account in accountShortNamewise)
                {
                    if (string.IsNullOrWhiteSpace(account.Tag))
                    {
                        _logger.Info("Tag not available in this Account.");
                        continue;
                    }

                    _logger.Info("starting for account Tag " + account.Tag);

                    var pageNumber = 1;

                    var filter = new HiptoAcesCrossWalkViewModelFilter
                    {
                        Tag = account.Tag,
                        CustomerOnlyWithAcesId = true,
                        OnlyEligibileCustomer = true,
                        Year = DateTime.Today.Year
                    };

                    while (true)
                    {
                        int totalRecords = 0;

                        var customers = _customerRepository.GetCustomerForHiptoAcesCrossWalk(filter, pageNumber, PageSize, out totalRecords);
                        if (customers.IsNullOrEmpty())
                        {
                            _logger.Info("No customer found for Account Tag: " + account.Tag);
                            break;
                        }

                        var collection = new List<HiptoAcesCrossWalkViewModel>();

                        foreach (var customer in customers)
                        {
                            var model = _hiptoAcesCrossWalkFactory.Create(customer, account);
                            collection.Add(model);
                        }

                        if (!DirectoryOperationsHelper.IsFileExist(destinationFile))
                        {
                            WriteCsvHeader(destinationFile);
                        }

                        WriteCsv(collection, destinationFile);

                        _logger.Info((pageNumber * PageSize) + " out of " + totalRecords);

                        if ((pageNumber * PageSize) >= totalRecords)
                            break;

                        pageNumber++;
                    }
                }

                _logger.Info("File Generated Successfully at following Location: ");
                _logger.Info(destinationFile);
            }
            catch (Exception ex)
            {
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack Trace: " + ex.StackTrace);
            }

        }

        private void WriteCsvHeader(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var members = (typeof(HiptoAcesCrossWalkViewModel)).GetMembers();

                var header = new List<string>();

                foreach (var memberInfo in members)
                {
                    if (memberInfo.MemberType != MemberTypes.Property)
                        continue;

                    var propInfo = (memberInfo as PropertyInfo);

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

        private void WriteCsv(IEnumerable<HiptoAcesCrossWalkViewModel> collection, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(HiptoAcesCrossWalkViewModel)).GetMembers();

                foreach (var model in collection)
                {
                    var values = new List<string>();
                    foreach (var memberInfo in members)
                    {
                        if (memberInfo.MemberType != MemberTypes.Property)
                            continue;

                        var propInfo = (memberInfo as PropertyInfo);

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


    }
}
