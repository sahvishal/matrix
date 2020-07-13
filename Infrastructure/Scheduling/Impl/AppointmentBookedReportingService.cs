using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling;
using Falcon.App.Core.Scheduling.Enum;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    [DefaultImplementation]
    public class AppointmentBookedReportingService : IAppointmentBookedReportingService
    {
        private readonly IEventCustomerRepository _eventCustomerRepository;
        public AppointmentBookedReportingService(IEventCustomerRepository eventCustomerRepository)
        {
            _eventCustomerRepository = eventCustomerRepository;
        }

        public IEnumerable<AppointmentBookedChartViewModel> GetAppointmentBookedChartForLastSevenDays(AppointmentBookedChartStatus appointmentBookedType)
        {
            var eventCustomers = _eventCustomerRepository.GetAppointmentBookedChartForLastSevenDays(appointmentBookedType).ToArray();

            return new List<AppointmentBookedChartViewModel>
            {
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.Date).Count(), BookedAppointmentDate=DateTime.Now.Date.ToString("MMM dd")},
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.AddDays(-1).Date).Count(), BookedAppointmentDate=DateTime.Now.AddDays(-1).ToString("MMM dd")},
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.AddDays(-2).Date).Count(), BookedAppointmentDate=DateTime.Now.AddDays(-2).ToString("MMM dd")},
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.AddDays(-3).Date).Count(), BookedAppointmentDate=DateTime.Now.AddDays(-3).ToString("MMM dd")},
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.AddDays(-4).Date).Count(), BookedAppointmentDate=DateTime.Now.AddDays(-4).ToString("MMM dd")},
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.AddDays(-5).Date).Count(), BookedAppointmentDate=DateTime.Now.AddDays(-5).ToString("MMM dd")},
                new AppointmentBookedChartViewModel{BookedAppointmentCustomers=eventCustomers.Where(x => x.DataRecorderMetaData.DateCreated.Date == DateTime.Now.AddDays(-6).Date).Count(), BookedAppointmentDate=DateTime.Now.AddDays(-6).ToString("MMM dd")},
            };
        }
    }
}
