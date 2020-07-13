﻿using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Medical
{
    public interface IPhysicianPartnerResultExportAaaFactory
    {
        PhysicianPartnerResultExportModel SetAaaData(PhysicianPartnerResultExportModel model, PpAaaTestResult testResult);
    }
}
