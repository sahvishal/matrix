using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Application.Repositories
{
    [DefaultImplementation(Interface = typeof(INotesRepository))]
    public class NotesRepository : PersistenceRepository, IRepository<Notes>, INotesRepository
    {
        public Notes Get(long id)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var notesDetailEntity = linqMetaData.NotesDetails.Where(n => n.NoteId == id).SingleOrDefault();
                return AutoMapper.Mapper.Map<NotesDetailsEntity, Notes>(notesDetailEntity);
            }
        }

        public IEnumerable<Notes> Get(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var notesDetailEntities = linqMetaData.NotesDetails.Where(n => ids.Contains(n.NoteId)).ToArray();
                return AutoMapper.Mapper.Map<IEnumerable<NotesDetailsEntity>, IEnumerable<Notes>>(notesDetailEntities);
            }
        }

        public Notes Save(Notes domainObject)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = AutoMapper.Mapper.Map<Notes, NotesDetailsEntity>(domainObject);
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
                return AutoMapper.Mapper.Map<NotesDetailsEntity, Notes>(entity);
            }
        }

        public void Delete(Notes domainObject)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(IEnumerable<Notes> domainObjects)
        {
            throw new System.NotImplementedException();
        }
    }
}