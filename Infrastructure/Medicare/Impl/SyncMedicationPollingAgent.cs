using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncMedicationPollingAgent : ISyncMedicationPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ISettings _setting;
        private readonly bool _isDevEnvironment;
        private readonly OrganizationRoleUser _modifiedByService;

        public SyncMedicationPollingAgent(IMedicationRepository medicationRepository, IMedicareApiService medicareApiService, ISettings setting,
            ILogManager logManager)
        {
            _medicationRepository = medicationRepository;
            _medicareApiService = medicareApiService;
            _setting = setting;
            _logger = logManager.GetLogger("SyncMedicationPollingAgent");
            _isDevEnvironment = setting.IsDevEnvironment;
            _modifiedByService = new OrganizationRoleUser(1);
        }

        public void Sync()
        {
            _logger.Info(string.Format("SyncMedicationPollingAgent Started"));
            try                                                                             // here try catch is unnecessary , can be removed
            {
                if (!_setting.SyncWithHra)
                {
                    _logger.Info("Syncing with HRA is off ");
                    return;
                }
                SyncMedicationData(_logger, _modifiedByService.Id, null);
                _logger.Info(string.Format("Exiting SyncMedicationPollingAgent"));
            }
            catch (Exception ex)
            {
                _logger.Error("Exception occurred SyncMedicationPollingAgent , Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }

        public void SyncMedicationData(ILogger logger, long modifiedBy, bool? syncAfterUpload = null, long? customerId = null)
        {
            try
            {
                if (!_setting.SyncWithHra)
                {
                    _logger.Info("Syncing with HRA is off ");
                    return;
                }
                var loopCount = 1;
                var lastMaxIdColumn = 0L;

                if (_isDevEnvironment || !(DateTime.Now.TimeOfDay < new TimeSpan(4, 0, 0) && DateTime.Now.TimeOfDay > new TimeSpan(1, 0, 0))
                    || (syncAfterUpload.HasValue && syncAfterUpload.Value))
                {
                    if (syncAfterUpload.HasValue && syncAfterUpload.Value)
                    {
                        logger.Info("Beginning medication sync to HRA");
                    }
                    else if (syncAfterUpload.HasValue && !syncAfterUpload.Value)
                    {
                        logger.Info("Beginning Live sync to HRA for CustomerId: " + customerId);
                    }

                    var medicationForSync = _medicationRepository.GetMedicationForSync(lastMaxIdColumn, customerId);
                    do
                    {
                        var pulledRecordsCount = medicationForSync.Count();
                        if (medicationForSync.Any())
                        {
                            try
                            {
                                lastMaxIdColumn = medicationForSync.Max(x => x.Id);

                                _logger.Info("Begining Sync " + pulledRecordsCount + " records , Loop count: " + loopCount);
                                var listModel = new MedicareMedicationListModel
                                {
                                    Medication = Mapper.Map<IEnumerable<Medication>, IEnumerable<MedicareMedicationViewModel>>(medicationForSync).ToArray(),
                                    AuthToken = DateTime.UtcNow.ToLongTimeString().Encrypt(),
                                    OrganizationName = _setting.OrganizationNameForHraQuestioner
                                };

                                var successCustomerIds = _medicareApiService.PostAnonymous<List<long>>(_setting.MedicareApiUrl + MedicareApiUrl.SyncMedication, listModel);

                                var successCount = 0;
                                if (successCustomerIds.Any())
                                {
                                    //easy way to find matching list in a list
                                    foreach (var cid in successCustomerIds.Distinct())
                                    {
                                        foreach (var medication in medicationForSync)
                                        {
                                            if (cid == medication.CustomerId)
                                            {
                                                medication.DateModified = DateTime.Now;
                                                medication.ModifiedBy = modifiedBy;
                                                medication.IsSynced = true;
                                                _medicationRepository.SaveMedication(medication);
                                                successCount++;
                                            }
                                        }
                                    }
                                }
                                _logger.Info("Sync done for LoopCount: " + loopCount + " , successfully synced " + successCount + " records");
                                _logger.Info("Last max Id column is  : " + lastMaxIdColumn);
                            }
                            catch (Exception ex)
                            {
                                logger.Error("Error Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
                            }
                            medicationForSync = _medicationRepository.GetMedicationForSync(lastMaxIdColumn, customerId);
                            loopCount++;
                        }

                    } while (medicationForSync.Any());

                    if (syncAfterUpload.HasValue && syncAfterUpload.Value)
                    {
                        logger.Info("Exiting medication sync to HRA");
                    }
                    else if (syncAfterUpload.HasValue && !syncAfterUpload.Value)
                    {
                        logger.Info("Exiting Live sync to HRA");
                    }
                }
                else
                {
                    logger.Info(string.Format("SyncMedicationPollingAgent can not be called as time of day is {0}", DateTime.Now.TimeOfDay));
                }
            }
            catch (Exception ex)
            {
                logger.Error("Exception occurred , Message: " + ex.Message + "\n\t Stack Trace: " + ex.StackTrace);
            }
        }
    }
}
