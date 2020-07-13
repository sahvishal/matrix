using System;
using Falcon.App.Core.Application.Attributes;

namespace API.Areas.Scheduling.Models
{
    [NoValidationRequired]
    public class CustomerCheckInCheckOutTimeModel
    {
        public long EventCustomerId { get; set; }
        public long AppointmentId { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
    }
}