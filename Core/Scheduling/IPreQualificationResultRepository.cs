using Falcon.App.Core.Application;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IPreQualificationResultRepository : IRepository<PreQualificationResult>
    {
        PreQualificationResult Get(long tempCartId);
        PreQualificationResult GetByCallId(long callId);
        PreQualificationResult GetById(long id);
        PreQualificationResult GetByEventIdCustomerId(long evetId, long customerId);
    }
}