using System.IO;
using System.Xml.Serialization;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class DateAddedSettingManager : IDateAddedSettingManager
    {
        public void SerializeandSave(string fileName, List<DateAddedSettings> records)
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

        public List<DateAddedSettings> Deserialize(string fileName)
        {
            List<DateAddedSettings> dateAddedSettings = new List<DateAddedSettings>();
            if (!File.Exists(fileName))
            {
                SerializeandSave(fileName, dateAddedSettings);
            };

            var serializer = new XmlSerializer(typeof(List<DateAddedSettings>));
            var stream = new StreamReader(fileName);

            var records = serializer.Deserialize(stream);

            stream.Close();
            stream.Dispose();

            if (records is List<DateAddedSettings>)
                return records as List<DateAddedSettings>;

            return null;
        }
    }
}



