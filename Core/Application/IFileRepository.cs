namespace Falcon.App.Core.Application
{
    public interface IFileRepository
    {
        void MarkasArchived(long fileId);
        void Delete(long id);
    }
}
