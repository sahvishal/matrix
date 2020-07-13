using System;
using System.Threading.Tasks;
using Falcon.App.Core.Application;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class NewResultFlowStateService : INewResultFlowStateService
    {
        private readonly IMedicareApiService _medicareApiService;
        private readonly ITestResultService _testResultService;

        private readonly string _medicareApiUrl;
        private readonly string _organizationName;
        private readonly bool _syncWithHra;
        private readonly ILogger _logger;

        public NewResultFlowStateService(IMedicareApiService medicareApiService, ISettings settings, ILogManager logManager, ITestResultService testResultService)
        {
            _medicareApiService = medicareApiService;
            _testResultService = testResultService;
            _medicareApiUrl = settings.MedicareApiUrl;
            _organizationName = settings.OrganizationNameForHraQuestioner;
            _syncWithHra = settings.SyncWithHra;
            _logger = logManager.GetLogger("HipNewResultFlowStateService");
        }

        public bool SyncHraCanUnsignForVisit(MedicareCanUnsignViewModel model, long orgRoleId, string callingMethod)
        {
            try
            {
                _logger.Info("calling method " + callingMethod + " eventId: " + model.EventId + " customerid: " + model.HfCustomerId);
                var signFeature = new ToggleSignFeatureViewModel
                {
                    AuthToken = DateTime.UtcNow.ToLongTimeString().Encrypt(),
                    OrganizationName = _organizationName,
                    CanUnsignModel = model
                };
                _logger.Info("completed method " + callingMethod + " eventId: " + model.EventId + " customerid: " + model.HfCustomerId);
                
                if (_syncWithHra)
                {
                    return _medicareApiService.PostAnonymous<bool>(_medicareApiUrl + MedicareApiUrl.ToggleCanUnSignForVisit, signFeature);
                }
                _logger.Info("Sync with HRA is Off");
                   

            }
            catch (Exception ex)
            {
                _logger.Info("error method " + callingMethod + " eventId: " + model.EventId + " customerid: " + model.HfCustomerId);
                _logger.Info("ex " + ex.Message);
                _logger.Info("ex " + ex.StackTrace);
            }

            return false;
        }

        public bool SyncReadyForCodingForVisit(EhrReadyforCodingViewModel readyforCodingModel, long orgRoleId, string callingMethod)
        {
            try
            {
                _logger.Info("calling method " + callingMethod + " from Hra. eventId: " + readyforCodingModel.EventId + " customerId: " + readyforCodingModel.HfCustomerId);
                var model = new EhrToggleReadyForCodingSyncModel
                {
                    OrganizationName = _organizationName,
                    AuthToken = DateTime.UtcNow.ToLongTimeString().Encrypt(),
                    ReadyForCodingModel = readyforCodingModel
                };
                
                var isSynced = false;
                if (_syncWithHra)
                {
                    isSynced = _medicareApiService.PostAnonymous<bool>(_medicareApiUrl + MedicareApiUrl.ToggleReadyForCodingForVisit, model);
                }
                else
                {
                    _logger.Info("Sync with HRA is Off");
                }
                 

                _logger.Info("completed calling method " + callingMethod + " eventId: " + readyforCodingModel.EventId + " customerId: " + readyforCodingModel.HfCustomerId + " returned value from Hra : " + isSynced);

                if (isSynced)
                {
                    _logger.Info("Sync Success for calling method " + callingMethod + " eventId: " + readyforCodingModel.EventId + " customerId: " + readyforCodingModel.HfCustomerId);

                    _testResultService.SetResultstoState(model.ReadyForCodingModel.EventId, model.ReadyForCodingModel.HfCustomerId, (int)NewTestResultStateNumber.NpSigned, false, orgRoleId);
                }
                _logger.Info("completed calling method " + callingMethod + " eventId: " + readyforCodingModel.EventId + " customerId: " + readyforCodingModel.HfCustomerId);

                return isSynced;
            }
            catch (Exception ex)
            {
                _logger.Error("error for calling method " + callingMethod + " eventId: " + readyforCodingModel.EventId + " customerid: " + readyforCodingModel.HfCustomerId);
                _logger.Error("ex " + ex.Message);
                _logger.Error("ex " + ex.StackTrace);
            }

            return false;
        }

        public bool SyncReadyForEvaluation(EhrReadyForReEvaluation model, long orgRoleId, string callingMethod)
        {
            try
            {
                _logger.Info("calling Method: " + callingMethod + " EventId: " + model.EventId + " Customer id: " + model.HfCustomerId);

                var npModel = new EhrNpReEvaluationModel
                {
                    OrganizationName = _organizationName,
                    AuthToken = DateTime.UtcNow.ToLongTimeString().Encrypt(),
                    ReEvalModel = model,
                };

                if (_syncWithHra)
                {
                    var result = _medicareApiService.PostAnonymous<bool>(_medicareApiUrl + MedicareApiUrl.ReadyForReEvaluation, npModel);

                    _logger.Info("completed Method: " + callingMethod + " EventId: " + model.EventId + " Customer id: " + model.HfCustomerId + " result:" + result);

                    return result;
                }
                _logger.Info("Sync with HRA is Off");
                
            }
            catch (Exception ex)
            {
                _logger.Info("ex " + ex.Message);
                _logger.Info("ex " + ex.StackTrace);
            }

            return false;
        }

        public bool RunTaskReadyForCodingForVisit(EhrReadyforCodingViewModel model, long orgId, string callingMethod)
        {
            Task.Run(() => SyncReadyForCodingForVisit(model, orgId, callingMethod));
            return true;
        }

        public bool RunTaskSyncHraCanUnsignForVisit(MedicareCanUnsignViewModel model, long orgId, string callingMethod)
        {
            Task.Run(() => SyncHraCanUnsignForVisit(model, orgId, callingMethod));
            return true;
        }

    }
}
