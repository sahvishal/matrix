using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using System.Linq;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class UniversalMemberReportService : IUniversalMemberReportService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateAccountRepository _corporateAccountRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICustomerEligibilityRepository _customerEligibilityRepository;

        private readonly ILogger _logger;
        private const int PageSize = 100;
        private readonly string _folderPath;
        private readonly string _folderArchivedPath;
        private readonly string _sftpFolderPath;

        public UniversalMemberReportService(ICustomerRepository customerRepository, ICorporateAccountRepository corporateAccountRepository,
            ILogManager logManager, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, ILanguageRepository languageRepository,
            ICustomerEligibilityRepository customerEligibilityRepository, ISettings settings)
        {
            _customerRepository = customerRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _languageRepository = languageRepository;
            _customerEligibilityRepository = customerEligibilityRepository;

            _logger = logManager.GetLogger("UniversalMemberReport");
            _folderPath = settings.UniversalMemberFilePath;
            _folderArchivedPath = settings.UniversalMemberArchivedFilePath;
            _sftpFolderPath = settings.UniversalMemberFileSftpPath;
        }

        public void GetUniversalMemberCustomerReport()
        {
            try
            {
                var accounts = _corporateAccountRepository.GetAllCorporateAccountToSendPatientDataToAces();
                if (accounts.IsNullOrEmpty())
                {
                    _logger.Info("No Account marked to Send Patient Data to Aces");
                    return;
                }

                var distinctClientIds = accounts.Where(x => !string.IsNullOrWhiteSpace(x.ClientId)).Select(t => t.ClientId).Distinct();
                foreach (var clientId in distinctClientIds)
                {
                    var accountBasedOnClientId = accounts.Where(a => a.ClientId == clientId);

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
                var accountShortNamewise = accounts.Where(a => a.AcesClientShortName == acesClientShortName);

                if (!accountShortNamewise.IsNullOrEmpty())
                {
                    var destinationFoler = _folderPath; //Path.Combine(_folderPath, clientId);
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(destinationFoler);
                    DirectoryOperationsHelper.CreateDirectoryIfNotExist(_folderArchivedPath);
                    var fileNameWithoutExtention = acesClientShortName + "_Universal_Member";
                    var fileName = fileNameWithoutExtention + ".txt";
                    var destinationFile = Path.Combine(destinationFoler, fileName);

                    if (DirectoryOperationsHelper.IsFileExist(destinationFile))
                    {
                        var archiveFileName = fileNameWithoutExtention + "_" + DateTime.Today.AddDays(-1).ToString("ddMMyyyy") + ".txt";
                        var archiveFilePath = Path.Combine(_folderArchivedPath, archiveFileName);
                        DirectoryOperationsHelper.DeleteFileIfExist(archiveFilePath);
                        DirectoryOperationsHelper.Move(destinationFile, archiveFilePath);
                    }

                    var suppressedRecordsFile = Path.Combine(destinationFoler, acesClientShortName + "_Suppressed_Member_Records.txt");

                    if (DirectoryOperationsHelper.IsFileExist(suppressedRecordsFile))
                    {
                        var archivesuppressedRecordsFileName = acesClientShortName + "_Suppressed_Member_Records_" + DateTime.Today.AddDays(-1).ToString("ddMMyyyy") + ".txt";
                        var archiveFilePath = Path.Combine(_folderArchivedPath, archivesuppressedRecordsFileName);

                        DirectoryOperationsHelper.Move(suppressedRecordsFile, Path.Combine(_folderArchivedPath, archivesuppressedRecordsFileName));
                    }

                    WriteCsvHeader(destinationFile);

                    _logger.Info("starting for account AcesClientShortName " + acesClientShortName);

                    foreach (var corporateAccount in accountShortNamewise)
                    {
                        try
                        {
                            _logger.Info("starting for account Tag " + corporateAccount.Tag);

                            var filter = new UniversalMemberListModelFilter
                            {
                                AccountId = corporateAccount.Id,
                                Tag = corporateAccount.Tag
                            };

                            var pageNumber = 1;

                            while (true)
                            {
                                int totalRecords = 0;
                                var customers = _customerRepository.GetCustomerForUniversalMemberReport(filter, pageNumber,
                                    PageSize, out totalRecords);

                                if (customers.IsNullOrEmpty())
                                    break;

                                var customerIds = customers.Select(x => x.CustomerId);

                                var pcpCollection =
                                    _primaryCarePhysicianRepository.GetCustomerPcpWithoutAddress(
                                        customers.Select(x => x.CustomerId));
                                var customerEligilityCollection =
                                    _customerEligibilityRepository.GetCustomerEligibilityByCustomerIds(customerIds);
                                var languages = _languageRepository.GetAll();

                                var collection = new List<UniversalMemberViewModel>();
                                var suppressedRecordsCollection = new List<UniversalMemberViewModel>();

                                foreach (var customer in customers)
                                {
                                    var customerPcps =
                                        pcpCollection.Where(pcp => pcp.CustomerId == customer.CustomerId).ToArray();
                                    var customerEligibilityStatus =
                                        customerEligilityCollection.Where(x => x.CustomerId == customer.CustomerId).ToArray();

                                    var pcpStartDate = (DateTime?)null;
                                    var pcpEndDate = (DateTime?)null;
                                    var pcpId = (long?)null;
                                    if (!customerPcps.IsNullOrEmpty())
                                    {
                                        var activePcp = customerPcps.SingleOrDefault(x => x.IsActive);

                                        if (activePcp != null)
                                        {
                                            pcpStartDate = activePcp.DataRecorderMetaData.DateCreated;
                                            pcpId = activePcp.Id;
                                        }
                                    }

                                    var eligibilityStartDate = (DateTime?)null;
                                    var eligibilityEndDate = (DateTime?)null;

                                    if (!customerEligibilityStatus.IsNullOrEmpty())
                                    {
                                        var customerEligibilityforCurrentYear =
                                            customerEligibilityStatus.FirstOrDefault(x => x.IsEligible.HasValue && x.IsEligible.Value && x.ForYear == DateTime.Today.Year);

                                        if (customerEligibilityforCurrentYear != null)
                                        {
                                            var year = customerEligibilityforCurrentYear.ForYear;
                                            eligibilityStartDate = new DateTime(year, 1, 1);
                                            eligibilityEndDate = new DateTime(year, 12, 31);
                                        }
                                    }

                                    var language = languages.SingleOrDefault(x => x.Id == customer.LanguageId);

                                    var model = SetUniversalMemberViewModelData(customer, corporateAccount, language, pcpStartDate, pcpEndDate, eligibilityStartDate, eligibilityEndDate, pcpId);

                                    if (string.IsNullOrWhiteSpace(model.FirstName) || string.IsNullOrWhiteSpace(model.LastName) || model.DoB == null || string.IsNullOrWhiteSpace(model.ClientMemberId))
                                    {
                                        suppressedRecordsCollection.Add(model);
                                    }
                                    else
                                    {
                                        collection.Add(model);
                                    }
                                }

                                WriteCsv(collection, destinationFile);
                                if (!suppressedRecordsCollection.IsNullOrEmpty())
                                {
                                   
                                    WriteCsvHeader(suppressedRecordsFile);

                                    WriteCsv(suppressedRecordsCollection, suppressedRecordsFile);
                                }

                                _logger.Info((pageNumber * PageSize) + " out of " + totalRecords);

                                if ((pageNumber * PageSize) >= totalRecords)
                                    break;

                                pageNumber++;
                            }

                            _logger.Info("completed for Account " + corporateAccount.Tag);
                        }
                        catch (Exception exception)
                        {
                            _logger.Error("some error occurred while created Member List for Account " + corporateAccount.Tag);
                            _logger.Error("Message: " + exception.Message);
                            _logger.Error("Stack Trace: " + exception.StackTrace);
                        }
                    }

                    if (DirectoryOperationsHelper.IsFileExist(destinationFile))
                    {
                        _logger.Info("Universal Member Report generated : " + destinationFile);

                        DirectoryOperationsHelper.CreateDirectoryIfNotExist(_sftpFolderPath);

                        _logger.Info("Deleting old file from SFTP.");
                        DirectoryOperationsHelper.DeleteFileIfExist(Path.Combine(_sftpFolderPath, acesClientShortName + "_Universal_Member.txt"));
                        _logger.Info("Old file deleted from SFTP.");

                        _logger.Info("Copying file to SFTP location : " + _sftpFolderPath);
                        var sftpFilePath = Path.Combine(_sftpFolderPath, fileName);
                        DirectoryOperationsHelper.Copy(destinationFile, sftpFilePath);
                        _logger.Info("File copied : " + sftpFilePath);
                    }
                }
            }
        }

        private string GetGenderCode(Gender gender)
        {
            switch (gender)
            {
                case Gender.Female:
                    return "F";
                case Gender.Male:
                    return "M";
                default:
                    return "U";
            }
        }

        private UniversalMemberViewModel SetUniversalMemberViewModelData(Customer customer, CorporateAccount account, Language language, DateTime? pcpStartDate, DateTime? pcpEndDate, DateTime? eligiblityStartDate, DateTime? eligiblityEndDate, long? pcpId)
        {
            var languageCode = GetLanguagesCode(language);
            var raceCode = GetRaceCode(customer.Race);
            var model = new UniversalMemberViewModel
            {
                ClientID = account.ClientId,
                ClientMemberId = ClearText(customer.InsuranceId),
                AltClientMemberId = string.Empty,
                Title = string.Empty,
                FirstName = ClearText(customer.Name.FirstName),
                MiddleName = ClearText(customer.Name.MiddleName),
                LastName = ClearText(customer.Name.LastName),
                Gender = GetGenderCode(customer.Gender),
                DoB = customer.DateOfBirth,
                HicNumber = ClearText(customer.Hicn),
                MediCaidNumber = string.Empty,
                HomeStreet1 = customer.Address != null ? ClearText(customer.Address.StreetAddressLine1) : string.Empty,
                HomeStreet2 = customer.Address != null ? ClearText(customer.Address.StreetAddressLine2) : string.Empty,
                HomeCity = customer.Address != null ? customer.Address.City : string.Empty,
                HomeCounty = string.Empty,
                HomeState = customer.Address != null ? customer.Address.StateCode : string.Empty,
                HomeZip = customer.Address != null ? customer.Address.ZipCode.Zip : string.Empty,

                TelephoneNumber1 = CleanPhone(customer.HomePhoneNumber),
                TelephoneNumber2 = CleanPhone(customer.MobilePhoneNumber),
                TelephoneNumber3 = CleanPhone(customer.OfficePhoneNumber),

                EmailAddress = (customer.Email != null ? customer.Email.ToString() : string.Empty),
                SubscriberId = string.Empty,
                MarketingPlan = ClearText(customer.Market),
                Language = languageCode > 0 ? languageCode.ToString() : string.Empty,
                Race = raceCode > 0 ? raceCode.ToString() : string.Empty,
                PlanID = string.Empty,
                OtherPlanID = string.Empty,
                MetalLevel = string.Empty,
                CmsNumber = string.Empty,
                PbpNumber = string.Empty,
                EligibilityStartDate = eligiblityStartDate,
                EligibilityEndDate = eligiblityEndDate,
                TerminationReason = string.Empty,
                EligibilityGroup = string.Empty,
                ClientProviderId = pcpId.HasValue ? pcpId.Value.ToString() : string.Empty,
                NetworkProvider = string.Empty,
                PcpStartDate = pcpStartDate,
                PcpEndDate = pcpEndDate,
                Custom1 = customer.CustomerId.ToString(),
                Custom2 = string.Empty,
                Custom3 = string.Empty,
                PreferredPlanName = string.Empty,
                Mbi = string.Empty
            };

            if (customer.BillingAddress != null)
            {
                model.MailingStreet1 = ClearText(customer.BillingAddress.StreetAddressLine1);
                model.MailingStreet2 = ClearText(customer.BillingAddress.StreetAddressLine2);
                model.MailingCity = customer.BillingAddress.City;
                model.MailingCounty = string.Empty;
                model.MailingState = customer.BillingAddress.StateCode;
                model.MailingZip = customer.BillingAddress.ZipCode.Zip;
            }
            return model;
        }

        private string ClearText(string textToBeClean)
        {
            if (string.IsNullOrWhiteSpace(textToBeClean)) return string.Empty;
            textToBeClean = textToBeClean.Trim();

            var cleanText = Regex.Replace(textToBeClean, @"[\n\r\t|]", ",");

            return cleanText;
        }

        private int GetLanguagesCode(Language language)
        {
            if (language != null && !string.IsNullOrWhiteSpace(language.Name))
            {
                var lang = GetLanguages().FirstOrDefault(l => l.SecondValue.ToLower() == language.Name.ToLower());
                return lang != null ? lang.FirstValue : 0;
            }

            return 0;
        }

        private int GetRaceCode(Race race)
        {
            var raceCode = GetRace().FirstOrDefault(c => c.SecondValue.ToLower() == race.ToString().ToLower());
            if (raceCode != null)
                return raceCode.FirstValue;

            return 0;
        }

        private IEnumerable<OrderedPair<int, string>> GetRace()
        {
            /*Asian
African American
Hispanic
Native Indian
Other
Pacific Islander/Native Hawaiian
Unknown
White
*/
            return new List<OrderedPair<int, string>>
            {
                new OrderedPair<int, string>(1, "Asian"),
                new OrderedPair<int, string>(2, "AfricanAmerican"),
                new OrderedPair<int, string>(3, "Hispanic"),
                new OrderedPair<int, string>(4, "NativeAmerican"),
                new OrderedPair<int, string>(5, "Other"),
                //new OrderedPair<int, string>(6, "Pacific Islander/Native Hawaiian"),
                //new OrderedPair<int, string>(7, "Unknown"),
                new OrderedPair<int, string>(8, "Caucasian"),//White
            };
        }

        private static IEnumerable<OrderedPair<int, string>> GetLanguages()
        {
            return new List<OrderedPair<int, string>>
            {
                new OrderedPair<int, string>(1, "Arabic"),
                new OrderedPair<int, string>(2, "Bengali"),
                new OrderedPair<int, string>(3, "Cantonese"),
                new OrderedPair<int, string>(4, "French"),
                new OrderedPair<int, string>(5, "Hindustani"),
                new OrderedPair<int, string>(6, "Mandarin"),
                new OrderedPair<int, string>(7, "Portuguese"),
                new OrderedPair<int, string>(8, "Russian"),
                new OrderedPair<int, string>(9, "Spanish"),
                new OrderedPair<int, string>(10, "Other"),//Other/Unknown
                new OrderedPair<int, string>(11, "Chinese"),
                new OrderedPair<int, string>(12, "German"),
                new OrderedPair<int, string>(13, "Korean"),
                new OrderedPair<int, string>(14, "Tagalog"),
                new OrderedPair<int, string>(15, "Vietnamese"),
                new OrderedPair<int, string>(19, "Thai"),
                new OrderedPair<int, string>(20, "Armenian"),
                new OrderedPair<int, string>(22, "Filipino; Philipino"),
                new OrderedPair<int, string>(23, "Philippine languages"),
                new OrderedPair<int, string>(24, "Greek"),
                new OrderedPair<int, string>(26, "Hindi"),
                new OrderedPair<int, string>(27, "Hungarian"),
                new OrderedPair<int, string>(28, "Indic languages"),
                new OrderedPair<int, string>(29, "Italian"),
                new OrderedPair<int, string>(30, "Japanese"),
                new OrderedPair<int, string>(31, "Marathi"),
                new OrderedPair<int, string>(32, "Panjabi; Punjabi"),
                new OrderedPair<int, string>(33, "Persian"),
                new OrderedPair<int, string>(35, "Polish"),
                new OrderedPair<int, string>(36, "Sign Languages"),
                new OrderedPair<int, string>(37, "Urdu"),
                new OrderedPair<int, string>(38, "Albanian"),
                new OrderedPair<int, string>(40, "Amharic"),
                new OrderedPair<int, string>(41, "Croatian"),
                new OrderedPair<int, string>(42, "Central Khmer"),
                new OrderedPair<int, string>(43, "Lao"),
                new OrderedPair<int, string>(44, "North American Indian languages"),
                new OrderedPair<int, string>(45, "Somali"),
                new OrderedPair<int, string>(46, "Serbian"),
                new OrderedPair<int, string>(47, "Undetermined"),
                new OrderedPair<int, string>(48, "Bosnian"),
                new OrderedPair<int, string>(49, "Burmese"),
                new OrderedPair<int, string>(51, "Creole"),
                new OrderedPair<int, string>(52, "Danish"),
                new OrderedPair<int, string>(53, "Dutch"),
                new OrderedPair<int, string>(55, "French Creole"),
                new OrderedPair<int, string>(56, "Gujarati"),
                new OrderedPair<int, string>(57, "Haitian"),
                new OrderedPair<int, string>(58, "Hebrew"),
                new OrderedPair<int, string>(59, "Indonesian"),
                new OrderedPair<int, string>(60, "Malayalam"),
                new OrderedPair<int, string>(61, "Norwegian"),
                new OrderedPair<int, string>(62, "Pali"),
                new OrderedPair<int, string>(63, "Pashtu/Pashto"),
                new OrderedPair<int, string>(64, "Romanian"),
                new OrderedPair<int, string>(66, "Slovenian"),
                new OrderedPair<int, string>(67, "Swahili"),
                new OrderedPair<int, string>(68, "Turkish"),
                new OrderedPair<int, string>(69, "Ukranian"),
                new OrderedPair<int, string>(70, "Hmong"),
                new OrderedPair<int, string>(99, "English"),
            };
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
                var members = (typeof(UniversalMemberViewModel)).GetMembers();

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

        private void WriteCsv(IEnumerable<UniversalMemberViewModel> collection, string fileName)
        {

            var fs = new FileStream(fileName, FileMode.Append);
            var streamWriter = new StreamWriter(fs);
            try
            {
                var members = (typeof(UniversalMemberViewModel)).GetMembers();

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

        private void DeleteUnUsedFiles(string filePath, string fileName)
        {
            try
            {
                var enddate = DateTime.Today.AddDays(-7);
                var existingFiles = new List<string>();

                for (var date = DateTime.Today; enddate < date; date = date.AddDays(-1))
                {
                    string filename = fileName + date.ToString("yyyyMMdd");
                    existingFiles.Add(filename);
                }

                var files = DirectoryOperationsHelper.GetFiles(filePath, fileName + "*.txt");
                foreach (string file in files)
                {
                    if (existingFiles.Any(x => file.Contains(x)))
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
    }
}
