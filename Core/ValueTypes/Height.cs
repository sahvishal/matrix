using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.ValueTypes
{
    public class Height : Length
    {
        [IgnoreAudit]
        public string MetricHeight { get { return Meters + "m"; } }
        [IgnoreAudit]
        public string EnglishHeight { get { return Feet + "'" + Inches + "\""; } }     
  
        public Height() { }

        public Height(double feet, double inches) : base(feet, inches)
        {
        }
    }
}