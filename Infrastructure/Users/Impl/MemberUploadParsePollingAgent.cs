using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Sales;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class MemberUploadParsePollingAgent : IMemberUploadParsePollingAgent
    {
        private readonly ILogger _logger;
        private readonly ICorporateUploadRepository _corporateUploadRepository;
        private readonly IMemberUploadParseDetailRepository _memberUploadParseDetailRepository;
        private readonly IPreApprovedTestRepository _preApprovedTestRepository;
        private readonly IPreApprovedPackageRepository _preApprovedPackageRepository;
        private readonly IEventCustomerPreApprovedTestService _eventCustomerPreApprovedTestService;
        private readonly ICorporateCustomerUploadService _corporateCustomerUploadService;
        private IMemberUploadParseDetailFactory _memberUploadParseDetailFactory;

        public MemberUploadParsePollingAgent(ILogManager logManager, ICorporateUploadRepository corporateUploadRepository,
            IMemberUploadParseDetailRepository memberUploadParseDetailRepository, IPreApprovedTestRepository preApprovedTestRepository,
            IPreApprovedPackageRepository preApprovedPackageRepository, IEventCustomerPreApprovedTestService eventCustomerPreApprovedTestService,
            ICorporateCustomerUploadService corporateCustomerUploadService, IMemberUploadParseDetailFactory memberUploadParseDetailFactory)
        {
            _logger = logManager.GetLogger("MemberUploadParsePollingAgent");
            _corporateUploadRepository = corporateUploadRepository;
            _memberUploadParseDetailRepository = memberUploadParseDetailRepository;
            _preApprovedTestRepository = preApprovedTestRepository;
            _preApprovedPackageRepository = preApprovedPackageRepository;
            _eventCustomerPreApprovedTestService = eventCustomerPreApprovedTestService;
            _corporateCustomerUploadService = corporateCustomerUploadService;
            _memberUploadParseDetailFactory = memberUploadParseDetailFactory;
        }

        public void Parse()
        {
            _logger.Info("Starting Member Upload Parsing");

            var corporateUploads = _corporateUploadRepository.GetByParseStatus((int)MemberUploadParseStatus.Start);

            if (corporateUploads == null || !corporateUploads.Any())
            {
                _logger.Info("No corporate Upload found to parse");
            }

            foreach (var corporateUpload in corporateUploads)
            {
                try
                {
                    _logger.Info("\n\n--------------------------------------------------------------------------------------------------------------------");
                    _logger.Info("-------------------------------Starting Parsing for corporateUploadId: " + corporateUpload.Id + "----------------------------------");
                    UpdateCorporateUploadStatus(corporateUpload, MemberUploadParseStatus.Parsing);

                    var members = _memberUploadParseDetailRepository.GetByCorporateUploadId(corporateUpload.Id);

                    if (members == null || !members.Any())
                    {
                        _logger.Info("No members found by corporateUploadId: " + corporateUpload.Id);
                        UpdateCorporateUploadStatus(corporateUpload, MemberUploadParseStatus.Parsed);
                        _logger.Info("-------------------------------Parsing completed for corporateUploadId: " + corporateUpload.Id + "----------------------------------\n\n");
                        continue;
                    }

                    foreach (var member in members)
                    {
                        _logger.Info("Parsing for CustomerId: " + member.CustomerId);
                        var eventCustomers = _eventCustomerPreApprovedTestService.GetFutureEventCustomers(member.CustomerId, isTodayIncluded: false);
                        var viewModel = _memberUploadParseDetailFactory.GetCorporateCustomerModel(member, corporateUpload.Id);
                        if (eventCustomers == null || !eventCustomers.Any())
                        {
                            _corporateCustomerUploadService.UpateCustomerPreApprovedTest(viewModel, corporateUpload.UploadedBy, member.CustomerId);
                            _corporateCustomerUploadService.UpdateCustomerPreApprovedPackges(viewModel, corporateUpload.UploadedBy, member.CustomerId);

                        }
                        else
                        {
                            _eventCustomerPreApprovedTestService.MarkcustomerForAdjustOrder(viewModel, eventCustomers, corporateUpload.UploadedBy, member.CustomerId, corporateUpload.Id);

                            _corporateCustomerUploadService.UpateCustomerPreApprovedTest(viewModel, corporateUpload.UploadedBy, member.CustomerId);
                            _corporateCustomerUploadService.UpdateCustomerPreApprovedPackges(viewModel, corporateUpload.UploadedBy, member.CustomerId);
                            _corporateCustomerUploadService.UpdateCustomerPreApprovedForFutureEvents(eventCustomers, viewModel);
                        }

                        _logger.Info("Parsed for CustomerId: " + member.CustomerId);
                    }

                    UpdateCorporateUploadStatus(corporateUpload, MemberUploadParseStatus.Parsed);
                    _logger.Info("-------------------------------Parsing completed for corporateUploadId: " + corporateUpload.Id + "----------------------------------\n\n");
                }
                catch (Exception ex)
                {
                    _logger.Error("Parsing failed for corporateUploadId" + corporateUpload.Id);
                    _logger.Error("Error: " + ex.Message + ". StackTrace: " + ex.StackTrace);
                    UpdateCorporateUploadStatus(corporateUpload, MemberUploadParseStatus.Failed);
                }
            }
        }

        private void UpdateCorporateUploadStatus(CorporateUpload corporateUpload, MemberUploadParseStatus status)
        {
            corporateUpload.ParseStatus = (int)status;
            _corporateUploadRepository.Save(corporateUpload);
            _logger.Info("Updated CorporateUpload Status to " + status.ToString());
        }
    }
}
