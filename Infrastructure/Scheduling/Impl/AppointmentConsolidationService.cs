using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories;

namespace Falcon.App.Infrastructure.Scheduling.Impl
{
    public class AppointmentConsolidationService : IAppointmentConsolidationService
    {
        public void ConsolidateAppointments()
        {
            var appointmentRepository = new AppointmentRepository();

            //appointmentRepository.ReleaseTemporarilyBookedAppointment();
        }
    }
}