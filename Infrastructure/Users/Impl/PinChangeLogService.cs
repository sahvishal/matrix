using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class PinChangeLogService : IPinChangeLogService
    {
        private readonly IPinChangeLogRepository _pinChangeLogRepository;
        private readonly IConfigurationSettingRepository _configurationSettingRepository;

        public PinChangeLogService(IPinChangeLogRepository pinChangeLogRepository, IConfigurationSettingRepository configurationSettingRepository)
        {
            _pinChangeLogRepository = pinChangeLogRepository;
            _configurationSettingRepository = configurationSettingRepository;
        }

        public bool IsPinRepeated(long technicianId, string pin)
        {
            var countString = _configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPinNonRepetitionCount);
            var count = Convert.ToInt32(countString);

            var previousPinList = _pinChangeLogRepository.GetOldPinList(technicianId);
            if (previousPinList == null || !previousPinList.Any())
                return false;

            if (previousPinList.Count() >= count)
            {
                previousPinList = previousPinList.OrderByDescending(x => x.Sequence).Take(count);
            }

            return previousPinList.Any(x => x.Pin == pin);
        }

        public bool Update(string pin, long technicianId, long createdByOrgRoleUserId)
        {
            var pinlist = _pinChangeLogRepository.GetOldPinList(technicianId);
            var count = Convert.ToInt32(_configurationSettingRepository.GetConfigurationValue(ConfigurationSettingName.PreviousPinNonRepetitionCount));

            if (pinlist == null || pinlist.Count() < count)
            {
                var PinChangeLog = new PinChangelog()
                {
                    TechnicianId = technicianId,
                    CreatedByOrgRoleUserId = createdByOrgRoleUserId,
                    Pin = pin,
                    DateCreated = DateTime.Now,
                    Sequence = pinlist == null ? 1 : pinlist.Count() + 1
                };
                return _pinChangeLogRepository.Save(PinChangeLog);
            }

            if (pinlist.Count() > count)
            {
                var extraInDb = pinlist.Count() - count;
                var toBeDeletedList = pinlist.OrderBy(x => x.Sequence).Take(extraInDb);

                foreach (var PinChangelog in toBeDeletedList)
                {
                    _pinChangeLogRepository.Delete(PinChangelog);
                }
                pinlist.ToList().ForEach(x => x.Sequence = x.Sequence - extraInDb);

                pinlist = pinlist.Where(x => !toBeDeletedList.Select(d => d.Id).Contains(x.Id));
            }

            if (pinlist.Any())
            {
                var oldestPin = pinlist.OrderBy(x => x.Sequence).First();
                pinlist.ToList().ForEach(x => x.Sequence = x.Sequence - 1);
                oldestPin.Sequence = count;
                oldestPin.TechnicianId = technicianId;
                oldestPin.CreatedByOrgRoleUserId = createdByOrgRoleUserId;
                oldestPin.Pin = pin;
                oldestPin.DateCreated = DateTime.Now;

                foreach (var PinChangeLog in pinlist)
                {
                    _pinChangeLogRepository.Save(PinChangeLog);
                }
            }

            return true;
        }
    }
}
