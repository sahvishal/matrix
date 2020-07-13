using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Interfaces;

namespace Falcon.App.Core.Medical.Impl
{
    [DefaultImplementation]
    public class MedicationService : IMedicationService
    {
        private readonly IMedicationUploadRepository _medicationUploadRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMedicationFactory _medicationFactory;
        private readonly ISyncMedicationPollingAgent _syncMedicationPollingAgent;
        private readonly ILogger _logger;

        public MedicationService(IOrganizationRoleUserRepository organizationRoleUserRepository, IMedicationUploadRepository medicationUploadRepository,
            IMedicationRepository medicationRepository, IMedicationFactory medicationFactory, ISyncMedicationPollingAgent syncMedicationPollingAgent, ILogManager logger)
        {
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _medicationUploadRepository = medicationUploadRepository;
            _medicationRepository = medicationRepository;
            _medicationFactory = medicationFactory;
            _syncMedicationPollingAgent = syncMedicationPollingAgent;
            _logger = logger.GetLogger("MedicationService");
        }

        public IEnumerable<MedicationUploadViewModel> GetUploadList(int pageNumber, int pageSize, MedicationUploadListModelFilter filter, out int totalRecords)
        {
            var list = _medicationUploadRepository.GetUploadList(pageNumber, pageSize, filter, out totalRecords).ToArray();
            var uploadByIds = list.Select(c => c.UploadedBy).Distinct().ToArray();

            IEnumerable<OrderedPair<long, string>> uploadedbyAgentNameIdPair = null;

            if (uploadByIds != null && uploadByIds.Any())
            {
                uploadedbyAgentNameIdPair = _organizationRoleUserRepository.GetNameIdPairofUsers(uploadByIds).ToArray();
            }
            foreach (var rapsUploadModel in list)
            {
                if (uploadedbyAgentNameIdPair != null && uploadedbyAgentNameIdPair.Any())
                {
                    rapsUploadModel.UploadedName = uploadedbyAgentNameIdPair.Single(ap => ap.FirstValue == rapsUploadModel.UploadedBy).SecondValue;
                }

            }
            return list;
        }

        public void SaveMedications(IEnumerable<MedicationEditModel> medications, long customerId, long orgRoleUserId)
        {
            if (medications.IsNullOrEmpty()) return;

            var updateList = medications.Where(x => x.Id != 0).ToArray();
            var insertList = medications.Where(x => x.Id == 0).ToArray();

            var medicationIdNotToMarkAsDelete = updateList.Select(x => x.Id).ToArray();
            _medicationRepository.MarkForDelete(customerId, orgRoleUserId, medicationIdNotToMarkAsDelete);

            if (!insertList.IsNullOrEmpty())
            {
                var model = _medicationFactory.CreateModel(insertList, customerId);
                _medicationRepository.SaveMedications(model, orgRoleUserId);
            }
            updateList = updateList.Where(x => x.IsEdited).ToArray();
            if (!updateList.IsNullOrEmpty())
            {
                var model = _medicationFactory.CreateModel(updateList, customerId);
                _medicationRepository.UpdateMedications(model, orgRoleUserId);
            }
            if (insertList.Any() || updateList.Any())
                _syncMedicationPollingAgent.SyncMedicationData(_logger, orgRoleUserId, false, customerId);
        }

        public IEnumerable<MedicationEditModel> GetMedications(long customerId)
        {
            var medications = _medicationRepository.GetByCustomerId(customerId);
            if (medications.IsNullOrEmpty()) return null;
            return _medicationFactory.CreateViewModel(medications);
        }
    }
}
