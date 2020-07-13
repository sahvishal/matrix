using Falcon.App.Core.Insurance.Domain;

namespace Falcon.App.Core.Insurance
{
    public interface IClaimRepository
    {
        Claim Save(Claim domain);
        Claim GetById(long id);
    }
}
