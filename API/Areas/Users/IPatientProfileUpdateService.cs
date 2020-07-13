using API.Areas.Users.Models;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users.ViewModels;

namespace API.Areas.Users
{
    public interface IPatientProfileUpdateService
    {
        void Save(Patient patient, long orgRoleId);

        CustomerEventDetailViewModel GetPatients(PatientSearchFilter filter, long technicianId);

        CustomerAppointmentViewModel GetPatientDetail(long eventCustomerId);
    }
}