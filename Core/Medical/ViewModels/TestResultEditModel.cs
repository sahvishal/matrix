using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestResultEditModel
    {
        public long TestResultId { get; set; }
        public long TestId { get; set; }
        public string Label { get; set; }

        public IEnumerable<ResultReadingEditModel> ResultReadings { get; set; }

        public IEnumerable<FindingEditModel> Findings { get; set; }

        public FindingEditModel SelectedFinding
        {
            get
            {
                if (Findings != null && Findings.Count() > 0)
                {
                    var selected = Findings.Where(f => f.IsSelected).SingleOrDefault();
                    if (selected != null) return selected;
                }
                return null;
            }
        }
        
        public int CurrentState { get; set; }
        public bool IsComplete { get; set; }
        public bool IsMarkedSelfPresent { get; set; }
        public long ConductedByOrgRoleUserId { get; set; }
    }
}