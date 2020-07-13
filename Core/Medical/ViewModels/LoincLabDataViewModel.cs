using System;
using System.Collections.Generic;
using Falcon.App.Core.Users.Enum;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class LoincLabDataViewModel
    {
        public long CustomerId { get; set; }

        public string Name { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public long EventId { get; set; }

        public Gender Gender { get; set; }

        public string MemberId { get; set; }

        public string Gmpi { get; set; }

        public IEnumerable<LoincLabDataModel> LabDataList { get; set; }
    }
}
