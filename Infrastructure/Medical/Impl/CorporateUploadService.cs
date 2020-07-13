using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Marketing.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.Enum;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.ValueTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using File = Falcon.App.Core.Application.Domain.File;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class CorporateUploadService : ICorporateUploadService
    {
        private readonly ICorporateUploadHelper _corporateUploadHelper;
        private readonly IPackageRepository _packageRepository;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IEventCustomerPreApprovedTestService _eventCustomerPreApprovedTestService;
        private readonly ICorporateCustomerCustomTagService _corporateCustomerCustomTagService;
        private readonly ICustomerRepository _customerRepository;

        private readonly IMediaRepository _mediaRepository;
        private readonly ICorporateUploadRepository _corporateUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMassRegistrationEditModelFactory _massRegistrationEditModelFactory;
        private readonly IAddressService _addressService;
        private readonly IAddressRepository _addressRepository;
        private readonly IMemberUploadLogRepository _memberUploadLogRepository;
        private readonly ICustomerService _customerService;
        private readonly IStateRepository _stateRepository;


        public CorporateUploadService(ICorporateUploadHelper corporateUploadHelper, IPackageRepository packageRepository,
            ICustomerRegistrationService customerRegistrationService, IEventCustomerPreApprovedTestService eventCustomerPreApprovedTestService,
            ICorporateCustomerCustomTagService corporateCustomerCustomTagService, ICustomerRepository customerRepository,
            IMediaRepository mediaRepository, IUniqueItemRepository<File> fileRepository, IOrganizationRoleUserRepository organizationRoleUserRepository
            , ICorporateUploadRepository corporateUploadRepository, IMassRegistrationEditModelFactory massRegistrationEditModelFactory, IAddressService addressService, IAddressRepository addressRepository, IMemberUploadLogRepository memberUploadLogRepository,
            ICustomerService customerService, IStateRepository stateRepository)
        {
            _corporateUploadHelper = corporateUploadHelper;
            _packageRepository = packageRepository;
            _customerRegistrationService = customerRegistrationService;
            _eventCustomerPreApprovedTestService = eventCustomerPreApprovedTestService;
            _corporateCustomerCustomTagService = corporateCustomerCustomTagService;
            _customerRepository = customerRepository;
            _mediaRepository = mediaRepository;
            _fileRepository = fileRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _corporateUploadRepository = corporateUploadRepository;
            _massRegistrationEditModelFactory = massRegistrationEditModelFactory;
            _addressService = addressService;
            _addressRepository = addressRepository;
            _memberUploadLogRepository = memberUploadLogRepository;
            _customerService = customerService;
            _stateRepository = stateRepository;
        }

        public void CorporateUploadDataRow(CorporateCustomerEditModel customerEditModel, IEnumerable<Language> languages, IEnumerable<Lab> labs,
            List<string> customTags, CorporateUploadEditModel corporateModel, IEnumerable<AccountAdditionalFieldsEditModel> accountAdditionalFields,
            List<EventCusomerAdjustOrderViewModel> adjustOrderForCustomerEditModel, OrganizationRoleUser createdByOrgRoleUser, long organizationRoleUserId,
            List<long> customerList, long? source, StringBuilder sb, long corporateUploadId, out CustomerWithDuplicateAcesModel customerIdWithSameAcesId)
        {

            var customerWithSameAcesId = new CustomerWithDuplicateAcesModel();
            string errorMessage = _corporateUploadHelper.CheckAddtionalField(customerEditModel, accountAdditionalFields);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                throw new InvalidOperationException("System will not parse the customer data as " + errorMessage + " is not added for this corporate account.");
            }

            if (!string.IsNullOrEmpty(customerEditModel.PreApprovedPackage))
            {
                var preApprovedPackage = _packageRepository.GetByName(customerEditModel.PreApprovedPackage);
                if (preApprovedPackage == null)
                {
                    throw new InvalidOperationException("Package does not exist");
                }
                customerEditModel.PreApprovedPackageId = preApprovedPackage.Id;
            }

            //Customer customerWithAcesId = null;
            List<Customer> customersWithAcesId = null;

            var isMemberUploadByAces = false;
            isMemberUploadByAces = (source.HasValue && source.Value == (long)MemberUploadSource.Aces);

            if (!string.IsNullOrWhiteSpace(customerEditModel.AcesId))
            {
                customersWithAcesId = _customerRegistrationService.GetCustomersByAcesId(customerEditModel.AcesId);
                //if (!customersWithAcesId.IsNullOrEmpty() && customersWithAcesId.Count() > 1)
                //{
                //    throw new InvalidOperationException("Aces Id can not be duplicate, Aces Id : " + customerEditModel.AcesId + " already assigned.");
                //}

                //customerWithAcesId = customersWithAcesId.IsNullOrEmpty() ? null : customersWithAcesId.First();
            }

            if (customerEditModel.PreApprovedTest != null && customerEditModel.PreApprovedTest.Any())
            {
                var pairs = TestType.A1C.GetNameValuePairs();
                var preApprovedTestExists = pairs.Where(x => customerEditModel.PreApprovedTest.Contains(x.SecondValue.ToLower())).Select(x => x.SecondValue.ToLower());

                var testNotExist = string.Empty;

                if (preApprovedTestExists != null && preApprovedTestExists.Any() && (preApprovedTestExists.Count() != customerEditModel.PreApprovedTest.Count()))
                {
                    var testNotExistInSystem = customerEditModel.PreApprovedTest.Where(x => !preApprovedTestExists.Contains(x.ToLower())).Select(x => x).ToArray();

                    testNotExist = string.Join(",", testNotExistInSystem);
                }
                else if (preApprovedTestExists == null || !preApprovedTestExists.Any())
                {
                    testNotExist = string.Join(",", customerEditModel.PreApprovedTest);
                }

                if (!string.IsNullOrEmpty(testNotExist))
                    throw new InvalidOperationException(testNotExist + " test alias name does not exist in HIP");
            }

            if (string.IsNullOrEmpty(customerEditModel.Activity))
            {
                throw new InvalidOperationException("Activity cannot be blank.");
            }

            if (!isMemberUploadByAces && !(customerEditModel.Activity.ToLower() == UploadActivityType.MailOnly.GetDescription().ToLower() || customerEditModel.Activity.ToLower() == UploadActivityType.OnlyCall.GetDescription().ToLower() ||
                customerEditModel.Activity.ToLower() == UploadActivityType.BothMailAndCall.GetDescription().ToLower()))
            {
                throw new InvalidOperationException("Activity value invalid.");
            }

            if (isMemberUploadByAces && !(customerEditModel.Activity.ToLower() == UploadActivityType.MailOnly.GetDescription().ToLower() ||
                customerEditModel.Activity.ToLower() == UploadActivityType.None.GetDescription().ToLower() || customerEditModel.Activity.ToLower() == UploadActivityType.BothMailAndCall.GetDescription().ToLower()
                || customerEditModel.Activity.ToLower() == UploadActivityType.DoNotCallDoNotMail.GetDescription().ToLower()))
            {
                throw new InvalidOperationException("Activity value invalid.");
            }

            if (!string.IsNullOrEmpty(customerEditModel.PredictedZip))
            {
                var invalidZipMessage = _customerRegistrationService.ValidateZipCodes(customerEditModel.PredictedZip);
                if (!string.IsNullOrEmpty(invalidZipMessage))
                {
                    throw new InvalidOperationException(invalidZipMessage);
                }
            }

            //if (string.IsNullOrEmpty(customerEditModel.TargetYear))
            //{
            //    throw new InvalidOperationException("Target Year is required");
            //}

            if (!string.IsNullOrEmpty(customerEditModel.TargetYear))
            {
                int targetYear;
                var validTargetYear = int.TryParse(customerEditModel.TargetYear, out targetYear);
                if (!validTargetYear || targetYear < DateTime.Now.Year || targetYear > (DateTime.Now.Year + 2))
                {
                    throw new InvalidOperationException("Invalid Target Year");
                }
            }

            if (!isMemberUploadByAces && !string.IsNullOrEmpty(customerEditModel.Email) && !IsValidEmailAddress(customerEditModel.Email))
            {
                throw new InvalidOperationException("Invalid Customer Email Address.");
            }

            if (!isMemberUploadByAces && !string.IsNullOrEmpty(customerEditModel.AlternateEmail) && !IsValidEmailAddress(customerEditModel.AlternateEmail))
            {
                throw new InvalidOperationException("Invalid Customer Alternate Email Address.");
            }

            if (!isMemberUploadByAces && !string.IsNullOrEmpty(customerEditModel.PcpEmail) && !IsValidEmailAddress(customerEditModel.PcpEmail))
            {
                throw new InvalidOperationException("Invalid PCP Email Address.");
            }

            if (!isMemberUploadByAces)
            {
                if ((!string.IsNullOrEmpty(customerEditModel.BillingMemberId) || !string.IsNullOrEmpty(customerEditModel.BillingMemberPlan)) && (customerEditModel.BillingMemberPlanYear == null || customerEditModel.BillingMemberPlanYear == 0))
                {
                    throw new InvalidOperationException("Billing Year is required");
                }

                if (customerEditModel.BillingMemberPlanYear.HasValue && customerEditModel.BillingMemberPlanYear.Value > 0 && string.IsNullOrEmpty(customerEditModel.BillingMemberId) && string.IsNullOrEmpty(customerEditModel.BillingMemberPlan))
                {
                    throw new InvalidOperationException("Billing MemberID or Billing Plan Name or both is required");
                }

                if (!string.IsNullOrEmpty(customerEditModel.WarmTransferAllowed) && (customerEditModel.WarmTransferAllowed.ToLower() != "yes" && customerEditModel.WarmTransferAllowed.ToLower() != "no"))
                {
                    throw new InvalidOperationException("Invalid WarmTransfer Allowed Value");
                }

                if (!string.IsNullOrEmpty(customerEditModel.WarmTransferAllowed) && string.IsNullOrEmpty(customerEditModel.WarmTransferYear))
                {
                    throw new InvalidOperationException("WarmTransfer Year is required");
                }
                if (!string.IsNullOrEmpty(customerEditModel.WarmTransferYear))
                {
                    int warmTransferYear;
                    var validWarmTransferYear = int.TryParse(customerEditModel.WarmTransferYear, out warmTransferYear);
                    if (!validWarmTransferYear || warmTransferYear < DateTime.Now.Year || warmTransferYear > (DateTime.Now.Year + 2))
                    {
                        throw new InvalidOperationException("Invalid WarmTransfer Year");
                    }
                }

                //if (customerEditModel.RequiredTest != null && customerEditModel.RequiredTest.Any())
                //{
                //    var pairs = TestType.A1C.GetNameValuePairs();
                //    var requiredTestExists = pairs.Where(x => customerEditModel.RequiredTest.Contains(x.SecondValue.ToLower())).Select(x => x.SecondValue.ToLower());

                //    var testNotExist = string.Empty;

                //    if (requiredTestExists != null && requiredTestExists.Any() && (requiredTestExists.Count() != customerEditModel.RequiredTest.Count()))
                //    {
                //        var testNotExistInSystem = customerEditModel.RequiredTest.Where(x => !requiredTestExists.Contains(x.ToLower())).Select(x => x).ToArray();

                //        testNotExist = string.Join(",", testNotExistInSystem);
                //    }
                //    else if (requiredTestExists == null || !requiredTestExists.Any())
                //    {
                //        testNotExist = string.Join(",", customerEditModel.RequiredTest);
                //    }

                //    if (!string.IsNullOrEmpty(testNotExist))
                //        throw new InvalidOperationException(testNotExist + " test alias name does not exist in HIP (Required Test)");

                //    if (string.IsNullOrEmpty(customerEditModel.ForYear))
                //    {
                //        throw new InvalidOperationException("For Year is required");
                //    }
                //    int forYear;
                //    var validforYear = int.TryParse(customerEditModel.ForYear, out forYear);
                //    if (!validforYear || forYear < DateTime.Now.Year || forYear > (DateTime.Now.Year + 2))
                //    {
                //        throw new InvalidOperationException("Invalid For Year");
                //    }
                //}
            }

            if (string.IsNullOrEmpty(customerEditModel.EligibilityYear))
            {
                throw new InvalidOperationException("Eligibility Year is required");
            }

            int eligibilityYear;
            var validEligibilityYear = int.TryParse(customerEditModel.EligibilityYear, out eligibilityYear);
            if (!validEligibilityYear || eligibilityYear < DateTime.Now.Year || eligibilityYear > (DateTime.Now.Year + 2))
            {
                throw new InvalidOperationException("Invalid Eligibility Year");
            }

            var activityPairs = UploadActivityType.MailOnly.GetNameValuePairs();
            var activityId = activityPairs.First(x => customerEditModel.Activity.ToLower() == x.SecondValue.ToLower()).FirstValue;

            bool isNewCustomer = false;

            DateTime? dob = null;
            if (!string.IsNullOrEmpty(customerEditModel.Dob))
            {
                try
                {
                    dob = Convert.ToDateTime(customerEditModel.Dob);
                }
                catch (Exception ex)
                {
                    throw new Exception("DOB is not in correct format. Please Provide in MM/DD/YYYY", ex);
                }
            }

            if (isMemberUploadByAces)
            {

                if (string.IsNullOrEmpty(customerEditModel.Product))
                {
                    throw new InvalidOperationException("Product Type is required");
                }

                if (!string.IsNullOrEmpty(customerEditModel.Product))
                {
                    var productTypePairs = ProductType.CHA.GetNameValuePairs();

                    if (!productTypePairs.Any(x => x.SecondValue.ToLower() == customerEditModel.Product.ToLower()))
                        throw new InvalidOperationException("Invalid Product Type");
                }

                if (string.IsNullOrEmpty(customerEditModel.DNCFlag))
                {
                    throw new InvalidOperationException("DNC is required");
                }
                if (!string.IsNullOrEmpty(customerEditModel.DNCFlag))
                {
                    if (customerEditModel.DNCFlag.Trim() == "1")
                    {
                        customerEditModel.DNCFlag = "yes";
                    }
                    else if (customerEditModel.DNCFlag.Trim() == "0")
                    {
                        customerEditModel.DNCFlag = "no";
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid DNC, Only 0/1 is accepted.");
                    }

                }
            }
            var customer = _customerRepository.GetCustomerForCorporate(customerEditModel.FirstName, customerEditModel.MiddleName, customerEditModel.LastName,
                customerEditModel.Email, PhoneNumber.ToNumber(customerEditModel.PhoneHome), PhoneNumber.ToNumber(customerEditModel.PhoneCell),
                dob, corporateModel == null ? string.Empty : corporateModel.Tag, sb);

            if (customer == null && (sb != null && sb.ToString() != ""))
            {
                throw new Exception("");
            }
            else
            {
                sb = new StringBuilder();
            }

            //IEnumerable<EventCustomer> eventCustomers = null;

            //if (customer != null && customer.CustomerId > 0)
            //{
            //    eventCustomers = _eventCustomerPreApprovedTestService.GetFutureEventCustomers(customer.CustomerId);
            //}

            if (string.IsNullOrWhiteSpace(customerEditModel.State) || string.IsNullOrWhiteSpace(customerEditModel.City) || string.IsNullOrWhiteSpace(customerEditModel.Zip))
            {
                var addressErrorMessage = "";
                if (string.IsNullOrWhiteSpace(customerEditModel.State))
                    addressErrorMessage = addressErrorMessage + "State";

                if (string.IsNullOrWhiteSpace(customerEditModel.City))
                    addressErrorMessage = string.IsNullOrWhiteSpace(addressErrorMessage) ? "City" : addressErrorMessage + ", City";

                if (string.IsNullOrWhiteSpace(customerEditModel.Zip))
                    addressErrorMessage = string.IsNullOrWhiteSpace(addressErrorMessage) ? "Zip" : addressErrorMessage + ", Zip";

                addressErrorMessage = addressErrorMessage + " is required.";

                throw new Exception(addressErrorMessage);
            }

            AddressSanitizingInvalidZip(customerEditModel);

            if (customer != null && !customersWithAcesId.IsNullOrEmpty())
            {
                customersWithAcesId = customersWithAcesId.Where(x => x.CustomerId != customer.CustomerId).ToList();
            }

            if (!customersWithAcesId.IsNullOrEmpty())
            {
                customersWithAcesId.ForEach(x => x.AcesId = "");
            }

            using (var scope = new TransactionScope())
            {
                if (!customersWithAcesId.IsNullOrEmpty())
                {
                    foreach (var member in customersWithAcesId)
                    {
                        _customerService.SaveCustomerOnly(member, organizationRoleUserId);
                    }

                    customerWithSameAcesId.AcesId = customerEditModel.AcesId;
                    customerWithSameAcesId.CustomerId = customer != null ? customer.CustomerId : 0;
                    customerWithSameAcesId.CustomersWithSameAcesId = string.Join(",", customersWithAcesId.Select(x => x.CustomerId));
                }

                var updatedCustomer = _customerRegistrationService.RegisterCorporateCustomer(customer, customerEditModel, corporateModel == null ? string.Empty : corporateModel.Tag,
                    createdByOrgRoleUser, languages, labs, sb, activityId, source, out isNewCustomer);

                if (customTags != null && customTags.Any() && updatedCustomer != null)
                {
                    foreach (var customTag in customTags)
                    {
                        _corporateCustomerCustomTagService.Save(new CorporateCustomerCustomTag
                        {
                            CustomerId = updatedCustomer.CustomerId,
                            IsActive = true,
                            Tag = customTag,
                            DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(organizationRoleUserId), DateTime.Now, null)
                        });
                    }
                }

                customerEditModel.CustomerId = updatedCustomer.CustomerId;

                //if (!eventCustomers.IsNullOrEmpty())
                //{
                //    var list = _eventCustomerPreApprovedTestService.MarkcustomerForAdjustOrder(customerEditModel, eventCustomers, createdByOrgRoleUser, updatedCustomer, corporateModel.UploadCorporateId);

                //    if (!list.IsNullOrEmpty())
                //        adjustOrderForCustomerEditModel = adjustOrderForCustomerEditModel.Concat(list).ToList();
                //}

                scope.Complete();
            }

            UpdateNeedVerificationAddress(customerEditModel);

            if (isNewCustomer && customerList != null)
            {
                customerList.Add(customerEditModel.CustomerId);
            }

            UpdateCorporateMemberUpload(corporateUploadId, customerEditModel);

            customerIdWithSameAcesId = customerWithSameAcesId;
        }
        private bool IsValidEmailAddress(string email)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
                return regex.IsMatch(email.ToLower().Trim());
            }

            return true;
        }

        public MemberUploadDetailsListModel GetMemberUploadDetails(int pageNumber, int pageSize, MemberUploadDetailsListModelFilter filter, out int totalRecords)
        {
            filter.SourceId = (long)MemberUploadSource.Aces;
            var corporateUploads = (IReadOnlyCollection<CorporateUpload>)_corporateUploadRepository.GetByFilter(pageNumber, pageSize, filter, out totalRecords);

            if (corporateUploads == null || !corporateUploads.Any()) return null;

            var successfileIds = corporateUploads.Select(s => s.FileId).ToArray();
            var failedfileIds = corporateUploads.Where(x => x.LogFileId.HasValue).Select(s => s.LogFileId.Value).ToArray();
            var fileIds = successfileIds.Concat(failedfileIds).ToArray();
            // var mediaLocation = filter.SourceId == (long)MemberUploadSource.Aces ? _mediaRepository.GetMemberUploadbyAcesFolderLocation() : _mediaRepository.GetUploadCsvMediaFileLocation();
            var mediaLocation = _mediaRepository.GetMemberUploadbyAcesFolderLocation();


            IEnumerable<FileModel> fileModels = null;
            if (fileIds != null && fileIds.Any())
            {
                var files = _fileRepository.GetByIds(fileIds);

                if (files != null && files.Any())
                {
                    fileModels = GetFileModelFromFile(files, mediaLocation);
                }
            }

            return GetListModel(fileModels, corporateUploads);
        }

        private IEnumerable<FileModel> GetFileModelFromFile(IEnumerable<File> files, MediaLocation location)
        {
            var collection = new List<FileModel>();
            files.ToList().ForEach(f =>
            {
                var fileModel = new FileModel
                {
                    Id = f.Id,
                    Caption = Path.GetFileNameWithoutExtension(f.Path),
                    FileName = f.Path,
                    FileSize = f.FileSize,
                    FileType = (long)f.Type,
                    PhisicalPath = f.Path,
                    UploadedBy = f.UploadedBy.Id,
                    Url = location.Url
                };
                collection.Add(fileModel);
            });
            return collection;
        }

        private MemberUploadDetailsListModel GetListModel(IEnumerable<FileModel> fileModels, IEnumerable<CorporateUpload> corporateUpload)
        {
            var model = new MemberUploadDetailsListModel();
            var collection = new List<MemberUploadDetailsViewModel>();
            corporateUpload.ToList().ForEach(eu =>
            {


                var successFile = (from f in fileModels where f.Id == eu.FileId select f).Single();

                FileModel failedFile = null;

                if (eu.LogFileId.HasValue)
                {
                    failedFile = (from f in fileModels where f.Id == eu.LogFileId select f).Single();
                }

                var memberUploadDetailsViewModel = new MemberUploadDetailsViewModel
                {
                    File = successFile,
                    SuccessfullCustomer = eu.SuccessfullUploadCount,
                    FailedCustomer = eu.FailedUploadCount,
                    UploadTime = eu.UploadTime,
                    FailedFile = failedFile

                };

                collection.Add(memberUploadDetailsViewModel);
            });

            model.Collection = collection;
            return model;
        }

        private void UpdateNeedVerificationAddress(CorporateCustomerEditModel customerEditModel)
        {
            var addressIds = new List<long>();
            if (customerEditModel.IsCustomerZipInvalid)
            {
                addressIds.Add(customerEditModel.CustomerAddressId);
            }
            if (customerEditModel.IsPCPZipInvalid)
            {
                addressIds.Add(customerEditModel.PCPAddressId);
            }
            if (customerEditModel.IsPCPMailingZipInvalid)
            {
                addressIds.Add(customerEditModel.PCPMailingAddressId);
            }
            if (!addressIds.IsNullOrEmpty())
            {
                _addressRepository.UpdateNeedVerficationbyAddressIds(addressIds);
            }
        }

        private void AddressSanitizingInvalidZip(CorporateCustomerEditModel customerEditModel)
        {
            if (!string.IsNullOrEmpty(customerEditModel.State) && customerEditModel.State.Length == 2)
            {
                var stateNameFromStateCode = _stateRepository.GetStatebyCode(customerEditModel.State);
                if (stateNameFromStateCode == null)
                    throw new Exception("Invalid State Name:" + customerEditModel.State);
                else
                    customerEditModel.State = stateNameFromStateCode.Name;
            }

            var customerAddress = _massRegistrationEditModelFactory.CreateAddress(customerEditModel, MemberUploadAddress.CustomerAddress.ToString());
            _addressService.GetAddressSanitizingInvalidZip(customerAddress, customerEditModel, MemberUploadAddress.CustomerAddress.ToString());

            if (customerEditModel.PcpAddress1.Length > 0 && customerEditModel.PcpState.Length > 0 && customerEditModel.PcpCity.Length > 0 && customerEditModel.PcpZip.Length > 0)
            {
                if (!string.IsNullOrEmpty(customerEditModel.PcpState) && customerEditModel.PcpState.Length == 2)
                {
                    var stateNameFromStateCode = _stateRepository.GetStatebyCode(customerEditModel.PcpState);
                    if (stateNameFromStateCode == null)
                        throw new Exception("Invalid State Name:" + customerEditModel.PcpState);
                    else
                        customerEditModel.PcpState = stateNameFromStateCode.Name;
                }
                var pcpAddress = _massRegistrationEditModelFactory.CreateAddress(customerEditModel, MemberUploadAddress.PcpAddress.ToString());
                _addressService.GetAddressSanitizingInvalidZip(pcpAddress, customerEditModel, MemberUploadAddress.PcpAddress.ToString());
            }
            if ((customerEditModel.PCPMailingAddress1.Length > 0 && customerEditModel.PCPMailingState.Length > 0 && customerEditModel.PCPMailingCity.Length > 0 && customerEditModel.PCPMailingZip.Length > 0))
            {

                if (!string.IsNullOrEmpty(customerEditModel.PCPMailingState) && customerEditModel.PCPMailingState.Length == 2)
                {
                    var stateNameFromStateCode = _stateRepository.GetStatebyCode(customerEditModel.PCPMailingState);
                    if (stateNameFromStateCode == null)
                        throw new Exception("Invalid State Name:" + customerEditModel.PCPMailingState);
                    else
                        customerEditModel.PCPMailingState = stateNameFromStateCode.Name;
                }
                var pcpMailingAddress = _massRegistrationEditModelFactory.CreateAddress(customerEditModel, MemberUploadAddress.PcpMailingAddress.ToString());
                _addressService.GetAddressSanitizingInvalidZip(pcpMailingAddress, customerEditModel, MemberUploadAddress.PcpMailingAddress.ToString());
            }
        }

        private void UpdateCorporateMemberUpload(long corportateUploadId, CorporateCustomerEditModel customerEditModel)
        {
            _memberUploadLogRepository.Save(new MemberUploadLog
            {
                CorporateUploadId = corportateUploadId,
                CustomerId = customerEditModel.CustomerId,
                IsCustomerZipInvalid = customerEditModel.IsCustomerZipInvalid,
                IsPCPZipInvalid = customerEditModel.IsPCPZipInvalid,
                IsPCPMailingZipInvalid = customerEditModel.IsPCPMailingZipInvalid,
                NewInsertedZipIds = customerEditModel.NewInsertedZipIds,
                NewInsertedCityIds = customerEditModel.NewInsertedCityIds,
            });

        }

        public string DownlaodFilePath(string FileName)
        {
            return Path.Combine(_mediaRepository.GetMemberUploadbyAcesFolderLocation().PhysicalPath, FileName);
        }

    }

}
