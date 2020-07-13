using System.IO;
using System.Xml.Serialization;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class CustomSettingManager : ICustomSettingManager
    {
        public void SerializeandSave(string fileName, CustomSettings records)
        {
            if (records == null) return;

            var serializer = new XmlSerializer(records.GetType());

            if (Path.GetDirectoryName(fileName) == null || !Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            if (File.Exists(fileName)) File.Delete(fileName);

            var stream = new StreamWriter(fileName);

            serializer.Serialize(stream, records);

            stream.Close();
            stream.Dispose();
        }

        public CustomSettings Deserialize(string fileName)
        {
            if (!File.Exists(fileName))
            {
                SerializeandSave(fileName, new CustomSettings());
            };

            var serializer = new XmlSerializer(typeof(CustomSettings));
            var stream = new StreamReader(fileName);

            var records = serializer.Deserialize(stream);

            stream.Close();
            stream.Dispose();

            if (records is CustomSettings)
                return records as CustomSettings;

            return null;
        }
    }
}



