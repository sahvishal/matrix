using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Application.Repositories
{
    [DefaultImplementation(Interface = typeof(IToolTipRepository))]
    public class ToolTipRepository : PersistenceRepository, IToolTipRepository
    {
        public string GetToolTipContentByTag(ToolTipType toolTipType)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from tt in linqMetaData.ToolTip
                        where tt.Tag == toolTipType.ToString()
                        select tt.Content).SingleOrDefault();
            }
        }
    }
}
