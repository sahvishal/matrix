using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportAwvHemoglobinFactory : IPcpResultExportAwvHemoglobinFactory
    {
        public PcpResultExportModel SetAwvHemoglobinData(PcpResultExportModel model, AwvHemaglobinTestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Hba1c != null)
            {
                if (testResult.Hba1c.Reading != null)
                    model.HemoglobinReading = testResult.Hba1c.Reading;
            }

            model.HemoglobinUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.HemoglobinCritical = PcpResultExportHelper.YesString;
            else if(!useBlankValue)
                model.HemoglobinCritical = PcpResultExportHelper.NoString;

            if (testResult.PhysicianInterpretation != null)
                model.HemoglobinPhysicianNotes = testResult.PhysicianInterpretation.Remarks;

            return model;
        }
    }
}