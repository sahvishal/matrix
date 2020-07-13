using System;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class MonarchAttestaionFormViewModel
    {
        public string MemberName { get; set; }
        public DateTime? Dob { get; set; }
        public string MemberId { get; set; }
        public DateTime ScreeningDate { get; set; }
    }
}