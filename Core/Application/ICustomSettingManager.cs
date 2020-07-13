using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Application
{
    public interface ICustomSettingManager
    {
        void SerializeandSave(string fileName, CustomSettings records);
        CustomSettings Deserialize(string fileName);
    }
}
