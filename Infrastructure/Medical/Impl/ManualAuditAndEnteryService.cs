using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories.Screening;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class ManualAuditAndEnteryService : IManualAuditAndEnteryService
    {
        private readonly IEventCustomerResultRepository _eventCustomerResultRepository;
        private readonly ITestResultService _testResultService;
        private readonly ICommunicationRepository _communicationRepository;
        private readonly INewResultFlowStateService _newResultFlowStateService;
        private readonly IEventRepository _eventRepository;

        public ManualAuditAndEnteryService(IEventCustomerResultRepository eventCustomerResultRepository, ITestResultService testResultService, ICommunicationRepository communicationRepository, INewResultFlowStateService newResultFlowStateService,
            IEventRepository eventRepository)
        {
            _eventCustomerResultRepository = eventCustomerResultRepository;
            _testResultService = testResultService;
            _communicationRepository = communicationRepository;
            _newResultFlowStateService = newResultFlowStateService;
            _eventRepository = eventRepository;
            new TestResultRepository();
        }

        public void SetPostAuditEvaluation(PostEvaluationEditModel model)
        {

            if (model.IsNewResultflow)
            {
                if (model.DoPostAudit)
                {
                    if (_eventRepository.IsHealthPlanEvent(model.EventId))
                    {
                        _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.PostAuditNew, false, model.OrganizationRoleUserId);

                        var eventCustomerResult = _eventCustomerResultRepository.GetByCustomerIdAndEventId(model.CustomerId, model.EventId);
                        if (eventCustomerResult.IsIpResultGenerated)
                        {
                            _eventCustomerResultRepository.UpdateIsIpResultGenerated(eventCustomerResult.Id, false);
                        }
                    }
                    else
                    {
                        _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.PdfGenerated, false, model.OrganizationRoleUserId);
                    }
                }
                else if (model.DoReque)
                {
                    RevertResultForToPhysicianForEvaluation(model);
                }
                else if (model.IsRevertToCoding)
                {
                    RevertResultForReadyForCoding(model);
                }
                else if (model.IsRevertToNp)
                {
                    RevertResultForNpReevaluation(model);
                }
                else if (model.IsRevertToPreAudit)
                {
                    ResultUndoPreAudit(model);
                }
            }
            else
            {
                if (model.DoPostAudit)
                {
                    _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)TestResultStateNumber.PostAudit, true, model.OrganizationRoleUserId);
                }
                else if (model.DoReque)
                {
                    _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)TestResultStateNumber.PostAudit, false, model.OrganizationRoleUserId);
                }
            }

            if (!string.IsNullOrWhiteSpace(model.Message) && model.IsNewResultflow)
            {
                _communicationRepository.SaveCommunicationDetails(model.Message, new OrganizationRoleUser(model.OrganizationRoleUserId), model.CustomerId, model.EventId);
            }

            _eventCustomerResultRepository.SetEventCustomerPennedBack(model.EventId, model.CustomerId, model.IsPennedBack);
        }


        private void RevertResultForToPhysicianForEvaluation(PostEvaluationEditModel model)
        {
            _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.PreAudit, false, model.OrganizationRoleUserId);
        }

        private void RevertResultForReadyForCoding(PostEvaluationEditModel model)
        {
            _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.NpSigned, (model.ShowHraQuestions && model.IsEawvTestPurchased), model.OrganizationRoleUserId);
            if (model.ShowHraQuestions && model.IsEawvTestPurchased)
            {
                SyncReadyForCoding(model);
            }

        }
        private void SyncReadyForCoding(PostEvaluationEditModel model)
        {
            var ehrReadyforCoding = new EhrReadyforCodingViewModel
            {
                EventId = model.EventId,
                HfCustomerId = model.CustomerId,
                ReadyForCoding = true,
                Message = model.Message
            };
            _newResultFlowStateService.RunTaskReadyForCodingForVisit(ehrReadyforCoding, model.OrganizationRoleUserId, "SetAllResultsforPostEvaluationEdit");
        }

        private void RevertResultForNpReevaluation(PostEvaluationEditModel model)
        {
            if (model.ShowHraQuestions && model.IsEawvTestPurchased)
            {
                if (SyncRevertToNp(model))
                {
                    _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.Evaluated, false, model.OrganizationRoleUserId);
                }
            }
        }
        private bool SyncRevertToNp(PostEvaluationEditModel model)
        {
            var ehrReadyForReEvaluation = new EhrReadyForReEvaluation
            {
                EventId = model.EventId,
                HfCustomerId = model.CustomerId,
                ReadyForReEvaluation = true,
                Message = model.Message
            };

            return _newResultFlowStateService.SyncReadyForEvaluation(ehrReadyForReEvaluation, model.OrganizationRoleUserId, "SetAllResultsforPostEvaluationEdit");
        }

        private void ResultUndoPreAudit(PostEvaluationEditModel model)
        {
            _testResultService.SetResultstoState(model.EventId, model.CustomerId, (int)NewTestResultStateNumber.ResultEntryCompleted, false, model.OrganizationRoleUserId);

            if (model.ShowHraQuestions && model.IsEawvTestPurchased)
            {
                SyncCanUnsignHra(model);
            }
        }
        private void SyncCanUnsignHra(PostEvaluationEditModel model)
        {
            var ehrCanUnsignHra = new MedicareCanUnsignViewModel
            {
                EventId = model.EventId,
                HfCustomerId = model.CustomerId,
                CanUnsign = true,
                Message = model.Message
            };

            _newResultFlowStateService.RunTaskSyncHraCanUnsignForVisit(ehrCanUnsignHra, model.OrganizationRoleUserId, "SetAllResultsforPostEvaluationEdit");
        }
    }


}
