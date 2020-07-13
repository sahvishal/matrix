using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class MemberUploadParseDetailRepository : PersistenceRepository, IMemberUploadParseDetailRepository
    {
        public IEnumerable<MemberUploadParseDetail> GetByCorporateUploadId(long corporateUploadId, bool isSuccessful = true)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from q in linqMetaData.MemberUploadParseDetail
                                where q.CorporateUploadId == corporateUploadId
                                && q.IsSuccessful == isSuccessful
                                select q).ToArray();

                return Mapper.Map<IEnumerable<MemberUploadParseDetailEntity>, IEnumerable<MemberUploadParseDetail>>(entities);
            }
        }

        public void Save(MemberUploadParseDetail domain)
        {
            var entity = Mapper.Map<MemberUploadParseDetail, MemberUploadParseDetailEntity>(domain);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                {
                    throw new PersistenceFailureException();
                }
            }
        }
    }
}
