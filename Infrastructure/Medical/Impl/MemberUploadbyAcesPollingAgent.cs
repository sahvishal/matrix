using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Communication;
using Falcon.App.Core.Communication.Enum;
using Falcon.App.Core.Communication.Interfaces;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class MemberUploadbyAcesPollingAgent : IMemberUploadbyAcesPollingAgent
    {
        private readonly ICorporateUploadService _corporateUploadService;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly IAccountAdditionalFieldRepository _accountAdditionalFieldRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILabRepository _labRepository;
        private readonly ICorporateUploadHelper _corporateUploadHelper;
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger _logger;
        private readonly ICustomerRepository _customerRepository;
        private readonly IPatientWithNoCustomTagFactory _patientWithNoCustomTagFactory;
        private readonly IEmailNotificationModelsFactory _emailNotificationModelsFactory;
        private readonly INotifier _notifier;
        private readonly IMemberUploadbyAcesFailedCustomerFactory _memberUploadbyAcesFailedCustomerFactory;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IMemberUploadLogRepository _memberUploadLogRepository;
        private readonly IMemberTermByAbsencePublisher _memberTermByAbsencePublisher;
        private readonly IMemberUploadByAcesHelper _memberUploadByAcesHelper;
        private readonly IMemberUploadParseDetailRepository _memberUploadParseDetailRepository;
        private readonly IMemberUploadParseDetailFactory _memberUploadParseDetailFactory;
        private readonly ICustomerWithDuplicateAcesIdFileGenerator _customerWithDuplicateAcesIdFileGenerator;
        private readonly ICorporateUploadRepository _corporateUploadRepository;

        private readonly string _memberUploadbyAcesSourceFolderPath;

        private readonly bool _stopMemberUploadbyAces;

        private const long OrgRoleId = 1;
        private const long OrgRoleUserId = 1;

        public const int PageSize = 100;

        public MemberUploadbyAcesPollingAgent(ICorporateUploadService corporateUploadService, ICorporateAccountRepository corporateAccountRepository,
            ISettings settings, ILogManager logManager, IPipeDelimitedReportHelper pipeDelimitedReportHelper, IAccountAdditionalFieldRepository accountAdditionalFieldRepository,
            ILanguageRepository languageRepository, ILabRepository labRepository, ICorporateUploadHelper corporateUploadHelper,
            IMediaRepository mediaRepository, ICustomerRepository customerRepository, IPatientWithNoCustomTagFactory patientWithNoCustomTagFactory,
            IEmailNotificationModelsFactory emailNotificationModelsFactory, INotifier notifier, IMemberUploadbyAcesFailedCustomerFactory memberUploadbyAcesFailedCustomerFactory,
            IPreApprovedPackageRepository preApprovedPackageRepository, IPreApprovedTestRepository preApprovedTestRepository,
            IMemberUploadLogRepository memberUploadLogRepository, IMemberTermByAbsencePublisher memberTermByAbsencePublisher, IMemberUploadByAcesHelper memberUploadByAcesHelper,
            IMemberUploadParseDetailRepository memberUploadParseDetailRepository, IMemberUploadParseDetailFactory memberUploadParseDetailFactory,
            ICustomerWithDuplicateAcesIdFileGenerator customerWithDuplicateAcesIdFileGenerator, ICorporateUploadRepository corporateUploadRepository)
        {
            _corporateUploadService = corporateUploadService;
            _corporateAccountRepository = corporateAccountRepository;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _accountAdditionalFieldRepository = accountAdditionalFieldRepository;
            _languageRepository = languageRepository;
            _labRepository = labRepository;
            _corporateUploadHelper = corporateUploadHelper;
            _mediaRepository = mediaRepository;
            _customerRepository = customerRepository;
            _patientWithNoCustomTagFactory = patientWithNoCustomTagFactory;

            _memberUploadbyAcesSourceFolderPath = settings.MemberUploadbyAcesSourceFolderPath;

            _emailNotificationModelsFactory = emailNotificationModelsFactory;
            _notifier = notifier;

            _memberUploadbyAcesFailedCustomerFactory = memberUploadbyAcesFailedCustomerFactory;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _memberUploadLogRepository = memberUploadLogRepository;
            _memberTermByAbsencePublisher = memberTermByAbsencePublisher;
            _memberUploadByAcesHelper = memberUploadByAcesHelper;
            _memberUploadParseDetailRepository = memberUploadParseDetailRepository;
            _memberUploadParseDetailFactory = memberUploadParseDetailFactory;
            _stopMemberUploadbyAces = settings.StopMemberUploadbyAces;
            _customerWithDuplicateAcesIdFileGenerator = customerWithDuplicateAcesIdFileGenerator;

            _corporateUploadRepository = corporateUploadRepository;
            _logger = logManager.GetLogger("MemberUploadbyAcesPollingAgent");
        }

        public void PollForMemberUploadbyAces()
        {
            try
            {
                if (_stopMemberUploadbyAces)
                {
                    _logger.Info("Customer Eligibility Upload Polling Agent stopped @:" + DateTime.Now);
                    return;
                }

                _logger.Info("Entering Member Upload by Aces Polling Agent @" + DateTime.Now);

                if (!DirectoryOperationsHelper.IsDirectoryExist(_memberUploadbyAcesSourceFolderPath))
                {
                    _logger.Info("Source folder not availble.");
                    return;
                }
                var files = DirectoryOperationsHelper.GetFiles(_memberUploadbyAcesSourceFolderPath, "*.txt");

                if (files.IsNullOrEmpty())
                {
                    _logger.Info("Files not availble in Source Folder.");
                    return;
                }

                var intakeFiles = files.Where(x => x.ToLower().Contains("outtake") && !x.ToLower().Contains("eligibility")).ToList();

                if (intakeFiles.IsNullOrEmpty())
                {
                    _logger.Info("Files not availble in Source Folder after outtake filter.");
                    return;
                }

                var mediaLocation = _mediaRepository.GetMemberUploadbyAcesFolderLocation();

                MoveFileMediaLocation(intakeFiles, mediaLocation);

                var todaysFiles = DirectoryOperationsHelper.GetFiles(Path.Combine(mediaLocation.PhysicalPath, DateTime.Today.ToString("yyyyMMdd")));

                if (todaysFiles.IsNullOrEmpty())
                {
                    _logger.Info("Files not availble in Source Folder.");
                    return;
                }

                var corporateAccount = _corporateAccountRepository.GetAllCorporateAccountAcestoHipInTake();
                if (corporateAccount.IsNullOrEmpty())
                {
                    _logger.Info("Account not found for Aces to Hip upload.");
                    return;
                }

                var languages = _languageRepository.GetAll();
                var labs = _labRepository.GetAll();

                var sendMail = false;
                foreach (var account in corporateAccount)
                {
                    _logger.Info("Parsing start for Account Tag :" + account.Tag);

                    var acesToHipIntakeShortName = account.AcesToHipIntakeShortName;

                    if (string.IsNullOrWhiteSpace(acesToHipIntakeShortName))
                    {
                        _logger.Info("AcesToHipIntake ShortName is blank for Account Tag :" + account.Tag);
                        continue;
                    }

                    acesToHipIntakeShortName = acesToHipIntakeShortName.ToLower() + "_";
                    var filesAcesToHipIntakeShortName = todaysFiles.Where(x => x.ToLower().Contains(acesToHipIntakeShortName) && x.ToLower().Contains("outtake") && !x.ToLower().Contains("eligibility"));

                    if (filesAcesToHipIntakeShortName.IsNullOrEmpty())
                    {
                        _logger.Info("Files not available for Short name : " + acesToHipIntakeShortName + " and Account Tag :" + account.Tag);
                        continue;
                    }

                    var customerList = new List<long>();

                    foreach (var file in filesAcesToHipIntakeShortName)
                    {
                        var filewithoutExtension = Path.GetFileNameWithoutExtension(file);
                        var acesClientShortName = filewithoutExtension.Split('_')[0];
                        if (acesClientShortName.ToLower() != account.AcesToHipIntakeShortName.ToLower())
                        {
                            _logger.Info("File Short name : " + acesClientShortName + " and Account Short name :" + account.AcesToHipIntakeShortName.ToLower() + " not matched.");
                            continue;
                        }

                        if (ParseMemberUploadbyAces(file, account, customerList, languages, labs))
                        {
                            if (!sendMail)
                                sendMail = true;
                        }
                    }

                    if (customerList.IsNullOrEmpty())
                    {
                        _logger.Info("PatientReportWithnoCustomTag Report not generated because new Customer not found for short name : " + acesToHipIntakeShortName + " and Account Tag :" + account.Tag);
                        continue;
                    }

                    PatientReportWithnoCustomTag(customerList.ToArray(), account.Tag);
                }
                if (sendMail)
                {
                    var listWithoutCustomTagsModel = _emailNotificationModelsFactory.GetListWithoutCustomTagsViewModel(_memberUploadbyAcesSourceFolderPath, Path.Combine(_memberUploadbyAcesSourceFolderPath, "Failed")
                        , Path.Combine(_memberUploadbyAcesSourceFolderPath, "AdjustOrder"));
                    _notifier.NotifySubscribersViaEmail(NotificationTypeAlias.ListWithoutCustomTags, EmailTemplateAlias.ListWithoutCustomTags, listWithoutCustomTagsModel, 0, 1, "MemberUploadbyAcesPollingAgent");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Exception occurred during execution of servcie. \nException Message: {0}\n\tStackTrace:{1}", ex.Message, ex.StackTrace));
                return;
            }
        }

        private string GetFileName(string sourceFile, MediaLocation mediaLocation)
        {
            var fileNameWithoutExtention = Path.GetFileNameWithoutExtension(sourceFile);
            var archiveFileName = fileNameWithoutExtention + "_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt";
            var destinationFile = Path.Combine(mediaLocation.PhysicalPath, archiveFileName);
            var archiveFilePath = string.Empty;
            try
            {
                var archiveFolderPath = Path.Combine(_memberUploadbyAcesSourceFolderPath, DateTime.Today.ToString("yyyyMMdd"), "Archive");
                archiveFilePath = Path.Combine(archiveFolderPath, archiveFileName);
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(archiveFolderPath);
                DirectoryOperationsHelper.Copy(sourceFile, archiveFilePath);
                DirectoryOperationsHelper.Move(sourceFile, destinationFile);
                _logger.Info("Source Path: " + sourceFile);
                _logger.Info("Destination Path: " + destinationFile);
            }
            catch (Exception ex)
            {
                _logger.Error("Error while archiving file.");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack trace: " + ex.StackTrace);
            }

            _logger.Info("Archive Path: " + archiveFilePath);
            return destinationFile;
        }

        private DataTable GetRows(string file)
        {

            _logger.Info("Start : File converting in Table");
            var memberData = _pipeDelimitedReportHelper.ReadWithTextQualifier(file);
            _logger.Info("End : File converted in Table");

            if (memberData == null || memberData.Rows == null || memberData.Rows.Count <= 0)
            {
                _logger.Info("Data not available in file(" + file + ")");
                return null;
            }

            _logger.Info("Total (" + memberData.Rows.Count + ") records found in file (" + file + ")");

            return memberData;
        }

        private bool IsAnyColumnMissing(DataTable dataTable)
        {
            var columns = dataTable.Columns.Cast<DataColumn>().Select(x => x.ColumnName.ToLower().Trim()).ToArray();
            var missingColumnNames = _corporateUploadHelper.CheckAllMemberUploadbyAcesColumnExist(columns);

            if (!string.IsNullOrEmpty(missingColumnNames))
            {
                _logger.Info("Column Name(" + missingColumnNames + ") missing ");
                return true;
            }

            return false;
        }

        private bool ParseMemberUploadbyAces(string file, CorporateAccount corporateAccount, List<long> customerList, IEnumerable<Language> languages, IEnumerable<Lab> labs)
        {
            try
            {
                _logger.Info("Start converting data from CSV to data table :" + DateTime.Now);

                var mediaLocation = _mediaRepository.GetMemberUploadbyAcesFolderLocation();
                var fileToParse = GetFileName(file, mediaLocation);
                var memberData = GetRows(fileToParse);

                var corportateUpload = _memberUploadByAcesHelper.Upload(fileToParse, corporateAccount);

                if (memberData == null) return false;

                var rowCountInFile = memberData.Rows.Count;

                _logger.Info("Data coverted from CSV to Data Table :" + DateTime.Now + " & Row count is : " + rowCountInFile);

                if (IsAnyColumnMissing(memberData))
                {
                    return false;
                }

                //var failedCustomers = new List<MemberUploadbyAcesFailedCustomerModel>();
                var adjustOrderCustomer = new List<EventCusomerAdjustOrderViewModel>();

                var rows = memberData.AsEnumerable();

                var orgRoleUser = new OrganizationRoleUser() { Id = OrgRoleUserId, RoleId = OrgRoleId };
                var corporateModel = new CorporateUploadEditModel { Tag = corporateAccount.Tag, CorporateAccountId = corporateAccount.Id, UploadCorporateId = corportateUpload.Id };

                var accountAdditionalFields = _accountAdditionalFieldRepository.GetAccountAdditionalFieldsEditModelByAccountId(corporateAccount.Id);
                var index = 1;
                var customerIdWithSameAcesId = new List<CustomerWithDuplicateAcesModel>();

                foreach (DataRow row in rows)
                {
                    _logger.Info(index + " out of " + rowCountInFile + " processing");

                    var customerEditModel = CreateEditModel(row);

                    if (customerEditModel == null)
                    {
                        continue;
                    }
                    var sb = new StringBuilder();

                    try
                    {
                        _logger.Info("Record:  First Name :" + customerEditModel.FirstName + ", Last Name :" + customerEditModel.LastName + " and ACES Id :" + customerEditModel.AcesId);
                        var customerWithDuplicateAcesModel = new CustomerWithDuplicateAcesModel();
                        _corporateUploadService.CorporateUploadDataRow(customerEditModel, languages, labs, null, corporateModel, accountAdditionalFields,
                                    adjustOrderCustomer, orgRoleUser, OrgRoleId, customerList, (long)MemberUploadSource.Aces, sb, corportateUpload.Id, out customerWithDuplicateAcesModel);

                        if (customerWithDuplicateAcesModel != null && customerWithDuplicateAcesModel.CustomerId > 0)
                            customerIdWithSameAcesId.Add(customerWithDuplicateAcesModel);
                    }
                    catch (Exception ex)
                    {
                        customerEditModel.ErrorMessage = sb.ToString();
                        if (!string.IsNullOrEmpty(ex.Message))
                            customerEditModel.ErrorMessage += " Error Message: " + ex.Message;
                        _logger.Error("While Saving customer");
                        _logger.Error(customerEditModel.ErrorMessage);
                        //var model = _memberUploadbyAcesFailedCustomerFactory.Create(customerEditModel);
                        //failedCustomers.Add(model);
                    }
                    _logger.Info(index + " out of " + rowCountInFile + " completed");

                    var memberUploadParseDetail = _memberUploadParseDetailFactory.GetDomain(customerEditModel, corportateUpload.Id);
                    _memberUploadParseDetailRepository.Save(memberUploadParseDetail);

                    index++;
                }

                if (!customerIdWithSameAcesId.IsNullOrEmpty())
                    _customerWithDuplicateAcesIdFileGenerator.GenerateCsvFile(corportateUpload.Id, customerIdWithSameAcesId);

                var failedRecords = _memberUploadParseDetailRepository.GetByCorporateUploadId(corportateUpload.Id, false);
                var failedCustomers = _memberUploadParseDetailFactory.GetMemberUploadbyAcesFailedCustomerListModel(failedRecords, corportateUpload.SourceId);

                CreateFailedUploadFile(file, mediaLocation, failedCustomers, corportateUpload);

                CreateAdjustOrderUploadFile(file, mediaLocation, adjustOrderCustomer, corportateUpload);

                corportateUpload.ParseStatus = (int)MemberUploadParseStatus.Start;
                corportateUpload = _memberUploadByAcesHelper.UpdateCorporateUpload(corportateUpload, failedCustomers.Count(), rowCountInFile);

                if (corportateUpload.SuccessfullUploadCount > 0)
                {
                    _logger.Info("Set IsTermByAbsence is True");
                    corportateUpload.IsTermByAbsence = true;
                    _corporateUploadRepository.Save(corportateUpload);                   

                    _logger.Info("Publishing: Corporate Upload Id: " + corportateUpload.Id);
                    _memberTermByAbsencePublisher.PublishCorporateUpload(corportateUpload.Id);
                    _logger.Info("Publish Successfully: Corporate Upload Id: " + corportateUpload.Id);
                }

                return (failedCustomers.Any() || accountAdditionalFields.Any() || customerList.Any());
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error occurred while processing the {0}.\nMessage: {1}\n\tStackTrace: {2}", file, ex.Message, ex.StackTrace));
                return false;
            }
        }

        private CorporateCustomerEditModel CreateEditModel(DataRow row)
        {
            try
            {
                CorporateCustomerEditModel customerEditModel = _corporateUploadHelper.GetMemberUploadbyAcesCustomerEditModel(row);
                customerEditModel.MemberUploadSourceId = (long)MemberUploadSource.Aces;
                customerEditModel.PredictedZip = string.Empty;

                customerEditModel.IsCustomerZipInvalid = false;
                customerEditModel.IsPCPZipInvalid = false;
                customerEditModel.IsPCPMailingZipInvalid = false;

                return customerEditModel;
            }
            catch (Exception ex)
            {
                _logger.Error("Error occurred while converting row in edit model. ");
                _logger.Error("Exception Message :" + ex.Message);
                _logger.Error("Stack Trace :" + ex.StackTrace);
            }
            return null;
        }

        private void CreateFailedUploadFile(string file, MediaLocation mediaLocation, List<MemberUploadbyAcesFailedCustomerModel> failedRecords, CorporateUpload corportateUpload)
        {
            if (failedRecords.Any())
            {
                try
                {
                    var nameWithoutExt = Path.GetFileNameWithoutExtension(file);

                    var fileName = nameWithoutExt + "_Failed_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt";
                    var sourceFailedLocation = Path.Combine(mediaLocation.PhysicalPath, fileName);

                    DirectoryOperationsHelper.DeleteFileIfExist(sourceFailedLocation);

                    _logger.Info("Number of failed Records: " + failedRecords.Count);
                    _logger.Info("Creating file for failed records...");

                    _pipeDelimitedReportHelper.Write(failedRecords.OrderBy(x => x.CustomerId), mediaLocation.PhysicalPath, fileName);
                    _logger.Info("failed records file created.");

                    _logger.Info("Failed file Coping in Client Location.");

                    var targetFailedFoler = Path.Combine(_memberUploadbyAcesSourceFolderPath, DateTime.Today.ToString("yyyyMMdd"), "Failed");
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(targetFailedFoler);

                    var targetFailedLocation = Path.Combine(targetFailedFoler, fileName);

                    DirectoryOperationsHelper.CopyWithReplace(sourceFailedLocation, targetFailedLocation);

                    _memberUploadByAcesHelper.UploadFailedFile(sourceFailedLocation, corportateUpload);

                    _logger.Info("Failed Record Path:" + sourceFailedLocation);
                    _logger.Info("Client Failed Record Path:" + targetFailedLocation);

                    _logger.Info("Failed file Copied in Client Location.");

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error occurred while creating failed records file. \nException Message: {0}\n\tStackTrace: {1}", ex.Message, ex.StackTrace));
                }
            }
        }

        private void CreateAdjustOrderUploadFile(string file, MediaLocation mediaLocation, List<EventCusomerAdjustOrderViewModel> adjustOrderRecords, CorporateUpload corportateUpload)
        {
            if (adjustOrderRecords.Any())
            {
                try
                {
                    var nameWithoutExt = Path.GetFileNameWithoutExtension(file);

                    var fileName = nameWithoutExt + "_adjustOrder_" + DateTime.Now.ToString("MMddyyyyHHmmss") + ".txt";
                    var sourceAdjustOrderLocation = Path.Combine(mediaLocation.PhysicalPath, fileName);

                    DirectoryOperationsHelper.DeleteFileIfExist(sourceAdjustOrderLocation);

                    _logger.Info("Number of Adjust Order Records: " + adjustOrderRecords.Count);
                    _logger.Info("Creating file for Adjust Order records...");

                    _pipeDelimitedReportHelper.WriteWithTextQualifier(adjustOrderRecords.OrderBy(x => x.CustomerId), mediaLocation.PhysicalPath, fileName);
                    _logger.Info("Adjust Order records file created.");

                    _logger.Info("Adjust order file Coping in Client Location.");

                    var targetAdjustOrderFoler = Path.Combine(_memberUploadbyAcesSourceFolderPath, DateTime.Today.ToString("yyyyMMdd"), "AdjustOrderRecords");
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(targetAdjustOrderFoler);

                    var targetAdjustOrderLocation = Path.Combine(targetAdjustOrderFoler, fileName);
                    DirectoryOperationsHelper.CopyWithReplace(sourceAdjustOrderLocation, targetAdjustOrderLocation);

                    _memberUploadByAcesHelper.UploadAdjustOrderFile(sourceAdjustOrderLocation, corportateUpload);

                    _logger.Info("Adjust order file Copied in Client Location.");

                    _logger.Info("Failed Record Path:" + sourceAdjustOrderLocation);
                    _logger.Info("Client Failed Record Path:" + targetAdjustOrderLocation);

                }
                catch (Exception ex)
                {
                    _logger.Error(string.Format("Error occurred while creating failed records file. \nException Message: {0}\n\tStackTrace: {1}", ex.Message, ex.StackTrace));
                }
            }
        }

        private void PatientReportWithnoCustomTag(long[] customerIds, string accountTag)
        {
            _logger.Info("Entering Patient Report with no Custom Tag @" + DateTime.Now);

            _logger.Info(customerIds.Count() + " Customer found.");
            var destinationFoler = Path.Combine(_memberUploadbyAcesSourceFolderPath, "PatientReportWithnoCustomTag", DateTime.Today.ToString("yyyyMMdd"));
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);

            var fileName = "PatientReportWithnoCustomTag_" + accountTag + "_" + DateTime.Now.AddDays(-1).ToString("MMddyyyyHHmmss") + ".txt";
            var destinationFile = Path.Combine(destinationFoler, fileName);

            DirectoryOperationsHelper.DeleteFileIfExist(destinationFile);

            WriteCsvHeader(destinationFile);

            var collection = new List<PatientWithNoCustomTagViewModel>();

            var pageNumber = 1;
            int totalRecords = customerIds.Count();
            var totalPages = (totalRecords / PageSize) + (totalRecords % PageSize != 0 ? 1 : 0);

            do
            {
                var pagedCustomers = customerIds.Skip(PageSize * (pageNumber - 1)).Take(PageSize);
                var parsedCustomerIds = pagedCustomers.ToArray();
                var customers = _customerRepository.GetCustomersWoithoutLoginAndAddressDetails(parsedCustomerIds);

                var preapprovedTest = _preApprovedTestRepository.GetPreApprovedTests(parsedCustomerIds);
                var preApprovedPackageTest = _preApprovedPackageRepository.GetPreApprovedPackageTestByCustomerIds(parsedCustomerIds);

                foreach (var customer in customers)
                {
                    var tests = preapprovedTest.Where(x => x.FirstValue == customer.CustomerId).Select(x => x.SecondValue);
                    var packageTest = preApprovedPackageTest.Where(x => x.FirstValue == customer.CustomerId).Select(x => x.SecondValue);

                    var allTest = tests.Union(packageTest).Distinct().ToArray();

                    string testName = string.Empty;
                    if (!allTest.IsNullOrEmpty())
                    {
                        testName = string.Join(",", allTest);
                    }

                    var patientData = _patientWithNoCustomTagFactory.Create(customer, testName);
                    collection.Add(patientData);
                }

                WriteCsv(collection, destinationFile);
                pageNumber++;
            }
            while (totalPages >= pageNumber);

            _logger.Info("Customer With No customer Tags: " + destinationFile);

            _logger.Info("Patient Report with no Custom Tag Completed.");
        }

        private void WriteCsvHeader(string fileName)
        {
            var fs = new FileStream(fileName, FileMode.OpenOrCreate);
            var streamWriter = new StreamWriter(fs);

            try
            {
                var members = (typeof(PatientWithNoCustomTagViewModel)).GetMembers();

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

                    header.Add("\"" + propertyName + "\"");
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

        private void WriteCsv(IEnumerable<PatientWithNoCustomTagViewModel> collection, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(PatientWithNoCustomTagViewModel)).GetMembers();

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
                            values.Add("\"" + formatter.ToString(obj) + "\"");
                        else
                            values.Add("\"" + obj.ToString() + "\"");

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

        private void MoveFileMediaLocation(List<string> sourceFiles, MediaLocation mediaLocation)
        {
            var dateWiseFolder = Path.Combine(mediaLocation.PhysicalPath, DateTime.Today.ToString("yyyyMMdd"));
            _logger.Info("Files moved in this location :" + dateWiseFolder);
            try
            {
                DirectoryOperationsHelper.CreateDirectoryIfNotExist(dateWiseFolder);
                foreach (var file in sourceFiles)
                {
                    DirectoryOperationsHelper.Move(file, Path.Combine(dateWiseFolder, Path.GetFileName(file)));
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Error while archiving file.");
                _logger.Error("Message: " + ex.Message);
                _logger.Error("Stack trace: " + ex.StackTrace);
            }

            _logger.Info("Date Path: " + dateWiseFolder);

        }

    }
}
