using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare;
using Falcon.App.Core.Medicare.Enum;
using Falcon.App.Core.Medicare.ViewModels;

namespace Falcon.App.Infrastructure.Medicare.Impl
{
    [DefaultImplementation]
    public class SyncRapsPollingAgent : ISyncRapsPollingAgent
    {
        private readonly ILogger _logger;
        private readonly IRapsRepository _rapsRepository;
        private readonly IMedicareApiService _medicareApiService;
        private readonly ISettings _setting;
        private readonly bool _isDevEnvironment;


        public SyncRapsPollingAgent(ILogManager logManager, ISettings settings, IMedicareApiService medicareApiService, IRapsRepository rapsRepository)
        {
            _logger = logManager.GetLogger("SyncRapsPollingAgent");
            _setting = settings;
            _medicareApiService = medicareApiService;
            _rapsRepository = rapsRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
        }
        /// <summary>
        /// This can be rerun any time. The service updates the last run time and will continue 
        /// </summary>
        public void Sync()
        {
            if (!_setting.SyncWithHra)
            {
                _logger.Info("Syncing with HRA is off ");
                return;
            }

            _logger.Info(string.Format("SyncRapsPollingAgent Started"));
            var skipCount = 0;
            var loopCount = 0;
            var timer = new Stopwatch();
            try
            {
                if (_isDevEnvironment || !(DateTime.Now.TimeOfDay > new TimeSpan(6, 0, 0) && DateTime.Now.TimeOfDay < new TimeSpan(20, 0, 0)))
                {
                    var raps = _rapsRepository.GetRapsForSync(skipCount).ToArray();
                    do
                    {
                        if (raps.Any())
                        {
                            var recordsPulled = raps.Count();
                            _logger.Info(string.Format("Loop Count: {0} Skip Count: {1} #Records pulled for Sync: {2}", ++loopCount, skipCount, recordsPulled));
                            var orgName = _setting.OrganizationNameForHraQuestioner;
                            try
                            {
                                var listModel = new MedicareRapsListModel()
                                {
                                    Raps = Mapper.Map<IEnumerable<Raps>, IEnumerable<MedicareRapsViewModel>>(raps).ToArray(),
                                    OrganizationName = orgName,
                                    TimeToken = DateTime.UtcNow.ToLongTimeString().Encrypt()
                                };

                                _logger.Info("Syncing Raps to HRA.");
                                timer.Start();

                                var success = _medicareApiService.PostAnonymous<List<long>>(_setting.MedicareApiUrl + MedicareApiUrl.SyncRaps, listModel);
                                timer.Stop();
                                _logger.Info("Sync to Hra complete, time taken: " + timer.ElapsedMilliseconds);
                                timer.Reset();

                                if (success.Any())
                                {
                                    foreach (var medicareRapsViewModel in raps.Where(x => success.Contains(x.CustomerId)))
                                    {
                                        medicareRapsViewModel.IsSynced = true;
                                        _rapsRepository.SaveRaps(medicareRapsViewModel);
                                    }
                                    skipCount += recordsPulled - raps.Count(x => success.Contains(x.CustomerId));
                                }
                                else
                                {
                                    skipCount += recordsPulled;
                                }
                            }
                            catch (Exception exception)
                            {
                                skipCount += recordsPulled;
                                _logger.Error("Error Message: " + exception.Message + "\n\tStack Trace: " + exception.StackTrace);
                            }
                            raps = _rapsRepository.GetRapsForSync(skipCount).ToArray();
                        }
                    } while (raps.Any());
                }
                else
                {
                    _logger.Info(string.Format("SyncRapsPollingAgent can not be called as time of day is {0}", DateTime.Now.TimeOfDay));
                }
            }
            catch (Exception exception)
            {
                _logger.Error("Error occured in SyncRapsPollingAgent , Message: " + exception.Message + "\n\tStack Trace: " + exception.StackTrace);
            }
            _logger.Info("Sync Raps complete, Exiting...");
        }
    }
}
