using System;
namespace Falcon.App.Core.Users.Domain
{
    public class Technician : User
    {
        public long TechnicianId { get; set; }

        public Technician()
        { }

        public Technician(long userId)
            : base(userId)
        { }

        public bool CanDoPreAudit { get; set; }
        public bool IsTeamLead { get; set; }
        public string Pin { get; set; }
        public DateTime? PinChangeDate { get; set; }
    }
}