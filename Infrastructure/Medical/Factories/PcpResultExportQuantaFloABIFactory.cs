using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportQuantaFloABIFactory : IPcpResultExportQuantaFloABIFactory
    {
        public PcpResultExportModel SetQuantaFloABIData(PcpResultExportModel model, QuantaFloABITestResult testResult, bool useBlankValue = false)
        {
            if (testResult.Finding != null) model.QuantaFloAbiResult = testResult.Finding.Label;

            model.QuantaFloAbiUnableToScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.QuantaFloAbiCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.QuantaFloAbiCritical = PcpResultExportHelper.NoString;

            return model;
        }
    }
}