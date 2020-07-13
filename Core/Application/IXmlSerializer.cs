namespace Falcon.App.Core.Application
{
    public interface IXmlSerializer<T>
    {
        void SerializeandSave(string fileName, T records);
        T Deserialize(string fileName);
    }
}