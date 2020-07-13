using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Core.OutboundReport.Enum;
using Falcon.App.Core.OutboundReport.ViewModels;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.Interfaces;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using File = Falcon.App.Core.Application.Domain.File;
using Falcon.App.Core.Medical;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.OutboundReport.Impl
{
    [DefaultImplementation]
    public class ChaseOutboundParsePollingAgent : IChaseOutboundParsePollingAgent
    {
        private readonly IOutboundUploadRepository _outboundUploadRepository;
        private readonly IUniqueItemRepository<File> _fileRepository;
        private readonly IPipeDelimitedReportHelper _pipeDelimitedReportHelper;
        private readonly ILanguageRepository _languageRepository;
        private readonly IChaseOutboundFactory _chaseOutboundFactory;
        private readonly IChaseProductRepository _chaseProductRepository;
        private readonly IChaseChannelLevelRepository _chaseChannelLevelRepository;
        private readonly IChaseGroupRepository _chaseGroupRepository;
        private readonly IChaseCampaignRepository _chaseCampaignRepository;
        private readonly IChaseCampaignTypeRepository _chaseCampaignTypeRepository;
        private readonly IRelationshipRepository _relationshipRepository;
        private readonly IMediaRepository _mediaRepository;
        private readonly IChaseOutboundRepository _chaseOutboundRepository;
        private readonly IUniqueItemRepository<CorporateAccount> _corporateAccountRepository;
        private readonly ILabRepository _labRepository;
        private readonly ICustomerRegistrationService _customerRegistrationService;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ILogger _logger;
        private readonly IAddressService _addressService;
        private readonly ICustomerRepository _customerRepository;
        private readonly ICorporateCustomerCustomTagService _corporateCustomerCustomTagService;
        private readonly IActivityTypeRepository _activityTypeRepository;

        private readonly string _accountIds;

        private const string IndicatorYes = "yes";
        private const string IndicatorY = "y";
        private const string LogHeader = ChaseOutboundColumn.TenantId + "|" + ChaseOutboundColumn.ClientId + "|" + ChaseOutboundColumn.CampaignId + "|" + ChaseOutboundColumn.IndividualIdNumber + "|" + ChaseOutboundColumn.ContractNumber + "|" +
                                            ChaseOutboundColumn.ContractPersonNumber + "|" + ChaseOutboundColumn.ConsumerId + "|" + "ErrorMessage";

        public ChaseOutboundParsePollingAgent(IOutboundUploadRepository outboundUploadRepository, IUniqueItemRepository<File> fileRepository, IPipeDelimitedReportHelper pipeDelimitedReportHelper, ILogManager logManager,
            ILanguageRepository languageRepository, IChaseOutboundFactory chaseOutboundFactory, IChaseProductRepository chaseProductRepository, IChaseChannelLevelRepository chaseChannelLevelRepository,
            IChaseGroupRepository chaseGroupRepository, IChaseCampaignRepository chaseCampaignRepository, IChaseCampaignTypeRepository chaseCampaignTypeRepository, IRelationshipRepository relationshipRepository, IMediaRepository mediaRepository,
            IChaseOutboundRepository chaseOutboundRepository, ISettings settings, IUniqueItemRepository<CorporateAccount> corporateAccountRepository, ILabRepository labRepository, ICustomerRegistrationService customerRegistrationService,
            IOrganizationRoleUserRepository organizationRoleUserRepository, IStateRepository stateRepository, ICustomerRepository customerRepository, ICorporateCustomerCustomTagService corporateCustomerCustomTagService, IAddressService addressService, IActivityTypeRepository activityTypeRepository)
        {
            _outboundUploadRepository = outboundUploadRepository;
            _fileRepository = fileRepository;
            _pipeDelimitedReportHelper = pipeDelimitedReportHelper;
            _languageRepository = languageRepository;
            _chaseOutboundFactory = chaseOutboundFactory;
            _chaseProductRepository = chaseProductRepository;
            _chaseChannelLevelRepository = chaseChannelLevelRepository;
            _chaseGroupRepository = chaseGroupRepository;
            _chaseCampaignRepository = chaseCampaignRepository;
            _chaseCampaignTypeRepository = chaseCampaignTypeRepository;
            _relationshipRepository = relationshipRepository;
            _mediaRepository = mediaRepository;
            _chaseOutboundRepository = chaseOutboundRepository;
            _corporateAccountRepository = corporateAccountRepository;
            _labRepository = labRepository;
            _customerRegistrationService = customerRegistrationService;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _stateRepository = stateRepository;
            _customerRepository = customerRepository;
            _corporateCustomerCustomTagService = corporateCustomerCustomTagService;
            _addressService = addressService;
            _logger = logManager.GetLogger("Chase_Outbound_Import");
            _activityTypeRepository = activityTypeRepository;
            _accountIds = settings.FloridaBlueAccountId;
        }

        public void PollForOutboundChase()
        {
            var outboundUploads = _outboundUploadRepository.GetAllUploadedFilesByType((long)OutboundUploadType.ChaseOutbound);
            if (outboundUploads == null || !outboundUploads.Any())
            {
                _logger.Info("No new files uploaded.");
                return;
            }

            var accountIds = _accountIds.Split(',');

            //var activityTypes = _activityTypeRepository.GetAll();

            foreach (var accountId in accountIds)
            {
                var account = _corporateAccountRepository.GetById(Convert.ToInt32(accountId));

                var fileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "Chase");
                var archivedFileLocation = _mediaRepository.GetOutboundUploadMediaFileLocation(account.FolderName, "ChaseArchived");

                foreach (var outboundUpload in outboundUploads)
                {
                    try
                    {
                        var file = GetFile(outboundUpload.FileId);

                        if (!System.IO.File.Exists(fileLocation.PhysicalPath + file.Path))
                        {
                            _logger.Info("File not found : " + fileLocation.PhysicalPath + file.Path);
                            continue;
                        }

                        _logger.Info("Importing File : " + file.Path);

                        outboundUpload.StatusId = (long)OutboundUploadStatus.Parsing;
                        outboundUpload.ParseStartTime = DateTime.Now;
                        _outboundUploadRepository.Save(outboundUpload);

                        DataTable table = _pipeDelimitedReportHelper.Read(fileLocation.PhysicalPath + file.Path);

                        if (table.Rows.Count <= 0)
                        {
                            _logger.Info("No rows found.");
                            outboundUpload.ParseEndTime = DateTime.Now;
                            outboundUpload.StatusId = (long)OutboundUploadStatus.Parsed;
                            _outboundUploadRepository.Save(outboundUpload);
                            continue;
                        }

                        var csvStringBuilder = new StringBuilder();
                        csvStringBuilder.Append(LogHeader + Environment.NewLine);

                        var languages = _languageRepository.GetAll();
                        var labs = _labRepository.GetAll();

                        var successRows = 0;
                        foreach (DataRow row in table.Rows)
                        {
                            var model = GetChaseOutboundModel(row);
                            var errorRow = model.TenantId + "|" + model.ClientId + "|" + model.CampaignId + "|" + model.IndividualId + "|" + model.ContractNumber + "|" + model.ContractPersonNumber + "|" + model.ConsumerId;
                            try
                            {
                                if (!string.IsNullOrEmpty(model.HomeAddressState))
                                {
                                    try
                                    {
                                        var state = _stateRepository.GetStatebyCode(model.HomeAddressState) ?? _stateRepository.GetState(model.HomeAddressState);
                                        if (state != null)
                                        {
                                            model.HomeAddressState = state.Name;
                                        }
                                        else
                                        {
                                            csvStringBuilder.Append(errorRow + "|" + "Invalid Home_Addr_State" + Environment.NewLine);
                                            continue;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error("Error importing data.");
                                        _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                        csvStringBuilder.Append(errorRow + "|" + ex.Message + Environment.NewLine);
                                        continue;
                                    }
                                }

                                if (!string.IsNullOrEmpty(model.AddressState))
                                {
                                    try
                                    {
                                        var state = _stateRepository.GetStatebyCode(model.AddressState) ?? _stateRepository.GetState(model.AddressState);
                                        if (state != null)
                                        {
                                            model.AddressState = state.Name;
                                        }
                                        else
                                        {
                                            csvStringBuilder.Append(errorRow + "|" + "Invalid Addr_State" + Environment.NewLine);
                                            continue;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error("Error importing data.");
                                        _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                        csvStringBuilder.Append(errorRow + "|" + ex.Message + Environment.NewLine);
                                        continue;
                                    }
                                }

                                if (!string.IsNullOrEmpty(model.ProviderOfRecordAddressState))
                                {
                                    try
                                    {
                                        var state = _stateRepository.GetStatebyCode(model.ProviderOfRecordAddressState) ?? _stateRepository.GetState(model.ProviderOfRecordAddressState);
                                        if (state != null)
                                        {
                                            model.ProviderOfRecordAddressState = state.Name;
                                        }
                                        else
                                        {
                                            csvStringBuilder.Append(errorRow + "|" + "Invalid Provider_Addr_State" + Environment.NewLine);
                                            continue;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        _logger.Error("Error importing data.");
                                        _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                        csvStringBuilder.Append(errorRow + "|" + ex.Message + Environment.NewLine);
                                        continue;
                                    }
                                }

                                var chaseOutbound = _chaseOutboundFactory.Create(model);

                                var corporateCustomerEditModel = _chaseOutboundFactory.CreateCorporateCustomerEditModel(model);

                                var createdBy = _organizationRoleUserRepository.GetOrganizationRoleUser(1);
                                StringBuilder sb = new StringBuilder();

                                //var activityType = activityTypes.FirstOrDefault(x => x.Alias == corporateCustomerEditModel.Activity);

                                bool isNewCustomer = false;
                                DateTime? dob = null;

                                if (!string.IsNullOrEmpty(corporateCustomerEditModel.Dob))
                                {
                                    try
                                    {
                                        dob = Convert.ToDateTime(corporateCustomerEditModel.Dob);
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Exception("DOB is not in correct format. Please Provide in MM/DD/YYYY", ex);
                                    }
                                }

                                var customer = _customerRepository.GetCustomerForCorporate(corporateCustomerEditModel.FirstName, corporateCustomerEditModel.MiddleName,
                                    corporateCustomerEditModel.LastName, corporateCustomerEditModel.Email, PhoneNumber.ToNumber(corporateCustomerEditModel.PhoneHome),
                                    PhoneNumber.ToNumber(corporateCustomerEditModel.PhoneCell), dob, account.Tag, sb);

                                var updatedCustomer = _customerRegistrationService.RegisterCorporateCustomer(customer, corporateCustomerEditModel, account.Tag, createdBy, languages, labs,
                                    sb, (long)UploadActivityType.BothMailAndCall, null, out isNewCustomer);

                                chaseOutbound.CustomerId = updatedCustomer.CustomerId;

                                var address = new Address(model.AddressLine1, model.AddressLine2, model.AddressCity,
                                    model.AddressState, model.AddressZipCode, "USA");


                                address = _addressService.SaveAfterSanitizing(address);
                                if (address.Id > 0)
                                {
                                    _customerRepository.UpdateBillingAddress(updatedCustomer.CustomerId, address.Id);
                                }
                                var customTags = model.CustomTags.Split(',');
                                if (customTags != null && customTags.Any() && updatedCustomer != null)
                                {
                                    foreach (var customTag in customTags)
                                    {
                                        _corporateCustomerCustomTagService.Save(new CorporateCustomerCustomTag
                                        {
                                            CustomerId = updatedCustomer.CustomerId,
                                            IsActive = true,
                                            Tag = customTag,
                                            DataRecorderMetaData = new DataRecorderMetaData(new OrganizationRoleUser(createdBy.Id), DateTime.Now, null)
                                        });
                                    }
                                }

                                if (!string.IsNullOrEmpty(model.RelationshipCode) || !string.IsNullOrEmpty(model.RelationshipDescription))
                                {
                                    var relationship = GetRelationship(model.RelationshipCode, model.RelationshipDescription);
                                    chaseOutbound.RelationshipId = relationship.Id;
                                }

                                chaseOutbound = _chaseOutboundRepository.Save(chaseOutbound);
                                // _chaseProductRepository.DeleteByCustomerId(chaseOutbound.CustomerId);

                                if (!string.IsNullOrEmpty(model.ProductLevel1))
                                    SaveChaseProduct(model.ProductLevel1, 1, chaseOutbound.CustomerId, chaseOutbound.Id);
                                if (!string.IsNullOrEmpty(model.ProductLevel2))
                                    SaveChaseProduct(model.ProductLevel2, 2, chaseOutbound.CustomerId, chaseOutbound.Id);
                                if (!string.IsNullOrEmpty(model.ProductLevel3))
                                    SaveChaseProduct(model.ProductLevel3, 3, chaseOutbound.CustomerId, chaseOutbound.Id);
                                if (!string.IsNullOrEmpty(model.ProductLevel4))
                                    SaveChaseProduct(model.ProductLevel4, 4, chaseOutbound.CustomerId, chaseOutbound.Id);
                                if (!string.IsNullOrEmpty(model.ProductLevel5))
                                    SaveChaseProduct(model.ProductLevel5, 5, chaseOutbound.CustomerId, chaseOutbound.Id);

                                // _chaseChannelLevelRepository.DeleteByCustomerId(chaseOutbound.CustomerId);

                                if (!string.IsNullOrEmpty(model.ChannelLevel2))
                                    SaveChaseChannel(model.ChannelLevel2, 2, chaseOutbound.CustomerId, chaseOutbound.Id);
                                if (!string.IsNullOrEmpty(model.ChannelLevel3))
                                    SaveChaseChannel(model.ChannelLevel3, 3, chaseOutbound.CustomerId, chaseOutbound.Id);

                                if (!string.IsNullOrEmpty(model.GroupName) || !string.IsNullOrEmpty(model.GroupNumber) || !string.IsNullOrEmpty(model.GroupDivision))
                                {
                                    var chaseGroup = GetChaseGroup(model.GroupName, model.GroupNumber, model.GroupDivision);
                                    chaseOutbound.ChaseGroupId = chaseGroup.Id;
                                }

                                if (string.IsNullOrEmpty(model.CampaignId) || string.IsNullOrEmpty(model.CampaignName))
                                {
                                    _logger.Info("Campaign Id/Name missing. Incomplete Data");
                                    /*csvStringBuilder.Append(errorRow + "|" + "Campaign Id/Name missing. Incomplete Data." + Environment.NewLine);
                                    continue;*/
                                }
                                else
                                {
                                    SaveCampaign(model, chaseOutbound.CustomerId, chaseOutbound.Id);
                                }

                                if (!string.IsNullOrEmpty(model.ForecastedOutreachDate))
                                {
                                    try
                                    {
                                        chaseOutbound.ForecastedOutreachDate = Convert.ToDateTime(model.ForecastedOutreachDate);
                                    }
                                    catch (Exception)
                                    {
                                        csvStringBuilder.Append(errorRow + "|" + "Forecasted_Outreach_Date is not in correct format. Please Provide in MM/DD/YYYY" + Environment.NewLine);
                                        continue;
                                    }
                                }
                                if (!string.IsNullOrEmpty(model.RecordProcessDate))
                                {
                                    try
                                    {
                                        chaseOutbound.RecordProcessDate = Convert.ToDateTime(model.RecordProcessDate);
                                    }
                                    catch (Exception)
                                    {
                                        csvStringBuilder.Append(errorRow + "|" + "Record_Process_Date is not in correct format. Please Provide in MM/DD/YYYY" + Environment.NewLine);
                                        continue;
                                    }
                                }



                                successRows++;
                            }
                            catch (Exception ex)
                            {
                                _logger.Error("Error importing data.");
                                _logger.Error("Message: " + ex.Message + "\nStack Trace; " + ex.StackTrace);
                                csvStringBuilder.Append(errorRow + "|" + ex.Message + Environment.NewLine);
                            }
                        }

                        if (successRows < table.Rows.Count)
                        {
                            var logFileName = _pipeDelimitedReportHelper.GetReportName(ReportType.Exception);

                            var logFile = SaveLogFile(fileLocation.PhysicalPath + logFileName + ".txt", csvStringBuilder);
                            outboundUpload.LogFileId = logFile.Id;
                        }

                        outboundUpload.SuccessUploadCount = successRows;
                        outboundUpload.FailedUploadCount = table.Rows.Count - successRows;
                        outboundUpload.ParseEndTime = DateTime.Now;
                        outboundUpload.StatusId = successRows > 0 ? (long)OutboundUploadStatus.Parsed : (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(outboundUpload);

                        if (successRows > 1)
                        {
                            System.IO.File.Move(fileLocation.PhysicalPath + file.Path, archivedFileLocation.PhysicalPath + file.Path);
                            ((IFileRepository)_fileRepository).MarkasArchived(file.Id);
                        }
                    }
                    catch (Exception ex)
                    {
                        outboundUpload.StatusId = (long)OutboundUploadStatus.ParseFailed;
                        _outboundUploadRepository.Save(outboundUpload);
                        _logger.Error(string.Format("while Parsing File"));
                        _logger.Error("Ex Message" + ex.Message);
                        _logger.Error("Ex Stack Trace " + ex.StackTrace);
                    }
                }
            }
        }

        private File GetFile(long fileId)
        {
            var file = _fileRepository.GetById(fileId);

            return file;
        }

        private Relationship GetRelationship(string code, string description)
        {
            var relationship = _relationshipRepository.GetByCode(code) ?? _relationshipRepository.Save(new Relationship
            {
                Code = code,
                Description = description,
                Alias = description.Trim().Replace(" ", "")
            });

            return relationship;
        }

        private void SaveCampaign(ChaseOutboundViewModel model, long customerId, long chaseOutboundId)
        {
            var chaseCampaignType = _chaseCampaignTypeRepository.GetByName(model.CampaignType) ?? _chaseCampaignTypeRepository.Save(new ChaseCampaignType { Name = model.CampaignType, Alias = model.CampaignType.Trim().Replace(" ", "") });

            var chaseCampaign = _chaseCampaignRepository.Save(new ChaseCampaign
            {
                CampaignId = model.CampaignId,
                CampaignFileId = model.CampaignFileId,
                CampaignName = model.CampaignName,
                CampaignCode = model.CampaignCode,
                CampaignHouseholdId = model.CampaignHouseholdId,
                ChaseCampaignTypeId = chaseCampaignType.Id
            });

            //  _chaseCampaignRepository.DeactivateAllCustomerCampaigns(customerId);

            _chaseCampaignRepository.SaveCustomerChaseCampaign(new CustomerChaseCampaign
            {
                ChaseOutboundId = chaseOutboundId,
                CustomerId = customerId,
                ChaseCampaignId = chaseCampaign.Id,
                IsActive = true
            });
        }

        private ChaseGroup GetChaseGroup(string groupName, string groupNumber, string groupDivision)
        {
            var chaseGroup = _chaseGroupRepository.GetByNameNumberAndDivision(groupName, groupNumber, groupDivision);

            if (chaseGroup == null)
            {
                chaseGroup = new ChaseGroup
                {
                    Name = groupName,
                    Number = groupNumber,
                    Division = groupDivision
                };

                chaseGroup = _chaseGroupRepository.Save(chaseGroup);
            }

            return chaseGroup;
        }

        private ChaseOutboundViewModel GetChaseOutboundModel(DataRow row)
        {
            var model = new ChaseOutboundViewModel
            {
                TenantId = GetRowValue(row, ChaseOutboundColumn.TenantId),
                CampaignId = GetRowValue(row, ChaseOutboundColumn.CampaignId),
                IndividualId = GetRowValue(row, ChaseOutboundColumn.IndividualIdNumber),
                VendorCD = GetRowValue(row, ChaseOutboundColumn.VendorCd),
                ClientId = GetRowValue(row, ChaseOutboundColumn.ClientId),
                ContractNumber = GetRowValue(row, ChaseOutboundColumn.ContractNumber),
                ContractPersonNumber = GetRowValue(row, ChaseOutboundColumn.ContractPersonNumber),
                ConsumerId = GetRowValue(row, ChaseOutboundColumn.ConsumerId),
                CampaignFileId = GetRowValue(row, ChaseOutboundColumn.CampaignFileId),
                CampaignName = GetRowValue(row, ChaseOutboundColumn.CampaignName),
                BusinessCaseId = GetRowValue(row, ChaseOutboundColumn.BusinessCaseId),
                CampaignCode = GetRowValue(row, ChaseOutboundColumn.CampaignCode),
                CampaignHouseholdId = GetRowValue(row, ChaseOutboundColumn.CampaignHouseholdId),
                CampaignType = GetRowValue(row, ChaseOutboundColumn.CampaignType),
                CampaignMemberId = GetRowValue(row, ChaseOutboundColumn.CampaignMemberId),
                DistributionId = GetRowValue(row, ChaseOutboundColumn.DistributionId),
                SubscriberIndicator = GetRowValue(row, ChaseOutboundColumn.SubcriberIndicator).ToLower() == IndicatorY,
                FirstName = GetRowValue(row, ChaseOutboundColumn.FirstName),
                MiddleInitial = GetRowValue(row, ChaseOutboundColumn.MiddleInitial),
                LastName = GetRowValue(row, ChaseOutboundColumn.LastName),
                DateOfBirth = GetRowValue(row, ChaseOutboundColumn.BirthDate),
                GenderCode = GetRowValue(row, ChaseOutboundColumn.GenderCode),
                Ssn = GetRowValue(row, ChaseOutboundColumn.Ssn),
                AddressLine1 = GetRowValue(row, ChaseOutboundColumn.AddressLine1),
                AddressLine2 = GetRowValue(row, ChaseOutboundColumn.AddressLine2),
                AddressCity = GetRowValue(row, ChaseOutboundColumn.AddressCity),
                AddressState = GetRowValue(row, ChaseOutboundColumn.AddressState),
                AddressZipCode = GetRowValue(row, ChaseOutboundColumn.AddressZipCode),
                AddressCountyName = GetRowValue(row, ChaseOutboundColumn.AddressCountyName),
                AddressCountyCode = GetRowValue(row, ChaseOutboundColumn.AddressCountyCode),
                Email = GetRowValue(row, ChaseOutboundColumn.AddressEmail),
                RelationshipCode = GetRowValue(row, ChaseOutboundColumn.RelationshipCode),
                RelationshipDescription = GetRowValue(row, ChaseOutboundColumn.RelationshipDescription),
                IdentifiedIndicator = GetRowValue(row, ChaseOutboundColumn.IdentifiedIndicator).ToLower() == IndicatorYes,
                PhoneNumber = GetRowValue(row, ChaseOutboundColumn.PhoneContactNumber),
                WorkPhoneNumber = GetRowValue(row, ChaseOutboundColumn.WorkPhoneNumber),
                OutboundCallIndicator = GetRowValue(row, ChaseOutboundColumn.OutboundCallIndicator).ToLower() == IndicatorY,
                WirelessIndicator = GetRowValue(row, ChaseOutboundColumn.WirelessIndicator).ToLower() == IndicatorY,
                LanguagePreferenceCode = GetRowValue(row, ChaseOutboundColumn.LanguagePreferenceCode),
                PriorityCode = GetRowValue(row, ChaseOutboundColumn.PriorityCode),
                KeyCode = GetRowValue(row, ChaseOutboundColumn.KeyCode),
                MedicareIndicator = GetRowValue(row, ChaseOutboundColumn.MedicareIndicator).ToLower() == IndicatorY,
                GroupNumber = GetRowValue(row, ChaseOutboundColumn.GroupNumber),
                GroupDivision = GetRowValue(row, ChaseOutboundColumn.GroupDivision),
                GroupName = GetRowValue(row, ChaseOutboundColumn.GroupName),
                HmoLobIndicator = GetRowValue(row, ChaseOutboundColumn.HmoLobIndicator).ToLower() == IndicatorY,
                ProductLevel1 = GetRowValue(row, ChaseOutboundColumn.ProductLevel1),
                ProductLevel2 = GetRowValue(row, ChaseOutboundColumn.ProductLevel2),
                ProductLevel3 = GetRowValue(row, ChaseOutboundColumn.ProductLevel3),
                ProductLevel4 = GetRowValue(row, ChaseOutboundColumn.ProductLevel4),
                ProductLevel5 = GetRowValue(row, ChaseOutboundColumn.ProductLevel5),
                Hicn = GetRowValue(row, ChaseOutboundColumn.Hicn),
                ReferMemberTo = GetRowValue(row, ChaseOutboundColumn.ReferMemberTo),
                ProviderOfRecordFullName = GetRowValue(row, ChaseOutboundColumn.ProviderOfRecordFullName),
                ProviderOfRecordPhoneNumber = GetRowValue(row, ChaseOutboundColumn.ProviderOfRecordPhoneNumber),
                ProviderOfRecordGroupName = GetRowValue(row, ChaseOutboundColumn.ProviderOfRecordGroupName),
                ProviderOfRecordGroupNumber = GetRowValue(row, ChaseOutboundColumn.ProviderOfRecordGroupNumber),
                ProviderOfRecordAddressLine1 = GetRowValue(row, ChaseOutboundColumn.ProviderAddressLine1),
                ProviderOfRecordAddressLine2 = GetRowValue(row, ChaseOutboundColumn.ProviderAddressLine2),
                ProviderOfRecordAddressCity = GetRowValue(row, ChaseOutboundColumn.ProviderAddressCity),
                ProviderOfRecordAddressState = GetRowValue(row, ChaseOutboundColumn.ProviderAddressState),
                ProviderOfRecordAddressZipCode = GetRowValue(row, ChaseOutboundColumn.ProviderAddressZipCode),
                ChannelLevel2 = GetRowValue(row, ChaseOutboundColumn.ChannelLevel2),
                ChannelLevel3 = GetRowValue(row, ChaseOutboundColumn.ChannelLevel3),
                ClosestRetailCenter = GetRowValue(row, ChaseOutboundColumn.ClosestRetailCenter),
                ConfidenceScore = GetRowValue(row, ChaseOutboundColumn.ConfidenceScore),
                LocationCode = GetRowValue(row, ChaseOutboundColumn.LocationCode),
                ForecastedOutreachDate = GetRowValue(row, ChaseOutboundColumn.ForecastedOutreachDate),
                RecordProcessDate = GetRowValue(row, ChaseOutboundColumn.RecordProcessDate),
                AgentContextNameValueSet = GetRowValue(row, ChaseOutboundColumn.AgentContextNameValueSet),
                HomeAddressLine1 = GetRowValue(row, ChaseOutboundColumn.HomeAddressLine1),
                HomeAddressLine2 = GetRowValue(row, ChaseOutboundColumn.HomeAddressLine2),
                HomeAddressCity = GetRowValue(row, ChaseOutboundColumn.HomeAddressCity),
                HomeAddressState = GetRowValue(row, ChaseOutboundColumn.HomeAddressState),
                HomeAddressZipCode = GetRowValue(row, ChaseOutboundColumn.HomeAddressZipCode),
                HomeAddressCountyName = GetRowValue(row, ChaseOutboundColumn.HomeAddressCountyName),
                HomeAddressCountyCode = GetRowValue(row, ChaseOutboundColumn.HomeAddressCountyCode),
                CustomTags = GetRowValue(row, ChaseOutboundColumn.CustomTags, false)
            };

            return model;
        }

        private void SaveChaseProduct(string name, int level, long customerId, long chaseOutboundId)
        {
            var chaseProduct = _chaseProductRepository.GetByNameAndLevel(name, level);

            if (chaseProduct == null)
            {
                chaseProduct = new ChaseProduct
                {
                    Name = name,
                    ProductLevel = level,
                };

                chaseProduct = _chaseProductRepository.Save(chaseProduct);
            }

            _chaseProductRepository.SaveCustomerChaseProduct(new CustomerChaseProduct
            {
                ChaseOutboundId = chaseOutboundId,
                CustomerId = customerId,
                ChaseProductId = chaseProduct.Id
            });
        }

        private void SaveChaseChannel(string channelName, int level, long customerId, long chaseOutboundId)
        {
            var chaseChannel = _chaseChannelLevelRepository.GetByNameAndLevel(channelName, level);

            if (chaseChannel == null)
            {
                chaseChannel = new ChaseChannelLevel
                {
                    ChannelName = channelName,
                    ChannelLevel = level,
                };

                chaseChannel = _chaseChannelLevelRepository.Save(chaseChannel);
            }

            _chaseChannelLevelRepository.SaveCustomerChaseChannel(new CustomerChaseChannel
            {
                ChaseOutboundId = chaseOutboundId,
                CustomerId = customerId,
                ChaseChannelLevelId = chaseChannel.Id
            });
        }

        private static string GetRowValue(DataRow row, string fieldName, bool format = true)
        {
            if (row == null || row[fieldName] == null || row[fieldName] == DBNull.Value) return string.Empty;
            if (format)
                return FormatSentence(row[fieldName].ToString().Trim());
            return row[fieldName].ToString().Trim();
        }

        private static string FormatSentence(string source)
        {
            var words = source.Split(' ').Select(t => t.ToCharArray()).ToList();
            words.ForEach(t =>
            {
                for (int i = 0; i < t.Length; i++)
                {
                    t[i] = i.Equals(0) ? char.ToUpper(t[i]) : char.ToLower(t[i]);
                }
            });
            return string.Join(" ", words.Select(t => new string(t)));
        }

        private File SaveLogFile(string logFilePath, StringBuilder csvStringBuilder)
        {
            WriteCsv(logFilePath, csvStringBuilder);

            var failedRecords = new FileInfo(logFilePath);

            var file = new File
            {
                Path = failedRecords.Name,
                FileSize = failedRecords.Length,
                Type = FileType.Csv,
                UploadedBy = new OrganizationRoleUser(1),
                UploadedOn = DateTime.Now
            };
            file = _fileRepository.Save(file);

            return file;
        }

        private void WriteCsv(string fileName, StringBuilder csvStringBuilder)
        {
            System.IO.File.AppendAllText(fileName, csvStringBuilder.ToString());
        }
    }
}
