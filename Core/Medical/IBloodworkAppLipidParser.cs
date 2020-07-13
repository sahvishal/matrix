﻿using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical
{
    public interface IBloodworkAppLipidParser
    {
        string ErrorSummary { get; }
        TestResult Parse(long customerId, string xmlFilePath,TestType testType);
    }
}
