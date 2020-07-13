namespace Falcon.App.Core.Scheduling.Domain
{
    public class Ndc
    {
        public long Id { get; set; }
        public string ProductName { get; set; }
        public string NdcCode { get; set; }
        public string Route { get; set; }
        public string Dose { get; set; }

        public string ActiveNumeratorStrength { get; set; }
        public string ActiveIngredUnit { get; set; }
        
    }
}
