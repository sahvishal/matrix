using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IFraminghamRiskCalculationRepository
    {
        List<FraminghamCalculationSource> GetFraminghamCalculationSource();
        decimal? GetFraminghamRiskforScoreRange(int score, bool isGenderMale);
        OrderedPair<bool, bool> GetSmokerDiabeticInformation(long customerId);
        bool SaveSmokerDiabeticInformation(long customerId, bool isSmoker, bool isDiabetic);
    }
}
