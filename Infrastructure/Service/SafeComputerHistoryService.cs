using System;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Infrastructure.Service
{
    [DefaultImplementation]
    public class SafeComputerHistoryService : ISafeComputerHistoryService
    {
        private readonly ISafeComputerHistoryRepository _safeComputerHistoryRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;
        private readonly int _safeDeviceExpiryDays;

        public SafeComputerHistoryService(ISafeComputerHistoryRepository safeComputerHistoryRepository, IConfigurationSettingRepository configurationSettingRepository)
        {
            _safeComputerHistoryRepository = safeComputerHistoryRepository;
            _configurationSettingRepository = configurationSettingRepository;
            _safeDeviceExpiryDays = Convert.ToInt32(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.SafeDeviceExpiryDays));
        }


        public bool IsSafe(SafeComputerHistory safeComputer)
        {
            var list = _safeComputerHistoryRepository.Get(safeComputer.UserLoginId);
            if (list == null)
                return false;

            foreach (var safeComputerHistory in list)
            {
                if (safeComputerHistory.IsActive && safeComputerHistory.BrowserType == safeComputer.BrowserType && safeComputerHistory.ComputerIp == safeComputer.ComputerIp && safeComputerHistory.DateModified.AddDays(_safeDeviceExpiryDays) > DateTime.Today.Date)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Save(SafeComputerHistory safeComputer)
        {
            return _safeComputerHistoryRepository.Save(safeComputer);
        }
    }
}
