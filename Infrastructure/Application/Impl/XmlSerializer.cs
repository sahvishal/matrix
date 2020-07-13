using System.IO;
using System.Xml.Serialization;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Helper;

namespace Falcon.App.Infrastructure.Application.Impl
{
    [DefaultImplementation]
    public class XmlSerializer<T> : IXmlSerializer<T>
    {
        public void SerializeandSave(string fileName, T records)
        {
            if (records == null) return;

            var serializer = new XmlSerializer(records.GetType());
            
            DirectoryOperationsHelper.CreateDirectoryIfNotExist(Path.GetDirectoryName(fileName));
            
            DirectoryOperationsHelper.DeleteFileIfExist(fileName);

            var stream = new StreamWriter(fileName);

            serializer.Serialize(stream, records);

            stream.Close();
            stream.Dispose();
        }

        public T Deserialize(string fileName)
        {

            if (!File.Exists(fileName))
            {
                return default(T);
            };

            var serializer = new XmlSerializer(typeof(T));
            var stream = new StreamReader(fileName);

            var records = serializer.Deserialize(stream);

            stream.Close();
            stream.Dispose();

            if (records is T)
                return (T)records;

            return default(T);
        }
    }
}
