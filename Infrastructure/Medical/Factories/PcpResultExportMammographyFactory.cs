﻿using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class PcpResultExportMammographyFactory : IPcpResultExportMammographyFactory
    {
        public PcpResultExportModel SetMammographyData(PcpResultExportModel model, MammogramTestResult testResult, bool useBlankValue = false)
        {
            model.MammographyUnabletoScreen = testResult.UnableScreenReason != null && testResult.UnableScreenReason.Count > 0 ? PcpResultExportHelper.YesString : (useBlankValue ? "" : PcpResultExportHelper.NoString);

            if ((testResult.ResultStatus != null && testResult.ResultStatus.SelfPresent) || (testResult.PhysicianInterpretation != null && testResult.PhysicianInterpretation.IsCritical))
                model.MammographyCritical = PcpResultExportHelper.YesString;
            else if (!useBlankValue)
                model.MammographyCritical = PcpResultExportHelper.NoString;

            if (testResult.Finding != null)
                model.MammographyFinding = testResult.Finding.Label;

            return model;
        }

    }
}