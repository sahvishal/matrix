using Falcon.App.Core.Application;
using Falcon.App.Core.CallCenter;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Users;
using System;
using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.CallCenter.ViewModels;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Application.Attributes;
using System.Net;
using Newtonsoft.Json;

namespace Falcon.App.Infrastructure.CallCenter.Impl
{
    [DefaultImplementation]
    public class ViciCallParserPollingAgent : IViciCallParserPollingAgent
    {
        private readonly ISettings _settings;
        private readonly ILogger _logger;
        private readonly bool _isDevEnvironment;
        private readonly ICallUploadService _callUploadService;
        private readonly IUserLoginRepository _userLoginRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;

        public ViciCallParserPollingAgent(ISettings settings, ILogManager logManager, ICallUploadService callUploadService,
            IUserLoginRepository userLoginRepository, IOrganizationRoleUserRepository organizationRoleUserRepository)
        {
            _settings = settings;
            _callUploadService = callUploadService;
            _userLoginRepository = userLoginRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _isDevEnvironment = settings.IsDevEnvironment;
            _logger = logManager.GetLogger("ViciDialerCallParsing");

        }

        public void PollForCallParsing()
        {
            try
            {
                _logger.Info("Entering In Vici Dialer Parsing...");
                var timeOfDay = DateTime.Now;
                if (_isDevEnvironment || (timeOfDay.TimeOfDay < new TimeSpan(1, 0, 0)) || (timeOfDay.TimeOfDay > new TimeSpan(2, 0, 0)))
                {
                    //Check for file

                    var listModel = Get<IEnumerable<ViciDialerCallModel>>(_settings.ViciDialerApiUrl);

                    _logger.Info("Getting data from API.");

                    if (listModel.IsNullOrEmpty())
                    {
                        _logger.Info("No data found to parse.");
                        return;
                    }

                    long orgRoleUserId = 1;

                    var ViciUser = _userLoginRepository.GetByUserName(_settings.ViciDialerUserName);
                    if (ViciUser != null)
                    {
                        var organizationRoleUser = _organizationRoleUserRepository.GetOrganizationRoleUsermodel(ViciUser.Id, (long)Roles.CallCenterRep);
                        if (organizationRoleUser != null)
                            orgRoleUserId = organizationRoleUser.OrganizationRoleUserId;
                    }

                    foreach (var model in listModel)
                    {
                        try
                        {
                            _callUploadService.SaveViciDialerCall(model, orgRoleUserId);
                        }
                        catch (Exception ex)
                        {
                            _logger.Error(string.Format("Error for Customer Id: {0}. Message: {2}. \n Stack Trace{3}", model.CustomerId, ex.Message, ex.StackTrace));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error("Vici Dialer Parsing Exception Message: " + ex.Message + "\n Stack Trace:" + ex.StackTrace);
            }
        }

        private T Get<T>(string url)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/json";
                    client.Headers["timezoneoffset"] = (TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes).ToString();

                    var result = client.DownloadString(url);

                    if (string.IsNullOrEmpty(result)) return default(T);

                    var response = JsonConvert.DeserializeObject<T>(result);
                    return response != null ? JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(response)) : default(T);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(string.Format("Error occurred while getting the response from API. Message: {0} \nStackTrace: {1}", ex.Message, ex.StackTrace));
                return default(T);
            }
        }
    }
}
