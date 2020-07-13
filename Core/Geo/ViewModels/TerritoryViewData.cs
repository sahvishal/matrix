namespace Falcon.App.Core.Geo.ViewModels
{
    public class TerritoryViewData
    {
        public long TerritoryId { get; set; }
        public long ParentTerritoryId { get; set; }
        public string TerritoryName { get; set; }
        public string Description { get; set; }
        public string TerritoryTypeName { get; set; }
    }
}