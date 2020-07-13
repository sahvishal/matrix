using System;
using System.Collections.Generic;
using API.Areas.Scheduling.Models;
using Falcon.App.Core.Scheduling.ViewModels;

namespace API.Areas.Scheduling
{
    public interface IEventCustomerBriefListService
    {
        EventCustomerBrifListModel GetList(EventCustomerListFilter filter);
        bool UpdateCheckinCheckOutTime(long eventIdCustomerId, long appointmentId, DateTime? checkInTime, DateTime? checkOutTime);
        EventCustomerConsents UpdateConsentsStatusforEventIdCustomerId(EventCustomerConsents model);
        IEnumerable<ShortPatientInfoViewModel> GetPatientsByEventyId(long eventId);
    }
}
