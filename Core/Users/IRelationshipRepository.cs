using System.Collections.Generic;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Users
{
    public interface IRelationshipRepository
    {
        Relationship GetById(long id);

        Relationship GetByCode(string code);

        Relationship Save(Relationship domain);

        IEnumerable<Relationship> GetAll();

        IEnumerable<Relationship> GetByIds(IEnumerable<long> ids);
    }
}
