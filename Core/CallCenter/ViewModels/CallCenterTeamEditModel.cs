using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    [NoValidationRequired]
    public class CallCenterTeamEditModel : ViewModelBase
    {
        public long Id { get; set; }

        [Display(Name = "Team Name")]
        [MaxLength(255, ErrorMessage = "Maximum {2} characters exceeded")]
        [MinLength(5, ErrorMessage = "Minimum 5 characters required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [MaxLength(2048)]
        public string Description { get; set; }

        [Display(Name = "Team Type")]
        public long TypeId { get; set; }

        public IEnumerable<OrderedPair<long, string>> AgentsMasterList { get; set; }

        public IEnumerable<OrderedPair<long, string>> Assignments { get; set; }
    }
}
