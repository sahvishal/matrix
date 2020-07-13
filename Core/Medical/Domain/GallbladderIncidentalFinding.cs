using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class GallbladderIncidentalFinding : IncidentalFinding
    {
        public SonographicAppearance Appearance { get; set; }
        public string Size { get; set; }

        public GallbladderIncidentalFinding()
        {}

        public GallbladderIncidentalFinding(long gallbladderIncidentalFindingId)
            : base(gallbladderIncidentalFindingId)
        {}
    }
}