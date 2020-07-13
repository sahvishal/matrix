using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Mappers;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    public class FileRepository : UniqueItemRepository<File, FileEntity>, IFileRepository
    {
        public FileRepository()
            : this(new FileMapper())
        { }

        public FileRepository(IMapper<File, FileEntity> mapper)
            : base(mapper)
        { }

        protected override EntityField2 EntityIdField
        {
            get { return FileFields.FileId; }
        }

        public void MarkasArchived(long fileId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.UpdateEntitiesDirectly(new FileEntity {IsArchived = true}, new RelationPredicateBucket(FileFields.FileId == fileId));
            }   
        }

        public void Delete(long id)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly("FileEntity", new RelationPredicateBucket(FileFields.FileId == id));
            }
        }
    }
}
