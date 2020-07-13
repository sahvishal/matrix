using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;
using Falcon.App.Core.Medical.Interfaces;

namespace Falcon.App.Core.Medical.Impl
{
    public class FraminghamRiskCalculationService : IFraminghamRiskCalculationService
    {
        delegate FraminghamCalculationSource DelegateReturnEligibleSource(List<FraminghamCalculationSource> list, ReadingLabels readingLabel, int reading);


        public int GetScoreForCalculatingFraminghamRisk(int age, bool isGenderMale, int? totalCholestrol, int hdl, int? ldl, int systolic, 
                                                            int diastolic, bool isSmoker, bool isDiabetic, List<FraminghamCalculationSource> framinghamCalculationSourceList)
        {

            DelegateReturnEligibleSource delegateReturnEligibleSource = delegate(List<FraminghamCalculationSource> framinghamCalculationSources, ReadingLabels readingLabel, int reading)
              {
                  return framinghamCalculationSources.Find(framinghamCalculationSource =>
                  {
                      if (framinghamCalculationSource.Reading == readingLabel)
                      {
                          if (framinghamCalculationSource.MinValue != null && framinghamCalculationSource.MaxValue != null)
                          {
                              if (reading >= framinghamCalculationSource.MinValue && reading <= framinghamCalculationSource.MaxValue)
                                  return true;
                          }
                          else if (framinghamCalculationSource.MinValue != null)
                          {
                              if (reading >= framinghamCalculationSource.MinValue) return true;
                          }
                          else if (framinghamCalculationSource.MaxValue != null)
                          {
                              if (reading <= framinghamCalculationSource.MaxValue) return true;
                          }
                          return false;
                      }
                      return false;
                  });
              };

            var framinghamCalculationSourceSmoker = delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.Smoker, (isSmoker ? 1 : 0));
            var framinghamCalculationSourceDiabetic = delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.Diabetes, (isDiabetic ? 1 : 0));
            var framinghamCalculationSourceAge = delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.Age, age);
            var framinghamCalculationSourceTChol = totalCholestrol != null ? delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.TotalCholestrol, totalCholestrol.Value) : null;
            var framinghamCalculationSourceLDL = ldl != null ? delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.LDL, ldl.Value) : null;
            var framinghamCalculationSourceHDL = delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.HDL, hdl);
            var framinghamCalculationSourceSystolic = delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.SystolicRight, systolic); // put in the value for systolic
            var framinghamCalculationSourceDiastolic = delegateReturnEligibleSource(framinghamCalculationSourceList, ReadingLabels.DiastolicRight, diastolic);

            int sumScore = 0;

            if (isGenderMale)
            {
                if (framinghamCalculationSourceAge != null) sumScore += framinghamCalculationSourceAge.MaleScore;

                if (framinghamCalculationSourceSmoker != null) sumScore += framinghamCalculationSourceSmoker.MaleScore;

                if (framinghamCalculationSourceDiabetic != null) sumScore += framinghamCalculationSourceDiabetic.MaleScore;
                
                if (framinghamCalculationSourceLDL != null) sumScore += framinghamCalculationSourceLDL.MaleScore;
                else if (framinghamCalculationSourceTChol != null) sumScore += framinghamCalculationSourceTChol.MaleScore;
                
                if (framinghamCalculationSourceHDL != null) sumScore += framinghamCalculationSourceHDL.MaleScore;

                if (framinghamCalculationSourceSystolic.MaleScore > framinghamCalculationSourceDiastolic.MaleScore)
                    sumScore += framinghamCalculationSourceSystolic.MaleScore;
                else
                    sumScore += framinghamCalculationSourceDiastolic.MaleScore;
                
            }
            else
            {
                if (framinghamCalculationSourceAge != null) sumScore += framinghamCalculationSourceAge.FemaleScore;

                if (framinghamCalculationSourceSmoker != null) sumScore += framinghamCalculationSourceSmoker.FemaleScore;

                if (framinghamCalculationSourceDiabetic != null) sumScore += framinghamCalculationSourceDiabetic.FemaleScore;
                
                if (framinghamCalculationSourceLDL != null) sumScore += framinghamCalculationSourceLDL.FemaleScore;
                else if (framinghamCalculationSourceTChol != null) sumScore += framinghamCalculationSourceTChol.FemaleScore;

                if (framinghamCalculationSourceHDL != null) sumScore += framinghamCalculationSourceHDL.FemaleScore;

                if (framinghamCalculationSourceSystolic.FemaleScore > framinghamCalculationSourceDiastolic.FemaleScore)
                    sumScore += framinghamCalculationSourceSystolic.FemaleScore;
                else
                    sumScore += framinghamCalculationSourceDiastolic.FemaleScore;
            }
            
            return sumScore;

        }

    }
}
