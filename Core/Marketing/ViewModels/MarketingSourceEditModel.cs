using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.ViewModels;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Enum;
namespace Falcon.App.Core.Marketing.ViewModels
{
    public class MarketingSourceEditModel : ViewModelBase
    {
        [UIHint("Hidden")]
        public long Id { get; set; }

        [UIHint("ExtendedTextBox")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Description("Show Online")]
        public bool ShowOnline { get; set; }
        public IEnumerable<long> SelectedTerritories { get; set; }
        public IEnumerable<OrderedPair<long, string>> Territories { get; set; }

        public MarketingSourceEditModel(ITerritoryRepository territoryRepository)
        {
            Territories = territoryRepository.GetAllTerritoriesIdNamePair(TerritoryType.Advertiser);
        }

        public MarketingSourceEditModel()
        {
            
        }

    }
}