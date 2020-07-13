using System.IO;

namespace Webhook.Models
{
    public class TwilioXmlSerializer
    {
        public void SerializeandSave(string fileName, TwillioMessageResponse records)
        {
            if (records == null) return;

            var serializer = new System.Xml.Serialization.XmlSerializer(records.GetType());

            TwilioDirectoryOperationsHelper.CreateDirectoryIfNotExist(Path.GetDirectoryName(fileName));

            TwilioDirectoryOperationsHelper.DeleteFileIfExist(fileName);

            var stream = new StreamWriter(fileName);

            serializer.Serialize(stream, records);

            stream.Close();
            stream.Dispose();
        }

    }
}