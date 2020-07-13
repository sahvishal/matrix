﻿using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPcpResultExportAwvLipidFactory
    {
        PcpResultExportModel SetAwvLipidData(PcpResultExportModel model, AwvLipidTestResult testResult, bool useBlankValue = false);
    }
}