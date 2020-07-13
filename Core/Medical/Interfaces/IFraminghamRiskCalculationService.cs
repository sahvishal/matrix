using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IFraminghamRiskCalculationService
    {
        int GetScoreForCalculatingFraminghamRisk(int age, bool isGenderMale, int? totalCholestrol, int hdl, int? ldl,
                                                 int systolic,
                                                 int diastolic, bool isSmoker, bool isDiabetic, 
                                                 List<FraminghamCalculationSource> framinghamCalculationSourceList);
    }
}
