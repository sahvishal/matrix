using System.Linq;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Marketing.Interfaces
{
    public interface IClickConversionReportCampaignFilter
    {
        IQueryable<VwCampaignClickConversionEntity> FilterCampaigns(IQueryable<VwCampaignClickConversionEntity> queryable);
    }
}