using System;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.CallCenter.ViewModels
{
    public class CallCenterTeamViewModel : ViewModelBase
    {
        [Hidden]
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        [Format("MM/dd/yyyy")]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified {get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public IEnumerable<string> Agents { get; set; }
    }
}
