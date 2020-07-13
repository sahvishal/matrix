using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Application
{
    public interface IDateAddedSettingManager
    {
        void SerializeandSave(string fileName, List<DateAddedSettings> records);
        List<DateAddedSettings> Deserialize(string fileName);
    }
}
