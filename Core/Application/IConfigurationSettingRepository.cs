using Falcon.App.Core.Enum;

namespace Falcon.App.Core.Application
{
    public interface IConfigurationSettingRepository
    {
        string GetConfigurationValue(ConfigurationSettingName settingName);
    }
}