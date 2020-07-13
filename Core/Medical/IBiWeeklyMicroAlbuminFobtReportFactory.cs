using System;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IBiWeeklyMicroAlbuminFobtReportFactory
    {
        BiWeeklyMicroAlbuminFobtReportViewModel CreateModel(Customer customer,DateTime eventDate,bool fobtKit,bool microAlbuminKit,PhysicianLabTest physicianLabtest);
    }
}
