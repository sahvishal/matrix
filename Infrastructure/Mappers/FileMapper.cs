using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Users.Domain;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Mappers
{
    public class FileMapper : DomainEntityMapper<File, FileEntity>
    {
        protected override void MapDomainFields(FileEntity entity, File domainObjectToMapTo)
        {
            domainObjectToMapTo.Id = entity.FileId;
            domainObjectToMapTo.FileSize = entity.Size;
            domainObjectToMapTo.Path = entity.Path;
            domainObjectToMapTo.Type = (FileType)entity.Type;
            domainObjectToMapTo.UploadedBy = new OrganizationRoleUser(entity.CreatedBy);
            domainObjectToMapTo.UploadedOn = entity.CreatedDate;
            domainObjectToMapTo.IsArchived = entity.IsArchived;
        }

        protected override void MapEntityFields(File domainObject, FileEntity entityToMapTo)
        {
            entityToMapTo.FileId = domainObject.Id;
            entityToMapTo.Size = domainObject.FileSize;
            entityToMapTo.Path = domainObject.Path;
            entityToMapTo.Type = (long)domainObject.Type;
            entityToMapTo.CreatedBy = domainObject.UploadedBy.Id;
            entityToMapTo.CreatedDate = domainObject.UploadedOn;
        }
    }
}
