using System;
using System.ComponentModel;

namespace Falcon.App.Core.Scheduling.ViewModels
{
    public class HiptoAcesCrossWalkViewModel
    {
        [DisplayName("ClientID")]
        public string ClientId { get; set; }
        [DisplayName("HipID")]
        public long HipId { get; set; }
        [DisplayName("AcesID")]
        public string AcesId { get; set; }
        [DisplayName("ClientMemberID")]
        public string ClientMemberId { get; set; }
        [DisplayName("SecondaryClientMemberID")]
        public string SecondaryClientMemberId { get; set; }
    }
}
